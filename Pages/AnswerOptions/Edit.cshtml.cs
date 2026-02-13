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

namespace QuizApp.Pages.AnswerOptions
{
    public class EditModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public EditModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AnswerOption AnswerOption { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answeroption =  await _context.AnswerOption.FirstOrDefaultAsync(m => m.Id == id);
            if (answeroption == null)
            {
                return NotFound();
            }
            AnswerOption = answeroption;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AnswerOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerOptionExists(AnswerOption.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AnswerOptionExists(int id)
        {
            return _context.AnswerOption.Any(e => e.Id == id);
        }
    }
}
