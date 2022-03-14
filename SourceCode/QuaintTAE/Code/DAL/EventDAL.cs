using QuaintPark;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.DAL
{
    public class EventDAL
    {
        public bool Save(Events evnt)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("EventCode", evnt.EventCode);
                db.AddParameters("Title", evnt.Title);
                db.AddParameters("FromDate", evnt.FromDate);
                db.AddParameters("ToDate", evnt.ToDate);
                db.AddParameters("Description", evnt.Description);
                db.AddParameters("IsActive", evnt.IsActive);
                db.AddParameters("CreatedDate", ((evnt.CreatedDate == null) ? evnt.CreatedDate : evnt.CreatedDate.Value));
                db.AddParameters("CreatedBy", evnt.CreatedBy);
                db.AddParameters("CreatedFrom", evnt.CreatedFrom);
                db.AddParameters("UpdatedDate", ((evnt.UpdatedDate == null) ? evnt.UpdatedDate : evnt.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", evnt.UpdatedBy);
                db.AddParameters("UpdatedFrom", evnt.UpdatedFrom);
                db.AddParameters("LocationId", evnt.LocationId);
                int affectedRows = db.ExecuteNonQuery("Insert_Event", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Event", false);
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
                db.AddParameters("EventId", id);
                DataTable dt = db.ExecuteDataTable("Get_Event_By_Id", true);
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

        public bool Update(Events evnt)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("EventId", evnt.EventId);
                db.AddParameters("EventCode", evnt.EventCode);
                db.AddParameters("Title", evnt.Title);
                db.AddParameters("FromDate", evnt.FromDate);
                db.AddParameters("ToDate", evnt.ToDate);
                db.AddParameters("Description", evnt.Description);
                db.AddParameters("IsActive", evnt.IsActive);
                db.AddParameters("CreatedDate", ((evnt.CreatedDate == null) ? evnt.CreatedDate : evnt.CreatedDate.Value));
                db.AddParameters("CreatedBy", evnt.CreatedBy);
                db.AddParameters("CreatedFrom", evnt.CreatedFrom);
                db.AddParameters("UpdatedDate", ((evnt.UpdatedDate == null) ? evnt.UpdatedDate : evnt.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", evnt.UpdatedBy);
                db.AddParameters("UpdatedFrom", evnt.UpdatedFrom);
                db.AddParameters("LocationId", evnt.LocationId);
                int affectedRows = db.ExecuteNonQuery("Update_Event", true);

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

        public bool Delete(Events evnt)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("EventId", evnt.EventId);
                int affectedRows = db.ExecuteNonQuery("Delete_Event", true);

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