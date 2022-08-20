using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaPayCoreAssignment2.Entity;
using PatikaPayCoreAssignment2.FluentValidation;
using System.Linq;

namespace PatikaPayCoreAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        StaffValidator staffValidator = new StaffValidator();

        private static List<Staff> StaffList = new List<Staff>() 
        { 
            new Staff 
            {
                Id=1,Name="Şeyma",
                LastName="Dönmez",
                Email="seymadonmezz1@gmail.com",
                PhoneNumber="+905554443322",
                DateOfBirth=new DateTime(1994,09,21),
                Salary=5000},
            new Staff 
            {
                Id=2,
                Name="Eda",
                LastName="Dönmez",
                Email="eda@gmail.com",
                PhoneNumber="+905554443322",
                DateOfBirth=new DateTime(1998,05,13),
                Salary=6000}
        };
        public StaffController()
        {

        }


        [HttpGet]
        [Route("Get")]
        public List<Staff> Get()
        {
            var staffList = StaffList.OrderBy(x => x.Id).ToList<Staff>();
            return staffList;
        }



        [HttpPost]
        [Route("AddStaff")]
        public IActionResult AddStaff([FromBody] Staff request)
        {
            ValidationResult result = staffValidator.Validate(request, options => options.ThrowOnFailures());

            if (result.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.er);
            }
            //if (ModelState.IsValid)
            //{
            //    StaffList.Add(request);
            //    return Ok();
            //}

            //else return BadRequest();
        }
    }
}

