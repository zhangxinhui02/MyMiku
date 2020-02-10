using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace 我的Miku.工具
{
    public partial class 快速搜索 : 模板
    {
        public 快速搜索()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://st.so.com/");
            System.Diagnostics.Process.Start("http://image.baidu.com/?fr=shitu");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://search.chongbuluo.com/");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                string[] files1 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "*" + textBox1.Text + "*");
                string[] files2 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "*" + textBox1.Text + "*");
                string[] files3 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Recent), "*" + textBox1.Text + "*");
                string[] files4 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "*" + textBox1.Text + "*");
                listBox1.Items.AddRange(files1);
                listBox1.Items.AddRange(files2);
                listBox1.Items.AddRange(files3);
                listBox1.Items.AddRange(files4);
            }
            catch (Exception)
            {

                
            }
            

            if (textBox1.Text != "")
            {
                webBrowser1.Visible = true;
                pictureBox5.Visible = false;
                string s = textBox1.Text;
                webBrowser1.Navigate("https://www.sogou.com/web?query=" + s);
            }
            else
            {
                webBrowser1.Visible = false;
                pictureBox5.Visible = true;
                webBrowser1.Navigate("");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "https://cn.bing.com/search?q=" + textBox1.Text;
            System.Diagnostics.Process.Start(s);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(listBox1.SelectedItem.ToString());
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
            if (isMax)
            {
                WindowState = FormWindowState.Normal;
                isMax = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                isMax = true;
            }
        }
    }
}
