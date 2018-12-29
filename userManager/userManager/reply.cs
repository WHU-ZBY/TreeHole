using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userManager
{
   public class reply
    {
        public int replyId { set; get; }
        public string imageId { set; get; }
        public string wxid { set; get; }
        public string content { set; get; }
        public string name { set; get; }
        public string time { set; get; }
        public string replyTo { set; get; }
        public string replyTowx { set; get; }
        public reply() { }
        public reply(int replyId,string imageId,string wxid,string content,string name,string time,string replyTo,string replyTowx)
        {
            this.replyId = replyId;
            this.imageId = imageId;
            this.wxid = wxid;
            this.content = content;
            this.name = name;
            this.time = time;
            this.replyTo = replyTo;
            this.replyTowx = replyTowx;
        }
        public override string ToString()
        {
            return replyId + imageId + wxid + content + name + time + replyTo + replyTowx;
        }
    }
}
