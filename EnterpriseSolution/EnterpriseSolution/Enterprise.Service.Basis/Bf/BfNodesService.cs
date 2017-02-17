using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// 文件名:  BfNodesService.cs
    /// 功能描述: 业务逻辑层-业务流节点表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:56
    /// </summary>
    public class BfNodesService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfNodesData dal = new BfNodesData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfNodesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfNodesModel model)
        {
            return dal.Execute(model);
        }


        /// <summary>
        /// 根据业务流ID和版本号获取所有节点信息集合
        /// </summary>
        /// <param name="bf_id">业务流ID</param>
        /// <param name="bf_version">业务流版本</param>
        /// <returns></returns>
        public IList<BfNodesModel> GetListById_Version(string bf_id, int bf_version)
        {
            return dal.GetListById_Version(bf_id, bf_version);
        }


        #region 静态方法区

        /// <summary>
        /// 根据传递的表单文件路径自动判断相应的业务流ID和版本号
        /// </summary>
        /// <param name="formPath">文件路径</param>
        /// <param name="bfVersion">发布版本号</param>
        /// <returns></returns>
        public static string GetBF_Id_VersionForFormPath(string formPath, out int bfVersion)
        {
            //版本号初始值
            bfVersion = 1;
            //所有与当前路径相符的业务流节点集合,版本号从大到小排序
            List<BfNodesModel> nodeList = dal.GetList().Where(p => p.BF_FORM.Contains(formPath)).
                OrderByDescending(p=>p.BF_VERSION).ToList();
            foreach (var n in nodeList)
            {
                if (n.BfPublish.BF_PUBSIGN == 1)
                {
                    bfVersion = n.BF_VERSION;
                    return n.BF_ID;
                }
            }
            return "";
        }

        #endregion

    }

}
