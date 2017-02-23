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

            Console.WriteLine(Model.getModel().Login("james@gmail.com", "lol"));
            Model.getModel().setRegisteredCourses();
            Console.WriteLine(Model.getModel().getStudent().listCourse.Count);
            Console.ReadLine();
           /* Model model = new Model();
            int start = 1;
            do
            {
               
                switch (start)
                {
                    case 1:
                        String username = View.getEmailAdress();
                        String password = View.getPassword(); ;
                        String fullname = View.getFullname();
                        string[] firstlast = fullname.Split(' ');
                        model.Register(username, password, "lol", "dsf", "dsfs", 1);
                        int role = View.getRole();
                        Console.WriteLine( role);
                        if(role == 1)
                        {
                            Boolean major = false;
                            while(major == false)
                            {
                                Dictionary<int,String> majorList = model.getMajors();
                                String decideM = View.generateList(majorList);
                                Console.WriteLine("decide is" +decideM);
                                model.setMajor(decideM);

                            //    model.
                                //major = true;
                            }
                           
                        }
                        break;
                    case 2:     
                        //int role = View.getRole();
                        break;
                    case 5:
                       
                    default:
                        break;

                }
               // start = View.choose();
               // Console.WriteLine("View = " + start);
            } while (start != 4);*/
        }

   
    }
   
}
