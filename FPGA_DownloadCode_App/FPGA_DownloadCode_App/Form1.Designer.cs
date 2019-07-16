namespace FPGA_DownloadCode_App
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFile_btn = new System.Windows.Forms.Button();
            this.quit_btn = new System.Windows.Forms.Button();
            this.selectedFile_txtbox = new System.Windows.Forms.TextBox();
            this.selectedFile_lbl = new System.Windows.Forms.Label();
            this.serialPortName_txtbox = new System.Windows.Forms.TextBox();
            this.serialPortName_lbl = new System.Windows.Forms.Label();
            this.openSerialPort_btn = new System.Windows.Forms.Button();
            this.writeConfiguration_btn = new System.Windows.Forms.Button();
            this.writeConfiguration_progbar = new System.Windows.Forms.ProgressBar();
            this.writeConfiguration_lbl = new System.Windows.Forms.Label();
            this.toggleTestLed_btn = new System.Windows.Forms.Button();
            this.closeSerialPort_btn = new System.Windows.Forms.Button();
            this.executeCommand_lbl = new System.Windows.Forms.Label();
            this.executeCommand_box = new System.Windows.Forms.ComboBox();
            this.executeCommand_btn = new System.Windows.Forms.Button();
            this.executeCommand_txtBox = new System.Windows.Forms.TextBox();
            this.executeCommandOutput_lbl = new System.Windows.Forms.Label();
            this.fileSize_lbl = new System.Windows.Forms.Label();
            this.fileSizeNumber_lbl = new System.Windows.Forms.Label();
            this.executeCommandParameter_txtBox = new System.Windows.Forms.TextBox();
            this.readConfiguration_btn = new System.Windows.Forms.Button();
            this.validateConfiguration_btn = new System.Windows.Forms.Button();
            this.resetFPGA_btn = new System.Windows.Forms.Button();
            this.eraseConfigurationMemory_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFile_btn
            // 
            this.openFile_btn.Location = new System.Drawing.Point(130, 133);
            this.openFile_btn.Name = "openFile_btn";
            this.openFile_btn.Size = new System.Drawing.Size(75, 23);
            this.openFile_btn.TabIndex = 0;
            this.openFile_btn.Text = "Open File";
            this.openFile_btn.UseVisualStyleBackColor = true;
            this.openFile_btn.Click += new System.EventHandler(this.openFile_btn_Click);
            // 
            // quit_btn
            // 
            this.quit_btn.Location = new System.Drawing.Point(450, 311);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 1;
            this.quit_btn.Text = "Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // selectedFile_txtbox
            // 
            this.selectedFile_txtbox.Location = new System.Drawing.Point(12, 133);
            this.selectedFile_txtbox.Name = "selectedFile_txtbox";
            this.selectedFile_txtbox.Size = new System.Drawing.Size(100, 20);
            this.selectedFile_txtbox.TabIndex = 2;
            // 
            // selectedFile_lbl
            // 
            this.selectedFile_lbl.AutoSize = true;
            this.selectedFile_lbl.Location = new System.Drawing.Point(10, 117);
            this.selectedFile_lbl.Name = "selectedFile_lbl";
            this.selectedFile_lbl.Size = new System.Drawing.Size(71, 13);
            this.selectedFile_lbl.TabIndex = 3;
            this.selectedFile_lbl.Text = "Selected File:";
            // 
            // serialPortName_txtbox
            // 
            this.serialPortName_txtbox.Location = new System.Drawing.Point(12, 39);
            this.serialPortName_txtbox.Name = "serialPortName_txtbox";
            this.serialPortName_txtbox.Size = new System.Drawing.Size(100, 20);
            this.serialPortName_txtbox.TabIndex = 4;
            this.serialPortName_txtbox.Text = "COM10";
            // 
            // serialPortName_lbl
            // 
            this.serialPortName_lbl.AutoSize = true;
            this.serialPortName_lbl.Location = new System.Drawing.Point(9, 23);
            this.serialPortName_lbl.Name = "serialPortName_lbl";
            this.serialPortName_lbl.Size = new System.Drawing.Size(58, 13);
            this.serialPortName_lbl.TabIndex = 5;
            this.serialPortName_lbl.Text = "Serial Port:";
            this.serialPortName_lbl.Click += new System.EventHandler(this.serialPortName_lbl_Click);
            // 
            // openSerialPort_btn
            // 
            this.openSerialPort_btn.Location = new System.Drawing.Point(118, 39);
            this.openSerialPort_btn.Name = "openSerialPort_btn";
            this.openSerialPort_btn.Size = new System.Drawing.Size(62, 39);
            this.openSerialPort_btn.TabIndex = 6;
            this.openSerialPort_btn.Text = "Open Serial Port";
            this.openSerialPort_btn.UseVisualStyleBackColor = true;
            this.openSerialPort_btn.Click += new System.EventHandler(this.openSerialPort_btn_Click);
            // 
            // writeConfiguration_btn
            // 
            this.writeConfiguration_btn.Location = new System.Drawing.Point(12, 175);
            this.writeConfiguration_btn.Name = "writeConfiguration_btn";
            this.writeConfiguration_btn.Size = new System.Drawing.Size(84, 45);
            this.writeConfiguration_btn.TabIndex = 7;
            this.writeConfiguration_btn.Text = "Write Configuration";
            this.writeConfiguration_btn.UseVisualStyleBackColor = true;
            this.writeConfiguration_btn.Click += new System.EventHandler(this.writeConfiguration_btn_Click);
            // 
            // writeConfiguration_progbar
            // 
            this.writeConfiguration_progbar.Location = new System.Drawing.Point(12, 246);
            this.writeConfiguration_progbar.Name = "writeConfiguration_progbar";
            this.writeConfiguration_progbar.Size = new System.Drawing.Size(237, 23);
            this.writeConfiguration_progbar.TabIndex = 8;
            this.writeConfiguration_progbar.Click += new System.EventHandler(this.writeConfiguration_progbar_Click);
            // 
            // writeConfiguration_lbl
            // 
            this.writeConfiguration_lbl.AutoSize = true;
            this.writeConfiguration_lbl.Location = new System.Drawing.Point(13, 227);
            this.writeConfiguration_lbl.Name = "writeConfiguration_lbl";
            this.writeConfiguration_lbl.Size = new System.Drawing.Size(137, 13);
            this.writeConfiguration_lbl.TabIndex = 9;
            this.writeConfiguration_lbl.Text = "Downloading Configuration:";
            // 
            // toggleTestLed_btn
            // 
            this.toggleTestLed_btn.Location = new System.Drawing.Point(284, 39);
            this.toggleTestLed_btn.Name = "toggleTestLed_btn";
            this.toggleTestLed_btn.Size = new System.Drawing.Size(75, 39);
            this.toggleTestLed_btn.TabIndex = 10;
            this.toggleTestLed_btn.Text = "Toggle Test Led";
            this.toggleTestLed_btn.UseVisualStyleBackColor = true;
            this.toggleTestLed_btn.Click += new System.EventHandler(this.toggleTestLed_btn_Click);
            // 
            // closeSerialPort_btn
            // 
            this.closeSerialPort_btn.Location = new System.Drawing.Point(186, 39);
            this.closeSerialPort_btn.Name = "closeSerialPort_btn";
            this.closeSerialPort_btn.Size = new System.Drawing.Size(67, 39);
            this.closeSerialPort_btn.TabIndex = 11;
            this.closeSerialPort_btn.Text = "Close Serial Port";
            this.closeSerialPort_btn.UseVisualStyleBackColor = true;
            this.closeSerialPort_btn.Click += new System.EventHandler(this.closeSerialPort_btn_Click);
            // 
            // executeCommand_lbl
            // 
            this.executeCommand_lbl.AutoSize = true;
            this.executeCommand_lbl.Location = new System.Drawing.Point(401, 39);
            this.executeCommand_lbl.Name = "executeCommand_lbl";
            this.executeCommand_lbl.Size = new System.Drawing.Size(99, 13);
            this.executeCommand_lbl.TabIndex = 12;
            this.executeCommand_lbl.Text = "Execute Command:";
            // 
            // executeCommand_box
            // 
            this.executeCommand_box.FormattingEnabled = true;
            this.executeCommand_box.Items.AddRange(new object[] {
            "Write Enable",
            "Volatile SR Write Enable",
            "Write Disable",
            "Read Status Register 1",
            "Read Status Register 2",
            "Write Status Register",
            "Page Program",
            "Sector Erase (4KB)",
            "Block Erase (32KB)",
            "Block Erase (64KB)",
            "Chip Erase",
            "Erase / Program Suspend",
            "Erase / Program Resume",
            "Power-down",
            "Read Data",
            "Fast Read",
            "Release Powedown / ID",
            "Manufacturer / Device ID",
            "JEDEC ID",
            "Read Unique ID",
            "Read SFDP Register",
            "Erase Security Registers",
            "Program Security Registers",
            "Read Security Registers",
            "Enable Reset",
            "Reset",
            "Fast Read Dual Output ",
            "Fast Read Dual I/O",
            "Manufacturer / Device Id by Dual I/O",
            "Quad Page Program",
            "Fast Read Quad Output",
            "Set Burst with Wrap",
            "Manufacturer / Device ID by Quad I/O"});
            this.executeCommand_box.Location = new System.Drawing.Point(404, 56);
            this.executeCommand_box.Name = "executeCommand_box";
            this.executeCommand_box.Size = new System.Drawing.Size(121, 21);
            this.executeCommand_box.TabIndex = 13;
            // 
            // executeCommand_btn
            // 
            this.executeCommand_btn.Location = new System.Drawing.Point(404, 84);
            this.executeCommand_btn.Name = "executeCommand_btn";
            this.executeCommand_btn.Size = new System.Drawing.Size(121, 24);
            this.executeCommand_btn.TabIndex = 14;
            this.executeCommand_btn.Text = "Execute Command";
            this.executeCommand_btn.UseVisualStyleBackColor = true;
            this.executeCommand_btn.Click += new System.EventHandler(this.executeCommand_btn_Click);
            // 
            // executeCommand_txtBox
            // 
            this.executeCommand_txtBox.Location = new System.Drawing.Point(404, 133);
            this.executeCommand_txtBox.Multiline = true;
            this.executeCommand_txtBox.Name = "executeCommand_txtBox";
            this.executeCommand_txtBox.Size = new System.Drawing.Size(121, 87);
            this.executeCommand_txtBox.TabIndex = 15;
            // 
            // executeCommandOutput_lbl
            // 
            this.executeCommandOutput_lbl.AutoSize = true;
            this.executeCommandOutput_lbl.Location = new System.Drawing.Point(404, 114);
            this.executeCommandOutput_lbl.Name = "executeCommandOutput_lbl";
            this.executeCommandOutput_lbl.Size = new System.Drawing.Size(92, 13);
            this.executeCommandOutput_lbl.TabIndex = 16;
            this.executeCommandOutput_lbl.Text = "Command Output:";
            // 
            // fileSize_lbl
            // 
            this.fileSize_lbl.AutoSize = true;
            this.fileSize_lbl.Location = new System.Drawing.Point(12, 156);
            this.fileSize_lbl.Name = "fileSize_lbl";
            this.fileSize_lbl.Size = new System.Drawing.Size(49, 13);
            this.fileSize_lbl.TabIndex = 17;
            this.fileSize_lbl.Text = "File Size:";
            // 
            // fileSizeNumber_lbl
            // 
            this.fileSizeNumber_lbl.AutoSize = true;
            this.fileSizeNumber_lbl.Location = new System.Drawing.Point(61, 156);
            this.fileSizeNumber_lbl.Name = "fileSizeNumber_lbl";
            this.fileSizeNumber_lbl.Size = new System.Drawing.Size(0, 13);
            this.fileSizeNumber_lbl.TabIndex = 18;
            // 
            // executeCommandParameter_txtBox
            // 
            this.executeCommandParameter_txtBox.Location = new System.Drawing.Point(404, 227);
            this.executeCommandParameter_txtBox.Name = "executeCommandParameter_txtBox";
            this.executeCommandParameter_txtBox.Size = new System.Drawing.Size(100, 20);
            this.executeCommandParameter_txtBox.TabIndex = 19;
            this.executeCommandParameter_txtBox.Text = "0";
            this.executeCommandParameter_txtBox.TextChanged += new System.EventHandler(this.executeCommandParameter_txtBox_TextChanged);
            // 
            // readConfiguration_btn
            // 
            this.readConfiguration_btn.Location = new System.Drawing.Point(102, 175);
            this.readConfiguration_btn.Name = "readConfiguration_btn";
            this.readConfiguration_btn.Size = new System.Drawing.Size(87, 45);
            this.readConfiguration_btn.TabIndex = 20;
            this.readConfiguration_btn.Text = "Read Configuration";
            this.readConfiguration_btn.UseVisualStyleBackColor = true;
            this.readConfiguration_btn.Click += new System.EventHandler(this.readConfiguration_btn_Click);
            // 
            // validateConfiguration_btn
            // 
            this.validateConfiguration_btn.Location = new System.Drawing.Point(195, 175);
            this.validateConfiguration_btn.Name = "validateConfiguration_btn";
            this.validateConfiguration_btn.Size = new System.Drawing.Size(77, 45);
            this.validateConfiguration_btn.TabIndex = 21;
            this.validateConfiguration_btn.Text = "Validate Configuration";
            this.validateConfiguration_btn.UseVisualStyleBackColor = true;
            this.validateConfiguration_btn.Click += new System.EventHandler(this.validateConfiguration_btn_Click);
            // 
            // resetFPGA_btn
            // 
            this.resetFPGA_btn.Location = new System.Drawing.Point(284, 246);
            this.resetFPGA_btn.Name = "resetFPGA_btn";
            this.resetFPGA_btn.Size = new System.Drawing.Size(87, 23);
            this.resetFPGA_btn.TabIndex = 22;
            this.resetFPGA_btn.Text = "Reset FPGA";
            this.resetFPGA_btn.UseVisualStyleBackColor = true;
            this.resetFPGA_btn.Click += new System.EventHandler(this.resetFPGA_btn_Click);
            // 
            // eraseConfigurationMemory_btn
            // 
            this.eraseConfigurationMemory_btn.Location = new System.Drawing.Point(284, 175);
            this.eraseConfigurationMemory_btn.Name = "eraseConfigurationMemory_btn";
            this.eraseConfigurationMemory_btn.Size = new System.Drawing.Size(87, 53);
            this.eraseConfigurationMemory_btn.TabIndex = 23;
            this.eraseConfigurationMemory_btn.Text = "Erase Configuration Memory";
            this.eraseConfigurationMemory_btn.UseVisualStyleBackColor = true;
            this.eraseConfigurationMemory_btn.Click += new System.EventHandler(this.eraseConfigurationMemory_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 346);
            this.Controls.Add(this.eraseConfigurationMemory_btn);
            this.Controls.Add(this.resetFPGA_btn);
            this.Controls.Add(this.validateConfiguration_btn);
            this.Controls.Add(this.readConfiguration_btn);
            this.Controls.Add(this.executeCommandParameter_txtBox);
            this.Controls.Add(this.fileSizeNumber_lbl);
            this.Controls.Add(this.fileSize_lbl);
            this.Controls.Add(this.executeCommandOutput_lbl);
            this.Controls.Add(this.executeCommand_txtBox);
            this.Controls.Add(this.executeCommand_btn);
            this.Controls.Add(this.executeCommand_box);
            this.Controls.Add(this.executeCommand_lbl);
            this.Controls.Add(this.closeSerialPort_btn);
            this.Controls.Add(this.toggleTestLed_btn);
            this.Controls.Add(this.writeConfiguration_lbl);
            this.Controls.Add(this.writeConfiguration_progbar);
            this.Controls.Add(this.writeConfiguration_btn);
            this.Controls.Add(this.openSerialPort_btn);
            this.Controls.Add(this.serialPortName_lbl);
            this.Controls.Add(this.serialPortName_txtbox);
            this.Controls.Add(this.selectedFile_lbl);
            this.Controls.Add(this.selectedFile_txtbox);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.openFile_btn);
            this.Name = "Form1";
            this.Text = " FPGA Download Code App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFile_btn;
        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.TextBox selectedFile_txtbox;
        private System.Windows.Forms.Label selectedFile_lbl;
        private System.Windows.Forms.TextBox serialPortName_txtbox;
        private System.Windows.Forms.Label serialPortName_lbl;
        private System.Windows.Forms.Button openSerialPort_btn;
        private System.Windows.Forms.Button writeConfiguration_btn;
        private System.Windows.Forms.ProgressBar writeConfiguration_progbar;
        private System.Windows.Forms.Label writeConfiguration_lbl;
        private System.Windows.Forms.Button toggleTestLed_btn;
        private System.Windows.Forms.Button closeSerialPort_btn;
        private System.Windows.Forms.Label executeCommand_lbl;
        private System.Windows.Forms.ComboBox executeCommand_box;
        private System.Windows.Forms.Button executeCommand_btn;
        private System.Windows.Forms.TextBox executeCommand_txtBox;
        private System.Windows.Forms.Label executeCommandOutput_lbl;
        private System.Windows.Forms.Label fileSize_lbl;
        private System.Windows.Forms.Label fileSizeNumber_lbl;
        private System.Windows.Forms.TextBox executeCommandParameter_txtBox;
        private System.Windows.Forms.Button readConfiguration_btn;
        private System.Windows.Forms.Button validateConfiguration_btn;
        private System.Windows.Forms.Button resetFPGA_btn;
        private System.Windows.Forms.Button eraseConfigurationMemory_btn;
    }
}

