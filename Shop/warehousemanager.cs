using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Shop
{
    internal class warehousemanager : ICrud
    {

        static string Login;

        public warehousemanager(string login)
        {
            Login = login;
        }
        public void Update(int Index)
        {
            Console.Clear();
            Console.CursorVisible = false;

            List<item> items = FileManager.ReadFromFile<item>("items.json");
            List<User> users = FileManager.ReadUsersFromFile();




            Console.WriteLine("Изменение данных о товаре");


            bool right = false;
            string name = "";
            int cost = -1;
            int amount= -1;
            int id = -1;
            while (!right)
            {
                SetCursorPosition(3, 2); WriteLine($"ID: ");
                SetCursorPosition(3, 3); WriteLine($"Имя товара: ");
                SetCursorPosition(3, 4); WriteLine($"Цена:       ");
                SetCursorPosition(3, 5); WriteLine($"Количество: ");
                SetCursorPosition(3, 6); WriteLine($"Сохранить ");
                SetCursorPosition(3, 7); WriteLine($"Выйти ");
                Control.arrows(6, 2);
                switch (CursorTop-2)
                {
                    case 0:
                        SetCursorPosition(15, 3);
                        Write("                                      ");
                        SetCursorPosition(15, 3);
                        while (id < 0)
                        {
                            SetCursorPosition(15, 3);
                            Write("                 ");
                            try
                            {
                                id = Convert.ToInt32(ReadLine());
                            }
                            catch (Exception)
                            {
                                SetCursorPosition(15, 3);
                                Write("Ошибка ввода");
                            }
                            ReadKey();
                        }
                        break;
                    case 1:
                        SetCursorPosition(15, 3);
                        Write("                                      "); 
                        SetCursorPosition(15, 3);
                        name = Console.ReadLine();
                        break;
                    case 2:
                        while (amount < 0)
                        {
                            SetCursorPosition(15, 4);
                            Write("                                      ");
                            SetCursorPosition(15, 4);
                            try
                            {
                                amount = Convert.ToInt32(ReadLine());
                            }
                            catch (Exception)
                            {
                                SetCursorPosition(15, 4);
                                Write("Ошибка ввода");
                            }
                            if (amount < 0) SetCursorPosition(15, 4); Write("Ошибка ввода");
                            ReadKey();
                        }
                        
                         
                        break;
                    case 3:
                        while (cost < 0)
                        {
                            SetCursorPosition(15, 5);
                            Write("                                      ");
                            SetCursorPosition(15, 5);
                            try
                            {
                                cost = Convert.ToInt32(ReadLine());
                            }
                            catch (Exception)
                            {
                                SetCursorPosition(15, 4);
                                Write("Ошибка ввода");
                            }
                            if (amount < 0) SetCursorPosition(15, 4); Write("Ошибка ввода");
                            ReadKey();
                        }

                        break;
                    case 4:
                        if (name == "" || cost == -1 || amount == -1)
                        {
                            Console.SetCursorPosition(2, 6);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Ошибка. Поля не заполнены.");
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.SetCursorPosition(2, 6);
                            Console.Write("                                                    ");
                        }
                        else
                        {
                            items.Add(new item(id, name, cost, amount));
                            FileManager.SaveToFile(items, "items.json");

                            Console.SetCursorPosition(2, 7);
                            Console.Write("Успех. Товар создан.");
                            showitems();
                        }
                        break;
                    case 5:
                        showitems();
                        break;
                }
            }

        }
        public void admincontrols(int damount, int startheight = 2, int gap = 1)
        {
            int selector = 0;
            int selected = 0;
            List<User> users = FileManager.ReadUsersFromFile();

            Console.SetCursorPosition(1, startheight);
            Console.SetCursorPosition(1, startheight);
            bool run = true;
            while (run)
            {
                ConsoleKeyInfo menuchoosekey = Console.ReadKey();
                string choosekey = (menuchoosekey.Key.ToString());
                switch (choosekey)
                {
                    case "UpArrow":
                        Console.SetCursorPosition(1, selector+startheight);
                        selector--;
                        break;
                    case "DownArrow":
                        Console.SetCursorPosition(1, selector+startheight);
                        selector++;
                        break;
                    case "Enter":
                        selected = selector;
                        run = false;
                        break;
                    case "D1":
                        {
                            Create();
                            break;
                        }
                    case "D2":
                        {
                            Read();
                            break;
                        }
                    case "D3":
                        {
                            Update(selected);
                            break;
                        }
                    case "D4":
                        {
                            Delete(selected);
                            showitems();
                            break;
                        }
                    case "Escape":
                        {
                            Authorization.authorization();
                            break;
                        }
                }
                if (selector < 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                    Console.Write("  ");
                    selector = damount - gap;
                }

                if (selector > damount - 1)
                {
                    Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                    Console.Write("  ");
                    selector = 0;
                    Console.SetCursorPosition(1, 0);
                    Console.SetCursorPosition(1, startheight);
                }
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("  ");
                Console.SetCursorPosition(1, startheight);
                Console.SetCursorPosition(1, selector+startheight);
                Console.Write(selector + 1);

            }
        }

        public void Delete(int Index)
        {
            List<item> items = FileManager.ReadFromFile<item>("items.json");
            items.RemoveAt(Index);
            FileManager.SaveToFile(items, "items.json");
        }

        public void Read()
        {

        }

        public void showitems()
        {
            Console.Clear();

            List<item> items = FileManager.ReadFromFile<item>("items.json");
            List<User> users = FileManager.ReadUsersFromFile();


            if (items == null)
            {
                Console.WriteLine("Нет товаров. Нажмите любую клавишу чтобы их добавть.");
                Console.ReadKey();
                Create();
            }
            items = FileManager.ReadFromFile<item>("items.json");
            string[] itemamount = new string[items.Count];
            string label = Login;

            foreach (User user in users)
            {
                if (user.Login == Login)
                {
                    if (user.Name != null)
                    {
                        label = user.Name;
                        break;
                    }
                }
            }

            UI.header(true, label, "Кладовщик");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("ID  Название              Цена         Количество   ");

            for (int i = 0; i < itemamount.Length; i++)
            {
                itemamount[i] = items[i].Name;

                Console.SetCursorPosition(4, i + 3);
                Console.WriteLine(items[i].ID);

                Console.SetCursorPosition(7, i + 3);
                Console.WriteLine(items[i].Name);
                SetCursorPosition(29, i + 3);
                WriteLine(items[i].Cost);
                SetCursorPosition(42, i + 3);
                WriteLine(items[i].Amount);
            }
            SetCursorPosition(65, 2); Write("1 Создание");
            SetCursorPosition(65, 3); Write("3 Изменение");
            SetCursorPosition(65, 4); Write("4 Удаление");
            ReadKey();
            admincontrols(itemamount.Count(), 3);
        }

        public void Create()
        {
            
        }
    }
}
