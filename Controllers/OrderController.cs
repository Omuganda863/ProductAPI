using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.Models.DTOS;
using Web_API.Services;
using Web_API.Services.Iservices;
using System.Net;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Iorders orders;
        private readonly IMapper mapper;
        private readonly ResponseDTO responseDTO = new ResponseDTO();
        public OrderController(Iorders order, IMapper mapper)
        {
            this.orders = order;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllOrders()
        {
            var products = await orders.GetAllOrdersAsync();
            responseDTO.Result = products;
            return Ok(responseDTO);

        }
        //[HttpPost]
        //public async Task<ActionResult<ResponseDTO>> CreateOrder(AddOrdersDTO AddOrder)
        //{
        //    var newOrder = mapper.Map<Order>(AddOrder);
        //    var success = await orders.CreateOrderAsync(newOrder);
        //    if (success)
        //    {
        //        responseDTO.StatusCode = HttpStatusCode.Created;
        //        responseDTO.Message = "Order Created";
        //        return Ok(responseDTO);
        //    }
        //    responseDTO.StatusCode = HttpStatusCode.InternalServerError;
        //    responseDTO.Message = "System Error";
        //    return StatusCode(500, responseDTO);
        //}








    }

}