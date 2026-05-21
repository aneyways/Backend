using AudioShop.BusinessLogic.Core;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Entities.Category;
using AudioShop.Domains.Models.Category;

namespace AudioShop.BusinessLogic.Functions
{
    public class CategoryFlow : CategoryActions, ICategoryActions
    {
        public List<CategoryResponseDto> GetAllCategoriesAction()
        {
            var categories = ExecuteGetAllCategoriesAction();
            return categories.Select(c => MapToDto(c)).ToList();
        }

        public CategoryResponseDto GetCategoryByIdAction(int id)
        {
            var category = ExecuteGetCategoryByIdAction(id);
            if (category == null) return null;
            return MapToDto(category);
        }

        public CategoryResponseDto CreateCategoryAction(CategoryCreateDto _category)
        {
            var category = ExecuteCreateCategoryAction(_category);
            return MapToDto(category);
        }

        public CategoryResponseDto UpdateCategoryAction(int id, CategoryCreateDto _category)
        {
            var category = ExecuteUpdateCategoryAction(id, _category);
            if (category == null) return null;
            return MapToDto(category);
        }

        public bool DeleteCategoryAction(int id)
        {
            return ExecuteDeleteCategoryAction(id);
        }

        private CategoryResponseDto MapToDto(CategoryData category)
        {
            return new CategoryResponseDto()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}