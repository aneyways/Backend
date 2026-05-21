using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Category;
using AudioShop.Domains.Models.Category;
using Microsoft.EntityFrameworkCore;



namespace AudioShop.BusinessLogic.Core
{
    public class CategoryActions
    {
        protected AppDbContext _db = new AppDbContext();

        public List<CategoryData> ExecuteGetAllCategoriesAction()
        {
            return _db.Categories
                .Include(c => c.SubCategories)
                .ToList();
        }

        public CategoryData ExecuteGetCategoryByIdAction(int id)
        {
            return _db.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefault(c => c.Id == id);
        }

        public CategoryData ExecuteCreateCategoryAction(CategoryCreateDto _category)
        {
            var newCategory = new CategoryData
            {
                Name = _category.Name
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return newCategory;
        }

        public CategoryData ExecuteUpdateCategoryAction(int id, CategoryCreateDto _category)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return null;
            category.Name = _category.Name;
            _db.SaveChanges();
            return category;
        }

        public bool ExecuteDeleteCategoryAction(int id)
        {
            var category = _db.Categories
                .Include(c => c.SubCategories)
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);
            if (category == null) return false;
            if (category.Products.Any() || category.SubCategories.Any()) return false;
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return true;
        }
    }
}
