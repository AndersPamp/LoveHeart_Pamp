using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveHeart.Domain
{
    class Schedule
    {
        public DateTime AppointmentDate { get; set; }
        public Owner Owner { get; }
        public Animal Animal { get; }
        public string Problem { get; set; }

        public Schedule(DateTime appointmentDate, Owner owner, Animal animal, string problem)
        {
            AppointmentDate = appointmentDate;
            Owner = owner;
            Animal = animal;
            Problem = problem;
        }
    }
}
