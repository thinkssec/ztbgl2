using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Data.Common.Doc
{	

    /// <summary>
    /// �ļ���:  IDocArticlesData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/26 15:10:22
    /// </summary>
    public interface IDocArticlesData : IDataCommon<DocArticlesModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion

        DocArticlesModel GetListById(int id);
    }

}
