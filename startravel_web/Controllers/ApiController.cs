using startravel_web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Web.Script.Serialization;

namespace startravel_web.Controllers
{
    public class ApiController : Controller
    {
        //tour1.1
        public async Task<GRPList_result> GRPList_api(GRPList_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/GRPList";
            HttpClient client = new HttpClient();
            JavaScriptSerializer jsonConverter = new JavaScriptSerializer();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<GRPList_result>(collection);
            //var collection_jobj = jsonConverter.Deserialize<GRPProductDetail_result>(collection);
            return collection_jobj;
        }

        //tour1.2
        public async Task<IGRPTrafficInfo_result> IGRPTrafficInfo_api(IGRPTrafficInfo_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/IGRPTrafficInfo";
            string final_URI = targetURI + "?prod_no=" + postdata.prod_no + "&grp_no=" + postdata.grp_no;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<IGRPTrafficInfo_result>(collection);
            return collection_jobj;
        }

        //tour1.5
        public async Task<GRPPriceInfo_result> GRPPriceInfo_api(GRPPriceInfo_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/GRPPriceInfo";
            string final_URI = targetURI + "?prod_no=" + postdata.prod_no + "&grp_no=" + postdata.grp_no;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<GRPPriceInfo_result>(collection);

            return collection_jobj;
        }


        //tour1.6
        public async Task<GRPProductDetail_result> GRPProductDetail_api(GRPProductDetail_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/GRPProductDetail";
            HttpClient client = new HttpClient();
            JavaScriptSerializer jsonConverter = new JavaScriptSerializer();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<GRPProductDetail_result>(collection);
            //var collection_jobj = jsonConverter.Deserialize<GRPProductDetail_result>(collection);
            return collection_jobj;
        }

        //tour_1.7
        public async Task<GRPCalendar_result> GRPCalendar_api(GRPCalendar_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/GRPCalendar";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<GRPCalendar_result>(collection);
            return collection_jobj;
          
        }

        //tour_1.8
        public async Task<GRPAddPurchase_result> GRPAddPurchase_api(GRPAddPurchase_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/GRPAddPurchase";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<GRPAddPurchase_result>(collection);
            return collection_jobj;

        }

        //tour_1.9
        public async Task<GRPDepartureList_result> GRPDepartureList_api(GRPDepartureList_PostData postdata)
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/GRPDepartureList";
            string final_URI = targetURI + "?Depart_SDate=" + postdata.Depart_SDate + "&Depart_EDate=" + postdata.Depart_EDate;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<GRPDepartureList_result>(collection);

            return collection_jobj;

        }


        //tour_1.12
        public async Task<IGRPTravelRegion_result> IGRPTravelRegion_api()
        {
            string targetURI = "https://dtour-api.startravel.com.tw/api/IGRPTravelRegion";
            string final_URI = targetURI;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<IGRPTravelRegion_result>(collection);

            return collection_jobj;

        }

        //member_1.1
        public async Task<LoginVerify_result> LoginVerify_api(LoginVerify_PostData postdata)
        {
            string targetURI = "https://dmember-api.startravel.com.tw/api/LoginVerify";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<LoginVerify_result>(collection);
            return collection_jobj;
           
        }

        //member_1.11
        public async Task<tCashAvblBalance_result> tCashAvblBalance_api(tCashAvblBalance_PostData postdata)
        {
            string targetURI = "https://dmember-api.startravel.com.tw/api/tCashAvblBalance";
            string final_URI = targetURI + "?member_no=" + postdata.member_no;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<tCashAvblBalance_result>(collection);
            return collection_jobj;
        }


        //member_1.13 Task<PassengerContacts_get_result>
        public async Task<PassengerContacts_get_result> PassengerContacts_get_api(PassengerContacts_get_PostData postdata)
        {
            string targetURI = "https://dmember-api.startravel.com.tw/api/PassengerContacts";
            string final_URI = targetURI + "?member_no=" + postdata.member_no;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<PassengerContacts_get_result>(collection);
            //Response.Write("PROD_NO：" + response + "<br/>");
            return collection_jobj;
        }

        //order_1.2 
        public async Task<PaymentOrder_result> PaymentOrder_api(PaymentOrder_PostData postdata)
        {
            string targetURI = "https://dorder-api.startravel.com.tw/api/PaymentOrder";
            string final_URI = targetURI + "?order_no=" + postdata.order_no;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<PaymentOrder_result>(collection);
            return collection_jobj;
           
        }

        //order_1.3
        public async Task<ATMTransferAccount_result> ATMTransferAccount_api(ATMTransferAccount_PostData postdata)
        {
            string targetURI = "https://dorder-api.startravel.com.tw/api/ATMTransferAccount";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<ATMTransferAccount_result>(collection);
            return collection_jobj;
           
        }


        //order_1.4
        public async Task<OrderStore_result> OrderStore_api()
        {
            string targetURI = "https://dorder-api.startravel.com.tw/api/OrderStore";
            string final_URI = targetURI;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<OrderStore_result>(collection);

            return collection_jobj;

        }


        //order_1.5
        public async Task<OrderInfomation_result> OrderInfomation_api(OrderInfomation_PostData postdata)
        {
            string targetURI = "https://dorder-api.startravel.com.tw/api/OrderInfomation";
            string final_URI = targetURI + "?order_no=" + postdata.order_no;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            HttpResponseMessage response = client.GetAsync(final_URI).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<OrderInfomation_result>(collection);
            return collection_jobj;

        }

        //PMCH
        public async Task<OrderInstallment_result> OrderInstallment_api(OrderInstallment_PostData postdata)
        {
            string targetURI = "https://dpmch-api.startravel.com.tw/api/OrderInstallment";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            string json = JsonConvert.SerializeObject(postdata);
            HttpContent contentPost = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(targetURI, contentPost).Result;
            var collection = response.Content.ReadAsStringAsync().Result;
            var collection_jobj = JsonConvert.DeserializeObject<OrderInstallment_result>(collection);
            return collection_jobj;

        }

	}
}