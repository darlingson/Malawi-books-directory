using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Malawi_books_directory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malawi_books_directory.Components
{
    public class RandomBooksViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public RandomBooksViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var randomBooks = await _context.Books
                .Include(b => b.Author)
                .OrderBy(r => Guid.NewGuid())
                .Take(10)
                .ToListAsync();

            return View(randomBooks);
        }
    }
}
