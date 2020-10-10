namespace magX
{
    partial class loadFile_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loadFile_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.openTxt = new System.Windows.Forms.TextBox();
            this.clear = new Bunifu.Framework.UI.BunifuImageButton();
            this.readOnly = new System.Windows.Forms.CheckBox();
            this.discard = new Bunifu.Framework.UI.BunifuImageButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openFile = new System.Windows.Forms.Button();
            this.filepathTxt = new System.Windows.Forms.TextBox();
            this.commands = new System.Windows.Forms.Label();
            this.unwanted = new System.Windows.Forms.TextBox();
            this.validCommands = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discard)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("MingLiU-ExtB", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loaded file";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 30);
            this.panel1.TabIndex = 1;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.ImageActive = null;
            this.close.Location = new System.Drawing.Point(464, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(43, 28);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close.TabIndex = 8;
            this.close.TabStop = false;
            this.close.Zoom = 10;
            this.close.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.openTxt);
            this.panel2.Location = new System.Drawing.Point(-4, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 302);
            this.panel2.TabIndex = 2;
            // 
            // openTxt
            // 
            this.openTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openTxt.Location = new System.Drawing.Point(0, 0);
            this.openTxt.Multiline = true;
            this.openTxt.Name = "openTxt";
            this.openTxt.Size = new System.Drawing.Size(368, 302);
            this.openTxt.TabIndex = 0;
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.clear.Enabled = false;
            this.clear.Image = ((System.Drawing.Image)(resources.GetObject("clear.Image")));
            this.clear.ImageActive = null;
            this.clear.Location = new System.Drawing.Point(370, 242);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(43, 31);
            this.clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clear.TabIndex = 1;
            this.clear.TabStop = false;
            this.clear.Zoom = 10;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // readOnly
            // 
            this.readOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readOnly.AutoSize = true;
            this.readOnly.Checked = true;
            this.readOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readOnly.Enabled = false;
            this.readOnly.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.readOnly.Location = new System.Drawing.Point(370, 286);
            this.readOnly.Name = "readOnly";
            this.readOnly.Size = new System.Drawing.Size(73, 17);
            this.readOnly.TabIndex = 3;
            this.readOnly.Text = "ReadOnly";
            this.readOnly.UseVisualStyleBackColor = true;
            this.readOnly.CheckedChanged += new System.EventHandler(this.readOnly_CheckedChanged);
            // 
            // discard
            // 
            this.discard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.discard.Enabled = false;
            this.discard.Image = ((System.Drawing.Image)(resources.GetObject("discard.Image")));
            this.discard.ImageActive = null;
            this.discard.Location = new System.Drawing.Point(370, 185);
            this.discard.Name = "discard";
            this.discard.Size = new System.Drawing.Size(43, 31);
            this.discard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.discard.TabIndex = 4;
            this.discard.TabStop = false;
            this.discard.Zoom = 10;
            this.discard.Click += new System.EventHandler(this.discard_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(413, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Discard Non Command";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(413, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clear All";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.openFile);
            this.panel3.Controls.Add(this.filepathTxt);
            this.panel3.Location = new System.Drawing.Point(-4, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panel3.Size = new System.Drawing.Size(510, 37);
            this.panel3.TabIndex = 7;
            // 
            // openFile
            // 
            this.openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFile.Location = new System.Drawing.Point(398, 8);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(65, 23);
            this.openFile.TabIndex = 1;
            this.openFile.Text = "OPEN";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // filepathTxt
            // 
            this.filepathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filepathTxt.Location = new System.Drawing.Point(10, 10);
            this.filepathTxt.Name = "filepathTxt";
            this.filepathTxt.Size = new System.Drawing.Size(344, 20);
            this.filepathTxt.TabIndex = 0;
            // 
            // commands
            // 
            this.commands.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.commands.Location = new System.Drawing.Point(370, 109);
            this.commands.Name = "commands";
            this.commands.Size = new System.Drawing.Size(133, 36);
            this.commands.TabIndex = 8;
            // 
            // unwanted
            // 
            this.unwanted.Enabled = false;
            this.unwanted.Location = new System.Drawing.Point(373, 148);
            this.unwanted.Name = "unwanted";
            this.unwanted.Size = new System.Drawing.Size(40, 20);
            this.unwanted.TabIndex = 9;
            // 
            // validCommands
            // 
            this.validCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validCommands.Enabled = false;
            this.validCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validCommands.Location = new System.Drawing.Point(370, 328);
            this.validCommands.Name = "validCommands";
            this.validCommands.Size = new System.Drawing.Size(121, 47);
            this.validCommands.TabIndex = 10;
            this.validCommands.Text = "Collect Valid Commands";
            this.validCommands.UseVisualStyleBackColor = true;
            this.validCommands.Click += new System.EventHandler(this.validCommands_Click);
            // 
            // loadFile_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(506, 387);
            this.Controls.Add(this.validCommands);
            this.Controls.Add(this.unwanted);
            this.Controls.Add(this.commands);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.discard);
            this.Controls.Add(this.readOnly);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loadFile_Form";
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discard)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox openTxt;
        private Bunifu.Framework.UI.BunifuImageButton clear;
        private System.Windows.Forms.CheckBox readOnly;
        private Bunifu.Framework.UI.BunifuImageButton discard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox filepathTxt;
        private Bunifu.Framework.UI.BunifuImageButton close;
        private System.Windows.Forms.Label commands;
        private System.Windows.Forms.TextBox unwanted;
        private System.Windows.Forms.Button validCommands;
    }
}