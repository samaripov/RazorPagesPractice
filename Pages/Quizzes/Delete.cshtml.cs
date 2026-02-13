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
    public class DeleteModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public DeleteModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quiz Quiz { get; set; } = default!;

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

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz != null)
            {
                Quiz = quiz;
                _context.Quiz.Remove(Quiz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
