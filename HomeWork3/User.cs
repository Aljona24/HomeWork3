using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork3
{
    [Serializable]
    public class User
    {
        public User()
        {

        }
        public User(int id, string name, string login, string password)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return Id + " | " + Name + " | " + Login + " | " + Password;
        }
    }
}