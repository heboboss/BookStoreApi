using BooksSoreApp.Entities;
using BooksSoreApp.Mappers;
using BooksSoreApp.Models;
using BooksSoreApp.Resources;
using Microsoft.EntityFrameworkCore;

namespace BooksSoreApp.Managers
{
    public interface IBookManager
    {
        BookResource? GetBookById(int id);
        List<BookResource> GetAllBooks();
        BookResource CreateBook(BookModel book);
        BookResource? UpdateBook(int id, BookModel book);
        void DeleteBook(int id);
    }
    public class BookManager: IBookManager
    {
        private readonly BookStoreDbContext _context;
        private readonly IAuthorManager _authorManager;
        public BookManager(
            BookStoreDbContext context,
            IAuthorManager authorManager
            )
        {
            _context = context;
            _authorManager = authorManager;
        }

        private void ValidateAuthor(int authorId)
        {
            var author = _context.Find<AuthorEntity>(authorId);
            if (author == null)
            {
                throw new Exception("Author Not Found");
            }
        }

        public BookResource? GetBookById(int id)
        {
            var book = _context.Set<BookEntity>()
                .Where(x => x.Id == id)
                .Include(e => e.Author)
                .FirstOrDefault().MapEntityToResource();

            return book;
        }

        public List<BookResource> GetAllBooks()
        {
            var books = _context.Set<BookEntity>().Include(e => e.Author).Select(x => x.MapEntityToResource()).ToList();
            return books;
        }

        public BookResource CreateBook(BookModel book)
        {
            ValidateAuthor(book.AuthorId);
            var entity = book.MapModelToEntity();
            _context.Add(entity);
            _context.SaveChanges();

            var createdBook = GetBookById(entity.Id);
            return createdBook;
        }

        public BookResource? UpdateBook(int id, BookModel book)
        {
            ValidateAuthor(book.AuthorId);
            var existedBook = GetBookById(id);
            if (existedBook == null) return null;
            var entity = book.MapModelToEntity();
            _context.Update(entity);
            _context.SaveChanges();

            var updatedBook = GetBookById(entity.Id);
            return updatedBook;
        }

        public void DeleteBook(int id)
        {
            var existedBook = GetBookById(id);
            if (existedBook == null) return;
            _context.Remove(existedBook);
            _context.SaveChanges();
        }
    }
}
