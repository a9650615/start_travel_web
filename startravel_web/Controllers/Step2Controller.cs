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
             string view_prod_no_s = "IGRP000011159";
             string view_grp_no_s = "TYO05ITC0717T";
             string room_count_name_s="1,1,0,0,0,0";
            string psub_list = "";
            string visa_list =  "";
            string insu_list = "";
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
                    if (visa_count==0)
                    {
                       visa_list = i.ToString();
                    }else
                    {
                        visa_list =visa_list+","+i.ToString();
                    }
                    visa_count = visa_count + 1;
                }
                else if (name_num.Equals("PSUB"))
                {
                    if (pusb_count==0)
                    { 
                      psub_list = i.ToString();
                    }else
                    {
                       psub_list =psub_list+","+i.ToString();
                    }
                    pusb_count = pusb_count + 1;
                }
                else if (name_num.Equals("INSU"))
                {
                    if (insu_count==0)
                    { 
                      insu_list = i.ToString();
                    }
                    else
                    {
                        insu_list = insu_list+","+i.ToString();
                    }
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
                                 insu_count=insu_count,
                                 member_number=member_number_s
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

                    string psub_list = "";
                    string visa_list = "";
                    string insu_list = "";
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
                            if (visa_count == 0)
                            {
                                visa_list = i.ToString();
                            }
                            else
                            {
                                visa_list = visa_list + "," + i.ToString();
                            }
                            visa_count = visa_count + 1;
                        }
                        else if (name_num.Equals("PSUB"))
                        {
                            if (pusb_count == 0)
                            {
                                psub_list = i.ToString();
                            }
                            else
                            {
                                psub_list = psub_list + "," + i.ToString();
                            }
                            pusb_count = pusb_count + 1;
                        }
                        else if (name_num.Equals("INSU"))
                        {
                            if (insu_count == 0)
                            {
                                insu_list = i.ToString();
                            }
                            else
                            {
                                insu_list = insu_list + "," + i.ToString();
                            }
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
                        insu_count = insu_count,
                        member_number=member_number_s
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

            public async Task<ActionResult> test(
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

                Response.Write("***********連絡人資料*********"  + "<br/>");
                Response.Write("contact_c_first_name：" + contact_c_first_name + "<br/>");
                Response.Write("contact_c_last_name：" + contact_c_last_name + "<br/>");
                Response.Write("contact_mobile：" + contact_mobile + "<br/>");
                Response.Write("contact_h_phone：" + contact_h_phone + "<br/>");
                Response.Write("contact_o_phone：" + contact_o_phone + "<br/>");
                Response.Write("contact_email：" + contact_email + "<br/>");
                Response.Write("contact_time：" + contact_time + "<br/>");
                Response.Write("contact_note：" + contact_note + "<br/>");
                Response.Write("***********旅客人資料*********" + "<br/>");
                Response.Write("passengerInfo_first_c_name_array：" +passengerInfo_first_c_name_array +"<br/>");
                Response.Write("passengerInfo_last_c_name_array：" +passengerInfo_last_c_name_array + "<br/>");
                Response.Write("passengerInfo_first_e_name_array：" + passengerInfo_first_e_name_array + "<br/>");
                Response.Write("passengerInfo_last_e_name_array：" +passengerInfo_last_e_name_array + "<br/>");
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
                Response.Write("insu_array_hidden：" + insu_array_hidden + "<br/>");

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

                Response.Write("total_prod_sub_s：" + total_prod_sub_s + "<br/>");


                //string[] cus_total_prod_correspond_list= new string[int.Parse(total_people_hidden)];
                //string[] pusb_correspond_count_list = pusb_array_hidden.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                //string[] visa_correspond_count_list = visa_array_hidden.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string[] total_correspond_count_list = total_prod_sub_s.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);





                    //build prod_sub_array
                    Response.Write("***********build  prod_sub_itemlist*********" + "<br/>");
               
              
                  string[] cus_prod_sub_count_list = new string[int.Parse(total_people_hidden)];
                  string[] cus_prod_sub_array = passengerInfo_prod_sub_array.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                  for (int i = 0; i < int.Parse(total_people_hidden);i=i+1 )
                  {
                      for(int j=0;j< total_prod_sub_number;j=j+1)
                      {
                          if(j==0)
                          {
                              cus_prod_sub_count_list[i] = cus_prod_sub_array[i * total_prod_sub_number+j];
                          }else
                          {
                              cus_prod_sub_count_list[i] = cus_prod_sub_count_list[i]+","+cus_prod_sub_array[i * total_prod_sub_number+j];
                          }                   
                       }
                  }

                 // Response.Write("cus_prod_sub_count_list0：" + cus_prod_sub_count_list[0] + "<br/>");

                 //  Response.Write("cus_prod_sub_count_list1：" + cus_prod_sub_count_list[1] + "<br/>");

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


                  Response.Write("***********build  cus_itemlist*********" + "<br/>");
               // 
                 List<OrderGrpCreateCusModel_param> cus_itemlist = new List<OrderGrpCreateCusModel_param>();

                for (int i = 0; i < int.Parse(total_people_hidden);i=i+1 )
                {

                    List<OrderGrpCreateProdSubModel_param> prod_sub_itemlist = new List<OrderGrpCreateProdSubModel_param>();
                    //string[] everyone_cus_prod_sub_count_list = new string[int.Parse(total_prod_sub_number)];
                    string[] everyone_cus_prod_sub_array =  cus_prod_sub_count_list[i] .ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);


                    for (int j = 0; j < total_prod_sub_number;j=j+1 )
                    {
                        if( int.Parse(everyone_cus_prod_sub_array[j])!=0)
                        {
                            prod_sub_itemlist.Add(new OrderGrpCreateProdSubModel_param 
                                {
                                   PROD_SUB_NO=grpaddpurchase_source.Data[int.Parse(total_correspond_count_list[j])].prod_SUB_NO,
                                   PROD_SUB_QTY="1"
                                
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
                            ROOM_COND = "0001",
                            ORDER_PROD_SUB = prod_sub_itemlist

                        });
                }


                //final contact data

                OrderGrpCreate_PostData OrderGrpCreate_postData = new OrderGrpCreate_PostData() 
                { 
                     ORDER_SALES=null,
                     ORDER_CONTACT_NO =member_no_hidden,
                     ORDER_CONTACT_TYPE =null,
                     ORDER_CONTACT_NAME =contact_c_first_name+""+contact_c_last_name,
                     ORDER_CONTACT_ID = "A180352504",
                     ORDER_CONTACT_TEL1 =contact_h_phone,
                     ORDER_CONTACT_TEL2 =contact_o_phone,
                     ORDER_CONTACT_MOBIL = contact_mobile,
                     ORDER_CONTACT_EMAIL =contact_email,
                     ORDER_CONTACT_FAX =null,
                     ORDER_CONTACT_ADDRESS =null,
                     ORDER_NOTE =order_note,
                     ORDER_INV_ID =company_title,
                     ORDER_INV_NO =uniform_numbers,
                     ORDER_INV_RECEIVER =recipients,
                     ORDER_INV_ADDRESS  =recipients_address,
                     ORDER_INV_TYPE = "1",
                     ORDER_TAKE_TYPE=null,
                     ORDER_MAIL_RECEIVER =registered,
                     ORDER_MAIL_ADDRESS =registered_address,
                     ORDER_CREATOR =null,
                     PROD_NO =prod_no_hidden,
                     GRP_NO =grp_no_hidden,
                      ORDER_CUS =cus_itemlist
                               
                };

                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                Response.Write(Serializer.Serialize(OrderGrpCreate_postData) + "<br/>");   


                var ordergrpcreate_source = await api.OrderGrpCreate_api(OrderGrpCreate_postData);
                Response.Write("********************************" + "<br/>");
                Response.Write("ordergrpcreate_source.rCode:" + ordergrpcreate_source.rCode + "<br/>");
                Response.Write("ordergrpcreate_source.rCodeDesc:" + ordergrpcreate_source.rCodeDesc + "<br/>");


                if(ordergrpcreate_source.rCode.Equals("0001"))
                {
                    Response.Write("訂購成功" + "<br/>");
                    Response.Write("訂單標號為:" + ordergrpcreate_source.Data.ORDER_NO + "<br/>");
                }

                //Response.ContentType = "application/json";
                //將資料序列化為JSON格式並輸出
               // JavaScriptSerializer Serializer = new JavaScriptSerializer();
                //Response.Write(Serializer.Serialize(OrderGrpCreate_postData));   


                    return View();
            }
 
	}
}