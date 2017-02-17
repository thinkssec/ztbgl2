using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Office;

namespace Enterprise.Data.Common.Office
{	

    /// <summary>
    /// �ļ���:  IOfficeDocumentData.cs
    /// ��������: ���ݲ�-������ת�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-27 21:01:29
    /// </summary>
    public interface IOfficeDocumentData : IDataCommon<OfficeDocumentModel>
    {
        #region ����������

        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OfficeDocumentModel GetModelById(string id);

        #endregion
    }

}
