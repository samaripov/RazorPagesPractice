using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.AnswerOptions
{
    public class DetailsModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public DetailsModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        public AnswerOption AnswerOption { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answeroption = await _context.AnswerOption.FirstOrDefaultAsync(m => m.Id == id);

            if (answeroption is not null)
            {
                AnswerOption = answeroption;

                return Page();
            }

            return NotFound();
        }
    }
}
