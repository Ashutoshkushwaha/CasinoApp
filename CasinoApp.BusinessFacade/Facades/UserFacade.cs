using CasinoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.BusinessFacade
{
    public class UserFacade: FacadeBase, IUserFacade
    {
        public UserFacade()
            : base(FacadeType.UserFacade)
        {

        }


        public OperationResult<IUserDTO> CreateUser(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.CreateUser(userDTO);
            //throw new NotImplementedException();
        }

        public OperationResult<IUserDTO> RechargeAmount(int id, decimal rechargeAmount)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.RechargeAmount(id, rechargeAmount);
            //throw new NotImplementedException();
        }

        public OperationResult<IList<IUserDTO>> GetAllUsers()
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetAllUsers();
            //throw new NotImplementedException();
        }

        public OperationResult<IList<IUserDTO>> GetFilteredUsers(string userName, string userContact, string userEmail)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetFilteredUsers(userName, userContact, userEmail);
            //throw new NotImplementedException();
        }


        public OperationResult<IUserDTO> BlockAmount(string uniqueId, int amount)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.BlockAmount(uniqueId, amount);
            
        }


        public OperationResult<IUserDTO> ModifyAmount(string uniqueId, decimal factor)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.ModifyAmount(uniqueId, factor);
        }
    }
}
