using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using MySqlX.XDevAPI;

namespace MVC.Controllers
{
    [Route("/file")]
    public class FileController : ControllerBase
    {

        [HttpPost]
        [Route("Get1/{parameter}")]

        public String GetMessage(string kind,string region)
        {
            if (region == "All")
            {
                MessagerDb db = new MessagerDb();
                List<Message> msList = db.GetAllMessage();
                string a = "[";
                foreach (Message message in msList)
                {
                    a += message.toJson();
                    if (msList.IndexOf(message) < msList.Count - 1)
                    {
                        a += ",";
                    }
                }
                a += "]";
                return a;
            }
            else
            {
                MessagerDb db = new MessagerDb();
                List<Message> msList = db.GetMessage(region);
                string a = "[";
                foreach (Message message in msList)
                {
                    a += message.toJson();
                    if (msList.IndexOf(message) < msList.Count - 1)
                    {
                        a += ",";
                    }
                }
                a += "]";
                return a;
            }
        }
        [Route("Get2/{parameter}")]
        public string GetReplies(string msid)
        {
            MessagerDb db = new MessagerDb();
            List<Reply> rpList = db.GetReply(msid);
            string a = "[";
            foreach (Reply reply in rpList)
            {
                a += reply.toJson();
                if (rpList.IndexOf(reply) < rpList.Count - 1)
                {
                    a += ",";
                }
            }
            a += "]";
            return a;
        }
        [Route("Get3/{parameter}")]
        public string MyReplies(string wxid)
        {
            MessagerDb db = new MessagerDb();
            List<Reply> rpList = db.GetMyReply(wxid);
            string a = "[";
            foreach (Reply reply in rpList)
            {
                a += reply.toJson();
                if (rpList.IndexOf(reply) < rpList.Count - 1)
                {
                    a += ",";
                }
            }
            a += "]";
            return a;
        }
        [Route("Get4/{parameter}")]
        public string GetId(string wxid)
        {
            MessagerDb db = new MessagerDb();
            return db.GetId(wxid);
        }
        [Route("Upload1/{parameter}")]
        public void UpMessage(string name, string content, string wxId, string region, string imageId)
        {
            Message a = new Message(name, content, wxId, region, imageId);
            MessagerDb db = new MessagerDb();
            db.UploadMessage(a);
        }
        [Route("Upload2/{parameter}")]
        public void UpReply(string name, string content, string wxId, string replyTo, string imageId, string replytowx)
        {
            Reply a = new Reply(name,content,wxId,replyTo,imageId, replytowx);
            MessagerDb db = new MessagerDb();
            db.UploadReply(a);
        }
        [Route("Upload3/{parameter}")]
        public void UpName(string name, string imageid,string wxid)
        {
            MessagerDb db = new MessagerDb();
            db.UploadId(name,imageid, wxid);
        }
        [Route("DelMs/{parameter}")]
        public void DelMs(string msid)
        {      
            MessagerDb db = new MessagerDb();
            db.DeleteMessage(msid);
        }
        [Route("DelRp/{parameter}")]
        public void DelRp(string rpid)
        {
            MessagerDb db = new MessagerDb();
            db.DeleteReply(rpid);
        }
    }
}