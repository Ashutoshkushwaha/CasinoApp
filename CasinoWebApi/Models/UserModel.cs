using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasinoWebApi.Models
{
    public class UserModel
    {
        public string Customer_Name { get; set; }
        public string Contact_Number { get; set; }
        public string Email_Id { get; set; }
        public decimal Account_Balance { get; set; }
        public decimal Blocked_Amount { get; set; }
        public string Unique_User_Id { get; set; }
    }
}