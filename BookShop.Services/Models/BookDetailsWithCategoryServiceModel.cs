using AutoMapper;
using BookShop.Common.Mapping;
using BookShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Services.Models
{
    public class BookDetailsWithCategoryServiceModel : BookDetailServiceModel, IHaveCustomMapping
    {
        public List<string> Categories { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Book, BookDetailsWithCategoryServiceModel>()
                .ForMember(bc => bc.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        }
    }
}
