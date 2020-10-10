using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;

namespace magX
{

    public partial class Form1 : Form
    {
        
        string credential;
       
        public static string filepath;
        public Form1()
        {
            InitializeComponent();
            FormWindowState state = this.WindowState;
            cncir.Value = 100;
            iconPos(state);
            cncpic.Show();
            customizePanels();
            
        }
        public static string comportName;
        public static int baudRate;
        private void customizePanels()
        {
            simuPanel.Visible = false;
            commandPanel.Visible = false;
            connpanel.Visible = false;

        }
        private void iconPos(FormWindowState fw)
        {
            if (fw == FormWindowState.Normal)
            {
                cncpic.Location = new Point(childPanel.Width / 2 - cncpic.Width / 2, childPanel.Height / 2 - cncpic.Height / 2);
                cncir.Location = new Point(childPanel.Width / 2 - cncir.Width / 2, childPanel.Height / 2 - cncir.Height / 2);

            }
            else
            {
                cncpic.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - cncir.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - cncir.Height / 2);
                cncpic.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - cncpic.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - cncpic.Height / 2);
            }
           cncpic.BringToFront();
        }

        private void hidePannels()
        {
            if (simuPanel.Visible == true)
                simuPanel.Visible = false;
            if (connpanel.Visible == true)
                connpanel.Visible = false;
            if (commandPanel.Visible == true)
                commandPanel.Visible = false;
        }
        private void showPanels(Panel submenu)
        {
            if (submenu.Visible == false)
                submenu.Visible = true;
            else
                submenu.Visible = false;

        }

 
        private Form activeForm = null;
        private void openChildform(Form child)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = child;
            child.TopLevel=false;
            child.FormBorderStyle = FormBorderStyle.None;
            childPanel.Controls.Add(child);
            childPanel.Tag = child;
            child.StartPosition = FormStartPosition.CenterScreen;
            child.BringToFront();
            child.Show();
           
        }

        


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if(serialport1.IsOpen)
            serialport1.Close();
            this.Close();
        }
       
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormWindowState state = this.WindowState;
            windowMgt(state);
            
            
        }
        private void windowMgt(FormWindowState fw)
        {
            if (fw == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                iconPos(this.WindowState);

            }

            if (fw == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                

            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FormWindowState state = new FormWindowState();
            iconPos(state);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showPanels(connpanel);
        }

        private void comBtn_Click(object sender, EventArgs e)
        {
            showPanels(commandPanel);
        }

        private void SimulateBtn_Click(object sender, EventArgs e)
        {
            if (filepath != null)
            {
                loadFile_Form fl = new loadFile_Form(filepath);
                openChildform(fl);
            }
            else
            {
                MessageBox.Show(this, "File Path not specified","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
        SerialPort serialport1 = new SerialPort();
        private void button2_Click(object sender, EventArgs e)
        {
            //CODES
            hidePannels();
            Form2 f = new Form2();
            if (activeForm != null)
                activeForm.Close();
            activeForm = f;
            f.TopMost=true;
            f.Focus();
            f.BringToFront();
            if (f.ShowDialog() == DialogResult.OK)
            {
                credential = f.Credentials;
                if (credential == null)
                {

                }
                else { 
                comportName = credential.Substring(0, credential.IndexOf("/"));
                baudRate = Convert.ToInt32(credential.Substring(credential.IndexOf("/")+1));
                if(comportName!=null & baudRate != 0)
                {
                    if (serialport1.IsOpen)
                    {
                        MessageBox.Show(this, "SerialPort is open,Process cancelled", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else { 
                    //serialport1.PortName = comportName;
                    //serialport1.BaudRate = baudRate;
                    // serialport1.Open();
                    statusLabel.BackColor = System.Drawing.Color.Green;
                    label2.Text = "connected to";
                    comName.Text = comportName;
                        comName.BorderStyle = BorderStyle.FixedSingle;
                            comName.ForeColor = System.Drawing.Color.Green;
                        label2.BorderStyle = BorderStyle.None;


                    }
                   }
                }

            }





           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hidePannels();
            //CODES
            if (serialport1.IsOpen) { 
            serialport1.Close();
                statusLabel.BackColor = System.Drawing.Color.Red;
                comName.Text = "";
                comName.BorderStyle = BorderStyle.None;
        }
            statusLabel.BackColor = System.Drawing.Color.Red;
            comName.Text = "";
            comName.BorderStyle = BorderStyle.None;
           
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        Boolean formOpenned;
        private void button5_Click(object sender, EventArgs e)
        {
            hidePannels();
            manualForm fm = new manualForm(credential);
            formOpenned = CheckOpened(fm.Name);
            if (formOpenned == false)
            {
                if (credential == null)
                    MessageBox.Show(this, "Establish Serial Communication to Continue", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    openChildform(fm);
                }
            }
            else
                MessageBox.Show(this, "Close the exixsting form before starting new Session", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //CODES
            hidePannels();
            DialogResult results = openFileDialog1.ShowDialog();
            if (results == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                
            }

            
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            //CODES
            hidePannels();
        }

        private void inprocessBtn_Click(object sender, EventArgs e)
        {
            //CODES
            hidePannels();
        }

        private void simulate_Click(object sender, EventArgs e)
        {
            showPanels(simuPanel);
        }

        private void prevBtn_Click_1(object sender, EventArgs e)
        {
            hidePannels();
            string pathF = loadFile_Form.validFile;
            Form5 fms = new Form5(pathF);
            openChildform(fms);
            

        }

        private void inprocessBtn_Click_1(object sender, EventArgs e)
        {
            hidePannels();
        }
    }
}
