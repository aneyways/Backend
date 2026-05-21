using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ICategoryActions
    {
        List<CategoryResponseDto> GetAllCategoriesAction();
        CategoryResponseDto CreateCategoryAction(CategoryCreateDto category);
        CategoryResponseDto GetCategoryByIdAction(int id);
        CategoryResponseDto UpdateCategoryAction(int id, CategoryCreateDto category);
        bool DeleteCategoryAction(int id);
    }
}