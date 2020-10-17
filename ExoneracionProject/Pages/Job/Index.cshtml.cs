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
    public class IndexModel : PageModel
    {
        private readonly ExoneracionProject.Data.RecruitContext _context;

        public IndexModel(ExoneracionProject.Data.RecruitContext context)
        {
            _context = context;
        }

        public IList<ExoneracionProject.Models.Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Jobs.ToListAsync();
        }
    }
}
