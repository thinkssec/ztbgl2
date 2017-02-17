using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{	

    /// <summary>
    /// �ļ���:  ISysUserindividData.cs
    /// ��������: ���ݲ�-���Ի����ñ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-7-3 11:42:29
    /// </summary>
    public interface ISysUserindividData : IDataBasis<SysUserindividModel>
    {
        #region ����������

        /// <summary>
        /// ��ȡָ��ID������
        /// </summary>
        /// <returns></returns>
        SysUserindividModel GetModelById(int id);

        #endregion
    }

}
