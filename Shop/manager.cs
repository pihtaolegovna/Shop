using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Shop
{
    internal class manager
    {

        static string Login;

        public manager(string login)
        {
            Login = login;
        }


        public void showitems()
        {
            List<User> users = FileManager.ReadUsersFromFile();
            string[] usersamount = new string[users.Count];

            Console.CursorVisible = false;

            string label = Authorization.enteredlogin;
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
            Clear();
            UI.header(true, label, "Кладовщик");
            ReadKey();
        }
    }
}
