using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// �ļ���:  IDocumentDownloadsData.cs
    /// ��������: ���ݲ�-�ĵ���������ؼ�¼�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/6 8:25:01
    /// </summary>
    public interface IDocumentDownloadsData : IDataApp<DocumentDownloadsModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentDownloadsModel> GetListBySQL(string sql);

        #endregion
    }

}
