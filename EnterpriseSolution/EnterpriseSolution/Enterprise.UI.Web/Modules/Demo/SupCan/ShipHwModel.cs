using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise.UI.Web.Modules.Demo.SupCan
{
    public class ShipHwModel
    {

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 销售日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 接单日期
        /// </summary>
        public DateTime? RequiredDate { get; set; }
        /// <summary>
        /// 货重
        /// </summary>
        public double Freight { get; set; }
        /// <summary>
        /// 船名
        /// </summary>
        public string ShipName { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ShipAddress { get; set; }

    }

}