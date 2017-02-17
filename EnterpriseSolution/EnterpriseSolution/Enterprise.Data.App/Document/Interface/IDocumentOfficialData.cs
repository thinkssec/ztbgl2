using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// �ļ���:  IDocumentOfficialData.cs
    /// ��������: ���ݲ�-���ı����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/4/22 16:23:52
    /// </summary>
    public interface IDocumentOfficialData : IDataApp<DocumentOfficialModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentOfficialModel> GetListBySQL(string sql);

        #endregion
    }

}
