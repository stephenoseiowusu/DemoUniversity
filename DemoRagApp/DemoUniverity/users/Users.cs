using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUniversity.Users
{
    public  abstract class Users
    {
        #region fields
        public string firstname;
        public string lastname;
        protected string password;
        private string email;
        private int id;
        #endregion fields
        /// <summary>
        /// 
        /// </summary>

        #region Contructors
        public Users()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="id"></param>
        public Users( string Firstname, string Lastname, string password, string email, int id)
        {
            this.firstname = Firstname;
            this.lastname = Lastname;
            this.password = password;
            this.email = email;
            this.id = id;
        }
        #endregion

        #region Property
        public String Fullname {
            get { return $"{firstname} {lastname}"; }
            set { firstname = value.Split(' ')[0];
                lastname = value.Split(' ')[1];
            }
        }
       public virtual String Password
       {
            get { return password; }
       }
       public String Email
       {
            get { return email; }
            set { email = Email; }
       }
       
       public int ID
        {
            get {return id; }
            set { id = ID; }
        }
        #endregion

        public override string ToString()
        {
            String result = "";
            result += Fullname;
            result += "\n";
            result += $"email:{email}";
            return result;
        }
        public abstract String getInfo();
    }
}







