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
            double x, y, z, r, b, l, db, dl, aa, ab, x1, y1, z1, x1p, y1p;
            aa = Math.PI;
            ab = Math.PI / 3;
            r = 100;
            db = 0.27;
            dl = 0.31415926535897932384626433832795;
            b = -Math.PI / 2;
            while (b < Math.PI / 2)
            {
                l = 0;
                x = r * Math.Cos(b) * Math.Sin(l);
                y = r * Math.Cos(b) * Math.Cos(l);
                z = r * Math.Sin(b);
                x1p = x * Math.Cos(aa) - y * Math.Sin(aa);
                y1p = x * Math.Sin(aa) * Math.Cos(ab) + y * Math.Cos(aa) * Math.Cos(ab) - z * Math.Sin(ab);
                while (l < Math.PI * 2 + dl)
                {
                    x = r * Math.Cos(b) * Math.Sin(l);
                    y = r * Math.Cos(b) * Math.Cos(l);
                    z = r * Math.Sin(b);
                    x1 = x * Math.Cos(aa) - y * Math.Sin(aa);
                    y1 = x * Math.Sin(aa) * Math.Cos(ab) + y * Math.Cos(aa) * Math.Cos(ab) - z * Math.Sin(ab);
                    z1 = x * Math.Sin(aa) * Math.Sin(ab) + y * Math.Cos(aa) * Math.Sin(ab) + z * Math.Cos(ab);
                    if ((z1 > 0))
                    {
                        grp.DrawLine(new Pen(Color.Red, 1), Convert.ToInt32(x1p) + 400, Convert.ToInt32(y1p) + 400, Convert.ToInt32(x1) + 400, Convert.ToInt32(y1) + 400);
                    }
                    x1p = x1;
                    y1p = y1;
                    l += dl;
                }
                b += db;
            }
            l = 0;
            while (l < Math.PI * 2)
            {
                b = -Math.PI / 2;
                x = r * Math.Cos(b) * Math.Sin(l);
                y = r * Math.Cos(b) * Math.Cos(l);
                z = r * Math.Sin(b);
                x1p = x * Math.Cos(aa) - y * Math.Sin(aa);
                y1p = x * Math.Sin(aa) * Math.Cos(ab) + y * Math.Cos(aa) * Math.Cos(ab) - z * Math.Sin(ab);
                while (b < Math.PI / 2 + db)
                {
                    x = r * Math.Cos(b) * Math.Sin(l);
                    y = r * Math.Cos(b) * Math.Cos(l);
                    z = r * Math.Sin(b);
                    x1 = x * Math.Cos(aa) - y * Math.Sin(aa);
                    y1 = x * Math.Sin(aa) * Math.Cos(ab) + y * Math.Cos(aa) * Math.Cos(ab) - z * Math.Sin(ab);
                    z1 = x * Math.Sin(aa) * Math.Sin(ab) + y * Math.Cos(aa) * Math.Sin(ab) + z * Math.Cos(ab);
                    if ((z1 > 0))
                    {
                        grp.DrawLine(new Pen(Color.Blue, 1), Convert.ToInt32(x1p) + 400, Convert.ToInt32(y1p) + 400, Convert.ToInt32(x1) + 400, Convert.ToInt32(y1) + 400);
                    }
                    x1p = x1;
                    y1p = y1;
                    b += db;
                }
                l += dl;
            }
            pictureBox1.Refresh();
        }
    }
}
