using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSight.Models
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }


    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext db;
        public CategoryRepository(AppDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Category> AllCategories => db.Categories;
    }
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit pies", description="All-fruity pies"},
                new Category{CategoryId=2, CategoryName="Cheese cakes", description="Cheesy all the way"},
                new Category{CategoryId=3, CategoryName="Seasonal pies", description="Get in the mood for a seasonal pie"}
            };
    }
}
