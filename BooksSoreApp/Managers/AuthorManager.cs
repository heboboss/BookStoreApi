using BooksSoreApp.Entities;
using BooksSoreApp.Mappers;
using BooksSoreApp.Models;
using BooksSoreApp.Resources;

namespace BooksSoreApp.Managers
{
    public interface IAuthorManager
    {
        AuthorResource? GetAuthorById(int id);
        List<AuthorResource> GetAllAuthors();
        AuthorResource CreateAuthor(AuthorModel book);
        AuthorResource? UpdateAuthor(int id, AuthorModel book);
        void DeleteAuthor(int id);
    }
    public class AuthorManager : IAuthorManager
    {
        private readonly BookStoreDbContext _context;
        public AuthorManager(BookStoreDbContext context)
        {
            _context = context;
        }

        public AuthorResource? GetAuthorById(int id)
        {
            var author = _context.Find<AuthorEntity>(id)?.MapEntityToResource();
            return author;
        }

        public List<AuthorResource> GetAllAuthors()
        {
            var authors = _context.Set<AuthorEntity>().Select(x => x.MapEntityToResource()).ToList();
            return authors;
        }

        public AuthorResource CreateAuthor(AuthorModel author)
        {
            var entity = author.MapModelToEntity();
            _context.Add(entity);
            _context.SaveChanges();

            var createdAuthor = GetAuthorById(entity.Id);
            return createdAuthor;
        }

        public AuthorResource? UpdateAuthor(int id, AuthorModel author)
        {
            var existedAuthor = GetAuthorById(id);
            if (existedAuthor == null) return null;
            var entity = author.MapModelToEntity();
            _context.Update(entity);
            _context.SaveChanges();

            var updatedAuthor = GetAuthorById(entity.Id);
            return updatedAuthor;
        }

        public void DeleteAuthor(int id)
        {
            var existedAuthor = GetAuthorById(id);
            if (existedAuthor == null) return;
            _context.Remove(existedAuthor);
            _context.SaveChanges();
        }
    }

}
