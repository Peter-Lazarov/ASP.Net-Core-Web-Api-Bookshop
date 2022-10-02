namespace BookShop.Services
{
    using BookShop.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<BookDetailServiceModel> Details(int id);

        Task<IEnumerable<BookListing>> AllBooks(string word);

        Task<int> CreateBook(
                string title,
                string description,
                decimal price,
                int copies,
                int? edition,
                int? ageRestriction,
                DateTime releaseDate,
                int authorId,
                string categories);

        Task DeleteThisBook(int id);

        Task<bool> Exist(int id);

    }
}
