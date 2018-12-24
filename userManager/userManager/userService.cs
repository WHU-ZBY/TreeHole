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
        public void deleteUser(int msid)
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
    }
}
