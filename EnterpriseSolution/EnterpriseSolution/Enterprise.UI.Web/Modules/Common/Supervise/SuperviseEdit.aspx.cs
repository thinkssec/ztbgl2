using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Control;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis;

namespace Enterprise.UI.Web.Modules.Common.Supervise
{
    public partial class SuperviseEdit : BasePage
    {
        /// <summary>
        /// by pengwei
        /// @@@2013-3-15 与QW讨论 本页程序 不允许编辑一个督办事务 ，督办事务一经发起只能删除
        /// </summary>
        
        public string Id = (string)Enterprise.Component.Infrastructure.Utility.sink("id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                h_id.Value = Id;
                OnStart();
            }
        }

        private void OnStart()
        {
            OnCommand();
            //OnBindData();
        }

        private void OnBindData()
        {
            Enterprise.Service.Common.Supervise.SuperviseInfoService service = new Service.Common.Supervise.SuperviseInfoService();
            var model = service.GetList("from SuperviseInfoModel p where p.DBID='" + h_id.Value + "'").FirstOrDefault();
             if (model != null)
            {
                t_bt.Text = model.DBBT;
                t_dbbh.Text = model.DBBH;
                t_Content.Text = model.DBNR;
                Enterprise.Service.Common.Supervise.SuperviseProcessService spService = new Service.Common.Supervise.SuperviseProcessService();
                IList<Enterprise.Model.Common.Supervise.SuperviseProcessModel> list = spService.GetList("from SuperviseProcessModel where DBID='"+Id+"'");
                List<string> db_userIds = list.Select(s => s.BLRID).Distinct().ToList();
                db_users_value.Value = db_userIds.ToEnableSplitString();
                t_yqwcsj.Text = model.YQWCSJ.ToString();
                db_lingdao_value.Value = model.FZLD.ToString();      
                 //填充任务回复时间点
                ddl_dbsj.DataSource = list;
                ddl_dbsj.DataTextField = "YQSBSJ";
                ddl_dbsj.DataValueField = "YQSBSJ";
                ddl_dbsj.DataBind();
            }
        }

        private void OnCommand()
        {
            CreateBT.AddButton("back.gif", Trans("返回"), "SuperviseIndex.aspx", Utility.PopedomType.List, HeadMenu1);
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {          
                
            //Boss下达任务
            Enterprise.Service.Common.Supervise.SuperviseInfoService service = new Service.Common.Supervise.SuperviseInfoService();

            //任务内容
            Enterprise.Model.Common.Supervise.SuperviseInfoModel model = new Model.Common.Supervise.SuperviseInfoModel();
            model.DBID = "DB-"+Guid.NewGuid().ToString();//ID
            model.DBBT = t_bt.Text; //标题
            model.DBBH = t_dbbh.Text;//编号
            model.DBNR = t_Content.Text;//内容
            model.DBSJ = t_dbsj.Text; //督办时间 (实际运行中可能要改为当前时间 数据补录时可能需要)
            if (!string.IsNullOrEmpty(db_lingdao_value.Value))
            {
                model.FZLD = db_lingdao_value.Value.ToInt(); //负责领导 允许为空
            }
            model.YQWCSJ = t_yqwcsj.Text; //要求完成时间
            model.XDSJ = DateTime.Now.ToString();//实际下达时间

            model.DBR = Enterprise.Component.Infrastructure.Utility.Get_UserId;

            //任务接受者
            string userIds = db_users_value.Value.ToString();

            //任务执行列表
            Enterprise.Service.Common.Supervise.SuperviseProcessService processService = new Service.Common.Supervise.SuperviseProcessService();

            //生成任务执行列表

            //如果有督办时间 则获取下拉中的所有时间点
            List<string> dbsjs = new List<string>();
            string dbsjvalue = Request.Form["ctl00$MainPH$db_dbsj_value"];

            if (!string.IsNullOrEmpty(dbsjvalue))
            {
                foreach (var dbsj in dbsjvalue.Split(','))
                {
                    if(!string.IsNullOrEmpty(dbsj))
                    dbsjs.Add(dbsj);
                }
            }
            //将要求完成时间添加到集合
            if (!dbsjs.Contains(model.YQWCSJ))
            {
                dbsjs.Add(model.YQWCSJ);
            }
            model.DB_Option_Action = WebKeys.InsertAction;
            bool rb = service.Execute(model);
            //创办任务
            processService.ProcessJobs(userIds, model, dbsjs,userModel);
            Enterprise.Component.Infrastructure.Utility.ShowMsg(this.Page, Trans("提示"), Trans("操作成功"), "SuperviseManage.aspx");

               

        }
    }
}