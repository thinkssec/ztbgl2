using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Article;

namespace Enterprise.Data.Common.Article
{	

    /// <summary>
    /// �ļ���:  IArticleInfoData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/28 10:54:44
    /// </summary>
    public interface IArticleInfoData : IDataCommon<ArticleInfoModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
    }

}
