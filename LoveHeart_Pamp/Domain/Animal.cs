using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveHeart.Domain
{
    class Animal
    {
        public string Name { get; }
        public int Dob  { get; }
        public Animal(string name, int dob)
        {
            Name = name;
            Dob = dob;
        }
    }
}
