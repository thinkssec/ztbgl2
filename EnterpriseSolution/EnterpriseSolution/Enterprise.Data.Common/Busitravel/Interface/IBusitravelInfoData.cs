using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{	

    /// <summary>
    /// �ļ���:  IBusitravelInfoData.cs
    /// ��������: ���ݲ�-������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-23 17:52:26
    /// </summary>
    public interface IBusitravelInfoData : IDataCommon<BusitravelInfoModel>
    {
        #region ����������

        /// <summary>
        /// ��ȡָ��ID�Ĳ��ü�¼
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        BusitravelInfoModel GetModelById(string bid);

        #endregion
    }

}
