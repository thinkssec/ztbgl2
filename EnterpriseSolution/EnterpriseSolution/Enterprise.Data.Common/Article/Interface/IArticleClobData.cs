using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Article;

namespace Enterprise.Data.Common.Article
{	

    /// <summary>
    /// �ļ���:  IArticleClobData.cs
    /// ��������: ���ݲ�-���ı����ݱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/7 13:50:48
    /// </summary>
    public interface IArticleClobData : IDataCommon<ArticleClobModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ArticleClobModel> GetListBySQL(string sql);


        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<ArticleClobModel> GetListByHQL(string hql);


        #endregion
    }

}
