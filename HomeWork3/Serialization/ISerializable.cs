using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork3
{
    public interface ISerializable
    {
        void Write(List<User> users);
        List<User> Read();
    }
}