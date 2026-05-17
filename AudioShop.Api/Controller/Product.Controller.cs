using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioShop.BusinessLogic;
// using AudioShop.API.Attributes;


namespace AudioShop.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductAction _productActions;
        public ProductController()
        {
            var _bl = new AudioShop.BusinessLogic.BusinessLogic();
            _productActions = _bl.GetProductAction();
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            var _products = _productActions.GetAllProductsAction();
            return Ok(_products);
        }

        [HttpPost]
        // [ManagerMod]
        public IActionResult CreateNewProduct(ProductCreateDto _product)
        {
            var _newProduct = _productActions.CreateNewProductAction(_product);
            return Created($"/api/product/{_newProduct.Id}", _newProduct);
        }

        [HttpPut("{id}")]
        // [ManagerMod]
        public IActionResult UpdateProduct(int id, ProductCreateDto _product)
        {
            var _updatedProduct = _productActions.UpdateProductAction(id, _product);
            return Ok(_updatedProduct);
        }

        [HttpDelete("{id}")]
        // [AdminMod]
        public IActionResult DeleteProduct(int id)
        {
            var IsDeleted = _productActions.DeleteProductAction(id);
            if (!IsDeleted) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var _product = _productActions.GetByIdProductAction(id);

            if (_product == null) return NotFound();

            return Ok(_product);
        }

        [HttpGet("category/{category}")]
        public IActionResult GetByCategory(string _category)
        {
            var _product = _productActions.GetByCategoryProductsAction(_category);

            if (_product == null) return NotFound();

            return Ok(_product);
        }
    }
}