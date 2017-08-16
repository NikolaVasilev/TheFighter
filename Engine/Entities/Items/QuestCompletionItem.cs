using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public class QuestCompletionItem
    {
        public IItem Details { get; set; }
        public int Quantity { get; set; }

        public QuestCompletionItem(IItem details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
