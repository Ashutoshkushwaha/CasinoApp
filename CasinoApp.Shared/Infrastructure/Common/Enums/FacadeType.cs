using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
       
        /// <summary>
        /// Notice Facade
        /// </summary>
        [QualifiedTypeName("CasinoApp.BusinessFacade.dll", "CasinoApp.BusinessFacade.SampleFacade")]
        SampleFacade = 0,
        [QualifiedTypeName("CasinoApp.BusinessFacade.dll", "CasinoApp.BusinessFacade.UserFacade")]
        UserFacade = 1
    }
}
