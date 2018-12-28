using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
{
    public class Reply
    {
        public string name;
        public string content;
        public string dateTime;
        public string wxId;
        public string rpId;
        public string replyTo;
        public string imageId;
        public string replytowx;

        public Reply(string name, string content,string wxId,string replyTo, string imageId, string replytowx)
        {
            this.imageId = imageId;
            this.name = name;
            this.content = content;
            this.wxId = wxId;
            this.replyTo = replyTo;
            this.replytowx = replytowx;
            this.dateTime = DateTime.Now.ToString();
        }
        public Reply(string name, string content, string wxId, string replyTo, string imageId,string time,string replyid,string replytowx)
        {
            this.imageId = imageId;
            this.name = name;
            this.content = content;
            this.wxId = wxId;
            this.replyTo = replyTo;
            this.rpId = replyid;
            this.dateTime = DateTime.Now.ToString();
            this.replytowx = replytowx;
            dateTime = time;
        }
        public Reply(string name, string content, string wxId, string replyTo, string imageId, string time, string replyid)
        {
            this.imageId = imageId;
            this.name = name;
            this.content = content;
            this.wxId = wxId;
            this.replyTo = replyTo;
            this.rpId = replyid;
            this.dateTime = DateTime.Now.ToString();
            dateTime = time;
        }
        public string toJson()
        {
            string json = "{\"name\":\"" + name + "\",\"replyid\":\"" +rpId+ "\",\"content\":\"" + content + "\",\"wxid\":\"" + wxId + "\",\"replyto\":\"" + replyTo + "\",\"iamgeid\":\"" +imageId + "\",\"datetime\":\"" + dateTime.ToString() + "\"}";
            return json;
        }
    }
}
