using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfNoderolesData.cs
    /// ��������: ���ݲ�-ҵ�����ڵ��ɫ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:55
    /// </summary>
    public interface IBfNoderolesData : IDataBasis<BfNoderolesModel>
    {
        /// <summary>
        /// ����ҵ����ID�Ͱ汾�Ż�ȡ���н�ɫ��Ϣ����
        /// </summary>
        /// <param name="bf_id">ҵ����ID</param>
        /// <param name="bf_version">ҵ�����汾</param>
        /// <returns></returns>
        IList<BfNoderolesModel> GetListById_Version(string bf_id, int bf_version);
    }
}
