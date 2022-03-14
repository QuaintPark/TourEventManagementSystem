using QuaintTAE.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintTAE.Account
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardInfo();
            }
        }

        private void LoadDashboardInfo()
        {
            try
            {
                //Total Guide
                GuideBLL guideBLL = new GuideBLL();
                DataTable dtGuide = guideBLL.GetAll();
                lblTotalGuide.Text = Convert.ToString(Convert.ToInt32(dtGuide.Rows.Count));

                //Total Event
                EventBLL eventBLL = new EventBLL();
                DataTable dtEvent = eventBLL.GetAll();
                lblTotalEvent.Text = Convert.ToString(Convert.ToInt32(dtEvent.Rows.Count));

                //Total Location
                LocationBLL locationBLL = new LocationBLL();
                DataTable dtLocation = locationBLL.GetAll();
                lblTotalLocation.Text = Convert.ToString(Convert.ToInt32(dtLocation.Rows.Count));

                //Total Hotel Reservation
                HotelReservationBLL hotelReservationBLL = new HotelReservationBLL();
                DataTable dtHotelReservation = hotelReservationBLL.GetAll();
                lblTotalHotelReservation.Text = Convert.ToString(Convert.ToInt32(dtHotelReservation.Rows.Count));

                //Total Registration
                RegistrationBLL registrationBLL = new RegistrationBLL();
                DataTable dtRegistration = registrationBLL.GetAll();
                lblTotalRegistration.Text = Convert.ToString(Convert.ToInt32(dtRegistration.Rows.Count));

                //Total Registration
                //SubscribeBLL subscribeBLL = new SubscribeBLL();
                //DataTable dtSubscribe = subscribeBLL.GetAll();
                //lblTotalSubscribe.Text = Convert.ToString(Convert.ToInt32(dtSubscribe.Rows.Count));
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}