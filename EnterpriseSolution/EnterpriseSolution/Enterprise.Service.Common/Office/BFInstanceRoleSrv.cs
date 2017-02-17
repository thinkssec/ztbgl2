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
    /// 文件名:  BFInstanceRoleSrv.cs
    /// 功能描述: 业务逻辑层-用于获取公文审批流程的各种角色用户
    /// 创建人：qw
	/// 创建时间 ：2013-2-28
    /// </summary>
    public partial class BFInstanceRoleSrv
    {
        
        #region 静态角色==职务角色

        #endregion

        #region 动态角色

        /// <summary>
        /// 公文起草人
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
        /// 公文审核人==公文流转接收领导
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
