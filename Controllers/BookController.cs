﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Malawi_books_directory.Data;
using Malawi_books_directory.Models;
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
                    Price = model.Price,
                    AvailabilityStatus = model.AvailabilityStatus,
                    Tags = model.Tags
                };
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Assuming you have an Index action
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
    }
}

