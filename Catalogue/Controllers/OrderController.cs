using Catalogue.Core.Interfaces;
using Catalogue.Extensions;
using Catalogue.Models.Request;
using Catalogue.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Controllers
{
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("LoadOrders")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponseModel>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> LoadOrders([FromQuery]LoadOrdersRequestModel model)
        {
            var response = orderService.SearchOrderAsync(User.GetCustomerId(), model.SearchText);
            return new JsonResult(response);
        }
    }
}