using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ISubCategoryAction
    {
        List<SubCategoryResponseDto> GetAllSubCategoriesAction();
        List<SubCategoryResponseDto> GetSubCategoriesByCategoryAction(int categoryId);
        SubCategoryResponseDto GetSubCategoryByIdAction(int id);
        SubCategoryResponseDto CreateSubCategoryAction(SubCategoryCreateDto subCategory);
        SubCategoryResponseDto UpdateSubCategoryAction(int id, SubCategoryCreateDto subCategory);
        bool DeleteSubCategoryAction(int id);
    }
}