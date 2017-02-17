using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// �ļ���:  IExcEmailData.cs
    /// ��������: ���ݲ�-�ʼ����ͱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:19:24
    /// </summary>
    public interface IExcEmailData : IDataBasis<ExcEmailModel>
    {
        /// <summary>
        /// ��ȡָ���ļ�¼
        /// </summary>
        /// <returns></returns>
        ExcEmailModel GetModelById(string Id);
    }
}
