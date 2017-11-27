using CasinoApp.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Business
{
    public class UserValidator : AbstractValidator<IUserDTO>
    {
        public UserValidator()
        {
            RuleSet("CreateUserEmail", () =>
            {
                RuleFor(user => user.Email_Id).Must(IsUniqueEmail).WithMessage(Constants.UserMessage.EmailUnique);
                RuleFor(user => user.DOB).Must(CalcAge).WithMessage(Constants.UserMessage.AgeError);
            });
        }
        private bool IsUniqueEmail(string arg)
        {
            IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
            IUserDTO userDTO = userDAC.GetUserByEmail(arg);
            return userDTO == null;
        }

        private bool CalcAge(DateTime dob)
        {
            int age = ((DateTime.Now.Year - dob.Year) * 372 + (DateTime.Now.Month - dob.Month) * 31 + (DateTime.Now.Day - dob.Day)) / 372;
            if (age > 18)
            {
                return true;
            }
            else
            {
                return false;
            } 
 

        }
    }

}
