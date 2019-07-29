namespace XylophoneRobot
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnRobotSetting = new System.Windows.Forms.Button();
            this.lblConnectState = new System.Windows.Forms.Label();
            this.lblLabel001 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMusicTitle = new System.Windows.Forms.TextBox();
            this.cbTempo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnTestPlay = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnLoadMusic = new System.Windows.Forms.Button();
            this.btnNewMusic = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLengthDown = new System.Windows.Forms.Button();
            this.btnLengthUp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPitchDown = new System.Windows.Forms.Button();
            this.btnPitchUp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbScale0 = new System.Windows.Forms.RadioButton();
            this.iListScale2 = new System.Windows.Forms.ImageList(this.components);
            this.rbScaleDot1 = new System.Windows.Forms.RadioButton();
            this.rbScale7 = new System.Windows.Forms.RadioButton();
            this.rbScale6 = new System.Windows.Forms.RadioButton();
            this.rbScale5 = new System.Windows.Forms.RadioButton();
            this.rbScale4 = new System.Windows.Forms.RadioButton();
            this.rbScale3 = new System.Windows.Forms.RadioButton();
            this.rbScale2 = new System.Windows.Forms.RadioButton();
            this.rbScale1 = new System.Windows.Forms.RadioButton();
            this.rbScaleP = new System.Windows.Forms.RadioButton();
            this.iListScale1 = new System.Windows.Forms.ImageList(this.components);
            this.rbScaleHighC = new System.Windows.Forms.RadioButton();
            this.rbScaleB = new System.Windows.Forms.RadioButton();
            this.rbScaleA = new System.Windows.Forms.RadioButton();
            this.rbScaleG = new System.Windows.Forms.RadioButton();
            this.rbScaleF = new System.Windows.Forms.RadioButton();
            this.rbScaleE = new System.Windows.Forms.RadioButton();
            this.rbScaleD = new System.Windows.Forms.RadioButton();
            this.rbScaleC = new System.Windows.Forms.RadioButton();
            this.iListScaleLen0 = new System.Windows.Forms.ImageList(this.components);
            this.iListScaleLen1 = new System.Windows.Forms.ImageList(this.components);
            this.iListScaleLen2 = new System.Windows.Forms.ImageList(this.components);
            this.iListScaleLen3 = new System.Windows.Forms.ImageList(this.components);
            this.iListScaleLen4 = new System.Windows.Forms.ImageList(this.components);
            this.iListScaleLen5 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chkUseEffect = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUseKeyboard = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnViewCommMonitor = new System.Windows.Forms.Button();
            this.pnlCommMonitor = new System.Windows.Forms.Panel();
            this.btnDebugClear = new System.Windows.Forms.Button();
            this.txtCommMonitor = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnl = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlCommMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.PortName = "COM17";
            this.serialPort.ReadBufferSize = 1024;
            this.serialPort.WriteBufferSize = 1024;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btnRobotSetting
            // 
            this.btnRobotSetting.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRobotSetting.Location = new System.Drawing.Point(953, 586);
            this.btnRobotSetting.Name = "btnRobotSetting";
            this.btnRobotSetting.Size = new System.Drawing.Size(118, 33);
            this.btnRobotSetting.TabIndex = 18;
            this.btnRobotSetting.Text = "Robot Setting";
            this.btnRobotSetting.UseVisualStyleBackColor = true;
            this.btnRobotSetting.Click += new System.EventHandler(this.btnRobotSetting_Click);
            // 
            // lblConnectState
            // 
            this.lblConnectState.BackColor = System.Drawing.Color.Gray;
            this.lblConnectState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnectState.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectState.Location = new System.Drawing.Point(12, 26);
            this.lblConnectState.Name = "lblConnectState";
            this.lblConnectState.Size = new System.Drawing.Size(80, 18);
            this.lblConnectState.TabIndex = 19;
            this.lblConnectState.Text = "Disconnected";
            this.lblConnectState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLabel001
            // 
            this.lblLabel001.BackColor = System.Drawing.Color.White;
            this.lblLabel001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLabel001.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel001.Location = new System.Drawing.Point(12, 9);
            this.lblLabel001.Name = "lblLabel001";
            this.lblLabel001.Size = new System.Drawing.Size(80, 18);
            this.lblLabel001.TabIndex = 20;
            this.lblLabel001.Text = "Connect State";
            this.lblLabel001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(150, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "Music Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtMusicTitle);
            this.panel1.Location = new System.Drawing.Point(258, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 33);
            this.panel1.TabIndex = 23;
            // 
            // txtMusicTitle
            // 
            this.txtMusicTitle.BackColor = System.Drawing.Color.Cornsilk;
            this.txtMusicTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMusicTitle.Location = new System.Drawing.Point(1, 1);
            this.txtMusicTitle.Name = "txtMusicTitle";
            this.txtMusicTitle.Size = new System.Drawing.Size(691, 29);
            this.txtMusicTitle.TabIndex = 64;
            this.txtMusicTitle.Text = "No Name";
            this.txtMusicTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbTempo
            // 
            this.cbTempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTempo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTempo.FormattingEnabled = true;
            this.cbTempo.Items.AddRange(new object[] {
            "70",
            "90",
            "110",
            "130",
            "150"});
            this.cbTempo.Location = new System.Drawing.Point(1027, 26);
            this.cbTempo.Name = "cbTempo";
            this.cbTempo.Size = new System.Drawing.Size(55, 24);
            this.cbTempo.TabIndex = 27;
            this.cbTempo.SelectedIndexChanged += new System.EventHandler(this.cbTempo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1032, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tempo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1002, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.White;
            this.btnPlay.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(452, 630);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(145, 50);
            this.btnPlay.TabIndex = 29;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(613, 630);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(145, 50);
            this.btnStop.TabIndex = 31;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnTestPlay
            // 
            this.btnTestPlay.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnTestPlay.Location = new System.Drawing.Point(291, 630);
            this.btnTestPlay.Name = "btnTestPlay";
            this.btnTestPlay.Size = new System.Drawing.Size(145, 50);
            this.btnTestPlay.TabIndex = 32;
            this.btnTestPlay.Text = "Test Play";
            this.btnTestPlay.UseVisualStyleBackColor = false;
            this.btnTestPlay.Click += new System.EventHandler(this.btnTestPlay_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(167, 586);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.Location = new System.Drawing.Point(304, 586);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(112, 33);
            this.btnDeleteAll.TabIndex = 35;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnLoadMusic
            // 
            this.btnLoadMusic.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMusic.Location = new System.Drawing.Point(441, 586);
            this.btnLoadMusic.Name = "btnLoadMusic";
            this.btnLoadMusic.Size = new System.Drawing.Size(112, 33);
            this.btnLoadMusic.TabIndex = 36;
            this.btnLoadMusic.Text = "Load Music";
            this.btnLoadMusic.UseVisualStyleBackColor = true;
            this.btnLoadMusic.Click += new System.EventHandler(this.btnLoadMusic_Click);
            // 
            // btnNewMusic
            // 
            this.btnNewMusic.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewMusic.Location = new System.Drawing.Point(578, 586);
            this.btnNewMusic.Name = "btnNewMusic";
            this.btnNewMusic.Size = new System.Drawing.Size(112, 33);
            this.btnNewMusic.TabIndex = 37;
            this.btnNewMusic.Text = "New...";
            this.btnNewMusic.UseVisualStyleBackColor = true;
            this.btnNewMusic.Click += new System.EventHandler(this.btnNewMusic_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(715, 586);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 33);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLengthDown
            // 
            this.btnLengthDown.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLengthDown.Location = new System.Drawing.Point(10, 20);
            this.btnLengthDown.Name = "btnLengthDown";
            this.btnLengthDown.Size = new System.Drawing.Size(40, 40);
            this.btnLengthDown.TabIndex = 39;
            this.btnLengthDown.Text = "-";
            this.btnLengthDown.UseVisualStyleBackColor = true;
            this.btnLengthDown.Click += new System.EventHandler(this.btnLengthDown_Click);
            // 
            // btnLengthUp
            // 
            this.btnLengthUp.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLengthUp.Location = new System.Drawing.Point(54, 20);
            this.btnLengthUp.Name = "btnLengthUp";
            this.btnLengthUp.Size = new System.Drawing.Size(40, 40);
            this.btnLengthUp.TabIndex = 40;
            this.btnLengthUp.Text = "+";
            this.btnLengthUp.UseVisualStyleBackColor = true;
            this.btnLengthUp.Click += new System.EventHandler(this.btnLengthUp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLengthDown);
            this.groupBox1.Controls.Add(this.btnLengthUp);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(771, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(105, 68);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  Length ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPitchDown);
            this.groupBox2.Controls.Add(this.btnPitchUp);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(884, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(105, 68);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Pitch ";
            // 
            // btnPitchDown
            // 
            this.btnPitchDown.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPitchDown.Location = new System.Drawing.Point(10, 20);
            this.btnPitchDown.Name = "btnPitchDown";
            this.btnPitchDown.Size = new System.Drawing.Size(40, 40);
            this.btnPitchDown.TabIndex = 39;
            this.btnPitchDown.Text = "▼";
            this.btnPitchDown.UseVisualStyleBackColor = true;
            this.btnPitchDown.Click += new System.EventHandler(this.btnPitchDown_Click);
            // 
            // btnPitchUp
            // 
            this.btnPitchUp.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPitchUp.Location = new System.Drawing.Point(54, 20);
            this.btnPitchUp.Name = "btnPitchUp";
            this.btnPitchUp.Size = new System.Drawing.Size(40, 40);
            this.btnPitchUp.TabIndex = 40;
            this.btnPitchUp.Text = "▲";
            this.btnPitchUp.UseVisualStyleBackColor = true;
            this.btnPitchUp.Click += new System.EventHandler(this.btnPitchUp_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rbScale0);
            this.panel2.Controls.Add(this.rbScaleDot1);
            this.panel2.Controls.Add(this.rbScale7);
            this.panel2.Controls.Add(this.rbScale6);
            this.panel2.Controls.Add(this.rbScale5);
            this.panel2.Controls.Add(this.rbScale4);
            this.panel2.Controls.Add(this.rbScale3);
            this.panel2.Controls.Add(this.rbScale2);
            this.panel2.Controls.Add(this.rbScale1);
            this.panel2.Controls.Add(this.rbScaleP);
            this.panel2.Controls.Add(this.rbScaleHighC);
            this.panel2.Controls.Add(this.rbScaleB);
            this.panel2.Controls.Add(this.rbScaleA);
            this.panel2.Controls.Add(this.rbScaleG);
            this.panel2.Controls.Add(this.rbScaleF);
            this.panel2.Controls.Add(this.rbScaleE);
            this.panel2.Controls.Add(this.rbScaleD);
            this.panel2.Controls.Add(this.rbScaleC);
            this.panel2.Location = new System.Drawing.Point(13, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 72);
            this.panel2.TabIndex = 47;
            // 
            // rbScale0
            // 
            this.rbScale0.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale0.FlatAppearance.BorderSize = 0;
            this.rbScale0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale0.ImageIndex = 16;
            this.rbScale0.ImageList = this.iListScale2;
            this.rbScale0.Location = new System.Drawing.Point(702, 6);
            this.rbScale0.Name = "rbScale0";
            this.rbScale0.Size = new System.Drawing.Size(40, 57);
            this.rbScale0.TabIndex = 18;
            this.rbScale0.UseVisualStyleBackColor = true;
            this.rbScale0.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // iListScale2
            // 
            this.iListScale2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScale2.ImageStream")));
            this.iListScale2.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScale2.Images.SetKeyName(0, "1(40x57).png");
            this.iListScale2.Images.SetKeyName(1, "1_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(2, "2(40x57).png");
            this.iListScale2.Images.SetKeyName(3, "2_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(4, "3(40x57).png");
            this.iListScale2.Images.SetKeyName(5, "3_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(6, "4(40x57).png");
            this.iListScale2.Images.SetKeyName(7, "4_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(8, "5(40x57).png");
            this.iListScale2.Images.SetKeyName(9, "5_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(10, "6(40x57).png");
            this.iListScale2.Images.SetKeyName(11, "6_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(12, "7(40x57).png");
            this.iListScale2.Images.SetKeyName(13, "7_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(14, "Dot1(40x57).png");
            this.iListScale2.Images.SetKeyName(15, "Dot1_Sel(40x57).png");
            this.iListScale2.Images.SetKeyName(16, "0(40x57).png");
            this.iListScale2.Images.SetKeyName(17, "0_Sel(40x57).png");
            // 
            // rbScaleDot1
            // 
            this.rbScaleDot1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleDot1.FlatAppearance.BorderSize = 0;
            this.rbScaleDot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleDot1.ImageIndex = 14;
            this.rbScaleDot1.ImageList = this.iListScale2;
            this.rbScaleDot1.Location = new System.Drawing.Point(662, 6);
            this.rbScaleDot1.Name = "rbScaleDot1";
            this.rbScaleDot1.Size = new System.Drawing.Size(40, 57);
            this.rbScaleDot1.TabIndex = 17;
            this.rbScaleDot1.UseVisualStyleBackColor = true;
            this.rbScaleDot1.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale7
            // 
            this.rbScale7.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale7.FlatAppearance.BorderSize = 0;
            this.rbScale7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale7.ImageIndex = 12;
            this.rbScale7.ImageList = this.iListScale2;
            this.rbScale7.Location = new System.Drawing.Point(622, 6);
            this.rbScale7.Name = "rbScale7";
            this.rbScale7.Size = new System.Drawing.Size(40, 57);
            this.rbScale7.TabIndex = 16;
            this.rbScale7.UseVisualStyleBackColor = true;
            this.rbScale7.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale6
            // 
            this.rbScale6.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale6.FlatAppearance.BorderSize = 0;
            this.rbScale6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale6.ImageIndex = 10;
            this.rbScale6.ImageList = this.iListScale2;
            this.rbScale6.Location = new System.Drawing.Point(582, 6);
            this.rbScale6.Name = "rbScale6";
            this.rbScale6.Size = new System.Drawing.Size(40, 57);
            this.rbScale6.TabIndex = 15;
            this.rbScale6.UseVisualStyleBackColor = true;
            this.rbScale6.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale5
            // 
            this.rbScale5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale5.FlatAppearance.BorderSize = 0;
            this.rbScale5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale5.ImageIndex = 8;
            this.rbScale5.ImageList = this.iListScale2;
            this.rbScale5.Location = new System.Drawing.Point(542, 6);
            this.rbScale5.Name = "rbScale5";
            this.rbScale5.Size = new System.Drawing.Size(40, 57);
            this.rbScale5.TabIndex = 14;
            this.rbScale5.UseVisualStyleBackColor = true;
            this.rbScale5.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale4
            // 
            this.rbScale4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale4.FlatAppearance.BorderSize = 0;
            this.rbScale4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale4.ImageIndex = 6;
            this.rbScale4.ImageList = this.iListScale2;
            this.rbScale4.Location = new System.Drawing.Point(502, 6);
            this.rbScale4.Name = "rbScale4";
            this.rbScale4.Size = new System.Drawing.Size(40, 57);
            this.rbScale4.TabIndex = 13;
            this.rbScale4.UseVisualStyleBackColor = true;
            this.rbScale4.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale3
            // 
            this.rbScale3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale3.FlatAppearance.BorderSize = 0;
            this.rbScale3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale3.ImageIndex = 4;
            this.rbScale3.ImageList = this.iListScale2;
            this.rbScale3.Location = new System.Drawing.Point(462, 6);
            this.rbScale3.Name = "rbScale3";
            this.rbScale3.Size = new System.Drawing.Size(40, 57);
            this.rbScale3.TabIndex = 12;
            this.rbScale3.UseVisualStyleBackColor = true;
            this.rbScale3.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale2
            // 
            this.rbScale2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale2.FlatAppearance.BorderSize = 0;
            this.rbScale2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale2.ImageIndex = 2;
            this.rbScale2.ImageList = this.iListScale2;
            this.rbScale2.Location = new System.Drawing.Point(422, 6);
            this.rbScale2.Name = "rbScale2";
            this.rbScale2.Size = new System.Drawing.Size(40, 57);
            this.rbScale2.TabIndex = 11;
            this.rbScale2.UseVisualStyleBackColor = true;
            this.rbScale2.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScale1
            // 
            this.rbScale1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScale1.FlatAppearance.BorderSize = 0;
            this.rbScale1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScale1.ImageIndex = 0;
            this.rbScale1.ImageList = this.iListScale2;
            this.rbScale1.Location = new System.Drawing.Point(382, 6);
            this.rbScale1.Name = "rbScale1";
            this.rbScale1.Size = new System.Drawing.Size(40, 57);
            this.rbScale1.TabIndex = 10;
            this.rbScale1.UseVisualStyleBackColor = true;
            this.rbScale1.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleP
            // 
            this.rbScaleP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleP.FlatAppearance.BorderSize = 0;
            this.rbScaleP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleP.ImageIndex = 16;
            this.rbScaleP.ImageList = this.iListScale1;
            this.rbScaleP.Location = new System.Drawing.Point(326, 5);
            this.rbScaleP.Name = "rbScaleP";
            this.rbScaleP.Size = new System.Drawing.Size(40, 57);
            this.rbScaleP.TabIndex = 9;
            this.rbScaleP.UseVisualStyleBackColor = true;
            this.rbScaleP.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // iListScale1
            // 
            this.iListScale1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScale1.ImageStream")));
            this.iListScale1.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScale1.Images.SetKeyName(0, "C(40x57).png");
            this.iListScale1.Images.SetKeyName(1, "C_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(2, "D(40x57).png");
            this.iListScale1.Images.SetKeyName(3, "D_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(4, "E(40x57).png");
            this.iListScale1.Images.SetKeyName(5, "E_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(6, "F(40x57).png");
            this.iListScale1.Images.SetKeyName(7, "F_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(8, "G(40x57).png");
            this.iListScale1.Images.SetKeyName(9, "G_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(10, "A(40x57).png");
            this.iListScale1.Images.SetKeyName(11, "A_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(12, "B(40x57).png");
            this.iListScale1.Images.SetKeyName(13, "B_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(14, "HighC(40x57).png");
            this.iListScale1.Images.SetKeyName(15, "HighC_Sel(40x57).png");
            this.iListScale1.Images.SetKeyName(16, "P(40x57).png");
            this.iListScale1.Images.SetKeyName(17, "P_Sel(40x57).png");
            // 
            // rbScaleHighC
            // 
            this.rbScaleHighC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleHighC.FlatAppearance.BorderSize = 0;
            this.rbScaleHighC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleHighC.ImageIndex = 14;
            this.rbScaleHighC.ImageList = this.iListScale1;
            this.rbScaleHighC.Location = new System.Drawing.Point(286, 5);
            this.rbScaleHighC.Name = "rbScaleHighC";
            this.rbScaleHighC.Size = new System.Drawing.Size(40, 57);
            this.rbScaleHighC.TabIndex = 8;
            this.rbScaleHighC.UseVisualStyleBackColor = true;
            this.rbScaleHighC.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleB
            // 
            this.rbScaleB.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleB.FlatAppearance.BorderSize = 0;
            this.rbScaleB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleB.ImageIndex = 12;
            this.rbScaleB.ImageList = this.iListScale1;
            this.rbScaleB.Location = new System.Drawing.Point(246, 5);
            this.rbScaleB.Name = "rbScaleB";
            this.rbScaleB.Size = new System.Drawing.Size(40, 57);
            this.rbScaleB.TabIndex = 7;
            this.rbScaleB.UseVisualStyleBackColor = true;
            this.rbScaleB.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleA
            // 
            this.rbScaleA.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleA.FlatAppearance.BorderSize = 0;
            this.rbScaleA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleA.ImageIndex = 10;
            this.rbScaleA.ImageList = this.iListScale1;
            this.rbScaleA.Location = new System.Drawing.Point(206, 5);
            this.rbScaleA.Name = "rbScaleA";
            this.rbScaleA.Size = new System.Drawing.Size(40, 57);
            this.rbScaleA.TabIndex = 6;
            this.rbScaleA.UseVisualStyleBackColor = true;
            this.rbScaleA.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleG
            // 
            this.rbScaleG.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleG.FlatAppearance.BorderSize = 0;
            this.rbScaleG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleG.ImageIndex = 8;
            this.rbScaleG.ImageList = this.iListScale1;
            this.rbScaleG.Location = new System.Drawing.Point(166, 5);
            this.rbScaleG.Name = "rbScaleG";
            this.rbScaleG.Size = new System.Drawing.Size(40, 57);
            this.rbScaleG.TabIndex = 5;
            this.rbScaleG.UseVisualStyleBackColor = true;
            this.rbScaleG.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleF
            // 
            this.rbScaleF.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleF.FlatAppearance.BorderSize = 0;
            this.rbScaleF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleF.ImageIndex = 6;
            this.rbScaleF.ImageList = this.iListScale1;
            this.rbScaleF.Location = new System.Drawing.Point(126, 5);
            this.rbScaleF.Name = "rbScaleF";
            this.rbScaleF.Size = new System.Drawing.Size(40, 57);
            this.rbScaleF.TabIndex = 4;
            this.rbScaleF.UseVisualStyleBackColor = true;
            this.rbScaleF.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleE
            // 
            this.rbScaleE.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleE.FlatAppearance.BorderSize = 0;
            this.rbScaleE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleE.ImageIndex = 4;
            this.rbScaleE.ImageList = this.iListScale1;
            this.rbScaleE.Location = new System.Drawing.Point(86, 5);
            this.rbScaleE.Name = "rbScaleE";
            this.rbScaleE.Size = new System.Drawing.Size(40, 57);
            this.rbScaleE.TabIndex = 3;
            this.rbScaleE.UseVisualStyleBackColor = true;
            this.rbScaleE.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleD
            // 
            this.rbScaleD.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleD.FlatAppearance.BorderSize = 0;
            this.rbScaleD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleD.ImageIndex = 2;
            this.rbScaleD.ImageList = this.iListScale1;
            this.rbScaleD.Location = new System.Drawing.Point(46, 5);
            this.rbScaleD.Name = "rbScaleD";
            this.rbScaleD.Size = new System.Drawing.Size(40, 57);
            this.rbScaleD.TabIndex = 2;
            this.rbScaleD.UseVisualStyleBackColor = true;
            this.rbScaleD.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // rbScaleC
            // 
            this.rbScaleC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbScaleC.FlatAppearance.BorderSize = 0;
            this.rbScaleC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbScaleC.ImageIndex = 0;
            this.rbScaleC.ImageList = this.iListScale1;
            this.rbScaleC.Location = new System.Drawing.Point(6, 5);
            this.rbScaleC.Name = "rbScaleC";
            this.rbScaleC.Size = new System.Drawing.Size(40, 57);
            this.rbScaleC.TabIndex = 0;
            this.rbScaleC.UseVisualStyleBackColor = true;
            this.rbScaleC.Click += new System.EventHandler(this.rbScale_CheckedChanged);
            // 
            // iListScaleLen0
            // 
            this.iListScaleLen0.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScaleLen0.ImageStream")));
            this.iListScaleLen0.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScaleLen0.Images.SetKeyName(0, "1C.png");
            this.iListScaleLen0.Images.SetKeyName(1, "1C_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(2, "1D.png");
            this.iListScaleLen0.Images.SetKeyName(3, "1D_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(4, "1E.png");
            this.iListScaleLen0.Images.SetKeyName(5, "1E_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(6, "1F.png");
            this.iListScaleLen0.Images.SetKeyName(7, "1F_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(8, "1G.png");
            this.iListScaleLen0.Images.SetKeyName(9, "1G_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(10, "1A.png");
            this.iListScaleLen0.Images.SetKeyName(11, "1A_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(12, "1B.png");
            this.iListScaleLen0.Images.SetKeyName(13, "1B_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(14, "1HC8.png");
            this.iListScaleLen0.Images.SetKeyName(15, "1HC8_Sel.png");
            this.iListScaleLen0.Images.SetKeyName(16, "1P.png");
            this.iListScaleLen0.Images.SetKeyName(17, "1P_Sel.png");
            // 
            // iListScaleLen1
            // 
            this.iListScaleLen1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScaleLen1.ImageStream")));
            this.iListScaleLen1.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScaleLen1.Images.SetKeyName(0, "2C.png");
            this.iListScaleLen1.Images.SetKeyName(1, "2C_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(2, "2D.png");
            this.iListScaleLen1.Images.SetKeyName(3, "2D_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(4, "2E.png");
            this.iListScaleLen1.Images.SetKeyName(5, "2E_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(6, "2F.png");
            this.iListScaleLen1.Images.SetKeyName(7, "2F_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(8, "2G.png");
            this.iListScaleLen1.Images.SetKeyName(9, "2G_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(10, "2A.png");
            this.iListScaleLen1.Images.SetKeyName(11, "2A_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(12, "2B.png");
            this.iListScaleLen1.Images.SetKeyName(13, "2B_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(14, "2HC.png");
            this.iListScaleLen1.Images.SetKeyName(15, "2HC_Sel.png");
            this.iListScaleLen1.Images.SetKeyName(16, "2P.png");
            this.iListScaleLen1.Images.SetKeyName(17, "2P_Sel.png");
            // 
            // iListScaleLen2
            // 
            this.iListScaleLen2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScaleLen2.ImageStream")));
            this.iListScaleLen2.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScaleLen2.Images.SetKeyName(0, "3C.png");
            this.iListScaleLen2.Images.SetKeyName(1, "3C_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(2, "3D.png");
            this.iListScaleLen2.Images.SetKeyName(3, "3D_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(4, "3E.png");
            this.iListScaleLen2.Images.SetKeyName(5, "3E_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(6, "3F.png");
            this.iListScaleLen2.Images.SetKeyName(7, "3F_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(8, "3G.png");
            this.iListScaleLen2.Images.SetKeyName(9, "3G_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(10, "3A.png");
            this.iListScaleLen2.Images.SetKeyName(11, "3A_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(12, "3B.png");
            this.iListScaleLen2.Images.SetKeyName(13, "3B_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(14, "3HC.png");
            this.iListScaleLen2.Images.SetKeyName(15, "3HC_Sel.png");
            this.iListScaleLen2.Images.SetKeyName(16, "3P.png");
            this.iListScaleLen2.Images.SetKeyName(17, "3P_Sel.png");
            // 
            // iListScaleLen3
            // 
            this.iListScaleLen3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScaleLen3.ImageStream")));
            this.iListScaleLen3.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScaleLen3.Images.SetKeyName(0, "4C.png");
            this.iListScaleLen3.Images.SetKeyName(1, "4C_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(2, "4D.png");
            this.iListScaleLen3.Images.SetKeyName(3, "4D_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(4, "4E.png");
            this.iListScaleLen3.Images.SetKeyName(5, "4E_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(6, "4F.png");
            this.iListScaleLen3.Images.SetKeyName(7, "4F_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(8, "4G.png");
            this.iListScaleLen3.Images.SetKeyName(9, "4G_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(10, "4A.png");
            this.iListScaleLen3.Images.SetKeyName(11, "4A_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(12, "4B.png");
            this.iListScaleLen3.Images.SetKeyName(13, "4B_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(14, "4HC.png");
            this.iListScaleLen3.Images.SetKeyName(15, "4HC_Sel.png");
            this.iListScaleLen3.Images.SetKeyName(16, "4P.png");
            this.iListScaleLen3.Images.SetKeyName(17, "4P_Sel.png");
            // 
            // iListScaleLen4
            // 
            this.iListScaleLen4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScaleLen4.ImageStream")));
            this.iListScaleLen4.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScaleLen4.Images.SetKeyName(0, "5C.png");
            this.iListScaleLen4.Images.SetKeyName(1, "5C_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(2, "5D.png");
            this.iListScaleLen4.Images.SetKeyName(3, "5D_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(4, "5E.png");
            this.iListScaleLen4.Images.SetKeyName(5, "5E_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(6, "5F.png");
            this.iListScaleLen4.Images.SetKeyName(7, "5F_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(8, "5G.png");
            this.iListScaleLen4.Images.SetKeyName(9, "5G_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(10, "5A.png");
            this.iListScaleLen4.Images.SetKeyName(11, "5A_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(12, "5B.png");
            this.iListScaleLen4.Images.SetKeyName(13, "5B_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(14, "5HC.png");
            this.iListScaleLen4.Images.SetKeyName(15, "5HC_Sel.png");
            this.iListScaleLen4.Images.SetKeyName(16, "5P.png");
            this.iListScaleLen4.Images.SetKeyName(17, "5P_Sel.png");
            // 
            // iListScaleLen5
            // 
            this.iListScaleLen5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListScaleLen5.ImageStream")));
            this.iListScaleLen5.TransparentColor = System.Drawing.Color.Transparent;
            this.iListScaleLen5.Images.SetKeyName(0, "6C.png");
            this.iListScaleLen5.Images.SetKeyName(1, "6C_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(2, "6D.png");
            this.iListScaleLen5.Images.SetKeyName(3, "6D_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(4, "6E.png");
            this.iListScaleLen5.Images.SetKeyName(5, "6E_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(6, "6F.png");
            this.iListScaleLen5.Images.SetKeyName(7, "6F_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(8, "6G.png");
            this.iListScaleLen5.Images.SetKeyName(9, "6G_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(10, "6A.png");
            this.iListScaleLen5.Images.SetKeyName(11, "6A_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(12, "6B.png");
            this.iListScaleLen5.Images.SetKeyName(13, "6B_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(14, "6HC.png");
            this.iListScaleLen5.Images.SetKeyName(15, "6HC_Sel.png");
            this.iListScaleLen5.Images.SetKeyName(16, "6P.png");
            this.iListScaleLen5.Images.SetKeyName(17, "6P_Sel.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // chkUseEffect
            // 
            this.chkUseEffect.AutoSize = true;
            this.chkUseEffect.Location = new System.Drawing.Point(31, 593);
            this.chkUseEffect.Name = "chkUseEffect";
            this.chkUseEffect.Size = new System.Drawing.Size(87, 20);
            this.chkUseEffect.TabIndex = 79;
            this.chkUseEffect.Text = "Use Effect";
            this.chkUseEffect.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUseKeyboard);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(998, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 68);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Use Key";
            // 
            // btnUseKeyboard
            // 
            this.btnUseKeyboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUseKeyboard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUseKeyboard.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseKeyboard.Location = new System.Drawing.Point(17, 31);
            this.btnUseKeyboard.Name = "btnUseKeyboard";
            this.btnUseKeyboard.Size = new System.Drawing.Size(56, 23);
            this.btnUseKeyboard.TabIndex = 30;
            this.btnUseKeyboard.Text = "Off";
            this.btnUseKeyboard.UseVisualStyleBackColor = false;
            this.btnUseKeyboard.Click += new System.EventHandler(this.btnUseKeyboard_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnViewCommMonitor);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(935, 631);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 49);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Comm. Monitor ";
            // 
            // btnViewCommMonitor
            // 
            this.btnViewCommMonitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewCommMonitor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnViewCommMonitor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCommMonitor.Location = new System.Drawing.Point(42, 20);
            this.btnViewCommMonitor.Name = "btnViewCommMonitor";
            this.btnViewCommMonitor.Size = new System.Drawing.Size(56, 23);
            this.btnViewCommMonitor.TabIndex = 31;
            this.btnViewCommMonitor.Text = "Off";
            this.btnViewCommMonitor.UseVisualStyleBackColor = false;
            this.btnViewCommMonitor.Click += new System.EventHandler(this.btnViewCommMonitor_Click);
            // 
            // pnlCommMonitor
            // 
            this.pnlCommMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlCommMonitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommMonitor.Controls.Add(this.btnDebugClear);
            this.pnlCommMonitor.Controls.Add(this.txtCommMonitor);
            this.pnlCommMonitor.Location = new System.Drawing.Point(548, 472);
            this.pnlCommMonitor.Name = "pnlCommMonitor";
            this.pnlCommMonitor.Size = new System.Drawing.Size(548, 100);
            this.pnlCommMonitor.TabIndex = 65;
            this.pnlCommMonitor.Visible = false;
            // 
            // btnDebugClear
            // 
            this.btnDebugClear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebugClear.Location = new System.Drawing.Point(487, 4);
            this.btnDebugClear.Name = "btnDebugClear";
            this.btnDebugClear.Size = new System.Drawing.Size(55, 33);
            this.btnDebugClear.TabIndex = 66;
            this.btnDebugClear.Text = "Clear";
            this.btnDebugClear.UseVisualStyleBackColor = true;
            this.btnDebugClear.Click += new System.EventHandler(this.btnDebugClear_Click);
            // 
            // txtCommMonitor
            // 
            this.txtCommMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCommMonitor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommMonitor.Location = new System.Drawing.Point(4, 4);
            this.txtCommMonitor.Multiline = true;
            this.txtCommMonitor.Name = "txtCommMonitor";
            this.txtCommMonitor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommMonitor.Size = new System.Drawing.Size(479, 91);
            this.txtCommMonitor.TabIndex = 66;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // pnl
            // 
            this.pnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl.BackgroundImage")));
            this.pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl.Location = new System.Drawing.Point(10, 136);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1090, 440);
            this.pnl.TabIndex = 0;
            this.pnl.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 688);
            this.Controls.Add(this.pnlCommMonitor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chkUseEffect);
            this.Controls.Add(this.btnRobotSetting);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewMusic);
            this.Controls.Add(this.btnLoadMusic);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnTestPlay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbTempo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLabel001);
            this.Controls.Add(this.lblConnectState);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Xylophone Robot (Ver. 1.06)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.pnlCommMonitor.ResumeLayout(false);
            this.pnlCommMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnRobotSetting;
        private System.Windows.Forms.Label lblConnectState;
        private System.Windows.Forms.Label lblLabel001;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnTestPlay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnLoadMusic;
        private System.Windows.Forms.Button btnNewMusic;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLengthDown;
        private System.Windows.Forms.Button btnLengthUp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPitchDown;
        private System.Windows.Forms.Button btnPitchUp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbScaleC;
        private System.Windows.Forms.ImageList iListScale1;
        private System.Windows.Forms.ImageList iListScale2;
        private System.Windows.Forms.RadioButton rbScaleF;
        private System.Windows.Forms.RadioButton rbScaleE;
        private System.Windows.Forms.RadioButton rbScaleD;
        private System.Windows.Forms.RadioButton rbScale0;
        private System.Windows.Forms.RadioButton rbScaleDot1;
        private System.Windows.Forms.RadioButton rbScale7;
        private System.Windows.Forms.RadioButton rbScale6;
        private System.Windows.Forms.RadioButton rbScale5;
        private System.Windows.Forms.RadioButton rbScale4;
        private System.Windows.Forms.RadioButton rbScale3;
        private System.Windows.Forms.RadioButton rbScale2;
        private System.Windows.Forms.RadioButton rbScale1;
        private System.Windows.Forms.RadioButton rbScaleP;
        private System.Windows.Forms.RadioButton rbScaleHighC;
        private System.Windows.Forms.RadioButton rbScaleB;
        private System.Windows.Forms.RadioButton rbScaleA;
        private System.Windows.Forms.RadioButton rbScaleG;
        private System.Windows.Forms.ImageList iListScaleLen0;
        private System.Windows.Forms.ImageList iListScaleLen1;
        private System.Windows.Forms.ImageList iListScaleLen2;
        private System.Windows.Forms.ImageList iListScaleLen3;
        private System.Windows.Forms.ImageList iListScaleLen4;
        private System.Windows.Forms.ImageList iListScaleLen5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox txtMusicTitle;
        private System.Windows.Forms.CheckBox chkUseEffect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnlCommMonitor;
        private System.Windows.Forms.Button btnDebugClear;
        private System.Windows.Forms.TextBox txtCommMonitor;
        private System.Windows.Forms.Button btnUseKeyboard;
        private System.Windows.Forms.Button btnViewCommMonitor;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel pnl;
    }
}

