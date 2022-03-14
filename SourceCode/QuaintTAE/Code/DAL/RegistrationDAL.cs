using QuaintPark;
using QuaintTAE.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.DAL
{
    public class RegistrationDAL
    {
        public bool Save(Registrations registration)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("RegistrationCode", registration.RegistrationCode);
                db.AddParameters("FullName", registration.FullName);
                db.AddParameters("Email", registration.Email);
                db.AddParameters("ContactNumber", registration.ContactNumber);
                db.AddParameters("Address", registration.Address);
                db.AddParameters("EventId", registration.EventId);
                int affectedRows = db.ExecuteNonQuery("Insert_Registration", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Registration", false);
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
                db.AddParameters("RegistrationId", id);
                DataTable dt = db.ExecuteDataTable("Get_Registration_By_Id", true);
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

        public bool Update(Registrations registration)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("EventId", registration.EventId);
                db.AddParameters("RegistrationId", registration.RegistrationId);
                db.AddParameters("RegistrationCode", registration.RegistrationCode);
                db.AddParameters("FullName", registration.FullName);
                db.AddParameters("Email", registration.Email);
                db.AddParameters("ContactNumber", registration.ContactNumber);
                db.AddParameters("Address", registration.Address);
                db.AddParameters("EventId", registration.EventId);
                int affectedRows = db.ExecuteNonQuery("Update_Registration", true);

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

        public bool Delete(Registrations registration)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("RegistrationId", registration.EventId);
                int affectedRows = db.ExecuteNonQuery("Delete_Registration", true);

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