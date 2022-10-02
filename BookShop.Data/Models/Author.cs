namespace BookShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using static DataConstants;

    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string LastName { get; set; }

        public List<Book> AllBooks { get; set; } = new List<Book>();
    }
}
