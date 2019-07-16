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

//defines

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
*/
namespace FPGA_DownloadCode_App
{
    public partial class Form1 : Form
    {
        private FileStream selectedFile;
        private SerialPort _serialPort;
        byte[] binaryFile = null;
        byte[] binaryMemoryContent = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile_btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            if(_serialPort != null && _serialPort.IsOpen == true)
            {
                _serialPort.Close();
            }
            Application.Exit();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            selectedFile_txtbox.Text = openFileDialog1.FileName;
            try {
                binaryFile = File.ReadAllBytes(openFileDialog1.FileName);
                fileSizeNumber_lbl.Text = binaryFile.GetLength(0).ToString() + " bytes";    
            }
            catch(IOException ev)
            {
                MessageBox.Show(ev.Message,"Cannot Open File", MessageBoxButtons.OK);
            }
        }

        private void serialPortName_lbl_Click(object sender, EventArgs e)
        {

        }

        private void openSerialPort_btn_Click(object sender, EventArgs e)
        {
            //open and configure serial port
            _serialPort = new SerialPort();
            _serialPort.PortName = serialPortName_txtbox.Text;
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
            catch(IOException ev)
            {
                MessageBox.Show(_serialPort.PortName, "Cannot open Serial Port:", MessageBoxButtons.OK);
            }
        }

        private void writeConfiguration_btn_Click(object sender, EventArgs e)
        {
            int progress = 0;
            int pageNumber = binaryFile.GetLength(0) / 256 + 1; //Configuration file length in number of pages
            byte[] pageBuffer = new byte[256]; //256 bytes page buffer
            byte[] pageAddress = new byte[4];
            byte[] com_buf = { 0x07 };
            byte[] byteNumber = new byte[2];
            byte[] full_buf = new byte[263];/// this buffer contains all the other buffer for smooth transmition

            writeConfiguration_lbl.Text = "Downloading configuration";
            //write configuration file in memory page to page
            for (int i = 0; i < pageNumber; i++)
            {
                //first erase 4KB sector if needed
                if( i % 16 == 0)
                {
                    byte[] sector_address = BitConverter.GetBytes(i * 256);
                    com_buf[0] = 0x08;
                    Array.Copy(com_buf, 0, full_buf, 0, 1);
                    full_buf[1] = sector_address[2];
                    full_buf[2] = sector_address[1];
                    full_buf[3] = sector_address[0];
                    if (_serialPort != null && _serialPort.IsOpen == true)
                    {
                        _serialPort.DiscardOutBuffer();
                        _serialPort.Write(full_buf, 0, 4);
                        while (_serialPort.ReadByte() != 0x01)
                            ;//just busy wait until microcontroller responds 
                    }
                }
                com_buf[0] = 0x07;
                if (i != pageNumber - 1)
                {
                    Array.Copy(binaryFile, i * 256, pageBuffer, 0, 256);
                    if (_serialPort != null && _serialPort.IsOpen == true)
                    {
                        _serialPort.DiscardOutBuffer();
                        //first write the command code before evey data
                        //then the current page address and then the usefull data                                                      
                        //send page to microntroller
                        pageAddress = BitConverter.GetBytes(i * 256);
                        byteNumber[0] = 0x01;
                        byteNumber[1] = 0x00;
                        //send page in 32 bytes transactions 
                        //and then send the page program command
                        com_buf[0] = 0x24;
                        for (int j = 0; j < 8; j++)
                        {
                            int buf_adr = j * 32;
                            byte[] buf_adr_bytes = new byte[4];
                            buf_adr_bytes = BitConverter.GetBytes(buf_adr);
                            full_buf[0] = com_buf[0];
                            full_buf[1] = buf_adr_bytes[0];
                            Array.Copy(pageBuffer, buf_adr, full_buf, 2, 32);
                            _serialPort.Write(full_buf, 0, 34);
                            while (_serialPort.ReadByte() != 0x01)
                                ;//just busy wait until microcontroller responds 
                        }
                        //now send the page program command with the page address and the
                        //number of bytes to be written in page
                        com_buf[0] = 0x07;
                        full_buf[0] = com_buf[0];
                        full_buf[1] = pageAddress[2];
                        full_buf[2] = pageAddress[1];
                        full_buf[3] = pageAddress[0];
                        full_buf[4] = byteNumber[0];
                        full_buf[5] = byteNumber[1];
                        _serialPort.Write(full_buf, 0, 6);
                    }
                }
                else
                {
                    int remaining_bytes = binaryFile.GetLength(0) - i * 256;
                    if (remaining_bytes < 0)
                        remaining_bytes = binaryFile.GetLength(0);
                    Array.Copy(binaryFile, i * 256, pageBuffer, 0, remaining_bytes);
                    if (_serialPort != null && _serialPort.IsOpen == true)
                    {
                        _serialPort.DiscardOutBuffer();
                        //first write the command code before evey data
                        //then the current page address and then the usefull data                      
                        //send page to microntroller
                        pageAddress = BitConverter.GetBytes(i * 256);
                        if (remaining_bytes != 256)
                        {
                            byteNumber[0] = 0x00;
                            byteNumber[1] = (byte)remaining_bytes;
                        }
                        else
                        {
                            byteNumber[0] = 0x01;
                            byteNumber[1] = 0x00;
                        }
                        //send page in 32 bytes transactions 
                        //and then send the page program command
                        com_buf[0] = 0x24;
                        for (int j = 0; j < 8; j++)
                        {
                            int buf_adr =  j * 32;
                            byte[] buf_adr_bytes = new byte[4];
                            buf_adr_bytes = BitConverter.GetBytes(buf_adr);
                            full_buf[0] = com_buf[0];
                            full_buf[1] = buf_adr_bytes[0];
                            Array.Copy(pageBuffer, buf_adr, full_buf, 2 , 32);
                            _serialPort.Write(full_buf, 0, 34);
                            while (_serialPort.ReadByte() != 0x01)
                                ;//just busy wait until microcontroller responds 
                        }
                        //now send the page program command with the page address and the
                        //number of bytes to be written in page
                        com_buf[0] = 0x07;
                        full_buf[0] = com_buf[0];
                        full_buf[1] = pageAddress[2];
                        full_buf[2] = pageAddress[1];
                        full_buf[3] = pageAddress[0];
                        full_buf[4] = byteNumber[0];
                        full_buf[5] = byteNumber[1];
                        _serialPort.Write(full_buf, 0, 6);
  
                    }
                }
                //microcontroller sends 0x01 every time the current page has been written
                while (_serialPort.ReadByte() != 0x01)
                    ;//just busy wait until microcontroller responds     
                progress = (i+1) * 100 / pageNumber;
                writeConfiguration_progbar.Value = progress;
            }
            MessageBox.Show("Memory Programmed!");
        }

        private void toggleTestLed_btn_Click(object sender, EventArgs e)
        {
            if(_serialPort != null && _serialPort.IsOpen == true)
            {
                byte[] com_buf = { 0x23 };
                _serialPort.Write(com_buf, 0, 1);
            }
        }

        private void closeSerialPort_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true)
                _serialPort.Close();
        }

        private void executeCommand_btn_Click(object sender, EventArgs e)
        {
            if(_serialPort != null && _serialPort.IsOpen == true)
            {
                byte[] com_buf = new byte[1];
                byte[] read_buffer;
                switch (executeCommand_box.Text)
                {
                    case "Write Enable":
                        //com_buf[0] = 0x01;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Volatile SR Write Enable":
                        //com_buf[0] = 0x02;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Write Disable":
                        //com_buf[0] = 0x03;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Read Status Register 1":
                        com_buf[0] = 0x04;
                        _serialPort.Write(com_buf, 0, 1);
                        Thread.Sleep(1);
                        read_buffer = new byte[1];
                        _serialPort.Read(read_buffer, 0, 1);
                        executeCommand_txtBox.Text = string.Format("Status Register 1: \n 0x{0:X}", read_buffer[0]);
                        break;
                    case "Read Status Register 2":
                        com_buf[0] = 0x05;
                        _serialPort.Write(com_buf, 0, 1);
                        Thread.Sleep(1);
                        read_buffer = new byte[1];
                        _serialPort.Read(read_buffer, 0, 1);
                        executeCommand_txtBox.Text = string.Format("Status Register 2: \n 0x{0:X}", read_buffer[0]);
                        break;
                    case "Write Status Register":
                        //com_buf[0] = 0x06;
                        //_serialPort.Write(com_buf, 0, 1);
                        break; 
                    case "Page Program":
                        //com_buf[0] = 0x07;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Sector Erase (4KB)":
                        //com_buf[0] = 0x08;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Block Erase (32KB)":
                        //com_buf[0] = 0x09;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Block Erase (64KB)":
                        //com_buf[0] = 0x0A;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Chip Erase":
                        //com_buf[0] = 0x0B;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Erase / Program Suspend":
                        //com_buf[0] = 0x0C;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Erase / Program Resume":
                        //com_buf[0] = 0x0D;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Power-down":
                        //com_buf[0] = 0x0E;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Read Data":
                        //read a page
                        byte[] send_buf = new byte[4];
                        byte[] page_address = BitConverter.GetBytes(256*int.Parse(executeCommandParameter_txtBox.Text));
                        com_buf[0] = 0x0F;
                        Array.Copy(com_buf, 0, send_buf, 0, 1);
                        send_buf[1] = page_address[2];
                        send_buf[2] = page_address[1];
                        send_buf[3] = page_address[0];
                        _serialPort.Write(send_buf, 0, 4);
                        Thread.Sleep(500);
                        read_buffer = new byte[256];
                        _serialPort.Read(read_buffer, 0, 256);
                        executeCommand_txtBox.Text = "";
                        for(int i=0; i<256; i++)
                        {
                            executeCommand_txtBox.AppendText(" "+i.ToString()+":" + read_buffer[i].ToString());
                        }
                        break;
                    case "Fast Read":
                        //com_buf[0] = 0x10;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Release Powerdown ID":
                        //com_buf[0] = 0x11;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Manufacturer / Device ID":
                        com_buf[0] = 0x12;
                        _serialPort.Write(com_buf, 0, 1);
                        Thread.Sleep(1);
                        read_buffer = new byte[2];
                        _serialPort.Read(read_buffer, 0, 2);
                        executeCommand_txtBox.Text = string.Format("Manufacturer ID: 0x{0:X} \n Device ID: 0x{1:X}",read_buffer.GetValue(0), read_buffer.GetValue(1));
                        break;
                    case "JEDEC ID":
                        com_buf[0] = 0x13;
                        _serialPort.Write(com_buf, 0, 1);
                        Thread.Sleep(1);
                        read_buffer = new byte[3];
                        _serialPort.Read(read_buffer, 0, 3);
                        executeCommand_txtBox.Text = string.Format("JEDEC ID\n Manufacturer ID: 0x{0:X}\n Memory type: 0x{1:X}\n Capacity: 0x{2:X}", read_buffer.GetValue(0), read_buffer.GetValue(1), read_buffer.GetValue(2));
                        break;
                    case "Read Unique ID":
                        com_buf[0] = 0x14;
                        _serialPort.Write(com_buf, 0, 1);
                        Thread.Sleep(1);
                        read_buffer = new byte[8];
                        _serialPort.Read(read_buffer, 0, 8);
                        executeCommand_txtBox.Text = string.Format("Unique 64bit ID:\n 0x{0:X}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}{7:X}", read_buffer.GetValue(0), read_buffer.GetValue(1), read_buffer.GetValue(2), read_buffer.GetValue(3), read_buffer.GetValue(4), read_buffer.GetValue(5), read_buffer.GetValue(6), read_buffer.GetValue(7));
                        break;
                    case "Read SFDP Register":
                        //com_buf[0] = 0x15;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Erase Security Registers":
                        //com_buf[0] = 0x16;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Program Security Registers":
                        //com_buf[0] = 0x17;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Read Security Registers":
                        //com_buf[0] = 0x18;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Enable Reset":
                        //com_buf[0] = 0x19;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Reset":
                        //com_buf[0] = 0x1A;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Fast Read Dual Output":
                        //com_buf[0] = 0x1B;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Fast Read Dual I/O":
                        //com_buf[0] = 0x1C;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Manufacturer / Device ID by Dual I/O":
                        //com_buf[0] = 0x1D;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Quad Page Program":
                        //com_buf[0] = 0x1E;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Fast Read Quad Output":
                        //com_buf[0] = 0x1F;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Fast Read Quad I/O":
                        //com_buf[0] = 0x20;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Set Burst with Wrap":
                        //com_buf[0] = 0x21;
                        //_serialPort.Write(com_buf, 0, 1);
                        break;
                    case "Manufacturer / Device ID by Quad I/O":
                        //com_buf[0] = 0x22;
                        //_serialPort.Write(com_buf, 0, 1);
                        
                        break;
                    default:
                        break;      
                }
            }
            else
            {
                executeCommand_txtBox.Text = "Serial Port not open! No command output.";
            }
        }

        private void executeCommandParameter_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void writeConfiguration_progbar_Click(object sender, EventArgs e)
        {

        }

        private void readConfiguration_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true)
            {
                //the size of the flash is 1MB
                binaryMemoryContent = new byte[1024 * 1024];
                int pageNumber = 4096;  //4096 pages of 256 bytes each
                byte[] read_buffer = new byte[256];
                byte[] com_buf = new byte[1];
                writeConfiguration_lbl.Text = "Reading Configuration";
                for (int i = 0; i < pageNumber; i++)
                {
                    byte[] send_buf = new byte[4];
                    byte[] page_address = BitConverter.GetBytes(256 * i);
                    com_buf[0] = 0x0F;
                    Array.Copy(com_buf, 0, send_buf, 0, 1);
                    send_buf[1] = page_address[2];
                    send_buf[2] = page_address[1];
                    send_buf[3] = page_address[0];
                    _serialPort.Write(send_buf, 0, 4);
                    Thread.Sleep(3);
                    _serialPort.Read(read_buffer, 0, 256);
                    Array.Copy(read_buffer, 0, binaryMemoryContent, i * 256, 256);
                    writeConfiguration_progbar.Value = (i + 1) * 100 / pageNumber;
                }
                MessageBox.Show("Configuration has been read succesfully!", "Read Configuration", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("You have to open the serial port first!!", "Read Configuration", MessageBoxButtons.OK);
            }
        }

        private void validateConfiguration_btn_Click(object sender, EventArgs e)
        {
            if (binaryFile == null)
                MessageBox.Show("You have to open a configuration file first!!", "Validate Configuration", MessageBoxButtons.OK);
            else
            {
                if (_serialPort != null && _serialPort.IsOpen == true)
                {
                    //read configuration
                    if (binaryMemoryContent == null)
                        binaryMemoryContent = new byte[1024 * 1024];
                    int pageNumber = 4096;  //4096 pages of 256 bytes each
                    byte[] read_buffer = new byte[256];
                    byte[] com_buf = new byte[1];
                    writeConfiguration_lbl.Text = "Reading Configuration";
                    for (int i = 0; i < pageNumber; i++)
                    {
                        byte[] send_buf = new byte[4];
                        byte[] page_address = BitConverter.GetBytes(256 * i);
                        com_buf[0] = 0x0F;
                        Array.Copy(com_buf, 0, send_buf, 0, 1);
                        send_buf[1] = page_address[2];
                        send_buf[2] = page_address[1];
                        send_buf[3] = page_address[0];
                        _serialPort.Write(send_buf, 0, 4);
                        Thread.Sleep(3);
                        _serialPort.Read(read_buffer, 0, 256);
                        Array.Copy(read_buffer, 0, binaryMemoryContent, i * 256, 256);
                        writeConfiguration_progbar.Value = (i + 1) * 100 / pageNumber;
                    }

                    writeConfiguration_lbl.Text = "Validating Configuration";
                    Boolean valid = true;
                    int configurationLength = binaryFile.GetLength(0);
                    for (int i = 0; i < configurationLength; i++)
                    {
                        if (binaryFile[i] != binaryMemoryContent[i])
                        {
                            valid = false;
                            break;
                        }
                        writeConfiguration_progbar.Value = (i + 1) * 100 / configurationLength;
                    }
                    if (valid == true)
                    {
                        MessageBox.Show("Configuration is valid!!", "Validate Configuration", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Configuration is invalid!!", "Validate Configuration", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("You have to open the serial port first!!", "Validate Configuration", MessageBoxButtons.OK);
                }
            }
        }

        private void resetFPGA_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true)
            {
                byte[] com_buf = new byte[1];
                com_buf[0] = 0x25;
                _serialPort.Write(com_buf, 0, 1);
                Thread.Sleep(1);
            }
            else
            {
                MessageBox.Show("You have to open the serial port first!!", "Validate Configuration", MessageBoxButtons.OK);
            }
        }

        private void eraseConfigurationMemory_btn_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen == true)
            {
                writeConfiguration_lbl.Text = "Erasing Configuration Memory";
                byte[] com_buf = new byte[1];
                byte[] full_buf = new byte[4];
                //erase 256 sectors of 4KB each(maybe imroved if we use block erase)
                for (int i=0; i<256; i++)
                { 
                    byte[] sector_address = BitConverter.GetBytes(i * 4096);
                    com_buf[0] = 0x08;
                    Array.Copy(com_buf, 0, full_buf, 0, 1);
                    full_buf[1] = sector_address[2];
                    full_buf[2] = sector_address[1];
                    full_buf[3] = sector_address[0];
                    if (_serialPort != null && _serialPort.IsOpen == true)
                    {
                        _serialPort.DiscardOutBuffer();
                        _serialPort.Write(full_buf, 0, 4);
                        while (_serialPort.ReadByte() != 0x01)
                            ;//just busy wait until microcontroller responds 
                    }
                    writeConfiguration_progbar.Value = (i + 1) * 100 / 256;
                }
                MessageBox.Show("Configuration Memory has been erased!", "Erase Configuration Memory", MessageBoxButtons.OK);
            }
        }
    }
}
