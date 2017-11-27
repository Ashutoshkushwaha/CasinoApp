using CasinoApp.EntityDataModel;
using CasinoApp.EntityDataModel.EntityModel;
using CasinoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Data
{
    public class UserDAC: DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }


        public IUserDTO CreateUser(IUserDTO userDTO)
        {
            IUserDTO retVal = null;
            userDTO.Unique_User_Id = userDTO.Email_Id;
            userDTO.Account_Balance = 500;
            userDTO.Blocked_Amount = 0;

            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {
      
                    CustomerList customer = new CustomerList();
                    EntityConverter.FillEntityFromDTO(userDTO, customer);
                    context.CustomerLists.Add(customer);
                    if (context.SaveChanges() > 0)
                    {
                        userDTO.Customer_Id = customer.Customer_Id; 
                        retVal = userDTO;
                    }
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;
            //throw new NotImplementedException();
        }

        public IUserDTO RechargeAmount(int id, decimal rechargeAmount)
        {
            IUserDTO retVal = null;
            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {

                    
                    CustomerList customer = context.CustomerLists.Where(item => item.Customer_Id == id).FirstOrDefault();
                    if (customer !=  null)
                    {
                        customer.Account_Balance += rechargeAmount;
                    }
                    if (context.SaveChanges() > 0)
                    {
                        EntityConverter.FillDTOFromEntity(customer, retVal);
                    }
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;
            
            //throw new NotImplementedException();
        }

        public IList<IUserDTO> GetAllUsers()
        {
            IList<IUserDTO> retVal = new List<IUserDTO>();
            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {

                    foreach (var user in context.CustomerLists)
                    {
                        IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityConverter.FillDTOFromEntity(user, userDTO);
                        retVal.Add(userDTO);
               
                    }
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;           
        }


        public IList<IUserDTO> GetFilteredUsers(string userName, string userContact, string userEmail)
        {
            IList<IUserDTO> retVal = new List<IUserDTO>();
            IList<SearchCustomer_Result> filteredList = new List<SearchCustomer_Result>();
            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {
                    if (userName == "")
                    {
                        userName = null;
                    }
                    if (userContact == "")
                    {
                        userContact = null;
                    }
                    if (userEmail == "")
                    {
                        userEmail = null;
                    }
                    filteredList = (IList<SearchCustomer_Result>)context.SearchCustomer(userName, userContact, userEmail).ToList();
                    foreach (var user in filteredList)
                    {
                        IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityConverter.FillDTOFromEntity(user, userDTO);
                        retVal.Add(userDTO);

                    }
                    
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;
        }


        public IUserDTO BlockAmount(string uniqueId, int amount)
        {
            IUserDTO retVal = null;
            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {


                    CustomerList customer = context.CustomerLists.Where(item => item.Unique_User_Id == uniqueId).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.Blocked_Amount = amount;
                        customer.Account_Balance -= amount;
                        if (context.SaveChanges() > 0)
                        {
                            retVal = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityConverter.FillDTOFromEntity(customer, retVal);
                        }
                        
                    }
                    
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;
        }

        public IUserDTO GetUserByEmail(string email)
        {
            IUserDTO createUserRetval = null;

            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {
                    CustomerList playerDetails = context.CustomerLists.FirstOrDefault(item => item.Email_Id == email);

                    if (playerDetails != null)
                    {
                        createUserRetval = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(playerDetails, createUserRetval);

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetval;

        }


        public IUserDTO ModifyAmount(string uniqueId, decimal factor)
        {
            IUserDTO retVal = null;
            try
            {
                using (CasioAppEntities context = new CasioAppEntities())
                {


                    CustomerList customer = context.CustomerLists.Where(item => item.Unique_User_Id == uniqueId).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.Account_Balance += (decimal)(factor * customer.Blocked_Amount) ;
                        customer.Blocked_Amount = 0;
                        if (context.SaveChanges() > 0)
                        {
                            retVal = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityConverter.FillDTOFromEntity(customer, retVal);
                        }
                        
                    }
                    
                    
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;
        }
    }
}
