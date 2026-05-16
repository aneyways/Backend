using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ICategoryActions
    {
        CategoryInfoDto CreateCategory(CategoryCreateDto category);

        List<CategoryInfoDto> GetAllCategories();

        CategoryInfoDto GetCategoryById(int id);

        CategoryInfoDto UpdateCategory(int id, CategoryCreateDto category);

        bool DeleteCategory(int id);
    }
}