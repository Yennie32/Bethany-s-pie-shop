using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// mock data file that implements ICategoryRepository
namespace BethanysPieShop.Models // Déclare un espace de noms pour organiser le code
{
    public class MockCategoryRepository : ICategoryRepository // Déclare une classe qui implémente l'interface ICategoryRepository
    {
        // Propriété qui retourne une liste simulée de catégories
        public IEnumerable<Category> AllCategories =>
            new List<Category> // Création et initialisation d'une liste d'objets Category
            {
                new Category {CategoryId = 1, CategoryName = "Fruit pies", Description = "All-fruity pies"},
                new Category {CategoryId = 2, CategoryName = "Cheese cakes", Description = "Cheesy cakes all the way"},
                new Category {CategoryId = 3, CategoryName = "Seasonal pies", Description = "Get in the mood for a seasonal pie"}
            };
    }
}
