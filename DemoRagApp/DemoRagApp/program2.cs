using DemoUniversity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUniversity.Users;
namespace DemoRagApp
{
    class program2
    {
        static void Main(string[] args)
        {
            Users current_user;
           
            Console.WriteLine("Enter an operation are you a student enter 1 or an admin enter 2 or 3 to register");
            int operation = Console.Read();
            switch (operation)
            {
                case 1:  Console.WriteLine("Enter user name");
                         String username = Console.ReadLine();
                         Console.WriteLine("Enter password");
                         String password = Console.ReadLine();
                         break;
                case 2:
                         Console.WriteLine("Enter user name");
                         username = Console.ReadLine();
                         Console.WriteLine("Enter password");
                         password = Console.ReadLine();
                         break;
                case 3:
                       Console.WriteLine("Enter username");
                       username = Console.ReadLine();
                       Console.WriteLine("Enter password");
                       password = Console.ReadLine();
                       Console.WriteLine("Enter Role You wish to be 1 for admin 2 for student");
                       int role = Console.Read();
                       Register(role);
                       break;

                default: Console.WriteLine("Incorrect input");
                         break;

            }


        }
        public static void studentRole()
        {

            String what = Console.ReadLine();
            while(!what.ToLower().Equals("quit"))
            {

            }
        }
        public static void Register(int role)
        {

        }
    }
   
}
