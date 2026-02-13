using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public CreateModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int quizId)
        {   
            var quiz = await _context.Quiz.FirstOrDefaultAsync(q => q.Id == quizId);
            QuizTitle = quiz.Title;
            ViewData["QuizId"] = quizId;
            return Page();
        }
        public string QuizTitle { get; set; } = "Quiz";
        [BindProperty]
        public Question Question { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                // For example, output the errors to the console
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                return Page();
            }
            
            _context.Question.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Details", new { id = Question.QuizId });
        }
    }
}
