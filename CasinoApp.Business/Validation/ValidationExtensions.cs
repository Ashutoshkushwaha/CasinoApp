using CasinoApp.Shared;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Business
{
    public static class ValidationExtensions
    {
        public static CasinoAppValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<CasinoAppValidationFailure> errors = new List<CasinoAppValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new CasinoAppValidationResult(errors);
        }

        public static CasinoAppValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new CasinoAppValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }
    }
}
