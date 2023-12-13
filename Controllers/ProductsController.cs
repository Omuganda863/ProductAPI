using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.Models.DTOS;
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
    }
}
