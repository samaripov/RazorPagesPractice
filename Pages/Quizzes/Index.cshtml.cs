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
    public class IndexModel : PageModel
    {
        private readonly QuizApp.Data.QuizAppContext _context;

        public IndexModel(QuizApp.Data.QuizAppContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quiz.ToListAsync();
        }
    }
}
