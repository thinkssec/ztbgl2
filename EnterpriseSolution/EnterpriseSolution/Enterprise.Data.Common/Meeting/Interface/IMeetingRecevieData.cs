using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Data.Common.Meeting
{	

    /// <summary>
    /// �ļ���:  IMeetingRecevieData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/3/1 15:50:39
    /// </summary>
    public interface IMeetingRecevieData : IDataCommon<MeetingRecevieModel>
    {
        #region ����������
        
        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <param name="hql">Nhibernate HQL,���hqlΪ�� ������������</param>
        /// <returns></returns>
        IList<MeetingRecevieModel> GetListByHQL(string hql);

        #endregion
    }

}
