using Microsoft.AspNetCore.Mvc;
using Malawi_books_directory.Data;
using Malawi_books_directory.Models;
namespace Malawi_books_directory.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author model)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    Name = model.Name,
                    Biography = model.Biography,
                    DateOfBirth = model.DateOfBirth,
                    Nationality = model.Nationality,
                    PhotoUrl = model.PhotoUrl
                };
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Assuming you have an Index action
            }
            return View(model);
        }

        // GET: Author/Index
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }
    }
}


