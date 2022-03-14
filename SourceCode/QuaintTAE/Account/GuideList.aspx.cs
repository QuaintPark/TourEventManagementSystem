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
    public partial class GuideList : System.Web.UI.Page
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
                GuideBLL guideBLL = new GuideBLL();
                DataTable dt = guideBLL.GetAll();
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
                    GuideBLL guideBLL = new GuideBLL();
                    DataTable dt = guideBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Guides guide = new Guides();
                            guide.GuideId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["GuideId"]));
                            guide.GuideCode = Convert.ToString(dt.Rows[0]["GuideCode"]);
                            guide.Name = Convert.ToString(dt.Rows[0]["Name"]);
                            guide.ContactNumber = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                            guide.Email = Convert.ToString(dt.Rows[0]["Email"]);
                            guide.AddressLine1 = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                            guide.AddressLine2 = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                            guide.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            guide.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            guide.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            guide.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);
                            guide.LocationId = Convert.ToInt32(dt.Rows[0]["LocationId"]);

                            guide.UpdatedDate = DateTime.Now;
                            guide.UpdatedBy = UserInfo;
                            guide.UpdatedFrom = StationInfo;

                            if (guide.IsActive)
                            {
                                guide.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                guide.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (guideBLL.Update(guide))
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
                    GuideBLL guideBLL = new GuideBLL();
                    Guides guide = new Guides();
                    guide.GuideId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (guide.GuideId > 0)
                    {
                        if (guideBLL.Delete(guide))
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