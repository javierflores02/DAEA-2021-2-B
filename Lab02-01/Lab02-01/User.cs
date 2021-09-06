using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_01
{
    class User
    {
        private String username;
        private String password;

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public String get_username()
        {
            return this.username;
        }

        public String get_password()
        {
            return this.password;
        }
    }
}
