using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Common.Supervise;
using Enterprise.Model.Common.Supervise;
using Enterprise.Service.Basis.Bf;

namespace Enterprise.UI.Web.Modules.Common.Supervise
{
    public partial class SuperviseProcessDetailsManage : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Enterprise.Component.Infrastructure.Utility.sink("dbid", Enterprise.Component.Infrastructure.Utility.MethodType.Get, 0, 0, Enterprise.Component.Infrastructure.Utility.DataType.Str);
        public Model.Common.Supervise.SuperviseInfoModel InfoModel { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                Service.Common.Supervise.SuperviseInfoService infoService = new SuperviseInfoService();
                InfoModel = infoService.GetList("from SuperviseInfoModel where DBID='" + Id + "'").FirstOrDefault();
                edittable.Visible = false;
                Model.Common.Supervise.SuperviseProcessModel processModel = new SuperviseProcessModel();
                Service.Common.Supervise.SuperviseProcessService processService = new SuperviseProcessService();
                IList<SuperviseProcessModel> list = processService.GetList("from SuperviseProcessModel where DBID='" + Id + "' and BLRID='" + Utility.Get_UserId + "'");
                gv.DataSource = list;
                gv.DataBind();
            }
            catch
            {
 
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = Enterprise.Service.Basis.Sys.SysUserService.GetUserName(e.Row.Cells[0].Text.ToInt());
            }
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            edittable.Visible = true;
            ff.Value = gv.SelectedRow.Cells[2].Text;
            tb_bz.Text = gv.SelectedRow.Cells[3].Text;
        }

        protected void LBtn_Save_Click(object sender, EventArgs e)
        {
            string dbid = gv.SelectedDataKey[0].ToString();
            string blrid = gv.SelectedDataKey[1].ToString();
            string sbsj = gv.SelectedDataKey[2].ToString();
            Enterprise.Model.Common.Supervise.SuperviseProcessModel model = new SuperviseProcessModel();
            Enterprise.Service.Common.Supervise.SuperviseProcessService pService = new SuperviseProcessService();

            model.DBID = dbid;
            model.BLRID = blrid;
            model.YQSBSJ = sbsj;
            model.DQJD = ff.Value.ToDecimal();
            model.BZ = tb_bz.Text;
            model.DB_Option_Action = WebKeys.UpdateAction;
            model.SJSBSJ = DateTime.Now.ToString("yyyy-MM-dd");
            //规则检查 不能在要求完成时间前录入100%
            if (model.YQSBSJ != InfoModel.YQWCSJ && model.DQJD == 100)
            {
                Utility.ShowMsg(this.Page, Trans("错误提示"), Trans("您只能在要求上报时间填100%"));
            }
            else
            {
                pService.Execute(model);
                if (model.DQJD == 100)
                {
                    //如果进度为100 消除这个代办
                    BfMsgService.UpdateMsgOver(MsgID);
                }
                BindGrid();
            }
        }
    }
}