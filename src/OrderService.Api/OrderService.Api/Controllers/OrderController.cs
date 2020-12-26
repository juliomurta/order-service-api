using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service.Interface;

namespace OrderService.Api.Controllers
{
    [Route(WebConstants.OrdersRouteName)]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] OrderFilter filter)
        {
            try
            {
                var result = this.orderService.Search(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = this.orderService.Get(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order model)
        {
            try
            {
                var result = this.orderService.Create(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Order model)
        {
            try
            {
                model.Id = id;
                var result = this.orderService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (this.orderService.Delete(x => x.Id == id))
                {
                    return Ok("Removed sucessfully");
                }
                else
                {
                    return BadRequest("Not removed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }
    }
}
