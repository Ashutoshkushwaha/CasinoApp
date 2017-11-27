namespace CasinoApp.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        [QualifiedTypeName("CasinoApp.Business.dll", "CasinoApp.Business.SampleBDC")]
        SampleBDC = 0,
        [QualifiedTypeName("CasinoApp.Business.dll", "CasinoApp.Business.UserBDC")]
        UserBDC = 1,
        
    }
}
