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
    public class ListController : Controller
    {
        //
        // GET: /List/

        public async Task<ActionResult> Index(string CITY_TO, string TravelRegion, string CITY_FROM, string tourday, string CurrentPage, string PageSize, string S_DATE_S, string S_DATE_E, string S_TIME_S, string S_TIME_E, string E_TIME_S, string E_TIME_E, string TravelKind, string travel_type, string order_type, string Departure)
        {
            
            ApiController api = new ApiController();


            string view_CITY_TO;
            string view_TRAVEL_REGION ;
            string view_CITY_FROM;
            string view_tourday;
            int view_CurrentPage;
            int view_PageSize;
            string view_S_DATE_S;
            string view_S_DATE_E;
            string view_S_TIME_S ;
            string view_S_TIME_E;
            string view_E_TIME_S;
            string view_E_TIME_E ;
            int view_TravelKind ;
            string view_travel_type;
            string view_order_type;
            int view_Departure ;
            string view_CITY_TO_NAME="";
            string view_CITY_FROM_NAME="";


            if (string.IsNullOrWhiteSpace(CITY_FROM))
            {
                 view_CITY_FROM = "TPE";
            }
            else
            {
                 view_CITY_FROM = CITY_FROM;
            }


            if (string.IsNullOrWhiteSpace(CITY_TO))
            {
                if(string.IsNullOrWhiteSpace(TravelRegion))
                {
                    view_TRAVEL_REGION = "JP";
                    view_CITY_TO = "";
                }
                else
                {
                    view_TRAVEL_REGION = TravelRegion;
                    view_CITY_TO = "";
                }
            }
            else
            {
                view_CITY_TO = CITY_TO;
                view_TRAVEL_REGION = "";
            }


            if(string.IsNullOrWhiteSpace(tourday))
            {
                view_tourday = "GE1";
            }
            else
            {
                view_tourday = tourday;
            }


            if (string.IsNullOrWhiteSpace(CurrentPage))
            {
                view_CurrentPage = 1;
            }
            else
            {
                view_CurrentPage = int.Parse(CurrentPage); ;
            }


            if (string.IsNullOrWhiteSpace(PageSize))
            {
                view_PageSize = 5;
            }
            else
            {
                view_PageSize = int.Parse(PageSize); ;
            }

            if (string.IsNullOrWhiteSpace(S_DATE_S))
            {
                string current_date = DateTime.Now.ToString("yyyyMMdd");
             //  string  current_date = "20171001";
                view_S_DATE_S = current_date;
            }
            else
            {
                view_S_DATE_S = S_DATE_S;
            }

            if (string.IsNullOrWhiteSpace(S_DATE_E))
            {
                string current_date = DateTime.Now.ToString("yyyyMMdd");
                DateTime current_date_d = DateTime.ParseExact(current_date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                current_date_d = current_date_d.AddDays(30);
                view_S_DATE_E = current_date_d.ToString("yyyyMMdd");
               // string current_date_d = "20171230";
                //view_S_DATE_E = current_date_d;

            }
            else
            {
                view_S_DATE_E = S_DATE_E;
            }

            if (string.IsNullOrWhiteSpace(S_TIME_S))
            {

                view_S_TIME_S = "000000";

            }
            else
            {
                
                view_S_TIME_S = S_TIME_S;
            }

            if (string.IsNullOrWhiteSpace(S_TIME_E))
            {

                view_S_TIME_E = "235900";

            }
            else
            {
                view_S_TIME_E = S_TIME_E;
            }

            if (string.IsNullOrWhiteSpace(E_TIME_S))
            {

                view_E_TIME_S = "000000";

            }
            else
            {
                view_E_TIME_S = E_TIME_S;
            }

            if (string.IsNullOrWhiteSpace(E_TIME_E))
            {

                view_E_TIME_E = "235900";

            }
            else
            {
                view_E_TIME_E = E_TIME_E;
            }


            if (string.IsNullOrWhiteSpace(TravelKind))
            {

                view_TravelKind =0;

            }
            else
            {
                view_TravelKind = int.Parse(TravelKind);
            }


            if (string.IsNullOrWhiteSpace(travel_type))
            {

                view_travel_type = "IGRP";

            }
            else
            {
                view_travel_type = travel_type;
            }

            if (string.IsNullOrWhiteSpace(order_type))
            {

                view_order_type = "PriceInc";

            }
            else
            {
                view_order_type = order_type;
            }

            if (string.IsNullOrWhiteSpace(Departure))
            {

                view_Departure = 0;

            }
            else
            {
                view_Departure = int.Parse(Departure);
            }


            if (view_S_TIME_S.Equals("000000") && view_S_TIME_E.Equals("235900"))
            {
                view_S_TIME_S = "";
                view_S_TIME_E = "";
            }

            if (view_E_TIME_S.Equals("000000") && view_E_TIME_E.Equals("235900"))
            {
                view_E_TIME_S = "";
                view_E_TIME_E = "";
            }
          


          /*  string current_date_test = DateTime.Now.ToString("yyyyMM");
            //string current_date = DateTime.Now.ToString("yyyyMMdd");
            DateTime current_date_d_test = DateTime.ParseExact(current_date_test, "yyyyMM", System.Globalization.CultureInfo.InvariantCulture);
            current_date_d_test = current_date_d_test.AddMonths(1);
            string next_date = current_date_d_test.ToString("yyyyMM");

            Response.Write("view_search_stime_s：" + current_date_test + "<br/>");
            Response.Write("view_search_stime_e：" + next_date + "<br/>");*/

            /*string view_CITY_TO="BKK";
            string view_TRAVEL_REGION = "";
            string view_CITY_FROM="TPE";
            string view_tourday="GE1";
            int view_CurrentPage=1;
            int view_PageSize=5;
            string view_S_DATE_S="20171001";
            string view_S_DATE_E="20180930";
            string view_S_TIME_S="100000";
            string view_S_TIME_E="210000";
            string view_E_TIME_S="010000";
            string view_E_TIME_E="210000";
            int view_TravelKind= 1;
            string view_travel_type="IGRP";
            string view_order_type = "PriceInc";
            int view_Departure = 0;*/

            GRPList_PostData grplist_postData = new GRPList_PostData() {
                                                                         CITY_TO = view_CITY_TO, 
                                                                         TravelRegion=view_TRAVEL_REGION,
                                                                         CITY_FROM = view_CITY_FROM,
                                                                         tourday = view_tourday,
                                                                         CurrentPage = view_CurrentPage, 
                                                                         PageSize = view_PageSize,
                                                                         S_DATE_S = view_S_DATE_S,
                                                                         S_DATE_E = view_S_DATE_E,
                                                                         S_TIME_S = view_S_TIME_S,
                                                                         S_TIME_E = view_S_TIME_E,
                                                                         E_TIME_S = view_E_TIME_S,
                                                                         E_TIME_E = view_E_TIME_E,
                                                                         TravelKind = view_TravelKind,
                                                                         travel_type = view_travel_type,
                                                                         order_type = view_order_type,
                                                                         Departure = view_Departure
            };

            GRPDepartureList_PostData grpdeparturelist_postdata = new GRPDepartureList_PostData() { Depart_SDate = view_S_DATE_S, Depart_EDate = view_S_DATE_E };

            var grplist_source = await api.GRPList_api(grplist_postData);
            var igrptravelregion_source = await api.IGRPTravelRegion_api();
            var grpdeparturelist_source = await api.GRPDepartureList_api(grpdeparturelist_postdata);


       


            //=====build grpdeparturelist list item
            List<SelectListItem> grpdeparturelist_item = new List<SelectListItem>();
            for (int i = 0; i < grpdeparturelist_source.Data.Count; i = i + 1)
            {
                var item_departure = grpdeparturelist_source.Data[i];

                if (item_departure.CITY_FROM.Equals(view_CITY_FROM))
                {
                    view_CITY_FROM_NAME = item_departure.SC_NAME;
                }


              grpdeparturelist_item.Add(new SelectListItem()
                   {
                    Text = item_departure.SC_NAME,
                     Value = item_departure.CITY_FROM,
                    Selected = item_departure.CITY_FROM.Equals(view_CITY_FROM)
                });
            
            }
            ViewBag.departurelistItems = grpdeparturelist_item;


            //=====build grptravelregion list item

            List<SelectListItem> grptravelregion_item = new List<SelectListItem>();

            for (int i = 0; i < igrptravelregion_source.Data.Count; i = i + 1)
            {
                var item_cat1 = igrptravelregion_source.Data[i];

                if (item_cat1.Cat1Code.Equals(view_TRAVEL_REGION))
                {
                    view_CITY_TO_NAME = item_cat1.Cat1Name;
                }

                grptravelregion_item.Add(new SelectListItem()
                {

                    Text = item_cat1.Cat1Name,
                    Value = item_cat1.Cat1Code,
                    Selected = item_cat1.Cat1Code.Equals(view_TRAVEL_REGION)

                });


                for (int j = 0; j < item_cat1.Cat2List.Count; j = j + 1)
                {
                    var item_cat2 = item_cat1.Cat2List[j];

                    if (item_cat2.Cat2Code.Equals(view_TRAVEL_REGION))
                    {
                        view_CITY_TO_NAME = item_cat2.Cat2Name;
                    }


                    grptravelregion_item.Add(new SelectListItem()
                    {

                        Text = "　"+ item_cat2.Cat2Name,
                        Value = item_cat2.Cat2Code,
                        Selected = item_cat2.Cat2Code.Equals(view_TRAVEL_REGION)

                    });
                }
            }

            ViewBag.grptravelregionlistItems = grptravelregion_item;
            //=====build grptravelregion list item

            list_view_return_data list_view_data = new list_view_return_data { grplist_result = grplist_source, grplist_postdata = grplist_postData, igrptravelregion_result = igrptravelregion_source, city_from_name = view_CITY_FROM_NAME, city_to_name = view_CITY_TO_NAME };

            return View(list_view_data);
        


          

        }

        [HttpPost]
        public ActionResult re_search(string search_city_from, string search_city_to, string search_choose_date_s, string search_choose_date_e, string search_travelkind, string search_tour_day, string search_stime_s, string search_stime_e, string search_etime_s, string search_etime_e, string search_is_ensure, string order_type_1, string research_page, string which_button, string final_prod, string final_grp, string search_city_from_name, string search_city_to_name,string window_open )
        {
            string view_search_city_from = search_city_from;
            string view_search_city_to = search_city_to;
            string view_search_city_from_name = search_city_from_name;
            string view_search_city_to_name = search_city_to_name;

            string view_search_choose_date_s = search_choose_date_s.Substring(0,10);
            string view_search_choose_date_e = search_choose_date_e.Substring(0,10);
            string view_search_travelkind = search_travelkind;
            string view_search_tour_day = search_tour_day;
            string view_search_stime_s = search_stime_s;
            string view_search_stime_e = search_stime_e;
            string view_search_etime_s = search_etime_s;
            string view_search_etime_e = search_etime_e;
            string view_currentpage = research_page;
            string view_pagesize="5";
            string view_travel_type="IGRP";
            string view_order_type = order_type_1;
            string view_departure=search_is_ensure;
            string view_which_button = which_button;
            string view_final_prod = final_prod;
            string view_final_grp = final_grp;
            string view_window_open = window_open;

           /* Response.Write("view_search_stime_s：" + view_search_stime_s + "<br/>");
            Response.Write("view_search_stime_e：" + view_search_stime_e + "<br/>");
            Response.Write("view_search_etime_s：" + view_search_etime_s + "<br/>");
            Response.Write("view_search_etime_e：" + view_search_etime_e + "<br/>");*/

           DateTime view_search_choose_date_s_d = DateTime.ParseExact(view_search_choose_date_s, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
           DateTime view_search_choose_date_e_d = DateTime.ParseExact(view_search_choose_date_e, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);

            DateTime view_search_stime_s_d = DateTime.ParseExact(view_search_stime_s, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime view_search_stime_e_d = DateTime.ParseExact(view_search_stime_e, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime view_search_etime_s_d = DateTime.ParseExact(view_search_etime_s, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime view_search_etime_e_d = DateTime.ParseExact(view_search_etime_e, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);


           

           /* Response.Write("view_departure：" + view_departure + "<br/>");
            Response.Write("search_city_from：" + search_city_from + "<br/>");
            Response.Write("search_city_to：" + search_city_to + "<br/>");
            Response.Write("view_search_choose_date_s_d：" + view_search_choose_date_s_d.ToString() + "<br/>");
            Response.Write("view_search_choose_date_e_d：" + view_search_choose_date_e_d.ToString() + "<br/>");

            Response.Write("search_travelkind：" + search_travelkind + "<br/>");
            Response.Write("search_tour_day：" + search_tour_day + "<br/>");
            Response.Write("view_search_stime_s_d：" + view_search_stime_s_d.ToString("HHmmss") + "<br/>");
            Response.Write("view_search_stime_e_d：" + view_search_stime_e_d.ToString("HHmmss") + "<br/>");
            Response.Write("view_search_etime_s_d：" + view_search_etime_s_d.ToString("HHmmss") + "<br/>");
            Response.Write("view_search_etime_e_d：" + view_search_etime_e_d.ToString("HHmmss") + "<br/>");
            Response.Write("view_currentpage：" + view_currentpage + "<br/>");
            Response.Write("view_order_type：" + view_order_type + "<br/>");

            Response.Write("view_which_button：" + view_which_button + "<br/>");
            Response.Write("view_final_prod：" + final_prod + "<br/>");
            Response.Write("view_final_grp：" + final_grp + "<br/>");*/


            ///  0: order,page  1: detail  2:reserch

            if (view_which_button.Equals("0"))
            {
                return RedirectToAction("Index", "List", new { CITY_TO = "", TravelRegion = view_search_city_to, CITY_FROM = view_search_city_from, tourday = view_search_tour_day, CurrentPage = view_currentpage, PageSize = view_pagesize, S_DATE_S = view_search_choose_date_s_d.ToString("yyyyMMdd"), S_DATE_E = view_search_choose_date_e_d.ToString("yyyyMMdd"), S_TIME_S = view_search_stime_s_d.ToString("HHmmss"), S_TIME_E = view_search_stime_e_d.ToString("HHmmss"), E_TIME_S = view_search_etime_s_d.ToString("HHmmss"), E_TIME_E = view_search_etime_e_d.ToString("HHmmss"), TravelKind = search_travelkind, travel_type = view_travel_type, order_type = view_order_type, Departure = view_departure, CITY_TO_NMAE = view_search_city_to_name, CITY_FROM_NMAE = view_search_city_from_name });
            }
            else if (view_which_button.Equals("1"))
            {
                return RedirectToAction("Index", "Detail", new { prod_no = view_final_prod, grp_no = view_final_grp,window_open=view_window_open });
            }
            else
            {
                return RedirectToAction("Index", "List", new { CITY_TO = "", TravelRegion = view_search_city_to, CITY_FROM = view_search_city_from, tourday = view_search_tour_day, CurrentPage = "1", PageSize = view_pagesize, S_DATE_S = view_search_choose_date_s_d.ToString("yyyyMMdd"), S_DATE_E = view_search_choose_date_e_d.ToString("yyyyMMdd"), S_TIME_S = view_search_stime_s_d.ToString("HHmmss"), S_TIME_E = view_search_stime_e_d.ToString("HHmmss"), E_TIME_S = view_search_etime_s_d.ToString("HHmmss"), E_TIME_E = view_search_etime_e_d.ToString("HHmmss"), TravelKind = search_travelkind, travel_type = view_travel_type, order_type = view_order_type, Departure = view_departure ,CITY_TO_NMAE = view_search_city_to_name, CITY_FROM_NMAE = view_search_city_from_name});
            }



            
            //return RedirectToAction("Index", "List", new { CITY_TO = "", TravelRegion = view_search_city_to, CITY_FROM = view_search_city_from, tourday = view_search_tour_day, CurrentPage = view_currentpage, PageSize = view_pagesize, S_DATE_S = view_search_choose_date_s_d.ToString("yyyyMMdd"), S_DATE_E = view_search_choose_date_e_d.ToString("yyyyMMdd"), S_TIME_S = view_search_stime_s_d.ToString("HHmmss"), S_TIME_E = view_search_stime_e_d.ToString("HHmmss"), E_TIME_S = view_search_etime_s_d.ToString("HHmmss"), E_TIME_E = view_search_etime_e_d.ToString("HHmmss"), TravelKind = search_travelkind, travel_type = view_travel_type, order_type = view_order_type, Departure = view_departure });
          // return View();
        }

       /* public ActionResult order_search(string search_city_from, string search_city_to, string search_choose_date_s, string search_choose_date_e, string search_travelkind, string search_tour_day, string search_stime_s, string search_stime_e, string search_etime_s, string search_etime_e, string search_is_ensure)
        {
          
            
            return View();
        }*/

	}
}