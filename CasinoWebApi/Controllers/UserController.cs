using CasinoApp.Shared;
using CasinoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CasinoWebApi
{
    public class UserController : ApiController
    {
        [HttpGet]
        public List<UserModel> GetUser()
        {
            List<UserModel> list = new List<UserModel>();
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IList<IUserDTO>> result = userFacade.GetAllUsers();
            if (result.IsValid())
            {
                foreach (var user in result.Data)
                {
                    UserModel model = new UserModel();
                    model.Contact_Number = user.Contact_Number;
                    model.Customer_Name = user.Customer_Name;
                    model.Account_Balance = user.Account_Balance;
                    model.Email_Id = user.Email_Id;
                    model.Blocked_Amount = user.Blocked_Amount;
                    model.Unique_User_Id = user.Unique_User_Id;
                    list.Add(model);
                }
            }
            return list;
        }

        [HttpGet]
        public UserModel GetUser(string id)
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            UserModel model = new UserModel();
            List<UserModel> list = new List<UserModel>();
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IList<IUserDTO>> result = userFacade.GetAllUsers();
            if (result.IsValid())
            {
                foreach (var user in result.Data)
                {
                    if (user.Unique_User_Id == id)
                    {
                        model.Contact_Number = user.Contact_Number;
                        model.Customer_Name = user.Customer_Name;
                        model.Account_Balance = user.Account_Balance;
                        model.Email_Id = user.Email_Id;
                        model.Blocked_Amount = user.Blocked_Amount;
                        model.Unique_User_Id = user.Unique_User_Id;                                       
                    }
                }
            }
            return model;            
        }

        [HttpPut]
        public UserModel BlockAmount(string id, int amount)
            {
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            UserModel model = new UserModel();
            OperationResult<IUserDTO> result = userFacade.BlockAmount(id, amount);
            if (result.IsValid())
            {
                model.Contact_Number = result.Data.Contact_Number;
                model.Customer_Name = result.Data.Customer_Name;
                model.Account_Balance = result.Data.Account_Balance;
                model.Email_Id = result.Data.Email_Id;
                model.Blocked_Amount = result.Data.Blocked_Amount;
                model.Unique_User_Id = result.Data.Unique_User_Id;              
            }
            return model;
        }

        [HttpPut]
        public UserModel ModifyAmount(string id, decimal factor)
        {
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            UserModel model = new UserModel();
            OperationResult<IUserDTO> result = userFacade.ModifyAmount(id, factor);
            if (result.IsValid())
            {
                model.Contact_Number = result.Data.Contact_Number;
                model.Customer_Name = result.Data.Customer_Name;
                model.Account_Balance = result.Data.Account_Balance;
                model.Email_Id = result.Data.Email_Id;
                model.Blocked_Amount = result.Data.Blocked_Amount;
                model.Unique_User_Id = result.Data.Unique_User_Id;
            }
            return model;
        }
    }
}
