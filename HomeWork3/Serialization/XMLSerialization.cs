using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;


namespace HomeWork3
{
    public class XMLSerializer : ISerializable
    {
        public List<User> Read()
        {
            List<User> users;
            FileInfo fi = new FileInfo("users.bin");
            long fileLength;


            if (fi.Exists == true)
            {
                fileLength = fi.Length;
            }
            else
            {
                fileLength = 0;
            }



            if (fileLength == 0)
            {
                users = new List<User>();
            }
            else
            {
                using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<User>));
                    users = (List<User>)xs.Deserialize(fs);
                }
            }            
            return users;
        }
        public void Write(List<User> users)
        {
            using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<User>));
                xs.Serialize(fs, users);
            }
        }
    }
}