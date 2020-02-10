using System;
using System.Windows.Forms;

namespace 我的Miku.常用
{
    public partial class 备忘录 : 模板
    {
        public 备忘录()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isDel = true;
            try
            {
                listBox1.Items.Insert(0, "新建备忘录");
                listBox1.SelectedIndex = 0;
                textBox1.Visible = true;
                textBox1.Text = "";
            }
            catch (Exception)
            {

            }
            isDel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = listBox1.SelectedIndex;
            listBox1.Items.Insert(num, textBox1.Text);
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.SelectedIndex = num;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isDel = true;
            for (int i = 0; i < 主窗体.beiwangValue.Items.Count; i++)
            {
                if (主窗体.beiwangValue.Items[i].ToString() == textBox1.Text)
                {

                    try
                    {
                        主窗体.beiwangTime.Items.RemoveAt(i);
                        主窗体.beiwangValue.Items.RemoveAt(i);
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            try
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                textBox1.Text = "";
                textBox1.Visible = false;
            }
            catch (Exception)
            {

            }
            isDel = false;
        }

        bool isProing = false;

        private void listBox1_Click(object sender, EventArgs e)
        {
            isProing = true;
            checkBox1.Checked = false;
            textBox1.Visible = true;
            textBox1.Text = listBox1.Text;
            for (int i = 0; i < 主窗体.beiwangValue.Items.Count; i++)
            {
                if (主窗体.beiwangValue.Items[i].ToString() == textBox1.Text)
                {

                    try
                    {
                        checkBox1.Checked = true;
                        dateTimePicker1.Value = DateTime.ParseExact(主窗体.beiwangTime.Items[i].ToString(), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch (Exception)
                    {

                    }

                }

            }
            isProing = false;
        }


        bool isDel = false;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isDel)
            {

                try
                {
                    int num = listBox1.SelectedIndex;
                    listBox1.Items.Insert(num, textBox1.Text);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    listBox1.SelectedIndex = num;
                }
                catch (Exception)
                {
                    listBox1.Items.Insert(0, textBox1.Text);
                    listBox1.SelectedIndex = 0;
                }


            }

        }



        private void button4_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception)
            {
                MessageBox.Show("首先要选定备忘录哦~");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isProing)
            {
                if (checkBox1.Checked == true)
                {
                    if (listBox1.SelectedItem == null)
                    {
                        MessageBox.Show("首先要选定备忘录哦~");
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        if (textBox1.Text != "")
                        {
                            dateTimePicker1.Enabled = true;
                            button3.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("似乎少了点什么……");
                            checkBox1.Checked = false;
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < 主窗体.beiwangValue.Items.Count; i++)
                    {
                        if (主窗体.beiwangValue.Items[i].ToString() == textBox1.Text)
                        {

                            try
                            {
                                主窗体.beiwangTime.Items.RemoveAt(i);
                                主窗体.beiwangValue.Items.RemoveAt(i);
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            checkBox1.Checked = false;
                        }
                    }

                    dateTimePicker1.Enabled = false;
                    button3.Enabled = false;
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    主窗体.beiwangTime.Items.Add(dateTimePicker1.Value.GetDateTimeFormats('g')[0].ToString());
                    主窗体.beiwangValue.Items.Add(textBox1.Text);
                }
                else
                {
                    for (int i = 0; i < 主窗体.beiwangValue.Items.Count; i++)
                    {
                        if (textBox1.Text == 主窗体.beiwangValue.Items[i].ToString())
                        {
                            主窗体.beiwangValue.Items.RemoveAt(i);
                        }

                    }

                }
                MessageBox.Show("设置成功");
            }
            catch (Exception)
            {

                MessageBox.Show("未知错误");
            }

        }
        //数据

        IniFiles ini = new IniFiles(Environment.ExpandEnvironmentVariables("%AppData%\\mikuconfig.ini"));

        private void 备忘录_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.IniWriteValue("beiwang", "listNum", Convert.ToString(listBox1.Items.Count));
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                ini.IniWriteValue("beiwang", "list" + Convert.ToString(i), listBox1.Items[i].ToString());
            }
        }

        private void 备忘录_Load(object sender, EventArgs e)
        {
            isDel = true;
            try
            {
                if (ini.ExistINIFile())
                {
                    int listNum = Convert.ToInt32(ini.IniReadValue("beiwang", "listNum"));
                    for (int i = 0; i < listNum; i++)
                    {
                        listBox1.Items.Add(ini.IniReadValue("beiwang", "list" + Convert.ToString(i)));
                    }
                }
            }
            catch (Exception)
            {
            }
            isDel = false;
        }
    }
}
