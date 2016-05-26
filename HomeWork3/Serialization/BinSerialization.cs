using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HomeWork3
{
    public class BinSerializer : ISerializable
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
                using (FileStream fs = new FileStream("users.bin", FileMode.OpenOrCreate))
                {

                    BinaryFormatter bf = new BinaryFormatter();
                    try
                    {
                        users = (List<User>)bf.Deserialize(fs);
                    }
                    catch (Exception e)
                    {
                        users = new List<User>();
                    }
                }
            }
            return users;
        }
        public void Write(List<User> users)
        {
            File.WriteAllText("users.bin", "");
            using (FileStream fs = new FileStream("users.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, users);
            }
        }
    }
}