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

namespace magX
{
    public partial class Form2 : Form
    {
        private string credentials;
        public string Credentials
        {
            get { return credentials; }
            set { credentials = value; } //getter setter funtion
        }
        public Form2()
        {
            InitializeComponent();
            updatePorts();
        }
        private void updatePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comPort.Items.Add(port);
            }

        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void connectPort_Click(object sender, EventArgs e)
        {
            if (baud.SelectedIndex != -1 & comPort.SelectedIndex != -1)
                Credentials = comPort.Text+"/"+baud.Text;

            else
            {
                MessageBox.Show(this, "fields can not be empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enterPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (baud.SelectedIndex != -1 & comPort.SelectedIndex != -1)
                    Credentials = comPort.Text + "/" + baud.Text;

                else
                {
                    MessageBox.Show(this, "fields can not be empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
