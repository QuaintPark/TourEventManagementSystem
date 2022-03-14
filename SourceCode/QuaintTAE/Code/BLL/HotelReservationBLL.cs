using QuaintTAE.Code.DAL;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.BLL
{
    public class HotelReservationBLL
    {
        public bool Save(HotelReservations hotelReservation)
        {
            try
            {
                HotelReservationDAL hotelReservationDAL = new HotelReservationDAL();
                return hotelReservationDAL.Save(hotelReservation);               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsEmailExist(HotelReservations hotelReservation)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Email"]).ToString() == hotelReservation.Email);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return true;
                    else
                        return false;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                HotelReservationDAL hotelReservationDAL = new HotelReservationDAL();
                return hotelReservationDAL.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAllActive()
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetById(int id)
        {
            try
            {
                HotelReservationDAL hotelReservationDAL = new HotelReservationDAL();
                return hotelReservationDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(HotelReservations hotelReservation)
        {
            try
            {
                HotelReservationDAL hotelReservationDAL = new HotelReservationDAL();
                return hotelReservationDAL.Update(hotelReservation);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(HotelReservations hotelReservation)
        {
            try
            {
                HotelReservationDAL hotelReservationDAL = new HotelReservationDAL();
                return hotelReservationDAL.Delete(hotelReservation);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}