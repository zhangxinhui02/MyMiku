using System;
using System.Windows.Forms;

namespace 我的Miku.常用
{
    public partial class 管理最近文件 : 模板
    {
        public 管理最近文件()
        {
            InitializeComponent();
        }

        public static ListBox l1 = new ListBox();
        public static ListBox l1path = new ListBox();
        public static ListBox l2 = new ListBox();


        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            listBox2.Items.Add(path);
            l2.Items.Add(path);
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                      //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(listBox2.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("找不到文件啦~\r\n文件路径发生了改变");
            }

        }

        IniFiles ini = new IniFiles(Environment.ExpandEnvironmentVariables("%AppData%\\mikuconfig.ini"));


        private void 管理最近文件_Load(object sender, EventArgs e)
        {
            try
            {
                l1.Items.Clear();
                l2.Items.Clear();
                l1path.Items.Clear();
                if (ini.ExistINIFile())
                {
                    int list1Num = Convert.ToInt32(ini.IniReadValue("files", "list1Num"));
                    //l1.Items.Clear();
                    for (int i = 0; i < list1Num; i++)
                    {
                        l1.Items.Add(ini.IniReadValue("files", "list1" + Convert.ToString(i)));
                    }
                }
                if (ini.ExistINIFile())
                {
                    int list2Num = Convert.ToInt32(ini.IniReadValue("files", "list2Num"));
                    //l2.Items.Clear();
                    for (int i = 0; i < list2Num; i++)
                    {
                        l2.Items.Add(ini.IniReadValue("files", "list2" + Convert.ToString(i)));
                    }
                }
                if (ini.ExistINIFile())
                {
                    int listpathNum = Convert.ToInt32(ini.IniReadValue("files", "listpathNum"));
                    //l1path.Items.Clear();
                    for (int i = 0; i < listpathNum; i++)
                    {
                        l1path.Items.Add(ini.IniReadValue("files", "listpath" + Convert.ToString(i)));
                    }
                }
            }
            catch (Exception)
            {
                
            }
            

            listBox1.Items.AddRange(l1.Items);
            listBox2.Items.AddRange(l2.Items);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int num = listBox2.Items.IndexOf(listBox2.SelectedItem);
                l2.Items.RemoveAt(num);
                listBox2.Items.RemoveAt(num);
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = listBox1.Items.IndexOf(listBox1.SelectedItem);
                l1.Items.RemoveAt(num);
                listBox1.Items.RemoveAt(num);

            }
            catch (Exception)
            {

            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int num = listBox1.Items.IndexOf(listBox1.SelectedItem);

                System.Diagnostics.Process.Start(l1path.Items[num].ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("找不到文件啦~\r\n文件路径发生了改变");
            }
        }

        private void 管理最近文件_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.IniWriteValue("files", "list1Num", Convert.ToString(l1.Items.Count));
            for (int i = 0; i < l1.Items.Count; i++)
            {
                ini.IniWriteValue("files", "list1" + Convert.ToString(i), l1.Items[i].ToString());
            }
            ini.IniWriteValue("files", "list2Num", Convert.ToString(l2.Items.Count));
            for (int i = 0; i < l2.Items.Count; i++)
            {
                ini.IniWriteValue("files", "list2" + Convert.ToString(i), l2.Items[i].ToString());
            }
            ini.IniWriteValue("files", "listpathNum", Convert.ToString(l1path.Items.Count));
            for (int i = 0; i < l1path.Items.Count; i++)
            {
                ini.IniWriteValue("files", "listpath" + Convert.ToString(i), l1path.Items[i].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            l1.Items.Clear();
            l1path.Items.Clear();
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            l2.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
