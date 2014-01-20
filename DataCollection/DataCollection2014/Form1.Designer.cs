namespace DataCollection2014
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.gyroAngle = new System.Windows.Forms.TextBox();
            this.packetCounter = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rightFrontAmps = new System.Windows.Forms.TextBox();
            this.leftBackAmps = new System.Windows.Forms.TextBox();
            this.rightBackAmps = new System.Windows.Forms.TextBox();
            this.LeftFrontAmps = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rightFrontVolts = new System.Windows.Forms.TextBox();
            this.leftBackVolts = new System.Windows.Forms.TextBox();
            this.rightBackVolts = new System.Windows.Forms.TextBox();
            this.leftFrontVolts = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RightFrontEncoder = new System.Windows.Forms.TextBox();
            this.LeftBackEncoder = new System.Windows.Forms.TextBox();
            this.RightBackEncoder = new System.Windows.Forms.TextBox();
            this.LeftFrontEncoder = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.BatteryID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BatteryAmps = new System.Windows.Forms.TextBox();
            this.BatteryVolts = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DisconnectionMessages = new System.Windows.Forms.RichTextBox();
            this.General2 = new System.Windows.Forms.TabPage();
            this.ConsoleStatus = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.NetConsoleDisplay = new System.Windows.Forms.RichTextBox();
            this.Status = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.slowSpeed = new System.Windows.Forms.RadioButton();
            this.ultraSpeed = new System.Windows.Forms.RadioButton();
            this.mediumSpeed = new System.Windows.Forms.RadioButton();
            this.fastSpeed = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Listen = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.SavetoDisk = new System.Windows.Forms.Button();
            this.ListenTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.General.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ConsoleStatus.SuspendLayout();
            this.Status.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.General);
            this.tabControl1.Controls.Add(this.General2);
            this.tabControl1.Controls.Add(this.ConsoleStatus);
            this.tabControl1.Controls.Add(this.Status);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 259);
            this.tabControl1.TabIndex = 0;
            // 
            // General
            // 
            this.General.Controls.Add(this.label20);
            this.General.Controls.Add(this.gyroAngle);
            this.General.Controls.Add(this.packetCounter);
            this.General.Controls.Add(this.label19);
            this.General.Controls.Add(this.panel10);
            this.General.Controls.Add(this.panel9);
            this.General.Controls.Add(this.panel7);
            this.General.Controls.Add(this.panel4);
            this.General.Controls.Add(this.panel3);
            this.General.Controls.Add(this.DisconnectionMessages);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(535, 233);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(89, 183);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 17;
            this.label20.Text = "Gyro Angle";
            // 
            // gyroAngle
            // 
            this.gyroAngle.Location = new System.Drawing.Point(84, 199);
            this.gyroAngle.Name = "gyroAngle";
            this.gyroAngle.Size = new System.Drawing.Size(64, 20);
            this.gyroAngle.TabIndex = 16;
            // 
            // packetCounter
            // 
            this.packetCounter.Location = new System.Drawing.Point(3, 199);
            this.packetCounter.Name = "packetCounter";
            this.packetCounter.Size = new System.Drawing.Size(69, 20);
            this.packetCounter.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(0, 183);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Packet Count";
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(215, 112);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 100);
            this.panel10.TabIndex = 13;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.rightFrontAmps);
            this.panel9.Controls.Add(this.leftBackAmps);
            this.panel9.Controls.Add(this.rightBackAmps);
            this.panel9.Controls.Add(this.LeftFrontAmps);
            this.panel9.Controls.Add(this.label25);
            this.panel9.Controls.Add(this.label26);
            this.panel9.Controls.Add(this.label27);
            this.panel9.Controls.Add(this.label28);
            this.panel9.Controls.Add(this.label18);
            this.panel9.Location = new System.Drawing.Point(396, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(133, 100);
            this.panel9.TabIndex = 12;
            // 
            // rightFrontAmps
            // 
            this.rightFrontAmps.Location = new System.Drawing.Point(68, 29);
            this.rightFrontAmps.Name = "rightFrontAmps";
            this.rightFrontAmps.Size = new System.Drawing.Size(60, 20);
            this.rightFrontAmps.TabIndex = 16;
            // 
            // leftBackAmps
            // 
            this.leftBackAmps.Location = new System.Drawing.Point(6, 68);
            this.leftBackAmps.Name = "leftBackAmps";
            this.leftBackAmps.Size = new System.Drawing.Size(60, 20);
            this.leftBackAmps.TabIndex = 18;
            // 
            // rightBackAmps
            // 
            this.rightBackAmps.Location = new System.Drawing.Point(68, 68);
            this.rightBackAmps.Name = "rightBackAmps";
            this.rightBackAmps.Size = new System.Drawing.Size(60, 20);
            this.rightBackAmps.TabIndex = 14;
            // 
            // LeftFrontAmps
            // 
            this.LeftFrontAmps.Location = new System.Drawing.Point(6, 29);
            this.LeftFrontAmps.Name = "LeftFrontAmps";
            this.LeftFrontAmps.Size = new System.Drawing.Size(60, 20);
            this.LeftFrontAmps.TabIndex = 20;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(70, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 21;
            this.label25.Text = "Right Back";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 17;
            this.label26.Text = "Left Front";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 13);
            this.label27.TabIndex = 19;
            this.label27.Text = "Left Back";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(69, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 13);
            this.label28.TabIndex = 15;
            this.label28.Text = "Right Front";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Current";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rightFrontVolts);
            this.panel7.Controls.Add(this.leftBackVolts);
            this.panel7.Controls.Add(this.rightBackVolts);
            this.panel7.Controls.Add(this.leftFrontVolts);
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.label23);
            this.panel7.Controls.Add(this.label24);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Location = new System.Drawing.Point(253, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(137, 100);
            this.panel7.TabIndex = 11;
            // 
            // rightFrontVolts
            // 
            this.rightFrontVolts.Location = new System.Drawing.Point(72, 29);
            this.rightFrontVolts.Name = "rightFrontVolts";
            this.rightFrontVolts.Size = new System.Drawing.Size(60, 20);
            this.rightFrontVolts.TabIndex = 16;
            // 
            // leftBackVolts
            // 
            this.leftBackVolts.Location = new System.Drawing.Point(6, 68);
            this.leftBackVolts.Name = "leftBackVolts";
            this.leftBackVolts.Size = new System.Drawing.Size(60, 20);
            this.leftBackVolts.TabIndex = 18;
            // 
            // rightBackVolts
            // 
            this.rightBackVolts.Location = new System.Drawing.Point(72, 66);
            this.rightBackVolts.Name = "rightBackVolts";
            this.rightBackVolts.Size = new System.Drawing.Size(60, 20);
            this.rightBackVolts.TabIndex = 14;
            // 
            // leftFrontVolts
            // 
            this.leftFrontVolts.Location = new System.Drawing.Point(6, 29);
            this.leftFrontVolts.Name = "leftFrontVolts";
            this.leftFrontVolts.Size = new System.Drawing.Size(60, 20);
            this.leftFrontVolts.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "Right Back";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 17;
            this.label22.Text = "Left Front";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Left Back";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(69, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Right Front";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Voltages";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.RightFrontEncoder);
            this.panel4.Controls.Add(this.LeftBackEncoder);
            this.panel4.Controls.Add(this.RightBackEncoder);
            this.panel4.Controls.Add(this.LeftFrontEncoder);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(109, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(138, 100);
            this.panel4.TabIndex = 10;
            // 
            // RightFrontEncoder
            // 
            this.RightFrontEncoder.Location = new System.Drawing.Point(72, 29);
            this.RightFrontEncoder.Name = "RightFrontEncoder";
            this.RightFrontEncoder.Size = new System.Drawing.Size(60, 20);
            this.RightFrontEncoder.TabIndex = 9;
            // 
            // LeftBackEncoder
            // 
            this.LeftBackEncoder.Location = new System.Drawing.Point(6, 68);
            this.LeftBackEncoder.Name = "LeftBackEncoder";
            this.LeftBackEncoder.Size = new System.Drawing.Size(60, 20);
            this.LeftBackEncoder.TabIndex = 10;
            // 
            // RightBackEncoder
            // 
            this.RightBackEncoder.Location = new System.Drawing.Point(72, 68);
            this.RightBackEncoder.Name = "RightBackEncoder";
            this.RightBackEncoder.Size = new System.Drawing.Size(60, 20);
            this.RightBackEncoder.TabIndex = 8;
            // 
            // LeftFrontEncoder
            // 
            this.LeftFrontEncoder.Location = new System.Drawing.Point(6, 29);
            this.LeftFrontEncoder.Name = "LeftFrontEncoder";
            this.LeftFrontEncoder.Size = new System.Drawing.Size(60, 20);
            this.LeftFrontEncoder.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(69, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Right Back";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Encoders";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Left Front";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Left Back";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Right Front";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.BatteryID);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.BatteryAmps);
            this.panel3.Controls.Add(this.BatteryVolts);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 92);
            this.panel3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "V";
            // 
            // BatteryID
            // 
            this.BatteryID.Location = new System.Drawing.Point(34, 69);
            this.BatteryID.Name = "BatteryID";
            this.BatteryID.Size = new System.Drawing.Size(42, 20);
            this.BatteryID.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "#";
            // 
            // BatteryAmps
            // 
            this.BatteryAmps.Location = new System.Drawing.Point(23, 46);
            this.BatteryAmps.Name = "BatteryAmps";
            this.BatteryAmps.Size = new System.Drawing.Size(60, 20);
            this.BatteryAmps.TabIndex = 7;
            // 
            // BatteryVolts
            // 
            this.BatteryVolts.Location = new System.Drawing.Point(23, 20);
            this.BatteryVolts.Name = "BatteryVolts";
            this.BatteryVolts.Size = new System.Drawing.Size(60, 20);
            this.BatteryVolts.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Battery Status";
            // 
            // DisconnectionMessages
            // 
            this.DisconnectionMessages.AccessibleDescription = "stuff";
            this.DisconnectionMessages.AccessibleName = "textBox";
            this.DisconnectionMessages.Location = new System.Drawing.Point(4, 112);
            this.DisconnectionMessages.Name = "DisconnectionMessages";
            this.DisconnectionMessages.ReadOnly = true;
            this.DisconnectionMessages.Size = new System.Drawing.Size(205, 68);
            this.DisconnectionMessages.TabIndex = 8;
            this.DisconnectionMessages.Text = "look for disconnection messages here ";
            // 
            // General2
            // 
            this.General2.Location = new System.Drawing.Point(4, 22);
            this.General2.Name = "General2";
            this.General2.Size = new System.Drawing.Size(535, 233);
            this.General2.TabIndex = 3;
            this.General2.Text = "General2";
            this.General2.UseVisualStyleBackColor = true;
            // 
            // ConsoleStatus
            // 
            this.ConsoleStatus.Controls.Add(this.label12);
            this.ConsoleStatus.Controls.Add(this.NetConsoleDisplay);
            this.ConsoleStatus.Location = new System.Drawing.Point(4, 22);
            this.ConsoleStatus.Name = "ConsoleStatus";
            this.ConsoleStatus.Padding = new System.Windows.Forms.Padding(3);
            this.ConsoleStatus.Size = new System.Drawing.Size(535, 233);
            this.ConsoleStatus.TabIndex = 1;
            this.ConsoleStatus.Text = "NetConsole";
            this.ConsoleStatus.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "NetConsole Information";
            // 
            // NetConsoleDisplay
            // 
            this.NetConsoleDisplay.Location = new System.Drawing.Point(16, 20);
            this.NetConsoleDisplay.Name = "NetConsoleDisplay";
            this.NetConsoleDisplay.ReadOnly = true;
            this.NetConsoleDisplay.Size = new System.Drawing.Size(420, 207);
            this.NetConsoleDisplay.TabIndex = 1;
            this.NetConsoleDisplay.Text = "";
            // 
            // Status
            // 
            this.Status.Controls.Add(this.label15);
            this.Status.Controls.Add(this.label14);
            this.Status.Controls.Add(this.label1);
            this.Status.Controls.Add(this.panel8);
            this.Status.Controls.Add(this.panel6);
            this.Status.Controls.Add(this.panel5);
            this.Status.Controls.Add(this.panel2);
            this.Status.Controls.Add(this.panel1);
            this.Status.Location = new System.Drawing.Point(4, 22);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(535, 233);
            this.Status.TabIndex = 2;
            this.Status.Text = "Status";
            this.Status.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(275, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Buttons";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(125, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Joystick Axis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Connection Status";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.radioButton6);
            this.panel8.Controls.Add(this.radioButton5);
            this.panel8.Controls.Add(this.label17);
            this.panel8.Location = new System.Drawing.Point(12, 160);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(152, 57);
            this.panel8.TabIndex = 15;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(3, 39);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(151, 17);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Resume When Connected";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(3, 16);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(92, 17);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Stop Listening";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "When Dissconected:";
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(215, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(165, 100);
            this.panel6.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(108, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(101, 101);
            this.panel5.TabIndex = 13;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.slowSpeed);
            this.panel2.Controls.Add(this.ultraSpeed);
            this.panel2.Controls.Add(this.mediumSpeed);
            this.panel2.Controls.Add(this.fastSpeed);
            this.panel2.Location = new System.Drawing.Point(12, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 104);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Update Speed";
            // 
            // slowSpeed
            // 
            this.slowSpeed.AutoSize = true;
            this.slowSpeed.Location = new System.Drawing.Point(-1, 85);
            this.slowSpeed.Name = "slowSpeed";
            this.slowSpeed.Size = new System.Drawing.Size(48, 17);
            this.slowSpeed.TabIndex = 6;
            this.slowSpeed.TabStop = true;
            this.slowSpeed.Text = "Slow";
            this.slowSpeed.UseVisualStyleBackColor = true;
            this.slowSpeed.CheckedChanged += new System.EventHandler(this.slowSpeed_CheckedChanged);
            // 
            // ultraSpeed
            // 
            this.ultraSpeed.AutoSize = true;
            this.ultraSpeed.Location = new System.Drawing.Point(-1, 16);
            this.ultraSpeed.Name = "ultraSpeed";
            this.ultraSpeed.Size = new System.Drawing.Size(47, 17);
            this.ultraSpeed.TabIndex = 3;
            this.ultraSpeed.TabStop = true;
            this.ultraSpeed.Text = "Ultra";
            this.ultraSpeed.UseVisualStyleBackColor = true;
            this.ultraSpeed.CheckedChanged += new System.EventHandler(this.ultraSpeed_CheckedChanged);
            // 
            // mediumSpeed
            // 
            this.mediumSpeed.AutoSize = true;
            this.mediumSpeed.Checked = true;
            this.mediumSpeed.Location = new System.Drawing.Point(-1, 62);
            this.mediumSpeed.Name = "mediumSpeed";
            this.mediumSpeed.Size = new System.Drawing.Size(62, 17);
            this.mediumSpeed.TabIndex = 5;
            this.mediumSpeed.TabStop = true;
            this.mediumSpeed.Text = "Medium";
            this.mediumSpeed.UseVisualStyleBackColor = true;
            this.mediumSpeed.CheckedChanged += new System.EventHandler(this.mediumSpeed_CheckedChanged);
            // 
            // fastSpeed
            // 
            this.fastSpeed.AutoSize = true;
            this.fastSpeed.Location = new System.Drawing.Point(-1, 39);
            this.fastSpeed.Name = "fastSpeed";
            this.fastSpeed.Size = new System.Drawing.Size(45, 17);
            this.fastSpeed.TabIndex = 4;
            this.fastSpeed.Text = "Fast";
            this.fastSpeed.UseVisualStyleBackColor = true;
            this.fastSpeed.CheckedChanged += new System.EventHandler(this.fastSpeed_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.ForeColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 23);
            this.panel1.TabIndex = 11;
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(12, 277);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(43, 23);
            this.Listen.TabIndex = 1;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.Listen_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(61, 277);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(45, 23);
            this.Pause.TabIndex = 2;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(112, 277);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(37, 23);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // SavetoDisk
            // 
            this.SavetoDisk.Location = new System.Drawing.Point(155, 277);
            this.SavetoDisk.Name = "SavetoDisk";
            this.SavetoDisk.Size = new System.Drawing.Size(77, 23);
            this.SavetoDisk.TabIndex = 4;
            this.SavetoDisk.Text = "Save to Disk";
            this.SavetoDisk.UseVisualStyleBackColor = true;
            this.SavetoDisk.Click += new System.EventHandler(this.SavetoDisk_Click);
            // 
            // ListenTimer
            // 
            this.ListenTimer.Enabled = true;
            this.ListenTimer.Tick += new System.EventHandler(this.ListenTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 302);
            this.Controls.Add(this.SavetoDisk);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "DataListener2014";
            this.tabControl1.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ConsoleStatus.ResumeLayout(false);
            this.ConsoleStatus.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage ConsoleStatus;
        private System.Windows.Forms.TabPage Status;
        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button SavetoDisk;
        private System.Windows.Forms.Timer ListenTimer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox RightFrontEncoder;
        private System.Windows.Forms.TextBox LeftBackEncoder;
        private System.Windows.Forms.TextBox RightBackEncoder;
        private System.Windows.Forms.TextBox LeftFrontEncoder;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox BatteryID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BatteryAmps;
        private System.Windows.Forms.TextBox BatteryVolts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RichTextBox DisconnectionMessages;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox NetConsoleDisplay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton slowSpeed;
        private System.Windows.Forms.RadioButton ultraSpeed;
        private System.Windows.Forms.RadioButton mediumSpeed;
        private System.Windows.Forms.RadioButton fastSpeed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage General2;
        private System.Windows.Forms.TextBox packetCounter;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox gyroAngle;
        private System.Windows.Forms.TextBox rightFrontAmps;
        private System.Windows.Forms.TextBox leftBackAmps;
        private System.Windows.Forms.TextBox rightBackAmps;
        private System.Windows.Forms.TextBox LeftFrontAmps;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox rightFrontVolts;
        private System.Windows.Forms.TextBox leftBackVolts;
        private System.Windows.Forms.TextBox rightBackVolts;
        private System.Windows.Forms.TextBox leftFrontVolts;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
    }
}

