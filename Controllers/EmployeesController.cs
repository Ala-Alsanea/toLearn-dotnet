using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace toLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private static List<Employees> employees = new List<Employees>{
            new Employees(),
            new Employees {Id=1,Name="creper",Title="monster"},
            new Employees {Id=2,Title="monster"}

        };

        [HttpGet("All")]
        public ActionResult<Employees> GetAll()
        {
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public ActionResult<Employees> GetOne(int id)
        {
            return Ok(employees.FirstOrDefault(c=>c.Id ==id));
        }

    }
}