using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 成员状态
    /// </summary>
    public enum MemberStatus
    {
        在岗 = 0,
        离岗 = 1,
        待岗 = 2
    }

    /// <summary>
    /// 成员性质
    /// </summary>
    public enum MemberProperty
    {
        职工 = 1,
        辅助 = 2
    }
}
