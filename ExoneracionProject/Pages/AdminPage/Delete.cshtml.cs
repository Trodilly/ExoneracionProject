using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.AdminPage
{
    public class DeleteModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public DeleteModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _context.Admins.FirstOrDefaultAsync(m => m.Id == id);

            if (Admin == null)
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

            Admin = await _context.Admins.FindAsync(id);

            if (Admin != null)
            {
                _context.Admins.Remove(Admin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
