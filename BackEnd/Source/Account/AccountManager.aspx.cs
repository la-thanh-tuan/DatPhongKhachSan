using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infrastructure;

namespace BackEnd.Source.Account
{
    public partial class AccountManager : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (BackEndAuthentication.GetCurrentUserLogin(_db).ManagerPermission.Permission != Permission.Admin)
                Response.Redirect("~/Source/Home.aspx");
            dtgAccount.DataSource = _db.Managers.ToList();
            dtgAccount.DataBind();
            DataGridHelper.SetStyle(dtgAccount);
        }

        protected void dtgAccount_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DropDownList ddlSex = e.Item.FindControl("ddlSex") as DropDownList;
            if (ddlSex != null)
            {
                try
                {

                    if (
                        e.Item.DataItem != null&&
                        (bool)DataBinder.Eval(e.Item.DataItem, "Sex") == true)
                    {
                        ddlSex.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlSex.SelectedIndex = 1;
                    }
                }
                catch { }
                DropDownList ddlPermission = e.Item.FindControl("ddlPermission") as DropDownList;
                foreach (ManagerPermission mnp in _db.ManagerPermissions.Distinct().ToList())
                {
                    ddlPermission.Items.Add(new ListItem(mnp.Permission.ToString(), mnp.Id.ToString()));
                }
                try
                {
                    if(e.Item.DataItem!=null)
                    {
                        int id = (int)DataBinder.Eval(e.Item.DataItem, "Id");
                        ddlPermission.SelectedValue = _db.Managers.Where(x => x.Id == id).First().ManagerPermission.Id.ToString();

                    }
                }
                catch { }
            }
        }

        protected void dtgAccount_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgAccount.CurrentPageIndex = e.NewPageIndex;
            dtgAccount.DataSource = _db.Managers.ToList();
            dtgAccount.DataBind();
        }

        protected void dtgAccount_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "save")
            {
                try
                {
                    int Id = int.Parse(e.CommandArgument.ToString());
                    Manager mn = _db.Managers.Where(x => x.Id == Id).First();
                    mn.Name = (e.Item.FindControl("tbName") as TextBox).Text;
                    mn.Phone = (e.Item.FindControl("tbPhone") as TextBox).Text;
                    mn.Skype = (e.Item.FindControl("tbSkype") as TextBox).Text;
                    mn.Active = (e.Item.FindControl("chkActive") as CheckBox).Checked;
                    DropDownList ddlSex = (e.Item.FindControl("ddlSex") as DropDownList);
                    if (ddlSex.SelectedValue == "0")
                    {
                        mn.Sex = false;
                    }
                    else
                        mn.Sex = true;
                    if (mn.UserName != "admin")
                    {
                        int id = int.Parse((e.Item.FindControl("ddlPermission") as DropDownList).SelectedValue);
                        mn.ManagerPermission = _db.ManagerPermissions.Where(x => x.Id == id).First();
                    }
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Lưu thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("Lưu bị lỗi !", Page);
                }
            }
            else if (e.CommandName == "delete")
            {
                try
                {
                    int Id = int.Parse(e.CommandArgument.ToString());
                    Manager mn = _db.Managers.Where(x => x.Id == Id).First();
                    if(BackEndAuthentication.GetCurrentUserLogin(new DatPhongKhachSanDbContext()).ManagerPermission.Id!=1)
                    {
                        Notify.ShowMessageError("Không có quyền !", Page);
                        return;

                    }
                    if (mn.Id==BackEndAuthentication.GetCurrentUserLogin(new DatPhongKhachSanDbContext()).Id)
                    {
                        Notify.ShowMessageError("Không thể xóa tài khoản mặc định !", Page);
                        return;
                    }
                    _db.Managers.Remove(mn);
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Xóa thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("Xóa bị lỗi !", Page);
                }
            }
            else if (e.CommandName == "add")
            {
                try
                {
                    Manager mn = new Manager();
                    mn.UserName = (e.Item.FindControl("tbUserName") as TextBox).Text;
                    mn.Password = MyEncryption.Encrypt("123456");
                    if (mn.UserName.Trim().Length == 0)
                    {
                        Notify.ShowMessageError("Bắt buộc phải có UserName !", Page);
                        return;
                    }
                    if (_db.Managers.Where(x => x.UserName == mn.UserName).Count() > 0)
                    {
                        Notify.ShowMessageError("Tài khoản đã tồn tại !", Page);
                        return;
                    }
                    mn.Name = (e.Item.FindControl("tbName") as TextBox).Text;
                    mn.Phone = (e.Item.FindControl("tbPhone") as TextBox).Text;
                    mn.Email = (e.Item.FindControl("tbEmail") as TextBox).Text;
                    mn.Skype = (e.Item.FindControl("tbSkype") as TextBox).Text;
                    mn.Active = (e.Item.FindControl("chkActive") as CheckBox).Checked;
                    mn.BirthDay = DateTime.Parse((e.Item.FindControl("tbBirthDay") as TextBox).Text, CultureInfo.GetCultureInfo("en-Gb"));
                    DropDownList ddlSex = (e.Item.FindControl("ddlSex") as DropDownList);
                    if (ddlSex.SelectedValue == "0")
                    {
                        mn.Sex = false;
                    }
                    else
                        mn.Sex = true;

                    int id = int.Parse((e.Item.FindControl("ddlPermission") as DropDownList).SelectedValue);
                    mn.ManagerPermission = _db.ManagerPermissions.Where(x => x.Id == id).First();
                    _db.Managers.Add(mn);
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Thêm thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("Thêm bị lỗi !", Page);
                }
            }
            LoadData();
        }
    }
}