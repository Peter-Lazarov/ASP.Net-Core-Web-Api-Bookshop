namespace BookShop.Services.Models
{
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class BookCompleteServiceModel : BookDetailServiceModel, IHaveCustomMapping
    {
        public string Author { get; set; }

        public List<string> Categories { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Book, BookCompleteServiceModel>()
                .ForMember(bc => bc.Author, cfg => cfg.MapFrom(b => b.Author.FirstName + " " + b.Author.LastName))
                .ForMember(bc => bc.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        }
    }
}
