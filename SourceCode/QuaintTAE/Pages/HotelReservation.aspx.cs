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
    public partial class HotelReservation : System.Web.UI.Page
    {
        // Defined variable
        //private int totalAllowRoom = 30;


        // Message Box Method(s)
        private void Alert(AlertType alertType, string message)
        {
            //alertMessage.InnerHtml = Core.AlertBox(alertType, message);
            tmrAlertMessage.Enabled = true;
            tmrAlertMessage.Interval = Core.AlertBoxInternal;
        }

        protected void tmrAlertMessage_Tick(object sender, EventArgs e)
        {
            if (tmrAlertMessage.Interval == Core.AlertBoxInternal)
            {
                //alertMessage.InnerHtml = string.Empty;
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
                if (Request.QueryString["Ref"] != null)
                {
                    if (Convert.ToString(Request.QueryString["Ref"]).ToString().ToLower() == "success")
                        Alert(AlertType.Success, "Saved successfully.");
                }

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
                ModelCode = CodePrefix.Hotel + "-" + lib.GetSixDigitNumber(1);
                HotelReservationBLL hotelReservationBLL = new HotelReservationBLL();
                DataTable dt = hotelReservationBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["HotelCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Hotel + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to load.");
            }
        }

        private void ClearFields()
        {
            txtHotelName.Text = string.Empty;
            txtArrivalDate.Text = string.Empty;
            txtDepartureDate.Text = string.Empty;
            txtRoomType.Text = string.Empty;
            txtBookedBy.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;

            txtHotelName.Focus();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHotelName.Text))
                {
                    Alert(AlertType.Warning, "Enter hotel name.");
                    txtHotelName.Focus();
                }
                else if (string.IsNullOrEmpty(txtArrivalDate.Text))
                {
                    Alert(AlertType.Warning, "Enter date of arrival.");
                    txtArrivalDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtDepartureDate.Text))
                {
                    Alert(AlertType.Warning, "Enter date of departure.");
                    txtDepartureDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtRoomType.Text))
                {
                    Alert(AlertType.Warning, "Enter room type.");
                    txtRoomType.Focus();
                }
                else if (string.IsNullOrEmpty(txtBookedBy.Text))
                {
                    Alert(AlertType.Warning, "Enter booked by name.");
                    txtBookedBy.Focus();
                }
                else if (string.IsNullOrEmpty(txtContactNumber.Text))
                {
                    Alert(AlertType.Warning, "Enter contact number.");
                    txtContactNumber.Focus();
                }
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string hotelName = Convert.ToString(txtHotelName.Text);
                    DateTime arrivalDate = Convert.ToDateTime(txtArrivalDate.Text);
                    DateTime departureDate = Convert.ToDateTime(txtDepartureDate.Text);
                    string roomType = Convert.ToString(txtRoomType.Text);
                    string bookedBy = Convert.ToString(txtBookedBy.Text);
                    string email = Convert.ToString(txtEmail.Text);
                    string contactNumber = Convert.ToString(txtContactNumber.Text);
                    string address = Convert.ToString(txtAddress.Text);


                    HotelReservationBLL hotelReservationBLL = new HotelReservationBLL();
                    HotelReservations hotelReservation = new HotelReservations();
                    hotelReservation.HotelCode = this.ModelCode;
                    hotelReservation.HotelName = hotelName;
                    hotelReservation.ArrivalDate = arrivalDate;
                    hotelReservation.DepartureDate = departureDate;
                    hotelReservation.RoomType = roomType;
                    hotelReservation.BookedBy = roomType;
                    hotelReservation.Email = email;
                    hotelReservation.ContactNumber = contactNumber;
                    hotelReservation.Address = address;
                    hotelReservation.IsActive = true;
                    hotelReservation.CreatedDate = DateTime.Now;
                    hotelReservation.CreatedBy = this.UserInfo;
                    hotelReservation.CreatedFrom = this.StationInfo;

                    //DataTable dtAvailableRoom = hotelReservationBLL.GetAllActive();
                    //int totalAvailableRoom = dtAvailableRoom.Rows.Count;
                    if (hotelReservationBLL.Save(hotelReservation))
                    {
                        //Alert(AlertType.Success, "Saved successfully.");
                        Alert(AlertType.Success, "Saved successfully.");
                        ClearFields();
                        GenerateCode();

                        Response.Redirect("~/Pages/HotelReservation.aspx?Ref=success", false);
                    }
                    else
                    {
                        Alert(AlertType.Error, "Failed to save.");
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