﻿using System;
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
    public partial class Form1 : Form
    {
        string str;
        public string Strmsid;
        userService userservice = new userService();
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = userservice.users;
            dataGridView1.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                Strmsid = this.textBox1.Text;
                int msid = Int32.Parse(Strmsid);
                bindingSource1.DataSource = userservice.findUser(msid);
            }
            else
            {
                bindingSource1.DataSource = userservice.users;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Strmsid = this.textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (bindingSource1.Current != null)
            {
                user user1 = (user)bindingSource1.Current;
                Strmsid = user1.MsId.ToString();
                //执行删除
                string url = "https://andyfool.com/file/DelMs/DelMs?msid=" + Strmsid;
                HttpApiDel(url, "{}", "POST");
                //获取新的信息
                string urlt = "https://andyfool.com/file/Get1/GetMessage?region=1";
                str = HttpApi(urlt, "{}", "POST");
                userservice.users = JsonConvert.DeserializeObject<List<user>>(str);
                bindingSource1.DataSource = userservice.users;
            }
            else
            {
                MessageBox.Show("No user is selected!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string url = "https://andyfool.com/file/Get1/GetMessage?region=1";
            str = HttpApi(url, "{}", "POST");
            userservice.users = JsonConvert.DeserializeObject<List<user>>(str);
            bindingSource1.DataSource = userservice.users;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            user user1 = (user)bindingSource1.Current;
            Strmsid = user1.MsId.ToString();
            form2.mesId = Strmsid;
            form2.Visible = false;
            form2.ShowDialog();
        }
    }
}
