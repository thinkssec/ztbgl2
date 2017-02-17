using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Article;

namespace Enterprise.Data.Common.Article
{	

    /// <summary>
    /// �ļ���:  IArticleDownloadData.cs
    /// ��������: ���ݲ�-�ĵ����ع������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-5-16 17:44:17
    /// </summary>
    public interface IArticleDownloadData : IDataCommon<ArticleDownloadModel>
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
