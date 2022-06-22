using ApplicationCore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Email address should be in right format")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Passowrd should have minimum 8 with at least on upper, lower, number and special character")]
        // minimum of 8 character
        // 1 number, 1 uppercase, 1 lower case
        // strong password
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // Minimum year and Max Year that a person can enter
        // Custom Validator
        [YearValidation(1900)]
        public DateTime DateOfBirth { get; set; }
    }
}
