namespace CasinoApp.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {

        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("CasinoApp.DTOModel.dll", "CasinoApp.DTOModel.SampleDTO")]
        SampleDTO = 1,
        [QualifiedTypeName("CasinoApp.DTOModel.dll", "CasinoApp.DTOModel.UserDTO")]
        UserDTO = 2,

    }
}
