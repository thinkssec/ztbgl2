using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{	

    /// <summary>
    /// �ļ���:  IBfTrustusersData.cs
    /// ��������: ���ݲ�-�����������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-26 15:29:32
    /// </summary>
    public interface IBfTrustusersData : IDataBasis<BfTrustusersModel>
    {
        #region ����������

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<BfTrustusersModel> GetListByHQL(string hql);

        #endregion
    }

}
