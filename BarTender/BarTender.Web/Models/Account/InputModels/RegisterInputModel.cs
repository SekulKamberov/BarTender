using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarTender.Web.Models.Account.InputModels
{
    public class RegisterInputModel
    {
        private const int UsernameMinimumLength = 4;
        private const int PasswordMinimumLength = 8;

        private const string EmailErrorMessage = "Please enter valid e-mail address";
        private const string UsernameRegex = "^[^@]*$";
        private const string UsernameRegexErrorMessage = "Username should not contain @ symbol";
        private const string UsernameErrorMessage = "Username should be at last 4 symbols long";
        private const string PasswordErrorMessage = "Password should be at last 8 symbols long";

        [Required]
        [EmailAddress(ErrorMessage = EmailErrorMessage)]
        public string Email { get; set; }


        [Required]
        [RegularExpression(UsernameRegex, ErrorMessage = UsernameRegexErrorMessage)]
        [MinLength(UsernameMinimumLength, ErrorMessage = UsernameErrorMessage)]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        [Required] 
        [MinLength(PasswordMinimumLength, ErrorMessage = PasswordErrorMessage)]
        public string Password { get; set; }
    }
}
