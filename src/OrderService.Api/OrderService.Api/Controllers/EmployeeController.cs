using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Model;
using OrderService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Controllers
{
    [Route(WebConstants.EmployeesRouteName)]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] EmployeeFilter filter)
        {
            try
            {
                var result = this.employeeService.Search(filter);
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
                var result = this.employeeService.Get(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee model)
        {
            try
            {
                var result = this.employeeService.Create(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: { ex.Message }");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Employee model)
        {
            try
            {
                model.Id = id;
                var result = this.employeeService.Update(model);
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
                if (this.employeeService.Delete(x => x.Id == id))
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


        public IActionResult UploadDocument([FromBody] UploadFileViewModel uploadFileViewModel)
        {
            try
            {
                if (uploadFileViewModel == null)
                {
                    return BadRequest("Arguments cannot be null.");
                }

                string tempFolder = Path.Combine(Path.GetTempPath(), uploadFileViewModel.EmployeeId.ToString());
                Directory.CreateDirectory(tempFolder);

                var fileName = Path.Combine(tempFolder, uploadFileViewModel.FileName);

                using (var fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    fs.Write(uploadFileViewModel.FileAsByteArray, 0, uploadFileViewModel.FileAsByteArray.Length);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
