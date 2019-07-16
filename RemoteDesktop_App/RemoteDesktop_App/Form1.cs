using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using gma.System.Windows;
using System.Net;
using System.Net.Sockets;

namespace RemoteDesktop_App
{
    public partial class Form1 : Form
    {
        
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        
        Process ffplay = new Process();
        private int cursorPosInFrameX;
        private int cursorPosInFrameY;
        private SynchronousSocketClient Client;
        private bool onFormFlag = false;

        public Form1()
        {        
            InitializeComponent();
            Application.EnableVisualStyles();
            this.DoubleBuffered = true;
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Process[] pname = Process.GetProcessesByName("ffplay");
            if (pname.Length == 0)
                MessageBox.Show("The is no Stream to stop");
            else {
                foreach (Process proc in pname)
                    proc.Kill();
            }

        }

        private void start_stream_button_Click(object sender, EventArgs e)
        {
            __ffplay();
        }
         
        
        // This method is responsible for running the ffplay program and capturing its output on the screen.
        private void __ffplay()
        {
            try{
                ffplay.StartInfo.FileName = "C:\\ffmpeg\\bin\\ffplay.exe";
                if(checkBox1.Checked == true)
                    ffplay.StartInfo.Arguments = /*" -f mpegts -noborder -i udp:/" + IP_textBox.Text;*/" -f dshow -noborder -i video=\""+ deviceName_textBox.Text +"\" ";
                else
                    ffplay.StartInfo.Arguments = " -f mpegts -noborder -i udp:/" + IP_textBox.Text;
                ffplay.StartInfo.CreateNoWindow = true;
                ffplay.StartInfo.RedirectStandardOutput = true;
                ffplay.StartInfo.UseShellExecute = false;

                ffplay.EnableRaisingEvents = true;
                ffplay.OutputDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffplay");
                ffplay.ErrorDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffplay");
                ffplay.Exited += (o, e) => Debug.WriteLine("Exited", "ffplay");

                ffplay.Start();
                Thread.Sleep(7000);
                // child, new parent
                // make 'this' the parent of ffmpeg (presuming you are in scope of a Form or Control)
                SetParent(ffplay.MainWindowHandle, videoPanel.Handle);
                // window, x, y, width, height, repaint
                // move the ffplayer window to the top-left corner and set the size to 320x280
                MoveWindow(ffplay.MainWindowHandle, 0, 0, 640, 480, true);
                                  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        
        private void stropStream_btn_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("ffplay");
            if (pname.Length == 0)
                MessageBox.Show("The is no Stream to stop");
            else {
                foreach (Process proc in pname)
                    proc.Kill();
            }
        }



        
        UserActivityHook actHook;
        private void Form1_Load(object sender , EventArgs e)
        {
            actHook = new UserActivityHook();
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
        }
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            textBox2.Text = Cursor.Position.X.ToString();
            textBox3.Text = Cursor.Position.Y.ToString();
            
            cursorPosInFrameX = (Cursor.Position.X - (this.Left + videoPanel.Left) - 9);
            cursorPosInFrameY = (Cursor.Position.Y - (this.Top + videoPanel.Top) - 31);
            textBox1.Text = cursorPosInFrameX.ToString();
            textBox4.Text = cursorPosInFrameY.ToString();

            if (selectDevice_comboBox.Text.Equals("Mouse")) {
                if ((Client != null) && (Client.getIsOpen() == true)) {
                    if ((Cursor.Position.X >= ((this.Left + videoPanel.Left) - 9)) && (Cursor.Position.X <= (this.Right - videoPanel.Right - 9))) ;
                    {
                        try {
                            string mousePosition = cursorPosInFrameX.ToString() + ":" + cursorPosInFrameY.ToString() + "\n";
                            Client.Send(mousePosition);
                        } catch (Exception ev)
                        {
                            Console.WriteLine(ev.ToString());
                        }

                    }
                }
            }
        }

        // Open a new socket and connect to the remote device server to send
        // the mouse coordinates.
        private void TCPConnect_btn_Click(object sender, EventArgs e)
        {
            Client = new SynchronousSocketClient(mouseConnectIP_textBox.Text, 8989);
            Client.StartClient();
        }
        
        private void TCPShutdown_btn_Click(object sender, EventArgs e)
        {
            if(Client != null)
                Client.Shutdown();
        }

        private void checkConnection_btn_Click(object sender, EventArgs e)
        {
            if(Client != null)
                Client.Send(mouseConnectIP_textBox.Text);
        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (selectDevice_comboBox.Text.Equals("Keyboard"))
            {
                if ((Client != null) && (Client.getIsOpen() == true))
                {
                    try
                    {
                        int keychar = e.KeyChar;
                        if (keychar >= 65 && keychar <= 90)
                            keychar += 32;                              
                        string keyboardMessage = (char)keychar + "\n";
                        Client.Send(keyboardMessage);                       
                    }
                    catch (Exception ev)
                    {
                        Console.WriteLine(ev.ToString());
                    }
                }
            }
            keyboard_textBox.Text += e.KeyChar.ToString();
            if (keyboard_textBox.Text.Length >= 10)
                keyboard_textBox.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void keyboard_textBox_TextChanged(object sender, EventArgs e)
        {/*
            if (selectDevice_comboBox.Text.Equals("Keyboard"))
            {
                if ((Client != null) && (Client.getIsOpen() == true))
                {
                        try
                        {
                            string keyboardMessage = keyboard_textBox.Text + "\n";
                        keyboard_textBox.Text = "";
                            Client.Send(keyboardMessage);
                        }
                        catch (Exception ev)
                        {
                            Console.WriteLine(ev.ToString());
                        }                 
                }
            }
            */
        }

        private void keyboard_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (selectDevice_comboBox.Text.Equals("Keyboard"))
            {
                if ((Client != null) && (Client.getIsOpen() == true))
                {
                    try
                    {
                        string keyboardMessage = "";
                        if (e.Control)
                        {
                            keyboardMessage = "ctrl\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.Alt)
                        {
                            keyboardMessage = "alt\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.Shift)
                        {
                            keyboardMessage = "shift\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if(e.KeyCode == Keys.Return)
                        {
                            keyboardMessage = "return\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if(e.KeyCode == Keys.Tab)
                        {
                            keyboardMessage = "tab\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Insert)
                        {
                            keyboardMessage = "insert\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Left)
                        {
                            keyboardMessage = "left\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Right)
                        {
                            keyboardMessage = "right\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Up)
                        {
                            keyboardMessage = "up\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Down)
                        {
                            keyboardMessage = "down\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Escape)
                        {
                            keyboardMessage = "escape\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.Delete)
                        {
                            keyboardMessage = "delete\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                        else if (e.KeyCode == Keys.CapsLock)
                        {
                            keyboardMessage = "capslock\n".ToString();
                            Client.Send(keyboardMessage);
                        }
                    }
                    catch (Exception ev)
                    {
                        Console.WriteLine(ev.ToString());
                    }
                }
            }
        }

        private void IP_label_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
