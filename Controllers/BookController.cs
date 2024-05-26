using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Malawi_books_directory.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book model)
        {
            Console.WriteLine(model.Author);
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    Author = model.Author,
                    Description = model.Description,
                    PublishedDate = model.PublishedDate,
                    Genre = model.Genre,
                    ISBN = model.ISBN,
                    Publisher = model.Publisher,
                    Language = model.Language,
                    NumberOfPages = model.NumberOfPages,
                    CoverImageUrl = model.CoverImageUrl,
                    Tags = model.Tags
                };
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Assuming you have an Index action
            }
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", model.AuthorId);
            return View(model);
        }

        // GET: Book/Index
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Edit actions
        public IActionResult Edit(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Authors = _context.Authors.ToList();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,AuthorId,Description,PublishedDate,Genre,ISBN,Publisher,Language,NumberOfPages,CoverImageUrl,Rating,Price,AvailabilityStatus,Tags")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = _context.Authors.ToList();
            return View(book);
        }
    }
}


