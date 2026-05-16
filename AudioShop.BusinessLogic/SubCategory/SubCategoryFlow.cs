using AudioShop.BusinessLogic.Interface;
using AudioShop.BusinessLogic.Core.SubCategory;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Entities.Category;
using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Functions.SubCategory
{
    public class SubCategoryFlow : ISubCategoryActions
    {
        private readonly SubCategoryActions _subCategoryActions;

        public SubCategoryFlow()
        {
            _subCategoryActions = new SubCategoryActions();
        }

        public SubCategoryInfoDto CreateSubCategory(SubCategoryCreateDto subCategory)
        {
            var _subCategory = _subCategoryActions.ExecuteCreateSubCategoryAction(subCategory);

            if (_subCategory == null)
            {
                return null;
            }

            return MapSubCategoryToInfoDto(_subCategory);
        }

        public List<SubCategoryInfoDto> GetAllSubCategories()
        {
            var _subCategories = _subCategoryActions.ExecuteGetAllSubCategoriesAction();

            return _subCategories
                .Select(subCategory => MapSubCategoryToInfoDto(subCategory))
                .ToList();
        }

        public List<SubCategoryInfoDto> GetSubCategoriesByCategoryId(int categoryId)
        {
            var _subCategories = _subCategoryActions.ExecuteGetSubCategoriesByCategoryIdAction(categoryId);

            return _subCategories
                .Select(subCategory => MapSubCategoryToInfoDto(subCategory))
                .ToList();
        }

        public SubCategoryInfoDto GetSubCategoryById(int id)
        {
            var _subCategory = _subCategoryActions.ExecuteGetSubCategoryByIdAction(id);

            if (_subCategory == null)
            {
                return null;
            }

            return MapSubCategoryToInfoDto(_subCategory);
        }

        public SubCategoryInfoDto UpdateSubCategory(int id, SubCategoryCreateDto subCategory)
        {
            var _subCategory = _subCategoryActions.ExecuteUpdateSubCategoryAction(id, subCategory);

            if (_subCategory == null)
            {
                return null;
            }

            return MapSubCategoryToInfoDto(_subCategory);
        }

        public bool DeleteSubCategory(int id)
        {
            return _subCategoryActions.ExecuteDeleteSubCategoryAction(id);
        }

        private SubCategoryInfoDto MapSubCategoryToInfoDto(SubCategoryData subCategory)
        {
            return new SubCategoryInfoDto()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId
            };
        }
    }
}