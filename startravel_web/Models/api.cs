using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace startravel_web.Models
{
    public class api
    {
    }


    public class list_view_return_data
    {
        public GRPList_result grplist_result { get; set; }
        public GRPList_PostData grplist_postdata { get; set; }
        public IGRPTravelRegion_result igrptravelregion_result { get; set; }
        public string city_from_name { get; set; }
        public string city_to_name { get; set; }

    }

    public class detail_view_return_data
    {
        public GRPProductDetail_result grpproductdetail_result { get; set; }
        public GRPCalendar_result grpcalendar_result { get; set; }
        public GRPAddPurchase_result grpaddpurchase_result { get; set; }
        public GRPPriceInfo_result grppriceinfo_result { get; set; }
        public string window_open { get; set; }

    }

    public class step1_view_return_data
    {
        public GRPProductDetail_result grpproductdetail_result { get; set; }
        public IGRPTrafficInfo_result igrptrafficinfo_result { get; set; }
        public GRPPriceInfo_result grppriceinfo_result { get; set; }
        

    }

    public class step2_view_return_data
    {
        public GRPProductDetail_result grpproductdetail_result { get; set; }
        public IGRPTrafficInfo_result igrptrafficinfo_result { get; set; }
        public GRPPriceInfo_result grppriceinfo_result { get; set; }
        public GRPAddPurchase_result grpaddpurchase_result { get; set; }
        public PassengerContacts_get_result passengercontacts_get_result { get; set; }
        public OrderStore_result orderstore_result { get; set; }
        public string room_count { get; set; }
        public string psub_list { get; set; }
        public string visa_list { get; set; }
        public string insu_list { get; set; }
        public int visa_count { get; set; }
        public int pusb_count { get; set; }
        public int insu_count { get; set; }
        public string member_info { get; set; }
        public string member_number { get; set; }

    }

    public class step3_view_return_data
    {
        public PaymentOrder_result paymentorder_result { get; set; }
        public tCashAvblBalance_result tcashavblbalance_result { get; set; }
        public OrderInstallment_result orderinstallment_result { get; set; }
        public string order_no { get; set; }
        public string member_name { get; set; }
    }


    public class step3_1_view_return_data
    {
        public OrderInfomation_result orderinfomation_result { get; set; }
        public int tcash { get; set; }
        public ATMTransferAccount_result atmtransferaccount_result { get; set; }
        public string order_no { get; set; }
       
    }


    public class step4_view_return_data
    {
        public OrderInfomation_result orderinfomation_result { get; set; }
        
    }

    //=====tour1.1=====//
    public class GRPList_result
    {
        public ProdListPageViewModel Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class ProdListPageViewModel
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProdListViewModel> prod { get; set; }
    }

    public class ProdListViewModel
    {
        public int RankNO { get; set; }
        public string Prod_NO { get; set; }
        public string Prod_Name { get; set; }
        public string Image_URL { get; set; }
        public string Prod_Type1 { get; set; }
        public string Tourdays { get; set; }
        public decimal Price { get; set; }
        public decimal Price_Agt { get; set; }
        public string City_From_Name { get; set; }
        public string City_To_Name { get; set; }
        public string CAT1Name { get; set; }
        public string CAT2Name { get; set; }
        public List<GRPListViewModels> GrpList { get; set; }
    }

    public class GRPListViewModels
    {
        public string Prod_NO { get; set; }
        public string GRP_NO { get; set; }
        public string S_DATE { get; set; }
        public string QTY_KK_ORG { get; set; }
        public decimal QTY_KK { get; set; }
        public decimal QTY_HL { get; set; }
        public decimal Price { get; set; }
        public decimal Price_AGT { get; set; }
        public string DEPARTURE_FLAG { get; set; }
        public decimal MIN_Tourer{ get; set; }
        public decimal MAX_Tourer { get; set; }
        public List<GRPFlyInfoViewModel> FlyList { get; set; }
    }

    //=====tour1.1=====//
    //=====tour1.2=====//
    public class IGRPTrafficInfo_result
    {
        public List<IGRPTrafficInfoViewModel> Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class IGRPTrafficInfoViewModel
    {
        public String date_at { get; set; }
        public String city_from_name { get; set; }
        public String city_to_name { get; set; }
        public String air_no { get; set; }
        public String air_name { get; set; }
        public String depart_time { get; set; }
        public String arrive_time { get; set; }
      
    }


    //=====tour1.2=====//
    //=====tour1.5=====//
    public class GRPPriceInfo_result
    {
        public List<GRPPriceInfoViewModel> Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class GRPPriceInfoViewModel
    {
        public String Category_name { get; set; }
        public List<RoleTypeViewModel> Role_Type { get; set; }
    }

    public class RoleTypeViewModel
    {
        public String Type_name { get; set; }
        public String Type_no { get; set; }
        public int Price { get; set; }
        public int COND_QTYA { get; set; }
        public int COND_QTYB { get; set; }
        public int COND_QTYC { get; set; }
    }
    //=====tour1.5=====//

    //=====tour1.6=====//
     public class GRPInfoViewModel
    {
        public String CAT_1 { get; set; }
        public String CAT_2 { get; set; }
        public String CITY_FROM { get; set; }
        public String CITY_TO { get; set; }
        public String CITY_FROM_NAME { get; set; }
        public String CITY_TO_NAME { get; set; }
        public String CAT1NAME { get; set; }
        public String CAT2NAME { get; set; }
        public String PROD_NO { get; set; }
        public String GRP_NO { get; set; }
        public String S_DATE { get; set; }
        public String E_DATE { get; set; }
        public decimal PRICE { get; set; }
        public decimal PRE_AMT { get; set; }
        public String PRE_DAY { get; set; }
        public String DUEDAY_PAY { get; set; }
        public String DUEDAY_DOC { get; set; }
        public String FEE_CONTRAIN { get; set; }
        public String FEE_NOT_CONTRAIN { get; set; }
        public String PROD_NOTE { get; set; }
        public decimal MIN_TOURER { get; set; }
        public decimal MAX_TOURER { get; set; }
        public String PROD_PIC { get; set; }
        public decimal QTY_KK { get; set; }
        public String PROD_NAME { get; set; }
        public String PROD_DESC4 { get; set; }
        public String PROD_DESC3 { get; set; }
        public String URL { get; set; }
        public GRPPicURLViewModel PIC_URL { get; set; }
        public List<GRPDateListViewModel> DateList { get; set; }
        public List<GRPFlyInfoViewModel> TrafficList { get; set; }
    }

    public class GRPProductDetail_result
    {
        public GRPInfoViewModel Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

   

    public class GRPPicURLViewModel
    {
        public String URL1 { get; set; }
        public String URL2 { get; set; }
        public String URL3 { get; set; }
        public String URL4 { get; set; }
    }

    public class GRPDateListViewModel
    {
        public String DATEPIC_URL { get; set; }
        public String DATE_AT { get; set; }
        public String PATH_TITLE { get; set; }
        public String PATH_DESC { get; set; }
        public String MEAL { get; set; }
        public String HOTEL { get; set; }
    }
    public class GRPFlyInfoViewModel
    {
        public String DATE_AT { get; set; }
        public String CITY_FROM { get; set; }
        public String CITY_FROM_NAME { get; set; }
        public String CITY_FROM_SC_NAME { get; set; } 
        public String CITY_TO { get; set; }
        public String CITY_TO_NAME { get; set; }
        public String CITY_TO_SC_NAME { get; set; }  
        public String AIR_NAME { get; set; }
        public String FLY_NO { get; set; }
        public String DEPARRT_TIME { get; set; }
        public String ARRIVE_TIME { get; set; }
        public String FORWARD_FLAG { get; set; }
        public String DAY_CHAGE { get; set; }
    }
    //=====tour1.6=====//
    //=====tour1.7=====//
    public class GRPCalendar_result
    {
        public GRPCalendarViewModel Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class GRPCalendarViewModel
    {
        public String search_s_month { get; set; }
        public String search_e_month { get; set; }
        public String Prod_no { get; set; }
        public List<GRPCalendarSdateViewModel> grp_date { get; set; }

    }

    public class GRPCalendarSdateViewModel
    {
        public String S_date { get; set; }
        public int Grp_count { get; set; }
        public List<GRPCalendarQtyViewModel> Grp { get; set; }

    }

    public class GRPCalendarQtyViewModel
    {
        public String Grp_no { get; set; }
        public decimal Price { get; set; }
        public int Qty_kk { get; set; }
        public int Qty_hl { get; set; }

    }

    //=====tour1.7=====//
    //=====tour1.8=====//
    public class GRPAddPurchase_result
    {
        public List<GRPAddPurasViewModel> Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class GRPAddPurasViewModel
    {
        public String prod_SUB_NO { get; set; }
        public Decimal PROD_SUB_PRICE { get; set; }
        public String PROD_SUB_NAME { get; set; }
        public String PROD_SUB_DESC { get; set; }
        

    }

    //=====tour1.8=====//

    //=====tour1.9=====//
    public class GRPDepartureList_result
    {
        public List<GRPDepartureListViewMode> Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class GRPDepartureListViewMode
    {
        public String CITY_FROM { get; set; }
        public String SC_NAME { get; set; }


    }

    //=====tour1.9=====//
    //=====tour1.11=====//

    public class GRPCalendarInfoList_result
    {
        public List<GRPCalendarInfoListViewModel> Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class GRPCalendarInfoListViewModel
    {
        public String PROD_NAME { get; set; }
        public String CAT_1 { get; set; }
        public String CAT_2 { get; set; }
        public String CITY_FROM { get; set; }
        public String CITY_TO { get; set; }
        public String CITY_FROM_NAME { get; set; }
        public String CITY_TO_NAME { get; set; }
        public String CAT1NAME { get; set; }
        public String CAT2NAME { get; set; }
        public List<GRPFlyInfoViewModel> TrafficList { get; set; }
        public String PROD_NO { get; set; }
        public String GRP_NO { get; set; }
        public String S_DATE { get; set; }
        public String E_DATE { get; set; }
        public decimal PRICE { get; set; }
        public decimal PRE_AMT { get; set; }
        public String PRE_DAY { get; set; }
        public String DUEDAY_PAY { get; set; }
        public String DUEDAY_DOC { get; set; }
        public decimal MIN_TOURER { get; set; }
        public decimal MAX_TOURER { get; set; }
        public decimal QTY_KK_ORG { get; set; }
        public decimal QTY_KK { get; set; }
        public decimal QTY_HL { get; set; }
        public decimal DEPARTURE_FLAG { get; set; }

    }



    //=====tour1.11=====//


    //=====tour1.12=====//
    public class IGRPTravelRegion_result
    {
        public List<TravelRegionCatModel> Data { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
        public DateTime TokenExpires { get; set; }
    }

    public class TravelRegionCatModel
    {
        public String Cat1Code { get; set; }
        public String Cat1Name { get; set; }
        public List<TravelRegionCatModelList> Cat2List { get; set; }
    }

    public class TravelRegionCatModelList
    {
        public String Cat2Code { get; set; }
        public String Cat2Name { get; set; }
      
    }

    //=====tour1.12=====//


    public class GRPList_PostData
    {
        public string CITY_TO { get; set; }
        public string CITY_FROM { get; set; }
        public string TravelRegion { get; set; }
        public string tourday { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string S_DATE_S { get; set; }
        public string S_DATE_E { get; set; }
        public string S_TIME_S { get; set; }
        public string S_TIME_E { get; set; }
        public string E_TIME_S { get; set; }
        public string E_TIME_E { get; set; }
        public string travel_type { get; set; }
        public string order_type { get; set; }
        public int TravelKind { get; set; }
        public int Departure { get; set; } 

    }

    public class IGRPTrafficInfo_PostData
    {
        public string prod_no { get; set; }
        public string grp_no { get; set; }

    }

    public class DGRPTrafficInfo_PostData
    {
        public string prod_no { get; set; }
        public string grp_no { get; set; }
    }

    public class GRPTrafficInfoList_PostData
    {
        public string Prod_no { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class GRPPriceInfo_PostData
    {
        public string prod_no { get; set; }
        public string grp_no { get; set; }
    }

    public class GRPProductDetail_PostData
    {
        public string prod_no { get; set; }
        public string grp_no { get; set; }
    }

    public class GRPCalendar_PostData
    {
        public string prod_no { get; set; }
        public string s_month { get; set; }
        public string e_month { get; set; }
    }

    public class GRPAddPurchase_PostData
    {
        public string prod_no { get; set; }
        public string grp_no { get; set; }
    }

    public class GRPDepartureList_PostData
    {
        public string Depart_SDate { get; set; }
        public string Depart_EDate { get; set; }
    }

    public class GRPDestinationList_PostData
    {
        public string Depart_SDate { get; set; }
        public string Depart_EDate { get; set; }
    }

    public class GRPCalendarInfoList_PostData
    {
        public string prod_no { get; set; }
        public string date { get; set; }
    }

    public class LoginVerify_PostData
    {
        public string ID_NO { get; set; }
        public string password { get; set; }
    }

    public class tCashAvblBalance_PostData
    {
        public string member_no { get; set; }
    }

    public class PassengerContacts_get_PostData
    {
        public string member_no { get; set; }
    }

    public class PassengerContacts_post_PostData
    {
        public string member_no { get; set; }
        public string id_no { get; set; }
        public string sex { get; set; }
        public string name_c_first { get; set; }
        public string name_c_last { get; set; }
        public string name_e_first { get; set; }
        public string name_e_last { get; set; }
        public string birthday { get; set; }
    }

    public class TKLogin_PostData
    {
        public string user_no { get; set; }
    }

    public class PaymentOrder_PostData
    {
        public string order_no { get; set; }
    }

    public class ATMTransferAccount_PostData
    {
        public string order_no { get; set; }
    }

    public class OrderStore_PostData
    {
        public string order_no { get; set; }
    }

    public class OrderInfomation_PostData
    {
        public string order_no { get; set; }
    }

    public class OrderInstallment_PostData
    {
        public string ORDER_NO { get; set; }
        public string ORDER_SOURCE { get; set; }
        public string ORDER_TIME { get; set; }
        public string PAY_FLOW { get; set; }
        public string ORDER_PAYMENT { get; set; }
        public string USER_NUMBER { get; set; }
        public string LST_SEQNO { get; set; }
        public string ONLINE_TICKET { get; set; }
        public string IHOL_PAY { get; set; }
        public string DIRECT_ALLPay { get; set; }
    }


    //order 1.6
    public class OrderGrpCreate_PostData
    {
        public string ORDER_SALES { get; set; }
        public string ORDER_CONTACT_NO { get; set; }
        public string ORDER_CONTACT_TYPE { get; set; }
        public string ORDER_CONTACT_NAME { get; set; }
        public string ORDER_CONTACT_ID { get; set; }
        public string ORDER_CONTACT_TEL1 { get; set; }
        public string ORDER_CONTACT_TEL2 { get; set; }
        public string ORDER_CONTACT_MOBIL { get; set; }
        public string ORDER_CONTACT_EMAIL { get; set; }
        public string ORDER_CONTACT_FAX { get; set; }
        public string ORDER_CONTACT_ADDRESS { get; set; }
        public string ORDER_NOTE { get; set; }
        public string ORDER_INV_ID { get; set; }
        public string ORDER_INV_NO { get; set; }
        public string ORDER_INV_RECEIVER { get; set; }
        public string ORDER_INV_ADDRESS { get; set; }
        public string ORDER_INV_TYPE { get; set; }
        public string ORDER_TAKE_TYPE { get; set; }
        public string ORDER_MAIL_RECEIVER { get; set; }
        public string ORDER_MAIL_ADDRESS { get; set; }
        public string ORDER_CREATOR { get; set; }
        public string PROD_NO { get; set; }
        public string GRP_NO { get; set; }
        public List<OrderGrpCreateCusModel_param> ORDER_CUS { get; set; }
    }

    public class OrderGrpCreateCusModel_param
    {
        public string CUS_SEQNO { get; set; }
        public string CUS_TYPE { get; set; }
        public string CUS_ID { get; set; }
        public string CUS_NAME_C_FIRST { get; set; }
        public string CUS_NAME_C_LAST { get; set; }
        public string CUS_NAME_E_FIRST { get; set; }
        public string CUS_NAME_E_LASTE { get; set; }
        public string CUS_SEX { get; set; }
        public string CUS_BIRTHDAY { get; set; }
        public string CUS_TEL1 { get; set; }
        public string CUS_TEL2 { get; set; }
        public string CUS_MOBIL { get; set; }
        public string CUS_EMAIL { get; set; }
        public string CUS_FAX { get; set; }
        public string CUS_ADDRESS { get; set; }
        public string CUS_FOOD { get; set; }
        public string PASSPORT_NO { get; set; }
        public string PASSPORT_S_DATE { get; set; }
        public string PASSPORT_E_DATE { get; set; }
        public string ROOM_COND { get; set; }
        public List<OrderGrpCreateProdSubModel_param> ORDER_PROD_SUB { get; set; }
    }
    public class OrderGrpCreateProdSubModel_param
    {

        public string PROD_SUB_NO { get; set; }
        public string PROD_SUB_QTY { get; set; }
    }


    ///member
    ///

    //member 1.1
    public class  LoginVerify_result
    {
        public LoginVerifyViewModel Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }
      
    }

    public class LoginVerifyViewModel
    {
        public String MEMBER_NO { get; set; }
        public String MEMBER_NAME { get; set; }
        public String PASSWORD { get; set; }
        public String ID_NO { get; set; }
        public String EMAIL { get; set; }
        public String MEMBER_E_NAME { get; set; }
        public String GENDER { get; set; }
        public String BIRTHDAY { get; set; }
        public String ADDRESS { get; set; }
    }

    //member 1.1

    //member 1.11
    public class tCashAvblBalance_result
    {
        public tCashAvblBalanceViewModel Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }

    }

    public class tCashAvblBalanceViewModel
    {
        public String member_no { get; set; }
        public int Tcash { get; set; }
        

    }

    //member 1.11
    //member 1.13
    public class PassengerContacts_get_result
    {
        public List<MemberCustViewModel> Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }

    }

    public class MemberCustViewModel
    {
        public String ID_NO { get; set; }
        public String SEX { get; set; }
        public String NAME_C_FIRST { get; set; }
        public String NAME_C_LAST { get; set; }
        public String NAME_E_FIRST { get; set; }
        public String NAME_E_LAST { get; set; }
        public String BIRTHDAY { get; set; }
      
    }

    public class PassengerContacts_post_result
    {
        public PassengerContactsAddViewModel Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }

    }
    public class PassengerContactsAddViewModel
    {
        public enum status { }
       
    }
   

    //member 1.13

    //order_1.2
    public class PaymentOrder_result
    {
        public List<PaymentOrderViewModel> Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }

    }

    public class PaymentOrderViewModel
    {
        public String Order_No { get; set; }
        public int Lst_SeqNo { get; set; }
        public String Prod_Type1 { get; set; }
        public String Lst_Status { get; set; }
        public String Lst_Status_Desc { get; set; }
        public String Prod_Name { get; set; }
        public String Cust_Name { get; set; }
        public String Prod_Name_Sub { get; set; }
        public Decimal Prod_Amt { get; set; }
        public Decimal PromoAmt { get; set; }
        public Decimal Pre_Amt { get; set; }
        public Decimal PaidAmt { get; set; }
        public Decimal UnPayAmt { get; set; }
        public DateTime PayDeadlineTime { get; set; }
        public bool CanPrePay { get; set; }
        public bool CanPayAll { get; set; }
        public List<OrderProdSubViewModel> OrderProdSub { get; set; }
        
    }

    public class OrderProdSubViewModel
    {
        public String Order_No { get; set; }
        public int Lst_SeqNo { get; set; }
        public int Prod_Sub_SeqNo { get; set; }
        public String Prod_Sub_No { get; set; }
        public Decimal Prod_Sub_Price { get; set; }
        public int Prod_Sub_Qty { get; set; }
        public Decimal Prod_Sub_Amt { get; set; }
        public String Prod_Sub_Name { get; set; }
        
    }
    //order_1.2

    //order_1.3
    public class ATMTransferAccount_result
    {
        public List<ATMTransferAccountViewModel> Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }

    }

    public class ATMTransferAccountViewModel
    {
        public String ATMTransferAccountNo { get; set; }
        
    }
    //order_1.3

    //order_1.4
     public class OrderStore_result
    {
         public List<OrderStoreViewModel> Data { get; set; }
        public DateTime TokenExpires { get; set; }
        public String rCode { get; set; }
        public String rCodeDesc { get; set; }

    }

     public class OrderStoreViewModel
     {
         public String Dept_Region { get; set; }
         public String Dept_No { get; set; }
         public String Dept_Name { get; set; }
         public String Dept_Tel { get; set; }
         public String Dept_Address { get; set; }
     }
     //order_1.4

     //order_1.5
     public class OrderInfomation_result
     {
         public OrderInfoViewModel Data { get; set; }
         public DateTime TokenExpires { get; set; }
         public String rCode { get; set; }
         public String rCodeDesc { get; set; }

     }

     public class OrderInfoViewModel
     {
         public String status { get; set; }
         public String ORDER_NO { get; set; }
         public String PROD_NAME { get; set; }
         public String ORDER_DATE { get; set; }
         public String OP_MAN { get; set; }
         public String PRE_DAY { get; set; }
         public String DUEDAY_PAY { get; set; }
         public String DUEDAY_DOC { get; set; }
         public String USER_NO { get; set; }
         public String USER_NAME { get; set; }
         public String EMAIL { get; set; }
         public String MASTER_TEL { get; set; }
         public String EXT_NO { get; set; }
         public String FAX1 { get; set; }
         public List<OrderLstViewModel> OrderLst { get; set; }
         public OrderHTLViewModel OrderHTL { get; set; }
         public List<OrderTrafficViewModel> OrderTraffic { get; set; }
         public List<OrderCusAndSubViewModel> CusAndSub { get; set; }
         public OrderContactInfoViewModel OrderOthers { get; set; }

     }

     public class OrderLstViewModel
     {
         public String PROD_NO { get; set; }
         public String GRP_NO { get; set; }
         public String LST_SEQNO { get; set; }
         public String PROD_NAME { get; set; }
         public String LST_STATUS { get; set; }
         public String OP_DL_DATETIME { get; set; }
         public String PROD_COND1 { get; set; }
         public String PROD_PRICE { get; set; }
         public String PROD_SUB_AMT { get; set; }
         public String PAID_AMT_SALES { get; set; }
         public String PRE_AMT { get; set; }
         public String CUS_NAME { get; set; }
         public String CUS_E_NAME { get; set; }
         public String CUS_SEX { get; set; }
         public String COND_QTYB_NOTE { get; set; }
         public String QTYAC_NOTE { get; set; }
         public String COND_NOTE { get; set; }
         public String TCASH2USE { get; set; }
         public String NOPAID { get; set; }
     }

     public class OrderHTLViewModel
     {
         public String HOTEL_NAME { get; set; }
         public String CHECKIN { get; set; }
         public String CHECKOUT { get; set; }      
     }

     public class OrderTrafficViewModel
     {
         public String CNAME_FROM { get; set; }
         public String CNAME_TO { get; set; }
         public String SEQNO { get; set; }
         public String DEPART_TIME { get; set; }
         public String ARRIVE_TIME { get; set; }
         public String AIR_NAME { get; set; }
         public String FLY_NO { get; set; }
         public String CITY_FROM { get; set; }
         public String CITY_TO { get; set; }
         public String FORWARD_FLAG { get; set; }
     }

     public class OrderCusAndSubViewModel
     {
         public String CUS_NAME { get; set; }
         public String CUS_E_NAME { get; set; }
         public String CUS_FOOD { get; set; }
         public String PROD_SUB_NAME { get; set; }
         public string CUS_SEQNO { get; set; }
       
     }
     public class OrderContactInfoViewModel
     {
         public String ORDER_CONTACT_NAME { get; set; }
         public String ORDER_CONTACT_TEL1 { get; set; }
         public String ORDER_CONTACT_MOBIL { get; set; }
         public String ORDER_INV_ID { get; set; }
         public String ORDER_INV_NO { get; set; }
         public String ORDER_NOTE { get; set; }

     }

     //order_1.5
    //order_1.6

     public class OrderGrpCreate_result
     {
         public OrdersCreateViewModel Data { get; set; }
         public DateTime TokenExpires { get; set; }
         public String rCode { get; set; }
         public String rCodeDesc { get; set; }

     }

     public class OrdersCreateViewModel
     {
         public string ORDER_NO { get; set; }
        
     }

    //order_1.6

     //pach1.1
     public class OrderInstallment_result
     {
         public List<SelectorViewModel> Data { get; set; }
         public DateTime TokenExpires { get; set; }
         public String rCode { get; set; }
         public String rCodeDesc { get; set; }

     }

     public class SelectorViewModel
     {
         public String PMCH_NO { get; set; }
         public String PMCH_NAME { get; set; }
         public String PMCH_URL { get; set; }
         
     }
     //pach1.1
}