using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Office;

namespace Enterprise.Data.Common.Office
{	

    /// <summary>
    /// �ļ���:  IOfficeRecevieData.cs
    /// ��������: ���ݲ�-����ǩ�ռ�¼���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-27 21:01:30
    /// </summary>
    public interface IOfficeRecevieData : IDataCommon<OfficeRecevieModel>
    {
        #region ����������

        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OfficeRecevieModel GetModelById(string id);

        #endregion
    }

}
