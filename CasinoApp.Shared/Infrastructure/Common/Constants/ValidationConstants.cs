using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CasinoApp.Shared
{
   public static class ValidationConstants
    {


       public static class CommonMessages
       {
           public static string common = "Common";
           public static string admin = "admin";
           public static string update = "update";
           public static string create = "create";
           public static string employee = "Employee";
       }
       public static class DepartmentMessages
       {
           public static string getAllFailed = "Get All Departments Failed";
           public static string getDeptFailed = "Getting Department Failed";
       }
       public static class NoticeMessages
       {
           public static string currentFailed = "Getting current Notices Failed";
           public static string activeFailed = "Getting active Notices Failed";
           public static string deleteFailed = "Deleting Notice Failed";
           public static string updateFailed = "Updating Notice Failed";
           public static string createFailed = "Create Notice Failed";

           public static string title = "Title";
           public static string emptyTitle = "Title Cannot be empty";
           public static string titleLength = "Title length must be between 1 to 100 characters";
           public static string description = "Description";
           public static string emptyDescription = "Description Cannot be empty";
           public static string descriptionLength = "Description length must be between 1 to 500 characters";
           public static string startDate = "StartDate";
           public static string emptyDate = "Date Cannot be empty";
           public static string expirationDate = "ExpirationDate";
           public static string expirationDateGreaterThanError = "Expiration Date should be greater than Start Date";
       }
       public static class IssueMessages
       {
           public static string createFailed = "Create Issue Failed";
           public static string delelteFailed = "Delete Issue Failed";
           public static string updateAdminFailed = "Update Issue By Admin Failed";
           public static string updateNonAdminFailed = "Update Issue By Non Admin Failed";
           public static string gettIssueIdFailed = "Getting Issue By EmployeeId Failed";
           public static string gettIssueFailed = "Getting Issue By IssueId Failed";
           public static string gettActiveIssueFailed = "Getting Active Issues Failed";

           public static string title = "Title";
           public static string emptyTitle = "Title Cannot be empty";
           public static string titleLength = "Title length must be between 1 to 100 characters";
           public static string description = "Description";
           public static string emptyDescription = "Description Cannot be empty";
           public static string descriptionLength = "Description length must be between 1 to 500 characters";
           public static string emptyPriority = "Priority Cannot be empty it should be either of NORMAL , URGENT , IMMEDIATE";
           public static string commentsLength = "Comments length should be between 1 to 500 characters";
           public static string emptyAssignedTo = "AssignedTo cannot be empty";
           public static string statusError = "Status cannot be empty it should be either of OPEN , WORK IN PROGRESS , CLOSED";
       }
       public static class IssueHistoryMessages
       {
           public static string commentsLength = "Comments length should be between 1 to 500 characters";
           public static string emptyAssignedTo = "AssignedTo cannot be empty";
           public static string statusError = "Status cannot be empty it should be either of OPEN , WORK IN PROGRESS , CLOSED";
       }
       public static class UserMessages
       {
           public static string createFailed = "Create User Failed";
           public static string delelteFailed = "Delete User Failed";
           public static string updateFailed = "Update User Failed";
           public static string searchFailed = "Searchng User Failed";
           public static string getUserByEmailFailed = "Getting User By Email Id Failed";
           
           
           public static string emptyFirstName = "First Name cannot be empty";
           public static string emptyLastName = "Lasat Name Cannot be empty";
           public static string firstNameLength = "First Name length should be between 1 to 100 characters";
           public static string lastNameLength = "Second Name length should be between 1 to 100 characters";
           public static string emptyDateofJoining = "Date Of Joining cannot be empty";
           public static string emptyTerminationDate = "Termination Date cannot be empty";
           public static string terminationDateError = "Termination Date cannot be less than Date of Joining";
           public static string emptyEmail = "Email cannot be empty";
           public static string emailInValid = "Not a valid email ID";
           public static string emptyPassword = "Password Cannot be empty";
           public static string passwordLength = "Password Must be between 8 to 16 characters";
           public static string passwordInValid = "Password is invalid.  Must contain atleas 1 numeric character , 1 special character out of (!, @, #, $, %, ^, &, *, ~, ?, .) ";
           public static string existingEmailError = "Email Id already exists";
           public static string specialChar = "!@#$%^&*~?.";
           public static string DatelessError = "Date Should be less than todays date";
       }
       public static Regex hasNumber = new Regex(@"[0-9]+");
       
       public static Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
       
    }

}
