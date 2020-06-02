using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace IBFNS_Detector_Simulator
{
    public partial class IBFNS_Detector_Simulator : Form
    {
        int RxData;
        int Connection = 0;
        int ModbusAddress = 0x03; // Fix modbus Address
        int ModbusFunction = 0x04; // Fix modbus function
        int ModbusCRC1; // to check if data lost or not
        int ModbusCRC2; // to check if data lost or not
        int DeviceType = 0x05;
        int DeviceAdress = 0x06;
        int AlarmThreshold = 0x07;
        int Temperature = 0x08;
        int Smokelvl = 0x09;
        int AlarmStatus = 0x10;
        int Reset = 0x55;
        public IBFNS_Detector_Simulator()
        {
            InitializeComponent();
        }

        private void IBFNS_Detector_Simulator_Load(object sender, EventArgs e)
        {
            pictureBox_HeatDetector.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_SmokeDetector.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_AlarmButton.SizeMode = PictureBoxSizeMode.StretchImage;
            comboBox_BaudrateSelect.Items.Add("4800");
            comboBox_BaudrateSelect.Items.Add("9600");
            comboBox_BaudrateSelect.Items.Add("19200");
            if (serialPort1.IsOpen)
                serialPort1.Close();
            foreach (String portNames in SerialPort.GetPortNames())
                comboBox_ComSelect.Items.Add(portNames);
            richTextBox_Report.Text = Environment.NewLine + "Port Connected.";
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (button_Connect.Text == "Connect")
            {
                if (comboBox_ComSelect.Text == "")
                {
                    MessageBox.Show("Please Select a Port!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (comboBox_BaudrateSelect.Text == "")
                {
                    MessageBox.Show("Please Select a Baudrate!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (comboBox_ComSelect.SelectedItem != null)
                {
                    serialPort1.PortName = comboBox_ComSelect.SelectedItem.ToString();
                    serialPort1.BaudRate = int.Parse(comboBox_BaudrateSelect.SelectedItem.ToString()); ;
                    serialPort1.Parity = 0;
                    serialPort1.DataBits = 8;
                    button_Connect.Text = "Disconnect";
                    button_Connect.BackColor = Color.Green;
                    button_Connect.ForeColor = Color.White;
                    serialPort1.Open();
                }

            }
            else
            {
                serialPort1.Close();
                button_Connect.Text = "Connect";
                button_Connect.BackColor = Color.White;
                button_Connect.ForeColor = Color.Black;
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            RxData = serialPort1.ReadByte();


        }

        private void buttonConnectD_Click(object sender, EventArgs e)
        {
            if (buttonConnectD.Text == "Connect Device")
            {
                buttonConnectD.Text = "Device Connected";
                buttonConnectD.BackColor = Color.Green;
                buttonConnectD.ForeColor = Color.White;
                Connection = 1;
                timer1.Enabled=true;
                richTextBox_Report.Text += Environment.NewLine + "Device Connected.";

            }
            else
            {
                buttonConnectD.Text = "Connect Device";
                buttonConnectD.BackColor = Color.White;
                buttonConnectD.ForeColor = Color.Black;
                Connection = 0;
                timer1.Enabled = false;
                richTextBox_Report.Text += Environment.NewLine + "Device Disconnected.";
            }
        }

        private void buttonSendAlarm_Click(object sender, EventArgs e)
        {
            if (buttonSendAlarm.Text == "Send Alarm")
            {
                buttonSendAlarm.Text = "ALARM";
                buttonSendAlarm.BackColor = Color.Green;
                buttonSendAlarm.ForeColor = Color.White;
                AlarmStatus = 0x0A;
                richTextBox_Report.Text += Environment.NewLine + "Alarm Sent.";
            }
            else
            {
                buttonSendAlarm.Text = "Send Alarm";
                buttonSendAlarm.BackColor = Color.White;
                buttonSendAlarm.ForeColor = Color.Black;
                AlarmStatus = 0x0B;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Connection == 1)
            {
                DeviceAdress = int.Parse(textDeviceAddress.Text);
                AlarmThreshold = int.Parse(textBoxAlarmThr.Text);
                Temperature = int.Parse(textTemperature.Text);
                Smokelvl = int.Parse(textSmokeLevel.Text);
                if(Temperature> AlarmThreshold)
                {
                    buttonSendAlarm.Text = "ALARM";
                    buttonSendAlarm.BackColor = Color.Green;
                    buttonSendAlarm.ForeColor = Color.White;
                    AlarmStatus = 0x0A;
                }
                else
                {
                    buttonSendAlarm.Text = "Send Alarm";
                    buttonSendAlarm.BackColor = Color.White;
                    buttonSendAlarm.ForeColor = Color.Black;
                    AlarmStatus = 0x0B;
                }
                    
                if (RxData == (byte)DeviceAdress)
                {

                    richTextBox_Report.Text += Environment.NewLine + "Modbus packet received for Address :" + DeviceAdress;
                    RxData = 0;
                    byte[] crcData = new byte[6];
                    crcData[0] = (byte)DeviceAdress;
                    crcData[1] = (byte)DeviceType;
                    crcData[2] = (byte)AlarmStatus;
                    crcData[3] = (byte)AlarmThreshold;
                    crcData[4] = (byte)Temperature;
                    crcData[5] = (byte)Smokelvl;
                    ModbusCRC1 = (Crc16.ComputeCrc(crcData) >> 8) & 0x00FF;
                    ModbusCRC2 = Crc16.ComputeCrc(crcData) & 0x00FF;
                    byte[] txData = new byte[10];
                    txData[0] = (byte)ModbusAddress;
                    txData[1] = (byte)ModbusFunction;
                    txData[2] = (byte)DeviceAdress;
                    txData[3] = (byte)DeviceType;
                    txData[4] = (byte)AlarmStatus;
                    txData[5] = (byte)AlarmThreshold;
                    txData[6] = (byte)Temperature;
                    txData[7] = (byte)Smokelvl;
                    txData[8] = (byte)ModbusCRC1;
                    txData[9] = (byte)ModbusCRC2;
                    serialPort1.Write(txData, 0, 10);
                }
                else if(RxData == Reset)
                {
                    RxData = 0;
                    buttonSendAlarm.Text = "Send Alarm";
                    buttonSendAlarm.BackColor = Color.White;
                    buttonSendAlarm.ForeColor = Color.Black;
                    AlarmStatus = 0x0B;
                    richTextBox_Report.Text += Environment.NewLine + "System Reset Received.";
                }
            }

        }
        private void checkBox_HeatD_CheckedChanged(object sender, EventArgs e)
        {
            DeviceType = 0x01;
        }

        private void checkBox_SmokeD_CheckedChanged(object sender, EventArgs e)
        {
            DeviceType = 0x02;
        }

        private void checkBox_AlarmB_CheckedChanged(object sender, EventArgs e)
        {
            DeviceType = 0x03;
        }
    }
}
