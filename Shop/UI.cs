using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Shop
{
    internal class UI
    {
        public static void authorization_window()
        {
            FileManager.ReadUsersFromFile();
            header(false);
            WriteLine("   Логин: \n    Пароль: ");
            SetCursorPosition(10, 2);
            WriteLine();
        }
        public static void admin_window()
        {

        }
        public static void cashier_window()
        {

        }
        public static void hr_window()
        {

        }
        public static void wirehouse_window()
        {

        }
        public static void manager_window()
        {

        }
        public static void header(bool authorized, string name = "", string role = "")
        {
            if (authorized)
            {
                WriteLine($"│ Epicshopmanager  1.0 │ Добро пожаловать, {name}. Вы вошли как {role}");
                WriteLine("└──────────────────────┴────────────────────────────────────────────────────────────────────────┘");
                Console.SetCursorPosition(96, 0); Write("│"); SetCursorPosition(0, 3);
            }
            else WriteLine("│ Epicshopmanager  1.0 │ Добро пожаловать │\n" +
                           "└──────────────────────┴──────────────────┘");
        }
    }
    public static class Control
    {
        public static int selector = 0;
        public static int selected;
        public static int damount = 0;
        public static List<string> options = new List<string>();
        public static void arrows(int damount, int startheight = 2, int gap = 1)
        {
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
                    default:
                        selected = selector;
                        run = false;
                        break;
                }
                if (selector < 0)
                {
                    SetCursorPosition(CursorLeft-1, CursorTop);
                    Write("  ");
                    selector = damount - gap;
                }

                if (selector > damount - 1)
                {
                    SetCursorPosition(CursorLeft-1, CursorTop);
                    Write("  ");
                    selector = 0;
                    SetCursorPosition(1, 0);
                    SetCursorPosition(1, startheight);
                }
                SetCursorPosition(0, CursorTop);
                Write("  ");
                SetCursorPosition(1, startheight);
                SetCursorPosition(1, selector+startheight);
                Write(selector + 1);
            }
        }
    }
}
