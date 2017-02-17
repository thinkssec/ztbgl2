using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{	

    /// <summary>
    /// �ļ���:  ISysCacherelationData.cs
    /// ��������: ���ݲ�-���������ϵ�����ݷ��ʽӿ�
    /// �����ˣ�����������
    /// ����ʱ�䣺2015/3/17 14:20:12
    /// </summary>
    public interface ISysCacherelationData : IDataBasis<SysCacherelationModel>
    {
        #region ����������

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SysCacherelationModel GetSingle(string key);

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<SysCacherelationModel> GetListByHQL(string hql);

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SysCacherelationModel> GetListBySQL(string sql);

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);
        
        #endregion
    }

}
