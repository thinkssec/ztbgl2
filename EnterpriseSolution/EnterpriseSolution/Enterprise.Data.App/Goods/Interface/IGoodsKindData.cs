using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Goods;

namespace Enterprise.Data.App.Goods
{	

    /// <summary>
    /// �ļ���:  IGoodsKindData.cs
    /// ��������: ���ݲ�-�����������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:12
    /// </summary>
    public interface IGoodsKindData : IDataApp<GoodsKindModel>
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
