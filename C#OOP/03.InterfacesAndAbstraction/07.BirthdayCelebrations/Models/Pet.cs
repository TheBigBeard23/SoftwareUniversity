using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name,DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
