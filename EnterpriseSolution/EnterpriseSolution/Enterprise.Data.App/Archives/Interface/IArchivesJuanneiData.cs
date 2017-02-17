using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Archives;

namespace Enterprise.Data.App.Archives
{	

    /// <summary>
    /// �ļ���:  IArchivesJuanneiData.cs
    /// ��������: ���ݲ�-����Ŀ¼�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/7 13:50:45
    /// </summary>
    public interface IArchivesJuanneiData : IDataApp<ArchivesJuanneiModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ArchivesJuanneiModel> GetListBySQL(string sql);

        #endregion
    }

}
