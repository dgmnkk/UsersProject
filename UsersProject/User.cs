using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersProject
{
    internal class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return $"{Login}, {Password}, {Adress}, {PhoneNumber}, {Role}";
        }
    }
}
