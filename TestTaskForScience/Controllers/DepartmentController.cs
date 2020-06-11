using BLL.Interfaces;
using BLL.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TestTaskForScience.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentAsync(Guid id)
        {
            var departments = await _departmentService.GetDepartmentAsync(id);
            return Ok(departments);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var allDepartments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(allDepartments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentModel departmentModel)
        {
            await _departmentService.CreateDepartmentAsync(departmentModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkObjectResult> DeleteDepartmentAsync(Guid id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<OkObjectResult> UpdateDepartment(Guid id, DepartmentModel departmentModel)
        {
            var result = await _departmentService.UpdateDepartmentAsync(id, departmentModel);
            return Ok(result);
        }
    }
}