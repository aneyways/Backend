using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.RenderTree;

namespace AudioShop.Api.Controller
{
	[Route("api/product")]
	[ApiController]

	public class ProductController : ControllerBase
	{
		private IProduct _product;

		public ProductController()
		{
			var bl = new BusinessLogic.BusinessLogic();
			_product = bl.GetProductActions();
		}

		[HttpGet("getAll")]

		public IActionResult GetAllProducts()
		{
			var products = _product.GetAllProductsAction();
			return Ok(products);
		}

		[HttpGet("id")]

		public IActionResult GetProductById(int id)
		{
			var product = _product.GetProductByIdAction(id);
			if (product == null)
			{
				return NotFound(new { Message = $"Product with {id} not found" });
			}
			return Ok(product);
		}

		[HttpPost]

		public IActionResult Create([FromBody] ProductDto product)
		{
			var status = _product.ResponseProductCreateAction(product);
			return Ok(status);
		}

		[HttpPut]
		public IActionResult Update([FromBody] ProductDto product)
		{
			var status = _product.ResponseProductUpdateAction(product);
			return Ok(status);
		}

		[HttpDelete]

		public IActionResult Delete(int id)
		{
			var status = _product.ResponseProductDeleteAction(id);
			return Ok(status);
		}
	}
}