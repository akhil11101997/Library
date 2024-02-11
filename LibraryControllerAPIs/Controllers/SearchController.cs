using LibraryControllerAPIs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryControllerAPIs.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Search/Books
        [HttpGet("Books")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(string query, string genre, bool filter)
        {
            var booksQuery = _context.Books.AsQueryable();

            // Filter by genre
            if (!string.IsNullOrEmpty(genre))
            {
                booksQuery = booksQuery.Where(b => b.Genre.ToLower() == genre.ToLower());
            }

            // Search by query
            if (!string.IsNullOrEmpty(query))
            {
                booksQuery = booksQuery.Where(b => b.Title.ToLower().Contains(query.ToLower()));
            }
            if (filter)
            {
                return booksQuery.OrderBy(b => b.Title).ToList();
            }
            else
            {
                return booksQuery.OrderByDescending(b => b.Title).ToList();
            }
        }

        // GET: api/Search/Authors
        [HttpGet("Authors")]
        public async Task<ActionResult<IEnumerable<Author>>> SearchAuthors(string query, bool filter)
        {
            var authorsQuery = _context.Authors.AsQueryable();

            // Search by query
            if (!string.IsNullOrEmpty(query))
            {
                authorsQuery = authorsQuery.Where(a => a.Name.ToLower().Contains(query.ToLower()));
            }

            if (filter)
            {
                return authorsQuery.OrderBy(b => b.Name).ToList();
            }
            else
            {
                return authorsQuery.OrderByDescending(b => b.Name).ToList();
            }
        }
    }
}