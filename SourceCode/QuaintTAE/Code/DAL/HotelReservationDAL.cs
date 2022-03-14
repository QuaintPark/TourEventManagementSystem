using QuaintPark;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.DAL
{
    public class HotelReservationDAL
    {
        public bool Save(HotelReservations hotelReservation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("HotelCode", hotelReservation.HotelCode);
                db.AddParameters("HotelName", hotelReservation.HotelName);
                db.AddParameters("ArrivalDate", hotelReservation.ArrivalDate);
                db.AddParameters("DepartureDate", hotelReservation.DepartureDate);
                db.AddParameters("RoomType", hotelReservation.RoomType);
                db.AddParameters("BookedBy", hotelReservation.BookedBy);
                db.AddParameters("Email", hotelReservation.Email);
                db.AddParameters("ContactNumber", hotelReservation.ContactNumber);
                db.AddParameters("Address", hotelReservation.Address);
                db.AddParameters("IsActive", hotelReservation.IsActive);
                db.AddParameters("CreatedDate", ((hotelReservation.CreatedDate == null) ? hotelReservation.CreatedDate : hotelReservation.CreatedDate.Value));
                db.AddParameters("CreatedBy", hotelReservation.CreatedBy);
                db.AddParameters("CreatedFrom", hotelReservation.CreatedFrom);
                db.AddParameters("UpdatedDate", ((hotelReservation.UpdatedDate == null) ? hotelReservation.UpdatedDate : hotelReservation.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", hotelReservation.UpdatedBy);
                db.AddParameters("UpdatedFrom", hotelReservation.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_HotelReservation", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public DataTable GetAll()
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                DataTable dt = db.ExecuteDataTable("Get_All_HotelReservation", false);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public DataTable GetById(int id)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                db.AddParameters("HotelId", id);
                DataTable dt = db.ExecuteDataTable("Get_HotelReservation_By_Id", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public bool Update(HotelReservations hotelReservation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("HotelId", hotelReservation.HotelId);
                db.AddParameters("HotelCode", hotelReservation.HotelCode);
                db.AddParameters("HotelName", hotelReservation.HotelName);
                db.AddParameters("ArrivalDate", hotelReservation.ArrivalDate);
                db.AddParameters("DepartureDate", hotelReservation.DepartureDate);
                db.AddParameters("RoomType", hotelReservation.RoomType);
                db.AddParameters("BookedBy", hotelReservation.BookedBy);
                db.AddParameters("Email", hotelReservation.Email);
                db.AddParameters("ContactNumber", hotelReservation.ContactNumber);
                db.AddParameters("Address", hotelReservation.Address);
                db.AddParameters("IsActive", hotelReservation.IsActive);
                db.AddParameters("CreatedDate", ((hotelReservation.CreatedDate == null) ? hotelReservation.CreatedDate : hotelReservation.CreatedDate.Value));
                db.AddParameters("CreatedBy", hotelReservation.CreatedBy);
                db.AddParameters("CreatedFrom", hotelReservation.CreatedFrom);
                db.AddParameters("UpdatedDate", ((hotelReservation.UpdatedDate == null) ? hotelReservation.UpdatedDate : hotelReservation.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", hotelReservation.UpdatedBy);
                db.AddParameters("UpdatedFrom", hotelReservation.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_hotelReservation", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public bool Delete(HotelReservations hotelReservation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("HotelId", hotelReservation.HotelId);
                int affectedRows = db.ExecuteNonQuery("Delete_HotelReservation", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }
    }
}