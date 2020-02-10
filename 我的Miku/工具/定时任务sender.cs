using System.Windows.Forms;

namespace 我的Miku.工具
{
    public static class 定时任务sender
    {
        

        #region 声明10个引用变量
        public static 定时任务 task1;
        public static 定时任务 task2;
        public static 定时任务 task3;
        public static 定时任务 task4;
        public static 定时任务 task5;
        public static 定时任务 task6;
        public static 定时任务 task7;
        public static 定时任务 task8;
        public static 定时任务 task9;
        public static 定时任务 task10;
        #endregion

        public static void give(string task, long time, string value, string name)
        {
            if (task1==null)
            {
                task1 = new 定时任务();
                task1.newTask(task, time, value, name,1);
                MessageBox.Show("创建成功！");
            }
            else if (task2==null)
            {
                task2 = new 定时任务();
                task2.newTask(task, time, value, name,2);
                MessageBox.Show("创建成功！");
            }
            else if (task3 == null)
            {
                task3 = new 定时任务();
                task3.newTask(task, time, value, name, 3);
                MessageBox.Show("创建成功！");
            }
            else if (task4 == null)
            {
                task4 = new 定时任务();
                task4.newTask(task, time, value, name,4);
                MessageBox.Show("创建成功！");
            }
            else if (task5 == null)
            {
                task5 = new 定时任务();
                task5.newTask(task, time, value, name,5);
                MessageBox.Show("创建成功！");
            }
            else if (task6 == null)
            {
                task6 = new 定时任务();
                task6.newTask(task, time, value, name,6);
                MessageBox.Show("创建成功！");
            }
            else if (task7 == null)
            {
                task7 = new 定时任务();
                task7.newTask(task, time, value, name,7);
                MessageBox.Show("创建成功！");
            }
            else if (task8 == null)
            {
                task8 = new 定时任务();
                task8.newTask(task, time, value, name,8);
                MessageBox.Show("创建成功！");
            }
            else if (task9 == null)
            {
                task9 = new 定时任务();
                task9.newTask(task, time, value, name,9);
                MessageBox.Show("创建成功！");
            }
            else if (task10 == null)
            {
                task10 = new 定时任务();
                task10.newTask(task, time, value, name,10);
                MessageBox.Show("创建成功！");
            }
            else MessageBox.Show("最多创建10个任务哦~");
        }

        public static void kill(byte num)
        {
            switch (num)
            {
                case 1:
                    task1 = null;
                    break;
                case 2:
                    task2 = null;
                    break;
                case 3:
                    task3 = null;
                    break;
                case 4:
                    task4 = null;
                    break;
                case 5:
                    task5 = null;
                    break;
                case 6:
                    task6 = null;
                    break;
                case 7:
                    task7 = null;
                    break;
                case 8:
                    task8 = null;
                    break;
                case 9:
                    task9 = null;
                    break;
                case 10:
                    task10 = null;
                    break;
            }
        }
    }
}