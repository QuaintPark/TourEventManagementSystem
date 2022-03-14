using QuaintTAE.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintTAE.Pages
{
    public partial class Guide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLocation();
                LoadList(0);
            }
        }

        private void LoadLocation()
        {
            try
            {
                LocationBLL locationBLL = new LocationBLL();
                DataTable dt = locationBLL.GetAllActive();
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();

                ddlLocation.Items.Insert(0, "All Guide");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadList(int locationId)
        {
            try
            {
                GuideBLL guideBLL = new GuideBLL();
                DataTable dt = new DataTable();

                if (locationId > 0)
                    dt = guideBLL.GetByLocationId(locationId);
                else
                    dt = guideBLL.GetAllActive();

                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLocation.SelectedIndex == 0)
                {
                    LoadList(0);
                }
                else
                {
                    int locationId = Convert.ToInt32(Convert.ToString(ddlLocation.SelectedValue));
                    LoadList(locationId);
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}