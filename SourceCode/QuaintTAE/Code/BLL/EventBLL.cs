using QuaintTAE.Code.DAL;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.BLL
{
    public class EventBLL
    {
        public bool Save(Events evnt)
        {
            try
            {
                EventDAL evntDAL = new EventDAL();

                if (IsTitleExist(evnt))
                {
                    throw new Exception("Title already exist.");
                }
                else
                {
                    return evntDAL.Save(evnt);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsTitleExist(Events evnt)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Title"]).ToString() == evnt.Title);
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
                EventDAL evntDAL = new EventDAL();
                return evntDAL.GetAll();
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
                EventDAL evntDAL = new EventDAL();
                return evntDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Events evnt)
        {
            try
            {
                EventDAL evntDAL = new EventDAL();
                return evntDAL.Update(evnt);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Events evnt)
        {
            try
            {
                EventDAL evntDAL = new EventDAL();
                return evntDAL.Delete(evnt);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}