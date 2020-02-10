using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace 我的Miku.工具
{
    public partial class 优化清理 : 模板
    {
        public 优化清理()
        {
            InitializeComponent();
        }

        public void cmd(string Command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";         //确定程序名
            p.StartInfo.Arguments = "/c " + Command;   //确定程式命令行
            p.StartInfo.UseShellExecute = false;      //Shell的使用
            p.StartInfo.RedirectStandardInput = true;  //重定向输入
            p.StartInfo.RedirectStandardOutput = false; //重定向输出
            p.StartInfo.RedirectStandardError = true;  //重定向输出错误
            p.StartInfo.CreateNoWindow = false;        //设置置不显示示窗口
            p.Start();
        }





        //垃圾清理
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\垃圾清理.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\磁盘整理.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\手动清理.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\自动清理.bat");
                MessageBox.Show("Miku会在每天中午12:00准时清理垃圾~");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\取消自动清理.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\简易杀毒.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\清除启动项.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\服务优化.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\操作端口.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("RunDLL32.exe", "shell32.dll,Control_RunDLL appwiz.cpl");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\修复网络.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Clean\\停用更新.bat");
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重装Miku。");
            }

        }
    }
}
