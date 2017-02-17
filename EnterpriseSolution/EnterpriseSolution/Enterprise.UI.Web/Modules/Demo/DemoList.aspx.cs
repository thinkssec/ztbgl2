using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Service.Basis;
using Enterprise.Model.App.Project;
using System.Collections;

namespace Enterprise.UI.Web.Modules.Demo
{
    public partial class DemoList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                BindGrid();
            }
        }

        private void BindGrid()
        {
            //Hack:--Demo GridView事件绑定
            // IList<T> list = xxxxService.GetList(hql)
            //throw new NotImplementedException();


            string[] strs = { "aaaa", "bbb", "ccc"};

            int[] ints = { 1 };
            //ArrayList aaa = new ArrayList(); 

            DemoList d1 = new DemoList();
            DemoList d2 = new DemoList();
            DemoList[] sss = {d1,d2 };


            List<int> list = new List<int>();

            Enterprise.Service.App.Project.ProjectCheckService service = new Service.App.Project.ProjectCheckService();

            //service.GetList().OrderByDescending(s=>).FirstOrDefault();

            
            




        }
    }
}