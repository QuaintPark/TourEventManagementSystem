using QuaintPark;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.DAL
{
    public class LocationDAL
    {
        public bool Save(Locations location)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("LocationCode", location.LocationCode);
                db.AddParameters("Name", location.Name);
                db.AddParameters("Description", location.Description);
                db.AddParameters("IsActive", location.IsActive);
                db.AddParameters("CreatedDate", ((location.CreatedDate == null) ? location.CreatedDate : location.CreatedDate.Value));
                db.AddParameters("CreatedBy", location.CreatedBy);
                db.AddParameters("CreatedFrom", location.CreatedFrom);
                db.AddParameters("UpdatedDate", ((location.UpdatedDate == null) ? location.UpdatedDate : location.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", location.UpdatedBy);
                db.AddParameters("UpdatedFrom", location.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Location", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Location", false);
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
                db.AddParameters("LocationId", id);
                DataTable dt = db.ExecuteDataTable("Get_Location_By_Id", true);
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

        public bool Update(Locations location)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("LocationId", location.LocationId);
                db.AddParameters("LocationCode", location.LocationCode);
                db.AddParameters("Name", location.Name);
                db.AddParameters("Description", location.Description);
                db.AddParameters("IsActive", location.IsActive);
                db.AddParameters("CreatedDate", ((location.CreatedDate == null) ? location.CreatedDate : location.CreatedDate.Value));
                db.AddParameters("CreatedBy", location.CreatedBy);
                db.AddParameters("CreatedFrom", location.CreatedFrom);
                db.AddParameters("UpdatedDate", ((location.UpdatedDate == null) ? location.UpdatedDate : location.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", location.UpdatedBy);
                db.AddParameters("UpdatedFrom", location.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Location", true);

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

        public bool Delete(Locations location)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("LocationId", location.LocationId);
                int affectedRows = db.ExecuteNonQuery("Delete_Location", true);

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