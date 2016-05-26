using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HomeWork3
{
    public class Menu
    {
        List<User> users = new List<User>();
        string option;
        ISerializable serializer;        
        public void ShowMenu()
        {
            serializer = checkConfigurationFile();
            users = serializer.Read();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Информация о юзерах");
                Console.WriteLine("Колличество юзеров в базе: " + users.Count);
                Console.WriteLine("Id| Name  |  Login  |  Password");
                foreach (User u in users)
                {
                    Console.WriteLine(u.ToString());
                }
                string[] s = Console.ReadLine().ToUpper().Split(' ');
                switch (s[0])
                {
                    case "ADD":
                        
                        User u = new User();
                        Console.WriteLine("Создание нового юзера");
                        Console.WriteLine("Введите Id");


                        int idNewUser = Convert.ToInt32(Console.ReadLine());
                        User existUser = users.Find(i => i.Id == idNewUser);
                        if (existUser == null)
                        {
                            u.Id = idNewUser;
                        }
                        else
                        {
                            Console.WriteLine("Юзер с таким id уже существует. Добавление не удалось. Попробуйте еще раз.");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Введите Name");
                        u.Name = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Введите Login");
                        u.Login = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Введите Password");
                        u.Password = Convert.ToString(Console.ReadLine());
                        users.Add(u);
                        break;
                    case "DEL":
                        if (s.Length== 1)
                        {
                            Console.WriteLine("Команда не распознана. Попробуйте еще раз.");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            User delUser  = users.Find(i => i.Id == Convert.ToInt32(s[1]));
                            if (delUser == null)
                            {
                                Console.WriteLine("Юзер с таким id не найден. Попробуйт еще раз.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                users.Remove(delUser);
                            } 
                            break;
                        }
                    case "EDIT":
                        if (s.Length == 1)
                        {
                            Console.WriteLine("Команда не распознана. Попробуйте еще раз.");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            User editUser = users.Find(i => i.Id == Convert.ToInt32(s[1]));
                            if (editUser == null)
                            {
                                Console.WriteLine("Юзер с таким id не найден. Попробуйт еще раз.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                users.Remove(editUser);
                            }                             

                            Console.WriteLine("Введите новый Id");
                            editUser.Id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Введите новый Name");
                            editUser.Name = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Введите новый Login");
                            editUser.Login = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Введите новый Password");
                            editUser.Password = Convert.ToString(Console.ReadLine());

                            users.Add(editUser);
                            break;
                        }
                    case "HELP":
                        Console.WriteLine("Add - добавить юзера");
                        Console.WriteLine("Del (id нужного юзера) - удалить юзера по id");
                        Console.WriteLine("Edit (id нужного юзера) - редактировать юзера по id");
                        Console.ReadKey();
                        break;
                    case "E":
                        serializer.Write(users);
                        return;
                    default:
                        break;
                }
            }
        }
        private ISerializable checkConfigurationFile()
        {
            while (true)
            {
                option = File.ReadAllText("option.ini");
                if (option == "xml")
                {                    
                    return new XMLSerializer();
                }
                else if (option == "bin")
                {
                    return new BinSerializer();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Конфигурационный файл поврежден. Исправьте и нажмите любую клавишу.");
                    Console.ReadKey();
                }
            }
        }
    }
}