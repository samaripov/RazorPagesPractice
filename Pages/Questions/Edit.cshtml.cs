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
    public class EditModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public EditModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Question Question { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? quizId)
        {
            if (id == null || quizId == null)
            {
                return NotFound();
            }
            ViewData["QuizId"] = quizId;
            var question =  await _context.Question.FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            Question = question;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int quizId)
        {   
            Question.QuizId = quizId;
            Console.WriteLine(Question.Text);
            Console.WriteLine(Question.QuizId);
     

            _context.Attach(Question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(Question.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Quizzes/Details", new { id = Question.QuizId });
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}
