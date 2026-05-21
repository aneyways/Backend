using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Category;
using AudioShop.Domains.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace AudioShop.BusinessLogic.Core
{
    public class SubCategoryActions
    {
        protected AppDbContext _db = new AppDbContext();

        public List<SubCategoryData> ExecuteGetAllSubCategoriesAction()
        {
            return _db.SubCategories.ToList();
        }

        public List<SubCategoryData> ExecuteGetSubCategoriesByCategoryAction(int categoryId)
        {
            return _db.SubCategories
                .Where(s => s.CategoryId == categoryId)
                .ToList();
        }

        public SubCategoryData ExecuteGetSubCategoryByIdAction(int id)
        {
            return _db.SubCategories
                .Include(s => s.Category)
                .FirstOrDefault(s => s.Id == id);
        }

        public SubCategoryData ExecuteCreateSubCategoryAction(SubCategoryCreateDto _subCategory)
        {
            var newSubCategory = new SubCategoryData()
            {
                Name = _subCategory.Name,
                CategoryId = _subCategory.CategoryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _db.SubCategories.Add(newSubCategory);
            _db.SaveChanges();
            return newSubCategory;
        }

        public SubCategoryData ExecuteUpdateSubCategoryAction(int id, SubCategoryCreateDto _subCategory)
        {
            var subCategory = _db.SubCategories.FirstOrDefault(s => s.Id == id);
            if (subCategory == null) return null;
            subCategory.Name = _subCategory.Name;
            subCategory.CategoryId = _subCategory.CategoryId;
            subCategory.UpdatedAt = DateTime.Now;
            _db.SaveChanges();
            return subCategory;
        }

        public bool ExecuteDeleteSubCategoryAction(int id)
        {
            var subCategory = _db.SubCategories
                .Include(s => s.Products)
                .FirstOrDefault(s => s.Id == id);
            if (subCategory == null) return false;
            if (subCategory.Products != null && subCategory.Products.Any()) return false;
            _db.SubCategories.Remove(subCategory);
            _db.SaveChanges();
            return true;
        }
    }
}