using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public abstract class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int Price { get; set; }

        public Item(int id, string name, string namePlural, int price)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Price = price;
        }
    }
}
