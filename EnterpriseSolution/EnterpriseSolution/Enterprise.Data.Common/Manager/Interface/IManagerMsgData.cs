using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Manager;

namespace Enterprise.Data.Common.Manager
{	

    /// <summary>
    /// �ļ���:  IManagerMsgData.cs
    /// ��������: ���ݲ�-�쵼�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/27 17:55:12
    /// </summary>
    public interface IManagerMsgData : IDataCommon<ManagerMsgModel>
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
