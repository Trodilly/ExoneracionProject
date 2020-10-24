using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.Job
{
    public class CreateModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public CreateModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
            Job = new Models.Job();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ExoneracionProject.Models.Job Job { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
