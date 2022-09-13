﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeDemo
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches =
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => sandwiches[name];
            set => sandwiches[name] = value;
        }


    }
}
