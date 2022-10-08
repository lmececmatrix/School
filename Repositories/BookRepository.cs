using KinderGarten.Data;
using KinderGarten.Models;

namespace KinderGarten.Repositories
{
    public class BookRepository
    {
        private readonly KinderGartenContext _context;

        public BookRepository(KinderGartenContext context)
        {
            _context = context;
        }

        public async Task<int> Create(BookModel model)
        {
            var book = new Book()
            {
                Id= 0,
                Name = model.Name,
                Email = model.Email,
                ClassID = model.ClassID,
            };

            // book.Class = _context.Classes.Find(model.ClassID);

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
    }
}
