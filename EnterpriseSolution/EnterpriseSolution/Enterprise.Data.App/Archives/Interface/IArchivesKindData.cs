using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Archives;

namespace Enterprise.Data.App.Archives
{	

    /// <summary>
    /// �ļ���:  IArchivesKindData.cs
    /// ��������: ���ݲ�-�����������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/7 13:50:46
    /// </summary>
    public interface IArchivesKindData : IDataApp<ArchivesKindModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ArchivesKindModel> GetListBySQL(string sql);

        #endregion
    }

}
