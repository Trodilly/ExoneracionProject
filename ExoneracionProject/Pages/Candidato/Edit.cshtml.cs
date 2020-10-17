using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.Candidato
{
    public class EditModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(ExoneracionProject.Data.RecruitContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public IEnumerable<SelectListItem> Languages { get; set; }
        public IEnumerable<SelectListItem> Grades { get; set; }
        [BindProperty]
        public ExoneracionProject.Models.Candidato Candidato { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Languages = htmlHelper.GetEnumSelectList<Language>();
            Grades = htmlHelper.GetEnumSelectList<Grades>();

            Candidato = await _context.Candidatos
                .Include(c => c.Job)
                .Include(c => c.Competences)
                .Include(c => c.JobExperiences)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Candidato == null)
            {
                return NotFound();
            }
          // ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(Candidato.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidatoExists(Guid id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
