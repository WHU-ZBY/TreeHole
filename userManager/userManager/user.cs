using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace userManager
{
    public class user
    {
        [Key]
        public string Wxid { set; get; }
        public int MsId { set; get; }
        public string Name { set; get; }
        public string Content { set; get; }
        public string Time { set; get; }
        public string Region { set; get; }
        public string Imageid { set; get; }
        public user() { }
        public user(int msId, string name, string wxid, string content, string time, string region, string imageid)
        {
            this.MsId = msId;
            this.Name = name;
            this.Wxid = wxid;
            this.Content = content;
            this.Time = time;
            this.Region = region;
            this.Imageid = imageid;
        }
        public override string ToString()
        {
            return MsId + Name + Wxid + Content + Time + Region + Imageid;
        }
    }
}
