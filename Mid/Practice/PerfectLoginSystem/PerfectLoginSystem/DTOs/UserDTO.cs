using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PerfectLoginSystem.DTOs
{
    public class NoSpecialCharactersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                if (Regex.IsMatch(stringValue, @"^[a-zA-Z\s]+$"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The field should not contain special characters or numbers.");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        [Required]
        [NoSpecialCharacters]
        public string FirstName { get; set; }
        [Required]
        [NoSpecialCharacters]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public System.DateTime DOB { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}