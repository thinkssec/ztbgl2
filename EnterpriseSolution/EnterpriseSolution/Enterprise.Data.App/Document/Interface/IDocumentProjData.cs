using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// �ļ���:  IDocumentProjData.cs
    /// ��������: ���ݲ�-ҵ���ĵ������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/6 8:25:03
    /// </summary>
    public interface IDocumentProjData : IDataApp<DocumentProjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentProjModel> GetListBySQL(string sql);

        #endregion
    }

}
