using System.ComponentModel.DataAnnotations;

namespace BooksSoreApp.Entities
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ISBN { get; set; }

        public byte? BookCoverImage { get; set; }

        public int AuthorId { get; set; }

        public virtual AuthorEntity Author { get; set; }
    }
}
