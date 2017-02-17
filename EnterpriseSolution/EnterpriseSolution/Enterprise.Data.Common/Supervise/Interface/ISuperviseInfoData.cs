using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Data.Common.Supervise
{	

    /// <summary>
    /// �ļ���:  ISuperviseInfoData.cs
    /// ��������: ���ݲ�-������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/3/13 10:53:09
    /// </summary>
    public interface ISuperviseInfoData : IDataCommon<SuperviseInfoModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
        void Delete(string dbid);
    }

}
