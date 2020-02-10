using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using System.Threading;

namespace 我的Miku
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(new ThreadStart(Warning)).Start();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 主窗体());

        }
        static void Warning()
        {
            MessageBox.Show("      程序部分代码暂时没有编写完成，将于大赛正式开始前完成。在编写期间随时有可能更新程序到http://mikumikumi.xyz:520/MyMiku.exe，敬请关注，更新日志请在http://mikumikumi.xyz:520/mikulog.html查看。");
        }

    }
}
