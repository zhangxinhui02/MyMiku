using System;
using System.Windows.Forms;
using 我的Miku.工具;
using 我的Miku.设置;
using 我的Miku.常用;
using System.Runtime.InteropServices;  //调用WINDOWS API函数时要用到
using Microsoft.Win32;  //写入注册表时要用到
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace 我的Miku
{
    public partial class 主窗体 : Form
    {
        public 主窗体()
        {
            InitializeComponent();
            fileSystemWatcher1.Path = Environment.GetFolderPath(Environment.SpecialFolder.Recent);

        }

        #region 拖动窗体 点击对话

        //此处卖萌。。。
        public static string[] mikutalk =//36
        {
            "魔法未来！","O(∩_∩)O~","wowaka☆\n2019.4.5","喵喵喵~","啊呜","ki☆ra"," ( っ*'ω'*c)","世界第一公主殿下！","雪Miku很漂亮的说~","下一场演唱会在什么时候呢","(程序作者真帅 别打我)","(固原一中很棒的)","Miku赛高","Hatsune Miku!","KEI赛高","39 39","Crypton!","镜音铃·连","大哥大姐还好吗","VOCALOID!","Hachi Hachi!","呼~","V4C是中V一大进步","Bilibili (゜-゜)つロ 干杯~","你好","把你mikumiku掉！","SNOW MIKU!","MIKU EXPO 2019!","你一定听过甩葱歌~","骑士团呢","Diva Desu.","听听《初梦》","wowaka，晚安。","Project Diva!","Piapro!","01"
        };

        [System.Runtime.InteropServices.DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        byte mikuMode = 1;//1白天 2晚上 
        Random rd;

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Start_MouseDown(object sender, MouseEventArgs e)
        {
            rd = new Random();

            if (mikuMode == 1)//白天
            {
                try
                {
                    Picture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\baitian.gif");
                }
                catch (Exception)
                {

                }
                clicktime.Enabled = true;
                if (Picture.Visible)
                {
                    sayText.Visible = true;
                    mikuSay(mikutalk[rd.Next() % 36]);
                    mikuStop();
                }

            }
            else
            {
                try
                {
                    Picture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\wanshang.gif");
                }
                catch (Exception)
                {

                }
                if (Picture.Visible)
                {
                    sayText.Visible = true;
                    mikuSay("嗯姆……Miku在睡觉啦");
                    mikuStop();
                }

                wanshang.Enabled = true;
            }



            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

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


        #region 常用
        private void 添加新的备忘录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                备忘录 备忘 = new 备忘录();
                备忘.Show();
            }
            catch (Exception ff)
            {
                MessageBox.Show(ff.ToString());
            }

        }

        //AI聊天 ai;
        private void 聊天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AI聊天 ai = new AI聊天();
                ai.Show();
            }
            catch (Exception ff)
            {

                MessageBox.Show(ff.ToString());
            }


        }

        private void 听音乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                音乐 音乐 = new 音乐();
                音乐.Show();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.ToString());
            }

        }


        public static ListBox beiwangTime = new ListBox();

        public static ListBox beiwangValue = new ListBox();



        private void beiwang_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            for (int i = 0; i < beiwangTime.Items.Count; i++)
            {//2005-11-5 14:06
                if (beiwangTime.Items[i].ToString() == dt.GetDateTimeFormats('g')[0].ToString())
                {

                    try
                    {
                        MessageBox.Show(beiwangValue.Items[i].ToString(), "备忘提示-我的Miku", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
                        beiwangTime.Items.RemoveAt(i);
                        beiwangValue.Items.RemoveAt(i);
                        i--;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void 备忘录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new 备忘录().Show();
            }
            catch (Exception j)
            {
                MessageBox.Show(j.ToString());
            }
        }


        //文件
        private void 主窗体_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            管理最近文件.l2.Items.Add(path);
            ini.IniWriteValue("files", "list2Num", Convert.ToString(管理最近文件.l2.Items.Count));
            for (int i = 0; i < 管理最近文件.l2.Items.Count; i++)
            {
                ini.IniWriteValue("files", "list2" + Convert.ToString(i), 管理最近文件.l2.Items[i].ToString());
            }
            if (Picture.Visible)
            {
                sayText.Visible = true;
                mikuSay("Miku收好文件了");
                mikuStop();
            }

        }

        private void 主窗体_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                      //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        private void 文件_Click(object sender, EventArgs e)
        {
            new 管理最近文件().Show();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            管理最近文件.l1.Items.Add(e.Name);
            管理最近文件.l1path.Items.Add(e.FullPath);

            ini.IniWriteValue("files", "list1Num", Convert.ToString(管理最近文件.l1.Items.Count));
            for (int i = 0; i < 管理最近文件.l1.Items.Count; i++)
            {
                ini.IniWriteValue("files", "list1" + Convert.ToString(i), 管理最近文件.l1.Items[i].ToString());
            }

            ini.IniWriteValue("files", "listpathNum", Convert.ToString(管理最近文件.l1path.Items.Count));
            for (int i = 0; i < 管理最近文件.l1path.Items.Count; i++)
            {
                ini.IniWriteValue("files", "listpath" + Convert.ToString(i), 管理最近文件.l1path.Items[i].ToString());
            }
        }

        private void openFile(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Recent) + @"\" + sender.ToString();
            System.Diagnostics.Process.Start(path);
        }
        #endregion

        #region 工具

        #region 定时任务

        public static string[] taskNum = { "t", "t", "t", "t", "t", "t", "t", "t", "t", "t", "t" };
        public static ToolStripItem[] ToolStripItem = { null, null, null, null, null, null, null, null, null, null, null, };


        private void 右键菜单_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int j = 2; j < 最近使用的文件ToolStripMenuItem.DropDownItems.Count; j++)
            {
                最近使用的文件ToolStripMenuItem.DropDownItems.RemoveAt(2);
            }

            for (int i = 0; i < 管理最近文件.l1.Items.Count; i++)
            {
                ToolStripItem s = 最近使用的文件ToolStripMenuItem.DropDownItems.Add(管理最近文件.l1.Items[i].ToString());
                s.Click += new EventHandler(openFile);
            }


            if (定时任务sender.task1 != null)
            {
                if (taskNum[1] == "t")
                {
                    taskNum[1] = 定时任务sender.task1.Name;
                    ToolStripItem[1] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[1]);
                }
            }
            else if (taskNum[1] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[1]);
                ToolStripItem[1] = null;
                taskNum[1] = "t";
            }



            if (定时任务sender.task2 != null)
            {
                if (taskNum[2] == "t")
                {
                    taskNum[2] = 定时任务sender.task2.Name;
                    ToolStripItem[2] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[2]);
                }
            }
            else if (taskNum[2] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[2]);
                ToolStripItem[2] = null;
                taskNum[2] = "t";
            }

            if (定时任务sender.task3 != null)
            {
                if (taskNum[3] == "t")
                {
                    taskNum[3] = 定时任务sender.task3.Name;
                    ToolStripItem[3] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[3]);
                }
            }
            else if (taskNum[3] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[3]);
                ToolStripItem[3] = null;
                taskNum[3] = "t";
            }

            if (定时任务sender.task4 != null)
            {
                if (taskNum[4] == "t")
                {
                    taskNum[4] = 定时任务sender.task4.Name;
                    ToolStripItem[4] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[4]);
                }
            }
            else if (taskNum[4] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[4]);
                ToolStripItem[4] = null;
                taskNum[4] = "t";
            }

            if (定时任务sender.task5 != null)
            {
                if (taskNum[5] == "t")
                {
                    taskNum[5] = 定时任务sender.task5.Name;
                    ToolStripItem[5] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[5]);
                }
            }
            else if (taskNum[5] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[5]);
                ToolStripItem[5] = null;
                taskNum[5] = "t";
            }

            if (定时任务sender.task6 != null)
            {
                if (taskNum[6] == "t")
                {
                    taskNum[6] = 定时任务sender.task6.Name;
                    ToolStripItem[6] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[6]);
                }
            }
            else if (taskNum[6] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[6]);
                ToolStripItem[6] = null;
                taskNum[6] = "t";
            }

            if (定时任务sender.task7 != null)
            {
                if (taskNum[7] == "t")
                {
                    taskNum[7] = 定时任务sender.task7.Name;
                    ToolStripItem[7] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[7]);
                }
            }
            else if (taskNum[7] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[7]);
                ToolStripItem[7] = null;
                taskNum[7] = "t";
            }

            if (定时任务sender.task8 != null)
            {
                if (taskNum[8] == "t")
                {
                    taskNum[8] = 定时任务sender.task8.Name;
                    ToolStripItem[8] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[8]);
                }
            }
            else if (taskNum[8] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[8]);
                ToolStripItem[8] = null;
                taskNum[8] = "t";
            }

            if (定时任务sender.task9 != null)
            {
                if (taskNum[9] == "t")
                {
                    taskNum[9] = 定时任务sender.task9.Name;
                    ToolStripItem[9] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[9]);
                }
            }
            else if (taskNum[9] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[9]);
                ToolStripItem[9] = null;
                taskNum[9] = "t";
            }

            if (定时任务sender.task10 != null)
            {
                if (taskNum[10] == "t")
                {
                    taskNum[10] = 定时任务sender.task10.Name;
                    ToolStripItem[10] = 定时任务ToolStripMenuItem.DropDownItems.Add(taskNum[10]);
                }
            }
            else if (taskNum[10] != "t")
            {
                定时任务ToolStripMenuItem.DropDownItems.Remove(ToolStripItem[10]);
                ToolStripItem[10] = null;
                taskNum[10] = "t";
            }


        }
        #endregion




        //定时任务
        private void 新建任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            添加定时任务 添加定时任务 = new 添加定时任务();
            添加定时任务.Show();
        }

        //管理任务
        private void 管理任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理定时任务 管理定时任务 = new 管理定时任务();
            管理定时任务.Show();
        }


        //快速加速
        private void 快速加速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            工具.加速.ClearMemory();
            if (Picture.Visible)
            {
                sayText.Visible = true;
                mikuSay("加速成功~");
                mikuStop();
            }
        }

        private void 聚合搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            快速搜索 快速搜素 = new 快速搜索();
            快速搜素.Show();
        }

        private void 管理列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new 管理最近文件().Show();
        }

        private void 加速_Click(object sender, EventArgs e)
        {
            工具.加速.ClearMemory();
            if (Picture.Visible)
            {
                sayText.Visible = true;
                mikuSay("加速成功~");
                mikuStop();
            }
        }



        private void 优化清理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            工具.优化清理 优化 = new 优化清理();
            优化.Show();
        }

        private void 必应BingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bing.com/");
        }

        private void 谷歌GoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.cn/");
        }

        private void 百度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com/");
        }
        #endregion

        #region 设置
        //透明度
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Opacity = 0.75;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
        }

        //退出下面另外写

        //隐藏
        private void 隐藏悬浮窗可在系统托盘恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Picture.Visible = false;
            备忘录.Visible = false;
            文件.Visible = false;
            加速.Visible = false;
        }
        //恢复
        private void 托盘_Click(object sender, EventArgs e)
        {
            Picture.Visible = true;
        }

        //调整大小
        private void 小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm().Width = 275;
            FindForm().Height = 225;
        }

        private void 中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm().Width = 305;
            FindForm().Height = 260;
        }

        private void 大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm().Width = 366;
            FindForm().Height = 332;
        }

        //关于
        private void 关于此程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于窗口 About = new 关于窗口();
            About.Show();
        }


        private void 帮助快速入门ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            帮助 帮助 = new 帮助();
            帮助.Show();
        }

        private void 设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            设置.设置 设置 = new 设置.设置();
            设置.Show();
        }


        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
         int uAction,
         int uParam,
         string lpvParam,
         int fuWinIni
         );

        byte pNum = 1;

        private void 切换壁纸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pPath = AppDomain.CurrentDomain.BaseDirectory + "Pictures\\" + Convert.ToString(pNum) + ".bmp";
                SystemParametersInfo(20, 0, pPath, 0x2);
                RegistryKey myRKey = Registry.CurrentUser;//获取册注表中的基表 
                myRKey = myRKey.OpenSubKey("Control Panel\\Desktop", true);//检索指定的子项 
                myRKey.SetValue("WallPaper", pPath);
                myRKey.SetValue("TitleWallPaper", "2");
                myRKey.Close();//关闭注册表 

                pNum++;
                if (pNum == 11)
                    pNum = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("安装文件损坏，请考虑重新安装Miku");
            }

        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }


        #endregion


        #region 快捷选项
        private void 打开快捷选项(object sender, EventArgs e)
        {
            备忘录.Visible = true;
            文件.Visible = true;
            加速.Visible = true;
        }

        private void 快捷选项计时(object sender, EventArgs e)
        {
            快捷选项关闭.Enabled = true;
        }

        private void 关闭快捷选项(object sender, EventArgs e)
        {

            备忘录.Visible = false;
            文件.Visible = false;
            加速.Visible = false;
            快捷选项关闭.Enabled = false;
        }

        private void 刷新时间(object sender, EventArgs e)
        {
            快捷选项关闭.Interval = 5000;
        }


        #endregion


        #region Miku对话
        public void mikuSay(string say)
        {
            sayPic.Visible = true;
            sayText.Text = say;
        }

        public void mikuStop()
        {
            sayTimer.Enabled = true;
        }

        private void sayTimer_Tick(object sender, EventArgs e)
        {
            sayText.Text = "";
            sayText.Visible = false;
            sayPic.Visible = false;
            sayTimer.Enabled = false;
        }
        #endregion




        #region 杂项

        public static string isBizhi = "0";
        private void bizhi_Tick(object sender, EventArgs e)
        {
            if (isBizhi != "0")
            {
                try
                {
                    string pPath = System.AppDomain.CurrentDomain.BaseDirectory + "Pictures\\" + Convert.ToString(pNum) + ".bmp";
                    SystemParametersInfo(20, 0, pPath, 0x2);
                    RegistryKey myRKey = Registry.CurrentUser;//获取册注表中的基表 
                    myRKey = myRKey.OpenSubKey("Control Panel\\Desktop", true);//检索指定的子项 
                    myRKey.SetValue("WallPaper", pPath);
                    myRKey.SetValue("TitleWallPaper", "2");
                    myRKey.Close();//关闭注册表 

                    pNum++;
                    if (pNum == 11)
                        pNum = 1;
                }
                catch (Exception)
                {
                    MessageBox.Show("安装文件损坏，请考虑重新安装Miku");
                }
            }

        }
        public static bool isEYE = false;
        bool isArea = true;
        public static string area = "银川";
        private void timeWatcher_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime tw = DateTime.Now;
                if (Convert.ToInt32(tw.Hour.ToString()) > 5 && Convert.ToInt32(tw.Hour.ToString()) < 22)
                {
                    if (isEYE)
                    {
                        y.Visible = false;
                    }

                    if (isArea)
                    {
                        AI聊天 ai = new AI聊天();
                        ai.Show();
                        ai.area();
                        isArea = false;
                    }

                    mikuMode = 1;
                    try
                    {
                        Picture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\wait.png");
                    }
                    catch (Exception)
                    {

                    }
                    if (Picture.Visible)
                    {
                        sayText.Visible = true;
                        mikuSay(mikutalk[rd.Next() % 36]);
                        mikuStop();
                    }
                }
                else
                {
                    if (isEYE)
                    {
                        y.Visible = true;
                    }
                    isArea = true;
                    mikuMode = 2;
                    try
                    {
                        Picture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\wanshang.gif");
                    }
                    catch (Exception)
                    {

                    }
                    wanshang.Enabled = true;
                    if (Picture.Visible)
                    {
                        sayText.Visible = true;
                        mikuSay("主人还不睡？注意身体哦");
                        mikuStop();
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void wanshang_Tick(object sender, EventArgs e)
        {
            try
            {
                Picture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\wanshang.png");
            }
            catch (Exception)
            {

            }

            wanshang.Enabled = false;
        }
        #endregion


        #region 数据保存读取

        IniFiles ini = new IniFiles(Environment.ExpandEnvironmentVariables("%AppData%\\mikuconfig.ini"));

        //保存
        private void 主窗体_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.IniWriteValue("main", "touming", Convert.ToString(Opacity));
            ini.IniWriteValue("main", "area", area);
            if (FindForm().Width == 275)
            {
                ini.IniWriteValue("main", "size", "S");
            }
            else if (FindForm().Width == 305)
            {
                ini.IniWriteValue("main", "size", "M");
            }
            else
            {
                ini.IniWriteValue("main", "size", "L");
            }
            ini.IniWriteValue("main", "isFirst", isFirst);
            ini.IniWriteValue("main", "pNum", Convert.ToString(pNum));
            ini.IniWriteValue("main", "isBizhi", isBizhi);
            ini.IniWriteValue("main", "beiwangNum", Convert.ToString(beiwangTime.Items.Count));
            if (isEYE == true)
            {
                ini.IniWriteValue("main", "isEYE", "1");
            }
            else
            {
                ini.IniWriteValue("main", "isEYE", "0");
            }
            for (int i = 0; i < beiwangTime.Items.Count; i++)
            {
                ini.IniWriteValue("main", "Value" + Convert.ToString(i), beiwangValue.Items[i].ToString());
                ini.IniWriteValue("main", "Time" + Convert.ToString(i), beiwangTime.Items[i].ToString());
            }

        }

        //读取
        string isFirst = "1";
        private void 主窗体_Load(object sender, EventArgs e)
        {
            this.Left = 800;
            this.Top = 100;
            clicktime.Enabled = true;


            try
            {

                if (ini.ExistINIFile())
                {
                    Opacity = Convert.ToDouble(ini.IniReadValue("main", "touming"));
                    area = ini.IniReadValue("main", "area");
                    if (ini.IniReadValue("main", "size") == "S")
                    {
                        FindForm().Width = 275;
                        FindForm().Height = 225;
                    }
                    else if (ini.IniReadValue("main", "size") == "L")
                    {
                        FindForm().Width = 366;
                        FindForm().Height = 332;
                    }
                    else
                    {
                        FindForm().Width = 305;
                        FindForm().Height = 260;
                    }
                    isFirst = ini.IniReadValue("main", "isFirst");
                    pNum = Convert.ToByte(ini.IniReadValue("main", "pNum"));
                    isBizhi = ini.IniReadValue("main", "isBizhi");
                    isEYE = (ini.IniReadValue("main", "isEYE") == "1");
                    int beiwangNum = Convert.ToInt32(ini.IniReadValue("main", "beiwangNum"));
                    for (int i = 0; i < beiwangNum; i++)
                    {
                        beiwangTime.Items.Add(ini.IniReadValue("main", "Time" + Convert.ToString(i)));
                        beiwangValue.Items.Add(ini.IniReadValue("main", "Value" + Convert.ToString(i)));
                    }
                }
            }
            catch (Exception)
            {

            }

            if (isFirst == "1")
            {
                new 帮助().Show();
                isFirst = "0";
                ini.IniWriteValue("main", "isFirst", isFirst);
            }
        }



        #endregion

        private void clicktime_Tick(object sender, EventArgs e)
        {
            if (mikuMode == 1)
            {
                try
                {
                    Picture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Images\wait.png");
                }
                catch (Exception)
                {

                }
            }



            clicktime.Enabled = false;
        }

        护眼模式 y = new 护眼模式();


        private void 护眼模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            y.Visible = !y.Visible;
        }

        private void 快速截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("SnippingTool.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 打开命令提示符CMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("cmd.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 录音机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("SoundRecorder.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 放大镜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("magnify.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 屏幕键盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        //引入API函数  
        [DllImport("user32 ")]
        public static extern bool LockWorkStation();//这个是调用windows的系统锁定 
        private void 锁定WindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LockWorkStation();

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 高性能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                runCmd("powercfg -s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");
                MessageBox.Show("设置成功");
            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        public void runCmd(string Command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";         //确定程序名
            p.StartInfo.Arguments = "/c " + Command;   //确定程式命令行
            p.StartInfo.UseShellExecute = false;      //Shell的使用
            p.StartInfo.RedirectStandardInput = true;  //重定向输入
            p.StartInfo.RedirectStandardOutput = true; //重定向输出
            p.StartInfo.RedirectStandardError = true;  //重定向输出错误
            p.StartInfo.CreateNoWindow = true;        //设置置不显示示窗口
            p.Start();
        }

        private void 平衡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                runCmd("powercfg -s 381b4222-f694-41f0-9685-ff5bb260df2e");
                MessageBox.Show("设置成功");
            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void 节能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                runCmd("powercfg -s a1841308-3541-4fab-bc81-f71556f20b4a");
                MessageBox.Show("设置成功");
            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }



        private void 整理桌面文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string wordPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Word文档");
            System.IO.Directory.CreateDirectory(wordPath);
            string excelPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "表格文档");
            System.IO.Directory.CreateDirectory(excelPath);
            string txtPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "文本文档");
            System.IO.Directory.CreateDirectory(txtPath);
            string pptPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "PPT文档");
            System.IO.Directory.CreateDirectory(pptPath);
            string picPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "图片文档");
            System.IO.Directory.CreateDirectory(picPath);
            string musicPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "音乐文档");
            System.IO.Directory.CreateDirectory(musicPath);
            string videoPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "视频文档");
            System.IO.Directory.CreateDirectory(videoPath);
            DirectoryInfo Dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            string move;

            move = "move " + Dir + "\\*.txt " + txtPath;
            runCmd(move);

            move = "move " + Dir + "\\*.doc " + wordPath;
            runCmd(move);
            move = "move " + Dir + "\\*.docx " + wordPath;
            runCmd(move);

            move = "move " + Dir + "\\*.xls " + excelPath;
            runCmd(move);
            move = "move " + Dir + "\\*.xlsx " + excelPath;
            runCmd(move);



            move = "move " + Dir + "\\*.ppt " + pptPath;
            runCmd(move);
            move = "move " + Dir + "\\*.pptx " + pptPath;
            runCmd(move);
            move = "move " + Dir + "\\*.pptm " + pptPath;
            runCmd(move);

            move = "move " + Dir + "\\*.png " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.jpg " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.jpeg " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.jpe " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.bmp " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.gif " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.psd " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.tif " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.tiff " + picPath;
            runCmd(move);
            move = "move " + Dir + "\\*.ico " + picPath;
            runCmd(move);

            move = "move " + Dir + "\\*.mp3 " + musicPath;
            runCmd(move);
            move = "move " + Dir + "\\*.wav " + musicPath;
            runCmd(move);
            move = "move " + Dir + "\\*.m3u " + musicPath;
            runCmd(move);
            move = "move " + Dir + "\\*.mid " + musicPath;
            runCmd(move);
            move = "move " + Dir + "\\*.aac " + musicPath;
            runCmd(move);

            move = "move " + Dir + "\\*.avi " + videoPath;
            runCmd(move);
            move = "move " + Dir + "\\*.mp4 " + videoPath;
            runCmd(move);
            move = "move " + Dir + "\\*.rmvb " + videoPath;
            runCmd(move);
            move = "move " + Dir + "\\*.mkv " + videoPath;
            runCmd(move);
            move = "move " + Dir + "\\*.flv " + videoPath;
            runCmd(move);
            move = "move " + Dir + "\\*.3gp " + videoPath;
            runCmd(move);
            MessageBox.Show("完成");
        }

        private void 任务管理器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("taskmgr.exe");

            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 后台纯净ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("      此部分代码暂时没有编写完成，将于大赛正式开始前完成。在编写期间随时有可能更新程序到http://mikumikumi.xyz:520/MyMiku.exe，敬请关注，更新日志请在http://mikumikumi.xyz:520/mikulog.html查看。");
        }
    }
}
