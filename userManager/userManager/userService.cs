using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userManager
{
    public class userService
    {
        public void AddMessage(messages s)
        {
            using (var db=new userDBExternal())
            {
                db.messages.Add(s);
                db.SaveChanges();
            }
        }
        public void AddReplies(replies r)
        {
            using (var db = new userDBExternal())
            {
                db.replies.Add(r);
                db.SaveChanges();
            }
        }
        public void DeleteMessage(int msid)
        {
            using (var db = new userDBExternal())
            {
                var message = db.messages.SingleOrDefault(o => o.msid == msid);
                db.messages.Remove(message);
                db.SaveChanges();
            }
        }
        public void DeleteReplies(int id)
        {
            using (var db = new userDBExternal())
            {
                var user = db.replies.SingleOrDefault(o => o.replyid == id);
                db.replies.Remove(user);
                db.SaveChanges();
            }
        }

        public messages GetMessage(int id)
        {
            using (var db = new userDBExternal())
            {
                return db.messages.SingleOrDefault(o => o.msid == id);
            }
        }
        public replies GetReply(int id)
        {
            using (var db = new userDBExternal())
            {
                return db.replies.SingleOrDefault(o => o.replyid == id);
            }
        }
        public List<messages> GetAllMessages()
        {
            using (var db = new userDBExternal())
            {
                return db.messages.ToList<messages>();
            }
        }
        public List<replies> GetAllReplies()
        {
            using (var db = new userDBExternal())
            {
                return db.replies.ToList<replies>();
            }
        }
    }
}
