using QuaintTAE.Code.DAL;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.BLL
{
    public class SubscribeBLL
    {
        public bool Save(Subscribes subscribe)
        {
            try
            {
                SubscribeDAL subscribeDAL = new SubscribeDAL();

                if (IsEmailExist(subscribe))
                {
                    throw new Exception("Email already exist.");
                }
                else
                {
                    return subscribeDAL.Save(subscribe);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsEmailExist(Subscribes subscribe)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Email"]).ToString() == subscribe.Email);
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
                SubscribeDAL subscribeDAL = new SubscribeDAL();
                return subscribeDAL.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Subscribes subscribe)
        {
            try
            {
                SubscribeDAL subscribeDAL = new SubscribeDAL();
                return subscribeDAL.Delete(subscribe);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}