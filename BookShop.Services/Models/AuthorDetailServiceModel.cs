namespace BookShop.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;

    public class AuthorDetailServiceModel : IMapFrom<Author>, IHaveCustomMapping
    {
        //Author form, what data of author to be downloaded from database

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> AllBooks { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Author, AuthorDetailServiceModel>()
                .ForMember(a => a.AllBooks, cfg => cfg.MapFrom(ad => ad.AllBooks.Select(b => b.Title)));
            //.ForMember(a => a.AllBooksAtService, cfg => cfg.MapFrom(ad => ad.AllBooks));
        }
    }
}
