using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Enterprise.Component.Infrastructure
{
    /// <summary>
    /// 硕正控件相关工具类
    /// </summary>
    public sealed class SupCanTool
    {

        #region 变量声明

        #endregion

        #region 将数据结果转换为XML

        /// <summary>
        /// 将集合中的对象转换为XML形式
        /// </summary>
        /// <param name="lst">集合</param>
        /// <param name="t">对象类型</param>
        /// <param name="dispNames">可显示的属性集合</param>
        /// <param name="nStart">起始索引</param>
        /// <param name="nRows">最大记录数量</param>
        /// <returns></returns>
        public static string ConvertArrayToSupCanXml(ArrayList lst, Type t, string[] dispNames, int nStart, int nRows)
        {
            StringBuilder sbStr = new StringBuilder(); //用来存储下面生成的xml
            // 生成xml数据
            sbStr.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?> <data totalrows=\"" + lst.Count + "\">");
            PropertyInfo[] pi = t.GetProperties();
            //从数据库读取数据 循环添加至XML
            for (int i = nStart; i < lst.Count; i++)
            {
                if (i - nStart >= nRows) break;
                var obj = lst[i];
                sbStr.Append("<record>");
                for (int j = 0; j < dispNames.Length; j++)
                {
                    sbStr.Append("<" + dispNames[j] + ">");
                    sbStr.Append("<![CDATA[");
                    foreach (PropertyInfo p in pi)
                    {
                        MethodInfo m = p.GetGetMethod();
                        if (m == null) continue;
                        if (p.Name.ToUpper() == dispNames[j].ToUpper())
                        {
                            try
                            {
                                sbStr.Append(CommonTool._ConvertToString(p.GetValue(obj, null)));
                            }
                            catch
                            {
                                sbStr.Append(string.Empty);
                            }
                            break;
                        }
                    }
                    sbStr.Append("]]>");
                    sbStr.Append("</" + dispNames[j] + ">");
                }
                sbStr.Append("</record>");
            }
            sbStr.Append("</data>");
            return sbStr.ToString();
        }

        /// <summary>
        /// DataTable数据转换成XML供硕正控件使用
        /// </summary>
        /// <param name="dt">数据集</param>
        /// <param name="dataString">字段名</param>
        /// <param name="nStart">本页起始行</param>
        /// <param name="nRows">每页显示记录数</param>
        public static string ConvertDataTableToSupCanXml(DataTable dt, string dataString, int nStart, int nRows)
        {
            StringBuilder sbStr = new StringBuilder(); //用来存储下面生成的xml
            // 生成xml数据
            sbStr.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?> <data totalrows=\"" + dt.Rows.Count.ToString() + "\">");
            if (dt.Rows.Count > 0)
            {
                //从数据库读取数据 循环添加至XML
                string[] columnName = dataString.Split(',');
                for (int i = nStart; i < dt.Rows.Count; i++)
                {
                    if (i - nStart >= nRows) break;
                    sbStr.Append("<record>");
                    for (int j = 0; j < columnName.Length; j++)
                    {
                        sbStr.Append("<" + columnName[j] + ">");
                        switch (dt.Rows[i][columnName[j]].GetType().ToString())
                        {
                            case "System.DBNull":
                                sbStr.Append(string.Empty);
                                break;
                            default:
                                sbStr.Append("<![CDATA[");
                                sbStr.Append(dt.Rows[i][columnName[j]].ToString());
                                sbStr.Append("]]>");
                                break;
                        }
                        sbStr.Append("</" + columnName[j] + ">");
                    }
                    sbStr.Append("</record>");
                }
            }
            sbStr.Append("</data>");
            return sbStr.ToString();
        }

        #endregion

        #region 将XML生成SQL脚本

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="xmlData">XML数据</param>
        /// <param name="table">表名</param>
        /// <param name="t">对象类型</param>
        public static string InsertSQL(string xmlData, string table, Type t)
        {
            XmlDocument xmlInfo = new XmlDocument();
            XmlElement xmlElement = null;
            string sql = "begin ";
            string tempName = "";
            try
            {
                xmlInfo.LoadXml(xmlData);
                xmlElement = xmlInfo["table"]["newRow"];
            }
            catch { }

            if (xmlElement == null)
            {
                return "";
            }

            if (string.IsNullOrEmpty(table))
            {
                table = CommonTool.GetTableNameByNsCls(t.ToString());
            }

            PropertyInfo[] properties = t.GetProperties();
            foreach (XmlNode item in xmlElement.ChildNodes)
            {
                sql += "insert into " + table + "(";
                string sqlMain = "";
                string sqlColumn = "";
                foreach (PropertyInfo pi in properties)
                {
                    MethodInfo m = pi.GetSetMethod();
                    if (m == null) continue;
                    tempName = pi.Name;
                    if (item[tempName] != null)
                    {
                        sqlColumn += tempName + ",";
                        if (pi.PropertyType.Equals(typeof(System.DateTime)) ||
                            pi.PropertyType.Equals(typeof(Nullable<System.DateTime>)))
                        {
                            //日期型特殊处理，oracle
                            sqlMain += "to_date('" + item[tempName].InnerText.Replace("\r\n", "").Replace(".", "-") + "','yyyy-MM-dd'),";
                        }
                        else
                        {
                            sqlMain += "'" + item[tempName].InnerText.Replace("\r\n", "") + "',";
                        }
                    }
                }
                sql += sqlColumn.Substring(0, sqlColumn.Length - 1) + ") values (";
                sql += sqlMain.Substring(0, sqlMain.Length - 1) + ");";
            }
            sql += "null; ";
            sql += "end; ";

            return sql;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="xmlData">XML数据</param>
        /// <param name="table">表名</param>
        /// <param name="t">对象类型</param>
        public static string UpdateSQL(string xmlData, string table, Type t)
        {
            XmlDocument xmlInfo = new XmlDocument();
            XmlElement xmlElement = null;
            try
            {
                xmlInfo.LoadXml(xmlData);
                xmlElement = xmlInfo["table"]["modifiedRow"];
            }
            catch { }

            if (xmlElement == null)
            {
                return "";
            }

            if (string.IsNullOrEmpty(table))
            {
                table = CommonTool.GetTableNameByNsCls(t.ToString());
            }

            PropertyInfo[] properties = t.GetProperties();
            string tempName = "";
            string sql = "begin ";
            foreach (XmlNode item in xmlElement.ChildNodes)
            {
                sql += "update " + table + " set ";
                string sqlWhere = " where ";
                string[] key = xmlInfo["table"].Attributes["key"].Value.Split(',');
                string[] keyValue = item.Attributes["key"].Value.Split(',');
                for (int i = 0; i < key.Length; i++)
                {
                    if (i != 0)
                    {
                        sqlWhere += " and ";
                    }
                    sqlWhere += key[i] + "='" + keyValue[i] + "'";
                }
                foreach (PropertyInfo pi in properties)
                {
                    MethodInfo m = pi.GetSetMethod();
                    if (m == null) continue;
                    tempName = pi.Name;
                    if (item[tempName] != null)
                    {
                        //sql += "pi.PropertyType==" + pi.PropertyType.ToString();
                        if (pi.PropertyType.Equals(typeof(System.DateTime)) ||
                            pi.PropertyType.Equals(typeof(Nullable<System.DateTime>)))
                        {
                            //日期型特殊处理，oracle
                            sql += tempName + "=to_date('" + item[tempName].InnerText.Replace("\r\n", "").Replace(".", "-") + "','yyyy-MM-dd'),";
                        }
                        else
                        {
                            sql += tempName + "='" + item[tempName].InnerText.Replace("\r\n", "") + "',";
                        }
                    }
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += sqlWhere + ";";
            }
            sql += "null; ";
            sql += "end; ";

            return sql;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="xmlData">XML数据</param>
        /// <param name="table">表名</param>
        /// <param name="t">对象类型</param>
        public static string DeleteSQL(string xmlData, string table, Type t)
        {
            XmlDocument xmlInfo = new XmlDocument();
            XmlElement xmlElement = null;
            try
            {
                xmlInfo.LoadXml(xmlData);
                xmlElement = xmlInfo["table"]["deletedRow"];
            }
            catch { }

            if (xmlElement == null)
            {
                return "";
            }

            if (string.IsNullOrEmpty(table))
            {
                table = CommonTool.GetTableNameByNsCls(t.ToString());
            }

            string sqlDel = "begin ";
            foreach (XmlNode item in xmlElement.ChildNodes)
            {
                sqlDel += "delete from " + table;
                string sqlWhere = " where ";
                string[] key = xmlInfo["table"].Attributes["key"].Value.Split(',');
                string[] keyValue = item.Attributes["key"].Value.Split(',');
                for (int i = 0; i < key.Length; i++)
                {
                    if (i != 0)
                    {
                        sqlWhere += " and ";
                    }
                    sqlWhere += key[i] + "='" + keyValue[i] + "'";
                }
                sqlDel += sqlWhere;
                sqlDel += ";";
            }
            sqlDel += "null; ";
            sqlDel += "end; ";

            return sqlDel;
        }

        #endregion

        #region 将XML转为对象集合

        /// <summary>
        /// 将需添加的XML数据转为对象集合
        /// </summary>
        /// <param name="xmlData">XML数据</param>
        /// <param name="t">对象类型</param>
        /// <returns></returns>
        public static ArrayList GetInsertModels(string xmlData, Type t)
        {
            ArrayList list = new ArrayList();
            XmlDocument xmlInfo = new XmlDocument();
            XmlElement xmlElement = null;
            try
            {
                xmlInfo.LoadXml(xmlData);
                xmlElement = xmlInfo["table"]["newRow"];
            }
            catch { }

            if (xmlElement == null)
            {
                return list;
            }

            PropertyInfo[] properties = t.GetProperties();
            foreach (XmlNode item in xmlElement.ChildNodes)
            {
                //每一行数据,声明一个新的对象
                Object obj = Activator.CreateInstance(t);
                foreach (PropertyInfo pi in properties)
                {
                    MethodInfo m = pi.GetSetMethod();
                    if (m == null) continue;
                    ParameterInfo[] pai = m.GetParameters();
                    if (pai == null) continue;
                    if (item[pi.Name] == null) continue;
                    string v = item[pi.Name].InnerText.Replace("\r\n", "");
                    //if (string.IsNullOrEmpty(v)) continue;
                    try
                    {
                        if (pai[0].ParameterType.IsGenericType)
                        {
                            m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType.GetGenericArguments()[0]) });
                        }
                        else if (typeof(IConvertible).IsAssignableFrom(pai[0].ParameterType))
                        {
                            m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType) });
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                list.Add(obj);
            }
            return list;
        }


        /// <summary>
        /// 将需更新的XML数据转为对象集合
        /// </summary>
        /// <param name="xmlData">XML数据</param>
        /// <param name="t">对象类型</param>
        /// <returns></returns>
        public static ArrayList GetUpdateModels(string xmlData, Type t)
        {
            ArrayList list = new ArrayList();
            List<string> attrKeys = new List<string>();
            XmlDocument xmlInfo = new XmlDocument();
            XmlElement xmlElement = null;
            try
            {
                xmlInfo.LoadXml(xmlData);
                xmlElement = xmlInfo["table"]["modifiedRow"];
            }
            catch { }

            if (xmlElement == null)
            {
                return list;
            }

            PropertyInfo[] properties = t.GetProperties();
            foreach (XmlNode item in xmlElement.ChildNodes)
            {
                //每一行数据,声明一个新的对象
                Object obj = Activator.CreateInstance(t);
                //主键部分
                string[] key = xmlInfo["table"].Attributes["key"].Value.Split(',');
                attrKeys.AddRange(key);//保存变动的属性名称
                string[] keyValue = item.Attributes["key"].Value.Split(',');
                for (int i = 0; i < key.Length; i++)
                {
                    foreach (PropertyInfo pi in properties)
                    {
                        MethodInfo m = pi.GetSetMethod();
                        if (m == null) continue;
                        ParameterInfo[] pai = m.GetParameters();
                        if (pai == null) continue;
                        if (pi.Name != key[i]) continue;
                        string v = keyValue[i];
                        //if (string.IsNullOrEmpty(v)) continue;
                        try
                        {
                            if (pai[0].ParameterType.IsGenericType)
                            {
                                m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType.GetGenericArguments()[0]) });
                            }
                            else if (typeof(IConvertible).IsAssignableFrom(pai[0].ParameterType))
                            {
                                m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType) });
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                //数据部分
                foreach (PropertyInfo pi in properties)
                {
                    MethodInfo m = pi.GetSetMethod();
                    if (m == null) continue;
                    ParameterInfo[] pai = m.GetParameters();
                    if (pai == null) continue;
                    if (pi.Name == WebKeys.ModifyAttrKeys)
                    {
                        try
                        {
                            //保存出现数据变动的属性集合进MODEL
                            pi.SetValue(obj, attrKeys, null);
                        }
                        catch { }
                        continue;
                    }
                    if (item[pi.Name] == null) continue;
                    string v = item[pi.Name].InnerText.Replace("\r\n", "");
                    //if (string.IsNullOrEmpty(v)) continue;
                    attrKeys.Add(pi.Name);//保存变动的属性名称
                    try
                    {
                        if (pai[0].ParameterType.IsGenericType)
                        {
                            m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType.GetGenericArguments()[0]) });
                        }
                        else if (typeof(IConvertible).IsAssignableFrom(pai[0].ParameterType))
                        {
                            m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType) });
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                //保存
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// 将需删除的XML数据转为对象集合
        /// </summary>
        /// <param name="xmlData">XML数据</param>
        /// <param name="t">对象类型</param>
        /// <returns></returns>
        public static ArrayList GetDeleteModels(string xmlData, Type t)
        {
            ArrayList list = new ArrayList();
            List<string> attrKeys = new List<string>();
            XmlDocument xmlInfo = new XmlDocument();
            XmlElement xmlElement = null;
            try
            {
                xmlInfo.LoadXml(xmlData);
                xmlElement = xmlInfo["table"]["deletedRow"];
            }
            catch { }

            if (xmlElement == null)
            {
                return list;
            }

            PropertyInfo[] properties = t.GetProperties();
            foreach (XmlNode item in xmlElement.ChildNodes)
            {
                //每一行数据,声明一个新的对象
                Object obj = Activator.CreateInstance(t);
                //主键部分
                string[] key = xmlInfo["table"].Attributes["key"].Value.Split(',');
                attrKeys.AddRange(key);//保存变动的属性名称
                string[] keyValue = item.Attributes["key"].Value.Split(',');
                for (int i = 0; i < key.Length; i++)
                {
                    foreach (PropertyInfo pi in properties)
                    {
                        MethodInfo m = pi.GetSetMethod();
                        if (m == null) continue;
                        ParameterInfo[] pai = m.GetParameters();
                        if (pai == null) continue;
                        if (pi.Name != key[i]) continue;
                        string v = keyValue[i];
                        //if (string.IsNullOrEmpty(v)) continue;
                        try
                        {
                            if (pai[0].ParameterType.IsGenericType)
                            {
                                m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType.GetGenericArguments()[0]) });
                            }
                            else if (typeof(IConvertible).IsAssignableFrom(pai[0].ParameterType))
                            {
                                m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType) });
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                //数据部分
                foreach (PropertyInfo pi in properties)
                {
                    MethodInfo m = pi.GetSetMethod();
                    if (m == null) continue;
                    ParameterInfo[] pai = m.GetParameters();
                    if (pai == null) continue;
                    if (pi.Name == WebKeys.ModifyAttrKeys)
                    {
                        try
                        {
                            //保存出现数据变动的属性集合进MODEL
                            pi.SetValue(obj, attrKeys, null);
                        }
                        catch { }
                        continue;
                    }
                    if (item[pi.Name] == null) continue;
                    string v = item[pi.Name].InnerText.Replace("\r\n", "");
                    //if (string.IsNullOrEmpty(v)) continue;
                    attrKeys.Add(pi.Name);//保存变动的属性名称
                    try
                    {
                        if (pai[0].ParameterType.IsGenericType)
                        {
                            m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType.GetGenericArguments()[0]) });
                        }
                        else if (typeof(IConvertible).IsAssignableFrom(pai[0].ParameterType))
                        {
                            m.Invoke(obj, new object[] { Convert.ChangeType(v, pai[0].ParameterType) });
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                //保存
                list.Add(obj);
            }
            return list;
        }

        #endregion
    }
}
