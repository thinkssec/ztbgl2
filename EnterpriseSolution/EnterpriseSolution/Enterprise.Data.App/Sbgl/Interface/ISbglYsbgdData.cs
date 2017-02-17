using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Sbgl;
using System.Data;

namespace Enterprise.Data.App.Sbgl
{	

    /// <summary>
    /// �ļ���:  ISbglYsbgdData.cs
    /// ��������: ���ݲ�-�豸ά����Ŀ���ձ��浥���ݷ��ʽӿ�
    /// �����ˣ�����������
    /// ����ʱ�䣺2015/4/30 8:22:37
    /// </summary>
    public interface ISbglYsbgdData : IDataApp<SbglYsbgdModel>
    {
        #region ����������

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SbglYsbgdModel GetSingle(string key);

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SbglYsbgdModel> GetListBySQL(string sql);

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);

        /// <summary>
        /// ��ȡ��ѯ���ݼ�
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        DataTable GetDataTable(string sql);

        #endregion
    }

}
