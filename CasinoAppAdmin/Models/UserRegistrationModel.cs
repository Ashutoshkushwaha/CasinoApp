using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CasinoAppAdmin.Models
{
    public class UserRegistrationModel
    {
        public int Customer_Id { get; set; }
        [RegularExpression(@"^[a-zA-z]+$",ErrorMessage = "Only Alphabets and spaces are permitted")]
        [Required]
        public string Customer_Name { get; set; }
        [Required]
        public System.DateTime DOB { get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "Contact Number should be of 10 digits")]
        [Required]
        public string Contact_Number { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email_Id { get; set; }
        public byte[] Copy_of_Id { get; set; }
        public decimal Account_Balance { get; set; }
        public decimal Blocked_Amount { get; set; }
        public string Unique_User_Id { get; set; }
    }
}