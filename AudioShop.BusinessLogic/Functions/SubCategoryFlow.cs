using AudioShop.BusinessLogic.Core;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Entities.Category;
using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Functions
{
    public class SubCategoryFlow : SubCategoryActions, ISubCategoryAction
    {
        public List<SubCategoryResponseDto> GetAllSubCategoriesAction()
        {
            return ExecuteGetAllSubCategoriesAction()
                .Select(s => MapToDto(s)).ToList();
        }

        public List<SubCategoryResponseDto> GetSubCategoriesByCategoryAction(int categoryId)
        {
            return ExecuteGetSubCategoriesByCategoryAction(categoryId)
                .Select(s => MapToDto(s)).ToList();
        }

        public SubCategoryResponseDto GetSubCategoryByIdAction(int id)
        {
            var subCategory = ExecuteGetSubCategoryByIdAction(id);
            if (subCategory == null) return null;
            return MapToDto(subCategory);
        }

        public SubCategoryResponseDto CreateSubCategoryAction(SubCategoryCreateDto _subCategory)
        {
            var subCategory = ExecuteCreateSubCategoryAction(_subCategory);
            return MapToDto(subCategory);
        }

        public SubCategoryResponseDto UpdateSubCategoryAction(int id, SubCategoryCreateDto _subCategory)
        {
            var subCategory = ExecuteUpdateSubCategoryAction(id, _subCategory);
            if (subCategory == null) return null;
            return MapToDto(subCategory);
        }

        public bool DeleteSubCategoryAction(int id)
        {
            return ExecuteDeleteSubCategoryAction(id);
        }

        private SubCategoryResponseDto MapToDto(SubCategoryData subCategory)
        {
            return new SubCategoryResponseDto()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId
            };
        }
    }
}