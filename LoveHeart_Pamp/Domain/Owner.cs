using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveHeart.Domain
{
    class Owner
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long  SocSecNr { get; }

        public Owner(string firstName, string lastName, long socSecNr)
        {
            FirstName = firstName;
            LastName = lastName;
            SocSecNr = socSecNr;
        }
    }
}
