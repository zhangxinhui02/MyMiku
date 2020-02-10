using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 我的Miku.常用
{
    public partial class 在线音乐 : 模板
    {
        public 在线音乐()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                webBrowser1.Visible = true;
                string url = "https://music.liuzhijin.cn/?name=" + textBox1.Text + @"&type=netease";
                label2.Text = "请稍候，正在打开：" + url;
                webBrowser1.Navigate(url);
            }
            else
            {
                MessageBox.Show("似乎少了点什么……");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Visible == true)
                webBrowser1.Visible = false;
            else webBrowser1.Visible = true;


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                if (textBox1.Text != "")
                {
                    webBrowser1.Visible = true;
                    string url = "https://music.liuzhijin.cn/?name=" + textBox1.Text + @"&type=netease";
                    label2.Text = "请稍候，正在打开：" + url;
                    webBrowser1.Navigate(url);
                }
                else
                {
                    MessageBox.Show("似乎少了点什么……");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = null;
            webBrowser1.Visible = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label2.Text = "正在定位上下文……";
            webBrowser1.Document.Window.ScrollTo(0, 586);
            label2.Text = "就绪";
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\maxd.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"Resources\max.png");
        }
        bool isMax = false;
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
