//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasinoApp.EntityDataModel.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerList
    {
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public System.DateTime DOB { get; set; }
        public string Contact_Number { get; set; }
        public string Email_Id { get; set; }
        public byte[] Copy_of_Id { get; set; }
        public decimal Account_Balance { get; set; }
        public decimal Blocked_Amount { get; set; }
        public string Unique_User_Id { get; set; }
    }
}
