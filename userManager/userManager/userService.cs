using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userManager
{
    public class userService
    {
        public List<user> users;
        public List<reply> replies;
        public void deleteUser(int msid)
        {
        }
        public void deleteReply(int replyId)
        {

        }
       public user findUser(int msid)
        {
            foreach(var u in users)
            {
                if (u.MsId == msid)
                {
                    return u;
                }
            }
            return null;
        }
        public reply findReply(int replyId)
        {
            foreach(var r in replies)
            {
                if (r.replyId == replyId)
                {
                    return r;
                }
            }
            return null;
        }
    }
}