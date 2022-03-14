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
    public partial class Guide : System.Web.UI.Page
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
                    Response.Redirect("~/Account/GuideList.aspx");
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



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiEntryDisallow = false;
                //QuaintSessionManager session = new QuaintSessionManager();
                //UserInfo = Convert.ToString(session.ActiveUserInformation);
                //StationInfo = Convert.ToString(session.ActiveStationInformation);
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
                GuideBLL guideBLL = new GuideBLL();
                DataTable dt = guideBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["GuideId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["GuideCode"]);
                        txtName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                        txtContactNumber.Text = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                        txtAddressLine1.Text = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                        txtAddressLine2.Text = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                        txtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);
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
                ModelCode = CodePrefix.Guide + "-" + lib.GetSixDigitNumber(1);
                GuideBLL guideBLL = new GuideBLL();
                DataTable dt = guideBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["GuideCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Guide + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtName.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            ddlLocation.SelectedIndex = 0;

            txtName.Focus();
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
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Alert(AlertType.Warning, "Enter name.");
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtContactNumber.Text))
                {
                    Alert(AlertType.Warning, "Enter contact number.");
                    txtContactNumber.Focus();
                }
                else if (string.IsNullOrEmpty(txtAddressLine1.Text))
                {
                    Alert(AlertType.Warning, "Enter address line 1.");
                    txtAddressLine1.Focus();
                }
                else if (ddlLocation.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select location.");
                    ddlLocation.Focus();
                }
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string Name = Convert.ToString(txtName.Text);
                    string contactNumber = Convert.ToString(txtContactNumber.Text);
                    string email = Convert.ToString(txtEmail.Text);
                    string addressLine1 = Convert.ToString(txtAddressLine1.Text);
                    string addressLine2 = Convert.ToString(txtAddressLine2.Text);
                    int locationId = Convert.ToInt32(ddlLocation.SelectedValue);

                    GuideBLL guideBLL = new GuideBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = guideBLL.GetById(this.ModelId);
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
                        guide.LocationId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["LocationId"]));

                        guide.Name = Name;
                        guide.ContactNumber = contactNumber;
                        guide.Email = email;
                        guide.AddressLine1 = addressLine1;
                        guide.AddressLine2 = addressLine2;
                        guide.LocationId = locationId;

                        guide.UpdatedDate = DateTime.Now;
                        guide.UpdatedBy = this.UserInfo;
                        guide.UpdatedFrom = this.StationInfo;

                        if (guideBLL.Update(guide))
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
                        Guides guide = new Guides();
                        guide.GuideCode = this.ModelCode; 
                        guide.Name = Name;
                        guide.ContactNumber = contactNumber;
                        guide.Email = email;
                        guide.AddressLine1 = addressLine1;
                        guide.AddressLine2 = addressLine2;
                        guide.IsActive = true;
                        guide.CreatedDate = DateTime.Now;
                        guide.CreatedBy = this.UserInfo;
                        guide.CreatedFrom = this.StationInfo;
                        guide.LocationId = locationId;

                        if (guideBLL.Save(guide))
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