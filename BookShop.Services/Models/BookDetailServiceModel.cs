namespace BookShop.Services.Models
{
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;
    using System;

    public class BookDetailServiceModel : IMapFrom<Book>
    {
        public string Title { get; set; }
        
        public int Id { get; set; }    

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int? Edition { get; set; } //? nullable

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }
    }
}
