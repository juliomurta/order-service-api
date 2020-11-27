using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;

namespace OrderService.Api.Controllers
{
    [Route(WebConstants.OrdersRouteName)]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] OrderFilter filter)
        {
            try
            {
                var result = this.orderRepository.Search(filter);
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
                var result = this.orderRepository.Get(x => x.Id == id);
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
                var result = this.orderRepository.Create(model);
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
                var result = this.orderRepository.Update(model);
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
                if (this.orderRepository.Delete(x => x.Id == id))
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
