using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userManager
{
    class Program
    {
        static void Main(string[] args)
        {
            userService userService = new userService();

            messages mes = new messages(1, "apdo", "dsafas", "what is content", "20181214", "china", "4");
            userService.AddMessage(mes);
        }
    }
}
