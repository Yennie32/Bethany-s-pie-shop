using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    // This class implements the ICategoryRepository interface,
    // providing a way to interact with the category data.
    public class CategoryRepository: ICategoryRepository
    {
        // Private field to store the database context.
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        // Constructor that initializes the repository with a database context.
        // This allows the repository to interact with the database.
        public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext){
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }
        
        // Property that retrieves all categories from the database,
        // ordered by category name.
        public IEnumerable<Category> AllCategories => 
            _bethanysPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
