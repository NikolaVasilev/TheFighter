﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IItem
    {
       int ID { get; set; }
       string Name { get; set; }
       string NamePlural { get; set; }
       int Price { get; set; }
    } 

}
