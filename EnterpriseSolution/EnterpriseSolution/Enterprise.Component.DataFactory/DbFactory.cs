using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Enterprise.Component.Infrastructure;

namespace Enterprise.Component.DataFactory
{
    /// <summary>
    ///  数据库实现
    /// </summary>
    public class DbFactory
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string HjzxConnString ="OracleConnString";

        /// <summary>
        /// 数据库
        /// </summary>
        public static Database HjzxDatabase
        {
            get
            {
                return CreateDatabase(HjzxConnString);
            }
        }

        /// <summary>
        /// 创建企业库数据库对象
        /// </summary>
        /// <param name="ConnString">数据库连接串名称</param>
        /// <returns></returns>
        public static Database CreateDatabase(string ConnString)
        {
            return DatabaseFactory.CreateDatabase(ConnString);
        }

    }
}
