using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSAutomation
{
    public class Property
    {
 //*********************Global locators*******************************************************************************
        public static String BASEURL = "BASEURL";
// public static String PROPERTY_FILENAME = "config/gui_automation.properties";
         public static String XLS_DATA = "XLS_DATA";
         public static String USERS_LIST = "USERS_LIST";
         public static String USER = "USER";
         public static String BROWSER = "BROWSER";
         public static String COMPANY = "COMPANY";
         public static String SERVER = "SERVER";
         public static String UID = "UID";
         public static String ScreenShotPath = "ScreenShotPath";
         public static String FILEPATH = "FILEPATH";
         public static String FILE = "FILE";
         public static String DownloadPath = "DownloadPath";
         public static String ResultPath = "ResultPath";
        //******************Customer Locators ***********************************************************************************

        public static String  Estimategrid_ID ="Estimategrid_ID";
        public static String CustomerMenu_ID = "CustomerMenu_ID";
        public static String CustShortname_ID="CustShortname_ID";
        public static String CreateCustomer_LINK = "CreateCustomer_LINK";
        public static String CustomerID_ID = "CustomerID_ID";
        public static String CustomerName_ID = "CustomerName_ID";
        public static String CustomerType_ID = "CustomerType_ID";
        public static String CustomerTypedropDown_CSS = "CustomerTypedropDown_CSS";
        public static String CustId_Save_CSS = "CustId_Save_CSS";
        public static String table_XPATH = "table_XPATH";
        public static String filetrName_ID = "filetrName_ID";
        public static String Customer_Status_ID = "Customer_Status_ID";
        public static String AddressBillTo_ID = "AddressBillTo_ID";
        public static String BilltoState_ID = "BilltoState_ID";
        public static String ZipBillto_ID = "ZipBillto_ID";
        public static String CountryBillTo_ID = "CountryBillTo_ID";
        public static String CustomerContact_LINK = "CustomerContact_LINK";
        public static String Contact_ID = "Contact_ID";
        public static String ContPh_ID = "ContPh_ID";
        public static String Cont_Email_ID = "Cont_Email_ID";
        public static String CityBillto_ID="CityBillto_ID";
        public static String PrimaryRep_ID="PrimaryRep_ID";
        public static String QouteRep_ID="QouteRep_ID";
        
        public static String PrimaryRepDropdown_CSS ="PrimaryRepDropdown_CSS";
        public static String QouteRepDropDown_CSS ="QouteRepDropDown_CSS";
        public static String  Shipto_Add_ID ="Shipto_Add_ID";
        public static String Shipto_City_ID="Shipto_City_ID";
        public static String ShipTo_Zip_ID="ShipTo_Zip_ID";
        public static String Shipto_State_ID="Shipto_State_ID";
        public static String  MaxShipOver_ID ="MaxShipOver_ID";
        public static String MinShipOver_ID="MinShipOver_ID";
        public static String Shippingmtd_ID="Shippingmtd_ID";
        public static String ShippingMtd_CSS="ShippingMtd_CSS";
        public static String CustUntizationPattern_ID="CustUntizationPattern_ID";
        public static String  ShipCustShortName_CSS ="ShipCustShortName_CSS";
        public static String  CountryShipto_ID ="CountryShipto_ID";
        public static String  ShippingMtddropdown_CSS ="ShippingMtddropdown_CSS";
        public static String Commercial_LINK="Commercial_LINK";
        public static String  BillingTerms_ID = "BillingTerms_ID";
        public static String BillingTermsDropdown_CSS="BillingTermsDropdown_CSS";
        public static String  CustSave_ID ="CustSave_ID";
        public static String  Make_Active_LINK ="Make_Active_LINK";
        public static String CustomerDefShipto_ID="CustomerDefShipto_ID";
        public static String searchCustomer_ID="searchCustomer_ID";
        public static String customerListtable_CSS ="customerListtable_CSS";
        public static String filterByName_ID="filterByName_ID";
        public static String AutoBusinessDiscount_ID="AutoBusinessDiscount_ID";
        public static String createsameproduct_ID="createsameproduct_ID";
        public static String AllBusinessSpec_ID="AllBusinessSpec_ID";
        public static String AllbusinesspsecApprove_XPATH="AllbusinesspsecApprove_XPATH";
        public static String  allspectable_CSS = "allspectable_CSS";
        public static String allowAnyShipTo_ID="allowAnyShipTo_ID";
        public static String createestimatebutton_ID="createestimatebutton_ID";
        public static String setasManufacturable_ID="setasManufacturable_ID";
        public static String  Approvetest_CSS = "Approvetest_CSS";
        public static String  editestimateform_ID = "editestimateform_ID";
        public static String  createnewproduct_ID ="createnewproduct_ID";
        //*******************BUndle strapping***************
        public static String  Bundlestarpping_CSS ="Bundlestarpping_CSS";
        public static String StrappingprodData_ID="StrappingprodData_ID";
        public static String StappingCost_ID="StappingCost_ID";
        public static String CostStartDate_ID="CostStartDate_ID";
        public static String CostSubmit_CSS="CostSubmit_CSS";
        public static String ProductDataforEstimateMat_ID="ProductDataforEstimateMat_ID";
        public static String PricingType_CSS="PricingType_CSS";
        public static String PricingMetricvalue_ID="PricingMetricvalue_ID";
        public static String addqty_ID="addqty_ID";
        public static String FromToTable_XPATH="FromToTable_XPATH";
        public static String  businesdiscount_ID ="businesdiscount_ID";
        public static String CosttableValues_CSS="CosttableValues_CSS";
        public static String  CosttableValues1_CSS ="CosttableValues1_CSS";
        public static String FactoryTicket_ID="FactoryTicket_ID";
        public static String  EstimateCost_LINK ="EstimateCost_LINK";
        public static String CostEstimate_XPATH="CostEstimate_XPATH";
        public static String  RouteList_XPATH ="RouteList_XPATH";
        public static String  materialList_XPATH ="materialList_XPATH";
        public static String  CostMaterialList_XPATH ="CostMaterialList_XPATH";
        public static String  filterByProduct_ID ="filterByProduct_ID";
        public static String Estimatefilter_ID = "Estimatefilter_ID";
        public static String SpecFilterTable_CSS = "SpecFilterTable_CSS";
        public static String EstimateTable_XPATH="EstimateTable_XPATH";
        public static String Bundlestrappingmaterial_ID="Bundlestrappingmaterial_ID";
        public static String  Unittization_ID ="Unittization_ID";
        public static String UnitizationType_ID="UnitizationType_ID";
        public static String Untitypedropdown_CSS="Untitypedropdown_CSS";
        //*********************Assembled product**********************************
        public static String AssembledProductKit_ID = "AssembledProductKit_ID";
        public static String addproductKit_ID = "addproductKit_ID";
        public static String ChildProductSpec_ID = "ChildProductSpec_ID";
        public static String ChildSpec_CSS = "ChildSpec_CSS";
        public static String CostPercentage_ID = "CostPercentage_ID";
        public static String PartMultiplier_ID = "PartMultiplier_ID";
        public static String SubmitChildPart_CSS = "SubmitChildPart_CSS";
        public static String AssembleSplit_XPATH = "AssembleSplit_XPATH";




        //****************************************************************************

        //********************ESTIMATE2*********************************************
        public static String InkColourMaterial_XPATH="InkColourMaterial_XPATH";
        public static String ProdDataMaterialID_ID = "ProdDataMaterialID_ID";
        public static String ProdDataToolType_ID = "ProdDataToolType_ID";
        public static String ProdDataToolName_ID = "ProdDataToolName_ID";
        public static String ProdDataToolID_ID = "ProdDataToolID_ID";
        public static String ProdDataToolCost_XPATH = "ProdDataToolCost_XPATH";
        public static String ToolPricingType_ID = "ToolPricingType_ID";

        public static String ToolPricingTypeDropDown_ID = "ToolPricingTypeDropDown_ID";
        public static String ToolPricingTypeSubmit_ID = "ToolPricingTypeSubmit_ID";
        public static String ProductMaterialInk_ID="ProductMaterialInk_ID";
        public static String ProductMaterialInk_XPATH="ProductMaterialInk_XPATH";
        public static String  PercentCoverage_ID = "PercentCoverage_ID";
        public static String NumberOfCostUnitWasted_ID="NumberOfCostUnitWasted_ID";
        public static String SubmitCoverage_CSS="SubmitCoverage_CSS";
        public static String businesdiscountinspec_ID="businesdiscountinspec_ID";


        //******************order Locators ***********************************************************************************
        public static String orderManag_ID = "orderManag_ID";
        public static String orderManagement_ID = "Orderentry_ID";
        public static String Orderentry_ID = "Orderentry_ID";
        public static String ordercustomer_ID = "ordercustomer_ID";
        public static String dropdown_XPATH = "dropdown_XPATH";
        public static String ordertable_XPATH = "ordertable_XPATH";
        public static String ordernetryPO_XPATH = "ordernetryPO_XPATH";
        public static String Shipto_XPATH = "Shipto_XPATH";
        public static String ShipToDropDown_XPATH = "ShipToDropDown_XPATH";
        public static String DileverySpec_XPATH = "DileverySpec_XPATH";
        public static String DileverySpecdropdown_XPATH = "DileverySpecdropdown_XPATH";
        public static String orderQty_XPATH = "orderQty_XPATH";
        public static String OrderDueDate_XPATH = "OrderDueDate_XPATH";
        public static String OrderDueDatePrice_XPATH = "OrderDueDatePrice_XPATH";
        public static String OrderSave_XPATH = "OrderSave_XPATH";
        public static String OrderdatePicker_ID = "OrderdatePicker_ID";
        public static String OrderId_XPATH = "OrderId_XPATH";
        public static String supplier_ID = "supplier_ID";
        public static String AddSalesLine_XPATH = "AddSalesLine_XPATH";
        public static String SaveOrder_ID="SaveOrder_ID";
        public static String AddSalesLine_CSS="AddSalesLine_CSS";
        public static String DileverySpecLine2_XPATH="DileverySpecLine2_XPATH";
        public static String orderQtyLine2_XPATH ="orderQtyLine2_XPATH";
        public static String  OrderDueDateLine2_XPATH ="OrderDueDateLine2_XPATH";
        public static String  DileverySpecdropdownLine2_XPATH ="DileverySpecdropdownLine2_XPATH";
        public static String filterbyorder_ID = "filterbyorder_ID";
        public static String FilterOrderDropdown_XPATH = "FilterOrderDropdown_XPATH";
        public static String filtersalelines_ID = "filtersalelines_ID";
        public static String orderTableList_XPATH = "orderTableList_XPATH";
        public static String  subMenuLiOrders_ID ="subMenuLiOrders_ID";
        //******************order Locators ***********************************************************************************
        public static String PruchasingMenu_ID = "PruchasingMenu_ID";
        public static String MatrerialMenu_ID = "MatrerialMenu_ID";
        public static String CreateNewmaterial_ID = "CreateNewmaterial_ID";
        public static String Materail_ID = "Materail_ID";
        public static String MaterialDescription_ID = "MaterialDescription_ID";
        public static String MaterialType_ID = "MaterialType_ID";
        public static String CostCurrent_ID = "CostCurrent_ID";
        public static String IsRealMaterial_ID = "IsRealMaterial_ID";
        public static String FilterMateriall1_ID = "FilterMateriall1_ID";
        public static String  filter_ID ="filter_ID";
        public static String Material_table_XPATH = "Material_table_XPATH";
        public static String Save_CSS = "Save_CSS";
        public static String  Material_table_ID ="Material_table_ID";
        public static String OrderList_CSS="OrderList_CSS";
        public static String Activestatus_XPATH="Activestatus_XPATH";
        //*****************************Specification**************************************************************
        public static String ProductMenu_ID = "ProductMenu_ID";
        public static String SpecificationMenu_ID = "SpecificationMenu_ID";
        public static String CreateNew = "CreateNew";
        public static String spec_number_ID = "spec_number_ID";
        public static String customer_ID = "customer_ID";
        public static String specID_ID = "specID_ID";
        public static String productstyle_ID = "productstyle_ID";
        public static String productGL_CSS = "productGL_CSS";
        public static String materialGrade_ID = "materialGrade_ID";
        public static String Spec_supplier_ID = "Spec_supplier_ID";
        public static String lenght_ID = "lenght_ID";
        public static String Width_ID = "Width_ID";
        public static String Depth_ID = "Depth_ID";
        public static String Recalculate_ID = "Recalculate_ID";
        public static String MaterialandOperationAddOn_ID = "MaterialandOperationAddOn_ID";
        public static String CutomerDropdwon_XPATH = "CutomerDropdwon_XPATH";
        public static String ProductStyleDropdown_ID = "ProductStyleDropdown_ID";
        public static String GL_code_IDDropdown_XPATH = "GL_code_IDDropdown_XPATH";
        public static String Material_grade_ID = "Material_grade_ID";
        public static String Material_grade_dropdown_XPATH = "Material_grade_dropdown_XPATH";
        public static String Bussiness_Spec_CSS = "Bussiness_Spec_CSS";
        public static String validate_Save_Button_ID = "validate_Save_Button_ID";
        public static String New_Buss_Spec_ID = "New_Buss_Spec_ID";
        public static String BusinessSpec_ID = "BusinessSpec_ID";
        public static String costmodel_ID = "costmodel_ID";
        public static String costmodeldropdown_ID = "costmodeldropdown_ID";
        public static String Qauntity_ID = "Qauntity_ID";
        public static String ShiptoAdd_ID = "ShiptoAdd_ID";
        public static String estimateenddate_ID = "estimateenddate_ID";
        public static String validdate_ID = "validdate_ID";
        public static String SaveAndGenerateRoutes_ID = "SaveAndGenerateRoutes_ID";
        public static String routes_ID = "routes_ID";
        public static String buttons_XPATH = "buttons_XPATH";
        public static String createprice_ID = "createprice_ID";
        public static String calculate_price_ID = "calculate_price_ID";
        public static String estimate_ID = "estimate_ID";
        public static String price_box_ID = "price_box_ID";
        public static String saveprice_ID = "saveprice_ID";
        public static String Operation_grid_XPATH="Operation_grid_XPATH";
        public static String CheckRoutings_CSS = "CheckRoutings_CSS";
        public static String RoutingList_ID="RoutingList_ID";
        public static String RouteCLose_ID = "RouteCLose_ID";
        public static String Save_ProductEstimate_ID = "Save_ProductEstimate_ID";
        public static String ProductDataestimate_ID = "ProductDataestimate_ID";
        public static String EstimateList_ID ="EstimateList_ID";
        public static String CreateEstimate_ID="CreateEstimate_ID";
        public static String costmodeldropdown_CSS = "costmodeldropdown_CSS";
        public static String UnitizationTable_XPATH = "UnitizationTable_XPATH";
        public static String  SelectUnitization_ID ="SelectUnitization_ID";
        public static String  UnitizationGrid_ID ="UnitizationGrid_ID";
        public static String RoutesGenrated_ID = "RoutesGenrated_ID";
        public static String Split_CSS = "Split_CSS";
        public static String CreateEstimatePrice_ID = "CreateEstimatePrice_ID";
        public static String Calculate_Price_ID = "Calculate_Price_ID";
        public static String  EstimatePriceList_ID = "EstimatePriceList_ID";
        public static String SavePriceList_ID= "SavePriceList_ID";
        public static String ApprovePriceList_ID="ApprovePriceList_ID";
        public static String SaveAlert_XPATH="SaveAlert_XPATH";
        public static String UnitizationModel_ID="UnitizationModel_ID";
        public static String AllOperation_grid_XPATH= "AllOperation_grid_XPATH";
        public static String AddMatrial_ID = "AddMatrial_ID";
        public static String AddMatrialDropdown_CSS="AddMatrialDropdown_CSS";
        public static String Operation_Delete_XPATH = "Operation_Delete_XPATH";
        public static String Suppliersubmit_ID="Suppliersubmit_ID";
        public static String Datpicker_ID="Datpicker_ID";
        public static String  MaterialAddon_XPATH ="MaterialAddon_XPATH";
        public static String  SaveProdEstimate_ID ="SaveProdEstimate_ID";
        public static String  MaterialAddonInSpec_ID = "MaterialAddonInSpec_ID";
        public static String ToolLink_CSS = "ToolLink_CSS";
        public static String  NUmberOfColour_ID ="NUmberOfColour_ID";
        public static String SubmitTool_CSS = "SubmitTool_CSS";
        public static String ToolLinkDropdown_CSS="ToolLinkDropdown_CSS";
        public static String AllMaterial_grid_XPATH="AllMaterial_grid_XPATH";
        public static String ColourPercentage_ID="ColourPercentage_ID";
        public static String ColourUnitsWasted_ID="ColourUnitsWasted_ID";
        public static String ColourPercentageSubmit_CSS="ColourPercentageSubmit_CSS";
        public static String ProductEstimateInformation_XPATH="ProductEstimateInformation_XPATH";
        public static String DiecutToolid_CSS ="DiecutToolid_CSS";
        public static String ToolIDdropdown_CSS ="ToolIDdropdown_CSS";
        public static String DieCutNumberUP_CSS = "DieCutNumberUP_CSS";
        public static String DieCutNumberOUT_CSS = "DieCutNumberOUT_CSS";
        public static String  warehouse_ID ="warehouse_ID";
        public static String  WarehouseDropdown_XPATH = "WarehouseDropdown_XPATH";
        public static String ShipToCustomer_ID="ShipToCustomer_ID";
         public static String shipmentMethod_ID ="shipmentMethod_ID";
        public static String CopyExsistingEstimate_ID="CopyExsistingEstimate_ID";
        public static String NumberPerBundle_ID="NumberPerBundle_ID";
        public static String RevisionProduct_ID="RevisionProduct_ID";
        public static String PartDivider_ID="PartDivider_ID";

        //*****************************tools**************************************************************

        public static String ToolMenu_ID = "ToolMenu_ID";
        public static String CreateTool_LINK= "CreateTool_LINK";
        public static String Tool_ID= "Tool_ID";
        public static String Tool_Type= "Tool_Type";
        public static String ToolLicensePlate_ID= "ToolLicensePlate_ID";
        public static String HomeLocation_ID= "HomeLocation_ID";
        public static String CurrentLocation_ID= "CurrentLocation_ID";
        public static String ToolStatus_ID= "ToolStatus_ID";
        public static String ImpressionCount_ID= "ImpressionCount_ID";
        public static String ImpressionExpected_ID= "ImpressionExpected_ID";
        public static String ToolSupplier_ID= "ToolSupplier_ID";
        public static String ToolPOnumber_ID= "ToolPOnumber_ID";
        public static String POCreatedDate_ID= "POCreatedDate_ID";
        public static String PODateDue_ID= "PODateDue_ID";
        public static String ToolCost_ID= "ToolCost_ID";
        public static String ReceiptNumber_ID= "ReceiptNumber_ID";
        public static String ReceiptDate_ID= "ReceiptDate_ID";
        public static String ToolGLcode_ID= "ToolGLcode_ID";
        public static String SupplierPurchaseDescription_ID= "SupplierPurchaseDescription_ID";
        public static String PricingType_ID= "PricingType_ID";
        public static String InvoiceCustomer_ID= "InvoiceCustomer_ID";
        public static String SalesPrice_ID= "SalesPrice_ID";
        public static String SaleToolGLcode_ID= "SaleToolGLcode_ID";
        public static String SalesRep_ID= "SalesRep_ID";
        public static String Invocicegeneration_ID= "Invocicegeneration_ID";
        public static String customerPO_ID= "customerPO_ID";
        public static String CustomerInvoiceDescription_ID= "CustomerInvoiceDescription_ID";
        public static String Save_ID= "Save_ID";
        public static String Order_ID= "Order_ID";
        public static String SetExisting_ID= "SetExisting_ID";
        public static String Cancel_ID= "Cancel_ID";
        public static String HomeLocationDropdown_XPATH = "HomeLocationDropdown_XPATH";
        public static String CurrLocationDropdown_XPATH="CurrLocationDropdown_XPATH";
        public static String SupplierDropdown_XPATH = "SupplierDropdown_XPATH";
        public static String  AvailableDate_ID ="AvailableDate_ID";
        public static String PurchasingGLCode_XPATH = "PurchasingGLCode_XPATH";
        public static String PricingTypeDropdown_XPATH="PricingTypeDropdown_XPATH";
        public static String CustomerDropdown_XPATH="CustomerDropdown_XPATH";
        public static String SalesGLDropdown_XPATH ="SalesGLDropdown_XPATH";
        public static String  SalesRepDropdown_XPATH ="SalesRepDropdown_XPATH";
        public static String  FilterToolID_ID ="FilterToolID_ID";
         public static String ToolFilter_ID = "ToolFilter_ID";
        public static String tooltable_CSS = "tooltable_CSS";
        public static String  PricingTypeDropdown_CSS ="PricingTypeDropdown_CSS";
        public static String Receive_ID="Receive_ID";
        public static String ToolStatusReceive_XPATH="ToolStatusReceive_XPATH";
        public static String  Filtertoolpage_CSS = "Filtertoolpage_CSS";


        //*****************************PO Processing **************************************************************
        public static String AccountingMenu_ID = "AccountingMenu_ID";
        public static String POProcessing_ID = "POProcessing_ID";
        public static String FilterTool_ID = "FilterTool_ID";
        public static String FilterPO_ID = "FilterPO_ID";
        public static String ToolNameFilter_ID = "ToolNameFilter_ID";
        public static String Table_toolgrid_XPATH = "Table_toolgrid_XPATH";
        public static String ProcessPO_ID = "ProcessPO_ID";
        public static String POstatus_XPATH="POstatus_XPATH";
        public static String FilterOrderid_ID = "FilterOrderid_ID";
        public static String  PrintOrderPOReport_ID ="PrintOrderPOReport_ID";
        public static String  ProcessPOID_XPATH ="ProcessPOID_XPATH";
        public static String FilterByMaterial_ID="FilterByMaterial_ID";
        public static String  Material_toolgrid_XPATH ="Material_toolgrid_XPATH";
        public static String MaterialProcessPOID_XPATH = "MaterialProcessPOID_XPATH";

        //*****************************MaterialPO created **************************************************************
             public static String CreatePOMaterial_ID = "CreatePOMaterial_ID";
              public static String Supplier_ID = "Supplier_ID";
              public static String Warehouse_ID = "Warehouse_ID";
            public static String TrasportMode_ID = "TrasportMode_ID";
            public static String SelectMaterial_ID = "SelectMaterial_ID";
            public static String MaterialSupplierDropdown_XPATH = "MaterialSupplierDropdown_XPATH";
        public static String WarehousDropdown_XPATH = "WarehousDropdown_XPATH";
        public static String TrasportModeDropdown_XPATH = "TrasportModeDropdown_XPATH";
        public static String MaterialIDSearch_CSS = "MaterialIDSearch_CSS";
        public static String MaterialFilter_CSS = "MaterialFilter_CSS";
        public static String MaterialSelectCheckbox_CSS = "MaterialSelectCheckbox_CSS";
        public static String AddMaterialPO_ID = "AddMaterialPO_ID";
        public static String SavePO_ID = "SavePO_ID";
        public static String PurcahsingMenu_ID ="PurcahsingMenu_ID";
        public static String PurchaseMaterial_ID ="PurchaseMaterial_ID";
        public static String  MaterialMode_ID = "MaterialMode_ID";
        //*****************************BoardlPO created **************************************************************
        public static String PrucaseboardOrderID_ID = "PrucaseboardOrderID_ID";
        public static String PurchaseBoardSearch_ID = "PurchaseBoardSearch_ID";
        public static String BoardList_XPATH = "BoardList_XPATH";
        public static String BoardList_ID = "BoardList_ID";
        public static String BoardListOrder_XPATH = "BoardListOrder_XPATH";
        public static String CreateBoardPO_CSS = "CreateBoardPO_CSS";
        public static String BoardProcessPO_ID = "BoardProcessPO_ID";
        public static String BoradSupplier_CSS ="BoradSupplier_CSS";
        public static String PurcahseboardMenu_ID="PurcahseboardMenu_ID";
        public static String  SupplierlistPO_XPATH ="SupplierlistPO_XPATH";
        public static String selectBoadPrint_XPATH="selectBoadPrint_XPATH";
        public static String selectBoadPOValue_XPATH="selectBoadPOValue_XPATH";
        //*****************************Receiveing PO **************************************************************
        public static String POReceving_ID ="POReceving_ID";
        public static String receiveSpplier_ID ="receiveSpplier_ID";
        public static String ReceiveBoard_ID ="ReceiveBoard_ID";
        public static String Shipment_ID ="Shipment_ID";
        public static String AddRecepietLine_CSS ="AddRecepietLine_CSS";
        public static String POinputReceive_CSS = "POinputReceive_CSS";
        public static String ReceiveUnit_ID ="ReceiveUnit_ID";
        public static String UnitQty_ID ="UnitQty_ID";
        public static String LatUnitQty_ID ="LatUnitQty_ID";
       public static String VendorID_ID ="VendorID_ID";
        public static String SaveReceivePO_ID ="SaveReceivePO_ID";
        public static String ReceiveSupplierPO_XPATH="ReceiveSupplierPO_XPATH";
        public static String  ReceivePOid_XPATH ="ReceivePOid_XPATH";
        //*****************************Payable Receipts**************************************************************

        public static String AcountingMenu_ID = "AcountingMenu_ID";
        public static String Payablereceipts_ID = "Payablereceipts_ID";
        public static String FilterByPOid_ID = "FilterByPOid_ID";
        public static String TypeOfreceipt_ID = "TypeOfreceipt_ID";
        public static String filterByCustomer_ID = "filterByCustomer_ID";
        public static String SerachReceipt_ID = "SerachReceipt_ID";
        public static String InvoiceDate_ID = "InvoiceDate_ID";
        public static String Beginpayable_ID = "Beginpayable_ID";
        public static String VendorIDReceipt_ID = "VendorIDReceipt_ID";
        public static String  receiptTable_ID ="receiptTable_ID";
        public static String CompletePay_ID="CompletePay_ID";
        public static String PayableCustomerDropdown_XPATH = "PayableCustomerDropdown_XPATH";
        public static String PayableDropdown_XPATH = "PayableDropdown_XPATH";
        public static String filterByStatus_ID="filterByStatus_ID";
        public static String POvalue_XPATH = "POvalue_XPATH";
        public static String  PayablereceiptsSearch_ID = "PayablereceiptsSearch_ID";
        public static String ReceiptTable_XPATH = "ReceiptTable_XPATH";
        public static String  SavePayable_ID ="SavePayable_ID";
        public static String  closebatchReceipt_ID = "closebatchReceipt_ID";
        public static String FilterByPO_ID = "FilterByPO_ID";
        //*****************************Quotation Report**************************************************************
        public static String CuatomerName_ID = "CuatomerName_ID";
        public static String Salutation_ID = "Salutation_ID";
        public static String QuotationBusinessStatus_ID = "QuotationBusinessStatus_ID";
        public static String QuotationApprovedStatus_ID = "QuotationApprovedStatus_ID";
        public static String QuotationEffectiveStartDate_ID = "QuotationEffectiveStartDate_ID";
        public static String findquotationestimateprices_ID = "findquotationestimateprices_ID";
        public static String filterBySpecId_ID = "filterBySpecId_ID";
        public static String estimatessearchfilter_ID = "estimatessearchfilter_ID";
        public static String Tablelist_XPATH = "Tablelist_XPATH";
        public static String addquotationestimates_ID = "addquotationestimates_ID";
        public static String MainTableList_XPATH = "MainTableList_XPATH";
        public static String Save_Link = "Save_Link";
        public static String QuotationReport_ID = "QuotationReport_ID";
        public static String  quotationMenuLInk_ID ="quotationMenuLInk_ID";
        public static String Create_New_LINK="Create_New_LINK";
        public static String  searchquotationdialog_ID ="searchquotationdialog_ID";
        public static String searchquotationdialog_CSS="searchquotationdialog_CSS";
        public static String CustomerSelectDropdown_XPATH="CustomerSelectDropdown_XPATH";

















    }



















    public class PropertyReader
    {
        public static string GetProperty(string key, ApplicationSettingsBase propertyClass)
        {
            SettingsProperty result = null;
            try
            {
                result = propertyClass.Properties[key];
            }
            catch
            {

            }

            if (result != null)
                return result.DefaultValue.ToString();

            return string.Empty;
        }

        internal static string GetProperty(string shipToDropDown_XPATH, int v)
        {
            throw new NotImplementedException();
        }
    }
}



