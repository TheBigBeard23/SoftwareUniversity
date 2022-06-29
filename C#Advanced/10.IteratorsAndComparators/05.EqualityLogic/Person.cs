using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        readonly string name;
        readonly int age;

        public Person(string name,int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name) == 0)
            {
                return this.age.CompareTo(other.age);
            }
            return this.name.CompareTo(other.name);
        }

        public override bool Equals(object obj)
        {
            return this.name == ((Person)obj).name && this.age == ((Person)obj).age;
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode() + (257 * 53);
        }
    }
}
