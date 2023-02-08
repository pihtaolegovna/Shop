using Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager.ReadUsersFromFile();
            Authorization.authorization();
        }

    }
}
