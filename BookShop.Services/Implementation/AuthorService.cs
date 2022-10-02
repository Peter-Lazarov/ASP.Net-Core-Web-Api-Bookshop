namespace BookShop.Services.Implementation
{
    using BookShop.Services.Models;
    using BookShop.Data;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using BookShop.Data.Models;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<AuthorDetailServiceModel> Details(int id)
        {
            return await this.db
                .Authors
                .Where(i => i.Id == id)
                .ProjectTo<AuthorDetailServiceModel>()
                .FirstOrDefaultAsync();
        }

        //public async Task<BookCompleteServiceModel> AuthorAndBooksOne(int id)
        //{
        //    return await this.db
        //        .Books
        //        .Where(b => b.AuthorId == id)
        //        .ProjectTo<BookCompleteServiceModel>()
        //        .FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<BookCompleteServiceModel>> AuthorAndBooks(int id)
        {
            return await this.db
                .Books
                .Where(b => b.AuthorId == id)
                .ProjectTo<BookCompleteServiceModel>()
                .ToListAsync();
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.db.Add(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await this.db.Authors.AnyAsync(a => a.Id == id);
        }
    }
}
