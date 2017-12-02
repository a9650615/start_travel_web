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
    public class Step2Controller : Controller
    {
        //
        // GET: /Step2/
        public async Task<ActionResult> Index(string member_number, string room_count_name, string view_grp_no, string view_prod_no)
        {
           // Response.Write("user_name：" + user_name + "<br/>");
           /* Response.Write("member_number：" + member_number + "<br/>");
            Response.Write("view_grp_no：" + view_grp_no + "<br/>");
            Response.Write("view_prod_no：" + view_prod_no + "<br/>");
            Response.Write("room_count_name：" + room_count_name + "<br/>");*/

            /*string member_number_s = member_number;
            string view_prod_no_s = view_prod_no;
            string view_grp_no_s = view_grp_no;
            string room_count_name_s = room_count_name;*/


             string member_number_s = "MEM0000000028";
             string view_prod_no_s = "IGRP000017364";
             string view_grp_no_s = "OKA04ITC1417A";
             string room_count_name_s="1,1,0,0,0";
            string[] psub_list = new string[7];
            string[] visa_list = new string[7];
            string[] insu_list = new string[7];
            int pusb_count = 0;
            int visa_count = 0;
            int insu_count = 0;

            ApiController api = new ApiController();

            LoginVerify_PostData loginverify_postData = new LoginVerify_PostData() { ID_NO = "T111111111", password = "test999" };
            var loginverify_source = await api.LoginVerify_api(loginverify_postData);
            
            GRPProductDetail_PostData grpproductdetail_postData = new GRPProductDetail_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };
            IGRPTrafficInfo_PostData igrptrafficinfo_postData = new IGRPTrafficInfo_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };
            GRPPriceInfo_PostData grppriceinfo_postData = new GRPPriceInfo_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };
            PassengerContacts_get_PostData passengercontacts_postData = new PassengerContacts_get_PostData() { member_no = member_number_s };
            GRPAddPurchase_PostData grpaddpurchase_postData = new GRPAddPurchase_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };


            var grpsource = await api.GRPProductDetail_api(grpproductdetail_postData);
            var igrptrafficinfo_source = await api.IGRPTrafficInfo_api(igrptrafficinfo_postData);
            var grppriceinfo_source = await api.GRPPriceInfo_api(grppriceinfo_postData);
            //var passengercontacts_source = await api.PassengerContacts_get_api(passengercontacts_postData);
            var passengercontacts_source = await api.PassengerContacts_get_api(passengercontacts_postData);
            var grpaddpurchase_source = await api.GRPAddPurchase_api(grpaddpurchase_postData);
           // Response.Write("0：" + passengercontacts_source + "<br/>");
            var orderstore_source = await api.OrderStore_api();


            for (int i=0; i < grpaddpurchase_source.Data.Count;i=i+1 )
            {
                var item = grpaddpurchase_source.Data[i];
                string name_num = item.prod_SUB_NO.Substring(0,4);
                if (name_num.Equals("VISA"))
                {
                    visa_list[visa_count] = i.ToString();
                    visa_count = visa_count + 1;
                }
                else if (name_num.Equals("PSUB"))
                {
                    psub_list[pusb_count] = i.ToString();
                    pusb_count = pusb_count + 1;
                }
                else if (name_num.Equals("INSU"))
                {
                    insu_list[insu_count] = i.ToString();
                    insu_count = insu_count + 1;
                }
                
            }

            string ary_member_info = loginverify_source.Data.MEMBER_NAME + "," + loginverify_source.Data.EMAIL;

            step2_view_return_data step2_view_data = new step2_view_return_data {
                                 grpproductdetail_result = grpsource,
                                 igrptrafficinfo_result = igrptrafficinfo_source,
                                 grppriceinfo_result = grppriceinfo_source,
                                 room_count = room_count_name_s,
                                 grpaddpurchase_result = grpaddpurchase_source,
                                 passengercontacts_get_result=passengercontacts_source,
                                 orderstore_result=orderstore_source,
                                 member_info = ary_member_info,
                                 visa_list = visa_list,
                                 psub_list = psub_list,
                                 insu_list = insu_list,
                                 visa_count = visa_count,
                                 pusb_count = pusb_count,
                                 insu_count=insu_count
                                 };


            //=====build passenget list item
            List<SelectListItem> passenget_item=new  List<SelectListItem>();
            for (int j = 0; j < passengercontacts_source.Data.Count;j=j+1 )
            {
                var item = passengercontacts_source.Data[j];
                string birthday_s=item.BIRTHDAY;
                if (!(birthday_s==null))
                {
                    DateTime p_birthday_s = DateTime.ParseExact(item.BIRTHDAY.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    item.BIRTHDAY = p_birthday_s.ToString("yyyy/MM/dd");
                }
           

                //Response.Write(j.ToString() + ": " + item.BIRTHDAY + "<br/>");
                passenget_item.Add(new SelectListItem() {

                    Text = item.NAME_C_FIRST + item.NAME_C_LAST,
                    Value=j.ToString()
                
                });
                
                //var item = passengercontacts_source.Data[j];
                //Response.Write(j.ToString() + ": " + item.ID_NO + "<br/>");
             }


            ViewBag.CategoryItems = passenget_item;

            //=====build passenget list item

            //=====build stroe list item
            List<SelectListItem> store_item = new List<SelectListItem>();
            for (int k = 0; k < orderstore_source.Data.Count; k = k + 1)
            {
                var item = orderstore_source.Data[k];
               
          
                //Response.Write(j.ToString() + ": " + item.BIRTHDAY + "<br/>");
                store_item.Add(new SelectListItem()
                {

                    Text = item.Dept_Region + "   " + item.Dept_Name,
                    Value = k.ToString()

                });
            }

            ViewBag.Selectstore = store_item;
            /*string[] strs = room_count_name.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);*/
          /*  for (int j = 0; j < passengercontacts_source.Data.Count;j=j+1 )
            {
                var item = passengercontacts_source.Data[j];
                Response.Write(j.ToString() + ": " + item.ID_NO + "<br/>");
             }*/
             
           // Response.Write("1：" + passengercontacts_source.Data[1].ID_NO + "<br/>");
            //Response.Write("2：" + passengercontacts_source.Data[2].ID_NO + "<br/>");
           // Response.Write("3：" + passengercontacts_source.Data[3].ID_NO + "<br/>");
           // Response.Write("4：" + passengercontacts_source.Data[4].ID_NO + "<br/>");
          //  Response.Write("5：" + passengercontacts_source.Data[5].ID_NO + "<br/>");
                // room_count_name.Split
                return View(step2_view_data);
        }

        [HttpPost]
        public async Task<ActionResult> Index(step1_view_return_data data, string user_name, string user_passwd, string room_count_name)
        {
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
                
                if (loginverify_source.rCode.Equals("0001"))
                {
                    string member_number = loginverify_source.Data.MEMBER_NO;
                   // TempData["message"] = "登入成功";
                    string member_number_s = member_number;
                    string view_prod_no_s = view_prod_no;
                    string view_grp_no_s = view_grp_no;
                    string room_count_name_s = room_count_name;

                    string[] psub_list = new string[7];
                    string[] visa_list = new string[7];
                    string[] insu_list = new string[7];
                    int pusb_count = 0;
                    int visa_count = 0;
                    int insu_count = 0;



                    ///Session
                   // Session.Add("user_name", loginverify_source.Data.MEMBER_NAME);

                    //ClientScript.RegisterClientScriptBlock(typeof(Default8), "SessionValue", String.Format("<script>var SessionValue='{0}';</script>", Session["AAA"])); 

                    // ApiController api = new ApiController();
                    GRPProductDetail_PostData grpproductdetail_postData = new GRPProductDetail_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };
                    IGRPTrafficInfo_PostData igrptrafficinfo_postData = new IGRPTrafficInfo_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };
                    GRPPriceInfo_PostData grppriceinfo_postData = new GRPPriceInfo_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };
                    PassengerContacts_get_PostData passengercontacts_postData = new PassengerContacts_get_PostData() { member_no = member_number_s };
                    GRPAddPurchase_PostData grpaddpurchase_postData = new GRPAddPurchase_PostData() { prod_no = view_prod_no_s, grp_no = view_grp_no_s };


                    var grpsource = await api.GRPProductDetail_api(grpproductdetail_postData);
                    var igrptrafficinfo_source = await api.IGRPTrafficInfo_api(igrptrafficinfo_postData);
                    var grppriceinfo_source = await api.GRPPriceInfo_api(grppriceinfo_postData);
                    //var passengercontacts_source = await api.PassengerContacts_get_api(passengercontacts_postData);
                    var passengercontacts_source = await api.PassengerContacts_get_api(passengercontacts_postData);
                    var grpaddpurchase_source = await api.GRPAddPurchase_api(grpaddpurchase_postData);
                    // Response.Write("0：" + passengercontacts_source + "<br/>");
                    var orderstore_source = await api.OrderStore_api();


                    for (int i = 0; i < grpaddpurchase_source.Data.Count; i = i + 1)
                    {
                        var item = grpaddpurchase_source.Data[i];
                        string name_num = item.prod_SUB_NO.Substring(0, 4);
                        if (name_num.Equals("VISA"))
                        {
                            visa_list[visa_count] = i.ToString();
                            visa_count = visa_count + 1;
                        }
                        else if (name_num.Equals("PSUB"))
                        {
                            psub_list[pusb_count] = i.ToString();
                            pusb_count = pusb_count + 1;
                        }
                        else if (name_num.Equals("INSU"))
                        {
                            insu_list[insu_count] = i.ToString();
                            insu_count = insu_count + 1;
                        }

                    }

                    string ary_member_info = loginverify_source.Data.MEMBER_NAME + "," + loginverify_source.Data.EMAIL;


                    step2_view_return_data step2_view_data = new step2_view_return_data
                    {
                        grpproductdetail_result = grpsource,
                        igrptrafficinfo_result = igrptrafficinfo_source,
                        grppriceinfo_result = grppriceinfo_source,
                        room_count = room_count_name_s,
                        grpaddpurchase_result = grpaddpurchase_source,
                        passengercontacts_get_result = passengercontacts_source,
                        orderstore_result = orderstore_source,
                        //loginverify_result=loginverify_source,
                        member_info=ary_member_info,
                        visa_list = visa_list,
                        psub_list = psub_list,
                        insu_list = insu_list,
                        visa_count = visa_count,
                        pusb_count = pusb_count,
                        insu_count = insu_count
                    };

                    //=====create memberInfo
                    

                    

                    //=====build passenget list item
                    List<SelectListItem> passenget_item = new List<SelectListItem>();
                    for (int j = 0; j < passengercontacts_source.Data.Count; j = j + 1)
                    {
                        var item = passengercontacts_source.Data[j];
                        string birthday_s = item.BIRTHDAY;
                        if (!(birthday_s == null))
                        {
                            DateTime p_birthday_s = DateTime.ParseExact(item.BIRTHDAY.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            item.BIRTHDAY = p_birthday_s.ToString("yyyy/MM/dd");
                        }


                        //Response.Write(j.ToString() + ": " + item.BIRTHDAY + "<br/>");
                        passenget_item.Add(new SelectListItem()
                        {

                            Text = item.NAME_C_FIRST + item.NAME_C_LAST,
                            Value = j.ToString()

                        });

                        //var item = passengercontacts_source.Data[j];
                        //Response.Write(j.ToString() + ": " + item.ID_NO + "<br/>");
                    }


                    ViewBag.CategoryItems = passenget_item;

                    //=====build passenget list item

                    //=====build stroe list item
                    List<SelectListItem> store_item = new List<SelectListItem>();
                    for (int k = 0; k < orderstore_source.Data.Count; k = k + 1)
                    {
                        var item = orderstore_source.Data[k];


                        //Response.Write(j.ToString() + ": " + item.BIRTHDAY + "<br/>");
                        store_item.Add(new SelectListItem()
                        {

                            Text = item.Dept_Region + "   " + item.Dept_Name,
                            Value = k.ToString()

                        });
                    }

                    ViewBag.Selectstore = store_item;
                    /*string[] strs = room_count_name.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);*/
                    /*  for (int j = 0; j < passengercontacts_source.Data.Count;j=j+1 )
                      {
                          var item = passengercontacts_source.Data[j];
                          Response.Write(j.ToString() + ": " + item.ID_NO + "<br/>");
                       }*/

                    // Response.Write("1：" + passengercontacts_source.Data[1].ID_NO + "<br/>");
                    //Response.Write("2：" + passengercontacts_source.Data[2].ID_NO + "<br/>");
                    // Response.Write("3：" + passengercontacts_source.Data[3].ID_NO + "<br/>");
                    // Response.Write("4：" + passengercontacts_source.Data[4].ID_NO + "<br/>");
                    //  Response.Write("5：" + passengercontacts_source.Data[5].ID_NO + "<br/>");
                    // room_count_name.Split
                    return View(step2_view_data);

                    // return RedirectToAction("Index", "Step2", new { view_prod_no = view_prod_no, view_grp_no = view_grp_no, room_count_name = room_count_name, member_number = member_number });
                }
                else
                {
                    TempData["message"] = "帳號或密碼輸入錯誤";
                    return RedirectToAction("Index", "Step1", new { prod_no = view_prod_no, grp_no = view_grp_no });
                }
           
            }
           }

            public ActionResult test(
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
                                            string passengerInfo_prod_sub_array

                )
            {

                Response.Write("contact_c_first_name：" + contact_c_first_name + "<br/>");
                Response.Write("contact_c_last_name：" + contact_c_last_name + "<br/>");
                Response.Write("contact_mobile：" + contact_mobile + "<br/>");
                Response.Write("contact_h_phone：" + contact_h_phone + "<br/>");
                Response.Write("contact_o_phone：" + contact_o_phone + "<br/>");
                Response.Write("contact_email：" + contact_email + "<br/>");
                Response.Write("contact_time：" + contact_time + "<br/>");
                Response.Write("contact_note：" + contact_note + "<br/>");
                Response.Write("passengerInfo_first_c_name_array：" +passengerInfo_first_c_name_array +"<br/>");
                Response.Write("passengerInfo_last_c_name_array：" +passengerInfo_last_c_name_array + "<br/>");
                Response.Write("passengerInfo_first_e_name_array：" + passengerInfo_first_e_name_array + "<br/>");
                Response.Write("passengerInfo_last_e_name_array：" +passengerInfo_last_e_name_array + "<br/>");
                Response.Write("passengerInfo_sex_array：" + passengerInfo_sex_array + "<br/>");
                Response.Write("passengerInfo_id_array：" + passengerInfo_id_array + "<br/>");
                Response.Write("passengerInfo_birthday_array：" + passengerInfo_birthday_array + "<br/>");
                Response.Write("passengerInfo_food_array：" + passengerInfo_food_array + "<br/>");
                Response.Write("passengerInfo_prod_sub_array：" + passengerInfo_prod_sub_array + "<br/>");
          
          
          
            
                return View();
            }
 
	}
}