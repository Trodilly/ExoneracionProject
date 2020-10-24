using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExoneracionProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExoneracionProject.Pages
{
    public class ReportModel : PageModel
    {
        private readonly Data.RecruitContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public ReportModel(Data.RecruitContext context,
                            UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }


        [BindProperty]
        public DateTime? StartDateFilter { get; set; }

        public List<Admin> Admins { get; set; }

        public void OnGet()
        {
            Admins = _context.Admins.ToList();
        }
        public async Task<IActionResult> OnPostDateFilter()
        {
            Admins = await _context.Admins.Where(a => a.StartDate >= StartDateFilter).ToListAsync();
            return Page();
        }

    }
}
