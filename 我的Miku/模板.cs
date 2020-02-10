using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 我的Miku
{
    public partial class 模板 : Form
    {
        public 模板()
        {
            InitializeComponent();
            pictureBox1.Anchor = AnchorStyles.Right;
            pictureBox2.Anchor = AnchorStyles.Right;
            pictureBox3.Anchor = AnchorStyles.Right;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;


        public void Draw()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Point p1 = new Point(0, 0);
            Point p2 = new Point(Width, 0);
            Point p3 = new Point(Width, 30);
            Point p4 = new Point(0, 50);

            Point p5 = new Point(0, Height);
            Point p6 = new Point(Width, Height - 50);
            Point p7 = new Point(Width, Height);

            Point p8 = new Point(0, 0);
            Point p9 = new Point(Width - 1, 0);
            Point p10 = new Point(Width - 1, Height - 1);
            Point p11 = new Point(0, Height - 1);

            PointF[] points1 = { p1, p2, p3, p4 };
            PointF[] points2 = { p5, p6, p7 };
            PointF[] points3 = { p8, p9, p10, p11 };

            Pen p = new Pen(Color.FromArgb(147, 214, 214), 1);
            Brush b = new SolidBrush(Color.FromArgb(147, 214, 214));

            g.FillPolygon(b, points1);
            g.FillPolygon(b, points2);
            g.DrawPolygon(p, points3);
            BackgroundImage = bmp;

        }

        private void F_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void F_TextChanged(object sender, EventArgs e)
        {
            label1.Text = Text;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\closed.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\close.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\mind.png");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\min.png");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void 模板_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void 模板_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
