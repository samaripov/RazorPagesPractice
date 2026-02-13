using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    public class DetailsModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public DetailsModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; } = default!;
        public IList<Question> Questions { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FirstOrDefaultAsync(m => m.Id == id);
            if (quiz is not null)
            {
                Quiz = quiz;
                
                Questions = await _context.Question.Where(q => q.QuizId == quiz.Id).ToListAsync();

                return Page();
            }

            return NotFound();
        }
    }
}
