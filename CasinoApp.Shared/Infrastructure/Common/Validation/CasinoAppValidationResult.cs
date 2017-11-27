using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Shared
{
    public class CasinoAppValidationResult
    {
        public IList<CasinoAppValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public CasinoAppValidationResult(IList<CasinoAppValidationFailure> failures)
        {
            Errors = failures;
        }

        public CasinoAppValidationResult()
        {
            Errors = new List<CasinoAppValidationFailure>();
        }
    }
}
