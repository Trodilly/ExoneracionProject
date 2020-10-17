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
    public class DeleteModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public DeleteModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExoneracionProject.Models.Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs.FirstOrDefaultAsync(m => m.Id == id);

            if (Job == null)
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

            Job = await _context.Jobs.FindAsync(id);

            if (Job != null)
            {
                _context.Jobs.Remove(Job);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
