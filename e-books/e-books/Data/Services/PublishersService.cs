using e_books.Data.Models;
using e_books.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static e_books.Data.Models.Puplisher;

namespace e_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers
                .Where(p => p.Id == publisherId) // p = Publisher
                .Select(p => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = p.Name,
                    BookAuthors = p.Books.Select(b => new BookAuthorVM() // b = Book
                    {
                        BookName = b.Title,
                        // ba = Book_Author (Join Table)
                        BookAuthors = b.Book_Authors.Select(ba => ba.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var publisher = _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefault(p => p.Id == id);

            if (publisher == null)
                return;
     //..............................................................
            if (publisher.Books != null && publisher.Books.Any())
            {
                _context.Books.RemoveRange(publisher.Books);
            }

            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

    }
}
