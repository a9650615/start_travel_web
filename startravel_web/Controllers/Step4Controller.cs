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
    public class Step4Controller : Controller
    {
        //
        // GET: /Step4/
        public async Task<ActionResult> Index()
        {

            string order_number_s = "SPO0004207587";

            ApiController api = new ApiController();
            OrderInfomation_PostData orderinfomation_postData = new OrderInfomation_PostData() { order_no = order_number_s };
            var orderinfomation_source = await api.OrderInfomation_api(orderinfomation_postData);

            step4_view_return_data step4_view_data = new step4_view_return_data { orderinfomation_result = orderinfomation_source};


            return View(step4_view_data);
        }
	}
}