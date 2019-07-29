using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO.Ports;

namespace XylophoneRobot
{
    public partial class frmMain : Form
    {
        #region Decleare
        //Const Declare
        const int UNIT_LENGTH = 16;    // 악보 그리는 영역에서, 최소단위 8분음표 하나를 표시하는 가로 픽셀 수
        const int UNIT_WIDTH = 15;     // 악보 그리는 영역에서, 음표 하나를 표시하는 가로 픽셀 수
        const int UNIT_HEIGHT = 55;    // 악보 그리는 영역에서, 음표 하나를 표시하는 세로 픽셀 수
        const int START_OFFSET = 20;   // 악보 그리는 영역에서, 높은음자리표가 차지하는 가로 픽셀 수
        const int DEFAULT_PGAIN = 64;  // Actuator P-Gain
        const int PACKET_LENGTH = 10;

        const int UN_SELECTED = 0;
        const int SELECTED = 1;

        // Serial Communication Part.
        string[] ports;
        bool bComOpened = false;
        bool bPlaying = false;
        int nComReceiveDelay = 20;  //엑츄에이터에서 리턴값이 있는 명령에서, 대기하는 시간(msec)
        int nComDefaultDelay = 3;   //엑츄에이터에서 리턴값이 없는 경우, 통신안정을 위해 대기하는 시간(msec)

        // Editting Flag Part.
        bool bUseKeyboard = false;      //Flag : 키보드(숫자 및 방향키)를 이용해 악보 입력 여부 설정 플래그
        bool bEditState = false;        //Flag : 키보드 단축키로 음계 입력시(뱡향키) 라디오버튼이 컨트롤을 가져가는 것을 막기 위함
        bool bViewCommMonitor = false;   //Flag : Serical Comm. Monitor View Visable 설정 플래그

        // Music Play
        int nCurIdx = -1;                                       // 음악 편집중, 현재 선택된 음표의 index
        Music music = new Music();                              // 음악을 구성하는 음들의 정보를 포함하는 클래스
        List<PictureBox> ListImage = new List<PictureBox>();    // 음계의 List들에 대응되는 UI에서 음표 Image를 관리하기 위한 List.
        XylobotProtocol controller = new XylobotProtocol();     // 로봇과 통신을 하기 위한 Protocol 정의
        private RobotSetting robotSetting = new RobotSetting(); // 로봇과 관련된 설정을 담당하는 UI Form
        private BackgroundWorker workerPlay = new BackgroundWorker();   // 음악 실행을 위한 Work Thread
        private BackgroundWorker workerPort = new BackgroundWorker();   // 시리얼 포트 연결을 위한 Work Thread
		private RobotParameter rPara = new RobotParameter();

        //공통으로 자주 사용하는 변수.
        int[] data = new int[3] { -1, -1, -1 };
        byte[] packet = new byte[PACKET_LENGTH];

        // Stop & Test 버튼을 눌렀는지 확인하는 변수
        bool bPushStopTestButton = false;

        // 불러오기 & 저장하기 관련 변수
        string FilePath;        // 파일 저장 위치        
        bool bCheckSave = true; // 저장 후 파일의 변화가 있는지 확인하는 변수

        // User control
        PaperPanel pnlCanvas1 = new PaperPanel();

        //Receive Buffer를 읽기 위한 structure. 10byte를 받으면, flag를 True로 변경하여 Receive Buffer 읽는 것을 종료함.    
        struct tReceiveData
        {
            public int counter;
            public bool flag;
            public int[] buffer;
        }
        tReceiveData tRxData = new tReceiveData();
        #endregion


        #region Application Initialize
        // ---------------------------------------------------------------------------------------------------------------
        // -- Application Initialize
        // ---------------------------------------------------------------------------------------------------------------
        public frmMain()
        {
            InitializeComponent();

            robotSetting.RobotGoPositionEvent += new RobotSetting.RobotGoPosition(RobotGoPosition_Event);
            robotSetting.RobotGetPresentPositionEvent += new RobotSetting.RobotGetPresentPosition(RobotGetPresentPosition_Event);
            robotSetting.RobotSetTorqueEnableEvent += new RobotSetting.RobotSetTorqueEnable(RobotSetTorqueEnable_Event);
            robotSetting.RobotSetGoalSpeedEvent += new RobotSetting.RobotSetGoalSpeed(RobotSetGoalSpeed_Event);
            robotSetting.RobotGetOffsetVPositionEvent += new RobotSetting.RobotGetOffsetVPosition(RobotGetOffsetVPosition_Event);
            robotSetting.RobotSetOffsetVPositionEvent += new RobotSetting.RobotSetOffsetVPosition(RobotSetOffsetVPosition_Event);
            robotSetting.RobotGetOffsetHPositionEvent += new RobotSetting.RobotGetOffsetHPosition(RobotGetOffsetHPosition_Event);
            robotSetting.RobotSetOffsetHPositionEvent += new RobotSetting.RobotSetOffsetHPosition(RobotSetOffsetHPosition_Event);
            robotSetting.RobotGetOffsetVMovingEvent += new RobotSetting.RobotGetOffsetVMoving(RobotGetOffsetVMoving_Event);
            robotSetting.RobotSetOffsetVMovingEvent += new RobotSetting.RobotSetOffsetVMoving(RobotSetOffsetVMoving_Event);

            robotSetting.RobotSetLEDEvent += new RobotSetting.RobotSetLED(RobotSetLED_Event);
            robotSetting.RobotSetPGainEvent += new RobotSetting.RobotSetPGain(RobotSetPGain_Event);
            robotSetting.RobotGetPGainEvent += new RobotSetting.RobotGetPGain(RobotGetPGain_Event);

            cbTempo.SelectedIndex = 2;          //Default 100 선택
            music.Tempo = int.Parse(cbTempo.Text);

            //Receive Buffer Read Structure 초기화
            tRxData.counter = 0;
            tRxData.flag = false;
            tRxData.buffer = new int[PACKET_LENGTH * 4];

            workerPlay.DoWork += new DoWorkEventHandler(play_DoWork);
            workerPlay.RunWorkerCompleted += new RunWorkerCompletedEventHandler(play_RunWorkerCompleted);

            workerPlay.WorkerSupportsCancellation = true;
            workerPort.DoWork += new DoWorkEventHandler(port_DoWork);
            workerPort.RunWorkerAsync();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bCheckSave == false)
            {
                if(CreateSaveMessageBox() == 2) e.Cancel = true;
            }
            if (serialPort.IsOpen)
            {
                byte[] packet = new byte[10];

                // RobotSetLED_Event(5); //LED Control

                packet = controller.Write_OperationMode(1); // 1 : Set Ready Mode
                SerialPortWrite(packet);

                serialPort.Close();
            }
        }
        #endregion

        void port_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                int nData = -1;
				int nValue = 0;

                bool bConnected = false;
                ports = SerialPort.GetPortNames();

                if (bComOpened == false)
                {
                    foreach (string strPort in ports)
                    {
                        if (serialPort.IsOpen) serialPort.Close();
                        serialPort.PortName = strPort;
                        try
                        {
                            serialPort.Open();
                            serialPort.DiscardInBuffer();
                        }
                        catch (UnauthorizedAccessException)
                        {
                            SetTextCommMoniter("UnAuthorizedAccessException: Unable to access port " + strPort);
                        }

                        if (serialPort.IsOpen)
                        {
                            if (bViewCommMonitor == true)
                                SetTextCommMoniter("[" + strPort + " Connect Test]" + "\r\n");
	                        packet = controller.Read_OperationMode();
	                        SerialPortWrite(packet);

	                        Delay(200);  // 최초 연결시, 모드 데이터를 리턴하는 명령을 보냄

                            if (tRxData.flag == true)
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    packet[i] = (byte)tRxData.buffer[i];
                                    tRxData.buffer[i] = 0;
                                }

                                tRxData.counter = 0;
                                tRxData.flag = false;
                                nData = controller.Decoding(packet, data)[0];
                                ComDebugging("RECV", packet); //For Debugging...
                            }

                            if (nData == 1 || nData == 2) // Xylobot is Ready Mode or Demo Mode
                            {
                                packet = controller.Write_OperationMode(3); // 3 : Set Basic Mode
                                SerialPortWrite(packet);

                                SetConnectionState(strPort, Color.Lime);
                                bComOpened = true;
                                SetTextCommMoniter("-----------------------------------------" + "\r\n");

                                //LWY :: 최초 연결시, 실로봇으로부터 초기필요한 값들을 읽어 와야 함.- V_Moving_Offset, V_Position_Offset, H_Position_Offset 
                                nValue = RobotGetOffsetVMoving_Event();
                                robotSetting.SetRobotParaVMovingOffset(nValue);
                                nValue = RobotGetOffsetHPosition_Event();
                                robotSetting.SetRobotParaHPositionOffset(nValue);
                                nValue = RobotGetOffsetVPosition_Event();
                                robotSetting.SetRobotParaVPositionOffset(nValue);
                                SetTextCommMoniter("-----------------------------------------" + "\r\n");

                                break;
                            }
                            else
                            {
                                serialPort.Close();
                            }
                        }
                    }
                }
                else
                {
                    foreach (string strPort in ports)
                    {
                        if (strPort == serialPort.PortName)
                        {
                            bConnected = true;
                            break;
                        }
                    }
                    if (bConnected == false)
                    {
                        if (serialPort.IsOpen)
                        {
                            serialPort.Close();
                        }
                        bComOpened = false;
                        SetConnectionState("Disconnected", Color.Gray);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        void SetTextCommMoniter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return;

            this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            txtCommMonitor.AppendText(str);
                        }));
        }

        void SetConnectionState(string str, Color clr)
        {
            if (string.IsNullOrEmpty(str))
                return;

            this.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            lblConnectState.Text = str;
                            lblConnectState.BackColor = clr;
                        }));
        }

        #region Delegate Function for Child Form Part / Actuator Command for Serial Cummnication Part 
        // ---------------------------------------------------------------------------------------------------------------
        // -- Delegate Function for Child Form Part / Actuator Command for Serial Cummnication Part 
        // ---------------------------------------------------------------------------------------------------------------

        private void SerialPortWrite(byte[] sndData)
        {
            if (serialPort.IsOpen == true)
            {
                serialPort.DiscardOutBuffer();
                serialPort.Write(sndData, 0, sndData.Length);
                ComDebugging("SEND", sndData); //For Debugging...
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(tRxData.flag == true) return;

            try
            {
                tRxData.counter = serialPort.BytesToRead;
                for (int i = 0; i < tRxData.counter; i++)
                {
                    tRxData.buffer[i] = serialPort.ReadByte();              // RX 데이터 받기
                }

                if (tRxData.buffer[0] == 0xFF && tRxData.buffer[1] == 0xFF) // 헤더 확인
                {
                    if (tRxData.counter >= 10) tRxData.flag = true;
                    else tRxData.flag = false;
                }
                else
                {
                    tRxData.counter = 0;
                    tRxData.flag = false;
                }
            }
            catch
            {
            }            
        }

        //실로봇 현재의 위치를 읽어오는 델리게이트 메소드
        private int[] RobotGetPresentPosition_Event(int id)
        {
            packet = controller.Read_PresentPosition(id);  // 0:broadcasting, 1, 2, 3
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);

            if (tRxData.flag == true)
            {
                for(int i = 0; i < PACKET_LENGTH; i++)
                {
                    packet[i] = (byte)tRxData.buffer[i];
                    tRxData.buffer[i] = 0;
                }
                tRxData.counter = 0;
                tRxData.flag = false;
                data = controller.Decoding(packet, data);
                ComDebugging("RECV", packet); //For Debugging...
            }
            return data;
        }

        //실로봇을 원하는 위치로 이동시키는 델리게이트 메소드
        private void RobotGoPosition_Event(int id, int pos1, int pos2, int pos3)
        {
            packet = controller.Write_TargetPosition(id, (ushort)pos1, (ushort)pos2, (ushort)pos3); // id : 0:broadcasting, 1, 2, 3
            SerialPortWrite(packet);
            Delay(nComDefaultDelay);
        }

        //실로봇의 토크를 Enable/Disable 시키는 델리게이트 메소드
        private void RobotSetTorqueEnable_Event(int nValue1, int nValue2, int nValue3)
        {
            packet = controller.Write_AllDevice_TorqueEnable((ushort)nValue1, (ushort)nValue2, (ushort)nValue3);
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);
        }

        //실로봇의 토크를 Enable/Disable 시키는 델리게이트 메소드
        private void RobotSetGoalSpeed_Event(int nValue1, int nValue2, int nValue3)
        {
            packet = controller.Write_AllDevice_MovingSpeed((ushort)nValue1, (ushort)nValue2, (ushort)nValue3);
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);
        }

        //실로봇이 연주하기 위해 티칭값에서 수직방향으로 Position Offset값을 읽어오는 델리게이트 메소드
        private int RobotGetOffsetVPosition_Event()
        {
            packet = controller.Read_OffsetVerticalPosition();
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);

            if (tRxData.flag == true)
            {
                for (int i = 0; i < PACKET_LENGTH; i++)
                {
                    packet[i] = (byte)tRxData.buffer[i];
                    tRxData.buffer[i] = 0;
                }
                tRxData.counter = 0;
                tRxData.flag = false;
                data = controller.Decoding(packet, data);
                ComDebugging("RECV", packet); //For Debugging...
            }
            return data[0];
        }

        //실로봇이 연주하기 위해 티칭값에서 수직방향으로 Position Offset값을 저장하는 델리게이트 메소드
        private void RobotSetOffsetVPosition_Event(int Value)
        {
            packet = controller.Write_OffsetVerticalPosition((short)Value);
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);
        }

        //실로봇이 연주하기 위해 티칭값에서 수평방향으로 Position Offset값을 읽어오는 델리게이트 메소드
        private int RobotGetOffsetHPosition_Event()
        {
            packet = controller.Read_OffsetHorizontalPosition();
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);

            if (tRxData.flag == true)
            {
                for (int i = 0; i < PACKET_LENGTH; i++)
                {
                    packet[i] = (byte)tRxData.buffer[i];
                    tRxData.buffer[i] = 0;
                }
                tRxData.counter = 0;
                tRxData.flag = false;
                data = controller.Decoding(packet, data);
                ComDebugging("RECV", packet); //For Debugging...
            }
            return data[0];
        }

        //실로봇이 연주하기 위해 티칭값에서 수평방향으로 Position Offset값을 저장하는 델리게이트 메소드
        private void RobotSetOffsetHPosition_Event(int Value)
        {
            packet = controller.Write_OffsetHorizontalPosition((short)Value);
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);
        }

        //실로봇이 연주하기 위해 수직방향으로 들어 올리는 Offset값을 읽어오는 델리게이트 메소드
        private int RobotGetOffsetVMoving_Event()
        {
            packet = controller.Read_OffsetVerticalMoving();

            SerialPortWrite(packet);
            Delay(nComReceiveDelay);

            if (tRxData.flag == true)
            {
                for (int i = 0; i < PACKET_LENGTH; i++)
                {
                    packet[i] = (byte)tRxData.buffer[i];
                    tRxData.buffer[i] = 0;
                }
                tRxData.counter = 0;
                tRxData.flag = false;
                data = controller.Decoding(packet, data);
                ComDebugging("RECV", packet); //For Debugging...
            }
            return data[0];
        }

        //실로봇이 연주하기 위해 수직방향으로 들어 올리는 Offset값을 저장하는 델리게이트 메소드
        private void RobotSetOffsetVMoving_Event(int Value)
        {
            packet = controller.Write_OffsetVerticalMoving((ushort)Value);
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);
        }

        //실로봇의 P-Gain을 설정하는 델리게이트 메소드
        private void RobotSetPGain_Event(int nValue1, int nValue2, int nValue3)
        {
            packet = controller.Write_Gain((ushort)nValue1, (ushort)nValue2, (ushort)nValue3);
            SerialPortWrite(packet);
        }

        //실로봇에 설정된 P-Gain값을 읽어오는 델리게이트 메소드
        private int[] RobotGetPGain_Event()
        {
            packet = controller.Read_Gain();
            SerialPortWrite(packet);
            Delay(nComReceiveDelay);
            Delay(nComReceiveDelay);

            if (tRxData.flag == true)
            {
                for (int i = 0; i < PACKET_LENGTH; i++)
                {
                    packet[i] = (byte)tRxData.buffer[i];
                    tRxData.buffer[i] = 0;
                }
                tRxData.counter = 0;
                tRxData.flag = false;
                data = controller.Decoding(packet, data);
                ComDebugging("RECV", packet); //For Debugging...
            }
            return data;
        }

        //실로봇의 LED 컨트롤 델리게이트 메소드 (0 : Off, 1:Red, 2:Orange, 3:Yellow, 4: Green, 5:blue, 6: Navy(Dark Blue), 7:Violet, 8:Red, 9:White)
        private void RobotSetLED_Event(int nValue)
        {
            switch(nValue)
            {
                case 0: packet = controller.Write_LEDControl(  0,   0,   0); break;
                case 1: packet = controller.Write_LEDControl(200,   0,   0); break;
                case 2: packet = controller.Write_LEDControl(200,  90,   0); break;
                case 3: packet = controller.Write_LEDControl(200, 200,   0); break;
                case 4: packet = controller.Write_LEDControl(  0, 200,   0); break;
                case 5: packet = controller.Write_LEDControl(  0,  84, 200); break;
                case 6: packet = controller.Write_LEDControl(  0,   0, 200); break;
                case 7: packet = controller.Write_LEDControl(113,   0, 200); break;
                case 8: packet = controller.Write_LEDControl(200,   0,   0); break;
                case 9: packet = controller.Write_LEDControl(100, 200, 100); break;
            }

            SerialPortWrite(packet);
        }

        //실로봇의 LED Mode 컨트롤 메소드 (0:지정색 계속 점등, 1:"번쩍", 2:대기모드(녹색 부드러운 점멸 계속)
        private void RobotSetLEDMode(int nValue1)
        {

        }

        private void ComDebugging(string sMsg, byte[] rcvData)
        {
            if (bViewCommMonitor == false) return;
            string tmpString = sMsg + "[" + rcvData.Length + "]";
            for (int i = 0; i < rcvData.Length; i++) tmpString = tmpString + " , " + rcvData[i];

            this.Invoke(new MethodInvoker(
                delegate ()
                {
                    txtCommMonitor.AppendText(tmpString + "\r\n");
                }));
        }


        private void btnDebugClear_Click(object sender, EventArgs e)
        {
            txtCommMonitor.Clear();
        }


        private void btnViewCommMonitor_Click(object sender, EventArgs e)
        {
            bViewCommMonitor = !bViewCommMonitor;
            pnlCommMonitor.Visible = bViewCommMonitor;

            if (bViewCommMonitor)
            {
                btnViewCommMonitor.Text = "On";
                btnViewCommMonitor.BackColor = Color.Lime;
            }
            else
            {
                btnViewCommMonitor.Text = "Off";
                btnViewCommMonitor.BackColor = Color.WhiteSmoke;
            }
        }
        #endregion


        #region Music Edit(음 추가, 피치 변경, 음길이 변경, 선택 등) Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Music Edit(음 추가, 피치 변경, 음길이 변경, 선택 등) Part
        // ---------------------------------------------------------------------------------------------------------------

        //음악 속도 변경  ----------------------------------------------------------------------------------
        private void cbTempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            music.Tempo = int.Parse(cbTempo.Text);
            robotSetting.Tempo = music.Tempo;
        }

        //악보 편집을 위해 음계 모양의 라디오 버튼을 클릭하면 발생하는 Events ------------------------------
        private void rbScale_CheckedChanged(object sender, EventArgs e)
        {
            if (bEditState == false) //Flag : 키보드 단축키로 음계 입력시 라디오버튼이 컨트롤을 가져가는 것을 막기 위함
            {
                int nScale = 0;
                //5선악보용 음 추가 라디오 버튼 클릭시, 볼드처리 유무를 표시하기 위해 이미지를 변경해 줌
                rbScaleC.ImageIndex = (Object.ReferenceEquals(sender, rbScaleC))        ?  1 :  0;
                rbScaleD.ImageIndex = (Object.ReferenceEquals(sender, rbScaleD))        ?  3 :  2;
                rbScaleE.ImageIndex = (Object.ReferenceEquals(sender, rbScaleE))        ?  5 :  4;
                rbScaleF.ImageIndex = (Object.ReferenceEquals(sender, rbScaleF))        ?  7 :  6;
                rbScaleG.ImageIndex = (Object.ReferenceEquals(sender, rbScaleG))        ?  9 :  8;
                rbScaleA.ImageIndex = (Object.ReferenceEquals(sender, rbScaleA))        ? 11 : 10;
                rbScaleB.ImageIndex = (Object.ReferenceEquals(sender, rbScaleB))        ? 13 : 12;
                rbScaleHighC.ImageIndex = (Object.ReferenceEquals(sender, rbScaleHighC))? 15 : 14;
                rbScaleP.ImageIndex = (Object.ReferenceEquals(sender, rbScaleP))        ? 17 : 16;

                //숫자악보용 음 추가 라디오 버튼 클릭시, 볼드처리 유무를 표시하기 위해 이미지를 변경해 줌
                rbScale1.ImageIndex =    (Object.ReferenceEquals(sender, rbScale1))     ?  1 :  0;
                rbScale2.ImageIndex =    (Object.ReferenceEquals(sender, rbScale2))     ?  3 :  2;
                rbScale3.ImageIndex =    (Object.ReferenceEquals(sender, rbScale3))     ?  5 :  4;
                rbScale4.ImageIndex =    (Object.ReferenceEquals(sender, rbScale4))     ?  7 :  6;
                rbScale5.ImageIndex =    (Object.ReferenceEquals(sender, rbScale5))     ?  9 :  8;
                rbScale6.ImageIndex =    (Object.ReferenceEquals(sender, rbScale6))     ? 11 : 10;
                rbScale7.ImageIndex =    (Object.ReferenceEquals(sender, rbScale7))     ? 13 : 12;
                rbScaleDot1.ImageIndex = (Object.ReferenceEquals(sender, rbScaleDot1))  ? 15 : 14;
                rbScale0.ImageIndex =    (Object.ReferenceEquals(sender, rbScale0))     ? 17 : 16;

                //클릭된 라디오 버튼의 값을 1~9까지 설정함 (1~8:도,레,미,파,솔,라,시,도, 9:쉼표)
                if (Object.ReferenceEquals(sender, rbScaleC)     || Object.ReferenceEquals(sender, rbScale1))    nScale = 1;
                if (Object.ReferenceEquals(sender, rbScaleD)     || Object.ReferenceEquals(sender, rbScale2))    nScale = 2;
                if (Object.ReferenceEquals(sender, rbScaleE)     || Object.ReferenceEquals(sender, rbScale3))    nScale = 3;
                if (Object.ReferenceEquals(sender, rbScaleF)     || Object.ReferenceEquals(sender, rbScale4))    nScale = 4;
                if (Object.ReferenceEquals(sender, rbScaleG)     || Object.ReferenceEquals(sender, rbScale5))    nScale = 5;
                if (Object.ReferenceEquals(sender, rbScaleA)     || Object.ReferenceEquals(sender, rbScale6))    nScale = 6;
                if (Object.ReferenceEquals(sender, rbScaleB)     || Object.ReferenceEquals(sender, rbScale7))    nScale = 7;
                if (Object.ReferenceEquals(sender, rbScaleHighC) || Object.ReferenceEquals(sender, rbScaleDot1)) nScale = 8;
                if (Object.ReferenceEquals(sender, rbScaleP)     || Object.ReferenceEquals(sender, rbScale0))    nScale = 9;

                //클릭된 라디오 버튼에 해당하는 음을 기본값 4분음표로 표시해 줌 
                AddScale(nScale, 2);  //para1 : 음계(도,레,미,...) , para2 : 음 길이(1:8분음표, 2:4분음표, 3:점4분음표, 4:2분음표, 6: 점2분음표, 8:온음표)
            }
            bEditState = false;
        }

        // -- 하나의 음을 추가하고, 악보에 표시함 -----------------------------------------------------------
        private void AddScale(int nScale, int nScaleLen)
        {
            int nOldIdx = nCurIdx;
            nCurIdx = nCurIdx + 1;

            music.AddScale(nCurIdx, nScale, nScaleLen);

            PictureBox pb = new PictureBox();
            pb.Size = new Size(UNIT_WIDTH, UNIT_HEIGHT);
            pb.Click += new EventHandler(Scale_Click);  //동적으로 생성된 PictureBox 컨트롤에 클릭이벤트 추가
            pb.Image = ScaleImageMapping(nCurIdx, SELECTED);   //para1 : Index, para2 : 선택상태(0:선택안됨(UN_SELECTED), 1:선택됨(SELECTED))
            ListImage.Insert(nCurIdx, pb);
            ListImage[nCurIdx].Location = CalculateScaleLocation(nCurIdx);
            pnlCanvas1.Controls.Add(ListImage[nCurIdx]);

            //이전 선택된 음표의 상태를 Selected에서 Unselected로 변경.
            if (nOldIdx >= 0) ListImage[nOldIdx].Image = ScaleImageMapping(nOldIdx, UN_SELECTED);

            bCheckSave = false;
            refreshOtherScales(nCurIdx);
        }

        // -- 선택된 음의 높이를 높임 -----------------------------------------------------------------------
        private void btnPitchUp_Click(object sender, EventArgs e)
        {
            music.SetPitchUp(nCurIdx);
            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
        }

        // -- 선택된 음의 높이를 낮춤 -----------------------------------------------------------------------
        private void btnPitchDown_Click(object sender, EventArgs e)
        {
            music.SetPitchDown(nCurIdx);
            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
        }

        // -- 선택된 음의 길이를 높임 -----------------------------------------------------------------------
        private void btnLengthUp_Click(object sender, EventArgs e)
        {
            music.SetLengthUp(nCurIdx);
            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
            refreshOtherScales(nCurIdx);
        }

        // -- 선택된 음의 길이를 낮춤 -----------------------------------------------------------------------
        private void btnLengthDown_Click(object sender, EventArgs e)
        {
            music.SetLengthDown(nCurIdx);
            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
            refreshOtherScales(nCurIdx);
        }

        // -- 악보에서 클릭된 위치정보를 통해 선택된 음을 알아냄 --------------------------------------------
        private void Scale_Click(object sender, EventArgs e)
        {
            int nOldIdx = -1;
            for (int nIdx = 0; nIdx < music.GetMusicScaleCount(); nIdx++)
            {
                if (Object.ReferenceEquals(sender, ListImage[nIdx]))
                {
                    nOldIdx = nCurIdx;
                    nCurIdx = nIdx;
                    break;
                }
            }
            ListImage[nOldIdx].Image = ScaleImageMapping(nOldIdx, UN_SELECTED);
            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
        }

        // -- 음추가, 길이 변경등에 따라, 나머지 음계를 다시 refresh 함 -------------------------------------
        private void refreshOtherScales(int Idx)
        {
            if (Idx < 0) return;

            int nNum = 0;
            for (nNum = Idx; nNum < music.GetMusicScaleCount(); nNum++)
            {
                ListImage[nNum].Location = CalculateScaleLocation(nNum);
            }
        }

        // -- 선택된 음계를 표시하기 위한 X,Y좌표를 계산함 --------------------------------------------------
        private Point CalculateScaleLocation(int Idx)
        {
            int posX = 0, posY = 0;
            float CurScaleLocation = music.GetMusicScaleLocation(Idx);

            posX = START_OFFSET + (int)((CurScaleLocation * UNIT_LENGTH) % (UNIT_LENGTH * 32));  // 4/4박자의 경우, 한줄은 8분음표 32개 기준함.
            posY = (int)((CurScaleLocation * UNIT_LENGTH) / (UNIT_LENGTH * 32)) * UNIT_HEIGHT;   //

            if (posY >= UNIT_HEIGHT * 8)        // 악보는 8줄이 있음 
            {
                posY = posY - UNIT_HEIGHT * 8;
                posX = posX + 546;              // 우측 악보는 546픽셀만큼 떨어져 있음
            }
            return new Point(posX, posY);
        }

        // -- 음계 및 음 길이에 해당하는 이미지를 선택함 ----------------------------------------------------
        private Image ScaleImageMapping(int nIdx, int nState) //para1 : 음높이, para2 : 음길이 Index, para3 : 선택상태(0:선택안됨, 1:선택됨)
        {
            Image image = null;
            int nScale = music.GetMusicScale(nIdx);

            switch (music.GetMusicScaleLen(nIdx))
            {
                case 1: image = iListScaleLen0.Images[(nScale - 1) * 2 + nState]; break;
                case 2: image = iListScaleLen1.Images[(nScale - 1) * 2 + nState]; break;
                case 3: image = iListScaleLen2.Images[(nScale - 1) * 2 + nState]; break;
                case 4: image = iListScaleLen3.Images[(nScale - 1) * 2 + nState]; break;
                case 6: image = iListScaleLen4.Images[(nScale - 1) * 2 + nState]; break;
                case 8: image = iListScaleLen5.Images[(nScale - 1) * 2 + nState]; break;
            }
            return image;
        }
        #endregion


        #region Command Button Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Command Button Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- 선택된 음을 삭제함 ----------------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nCurIdx < 0) return;

            ListImage[nCurIdx].Dispose();   //UI상에서 이미지를 삭제함
            ListImage.RemoveAt(nCurIdx);    //UI상에서 이미지를 삭제함
            music.RemoveScaleAt(nCurIdx);

            //상황 1 : 악보에 음계가 모두 사자짐
            if (music.GetMusicScaleCount() == 0)
            {
                nCurIdx = -1;
            }
            //상황 2 : 악보의 음계중 마지막 음계가 삭제됨
            else if (nCurIdx == music.GetMusicScaleCount())
            {
                nCurIdx = nCurIdx - 1;
                ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
            }
            //상황 3 : 악보의 음계중 중간 음계가 삭제됨
            else
            {
                ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
                refreshOtherScales(nCurIdx);
            }

            bCheckSave = false;
        }


        // -- 모든 음을 삭제함 ------------------------------------------------------------------------------
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (nCurIdx < 0) return;

            pnlCanvas1.Invalidate();
            for (int nNum = music.GetMusicScaleCount() - 1; nNum >= 0; nNum--)
            {
                ListImage[nNum].Dispose();
                ListImage[nNum].Image = null;

                ListImage.RemoveAt(nNum);
                music.RemoveScaleAt(nNum);
            }
            nCurIdx = -1;
            bCheckSave = false;
        }


        // -- Robot Setting Form을 표시함 -------------------------------------------------------------------
        private void btnRobotSetting_Click(object sender, EventArgs e)
        {
            robotSetting.Owner = this;
            robotSetting.ShowDialog();
        }


        // -- 새로운 음악 만들기 ----------------------------------------------------------------------------
        private void btnNewMusic_Click(object sender, EventArgs e)
        {
            txtMusicTitle.Text = "No Name";
            btnDeleteAll.PerformClick();
            bCheckSave = false;
        }


        // -- 음악을 파일에서 읽어오고, UI에 악보를 표시함 --------------------------------------------------
        private void btnLoadMusic_Click(object sender, EventArgs e)
        {
            // --- 저장 파일이 있을 경우 저장 메시지 박스 생성
            if (bCheckSave == false)
            {
                CreateSaveMessageBox();
            }

            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = null;
                FilePath = openFileDialog.FileName;
                music.LoadMusic(FilePath);

                // UI에 제목, 박자표, 빠르기 적용
                txtMusicTitle.Text = music.MusicTitle;
                cbTempo.Text = music.Tempo.ToString();

                pnlCanvas1.Controls.Clear();

                for (int nNum = 0; nNum < music.GetMusicScaleCount(); nNum++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(UNIT_WIDTH, UNIT_HEIGHT);
                    pb.Click += new EventHandler(Scale_Click);  //동적으로 생성된 PictureBox 컨트롤에 클릭이벤트 추가
                    pb.Image = ScaleImageMapping(nNum, UN_SELECTED);      //para1 : 음높이, para3 : 선택상태(0(UN_SELECTED):선택안됨, 1(SELECTED):선택됨)
                    ListImage.Insert(nNum, pb);
                    ListImage[nNum].Location = CalculateScaleLocation(nNum);
                    pnlCanvas1.Controls.Add(ListImage[nNum]);
                }
                nCurIdx = 0;
                ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);   //맨 첫음을 선택된 상태로.
                bCheckSave = true;
            }
        }


        // -- 음악을 파일로 저장함 --------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMusic();
        }

        private void SaveMusic()
        {
            music.MusicTitle = txtMusicTitle.Text;

            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(FilePath == null) FilePath = saveFileDialog.FileName;
                music.SaveMusic(FilePath);
                bCheckSave = true;
            }
        }

        private int CreateSaveMessageBox()
        {
            frmMain frm = new frmMain();
            DialogResult saveQuestion;
            int result = 0;

            if (FilePath != null) saveQuestion = MessageBox.Show("변경 내용을 " + FilePath + "에 저장하시겠습니까?", frm.Text, MessageBoxButtons.YesNoCancel);
            else saveQuestion = MessageBox.Show("변경 내용을 " + txtMusicTitle.Text + "에 저장하시겠습니까?", frm.Text, MessageBoxButtons.YesNoCancel);

            if (saveQuestion == DialogResult.Yes)
            {
                SaveMusic();
                result = 0;
            }
            else if (saveQuestion == DialogResult.No)
            {
                result = 1;
            }
            else if (saveQuestion == DialogResult.Cancel)
            {
                result = 2;
            }

            return result;
        }
        #endregion


        #region Music Play / Stop Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Music Play / Stop Part
        // ---------------------------------------------------------------------------------------------------------------

        // -- 음악을 처음부터 플레이 함 ---------------------------------------------------------------------
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (nCurIdx < 0) return;

            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, UN_SELECTED);
            nCurIdx = 0;

            workerPlay.RunWorkerAsync();

            btnTestPlay.BackColor = Color.Gray;
            btnTestPlay.Enabled = false;

            btnPlay.BackColor = Color.Lime;
            btnPlay.Enabled = false;

            btnStop.BackColor = Color.White;
            btnStop.Enabled = true;
        }


        // -- 음악을 현재 위치부터 플레이 함 ----------------------------------------------------------------
        private void btnTestPlay_Click(object sender, EventArgs e)
        {
            bPushStopTestButton = true;
            if (nCurIdx < 0) return;

            workerPlay.RunWorkerAsync();

            btnTestPlay.BackColor = Color.Yellow;
            btnTestPlay.Enabled = false;

            btnPlay.BackColor = Color.Gray;
            btnPlay.Enabled = false;

            btnStop.BackColor = Color.White;
            btnStop.Enabled = true;
        }

        // -- 음악을 처음부터 플레이 ---------------------------------------------------
        void play_DoWork(object sender, DoWorkEventArgs e)
        {
            int StartIdx = nCurIdx;
            int ReadyIdx = 0;
            ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, UN_SELECTED);

            //연주를 시작하는 첫음이 쉼표이면, 그 다음 음의 음높이를 얻어옴
            ReadyIdx = music.GetMusicScale(StartIdx);
            if (ReadyIdx == 9) ReadyIdx = music.GetNextMusicScale(StartIdx);

            // 연주를 시작함.
            bPlaying = true;

            robotSetting.ReadyToPlay(ReadyIdx);

            for (int nNum = StartIdx; nNum < music.GetMusicScaleCount(); nNum++)
            {
                ListImage[nNum].Image = ScaleImageMapping(nNum, 1);
                if (nNum > 0) ListImage[nNum - 1].Image = ScaleImageMapping(nNum - 1, UN_SELECTED);

                robotSetting.Play(music.GetMusicScale(nNum), music.GetMusicScaleLen(nNum), music.GetNextMusicScale(nNum));
                nCurIdx = nNum;

                if (bPlaying == false || bComOpened == false) break;
            }

            if (nCurIdx == (music.GetMusicScaleCount() - 1) && (chkUseEffect.Checked == true))
            {
                robotSetting.PlayEnding(); //연주의 마지막 음을 연주하면, Effect를 실행함
            }
        }

        // -- 음악 종료 ---------------------------------------------------
        void play_RunWorkerCompleted(object o, RunWorkerCompletedEventArgs e)
        {
            // 연주를 끝냄.
            RobotSetLED_Event(4); //LED Control
            StopMusic();
            if(bPushStopTestButton == false)
            {
                RobotGoPosition_Event(0, 512, 423, 294);
            }
            bPushStopTestButton = false;
        }

        // -- 음악을 멈춤 -----------------------------------------------------------------------------------
        private void btnStop_Click(object sender, EventArgs e)
        {
            bPushStopTestButton = true;
            StopMusic();
        }
        #endregion

        private void StopMusic()
        {
            bPlaying = false;

            btnTestPlay.BackColor = Color.White;
            btnTestPlay.Enabled = true;

            btnPlay.BackColor = Color.White;
            btnPlay.Enabled = true;

            btnStop.BackColor = Color.Gray;
            btnStop.Enabled = false;
        }

        #region Keyboard Editing Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Keyboard Editing Part
        // ---------------------------------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bEditState = true;  //Flag : 키보드 단축키로 음계 입력시 라디오버튼이 컨트롤을 가져가는 것을 막기 위함

            if (bUseKeyboard == true)
            {
                switch (keyData)
                {
                    case Keys.Down:
                        music.SetPitchDown(nCurIdx);
                        ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
                        break;
                    case Keys.Up:
                        music.SetPitchUp(nCurIdx);
                        ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
                        break;
                    case Keys.Right:
                        music.SetLengthUp(nCurIdx);
                        ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
                        refreshOtherScales(nCurIdx);
                        break;
                    case Keys.Left:
                        music.SetLengthDown(nCurIdx);
                        ListImage[nCurIdx].Image = ScaleImageMapping(nCurIdx, SELECTED);
                        refreshOtherScales(nCurIdx);
                        break;
                    case Keys.D1:
                    case Keys.NumPad1:
                        AddScale(1, 2);
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        AddScale(2, 2);
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                        AddScale(3, 2);
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                        AddScale(4, 2);
                        break;
                    case Keys.D5:
                    case Keys.NumPad5:
                        AddScale(5, 2);
                        break;
                    case Keys.D6:
                    case Keys.NumPad6:
                        AddScale(6, 2);
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                        AddScale(7, 2);
                        break;
                    case Keys.D8:
                    case Keys.NumPad8:
                        AddScale(8, 2);
                        break;
                    case Keys.D9:
                    case Keys.NumPad9:
                        AddScale(9, 2);
                        break;
                    case Keys.Delete:
                    case Keys.Back:
                        btnDelete.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, Keys.Space);
        }

        private void btnUseKeyboard_Click(object sender, EventArgs e)
        {
            bUseKeyboard = !bUseKeyboard;

            if(bUseKeyboard)
            {
                btnUseKeyboard.Text = "On";
                btnUseKeyboard.BackColor = Color.Lime;
            }
            else
            {
                btnUseKeyboard.Text = "Off";
                btnUseKeyboard.BackColor = Color.WhiteSmoke;
            }
        }
        #endregion


        private void Delay(long interval)
        {
            long timeGap = 0;
            long startTime = 0;
            long currentTime = 0;

            startTime = System.DateTime.Now.Ticks;

            while (tRxData.flag == false)
            {
                currentTime = System.DateTime.Now.Ticks;
                timeGap = (currentTime - startTime) / 10000; // timeGap = 1 milliseconds
                if (timeGap > interval)
                {
                    return;
                }
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Create panel
            pnlCanvas1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            pnlCanvas1.BackgroundImage = Properties.Resources.paper;
            pnlCanvas1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            pnlCanvas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCanvas1.Location = new System.Drawing.Point(10, 136);
            pnlCanvas1.Name = "pnlCanvas1";
            pnlCanvas1.Size = new System.Drawing.Size(1090, 440);
            pnlCanvas1.TabIndex = 0;

            this.Controls.Add(pnlCanvas1);
        }
    }
}
