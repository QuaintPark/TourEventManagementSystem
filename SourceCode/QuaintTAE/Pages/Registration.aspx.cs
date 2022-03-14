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

namespace QuaintTAE.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
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



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MultiEntryDisallow = false;
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);
                GenerateCode();

                if (Request.QueryString["Id"] != null)
                {
                    this.ModelId = Convert.ToInt32(QuaintSecurityManager.DecryptUrl(Convert.ToString(Request.QueryString["Id"])));
                }
            }
        }

        private void GenerateCode()
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                ModelCode = CodePrefix.Registration + "-" + lib.GetSixDigitNumber(1);
                RegistrationBLL registrationBLL = new RegistrationBLL();
                DataTable dt = registrationBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["RegistrationCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Registration + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to load.");
            }
        }

        private void ClearFileds()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;

            txtName.Focus();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Alert(AlertType.Warning, "Enter full name.");
                    txtName.Focus();
                }
                else if (string.IsNullOrEmpty(txtContactNumber.Text))
                {
                    Alert(AlertType.Warning, "Enter email.");
                    txtContactNumber.Focus();
                }
                else if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtAddress.Focus();
                }
                else
                {
                        Alert(AlertType.Information, "Please, wait...");
                        QuaintLibraryManager lib = new QuaintLibraryManager();
                        string fullName = Convert.ToString(txtName.Text);
                        string email = Convert.ToString(txtEmail.Text);
                        string contactNumber = Convert.ToString(txtContactNumber.Text);
                        string address = Convert.ToString(txtAddress.Text);

                        RegistrationBLL registrationBLL = new RegistrationBLL();
                        if (this.ModelId > 0)
                        {
                            Registrations registration = new Registrations();
                            registration.RegistrationCode = this.ModelCode;
                            registration.FullName = fullName;
                            registration.Email = email;
                            registration.ContactNumber = contactNumber;
                            registration.Address = address;
                            registration.EventId = this.ModelId;

                            if (registrationBLL.Save(registration))
                            {
                                Alert(AlertType.Success, "Registration successful.");
                                ClearFileds();
                                GenerateCode();
                            }
                            else
                            {
                                Alert(AlertType.Error, "Failed to registration.");
                            }
                        }
                    }
                }
            
            catch (Exception ex)
            {
                Alert(AlertType.Error, ex.Message.ToString());
            }
        }
    }
}