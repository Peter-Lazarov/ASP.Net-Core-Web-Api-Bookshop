namespace BookShop.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<AuthorDetailServiceModel> Details(int id);

        Task<IEnumerable<BookCompleteServiceModel>> AuthorAndBooks(int id);

        Task<int> Create(string firstName, string lastName);

        Task<bool> Exists(int id);
    }
}
