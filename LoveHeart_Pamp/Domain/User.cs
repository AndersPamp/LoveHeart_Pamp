using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveHeart.Domain
{
    public class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public char Position { get; }
        public string UserName { get; } //Must be unique, used as key in collection
        public string PassWord { get; }
        public long SocSecNr { get; }
        
        public User(string firstName, string lastName, char position, string userName, string passWord, long socSecNr)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            UserName = userName;
            PassWord = passWord;
            SocSecNr = socSecNr;
        }
    }
}
