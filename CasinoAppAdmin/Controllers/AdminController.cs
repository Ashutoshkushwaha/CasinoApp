using CasinoApp.Shared;
using PagedList;
using CasinoApp.Web.Shared;
using CasinoAppAdmin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasinoAppAdmin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public byte[] convertToBytes(HttpPostedFileBase ImageData)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(ImageData.InputStream);
            imageBytes = reader.ReadBytes((int)ImageData.ContentLength);
            return imageBytes;
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(UserRegistrationModel user)
        {
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            IUserDTO createCustomerDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            HttpPostedFileBase file = Request.Files["ImageData"];
            user.Copy_of_Id = convertToBytes(file);
            if (ModelState.IsValid) { 
                DTOConverter.FillDTOFromViewModel(createCustomerDTO, user);
                OperationResult<IUserDTO> result = userFacade.CreateUser(createCustomerDTO);
                if (result.ValidationResult != null && result.ValidationResult.Errors != null)
                {
                    IList<CasinoAppValidationFailure> resultFail = result.ValidationResult.Errors;
                    foreach (var item in resultFail)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();
                } 
            }
            return RedirectToAction("Index", "Home");
            
        }

        public ActionResult UserList(int ?page)
        {
            List<UserRegistrationModel> list = new List<UserRegistrationModel>();
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IList<IUserDTO>> result = userFacade.GetAllUsers();
            if (result.IsValid())
            {
                foreach (var user in result.Data)
                {
                    UserRegistrationModel model = new UserRegistrationModel();
                    DTOConverter.FillViewModelFromDTO(model, user);
                    list.Add(model);
                }
            }
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(list.OrderBy(item => item.Customer_Name).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Recharge(int CustomerId, decimal RechargeAmount)
        {
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> result = userFacade.RechargeAmount(CustomerId, RechargeAmount);
            if (result.IsValid())
            {
                
            }
            return RedirectToAction("UserList", "Admin");
        }

        public ActionResult GetFilteredUsers(string userName, string userContact, string userEmail)
        {
            List<UserRegistrationModel> filteredList = new List<UserRegistrationModel>();
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IList<IUserDTO>> result = userFacade.GetFilteredUsers(userName, userContact, userEmail);
            if (result.IsValid())
            {
                foreach (var user in result.Data)
                {
                    UserRegistrationModel model = new UserRegistrationModel();
                    DTOConverter.FillViewModelFromDTO(model, user);
                    filteredList.Add(model);
                }
            }
            return View("UserList", filteredList);
        }

    }
}