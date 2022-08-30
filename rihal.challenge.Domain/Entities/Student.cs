using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rihal.challenge.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
        public int CountryId { get; set; }

        public Class Class { get; set; }
        public Country Country{ get; set; }
    }
}
