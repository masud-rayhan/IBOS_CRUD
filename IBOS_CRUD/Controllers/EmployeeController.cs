using IBOS_CRUD.DataAccess;
using IBOS_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBOS_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        ///////////API01///////////
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,Employee employee)
        {
            if(id != employee.EmployeeId)
            {
                return BadRequest();
            }

            

            if (_dbContext.Employees.Any(x=> x.EmployeeCode == employee.EmployeeCode && x.EmployeeId !=id))
            {
                return BadRequest("Employee Code Duplicated");
            }


            _dbContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Employee emp = _dbContext.Employees.Find(id);

                if (emp== null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

                
            }

            return Ok(employee);
        }



        ///////////API02///////////
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var empList = _dbContext.Employees.OrderByDescending(x=> x.EmployeeSalary).ToList() ;
            return Ok(empList);
        }


    }
}
