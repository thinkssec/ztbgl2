using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Vote;

namespace Enterprise.Data.Common.Vote
{	

    /// <summary>
    /// �ļ���:  IVoteInfoData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/3/1 10:30:49
    /// </summary>
    public interface IVoteInfoData : IDataCommon<VoteInfoModel>
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
