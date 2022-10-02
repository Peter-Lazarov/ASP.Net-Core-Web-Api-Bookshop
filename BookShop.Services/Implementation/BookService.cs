namespace BookShop.Services.Implementation
{
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext dbFromMethod)
        {
            this.db = dbFromMethod;
        }

        public async Task<BookDetailServiceModel> Details(int id)
        {
            return await this.db
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailServiceModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookListing>> AllBooks(string word)
        {
            return await this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(word))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BookListing>()
                .ToListAsync();
        }

        public async Task<int> CreateBook(
                string title,
                string description,
                decimal price,
                int copies,
                int? edition,
                int? ageRestriction,
                DateTime releaseDate,
                int authorId,
                string categories)
        {
            var newCategoryNames = categories.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            var existingCategoriesFromRequest = await this.db
                .Categories
                .Where(c => newCategoryNames.Contains(c.Name))
                .ToListAsync();

            List<Category> categoriesForBook = new List<Category>(existingCategoriesFromRequest);

            foreach (var categoryName in newCategoryNames)
            {
                if (existingCategoriesFromRequest.All(c => c.Name != categoryName))
                {
                    var category = new Category
                    {
                        Name = categoryName
                    };

                    this.db.Add(category);

                    categoriesForBook.Add(category);
                }
            }

            await this.db.SaveChangesAsync();

            var book = new Book
            {
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };
            
            categoriesForBook.ForEach(c => book.Categories.Add
            (
                new BookCategory
                {
                    CategoryId = c.Id
                }
            ));

            this.db.Add(book);
            await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task DeleteThisBook(int id)
        {
            Book bookForDelete = await this.db
                 .Books
                 .Where(b => b.Id == id)
                 .FirstOrDefaultAsync();

             this.db
                .Books
                .Remove(bookForDelete);

            await this.db.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            return await this.db.Books.AnyAsync(b => b.Id == id);
        }
    }
}
