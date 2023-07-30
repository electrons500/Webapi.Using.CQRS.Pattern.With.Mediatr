using MediatR;
using Microsoft.AspNetCore.Mvc;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Commands;
using Webapi_Using_CQRS_Pattern_With_Mediatr.Features.ProductFeatures.Queries;


namespace Webapi_Using_CQRS_Pattern_With_Mediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator _Mediator;
        public ProductsController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpPost("AddProducts")]
        public async Task<ActionResult> AddProducts([FromBody] CreateProductCommand model)
        {
            var response = await _Mediator.Send(model);
            if (response)
            {
                return Ok("Product successfully saved.");
            }

            return BadRequest("Something has gone wrong");
        }

        // GET api/<ProductsController>/5
        [HttpGet("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var model = await _Mediator.Send(new GetAllProductsQuery());
            return Ok(model);
        }

        // GET api/<ProductsController>/5
        [HttpGet("GetProduct/{productId}")]
        public async Task<ActionResult> GetProduct(int productId)
        {
            var model = await _Mediator.Send(new GetProductByIdQuery { productId = productId});
            return Ok(model);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand model)
        {
           
            var response = await _Mediator.Send(model);
            if (response)
            {
                return Ok("Product successfully updated.");
            }
            return BadRequest("Something has gone wrong");

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId) 
        {
            bool response = await _Mediator.Send(new DeleteProductByIdCommand { productId = productId });
            if (response)
            {
                return Ok("Product successfully deleted.");
            }
            return BadRequest("Something has gone wrong");

        }
    }
}
