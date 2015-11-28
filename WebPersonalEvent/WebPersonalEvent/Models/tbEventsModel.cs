using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Security;
using System.Web.Mvc;
using System.Data;

namespace MvcPersonalEventsOrganization.Models
{
    #region Models
   

    public class tbEventsModel
    {
        
        [DefaultValue(0)]
        [DataType(DataType.Text)]
        [DisplayName("ID")]
        public string ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("EventType")]
        public string EventType { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("EventDate (MM/dd/yyyy)")]
        public DateTime EventDate { get; set; }


        [DataType(DataType.Text)]
        [DisplayName("Remarks")]
        public string Remarks { get; set; }
    }
    #endregion


    #region Services
    
    public class tbEventsModelService 
    {              
        public MembershipCreateStatus CreateEvent(string ID, string EventType,DateTime EventDate,string Remarks)
        {
            try
            {
                int intUserId =Convert.ToInt32(HttpContext.Current.Session["LoginUserId"]);
                if (String.IsNullOrEmpty(EventType)) throw new ArgumentException("Value cannot be null or empty.", "EventType");
                if (default(DateTime) == (EventDate)) throw new ArgumentException("Value cannot be null or empty.", "EventDate");

                //Insert
                string strSQL = "";
                if (ID == "0" || ID == "" || ID==null)
                    strSQL = "INSERT INTO tbEvents VALUES(" + intUserId + ", '" + EventType + "', '" + EventDate.ToString("MM/dd/yyyy") + "', '" + (Remarks == "" ? " " : Remarks) + "')";
                else
                    strSQL = "UPDATE tbEvents SET intUserId=" + intUserId + ", EventType='" + EventType + "', EventDate='" + EventDate.ToString("MM/dd/yyyy") + "', Remarks='" + (Remarks == "" ? " " : Remarks) + "' WHERE ID=" + ID;

                new SQLData().ExecuteQuery(strSQL);

                return MembershipCreateStatus.Success;
            }
            catch (Exception)
            {
                throw new ArgumentException("Error in save event details.", "EventType");
            }
            
        }

        //Get List of Events 
        public DataTable GetEvents(String ID)
        {
            try
            {
                int intUserId = Convert.ToInt32(HttpContext.Current.Session["LoginUserId"]);
                string strSQL = @"select CONVERT(varchar,EventDate,103) as EventDate,ID, intUserId, EventType, Remarks   from tbevents where intUserId=" + intUserId;

                if (!(ID == "0" || ID == "" || ID == null))
                    strSQL = strSQL + " and ID=" + ID;

                return new SQLData().GetData(strSQL);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        //Get List of Events 
        public void DeleteEvent(String ID)
        {
            try
            {
                int intUserId = Convert.ToInt32(HttpContext.Current.Session["LoginUserId"]);
                string strSQL = @"delete from tbevents where intUserId=" + intUserId + " and id = "+ID;                
                
                new SQLData().ExecuteQuery(strSQL);
            }
            catch (Exception)
            {                
            }
        }
    }




    #endregion

}