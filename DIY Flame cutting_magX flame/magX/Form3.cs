using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace magX
{
    public partial class manualForm : Form
    {
        Bitmap canvas;
        float X, Y, Xpos = 0, Ypos = 0, R, S = 0;
        int width, height,G;
        Graphics myG;
        string comportName,com;
        int baudRate;
        SerialPort serialport1 = new SerialPort();
        public manualForm(string data)
        {    
            InitializeComponent();
            //CREATE CANVAS
            canvas = new Bitmap(manualViewer.Size.Width, manualViewer.Size.Height);
            width = 105;
            height = 75;            

            if (data != null)
            {
                comportName = data.Substring(0, data.IndexOf("/"));
                baudRate = Convert.ToInt32(data.Substring(data.IndexOf("/") + 1));
                serialOpener(comportName, baudRate);
            }


        }
        bool gridCreated = false;
        void serialOpener(String port,int baud)
        {
            if (serialport1.IsOpen)
                serialport1.Close();
            
            serialport1.PortName = port;
            serialport1.BaudRate = baud;
            if (serialport1.IsOpen)
            {

            }
            else
            {
                serialport1.Open();
            }
        }



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            String dataSent = sendtxtBox.Text.ToUpper();
            serialport1.WriteLine(dataSent);
            output.Text += dataSent + System.Environment.NewLine;
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
            output.Refresh();
            decode();
        }

        private void manualForm_Load(object sender, EventArgs e)
        {

        }
        //  function to create gridlines...
        void createGrids()
        {
            int y, x;
            Pen pGrid = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
            myG = Graphics.FromImage(canvas);
            double mm2px = 96 / 25.4;
            int gridSize = 5;
            float sx = 0, sy = 0, ex = width, ey = height;

            //Horizontal gridlines
            {
                for (y = 0; y < ex / gridSize; y++)
                    myG.DrawLine(pGrid, sx, Convert.ToInt32(y * gridSize * mm2px), Convert.ToInt32(ex * mm2px), Convert.ToInt32(y * gridSize * mm2px));
               manualViewer.Image = canvas;
            }
            //Vertical gridlines
            for (x = 0; x < ex / gridSize; x++)
            {
                myG.DrawLine(pGrid, Convert.ToInt32(x * gridSize * mm2px), sy, Convert.ToInt32(x * gridSize * mm2px), Convert.ToInt32(ey * mm2px));
                manualViewer.Image = canvas;
            }


        }


        void decode()
        {
            com = sendtxtBox.Text;
            com = com.ToUpper();
            if (com.StartsWith("G"))
            {

                G = int.Parse(com.Substring(com.IndexOf('G') + 1, com.IndexOf('X') - 1));
                if (G == 1 && com.Contains('R') == false)
                {
                    Y = float.Parse(com.Substring(com.IndexOf('Y') + 1));
                    X = float.Parse(com.Substring((com.IndexOf('X') + 1), com.IndexOf('Y') - com.IndexOf('X') - 1));
                    
                    height = 75;
                    linearInterpolation(Xpos, height - Ypos, X, height - Y);
                    manualViewer.Image = canvas;
                    manualViewer.Refresh();
                    Thread.Sleep(100);
                    Xpos = X; Ypos = Y;


                }

                if (G == 2 || G == 3)
                {
                    Y = float.Parse(com.Substring(com.IndexOf('Y') + 1, com.IndexOf('R') - com.IndexOf('Y') - 1));
                    X = float.Parse(com.Substring((com.IndexOf('X') + 1), com.IndexOf('Y') - com.IndexOf('X') - 1));
                    R = float.Parse(com.Substring((com.IndexOf('R') + 1)));
                    drawArc(Xpos, Ypos, X, Y, R);
                    manualViewer.Image = canvas;

                }
                if (com.Contains('R') && G == 1)
                {
                    MessageBox.Show("Invalid Linear Command", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (com.StartsWith("M"))
            {
                int M;

                M = int.Parse(com.Substring(com.IndexOf('M') + 1, com.IndexOf('S') - 1));
                if (M == 300)
                {
                    S = float.Parse(com.Substring(com.IndexOf('S') + 1));


                }

            }
            else
            {
                MessageBox.Show("INVALID COMMAND", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // function to draw arcs

        void drawArc(float xpos, float ypos, float x, float y, float rad)
        {
            //Graphics g = Graphics.FromImage(canvas);
            Color arcPen = Color.White;
            float dd = 0.0001f;
            y = y + dd;
         
            int lw = 0;
            if (S == 0 || S == 40)
            {
                arcPen = Color.FromArgb(45, 255, 255, 255);
                lw = 1;
            }
            if (S == 30)
            {
                arcPen= Color.GreenYellow;
                lw = 2;
            }

            Pen p = new Pen(arcPen, lw);
            double dx = xpos - x;
            double dy = ypos - y;
            double cord_Sq = Math.Pow(dx, 2) + Math.Pow(dy, 2);
            float startAngle = 0;
            double swept = Math.Acos(1 - (cord_Sq / (2 * rad * rad)));

            double mm2px = 96 / 25.4;
            double cordX = 0, cordY = 0;
            if (dy >= 0 && dx >= 0)
            {
                if (G == 3)
                {
                    startAngle = 270;
                    cordX = xpos - rad;
                    cordY = height - ypos;
                    swept = -swept;
                    swept = 180 * swept / Math.PI;
                }
                if (G == 2)
                {
                    startAngle = 0;
                    cordX = xpos - (2 * rad);
                    cordY = height - (ypos + rad);
                    swept = 180 * swept / Math.PI;
                }


                myG.DrawArc(p, Convert.ToInt32(cordX * mm2px),
                    Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px),
                    Convert.ToInt32(2 * rad * mm2px), startAngle, Convert.ToInt32(swept));

                manualViewer.Image = canvas;
                Xpos = x;
                Ypos = y;
                G = 0;
            }

            if (dy < 0 && dx < 0)
            {
                if (G == 3)
                {
                    startAngle = 90;
                    cordX = xpos - rad;
                    cordY = height - (ypos + 2 * rad);
                    swept = -swept;
                    swept = 180 * swept / Math.PI;
                }
                if (G == 2)
                {
                    startAngle = 180;
                    cordX = xpos;
                    cordY = height - (ypos + rad);
                    swept = 180 * swept / Math.PI;
                }


                myG.DrawArc(p, Convert.ToInt32(cordX * mm2px), Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px), Convert.ToInt32(2 * rad * mm2px), startAngle, Convert.ToInt32(swept));
                // myG.DrawRectangle(pb, Convert.ToInt32(cordX * mm2px), Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px), Convert.ToInt32(2 * rad * mm2px));

                manualViewer.Image = canvas;
                Xpos = x;
                Ypos = y;
                G = 0;
            }
            if (dy >= 0 && dx < 0)
            {

                if (G == 3)
                {
                    startAngle = 180;
                    cordX = xpos;
                    cordY = height - (ypos + rad);
                    swept = -swept;
                    swept = 180 * swept / Math.PI;
                }
                if (G == 2)
                {
                    startAngle = 270;
                    cordX = xpos - rad;
                    cordY = height - ypos;
                    swept = 180 * swept / Math.PI;
                }


                myG.DrawArc(p, Convert.ToInt32(cordX * mm2px), Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px), Convert.ToInt32(2 * rad * mm2px), startAngle, Convert.ToInt32(swept));
                // myG.DrawRectangle(pb, Convert.ToInt32(cordX * mm2px), Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px), Convert.ToInt32(2 * rad * mm2px));
               manualViewer.Image = canvas;
                Xpos = x;
                Ypos = y;
                G = 0;
            }

            if (dy < 0 && dx >= 0)
            {

                if (G == 3)
                {
                    startAngle = 0;
                    cordX = xpos - 2 * rad;
                    cordY = height - (ypos + rad);
                    swept = -swept;
                    swept = 180 * swept / Math.PI;
                }
                if (G == 2)
                {
                    startAngle = 90;
                    cordX = xpos - rad;
                    cordY = height - (ypos + 2 * rad);
                    swept = 180 * swept / Math.PI;
                }


                myG.DrawArc(p, Convert.ToInt32(cordX * mm2px), Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px), Convert.ToInt32(2 * rad * mm2px), startAngle, Convert.ToInt32(swept));
                // myG.DrawRectangle(pb, Convert.ToInt32(cordX * mm2px), Convert.ToInt32(cordY * mm2px), Convert.ToInt32(2 * rad * mm2px), Convert.ToInt32(2 * rad * mm2px));
                manualViewer.Image = canvas;
                Xpos = x;
                Ypos = y;
                G = 0;
            }





        }
        
        //// function  to draw straight line
        void linearInterpolation(float Xpos, float Ypos, float x, float y)
        {
            double mm2px = 96 / 25.4;
            myG = Graphics.FromImage(canvas);
            Color p = Color.FromArgb(45, 255, 255, 255);
            int lw=1;
            if (S == 0 || S == 40)
            {
                p = Color.FromArgb(45, 255, 255, 255);
                lw = 1;
            }
            if (S == 30)
            {
                p = Color.GreenYellow;
                lw = 2;
            }
            Pen pen = new Pen(p, lw);
            myG.DrawLine(pen, Convert.ToInt32(Xpos * mm2px), Convert.ToInt32(Ypos * mm2px), Convert.ToInt32(x * mm2px), Convert.ToInt32(y * mm2px));
            manualViewer.Image = canvas;
            G = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(serialport1.IsOpen)
            serialport1.Close();
             this.Close();
        
           
         
        }

        private void enterPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                String dataSent = sendtxtBox.Text.ToUpper();
                serialport1.WriteLine(dataSent);
                output.Text += dataSent + System.Environment.NewLine;
                output.SelectionStart = output.Text.Length;
                output.ScrollToCaret();
                output.Refresh();
                decode();
                if (!String.IsNullOrEmpty(sendtxtBox.Text))
                {
                    sendtxtBox.SelectionStart = 0;
                   sendtxtBox.SelectionLength = sendtxtBox.Text.Length;
                }
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
                int click = 0, counter = 0;

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            click++;

            if (click % 2 == 1)
            {
                if (counter > 0)
                    gridCreated = true;
                grid.BackColor = System.Drawing.Color.FromArgb(224,224,224);
                createGrids();
                manualViewer.Image = canvas;
            }

            else
            {
                if (counter > 0)
                    myG.Clear(Color.Black);
                else
                    myG.Clear(Color.Black);
                grid.BackColor = System.Drawing.Color.FromArgb(73,15,15);
                gridCreated = false;
                manualViewer.Image = canvas;
                manualViewer.Refresh();
            }

        }

        private void restart_Click(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                myG.Clear(Color.Black);
              manualViewer.Refresh();
            }
            if (gridCreated)
                createGrids();

            Xpos = 0;
            Ypos = 0;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            click++;

            if (click % 2 == 1)
            {
                if (counter > 0)
                    gridCreated = true;
                createGrids();
               manualViewer.Image = canvas;
            }

            else
            {
                if (counter > 0)
                    myG.Clear(Color.Black);
                else
                    myG.Clear(Color.Black);
                gridCreated = false;
               manualViewer.Image = canvas;
                manualViewer.Refresh();
            }

        }

        private void manualViewer_Click(object sender, EventArgs e)
        {

        }
    }
}
