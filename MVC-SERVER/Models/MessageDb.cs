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
        public List<Reply> Getreply(string replyto)
        {
            List<Reply> list = new List<Reply>();
            //连接数据库
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("select replyid, imageid, wxid, content, name, time, replyto from replies WHERE replyto =\'" + replyto + "\'", msconnection);
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
                MySqlCommand mscommand = new MySqlCommand("select msId, name, wxid, content, time, region, imageid from messages WHERE region="+region, msconnection);
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
            return list;
        }
        public void UpMessage(Message ms)
        {
            using (MySqlConnection msconnection = GetConnection())
            {
                msconnection.Open();
                //查找数据库里面的表
                MySqlCommand mscommand = new MySqlCommand("INSERT INTO wxdb.messages (name, wxid, content, time, region, imageid) VALUES (\'"+ms.name +"\', \'" + ms.wxId +"\', \'" + ms.content+ "\', \'" + ms.dateTime +"\', \'" + ms.region +"\', \'" + ms.imageId +"\')", msconnection);
                mscommand.ExecuteReader();
            }
        }
    }

}
