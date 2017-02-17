using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysDictionaryService.cs
    /// 功能描述: 业务逻辑层-字典表数据处理
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysDictionaryService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysDictionaryData dal = new SysDictionaryData();
        /// <summary>
        /// 同步标识
        /// </summary>
        private static object _synRoot = new Object();
        /// <summary>
        /// 保存系统登录用户使用的语言类型
        /// </summary>
        private static Hashtable userLanguageTypeHash = Hashtable.Synchronized(new Hashtable());


        #region 公共方法

        /// <summary>
        /// 保存用户的语言类型
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="langType"></param>
        public static void AddLangType(string loginName,Utility.LanguageType langType)
        {
            userLanguageTypeHash[loginName] = langType;
        }

        /// <summary>
        /// 提取指定用户的语言类型
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static Utility.LanguageType GetLangType(string loginName)
        {
            //缺省为中文
            Utility.LanguageType langType = Utility.LanguageType.zhcn;

            if (userLanguageTypeHash.ContainsKey(loginName))
            {
                langType = (Utility.LanguageType)userLanguageTypeHash[loginName];
            }

            return langType;
        }


        /// <summary>
        /// 获取语言转换词典
        /// </summary>
        /// <returns></returns>
        public static IList<SysDictionaryModel> GetLangTransList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 将中文翻译成对应语言的文字 。LanguageType可扩展
        /// 此处采用了缓存 如需更新缓存请调用UpdateCache来更新字典缓存
        /// </summary>
        /// <param name="zhcn">中文</param>
        /// <returns></returns>
        public static string TranslateTo(string zhcn, Utility.LanguageType langType)
        {
            return zhcn;
            //mod by qw 2013.10.31 海检项目不需要多语言
            //if (langType == Utility.LanguageType.zhcn || string.IsNullOrEmpty(zhcn))
            //    return zhcn;
            //string covertString = (zhcn == null) ? "" : zhcn;
            //IList<SysDictionaryModel> dictionaryList = GetLangTransList();
            ////加锁同步
            //lock (_synRoot)
            //{
            //    var q = dictionaryList.Where(s => s.ZWMC == zhcn && s.YZ == langType.ToString()).FirstOrDefault();
            //    if (q != null)
            //    {
            //        covertString = q.DYMC;
            //    }
            //    //add by qw 2013.3.8 start 如果不存在该词条，则自动向数据表添加一条记录
            //    else if (CommonTool.CheckUnicodeIsZhcn(covertString))
            //    {
            //        try
            //        {
            //            //add by qw 2013.9.16 start 增加一个开关
            //            string zhcnSwitch = ConfigurationManager.AppSettings["ZhcnSwitch"];
            //            if (zhcnSwitch.ToLower().Equals("on"))
            //            {
            //                SysDictionaryModel dicModel = new SysDictionaryModel();
            //                dicModel.ZWMC = zhcn;
            //                dicModel.YZ = langType.ToString();
            //                dicModel.DYMC = zhcn;
            //                dicModel.SSZB = Utility.GetScriptFileName;
            //                dicModel.DB_Option_Action = WebKeys.InsertAction;
            //                dal.Execute(dicModel);
            //            }
            //            //end
            //        }
            //        catch (Exception ex)
            //        {
            //            Debuger.GetInstance().log("在TranslateTo方法中添加新词条出错=>" + ex.Message);
            //        }
            //    }
            //}
            ////end
            //return covertString;
        }

        /// <summary>
        /// 将中文翻译成对应语言的文字
        /// </summary>
        /// <param name="zhcn">中文</param>
        /// <returns></returns>
        public static string TransTo(string zhcn)
        {
            //if (Utility.Language != Utility.LanguageType.zhcn)
            //{
            //    return SysDictionaryService.TranslateTo(zhcn, Utility.Language);
            //}
            return zhcn;
        }

        #endregion


        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysDictionaryModel> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 根据中文名称获取对应的词典数据
        /// </summary>
        /// <returns></returns>
        public IList<SysDictionaryModel> GetListByZwmc(string zwmc)
        {
            return dal.GetListByZwmc(zwmc);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysDictionaryModel model)
        {
            return dal.Execute(model);
        }

    }

}
