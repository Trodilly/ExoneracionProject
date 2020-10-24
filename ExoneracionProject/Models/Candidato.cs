using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExoneracionProject.Models
{

    public class Candidato
    {
        public Candidato()
        {
            new Job();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NationalIdentifier { get; set; }
        public string Cellphone { get; set; }
        public int Age { get; set; }
        public string Salary { get; set; }
        public int Status { get; set; }

        public Language Languages { get; set; }

        public Grades Grades { get; set; }

        #region Relationships
        public ICollection<Competences> Competences { get; set; }

        public Guid? JobId { get; set; }
        public Job Job { get; set; }

        public ICollection<JobExperience> JobExperiences { get; set; }
        #endregion

    }
}
