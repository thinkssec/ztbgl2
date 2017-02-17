using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Zygl;
using Enterprise.Service.App.Zygl;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
using Enterprise.Component.BF;
using Enterprise.Service.Basis.Bf;
namespace Enterprise.UI.Web.Modules.App.Zygl
{
    public partial class ZyglJsEdit : Enterprise.Service.Basis.BasePage
    {
        public string ckId = (string)Utility.sink("WID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        //public string ckdId = (string)Utility.sink("QID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        public string zId = (string)Utility.sink("ZID", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        private ZyglPlanService pservice = new ZyglPlanService();
        //private ZyglWgysService service = new ZyglWgysService();
        private ZyglJsService service = new ZyglJsService();
        //private ZyglWgqtfyService dservice = new ZyglWgqtfyService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                OnStart();
                OnCommand();
            }
        }

        /// <summary>
        /// 控制按钮
        /// </summary>
        private void OnCommand()
        {
            //添加操作按钮
            CreateBT.AddButton("back.gif", Trans("返回"), "ZyglJsList.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 初始化加载项
        /// </summary>
        private void OnStart()
        {
            int deptId = 0;

             
            if (Cmd == "Edit")
            {
                OnBindData();
            }
            else if (Cmd == "Recv")
            {
                OnBindData();
            }
            
            else if (Cmd == "Delete2")
            {
                //var q = dservice.GetList().FirstOrDefault(p => p.QID == ckdId);
                //Hid_CKID.Value = ckId;
                //Hid_ZID.Value = zId;
                //if (q != null)
                //{
                //    string _note = "操作成功";
                //    q.DB_Option_Action = "Delete";
                //    try
                //    {
                //        dservice.Execute(q);
                //    }
                //    catch (Exception ex)
                //    {
                //        _note = ex.Message;
                //    }
                //    //Utility.ShowMsg(this.Page, "OK", this.Trans(_note), "HseSectEdit.aspx?Cmd=Edit&CKID=" + Hid_CKID.Value);
                //    Response.Redirect("ZyglJsEdit.aspx?Cmd=Edit&WID=" + Hid_CKID.Value + "&ZID=" + Hid_ZID.Value, false);
                //}
            }
        }
        protected string GetCommandBtn(string id)
        {
            string btnStrs = string.Empty;
            var zy = pservice.GetList().FirstOrDefault(p => p.ZID == Hid_ZID.Value);
            if(zy.STATUS==4)
            btnStrs += string.Format("<a onclick='return confirm(\"您确定要删除该记录吗?\");' href='ZyglJsEdit.aspx?Cmd=Delete2&QID={0}&WID={1}&ZID={2}'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>", id,Hid_CKID.Value,Hid_ZID.Value);
            return btnStrs;
        }
        /// <summary>
        /// 当编辑时绑定数据项
        /// </summary>
        private void OnBindData()
        {
            var q = service.GetList().FirstOrDefault(p => p.ZID == zId);
            var  zy= pservice.GetList().FirstOrDefault(p=>p.ZID == zId);
            Hid_ZID.Value = zId;
            if (q != null)
            {
                Hid_CKID.Value = q.WID;
                Txt_JH.Text = zy.JH;
                Txt_SGNR.Text = zy.SGNR;
                Txt_STARTDATE.Text = zy.STARTDATE.ToDateYMDFormat();
                Txt_PENDDATE.Text = zy.PENDDATE.ToDateYMDFormat();
                Txt_ENDDATE.Text = zy.ENDDATE.ToDateYMDFormat();
                Txt_SGDW.Text = q.SGDW;
                Txt_SGXCMS.Text = q.SGXCMS;
                Txt_YJFYZJ.Text = q.YJFYZJ.ToRequestString();
                Txt_LWF.Text = q.LWF.ToRequestString();
                Txt_YG.Text = q.YG.ToRequestString();
                Txt_CYG.Text = q.CYG.ToRequestString();
                Txt_BENG.Text = q.BENG.ToRequestString();
                Txt_FGQ.Text = q.FGQ.ToRequestString();
                Txt_QT.Text = q.QT.ToRequestString();
                Txt_SKF.Text = q.SKF.ToRequestString();
                Txt_CYF.Text = q.CYF.ToRequestString();
                Txt_HGL.Text = q.HGL.ToRequestString();
                Txt_ZSF.Text = q.ZSF.ToRequestString();
                Txt_JSFW.Text = q.JSFW.ToRequestString();

                tb_AFVIewNames.DBValue = q.FVIEWNAMES;
                //int c = dservice.GetList().Where(p => p.WID == Hid_CKID.Value && p.STATUS == -2).Count();
                //if (c == 0)
                //{
                //    ZyglWgqtfyModel dm = new ZyglWgqtfyModel();
                //    dm.STATUS = -2;
                //    ///dm.SUBMITTER = this.userModel.USERID;
                //    dm.WID = Hid_CKID.Value;
                //    dm.QID = Guid.NewGuid().ToRequestString();
                //    dm.DB_Option_Action = WebKeys.InsertAction;
                //    dservice.Execute(dm);
                //}
                //var lll = dservice.GetList().Where(p => p.WID == Hid_CKID.Value).OrderByDescending(o => o.STATUS).ToList();
                //GridView1.DataSource = lll;
                //GridView1.DataBind();
                ////lb_Dept.Text = SysDepartmentService.GetDepartMentName((int)q.CREATEDEPT);

                //end
            }
            else {
                q = new ZyglJsModel();
                q.WID = Guid.NewGuid().ToRequestString();
                Hid_CKID.Value = q.WID;
                q.ZID = Hid_ZID.Value;
                q.DB_Option_Action = WebKeys.InsertAction;
                service.Execute(q);
                Txt_JH.Text = zy.JH;
                Txt_SGNR.Text = zy.SGNR;
                Txt_STARTDATE.Text = zy.STARTDATE.ToDateYMDFormat();
                Txt_PENDDATE.Text = zy.PENDDATE.ToDateYMDFormat();
                Hid_CKID.Value = q.WID;
                Txt_ENDDATE.Text = zy.ENDDATE.ToDateYMDFormat();
                //int c = dservice.GetList().Where(p => p.WID == Hid_CKID.Value && p.STATUS == -2).Count();
                //if (c == 0)
                //{
                //    ZyglWgqtfyModel dm = new ZyglWgqtfyModel();
                //    dm.STATUS = -2;
                //    ///dm.SUBMITTER = this.userModel.USERID;
                //    dm.WID = Hid_CKID.Value;
                //    dm.QID = Guid.NewGuid().ToRequestString();
                //    dm.DB_Option_Action = WebKeys.InsertAction;
                //    dservice.Execute(dm);
                //}
                //var lll = dservice.GetList().Where(p => p.WID == Hid_CKID.Value).OrderByDescending(o => o.STATUS).ToList();
                //GridView1.DataSource = lll;
                //GridView1.DataBind();
            
            }
        }
        public  string ToAttachHtml2(object article)
        {
            string dbFilesString = article.ToRequestString();
            string html = "<table>";
            if (!string.IsNullOrEmpty(dbFilesString))
            {
                string[] str = dbFilesString.Split('|');
                for (int i = 0; i < str.Length; i++)
                {
                    string[] tmp = str[i].Split('*');
                    string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                    html += string.Format("<tr><td><a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + ext.Replace(".", "") + "',plain:true\" href=\"/Modules/Common/EntDisk/Content/Ashx/FileDownload.ashx?url={0}\" target='_blank'>{2}</a></td></tr>",
                        tmp.Last(),
                        FileHelper.Encrypt(tmp.Last()),
                        tmp.First());
                }
            }
            html += "</table>";
            return html;
        }
        private string sendMessageToAudit(ZyglJsModel model)
        {
            string msg = "消息已发送";
            BFController bfCtrl = new BFController();
            //发待办和提示消息
            //bfCtrl.SendNotificationMessage(
            //    model.CKID,//和项目关联的消息
            //    model.SHR1.Value,//接收人
            //    this.userModel,//当前用户
            //    string.Format("{0}-安全隐患整改审核，需要您进行查收!", model.CLEVEL),//消息标题
            //    string.Format("/Modules/App/Hse/HseSectAudit.aspx?Cmd=Audit1&CKID={0}", model.CKID),//消息内容
            //    BFRemindWay.MSG.ToString(), false);
            return msg;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ZyglWgqtfyModel model = e.Row.DataItem as ZyglWgqtfyModel;
                DropDownList mc = (DropDownList)e.Row.Cells[1].FindControl("MC");
                TextBox je = (TextBox)e.Row.Cells[2].FindControl("Txt_JE");
                TextBox bz = (TextBox)e.Row.Cells[4].FindControl("Txt_BZ");
                Label m = (Label)e.Row.Cells[3].FindControl("Lb_Key1");
                System.Web.UI.HtmlControls.HtmlAnchor m2 = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.Cells[3].FindControl("Lb_Key2");
                Label btn = (Label)e.Row.Cells[3].FindControl("Lb_Btn");
                System.Web.UI.HtmlControls.HtmlInputHidden hid = (System.Web.UI.HtmlControls.HtmlInputHidden)e.Row.Cells[3].FindControl("Hid_Key1");
                System.Web.UI.HtmlControls.HtmlInputHidden hid2 = (System.Web.UI.HtmlControls.HtmlInputHidden)e.Row.Cells[3].FindControl("Hid_Key2");
                mc.SelectedValue = model.MC;
                je.Text = model.JE.ToRequestString();
                bz.Text = model.BZ;
                

                m.Text = model.FJMC;
                m2.HRef = model.FJ;
                //m2.Attributes.Add("href", model.FJ);
                hid.Attributes.Add("ckdid", model.QID);
                hid2.Attributes.Add("ckdid", model.QID+"FJMC");
                //hid.Value = model.FNAMES;

                m.Attributes.Add("ckdid",model.QID);
                m2.Attributes.Add("ckdid", model.QID+"FJ");
                btn.Text = "<a id='" + model.QID + "'></a><script>$(function () {doRender('"+model.QID+"')});</script>";
            }
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            try
            {
                ZyglJsModel entity = service.GetList().FirstOrDefault(p => p.WID == Hid_CKID.Value);
                var zy = pservice.GetList().FirstOrDefault(p => p.ZID == Hid_ZID.Value);
                if (entity == null)
                {
                    //entity.DB_Option_Action = WebKeys.InsertAction;
                    //Hid_CKID.Value = entity.CKID = Guid.NewGuid().ToRequestString();
                    return;

                }
                else
                {
                    if (entity.STATUS > -1) {
                        Utility.ShowMsg(this.Page, "OK", this.Trans("已提交！无法保存！"), "ZyglJsList.aspx");
                        return;
                    }

                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }


                zy.ENDDATE = Txt_ENDDATE.Text.ToDateTime();
                entity.SGDW=Txt_SGDW.Text;
                entity.SGXCMS=Txt_SGXCMS.Text;
                entity.YJFYZJ=Txt_YJFYZJ.Text.ToDecimal();
                entity.LWF= Txt_LWF.Text.ToDecimal();
                entity.YG=Txt_YG.Text.ToDecimal();
                entity.CYG=Txt_CYG.Text.ToDecimal();
                entity.BENG=Txt_BENG.Text.ToDecimal();
                entity.FGQ=Txt_FGQ.Text.ToDecimal();
                entity.QT=Txt_QT.Text.ToDecimal();
                entity.SKF=Txt_SKF.Text.ToDecimal();
                entity.CYF=Txt_CYF.Text .ToDecimal();
                entity.HGL=Txt_HGL.Text.ToDecimal();
                entity.ZSF=Txt_ZSF.Text.ToDecimal();
                entity.JSFW = Txt_JSFW.Text.ToDecimal();
                entity.FNAMES = tb_AFVIewNames.Text;
                entity.FVIEWNAMES = tb_AFVIewNames.DBValue;
                entity.STATUS = -1;
                zy.DB_Option_Action = WebKeys.UpdateAction;
 


                if (service.Execute(entity))
                {
                    pservice.Execute(zy);
                    //BfMsgService bs = new BfMsgService();
                    //var l = bs.GetUnhandleList().Where(p=>p.BF_INSTANCEID==entity.DOCID);
                    //foreach (var q in l)
                    //{
                    //    q.DB_Option_Action = WebKeys.DeleteAction;
                    //    bs.ExecuteUnhandle(q);
                    //}
                    //sendMessageToRecv(entity);
                }


                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    DropDownList mc = (DropDownList)row.Cells[1].FindControl("MC");
                //    TextBox je = (TextBox)row.Cells[2].FindControl("Txt_JE");
                //    TextBox bz = (TextBox)row.Cells[4].FindControl("Txt_BZ");
                //    //Label m = (Label)row.Cells[3].FindControl("Lb_Key1");
                //    //System.Web.UI.HtmlControls.HtmlAnchor m2 = (System.Web.UI.HtmlControls.HtmlAnchor)row.Cells[3].FindControl("Lb_Key2");
                //    Label btn = (Label)row.Cells[3].FindControl("Lb_Btn");
                //    //Label btn = (Label)row.Cells[6].FindControl("Lb_Btn");
                //    System.Web.UI.HtmlControls.HtmlInputHidden hid = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[3].FindControl("Hid_Key1");
                //    System.Web.UI.HtmlControls.HtmlInputHidden hid2 = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[3].FindControl("Hid_Key2");

                //    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                //    var md = dservice.GetList().FirstOrDefault(p => p.QID == str_Id);
                //    md.MC = mc.SelectedValue;
                //    if (string.IsNullOrEmpty(je.Text)) continue;
                //    md.JE = je.Text.ToDecimal();
                //    md.BZ = bz.Text;
                //    String f = hid.Value;
                //    if (f != null) { 
                //        f = f.Replace("http://", "");
                //        f = f.Substring(f.IndexOf("/"));
                //    }
                //    md.FJ = f;
                //    md.FJMC = hid2.Value;
                //    md.STATUS = -1;
                //    //md.STATUS = -1;
                //    md.DB_Option_Action = WebKeys.UpdateAction;
                //    dservice.Execute(md);
                //}

                //int c = dservice.GetList().Where(p => p.WID == Hid_CKID.Value && p.STATUS == -2).Count();
                //if (c == 0)
                //{
                //    ZyglWgqtfyModel dm = new ZyglWgqtfyModel();
                //    dm.STATUS = -2;
                //    ///dm.SUBMITTER = this.userModel.USERID;
                //    dm.WID = Hid_CKID.Value;
                //    dm.QID = Guid.NewGuid().ToRequestString();
                //    dm.DB_Option_Action = WebKeys.InsertAction;
                //    dservice.Execute(dm);
                //}
               
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Response.Redirect("ZyglJsEdit.aspx?Cmd=Edit&WID=" + Hid_CKID.Value + "&ZID=" + Hid_ZID.Value, false);
        }
        

        protected void BtnAudit_OnClick(object sender, EventArgs e)
        {

            string _note = "提交成功";
            try
            {
                ZyglJsModel entity = service.GetList().FirstOrDefault(p => p.WID == Hid_CKID.Value);
                var zy = pservice.GetList().FirstOrDefault(p => p.ZID == Hid_ZID.Value);
                if (entity == null)
                {
                    //entity.DB_Option_Action = WebKeys.InsertAction;
                    //Hid_CKID.Value = entity.CKID = Guid.NewGuid().ToRequestString();
                    return;

                }
                else
                {
                    if (entity.STATUS > -1)
                    {
                        Utility.ShowMsg(this.Page, "OK", this.Trans("已提交！无法重复！"), "ZyglJsList.aspx");
                        return;
                    }

                    entity.DB_Option_Action = WebKeys.UpdateAction;
                }


                zy.ENDDATE = Txt_ENDDATE.Text.ToDateTime();
                entity.SGDW = Txt_SGDW.Text;
                entity.SGXCMS = Txt_SGXCMS.Text;
                entity.YJFYZJ = Txt_YJFYZJ.Text.ToDecimal();
                entity.LWF = Txt_LWF.Text.ToDecimal();
                entity.YG = Txt_YG.Text.ToDecimal();
                entity.CYG = Txt_CYG.Text.ToDecimal();
                entity.BENG = Txt_BENG.Text.ToDecimal();
                entity.FGQ = Txt_FGQ.Text.ToDecimal();
                entity.QT = Txt_QT.Text.ToDecimal();
                entity.SKF = Txt_SKF.Text.ToDecimal();
                entity.CYF = Txt_CYF.Text.ToDecimal();
                entity.HGL = Txt_HGL.Text.ToDecimal();
                entity.ZSF = Txt_ZSF.Text.ToDecimal();
                entity.JSFW = Txt_JSFW.Text.ToDecimal();
                entity.FNAMES = tb_AFVIewNames.Text;
                entity.FVIEWNAMES = tb_AFVIewNames.DBValue;
                entity.STATUS = 0;
                zy.STATUS = 5;
                zy.DB_Option_Action = WebKeys.UpdateAction;



                if (service.Execute(entity))
                {
                    pservice.Execute(zy);
                    //BfMsgService bs = new BfMsgService();
                    //var l = bs.GetUnhandleList().Where(p=>p.BF_INSTANCEID==entity.DOCID);
                    //foreach (var q in l)
                    //{
                    //    q.DB_Option_Action = WebKeys.DeleteAction;
                    //    bs.ExecuteUnhandle(q);
                    //}
                    //sendMessageToRecv(entity);
                }


                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    DropDownList mc = (DropDownList)row.Cells[1].FindControl("MC");
                //    TextBox je = (TextBox)row.Cells[2].FindControl("Txt_JE");
                //    TextBox bz = (TextBox)row.Cells[4].FindControl("Txt_BZ");
                //    //Label m = (Label)row.Cells[3].FindControl("Lb_Key1");
                //    //System.Web.UI.HtmlControls.HtmlAnchor m2 = (System.Web.UI.HtmlControls.HtmlAnchor)row.Cells[3].FindControl("Lb_Key2");
                //    Label btn = (Label)row.Cells[3].FindControl("Lb_Btn");
                //    //Label btn = (Label)row.Cells[6].FindControl("Lb_Btn");
                //    System.Web.UI.HtmlControls.HtmlInputHidden hid = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[3].FindControl("Hid_Key1");
                //    System.Web.UI.HtmlControls.HtmlInputHidden hid2 = (System.Web.UI.HtmlControls.HtmlInputHidden)row.Cells[3].FindControl("Hid_Key2");

                //    string str_Id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                //    var md = dservice.GetList().FirstOrDefault(p => p.QID == str_Id);
                //    md.MC = mc.SelectedValue;
                //    if (string.IsNullOrEmpty(je.Text)) continue;
                //    md.JE = je.Text.ToDecimal();
                //    md.BZ = bz.Text;
                //    String f = hid.Value;
                //    if (f != null)
                //    {
                //        f = f.Replace("http://", "");
                //        f = f.Substring(f.IndexOf("/"));
                //    }
                //    md.FJ = f;
                //    md.FJMC = hid2.Value;
                //    md.STATUS = -1;
                //    //md.STATUS = -1;
                //    md.DB_Option_Action = WebKeys.UpdateAction;
                //    dservice.Execute(md);
                //}

                //int c = dservice.GetList().Where(p => p.WID == Hid_CKID.Value && p.STATUS == -2).Count();
                //if (c == 0)
                //{
                //    ZyglWgqtfyModel dm = new ZyglWgqtfyModel();
                //    dm.STATUS = -2;
                //    ///dm.SUBMITTER = this.userModel.USERID;
                //    dm.WID = Hid_CKID.Value;
                //    dm.QID = Guid.NewGuid().ToRequestString();
                //    dm.DB_Option_Action = WebKeys.InsertAction;
                //    dservice.Execute(dm);
                //}

            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Response.Redirect("ZyglJsEdit.aspx?Cmd=Recv&WID=" + Hid_CKID.Value + "&ZID=" + Hid_ZID.Value, false);
        
        }
    }
}