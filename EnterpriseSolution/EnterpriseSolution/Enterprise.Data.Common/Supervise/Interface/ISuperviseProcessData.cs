using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Data.Common.Supervise
{	

    /// <summary>
    /// �ļ���:  ISuperviseProcessData.cs
    /// ��������: ���ݲ�-����������ȼ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/3/13 10:53:10
    /// </summary>
    public interface ISuperviseProcessData : IDataCommon<SuperviseProcessModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
        void DeleteJobs(string dbId);

        decimal GetProcess(string dbId,string yqsbsj);

        List<string> GetMyIdList(int userId);

        List<string> GetMyChargeList(int userId);
    }

}
