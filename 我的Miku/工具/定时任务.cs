using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;

namespace 我的Miku.工具
{
    public class 定时任务
    {
        public string Task;
        public long Time;
        public string Value;
        public string Name;
        public string Command;
        public static byte taskNum = 0;
        public byte Num;
        public long timeNow;

        public System.Timers.Timer aTimer;

        public void Timer()
        {
            //实例化Timer类，设置间隔时间为10000毫秒； 
            aTimer = new System.Timers.Timer(10000);

            //注册计时器的事件
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            //设置时间间隔为2秒（2000毫秒），覆盖构造函数设置的间隔
            aTimer.Interval = Time;

            //设置是执行一次（false）还是一直执行(true)，默认为true
            aTimer.AutoReset = false;

            //开始计时
            aTimer.Enabled = true;

        }

        public void timeTimer()
        {
            timeNow = Time + 60000;
            //实例化Timer类，设置间隔时间为10000毫秒； 
            System.Timers.Timer t = new System.Timers.Timer(10000);

            //注册计时器的事件
            t.Elapsed += new ElapsedEventHandler(OnTimedEvent2);

            //设置时间间隔为2秒（2000毫秒），覆盖构造函数设置的间隔
            t.Interval = 1000;

            //设置是执行一次（false）还是一直执行(true)，默认为true
            t.AutoReset = true;

            //开始计时
            t.Enabled = true;
        }

        private void OnTimedEvent2(object sender, ElapsedEventArgs e)
        {
            timeNow -= 1000;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            runTask();
        }

        public void newTask(string task, long time, string value, string name,byte num)
        {
            Task = task;
            Time = time;
            Value = value;
            Name = name;
            Num = num;

            switch (Task)
            {
                case "定时关机":
                    Command = "shutdown -s";
                    break;
                case "定时重启":
                    Command = "shutdown -r";
                    break;
                case "定时关闭某程序(值:映像名)":
                    Command = "taskkill -f -im " + Value;
                    break;
                case "定时运行某程序(值:路径)":
                    Command = "start " + Value;
                    break;
                case "定时打开文件(值:路径)":
                    Command = Value;
                    break;
                case "定时执行命令(值:cmd)":
                    Command = Value;
                    break;
                case "定时关闭Miku":
                    Command = "taskkill -f -im 我的Miku.exe";
                    break;
                default:
                    MessageBox.Show("任务值错误Error");
                    break;
            }
            Timer();
            timeTimer();
            taskNum++;
        }

        public void runTask()
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
            taskNum--;
            定时任务sender.kill(Num);
        }

        public long sendInterval()
        {
            return timeNow;
        }


    }
}
