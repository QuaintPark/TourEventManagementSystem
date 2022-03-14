using QuaintTAE.Code.DAL;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.BLL
{
    public class LocationBLL
    {
        public bool Save(Locations location)
        {
            try
            {
                LocationDAL locationDAL = new LocationDAL();

                if (IsNameExist(location))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return locationDAL.Save(location);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameExist(Locations location)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == location.Name);
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
                LocationDAL locationDAL = new LocationDAL();
                return locationDAL.GetAll();
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
                LocationDAL locationDAL = new LocationDAL();
                return locationDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Locations location)
        {
            try
            {
                LocationDAL locationDAL = new LocationDAL();
                return locationDAL.Update(location);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Locations location)
        {
            try
            {
                LocationDAL locationDAL = new LocationDAL();
                return locationDAL.Delete(location);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}