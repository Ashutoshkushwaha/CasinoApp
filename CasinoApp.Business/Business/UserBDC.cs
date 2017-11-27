using CasinoApp.Business;
using CasinoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Business
{
    public class UserBDC: BDCBase, IUserBDC
    {
        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }

        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                CasinoAppValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, Constants.UserMessage.CreateUserEmail); 
                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                    IUserDTO list = userDAC.CreateUser(userDTO);
                    if (list != null)
                    {
                        retVal = OperationResult<IUserDTO>.CreateSuccessResult(list, Constants.UserMessage.Usercreatedsuccessfully);
                    }
                    else
                    {
                        retVal = OperationResult<IUserDTO>.CreateFailureResult(Constants.UserMessage.InsertionFialed);
                    }
                } 
            }
            catch (DACException dacEx)
            {

                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal; 
            //throw new NotImplementedException();
        }

        public OperationResult<IUserDTO> RechargeAmount(int id, decimal rechargeAmount)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO userDTO = userDAC.RechargeAmount(id, rechargeAmount);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
            //throw new NotImplementedException();
        }

        public OperationResult<IList<IUserDTO>> GetAllUsers()
        {
            OperationResult<IList<IUserDTO>> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IList<IUserDTO> list = userDAC.GetAllUsers();
                retVal = OperationResult<IList<IUserDTO>>.CreateSuccessResult(list);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }


        public OperationResult<IList<IUserDTO>> GetFilteredUsers(string userName, string userContact, string userEmail)
        {
            OperationResult<IList<IUserDTO>> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IList<IUserDTO> filteredList = userDAC.GetFilteredUsers(userName, userContact, userEmail);
                retVal = OperationResult<IList<IUserDTO>>.CreateSuccessResult(filteredList);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }


        public OperationResult<IUserDTO> BlockAmount(string uniqueId, int amount)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                userDTO = userDAC.BlockAmount(uniqueId, amount);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);
                               
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }


        public OperationResult<IUserDTO> ModifyAmount(string uniqueId, decimal factor)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO userDTO = userDAC.ModifyAmount(uniqueId,factor);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(userDTO);

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }
    }
}
