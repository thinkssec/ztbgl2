using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Article;

namespace Enterprise.Data.Common.Article
{	

    /// <summary>
    /// �ļ���:  IArticleRecevieData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/28 10:54:45
    /// </summary>
    public interface IArticleRecevieData : IDataCommon<ArticleRecevieModel>
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
