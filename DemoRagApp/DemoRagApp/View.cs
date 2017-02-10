using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRagApp
{
    public class View
    {

  
      public static int choose()
      {
            Console.WriteLine("Enter 1 to login, 2 to register, and 4 to quit");
            int operation = int.Parse(Console.ReadLine());
           // Console.WriteLine("operation = " + operation);
            return operation;
      }
   
        public static String getUsername()
      {
            Console.WriteLine("Enter user name");
            String username = Console.ReadLine();
            return username;
      }
      public static String getPassword()
      {
            Console.WriteLine("Enter user password");
            String password = Console.ReadLine();
            return password;
      }
      public static int getRole()
      {
            Console.WriteLine("Enter to register for Student and 2 for admin");
            int choose = Console.Read();
            return choose;
      }
      
      
     
    }
}
