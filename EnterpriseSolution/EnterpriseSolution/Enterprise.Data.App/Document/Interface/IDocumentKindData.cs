using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// �ļ���:  IDocumentKindData.cs
    /// ��������: ���ݲ�-�ĵ���������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/6 8:25:02
    /// </summary>
    public interface IDocumentKindData : IDataApp<DocumentKindModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentKindModel> GetListBySQL(string sql);

        /// <summary>
        /// �������ݼ���
        /// ��˳������򣬲����ݲ㼶��ʾ
        /// </summary>
        /// <returns></returns>
        IList<DocumentKindModel> GetTreeList();

        #endregion
    }

}
