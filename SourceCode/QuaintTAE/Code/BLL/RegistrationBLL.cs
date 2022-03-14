using QuaintTAE.Code.DAL;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.BLL
{
    public class RegistrationBLL
    {
        public bool Save(Registrations registration)
        {
            try
            {
                RegistrationDAL registrationDAL = new RegistrationDAL();

                if (IsContactNumberExist(registration))
                {
                    throw new Exception("Contact number already exist.");
                }
                else
                {
                    return registrationDAL.Save(registration);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsContactNumberExist(Registrations registration)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["ContactNumber"]).ToString() == registration.ContactNumber);
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
                RegistrationDAL registrationDAL = new RegistrationDAL();
                return registrationDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public DataTable GetAllActive()
        //{
        //    try
        //    {
        //        DataTable dtList = GetAll();
        //        var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true);
        //        DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

        //        if (dt != null)
        //            if (dt.Rows.Count > 0)
        //                return dt;
        //            else
        //                return null;
        //        else
        //            return null;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public DataTable GetById(int id)
        {
            try
            {
                RegistrationDAL registrationDAL = new RegistrationDAL();
                return registrationDAL.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Registrations registration)
        {
            try
            {
                RegistrationDAL registartionDAL = new RegistrationDAL();
                return registartionDAL.Update(registration);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Registrations registration)
        {
            try
            {
                RegistrationDAL registrationDAL = new RegistrationDAL();
                return registrationDAL.Delete(registration);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}