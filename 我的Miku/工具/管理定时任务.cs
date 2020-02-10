using System;
using System.Windows.Forms;

namespace 我的Miku.工具
{
    public partial class 管理定时任务 : 模板
    {
        public 管理定时任务()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            添加定时任务 添加 = new 添加定时任务();
            添加.Show();
        }

        private void 管理定时任务_Activated(object sender, EventArgs e)
        {
            byte num = 0;

            listView.Items.Clear();

            if (定时任务sender.task1 != null)
            {

                string name = 定时任务sender.task1.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task1.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task1.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task1.Command);
                num++;
            }



            if (定时任务sender.task2 != null)
            {
                string name = 定时任务sender.task2.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task2.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task2.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task2.Command);
                num++;
            }


            if (定时任务sender.task3 != null)
            {
                string name = 定时任务sender.task3.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task3.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task3.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task3.Command);
                num++;
            }


            if (定时任务sender.task4 != null)
            {
                string name = 定时任务sender.task4.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task4.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task4.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task4.Command);
                num++;
            }


            if (定时任务sender.task5 != null)
            {
                string name = 定时任务sender.task5.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task5.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task5.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task5.Command);
                num++;
            }


            if (定时任务sender.task6 != null)
            {
                string name = 定时任务sender.task6.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task6.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task6.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task6.Command);
                num++;
            }


            if (定时任务sender.task7 != null)
            {
                string name = 定时任务sender.task7.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task7.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task7.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task7.Command);
                num++;
            }


            if (定时任务sender.task8 != null)
            {
                string name = 定时任务sender.task8.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task8.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task8.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task8.Command);
                num++;
            }


            if (定时任务sender.task9 != null)
            {
                string name = 定时任务sender.task9.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task9.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task9.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task9.Command);
                num++;
            }


            if (定时任务sender.task10 != null)
            {
                string name = 定时任务sender.task10.Name;
                listView.Items.Add(name);
                listView.Items[num].SubItems.Add(Convert.ToString(定时任务sender.task10.sendInterval() / 60000) + "分钟");
                listView.Items[num].SubItems.Add(定时任务sender.task10.Task);
                listView.Items[num].SubItems.Add(定时任务sender.task10.Command);
                num++;
            }
        }




        //删除任务
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0) return;
            else
            {
                int i = listView.SelectedItems[0].Index;
                try
                {
                    if (定时任务sender.task1.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task1.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task1.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task1.Command = "";
                        定时任务sender.kill(1);
                    }
                }
                catch { }

                try
                {
                    if (定时任务sender.task2.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task2.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task2.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task2.Command = "";
                        定时任务sender.kill(2);
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (定时任务sender.task3.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task3.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task3.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task3.Command = "";
                        定时任务sender.kill(3);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (定时任务sender.task4.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task4.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task4.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task4.Command = "";
                        定时任务sender.kill(4);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (定时任务sender.task5.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task5.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task5.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task5.Command = "";
                        定时任务sender.kill(5);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (定时任务sender.task6.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task6.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task6.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task6.Command = "";
                        定时任务sender.kill(6);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (定时任务sender.task7.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task7.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task7.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task7.Command = "";
                        定时任务sender.kill(7);
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (定时任务sender.task8.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task8.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task8.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task8.Command = "";
                        定时任务sender.kill(8);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (定时任务sender.task9.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task9.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task9.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task9.Command = "";
                        定时任务sender.kill(9);
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (定时任务sender.task10.Command == listView.SelectedItems[0].SubItems[3].Text && Convert.ToString(定时任务sender.task10.sendInterval() / 60000) + "分钟" == listView.SelectedItems[0].SubItems[1].Text && 定时任务sender.task10.Name == listView.SelectedItems[0].Text)
                    {
                        定时任务sender.task10.Command = "";
                        定时任务sender.kill(10);
                    }
                }
                catch (Exception)
                {

                }


                listView.Items.RemoveAt(i);
            }

            GC.Collect();
        }


    }
}
