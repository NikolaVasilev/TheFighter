using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    interface Ilocation
    {
         int ID { get; set; }
         string Name { get; set; }
         string Description { get; set; }
        

         bool HasAMonster { get; }
         bool HasAQuest { get; }
         bool DoesNotHaveAnItemRequiredToEnter { get; }
    }
}
