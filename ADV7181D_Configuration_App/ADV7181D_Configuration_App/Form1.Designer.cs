namespace ADV7181D_Configuration_App
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
            this.serialPort_txtBox = new System.Windows.Forms.TextBox();
            this.serialPort_lbl = new System.Windows.Forms.Label();
            this.openSerialPort_btn = new System.Windows.Forms.Button();
            this.closeSerialPort_btn = new System.Windows.Forms.Button();
            this.changeVideoFormat_btn = new System.Windows.Forms.Button();
            this.selectVideoFormat_comboBox = new System.Windows.Forms.ComboBox();
            this.selectVideoFormat_lbl = new System.Windows.Forms.Label();
            this.quit_btn = new System.Windows.Forms.Button();
            this.toggleTestLed_btn = new System.Windows.Forms.Button();
            this.readRegisterFile_btn = new System.Windows.Forms.Button();
            this.readRegisterFile_txtBox = new System.Windows.Forms.TextBox();
            this.readRegister_btn = new System.Windows.Forms.Button();
            this.readRegister_comboBox = new System.Windows.Forms.ComboBox();
            this.registerValue_txtBox = new System.Windows.Forms.TextBox();
            this.selectRegister_lbl = new System.Windows.Forms.Label();
            this.registerValue_lbl = new System.Windows.Forms.Label();
            this.writeRegister_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort_txtBox
            // 
            this.serialPort_txtBox.Location = new System.Drawing.Point(12, 48);
            this.serialPort_txtBox.Name = "serialPort_txtBox";
            this.serialPort_txtBox.Size = new System.Drawing.Size(100, 20);
            this.serialPort_txtBox.TabIndex = 0;
            this.serialPort_txtBox.Text = "COM10";
            // 
            // serialPort_lbl
            // 
            this.serialPort_lbl.AutoSize = true;
            this.serialPort_lbl.Location = new System.Drawing.Point(12, 32);
            this.serialPort_lbl.Name = "serialPort_lbl";
            this.serialPort_lbl.Size = new System.Drawing.Size(91, 13);
            this.serialPort_lbl.TabIndex = 1;
            this.serialPort_lbl.Text = "Select Serial Port:";
            // 
            // openSerialPort_btn
            // 
            this.openSerialPort_btn.Location = new System.Drawing.Point(118, 48);
            this.openSerialPort_btn.Name = "openSerialPort_btn";
            this.openSerialPort_btn.Size = new System.Drawing.Size(75, 40);
            this.openSerialPort_btn.TabIndex = 2;
            this.openSerialPort_btn.Text = "Open Serial Port";
            this.openSerialPort_btn.UseVisualStyleBackColor = true;
            this.openSerialPort_btn.Click += new System.EventHandler(this.openSerialPort_btn_Click);
            // 
            // closeSerialPort_btn
            // 
            this.closeSerialPort_btn.Location = new System.Drawing.Point(199, 48);
            this.closeSerialPort_btn.Name = "closeSerialPort_btn";
            this.closeSerialPort_btn.Size = new System.Drawing.Size(75, 40);
            this.closeSerialPort_btn.TabIndex = 3;
            this.closeSerialPort_btn.Text = "Close Serial Port";
            this.closeSerialPort_btn.UseVisualStyleBackColor = true;
            this.closeSerialPort_btn.Click += new System.EventHandler(this.closeSerialPort_btn_Click);
            // 
            // changeVideoFormat_btn
            // 
            this.changeVideoFormat_btn.Location = new System.Drawing.Point(139, 116);
            this.changeVideoFormat_btn.Name = "changeVideoFormat_btn";
            this.changeVideoFormat_btn.Size = new System.Drawing.Size(75, 48);
            this.changeVideoFormat_btn.TabIndex = 5;
            this.changeVideoFormat_btn.Text = "Change Video Format";
            this.changeVideoFormat_btn.UseVisualStyleBackColor = true;
            this.changeVideoFormat_btn.Click += new System.EventHandler(this.changeVideoFormat_btn_Click);
            // 
            // selectVideoFormat_comboBox
            // 
            this.selectVideoFormat_comboBox.FormattingEnabled = true;
            this.selectVideoFormat_comboBox.Items.AddRange(new object[] {
            "VGA 640x480 @ 60",
            "VGA 640x480 @ 72",
            "VGA 640x480 @ 75",
            "VGA 640x480 @ 85",
            "SVGA 800x600 @ 56",
            "SVGA 800x600 @ 60",
            "SVGA 800x600 @ 72",
            "SVGA 800x600 @ 75",
            "SVGA 800x600 @ 85",
            "XVGA 1024x768 @ 60",
            "XVGA 1024x768 @ 70",
            ""});
            this.selectVideoFormat_comboBox.Location = new System.Drawing.Point(12, 116);
            this.selectVideoFormat_comboBox.Name = "selectVideoFormat_comboBox";
            this.selectVideoFormat_comboBox.Size = new System.Drawing.Size(121, 21);
            this.selectVideoFormat_comboBox.TabIndex = 6;
            this.selectVideoFormat_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // selectVideoFormat_lbl
            // 
            this.selectVideoFormat_lbl.AutoSize = true;
            this.selectVideoFormat_lbl.Location = new System.Drawing.Point(12, 100);
            this.selectVideoFormat_lbl.Name = "selectVideoFormat_lbl";
            this.selectVideoFormat_lbl.Size = new System.Drawing.Size(105, 13);
            this.selectVideoFormat_lbl.TabIndex = 7;
            this.selectVideoFormat_lbl.Text = "Select Video Format:";
            // 
            // quit_btn
            // 
            this.quit_btn.Location = new System.Drawing.Point(464, 302);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 8;
            this.quit_btn.Text = "Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // toggleTestLed_btn
            // 
            this.toggleTestLed_btn.Location = new System.Drawing.Point(280, 48);
            this.toggleTestLed_btn.Name = "toggleTestLed_btn";
            this.toggleTestLed_btn.Size = new System.Drawing.Size(78, 40);
            this.toggleTestLed_btn.TabIndex = 9;
            this.toggleTestLed_btn.Text = "Toggle Test Led";
            this.toggleTestLed_btn.UseVisualStyleBackColor = true;
            this.toggleTestLed_btn.Click += new System.EventHandler(this.toggleTestLed_btn_Click);
            // 
            // readRegisterFile_btn
            // 
            this.readRegisterFile_btn.Location = new System.Drawing.Point(15, 175);
            this.readRegisterFile_btn.Name = "readRegisterFile_btn";
            this.readRegisterFile_btn.Size = new System.Drawing.Size(73, 48);
            this.readRegisterFile_btn.TabIndex = 10;
            this.readRegisterFile_btn.Text = "Read Register File";
            this.readRegisterFile_btn.UseVisualStyleBackColor = true;
            this.readRegisterFile_btn.Click += new System.EventHandler(this.readRegisterFile_btn_Click);
            // 
            // readRegisterFile_txtBox
            // 
            this.readRegisterFile_txtBox.Location = new System.Drawing.Point(94, 175);
            this.readRegisterFile_txtBox.Multiline = true;
            this.readRegisterFile_txtBox.Name = "readRegisterFile_txtBox";
            this.readRegisterFile_txtBox.Size = new System.Drawing.Size(145, 48);
            this.readRegisterFile_txtBox.TabIndex = 11;
            // 
            // readRegister_btn
            // 
            this.readRegister_btn.Location = new System.Drawing.Point(12, 240);
            this.readRegister_btn.Name = "readRegister_btn";
            this.readRegister_btn.Size = new System.Drawing.Size(73, 36);
            this.readRegister_btn.TabIndex = 12;
            this.readRegister_btn.Text = "Read Register";
            this.readRegister_btn.UseVisualStyleBackColor = true;
            this.readRegister_btn.Click += new System.EventHandler(this.readRegister_btn_Click);
            // 
            // readRegister_comboBox
            // 
            this.readRegister_comboBox.FormattingEnabled = true;
            this.readRegister_comboBox.Items.AddRange(new object[] {
            "0x00",
            "0x01",
            "0x02",
            "0x03",
            "0x04",
            "0x05",
            "0x06",
            "0x07",
            "0x08",
            "0x09",
            "0x0A",
            "0x0B",
            "0x0C",
            "0x0D",
            "0x0E",
            "0x0F",
            "0x10",
            "0x11",
            "0x12",
            "0x13",
            "0x14",
            "0x15",
            "0x16",
            "0x17",
            "0x18",
            "0x19",
            "0x1A",
            "0x1B",
            "0x1C",
            "0x1D",
            "0x1E",
            "0x1F",
            "0x20",
            "0x21",
            "0x22",
            "0x23",
            "0x24",
            "0x25",
            "0x26",
            "0x27",
            "0x28",
            "0x29",
            "0x2A",
            "0x2B",
            "0x2C",
            "0x2D",
            "0x2E",
            "0x2F",
            "0x30",
            "0x31",
            "0x32",
            "0x33",
            "0x34",
            "0x35",
            "0x36",
            "0x37",
            "0x38",
            "0x39",
            "0x3A",
            "0x3B",
            "0x3C",
            "0x3D",
            "0x3E",
            "0x3F",
            "0x40",
            "0x41",
            "0x42",
            "0x43",
            "0x44",
            "0x45",
            "0x46",
            "0x47",
            "0x48",
            "0x49",
            "0x4A",
            "0x4B",
            "0x4C",
            "0x4D",
            "0x4E",
            "0x4F",
            "0x50",
            "0x51",
            "0x52",
            "0x53",
            "0x54",
            "0x55",
            "0x56",
            "0x57",
            "0x58",
            "0x59",
            "0x5A",
            "0x5B",
            "0x5C",
            "0x5D",
            "0x5E",
            "0x5F",
            "0x60",
            "0x61",
            "0x62",
            "0x63",
            "0x64",
            "0x65",
            "0x66",
            "0x67",
            "0x68",
            "0x69",
            "0x6A",
            "0x6B",
            "0x6C",
            "0x6D",
            "0x6E",
            "0x6F",
            "0x70",
            "0x71",
            "0x72",
            "0x73",
            "0x74",
            "0x75",
            "0x76",
            "0x77",
            "0x78",
            "0x79",
            "0x7A",
            "0x7B",
            "0x7C",
            "0x7D",
            "0x7E",
            "0x7F",
            "0x80",
            "0x81",
            "0x82",
            "0x83",
            "0x84",
            "0x85",
            "0x86",
            "0x87",
            "0x88",
            "0x89",
            "0x8A",
            "0x8B",
            "0x8C",
            "0x8D",
            "0x8E",
            "0x8F",
            "0x90",
            "0x91",
            "0x92",
            "0x93",
            "0x94",
            "0x95",
            "0x96",
            "0x97",
            "0x98",
            "0x99",
            "0x9A",
            "0x9B",
            "0x9C",
            "0x9D",
            "0x9E",
            "0x9F",
            "0xA0",
            "0xA1",
            "0xA2",
            "0xA3",
            "0xA4",
            "0xA5",
            "0xA6",
            "0xA7",
            "0xA8",
            "0xA9",
            "0xAA",
            "0xAB",
            "0xAC",
            "0xAD",
            "0xAE",
            "0xAF",
            "0xB0",
            "0xB1",
            "0xB2",
            "0xB3",
            "0xB4",
            "0xB5",
            "0xB6",
            "0xB7",
            "0xB8",
            "0xB9",
            "0xBA",
            "0xBB",
            "0xBC",
            "0xBD",
            "0xBE",
            "0xBF",
            "0xC0",
            "0xC1",
            "0xC2",
            "0xC3",
            "0xC4",
            "0xC5",
            "0xC6",
            "0xC7",
            "0xC8",
            "0xC9",
            "0xCA",
            "0xCB",
            "0xCC",
            "0xCD",
            "0xCE",
            "0xCF",
            "0xD0",
            "0xD1",
            "0xD2",
            "0xD3",
            "0xD4",
            "0xD5",
            "0xD6",
            "0xD7",
            "0xD8",
            "0xD9",
            "0xDA",
            "0xDB",
            "0xDC",
            "0xDD",
            "0xDE",
            "0xDF",
            "0xE0",
            "0xE1",
            "0xE2",
            "0xE3",
            "0xE4",
            "0xE5",
            "0xE6",
            "0xE7",
            "0xE8",
            "0xE9",
            "0xEA",
            "0xEB",
            "0xEC",
            "0xED",
            "0xEE",
            "0x3F",
            "0xF0",
            "0xF1",
            "0xF2",
            "0xF3",
            "0xF4",
            "0xF5",
            "0xF6",
            "0xF7",
            "0xF8",
            "0xF9",
            "0xFA",
            "0xFB",
            "0xFC",
            "0xFD",
            "0xFE",
            "0xFF"});
            this.readRegister_comboBox.Location = new System.Drawing.Point(91, 256);
            this.readRegister_comboBox.Name = "readRegister_comboBox";
            this.readRegister_comboBox.Size = new System.Drawing.Size(139, 21);
            this.readRegister_comboBox.TabIndex = 13;
            this.readRegister_comboBox.SelectedIndexChanged += new System.EventHandler(this.readRegister_comboBox_SelectedIndexChanged);
            // 
            // registerValue_txtBox
            // 
            this.registerValue_txtBox.Location = new System.Drawing.Point(91, 296);
            this.registerValue_txtBox.Name = "registerValue_txtBox";
            this.registerValue_txtBox.Size = new System.Drawing.Size(139, 20);
            this.registerValue_txtBox.TabIndex = 14;
            // 
            // selectRegister_lbl
            // 
            this.selectRegister_lbl.AutoSize = true;
            this.selectRegister_lbl.Location = new System.Drawing.Point(91, 240);
            this.selectRegister_lbl.Name = "selectRegister_lbl";
            this.selectRegister_lbl.Size = new System.Drawing.Size(82, 13);
            this.selectRegister_lbl.TabIndex = 15;
            this.selectRegister_lbl.Text = "Select Register:";
            // 
            // registerValue_lbl
            // 
            this.registerValue_lbl.AutoSize = true;
            this.registerValue_lbl.Location = new System.Drawing.Point(91, 280);
            this.registerValue_lbl.Name = "registerValue_lbl";
            this.registerValue_lbl.Size = new System.Drawing.Size(76, 13);
            this.registerValue_lbl.TabIndex = 16;
            this.registerValue_lbl.Text = "Register Value";
            // 
            // writeRegister_btn
            // 
            this.writeRegister_btn.Location = new System.Drawing.Point(12, 282);
            this.writeRegister_btn.Name = "writeRegister_btn";
            this.writeRegister_btn.Size = new System.Drawing.Size(73, 34);
            this.writeRegister_btn.TabIndex = 17;
            this.writeRegister_btn.Text = "Write Register";
            this.writeRegister_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 337);
            this.Controls.Add(this.writeRegister_btn);
            this.Controls.Add(this.registerValue_lbl);
            this.Controls.Add(this.selectRegister_lbl);
            this.Controls.Add(this.registerValue_txtBox);
            this.Controls.Add(this.readRegister_comboBox);
            this.Controls.Add(this.readRegister_btn);
            this.Controls.Add(this.readRegisterFile_txtBox);
            this.Controls.Add(this.readRegisterFile_btn);
            this.Controls.Add(this.toggleTestLed_btn);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.selectVideoFormat_lbl);
            this.Controls.Add(this.selectVideoFormat_comboBox);
            this.Controls.Add(this.changeVideoFormat_btn);
            this.Controls.Add(this.closeSerialPort_btn);
            this.Controls.Add(this.openSerialPort_btn);
            this.Controls.Add(this.serialPort_lbl);
            this.Controls.Add(this.serialPort_txtBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serialPort_txtBox;
        private System.Windows.Forms.Label serialPort_lbl;
        private System.Windows.Forms.Button openSerialPort_btn;
        private System.Windows.Forms.Button closeSerialPort_btn;
        private System.Windows.Forms.Button changeVideoFormat_btn;
        private System.Windows.Forms.ComboBox selectVideoFormat_comboBox;
        private System.Windows.Forms.Label selectVideoFormat_lbl;
        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.Button toggleTestLed_btn;
        private System.Windows.Forms.Button readRegisterFile_btn;
        private System.Windows.Forms.TextBox readRegisterFile_txtBox;
        private System.Windows.Forms.Button readRegister_btn;
        private System.Windows.Forms.ComboBox readRegister_comboBox;
        private System.Windows.Forms.TextBox registerValue_txtBox;
        private System.Windows.Forms.Label selectRegister_lbl;
        private System.Windows.Forms.Label registerValue_lbl;
        private System.Windows.Forms.Button writeRegister_btn;
    }
}

