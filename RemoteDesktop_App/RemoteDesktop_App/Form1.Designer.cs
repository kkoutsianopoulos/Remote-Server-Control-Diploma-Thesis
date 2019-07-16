namespace RemoteDesktop_App
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
            this.quit_btn = new System.Windows.Forms.Button();
            this.start_stream_button = new System.Windows.Forms.Button();
            this.stropStream_btn = new System.Windows.Forms.Button();
            this.deviceName_textBox = new System.Windows.Forms.TextBox();
            this.deviceName_lbl = new System.Windows.Forms.Label();
            this.IP_textBox = new System.Windows.Forms.TextBox();
            this.IP_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.TCPConnect_btn = new System.Windows.Forms.Button();
            this.mouseConnectIP_textBox = new System.Windows.Forms.TextBox();
            this.TCPShutdown_btn = new System.Windows.Forms.Button();
            this.checkConnection_btn = new System.Windows.Forms.Button();
            this.keyboard_textBox = new System.Windows.Forms.TextBox();
            this.selectDevice_comboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // quit_btn
            // 
            this.quit_btn.Location = new System.Drawing.Point(670, 526);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(102, 23);
            this.quit_btn.TabIndex = 0;
            this.quit_btn.Text = "Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // start_stream_button
            // 
            this.start_stream_button.Location = new System.Drawing.Point(670, 12);
            this.start_stream_button.Name = "start_stream_button";
            this.start_stream_button.Size = new System.Drawing.Size(102, 25);
            this.start_stream_button.TabIndex = 2;
            this.start_stream_button.Text = "Start Stream";
            this.start_stream_button.UseVisualStyleBackColor = true;
            this.start_stream_button.Click += new System.EventHandler(this.start_stream_button_Click);
            // 
            // stropStream_btn
            // 
            this.stropStream_btn.Location = new System.Drawing.Point(670, 44);
            this.stropStream_btn.Name = "stropStream_btn";
            this.stropStream_btn.Size = new System.Drawing.Size(102, 23);
            this.stropStream_btn.TabIndex = 3;
            this.stropStream_btn.Text = "Stop Stream";
            this.stropStream_btn.UseVisualStyleBackColor = true;
            this.stropStream_btn.Click += new System.EventHandler(this.stropStream_btn_Click);
            // 
            // deviceName_textBox
            // 
            this.deviceName_textBox.BackColor = System.Drawing.SystemColors.Menu;
            this.deviceName_textBox.Location = new System.Drawing.Point(672, 86);
            this.deviceName_textBox.Name = "deviceName_textBox";
            this.deviceName_textBox.Size = new System.Drawing.Size(100, 20);
            this.deviceName_textBox.TabIndex = 4;
            this.deviceName_textBox.Text = "BisonCam, NB Pro";
            // 
            // deviceName_lbl
            // 
            this.deviceName_lbl.AutoSize = true;
            this.deviceName_lbl.Location = new System.Drawing.Point(669, 70);
            this.deviceName_lbl.Name = "deviceName_lbl";
            this.deviceName_lbl.Size = new System.Drawing.Size(103, 13);
            this.deviceName_lbl.TabIndex = 5;
            this.deviceName_lbl.Text = "Enter Device Name:";
            // 
            // IP_textBox
            // 
            this.IP_textBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.IP_textBox.Location = new System.Drawing.Point(672, 125);
            this.IP_textBox.Name = "IP_textBox";
            this.IP_textBox.Size = new System.Drawing.Size(100, 20);
            this.IP_textBox.TabIndex = 6;
            this.IP_textBox.Text = "147.102.14.117:1234";
            // 
            // IP_label
            // 
            this.IP_label.AutoSize = true;
            this.IP_label.Location = new System.Drawing.Point(669, 109);
            this.IP_label.Name = "IP_label";
            this.IP_label.Size = new System.Drawing.Size(84, 13);
            this.IP_label.TabIndex = 7;
            this.IP_label.Text = "Enter Stream IP:";
            this.IP_label.Click += new System.EventHandler(this.IP_label_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cursor Position:";
            // 
            // videoPanel
            // 
            this.videoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videoPanel.Location = new System.Drawing.Point(12, 12);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(640, 480);
            this.videoPanel.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(672, 188);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(102, 20);
            this.textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(672, 215);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(102, 20);
            this.textBox3.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(672, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(102, 20);
            this.textBox1.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(672, 266);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(102, 20);
            this.textBox4.TabIndex = 15;
            // 
            // TCPConnect_btn
            // 
            this.TCPConnect_btn.Location = new System.Drawing.Point(672, 319);
            this.TCPConnect_btn.Name = "TCPConnect_btn";
            this.TCPConnect_btn.Size = new System.Drawing.Size(102, 32);
            this.TCPConnect_btn.TabIndex = 16;
            this.TCPConnect_btn.Text = "TCP Connect";
            this.TCPConnect_btn.UseVisualStyleBackColor = true;
            this.TCPConnect_btn.Click += new System.EventHandler(this.TCPConnect_btn_Click);
            // 
            // mouseConnectIP_textBox
            // 
            this.mouseConnectIP_textBox.Location = new System.Drawing.Point(672, 357);
            this.mouseConnectIP_textBox.Name = "mouseConnectIP_textBox";
            this.mouseConnectIP_textBox.Size = new System.Drawing.Size(100, 20);
            this.mouseConnectIP_textBox.TabIndex = 17;
            this.mouseConnectIP_textBox.Text = "147.102.14.117";
            // 
            // TCPShutdown_btn
            // 
            this.TCPShutdown_btn.Location = new System.Drawing.Point(672, 383);
            this.TCPShutdown_btn.Name = "TCPShutdown_btn";
            this.TCPShutdown_btn.Size = new System.Drawing.Size(100, 53);
            this.TCPShutdown_btn.TabIndex = 18;
            this.TCPShutdown_btn.Text = "TCP Disconnect/Shutdown ";
            this.TCPShutdown_btn.UseVisualStyleBackColor = true;
            this.TCPShutdown_btn.Click += new System.EventHandler(this.TCPShutdown_btn_Click);
            // 
            // checkConnection_btn
            // 
            this.checkConnection_btn.Location = new System.Drawing.Point(672, 443);
            this.checkConnection_btn.Name = "checkConnection_btn";
            this.checkConnection_btn.Size = new System.Drawing.Size(100, 49);
            this.checkConnection_btn.TabIndex = 19;
            this.checkConnection_btn.Text = "Check Connection";
            this.checkConnection_btn.UseVisualStyleBackColor = true;
            this.checkConnection_btn.Click += new System.EventHandler(this.checkConnection_btn_Click);
            // 
            // keyboard_textBox
            // 
            this.keyboard_textBox.Location = new System.Drawing.Point(12, 499);
            this.keyboard_textBox.Name = "keyboard_textBox";
            this.keyboard_textBox.Size = new System.Drawing.Size(221, 20);
            this.keyboard_textBox.TabIndex = 20;
            this.keyboard_textBox.TextChanged += new System.EventHandler(this.keyboard_textBox_TextChanged);
            this.keyboard_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyboard_textBox_KeyPress);
            // 
            // selectDevice_comboBox
            // 
            this.selectDevice_comboBox.FormattingEnabled = true;
            this.selectDevice_comboBox.Items.AddRange(new object[] {
            "Keyboard",
            "Mouse"});
            this.selectDevice_comboBox.Location = new System.Drawing.Point(672, 292);
            this.selectDevice_comboBox.Name = "selectDevice_comboBox";
            this.selectDevice_comboBox.Size = new System.Drawing.Size(102, 21);
            this.selectDevice_comboBox.TabIndex = 21;
            this.selectDevice_comboBox.Text = "Select HID Dev";
            this.selectDevice_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(672, 151);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Use Local Device";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.selectDevice_comboBox);
            this.Controls.Add(this.keyboard_textBox);
            this.Controls.Add(this.checkConnection_btn);
            this.Controls.Add(this.TCPShutdown_btn);
            this.Controls.Add(this.mouseConnectIP_textBox);
            this.Controls.Add(this.TCPConnect_btn);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP_label);
            this.Controls.Add(this.IP_textBox);
            this.Controls.Add(this.deviceName_lbl);
            this.Controls.Add(this.deviceName_textBox);
            this.Controls.Add(this.stropStream_btn);
            this.Controls.Add(this.start_stream_button);
            this.Controls.Add(this.quit_btn);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.Button start_stream_button;
        private System.Windows.Forms.Button stropStream_btn;
        private System.Windows.Forms.TextBox deviceName_textBox;
        private System.Windows.Forms.Label deviceName_lbl;
        private System.Windows.Forms.TextBox IP_textBox;
        private System.Windows.Forms.Label IP_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button TCPConnect_btn;
        private System.Windows.Forms.TextBox mouseConnectIP_textBox;
        private System.Windows.Forms.Button TCPShutdown_btn;
        private System.Windows.Forms.Button checkConnection_btn;
        private System.Windows.Forms.TextBox keyboard_textBox;
        private System.Windows.Forms.ComboBox selectDevice_comboBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

