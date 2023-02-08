using System;
using System.Collections.Generic;
using static System.Console;
using System.Text;
using System.Linq;
using Shop;

namespace Shop
{
    static class Authorization
    {
        public static string enteredlogin;
        public static void authorization()
        {
            Console.Clear();
            FileManager.ReadUsersFromFile();
            UI.header(false);
            WriteLine("  Логин: ");
            WriteLine("  Пароль: ");

            SetCursorPosition(10, 2);
            enteredlogin = ReadLine();
            string enteredpassword = "";
            SetCursorPosition(10, 3);

            bool run = false;
            while (run)
            {
                ConsoleKeyInfo menuchoosekey = Console.ReadKey();
                string choosekey = (menuchoosekey.Key.ToString());
                switch (choosekey)
                {
                    default:
                        Write("\b \b");
                        Write("*");
                        enteredpassword += choosekey.ToString();
                        break;
                    case "Enter":
                        run = false;
                        break;
                    case "Backspace":
                        try
                        {
                            if (Console.CursorLeft > 10)
                            {
                                enteredpassword.Remove(enteredpassword.Length, 1);
                                SetCursorPosition(CursorLeft-3, CursorTop);
                                Write("\b \b");
                            }
                            else SetCursorPosition(10, CursorTop);

                        }
                        catch (Exception) { }
                        break;
                }
            }
            enteredpassword = ReadLine();
            SetCursorPosition(0, CursorTop+1);
            WriteLine("Вход");
            Console.ReadKey();
            auth(enteredlogin, enteredpassword);
            if (!auth(enteredlogin, enteredpassword)) WriteLine("Неверный логин и/или пароль"); Console.ReadKey(); authorization();
        }
        public static bool auth(string login, string password)
        {
            bool auth = false;

            List<User> users = FileManager.ReadUsersFromFile();

            foreach (User user in users)
            {
                if (!(user.Login != login || user.Password != password))
                {
                    switch (user.Role)
                    {
                        case 0:
                            new admin(login).showallusers(); // Нужен конструктор, принимающий оин аргумент, чтобы попасть в non-static класс. Даже если он публичный, будет запрошен конструктор для инициализации.
                            break;
                        case 1:
                            new hr(login).showallusers();
                            break;
                        case 2:
                            
                            break;
                        case 3:
                            new warehousemanager(login).showitems();
                            break;
                        case 4:
                            new cashier(login).showitems();
                            break;
                    }
                    auth = true;
                }
            }
            return auth;
        }
    }
}