using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
// The following serial port commands are just for the srail communication.
// They are not the true commands the spi memory supports.
// Serial Port Commands are:
/*
    0x01 : Write Enable
    0x02 : Volatile SR Write Enable
    0x03 : Write Disable 
    0x04 : Read Status Register 1
    0x05 : Read Status Register 2
    0x06 : Write Status Register
    0x07 : Page Program
    0x08 : Sector Erase (4KB)
    0x09 : Block Erase (32KB)
    0x0A : Block Erase (64KB)
    0x0B : Chip Erase
    0x0C : Erase / Program Suspend
    0x0D : Erase / Program Resume
    0x0E : Power-down 
    0x0F : Read Data
    0x10 : Fast Read
    0x11 : Release Powerdown / ID
    0x12 : Manufacturer / Device ID
    0x13 : JEDEC ID
    0x14 : Read Unique ID
    0x15 : Read SFDP Register
    0x16 : Erase Security Registers
    0x17 : Program Security Registers
    0x18 : Read Security Regisers
    0x19 : Enable Reset
    0x1A : Reset
    0x1B : Fast Read Dual Output
    0x1C : Fast Read Dual I/O
    0x1D : Manufacturer / Device ID by Dual I/O
    0x1E : Quad Page Program
    0x1F : Fast Read Quad Output
    0x20 : Fast Read Quad I/O
    0x21 : Set Burst with Wrap
    0x22 : Manufacturer / Device ID by Quad I/O
    0x23 : Toggle the test led on the board
    0x24 : Fill buffer
    0x25 : FPGA Reset

    0x26 : Change  Video Format to ADV7181D
    0x27 : Read ADV7181D Register File
    0x28 : Read ADV7181D Individual Register
    0x29 : Write ADV7181D Individual Register
*/
/*
    Video Format Codes for ADV7181D
    * the codes are the same as the real values used by ADV7181D for each video format
    0x00 : SVGA 800x600 @ 56
    0x01 : SVGA 800x600 @ 60
    0x02 : SVGA 800x600 @ 72
    0x03 : SVGA 800x600 @ 75
    0x04 : SVGA 800x600 @ 85
    0x08 : VGA 640x480 @ 60
    0x09 : VGA 640x480 @ 72
    0x0A : VGA 640x480 @ 75
    0x0B : VGA 640x480 @ 85
    0x0C : XGA 1024x768 @ 60
    0x0D : XGA 1024x768 @ 70 

*/
namespace ADV7181D_Configuration_App
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;
        public Form1()
        {
            InitializeComponent();
        }

        private void changeVideoFormat_btn_Click(object sender, EventArgs e)
        {
            if(_serialPort != null && _serialPort.IsOpen == true)
            {
                byte com_buf = 0x26;
                byte video_format_buf = new byte();
                byte[] send_buf = new byte[2];

                switch (selectVideoFormat_comboBox.Text)
                {
                    case "SVGA 600x800 @ 56":
                        video_format_buf = 0x00;
                        break;
                    case "SVGA 600x800 @ 60":
                        video_format_buf = 0x01;
                        break;
                    case "SVGA 600x800 @ 72":
                        video_format_buf = 0x02;
                        break;
                    case "SVGA 600x800 @ 75":
                        video_format_buf = 0x03;
                        break;
                    case "SVGA 600x800 @ 85":
                        video_format_buf = 0x04;
                        break;
                    case "VGA 640x480 @ 60":
                        video_format_buf = 0x08;
                        break;
                    case "VGA 640x480 @ 72":
                        video_format_buf = 0x09;
                        break;
                    case "VGA 640x480 @ 75":
                        video_format_buf = 0x0A;
                        break;
                    case "VGA 640x480 @ 85":
                        video_format_buf = 0x0B;
                        break;
                    case "XGA 1024x768 @ 60":
                        video_format_buf = 0x0C;
                        break;
                    case "XGA 1024x768 @ 70":
                        video_format_buf = 0x0D;
                        break;
                }
                send_buf[0] = com_buf;
                send_buf[1] = video_format_buf;
                _serialPort.Write(send_buf, 0, 2);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ///////// Quit Button ///////////////////////////////
        private void quit_btn_Click(object sender, EventArgs e)
        {
            if(_serialPort != null && _serialPort.IsOpen == true)
                _serialPort.Close();
            Application.Exit();
        }
        ///////// Open the Serial Port //////////////////////
        private void openSerialPort_btn_Click(object sender, EventArgs e)
        {
            //open and configure serial port
            _serialPort = new SerialPort();
            _serialPort.PortName = serialPort_txtBox.Text;
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.XOnXOff;
            _serialPort.WriteBufferSize = 4096;
            try
            {
                _serialPort.Open();
            }
            catch (IOException ev)
            {
                MessageBox.Show(_serialPort.PortName, "Cannot open Serial Port:", MessageBoxButtons.OK);
            }
        }
        ///////// Close the Serial Port ////////////////////////
        private void closeSerialPort_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true)
                _serialPort.Close();
        }

        private void toggleTestLed_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true)
            {
                byte[] com_buf = { 0x23 };
                _serialPort.Write(com_buf, 0, 1);
            }
        }

        private void readRegisterFile_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true) {
                byte[] send_buf = new byte[1];
                send_buf[0] = 0x27;
                _serialPort.Write(send_buf, 0, 1);

                byte[] recv_buf = new byte[253];
                _serialPort.Read(recv_buf, 0, 253);
                //Thread.Sleep(500);
                readRegisterFile_txtBox.Text = "";
                for (int i = 0; i < 253; i++)
                {
                    readRegisterFile_txtBox.AppendText(" " + i.ToString() + ":" + recv_buf[i].ToString());
                }
            }
        }

        private void readRegister_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void readRegister_btn_Click(object sender, EventArgs e)
        {
            if(_serialPort != null && _serialPort.IsOpen == true)
            {
                byte com_buf = 0x28;
                byte register_address = new byte();
                switch (readRegister_comboBox.Text)
                {
                    case "0x00":
                        register_address = 0x00;
                        break;
                    case "0x01":
                        register_address = 0x01;
                        break;
                    case "0x02":
                        register_address = 0x02;
                        break;
                    case "0x03":
                        register_address = 0x03;
                        break;
                    case "0x04":
                        register_address = 0x04;
                        break;
                    case "0x05":
                        register_address = 0x05;
                        break;
                    case "0x06":
                        register_address = 0x06;
                        break;
                    case "0x07":
                        register_address = 0x07;
                        break;
                    case "0x08":
                        register_address = 0x08;
                        break;
                    case "0x09":
                        register_address = 0x09;
                        break;
                    case "0x0A":
                        register_address = 0x0A;
                        break;
                    case "0x0B":
                        register_address = 0x0B;
                        break;
                    case "0x0C":
                        register_address = 0x0C;
                        break;
                    case "0x0D":
                        register_address = 0x0D;
                        break;
                    case "0x0E":
                        register_address = 0x0E;
                        break;
                    case "0x0F":
                        register_address = 0x0F;
                        break;
                    case "0x10":
                        register_address = 0x10;
                        break;
                    case "0x11":
                        register_address = 0x11;
                        break;
                    case "0x12":
                        register_address = 0x12;
                        break;
                    case "0x13":
                        register_address = 0x13;
                        break;
                    case "0x14":
                        register_address = 0x14;
                        break;
                    case "0x15":
                        register_address = 0x15;
                        break;
                    case "0x16":
                        register_address = 0x16;
                        break;
                    case "0x17":
                        register_address = 0x17;
                        break;
                    case "0x18":
                        register_address = 0x18;
                        break;
                    case "0x19":
                        register_address = 0x19;
                        break;
                    case "0x1A":
                        register_address = 0x1A;
                        break;
                    case "0x1B":
                        register_address = 0x1B;
                        break;
                    case "0x1C":
                        register_address = 0x1C;
                        break;
                    case "0x1D":
                        register_address = 0x1D;
                        break;
                    case "0x1E":
                        register_address = 0x1E;
                        break;
                    case "0x1F":
                        register_address = 0x1F;
                        break;
                    case "0x20":
                        register_address = 0x20;
                        break;
                    case "0x21":
                        register_address = 0x21;
                        break;
                    case "0x22":
                        register_address = 0x22;
                        break;
                    case "0x23":
                        register_address = 0x23;
                        break;
                    case "0x24":
                        register_address = 0x24;
                        break;
                    case "0x25":
                        register_address = 0x25;
                        break;
                    case "0x26":
                        register_address = 0x26;
                        break;
                    case "0x27":
                        register_address = 0x27;
                        break;
                    case "0x28":
                        register_address = 0x28;
                        break;
                    case "0x29":
                        register_address = 0x29;
                        break;
                    case "0x2A":
                        register_address = 0x2A;
                        break;
                    case "0x2B":
                        register_address = 0x2B;
                        break;
                    case "0x2C":
                        register_address = 0x2C;
                        break;
                    case "0x2D":
                        register_address = 0x2D;
                        break;
                    case "0x2E":
                        register_address = 0x2E;
                        break;
                    case "0x2F":
                        register_address = 0x2F;
                        break;
                    case "0x30":
                        register_address = 0x30;
                        break;
                    case "0x31":
                        register_address = 0x31;
                        break;
                    case "0x32":
                        register_address = 0x32;
                        break;
                    case "0x33":
                        register_address = 0x33;
                        break;
                    case "0x34":
                        register_address = 0x34;
                        break;
                    case "0x35":
                        register_address = 0x35;
                        break;
                    case "0x36":
                        register_address = 0x36;
                        break;
                    case "0x37":
                        register_address = 0x37;
                        break;
                    case "0x38":
                        register_address = 0x38;
                        break;
                    case "0x39":
                        register_address = 0x39;
                        break;
                    case "0x3A":
                        register_address = 0x3A;
                        break;
                    case "0x3B":
                        register_address = 0x3B;
                        break;
                    case "0x3C":
                        register_address = 0x3C;
                        break;
                    case "0x3D":
                        register_address = 0x3D;
                        break;
                    case "0x3E":
                        register_address = 0x3E;
                        break;
                    case "0x3F":
                        register_address = 0x3F;
                        break;
                    case "0x40":
                        register_address = 0x40;
                        break;
                    case "0x41":
                        register_address = 0x41;
                        break;
                    case "0x42":
                        register_address = 0x42;
                        break;
                    case "0x43":
                        register_address = 0x43;
                        break;
                    case "0x44":
                        register_address = 0x44;
                        break;
                    case "0x45":
                        register_address = 0x45;
                        break;
                    case "0x46":
                        register_address = 0x46;
                        break;
                    case "0x47":
                        register_address = 0x47;
                        break;
                    case "0x48":
                        register_address = 0x48;
                        break;
                    case "0x49":
                        register_address = 0x49;
                        break;
                    case "0x4A":
                        register_address = 0x4A;
                        break;
                    case "0x4B":
                        register_address = 0x4B;
                        break;
                    case "0x4C":
                        register_address = 0x4C;
                        break;
                    case "0x4D":
                        register_address = 0x4D;
                        break;
                    case "0x4E":
                        register_address = 0x4E;
                        break;
                    case "0x4F":
                        register_address = 0x4F;
                        break;
                    case "0x50":
                        register_address = 0x50;
                        break;
                    case "0x51":
                        register_address = 0x51;
                        break;
                    case "0x52":
                        register_address = 0x52;
                        break;
                    case "0x53":
                        register_address = 0x53;
                        break;
                    case "0x54":
                        register_address = 0x54;
                        break;
                    case "0x55":
                        register_address = 0x55;
                        break;
                    case "0x56":
                        register_address = 0x56;
                        break;
                    case "0x57":
                        register_address = 0x57;
                        break;
                    case "0x58":
                        register_address = 0x58;
                        break;
                    case "0x59":
                        register_address = 0x59;
                        break;
                    case "0x5A":
                        register_address = 0x5A;
                        break;
                    case "0x5B":
                        register_address = 0x5B;
                        break;
                    case "0x5C":
                        register_address = 0x5C;
                        break;
                    case "0x5D":
                        register_address = 0x5D;
                        break;
                    case "0x5E":
                        register_address = 0x5E;
                        break;
                    case "0x5F":
                        register_address = 0x5F;
                        break;
                    case "0x60":
                        register_address = 0x60;
                        break;
                    case "0x61":
                        register_address = 0x61;
                        break;
                    case "0x62":
                        register_address = 0x62;
                        break;
                    case "0x63":
                        register_address = 0x63;
                        break;
                    case "0x64":
                        register_address = 0x64;
                        break;
                    case "0x65":
                        register_address = 0x65;
                        break;
                    case "0x66":
                        register_address = 0x66;
                        break;
                    case "0x67":
                        register_address = 0x67;
                        break;
                    case "0x68":
                        register_address = 0x68;
                        break;
                    case "0x69":
                        register_address = 0x69;
                        break;
                    case "0x6A":
                        register_address = 0x6A;
                        break;
                    case "0x6B":
                        register_address = 0x6B;
                        break;
                    case "0x6C":
                        register_address = 0x6C;
                        break;
                    case "0x6D":
                        register_address = 0x6D;
                        break;
                    case "0x6E":
                        register_address = 0x6E;
                        break;
                    case "0x6F":
                        register_address = 0x6F;
                        break;
                    case "0x70":
                        register_address = 0x70;
                        break;
                    case "0x71":
                        register_address = 0x71;
                        break;
                    case "0x72":
                        register_address = 0x72;
                        break;
                    case "0x73":
                        register_address = 0x73;
                        break;
                    case "0x74":
                        register_address = 0x74;
                        break;
                    case "0x75":
                        register_address = 0x75;
                        break;
                    case "0x76":
                        register_address = 0x76;
                        break;
                    case "0x77":
                        register_address = 0x77;
                        break;
                    case "0x78":
                        register_address = 0x78;
                        break;
                    case "0x79":
                        register_address = 0x79;
                        break;
                    case "0x7A":
                        register_address = 0x7A;
                        break;
                    case "0x7B":
                        register_address = 0x7B;
                        break;
                    case "0x7C":
                        register_address = 0x7C;
                        break;
                    case "0x7D":
                        register_address = 0x7D;
                        break;
                    case "0x7E":
                        register_address = 0x7E;
                        break;
                    case "0x7F":
                        register_address = 0x7F;
                        break;
                    case "0x80":
                        register_address = 0x80;
                        break;
                    case "0x81":
                        register_address = 0x81;
                        break;
                    case "0x82":
                        register_address = 0x82;
                        break;
                    case "0x83":
                        register_address = 0x83;
                        break;
                    case "0x84":
                        register_address = 0x84;
                        break;
                    case "0x85":
                        register_address = 0x85;
                        break;
                    case "0x86":
                        register_address = 0x86;
                        break;
                    case "0x87":
                        register_address = 0x87;
                        break;
                    case "0x88":
                        register_address = 0x88;
                        break;
                    case "0x89":
                        register_address = 0x89;
                        break;
                    case "0x8A":
                        register_address = 0x8A;
                        break;
                    case "0x8B":
                        register_address = 0x8B;
                        break;
                    case "0x8C":
                        register_address = 0x8C;
                        break;
                    case "0x8D":
                        register_address = 0x8D;
                        break;
                    case "0x8E":
                        register_address = 0x8E;
                        break;
                    case "0x8F":
                        register_address = 0x8F;
                        break;
                    case "0x90":
                        register_address = 0x90;
                        break;
                    case "0x91":
                        register_address = 0x91;
                        break;
                    case "0x92":
                        register_address = 0x92;
                        break;
                    case "0x93":
                        register_address = 0x93;
                        break;
                    case "0x94":
                        register_address = 0x94;
                        break;
                    case "0x95":
                        register_address = 0x95;
                        break;
                    case "0x96":
                        register_address = 0x96;
                        break;
                    case "0x97":
                        register_address = 0x97;
                        break;
                    case "0x98":
                        register_address = 0x98;
                        break;
                    case "0x99":
                        register_address = 0x99;
                        break;
                    case "0x9A":
                        register_address = 0x9A;
                        break;
                    case "0x9B":
                        register_address = 0x9B;
                        break;
                    case "0x9C":
                        register_address = 0x9C;
                        break;
                    case "0x9D":
                        register_address = 0x9D;
                        break;
                    case "0x9E":
                        register_address = 0x9E;
                        break;
                    case "0x9F":
                        register_address = 0x9F;
                        break;
                    case "0xA0":
                        register_address = 0xA0;
                        break;
                    case "0xA1":
                        register_address = 0xA1;
                        break;
                    case "0xA2":
                        register_address = 0xA2;
                        break;
                    case "0xA3":
                        register_address = 0xA3;
                        break;
                    case "0xA4":
                        register_address = 0xA4;
                        break;
                    case "0xA5":
                        register_address = 0xA5;
                        break;
                    case "0xA6":
                        register_address = 0xA6;
                        break;
                    case "0xA7":
                        register_address = 0xA7;
                        break;
                    case "0xA8":
                        register_address = 0xA8;
                        break;
                    case "0xA9":
                        register_address = 0xA9;
                        break;
                    case "0xAA":
                        register_address = 0xAA;
                        break;
                    case "0xAB":
                        register_address = 0xAB;
                        break;
                    case "0xAC":
                        register_address = 0xAC;
                        break;
                    case "0xAD":
                        register_address = 0xAD;
                        break;
                    case "0xAE":
                        register_address = 0xAE;
                        break;
                    case "0xAF":
                        register_address = 0xAF;
                        break;
                    case "0xB0":
                        register_address = 0xB0;
                        break;
                    case "0xB1":
                        register_address = 0xB1;
                        break;
                    case "0xB2":
                        register_address = 0xB2;
                        break;
                    case "0xB3":
                        register_address = 0xB3;
                        break;
                    case "0xB4":
                        register_address = 0xB4;
                        break;
                    case "0xB5":
                        register_address = 0xB5;
                        break;
                    case "0xB6":
                        register_address = 0xB6;
                        break;
                    case "0xB7":
                        register_address = 0xB7;
                        break;
                    case "0xB8":
                        register_address = 0xB8;
                        break;
                    case "0xB9":
                        register_address = 0xB9;
                        break;
                    case "0xBA":
                        register_address = 0xBA;
                        break;
                    case "0xBB":
                        register_address = 0xBB;
                        break;
                    case "0xBC":
                        register_address = 0xBC;
                        break;
                    case "0xBD":
                        register_address = 0xBD;
                        break;
                    case "0xBE":
                        register_address = 0xBE;
                        break;
                    case "0xBF":
                        register_address = 0xBF;
                        break;
                    case "0xC0":
                        register_address = 0xC0;
                        break;
                    case "0xC1":
                        register_address = 0xC1;
                        break;
                    case "0xC2":
                        register_address = 0xC2;
                        break;
                    case "0xC3":
                        register_address = 0xC3;
                        break;
                    case "0xC4":
                        register_address = 0xC4;
                        break;
                    case "0xC5":
                        register_address = 0xC5;
                        break;
                    case "0xC6":
                        register_address = 0xC6;
                        break;
                    case "0xC7":
                        register_address = 0xC7;
                        break;
                    case "0xC8":
                        register_address = 0xC8;
                        break;
                    case "0xC9":
                        register_address = 0xC9;
                        break;
                    case "0xCA":
                        register_address = 0xCA;
                        break;
                    case "0xCB":
                        register_address = 0xCB;
                        break;
                    case "0xCC":
                        register_address = 0xCC;
                        break;
                    case "0xCD":
                        register_address = 0xCD;
                        break;
                    case "0xCE":
                        register_address = 0xCE;
                        break;
                    case "0xCF":
                        register_address = 0xCF;
                        break;
                    case "0xD0":
                        register_address = 0xD0;
                        break;
                    case "0xD1":
                        register_address = 0xD1;
                        break;
                    case "0xD2":
                        register_address = 0xD2;
                        break;
                    case "0xD3":
                        register_address = 0xD3;
                        break;
                    case "0xD4":
                        register_address = 0xD4;
                        break;
                    case "0xD5":
                        register_address = 0xD5;
                        break;
                    case "0xD6":
                        register_address = 0xD6;
                        break;
                    case "0xD7":
                        register_address = 0xD7;
                        break;
                    case "0xD8":
                        register_address = 0xD8;
                        break;
                    case "0xD9":
                        register_address = 0xD9;
                        break;
                    case "0xDA":
                        register_address = 0xDA;
                        break;
                    case "0xDB":
                        register_address = 0xDB;
                        break;
                    case "0xDC":
                        register_address = 0xDC;
                        break;
                    case "0xDD":
                        register_address = 0xDD;
                        break;
                    case "0xDE":
                        register_address = 0xDE;
                        break;
                    case "0xDF":
                        register_address = 0xDF;
                        break;
                    case "0xE0":
                        register_address = 0xE0;
                        break;
                    case "0xE1":
                        register_address = 0xE1;
                        break;
                    case "0xE2":
                        register_address = 0xE2;
                        break;
                    case "0xE3":
                        register_address = 0xE3;
                        break;
                    case "0xE4":
                        register_address = 0xE4;
                        break;
                    case "0xE5":
                        register_address = 0xE5;
                        break;
                    case "0xE6":
                        register_address = 0xE6;
                        break;
                    case "0xE7":
                        register_address = 0xE7;
                        break;
                    case "0xE8":
                        register_address = 0xE8;
                        break;
                    case "0xE9":
                        register_address = 0xE9;
                        break;
                    case "0xEA":
                        register_address = 0xEA;
                        break;
                    case "0xEB":
                        register_address = 0xEB;
                        break;
                    case "0xEC":
                        register_address = 0xEC;
                        break;
                    case "0xED":
                        register_address = 0xED;
                        break;
                    case "0xEE":
                        register_address = 0xEE;
                        break;
                    case "0xEF":
                        register_address = 0xEF;
                        break;
                    case "0xF0":
                        register_address = 0xF0;
                        break;
                    case "0xF1":
                        register_address = 0xF1;
                        break;
                    case "0xF2":
                        register_address = 0xF2;
                        break;
                    case "0xF3":
                        register_address = 0xF3;
                        break;
                    case "0xF4":
                        register_address = 0xF4;
                        break;
                    case "0xF5":
                        register_address = 0xF5;
                        break;
                    case "0xF6":
                        register_address = 0xF6;
                        break;
                    case "0xF7":
                        register_address = 0xF7;
                        break;
                    case "0xF8":
                        register_address = 0xF8;
                        break;
                    case "0xF9":
                        register_address = 0xF9;
                        break;
                    case "0xFA":
                        register_address = 0xFA;
                        break;
                    case "0xFB":
                        register_address = 0xFB;
                        break;
                    case "0xFC":
                        register_address = 0xFC;
                        break;
                    case "0xFD":
                        register_address = 0xFD;
                        break;
                    case "0xFE":
                        register_address = 0xFE;
                        break;
                    case "0xFF":
                        register_address = 0xFF;
                        break;
                }

                // Send the command and the register address to the microcontroller
                byte[] send_buf = new byte[2];
                send_buf[0] = com_buf;
                send_buf[1] = register_address;
                _serialPort.Write(send_buf, 0, 2);
                //receive the register value
                Thread.Sleep(10);
                int recv_val = _serialPort.ReadByte();
                registerValue_txtBox.Text = string.Format("0x{0:X} \n", recv_val);
            }
        }
    }
}
