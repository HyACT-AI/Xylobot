namespace XylophoneRobot
{
    partial class RobotSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAxis1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scrAxis3 = new System.Windows.Forms.HScrollBar();
            this.lblAxis3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scrAxis2 = new System.Windows.Forms.HScrollBar();
            this.lblAxis2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scrAxis1 = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTorqueOff = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnToneB = new System.Windows.Forms.Button();
            this.btnToneA = new System.Windows.Forms.Button();
            this.btnToneG = new System.Windows.Forms.Button();
            this.btnToneF = new System.Windows.Forms.Button();
            this.btnToneE = new System.Windows.Forms.Button();
            this.btnToneD = new System.Windows.Forms.Button();
            this.btnToneC = new System.Windows.Forms.Button();
            this.btnToneC_high = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRobotParaAdapt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRobotParaReload = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtHPositionOffset = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVPositionOffset = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tmrPositionMonitor = new System.Windows.Forms.Timer(this.components);
            this.btnTorqueOn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Axis 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAxis1
            // 
            this.lblAxis1.BackColor = System.Drawing.Color.White;
            this.lblAxis1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxis1.Location = new System.Drawing.Point(305, 71);
            this.lblAxis1.Name = "lblAxis1";
            this.lblAxis1.Size = new System.Drawing.Size(60, 20);
            this.lblAxis1.TabIndex = 8;
            this.lblAxis1.Text = "512";
            this.lblAxis1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.scrAxis3);
            this.panel1.Controls.Add(this.lblAxis3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.scrAxis2);
            this.panel1.Controls.Add(this.lblAxis2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.scrAxis1);
            this.panel1.Controls.Add(this.lblAxis1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 106);
            this.panel1.TabIndex = 9;
            // 
            // scrAxis3
            // 
            this.scrAxis3.LargeChange = 1;
            this.scrAxis3.Location = new System.Drawing.Point(79, 10);
            this.scrAxis3.Maximum = 1023;
            this.scrAxis3.Name = "scrAxis3";
            this.scrAxis3.Size = new System.Drawing.Size(220, 20);
            this.scrAxis3.TabIndex = 15;
            this.scrAxis3.Value = 512;
            this.scrAxis3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrAxis3_Scroll);
            // 
            // lblAxis3
            // 
            this.lblAxis3.BackColor = System.Drawing.Color.White;
            this.lblAxis3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxis3.Location = new System.Drawing.Point(305, 10);
            this.lblAxis3.Name = "lblAxis3";
            this.lblAxis3.Size = new System.Drawing.Size(60, 20);
            this.lblAxis3.TabIndex = 14;
            this.lblAxis3.Text = "512";
            this.lblAxis3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Axis 3";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scrAxis2
            // 
            this.scrAxis2.LargeChange = 1;
            this.scrAxis2.Location = new System.Drawing.Point(79, 40);
            this.scrAxis2.Maximum = 1023;
            this.scrAxis2.Name = "scrAxis2";
            this.scrAxis2.Size = new System.Drawing.Size(220, 20);
            this.scrAxis2.TabIndex = 12;
            this.scrAxis2.Value = 512;
            this.scrAxis2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrAxis2_Scroll);
            // 
            // lblAxis2
            // 
            this.lblAxis2.BackColor = System.Drawing.Color.White;
            this.lblAxis2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxis2.Location = new System.Drawing.Point(305, 40);
            this.lblAxis2.Name = "lblAxis2";
            this.lblAxis2.Size = new System.Drawing.Size(60, 20);
            this.lblAxis2.TabIndex = 11;
            this.lblAxis2.Text = "512";
            this.lblAxis2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Axis 2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scrAxis1
            // 
            this.scrAxis1.LargeChange = 1;
            this.scrAxis1.Location = new System.Drawing.Point(79, 71);
            this.scrAxis1.Maximum = 1023;
            this.scrAxis1.Name = "scrAxis1";
            this.scrAxis1.Size = new System.Drawing.Size(220, 20);
            this.scrAxis1.TabIndex = 9;
            this.scrAxis1.Value = 512;
            this.scrAxis1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrAxis1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "The robot\'s home position and high tone C are aligned and saved.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(366, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "(로봇의 원점 위치 및 높은 도음의 위치를 맞추고 저장합니다.)";
            // 
            // btnTorqueOff
            // 
            this.btnTorqueOff.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTorqueOff.Location = new System.Drawing.Point(411, 162);
            this.btnTorqueOff.Name = "btnTorqueOff";
            this.btnTorqueOff.Size = new System.Drawing.Size(91, 29);
            this.btnTorqueOff.TabIndex = 12;
            this.btnTorqueOff.Text = "Torque Off";
            this.btnTorqueOff.UseVisualStyleBackColor = true;
            this.btnTorqueOff.Click += new System.EventHandler(this.btnTorqueOff_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnToneB);
            this.panel2.Controls.Add(this.btnToneA);
            this.panel2.Controls.Add(this.btnToneG);
            this.panel2.Controls.Add(this.btnToneF);
            this.panel2.Controls.Add(this.btnToneE);
            this.panel2.Controls.Add(this.btnToneD);
            this.panel2.Controls.Add(this.btnToneC);
            this.panel2.Controls.Add(this.btnToneC_high);
            this.panel2.Location = new System.Drawing.Point(20, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 85);
            this.panel2.TabIndex = 13;
            // 
            // btnToneB
            // 
            this.btnToneB.BackColor = System.Drawing.Color.Purple;
            this.btnToneB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneB.FlatAppearance.BorderSize = 2;
            this.btnToneB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneB.Location = new System.Drawing.Point(364, 6);
            this.btnToneB.Name = "btnToneB";
            this.btnToneB.Size = new System.Drawing.Size(50, 58);
            this.btnToneB.TabIndex = 7;
            this.btnToneB.Text = "B";
            this.btnToneB.UseVisualStyleBackColor = false;
            this.btnToneB.Click += new System.EventHandler(this.btnToneB_Click);
            // 
            // btnToneA
            // 
            this.btnToneA.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnToneA.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneA.FlatAppearance.BorderSize = 2;
            this.btnToneA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneA.Location = new System.Drawing.Point(305, 6);
            this.btnToneA.Name = "btnToneA";
            this.btnToneA.Size = new System.Drawing.Size(50, 60);
            this.btnToneA.TabIndex = 6;
            this.btnToneA.Text = "A";
            this.btnToneA.UseVisualStyleBackColor = false;
            this.btnToneA.Click += new System.EventHandler(this.btnToneA_Click);
            // 
            // btnToneG
            // 
            this.btnToneG.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnToneG.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneG.FlatAppearance.BorderSize = 2;
            this.btnToneG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneG.Location = new System.Drawing.Point(246, 6);
            this.btnToneG.Name = "btnToneG";
            this.btnToneG.Size = new System.Drawing.Size(50, 62);
            this.btnToneG.TabIndex = 5;
            this.btnToneG.Text = "G";
            this.btnToneG.UseVisualStyleBackColor = false;
            this.btnToneG.Click += new System.EventHandler(this.btnToneG_Click);
            // 
            // btnToneF
            // 
            this.btnToneF.BackColor = System.Drawing.Color.LawnGreen;
            this.btnToneF.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneF.FlatAppearance.BorderSize = 2;
            this.btnToneF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneF.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneF.Location = new System.Drawing.Point(187, 6);
            this.btnToneF.Name = "btnToneF";
            this.btnToneF.Size = new System.Drawing.Size(50, 64);
            this.btnToneF.TabIndex = 4;
            this.btnToneF.Text = "F";
            this.btnToneF.UseVisualStyleBackColor = false;
            this.btnToneF.Click += new System.EventHandler(this.btnToneF_Click);
            // 
            // btnToneE
            // 
            this.btnToneE.BackColor = System.Drawing.Color.Yellow;
            this.btnToneE.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneE.FlatAppearance.BorderSize = 2;
            this.btnToneE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneE.Location = new System.Drawing.Point(128, 6);
            this.btnToneE.Name = "btnToneE";
            this.btnToneE.Size = new System.Drawing.Size(50, 66);
            this.btnToneE.TabIndex = 3;
            this.btnToneE.Text = "E";
            this.btnToneE.UseVisualStyleBackColor = false;
            this.btnToneE.Click += new System.EventHandler(this.btnToneE_Click);
            // 
            // btnToneD
            // 
            this.btnToneD.BackColor = System.Drawing.Color.Orange;
            this.btnToneD.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneD.FlatAppearance.BorderSize = 2;
            this.btnToneD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneD.Location = new System.Drawing.Point(69, 6);
            this.btnToneD.Name = "btnToneD";
            this.btnToneD.Size = new System.Drawing.Size(50, 68);
            this.btnToneD.TabIndex = 2;
            this.btnToneD.Text = "D";
            this.btnToneD.UseVisualStyleBackColor = false;
            this.btnToneD.Click += new System.EventHandler(this.btnToneD_Click);
            // 
            // btnToneC
            // 
            this.btnToneC.BackColor = System.Drawing.Color.Red;
            this.btnToneC.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneC.FlatAppearance.BorderSize = 2;
            this.btnToneC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneC.Location = new System.Drawing.Point(10, 6);
            this.btnToneC.Name = "btnToneC";
            this.btnToneC.Size = new System.Drawing.Size(50, 70);
            this.btnToneC.TabIndex = 1;
            this.btnToneC.Text = "C";
            this.btnToneC.UseVisualStyleBackColor = false;
            this.btnToneC.Click += new System.EventHandler(this.btnToneC_Click);
            // 
            // btnToneC_high
            // 
            this.btnToneC_high.BackColor = System.Drawing.Color.Red;
            this.btnToneC_high.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnToneC_high.FlatAppearance.BorderSize = 2;
            this.btnToneC_high.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToneC_high.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToneC_high.Location = new System.Drawing.Point(423, 6);
            this.btnToneC_high.Name = "btnToneC_high";
            this.btnToneC_high.Size = new System.Drawing.Size(50, 56);
            this.btnToneC_high.TabIndex = 0;
            this.btnToneC_high.Text = "C";
            this.btnToneC_high.UseVisualStyleBackColor = false;
            this.btnToneC_high.Click += new System.EventHandler(this.btnToneC_high_Click);
            // 
            // btnHome
            // 
            this.btnHome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(411, 226);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(91, 42);
            this.btnHome.TabIndex = 15;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRobotParaAdapt
            // 
            this.btnRobotParaAdapt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRobotParaAdapt.Location = new System.Drawing.Point(385, 335);
            this.btnRobotParaAdapt.Name = "btnRobotParaAdapt";
            this.btnRobotParaAdapt.Size = new System.Drawing.Size(86, 34);
            this.btnRobotParaAdapt.TabIndex = 17;
            this.btnRobotParaAdapt.Text = "Adapt";
            this.btnRobotParaAdapt.UseVisualStyleBackColor = true;
            this.btnRobotParaAdapt.Click += new System.EventHandler(this.btnRobotParaAdapt_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(549, 407);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 280);
            this.panel3.TabIndex = 19;
            // 
            // btnRobotParaReload
            // 
            this.btnRobotParaReload.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRobotParaReload.Location = new System.Drawing.Point(385, 291);
            this.btnRobotParaReload.Name = "btnRobotParaReload";
            this.btnRobotParaReload.Size = new System.Drawing.Size(86, 34);
            this.btnRobotParaReload.TabIndex = 21;
            this.btnRobotParaReload.Text = "Reload";
            this.btnRobotParaReload.UseVisualStyleBackColor = true;
            this.btnRobotParaReload.Click += new System.EventHandler(this.btnRobotParaReload_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtHPositionOffset);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtVPositionOffset);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(65, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(294, 86);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Offset Setting ";
            // 
            // txtHPositionOffset
            // 
            this.txtHPositionOffset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHPositionOffset.Location = new System.Drawing.Point(224, 53);
            this.txtHPositionOffset.Name = "txtHPositionOffset";
            this.txtHPositionOffset.Size = new System.Drawing.Size(50, 21);
            this.txtHPositionOffset.TabIndex = 21;
            this.txtHPositionOffset.Text = "1";
            this.txtHPositionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(193, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "Horizontal position offset(1=0.29°)";
            // 
            // txtVPositionOffset
            // 
            this.txtVPositionOffset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVPositionOffset.Location = new System.Drawing.Point(224, 24);
            this.txtVPositionOffset.Name = "txtVPositionOffset";
            this.txtVPositionOffset.Size = new System.Drawing.Size(50, 21);
            this.txtVPositionOffset.TabIndex = 19;
            this.txtVPositionOffset.Text = "1";
            this.txtVPositionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Vertical position offset(1=0.29°)";
            // 
            // tmrPositionMonitor
            // 
            this.tmrPositionMonitor.Interval = 50;
            this.tmrPositionMonitor.Tick += new System.EventHandler(this.tmrPositionMonitor_Tick);
            // 
            // btnTorqueOn
            // 
            this.btnTorqueOn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTorqueOn.Location = new System.Drawing.Point(411, 194);
            this.btnTorqueOn.Name = "btnTorqueOn";
            this.btnTorqueOn.Size = new System.Drawing.Size(91, 26);
            this.btnTorqueOn.TabIndex = 20;
            this.btnTorqueOn.Text = "Torque On";
            this.btnTorqueOn.UseVisualStyleBackColor = true;
            this.btnTorqueOn.Click += new System.EventHandler(this.btnTorqueOn_Click);
            // 
            // RobotSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 382);
            this.Controls.Add(this.btnRobotParaReload);
            this.Controls.Add(this.btnRobotParaAdapt);
            this.Controls.Add(this.btnTorqueOn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnTorqueOff);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RobotSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Robot Setting";
            this.Load += new System.EventHandler(this.RobotSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAxis1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar scrAxis1;
        private System.Windows.Forms.HScrollBar scrAxis3;
        private System.Windows.Forms.Label lblAxis3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.HScrollBar scrAxis2;
        private System.Windows.Forms.Label lblAxis2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTorqueOff;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnToneB;
        private System.Windows.Forms.Button btnToneA;
        private System.Windows.Forms.Button btnToneG;
        private System.Windows.Forms.Button btnToneF;
        private System.Windows.Forms.Button btnToneE;
        private System.Windows.Forms.Button btnToneD;
        private System.Windows.Forms.Button btnToneC;
        private System.Windows.Forms.Button btnToneC_high;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRobotParaAdapt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVPositionOffset;
        private System.Windows.Forms.Button btnRobotParaReload;
        private System.Windows.Forms.Timer tmrPositionMonitor;
        private System.Windows.Forms.Button btnTorqueOn;
        private System.Windows.Forms.TextBox txtHPositionOffset;
        private System.Windows.Forms.Label label16;
    }
}