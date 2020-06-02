namespace IBFNS_Detector_Simulator
{
    partial class IBFNS_Detector_Simulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBFNS_Detector_Simulator));
            this.buttonSendAlarm = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.comboBox_ComSelect = new System.Windows.Forms.ComboBox();
            this.comboBox_BaudrateSelect = new System.Windows.Forms.ComboBox();
            this.checkBox_HeatD = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDeviceAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTemperature = new System.Windows.Forms.TextBox();
            this.textSmokeLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_SmokeD = new System.Windows.Forms.CheckBox();
            this.checkBox_AlarmB = new System.Windows.Forms.CheckBox();
            this.richTextBox_Report = new System.Windows.Forms.RichTextBox();
            this.pictureBox_AlarmButton = new System.Windows.Forms.PictureBox();
            this.pictureBox_SmokeDetector = new System.Windows.Forms.PictureBox();
            this.pictureBox_HeatDetector = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonConnectD = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxAlarmThr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AlarmButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SmokeDetector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HeatDetector)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSendAlarm
            // 
            this.buttonSendAlarm.Location = new System.Drawing.Point(201, 432);
            this.buttonSendAlarm.Name = "buttonSendAlarm";
            this.buttonSendAlarm.Size = new System.Drawing.Size(160, 57);
            this.buttonSendAlarm.TabIndex = 0;
            this.buttonSendAlarm.Text = "Send Alarm";
            this.buttonSendAlarm.UseVisualStyleBackColor = true;
            this.buttonSendAlarm.Click += new System.EventHandler(this.buttonSendAlarm_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(201, 61);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(160, 59);
            this.button_Connect.TabIndex = 6;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // comboBox_ComSelect
            // 
            this.comboBox_ComSelect.FormattingEnabled = true;
            this.comboBox_ComSelect.Location = new System.Drawing.Point(201, 13);
            this.comboBox_ComSelect.Name = "comboBox_ComSelect";
            this.comboBox_ComSelect.Size = new System.Drawing.Size(73, 24);
            this.comboBox_ComSelect.TabIndex = 7;
            // 
            // comboBox_BaudrateSelect
            // 
            this.comboBox_BaudrateSelect.FormattingEnabled = true;
            this.comboBox_BaudrateSelect.Location = new System.Drawing.Point(287, 13);
            this.comboBox_BaudrateSelect.Name = "comboBox_BaudrateSelect";
            this.comboBox_BaudrateSelect.Size = new System.Drawing.Size(72, 24);
            this.comboBox_BaudrateSelect.TabIndex = 8;
            // 
            // checkBox_HeatD
            // 
            this.checkBox_HeatD.AutoSize = true;
            this.checkBox_HeatD.Location = new System.Drawing.Point(154, 13);
            this.checkBox_HeatD.Name = "checkBox_HeatD";
            this.checkBox_HeatD.Size = new System.Drawing.Size(18, 17);
            this.checkBox_HeatD.TabIndex = 9;
            this.checkBox_HeatD.UseVisualStyleBackColor = true;
            this.checkBox_HeatD.CheckedChanged += new System.EventHandler(this.checkBox_HeatD_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Device Address";
            // 
            // textDeviceAddress
            // 
            this.textDeviceAddress.Location = new System.Drawing.Point(311, 189);
            this.textDeviceAddress.Name = "textDeviceAddress";
            this.textDeviceAddress.Size = new System.Drawing.Size(50, 22);
            this.textDeviceAddress.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Temperature";
            // 
            // textTemperature
            // 
            this.textTemperature.Location = new System.Drawing.Point(311, 249);
            this.textTemperature.Name = "textTemperature";
            this.textTemperature.Size = new System.Drawing.Size(50, 22);
            this.textTemperature.TabIndex = 17;
            // 
            // textSmokeLevel
            // 
            this.textSmokeLevel.Location = new System.Drawing.Point(311, 280);
            this.textSmokeLevel.Name = "textSmokeLevel";
            this.textSmokeLevel.Size = new System.Drawing.Size(50, 22);
            this.textSmokeLevel.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "Smoke Level";
            // 
            // checkBox_SmokeD
            // 
            this.checkBox_SmokeD.AutoSize = true;
            this.checkBox_SmokeD.Location = new System.Drawing.Point(154, 191);
            this.checkBox_SmokeD.Name = "checkBox_SmokeD";
            this.checkBox_SmokeD.Size = new System.Drawing.Size(18, 17);
            this.checkBox_SmokeD.TabIndex = 32;
            this.checkBox_SmokeD.UseVisualStyleBackColor = true;
            this.checkBox_SmokeD.CheckedChanged += new System.EventHandler(this.checkBox_SmokeD_CheckedChanged);
            // 
            // checkBox_AlarmB
            // 
            this.checkBox_AlarmB.AutoSize = true;
            this.checkBox_AlarmB.Location = new System.Drawing.Point(154, 369);
            this.checkBox_AlarmB.Name = "checkBox_AlarmB";
            this.checkBox_AlarmB.Size = new System.Drawing.Size(18, 17);
            this.checkBox_AlarmB.TabIndex = 33;
            this.checkBox_AlarmB.UseVisualStyleBackColor = true;
            this.checkBox_AlarmB.CheckedChanged += new System.EventHandler(this.checkBox_AlarmB_CheckedChanged);
            // 
            // richTextBox_Report
            // 
            this.richTextBox_Report.Location = new System.Drawing.Point(382, 13);
            this.richTextBox_Report.Name = "richTextBox_Report";
            this.richTextBox_Report.Size = new System.Drawing.Size(257, 513);
            this.richTextBox_Report.TabIndex = 38;
            this.richTextBox_Report.Text = "";
            // 
            // pictureBox_AlarmButton
            // 
            this.pictureBox_AlarmButton.Image = global::IBFNS_Detector_Simulator.Properties.Resources.fire_alarm_pushbutton;
            this.pictureBox_AlarmButton.Location = new System.Drawing.Point(12, 367);
            this.pictureBox_AlarmButton.Name = "pictureBox_AlarmButton";
            this.pictureBox_AlarmButton.Size = new System.Drawing.Size(160, 159);
            this.pictureBox_AlarmButton.TabIndex = 5;
            this.pictureBox_AlarmButton.TabStop = false;
            // 
            // pictureBox_SmokeDetector
            // 
            this.pictureBox_SmokeDetector.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_SmokeDetector.Image")));
            this.pictureBox_SmokeDetector.Location = new System.Drawing.Point(12, 191);
            this.pictureBox_SmokeDetector.Name = "pictureBox_SmokeDetector";
            this.pictureBox_SmokeDetector.Size = new System.Drawing.Size(160, 159);
            this.pictureBox_SmokeDetector.TabIndex = 4;
            this.pictureBox_SmokeDetector.TabStop = false;
            // 
            // pictureBox_HeatDetector
            // 
            this.pictureBox_HeatDetector.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_HeatDetector.Image")));
            this.pictureBox_HeatDetector.Location = new System.Drawing.Point(12, 13);
            this.pictureBox_HeatDetector.Name = "pictureBox_HeatDetector";
            this.pictureBox_HeatDetector.Size = new System.Drawing.Size(160, 159);
            this.pictureBox_HeatDetector.TabIndex = 3;
            this.pictureBox_HeatDetector.TabStop = false;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Baudrate";
            // 
            // buttonConnectD
            // 
            this.buttonConnectD.Location = new System.Drawing.Point(203, 367);
            this.buttonConnectD.Name = "buttonConnectD";
            this.buttonConnectD.Size = new System.Drawing.Size(158, 57);
            this.buttonConnectD.TabIndex = 43;
            this.buttonConnectD.Text = "Connect Device";
            this.buttonConnectD.UseVisualStyleBackColor = true;
            this.buttonConnectD.Click += new System.EventHandler(this.buttonConnectD_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxAlarmThr
            // 
            this.textBoxAlarmThr.Location = new System.Drawing.Point(311, 219);
            this.textBoxAlarmThr.Name = "textBoxAlarmThr";
            this.textBoxAlarmThr.Size = new System.Drawing.Size(50, 22);
            this.textBoxAlarmThr.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Alarm Threshold";
            // 
            // IBFNS_Detector_Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(651, 546);
            this.Controls.Add(this.textBoxAlarmThr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonConnectD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox_Report);
            this.Controls.Add(this.checkBox_AlarmB);
            this.Controls.Add(this.checkBox_SmokeD);
            this.Controls.Add(this.textSmokeLevel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textTemperature);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDeviceAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_HeatD);
            this.Controls.Add(this.comboBox_BaudrateSelect);
            this.Controls.Add(this.comboBox_ComSelect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.pictureBox_AlarmButton);
            this.Controls.Add(this.pictureBox_SmokeDetector);
            this.Controls.Add(this.pictureBox_HeatDetector);
            this.Controls.Add(this.buttonSendAlarm);
            this.DoubleBuffered = true;
            this.Name = "IBFNS_Detector_Simulator";
            this.Text = "IBFNS Detector Simulator";
            this.Load += new System.EventHandler(this.IBFNS_Detector_Simulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AlarmButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SmokeDetector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HeatDetector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSendAlarm;
        private System.Windows.Forms.PictureBox pictureBox_HeatDetector;
        private System.Windows.Forms.PictureBox pictureBox_SmokeDetector;
        private System.Windows.Forms.PictureBox pictureBox_AlarmButton;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.ComboBox comboBox_ComSelect;
        private System.Windows.Forms.ComboBox comboBox_BaudrateSelect;
        private System.Windows.Forms.CheckBox checkBox_HeatD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDeviceAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTemperature;
        private System.Windows.Forms.TextBox textSmokeLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_SmokeD;
        private System.Windows.Forms.CheckBox checkBox_AlarmB;
        private System.Windows.Forms.RichTextBox richTextBox_Report;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonConnectDevice;
        private System.Windows.Forms.Button buttonConnectD;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxAlarmThr;
        private System.Windows.Forms.Label label3;
    }
}

