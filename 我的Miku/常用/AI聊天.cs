using System;

using System.Text;

using System.Windows.Forms;

using System.Net;

using System.IO;

using Newtonsoft.Json;

namespace 我的Miku.常用
{
    public partial class AI聊天 : 模板
    {
        public void area()
        {
            if (主窗体.area != "")
            {
                rtb_send.Text = 主窗体.area + "天气";
                try
                {
                    string returnMess = ConnectTuLing(rtb_send.Text);
                    rtb_mess.Text = returnMess;
                }
                catch (Exception)
                {
                    MessageBox.Show("网络未连接，未获取到天气");
                }
            }
            else
            {
                FindForm().Close();
            }
        }

        public AI聊天()
        {
            InitializeComponent();
            //base.pictureBox1.Anchor = AnchorStyles.Right;
            //base.pictureBox2.Anchor = AnchorStyles.Right;
            //pictureBox3.Anchor = AnchorStyles.Right;
        }

        HttpWebResponse Response = null;

        /// <summary>

        /// 对话图灵机器人

        /// </summary>

        /// <param name="p_strMessage"></param>

        /// <returns></returns>

        public string ConnectTuLing(string p_strMessage)

        {

            string result = null;

            try

            {


                String APIKEY = "3dfbc2363d6f4002953d0a0adf86d512";

                String _strMessage = p_strMessage;

                String INFO = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(_strMessage));

                String getURL = "http://www.tuling123.com/openapi/api?key=" + APIKEY + "&info=" + INFO;

                HttpWebRequest MyRequest = (HttpWebRequest)HttpWebRequest.Create(getURL);

                HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();

                Response = MyResponse;

                using (Stream MyStream = MyResponse.GetResponseStream())

                {

                    long ProgMaximum = MyResponse.ContentLength;

                    long totalDownloadedByte = 0;

                    byte[] by = new byte[1024];

                    int osize = MyStream.Read(by, 0, by.Length);

                    Encoding encoding = Encoding.UTF8;

                    while (osize > 0)

                    {

                        totalDownloadedByte = osize + totalDownloadedByte;

                        result += encoding.GetString(by, 0, osize);

                        long ProgValue = totalDownloadedByte;

                        osize = MyStream.Read(by, 0, by.Length);

                    }

                }

                //解析json

                JsonReader reader = new JsonTextReader(new StringReader(result));

                while (reader.Read())

                {

                    //text中的内容是需要的

                    if (reader.Path == "text")

                    {

                        //结果赋值

                        result = reader.Value.ToString();

                    }

                    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);

                }

            }

            catch (Exception)

            {

                MessageBox.Show("网络连接失败啦~");

            }

            return result;

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string returnMess = ConnectTuLing(rtb_send.Text);

            rtb_mess.Text = returnMess;
            rtb_send.Text = "";
        }

        /// <summary>

        /// 回车快捷键

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        private void rtb_send_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)

            {
                rtb_mess.Text = ConnectTuLing(rtb_send.Text);

                rtb_send.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb_mess.Text = "\n\n\n\n\n\n\n\n\n\n\n";
            rtb_send.Text = "技术支持：图灵机器人\r\n" + @"http://www.tuling123.com/";
        }

        private void AI聊天_TextChanged(object sender, EventArgs e)
        {
            base.label1.Text = FindForm().Text;
        }
    }
}
