namespace BookShop.Services.Models
{
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookDeleteServiceModel : IMapFrom<Book>, IHaveCustomMapping
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

        public List<BookCategory> CategoriesMapping { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Book, BookDeleteServiceModel>()
                .ForMember(bd => bd.CategoriesMapping, cfg => cfg.MapFrom(b => b.Categories));
        }
    }
}
