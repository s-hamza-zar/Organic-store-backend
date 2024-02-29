using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using organicEcomApi.Dto;
using organicEcomApi.Interfaces;
using organicEcomApi.Models;

namespace organicEcomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(400, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetAllProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetAllProducts());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(products);
        }

        [HttpGet("{ProductId:int}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int ProductId)
        {
            if (!_productRepository.ProductExists(ProductId))
            {
                return NotFound();
            }

            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(ProductId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(product);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreatePokemon(
           [FromQuery] int categoryId,
           ProductDto productCreate)

        {
            if (productCreate == null)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productMap = _mapper.Map<Product>(productCreate);


            if (!_productRepository.CreateProduct(categoryId, productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving...");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpDelete("{ProductId:int}")]

        public IActionResult DeleteProduct(int ProductId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.ProductExists(ProductId))
            {
                return NotFound();
            }

            if (!_productRepository.DeleteProduct(ProductId))
            {
                ModelState.AddModelError("", "something went wrong while deleting...");
                return BadRequest(ModelState);
            }

            return Ok("Succesfully Deleted...");
        }

        [HttpPut("update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public IActionResult UpdateProduct([FromBody] ProductDto updateProduct)
        {

            if (updateProduct == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_productRepository.ProductExists(updateProduct.Id))
            {
                return NotFound(ModelState);
            }

            var productMap = _mapper.Map<Product>(updateProduct);

            if (!_productRepository.UpdateProduct(productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving...");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully updated");
        }

    }
}
