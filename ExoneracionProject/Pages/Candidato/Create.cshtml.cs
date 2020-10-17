using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExoneracionProject.Data;
using ExoneracionProject.Models;

namespace ExoneracionProject.Pages.Candidato
{
    public class CreateModel : PageModel
    {
        private readonly RecruitContext _context;
        private readonly IHtmlHelper htmlHelper;


        [BindProperty]
        public ExoneracionProject.Models.Candidato Candidato { get; set; }
        [BindProperty]
        public ExoneracionProject.Models.Competences Competences { get; set; }
        [BindProperty]
        public ExoneracionProject.Models.JobExperience JobExperience { get; set; }


        public IEnumerable<SelectListItem> Languages { get; set; }
        public IEnumerable<SelectListItem> Grades { get; set; }


        public CreateModel(RecruitContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Languages = htmlHelper.GetEnumSelectList<Language>();
            Grades = htmlHelper.GetEnumSelectList<Grades>();
            //ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Languages = htmlHelper.GetEnumSelectList<Language>();
                Grades = htmlHelper.GetEnumSelectList<Grades>();
                return Page();
            }

            Candidato.Id = Guid.NewGuid();
            JobExperience.CandidatoId = Candidato.Id;
            Competences.CandidatoId = Candidato.Id;


            _context.Candidatos.Add(Candidato);
            _context.Competences.Add(Competences);
            _context.JobExperiences.Add(JobExperience);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
