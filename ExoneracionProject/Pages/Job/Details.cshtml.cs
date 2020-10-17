using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.Job
{
    public class DetailsModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public DetailsModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        public ExoneracionProject.Models.Job Job { get; set; }
        [BindProperty]
        public ExoneracionProject.Models.Candidato Candidato { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs
                .Include(j => j.Candidatos)
                    .ThenInclude(c=>c.Competences)
                .Include(j => j.Candidatos)
                    .ThenInclude(c => c.JobExperiences)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            _context.Candidatos.Attach(Candidato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
