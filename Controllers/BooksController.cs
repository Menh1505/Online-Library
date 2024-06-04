using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.Models;
using OnlineLibrary.Models.ViewModel;

namespace OnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public int pageSize = 9;
        public class PriceRange
        {
            public int Min { get; set; }
            public int Max { get; set; }
        }
        // GET: Books
        public IActionResult GetFilteredBooks([FromBody] FilterData filter)
        {
            var filteredBooks = _context.Books.ToList();
            //đưa cái lọc theo loại lên trước vì nó liên kết 2 bản phức tạp
            if(filter.Cat != null && filter.Cat.Count > 0 && !filter.Cat.Contains("all"))
            {
                var catList = filter.Cat.ToList();
                var selectCat = _context.BookCategories.Where(bc => filter.Cat.Contains(bc.CategoryId.ToString())).ToList(); //lụm bọn category trước để có bảng join với book
                filteredBooks = (from a in filteredBooks
                                join b in selectCat 
                                on a.BookId equals b.BookId
                                select a).ToList();             
            }
            if (filter.PriceRange != null && filter.PriceRange.Count > 0 && !filter.PriceRange.Contains("all"))
            {
                List<PriceRange> priceRanges = new List<PriceRange>();
                foreach (var range in filter.PriceRange) //tách dữ liệu 
                {
                    var value = range.Split("-").ToArray();
                    PriceRange priceRange = new PriceRange();
                    priceRange.Min = Int16.Parse(value[0]);
                    priceRange.Max = Int16.Parse(value[1]);
                    priceRanges.Add(priceRange);
                }
                filteredBooks = filteredBooks.Where(b => priceRanges.Any(r=>b.SellPrice >= r.Min && b.SellPrice <= r.Max)).ToList();
            }
            
            return PartialView("_ReturnBooks", filteredBooks);
        }
        public async Task<IActionResult> Index(int bookPage = 1)
        {
            return View(
                new BookListViewModel
                {
                    Books = _context.Books.Skip((bookPage - 1) * pageSize).Take(pageSize).ToList(),
                    pagingInfo = new PagingInfo
                    {
                        ItemsPerPage = pageSize,
                        CurrentPage = bookPage,
                        TotalItems = _context.Books.Count()
                    },
                    categories = _context.Categories,
                    bookCategories = _context.BookCategories
                }
            );
        }
        [HttpPost]
        public async Task<IActionResult> Search(string keyword, int bookPage = 1)
        {
            return View("Index",
                new BookListViewModel
                {
                    Books = _context.Books
                            .Where(b => b.BookName.Contains(keyword))
                            .Skip((bookPage - 1) * pageSize)
                            .Take(pageSize).ToList(),
                    pagingInfo = new PagingInfo
                    {
                        ItemsPerPage = pageSize,
                        CurrentPage = bookPage,
                        TotalItems = _context.Books.Count()
                    },
                    categories = _context.Categories,
                    bookCategories = _context.BookCategories
                }
            );
        }
        public async Task<IActionResult> BookById(int? categoryId)
        {
            if (categoryId != null)
            {
                var model = from a in _context.Books
                            join b in _context.BookCategories
                            on a.BookId equals b.BookId
                            where b.CategoryId == categoryId
                            select a;
                return View("Index", await model.ToListAsync());
            }
            return View("Index", await _context.Books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? bookId)
        {
            if (bookId == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == bookId);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookPhoto,BookName,BookAuthor,BookGenre,BookPublicationDate,BookPublisher,BookDescription,BookPages,BookRating,BookLanguage,Featured,JustArrived")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookPhoto,BookName,BookAuthor,BookGenre,BookPublicationDate,BookPublisher,BookDescription,BookPages,BookRating,BookLanguage,Featured,JustArrived")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
