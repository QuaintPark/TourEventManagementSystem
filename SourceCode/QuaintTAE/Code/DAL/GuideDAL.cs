using QuaintPark;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.DAL
{
    public class GuideDAL
    {
        public bool Save(Guides guide)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("GuideCode", guide.GuideCode);
                db.AddParameters("Name", guide.Name);
                db.AddParameters("ContactNumber", guide.ContactNumber);
                db.AddParameters("Email", guide.Email);
                db.AddParameters("AddressLine1", guide.AddressLine1);
                db.AddParameters("AddressLine2", guide.AddressLine2);
                db.AddParameters("IsActive", guide.IsActive);
                db.AddParameters("CreatedDate", ((guide.CreatedDate == null) ? guide.CreatedDate : guide.CreatedDate.Value));
                db.AddParameters("CreatedBy", guide.CreatedBy);
                db.AddParameters("CreatedFrom", guide.CreatedFrom);
                db.AddParameters("UpdatedDate", ((guide.UpdatedDate == null) ? guide.UpdatedDate : guide.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", guide.UpdatedBy);
                db.AddParameters("UpdatedFrom", guide.UpdatedFrom);
                db.AddParameters("LocationId", guide.LocationId);
                int affectedRows = db.ExecuteNonQuery("Insert_Guide", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Guide", false);
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
                db.AddParameters("GuideId", id);
                DataTable dt = db.ExecuteDataTable("Get_Guide_By_Id", true);
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

        public bool Update(Guides guide)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("GuideId", guide.GuideId);
                db.AddParameters("GuideCode", guide.GuideCode);
                db.AddParameters("Name", guide.Name);
                db.AddParameters("ContactNumber", guide.ContactNumber);
                db.AddParameters("Email", guide.Email);
                db.AddParameters("AddressLine1", guide.AddressLine1);
                db.AddParameters("AddressLine2", guide.AddressLine2);
                db.AddParameters("IsActive", guide.IsActive);
                db.AddParameters("CreatedDate", ((guide.CreatedDate == null) ? guide.CreatedDate : guide.CreatedDate.Value));
                db.AddParameters("CreatedBy", guide.CreatedBy);
                db.AddParameters("CreatedFrom", guide.CreatedFrom);
                db.AddParameters("UpdatedDate", ((guide.UpdatedDate == null) ? guide.UpdatedDate : guide.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", guide.UpdatedBy);
                db.AddParameters("UpdatedFrom", guide.UpdatedFrom);
                db.AddParameters("LocationId", guide.LocationId);
                int affectedRows = db.ExecuteNonQuery("Update_Guide", true);

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

        public bool Delete(Guides guide)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("GuideId", guide.GuideId);
                int affectedRows = db.ExecuteNonQuery("Delete_Guide", true);

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