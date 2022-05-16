using System.ComponentModel.DataAnnotations;

namespace BooksSoreApp.Entities
{
    public class AuthorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public byte? AuthorImage { get; set; }

        public virtual ICollection<BookEntity> Books { get; set; }
    }
}
