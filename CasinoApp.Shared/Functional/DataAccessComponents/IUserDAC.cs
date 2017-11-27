using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Shared
{
    public interface IUserDAC:  IDataAccessComponent
    {
        //IList<IUserDTO> GetAllUser
        IUserDTO CreateUser(IUserDTO userDTO);
        IUserDTO GetUserByEmail(string email);
        IUserDTO RechargeAmount(int id, decimal rechargeAmount);
        IList<IUserDTO> GetAllUsers();
        IList<IUserDTO> GetFilteredUsers(string userName, string userContact, string userEmail);
        IUserDTO BlockAmount(string uniqueId, int amount);
        IUserDTO ModifyAmount(string uniqueId, decimal factor);
        
    }
}
