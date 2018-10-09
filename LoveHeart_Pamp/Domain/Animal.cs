using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveHeart.Domain
{
    class Animal
    {
        public string TypeOfAnimal { get; }
        public string Name { get; }
        public DateTime Dob { get; }
        public int IdNr { get; }  //should be automatically assigned How????
        public Owner Owner { get; }
        public Animal(string typeOfAnimal, string name, DateTime dob, int idNr, Owner owner)
        {
            TypeOfAnimal = typeOfAnimal;
            Name = name;
            Dob = dob;
            IdNr = idNr;   // should be automatically assigned  How????
            Owner = owner;
        }
    }
}
