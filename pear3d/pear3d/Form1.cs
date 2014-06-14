using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pear3d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(800, 800);
            Graphics grp = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            double[] x = new double[4];
            double[] y = new double[4];
            double[] z = new double[4];
            double[] x1 = new double[4];
            double[] y1 = new double[4];
            double[] z1 = new double[4];
            double r, b, l, db, dl, aa, ab;
            aa = Math.PI / 4;
            ab = Math.PI / 3;
            r = 100;
            db = 0.27;
            dl = 0.31415926535897932384626433832795;
            b = -Math.PI / 2;
            while (b < Math.PI / 2)
            {
                l = 0;
                while (l < Math.PI * 2)
                {
                    x[0] = r * Math.Cos(b) * Math.Sin(l);
                    y[0] = r * Math.Cos(b) * Math.Cos(l);
                    z[0] = r * Math.Sin(b);
                    x[1] = r * Math.Cos(b + db) * Math.Sin(l);
                    y[1] = r * Math.Cos(b + db) * Math.Cos(l);
                    z[1] = r * Math.Sin(b + db);
                    x[2] = r * Math.Cos(b + db) * Math.Sin(l + dl);
                    y[2] = r * Math.Cos(b + db) * Math.Cos(l + dl);
                    z[2] = r * Math.Sin(b + db);
                    x[3] = r * Math.Cos(b) * Math.Sin(l + dl);
                    y[3] = r * Math.Cos(b) * Math.Cos(l + dl);
                    z[3] = r * Math.Sin(b);
                    if (z[0] > r / 2)
                    {
                        z[0] = z[0] + 2.5 * r * Math.Pow(z[0] / r - 0.5, 2);
                    }
                    if (z[1] > r / 2)
                    {
                        z[1] = z[1] + 2.5 * r * Math.Pow(z[1] / r - 0.5, 2);
                    }
                    if (z[2] > r / 2)
                    {
                        z[2] = z[2] + 2.5 * r * Math.Pow(z[2] / r - 0.5, 2);
                    }
                    if (z[3] > r / 2)
                    {
                        z[3] = z[3] + 2.5 * r * Math.Pow(z[3] / r - 0.5, 2);
                    }
                    x1[0] = x[0] * Math.Cos(aa) - y[0] * Math.Sin(aa);
                    y1[0] = x[0] * Math.Sin(aa) * Math.Cos(ab) + y[0] * Math.Cos(aa) * Math.Cos(ab) - z[0] * Math.Sin(ab);
                    z1[0] = x[0] * Math.Sin(aa) * Math.Sin(ab) + y[0] * Math.Cos(aa) * Math.Sin(ab) + z[0] * Math.Cos(ab);
                    x1[1] = x[1] * Math.Cos(aa) - y[1] * Math.Sin(aa);
                    y1[1] = x[1] * Math.Sin(aa) * Math.Cos(ab) + y[1] * Math.Cos(aa) * Math.Cos(ab) - z[1] * Math.Sin(ab);
                    z1[1] = x[1] * Math.Sin(aa) * Math.Sin(ab) + y[1] * Math.Cos(aa) * Math.Sin(ab) + z[1] * Math.Cos(ab);
                    x1[2] = x[2] * Math.Cos(aa) - y[2] * Math.Sin(aa);
                    y1[2] = x[2] * Math.Sin(aa) * Math.Cos(ab) + y[2] * Math.Cos(aa) * Math.Cos(ab) - z[2] * Math.Sin(ab);
                    z1[2] = x[2] * Math.Sin(aa) * Math.Sin(ab) + y[2] * Math.Cos(aa) * Math.Sin(ab) + z[2] * Math.Cos(ab);
                    x1[3] = x[3] * Math.Cos(aa) - y[3] * Math.Sin(aa);
                    y1[3] = x[3] * Math.Sin(aa) * Math.Cos(ab) + y[3] * Math.Cos(aa) * Math.Cos(ab) - z[3] * Math.Sin(ab);
                    z1[3] = x[3] * Math.Sin(aa) * Math.Sin(ab) + y[3] * Math.Cos(aa) * Math.Sin(ab) + z[3] * Math.Cos(ab);
                    if ((z1[0] > 0) && (z1[1] > 0) && (z1[2] > 0) && (z1[3] > 0))
                    {
                        grp.DrawLine(new Pen(Color.Red, 1), Convert.ToInt32(x1[0]) + 400, Convert.ToInt32(y1[0]) + 400, Convert.ToInt32(x1[1]) + 400, Convert.ToInt32(y1[1]) + 400);
                        grp.DrawLine(new Pen(Color.Red, 1), Convert.ToInt32(x1[1]) + 400, Convert.ToInt32(y1[1]) + 400, Convert.ToInt32(x1[2]) + 400, Convert.ToInt32(y1[2]) + 400);
                        grp.DrawLine(new Pen(Color.Red, 1), Convert.ToInt32(x1[2]) + 400, Convert.ToInt32(y1[2]) + 400, Convert.ToInt32(x1[3]) + 400, Convert.ToInt32(y1[3]) + 400);
                        grp.DrawLine(new Pen(Color.Red, 1), Convert.ToInt32(x1[3]) + 400, Convert.ToInt32(y1[3]) + 400, Convert.ToInt32(x1[0]) + 400, Convert.ToInt32(y1[0]) + 400);
                    }
                    l += dl;
                }
                b += db;
            }
            pictureBox1.Refresh();
        }
    }
}
