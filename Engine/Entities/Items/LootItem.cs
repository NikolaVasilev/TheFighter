using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public class LootItem
    {
        public IItem Details { get; set; }
        public int DropPercentage { get; set; }
        public bool IsDefaultItem { get; set; }

        public LootItem(IItem details, int dropPercentage, bool isDefaultItem)
        {
            Details = details;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}
