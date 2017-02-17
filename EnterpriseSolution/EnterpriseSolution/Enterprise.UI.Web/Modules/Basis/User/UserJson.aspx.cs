using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.Basis.User
{
    public partial class UserJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selected = (string)Utility.sink("selected", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
            string json = string.Empty;
            SysUserService uSer = new SysUserService();
            Response.Clear();

            //add by qw 2013.9.4 start 按孙丹的要求增加条件查询,根据条件先查询出缺省可选择人员ID
            int kind = (int)Utility.sink("kind", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
            if (kind > 0)
            {
                selected = getKindPersonIds(kind);
            }
            //end

            //从缓存中取
            if (WebKeys.EnableCaching)
            {
                json = (string)CacheHelper.GetCache(uSer.GetCacheClassKey() + "_GetUserJSON_" + selected);
            }

            if (string.IsNullOrEmpty(json))
            {
                DataTable dt = new DataTable();
                dt = uSer.GetRelationForCombox().Tables[0];
                json = dt.ToJsonForEasyuiComboTree("CID", "TEXT", "PARENTID", "d-0", selected);
                if (WebKeys.EnableCaching)
                {
                    //存入缓存
                    CacheHelper.Add(uSer.GetCacheClassKey() + "_GetUserJSON_" + selected, json);
                }
            }

            Response.Write(json);
            Response.End();

            #region TestData
            ////从数据库获取用户数据生成Json            
            //dt.Columns.Add("userId",typeof(int));
            //dt.Columns.Add("userName", typeof(string));
            //dt.Columns.Add("userNameRu",typeof(string));
            //dt.Columns.Add("deptId", typeof(int));
            //dt.Columns.Add("deptName", typeof(string));
            //dt.Columns.Add("deptParentId",typeof(int));
            //dt.Columns.Add("sex", typeof(string));
            //dt.Columns.Add("isdept", typeof(int));

            //DataRow dr = dt.NewRow();
            //dr[0] = 1;
            //dr[1] = "公司领导";
            //dr[2] = "Leaders";
            //dr[3] = 1;
            //dr[4] = "公司领导";
            //dr[5] = 0;
            //dr[6] = "";
            //dr[7] = 1;
            //dt.Rows.Add(dr);


            //dr = dt.NewRow();
            //dr[0] = 2;
            //dr[1] = "张玉梅";
            //dr[2] = "Robin.Smith";
            //dr[3] = 1;
            //dr[4]="公司领导";
            //dr[5] = 1;
            //dr[6] = "女";
            //dr[7] = 0;
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = 3;
            //dr[1] = "李中国";
            //dr[2] = "Loaria.Smith";
            //dr[3] = 1;
            //dr[4] = "公司领导";
            //dr[5] = 1;
            //dr[6] = "男";
            //dr[7] = 0;
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = 4;
            //dr[1] = "网络中心";
            //dr[2] = "Loaria.Smith";
            //dr[3] = 1;
            //dr[4] = "公司领导";
            //dr[5] = 0;
            //dr[6] = "男";
            //dr[7] = 1;
            //dt.Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// 获取符合查询条件的所有人员ID字符串
        /// 以逗号分割
        /// </summary>
        /// <param name="kind">类型值</param>
        /// <returns></returns>
        private string getKindPersonIds(int kind)
        {
            SysUserService userSrv = new SysUserService();
            //2==部门经理以上
            string sql2 = 
                "(select userid from basis_sys_userduty where userid>0 dutyid in (select dutyid from basis_sys_duty where dremark <= '5')) sql2";   
            //4==部门副经理以上
            string sql4 = 
                "(select userid from basis_sys_userduty where dutyid in (select dutyid from basis_sys_duty where dremark <= '6')) sql4";
            //8==中方员工
            string sql8 = "(select userid from basis_sys_user where udefaultlanguage='zhcn' and deptid > 0) sql8";
            //16==哈方员工
            string sql16 = "(select userid from basis_sys_user where udefaultlanguage='ru' and deptid > 0) sql16";
            //32==不含子公司
            string sql32 = "(select userid from basis_sys_user where deptid <= 15 and deptid > 0) sql32";
            //====生成SQL语名
            string SQL = string.Empty;
            string sqlHead = "select ";
            string sqlTable = "";
            string sqlEnd = " 1=1 ";
            if ((kind & 2) == 2)
            {
                sqlHead += " sql2.userid as userid2,";
                sqlTable += sql2 + ",";
                if (checkKind(kind, 4)) sqlEnd += " and sql2.userid=sql4.userid ";
                if (checkKind(kind, 8)) sqlEnd += " and sql2.userid=sql8.userid ";
                if (checkKind(kind, 16)) sqlEnd += " and sql2.userid=sql16.userid ";
                if (checkKind(kind, 32)) sqlEnd += " and sql2.userid=sql32.userid ";
            }
            else if ((kind & 4) == 4)
            {
                sqlHead += " sql4.userid as userid4,";
                sqlTable += sql4 + ",";
                if (checkKind(kind, 8)) sqlEnd += " and sql4.userid=sql8.userid ";
                if (checkKind(kind, 16)) sqlEnd += " and sql4.userid=sql16.userid ";
                if (checkKind(kind, 32)) sqlEnd += " and sql4.userid=sql32.userid ";
            }
            if ((kind & 8) == 8)
            {
                sqlHead += " sql8.userid as userid8,";
                sqlTable += sql8 + ",";
                if (!checkKind(kind, 2) && !checkKind(kind, 4))
                {
                    if (checkKind(kind, 16)) sqlEnd += " and sql8.userid=sql16.userid ";
                    if (checkKind(kind, 32)) sqlEnd += " and sql8.userid=sql32.userid ";
                }
            }
            else if ((kind & 16) == 16)
            {
                sqlHead += " sql16.userid as userid16,";
                sqlTable += sql16 + ",";
                if (!checkKind(kind, 2) && !checkKind(kind, 4) && !checkKind(kind, 8))
                {
                    if (checkKind(kind, 32)) sqlEnd += " and sql16.userid=sql32.userid ";
                }
            }
            if ((kind & 32) == 32)
            {
                sqlHead += " sql32.userid as userid32,";
                sqlTable += sql32 + ",";
            }

            if (!string.IsNullOrEmpty(sqlHead)) 
                sqlHead = sqlHead.TrimEnd(',');
            if (!string.IsNullOrEmpty(sqlTable)) 
                sqlTable = sqlTable.TrimEnd(',');

            SQL = sqlHead + " from " + sqlTable + " where " + sqlEnd;
            string userIds = string.Empty;
            DataSet ds = userSrv.GetDataSetBySQL(SQL);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    userIds += dr[0] + ",";
                }
            }
            return userIds.TrimEnd(',');
        }


        /// <summary>
        /// 检测是否选中
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private bool checkKind(int kind, int v)
        {
            return ((kind & v) == v);
        }

    }
}