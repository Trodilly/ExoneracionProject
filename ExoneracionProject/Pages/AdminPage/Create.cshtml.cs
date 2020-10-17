using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.AdminPage
{
    public class CreateModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public CreateModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Admin Admin { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Admins.Add(Admin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
