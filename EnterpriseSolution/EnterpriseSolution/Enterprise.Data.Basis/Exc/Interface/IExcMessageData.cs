using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// �ļ���:  IExcMessageData.cs
    /// ��������: ���ݲ�-��ʱ��Ϣ���ͱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-2-4 12:19:28
    /// </summary>
    public interface IExcMessageData : IDataBasis<ExcMessageModel>
    {
        /// <summary>
        /// ��ȡָ���ļ�¼
        /// </summary>
        /// <returns></returns>
        ExcMessageModel GetModelById(string Id);
    }
}
