using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace 我的Miku.设置
{
    public partial class 设置 : 模板
    {
        public 设置()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "初始化.bat");
            }
            catch (Exception)
            {

                MessageBox.Show("安装文件损坏，请考虑重新安装Miku");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                主窗体.isBizhi = "1";
            }
            else
            {
                主窗体.isBizhi = "0";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mikumikumi.xyz:520/MyMiku.exe");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("要卸载Miku了吗？\r\n(｡•́︿•̀｡)\r\n愿有缘再会\r\n记得卸载前关闭Miku");
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "unins000.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重新安装Miku");
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!isProing)
            {
                try
                {
                    if (checkBox2.Checked)
                    {
                        string path = Application.ExecutablePath;
                        RegistryKey rk = Registry.LocalMachine;
                        RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                        rk2.SetValue("我的Miku", path);
                        rk2.Close();
                        rk.Close();
                    }
                    else
                    {
                        string path = Application.ExecutablePath;
                        RegistryKey rk = Registry.LocalMachine;
                        RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                        rk2.DeleteValue("我的Miku", false);
                        rk2.Close();
                        rk.Close();
                    }
                }
                catch (Exception)
                {
                    isProing = true;
                    MessageBox.Show("发生错误。以管理员身份运行Miku可能会有所帮助。");
                    if (checkBox2.Checked == true)
                    {
                        checkBox2.Checked = false;
                    }
                    else
                    {
                        checkBox2.Checked = true;
                    }
                    isProing = false;
                }
            }
        }

        IniFiles ini = new IniFiles(Environment.ExpandEnvironmentVariables("%AppData%\\mikuconfig.ini"));
        bool isProing = false;
        private void 设置_Load(object sender, EventArgs e)
        {
            isProing = true;
            if (ini.ExistINIFile())
            {
                if (ini.IniReadValue("main", "isBizhi") == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

                if (ini.IniReadValue("settings", "ziqi") == "1")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }

                if (ini.IniReadValue("main", "isEYE") == "1")
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }

                //area = ini.IniReadValue("main", "area");
                textBox1.Text = ini.IniReadValue("main", "area");
            }
            isProing = false;
        }

        private void 设置_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ini.IniWriteValue("main", "isBizhi", "1");
            }
            else
            {
                ini.IniWriteValue("main", "isBizhi", "0");
            }

            if (checkBox2.Checked == true)
            {
                ini.IniWriteValue("settings", "ziqi", "1");
            }
            else
            {
                ini.IniWriteValue("settings", "ziqi", "0");
            }

            if (checkBox3.Checked == true)
            {
                ini.IniWriteValue("main", "isEYE", "1");
            }
            else
            {
                ini.IniWriteValue("main", "isEYE", "0");
            }

            主窗体.area = textBox1.Text;
            ini.IniWriteValue("main", "area", textBox1.Text);


            MessageBox.Show("设置项保存成功");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                主窗体.isEYE = true;
            }
            else
            {
                主窗体.isEYE = false;
            }
        }

        //string area = "银川";
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    area = textBox1.Text;
        //}
    }
}
