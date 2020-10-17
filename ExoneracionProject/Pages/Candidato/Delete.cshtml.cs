using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.Candidato
{
    public class DeleteModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public DeleteModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExoneracionProject.Models.Candidato Candidato { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidato = await _context.Candidatos
                .Include(c => c.Job).FirstOrDefaultAsync(m => m.Id == id);

            if (Candidato == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidato = await _context.Candidatos.FindAsync(id);

            if (Candidato != null)
            {
                _context.Candidatos.Remove(Candidato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
