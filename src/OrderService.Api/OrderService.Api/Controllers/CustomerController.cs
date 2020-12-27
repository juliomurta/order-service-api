using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Service.Interface;

namespace OrderService.Api.Controllers
{
    [Route(WebConstants.CustomersRouteName)]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CustomerFilter filter)
        {
            try
            {
                var result = this.customerService.Search(filter);
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
                var result = this.customerService.Get(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Customer model)
        {
            try
            {
                var result = this.customerService.Create(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Customer model)
        {
            try
            {
                model.Id = id;
                var result = this.customerService.Update(model);
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
                if(this.customerService.Delete(x => x.Id == id))
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
