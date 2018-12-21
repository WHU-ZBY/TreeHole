using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
{
    public class Reply
    {
        private string name;
        private string content;
        private string dateTime;
        private string wxId;
        private string rpId;
        private string replyTo;
        private string imageId;

        public Reply(string name, string content,string wxId,string replyTo, string imageId)
        {
            this.imageId = imageId;
            this.name = name;
            this.content = content;
            this.wxId = wxId;
            this.replyTo = replyTo;
            this.dateTime = DateTime.Now.ToString();
        }
        public Reply(string name, string content, string wxId, string replyTo, string imageId,string time,string replyid)
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
            string json = "{\"name\":\"" + name + "\",\"content\":\"" + content + "\",\"wxid\":\"" + wxId + "\",\"replyto\":\"" + replyTo + "\",\"iamgeid\":\"" +imageId + "\",\"datetime\":\"" + dateTime.ToString() + "\"}";
            return json;
        }
    }
}
