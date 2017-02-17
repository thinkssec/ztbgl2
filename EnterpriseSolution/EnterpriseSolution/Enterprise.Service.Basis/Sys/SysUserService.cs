using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using System.Web.UI.WebControls;

namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysUserService.cs
    /// 功能描述: 业务逻辑层-用户数据处理
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysUserService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysUserData dal = new SysUserData();

        /// <summary>
        /// 返回数据层的缓存项名称
        /// 主要是为了实现数据表变化时的缓存同步问题
        /// </summary>
        /// <returns></returns>
        public string GetCacheClassKey()
        {
            return SysUserData.cacheClassKey;
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取查询数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSetBySQL(string sql)
        {
            return dal.GetDataSetBySQL(sql);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        public SysUserModel Disp(int userId)
        {
            return dal.GetList().Where(p=>p.USERID==userId).FirstOrDefault();
        }

        /// <summary>
        /// 绑定带分组功能的用户下拉控件
        /// </summary>
        /// <param name="ddl">下拉控件</param>
        public void BindSSECDropDownListForUser(SSECDropDownList ddl)
        {
            ddl.Items.Clear();
            var userList = GetList().OrderBy(p => p.DEPTID);
            string jglx = string.Empty;
            foreach (var q in userList)
            {
                if (string.IsNullOrEmpty(jglx))
                {
                    ddl.Items.Add(new ListItem(SysDepartmentService.GetDepartMentName(q.DEPTID), "optgroup"));
                    ddl.Items.Add(new ListItem(q.UNAME, q.USERID.ToString()));
                    jglx = q.DEPTID.ToString();
                }
                else if (q.DEPTID.ToString() == jglx)
                {
                    ddl.Items.Add(new ListItem(q.UNAME, q.USERID.ToString()));
                }
                else
                {
                    ddl.Items.Add(new ListItem(SysDepartmentService.GetDepartMentName(q.DEPTID), "optgroup"));
                    ddl.Items.Add(new ListItem(q.UNAME, q.USERID.ToString()));
                    jglx = q.DEPTID.ToString();
                }
            }
        }

        #region "静态方法"

        /// <summary>
        ///  返回人员姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserName(int userId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p=>p.USERID==userId).FirstOrDefault();
            if (q != null)
            {
                return q.UNAME;
            }
            return "";
        }

        /// <summary>
        /// 返回人员姓名，同时返回其所在单位ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public static string GetUserName(int userId, out int deptId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.USERID == userId).FirstOrDefault();
            if (q != null)
            {
                deptId = q.DEPTID;
                return q.UNAME;
            }
            else
            {
                deptId = 0;
            }
            return "";
        }

        /// <summary>
        ///  返回人员姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserLoginName(int userId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.USERID == userId).FirstOrDefault();
            if (q != null)
            {
                return q.ULOGINNAME;
            }
            return "";
        }

        /// <summary>
        ///  返回人员的ID
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static int GetUserId(string loginName)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.ULOGINNAME == loginName).FirstOrDefault();
            if (q != null)
            {
                return q.USERID;
            }
            return 0;
        }

        /// <summary>
        ///  返回指定姓名的对应ID
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static int GetUserIdByUserName(string userName)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.UNAME == userName).FirstOrDefault();
            if (q != null)
            {
                return q.USERID;
            }
            return 0;
        }

        /// <summary>
        ///  按账号返回人员MODEL
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static SysUserModel GetUserModelByLoginName(string loginName)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.ULOGINNAME == loginName).FirstOrDefault();
            if (q != null)
            {
                return q;
            }
            return null;
        }


        /// <summary>
        /// 按ID返回人员MODEL
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static SysUserModel GetUserModelByUserId(int userId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.USERID == userId).FirstOrDefault();
            if (q != null)
            {
                return q;
            }
            return null;
        }

        /// <summary>
        /// 按数组返回人员信息
        /// </summary>
        /// <param name="uArray"></param>
        /// <returns></returns>
        public static string GetUserNameArray(string uArray)
        {
            string str = "";
            if (!string.IsNullOrEmpty(uArray))
            {
                string[] paths = uArray.Split(',');
                if (paths.Length >= 1)
                {
                    for (int i = 0; i < paths.Length; i++)
                    {
                        string uName = GetUserName(paths[i].ToInt());
                        if (!string.IsNullOrEmpty(uName))
                        {
                            str += uName + "; ";
                        }
                    }
                }
            }
            return str.TrimEnd(';');
        }

        /// <summary>
        ///  返回人员默认语言
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Utility.LanguageType GetUserLanguage(int userId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.GetList().Where(p => p.USERID == userId).FirstOrDefault();
            if (q != null)
            {
                if (q.UDEFAULTLANGUAGE == "zhcn")
                {
                    return Utility.LanguageType.zhcn;
                }
                else if (q.UDEFAULTLANGUAGE == "ru")
                {
                    return Utility.LanguageType.ru;
                }
            }
            return Utility.LanguageType.zhcn;
        }
        #endregion


        /// <summary>
        /// 返回人员集合@将部门和人员机构生成到一张数据表,便于生成基于部门的用户树结构
        /// </summary>
        /// <returns></returns>
        public DataSet GetRelationForCombox()
        {
            return dal.GetRelationForCombox();
        }

        /// <summary>
        /// 返回所有有职务的人员
        /// </summary>
        /// <returns></returns>
        public DataSet GetRelationForCombox_Zhiwu()
        {
            return dal.GetRelationForCombox_Zhiwu();
        }

        /// <summary>
        ///  返回人员所在部门
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetUserDeptId(int userId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.Disp(userId);
            if (q != null)
            {
                return q.DEPTID;
            }
            return 0;
        }


        /// <summary>
        ///  返回人员关系的隶属部门
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetUserAffiliationDeptId(int userId)
        {
            SysUserService uService = new SysUserService();
            var q = uService.Disp(userId);
            if (q != null)
            {
                return q.UAFFILIATION;
            }
            return 0;
        }

        /// <summary>
        /// 根据职务ID或是职务名称提取相应的人员ID
        /// </summary>
        /// <param name="dutyId">职务ID</param>
        /// <param name="dutyName">职务名称</param>
        /// <returns></returns>
        public static int GetDutyUserId(int dutyId, string dutyName)
        {

            if (dutyId > 0)
            {
                //按ID查询
                SysUserDutyService userDutySrv = new SysUserDutyService();
                var u = userDutySrv.GetList().FirstOrDefault(p => p.DUTYID == dutyId);
                if (u != null)
                {
                    return u.USERID.Value;
                }
            }
            else
            {
                //先按名称查询，再按ID查询
                SysDutyService dutySrv = new SysDutyService();
                var duty = dutySrv.GetList().FirstOrDefault(p=>p.DNAME == dutyName);
                if (duty != null)
                {
                    SysUserDutyService userDutySrv = new SysUserDutyService();
                    var u = userDutySrv.GetList().FirstOrDefault(p => p.DUTYID == duty.DUTYID);
                    if (u != null)
                    {
                        return u.USERID.Value;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 生成交流论坛用户验证参数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetBBSVerifyUrl(SysUserModel user)
        {
            StringBuilder paramSB = new StringBuilder();
            Crypto3DES des = new Crypto3DES();
            paramSB.Append("&orc_user=" + Base64.Base64Encode(des.Encrypt3DES(user.ULOGINNAME + "|" + user.UNAME)));//用户登录名 Crypto3DES 加密
            DateTime timeStamp = new DateTime(1970, 1, 1);  //得到1970年的时间戳
            long a = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000;  //注意这里有时区问题，用now就要减掉8个小时
            paramSB.Append("&timestamp=" + a);//long型时间
            paramSB.Append("&stamp_key=" + MD5Tool.GetMD5Hash(a + des.Key));//long型时间+密钥==MD5加密
            return paramSB.ToString();
        }


       
    }

}
