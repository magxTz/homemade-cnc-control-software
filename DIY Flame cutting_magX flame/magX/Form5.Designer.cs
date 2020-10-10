namespace magX
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.panel1 = new System.Windows.Forms.Panel();
            this.manualViewer = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.clear = new Bunifu.Framework.UI.BunifuImageButton();
            this.grid = new Bunifu.Framework.UI.BunifuImageButton();
            this.simuBtn = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualViewer)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 37);
            this.panel1.TabIndex = 0;
            // 
            // manualViewer
            // 
            this.manualViewer.BackColor = System.Drawing.Color.Black;
            this.manualViewer.Dock = System.Windows.Forms.DockStyle.Top;
            this.manualViewer.Location = new System.Drawing.Point(0, 37);
            this.manualViewer.Name = "manualViewer";
            this.manualViewer.Size = new System.Drawing.Size(650, 330);
            this.manualViewer.TabIndex = 1;
            this.manualViewer.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progress);
            this.panel2.Controls.Add(this.simuBtn);
            this.panel2.Controls.Add(this.bunifuImageButton2);
            this.panel2.Controls.Add(this.clear);
            this.panel2.Controls.Add(this.grid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 31);
            this.panel2.TabIndex = 2;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.bunifuImageButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(533, 0);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(39, 31);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 5;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click_1);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.clear.Dock = System.Windows.Forms.DockStyle.Right;
            this.clear.Image = ((System.Drawing.Image)(resources.GetObject("clear.Image")));
            this.clear.ImageActive = null;
            this.clear.Location = new System.Drawing.Point(572, 0);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(39, 31);
            this.clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clear.TabIndex = 4;
            this.clear.TabStop = false;
            this.clear.Zoom = 10;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // grid
            // 
            this.grid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.grid.Dock = System.Windows.Forms.DockStyle.Right;
            this.grid.Image = ((System.Drawing.Image)(resources.GetObject("grid.Image")));
            this.grid.ImageActive = null;
            this.grid.Location = new System.Drawing.Point(611, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(39, 31);
            this.grid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.grid.TabIndex = 3;
            this.grid.TabStop = false;
            this.grid.Zoom = 10;
            this.grid.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // simuBtn
            // 
            this.simuBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.simuBtn.Location = new System.Drawing.Point(0, 0);
            this.simuBtn.Name = "simuBtn";
            this.simuBtn.Size = new System.Drawing.Size(75, 31);
            this.simuBtn.TabIndex = 6;
            this.simuBtn.Text = "SIMULATE";
            this.simuBtn.UseVisualStyleBackColor = true;
            this.simuBtn.Click += new System.EventHandler(this.simuBtn_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(102, 10);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(389, 5);
            this.progress.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(585, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.manualViewer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manualViewer)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox manualViewer;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton grid;
        private Bunifu.Framework.UI.BunifuImageButton clear;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Button simuBtn;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button button1;
    }
}