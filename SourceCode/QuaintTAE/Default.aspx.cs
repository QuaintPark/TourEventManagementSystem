using QuaintTAE.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintTAE
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProgram();
            }
        }

        private void LoadProgram()
        {
            try
            {
                EventBLL evntBLL = new EventBLL();
                DataTable dt = evntBLL.GetAllActive();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrEvent.DataSource = dt;
                        rptrEvent.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}