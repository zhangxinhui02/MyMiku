using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace 我的Miku.常用
{
    public partial class 音乐 : 模板
    {
        public 音乐()
        {
            InitializeComponent();

            //建立播放列表，名字为MikuList
            axWindowsMediaPlayer1.currentPlaylist = axWindowsMediaPlayer1.newPlaylist("MikuList", "");
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        bool isPlaying = false;
        byte playMode = 1;  //1.循环     2.单曲    3.随机
        bool isListOpen = false;



        private void button1_Click(object sender, EventArgs e)
        {
            new 在线音乐().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        IniFiles ini = new IniFiles(Environment.ExpandEnvironmentVariables("%AppData%\\mikuconfig.ini"));

        private void test_Load(object sender, EventArgs e)
        {
            try
            {
                if (ini.ExistINIFile())
                {
                    int listNum = Convert.ToInt32(ini.IniReadValue("music", "listNum"));
                    for (int i = 0; i < listNum; i++)
                    {
                        listBox1.Items.Add(ini.IniReadValue("music", "list" + Convert.ToString(i)));
                        axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(ini.IniReadValue("music", "list" + Convert.ToString(i))));
                    }
                }
            }
            catch (Exception)
            {

            }

        }
        



        

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            axWindowsMediaPlayer1.currentPlaylist.clear();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(listBox1.Items[i].ToString()));
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPlaying == false)
                {
                    if (listBox1.Items.Count != 0)
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    else MessageBox.Show("还没有向播放列表添加音乐哦，点击下面文件夹图标打开播放列表~");
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                }
            }
            catch (Exception)
            {

            }

        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState.ToString() == "wmppsStopped" || axWindowsMediaPlayer1.playState.ToString() == "wmppsPaused" || axWindowsMediaPlayer1.playState.ToString() == "wmppsMediaEnded")//停止 暂停 完成
            {
                isPlaying = false;
                pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\play.png");
                pictureBox8.Enabled = false;
            }
            if (axWindowsMediaPlayer1.playState.ToString() == "wmppsPlaying")
            {
                isPlaying = true;
                pictureBox9.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\zanting.png");
                pictureBox8.Enabled = true;
                label4.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");
                label5.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("Author");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.previous();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.next();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            switch (playMode)
            {
                case 1://循环
                    playMode = 2;
                    pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\danqu.png");
                    timer1.Enabled = true;
                    break;
                case 2://单曲
                    playMode = 3;
                    pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\suiji.png");
                    axWindowsMediaPlayer1.settings.setMode("shuffle", true);
                    timer1.Enabled = false;
                    break;
                case 3://随机
                    playMode = 1;
                    pictureBox6.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\xunhuan.png");
                    axWindowsMediaPlayer1.settings.setMode("loop", true);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (axWindowsMediaPlayer1.currentMedia.duration - axWindowsMediaPlayer1.Ctlcontrols.currentPosition <= 1.0)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0;
                }
            }
            catch (Exception)
            {

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPlaying == false)
                {
                    if (listBox1.Items.Count != 0)
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.play();

                    }
                    else MessageBox.Show("还没有向播放列表添加音乐哦，点击下面文件夹图标打开播放列表~");
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                }
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (isListOpen == false)
            {
                Width = 760;
                Height = 411;
                isListOpen = true;
            }
            else
            {
                Width = 321;
                Height = 411;
                isListOpen = false;
            }
            Draw();
        }


        



        private void 音乐_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            ini.IniWriteValue("music", "listNum", Convert.ToString(listBox1.Items.Count));
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                ini.IniWriteValue("music", "list" + Convert.ToString(i), listBox1.Items[i].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FindForm().Width = 321;
            FindForm().Height = 411;
            isListOpen = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(s);
                    axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(s));
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.currentPlaylist.clear();
            listBox1.Items.Clear();
        }
    }
}
