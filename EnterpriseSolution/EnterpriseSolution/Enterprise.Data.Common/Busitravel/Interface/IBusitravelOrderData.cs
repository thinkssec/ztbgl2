using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{	

    /// <summary>
    /// �ļ���:  IBusitravelOrderData.cs
    /// ��������: ���ݲ�-�����������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-6-24 20:24:41
    /// </summary>
    public interface IBusitravelOrderData : IDataCommon<BusitravelOrderModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
    }

}
