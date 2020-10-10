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
using System.Threading;

namespace magX
{
    public partial class Form5 : Form
    {
       float X, Y, Xpos = 0, Ypos = 0, R, S = 0;
        int width, height, G;
        Graphics myG;
        Bitmap canvas;
        string com;
        string filePath_;
        string[] codeArray;
        float xMax = float.NegativeInfinity, yMax = float.NegativeInfinity;

        public Form5(string path)
        {
            InitializeComponent();
            filePath_ = path;
            double mm2px = 96 / 25.4;
            canvas = new Bitmap(manualViewer.Size.Width, manualViewer.Size.Height);
            myG = Graphics.FromImage(canvas);
            width = 170;
            height = 85;
            if (counter > 0)
            {
                myG.Clear(Color.Black);
                manualViewer.Refresh();
                if (gridCreated)
                    createGrids();
                Rectangle r = new Rectangle(Convert.ToInt32(0 * mm2px), Convert.ToInt32((85 - yMax) * mm2px), Convert.ToInt32((5 + xMax) * mm2px), Convert.ToInt32(height * mm2px));
                myG.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), r);
                manualViewer.Image = canvas;
            }
        }
        bool gridCreated = false;

        int lenn=0;
        private void Form5_Load(object sender, EventArgs e)
        {
            xMax = yMax = float.NegativeInfinity;
            progress.Value = 0;
            lenn = File.ReadLines(filePath_).Count();
            codeArray = new string[lenn];
            int i = 0;
            foreach (string line in File.ReadAllLines(filePath_))
            {
                aspect(line);
                codeArray[i] = line;

                i++;

            }
            double mm2px = 96 / 25.4;
            myG = Graphics.FromImage(canvas);
           Rectangle r = new Rectangle(Convert.ToInt32(0 * mm2px), Convert.ToInt32((95 - yMax) * mm2px), Convert.ToInt32((5 + xMax) * mm2px), Convert.ToInt32(height * mm2px));
           // myG.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), r);
            //manualViewer.Image = canvas;
            manualViewer.Enabled = true;
        }
        // function that calculate aspect ratio...
        int gg;
        float xx, yy;
        void aspect(string com)
        {
            if (com.StartsWith("G"))
            {
                gg = int.Parse(com.Substring(com.IndexOf('G') + 1, com.IndexOf('X') - 1));
                if (gg == 1)
                {
                    yy = float.Parse(com.Substring(com.IndexOf('Y') + 1));
                    xx = float.Parse(com.Substring((com.IndexOf('X') + 1), com.IndexOf('Y') - com.IndexOf('X') - 1));
                }
                if (gg == 2 || gg == 3)
                {
                    yy = float.Parse(com.Substring(com.IndexOf('Y') + 1, com.IndexOf('R') - com.IndexOf('Y') - 1));
                    xx = float.Parse(com.Substring((com.IndexOf('X') + 1), com.IndexOf('Y') - com.IndexOf('X') - 1));
                }
                if (xx > xMax)
                {
                    xMax = xx;
                }

                if (yy > yMax)
                {
                    yMax = yy;
                }

            }


        }

        private void simuBtn_Click(object sender, EventArgs e)
        {
            double mm2px = 96 / 25.4;
            myG = Graphics.FromImage(canvas);
            //////////////////////////////////////////////////////////
            progress.Value = 0;
            progress.Minimum = 0;
            progress.Maximum = codeArray.Length;
            //////////////////////////////////////////////////////////////
            if (counter > 0)
            {
                myG.Clear(Color.Black);
                manualViewer.Refresh();
                if (gridCreated)
                    createGrids();
                Rectangle r = new Rectangle(Convert.ToInt32(0 * mm2px), Convert.ToInt32((height - yMax) * mm2px), Convert.ToInt32( xMax* mm2px), Convert.ToInt32(height * mm2px));
                myG.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), r);
                manualViewer.Image = canvas;
            }
            for (int i = 0; i < codeArray.Length; i++)
            {
                com = codeArray[i];
                decode(com);
                progress.Value = i + 1;

                if (i == codeArray.Length - 1)
                {
                    Xpos = 0; Ypos = 0;
                    counter++;
                    MessageBox.Show("Simulation Complited Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
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

        int click = 0, counter = 0;
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            click++;

            if (click % 2 == 1)
            {
                if (counter > 0)
                    gridCreated = true;
                grid.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                createGrids();
                manualViewer.Image = canvas;
            }

            else
            {
                if (counter > 0)
                    myG.Clear(Color.Black);
                else
                    myG.Clear(Color.Black);
                grid.BackColor = System.Drawing.Color.FromArgb(73, 15, 15);
                gridCreated = false;
                manualViewer.Image = canvas;
                manualViewer.Refresh();
            }

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

        void decode(string command)
        {
            com = command;
            com = com.ToUpper();
            if (com.StartsWith("G"))
            {

                G = int.Parse(com.Substring(com.IndexOf('G') + 1, com.IndexOf('X') - 1));
                if (G == 1 && com.Contains('R') == false)
                {
                    Y = float.Parse(com.Substring(com.IndexOf('Y') + 1));
                    X = float.Parse(com.Substring((com.IndexOf('X') + 1), com.IndexOf('Y') - com.IndexOf('X') - 1));

                    height = 87;
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



        //
        // function to draw arcs

        void drawArc(float xpos, float ypos, float x, float y, float rad)
        {
            //Graphics g = Graphics.FromImage(canvas);
            Color arcPen = Color.White;

            Color bb = Color.White;
            float dd = 0.0001f;
            y = y + dd;
            int lw = 1;
            if (S == 0 || S == 40)
            {
                arcPen = Color.FromArgb(45, 255, 255, 255);
                lw = 1;
            }
            if (S == 30)
            {
                arcPen = Color.GreenYellow;
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
        //

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



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
