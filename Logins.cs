using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_MinWooPark
{
    class Logins
    {
        private int Id;
        private string userName;
        private string password;
        private int superUser;

        public Logins(int id, string userName, string password, int superUser)
        {
            Id = id;
            this.userName = userName;
            this.password = password;
            this.superUser = superUser;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int SuperUser { get => superUser; set => superUser = value; }
    }
}
