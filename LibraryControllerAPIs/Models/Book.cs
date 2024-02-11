using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryControllerAPIs.Models
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(Author.ID))]
        public string AuthorID { get; set; } = string.Empty;

        [Key]
        public string ISBN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }

        public BookCopyStatus Status { get; set; }

        /*public class BookCopy
        {
            [Key]
            public string CopyId { get; set; } = string.Empty;// Unique identifier for each copy
            public BookCopyStatus Status { get; set; }
        }
        public virtual ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();*/
    }

    public enum BookCopyStatus
    {
        Available,
        CheckedOut,
        Reserved
    }
}
