using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Data.Common.Doc
{	

    /// <summary>
    /// 文件名:  IDocClassData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/2/26 15:10:23
    /// </summary>
    public interface IDocClassData : IDataCommon<DocClassModel>
    {
        #region 代码生成器
        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
        
        DocClassModel GetListById(int classId);

        bool HasArticle(int classId);

        bool AllowPubArticleInClass(int classId, int userId);
    }

}
