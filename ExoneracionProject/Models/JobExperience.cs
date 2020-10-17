using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoneracionProject.Models
{
    public class JobExperience
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTittle { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Salary { get; set; }

        public Guid CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
    }
}
