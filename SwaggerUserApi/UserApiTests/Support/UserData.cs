using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApiTests.Support
{
    public class UserData
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int userStatus { get; set; }

        public UserData (int id, string username, string firstName, string lastName, string email, string password, string phone, int userStatus)
        {
            this.id = id;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.userStatus = userStatus;
        }

        public static List<UserData> CreateUserListForRequest()
        {
            List<UserData> userList = new List<UserData>()
            {
             new UserData(1, "Ben", "BenSol", "Smith", "BenS@gmail.com", "qwerty123", "+920 758 88 46", 1),
             new UserData(1, "Mick666", "Mick", "Gordon", "Gordon@gmail.com", "somepass", "+920 566 44 16", 1),
             new UserData(1, "Faker", "Lil", "henderson", "lil909@gmail.com", "1933zxc", "+925 862 32 22", 1)
            };
            return userList;
        }

        public static UserData CreateUserForRequest()
        {
            return new UserData(1, "John123", "John", "Smith", "John906@gmail.com", "qwerty123", "+920 758 88 46", 1);
        }

    }
}
