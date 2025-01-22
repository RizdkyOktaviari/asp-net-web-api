using ASPNETCRUD.Models;
using Bogus;

namespace ASPNETCRUD.Data.Seeder
{
    public class MasterDataSeeder
    {
        private readonly AppDbContext _context;

        public MasterDataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (!_context.Authors.Any())
            {
                var authorFaker = new Faker<Author>()
                    .RuleFor(a => a.Name, f => f.Name.FullName())
                    .RuleFor(a => a.CreatedAt, f => f.Date.Past(1))
                    .RuleFor(a => a.UpdatedAt, f => f.Date.Recent());

                var authors = authorFaker.Generate(30);
                _context.Authors.AddRange(authors);
            }

            if (!_context.Categories.Any())
            {
                var categoryFaker = new Faker<Category>()
                    .RuleFor(c => c.Name, f => f.Commerce.Department())
                    .RuleFor(c => c.CreatedAt, f => f.Date.Past(1))
                    .RuleFor(c => c.UpdatedAt, f => f.Date.Recent());

                var categories = categoryFaker.Generate(10);
                _context.Categories.AddRange(categories);
            }

            if (!_context.Books.Any())
            {
                var bookFaker = new Faker<Book>()
                    .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
                    .RuleFor(b => b.CreatedAt, f => f.Date.Past(1))
                    .RuleFor(b => b.UpdatedAt, f => f.Date.Recent());

                var books = bookFaker.Generate(50);
                _context.Books.AddRange(books);
            }

            _context.SaveChanges();

            if (!_context.AuthorBooks.Any())
            {
                var authorBookFaker = new Faker<AuthorBook>()
                    .RuleFor(ab => ab.AuthorId, f => f.PickRandom(_context.Authors.Select(a => a.Id).ToList()))
                    .RuleFor(ab => ab.BookId, f => f.PickRandom(_context.Books.Select(b => b.Id).ToList()));

                var authorBooks = authorBookFaker.Generate(100);
                _context.AuthorBooks.AddRange(authorBooks);
            }

            if (!_context.BookCategories.Any())
            {
                var bookCategoryFaker = new Faker<BookCategory>()
                    .RuleFor(bc => bc.BookId, f => f.PickRandom(_context.Books.Select(b => b.Id).ToList()))
                    .RuleFor(bc => bc.CategoryId, f => f.PickRandom(_context.Categories.Select(c => c.Id).ToList()));

                var bookCategories = bookCategoryFaker.Generate(200);
                _context.BookCategories.AddRange(bookCategories);
            }

            _context.SaveChanges();
        }
    }
}
