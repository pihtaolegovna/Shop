using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Shop
{
    static class FileManager
    {
        public static string jsonpath = $"C:/epicshopmanager/";
        public static string userjsonpath = $"C:/epicshopmanager/Users.json";
        public static string itemjsonpath = $"C:/epicshopmanager/Items.json";
        public static string cashjsonpath = $"C:/epicshopmanager/Cash.json";
        static public void SaveToFile<T>(T list, string path)
        {
            if (!File.Exists(jsonpath + path))
            {
                FileStream fileStream = File.Create(jsonpath + path);
                fileStream.Dispose();
            }

            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(userjsonpath, json);
        }

        static public List<User> ReadUsersFromFile()
        {
            List<User> users;
            if (!File.Exists(userjsonpath))
            {
                try
                {
                    Directory.CreateDirectory(jsonpath);
                    FileStream fileStream = File.Create(userjsonpath);
                    fileStream.Dispose();

                    users = new List<User>
                    {
                    new User(0, 0, "Admin", "Admin")
                    };
                    SaveToFile(users, "users.json");
                    Console.WriteLine($"Обнаружено отсутствие файлов. Файл .JSON успешно создан по пути {userjsonpath}\nНажмите любую клавишу для перехода к авторизации");
                }
                catch (Exception)
                {
                    users = new List<User>
                {
                    new User(0, 0, "Admin", "Admin")
                };
                    Console.WriteLine("Обнаружено отсутствие файлов. Ошибка создания файла .json. Отключение");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                string usersInfo = File.ReadAllText(userjsonpath);
                users = JsonConvert.DeserializeObject<List<User>>(usersInfo);
            }
            return users;
        }
        static public List<T> ReadFromFile<T>(string path)
        {
            List<T> result;
            if (!File.Exists(jsonpath + path))
            {
                FileStream fileStream = File.Create(jsonpath + path);
                fileStream.Dispose();
                Console.WriteLine($"Обнаружено отсутствие файлов. Файл .JSON успешно создан по пути {userjsonpath}\nНажмите любую клавишу для перехода к авторизации");
                Console.ReadKey();
            }

            string resultInfo = File.ReadAllText(jsonpath + path);
            result = JsonConvert.DeserializeObject<List<T>>(resultInfo);

            return result;
        }
    }
}