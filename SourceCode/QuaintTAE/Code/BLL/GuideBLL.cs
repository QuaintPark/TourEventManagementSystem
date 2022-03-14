using QuaintTAE.Code.DAL;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.BLL
{
    public class GuideBLL
    {
        public bool Save(Guides guide)
        {
            try
            {
                GuideDAL guideDAL = new GuideDAL();

                if (IsNameExist(guide))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return guideDAL.Save(guide);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsNameExist(Guides guide)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == guide.Name);
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
                GuideDAL guideDAL = new GuideDAL();
                return guideDAL.GetAll();
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

        public DataTable GetByLocationId(int locationId)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true && ((bool)x["LocationIsActive"]) == true && ((int)x["LocationId"]) == locationId);
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
                GuideDAL guideDAL = new GuideDAL();
                return guideDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Guides guide)
        {
            try
            {
                GuideDAL guideDAL = new GuideDAL();
                return guideDAL.Update(guide);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Guides guide)
        {
            try
            {
                GuideDAL guideDAL = new GuideDAL();
                return guideDAL.Delete(guide);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}