using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Enterprise.Model.App.Project;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;
using System.Data;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Service.App.Project
{
    public class ZbwjService
    {
        public static string ImageStoragePath = HttpContext.Current.Server.MapPath("~/Modules/Public/Zbwj/").ToString();
        public static string sourcePath = HttpContext.Current.Server.MapPath("~/Modules/Public/Zbwj/Null").ToString();
        private static readonly object obj = new object();
        const string suffix = ".doc";
        public static string zbsqF1 = "招标申请表1";
        public static string zbsqTpF1 = "综合类谈判项目申请表";
        public static string zbsqF2 = "招标申请表2";
        public static string zbsqTpF2 = "物资采购申请表";
        public static string zbsqF3 = "招标申请表3";
        public static string zbsqTpF3 = "工程直接委托申请表";
        public static string lxsqF1 = "招标项目立项审批表1";
        public static string lxsqTpF = "谈判类立项审批表";
        public static string lxsqF2 = "招标项目立项审批表2";
        public static string lxsqF3 = "招标项目立项审批表3";
        public static string tbyqhF = "投标邀请函";
        public static string zbwjlqdjbF = "招标文件领取登记表";
        public static string tbwjlqdjbF = "投标文件接收记录表";
        public static string kbhqdbF = "开标会签到表";
        public static string pbhqdbF = "评标会签到表";
        public static string kbpbgzjlF = "开标评标工作纪律";
        public static string pbwyhxyF = "评标委员会宣言";
        public static string kbrcbsxbF = "投标人唱标顺序表";
        public static string kbjlF = "开标记录";
        public static string pwpfF = "评委评分表";
        public static string pfhzF = "评分汇总表";
        public static string zbwjF = "川气东送管道招标文件";
        public static string pbbgF = "评标报告";
        public static string zbjggsF = "中标结果公示";
        public static string zbjgspbF = "综合类项目招标结果审批表";
        public static string zbtzsF = "中标通知书";
        const string dwmc = "中国石化天然气川气东送管道分公司";

        public enum ZbfsType
        {
            公开招标 = 1,
            邀请招标 = 2
        }

        public static string CreateZbtzs(string projid)
        {
            string rtn = "fail";
            ProjectFwsService fwsrv = new ProjectFwsService();
            ProjectInfoService infSrv = new ProjectInfoService();
            ProjectZbtzsService psSrv = new ProjectZbtzsService();
            ProjectPszjService pszjS = new ProjectPszjService();
            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projid).FirstOrDefault();
            ProjectZbtzsModel tM = psSrv.GetList().FirstOrDefault(w => w.PROJID == projid);
            List<ProjectZjpfModel> pfL = new List<ProjectZjpfModel>();
            string sql = string.Format(@"select *
              from (select avg(pf) pf, crminfo
                      from (select sum(pf) pf, crminfo, submitter
                              from APP_PROJECT_ZJPF t
                             where projid = '{0}'
                             group by submitter, crminfo)
                     group by crminfo)
             order by pf desc", projid);
            DataSet ds = infSrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ProjectZjpfModel p = new ProjectZjpfModel();
                p.CRMINFO = r["CRMINFO"].ToRequestString();
                p.PF = r["PF"].ToDecimal();
                pfL.Add(p);
            }

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (pfL != null && pfL.Count > 0)
                datas.Add("{param.001}", CrmInfoService.GetCrmName(pfL.First().CRMINFO));
            datas.Add("{param.002}", inM.PROJNAME);

            if (tM.P1.Length > 200)
            {
                datas.Add("{param.003}", tM.P1.Substring(0, 200));
                datas.Add("{param.003.1}", tM.P1.Substring(200, tM.P1.Length - 200));
            }
            else
            {
                datas.Add("{param.003}", tM.P1);
                datas.Add("{param.003.1}", "");
            }
            //datas.Add("{param.003}", tM.P1);

            rtn = ReplaceToWord(zbtzsF, projid, datas);
            return rtn;
        }
        public static string CreateZbjgspb(string projid)
        {
            string rtn = "fail";
            ProjectFwsService fwsrv = new ProjectFwsService();
            ProjectInfoService infSrv = new ProjectInfoService();
            ProjectZbjgspbService psSrv = new ProjectZbjgspbService();
            ProjectPszjService pszjS = new ProjectPszjService();
            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projid).FirstOrDefault();
            ProjectZbjgspbModel tM = psSrv.GetList().FirstOrDefault(w => w.PROJID == projid);
            List<ProjectZjpfModel> pfL = new List<ProjectZjpfModel>();
            string sql = string.Format(@"select *
              from (select avg(pf) pf, crminfo
                      from (select sum(pf) pf, crminfo, submitter
                              from APP_PROJECT_ZJPF t
                             where projid = '{0}'
                             group by submitter, crminfo)
                     group by crminfo)
             order by pf desc", projid);
            DataSet ds = infSrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ProjectZjpfModel p = new ProjectZjpfModel();
                p.CRMINFO = r["CRMINFO"].ToRequestString();
                p.PF = r["PF"].ToDecimal();
                pfL.Add(p);
            }

            Dictionary<string, string> datas = new Dictionary<string, string>();
            datas.Add("{param.001}", inM.PROJNAME);
            datas.Add("{param.002}", inM.PROJNUMBER);
            if (inM.PROJINCOME == null || inM.PROJINCOME <= 0)
                datas.Add("{param.004}","据实结算");
            else 
                datas.Add("{param.004}", inM.PROJINCOME.ToRequestString());
            if (tM.P1.Length > 200)
            {
                datas.Add("{param.005}", tM.P1.Substring(0, 200));
                datas.Add("{param.005.1}", tM.P1.Substring(200, tM.P1.Length - 200));
            }
            else
            {
                datas.Add("{param.005}", tM.P1);
                datas.Add("{param.005.1}", "");
            }
            //datas.Add("{param.005}", tM.P1);
            datas.Add("{param.006}", inM.NKBSJ.ToRequestString());
            datas.Add("{param.007}", inM.NKBDD);


            for (int i = 1; i <= 6; i++)
            {
                ProjectZjpfModel m = null;
                if (pfL.Count >= i)
                    m = pfL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.dw" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.dw" + i + "}", CrmInfoService.GetCrmName(m.CRMINFO));
                }
            }

            rtn = ReplaceToWord(zbjgspbF, projid, datas);
            return rtn;
        }
        public static string CreateZbjggs(string projid)
        {
            string rtn = "fail";
            ProjectFwsService fwsrv = new ProjectFwsService();
            ProjectInfoService infSrv = new ProjectInfoService();
            ProjectJbjggsService psSrv = new ProjectJbjggsService();
            ProjectPszjService pszjS = new ProjectPszjService();
            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projid).FirstOrDefault();
            ProjectJbjggsModel tM = psSrv.GetList().FirstOrDefault(w => w.PROJID == projid);
            List<ProjectZjpfModel> pfL = new List<ProjectZjpfModel>();
            string sql = string.Format(@"select *
              from (select avg(pf) pf, crminfo
                      from (select sum(pf) pf, crminfo, submitter
                              from APP_PROJECT_ZJPF t
                             where projid = '{0}'
                             group by submitter, crminfo)
                     group by crminfo)
             order by pf desc", projid);
            DataSet ds = infSrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ProjectZjpfModel p = new ProjectZjpfModel();
                p.CRMINFO = r["CRMINFO"].ToRequestString();
                p.PF = r["PF"].ToDecimal();
                pfL.Add(p);
            }

            Dictionary<string, string> datas = new Dictionary<string, string>();



            datas.Add("{param.001}", inM.PROJNAME);
            datas.Add("{param.002}", inM.PROJNUMBER);
            if (inM.PROJINCOME == null || inM.PROJINCOME <= 0)
                datas.Add("{param.004}", "据实结算");
            else
                datas.Add("{param.004}", inM.PROJINCOME.ToRequestString());

            if (tM.P1.Length > 200)
            {
                datas.Add("{param.nr}", tM.P1.Substring(0, 200));
                datas.Add("{param.nr.1}", tM.P1.Substring(200, tM.P1.Length - 200));
            }
            else
            {
                datas.Add("{param.nr}", tM.P1);
                datas.Add("{param.nr.1}", "");
            }
            //datas.Add("{param.nr}", tM.P1);
            datas.Add("{param.005}", inM.NKBSJ.ToRequestString());
            datas.Add("{param.006}", inM.NKBDD);
            datas.Add("{param.sj1}",tM.P2);
            datas.Add("{param.sj2}", tM.P3);
         

            for (int i = 1; i <= 6; i++)
            {
                ProjectZjpfModel m = null;
                if (pfL.Count >= i)
                    m = pfL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.dw" + i + "}", "");
                    datas.Add("{param.fs" + i + "}", "");
                    datas.Add("{param.pm" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.dw" + i + "}", CrmInfoService.GetCrmName(m.CRMINFO));
                    datas.Add("{param.fs" + i + "}", m.PF + "");
                    datas.Add("{param.pm" + i + "}", i+"");
                }
            }

            rtn = ReplaceToWord(zbjggsF, projid, datas);
            return rtn;
        }
        public static string CreatePbbg(string projid)
        {
            string rtn = "fail";
            ProjectFwsService fwsrv = new ProjectFwsService();
            ProjectInfoService infSrv = new ProjectInfoService();
            ProjectPbbgService psSrv = new ProjectPbbgService();
            ProjectPszjService pszjS = new ProjectPszjService();
            List<ProjectFwsModel> fwsL = fwsrv.GetList().Where(w => w.PROJID == projid && w.STATUS != -2).ToList();
            ProjectInfoModel inM = infSrv.GetList().Where(w => w.PROJID == projid).FirstOrDefault();
            ProjectPbbgModel tM = psSrv.GetList().FirstOrDefault(w => w.PROJID == projid);
            List<ProjectZjpfModel> pfL = new List<ProjectZjpfModel>();
            string sql = string.Format(@"select *
              from (select avg(pf) pf, crminfo
                      from (select sum(pf) pf, crminfo, submitter
                              from APP_PROJECT_ZJPF t
                             where projid = '{0}'
                             group by submitter, crminfo)
                     group by crminfo)
             order by pf desc", projid);
            DataSet ds = infSrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ProjectZjpfModel p = new ProjectZjpfModel();
                p.CRMINFO = r["CRMINFO"].ToRequestString();
                p.PF = r["PF"].ToDecimal();
                pfL.Add(p);
            }

            ProjectPszjModel zr = new ProjectPszjModel();
            zr = pszjS.GetList().FirstOrDefault(w => w.PROJID == projid && w.ROLE == "1");
            List<ProjectPszjModel> wyL = pszjS.GetList().Where(w => w.PROJID == projid && w.LB <= 3 && w.ROLE != "1").ToList();

            Dictionary<string, string> datas = new Dictionary<string, string>();



            datas.Add("{param.001}", inM.PROJNAME);
            if(zr!=null)
            datas.Add("{param.002}", SysUserService.GetUserName( zr.PERSONID.ToInt()));

            if (wyL != null) {
                string s="";
                foreach(var m in wyL){
                    s+=SysUserService.GetUserName( m.PERSONID.ToInt())+";";
                }
                datas.Add("{param.003}", s);
            }

            datas.Add("{param.004}", inM.NKBDD);
            datas.Add("{param.005}", inM.NKBSJ.ToRequestString());
            datas.Add("{param.006}", tM.P1);
            datas.Add("{param.007}", tM.P2);
            datas.Add("{param.008}", tM.P3);
            datas.Add("{param.010}", tM.P4);
            datas.Add("{param.009}", CrmInfoService.GetCrmName(pfL.First().CRMINFO));
            
            for (int i = 1; i <= 6; i++)
            {
                ProjectFwsModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbr" + i + "}", "");
                    datas.Add("{param.fh" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbr" + i + "}", CrmInfoService.GetCrmName(m.CRMINFO));
                    datas.Add("{param.fh" + i + "}", "符合/不符合");
                }
            }

            for (int i = 1; i <= 6; i++)
            {
                ProjectZjpfModel m = null;
                if (pfL.Count >= i)
                    m = pfL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.fws" + i + "}", "");
                    datas.Add("{param.zh" + i + "}", "");
                    datas.Add("{param.df" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.fws" + i + "}", CrmInfoService.GetCrmName(m.CRMINFO));
                    datas.Add("{param.zh" + i + "}", "综合分数");
                    datas.Add("{param.df" + i + "}", m.PF+"");
                }
            }

            rtn = ReplaceToWord(pbbgF, projid, datas);
            return rtn;
        }

        public static string CreateZbwj(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            ProjectPfbzService pfsrv = new ProjectPfbzService();
            ProjectZbwjService zbsrv = new ProjectZbwjService();
            List<ProjectPfbzModel> jsL = pfsrv.GetList().Where(w=>w.PROJID==projid&&w.XMMC=="技术部分").OrderBy(o=>o.XH).ToList();
            List<ProjectPfbzModel> swL = pfsrv.GetList().Where(w => w.PROJID == projid && w.XMMC == "商务部分").OrderBy(o => o.XH).ToList();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            ProjectZbwjModel z = zbsrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", z.P9);
            datas.Add("{param.003}", "    ");
            datas.Add("{param.004}", z.P1);

            if (z.P8.Length > 200)
            {
                datas.Add("{param.content}", z.P8.Substring(0, 200));
                datas.Add("{param.content.1}", z.P8.Substring(200, z.P8.Length - 200));
            }
            else
            {
                datas.Add("{param.content}", z.P8);
                datas.Add("{param.content.1}", "");
            }
            //datas.Add("{param.content}", z.P8);
            datas.Add("{param.cqjzrq}", z.P2);
            datas.Add("{param.005}", z.P3);
            datas.Add("{param.tbjzrq}", p.NKBSJ.ToRequestString());
            datas.Add("{param.zjly}", p.ZJLY);
            datas.Add("{param.shi}", p.NKBDD);
            datas.Add("{param.yxq}", z.P4);
            datas.Add("{param.bzj}", z.P5);
            datas.Add("{param.007}", z.P6);
            datas.Add("{param.008}", z.P7);
            datas.Add("{param.Z1}", z.Z1);
            datas.Add("{param.Z2}", z.Z2);
            datas.Add("{param.Z3}", z.Z3);
            datas.Add("{param.Z4}", z.Z4);
            datas.Add("{param.Z5}", z.Z5);
            datas.Add("{param.Z6}", z.Z6);

            datas.Add("{param.jsf}", jsL.Sum(s=>s.FZ)+"");
            datas.Add("{param.swf}", swL.Sum(s => s.FZ) + "");
            for (int i = 1; i <= 15; i++)
            {
                ProjectPfbzModel m = null;
                if (jsL.Count >= i)
                    m = jsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.js" + i + "}", "");
                    datas.Add("{param.jsf" + i + "}", "");
                    datas.Add("{param.jsbz" + i + "}", "");
                    datas.Add("{param.jsbz" + i + ".1}", "");
                }
                else
                {
                    datas.Add("{param.js" + i + "}", m.PBFX);
                    datas.Add("{param.jsf" + i + "}", m.FZ+"");
                    if (m.PFBZ.Length > 200)
                    {
                        datas.Add("{param.jsbz" + i + "}", m.PFBZ.Substring(0, 200));
                        datas.Add("{param.jsbz" + i + ".1}", m.PFBZ.Substring(200, m.PFBZ.Length-200));
                    }
                    else {
                        datas.Add("{param.jsbz" + i + "}", m.PFBZ);
                        datas.Add("{param.jsbz" + i + ".1}", "");
                    }
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                ProjectPfbzModel m = null;
                if (swL.Count >= i)
                    m = swL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.sw" + i + "}", "");
                    datas.Add("{param.swf" + i + "}", "");
                    datas.Add("{param.swbz" + i + "}", "");
                    datas.Add("{param.swbz" + i + ".1}", "");
                }
                else
                {
                    datas.Add("{param.sw" + i + "}", m.PBFX);
                    datas.Add("{param.swf" + i + "}", m.FZ + "");
                    if (m.PFBZ.Length > 200)
                    {
                        datas.Add("{param.swbz" + i + "}", m.PFBZ.Substring(0, 200));
                        datas.Add("{param.swbz" + i + ".1}", m.PFBZ.Substring(200, m.PFBZ.Length-200));
                    }
                    else {
                        datas.Add("{param.swbz" + i + "}", m.PFBZ);
                        datas.Add("{param.swbz" + i + ".1}","");
                    }
                }
            }

            rtn = ReplaceToWord(zbwjF, projid, datas);
            return rtn;
        }
        public static string CreateZbwj2(string projid,string bh) {
            string rtn = "";
            Dictionary<string, string> datas = new Dictionary<string, string>();
            datas.Add("XXXX",bh);
            rtn = ReplaceToWord5(zbwjF, projid, datas);
            return rtn;
        }
        public static string CreatePfhz(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            ProjectFwsService fsrv = new ProjectFwsService();
            ProjectPszjService zjSrv = new ProjectPszjService();
            ProjectZjpfService zjpfsrv = new ProjectZjpfService();

            List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();

            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            List<ProjectPszjModel> zjL = zjSrv.GetList().Where(w => w.PROJID == projid && w.LB <= 3).OrderBy(o => o.LB).OrderBy(o => o.ROLE).ToList();
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
            string sql = "";
            if(zjL.Count!=5&&zjL.Count!=7&&zjL.Count!=9)
                return rtn;
            sql = string.Format(@"select *
                                          from (select sum(pf) pf, crminfo, submitter
                                                  from APP_PROJECT_ZJPF
                                                 where projid = '{0}'
                                                 group by crminfo, submitter
                                                union all
                                                select round(avg(pf),1) pj, crminfo, 20000 submitter
                                                  from (select sum(pf) pf, crminfo, submitter
                                                          from APP_PROJECT_ZJPF
                                                         where projid = '{0}'
                                                         group by crminfo, submitter)
                                                 group by crminfo
                                                union all
                                                select rank() over(order by pf desc) pf,
                                                       crminfo,
                                                       10000 submitter
                                                  from (select sum(pf) pf, crminfo, null submitter
                                                          from APP_PROJECT_ZJPF
                                                         where projid = '{0}'
                                                         group by crminfo))", projid);
            DataSet ds = psrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                dic.Add(r["SUBMITTER"].ToRequestString() + r["CRMINFO"].ToRequestString(), r["PF"].ToDecimal());
            }


            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            sql = @"select b.crmname projid,a.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2 order by a.px";
            fwsL = fsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            int js = 1;
            //foreach (var m in fwsL)
            //{
            //    datas.Add("{param.tbr" + js + "}", CrmInfoService.GetCrmName( m.CRMINFO));
            //    js++;
            //}
            for (int i = fwsL.Count + 1; i <= 6; i++)
            {
                datas.Add("{param.tbr" + i + "}", "");
                datas.Add("{param.df" + i + "}", "");
                datas.Add("{param.mc" + i + "}", "");
                for (int j = 1; j <= zjL.Count; j++)
                    datas.Add("{param" + j + ".pf" + i + "}", "");

            }
            int ii = 1;
            foreach (var d in fwsL)
            {
                datas.Add("{param.tbr" + ii + "}", CrmInfoService.GetCrmName(d.CRMINFO));
                datas.Add("{param.df" + ii + "}", dic.ContainsKey("20000" + d.CRMINFO) ? dic["20000" + d.CRMINFO] + "" : "");
                datas.Add("{param.mc" + ii + "}", dic.ContainsKey("10000" + d.CRMINFO) ? dic["10000" + d.CRMINFO] + "" : "");
                int j = 1;

                foreach (var m in zjL)
                {
                    if (dic.ContainsKey(m.PERSONID + d.CRMINFO))
                    {
                        datas.Add("{param" + j + ".pf" + ii + "}", dic[m.PERSONID + d.CRMINFO] + "");
                    }
                    else
                        datas.Add("{param" + j + ".pf" + ii + "}", 0 + "");
                    j++;
                }

                ii++;
            }
            ii = 1;
            Dictionary<string, string> pics = new Dictionary<string, string>();
            //Dictionary<string, string> pics2 = new Dictionary<string, string>();
            SysUserindividService individSrv = new SysUserindividService();
            SysUserindividModel userIndivid = null;
            foreach (var m in zjL)
            {

                datas.Add("{param.pw" + ii + "}", SysUserService.GetUserName(m.PERSONID.ToInt()));
                userIndivid = individSrv.GetModelById(m.PERSONID.ToInt());
                //pics.Add("{param.qm" + ii + "}", sourcePath + "/photo.jpg");
                if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
                {
                    pics.Add("{param.qm" + ii + "}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
                }
                else {
                    pics.Add("{param.qm" + ii + "}", sourcePath + "/null.jpg");
                }
                ii++;
            }



            //pics2.Add("{param.qm}", sourcePath + "/pht.png");
            pics.Add("{param.qm}", sourcePath + "/null.jpg");
            rtn = ReplaceToWordPic(pfhzF + zjL.Count, projid, datas, pics);
            return rtn;
        }

        public static string CreateZjpf(string projid, int userid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            ProjectFwsService fsrv = new ProjectFwsService();
            ProjectPfbzService pfbzsrv = new ProjectPfbzService();
            ProjectZjpfService zjpfsrv = new ProjectZjpfService();

            List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();

            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            List<ProjectPfbzModel> pfbzL = pfbzsrv.GetList().Where(w => w.PROJID == projid).OrderBy(o => o.XH).OrderBy(o => o.XMMC).ToList();
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
            string sql = "";

            sql = string.Format(@"select sum(pf) pf,bzid,crminfo from APP_PROJECT_ZJPF where projid='{0}' and submitter={1} group by crminfo,bzid", projid, userid);
            DataSet ds = psrv.getDsBySql(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                dic.Add(r["BZID"].ToRequestString() + r["CRMINFO"].ToRequestString(), r["PF"].ToDecimal());
            }


            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            sql = @"select b.crmname projid,a.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2 order by a.px";
            fwsL = fsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            int js = 1;
            foreach (var m in pfbzL)
            {
                datas.Add("{param.x" + js + "}", m.XMMC);
                datas.Add("{param.y" + js + "}", m.PBFX);
                datas.Add("{param.z" + js + "}", m.FZ + "");
                datas.Add("{param.w" + js + "}", m.PFBZ + "");
                js++;
            }
            int i = 1;
            foreach (var d in fwsL)
            {
                datas.Add("{param.tbr" + i + "}", d.PROJID);
                int j = 1;
                decimal tj = 0;
                foreach (var m in pfbzL)
                {
                    if (dic.ContainsKey(m.BZID + d.CRMINFO))
                    {
                        tj += dic[m.BZID + d.CRMINFO];
                        datas.Add("{param" + i + ".pf" + j + "}", dic[m.BZID + d.CRMINFO] + "");
                    }
                    else
                        datas.Add("{param" + i + ".pf" + j + "}", 0 + "");
                    j++;
                }
                datas.Add("{param" + i + ".hj}", tj + "");
                i++;
            }
            for (i = pfbzL.Count + 1; i <= 20; i++)
            {
                datas.Add("{param.x" + i + "}", "");
                datas.Add("{param.y" + i + "}", "");
                datas.Add("{param.z" + i + "}", "");
                datas.Add("{param.w" + i + "}", "");
                datas.Add("{param1.pf" + i + "}", "");
                datas.Add("{param2.pf" + i + "}", "");
                datas.Add("{param3.pf" + i + "}", "");
                datas.Add("{param4.pf" + i + "}", "");
                datas.Add("{param5.pf" + i + "}", "");
                datas.Add("{param6.pf" + i + "}", "");
            }

            Dictionary<string, string> pics = new Dictionary<string, string>();
            SysUserindividService individSrv = new SysUserindividService();
            SysUserindividModel userIndivid = null;
            userIndivid = individSrv.GetModelById(userid);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.qm}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                pics.Add("{param.qm}", sourcePath + "/null.jpg");
            }
            //pics.Add("{param.qm}", sourcePath + "/photo.jpg");
            rtn = ReplaceToWordPicDel(pwpfF + fwsL.Count, projid, userid, datas, pics, pfbzL.Count);
            //rtn = ReplaceToWordPic(pwpfF + fwsL.Count, projid, datas, pics);
            return rtn;
        }
        //招标申请文件
        public static string CreateZbsq1(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            datas.Add("{param.004}", p.NKBDD);
            datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                    datas.Add("{param.rw" + i + "}", "");
                    datas.Add("{param.sw" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", m.CRMNAME);
                    datas.Add("{param.rw" + i + "}", m.SHUIH);
                    datas.Add("{param.sw" + i + "}", m.ZHANGH);
                }
            }
            rtn = ReplaceToWord(zbsqF1, projid, datas);
            return rtn;
        }
        public static string CreateZbsqTp1(string projid)
        {
            string rtn = "fail";
            ProjectTpinfoService psrv = new ProjectTpinfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectTpinfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            //datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.ZJLY == "成本") datas.Add("{param.tzcw}", "财务");
            else datas.Add("{param.tzcw}", "投资");
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            //datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            datas.Add("{param.004}", p.NKBDD);
            //datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            //datas.Add("{param.006}", p.PHONE);
            //if (p.PROJCONTENT.Length > 200)
            //{
            //    datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
            //    datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            //}
            //else
            //{
            //    datas.Add("{param.007}", p.PROJCONTENT);
            //    datas.Add("{param.007.1}", "");
            //}

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", i + "." + m.CRMNAME);
                }
            }
            if (p.SQLY.Length > 200)
            {
                datas.Add("{param.shyj}", p.SQLY.Substring(0, 200));
                datas.Add("{param.shyj.1}", p.SQLY.Substring(200, p.SQLY.Length - 200));
            }
            else
            {
                datas.Add("{param.shyj}", p.SQLY);
                datas.Add("{param.shyj.1}", "");
            }

            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            
            rtn = ReplaceToWord(zbsqTpF1, projid, datas);
            return rtn;
        }
        public static string CreateZbsq2(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.004}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            datas.Add("{param.004}", p.NKBDD);
            datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                    datas.Add("{param.rw" + i + "}", "");
                    datas.Add("{param.sw" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", m.CRMNAME);
                    datas.Add("{param.rw" + i + "}", m.SHUIH);
                    datas.Add("{param.sw" + i + "}", m.ZHANGH);
                }
            }
            rtn = ReplaceToWord(zbsqF2, projid, datas);
            return rtn;
        }

        public static string CreateZbsqTp2(string projid)
        {
            string rtn = "fail";
            ProjectTpinfoService psrv = new ProjectTpinfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectTpinfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            //datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
            datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            //datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            datas.Add("{param.004}", p.NKBDD);
            //datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            //datas.Add("{param.006}", p.PHONE);
            //if (p.PROJCONTENT.Length > 200)
            //{
            //    datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
            //    datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            //}
            //else
            //{
            //    datas.Add("{param.007}", p.PROJCONTENT);
            //    datas.Add("{param.007.1}", "");
            //}
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            //for (int i = 1; i <= 8; i++)
            //{
            //    CrmInfoModel m = null;
            //    if (fwsL.Count >= i)
            //        m = fwsL[i - 1];
            //    if (m == null)
            //    {
            //        datas.Add("{param.tbf" + i + "}", "");
            //        datas.Add("{param.rw" + i + "}", "");
            //        datas.Add("{param.sw" + i + "}", "");
            //    }
            //    else
            //    {
            //        datas.Add("{param.tbf" + i + "}", m.CRMNAME);
            //        datas.Add("{param.rw" + i + "}", m.SHUIH);
            //        datas.Add("{param.sw" + i + "}", m.ZHANGH);
            //    }
            //}
            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", i + "." + m.CRMNAME);
                }
            }
            if (p.SQLY.Length > 200)
            {
                datas.Add("{param.shyj}", p.SQLY.Substring(0, 200));
                datas.Add("{param.shyj.1}", p.SQLY.Substring(200, p.SQLY.Length - 200));
            }
            else
            {
                datas.Add("{param.shyj}", p.SQLY);
                datas.Add("{param.shyj.1}", "");
            }
            rtn = ReplaceToWord(zbsqTpF2, projid, datas);
            return rtn;
        }

        public static string CreateZbsq3(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            datas.Add("{param.004}", p.NKBDD);
            datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                    datas.Add("{param.xh" + i + "}", "");
                    datas.Add("{param.bh" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", m.CRMNAME);
                    datas.Add("{param.xh" + i + "}", i+"");
                    datas.Add("{param.bh" + i + "}", m.ZSBH);
                }
            }
            rtn = ReplaceToWord(zbsqF3, projid, datas);
            return rtn;
        }

        public static string CreateZbsqTp3(string projid)
        {
            string rtn = "fail";
            ProjectTpinfoService psrv = new ProjectTpinfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectTpinfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            //datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            //datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            //datas.Add("{param.004}", p.NKBDD);
            datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT != null && p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }
            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", i + "." + m.CRMNAME);
                }
            }
            rtn = ReplaceToWord(zbsqTpF3, projid, datas);
            return rtn;
        }

        public static string CreateLxsqty(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            datas.Add("{param.nyr}", p.SUBMITDATE.ToDateYMDFormat());
            datas.Add("{param.000}", Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName(p.DEPTID.Value));
            //datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            datas.Add("{param.004}", p.NKBDD);
            datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                    //datas.Add("{param.xh" + i + "}", "");
                    //datas.Add("{param.bh" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", i + "." + m.CRMNAME);
                    //datas.Add("{param.xh" + i + "}", i + "");
                    //datas.Add("{param.bh" + i + "}", m.ZSBH);
                }
            }
            //if (p.SQLY.Length > 200)
            //{
            //    datas.Add("{param.shyj}", p.SQLY.Substring(0, 200));
            //    datas.Add("{param.shyj.1}", p.SQLY.Substring(200, p.SQLY.Length - 200));
            //}
            //else
            //{
            //    datas.Add("{param.shyj}", p.SQLY);
            //    datas.Add("{param.shyj.1}", "");
            //}
            //datas.Add("{param.shyj}", p.SQLY);
            datas.Add("{param.spyj2}", string.IsNullOrEmpty(p.SPYJ2) ? "同意" : p.SPYJ2);
            if (p.ZJLY == "成本")
            {
                datas.Add("{param.spyj31}", string.IsNullOrEmpty(p.SPYJ3) ? "同意" : p.SPYJ3);
                datas.Add("{param.spyj3}", "");
            }
            else {
                datas.Add("{param.spyj3}", string.IsNullOrEmpty(p.SPYJ3) ? "同意" : p.SPYJ3);
                datas.Add("{param.spyj31}", "");
            }
            datas.Add("{param.spyj4}", string.IsNullOrEmpty(p.SPYJ4) ? "同意" : p.SPYJ4);
            datas.Add("{param.spyj5}", string.IsNullOrEmpty(p.SPYJ5) ? "同意" : p.SPYJ5);
            Dictionary<String, String> pics = new Dictionary<string, string>();
            SysUserindividService individSrv = new SysUserindividService();
            SysUserindividModel userIndivid = null;
            userIndivid = individSrv.GetModelById(p.SHR.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.shr}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.shr}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR2.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr2}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.spr2}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR3.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                if (p.ZJLY == "成本")
                {
                    pics.Add("{param.spr31}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
                    datas.Add("{param.spr3}", "");
                }
                else {
                    pics.Add("{param.spr3}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
                    datas.Add("{param.spr31}", "");
                }
            }
            else
            {
                datas.Add("{param.spr3}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR4.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr4}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.spr4}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR5.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr5}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {

                datas.Add("{param.spr5}", "");
            }
            string d11 = "项目立项审批表3"+p.ZBFS;
            rtn = ReplaceToWordPic(d11, projid, datas, pics);
            //if (1 == p.KINDID)
            //    rtn = ReplaceToWordPic(lxsqF1, projid, datas, pics);
            //if (2 == p.KINDID)
            //    rtn = ReplaceToWordPic(lxsqF2, projid, datas, pics);
            //if (3 == p.KINDID)
            //    rtn = ReplaceToWordPic(lxsqF3, projid, datas, pics);
            return rtn;
        }

        public static string CreateLxsq(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            datas.Add("{param.nyr}", p.SUBMITDATE.ToDateYMDFormat());
            datas.Add("{param.000}", Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName(p.DEPTID.Value));
            //datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            //datas.Add("{param.004}", p.NKBDD);
            //datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            //datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                    //datas.Add("{param.xh" + i + "}", "");
                    //datas.Add("{param.bh" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}",i+"."+ m.CRMNAME);
                    //datas.Add("{param.xh" + i + "}", i + "");
                    //datas.Add("{param.bh" + i + "}", m.ZSBH);
                }
            }
            if (p.SQLY.Length > 200)
            {
                datas.Add("{param.shyj}", p.SQLY.Substring(0, 200));
                datas.Add("{param.shyj.1}", p.SQLY.Substring(200, p.SQLY.Length - 200));
            }
            else
            {
                datas.Add("{param.shyj}", p.SQLY);
                datas.Add("{param.shyj.1}", "");
            }
            //datas.Add("{param.shyj}", p.SQLY);
            datas.Add("{param.spyj2}", string.IsNullOrEmpty(p.SPYJ2) ? "同意":  p.SPYJ2);
            datas.Add("{param.spyj3}", string.IsNullOrEmpty(p.SPYJ3) ? "同意" : p.SPYJ3);
            datas.Add("{param.spyj4}", string.IsNullOrEmpty(p.SPYJ4) ? "同意" : p.SPYJ4);
            datas.Add("{param.spyj5}", string.IsNullOrEmpty(p.SPYJ5) ? "同意" : p.SPYJ5);
            Dictionary<String, String> pics = new Dictionary<string, string>();
            SysUserindividService individSrv = new SysUserindividService();
            SysUserindividModel userIndivid = null;
            userIndivid=individSrv.GetModelById(p.SHR.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.shr}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else {
                datas.Add("{param.shr}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR2.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr2}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else {
                datas.Add("{param.spr2}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR3.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr3}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else {
                datas.Add("{param.spr3}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR4.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr4}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else {
                datas.Add("{param.spr4}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR5.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr5}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else {

                datas.Add("{param.spr5}", "");
            }
            
            if(1==p.KINDID)
                rtn = ReplaceToWordPic(lxsqF1, projid, datas,pics);
            if (2 == p.KINDID)
                rtn = ReplaceToWordPic(lxsqF2, projid, datas,pics);
            if (3 == p.KINDID)
                rtn = ReplaceToWordPic(lxsqF3, projid, datas,pics);
            return rtn;
        }

        public static string CreateLxsqTp(string projid)
        {
            string rtn = "fail";
            ProjectTpinfoService psrv = new ProjectTpinfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectTpinfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            //datas.Add("{param.000}", dwmc);
            datas.Add("{param.001}", p.PROJNAME);
            //datas.Add("{param.01}", p.ZBFS == 1 ? "公开招标" : "邀请招标");
            datas.Add("{param.11}", p.ZJLY);
            if (p.ZJLY == "成本") datas.Add("{param.tzcw}", "财务");
            else datas.Add("{param.tzcw}", "投资");
            datas.Add("{param.jbr}",SysUserService.GetUserName( p.SUBMITTER.ToInt()));
            if (p.PROJINCOME == null || p.PROJINCOME <= 0)
                datas.Add("{param.002}", "据实结算");
            else
                datas.Add("{param.002}", p.PROJINCOME.ToRequestString());
            //datas.Add("{param.nyr}", p.SUBMITDATE.ToDateYMDFormat());
            //datas.Add("{param.000}", Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName(p.DEPTID.Value));
            //datas.Add("{param.003}", p.NKBSJSTR.ToRequestString());
            //datas.Add("{param.004}", p.NKBDD);
            //datas.Add("{param.005}", SysUserService.GetUserName(p.SUBMITTER.Value));
            //datas.Add("{param.006}", p.PHONE);
            if (p.PROJCONTENT!=null&&p.PROJCONTENT.Length > 200)
            {
                datas.Add("{param.007}", p.PROJCONTENT.Substring(0, 200));
                datas.Add("{param.007.1}", p.PROJCONTENT.Substring(200, p.PROJCONTENT.Length - 200));
            }
            else
            {
                datas.Add("{param.007}", p.PROJCONTENT);
                datas.Add("{param.007.1}", "");
            }

            if (p.SQLY.Length > 200)
            {
                datas.Add("{param.shyj}", p.SQLY.Substring(0, 200));
                datas.Add("{param.shyj.1}", p.SQLY.Substring(200, p.SQLY.Length - 200));
            }
            else
            {
                datas.Add("{param.shyj}", p.SQLY);
                datas.Add("{param.shyj.1}", "");
            }
            //datas.Add("{param.007}", p.PROJCONTENT);
            //datas.Add("{param.008}", SysUserService.GetUserName(p.SHR.Value));

            for (int i = 1; i <= 8; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.tbf" + i + "}", "");
                    //datas.Add("{param.xh" + i + "}", "");
                    //datas.Add("{param.bh" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.tbf" + i + "}", i + "." + m.CRMNAME);
                    //datas.Add("{param.xh" + i + "}", i + "");
                    //datas.Add("{param.bh" + i + "}", m.ZSBH);
                }
            }
            
            datas.Add("{param.spyj2}", string.IsNullOrEmpty(p.SPYJ2) ? "同意" : p.SPYJ2);
            datas.Add("{param.spyj3}", string.IsNullOrEmpty(p.SPYJ3) ? "同意" : p.SPYJ3);
            datas.Add("{param.spyj4}", string.IsNullOrEmpty(p.SPYJ4) ? "同意" : p.SPYJ4);
            datas.Add("{param.spyj5}", string.IsNullOrEmpty(p.SPYJ5) ? "同意" : p.SPYJ5);
            Dictionary<String, String> pics = new Dictionary<string, string>();
            SysUserindividService individSrv = new SysUserindividService();
            SysUserindividModel userIndivid = null;
            userIndivid = individSrv.GetModelById(p.SHR.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.shr}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.shr}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR2.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr2}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.spr2}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR3.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr3}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.spr3}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR4.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr4}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {
                datas.Add("{param.spr4}", "");
            }
            userIndivid = individSrv.GetModelById(p.SPR5.Value);
            if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
            {
                pics.Add("{param.spr5}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
            }
            else
            {

                datas.Add("{param.spr5}", "");
            }

            rtn = ReplaceToWordPic(lxsqTpF, projid, datas, pics);
            return rtn;
        }

        public static string CreateZbwjlqdjb(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            ProjectZbwjlqdjbService zsrv = new ProjectZbwjlqdjbService();
            ProjectZbwjlqdjbModel zm = zsrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", SysUserService.GetUserName(p.SUBMITTER.Value));
            datas.Add("{param.004}", zm.LQDD);
            for (int i = 1; i <= 7; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.x" + i + "}", "");
                    datas.Add("{param.zbr" + i + "}", "");
                    datas.Add("{param.sj" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.x" + i + "}", i + "");
                    datas.Add("{param.zbr" + i + "}", m.CRMNAME);
                    datas.Add("{param.sj" + i + "}", "年   月   日   时");
                }
            }
            rtn = ReplaceToWord(zbwjlqdjbF, projid, datas);
            return rtn;
        }
        public static string CreateKbjl(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            ProjectFwsService crmsrv = new ProjectFwsService();
            List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.crmname crminfo,a.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2 order by a.px";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            for (int i = 1; i <= 10; i++)
            {
                ProjectFwsModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    //datas.Add("{param.x" + i + "}", "");
                    datas.Add("{param.tbr" + i + "}", "");
                    datas.Add("{param.xh" + i + "}", "");

                }
                else
                {
                    //datas.Add("{param.x" + i + "}", i + "");
                    datas.Add("{param.tbr" + i + "}", m.CRMINFO);
                    datas.Add("{param.xh" + i + "}", m.PX + "");

                }
            }
            rtn = ReplaceToWord(kbjlF + fwsL.Count, projid, datas);
            return rtn;
        }

        public static string CreateTbrcbsxb(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            ProjectFwsService crmsrv = new ProjectFwsService();
            List<ProjectFwsModel> fwsL = new List<ProjectFwsModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.crmname crminfo,a.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2 order by a.crminfo";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            for (int i = 1; i <= 10; i++)
            {
                ProjectFwsModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.x" + i + "}", "");
                    datas.Add("{param.dw" + i + "}", "");
                    datas.Add("{param.xh" + i + "}", "");

                }
                else
                {
                    datas.Add("{param.x" + i + "}", i + "");
                    datas.Add("{param.dw" + i + "}", m.CRMINFO);
                    datas.Add("{param.xh" + i + "}", m.PX + "");

                }
            }
            rtn = ReplaceToWord(kbrcbsxbF, projid, datas);
            return rtn;
        }

        public static string CreateTbwjlqdjb(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            for (int i = 1; i <= 7; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.x" + i + "}", "");
                    datas.Add("{param.tbr" + i + "}", "");
                    datas.Add("{param.sj" + i + "}", "");
                    datas.Add("{param.sl" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.x" + i + "}", i + "");
                    datas.Add("{param.tbr" + i + "}", m.CRMNAME);
                    datas.Add("{param.sj" + i + "}", "月  日   时  分");
                    datas.Add("{param.sl" + i + "}", "共    件");
                }
            }
            rtn = ReplaceToWord(tbwjlqdjbF, projid, datas);
            return rtn;
        }

        public static string CreateKbhqdb(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();
            CrmInfoService crmsrv = new CrmInfoService();
            List<CrmInfoModel> fwsL = new List<CrmInfoModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            string sql = @"select b.* from APP_PROJECT_FWS a,app_crm_info b where a.crminfo=b.infoid and projid='" + projid + "' and status<>-2";
            fwsL = crmsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            for (int i = 1; i <= 9; i++)
            {
                CrmInfoModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.x" + i + "}", "");
                    datas.Add("{param.tbr" + i + "}", "");

                }
                else
                {
                    datas.Add("{param.x" + i + "}", i + "");
                    datas.Add("{param.tbr" + i + "}", m.CRMNAME);

                }
            }
            rtn = ReplaceToWord(kbhqdbF, projid, datas);
            return rtn;
        }
        public static string CreatePbhqdb(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            //ProjectFwsService fsrv = new ProjectFwsService();

            List<ProjectPszjModel> fwsL = new List<ProjectPszjModel>();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;

            string sql = @"select b.uname personname,decode(a.lb,1,'技术评委',2,'经济评委',3,'需求评委',5,'工作人员',6,'监督人员','') projid,a.* from APP_PROJECT_PSZJ a,basis_sys_user b where a.personid=b.userid and projid='" + projid + "' and a.lb<>5 order by a.role desc ";
            ProjectPszjService crmsrv = new ProjectPszjService();

            fwsL = crmsrv.GetListBySQL(sql).ToList();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            for (int i = 1; i <= 15; i++)
            {
                ProjectPszjModel m = null;
                if (fwsL.Count >= i)
                    m = fwsL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.x" + i + "}", "");
                    datas.Add("{param.dw" + i + "}", "");
                    datas.Add("{param.xm" + i + "}", "");
                    datas.Add("{param.zz" + i + "}", "");
                }
                else
                {
                    datas.Add("{param.x" + i + "}", i + "");
                    datas.Add("{param.dw" + i + "}", "中国石化天然气川气东送管道分公司");
                    datas.Add("{param.xm" + i + "}", m.PERSONNAME);
                    //datas.Add("{param.zz" + i + "}", m.PROJID);
                    datas.Add("{param.zz" + i + "}","评委");

                }
            }
            rtn = ReplaceToWord(pbhqdbF, projid, datas);
            return rtn;
        }

        public static string CreateKbpbgzjl(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();

            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;

            ProjectKbpbgzjlService crmsrv = new ProjectKbpbgzjlService();
            ProjectKbpbgzjlModel m = crmsrv.GetList().Where(w => w.PROJID == projid).FirstOrDefault();
            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            datas.Add("{param.005}", m.P1);
            datas.Add("{param.006}", m.P2);
            datas.Add("{param.007}", m.P3);
            datas.Add("{param.008}", m.P4);
            datas.Add("{param.009}", m.P5);
            datas.Add("{param.010}", m.P6);
            rtn = ReplaceToWord(kbpbgzjlF, projid, datas);
            return rtn;
        }

        public static string CreatePbwyhxy(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();

            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();

            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;

            datas.Add("{param.001}", p.PROJNAME);
            datas.Add("{param.002}", p.PROJNUMBER);
            datas.Add("{param.003}", p.NKBDD);
            datas.Add("{param.004}", p.NKBSJ.ToRequestString());
            datas.Add("{param.p010}", "");
            datas.Add("{param.p011}", "");
            datas.Add("{param.p012}", "");
            datas.Add("{param.p013}", "");
            datas.Add("{param.p014}", "");
            datas.Add("{param.p015}", "");
            datas.Add("{param.p016}", "");
            datas.Add("{param.p017}", "");
            datas.Add("{param.p018}", "");
            datas.Add("{param.p019}", "");
            datas.Add("{param.p020}", "");

            //datas.Add("{param.005}", m.P1);
            //datas.Add("{param.006}", m.P2);
            //datas.Add("{param.007}", m.P3);
            //datas.Add("{param.008}", m.P4);
            //datas.Add("{param.009}", m.P5);
            //datas.Add("{param.010}", m.P6);
            Dictionary<string, string> pics = new Dictionary<string, string>();
            ProjectPszjService zjSrv = new ProjectPszjService();
            List<ProjectPszjModel> zjL = zjSrv.GetList().Where(w=>w.PROJID==projid).ToList();
            SysUserindividService individSrv = new SysUserindividService();
            SysUserindividModel userIndivid = null;
            for (int i = 1; i <= 9; i++)
            {
                ProjectPszjModel m = null;
                if (zjL.Count >= i)
                    m = zjL[i - 1];
                if (m == null)
                {
                    datas.Add("{param.p00" + i + "}", "");
                }
                else
                {
                    userIndivid = individSrv.GetModelById(m.PERSONID.ToInt());
                    if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
                    {
                        pics.Add("{param.p00" + i + "}", HttpContext.Current.Server.MapPath(userIndivid.SIGNPIC));
                    }
                    else
                    {
                        pics.Add("{param.p00" + i + "}", sourcePath + "/null.jpg");
                    }

                }
            }

            //pics.Add("{param.p001}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p002}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p003}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p004}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p005}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p006}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p007}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p008}", sourcePath + "/photo.jpg");
            //pics.Add("{param.p009}", sourcePath + "/photo.jpg");

            rtn = ReplaceToWordPic(pbwyhxyF, projid, datas, pics);
            return rtn;
        }
        public static string CreateTbyqh(string projid)
        {
            string rtn = "fail";
            ProjectInfoService psrv = new ProjectInfoService();
            ProjectInfoModel p = psrv.GetList().Where(o => o.PROJID == projid).FirstOrDefault();
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (p == null) return rtn;
            ProjectTbyqhService tsrv = new ProjectTbyqhService();
            ProjectTbyqhModel t = tsrv.GetList().Where(w => w.PROJID == projid).FirstOrDefault();
            datas.Add("{param.001}", t.P1);
            datas.Add("{param.002}", t.P2);
            datas.Add("{param.003}", t.P3);
            datas.Add("{param.004}", t.P4);
            datas.Add("{param.005}", t.P5);
            datas.Add("{param.006}", t.P6);
            datas.Add("{param.007}", t.P7);
            datas.Add("{param.008}", t.P8);
            datas.Add("{param.009}", t.P9);
            datas.Add("{param.xmmc}", p.PROJNAME);
            datas.Add("{param.zbbh}", p.PROJNUMBER);



            rtn = ReplaceToWord(tbyqhF, projid, datas);
            return rtn;
        }
        protected void InsertPtctureToWord(string plc, string file)
        {
            Application app = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                //图片地址
                string fileName = sourcePath + "/photo.jpg";
                object linkToFile = false;
                object saveWithDocument = true;

                //app = new Application();
                //doc = app.Documents.Add();
                //Table table = doc.Tables.Add(app.Selection.Range, 2, 2);
                //table.Columns[1].Width = 100f;
                //table.Columns[2].Width = 125f;
                //table.Cell(1, 1).Range.Text = "姓名";
                //table.Cell(1, 2).Range.Text = "张三";
                //table.Cell(2, 1).Range.Text = "照片";
                //table.Cell(2, 2).Select();



                app.Selection.Find.Replacement.ClearFormatting();
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Text = plc;

                object range = app.Selection.Range;
                InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(fileName, ref linkToFile, ref saveWithDocument, ref range);
                shape.Width = 100f;//图片宽度
                shape.Height = 120f;//图片高度
                shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapSquare;//四周环绕的方式
                string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
                string physicNewFile = sourcePath + "/" + newFile;
                doc.SaveAs(physicNewFile);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭文档
                }
                if (app != null)
                {
                    app.Quit();//退出应用程序
                }
            }
        }

        protected static string ReplaceToWordPic(string fName, string projid, Dictionary<string, string> datas, Dictionary<string, string> pics)
        {
            lock (obj)
            {


                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }
                //string filePath = Path.Combine(ImageStoragePath, fName + suffix);
                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}
                //else
                //{
                //}
                string targetPath = ImageStoragePath;
                string sourceFile = System.IO.Path.Combine(sourcePath, fName + suffix);
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                    //LogHelper.WriteLog("another");
                }
                else
                {
                }
                File.Copy(System.IO.Path.Combine(sourcePath + "/M", fName + suffix), sourceFile); 
                //Directory.Delete(targetPath + deptN,true);
                if (!Directory.Exists(targetPath + projid))
                {
                    Directory.CreateDirectory(targetPath + projid);
                }
                string moban = sourceFile;
                string physicNewFile = System.IO.Path.Combine(targetPath + projid, fName + suffix);

                Application app = null;
                Microsoft.Office.Interop.Word.Document doc = null;
                //将要导出的新word文件名
                //string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
                try
                {
                    app = new Application();//创建word应用程序
                    object fileName = moban;//模板文件
                    //打开模板文件
                    object oMissing = System.Reflection.Missing.Value;
                    doc = app.Documents.Open(ref fileName,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    //构造数据


                    object replace = WdReplace.wdReplaceAll;
                    foreach (var item in datas)
                    {
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Text = item.Key;//需要被替换的文本
                        app.Selection.Find.Replacement.Text = item.Value;//替换文本 

                        //执行替换操作
                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref replace,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                    }
                    //写图片
                    object linkToFile = false;
                    object saveWithDocument = true;
                    object left = 0;
                    object top = 0;
                    object width = 100;
                    object height = 50;
                    int i = 0;
                    foreach (var item in pics)
                    {
                        //doc.Content.Find.Text = item.Key;

                        //app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Text = item.Key;
                        if (string.IsNullOrEmpty(item.Value))
                        {
                            app.Selection.Find.Replacement.ClearFormatting();
                            app.Selection.Find.Replacement.Text = "";
                            app.Selection.Find.Execute(
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref replace,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing);
                            continue;

                        }

                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                        object range = app.Selection.Range;

                        left = i % 4 * 100;
                        i++;
                        //doc.Shapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref oMissing, ref oMissing, ref width, ref height, ref oMissing);
                        app.Selection.InlineShapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref oMissing);
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.Replacement.Text = "";

                        //app.Selection.Find.Execute(
                        //ref oMissing, ref oMissing,
                        //ref oMissing, ref oMissing,
                        //ref oMissing, ref oMissing,
                        //ref oMissing, ref oMissing, ref oMissing,
                        //ref oMissing, ref replace,
                        //ref oMissing, ref oMissing,
                        //ref oMissing, ref oMissing);


                        //InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref range);
                        //shape.Width = 100f;//图片宽度
                        //shape.Height = 120f;//图片高度
                        //shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapSquare;//四周环绕的方式
                    }

                    //对替换好的word模板另存为一个新的word文档
                    doc.SaveAs(physicNewFile,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                    //LogHelper.WriteLog(physicNewFile);
                    //准备导出word
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.Charset = "utf-8";
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc");
                    //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    //Response.ContentType = "application/ms-word";
                    //Response.End();
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    //这边为了捕获Response.End引起的异常
                    LogHelper.WriteLog(ex.ToRequestString());
                    physicNewFile = "fail";
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.ToRequestString());
                    physicNewFile = "fail";
                }
                finally
                {
                    if (doc != null)
                    {
                        doc.Close();//关闭word文档
                    }
                    if (app != null)
                    {
                        app.Quit();//退出word应用程序
                    }
                    //如果文件存在则输出到客户端
                    //if (File.Exists(physicNewFile))
                    //{
                    //    Response.WriteFile(physicNewFile);
                    //}
                }
                return physicNewFile;
            }
        }

        protected static string ReplaceToWordPic2(string fName, string projid, Dictionary<string, string> datas, Dictionary<string, string> pics, Dictionary<string, string> pics2)
        {
            if (!Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(sourcePath);
            }
            string filePath = Path.Combine(ImageStoragePath, fName + suffix);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
            }
            string targetPath = ImageStoragePath;
            string sourceFile = System.IO.Path.Combine(sourcePath, fName + suffix);
            //Directory.Delete(targetPath + deptN,true);
            if (!Directory.Exists(targetPath + projid))
            {
                Directory.CreateDirectory(targetPath + projid);
            }
            string moban = sourceFile;
            string physicNewFile = System.IO.Path.Combine(targetPath + projid, fName + suffix);

            Application app = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            //将要导出的新word文件名
            //string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
            try
            {
                app = new Application();//创建word应用程序
                object fileName = moban;//模板文件
                //打开模板文件
                object oMissing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref fileName,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                //构造数据


                object replace = WdReplace.wdReplaceAll;
                foreach (var item in datas)
                {
                    app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Text = item.Key;//需要被替换的文本
                    app.Selection.Find.Replacement.Text = item.Value;//替换文本 

                    //执行替换操作
                    app.Selection.Find.Execute(
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref replace,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                }
                //写图片
                object linkToFile = false;
                object saveWithDocument = true;
                object left = 0;
                object top = 0;
                object width = 100;
                object height = 50;
                int i = 0;
                i = 0;
                foreach (var item in pics2)
                {
                    //doc.Content.Find.Text = item.Key;

                    //app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Text = item.Key;
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.Replacement.Text = "";
                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref replace,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                        continue;

                    }

                    app.Selection.Find.Execute(
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                    object range = app.Selection.Range;

                    left = i % 4 * 100;
                    i++;
                    doc.Shapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref left, ref oMissing, ref width, ref height, ref range);
                    app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.Replacement.Text = "";


                    //InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref range);
                    //shape.Width = 100f;//图片宽度
                    //shape.Height = 120f;//图片高度
                    //shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapSquare;//四周环绕的方式
                }
                i = 0;
                foreach (var item in pics)
                {
                    //doc.Content.Find.Text = item.Key;

                    //app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Text = item.Key;
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.Replacement.Text = "";
                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref replace,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                        continue;

                    }

                    app.Selection.Find.Execute(
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                    object range = app.Selection.Range;

                    left = i % 4 * 100;
                    i++;
                    doc.Shapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref left, ref oMissing, ref width, ref height, ref range);
                    app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.Replacement.Text = "";


                    //InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref range);
                    //shape.Width = 100f;//图片宽度
                    //shape.Height = 120f;//图片高度
                    //shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapSquare;//四周环绕的方式
                }
                app.Selection.Find.Execute(
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref replace,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                //对替换好的word模板另存为一个新的word文档
                doc.SaveAs(physicNewFile,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                //准备导出word
                //Response.Clear();
                //Response.Buffer = true;
                //Response.Charset = "utf-8";
                //Response.AddHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc");
                //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                //Response.ContentType = "application/ms-word";
                //Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //这边为了捕获Response.End引起的异常
                physicNewFile = "fail";
            }
            catch (Exception ex)
            {
                physicNewFile = "fail";
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
                //如果文件存在则输出到客户端
                //if (File.Exists(physicNewFile))
                //{
                //    Response.WriteFile(physicNewFile);
                //}
            }
            return physicNewFile;
        }

        protected static string ReplaceToWordPicDel(string fName, string projid, int userid, Dictionary<string, string> datas, Dictionary<string, string> pics, int end)
        {
            lock (obj)
            {
                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }
                //string filePath = Path.Combine(ImageStoragePath, fName + suffix);
                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}
                //else
                //{
                //}
                string targetPath = ImageStoragePath;
                string sourceFile = System.IO.Path.Combine(sourcePath, fName + suffix);
                //LogHelper.WriteLog(sourceFile);
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                    //LogHelper.WriteLog("delete");
                }
                else
                {
                }
                File.Copy(System.IO.Path.Combine(sourcePath + "/M", fName + suffix), sourceFile); 
                //Directory.Delete(targetPath + deptN,true);
                if (!Directory.Exists(targetPath + projid))
                {
                    Directory.CreateDirectory(targetPath + projid);
                }
                string moban = sourceFile;
                string physicNewFile = System.IO.Path.Combine(targetPath + projid, userid + fName + suffix);

                Application app = null;
                Microsoft.Office.Interop.Word.Document doc = null;
                //将要导出的新word文件名
                //string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
                try
                {
                    app = new Application();//创建word应用程序
                    object fileName = moban;//模板文件
                    //打开模板文件
                    object oMissing = System.Reflection.Missing.Value;
                    doc = app.Documents.Open(ref fileName,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    //构造数据


                    object replace = WdReplace.wdReplaceAll;
                    foreach (var item in datas)
                    {
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Text = item.Key;//需要被替换的文本
                        app.Selection.Find.Replacement.Text = item.Value;//替换文本 

                        //执行替换操作
                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref replace,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                    }
                    //写图片
                    object linkToFile = false;
                    object saveWithDocument = true;
                    object left = 0;
                    object top = 0;
                    object width = 100;
                    object height = 50;
                    int i = 0;
                    if (pics != null)
                        foreach (var item in pics)
                        {
                            //doc.Content.Find.Text = item.Key;

                            //app.Selection.Find.Replacement.ClearFormatting();
                            app.Selection.Find.ClearFormatting();
                            app.Selection.Find.Text = item.Key;
                            if (string.IsNullOrEmpty(item.Value))
                            {
                                app.Selection.Find.Replacement.ClearFormatting();
                                app.Selection.Find.Replacement.Text = "";
                                app.Selection.Find.Execute(
                                ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref replace,
                                ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing);
                                continue;

                            }

                            app.Selection.Find.Execute(
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing);
                            object range = app.Selection.Range;

                            left = i % 4 * 100;
                            i++;
                            //doc.Shapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref left, ref oMissing, ref width, ref height, ref range);
                            app.Selection.InlineShapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref oMissing);
                        
                            app.Selection.Find.Replacement.ClearFormatting();
                            app.Selection.Find.Replacement.Text = "";

                            //app.Selection.Find.Execute(
                            //ref oMissing, ref oMissing,
                            //ref oMissing, ref oMissing,
                            //ref oMissing, ref oMissing,
                            //ref oMissing, ref oMissing, ref oMissing,
                            //ref oMissing, ref replace,
                            //ref oMissing, ref oMissing,
                            //ref oMissing, ref oMissing);
                            //InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(item.Value, ref linkToFile, ref saveWithDocument, ref range);
                            //shape.Width = 100f;//图片宽度
                            //shape.Height = 120f;//图片高度
                            //shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapSquare;//四周环绕的方式
                        }
                    //for (int r = 32 ; r >= end + 2; r--)
                    //{
                    //    doc.Content.Tables[1].Rows[r].Select();
                    //    app.Selection.SelectRow();
                    //    app.Selection.Delete();
                    //    //doc.Content.Tables[1].Rows[r].Delete();
                    //}


                    //对替换好的word模板另存为一个新的word文档
                    doc.SaveAs(physicNewFile,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                    //准备导出word
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.Charset = "utf-8";
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc");
                    //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    //Response.ContentType = "application/ms-word";
                    //Response.End();
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    //这边为了捕获Response.End引起的异常
                    physicNewFile = "fail";
                }
                catch (Exception ex)
                {
                    physicNewFile = "fail";
                }
                finally
                {
                    if (doc != null)
                    {
                        doc.Close();//关闭word文档
                    }
                    if (app != null)
                    {
                        app.Quit();//退出word应用程序
                    }
                    //如果文件存在则输出到客户端
                    //if (File.Exists(physicNewFile))
                    //{
                    //    Response.WriteFile(physicNewFile);
                    //}
                }
                return physicNewFile;
            }
        }

        protected static string ReplaceToWord(string fName, string projid, Dictionary<string, string> datas)
        {
            lock (obj)
            {
                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }
                //string filePath = Path.Combine(ImageStoragePath, fName + suffix);
                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}
                //else
                //{
                //}

                string targetPath = ImageStoragePath;
                string sourceFile = System.IO.Path.Combine(sourcePath, fName + suffix);
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                    //LogHelper.WriteLog("another");
                }
                else
                {
                }
                File.Copy(System.IO.Path.Combine(sourcePath + "/M", fName + suffix), sourceFile); 
                //Directory.Delete(targetPath + deptN,true);
                if (!Directory.Exists(targetPath + projid))
                {
                    Directory.CreateDirectory(targetPath + projid);
                }
                string moban = sourceFile;
                string physicNewFile = System.IO.Path.Combine(targetPath + projid, fName + suffix);

                Application app = null;
                Microsoft.Office.Interop.Word.Document doc = null;
                //将要导出的新word文件名
                //string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
                try
                {
                    app = new Application();//创建word应用程序
                    object fileName = moban;//模板文件
                    //打开模板文件
                    object oMissing = System.Reflection.Missing.Value;
                    doc = app.Documents.Open(ref fileName,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    //构造数据


                    object replace = WdReplace.wdReplaceAll;
                    foreach (var item in datas)
                    {
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Text = item.Key;//需要被替换的文本
                        //app.Selection.TypeText(item.Value);
                        app.Selection.Find.Replacement.Text = item.Value;//替换文本 
                        //执行替换操作
                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref replace,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                    }

                    //对替换好的word模板另存为一个新的word文档
                    doc.SaveAs(physicNewFile,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                    //准备导出word
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.Charset = "utf-8";
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc");
                    //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    //Response.ContentType = "application/ms-word";
                    //Response.End();
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    //这边为了捕获Response.End引起的异常
                    physicNewFile = "fail";
                }
                catch (Exception ex)
                {
                    physicNewFile = "fail";
                }
                finally
                {
                    if (doc != null)
                    {
                        doc.Close();//关闭word文档
                    }
                    if (app != null)
                    {
                        app.Quit();//退出word应用程序
                    }
                    //如果文件存在则输出到客户端
                    //if (File.Exists(physicNewFile))
                    //{
                    //    Response.WriteFile(physicNewFile);
                    //}
                }
                return physicNewFile;
            }
        }

        protected static string ReplaceToWord5(string fName, string projid, Dictionary<string, string> datas)
        {
            lock (obj)
            {
                if (!Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(sourcePath);
                }
                //string filePath = Path.Combine(ImageStoragePath, fName + suffix);
                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}
                //else
                //{
                //}

                string targetPath = ImageStoragePath;
                string sourceFile = System.IO.Path.Combine(ImageStoragePath + projid, fName + suffix);
                //if (File.Exists(sourceFile))
                //{
                //    File.Delete(sourceFile);
                //    //LogHelper.WriteLog("another");
                //}
                //else
                //{
                //}
                //File.Copy(System.IO.Path.Combine(sourcePath + "/M", fName + suffix), sourceFile);
                //Directory.Delete(targetPath + deptN,true);
                if (!Directory.Exists(targetPath + projid))
                {
                    Directory.CreateDirectory(targetPath + projid);
                }
                string moban = sourceFile;
                string physicNewFile = System.IO.Path.Combine(targetPath + projid, fName +"(审核通过)"+ suffix);

                Application app = null;
                Microsoft.Office.Interop.Word.Document doc = null;
                //将要导出的新word文件名
                //string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
                try
                {
                    app = new Application();//创建word应用程序
                    object fileName = moban;//模板文件
                    //打开模板文件
                    object oMissing = System.Reflection.Missing.Value;
                    doc = app.Documents.Open(ref fileName,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    //构造数据


                    object replace = WdReplace.wdReplaceAll;
                    foreach (var item in datas)
                    {
                        app.Selection.Find.Replacement.ClearFormatting();
                        app.Selection.Find.ClearFormatting();
                        app.Selection.Find.Text = item.Key;//需要被替换的文本
                        //app.Selection.TypeText(item.Value);
                        app.Selection.Find.Replacement.Text = item.Value;//替换文本 
                        //执行替换操作
                        app.Selection.Find.Execute(
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref replace,
                        ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                    }

                    //对替换好的word模板另存为一个新的word文档
                    doc.SaveAs(physicNewFile,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                    //准备导出word
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.Charset = "utf-8";
                    //Response.AddHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc");
                    //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    //Response.ContentType = "application/ms-word";
                    //Response.End();
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    //这边为了捕获Response.End引起的异常
                    physicNewFile = "fail";
                }
                catch (Exception ex)
                {
                    physicNewFile = "fail";
                }
                finally
                {
                    if (doc != null)
                    {
                        doc.Close();//关闭word文档
                    }
                    if (app != null)
                    {
                        app.Quit();//退出word应用程序
                    }
                    //如果文件存在则输出到客户端
                    //if (File.Exists(physicNewFile))
                    //{
                    //    Response.WriteFile(physicNewFile);
                    //}
                }
                return physicNewFile;
            }
        }
    }
}
