using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectRunningData.cs
    /// ��������: ���ݲ�-��Ŀ�ڵ�ƻ������б����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:23
    /// </summary>
    public interface IProjectRunningData : IDataApp<ProjectRunningModel>
    {
        #region ����������
        
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool ExecuteLst(IList<ProjectRunningModel> models);

        #endregion

        /// <summary>
        /// �������Ϳؼ��ű�
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        string GetRunningEasyuiTreeHtmlById(string projectId);
    }

}
