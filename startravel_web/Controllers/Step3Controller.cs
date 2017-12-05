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
        public async Task<ActionResult> Index(string order_number, string member_number)
        {

            string order_number_s = order_number;
            string member_number_s = member_number;
            string order_no_s = order_number;
            string order_source_s="STAR";
            string order_time_s="DP";
            string pay_flow_s="EC";
            string order_payment_s="MEMBER";
            string user_number_s = member_number;
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
            step3_view_return_data step3_view_data = new step3_view_return_data { paymentorder_result = paymentorder_source, tcashavblbalance_result = tcashavblbalance_source, orderinstallment_result = orderinstallment_source, order_no = order_no_s };

            return View(step3_view_data);
        }


        [HttpPost]
        public async Task<ActionResult> order(
                                          string contact_c_first_name,
                                          string contact_c_last_name,
                                          string contact_mobile,
                                          string contact_h_phone,
                                          string contact_o_phone,
                                          string contact_email,
                                          string contact_time,
                                          string contact_note,
                                          string passengerInfo_first_c_name_array,
                                          string passengerInfo_last_c_name_array,
                                          string passengerInfo_first_e_name_array,
                                          string passengerInfo_last_e_name_array,
                                          string passengerInfo_sex_array,
                                          string passengerInfo_id_array,
                                          string passengerInfo_birthday_array,
                                          string passengerInfo_food_array,
                                          string passengerInfo_prod_sub_array,
                                          string passengerInfo_room_type_array,
                                          string company_title,
                                          string uniform_numbers,
                                          string recipients,
                                          string recipients_address,
                                          string receipt_store_item,
                                          string receipt_store_address,
                                          string registered,
                                          string registered_address,
                                          string order_note,
                                          string total_people_hidden,
                                          string pusb_count_hidden,
                                          string visa_count_hidden,
                                          string insu_count_hidden,
                                          string room_count_hidden,
                                          string pusb_array_hidden,
                                          string visa_array_hidden,
                                          string insu_array_hidden,
                                          string prod_no_hidden,
                                          string grp_no_hidden,
                                          string member_no_hidden

              )
        {
            ///
            ApiController api = new ApiController();
            GRPAddPurchase_PostData grpaddpurchase_postData = new GRPAddPurchase_PostData() { prod_no = prod_no_hidden, grp_no = grp_no_hidden };
            var grpaddpurchase_source = await api.GRPAddPurchase_api(grpaddpurchase_postData);

            /*Response.Write("***********連絡人資料*********" + "<br/>");
            Response.Write("contact_c_first_name：" + contact_c_first_name + "<br/>");
            Response.Write("contact_c_last_name：" + contact_c_last_name + "<br/>");
            Response.Write("contact_mobile：" + contact_mobile + "<br/>");
            Response.Write("contact_h_phone：" + contact_h_phone + "<br/>");
            Response.Write("contact_o_phone：" + contact_o_phone + "<br/>");
            Response.Write("contact_email：" + contact_email + "<br/>");
            Response.Write("contact_time：" + contact_time + "<br/>");
            Response.Write("contact_note：" + contact_note + "<br/>");
            Response.Write("***********旅客人資料*********" + "<br/>");
            Response.Write("passengerInfo_first_c_name_array：" + passengerInfo_first_c_name_array + "<br/>");
            Response.Write("passengerInfo_last_c_name_array：" + passengerInfo_last_c_name_array + "<br/>");
            Response.Write("passengerInfo_first_e_name_array：" + passengerInfo_first_e_name_array + "<br/>");
            Response.Write("passengerInfo_last_e_name_array：" + passengerInfo_last_e_name_array + "<br/>");
            Response.Write("passengerInfo_sex_array：" + passengerInfo_sex_array + "<br/>");
            Response.Write("passengerInfo_id_array：" + passengerInfo_id_array + "<br/>");
            Response.Write("passengerInfo_birthday_array：" + passengerInfo_birthday_array + "<br/>");
            Response.Write("passengerInfo_food_array：" + passengerInfo_food_array + "<br/>");
            Response.Write("passengerInfo_prod_sub_array：" + passengerInfo_prod_sub_array + "<br/>");
            Response.Write("***********其他資料*********" + "<br/>");
            Response.Write("company_title：" + company_title + "<br/>");
            Response.Write("uniform_numbers：" + uniform_numbers + "<br/>");
            Response.Write("recipients：" + recipients + "<br/>");
            Response.Write("recipients_address：" + recipients_address + "<br/>");
            Response.Write("receipt_store_item：" + receipt_store_item + "<br/>");
            Response.Write("receipt_store_address：" + receipt_store_address + "<br/>");
            Response.Write("registered：" + registered + "<br/>");
            Response.Write("registered_address：" + registered_address + "<br/>");
            Response.Write("order_note：" + order_note + "<br/>");
            Response.Write("***********其他資料(total people,pusb,visa,insu)*********" + "<br/>");
            Response.Write("total_people_hidden：" + total_people_hidden + "<br/>");
            Response.Write("pusb_count_hidden：" + pusb_count_hidden + "<br/>");
            Response.Write("visa_count_hidden：" + visa_count_hidden + "<br/>");
            Response.Write("insu_count_hidden：" + insu_count_hidden + "<br/>");
            Response.Write("room_count_hidden：" + room_count_hidden + "<br/>");
            Response.Write("pusb_array_hidden：" + pusb_array_hidden + "<br/>");
            Response.Write("visa_array_hidden：" + visa_array_hidden + "<br/>");
            Response.Write("insu_array_hidden：" + insu_array_hidden + "<br/>");*/

            int total_prod_sub_number = int.Parse(pusb_count_hidden) + int.Parse(visa_count_hidden) + int.Parse(insu_count_hidden);
            //build prod_sub_correspond_list
            string[] prod_sub_correspond_list = new string[int.Parse(total_people_hidden)];

            //pusb visa insu
            string total_prod_sub_s;

            if (int.Parse(pusb_count_hidden) == 0)
            {
                if (int.Parse(visa_count_hidden) == 0)
                {
                    if (int.Parse(insu_count_hidden) == 0)
                    {
                        total_prod_sub_s = null;
                    }
                    else
                    {
                        total_prod_sub_s = insu_array_hidden;
                    }
                }
                else
                {
                    if (int.Parse(insu_count_hidden) == 0)
                    {
                        total_prod_sub_s = visa_array_hidden;
                    }
                    else
                    {
                        total_prod_sub_s = visa_array_hidden + "," + insu_array_hidden;
                    }
                }

            }
            else
            {

                if (int.Parse(visa_count_hidden) == 0)
                {
                    if (int.Parse(insu_count_hidden) == 0)
                    {
                        total_prod_sub_s = pusb_array_hidden;
                    }
                    else
                    {
                        total_prod_sub_s = pusb_array_hidden + "," + insu_array_hidden;
                    }
                }
                else
                {
                    if (int.Parse(insu_count_hidden) == 0)
                    {
                        total_prod_sub_s = pusb_array_hidden + "," + visa_array_hidden;
                    }
                    else
                    {
                        total_prod_sub_s = pusb_array_hidden + "," + visa_array_hidden + "," + insu_array_hidden;
                    }
                }

            }

          


        
            string[] total_correspond_count_list = total_prod_sub_s.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);





            //build prod_sub_array
            //Response.Write("***********build  prod_sub_itemlist*********" + "<br/>");
            string[] cus_prod_sub_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_prod_sub_array = passengerInfo_prod_sub_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                for (int j = 0; j < total_prod_sub_number; j = j + 1)
                {
                    if (j == 0)
                    {
                        cus_prod_sub_count_list[i] = cus_prod_sub_array[i * total_prod_sub_number + j];
                    }
                    else
                    {
                        cus_prod_sub_count_list[i] = cus_prod_sub_count_list[i] + "," + cus_prod_sub_array[i * total_prod_sub_number + j];
                    }
                }
            }

            //first_c_name
            string[] cus_first_c_name_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_first_c_name_array = passengerInfo_first_c_name_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_first_c_name_count_list[i] = cus_first_c_name_array[i];
            }

            //last_c_name
            string[] cus_last_c_name_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_last_c_name_array = passengerInfo_last_c_name_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_last_c_name_count_list[i] = cus_last_c_name_array[i];
            }

            //first_e_name
            string[] cus_first_e_name_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_first_e_name_array = passengerInfo_first_e_name_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_first_e_name_count_list[i] = cus_first_e_name_array[i];
            }

            //last_c_name
            string[] cus_last_e_name_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_last_e_name_array = passengerInfo_last_e_name_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_last_e_name_count_list[i] = cus_last_e_name_array[i];
            }

            //sex
            string[] cus_sex_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_sex_array = passengerInfo_sex_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_sex_count_list[i] = cus_sex_array[i];
            }

            //id
            string[] cus_id_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_id_array = passengerInfo_id_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_id_count_list[i] = cus_id_array[i];
            }

            //birthday
            string[] cus_birthday_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_birthday_array = passengerInfo_birthday_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                DateTime cus_birthday_transfer = DateTime.ParseExact(cus_birthday_array[i], "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

                cus_birthday_count_list[i] = cus_birthday_transfer.ToString("yyyyMMdd");
            }

            //birthday
            string[] cus_food_count_list = new string[int.Parse(total_people_hidden)];
            string[] cus_food_array = passengerInfo_food_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_food_count_list[i] = cus_food_array[i];
            }

            //room_type
            string[] cus_room_type_list = new string[int.Parse(total_people_hidden)];
            string[] cus_room_type_array = passengerInfo_room_type_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {
                cus_room_type_list[i] = cus_room_type_array[i];
            }


            //Response.Write("***********build  cus_itemlist*********" + "<br/>");
            // 
            List<OrderGrpCreateCusModel_param> cus_itemlist = new List<OrderGrpCreateCusModel_param>();

            for (int i = 0; i < int.Parse(total_people_hidden); i = i + 1)
            {

                List<OrderGrpCreateProdSubModel_param> prod_sub_itemlist = new List<OrderGrpCreateProdSubModel_param>();
                //string[] everyone_cus_prod_sub_count_list = new string[int.Parse(total_prod_sub_number)];
                string[] everyone_cus_prod_sub_array = cus_prod_sub_count_list[i].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);


                for (int j = 0; j < total_prod_sub_number; j = j + 1)
                {
                    if (int.Parse(everyone_cus_prod_sub_array[j]) != 0)
                    {
                        prod_sub_itemlist.Add(new OrderGrpCreateProdSubModel_param
                        {
                            PROD_SUB_NO = grpaddpurchase_source.Data[int.Parse(total_correspond_count_list[j])].prod_SUB_NO,
                            PROD_SUB_QTY = "1"

                        });
                        // grpaddpurchase_source
                    }

                    //cus_prod_sub_count_list[i] 


                }

                cus_itemlist.Add(new OrderGrpCreateCusModel_param
                {


                    CUS_SEQNO = i.ToString(),
                    CUS_TYPE = null,
                    CUS_ID = cus_id_count_list[i],
                    CUS_NAME_C_FIRST = cus_first_c_name_count_list[i],
                    CUS_NAME_C_LAST = cus_last_c_name_count_list[i],
                    CUS_NAME_E_FIRST = cus_first_e_name_count_list[i],
                    CUS_NAME_E_LASTE = cus_last_e_name_count_list[i],
                    CUS_SEX = cus_sex_count_list[i],
                    CUS_BIRTHDAY = cus_birthday_count_list[i],
                    CUS_TEL1 = null,
                    CUS_TEL2 = null,
                    CUS_MOBIL = null,
                    CUS_EMAIL = null,
                    CUS_FAX = null,
                    CUS_ADDRESS = null,
                    CUS_FOOD = cus_food_count_list[i],
                    PASSPORT_NO = null,
                    PASSPORT_S_DATE = null,
                    PASSPORT_E_DATE = null,
                    ROOM_COND = cus_room_type_list[i],
                    ORDER_PROD_SUB = prod_sub_itemlist

                });
            }


            //final contact data

            OrderGrpCreate_PostData OrderGrpCreate_postData = new OrderGrpCreate_PostData()
            {
                ORDER_SALES = null,
                ORDER_CONTACT_NO = member_no_hidden,
                ORDER_CONTACT_TYPE = null,
                ORDER_CONTACT_NAME = contact_c_first_name + "" + contact_c_last_name,
                ORDER_CONTACT_ID = "A180352504",
                ORDER_CONTACT_TEL1 = contact_h_phone,
                ORDER_CONTACT_TEL2 = contact_o_phone,
                ORDER_CONTACT_MOBIL = contact_mobile,
                ORDER_CONTACT_EMAIL = contact_email,
                ORDER_CONTACT_FAX = null,
                ORDER_CONTACT_ADDRESS = null,
                ORDER_NOTE = order_note,
                ORDER_INV_ID = company_title,
                ORDER_INV_NO = uniform_numbers,
                ORDER_INV_RECEIVER = recipients,
                ORDER_INV_ADDRESS = recipients_address,
                ORDER_INV_TYPE = "1",
                ORDER_TAKE_TYPE = null,
                ORDER_MAIL_RECEIVER = registered,
                ORDER_MAIL_ADDRESS = registered_address,
                ORDER_CREATOR = null,
                PROD_NO = prod_no_hidden,
                GRP_NO = grp_no_hidden,
                ORDER_CUS = cus_itemlist

            };

           // JavaScriptSerializer Serializer = new JavaScriptSerializer();
          //  Response.Write(Serializer.Serialize(OrderGrpCreate_postData) + "<br/>");


            var ordergrpcreate_source = await api.OrderGrpCreate_api(OrderGrpCreate_postData);
         //   Response.Write("********************************" + "<br/>");
          //  Response.Write("ordergrpcreate_source.rCode:" + ordergrpcreate_source.rCode + "<br/>");
           // Response.Write("ordergrpcreate_source.rCodeDesc:" + ordergrpcreate_source.rCodeDesc + "<br/>");


            if (ordergrpcreate_source.rCode.Equals("0001"))
            {
                //Response.Write("訂購成功" + "<br/>");
                //Response.Write("訂單標號為:" + ordergrpcreate_source.Data.ORDER_NO + "<br/>");
                return RedirectToAction("Index", "Step3", new { order_number = ordergrpcreate_source.Data.ORDER_NO, member_number = member_no_hidden });

            }else
            {
                return View();
            }


           
        }

	}
}