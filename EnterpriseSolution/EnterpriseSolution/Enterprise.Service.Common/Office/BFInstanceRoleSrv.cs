using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.BF;
using Enterprise.Model.Basis.Bf;
using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Common.Office;
using Enterprise.Service.Basis.Sys;
using Enterprise.Data.Common.Office;
using Enterprise.Service.Common.Office;

namespace Enterprise.Service.Common
{
	
    /// <summary>
    /// �ļ���:  BFInstanceRoleSrv.cs
    /// ��������: ҵ���߼���-���ڻ�ȡ�����������̵ĸ��ֽ�ɫ�û�
    /// �����ˣ�qw
	/// ����ʱ�� ��2013-2-28
    /// </summary>
    public partial class BFInstanceRoleSrv
    {
        
        #region ��̬��ɫ==ְ���ɫ

        #endregion

        #region ��̬��ɫ

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetOfficeDrafterUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            StringBuilder qcrSB = new StringBuilder();
            SysUserModel user = e.User as SysUserModel;
            qcrSB.Append(string.Format(",{0},", user.USERID));
            return qcrSB.ToString();
        }

        /// <summary>
        /// ���������==������ת�����쵼
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetOfficeAuditorUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            StringBuilder sb = new StringBuilder();
            OfficeDocumentService odService = new OfficeDocumentService();
            OfficeDocumentModel docModel = odService.GetModelById(e.Model.BF_INSTANCEID);
            sb.Append(string.Format(",{0},", docModel.ODCHECKERS));
            return sb.ToString();
        }


        #endregion
    }

}
