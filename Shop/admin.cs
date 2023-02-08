using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;

namespace Shop
{
    public class admin : ICrud
    {
        public void Create()
        {
            int enteredid = -1;
            string login = "";
            string password = "";
            int role = -1;
            List<User> users = FileManager.ReadUsersFromFile(); // грузим актуальные данные из жесон и начинаем создавать
            Clear();
            bool allisalright = false;
            while (!(allisalright))
            {
                SetCursorPosition(0, 0);
                Write("Создание нового пользователя");
                SetCursorPosition(3, 1);
                WriteLine("ID пользователя: ");
                SetCursorPosition(3, 2);
                WriteLine("Логин пользователя: ");
                SetCursorPosition(3, 3);
                WriteLine("Пароль пользователя: ");
                SetCursorPosition(3, 4);
                WriteLine("Роль пользователя: ");
                SetCursorPosition(3, 5);
                WriteLine("Сохранить: ");
                SetCursorPosition(3, 6);
                WriteLine("Выйти: ");
                Control.arrows(6, 1);
                switch (CursorTop)
                {
                    case 1:
                        {
                            bool right = false;
                            while (!right)
                            {
                                SetCursorPosition(20, 1);
                                CursorVisible = true;
                                try
                                {
                                    enteredid = Convert.ToInt32(ReadLine());
                                    foreach (User user in users)
                                    {
                                        if (user.ID == enteredid)
                                        {
                                            SetCursorPosition(3, 1);
                                            Write("ID Занято              ");
                                            Thread.Sleep(1000);
                                            SetCursorPosition(3, 1);
                                            Write("ID пользователя:        ");
                                            right = true;

                                            break;

                                        }
                                        else if (enteredid < 0)
                                        {
                                            SetCursorPosition(3, 1);
                                            Write("ID < 0.                ");
                                            Thread.Sleep(1000);
                                            SetCursorPosition(3, 1);
                                            Write("ID пользователя:       ");
                                            SetCursorPosition(21, 1);
                                            break;
                                        }
                                        else
                                        {
                                            SetCursorPosition(3, 1);
                                            WriteLine($"ID пользователя: {enteredid}");
                                            CursorVisible = false;
                                            right = true;

                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    SetCursorPosition(3, 1);
                                    Write("неверное значение ID");
                                    Thread.Sleep(1000);
                                    SetCursorPosition(3, 1);
                                    Write("ID пользователя:       ");
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            Console.SetCursorPosition(22, 2);
                            Console.Write("                                                       ");

                            allisalright = false;
                            bool right = false;

                            while (!right)
                            {
                                Console.SetCursorPosition(23, 2);
                                login = Console.ReadLine();

                                foreach (User user in users)
                                {
                                    if (user.Login == login)
                                    {
                                        Console.SetCursorPosition(2, 2);
                                        Console.Write("Логин пользователя: Ошибка. Пользователь с таким логином уже существует.");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(2, 2);
                                        Console.Write("Логин пользователя:                                                                         ");
                                        Console.SetCursorPosition(23, 2);
                                        allisalright = false;
                                        break;
                                    }
                                    else if (login == "")
                                    {
                                        Console.SetCursorPosition(2, 2);
                                        Console.Write("Логин пользователя: Ошибка. Пользователь не может быть с пустым логином.");
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(2, 2);
                                        Console.ResetColor();
                                        Console.Write("Логин пользователя:                                                                         ");
                                        Console.SetCursorPosition(23, 2);
                                        allisalright = false;
                                        break;
                                    }
                                    else
                                    {
                                        right = true;
                                    }
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.SetCursorPosition(23, 3);
                            Console.Write("                                                       ");
                            bool right = false;

                            while (!right)
                            {
                                Console.SetCursorPosition(24, 3);
                                password = Console.ReadLine();


                                if (password == "")
                                {
                                    Console.SetCursorPosition(3, 3);
                                    Console.Write("Пароль пользователя: Нельзя оставить поле пустым             ");
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(3, 3);
                                    Console.ResetColor();
                                    Console.Write("Пароль пользователя:                                          ");
                                    Console.SetCursorPosition(24, 3);
                                    allisalright = false;
                                    break;
                                }
                                else
                                {
                                    right = true;
                                }
                            }

                            Console.SetCursorPosition(23, 3);
                            Console.Write(password);
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(23, 3);
                            Console.Write(password);
                            break;
                        }
                    case 4:
                        {
                            Console.SetCursorPosition(21, 4);
                            Console.Write("                 ");

                            allisalright = false;
                            bool right = false;
                            while (!right)
                            {
                                try
                                {
                                    Console.SetCursorPosition(21, 4);
                                    role = Convert.ToInt32(Console.ReadLine());

                                    foreach (User user in users)
                                    {
                                        if (role < 0 || role > 4)
                                        {
                                            Console.SetCursorPosition(3, 4);
                                            Console.Write("Роль пользователя: Ошибка. Такой роли не существует.");
                                            Thread.Sleep(1000);
                                            Console.SetCursorPosition(3, 4);
                                            Console.Write("Роль пользователя:                                                ");
                                            allisalright = false;
                                            break;
                                        }
                                        else
                                        {
                                            right = true;
                                        }
                                    }

                                }
                                catch (Exception)
                                {
                                    Console.SetCursorPosition(2, 4);
                                    Console.Write("Роль пользователя: Ошибка. Неправельный ввод.");
                                    Thread.Sleep(1000);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(2, 4);
                                    Console.Write("Роль пользователя:                                                ");
                                }
                            }

                            Console.SetCursorPosition(21, 4);
                            Console.Write(role);
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.SetCursorPosition(21, 4);
                            Console.Write(role);
                            break;
                        }
                    case 5:

                        if (enteredid == -1 || role == -1 || login == "" || password == "")
                        {
                            Console.SetCursorPosition(2, 5);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Ошибка. Поля не заполнены.");
                            Thread.Sleep(1000);
                            Console.ResetColor();
                            Console.SetCursorPosition(2, 5);
                            Console.Write("                                                    ");
                        }
                        else
                        {
                            users.Add(new User(enteredid, role, login, password));
                            FileManager.SaveToFile(users, "Users.json");

                            Console.SetCursorPosition(2, 7);
                            Console.Write("Успех. Ползователь создан.");
                            showallusers();
                        }
                        break;
                    case 6:
                        showallusers();
                        break;
                }
            }



        }
        public void Update(int index)
        {

        }
        public void Delete(int index)
        {
            List<User> users = FileManager.ReadUsersFromFile();
            users.RemoveAt(index+1);
            FileManager.SaveToFile(users, "Users.json");
        }
        public void Read()
        {

        }
        string Login;

        public admin(string login)
        {
            Login = login;
        }
        public void showallusers()
        {
            Console.Clear();



            List<User> users = FileManager.ReadUsersFromFile();
            string[] usersamount = new string[users.Count];

            Console.CursorVisible = false;

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

            UI.header(true, label, Roles.Admin.ToString());


            Console.SetCursorPosition(0, 2);
            WriteLine("    ID Логин                  Роль\n\n");
            for (int i = 0; i < usersamount.Length; i++)
            {
                string role = "";
                usersamount[i] = users[i].ID + "  " + users[i].Login;

                Console.SetCursorPosition(4, i + 3);
                Console.WriteLine(users[i].ID + "  " + users[i].Login);
                switch (users[i].Role)
                {
                    case (int)Roles.Admin:
                        role = "Администратор";
                        break;
                    case (int)Roles.HR:
                        role = "Mенеджер персонала";
                        break;
                    case (int)Roles.Manager:
                        role = "Бухгалтер";
                        break;
                    case (int)Roles.WarehouseManager:
                        role = "Cклад-менеджер";
                        break;
                    case (int)Roles.Cashier:
                        role = "Кассир";
                        break;
                }
                SetCursorPosition(30, i + 3);
                WriteLine(role);
            }
            SetCursorPosition(65, 2); Write("1 Создать");
            SetCursorPosition(65, 3); Write("2 Просмотр");
            SetCursorPosition(65, 4); Write("3 Изменение");
            SetCursorPosition(65, 5); Write("4 Удаление");
            admincontrols(usersamount.Count(), 3);
        }
        public void admincontrols(int damount, int startheight = 2, int gap = 1)
        {
            int selector = 0;
            int selected = 0;
            List<User> users = FileManager.ReadUsersFromFile();
            //здесь ну очень нужен лист для айтемов(юзеров)

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
                            showallusers();
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
    }
}
