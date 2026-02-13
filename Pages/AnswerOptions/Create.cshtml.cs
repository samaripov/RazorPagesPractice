using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.AnswerOptions
{
    public class CreateModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public CreateModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int questionId, int quizId)
        {
            ViewData["QuestionId"] = questionId;
            ViewData["QuizId"] = quizId;
            return Page();
        }

        [BindProperty]
        public AnswerOption AnswerOption { get; set; } = new AnswerOption();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int quizId)
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

            _context.AnswerOption.Add(AnswerOption);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Questions/Details", new
            {
                id = AnswerOption.QuestionId,
                quizId
            });
        }
    }
}
