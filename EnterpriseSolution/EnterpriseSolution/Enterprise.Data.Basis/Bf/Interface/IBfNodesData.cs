using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfNodesData.cs
    /// ��������: ���ݲ�-ҵ�����ڵ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:56
    /// </summary>
    public interface IBfNodesData : IDataBasis<BfNodesModel>
    {
        /// <summary>
        /// ����ҵ����ID�Ͱ汾�Ż�ȡ���нڵ���Ϣ����
        /// </summary>
        /// <param name="bf_id">ҵ����ID</param>
        /// <param name="bf_version">ҵ�����汾</param>
        /// <returns></returns>
        IList<BfNodesModel> GetListById_Version(string bf_id, int bf_version);
    }
}
