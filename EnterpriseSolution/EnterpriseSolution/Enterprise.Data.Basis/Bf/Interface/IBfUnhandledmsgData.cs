using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  IBfUnhandledmsgData.cs
    /// ��������: ���ݲ�-ҵ����δ������Ϣ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:18:58
    /// </summary>
    public interface IBfUnhandledmsgData : IDataBasis<BfUnhandledmsgModel>
    {
        /// <summary>
        /// ��ȡ�����ѯ���������ݼ���
        /// </summary>
        /// <param name="hql">Hibernate��ѯ���</param>
        /// <returns></returns>
        IList<BfUnhandledmsgModel> GetListByHQL(string hql);

        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BfUnhandledmsgModel GetModelById(string id);
    }
}
