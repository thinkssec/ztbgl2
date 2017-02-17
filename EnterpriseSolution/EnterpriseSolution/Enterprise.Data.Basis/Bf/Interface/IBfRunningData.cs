using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfRunningData.cs
    /// ��������: ���ݲ�-ҵ�������б����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:58
    /// </summary>
    public interface IBfRunningData : IDataBasis<BfRunningModel>
    {
        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<BfRunningModel> GetList(string hql);

        /// <summary>
        /// ����ID���ز�ѯ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BfRunningModel GetModelById(string id);

        /// <summary>
        /// ����ʵ��ID�������ݼ���
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        IList<BfRunningModel> GetListByInstanceId(string instanceId);

        /// <summary>
        /// ����������ѯ�������
        /// </summary>
        /// <param name="sql">ԭ��SQL</param>
        /// <returns></returns>
        IList<BfRunningModel> GetListBySQL(string sql);

    }
}
