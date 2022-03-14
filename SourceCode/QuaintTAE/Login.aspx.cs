using QuaintTAE.Code.Global;
using QuaintTAE.Code.Model;
using QuaintTAE.Code.BLL;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuaintTAE
{
    public partial class Login : System.Web.UI.Page
    {
        // Message Box Method(s)
        private void Alert(AlertType alertType, string message)
        {
            alertMessage.InnerHtml = Core.AlertBox(alertType, message);
            tmrAlertMessage.Enabled = true;
            tmrAlertMessage.Interval = Core.AlertBoxInternal;
        }

        protected void tmrAlertMessage_Tick(object sender, EventArgs e)
        {
            if (tmrAlertMessage.Interval == Core.AlertBoxInternal)
            {
                alertMessage.InnerHtml = string.Empty;
                tmrAlertMessage.Enabled = false;
            }
        }



        // View State(s)
        private List<UsersModel> UserList
        {
            set { ViewState["UserList"] = value; }
            get
            {
                try
                {
                    if ((List<UsersModel>)ViewState["UserList"] == null)
                    {
                        return null;
                    }
                    else
                    {
                        return (List<UsersModel>)ViewState["UserList"];
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        private List<UsersModel> MemberList
        {
            set { ViewState["MemberList"] = value; }
            get
            {
                try
                {
                    if ((List<UsersModel>)ViewState["MemberList"] == null)
                    {
                        return null;
                    }
                    else
                    {
                        return (List<UsersModel>)ViewState["MemberList"];
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        private string ModelReference
        {
            set { ViewState["Reference"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Reference"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ModelReference = "admin";
                AccountLogout();
                LoadUser();

                if (Request.QueryString["Ref"] != null)
                {
                    if (Convert.ToString(Request.QueryString["Ref"]).ToLower() == "admin")
                    {
                        this.ModelReference = "admin";
                        AccountLogout();
                    }
                    else if (Convert.ToString(Request.QueryString["Ref"]).ToLower() == "member")
                    {
                        this.ModelReference = "member";
                        AccountLogout();
                    }
                    else if (Convert.ToString(Request.QueryString["Ref"]).ToLower() == "logout")
                    {
                        this.ModelReference = "logout";
                        AccountLogout();
                    }
                }
            }
        }

        private void AccountLogout()
        {
            QuaintSessionManager session = new QuaintSessionManager();
            session.RemoveAll();
            session.ClearAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
        }



        // User
        private void LoadUser()
        {
            try
            {
                UserBLL userBLL = new UserBLL();
                DataTable dt = userBLL.GetAllActive();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        List<UsersModel> usrList = new List<UsersModel>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            UsersModel usersModel = new UsersModel();
                            usersModel.UserId = Convert.ToInt32(Convert.ToString(dt.Rows[i]["UserId"]));
                            usersModel.UserCode = Convert.ToString(dt.Rows[i]["UserCode"]);
                            usersModel.FullName = Convert.ToString(dt.Rows[i]["FullName"]);
                            usersModel.Email = Convert.ToString(dt.Rows[i]["Email"]);
                            usersModel.UserName = Convert.ToString(dt.Rows[i]["UserName"]);
                            usersModel.Password = Convert.ToString(dt.Rows[i]["Password"]);
                            usersModel.PasswordStamp = Convert.ToString(dt.Rows[i]["PasswordStamp"]);
                            usersModel.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[i]["CreatedDate"]));
                            usersModel.CreatedBy = Convert.ToString(dt.Rows[i]["CreatedBy"]);
                            usersModel.CreatedFrom = Convert.ToString(dt.Rows[i]["CreatedFrom"]);
                            usersModel.UpdatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["UpdatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[i]["UpdatedDate"]));
                            usersModel.UpdatedBy = Convert.ToString(dt.Rows[i]["UpdatedBy"]);
                            usersModel.UpdatedFrom = Convert.ToString(dt.Rows[i]["UpdatedFrom"]);
                            usersModel.UserType = Convert.ToString(dt.Rows[i]["UserType"]);
                            usrList.Add(usersModel);
                        }
                        this.UserList = usrList.ToList();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }



        // Action
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    Alert(AlertType.Warning, "Enter username.");
                    txtUsername.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtPassword.Focus();
                }
                else
                {
                    Users user = new Users();
                    user.UserName = Convert.ToString(txtUsername.Text);
                    user.Password = Convert.ToString(txtPassword.Text);

                    if (!string.IsNullOrEmpty(this.ModelReference))
                    {
                        if (this.ModelReference == "admin")
                        {
                            //User
                            if (IsUsernameExist(user))
                            {
                                if (IsPasswordExist(user))
                                {
                                    UsersModel usrModel = AccountLogin(user);
                                    QuaintSessionManager session = new QuaintSessionManager();
                                    session.ActiveUserId = usrModel.UserId;
                                    session.ActiveUserName = usrModel.UserName;
                                    session.Add("UserType", "admin");
                                    session.Add("ActiveUser", usrModel);
                                    Response.Redirect("~/Account/Dashboard.aspx");
                                }
                                else
                                {
                                    Alert(AlertType.Error, "Username and password does not match.");
                                }
                            }
                            else
                            {
                                Alert(AlertType.Error, "User is not exist.");
                            }
                        }
                        else if (this.ModelReference == "member")
                        {
                            // Member
                            if (IsUsernameExist(user))
                            {
                                if (IsPasswordExist(user))
                                {
                                    UsersModel usrModel = AccountLogin(user);
                                    QuaintSessionManager session = new QuaintSessionManager();
                                    session.ActiveUserId = usrModel.UserId;
                                    session.ActiveUserName = usrModel.FullName;
                                    session.Add("UserType", "member");
                                    session.Add("ActiveUser", usrModel);
                                    Response.Redirect("~/MemberPanel/Dashboard.aspx");
                                }
                                else
                                {
                                    Alert(AlertType.Error, "Username and password does not match.");
                                }
                            }
                            else
                            {
                                Alert(AlertType.Error, "Member is not exist.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to login.");
            }
        }

        private bool IsUsernameExist(Users user)
        {
            try
            {
                bool flag = false;
                UsersModel usrModel = new UsersModel();

                if (!string.IsNullOrEmpty(this.ModelReference))
                {
                    if (this.ModelReference == "admin")
                    {
                        foreach (UsersModel usr in this.UserList)
                        {
                            if (usr.UserName == user.UserName)
                            {
                                usrModel = usr;
                                flag = true;
                                break;
                            }
                        }
                    }
                    else if (this.ModelReference == "member")
                    {
                        foreach (UsersModel usr in this.MemberList)
                        {
                            if (usr.UserName == user.UserName)
                            {
                                usrModel = usr;
                                flag = true;
                                break;
                            }
                        }
                    }
                }

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsPasswordExist(Users user)
        {
            try
            {
                bool flag = false;
                UsersModel usrModel = new UsersModel();

                if (!string.IsNullOrEmpty(this.ModelReference))
                {
                    if (this.ModelReference == "admin")
                    {
                        foreach (UsersModel usr in this.UserList)
                        {
                            if (usr.UserName == user.UserName && QuaintSecurityManager.Decrypt(usr.Password) == user.Password)
                            {
                                usrModel = usr;
                                flag = true;
                                break;
                            }
                        }
                    }
                    else if (this.ModelReference == "member")
                    {
                        foreach (UsersModel usr in this.MemberList)
                        {
                            if (usr.UserName == user.UserName && QuaintSecurityManager.Decrypt(usr.Password) == user.Password)
                            {
                                usrModel = usr;
                                flag = true;
                                break;
                            }
                        }
                    }
                }

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private UsersModel AccountLogin(Users user)
        {
            try
            {
                UsersModel usrModel = new UsersModel();

                if (!string.IsNullOrEmpty(this.ModelReference))
                {
                    if (this.ModelReference == "admin")
                    {
                        foreach (UsersModel usr in this.UserList)
                        {
                            if (usr.UserName == user.UserName && QuaintSecurityManager.Decrypt(usr.Password) == user.Password)
                            {
                                usrModel = usr;
                                break;
                            }
                        }
                    }
                    else if (this.ModelReference == "member")
                    {
                        foreach (UsersModel usr in this.MemberList)
                        {
                            if (usr.UserName == user.UserName && QuaintSecurityManager.Decrypt(usr.Password) == user.Password)
                            {
                                usrModel = usr;
                                break;
                            }
                        }
                    }
                }

                if (usrModel != null)
                    return usrModel;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}