using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfInstancerolesData.cs
    /// ��������: ���ݲ�-ҵ����ʵ����ɫ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:54
    /// </summary>
    public interface IBfInstancerolesData : IDataBasis<BfInstancerolesModel>
    {
        /// <summary>
        /// ��ȡָ��ҵ����ʵ��ID�µĶ�Ӧ��ɫ���ݼ���
        /// </summary>
        /// <param name="instanceId">ҵ����ʵ��ID</param>
        /// <returns></returns>
        IList<BfInstancerolesModel> GetListByInstanceId(string instanceId);
    }
}
