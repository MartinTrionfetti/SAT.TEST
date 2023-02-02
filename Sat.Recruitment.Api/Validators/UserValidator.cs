using Sat.Recruitment.Api.Models;
using System;

namespace Sat.Recruitment.Api.Validators
{
    public class UserValidator
    {
        //Validate errors  
        public Tuple<bool, string> ValidateErrors(User user)
        {
            var errors = "";
            if (string.IsNullOrWhiteSpace(user.Name)) errors += "Name is required. ";

            if (string.IsNullOrWhiteSpace(user.Email)) errors += "Email is required. ";
            else
            {
                var atIndex = user.Email.IndexOf("@");
                var dotIndex = user.Email.LastIndexOf(".");
                if (atIndex <= 0 || dotIndex <= 0 || dotIndex <= atIndex)
                {
                    errors += "Email is not valid. ";
                }
            }

            if (string.IsNullOrWhiteSpace(user.Address)) errors += "Address is required. ";
            if (string.IsNullOrWhiteSpace(user.Phone)) errors += "Phone is required. ";

            //If we return false we have to read errors string.
            return new Tuple<bool, string>(string.IsNullOrWhiteSpace(errors), errors);
        }
    }
}
