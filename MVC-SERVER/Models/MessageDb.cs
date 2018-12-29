using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace MVC
{
    public class MessagerDb
    {
        public string ConnectionString { get; set; }
        public MessagerDb()
        {
            this.ConnectionString = "server=127.0.0.1;userid=root;password=@Qq132325;database=wxdb;";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Reply> GetReply(string replyto)
        {
            List<Reply> list = new List<Reply>();
            //连接数据库
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("select replyid, imageid, wxid, content, name, time, replyto from replies WHERE replyto =" + replyto, msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {
                    //读取数据
                    while (reader.Read())
                    {
                        list.Add(new Reply(reader.GetString("name"), reader.GetString("content"), reader.GetString("wxid"), reader.GetString("replyto"), reader.GetString("imageid"), reader.GetString("time"), reader.GetString("replyid")));
                    }
                }
            }
            return list;
        }
        public List<Reply> GetMyReply(string wxid)
        {
            List<Reply> list = new List<Reply>();
            //连接数据库
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("select replyid, imageid, wxid, content, name, time, replyto from replies WHERE replytowx=\'" + wxid + "\'", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {
                    //读取数据
                    while (reader.Read())
                    {
                        list.Add(new Reply(reader.GetString("name"), reader.GetString("content"), reader.GetString("wxid"), reader.GetString("replyto"), reader.GetString("imageid"), reader.GetString("time"), reader.GetString("replyid")));
                    }
                }
            }
            list.Reverse();
            return list;
        }
        public List<Message> GetAllMessage()
        {
            List<Message> list = new List<Message>();
            //连接数据库
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("select msId, name, wxid, content, time, region, imageid from messages", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {

                    //读取数据
                    while (reader.Read())
                    {
                        string a = reader.GetInt16("msid").ToString();
                        list.Add(new Message(reader.GetString("name"), reader.GetString("content"), reader.GetString("wxid"), reader.GetString("region"), reader.GetString("imageid"), reader.GetString("time"), a));
                    }
                }
            }
            list.Reverse();
            return list;
        }
        public List<Message> GetMessage(string region)
        {
            List<Message> list = new List<Message>();
            //连接数据库
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("select msId, name, wxid, content, time, region, imageid from messages WHERE region=" + region, msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {

                    //读取数据
                    while (reader.Read())
                    {
                        string a = reader.GetInt16("msid").ToString();
                        list.Add(new Message(reader.GetString("name"), reader.GetString("content"), reader.GetString("wxid"), reader.GetString("region"), reader.GetString("imageid"), reader.GetString("time"), a));
                    }
                }
            }
            list.Reverse();
            return list;
        }
        public void UploadMessage(Message ms)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("INSERT INTO wxdb.messages (name, wxid, content, time, region, imageid) VALUES (\'" + ms.name + "\', \'" + ms.wxId + "\', \'" + ms.content + "\', \'" + ms.dateTime + "\', \'" + ms.region + "\', \'" + ms.imageId + "\')", msconnection);
                mscommand.ExecuteReader();
            }
        }
        public void UploadId(string name, string imageid, string wxid)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                MySqlCommand mscommand = new MySqlCommand("DELETE FROM wxdb.name WHERE (wxid = \'" + wxid + "\')", msconnection);
                mscommand.ExecuteReader();
                mscommand.Dispose();
                mscommand = new MySqlCommand("INSERT INTO wxdb.name (name, imageid,wxid) VALUES (\'" + name + "\', \'" + imageid + "\', \'" + wxid + "\')", msconnection);
                mscommand.ExecuteReader();
            }
        }
        public String GetId(string wxid)
        {
            string a = "默认";
            string b = "默认";
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                MySqlCommand mscommand = new MySqlCommand("select name, imageid from name WHERE wxid=\'" + wxid + "\'", msconnection);
                using (MySqlDataReader reader = mscommand.ExecuteReader())
                {

                    //读取数据
                    while (reader.Read())
                    {
                        a = reader.GetString("name");
                        b = reader.GetString("imageid");
                    }
                    return ("{\"name\":\"" + a + "\",\"imageid\":\"" + b + "\"}");

                }

            }
            return ("{\"name\":\"" + a + "\",\"imageid\":\"" + b + "\"}");
        }

        public void UploadReply(Reply rp)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("INSERT INTO wxdb.replies (imageid, wxid, content, name, time, replyto, replytowx) VALUES (\'" + rp.imageId + "\', \'" + rp.wxId + "\', \'" + rp.content + "\', \'" + rp.name + "\', \'" + rp.dateTime + "\', \'" + rp.replyTo + "\', \'" + rp.replytowx + "\')", msconnection);
                mscommand.ExecuteReader();
            }
        }
        public void DeleteReply(string replyid)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("DELETE FROM wxdb.replies WHERE (replyid = " + replyid + ")", msconnection);
                mscommand.ExecuteReader();
            }
        }
        public void DeleteMessage(string msid)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("DELETE FROM wxdb.messages WHERE (msid =" + msid + ");", msconnection);
                mscommand.ExecuteReader();
                mscommand = new MySqlCommand("DELETE FROM wxdb.replies WHERE (replyto =" + msid + ");", msconnection);
                mscommand.ExecuteReader();
            }
        }
    }

}
