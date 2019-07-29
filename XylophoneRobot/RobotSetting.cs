using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;

namespace XylophoneRobot
{
    public partial class RobotSetting : Form
    {
        #region Decleare
        public delegate void RobotGoPosition(int nAxis, int nValue1, int nValue2, int nValue3);
        public delegate void RobotSetTorqueEnable(int nValue1, int nValue2, int nValue3);
        public delegate int[] RobotGetPresentPosition(int nAxis);
        public delegate void RobotSetGoalSpeed(int nValue1, int nValue2, int nValue3);
        public delegate int  RobotGetOffsetVPosition();
        public delegate void RobotSetOffsetVPosition(int nValue);
        public delegate int  RobotGetOffsetHPosition();
        public delegate void RobotSetOffsetHPosition(int nValue);
        public delegate int  RobotGetOffsetVMoving();
        public delegate void RobotSetOffsetVMoving(int nValue);
        public delegate void RobotSetLED(int nValue);

        public delegate void RobotSetPGain(int nValue1, int nValue2, int nValue3);
        public delegate int[] RobotGetPGain();

        public event RobotGoPosition RobotGoPositionEvent;
        public event RobotSetTorqueEnable RobotSetTorqueEnableEvent;
        public event RobotGetPresentPosition RobotGetPresentPositionEvent;
        public event RobotSetGoalSpeed RobotSetGoalSpeedEvent;
        public event RobotGetOffsetVPosition RobotGetOffsetVPositionEvent;
        public event RobotSetOffsetVPosition RobotSetOffsetVPositionEvent;
        public event RobotGetOffsetHPosition RobotGetOffsetHPositionEvent;
        public event RobotSetOffsetHPosition RobotSetOffsetHPositionEvent;
        public event RobotGetOffsetVMoving   RobotGetOffsetVMovingEvent;
        public event RobotSetOffsetVMoving   RobotSetOffsetVMovingEvent;
        public event RobotSetLED RobotSetLEDEvent;

        public event RobotSetPGain RobotSetPGainEvent;
        public event RobotGetPGain RobotGetPGainEvent;


        const int ROBOTMAXSPEED     = 1023;
        const int ROBOTNORMALSPEED  =  300;
        const int BROADCAST_ID      =    0;

        public double[] Ang = new double[3] { 0.0, 0.0, 0.0 };
        public double[] Pos = new double[3] { 0.0, 0.0, 0.0 };

        public int[] TargetAngle = new int[3] { 0, 0, 0 };
        public int[] TempAngle = new int[3] { 0, 0, 0 };
        public int[] OldAngle = new int[3] { 0, 0, 0 };

        public int Tempo;

        int nComReceiveDelay = 10;  //엑츄에이터에서 리턴값이 있는 명령에서, 대기하는 시간(msec)
        int nComDefaultDelay = 3;   //엑츄에이터에서 리턴값이 없는 경우, 통신안정을 위해 대기하는 시간(msec)

        int nRobotSpeed = ROBOTNORMALSPEED;

        private bool bPositionMonitor = false;

        private RobotParameter rPara;
        #endregion


        #region Initialize Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Initialize Part
        // ---------------------------------------------------------------------------------------------------------------

        //Initialize Part.-------------------------------------------------------------
        public RobotSetting()
        {
            InitializeComponent();
            rPara = new RobotParameter();
        }

        private void RobotSetting_Load(object sender, EventArgs e)
        {
            int[] nPos = new int[3] { 0, 0, 0 }; 

            scrAxis1.Minimum = rPara.RangeMin[0]; scrAxis1.Maximum = rPara.RangeMax[0];
            scrAxis2.Minimum = rPara.RangeMin[1]; scrAxis2.Maximum = rPara.RangeMax[1];
            scrAxis3.Minimum = rPara.RangeMin[2]; scrAxis3.Maximum = rPara.RangeMax[2];
                        
            txtVPositionOffset.Text = rPara.V_Position_Offset.ToString();
            txtHPositionOffset.Text = rPara.H_Position_Offset.ToString();         

            nPos = this.RobotGetPresentPositionEvent(BROADCAST_ID);

            if ((nPos[0] >= scrAxis1.Minimum) && (nPos[0] <= scrAxis1.Maximum))
            {
                lblAxis1.Text = nPos[0].ToString();
                scrAxis1.Value = nPos[0];
            }
            if ((nPos[1] >= scrAxis2.Minimum) && (nPos[1] <= scrAxis2.Maximum))
            {
                lblAxis2.Text = nPos[1].ToString();
                scrAxis2.Value = nPos[1];
            }
            if ((nPos[2] >= scrAxis3.Minimum) && (nPos[2] <= scrAxis3.Maximum))
            {
                lblAxis3.Text = nPos[2].ToString();
                scrAxis3.Value = nPos[2];
            }
            
            SetPassiveMode(false);
        }

        private void RobotSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetPassiveMode(false);
        }
        #endregion


        #region 외부로부터 호출되는 메소드 Part
        // ---------------------------------------------------------------------------------------------------------------
        public void SetRobotParaVPositionOffset(int nValue)
        {
            rPara.V_Position_Offset = nValue;
        }

        public void SetRobotParaHPositionOffset(int nValue)
        {
            rPara.H_Position_Offset = nValue;
        }

        public void SetRobotParaVMovingOffset(int nValue)
        {
            rPara.V_Moving_Offset = nValue;
        }
        // ---------------------------------------------------------------------------------------------------------------
        #endregion


        #region Robot Parameter Read/Write Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Robot Parameter Read/Write Part
        // ---------------------------------------------------------------------------------------------------------------

        //실로봇으로 부터 3개의 설정값을 읽어옴 -------------------------------------------------------------
        private void btnRobotParaReload_Click(object sender, EventArgs e)
        {
            //실로봇으로 부터 3개의 설정값을 읽어옴
            rPara.V_Position_Offset = this.RobotGetOffsetVPositionEvent();
            rPara.H_Position_Offset = this.RobotGetOffsetHPositionEvent();

            txtVPositionOffset.Text = rPara.V_Position_Offset.ToString();
            txtHPositionOffset.Text = rPara.H_Position_Offset.ToString();
        }

        //3개의 설정값을 실로봇에 설정함 --------------------------------------------------------------------
        private void btnRobotParaAdapt_Click(object sender, EventArgs e)
        {
            rPara.V_Position_Offset = int.Parse(txtVPositionOffset.Text);
            rPara.H_Position_Offset = int.Parse(txtHPositionOffset.Text);

            this.RobotSetOffsetVPositionEvent(rPara.V_Position_Offset);
            Delay(nComDefaultDelay);
            this.RobotSetOffsetHPositionEvent(rPara.H_Position_Offset);
        }
        #endregion


        #region Robot Joging & Home/Teaching Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Robot Joging & Home/Teaching Part
        // ---------------------------------------------------------------------------------------------------------------

        //Robot Axis1 Joging --------------------------------------------------------------------------------
        private void scrAxis1_Scroll(object sender, ScrollEventArgs e)
        {
            SetPassiveMode(false);
            lblAxis1.Text = scrAxis1.Value.ToString();
            this.RobotGoPositionEvent(1, scrAxis1.Value, 0, 0);
        }

        //Robot Axis2 Joging --------------------------------------------------------------------------------
        private void scrAxis2_Scroll(object sender, ScrollEventArgs e)
        {
            SetPassiveMode(false);
            lblAxis2.Text = scrAxis2.Value.ToString();
            this.RobotGoPositionEvent(2, scrAxis2.Value, 0 , 0);
        }

        //Robot Axis3 Joging --------------------------------------------------------------------------------
        private void scrAxis3_Scroll(object sender, ScrollEventArgs e)
        {
            SetPassiveMode(false);
            lblAxis3.Text = scrAxis3.Value.ToString();
            this.RobotGoPositionEvent(3, scrAxis3.Value, 0, 0);
        }

        //Torque Set : true = Passive Mode / false = Active Mode ---------------------------------------------
        private void SetPassiveMode(bool bSet)
        {
            bPositionMonitor = bSet;
            tmrPositionMonitor.Enabled = bSet;
            Delay(nComDefaultDelay);
        }

        //Robot Torque Off -----------------------------------------------------------------------------------
        private void btnTorqueOff_Click(object sender, EventArgs e)
        {
            this.RobotSetTorqueEnableEvent(0, 0, 0);
            SetPassiveMode(true);
        }


        //Robot Torque On -----------------------------------------------------------------------------------
        private void btnTorqueOn_Click(object sender, EventArgs e)
        {
            this.RobotSetTorqueEnableEvent(1, 1, 1);
            SetPassiveMode(false);
        }


        //Go Home -------------------------------------------------------------------------------------------
        private void btnHome_Click(object sender, EventArgs e)
        {
            SetPassiveMode(false);

            nRobotSpeed = ROBOTNORMALSPEED;
            this.RobotSetGoalSpeedEvent(nRobotSpeed, nRobotSpeed, nRobotSpeed);
            Delay(nComReceiveDelay);

            this.RobotGoPositionEvent(BROADCAST_ID, rPara.OriginVal[0], rPara.OriginVal[1], rPara.OriginVal[2]);
            Delay(nComDefaultDelay);
        }
        

        //Passive Mode Timer Part(현재 위치값 읽음) ---------------------------------------------------------
        private void tmrPositionMonitor_Tick(object sender, EventArgs e)
        {
            int[] nPos = new int[3] { 0, 0, 0 };

            nPos = this.RobotGetPresentPositionEvent(BROADCAST_ID);

            if ((nPos[0] >= scrAxis1.Minimum) && (nPos[0] <= scrAxis1.Maximum))
            {
                lblAxis1.Text = nPos[0].ToString();
                scrAxis1.Value = nPos[0];
            }
            if ((nPos[1] >= scrAxis2.Minimum) && (nPos[1] <= scrAxis2.Maximum))
            {
                lblAxis2.Text = nPos[1].ToString();
                scrAxis2.Value = nPos[1];
            }
            if ((nPos[2] >= scrAxis3.Minimum) && (nPos[2] <= scrAxis3.Maximum))
            {
                lblAxis3.Text = nPos[2].ToString();
                scrAxis3.Value = nPos[2];
            }
        }
        #endregion


        #region Command Button Part (한음씩 쳐보기)
        // ---------------------------------------------------------------------------------------------------------------
        // -- Command Button Part (한음씩 쳐보기)
        // ---------------------------------------------------------------------------------------------------------------
        private void btnToneC_Click(object sender, EventArgs e)
        {
            TestPlay(1);
        }

        private void btnToneD_Click(object sender, EventArgs e)
        {
            TestPlay(2);
        }

        private void btnToneE_Click(object sender, EventArgs e)
        {
            TestPlay(3);
        }

        private void btnToneF_Click(object sender, EventArgs e)
        {
            TestPlay(4);
        }

        private void btnToneG_Click(object sender, EventArgs e)
        {
            TestPlay(5);
        }

        private void btnToneA_Click(object sender, EventArgs e)
        {
            TestPlay(6);
        }

        private void btnToneB_Click(object sender, EventArgs e)
        {
            TestPlay(7);
        }

        private void btnToneC_high_Click(object sender, EventArgs e)
        {
            TestPlay(8);
        }
        #endregion


        #region Music Play Part 
        // ---------------------------------------------------------------------------------------------------------------
        // -- Music Play Part 
        // ---------------------------------------------------------------------------------------------------------------
        //한음씩 연주해 봄
        public void TestPlay(int nScale)
        {
            Play(nScale, 1, 9);  //nNextScale을 쉼표(9)로 하여, 한음만 연주할때 사용.
            this.RobotSetLEDEvent(4); //LED Control
        }

        //한 음을 연주함
        public void Play(int nScale, int nLen, int nNextScale)
        {
            long nTotalInterval = 0;
            long TimeGap = 0;
            long InitStartTime = 0;
            long CurStartTime = 0;
            long CurrentTime = 0;
            long nTmpSleepTime = 0;

            InitStartTime = System.DateTime.Now.Ticks;
            nTotalInterval = (int)(60000f / (float)Tempo * (float)nLen / 2.0f);

            TargetAngle[0] = (int)(rPara.Angle[nScale, 0] / (rPara.ANGLE_RATIO * rPara.Dir[0]) + rPara.OriginVal[0]);
            TargetAngle[1] = (int)(rPara.Angle[nScale, 1] / (rPara.ANGLE_RATIO * rPara.Dir[1]) + rPara.OriginVal[1]);
            TargetAngle[2] = (int)(rPara.Angle[nScale, 2] / (rPara.ANGLE_RATIO * rPara.Dir[2]) + rPara.OriginVal[2]);

            if (nScale == 9) // 쉼표
            {
                //다음 음 위치로 이동함
                TargetAngle[0] = (int)(rPara.Angle[nNextScale, 0] / (rPara.ANGLE_RATIO * rPara.Dir[0]) + rPara.OriginVal[0]) + rPara.H_Position_Offset;
                this.RobotGoPositionEvent(1, TargetAngle[0], 0, 0);
            }
            else
            {
                //[Step1] 목표음계 위쪽으로 이동 (시간 : 수평 이동 시간(rPara.H_Moving_Time) - 약 80msce)
                CurStartTime = System.DateTime.Now.Ticks;
                TempAngle[0] = TargetAngle[0] + rPara.H_Position_Offset;
                TempAngle[1] = TargetAngle[1];
                TempAngle[2] = TargetAngle[2] + rPara.V_Moving_Offset + rPara.V_Position_defaultOffset + rPara.V_Position_Offset;
                this.RobotGoPositionEvent(BROADCAST_ID, TempAngle[0], TempAngle[1], TempAngle[2]);
                CurrentTime = System.DateTime.Now.Ticks;
                TimeGap = (CurrentTime - CurStartTime) / 10000; 
                nTmpSleepTime = rPara.H_Moving_Time - TimeGap;
                if (nTmpSleepTime > 0) Delay(nTmpSleepTime);

                //[Step2] 목표음계 건반으로 내려 침 (시간 : 수직 이동 시간(rPara.V_Moving_Time) - 약 50msce)
                CurStartTime = System.DateTime.Now.Ticks;
                TempAngle[0] = TargetAngle[0] + rPara.H_Position_Offset;
                TempAngle[1] = TargetAngle[1];
                TempAngle[2] = TargetAngle[2] + rPara.V_Position_defaultOffset + rPara.V_Position_Offset;
                this.RobotGoPositionEvent(BROADCAST_ID, TempAngle[0], TempAngle[1], TempAngle[2]);
                this.RobotSetLEDEvent(nScale); //LED Control
                CurrentTime = System.DateTime.Now.Ticks;
                TimeGap = (CurrentTime - CurStartTime) / 10000;  
                nTmpSleepTime = rPara.V_Moving_Time - TimeGap;
                if (nTmpSleepTime > 0) Delay(nTmpSleepTime);

                //[Step3] 다시 위쪽으로 들어 올림. (시간 : 수직 이동 시간의 반(rPara.V_Moving_Time / 2) - 약 50msce / 2)
                CurStartTime = System.DateTime.Now.Ticks;
                TempAngle[0] = TargetAngle[0] + rPara.H_Position_Offset;
                TempAngle[1] = TargetAngle[1];
                TempAngle[2] = TargetAngle[2] + rPara.V_Moving_Offset + rPara.V_Position_defaultOffset + rPara.V_Position_Offset;
                this.RobotGoPositionEvent(BROADCAST_ID, TempAngle[0], TempAngle[1], TempAngle[2]);
                CurrentTime = System.DateTime.Now.Ticks;
                TimeGap = (CurrentTime - CurStartTime) / 10000;
                nTmpSleepTime = (rPara.V_Moving_Time / 1) - TimeGap;
                if (nTmpSleepTime > 0) Delay(nTmpSleepTime);

                //[Step4] 다음음 위치의 위쪽으로 이동 (시간 : 수직 이동 시간(rPara.V_Moving_Time) + 남은 시간)
                if (nNextScale < 9)
                {
                    if (nTmpSleepTime > 0)
                    {
                        TargetAngle[0] = (int)(rPara.Angle[nNextScale, 0] / (rPara.ANGLE_RATIO * rPara.Dir[0]) + rPara.OriginVal[0]) + rPara.H_Position_Offset;
                        TargetAngle[1] = (int)(rPara.Angle[nNextScale, 1] / (rPara.ANGLE_RATIO * rPara.Dir[1]) + rPara.OriginVal[1]);
                        TargetAngle[2] = (int)(rPara.Angle[nNextScale, 2] / (rPara.ANGLE_RATIO * rPara.Dir[2]) + rPara.OriginVal[2]) + rPara.V_Moving_Offset + rPara.V_Position_defaultOffset + rPara.V_Position_Offset;
                        this.RobotGoPositionEvent(BROADCAST_ID, TargetAngle[0], TargetAngle[1], TargetAngle[2]);
                    }
                }
            }

            CurrentTime = System.DateTime.Now.Ticks;
            TimeGap = (CurrentTime - InitStartTime) / 10000;  // timeGap = 1 milliseconds
            nTmpSleepTime = nTotalInterval - TimeGap;
            if (nTmpSleepTime > 0) Delay(nTmpSleepTime);
        }


        //연주를 시작하기 전, 첫음 위치로 이동함
        public void ReadyToPlay(int nScale)
        {
            TargetAngle[0] = (int)(rPara.Angle[nScale, 0] / (rPara.ANGLE_RATIO * rPara.Dir[0]) + rPara.OriginVal[0]);
            TargetAngle[1] = (int)(rPara.Angle[nScale, 1] / (rPara.ANGLE_RATIO * rPara.Dir[1]) + rPara.OriginVal[1]);
            TargetAngle[2] = (int)(rPara.Angle[nScale, 2] / (rPara.ANGLE_RATIO * rPara.Dir[2]) + rPara.OriginVal[2]);

            TempAngle[0] = TargetAngle[0] + rPara.H_Position_Offset;
            TempAngle[1] = TargetAngle[1];
            TempAngle[2] = TargetAngle[2] + rPara.V_Moving_Offset + rPara.V_Position_defaultOffset + rPara.V_Position_Offset;

            this.RobotGoPositionEvent(BROADCAST_ID, TempAngle[0], TempAngle[1], TempAngle[2]);

            Delay(rPara.H_Moving_Time * 10);
            if (nRobotSpeed != ROBOTMAXSPEED) this.RobotSetGoalSpeedEvent(ROBOTMAXSPEED, ROBOTMAXSPEED, ROBOTMAXSPEED);
        }

        //연주 끝에 Endding Effect
        public void PlayEnding()
        {
            ReadyToPlay(1);

            for (int nNum = 1; nNum <= 8; nNum++)
            {
                TargetAngle[0] = (int)(rPara.Angle[nNum, 0] / (rPara.ANGLE_RATIO * rPara.Dir[0]) + rPara.OriginVal[0]);
                TargetAngle[1] = (int)(rPara.Angle[nNum, 1] / (rPara.ANGLE_RATIO * rPara.Dir[1]) + rPara.OriginVal[1]);
                TargetAngle[2] = (int)(rPara.Angle[nNum, 2] / (rPara.ANGLE_RATIO * rPara.Dir[2]) + rPara.OriginVal[2]);

                TempAngle[0] = TargetAngle[0] + rPara.H_Position_Offset;
                TempAngle[1] = TargetAngle[1];
                TempAngle[2] = TargetAngle[2] - 20;// + rPara.V_Moving_Offset + rPara.V_Position_Offset;

                this.RobotGoPositionEvent(BROADCAST_ID, TempAngle[0], TempAngle[1], TempAngle[2]);
                Delay(30);
            }

            TempAngle[2] += rPara.V_Moving_Offset + rPara.V_Position_defaultOffset + rPara.V_Position_Offset;
            this.RobotGoPositionEvent(3, TempAngle[2], 0 , 0);
        }

        private void Delay(long interval)
        {
            long timeGap = 0;
            long startTime = 0;
            long currentTime = 0;

            startTime = System.DateTime.Now.Ticks;

            while (timeGap <= interval)
            {
                currentTime = System.DateTime.Now.Ticks;
                timeGap = (currentTime - startTime) / 10000; // timeGap = 1 milliseconds
            }
        }
        #endregion
    }
}
