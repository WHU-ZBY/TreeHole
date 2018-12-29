using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using userManager;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace userManagerFrom
{
    public partial class Form2 : Form
    {
        string str;
        string Strid;
        public string mesId;
        userService userservice = new userService();
        public Form2()
        {
            InitializeComponent();
            bindingSource1.DataSource = userservice.replies;
            dataGridView1.DataSource = bindingSource1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://andyfool.com/file/Get2/GetReplies?msid="+mesId;
            str = HttpApi(url, "{}", "POST");
            userservice.replies = JsonConvert.DeserializeObject<List<reply>>(str);
            bindingSource1.DataSource = userservice.replies;
        }
        public static string HttpApi(string url, string jsonstr, string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString();//get或者post
            byte[] buffer = encoding.GetBytes(jsonstr);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                Strid = this.textBox1.Text;
                int replyid = Int32.Parse(Strid);
                bindingSource1.DataSource = userservice.findReply(replyid);
            }
            else
            {
                bindingSource1.DataSource = userservice.replies;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Strid = this.textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (bindingSource1.Current != null)
            {
                reply reply1 = (reply)bindingSource1.Current;
                string replyId = reply1.replyId.ToString();
                //执行删除
                string url = "https://andyfool.com/file/DelRp/DelRp?rpid=" +replyId;
                HttpApiDel(url, "{}", "POST");
                //获取新的信息
                string urlt = "https://andyfool.com/file/Get2/GetReplies?msid=" + mesId;
                str = HttpApi(urlt, "{}", "POST");
                userservice.replies = JsonConvert.DeserializeObject<List<reply>>(str);
                bindingSource1.DataSource = userservice.replies;
            }
            else
            {
                MessageBox.Show("No user is selected!");
            }
        }
        public static void HttpApiDel(string url, string jsonstr, string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString();//get或者post
            byte[] buffer = encoding.GetBytes(jsonstr);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
        }
    }
}
