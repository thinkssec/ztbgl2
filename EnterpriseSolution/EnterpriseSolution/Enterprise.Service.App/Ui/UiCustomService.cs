using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Ui;
using Enterprise.Model.App.Ui;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.App.Ui
{
	
    /// <summary>
    /// �ļ���:  UiCustomService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/3 13:48:43
    /// </summary>
    public class UiCustomService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IUiCustomData dal = new UiCustomData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<UiCustomModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<UiCustomModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ��ȡ��ID��Ӧ��Ψһ��¼
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public UiCustomModel GetSingleById(string cId)
        {
            return dal.GetListByHQL("from UiCustomModel c where c.CUSTOMID='" + cId + "'").FirstOrDefault();
        }

	    /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<UiCustomModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(UiCustomModel model)
        {
            return dal.Execute(model);
        }

        #endregion

        /// <summary>
        /// ��ȡһ���û��Ķ��ƽ������
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UiCustomModel GetSingleByUserId(string userId)
        {
            return dal.GetListByHQL("from UiCustomModel where USERID='"+userId+"'").FirstOrDefault();
        }

        /// <summary>
        /// ��ȡһ���û��Ķ��Ƶ�Tab����
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UiTabModel> GetTabsByUserId(string userId)
        {
            IList<UiTabModel> list = new List<UiTabModel>();
            UiTabService uiTabService = new UiTabService();
            UiDefaultService uiDefaultService  = new UiDefaultService();
            string uiCustomContent = "0";
            var q = GetSingleByUserId(userId);
            if (q != null)
            {
                uiCustomContent = q.UICONTENT;
                var userUiTabList = uiTabService.GetListByHQL("from UiTabModel p where p.TABID in (" + ConvertSqlIn(uiCustomContent) + ")");
                if (userUiTabList != null)
                {
                    //���û��趨��˳����ʾ
                    string[] uiTabIds = uiCustomContent.Split(',');
                    foreach (string uiTabId in uiTabIds)
                    {
                        var model = userUiTabList.FirstOrDefault(p => p.TABID == uiTabId);
                        if (model != null)
                        {
                            list.Add(model);
                        }
                    }
                }
            }
            else
            {
                //mod by qw 2014.6.11 ���ݵ�ǰ�û������н�ɫ��ȡ���ж��ƹ��� start
                SysUserRoleService userRoleSrv = new SysUserRoleService();
                var roleList = userRoleSrv.GetListByUserId(userId);
                //���û�ж��ƹ� ����ʾ���û����н�ɫ��Ĭ������
                var uiDefaultLst = uiDefaultService.GetListByRoles(roleList.Select(p => p.ROLEID).ToList<int>());
                StringBuilder uicontSB = new StringBuilder();
                foreach (var uiDefault in uiDefaultLst)
                {
                    uicontSB.Append(uiDefault.UICONTENT + ",");
                }
                list = uiTabService.GetListByHQL("from UiTabModel p where p.TABID in (" + ConvertSqlIn(uicontSB.ToString().TrimEnd(',')) + ")")
                    .OrderBy(p=>p.TABPX).ToList();
                //end
            }

            return list;
        }

        /// <summary>
        /// ��ȡ��ҳTab��ǩ��HTml
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetTabHtml(string userId)
        {
            string html = "";
            var q = GetTabsByUserId(userId);//.OrderBy(s=>s.TABPX);
            foreach (var t in q)
            {
                html += "<div title=\"" + t.TABNAME + "\" style=\"padding: 2px;\" href=\"/Modules/App/Ui/Iframe.aspx?url=" + t.TABURL + "\"></div>";
            }
            return html;
            
        }

        public string ConvertSqlIn(string uiContent)
        {
            string rtn = "";
            if (!string.IsNullOrEmpty(uiContent))
            {
                
                string[] str = uiContent.Split(',');
                foreach (string s in str)
                {
                    rtn += "'" + s + "',";
                }
                rtn = rtn.TrimEnd(',');
            }
            return rtn;
        }
        
    }

}
