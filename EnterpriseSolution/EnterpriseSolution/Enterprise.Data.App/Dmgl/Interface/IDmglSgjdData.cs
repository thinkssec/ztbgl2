using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Data.App.Dmgl
{	

    /// <summary>
    /// �ļ���:  IDmglSgjdData.cs
    /// ��������: ���ݲ�-ʩ���������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/5/17 15:16:26
    /// </summary>
    public interface IDmglSgjdData : IDataApp<DmglSgjdModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DmglSgjdModel> GetListBySQL(string sql);

        #endregion
    }

}
