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
    public class DetailController : Controller
    {
        //
        // GET: /Detail/
        public async Task<ActionResult> Index(string prod_no, string grp_no)
        {
            ApiController api = new ApiController();
         //   string prod_no_s ="IGRP000018712";
          //  string grp_no_s = "BKK05ITA0217A";

            
           string prod_no_s = prod_no;
            string grp_no_s = grp_no;
           // string travel_region_s=TravelRegion;
            
            //***GRPProductDetail_api testing***//
            GRPProductDetail_PostData grpproductdetail_postData = new GRPProductDetail_PostData() { prod_no = prod_no_s, grp_no = grp_no_s };
            var grpsource = await api.GRPProductDetail_api(grpproductdetail_postData);

            string current_date = DateTime.Now.ToString("yyyyMM");
            //string current_date = DateTime.Now.ToString("yyyyMMdd");
            DateTime current_date_d = DateTime.ParseExact(current_date, "yyyyMM", System.Globalization.CultureInfo.InvariantCulture);
            current_date_d = current_date_d.AddMonths(1);
            string next_date = current_date_d.ToString("yyyyMM");

           /// IGRPTrafficInfo_PostData igrptrafficinfo_postData = new IGRPTrafficInfo_PostData() { prod_no = "IGRP000018191", grp_no = "OKA04IT31617T" };
            GRPCalendar_PostData grpcalendar_postData = new GRPCalendar_PostData() { prod_no = prod_no_s, s_month = current_date, e_month = next_date };
            GRPAddPurchase_PostData grpaddpurchase_postData = new GRPAddPurchase_PostData() { prod_no = prod_no_s, grp_no = grp_no_s };
            GRPPriceInfo_PostData grppriceinfo_postData = new GRPPriceInfo_PostData() { prod_no = prod_no_s, grp_no = grp_no_s };

           
           var grpcalendar_source = await api.GRPCalendar_api(grpcalendar_postData);
           var grpaddpurchase_source = await api.GRPAddPurchase_api(grpaddpurchase_postData);
           var grppriceinfo_source = await api.GRPPriceInfo_api(grppriceinfo_postData);


           detail_view_return_data view_data = new detail_view_return_data { grpproductdetail_result = grpsource, grpcalendar_result = grpcalendar_source, grpaddpurchase_result = grpaddpurchase_source, grppriceinfo_result = grppriceinfo_source};

           return View(view_data);
        }

      
	}
}