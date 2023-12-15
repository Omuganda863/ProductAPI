using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web_API.Models;
using Web_API.Models.DTOS;
using Web_API.Services;
using Web_API.Services.Iservices;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Iproducts _iproducts;
        private readonly IMapper _mapper;
        private readonly ResponseDTO response = new ResponseDTO();
        public ProductsController(IMapper mapper, Iproducts iproducts)
        {
            _iproducts = iproducts;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllProductsAsync()
        {
            var products = await _iproducts.GetllProductsAsync();
            response.Result = products;
            return Ok(response);

        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> UpdateProductAsync()
        {
            var info = await _iproducts.UpdateProductAsync();
            response.Result = info;

            return Ok(response);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetProductAsync(int productId)
        {
            var pr = await _iproducts.GetProductAsync(productId);
            response.Result = pr;
            //return Ok(response);
            if (pr == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = $"Product with id `{productId}` does not exist";
                return NotFound(response);
            }
            response.Result = pr;
            return Ok(response);


        }
        [HttpPost("{product}")]
        public async Task<ActionResult<ResponseDTO>> AddProduct(Product product)
        {

           var prdct = _mapper.Map<Product>(product);
            var added = await _iproducts.AddProductAsync(prdct);
            response.StatusCode = HttpStatusCode.Created;
            response.Message = "Created Successfully";
            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult<ResponseDTO>> RemoveProduct(int id)
        {
            var deleted = await _iproducts.DeleteProductAsync(id);
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "deleted";
            return Ok(response);
        }
      
    }
}
