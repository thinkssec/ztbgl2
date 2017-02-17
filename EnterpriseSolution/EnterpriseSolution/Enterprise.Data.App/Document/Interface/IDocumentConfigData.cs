using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Document;

namespace Enterprise.Data.App.Document
{	

    /// <summary>
    /// �ļ���:  IDocumentConfigData.cs
    /// ��������: ���ݲ�-�ĵ������ñ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/6 8:24:59
    /// </summary>
    public interface IDocumentConfigData : IDataApp<DocumentConfigModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DocumentConfigModel> GetListBySQL(string sql);

        #endregion
    }

}
