using ASPNETCRUD.Data;
using ASPNETCRUD.Interfaces;
using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ASPNETCRUD.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;

        public BookService(AppDbContext appDbContext, IMemoryCache memoryCache)
        {
            _context = appDbContext;
            _cache = memoryCache;
        }

        public async Task<ResponseDto<Book>> CreateBook(Book book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return new ResponseDto<Book>(true, "Book created successfully", book);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Book>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Book>> DeleteBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return new ResponseDto<Book>(false, "Book not found");
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return new ResponseDto<Book>(true, "Book deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponseDto<Book>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<List<BookDtos>>> GetAllBooks()
        {
            if (_cache.TryGetValue("GetAllBooks", out List<BookDtos> cachedBooks))
            {
                return new ResponseDto<List<BookDtos>>(true, "Books retrieved from cache", cachedBooks);
            }
            try
            {
                var books = await _context.Books
                    .Select(b => new BookDtos
                    {
                        Id = b.Id,
                        Title = b.Title,
                        AuthorBooks = b.AuthorBooks.Select(ab => new AuthorBookDtos
                        {
                            Id = ab.Id,
                            AuthorId = ab.AuthorId,
                            BookId = ab.BookId,
                            Author = new AuthorDtos
                            {
                                Id = ab.Author.Id,
                                Name = ab.Author.Name
                            }
                        }).ToList()
                    })
                    .ToListAsync();
                _cache.Set("GetAllBooks", books, TimeSpan.FromMinutes(30));
                return new ResponseDto<List<BookDtos>>(true, "Books retrieved successfully", books);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<BookDtos>>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Book>> GetBookById(int id)
        {
            try
            {
                var book = await _context.Books
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (book == null)
                {
                    return new ResponseDto<Book>(false, "Book not found");
                }

                return new ResponseDto<Book>(true, "Book retrieved successfully", book);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Book>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Book>> UpdateBook(int id, Book book)
        {
            try
            {
                var existingBook = await _context.Books.FindAsync(id);
                if (existingBook == null)
                {
                    return new ResponseDto<Book>(false, "Book not found");
                }

                existingBook.Title = book.Title;

                _context.Books.Update(existingBook);
                await _context.SaveChangesAsync();

                return new ResponseDto<Book>(true, "Book updated successfully", existingBook);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Book>(false, ex.Message);
            }
        }
    }
}
