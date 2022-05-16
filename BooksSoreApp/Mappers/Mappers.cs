using BooksSoreApp.Entities;
using BooksSoreApp.Models;
using BooksSoreApp.Resources;

namespace BooksSoreApp.Mappers
{
    public static class Mappers
    {
        public static BookResource? MapEntityToResource(this BookEntity? bookEntity)
        {
            if (bookEntity != null)
                return new BookResource
                {
                    Id = bookEntity.Id,
                    Author = bookEntity.Author.MapEntityToResource(),
                    ISBN = bookEntity.ISBN,
                    Name = bookEntity.Name
                };
            return null;
        }

        public static AuthorResource MapEntityToResource(this AuthorEntity authorEntity)
        {
            return new AuthorResource
            {
                Id = authorEntity.Id,
                FirstName = authorEntity.FirstName,
                LastName = authorEntity.LastName
            };
        }

        public static BookEntity MapModelToEntity(this BookModel bookModel)
        {
            return new BookEntity
            {
                Name = bookModel.Name,
                ISBN = bookModel.ISBN,
                AuthorId = bookModel.AuthorId
            };
        }

        public static AuthorEntity MapModelToEntity(this AuthorModel authorModel)
        {
            return new AuthorEntity
            {
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName
            };
        }
    }
}
