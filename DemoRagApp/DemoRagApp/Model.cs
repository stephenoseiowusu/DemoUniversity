using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRagApp
{

    class Model
    {
        public int Login()
        {
            return 0;
        }
        public int Register(String Username, String password)
        {
            return Database.registerAdmin(Username,password) == true ? 1:0;
        }

    }

}
