using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Goods;

namespace Enterprise.Data.App.Goods
{	

    /// <summary>
    /// �ļ���:  IGoodsDeviceData.cs
    /// ��������: ���ݲ�-�豸���ӵ������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:11
    /// </summary>
    public interface IGoodsDeviceData : IDataApp<GoodsDeviceModel>
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
