using System.ComponentModel.DataAnnotations;

namespace PatikaPayCoreAssignment2.Entity
{
    public class Staff
    {
        //[Required]
        public int Id { get; set; }
        //[Required]
        //[StringLength(maximumLength:120,MinimumLength =5, ErrorMessage ="Name must be range in 5-120")]
        public string Name { get; set; }

        //[Required]
        //[StringLength(maximumLength: 120, MinimumLength = 5, ErrorMessage = "Last name must be range in 5-120")]
        public string LastName { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        //[EmailAddress]
        //[RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage ="Invalid email address")]
        public string Email { get; set; }

        //[Required]
        //[Phone(ErrorMessage = "Phone number is not valid")]
        //[RegularExpression(@"^([\+]?90[-]?|[0])?[1-9][0-9]{8}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        //[Range(minimum: 2000, maximum: 9000, ErrorMessage = "Salary must be range in 2000-9000")]
        public decimal Salary { get; set; }
    }
}
