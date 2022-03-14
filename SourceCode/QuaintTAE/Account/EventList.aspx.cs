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
    public partial class EventList : System.Web.UI.Page
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
                EventBLL eventBLL = new EventBLL();
                DataTable dt = eventBLL.GetAll();
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
                    EventBLL eventBLL = new EventBLL();
                    DataTable dt = eventBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Events evnt = new Events();
                            evnt.EventId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["EventId"]));
                            evnt.EventCode = Convert.ToString(dt.Rows[0]["EventCode"]);
                            evnt.Title = Convert.ToString(dt.Rows[0]["Title"]);
                            evnt.Slag = Convert.ToString(dt.Rows[0]["Slag"]);
                            evnt.FromDate = Convert.ToDateTime(dt.Rows[0]["FromDate"]);
                            evnt.ToDate = Convert.ToDateTime(dt.Rows[0]["ToDate"]);
                            evnt.Description = Convert.ToString(dt.Rows[0]["Description"]);
                            evnt.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            evnt.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            evnt.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            evnt.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);
                            evnt.LocationId = Convert.ToInt32(dt.Rows[0]["LocationId"]);

                            evnt.UpdatedDate = DateTime.Now;
                            evnt.UpdatedBy = UserInfo;
                            evnt.UpdatedFrom = StationInfo;

                            if (evnt.IsActive)
                            {
                                evnt.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                evnt.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (eventBLL.Update(evnt))
                            {
                                Alert(AlertType.Success, actionStatus + " successfully.");
                                LoadList();
                            }
                            else
                            {
                                Alert(AlertType.Error, "Failed to update.");
                            }
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
                    EventBLL eventBLL = new EventBLL();
                    Events evnt = new Events();
                    evnt.EventId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (evnt.EventId > 0)
                    {
                        if (eventBLL.Delete(evnt))
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