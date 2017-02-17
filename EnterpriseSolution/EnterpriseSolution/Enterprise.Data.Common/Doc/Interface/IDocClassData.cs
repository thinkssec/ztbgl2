using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Data.Common.Doc
{	

    /// <summary>
    /// �ļ���:  IDocClassData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/26 15:10:23
    /// </summary>
    public interface IDocClassData : IDataCommon<DocClassModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
        
        DocClassModel GetListById(int classId);

        bool HasArticle(int classId);

        bool AllowPubArticleInClass(int classId, int userId);
    }

}
