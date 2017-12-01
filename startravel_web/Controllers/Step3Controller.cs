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
    public class Step3Controller : Controller
    {
        //
        // GET: /Step3/
        public async Task<ActionResult> Index()
        {

            string order_number_s = "SPO0004207587";
            string member_number_s = "MEM0000000028";
            string order_no_s="SPO0004216113";
            string order_source_s="STAR";
            string order_time_s="DP";
            string pay_flow_s="EC";
            string order_payment_s="MEMBER";
            string user_number_s="MEM0000863765";
            string lst_seqno="1";
            string online_ticket_s="N";
            string ihol_pay_s="N";
            string direct_allpay_s="N";


            ApiController api = new ApiController();
            PaymentOrder_PostData paymentorder_postData = new PaymentOrder_PostData() { order_no= order_number_s};
            tCashAvblBalance_PostData tcashavblbalance_postData = new tCashAvblBalance_PostData() { member_no = member_number_s };
            OrderInstallment_PostData orderinstallment_postData = new OrderInstallment_PostData()
            {
                ORDER_NO = order_no_s,
                ORDER_SOURCE = order_source_s,
                ORDER_TIME = order_time_s,
                PAY_FLOW = pay_flow_s,
                ORDER_PAYMENT = order_payment_s,
                USER_NUMBER = user_number_s,
                LST_SEQNO = lst_seqno,
                ONLINE_TICKET = online_ticket_s,
                IHOL_PAY = ihol_pay_s,
                DIRECT_ALLPay = direct_allpay_s
            };

            var paymentorder_source = await api.PaymentOrder_api(paymentorder_postData);
            var tcashavblbalance_source = await api.tCashAvblBalance_api(tcashavblbalance_postData);
            var orderinstallment_source = await api.OrderInstallment_api(orderinstallment_postData);
            step3_view_return_data step3_view_data = new step3_view_return_data { paymentorder_result = paymentorder_source, tcashavblbalance_result = tcashavblbalance_source, orderinstallment_result = orderinstallment_source };

            return View(step3_view_data);
        }
	}
}