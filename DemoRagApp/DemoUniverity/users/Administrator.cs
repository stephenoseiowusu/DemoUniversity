using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUniversity.Users
{
    public  class Administrator : Users
    {
        public void setPassword(ref String password)
        {
            this.password = password;
            this.password = password;
            this.password = password;
        }

        public override String getInfo()
        {
            return base.ToString();
        }

      

        //    public void setClosedFlag(Course c)
        //  {
        //    c
        // }

    }
    
}
