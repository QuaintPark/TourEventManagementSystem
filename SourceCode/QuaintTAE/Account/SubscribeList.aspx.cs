using QuaintPark;
using QuaintTAE.Code.BLL;
using QuaintTAE.Code.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintTAE.Account
{
    public partial class SubscribeList : System.Web.UI.Page
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
                SubscribeBLL subscribeBLL = new SubscribeBLL();
                DataTable dt = subscribeBLL.GetAll();
                rptrList.DataSource = dt;
                rptrList.DataBind();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        //protected void btnActiveOrDeactive_Command(object sender, CommandEventArgs e)
        //{
        //    try
        //    {
        //        string id = Convert.ToString(e.CommandArgument);
        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            SubscribeBLL subscribeBLL = new SubscribeBLL();
        //            DataTable dt = subscribeBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
        //            if (dt != null)
        //            {
        //                if (dt.Rows.Count > 0)
        //                {
        //                    string actionStatus = "Updated";
        //                    HotelReservations hotelReservation = new HotelReservations();
        //                    hotelReservation.HotelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["HotelId"]));
        //                    hotelReservation.HotelCode = Convert.ToString(dt.Rows[0]["HotelCode"]);
        //                    hotelReservation.HotelName = Convert.ToString(dt.Rows[0]["HotelName"]);

        //                    hotelReservation.UpdatedDate = DateTime.Now;
        //                    hotelReservation.UpdatedBy = UserInfo;
        //                    hotelReservation.UpdatedFrom = StationInfo;

        //                    if (hotelReservation.IsActive)
        //                    {
        //                        hotelReservation.IsActive = false;
        //                        actionStatus = "Deactivated";
        //                    }
        //                    else
        //                    {
        //                        hotelReservation.IsActive = true;
        //                        actionStatus = "Activated";
        //                    }

        //                    if (hotelReservationBLL.Update(hotelReservation))
        //                    {
        //                        Alert(AlertType.Success, actionStatus + " successfully.");
        //                        LoadList();
        //                    }
        //                    else
        //                    {
        //                        Alert(AlertType.Error, "Failed to update.");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Alert(AlertType.Error, "Failed to process.");
        //    }
        //}

        //protected void btnDelete_Command(object sender, CommandEventArgs e)
        //{
        //    try
        //    {
        //        string id = Convert.ToString(e.CommandArgument);
        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            HotelReservationBLL hotelReservationBLL = new HotelReservationBLL();
        //            HotelReservations hotelReservation = new HotelReservations();
        //            hotelReservation.HotelId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
        //            if (hotelReservation.HotelId > 0)
        //            {
        //                if (hotelReservationBLL.Delete(hotelReservation))
        //                {
        //                    Alert(AlertType.Success, "Deleted successfully.");
        //                    LoadList();
        //                }
        //                else
        //                {
        //                    Alert(AlertType.Error, "Failed to delete.");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Alert(AlertType.Error, "Failed to delete.");
        //    }
        //}
    }
}