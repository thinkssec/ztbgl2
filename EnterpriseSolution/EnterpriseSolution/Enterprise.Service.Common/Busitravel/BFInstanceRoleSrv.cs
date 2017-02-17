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
using Enterprise.Model.Common.Busitravel;
using Enterprise.Service.Basis.Sys;
using Enterprise.Data.Common.Busitravel;

namespace Enterprise.Service.Common
{
	
    /// <summary>
    /// �ļ���:  BFInstanceRoleSrv.cs
    /// ��������: ҵ���߼���-���ڻ�ȡ�����������̵ĸ��ֽ�ɫ�û�
    /// �����ˣ�qw
	/// ����ʱ�� ��2013-2-24
    /// </summary>
    public partial class BFInstanceRoleSrv
    {
        
        #region ��̬��ɫ==ְ���ɫ

        /// <summary>
        /// �ܲ�
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetPresidencyUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            //�ܲ� == ��˾�쵼 ���ⲿ�ŵķֹ��쵼
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(1);
            if (q != null)
            {
                return string.Format(",{0},", q.DHEADERMANAGER);
            }
            return "";
        }


        /// <summary>
        /// ������Դ������
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetHRManagerUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(4);//������Դ��
            if (q != null)
            {
                return string.Format(",{0},", q.DMANAGER);
            }
            return "";
        }

        #endregion

        #region ��̬��ɫ

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetBusitravelSqrUserId(BFNodeEventArgs<BfInstancesModel> e)
        {
            StringBuilder sqrSB = new StringBuilder();
            //SysUserModel user = e.User as SysUserModel;
            sqrSB.Append(string.Format(",{0},", SysUserService.GetUserId(e.Model.BF_FOUNDER)));
            return sqrSB.ToString();
        }

        /// <summary>
        ///  ��ȡ���ž���(�ӹ�˾���ž���)����
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetDeptManager(BFNodeEventArgs<BfInstancesModel> e)
        {
            //��ȡ��ǰ�û����ڵĵ�λ
            int userId = SysUserService.GetUserId(e.Model.BF_FOUNDER);
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(SysUserService.GetUserAffiliationDeptId(userId));
            if (q != null)
            {
                return string.Format(",{0},", q.DMANAGER);
            }
            return "";
        }

        /// <summary>
        /// ��ȡ�ӹ�˾�ܾ������
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetSubcompanyManager(BFNodeEventArgs<BfInstancesModel> e)
        {
            //��ȡ��ǰ�û����ڵĵ�λ
            int userId = SysUserService.GetUserId(e.Model.BF_FOUNDER);
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(SysUserService.GetUserAffiliationDeptId(userId));
            if (q != null)
            {
                //ֻ֧������
                if (q.DPARENTID > 0)
                {
                    //�ӹ�˾�ܾ������Ӳ���
                    var qq = dService.DepartmentDisp(q.DPARENTID);
                    if (qq != null)
                    {
                        return string.Format(",{0},", qq.DMANAGER);
                    }
                }
                else
                {
                    //�ӹ�˾�ܾ������Ӳ���
                    return string.Format(",{0},", q.DMANAGER);
                }
            }
            return "";
        }

        /// <summary>
        /// ��ȡ�ֹ��쵼����
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string GetDeptHeaderManager(BFNodeEventArgs<BfInstancesModel> e)
        {
            //��ȡ��ǰ�û����ڵĵ�λ
            int userId = SysUserService.GetUserId(e.Model.BF_FOUNDER);
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.DepartmentDisp(SysUserService.GetUserAffiliationDeptId(userId));
            if (q != null)
            {
                return string.Format(",{0},", q.DHEADERMANAGER);
            }
            return "";
        }

        #endregion
    }

}
