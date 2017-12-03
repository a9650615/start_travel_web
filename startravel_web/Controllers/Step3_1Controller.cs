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
    public class Step3_1Controller : Controller
    {
        //
        // GET: /Step3_1/
        public async Task<ActionResult> Index()
        {

            string order_number_s = Request.Form["order_no_hidden"];
            //string member_number_s = "MEM0000000028";
            int tcash_i =0; 
            bool is_atm = true; //atm :true credit card:1false
            ApiController api = new ApiController();
            OrderInfomation_PostData orderinfomation_postData = new OrderInfomation_PostData() { order_no = order_number_s };
            ATMTransferAccount_PostData atmtransferaccount_postData = new ATMTransferAccount_PostData() { order_no = order_number_s };
            var orderinfomation_source = await api.OrderInfomation_api(orderinfomation_postData);
            var atmtransferaccount_source = await api.ATMTransferAccount_api(atmtransferaccount_postData);

            step3_1_view_return_data step3_1_view_data = new step3_1_view_return_data { orderinfomation_result = orderinfomation_source, tcash = tcash_i, atmtransferaccount_result = atmtransferaccount_source, order_no = order_number_s };

            return View(step3_1_view_data);
        }
        
	}
}