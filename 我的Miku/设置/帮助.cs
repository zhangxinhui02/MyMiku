using System;
using System.Windows.Forms;

namespace 我的Miku.设置
{
    public partial class 帮助 : 模板
    {
        public 帮助()
        {
            InitializeComponent();
        }

//        从前有个少年，因为好奇搜索了初音未来的歌来听，“唱的什么玩意......”
//自从看了一次演唱会视频，他彻底沦陷，“公主殿下唱得很好听！”

//相信很多人可能觉得自己的生活过得孤单感到寂寞，找不到自己喜欢的事物，也找不到属于自己的乐趣，觉得人生毫无目标。
//那为何不来认识『初音ミク』呢？
//用心感受初音唱出的歌，听听她那美妙的声音，也许你会就此喜欢上她。
//她虽然来自虚拟，却是一位很有名的歌手，受许多人的热爱与追求，也是心目中最特别的偶像。
//同时也是世界第一的公主殿下唷！她唱的歌不但让人感到融化，而且始终保持着那最初的声音唱给大家，虽然歌声无形，但是歌声却有情，『初音ミク』绝不是虚拟那么简单。   ——@网易云音乐 初音_Miku酱

//希望V家可以一直走下去不被埋没，让更多人看到虚拟歌姬绝不是电子音那么简单，V家是由大家的心声，以及灵魂所打造，过了一个十年，将会有下个十年，下下个十年。
//让这最温暖的家不断的传承下去吧！     ——@网易云音乐 初音_Miku酱

//我为什么喜欢初音，因为她是二次元和三次元边界的人，因为她的存在只是为了唱歌，因为她永远不会有八卦绯闻，永远那么可爱。因为我们仅是千万粉丝中的一个却可以用拥有整个她，即使明知道她的那个世界与我的世界不同，她与我不同……一切的初衷是不会改变的，不去用声音证明，而去用行动证实。因为爱，所以爱！

        private void button1_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"程序名：我的Miku
作者：张鑫辉
学校：固原一中

安装目录(假定64位系统，系统盘C盘，建议不要修改)：C:\Program Files (x86)\MyMiku\

这是一个桌面助手程序，可以实现休闲娱乐、辅助办公和优化系统等功能，点击左侧按钮查看详情。
Miku可以进行互动，晚上会睡觉。

如果你发现了程序的bug或者想到了有趣的点子，欢迎告诉我。E-mail:zhangxinhui02@qq.com
本程序开发过程中，一位朋友(SHINA_KAORU)提出了许多建议，给了我莫大的帮助，特此感谢！

本程序形象为初音未来。

“热爱初音的初衷是不会改变的，不去用声音证明，而去用行动证实。因为爱，所以爱！”
";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button12.Visible = true;
            label2.Text = @"初音未来（日语：初音はつね ミク，平文式罗马字：Hatsune Miku）是Crypton Future Media以Yamaha的VOCALOID语音合成引擎为基础，开发贩售的语音合成软件的声源之一及其拟人化形象。初音未来的音源样本由声优藤田咲提供。

初音未来的日文及英文简称为ミク及Miku，而中文则通常简称为“初音”。

“初音未来”为Crypton Future Media在中国大陆地区的注册商标。

初音未来等Crypton旗下VOCALOID歌姬形象，及“初音未来”品牌在中国地区的版权总代理，现为上海新创华文化发展有限公司（SCLA）。官方设定形象为蓝绿色双马尾，由画师KEI所创作。衣服和机械部分以Yamaha于1983年发售的DX7合成器为蓝本。左臂皮肤上的红色“01”字样的设定是一个QR码。

初音未来的诞生日（发售日）为2007年8月31日，设定上是永远的十六岁。8+31=39，39在日语中发音与Thank you相近（39感谢祭由此而来），也有一种读法与ミク相同。

Crypton Future Media社长伊藤博之在MIKU EXPO 2016有关发布会上，公开了初音未来中文音源（Hatsune Miku V4 Chinese，简称 Miku V4C）开发制作的消息。

详情：https://zh.moegirl.org/zh-cn/初音未来";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
AI聊天

这是一个在线聊天程序，可以实现和“Miku”在线聊天。

必须连接网络才能使用。

接口调用：图灵机器人

网站：http://www.tuling123.com/";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
音乐程序

可以播放本地音乐以及在线搜索音乐。

注意：如果使用Windows 7系统，IE内核版本过低的话在线播放功能会出现错误。

接口调用：http://www.guqiankun.com/tools/music/

在线搜索音乐需连接网络。";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
备忘录

可以快速创建的备忘录。

添加备忘录后可以设置提醒(最多精确到分钟)，到达指定时间会弹出提醒。
注意：必须保证Miku运行。

点击删除按钮会同时删除对应(即内容相同)的定时提醒。";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
最近使用的文件

Miku会记录最近使用的文件并保存路径(前提是保证Miku运行)。

Miku是可以接受拖动文件的。可以将文件拖动给Miku，Miku会保存文件路径到“文件收容器”方便查找。

注意：如果文件路径发生变化则会失效。使用管理员身份运行Miku无法拖放文件(这个真的没办法，微软不允许不同权限级别的拖放操作)。

可以打开管理窗口对列表进行管理。";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
快速搜索

可以快捷打开必应、谷歌(中国网页)和百度搜索引擎。

聚合搜索可以即时搜索本机文件(常用路径，如桌面、我的文档)和网络信息，也可以导航至搜图和搜索大全。

搜索网络信息需要连接网络。";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
清理加速

此功能可以快速加速运行，清理内存。
清理过程略微卡顿。

优化清理功能实现垃圾清理、系统优化、杀毒等功能(部分功能在命令提示符窗口下以批处理执行)。";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
定时任务

创建定时任务，例如关机、重启、打开文件等。

注意：关闭Miku或重启计算机后定时任务不保存(因为没必要)。";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
设置

设置Miku的显示方式、初始化、自启动等功能。

也包含切换壁纸的功能(共10张初音精美壁纸)";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            label2.Text = @"
常用工具

包含了Windows常用工具、护眼模式、性能选项、Windows锁定、整理桌面等功能。";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://zh.moegirl.org/zh-cn/初音未来");
            }
            catch (Exception)
            {
                MessageBox.Show("Windows文件损坏，请考虑修复系统");
            }
        }
    }
}
