using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfBaseData.cs
    /// ��������: ���ݲ�-ҵ�������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:50
    /// </summary>
    public interface IBfBaseData : IDataBasis<BfBaseModel>
    {
        /// <summary>
        /// ����ҵ����ID
        /// </summary>
        /// <returns></returns>
        string GetBF_ID();
    }
}
