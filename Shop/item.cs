using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    internal class item
    {
        public int ID;
        public string Name;
        public int Cost;
        public int Amount;

        public item(int id, string name, int cost, int amount)
        {
            ID = id;
            Name = name;
            Cost = cost;
            Amount = amount;
        }
    }
}
