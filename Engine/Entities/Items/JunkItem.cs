using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class JunkItem : Item
    {
        public JunkItem(int id, string name, string namePlural, int price) : base(id, name, namePlural, price)
        {
        }
    }
}
