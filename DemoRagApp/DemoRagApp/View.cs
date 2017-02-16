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
            Console.WriteLine("Enter 1 to login, 5 to register, and 4 to quit");
            int operation = int.Parse(Console.ReadLine());
           // Console.WriteLine("operation = " + operation);
            return operation;
      }
   
        public static String getEmailAdress()
      {
            Console.WriteLine("Enter EmailAdress");
            String username = Console.ReadLine();
            return username;
      }
      public static String getPassword()
      {
            Console.WriteLine("Enter user password");
            String password = Console.ReadLine();
            return password;
      }
        public static String getFullname()
        {
            Console.WriteLine("Enter your first and last name");
            String fullname = Console.ReadLine();
            return fullname;
        }
      public static int getRole()
      {
            Console.WriteLine("Enter to register for 1 Student and 2 for admin");
            int choose = int.Parse(Console.ReadLine());
            return choose;
      }

      public static String generateList(Dictionary<int,String> list)
      {
            Console.WriteLine("Enter the number your major of choice corresponds to");
            String course;
            for (int i = 0; i < list.Count; i++)
            {
                
                list.TryGetValue(i,out course).ToString();
                Console.WriteLine($"{i}: {course}");
              
            }
            int choose = int.Parse(Console.ReadLine());

            course = list.ElementAt(choose).Value;
           // list.TryGetValue(choose, out course);
            return course;
      }     
      
     
    }
}
