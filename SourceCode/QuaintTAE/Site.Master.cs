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

namespace QuaintTAE
{
    public partial class Site : System.Web.UI.MasterPage
    {

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
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);
                GenerateCode();
            }
        }

        private void GenerateCode()
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                ModelCode = CodePrefix.Email + "-" + lib.GetSixDigitNumber(1);
                SubscribeBLL subscribeBLL = new SubscribeBLL();
                DataTable dt = subscribeBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["EmailCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Email + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                //Alert(AlertType.Error, "Failed to load.");
            }
        }

        private void ClearFields()
        {
            txtEmail.Text = string.Empty;
            txtEmail.Focus();
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                string email = Convert.ToString(txtEmail.Text);

                SubscribeBLL subscribeBLL = new SubscribeBLL();
                Subscribes subscribe = new Subscribes();

                subscribe.EmailCode = this.ModelCode;
                subscribe.Email=email;

                if (subscribeBLL.Save(subscribe))
                {
                    ClearFields();
                    GenerateCode();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}