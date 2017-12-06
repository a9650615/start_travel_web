using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using startravel_web.Models;

namespace startravel_web.Controllers
{
    public class Step1Controller : Controller
    {
        //
        // GET: /Step1/
        public async Task<ActionResult> Index(string prod_no,string grp_no)
        {
            ApiController api = new ApiController();
            string view_prod_no = prod_no;
            string view_grp_no = grp_no;
           // string view_prod_no = "IGRP000018191";
            //string view_grp_no = "OKA04IT31617T";

            //***GRPProductDetail_api testing***//

            GRPProductDetail_PostData grpproductdetail_postData = new GRPProductDetail_PostData() { prod_no = view_prod_no, grp_no = view_grp_no };
            IGRPTrafficInfo_PostData igrptrafficinfo_postData = new IGRPTrafficInfo_PostData() { prod_no = view_prod_no, grp_no = view_grp_no };
            GRPPriceInfo_PostData grppriceinfo_postData = new GRPPriceInfo_PostData() { prod_no = view_prod_no, grp_no = view_grp_no };



            var grpsource = await api.GRPProductDetail_api(grpproductdetail_postData);
            var igrptrafficinfo_source = await api.IGRPTrafficInfo_api(igrptrafficinfo_postData);
            var grppriceinfo_source = await api.GRPPriceInfo_api(grppriceinfo_postData);
            // Response.Write("PROD_NAME：" + grpsource.Data.PROD_DESC3+ "<br/>");
            // JObject grpsource_ob =await grpsource;
            step1_view_return_data step1_view_data = new step1_view_return_data { grpproductdetail_result = grpsource, igrptrafficinfo_result = igrptrafficinfo_source, grppriceinfo_result = grppriceinfo_source };

            /////uututut

            return View(step1_view_data);
        }

       /* [HttpPost]
        public async Task<ActionResult> Index(detail_view_return_data data)
        {
            ApiController api = new ApiController();
            string view_prod_no = data.grpproductdetail_result.Data.PROD_NO;
            string view_grp_no = data.grpproductdetail_result.Data.GRP_NO;
            //string view_prod_no = "IGRP000018191";
            //string view_grp_no = "OKA04IT31617T";

            //GRPProductDetail_api testing//

            GRPProductDetail_PostData grpproductdetail_postData = new GRPProductDetail_PostData() { prod_no = view_prod_no, grp_no = view_grp_no };
            IGRPTrafficInfo_PostData igrptrafficinfo_postData = new IGRPTrafficInfo_PostData() { prod_no = view_prod_no, grp_no = view_grp_no };
            GRPPriceInfo_PostData grppriceinfo_postData = new GRPPriceInfo_PostData() { prod_no = view_prod_no, grp_no = view_grp_no };



            var grpsource = await api.GRPProductDetail_api(grpproductdetail_postData);
            var igrptrafficinfo_source = await api.IGRPTrafficInfo_api(igrptrafficinfo_postData);
            var grppriceinfo_source = await api.GRPPriceInfo_api(grppriceinfo_postData);
            // Response.Write("PROD_NAME：" + grpsource.Data.PROD_DESC3+ "<br/>");
            // JObject grpsource_ob =await grpsource;
            step1_view_return_data step1_view_data = new step1_view_return_data { grpproductdetail_result = grpsource, igrptrafficinfo_result = igrptrafficinfo_source, grppriceinfo_result = grppriceinfo_source };



            return View(step1_view_data);
        }*/


     
       /* [HttpPost]
        public async Task<ActionResult> Verify(step1_view_return_data data, string user_name, string user_passwd, string room_count_name)
        {
           // TempData["message"] = room_count_name;

            string view_prod_no = data.grpproductdetail_result.Data.PROD_NO;
            string view_grp_no = data.grpproductdetail_result.Data.GRP_NO;

           

           // return RedirectToAction("Index", "Step2", new { member_number = member_number, room_count_name = room_count_name, view_prod_no = view_prod_no, view_grp_no = view_grp_no });
           ApiController api = new ApiController();
            if (string.IsNullOrWhiteSpace(user_name) || string.IsNullOrWhiteSpace(user_passwd))
            {
                TempData["message"] = "身分證字號或密碼為空";
                return RedirectToAction("Index", "Step1", new { prod_no = view_prod_no, grp_no = view_grp_no });
            }
            else 
            {

                LoginVerify_PostData loginverify_postData = new LoginVerify_PostData() { ID_NO = user_name, password = user_passwd };
                var loginverify_source = await api.LoginVerify_api(loginverify_postData);
               // Response.Write("loginverify_source.rCode：" + loginverify_source.rCode + "<br/>");
                if( loginverify_source.rCode.Equals("0001"))
                {
                    string member_number = loginverify_source.Data.MEMBER_NO;
                    //TempData["message"] = "登入成功";
                    return RedirectToAction("Index", "Step2", new { view_prod_no = view_prod_no, view_grp_no = view_grp_no, room_count_name = room_count_name, member_number = member_number });
                }else
                {
                    TempData["message"] = "帳號或密碼輸入錯誤" ;
                    return RedirectToAction("Index", "Step1", new { prod_no = view_prod_no, grp_no = view_grp_no });
                }
               
               // TempData["message"] = loginverify_source.rCode;
              
            }
                
             

            
            //Response.Write("user_name：" + user_name + "<br/>");
            //Response.Write("user_passwd：" + user_passwd + "<br/>");
            //if()

            
        }*/
	}
}