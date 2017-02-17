using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// �ļ���:  IExcSmsData.cs
    /// ��������: ���ݲ�-���ŷ��ͱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:19:29
    /// </summary>
    public interface IExcSmsData : IDataBasis<ExcSmsModel>
    {
        
        /// <summary>
        /// ��ȡָ���ļ�¼
        /// </summary>
        /// <returns></returns>
        ExcSmsModel GetModelById(string Id);

    }
}
