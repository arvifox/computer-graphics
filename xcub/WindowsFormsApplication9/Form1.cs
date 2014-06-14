using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawLineBrezenhem(int x1, int y1, int x2, int y2, Bitmap pb)
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

        private double rfrac(double x)
        {
            return 1 - (x - Convert.ToInt32(x));
        }

        private void swap(ref double a, ref double b)
        {
            double tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

        private void plot(Bitmap pb, double x, double y, double c, bool sw)
        {
            Color resclr;
            if (sw)
            {
                resclr = pb.GetPixel(Convert.ToInt32(y), Convert.ToInt32(x));
            }
            else
            {
                resclr = pb.GetPixel(Convert.ToInt32(x), Convert.ToInt32(y));
            }
            Color LineColor = Color.Olive;
            resclr = Color.FromArgb(Convert.ToInt32(resclr.R * (1 - c) + LineColor.R * c),
                Convert.ToInt32(resclr.G * (1 - c) + LineColor.G * c),
                Convert.ToInt32(resclr.B * (1 - c) + LineColor.B * c));
            if (sw)
            {
                pb.SetPixel(Convert.ToInt32(y), Convert.ToInt32(x), resclr);
            }
            else
            {
                pb.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), resclr);
            }
        }

        private void DrawLineVU(Bitmap pb, int ax1, int ay1, int ax2, int ay2)
        {
            double x1, x2, y1, y2, dx, dy, gradient, xend, yend, xgap, xpxl1, ypxl1, xpxl2, ypxl2, intery;
            int x;
            bool swapped;
            x1 = ax1;
            x2 = ax2;
            y1 = ay1;
            y2 = ay2;
            dx = x2 - x1;
            dy = y2 - y1;
            swapped = Math.Abs(dx) < Math.Abs(dy);
            if (swapped)
            {
                swap(ref x1, ref y1);
                swap(ref x2, ref y2);
                swap(ref dx, ref dy);
            }
            if (x2 < x1)
            {
                swap(ref x1, ref x2);
                swap(ref y1, ref y2);
            }
            gradient = dy / dx;
            xend = Math.Round(x1);
            yend = y1 + gradient * (xend - x1);
            xgap = rfrac(x1 + 0.5);
            xpxl1 = xend;
            ypxl1 = Math.Floor(yend);
            plot(pb, xpxl1, ypxl1, rfrac(yend) * xgap, swapped);
            plot(pb, xpxl1, ypxl1 + 1, rfrac(yend) * xgap, swapped);
            intery = yend + gradient;
            xend = Math.Round(x2);
            yend = y2 + gradient * (xend - x2);
            xgap = rfrac(x2 + 0.5);
            xpxl2 = xend;
            ypxl2 = Math.Floor(yend);
            plot(pb, xpxl2, ypxl2, rfrac(yend) * xgap, swapped);
            plot(pb, xpxl2, ypxl2 + 1, rfrac(yend) * xgap, swapped);
            for (x = Convert.ToInt32(xpxl1) + 1; x <= Convert.ToInt32(xpxl2) - 1; x++)
            {
                plot(pb, x, Math.Floor(intery), rfrac(intery), swapped);
                plot(pb, x, Math.Floor(intery) + 1, rfrac(intery), swapped);
                intery += gradient;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(601, 801);
            Graphics grp = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            grp.DrawLine(new Pen(Color.Black, 1), 0, 400, 600, 400);
            grp.DrawLine(new Pen(Color.Black, 1), 300, 0, 300, 800);
            int p1x, p1y, p2x, p2y;
            for (double x = -34; x <= 33; x++)
            {
                p1x = Convert.ToInt32(x) + 300;
                p1y = Convert.ToInt32(Math.Pow(x, 3) / -100) + 400;
                p2x = Convert.ToInt32(x + 1) + 300;
                p2y = Convert.ToInt32(Math.Pow(x + 1, 3) / -100) + 400;
                //DrawLineBrezenhem(p1x, p1y, p2x, p2y, btm);
                DrawLineVU(btm, p1x, p1y, p2x, p2y);
            }
            pictureBox1.Refresh();
        }
    }
}
