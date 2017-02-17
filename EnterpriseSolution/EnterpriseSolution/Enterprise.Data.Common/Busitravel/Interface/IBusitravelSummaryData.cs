using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{	

    /// <summary>
    /// �ļ���:  IBusitravelSummaryData.cs
    /// ��������: ���ݲ�-����������ܱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-6-24 20:24:42
    /// </summary>
    public interface IBusitravelSummaryData : IDataCommon<BusitravelSummaryModel>
    {

        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<BusitravelSummaryModel> GetListBySQL(string sql);

        #endregion
    }

}
