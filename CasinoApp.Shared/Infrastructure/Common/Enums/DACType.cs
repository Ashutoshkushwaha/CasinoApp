namespace CasinoApp.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {

        [QualifiedTypeName("CasinoApp.Data.dll", "CasinoApp.Data.SampleDAC")]
        SampleDAC = 0,
        [QualifiedTypeName("CasinoApp.Data.dll", "CasinoApp.Data.UserDAC")]
        UserDAC = 1,
       
      
    }
}
