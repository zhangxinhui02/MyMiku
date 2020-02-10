using System;
using System.Windows.Forms;

namespace 我的Miku.工具
{
    public partial class 添加定时任务 : 模板
    {

        byte taskNum = 定时任务.taskNum;

       
        public 添加定时任务()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            FindForm().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                定时任务sender.give(任务名.Text, 60000 * long.Parse(时间.Text), 任务值.Text, name.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("输入的值不正确哦~");
            }
            
        }
    }
}