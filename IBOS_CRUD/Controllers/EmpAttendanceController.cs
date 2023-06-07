using IBOS_CRUD.DataAccess;
using IBOS_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBOS_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpAttendanceController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        ////////API03//////////

        [HttpGet]
        public async Task<IActionResult> GetAbsentEmployee()
        {
            var absEmployeeList =  _dbContext.EmpAttendeances.Where(x=>x.isAbsent==true).ToList().DistinctBy(x=>x.EmployeeId);

            return Ok(absEmployeeList);
        }


    }
}
