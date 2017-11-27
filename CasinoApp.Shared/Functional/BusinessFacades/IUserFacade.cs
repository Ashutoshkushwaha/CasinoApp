using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp.Shared
{
    public interface IUserFacade: IFacade 
    {
        //OperationResult<IList<IUserDTO>> SearchEmployee(IUserDTO searchEmployeeDTO, bool checkTerminationDate);
        OperationResult<IUserDTO> CreateUser(IUserDTO userDTO);
        OperationResult<IUserDTO> RechargeAmount(int id, decimal rechargeAmount);
        OperationResult<IList<IUserDTO>> GetAllUsers();
        OperationResult<IList<IUserDTO>> GetFilteredUsers(string userName, string userContact, string userEmail);
        OperationResult<IUserDTO> BlockAmount(string uniqueId, int amount);
        OperationResult<IUserDTO> ModifyAmount(string uniqueId, decimal factor);  
        
    }
}
