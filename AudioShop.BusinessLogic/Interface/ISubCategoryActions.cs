using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ISubCategoryActions
    {
        SubCategoryInfoDto CreateSubCategory(SubCategoryCreateDto subCategory);

        List<SubCategoryInfoDto> GetAllSubCategories();

        List<SubCategoryInfoDto> GetSubCategoriesByCategoryId(int categoryId);

        SubCategoryInfoDto GetSubCategoryById(int id);

        SubCategoryInfoDto UpdateSubCategory(int id, SubCategoryCreateDto subCategory);

        bool DeleteSubCategory(int id);
    }
}