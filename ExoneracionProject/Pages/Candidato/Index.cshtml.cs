using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExoneracionProject.Data;
using ExoneracionProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExoneracionProject.Pages.Candidato
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public IndexModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        public IList<ExoneracionProject.Models.Candidato> Candidato { get;set; }



        public async Task OnGetAsync()
        {
            Candidato = await _context.Candidatos
                .Include(c => c.Job)
                .Include(c => c.Competences)
                .Include(c => c.JobExperiences)
                .ToListAsync();
        }
    }
}
