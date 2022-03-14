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
    public partial class Event : System.Web.UI.Page
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

                if (this.MultiEntryDisallow)
                {
                    Response.Redirect("~/Account/EventList.aspx");
                }
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
        public int ModelId
        {
            set { ViewState["Id"] = value; }
            get
            {
                try
                {
                    return Convert.ToInt32(Convert.ToString(ViewState["Id"]));
                }
                catch
                {
                    return 0;
                }
            }
        }
        private string ModelCode
        {
            set { ViewState["Code"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Code"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private bool MultiEntryDisallow
        {
            set { ViewState["MultiEntryDisallow"] = value; }
            get
            {
                try
                {
                    return Convert.ToBoolean(Convert.ToString(ViewState["MultiEntryDisallow"]));
                }
                catch
                {
                    return false;
                }
            }
        }
        private string ModelSlag
        {
            set { ViewState["Slag"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Slag"]);
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
                MultiEntryDisallow = false;
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);
                LoadLocation();

                if (Request.QueryString["Id"] != null)
                {
                    this.ModelId = Convert.ToInt32(QuaintSecurityManager.DecryptUrl(Convert.ToString(Request.QueryString["Id"])));
                    Edit(this.ModelId);
                    lblTitleStatus.Text = "Update";
                    btnSave.Text = "Update";
                    btnSaveAndContinue.Text = "Update & Continue";
                    btnSaveAndContinue.Visible = false;
                }
                else
                {
                    GenerateCode();
                }
            }
        }

        private void LoadLocation()
        {
            try
            {
                LocationBLL locationBLL = new LocationBLL();
                DataTable dt = locationBLL.GetAll();
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();

                ddlLocation.Items.Insert(0, "--- Please Select ---");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void Edit(int id)
        {
            try
            {
                EventBLL evntBLL = new EventBLL();
                DataTable dt = evntBLL.GetById(id);
                if (dt != null)
                { 
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["EventId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["EventCode"]);
                        txtTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                        this.ModelSlag = Convert.ToString(dt.Rows[0]["Slag"]);
                        txtFromDate.Text = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["FromDate"])).ToString("MM/dd/yyyy");
                        txtToDate.Text = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["ToDate"])).ToString("MM/dd/yyyy");
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        ddlLocation.SelectedValue = Convert.ToString(dt.Rows[0]["LocationId"]);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to edit.");
            }
        }

        private void GenerateCode()
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                this.ModelCode = CodePrefix.Event + "-" + lib.GetSixDigitNumber(1);
                EventBLL eventBLL = new EventBLL();
                DataTable dt = eventBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["EventCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        this.ModelCode = CodePrefix.Event + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to load.");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlLocation.SelectedIndex = 0;

            txtTitle.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = true;
            SaveAndUpdate();
        }

        private void SaveAndUpdate()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    Alert(AlertType.Warning, "Enter title.");
                    txtTitle.Focus();
                }
                else if (string.IsNullOrEmpty(txtFromDate.Text))
                {
                    Alert(AlertType.Warning, "Select from date.");
                    txtFromDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtToDate.Text))
                {
                    Alert(AlertType.Warning, "Select to date.");
                    txtToDate.Focus();
                }
                else if (ddlLocation.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select location.");
                    ddlLocation.Focus();
                }
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string title = Convert.ToString(txtTitle.Text);
                    string slag = lib.ConvertToSlug(title);
                    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    int locationId = Convert.ToInt32(ddlLocation.SelectedValue);                   

                    EventBLL eventBLL = new EventBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = eventBLL.GetById(this.ModelId);
                        Events evnt = new Events();
                        evnt.EventId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["EventId"]));
                        evnt.EventCode = Convert.ToString(dt.Rows[0]["EventCode"]);
                        evnt.Title = Convert.ToString(dt.Rows[0]["Title"]);
                        evnt.Slag = Convert.ToString(dt.Rows[0]["Slag"]);
                        evnt.FromDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["FromDate"]));
                        evnt.ToDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["ToDate"]));
                        evnt.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        evnt.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        evnt.LocationId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LocationId"]));
                        evnt.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        evnt.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        evnt.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        evnt.Title = title.Trim();
                        evnt.Slag = slag;
                        evnt.FromDate = fromDate;
                        evnt.ToDate = toDate;
                        evnt.Description = description;
                        evnt.LocationId = locationId;

                        evnt.UpdatedDate = DateTime.Now;
                        evnt.UpdatedBy = this.UserInfo;
                        evnt.UpdatedFrom = this.StationInfo;

                        if (eventBLL.Update(evnt))
                        {
                            this.MultiEntryDisallow = true;
                            Alert(AlertType.Success, "Updated successfully.");
                            ClearFields();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to update.");
                        }
                    }
                    else
                    {
                        Events evnt = new Events();
                        evnt.EventCode = this.ModelCode;
                        evnt.Title = title;
                        evnt.Slag = slag;
                        evnt.FromDate = fromDate;
                        evnt.ToDate = toDate;
                        evnt.Description = description;
                        evnt.LocationId = locationId;
                        evnt.IsActive = true;
                        evnt.CreatedDate = DateTime.Now;
                        evnt.CreatedBy = this.UserInfo;
                        evnt.CreatedFrom = this.StationInfo;

                        if (eventBLL.Save(evnt))
                        {
                            Alert(AlertType.Success, "Saved successfully.");
                            ClearFields();
                            GenerateCode();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to save.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(AlertType.Error, ex.Message.ToString());
            }
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }
    }
}