using CasinoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.DTOModel
{
    [ViewModelMapping("CasinoAppAdmin.Models.UserRegistrationModel", MappingType.TotalExplicit)]
    [EntityMapping("CasinoApp.EntityDataModel.EntityModel.CustomerLists", MappingType.TotalExplicit)]
    public class UserDTO: DTOBase, IUserDTO
    {
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Customer_Id")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Customer_Id")]
        public int Customer_Id { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Customer_Name")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Customer_Name")]
        public string Customer_Name { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "DOB")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "DOB")]
        public System.DateTime DOB { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Contact_Number")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Contact_Number")]
        public string Contact_Number { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Email_Id")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Email_Id")]
        public string Email_Id { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Copy_of_Id")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Copy_of_Id")]
        public byte[] Copy_of_Id { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Account_Balance")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Account_Balance")]
        public decimal Account_Balance { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Blocked_Amount")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Blocked_Amount")]
        public decimal Blocked_Amount { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Unique_User_Id")] 
        [EntityPropertyMapping(MappingDirectionType.Both, "Unique_User_Id")]
        public string Unique_User_Id { get; set; }
    }
}
