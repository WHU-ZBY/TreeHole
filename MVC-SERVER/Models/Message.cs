using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
{
    public class Message
    {
        public string name;
        public string imageId;
        public string content;
        public string dateTime;
        public string wxId;
        public string region;
        public string msId;
        public List<Reply> replies = new List<Reply>();

        public Message(string name, string content,string wxId,string region,string imageId)
        {
            this.name = name;
            this.content = content;
            this.wxId = wxId;
            this.region = region;
            this.dateTime = DateTime.Now.ToString();
            this.imageId = imageId;
        }
        public Message(string name, string content, string wxId, string region, string imageId,string time,string msid)
        {
            this.name = name;
            this.content = content;
            this.wxId = wxId;
            this.region = region;
            this.dateTime = time;
            this.imageId = imageId;
            this.msId = msid;
        }
        public string toJson()
        {
            string json = "{\"name\":\"" + name + "\",\"content\":\"" + content + "\",\"wxid\":\"" + wxId + "\",\"msid\":\"" + msId + "\",\"region\":\"" + region + "\",\"imageid\":\"" + imageId + "\",\"datetime\":\"" + dateTime.ToString() + "\"}";
            return json;
        }
    }
}
