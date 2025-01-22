using ASPNETCRUD.Data;
using ASPNETCRUD.Interfaces;
using ASPNETCRUD.ModelDtos;
using ASPNETCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCRUD.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<ResponseDto<Author>> CreateAuthor(Author author)
        {
            try
            {
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
                return new ResponseDto<Author>(true, "Author created successfully", author);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Author>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Author>> DeleteAuthor(int id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return new ResponseDto<Author>(false, "Author not found");
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return new ResponseDto<Author>(true, "Author deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponseDto<Author>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<List<Author>>> GetAllAuthors()
        {
            try
            {
                var authors = await _context.Authors
                         .ToListAsync();

                return new ResponseDto<List<Author>>(true, "Authors retrieved successfully", authors);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<Author>>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Author>> GetAuthorById(int id)
        {
            try
            {
                var author = await _context.Authors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (author == null)
                {
                    return new ResponseDto<Author>(false, "Author not found");
                }

                return new ResponseDto<Author>(true, "Author retrieved successfully", author);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Author>(false, ex.Message);
            }
        }

        public async Task<ResponseDto<Author>> UpdateAuthor(int id, Author author)
        {
            try
            {
                var existingAuthor = await _context.Authors.FindAsync(id);
                if (existingAuthor == null)
                {
                    return new ResponseDto<Author>(false, "Author not found");
                }

                existingAuthor.Name = author.Name;

                _context.Authors.Update(existingAuthor);
                await _context.SaveChangesAsync();
                return new ResponseDto<Author>(true, "Author updated successfully", existingAuthor);
            }
            catch (Exception ex)
            {
                return new ResponseDto<Author>(false, ex.Message);
            }
        }
    }
}
