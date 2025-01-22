using ASPNETCRUD.Data;
using ASPNETCRUD.Interfaces;
using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCRUD.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly AppDbContext _context;
        public AuthorBookService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<ResponseDto<AuthorBook>> CreateAuthorBook(AuthorBook authorBook)
        {
            try
            {
                await _context.AuthorBooks.AddAsync(authorBook);
                await _context.SaveChangesAsync();
                return new ResponseDto<AuthorBook>(true, "AuthorBook created successfully", authorBook);
            }
            catch (Exception ex)
            {
                return new ResponseDto<AuthorBook>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<AuthorBook>> DeleteAuthorBook(int id)
        {
            try
            {
                var authorBook = await _context.AuthorBooks.FindAsync(id);
                if (authorBook == null)
                {
                    return new ResponseDto<AuthorBook>(false, "AuthorBook not found");
                }
                _context.AuthorBooks.Remove(authorBook);
                await _context.SaveChangesAsync();
                return new ResponseDto<AuthorBook>(true, "AuthorBook deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponseDto<AuthorBook>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<List<AuthorBook>>> GetAllAuthorBooks()
        {
            try
            {
                var authorBooks = await _context.AuthorBooks
                    .Include(ab => ab.Author)
                    .Include(ab => ab.Book)
                    .ToListAsync();

                if (authorBooks.Count == 0) return new ResponseDto<List<AuthorBook>>(false, "No AuthorBooks found");

                return new ResponseDto<List<AuthorBook>>(true, "AuthorBooks retrieved successfully", authorBooks);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<AuthorBook>>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<AuthorBook>> GetAuthorBookById(int id)
        {
            try
            {
                var authorBook = await _context.AuthorBooks
                    .AsNoTracking()
                    .Include(ab => ab.Author)
                    .Include(ab => ab.Book)
                    .FirstOrDefaultAsync(ab => ab.Id == id);

                if (authorBook == null) return new ResponseDto<AuthorBook>(false, "AuthorBook not found");

                return new ResponseDto<AuthorBook>(true, "AuthorBook retrieved successfully", authorBook);
            }
            catch (Exception ex)
            {
                return new ResponseDto<AuthorBook>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<AuthorBook>> UpdateAuthorBook(int id, AuthorBook authorBook)
        {
            try
            {
                var authorBookToUpdate = await _context.AuthorBooks.FindAsync(id);
                if (authorBookToUpdate == null)
                {
                    return new ResponseDto<AuthorBook>(false, "AuthorBook not found");
                }
                authorBookToUpdate.AuthorId = authorBook.AuthorId;
                authorBookToUpdate.BookId = authorBook.BookId;
                await _context.SaveChangesAsync();
                return new ResponseDto<AuthorBook>(true, "AuthorBook updated successfully", authorBookToUpdate);
            }
            catch (Exception ex)
            {
                return new ResponseDto<AuthorBook>(false, ex.Message);
            }
        }
    }
}
