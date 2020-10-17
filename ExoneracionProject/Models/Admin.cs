using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoneracionProject.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Nationalidentifier { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public string JobTittle { get; set; }
        public int Salary { get; set; }
        public bool Status { get; set; }
    }
}
