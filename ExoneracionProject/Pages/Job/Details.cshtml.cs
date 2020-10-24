using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ExoneracionProject.Models;
using ExoneracionProject.Data;

namespace ExoneracionProject.Pages.Job
{
    public class DetailsModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

        public DetailsModel(ExoneracionProject.Data.RecruitContext context, 
            Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
            NewCandidato = new Models.Candidato();
            NewJob = new Models.Job();
        }
        public ExoneracionProject.Models.Job Job { get; set; }

        public ExoneracionProject.Models.Candidato Candidato { get; set; }
        [BindProperty]
        public ExoneracionProject.Models.Candidato NewCandidato { get; set; }
        [BindProperty]
        public ExoneracionProject.Models.Job NewJob { get; set; }

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
        public async Task<IActionResult> OnPostAsync(Guid jobId, string salary)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Candidato = await _context.Candidatos.FirstOrDefaultAsync(c => c.Id == Guid.Parse(user.Id));

            Candidato.Salary = salary;
            Candidato.JobId = jobId;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostHireAsync()
        {
            Candidato = await _context.Candidatos.FirstOrDefaultAsync(c => c.Id == NewCandidato.Id);
            Job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == NewJob.Id);

            var employee = new Admin()
            {
                Id = Candidato.Id,
                Name = Candidato.Name,
                Nationalidentifier = Candidato.NationalIdentifier,
                StartDate = DateTime.Today.Date,
                JobTittle = Job.JobName,
                Salary = int.Parse(NewCandidato.Salary),
                Status = true,
            };

            _context.Admins.Add(employee);
            await _context.SaveChangesAsync();
            _context.Candidatos.Remove(Candidato);
            await _context.SaveChangesAsync();
            _context.Jobs.Remove(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
