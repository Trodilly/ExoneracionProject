using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoneracionProject.Models
{
    public class Competences
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public Guid CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
    }
}
