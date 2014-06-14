using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawLineP(int x1,int y1,int x2,int y2, Bitmap pb)
        {
            int deltaX = Math.Abs(x2 - x1);
            int deltaY = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            int error = deltaX - deltaY;
            pb.SetPixel(x2, y2, Color.Red);
            while (x1 != x2 || y1 != y2)
            {
                pb.SetPixel(x1, y1, Color.Red);
                int error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    x1 += signX;
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    y1 += signY;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            Bitmap btm = new Bitmap(801, 401);
            Graphics grp = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            grp.DrawLine(new Pen(Color.Black, 1), 0, 200, 800, 200);
            grp.DrawLine(new Pen(Color.Black, 1), 400, 0, 400, 400);
            int p1x, p1y, p2x, p2y;
            for (double x = -400; x <= 399; x++)
            {
                p1x = Convert.ToInt32(x) + 400;
                p1y = Convert.ToInt32(Math.Cos(x * Math.PI / 180)*-40) + 200;
                p2x = Convert.ToInt32(x + 1) + 400;
                p2y = Convert.ToInt32(Math.Cos((x + 1) * Math.PI / 180)*-40) + 200;
                DrawLineP(p1x, p1y, p2x, p2y, btm);
            }
            pictureBox1.Refresh();
        }
    }
}
