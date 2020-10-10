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

namespace magX
{
    public partial class loadFile_Form : Form
    {
        string long_fileName;
        public static string validFile;
        public loadFile_Form(string path)
        {
            InitializeComponent();
            filepathTxt.Text = path;
            long_fileName = path.Substring(path.LastIndexOf("\\")+1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void enableControls()
        {
            unwanted.Enabled = true;
            discard.Enabled = true;
            readOnly.Enabled = true;
            validCommands.Enabled = true;

        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openTxt.Clear();
            int len;
            openTxt.Enabled = false;
            

            String fpath = filepathTxt.Text;
            len = File.ReadLines(fpath).Count();
            commands.Text = Convert.ToString(len) + " Received commands";
            foreach (string line in File.ReadAllLines(fpath))
            {
                openTxt.Text += line + System.Environment.NewLine;
                openTxt.SelectionStart = openTxt.Text.Length;
                openTxt.ScrollToCaret();
                openTxt.Refresh();
            }
            enableControls();
        }

        private void readOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!readOnly.Checked)
                openTxt.Enabled = true;
            else
                openTxt.Enabled = false;

        }

        private void clear_Click(object sender, EventArgs e)
        {
            openTxt.Clear();
            
        }
        string[] stringArray;
        private void discard_Click(object sender, EventArgs e)
        {
            //create file that contain all valid commands;
          
            string dt = DateTime.UtcNow.ToString("MM-dd-yyyy ");

            string newFile = dt+long_fileName;
            try
            {
                if (File.Exists(newFile))
                {
                    File.Delete(newFile);

                }
                using (FileStream fs = File.Create(newFile))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(openTxt.Text);
                    fs.Write(info, 0, info.Length);
                }
                openTxt.Clear();

                //file to array.................................
                string[] lines = File.ReadAllLines(newFile);

                stringArray = new string[lines.Length];
                int i = 0;
                StreamReader sr = File.OpenText(newFile);
                for (i = 0; i < lines.Length; i++)
                {
                    int a = lines[i].IndexOf(unwanted.Text);

                    if (a >= 0)
                    {
                        stringArray[i] = lines[i].Remove(a);

                    }
                    else if (a == -1)
                    {
                        stringArray[i] = lines[i];
                    }
                    if (!string.IsNullOrEmpty(stringArray[i]) || !string.IsNullOrWhiteSpace(stringArray[i]))
                    {
                      openTxt.Text += stringArray[i] + System.Environment.NewLine;
                        openTxt.SelectionStart = openTxt.Text.Length;
                       openTxt.ScrollToCaret();
                        openTxt.Refresh();

                    }

                }
                sr.Close();
                commands.Text = openTxt.Lines.Count() + " Valid commands";



            }
            catch (Exception ex)
            {
                openTxt.Text = ex.ToString();
            }

            

        }

        private void validCommands_Click(object sender, EventArgs e)
        {
            if (stringArray.Length == 0)
            {
                MessageBox.Show("error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string newFile = "Valid "+DateTime.UtcNow.ToString("MM-dd-yyyy ")+long_fileName;
                try
                {
                    if (File.Exists(newFile))
                    {
                        File.Delete(newFile);

                    }
                    using (FileStream fs = File.Create(newFile))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(openTxt.Text);
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                    }
                    validFile = newFile;

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            MessageBox.Show(this, "File Compiled successfully", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
