using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Web.Mvc;

namespace MvcPersonalEventsOrganization.Models
{
  

    public class tbUsersServices
    {

        //Check for user Login or not
        public  Boolean isUserLogin() 
        {
            try
            {
                return Convert.ToInt32(HttpContext.Current.Session["LoginUserId"]) > 0;
            }catch(Exception)
            {
                return false;                    
            }
        }

        //Validate user
        public Boolean ValidateUser(string userName, string password)
        {
            DataTable dt=new SQLData().GetData("SELECT ID FROM tbUsers WHERE Username='" + userName + "' AND Password='" + password + "'");
            if (dt.Rows.Count != 0)
            {
                HttpContext.Current.Session["LoginUserId"] = dt.Rows[0][0].ToString();
                return true;
            }
            else
                return false;

        }

        public MembershipCreateStatus CreateUser(string Username, string Password, string Email, string FirtName, string LastName, DateTime DateOfBirth)
        {
            try
            {

                //Dupdate User
                if(new SQLData().GetData("SELECT ID FROM tbUsers WHERE Username='" + Username+ "'").Rows.Count != 0)
                    return MembershipCreateStatus.DuplicateUserName;

                if(Pro_ValidateEmail(Email)==false)
                    return MembershipCreateStatus.InvalidEmail;

                if (Password.Length<3)
                    return MembershipCreateStatus.InvalidPassword;

                string strSQL = "INSERT INTO tbUsers VALUES('" + Username + "', '" + Password + "', '" + Email + "', '" + FirtName + "', '" + LastName + "', '" + String.Format("{0:MM/dd/yy}",DateOfBirth) + "')";
                new SQLData().ExecuteQuery(strSQL);
                return MembershipCreateStatus.Success;
            }
            catch (Exception)
            {
                return MembershipCreateStatus.ProviderError;
            }
        }

        public Boolean Pro_ValidateEmail(string strEmail)
        {
            string email = strEmail;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
        
    }
}