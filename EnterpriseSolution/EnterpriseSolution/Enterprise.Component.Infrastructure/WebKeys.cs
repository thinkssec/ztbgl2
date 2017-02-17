using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Enterprise.Component.Infrastructure
{
    /// <summary>
    /// 页面常量类
    /// </summary>
    public class WebKeys
    {

        #region 缓存相关项

        /// <summary>
        /// 缓存过期时间（分钟）
        /// </summary>
        public static readonly int CacheTimeout = 
            ((ConfigurationManager.AppSettings["CacheDuration"] != null) ?
            int.Parse(ConfigurationManager.AppSettings["CacheDuration"]) : 20);

        /// <summary>
        /// 是否启用缓存
        /// </summary>
        public static readonly bool EnableCaching =
            ((ConfigurationManager.AppSettings["EnableCaching"] != null) ?
            bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]) : false);

        /// <summary>
        /// 数据表监控周期（秒）
        /// </summary>
        public static readonly int MonitorInterval =
            ((ConfigurationManager.AppSettings["MonitorInterval"] != null) ?
            int.Parse(ConfigurationManager.AppSettings["MonitorInterval"]) : 10);

        /// <summary>
        /// 缓存项名称--定时检测名称
        /// </summary>
        public static readonly string CacheItemKey = "SSEC_CacheItemKey_";


        #endregion


        #region 业务流设计器相关项

        /// <summary>
        /// 暂存数据用session名称
        /// </summary>
        public static readonly string SSEC_BF_SESSION_KEY = "ssec_bf_sessionKey";
        /// <summary>
        /// 业务流前缀
        /// </summary>
        public static readonly string BF_PREFIX = "BF";
        /// <summary>
        /// 业务流消息前缀
        /// </summary>
        public static readonly string BF_MESSAGE_PREFIX = "M";
        /// <summary>
        /// 业务流角色获取方法表前缀
        /// </summary>
        public static readonly string BF_CLSMETHOD_PREFIX = "MD";
        /// <summary>
        /// 业务流节点前缀
        /// </summary>
        public static readonly string BF_NODE_PREFIX = "N";
        /// <summary>
        /// 业务流实例前缀
        /// </summary>
        public static readonly string BF_INSTANCE_PERFIX = "P";
        /// <summary>
        /// 业务流节点运行前缀
        /// </summary>
        public static readonly string BF_RUN_PERFIX = "R";

        #endregion


        #region 错误相关项

        public static readonly string ErrorMessage = "ErrorMessage";

        public static readonly string Error = "Error";

        #endregion


        #region 关键项

        /// <summary>
        /// 语言名称标识
        /// </summary>
        public static readonly string LangName = "SSEC_Language";

        /// <summary>
        /// 语言转换词典缓存项名称
        /// </summary>
        public static readonly string LangCacheName = "SSEC_MyDictionary";

        /// <summary>
        /// 原始文本名称
        /// </summary>
        public static readonly string OriginalText = "SSEC_OriginalText";

        #endregion


        #region Cookie相关

        /// <summary>
        /// 缺省语言类型Cookie名称
        /// </summary>
        public static readonly string LangCookieName = "DefaultLangType";

        #endregion


        #region 动作标识

        /// <summary>
        /// 添加操作
        /// </summary>
        public static readonly string InsertAction = "Insert";
        /// <summary>
        /// 更新操作
        /// </summary>
        public static readonly string UpdateAction = "Update";
        /// <summary>
        /// 添加或更新操作
        /// </summary>
        public static readonly string InsertOrUpdateAction = "InsertOrUpdate";
        /// <summary>
        /// 删除操作
        /// </summary>
        public static readonly string DeleteAction = "Delete";
        /// <summary>
        /// 整体删除操作
        /// </summary>
        public static readonly string DeleteAllAction = "DeleteAll";
        /// <summary>
        /// 刷新操作
        /// </summary>
        public static readonly string RefreshAction = "Refresh";
        /// <summary>
        /// 数据变动过的属性名称集合的键名称
        /// </summary>
        public static readonly string ModifyAttrKeys = "Modify_Attr_Keys";

        #endregion


        #region ==================定制类项目专用标识=======================

        /// <summary>
        /// 数据库用户名称
        /// </summary>
        public static readonly string DATABASE_USERNAME = "LMFL2015";

        /// <summary>
        /// 项目前缀
        /// </summary>
        public static readonly string PROJ_PREFIX = "PT";

        /// <summary>
        /// 项目审核机构
        /// </summary>
        public static readonly int ProjectAuditDeptId = 
            ((ConfigurationManager.AppSettings["ProjectAuditDeptId"] != null) ?
            int.Parse(ConfigurationManager.AppSettings["ProjectAuditDeptId"]) : 0);

        /// <summary>
        /// 报告导出路径
        /// </summary>
        public static readonly string ProjectReportPath = 
            ConfigurationManager.AppSettings["ProjectReportPath"].ToRequestString();

        #endregion
    }
}