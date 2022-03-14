using QuaintPark;
using QuaintTAE.Code.BLL;
using QuaintTAE.Code.Global;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintTAE.Account
{
    public partial class RegistrationList : System.Web.UI.Page
    {
        // Message Box Method(s)
        private void Alert(AlertType alertType, string message)
        {
            alertMessage.InnerHtml = Core.AlertBox(alertType, message);
            tmrAlertMessage.Enabled = true;
            tmrAlertMessage.Interval = Core.AlertBoxInternal;
        }

        protected void tmrAlertMessage_Tick(object sender, EventArgs e)
        {
            if (tmrAlertMessage.Interval == Core.AlertBoxInternal)
            {
                alertMessage.InnerHtml = string.Empty;
                tmrAlertMessage.Enabled = false;
            }
        }



        // View State(s)
        private string UserInfo
        {
            set { ViewState["UserInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["UserInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private string StationInfo
        {
            set { ViewState["StationInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["StationInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

                LoadList();
            }
        }

        private void LoadList()
        {
            try
            {
                RegistrationBLL registrationBLL = new RegistrationBLL();
                DataTable dt = registrationBLL.GetAll();
                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void btnActiveOrDeactive_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    RegistrationBLL registrationBLL = new RegistrationBLL();
                    DataTable dt = registrationBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Registrations registration = new Registrations();
                            registration.RegistrationId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["RegistrationId"]));
                            registration.RegistrationCode = Convert.ToString(dt.Rows[0]["RegistrationCode"]);
                            registration.FullName = Convert.ToString(dt.Rows[0]["FullName"]);
                            registration.Email = Convert.ToString(dt.Rows[0]["Email"]);
                            registration.ContactNumber = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                            registration.Address = Convert.ToString(dt.Rows[0]["Address"]);
                            registration.EventId = Convert.ToInt32(dt.Rows[0]["EventId"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to process.");
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    RegistrationBLL registrationBLL = new RegistrationBLL();
                    Registrations registration = new Registrations();
                    registration.RegistrationId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (registration.RegistrationId > 0)
                    {
                        if (registrationBLL.Delete(registration))
                        {
                            Alert(AlertType.Success, "Deleted successfully.");
                            LoadList();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to delete.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to delete.");
            }
        }
    }
}