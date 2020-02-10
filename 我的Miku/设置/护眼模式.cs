using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 我的Miku.设置
{
    public partial class 护眼模式 : Form
    {
        #region 禁用Alt+F4和Alt+Tab
        protected override CreateParams CreateParams

        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                cp.ExStyle |= WS_EX_TOOLWINDOW;
                return cp;
            }

        }

        #endregion

        /*
             * 下面这段代码主要用来调用Windows API实现窗体透明(鼠标可以穿透窗体)
             */
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(IntPtr Handle, int crKey, byte bAlpha, int dwFlags);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;
        const int LWA_ALPHA = 2;


        public 护眼模式()
        {
            InitializeComponent();
            FindForm().Visible = false;
        }


        public static bool isOpened = false;

        

        private void MaskForm_Load(object sender, EventArgs e)
        {
            // 取消窗体任务栏
            ShowInTaskbar = false;
            // 窗体位于Windows最顶部
            this.TopMost = true;
            // 去除窗体边框
            this.FormBorderStyle = FormBorderStyle.None;//5+1+a+s+p+x
                                                        // 设置窗体最大化大小(除底部任务栏部分)
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            // 设置Windows窗口状态为最大化模式
            this.WindowState = FormWindowState.Maximized;
            // 设置Windows属性
            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);
            SetLayeredWindowAttributes(this.Handle, 0, 100, LWA_ALPHA);

            //this.BackColor = Color.Black;
        }

        public void SetOpacity(byte opacity)
        {
            SetLayeredWindowAttributes(this.Handle, 0, opacity, LWA_ALPHA);
        }
    }
}
