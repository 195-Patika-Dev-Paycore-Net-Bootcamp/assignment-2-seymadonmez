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



        //private static List<Staff> StaffList = new List<Staff>()
        //{
        //    new Staff
        //    {
        //        Id=1,Name="Şeyma",
        //        LastName="Dönmez",
        //        Email="seymadonmezz1@gmail.com",
        //        PhoneNumber="+905554443322",
        //        DateOfBirth=new DateTime(1994,09,21),
        //        Salary=5000},
        //    new Staff
        //    {
        //        Id=2,
        //        Name="Eda",
        //        LastName="Dönmez",
        //        Email="eda@gmail.com",
        //        PhoneNumber="+905554443322",
        //        DateOfBirth=new DateTime(1998,05,13),
        //        Salary=6000}
        //};

        private List<Staff> staffList;

        public StaffController()
        {
            staffList = new List<Staff>();

            Staff staff1= new Staff
            {
                Id = 1,
                Name = "Şeyma",
                LastName = "Dönmez",
                Email = "seymadonmezz1@gmail.com",
                PhoneNumber = "+905554443322",
                DateOfBirth = new DateTime(1994, 09, 21),
                Salary = 5000
            };

            Staff staff2 =new Staff
            {
                Id = 2,
                Name = "Eda",
                LastName = "Dönmez",
                Email = "eda@gmail.com",
                PhoneNumber = "+905554443322",
                DateOfBirth = new DateTime(1998, 05, 13),
                Salary = 6000
            };
            staffList.Add(staff1);
            staffList.Add(staff2);
            staffList.Add(new Staff { Id = 3, Name = "Aylin", LastName = "Sezgin", DateOfBirth = new DateTime(1999, 08, 19), Email = "aylin@aylin.com", PhoneNumber = "905554443322", Salary = 5500 });
        }


        [HttpGet("GetAll")]
        public List<Staff> GetAll()
        {
            var result = staffList.OrderBy(x => x.Id).ToList<Staff>();
            return result;
        }



        [HttpPost("AddStaff")]
        public IActionResult AddStaff([FromBody] Staff request)
        {
            ValidationResult result = staffValidator.Validate(request);

            if (result.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            //if (ModelState.IsValid)
            //{
            //    StaffList.Add(request);
            //    return Ok();
            //}

            //else return BadRequest();
        }

        [HttpGet("GetById/{id}")]
        public Staff GetById(int id)
        {
            var staff = staffList.Where(x => x.Id == id).SingleOrDefault();
            return staff;
        }

        [HttpPut("UpdateStaff")]
        public IActionResult UpdateStaff([FromBody] Staff updatedStaff, int id)
        {
            var staff = staffList.Where(x => x.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                staff.Name = updatedStaff.Name != default ? updatedStaff.Name : staff.Name;
                staff.LastName = updatedStaff.LastName != default ? updatedStaff.LastName : staff.LastName;
                staff.Email = updatedStaff.Email != default ? updatedStaff.Email : staff.Email;
                staff.DateOfBirth = updatedStaff.DateOfBirth != default ? updatedStaff.DateOfBirth : staff.DateOfBirth;
                staff.Salary = updatedStaff.Salary != default ? updatedStaff.Salary : staff.Salary;

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            var staff = staffList.SingleOrDefault(x=>x.Id==id);

            if(staff is null)
            {
                return BadRequest();
            }
            else
            {
                staffList.Remove(staff);
                return Ok();
            }
        }
    }
}

