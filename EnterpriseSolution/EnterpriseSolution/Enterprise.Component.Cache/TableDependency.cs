using System.Web.Caching;
using System.Configuration;

namespace Enterprise.Component.Cache
{

    /// <summary>
    /// �����Ǿ���Ҫ���Ʒ�� Category,Item,Product �Ĺ�ͬ���࣬����ʵ�����๹�캯����GetDependency����
    /// </summary>
    public abstract class TableDependency : ICacheDependency {

        // Ϊ����web.config�ļ����й����ݱ�����ã������ָ���
        protected char[] configurationSeparator = new char[] { ',' };

        protected AggregateCacheDependency dependency = new AggregateCacheDependency();

        //�������ݱ������ʵ��
       // private static readonly SYS_CacheDependency_Data cacheDAL = new SYS_CacheDependency_Data();

        /// <summary>
        /// ʵ���๹�캯�������þۺϻ�����������
        /// </summary>
        /// <param name="configKey">������Ϣ</param>
        protected TableDependency(string configKey) {

            //1=��web.config�ж�ȡ
            //string dbName = ConfigurationManager.AppSettings["CacheDatabaseName"];
            //string tableConfig = ConfigurationManager.AppSettings[configKey];
            //string[] tables = tableConfig.Split(configurationSeparator);

            //2=�ӻ��������ȡָ�����ƵĻ���������
            //SysCacheModel cacheModel = cacheDAL.GetModelByCacheName(configKey);
            //if (cacheModel != null && 
            //    !string.IsNullOrEmpty(cacheModel.DBName) && 
            //    !string.IsNullOrEmpty(cacheModel.TableNames))
            //{
            //    string[] tables = cacheModel.TableNames.Split(configurationSeparator);
            //    foreach (string tableName in tables)
            //    {
            //        //���ݱ�����
            //        dependency.Add(new SqlCacheDependency(cacheModel.DBName, tableName));
            //    }
            //}
        }

        
        /// <summary>
        /// ʵ��GetDependency���������ؾۺϻ�����������Dependency 
        /// </summary>
        /// <returns></returns>
        public AggregateCacheDependency GetDependency() {
            return dependency;
        }
    }
}
