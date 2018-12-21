using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Controllers
{
    [Route("/file")]
    public class FileController : ControllerBase
    {

        [HttpPost]
        [Route("Get/{parameter}")]

        public String GetMessageList(string region)
        {
            if (region=="All")
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
        public string GetReplies(string msid)
        {
            MessagerDb db = new MessagerDb();
            List<Reply> rpList = db.Getreply(msid);
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
        [Route("Upload/{parameter}")]
        public void UpMessage(string name, string content, string wxId, string region, string imageId)
        {
            Message a = new Message(name, content, wxId, region, imageId);
            MessagerDb db = new MessagerDb();
            db.UpMessage(a);
        }
    }
}