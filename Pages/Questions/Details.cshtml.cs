using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Questions
{
    public class DetailsModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public DetailsModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        public Question Question { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? quizId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FirstOrDefaultAsync(m => m.Id == id);
            ViewData["QuizId"] = quizId;

            if (question is not null)
            {
                Question = question;

                return Page();
            }

            return NotFound();
        }
    }
}
