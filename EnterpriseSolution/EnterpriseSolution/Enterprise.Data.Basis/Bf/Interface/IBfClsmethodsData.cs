using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfClsmethodsData.cs
    /// ��������: ���ݲ�-��ɫ��ȡ���������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:51
    /// </summary>
    public interface IBfClsmethodsData : IDataBasis<BfClsmethodsModel>
    {
        /// <summary>
        /// ���ɽ�ɫ��ȡ������ID
        /// </summary>
        /// <returns></returns>
        string GetClsMethod_ID();
    }
}
