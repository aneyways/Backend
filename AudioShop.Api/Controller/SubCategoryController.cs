using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.API.Controllers
{
    [Route("api/subcategory")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private ISubCategoryAction _subCategoryActions;

        public SubCategoryController()
        {
            var bl = new AudioShop.BusinessLogic.BusinessLogic();
            _subCategoryActions = bl.GetSubCategoryActions();
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAllSubCategories()
        {
            var subCategories = _subCategoryActions.GetAllSubCategoriesAction();
            return Ok(subCategories);
        }

        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        public IActionResult GetSubCategoriesByCategory(int categoryId)
        {
            var subCategories = _subCategoryActions.GetSubCategoriesByCategoryAction(categoryId);
            return Ok(subCategories);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetSubCategoryById(int id)
        {
            var subCategory = _subCategoryActions.GetSubCategoryByIdAction(id);
            if (subCategory == null) return NotFound("SubCategory not found");
            return Ok(subCategory);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateSubCategory([FromBody] SubCategoryCreateDto subCategory)
        {
            var created = _subCategoryActions.CreateSubCategoryAction(subCategory);
            return Created($"/api/subcategory/{created.Id}", created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateSubCategory(int id, [FromBody] SubCategoryCreateDto subCategory)
        {
            var updated = _subCategoryActions.UpdateSubCategoryAction(id, subCategory);
            if (updated == null) return NotFound("SubCategory not found");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSubCategory(int id)
        {
            var deleted = _subCategoryActions.DeleteSubCategoryAction(id);
            if (!deleted) return BadRequest("Подкатегория не удалена — возможно содержит продукты");
            return NoContent();
        }
    }
}