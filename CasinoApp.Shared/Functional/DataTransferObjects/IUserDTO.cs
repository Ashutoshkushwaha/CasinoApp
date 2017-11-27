using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Shared
{
    public interface IUserDTO: IDTO
    {
        int Customer_Id { get; set; }
        string Customer_Name { get; set; }
        System.DateTime DOB { get; set; }
        string Contact_Number { get; set; }
        string Email_Id { get; set; }
        byte[] Copy_of_Id { get; set; }
        decimal Account_Balance { get; set; }
        decimal Blocked_Amount { get; set; }
        string Unique_User_Id { get; set; }
    }
}
