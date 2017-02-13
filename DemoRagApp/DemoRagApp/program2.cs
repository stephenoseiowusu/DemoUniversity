using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DemoUniversity.Users;
namespace DemoRagApp
{
    class program2
    {
        static void Main(string[] args)
        {
           
            Model model = new Model();
            int start = 1;
            do
            {
               
                switch (start)
                {
                    case 1:
                        String username = View.getUsername();
                        String password = View.getPassword();
                        Console.WriteLine( model.Register(username, password));
                        break;
                    case 2:     
                        int role = View.getRole();
                        break;
                    default:
                        break;

                }
                start = View.choose();
               // Console.WriteLine("View = " + start);
            } while (start != 4);
        }

   
    }
   
}
