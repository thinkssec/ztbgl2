using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfInstancesData.cs
    /// ��������: ���ݲ�-ҵ����ʵ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:55
    /// </summary>
    public interface IBfInstancesData : IDataBasis<BfInstancesModel>
    {
        /// <summary>
        /// ����ID��ȡ��Ӧ����
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        BfInstancesModel GetModelById(string instanceId);
    }
}
