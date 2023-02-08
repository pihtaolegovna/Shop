using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Shop
{
    internal class hr : ICrud
    {
        string Login;

        public hr(string login)
        {
            Login = login;
        }

        public void Create()
        {

        }
        public void Read()
        {

        }
        public void userinfo(int Index)
        {
            Console.Clear();

            Console.CursorVisible = false;

            List<User> users = FileManager.ReadUsersFromFile();
            int SelectedIndex = 0;

            string name = users[Index].Name;
            string surname = users[Index].Surname;
            string patronymic = users[Index].Patronymic;
            string dateOfBirth = users[Index].DateOfBirth;
            string job = users[Index].Patronymic;
            long passportInfo = users[Index].PassportInfo;
            int salary = users[Index].Salary;

            Console.WriteLine("Просмотр данных сотрудника");

            Console.SetCursorPosition(0, 1);
            if (users[Index].Name == null)
            {
                Console.WriteLine($"   Имя: не назначено");
            }
            else
            {
                Console.WriteLine($"   Имя: {users[Index].Name}");
            }

            Console.SetCursorPosition(0, 2);
            if (users[Index].Surname == null)
            {
                Console.WriteLine($"   Фамилия: не назначена");
            }
            else
            {
                Console.WriteLine($"   Фамилия: {users[Index].Surname}");
            }

            Console.SetCursorPosition(0, 3);
            if (users[SelectedIndex].Patronymic == null)
            {
                Console.WriteLine($"   Очество: не назначено");
            }
            else
            {
                Console.WriteLine($"   Очество: {users[Index].Patronymic}");
            }

            Console.SetCursorPosition(0, 4);
            if (users[Index].DateOfBirth == null)
            {
                Console.WriteLine($"   Дата рождения [DD-MM-YYYY]: не назначена");
            }
            else
            {
                Console.WriteLine($"   Дата рождения [DD-MM-YYYY]: {users[Index].DateOfBirth}");
            }

            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"   Зарплата: {users[Index].Salary}");

            Console.SetCursorPosition(0, 6);
            if (users[Index].PassportInfo == 0)
            {
                Console.WriteLine($"   Серия и номер паспорта: не назначена");
            }
            else
            {
                Console.WriteLine($"   Серия и номер паспорта: {users[Index].PassportInfo}");
            }

            Console.SetCursorPosition(0, 7);
            if (users[Index].Job == null)
            {
                Console.WriteLine($"   Должность: не назначена");
            }
            else
            {
                Console.WriteLine($"   Должность: {users[Index].Job}");
            }
            ReadKey();
            showallusers();
        }
        public void Update(int Index)
        {
            Console.Clear();

            Console.CursorVisible = false;

            List<User> users = FileManager.ReadUsersFromFile();
            int SelectedIndex = 0;

            string name = users[Index].Name;
            string surname = users[Index].Surname;
            string patronymic = users[Index].Patronymic;
            string dateOfBirth = users[Index].DateOfBirth;
            string job = users[Index].Patronymic;
            long passportInfo = users[Index].PassportInfo;
            int salary = users[Index].Salary;

            Console.WriteLine("Изменение данных сотрудника");

            Console.SetCursorPosition(0, 1);
            if (users[Index].Name == null)
            {
                Console.WriteLine($"   Имя: не назначено");
            }
            else
            {
                Console.WriteLine($"   Имя: {users[Index].Name}");
            }

            Console.SetCursorPosition(0, 2);
            if (users[Index].Surname == null)
            {
                Console.WriteLine($"   Фамилия: не назначена");
            }
            else
            {
                Console.WriteLine($"   Фамилия: {users[Index].Surname}");
            }

            Console.SetCursorPosition(0, 3);
            if (users[SelectedIndex].Patronymic == null)
            {
                Console.WriteLine($"   Очество: не назначено");
            }
            else
            {
                Console.WriteLine($"   Очество: {users[Index].Patronymic}");
            }

            Console.SetCursorPosition(0, 4);
            if (users[Index].DateOfBirth == null)
            {
                Console.WriteLine($"   Дата рождения [DD-MM-YYYY]: не назначена");
            }
            else
            {
                Console.WriteLine($"   Дата рождения [DD-MM-YYYY]: {users[Index].DateOfBirth}");
            }

            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"   Зарплата: {users[Index].Salary}");

            Console.SetCursorPosition(0, 6);
            if (users[Index].PassportInfo == 0)
            {
                Console.WriteLine($"   Серия и номер паспорта: не назначена");
            }
            else
            {
                Console.WriteLine($"   Серия и номер паспорта: {users[Index].PassportInfo}");
            }

            Console.SetCursorPosition(0, 7);
            if (users[Index].Job == null)
            {
                Console.WriteLine($"   Должность: не назначена");
            }
            else
            {
                Console.WriteLine($"   Должность: {users[Index].Job}");
            }

            SetCursorPosition(0, 8); WriteLine("   Сохранить");
            SetCursorPosition(0, 9); WriteLine("   Выйти");

            bool right = false;
            while (!right)
            {
                Control.arrows(9, 1);
                switch (CursorTop-1)
                {
                    case 0:
                        Console.SetCursorPosition(7, 1);
                        Console.Write("                 ");

                        bool isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(7, 1);
                                name = Console.ReadLine();


                                if (name == "")
                                {
                                    name = users[Index].Name;
                                }

                                isCorrect = true;
                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 1);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" Имя: Ошибка. Неправельный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 1);
                                Console.Write(" Имя:                                                     ");
                            }
                        }

                        Console.SetCursorPosition(7, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(name);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(7, 1);
                        Console.Write(name);
                        SelectedIndex = 1;

                        break;

                    case 1:
                        Console.SetCursorPosition(10, 2);
                        Console.Write("                                                       ");

                        isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(11, 2);
                                surname = Console.ReadLine();


                                if (surname == "")
                                {
                                    surname = users[Index].Surname;
                                }

                                isCorrect = true;
                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 2);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  Фамилия: Ошибка. Неправельный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 2);
                                Console.Write("  Фамилия:                                                     ");
                            }
                        }

                        Console.SetCursorPosition(11, 2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(surname);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(11, 2);
                        Console.Write(surname);

                        SelectedIndex = 2;
                        break;

                    case 2:
                        Console.SetCursorPosition(12, 3);
                        Console.Write("                                                       ");

                        isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(11, 3);
                                patronymic = Console.ReadLine();


                                if (patronymic == "")
                                {
                                    patronymic = users[Index].Patronymic;
                                }

                                isCorrect = true;
                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 3);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  Отчество: Ошибка. Неправильный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 3);
                                Console.Write("  Отчество:                                                     ");
                            }
                        }

                        Console.SetCursorPosition(12, 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(patronymic);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(12, 3);
                        Console.Write(patronymic);

                        SelectedIndex = 3;
                        break;

                    case 3:
                        Console.SetCursorPosition(30, 4);
                        Console.Write("                                                       ");

                        isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(30, 4);
                                dateOfBirth = Console.ReadLine();

                                if (dateOfBirth == "")
                                {
                                    dateOfBirth = users[Index].DateOfBirth;
                                    break;
                                }

                                DateTime dateTimeObj;
                                isCorrect = DateTime.TryParse(dateOfBirth, out dateTimeObj);

                                if (isCorrect == false)
                                {
                                    Console.SetCursorPosition(0, 4);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("  Дата рождения [DD-MM-YYYY]:  Ошибка. Неправельный ввод.");
                                    Thread.Sleep(1000);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(0, 4);
                                    Console.Write("  Дата рождения [DD-MM-YYYY]:                                                       ");
                                }
                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 4);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  Дата рождения [DD-MM-YYYY]:  Ошибка. Неправельный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 4);
                                Console.Write("  Дата рождения [DD-MM-YYYY]:                                                       ");
                            }
                        }

                        Console.SetCursorPosition(30, 4);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(dateOfBirth);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(30, 4);
                        Console.Write(dateOfBirth);

                        SelectedIndex = 4;
                        break;

                    case 4:
                        Console.SetCursorPosition(12, 5);
                        Console.Write("                                                       ");

                        isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(12, 5);
                                salary = Convert.ToInt32(Console.ReadLine());
                                isCorrect = true;
                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 5);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  Зарплата: Ошибка. Неправильный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 5);
                                Console.Write("  Зарплата:                                                     ");
                            }
                        }

                        Console.SetCursorPosition(12, 5);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(salary);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(12, 5);
                        Console.Write(salary);

                        SelectedIndex = 5;
                        break;

                    case 5:
                        Console.SetCursorPosition(26, 6);
                        Console.Write("************                                                       ");

                        isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(26, 6);
                                passportInfo = Convert.ToInt64(Console.ReadLine());
                                isCorrect = true;

                                if (Convert.ToString(passportInfo).Length != 12)
                                {
                                    Console.SetCursorPosition(0, 6);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("  Серия и номер паспорта: Ошибка. Вы должны напечатать 12 цифр.");
                                    Thread.Sleep(1000);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(0, 6);
                                    Console.Write("  Серия и номер паспорта: ************                                            ");
                                    isCorrect = false;
                                }

                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 6);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  Серия и номер паспорта: Ошибка. Неправельный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 6);
                                Console.Write("  Серия и номер паспорта: ************                                                    ");
                            }
                        }

                        Console.SetCursorPosition(26, 6);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(passportInfo);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(26, 6);
                        Console.Write(passportInfo);

                        SelectedIndex = 6;
                        break;

                    case 6:
                        Console.SetCursorPosition(13, 7);
                        Console.Write("                                                       ");

                        isCorrect = false;

                        while (!isCorrect)
                        {
                            try
                            {
                                Console.SetCursorPosition(13, 7);
                                job = Console.ReadLine();


                                if (job == "")
                                {
                                    job = users[Index].Job;
                                }

                                isCorrect = true;

                            }
                            catch (Exception)
                            {
                                Console.SetCursorPosition(0, 7);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  Должность: Ошибка. Неправельный ввод.");
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                Console.SetCursorPosition(0, 7);
                                Console.Write("  Должность:                                                     ");
                            }
                        }

                        Console.SetCursorPosition(13, 7);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(job);
                        Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.SetCursorPosition(13, 7);
                        Console.Write(job);

                        SelectedIndex = 6;
                        break;
                    case 7:
                        {
                            users[Index] = new User((int)users[Index].ID, users[Index].Role, users[Index].Login, users[Index].Password, name, surname, patronymic, dateOfBirth, job, passportInfo, salary);
                            FileManager.SaveToFile(users, "Users.json");

                            Console.SetCursorPosition(3, 8);
                            Console.Write("Данные сотрудника изменены.");
                            Console.ReadLine();
                            Update(Index);
                            break;
                        }
                    case 8:
                        {
                            showallusers();
                            break;
                        }
                }
            }
        }
        public void Delete(int Index)
        {
            List<User> users = FileManager.ReadUsersFromFile();

            string name = null;
            string surname = null;
            string patronymic = null;
            string dateOfBirth = null;
            string job = null;
            long passportInfo = 0;
            int salary = 0;

            users[Index] = new User((int)users[Index].ID, users[Index].Role, users[Index].Login, users[Index].Password, name, surname, patronymic, dateOfBirth, job, passportInfo, salary);
            FileManager.SaveToFile(users, "Users.json");

            Console.SetCursorPosition(3, 8);
            Console.Write("Данные сотрудника изменены.");
            Console.ReadKey();
            Update(Index);
            showallusers();
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

            UI.header(true, label, "Менеджер Персонала");
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Логин                              ФИО           ");

            for (int i = 0; i < usersamount.Length; i++)
            {
                usersamount[i] = users[i].Login;

                Console.SetCursorPosition(3, i + 3);
                Console.WriteLine(users[i].Login);

                Console.SetCursorPosition(33, i + 3);
                Console.WriteLine(users[i].Surname + " " + users[i].Name + " " + users[i].Patronymic);
            }
            SetCursorPosition(65, 2); Write("");
            SetCursorPosition(65, 3); Write("2 Просмотр");
            SetCursorPosition(65, 4); Write("3 Изменение");
            SetCursorPosition(65, 5); Write("4 Удаление");
            hrcontrols(usersamount.Count(), 3);
        }
        public void hrcontrols(int damount, int startheight = 2, int gap = 1)
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
                            userinfo(CursorTop-3);
                            break;
                        }
                    case "D3":
                        {
                            Update(selected);
                            break;
                        }
                    case "D4":
                        {
                            Delete(CursorTop-3);
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
