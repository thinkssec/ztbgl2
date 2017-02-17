using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// �ļ���:  BfNodesService.cs
    /// ��������: ҵ���߼���-ҵ�����ڵ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:56
    /// </summary>
    public class BfNodesService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfNodesData dal = new BfNodesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfNodesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfNodesModel model)
        {
            return dal.Execute(model);
        }


        /// <summary>
        /// ����ҵ����ID�Ͱ汾�Ż�ȡ���нڵ���Ϣ����
        /// </summary>
        /// <param name="bf_id">ҵ����ID</param>
        /// <param name="bf_version">ҵ�����汾</param>
        /// <returns></returns>
        public IList<BfNodesModel> GetListById_Version(string bf_id, int bf_version)
        {
            return dal.GetListById_Version(bf_id, bf_version);
        }


        #region ��̬������

        /// <summary>
        /// ���ݴ��ݵı��ļ�·���Զ��ж���Ӧ��ҵ����ID�Ͱ汾��
        /// </summary>
        /// <param name="formPath">�ļ�·��</param>
        /// <param name="bfVersion">�����汾��</param>
        /// <returns></returns>
        public static string GetBF_Id_VersionForFormPath(string formPath, out int bfVersion)
        {
            //�汾�ų�ʼֵ
            bfVersion = 1;
            //�����뵱ǰ·�������ҵ�����ڵ㼯��,�汾�ŴӴ�С����
            List<BfNodesModel> nodeList = dal.GetList().Where(p => p.BF_FORM.Contains(formPath)).
                OrderByDescending(p=>p.BF_VERSION).ToList();
            foreach (var n in nodeList)
            {
                if (n.BfPublish.BF_PUBSIGN == 1)
                {
                    bfVersion = n.BF_VERSION;
                    return n.BF_ID;
                }
            }
            return "";
        }

        #endregion

    }

}
