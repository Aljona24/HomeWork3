using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork3
{
    public class Creator
    {
        public User CreateUser(int id, string name, string login, string password)
        {
            return new User(id, name, login, password);
        }
    }
}