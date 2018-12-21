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
namespace userManagerFrom
{
    public partial class Form1 : Form
    {
        public int msId;
        public string name;
        public string wxid;
        public string content;
        public string time;
        public string region;
        public string imageid;
        userService userservice = new userService();
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = userservice.GetAllMessages();
            dataGridView1.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                bindingSource1.DataSource = userservice.GetMessage(msId);
            }
            else
            {
                bindingSource1.DataSource = userservice.GetAllMessages();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wxid = this.textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = userservice.GetAllMessages().Count;
            if (dataGridView1.Rows[r].Cells[0].Value == null || dataGridView1.Rows[r].Cells[1].Value == null || dataGridView1.Rows[r].Cells[2].Value == null)
            {
                DialogResult result1 = MessageBox.Show("用户内容不可为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            wxid = dataGridView1.Rows[r].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[r].Cells[1].Value.ToString();
            msId = Int32.Parse(s1);
            name = dataGridView1.Rows[r].Cells[2].Value.ToString();
            content = dataGridView1.Rows[r].Cells[3].Value.ToString();
            time = dataGridView1.Rows[r].Cells[4].Value.ToString();
            region = dataGridView1.Rows[r].Cells[5].Value.ToString();
            imageid = dataGridView1.Rows[r].Cells[6].Value.ToString();
            int n = 0;
            List<messages> messageList = userservice.GetAllMessages();
            for (int i = 0; i < messageList.Count; i++)
            {
                if (messageList[i].msid == msId)
                {
                    n++;
                }
            }
            //如果id相同，则重复
            if (n > 0)
            {
                DialogResult result1 = MessageBox.Show("用户重复", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                userservice.AddMessage(new messages(msId, name, wxid, content, time, region, imageid));
                bindingSource1.DataSource = userservice.GetAllMessages();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (bindingSource1.Current != null)
            {
                messages mes = (messages)bindingSource1.Current;
                userservice.DeleteMessage(mes.msid);
                bindingSource1.DataSource = userservice.GetAllMessages();
            }
            else
            {
                MessageBox.Show("No user is selected!");
            }
        }
    }
}
