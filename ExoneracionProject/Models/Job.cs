using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoneracionProject.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string JobName { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }
        public bool Status { get; set; }

        public ICollection<Candidato> Candidatos { get; set; }
    }
}
