﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int Power = 100;
        public Paladin(string name)
            : base(name, Power)
        {
        }
    }
}
