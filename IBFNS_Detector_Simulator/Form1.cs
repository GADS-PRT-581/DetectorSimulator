/********* Libraries are Defined ***********/
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
/********* Libraries are Defined ***********/

namespace IBFNS_Detector_Simulator
{
    public partial class IBFNS_Detector_Simulator : Form
    {

        /********* Variables are Defined ***********/
        int RxData;                     // Received Data
        int Number;                     // Used for converting String to int
        int ConnectionStatus = 0;       // Conection Status Saved in this variable
        int Connected = 1;              // Connection Status Connected
        int Disconnected = 0;           // Connection Status Disconnected
        int ModbusAddress = 0x03;       // Constant modbus Address
        int ModbusFunction = 0x04;      // Constant modbus function
        int ModbusCRC1;                 // to check CRC if data lost or not
        int ModbusCRC2;                 // to check CRC if data lost or not
        int DeviceType = 0x00;          // Holds device Type
        int HeatDetector = 0x01;        // Device Type Heat Detecor
        int SmokeDetector = 0x02;       // Device Type Smoke Detecot
        int ButtonDevice = 0x03;        // Device Type Button
        int DeviceAdress = 0x00;        // Initial Device Address
        int AlarmThreshold = 0x00;      // Initial Alarm Threshold Lvl
        int Temperature = 0x00;         // Initial Temperature
        int Smokelvl = 0x00;            // Initial Smokelvl
        int AlarmStatus = 0x00;         // Holds Alarm Status
        int Alarm = 0x0A;               // Alarm Status - Alarm
        int NoAlarm = 0x0B;             // Alarm Status - NoAlarm
        int Reset = 0x55;               // Initial Smokelvl
        /********* Variables are Defined ***********/
        public IBFNS_Detector_Simulator()
        {
            InitializeComponent();
        }

        /*-----------------------------------------------------------------
           Function Name: IBFNS_Detector_Simulator_Load 
           Function Called: When application started First Time  
           Function Purpose: It initialize Serial port settings 
           Inputs: none
           Outputs: Serial Port Coms and Serial Port Baudrate
        -----------------------------------------------------------------*/
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
        }

        /*-----------------------------------------------------------------
           Function Name: button_Connect_Click 
           Function Called: When Connect Button Called  
           Function Purpose: User can connect selected port name
           Inputs: Port name, Baudrate
           Outputs: Textbox Notification, Buton Text and colour change
        -----------------------------------------------------------------*/
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
                    richTextBox_Report.Text = Environment.NewLine + "Port Connected.";
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
        /*-----------------------------------------------------------------
           Function Name: serialPort1_DataReceived 
           Function Called: When application received serial data from RPI 
           Function Purpose: Ir saves received data to RxData Variable
           Inputs: Serial Interrupt
           Outputs: RxData
        -----------------------------------------------------------------*/
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxData = serialPort1.ReadByte();
        }
        /*-----------------------------------------------------------------
           Function Name: buttonConnectD_Click 
           Function Called: When user clicked Connect Device Button  
           Function Purpose: It enables timer and start serial communication. 
           Inputs: Click Interrupt
           Outputs: ConnectionStatus, richTextBox_Report.Text, Button name and colour
        -----------------------------------------------------------------*/
        private void buttonConnectD_Click(object sender, EventArgs e)
        {
            if (buttonConnectD.Text == "Connect Device")
            {
                buttonConnectD.Text = "Device Connected";
                buttonConnectD.BackColor = Color.Green;
                buttonConnectD.ForeColor = Color.White;
                ConnectionStatus = Connected;
                timer1.Enabled=true;
                richTextBox_Report.Text += Environment.NewLine + "Device Connected.";

            }
            else
            {
                buttonConnectD.Text = "Connect Device";
                buttonConnectD.BackColor = Color.White;
                buttonConnectD.ForeColor = Color.Black;
                ConnectionStatus = Disconnected;
                timer1.Enabled = false;
                richTextBox_Report.Text += Environment.NewLine + "Device Disconnected.";
            }
        }
        /*-----------------------------------------------------------------
           Function Name: buttonSendAlarm_Click 
           Function Called: When user clicked Send Alarm Button  
           Function Purpose: It sends alarm to RPI
           Inputs: Click Interrupt
           Outputs: AlarmStatus, textTemperature.Text, textSmokeLevel.Text, buttonSendAlarm.Text
           button name and colour.
        -----------------------------------------------------------------*/
        private void buttonSendAlarm_Click(object sender, EventArgs e)
        {
            if (buttonSendAlarm.Text == "Send Alarm")
            {
                buttonSendAlarm.Text = "ALARM";
                buttonSendAlarm.BackColor = Color.Green;
                buttonSendAlarm.ForeColor = Color.White;
                AlarmStatus = Alarm;
                textTemperature.Text = "50";
                textSmokeLevel.Text = "50";
                richTextBox_Report.Text += Environment.NewLine + "Alarm Sent.";
            }
            else
            {
                buttonSendAlarm.Text = "Send Alarm";
                buttonSendAlarm.BackColor = Color.White;
                buttonSendAlarm.ForeColor = Color.Black;
                AlarmStatus = NoAlarm;
                textTemperature.Text = "10";
                textSmokeLevel.Text = "10";
            }
        }
        /*-----------------------------------------------------------------
           Function Name: timer1_Tick 
           Function Called: When time interrupt occured  
           Function Purpose: To send data to RPI every 1 milisecond
           Inputs: textDeviceAddress, textBoxAlarmThr, textTemperature, textSmokeLevel
           Outputs: Writes Modbus Packets to Seruial Port
        -----------------------------------------------------------------*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ConnectionStatus == Connected)
            {
                bool success = Int32.TryParse(textDeviceAddress.Text, out Number); // Convert Str to Int
                if (success)
                {
                    DeviceAdress = Number;
                }
                success = Int32.TryParse(textBoxAlarmThr.Text, out Number); // Convert Str to Int
                if (success)
                {
                    AlarmThreshold = Number;
                }
                success = Int32.TryParse(textTemperature.Text, out Number); // Convert Str to Int
                if (success)
                {
                    Temperature = Number;
                }
                success = Int32.TryParse(textSmokeLevel.Text, out Number); // Convert Str to Int
                if (success)
                {
                    Smokelvl = Number;
                }
                // Check Heat Alarm
                if ((DeviceType==HeatDetector) && (Temperature> AlarmThreshold)) 
                {
                    buttonSendAlarm.Text = "ALARM";
                    buttonSendAlarm.BackColor = Color.Green;
                    buttonSendAlarm.ForeColor = Color.White;
                    AlarmStatus = Alarm;
                }
                else if ((DeviceType == HeatDetector) && (Temperature <= AlarmThreshold))
                {
                    buttonSendAlarm.Text = "Send Alarm";
                    buttonSendAlarm.BackColor = Color.White;
                    buttonSendAlarm.ForeColor = Color.Black;
                    AlarmStatus = NoAlarm;
                }
                // Check Heat Alarm
                // Check Smoke Alarm
                if ((DeviceType == SmokeDetector) && (Smokelvl > AlarmThreshold))
                {
                    buttonSendAlarm.Text = "ALARM";
                    buttonSendAlarm.BackColor = Color.Green;
                    buttonSendAlarm.ForeColor = Color.White;
                    AlarmStatus = Alarm;
                }
                else if ((DeviceType == SmokeDetector) && (Smokelvl <= AlarmThreshold))
                {
                    buttonSendAlarm.Text = "Send Alarm";
                    buttonSendAlarm.BackColor = Color.White;
                    buttonSendAlarm.ForeColor = Color.Black;
                    AlarmStatus = NoAlarm;
                }
                // Check Smoke Alarm

                // Check Received Data if it is equel to Device addres user entered then send response to RPI
                if (RxData == (byte)DeviceAdress)
                {
                    richTextBox_Report.Text += Environment.NewLine + "Modbus packet received for Address :" + DeviceAdress;
                    RxData = 0;
                    // Create CRC buffer
                    byte[] crcData = new byte[6];
                    crcData[0] = (byte)DeviceAdress;
                    crcData[1] = (byte)DeviceType;
                    crcData[2] = (byte)AlarmStatus;
                    crcData[3] = (byte)AlarmThreshold;
                    crcData[4] = (byte)Temperature;
                    crcData[5] = (byte)Smokelvl;
                    //Calculate CRC
                    ModbusCRC1 = (Crc16.ComputeCrc(crcData) >> 8) & 0x00FF;
                    ModbusCRC2 = Crc16.ComputeCrc(crcData) & 0x00FF;

                    // Create TX Array
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
                    // Write TxData
                    serialPort1.Write(txData, 0, 10);
                }
                // Check System Reset
                else if(RxData == Reset)
                {
                    RxData = 0;
                    buttonSendAlarm.Text = "Send Alarm";
                    buttonSendAlarm.BackColor = Color.White;
                    buttonSendAlarm.ForeColor = Color.Black;
                    AlarmStatus = NoAlarm;
                    textTemperature.Text = "10";
                    textSmokeLevel.Text = "10";
                    richTextBox_Report.Text += Environment.NewLine + "System Reset Received.";
                }
            }

        }
        /*-----------------------------------------------------------------
           Function Name: checkBox_HeatD_CheckedChanged 
           Function Called: When user chose a device type  
           Function Purpose:  Saves Device Type : HeatDetector
           Inputs: none
           Outputs: DeviceType
        -----------------------------------------------------------------*/
        private void checkBox_HeatD_CheckedChanged(object sender, EventArgs e)
        {
            DeviceType = HeatDetector;
        }
        /*-----------------------------------------------------------------
           Function Name: checkBox_SmokeD_CheckedChanged 
           Function Called: When user chose a device type
           Function Purpose: Saves Device Type : SmokeDetector 
           Inputs: none
           Outputs: Serial Port Coms and Serial Port Baudrate
        -----------------------------------------------------------------*/
        private void checkBox_SmokeD_CheckedChanged(object sender, EventArgs e)
        {
            DeviceType = SmokeDetector;
        }
        /*-----------------------------------------------------------------
           Function Name: checkBox_AlarmB_CheckedChanged 
           Function Called: When user chose a device type  
           Function Purpose: Saves Device Type : ButtonDevice 
           Inputs: none
           Outputs: Serial Port Coms and Serial Port Baudrate
        -----------------------------------------------------------------*/
        private void checkBox_AlarmB_CheckedChanged(object sender, EventArgs e)
        {
            DeviceType = ButtonDevice;
        }
    }
}
