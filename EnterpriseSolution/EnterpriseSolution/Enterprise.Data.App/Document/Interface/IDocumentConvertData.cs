using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// �ļ���:  IDocumentConvertData.cs
    /// ��������: ���ݲ�-�ĵ�ת�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/6 8:25:00
    /// </summary>
    public interface IDocumentConvertData : IDataApp<DocumentConvertModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentConvertModel> GetListBySQL(string sql);

        #endregion
    }

}
