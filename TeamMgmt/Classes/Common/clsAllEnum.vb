Imports System.Data.SqlClient
Imports common
Imports System.IO
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Drawing



'Public Class clsEmailSMSConstants
'    '----------------complaint detail entry-------------
'    Public Const Complnt_code As String = "$comp_id$"
'    Public Const Assetcode As String = "$item_code$"
'    Public Const outlet As String = "$cust_code$"
'    Public Const complnt_date As String = "$comp_date$"
'    Public Const SerivceDealer As String = "$Executive_Code$"
'    '---------------------------------------------------


'    '----------------HR EM Resignation Letter-------------
'    Public Const doccode As String = "$doccode$"
'    Public Const docdate As String = "$docdate$"
'    Public Const EmpCode As String = "$EmpCode$"
'    Public Const EmpName As String = "$EmpName$"
'    Public Const DepCode As String = "$DepCode$"
'    Public Const DepName As String = "$DepName$"
'    Public Const ResonOfResignation As String = "$ResonOfResignation$"
'    Public Const ResignationDate As String = "$ResignationDate$"
'    Public Const Remarks As String = "$Remarks$"
'    Public Const HandoverCode As String = "$HandoverCode$"
'    Public Const HandoverName As String = "$HandoverName$"
'    '---------------------------------------------------

'    '----------------Sale Order------------------------
'    Public Const SaleOrderNo As String = "$DocNo$"
'    Public Const SaleOrderDate As String = "$DocDate$"
'    Public Const VendorNo As String = "$VendorNo$"
'    Public Const VendorName As String = "$VendorName$"
'    Public Const ContactPerson As String = "$ContactPerson$"
'    Public Const TotalAmount As String = "$TotalAmount$"
'    Public Const RoundOffAmount As String = "$RoundOffAmount$"
'    '------------------------------------------------------

'    '----------------Delivery Note Fresh Sale------------------------
'    Public Const DeliveryNo As String = "$DocNo$"
'    Public Const DeliveryDate As String = "$DocDate$"
'    Public Const LocationCode As String = "$LocationCode$"
'    Public Const LocationName As String = "$LocationName$"
'    Public Const BookingNo As String = "$BookingNo$"
'    '------------------------------------------------------

'    Public Const CustomerNo As String = "$CustomerNo$"
'    Public Const CustomerName As String = "$CustomerName$"
'    Public Const InvoiceNo As String = "$Purchase InvoiceNo$"

'    '---------------Sale register------------------
'    Public Const FromDate As String = "$From Date$"
'    Public Const ToDate As String = "$To Date$"
'    Public Const ReportType As String = "$Summary Or Detail$"
'    Public Const InvoiceType As String = "$Invoice Type$"
'    '----------------Purchase Requistion------------------------
'    Public Const PurchaseRequisitionNo As String = "$PurchaseRequisitionNo$"
'    Public Const PurchaseRequisitionDate As String = "$PurchaseRequisitionDate$"

'    'Public Const VendorNo As String = "$VendorNo$"
'    'Public Const VendorName As String = "$VendorName$"
'    'Public Const ContactPerson As String = "$ContactPerson$"
'    'Public Const TotalAmount As String = "$TotalAmount$"
'    '------------------------------------------------------
'    '---------------Quality Check------------------
'    Public Const QcNo As String = "$QC No$"
'    Public Const inDateTime As String = "$In Date Time$"
'    Public Const outDateTime As String = "$Out Date Time$"

'    Public Const Form_Code As String = "$FormId$"
'    Public Const UserCode As String = "$UserCode$"

'    '-------------RFQ---------------------
'    Public Const RFQ_No As String = "$DOC No$"
'    Public Const RFQ_Date As String = "$DOC DATE$"
'    Public Const Request_No As String = "$REQ NO$"
'    Public Const Request_Date As String = "$REQ Date$"
'    Public Const Request_Amount As String = "$REQ Amt$"
'    '-----------------------------------------------------

'    '' Anubhooti 25-Aug-2014 BM00000003528
'    '-------------Offer Letter HR---------------------
'    Public Const App_No As String = "$Applicant No$"
'    Public Const Offer_Date As String = "$Offer Date$"
'    Public Const DOJ As String = "$DOJ$"
'    Public Const Salary As String = "$Salary$"
'    Public Const ApplicantName As String = "$Applicant Name$"
'    '' Anubhooti 25-Aug-2014 BM00000003528
'    '-------------Appointment Letter HR---------------------
'    Public Const Appointment_Date As String = "$Appointment Date$"
'    '-----------------------------------------------------
'    '' Anubhooti 20-Oct-2015 BM00000008219
'    '-------------Service Call SW---------------------
'    Public Const Call_No As String = "$Service Call No$"
'    Public Const Call_Date As String = "$Call Date$"
'    Public Const Problem_Type As String = "$Problem_Type$"
'    Public Const Subject As String = "$Subject$"
'    Public Const ItemPartNo As String = "$Item Part No$"
'    Public Const IssueNotice As String = "$Issue Notice$"
'    Public Const AssignedTo As String = "$Assigned To$"
'    Public Const AssignedBy As String = "$Assigned By$"
'    '=================CSA DO====================
'    Public Const DOC_NO As String = "$Document No$"
'    Public Const DOC_Date As String = "$Document Date$"
'    Public Const Cust_Name As String = "$CSA Name$"
'    Public Const From_Location As String = "$From Location$"
'    Public Const RT_Detail As String = "$RT Rate And UOM$"
'    Public Const CSA_Item_Type As String = "$CSA Item Type$"
'    Public Const Doc_Amount As String = "$Document Amount$"

'    '-------------Leave Application---------------------
'    Public Const Leave_App_No As String = "$Application No$"
'    Public Const Application_Date As String = "$Application Date$"
'    Public Const Leave_From As String = "$Leave From$"
'    Public Const Leave_To As String = "$Leave To$"
'    Public Const Leave_Type As String = "$Leave Type$"
'    Public Const Leave_Days As String = "$Leave Days$"
'    Public Const Leave_Reason As String = "$Leave Reason$"
'    Public Const Employee_Name As String = "$Employee Name$"
'    Public Const EMP_CODE As String = "$Employee Code$"

'    '-------------Employeee Master---------------------
'    Public Const Birth_Date As String = "$Birth Date$"
'    Public Const AnniversaryDate As String = "$Anniversary Date$"
'    Public Const ProbPeriodEnDate As String = "$Probation Period End Date$"

'    '----------------Milk Shift End------------------------
'    Public Const Doc_Code As String = "$DocNo$"
'    'Public Const Doc_Date As String = "$DocDate$"
'    Public Const Mcc_Code As String = "$Mcc_Code$"
'    Public Const Mcc_Name As String = "$Mcc_Name$"
'    Public Const Shift As String = "$Shift$"
'    Public Const User_Code As String = "$Created_By$"
'    Public Const State_Name As String = "$State$"
'    Public Const Total_collection As String = "$Total_collection$"

'    Public Const FAT As String = "$FAT$"
'    Public Const SNF As String = "$SNF$"
'    Public Const Rate As String = "$Rate$"
'    Public Const Amount As String = "$Amount$"

'    Public Const UOM As String = "$UOM$"
'    ''richa agarwal against ticket no BM00000008361
'    Public Const VLCCode As String = "$VLC_Code$"
'    Public Const VLCUploaderCode As String = "$VLCUploaderCode$"
'    Public Const VLCName As String = "$VLC_Name$"
'    Public Const CowQty As String = "$Cow_Qty$"
'    Public Const BuffaloQty As String = "$Buffalo_Qty$"
'    Public Const CowFat As String = "$CowFat_%$"
'    Public Const BuffaloFat As String = "$BuffaloFat%$"
'    Public Const CowSNF As String = "$CowSNF_%$"
'    Public Const BuffaloSNF As String = "$BuffaloSNF%$"
'    Public Const CowAmount As String = "$Cow_Amount$"
'    Public Const BuffaloAmount As String = "$Buffalo_Amount$"

'    '----------------MCC Master------------------------
'    Public Const Shift_Open_Time As String = "$Shift_Open_Time$"
'    Public Const Total_Route As String = "$Total_Route$"
'    Public Const Total_Vlc As String = "$Total_Vlc$"
'    Public Const Shift_Close_Time As String = "$Shift_Close_Time$"
'    '------------------------------------------------------

'    Public Const CompanyName As String = "$CompanyName$"
'End Class

'Public Class AdjustmentEnum
'    Public Const strCostTransaction As String = "Store Adjustment"
'    Public Const strJWInvetoryTrans As String = "Job Work Inventory"
'    Public Const strCostTransactionProductionEntry As String = "Production Entry"
'    Public Const strCostTransactionEmpty As String = "Empty Transactions"
'End Class

Public Class clsEmailAndSMSRecipients
    Public Const strTransTrype As String = "POS"
End Class

Public Enum EnumTaxCalucationType
    Automatic = 0
    Mannual = 1
End Enum

Public Enum EnumControlType
    CheckBox = 0
    TextBox = 1
    NumericBox = 2
End Enum
Public Enum EnumTecxpertPaperSize
    NA = 0
    PaperSize10x12 = 1
    PaperSize10x6 = 2
    Guntur10x12 = 3
    HalfLegal85x7 = 4
End Enum

Public Enum EnumExportTo
    Excel = 0
    PDF = 1
    Refresh = 2
End Enum

Public Enum EnuChartType
    Bar = 1
    Pie = 2
    Line = 3
    Area = 4
End Enum

Public Enum EnumCustomFieldType
    TextType = 0
    NumberType = 1
    DateType = 2
    CheckType = 3
    FinderType = 4
    ComboListBoxType = 5
    PictureType = 6
    MultilineTextType = 7
    Buttons = 8
    RadioButtonType = 9
    GridType = 10


End Enum

Public Enum EnumConditionType
    StartsWith = 0
    DoesNotStartsWith = 1
    EndsWith = 2
    DoesNotEndsWith = 3
    EqualsTo = 4
    DoesNotEqualsTo = 5
    Contains = 6
    DoesNotContains = 7
    Between = 8
    GreaterThan = 9
    GreaterThanOrEquals = 10
    LessThan = 11
    LessThanOrEquals = 12
End Enum

Public Enum EnumCostingMethod
    NA = 0
    Averege = 1
    FIFO = 2
    LIFO = 3
    AveregeIn = 4
End Enum

Public Enum DBDataType
    image_Type = 0
    int_Type = 1
    decimal_Type = 2
    varbinary_Type = 3
    text_Type = 4
    datetime_Type = 5
    time_Type = 6
    varchar_Type = 7
    numeric_Type = 8
    nchar_Type = 9
    float_Type = 10
    date_Type = 11
    char_Type = 12
    bigint_Type = 13
    bit_Type = 14
    nvarchar_Type = 15
    NotApplicable = 16
End Enum

Public Enum PostingColumnType
    TEXT
    NUMBER
End Enum

Public Enum PostingStatusValueList
    YES
    Y
    ONE
End Enum

Public Enum Exporter
    Excel = 0
    PDF = 1
    Print = 2
    Refresh = 3
End Enum

Public Enum CrystalReportFolder
    Purchase = 1
    FixedAssets = 2
    CommonServices = 3
    GeneralLedger = 4
    HRPayroll = 5
    HumanResource = 6
    InventoryReport = 7
    KwalitySalesReport = 8
    MilkProcurement = 9
    NewSalesReports = 10
    PRODUCTION = 11
    PurchaseOrder = 12
    SalesReport = 13
    ServiceReport = 14
    TDS = 15
    UtilityReports = 16
End Enum


Public Class clsItemRowType
    Public Const RowTypeItem As String = "Item"
    Public Const RowTypeMisc As String = "Misc"
End Class
Public Class MIlkComponentType
    Public FAT_Per As Decimal = 0
    Public SNF_Per As Decimal = 0
    Public FAT_Cost As Decimal = 0
    Public SNF_Cost As Decimal = 0
    Public FAT_Kg As Decimal = 0
    Public SNF_Kg As Decimal = 0
End Class

Public Enum EnumTransType
    JournalEntry
    RcptEntry
    PymntEntry
    BankTransfer
    LoadOut
    SaleInvoice
    PurchaseInvoice
    SRN
    ICAdj
    MMTrans
    BankRvrs
    RcptADJ
    APInvoice
    SaleOrder
    SaleReturn
    SaleReturnInter
    ARInvoice
    PurchaseReturn
    ScrapInvoice
    ScrapShipment
    IssueReturnTransfer
    NRGP
    RGP
    SDShipment
    SDSaleReturn
    SaleInvoiceDemo
    Assemblies
    WareHouseBreakage
    VCGL
    APInvoiceTDS
    SaleQuotation
    GLAccount
    frmSalesmanTarget
    PuchaseOrder
    PurchaseIndent
    ExpiredItemEntry
    MilkSRN
    MilkPI
    productionEntry
    transfer
    SDCSATrans
    SDCSASale
    SDCSADO
    Bank_Guarantee_Master
    RICE_PROC
    RICE_MIX
    PP_ISSUE
    MCC_Material
    EXPORT_SO
    EXPORT_QUOTATION
    EXPORT_PROFORMA
    DispChallan
    MilkTransferIn
    Fresh_Sale
    Sale_Return
    Product_Invoice
    Product_Return_Sale
    CSA_Invoice
    EXPORT_Invoice
    Bulk_Invoice
    Bulk_Return
    CrateReceived
    InvoiceFreshSale
    MCCMaterialFrm
    SD_CSATRANS_RETURN
    MCCMaterialSaleReturn
    Export_Commercial_Inv
    PP_STDN
    PP_SP
    BulkSRNTrade
    DispatchBSTrade
    DispatchBS
    BulkSRN
    PRD_STG_PROC
    VSPTRAN
    PROD_ENTRY
    Export_Sale_Return
    FS_SH
    PS_SH
    MCC_MSRN
    MT_Sale_Order
    MT_Proforma
    MT_Comm_Inv
    MT_Sale_Inv
    MT_Sale_Ret
    MT_Sale_Qu
    MilkReceipt
    Mcc_transfer
    Bulk_Purchase
    GRN
    MRN
    VendorServiceCharge
    ComplaintDetailEntry
    DeliveryOrderPS
    Bulk_Purchase_Return
    Jobwork_Transfer_Milk
    Jobwork_Transfer_Other
End Enum

'Public Class clsOpenTransactionForm

'    Dim strRvalue As String = ""
'    Function getNavigatorValue(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing) As String
'        If clsCommon.myLen(strRvalue) > 0 Then
'            Return strRvalue
'            Exit Function
'        End If

'        If IsNothing(contrl) Then
'            For Each ctrl As Control In formname.Controls
'                If ctrl.HasChildren = True Then
'                    'getNavigatorValue(Me, ctrl)
'                End If
'                If TypeOf (ctrl) Is common.UserControls.txtNavigator Then
'                    Try
'                        strRvalue = clsCommon.myCstr(CType(ctrl, common.UserControls.txtNavigator).Value)
'                    Catch ex As Exception
'                        MessageBox.Show(ex.ToString)
'                    End Try
'                End If
'            Next
'        Else
'            For Each ctrl As Control In contrl.Controls
'                If ctrl.HasChildren = True Then
'                    ' getNavigatorValue(Me, ctrl)
'                End If
'                If TypeOf (ctrl) Is common.UserControls.txtNavigator Then
'                    Try
'                        strRvalue = clsCommon.myCstr(CType(ctrl, common.UserControls.txtNavigator).Value)
'                    Catch ex As Exception
'                        MessageBox.Show(ex.ToString)
'                    End Try
'                End If
'            Next
'        End If
'        If clsCommon.myLen(strRvalue) > 0 Then
'            Return strRvalue
'            Exit Function
'        End If
'        Return ""
'    End Function

'    Public Shared Sub OpenTransacionForm(ByVal TransType As EnumTransType, ByVal DocumnetNo As String)
'        'clsCommon.ProgressBarShow()
'        'clsCommon.ProgressBarUpdate("Opening Transacion.Please wait...")
'        Try
'            Select Case TransType
'                Case EnumTransType.JournalEntry
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.journalEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmJournalEntry(objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode)
'                    'frm.strVoucherNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.RcptEntry
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.ReceiptEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmReceipttNew
'                    'frm.strRcptNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.DispChallan
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMCCDispatch
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmMccDispatch
'                    'frm.strDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MilkTransferIn
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMilkTransferIn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmMilkTransferIn
'                    'frm.strDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PymntEntry
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.PaymentEntryNew
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmPaymentNew()
'                    'frm.strPaymentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.LoadOut
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.LoadOut
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmShipmentInvoice()
'                    'frm.strLoadOutNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.APInvoice
'                    If clsCommon.CompairString(clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Invoice_Type from TSPL_VENDOR_INVOICE_HEAD WHERE Document_No='" & DocumnetNo & "'")), "VS") = CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmVendorService
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New FrmVendorService()
'                        'frm.text = "Vendor Service Charge"
'                    Else
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnAPInvoiceEntry
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New FrmAPInvoiceEntry()
'                    End If
'                    'frm.strAPInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.BankTransfer
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.bankTransfer
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmBankTransfer(objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode)
'                    'frm.strbankTrans = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SRN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnSRN
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSRN()
'                    'frm.strSRNno = DocumnetNo
'                    'frm.FORMTYPE = clsUserMgtCode.mbtnSRN
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.InvoiceFreshSale
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmInvoiceFreshSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmInvoiceFreshSale()
'                    'frm.strSRNno = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()

'                Case EnumTransType.CrateReceived
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCreateReceived
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    ''frm = New frmCreateReceived()
'                    ''frm.strCrateReceived = DocumnetNo
'                    ''frm.WindowState = FormWindowState.Maximized
'                    ''frm.Show()

'                Case EnumTransType.PuchaseOrder
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnPurchaseOrder
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmPurchaseOrder(clsUserMgtCode.mbtnPurchaseOrder)
'                    'frm.PurchaseOrderNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PurchaseIndent
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnPurchaseRequistion
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmPurchaseOrder(clsUserMgtCode.mbtnPurchaseOrder)
'                    'frm.PurchaseOrderNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.ExpiredItemEntry
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmExpiryDateEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmExpiryDateEntry()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                    'Case EnumTransType.MMTrans
'                    '    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmExpiryDateEntry
'                    '    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmTransferNew(objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode)
'                    'frm.strTrnasfer = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.BankRvrs
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.reverseTransaction
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmReverseTransaction(objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode)
'                    'frm.strBankRvrse = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.ICAdj

'                    Dim strAdjustmentType As String = ClsAdjustments.GetTransactionType(DocumnetNo, Nothing)
'                    'Dim strCode As String
'                    'Dim qry As String
'                    'qry = "select TSPL_ADJUSTMENT_DETAIL.Adjustment_No  from TSPL_ADJUSTMENT_DETAIL where adjustment_No='" & DocumnetNo & "'"
'                    'Dim strCodeAdjustment As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry))

'                    'qry = "select TSPL_ADJUSTMENT_DETAIL.Adjustment_No  from TSPL_ADJUSTMENT_DETAIL "
'                    'Dim strCodeAdjustmentProduction As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry))

'                    'qry = "select TSPL_ADJUSTMENT_DETAIL.Adjustment_No  from TSPL_ADJUSTMENT_DETAIL "
'                    'Dim strCodeStoreAdjustment As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry))

'                    If common.clsCommon.CompairString(AdjustmentEnum.strCostTransactionEmpty, strAdjustmentType) = common.CompairStringResult.Equal Then
'                        'frm = New frmAdjustmentEmpty()
'                        'frm.strDocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnEmptyTrans
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo



'                    ElseIf common.clsCommon.CompairString(AdjustmentEnum.strCostTransactionProductionEntry, strAdjustmentType) = common.CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnProductionEntry
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmAdjustmentProduction()
'                        'frm.strDocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    ElseIf common.clsCommon.CompairString(AdjustmentEnum.strCostTransaction, strAdjustmentType) = common.CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnStoreAdjustment
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmAdjustmentStore()
'                        'frm.strDocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    End If
'                Case EnumTransType.SaleInvoice
'                    'frm = New frmShipmentInvoice()
'                    'frm.strLoadOutNo = common.clsCommon.myCstr(common.clsDBFuncationality.getSingleValue("select Shipment_No from TSPL_SALE_INVOICE_HEAD where Sale_Invoice_No='" + DocumnetNo + "'"))
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()

'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNSaleInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSNSaleInvoice
'                    'frm.DocumentNo = DocumnetNo 'common.clsCommon.myCstr(common.clsDBFuncationality.getSingleValue("select Against_Shipment_No from TSPL_SD_SALE_INVOICE_HEAD where Document_Code='" + DocumnetNo + "'"))
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.MdiParent = MDI
'                    'frm.Show()
'                Case EnumTransType.SaleInvoiceDemo
'                    Dim strInvType As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Invoice_Type from TSPL_SD_SALE_INVOICE_HEAD where Document_Code='" & DocumnetNo & "' "))
'                    If clsCommon.CompairString(strInvType, "S") = CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNServiceInvoice
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmSNServiceInvoice()
'                        'frm.strSaleInvoice = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    Else
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNSaleInvoice
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmSNSaleInvoice()
'                        'frm.strSaleInvoice = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    End If


'                Case EnumTransType.RcptADJ
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.ReceiptAdjustmentEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmAdj()
'                    'frm.strAdjNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PurchaseInvoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnPurchaseInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmPurchaseInvoice()
'                    'frm.strPOInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.frmSalesmanTarget
'                    'frm = New FrmSalesmanTarget()
'                    'frm.Code = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PurchaseReturn
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnPurchaseReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmPurchaseReturn()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SaleReturn, EnumTransType.SaleReturnInter
'                    Dim qry As String = "select 1 from TSPL_SALE_RETURN_HEAD where Sale_Return_No='" + DocumnetNo + "'"
'                    Dim dt As DataTable = common.clsDBFuncationality.GetDataTable(qry)
'                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNSaleReturn
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmSNSaleReturn()
'                        'frm.DocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    Else
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.saleReturn
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmSalesReturnNew()
'                        'frm.strPOInvoice = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    End If
'                Case EnumTransType.ARInvoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnARInvoiceEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmARInvoiceEntry()
'                    'frm.strAPInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.ScrapInvoice
'                    Dim qry As String = "SELECT shipment_No from TSPL_SCRAPINVOICE_HEAD where invoice_No='" + DocumnetNo + "'"
'                    Dim dt As DataTable = common.clsDBFuncationality.GetDataTable(qry)
'                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.ScrapSale
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmScrapSale()
'                        'frm.strShipmentno = clsCommon.myCstr(dt.Rows(0)("shipment_No"))
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    End If
'                Case EnumTransType.ScrapShipment
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.ScrapSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmScrapSale()
'                    'frm.strShipmentno = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.IssueReturnTransfer
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnIssueReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmIssueReturn()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.RGP
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnGatePass
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmRGP()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.NRGP
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnGatePass
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmRGP()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SDShipment
'                    Dim strDocType As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Trans_Type from TSPL_SD_SHIPMENT_HEAD where Document_Code='" + DocumnetNo + "'"))
'                    If clsCommon.CompairString(strDocType, "PS") = CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmShipmentProductSale
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmShipmentProductSale()
'                        'frm.DocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    ElseIf clsCommon.CompairString(strDocType, "FS") = CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmDispatchFreshSale
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmDispatchNoteFreshSale()
'                        'frm.DocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    Else
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNShipment
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmSNShipment()
'                        'frm.DocumentNo = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                    End If
'                    '===============================================================================

'                Case EnumTransType.SDSaleReturn
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNSaleReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSNSaleReturn()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Assemblies
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmAssemblies
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmAssemblies()
'                    'frm.Document_No = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.WareHouseBreakage
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmWarehouseBreakage
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmWarehouseBreakage()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.VCGL
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnVCGLEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmVCGLEntry()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.APInvoiceTDS
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnAPInvoiceEntryTDS
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmAPInvoiceEntryTDS()
'                    'frm.strAPInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SaleQuotation
'                    'Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNShipment
'                    'Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSaleQuotation()
'                    'frm.DocCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SaleOrder
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSNSalesOrder
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSNSalesOrder()
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.GLAccount
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.glAccount
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmGLAccount(objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode)
'                    'frm.strAccountCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.productionEntry
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnProductionEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmAdjustmentProduction()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.transfer
'                    'frm = New frmTransferDCC()
'                    'frm.strTransferno = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                    If clsCommon.CompairString(objCommonVar.CurrentCompanyCode, "KL") = CompairStringResult.Equal Then
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.Transfer
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New FrmTransferKDIL()
'                        'frm.strTransferno = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                        'formShow(frm, strProgramName)
'                    Else
'                        Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.Transfer
'                        Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                        'frm = New frmTransferDCC()
'                        'frm.strTransferno = DocumnetNo
'                        'frm.WindowState = FormWindowState.Maximized
'                        'frm.Show()
'                        'formShow(frm, strProgramName)
'                    End If
'                    '===============================================================================
'                Case EnumTransType.SDCSATrans
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCSATransfer
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmCSATransfer()
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SDCSASale
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCSASaleInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmCSASaleInvoice()
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SDCSADO
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCSADeliveryOrder
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmCSADeliveryOrder()
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Bank_Guarantee_Master
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmBankGuaranteeMaster1
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmBankGuaranteeMaster1()
'                    'frm.strPaymentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MilkSRN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMilkSRN
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmMilkSRNMCC()
'                    'frmMilkSRNMCC.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MilkPI
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMilkPurchaseInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmMilkPurchaseInvoiceMCC()
'                    'frmMilkPurchaseInvoiceMCC.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.RICE_MIX
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmRiceMixingEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmRiceMixingEntry()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.RICE_PROC
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmRiceProcessingEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmRiceProcessingEntry()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PP_ISSUE
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmProcessProductionIssueEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmProcessProductionIssueEntry()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MCC_Material
'                    DocumnetNo = clsDBFuncationality.getSingleValue("select Document_Code from TSPL_SD_shipment_HEAD where sale_Invoice_No='" & DocumnetNo & "'")
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMCCMaterial
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmMCCMaterialSale()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MCCMaterialFrm
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMCCMaterial
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmMCCMaterialSale()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MCCMaterialSaleReturn
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMCCMaterialSaleReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmMccMaterialSaleReturn()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.EXPORT_SO
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSalesOrderMT
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXSalesOrder(clsUserMgtCode.frmEXSalesOrder)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.EXPORT_QUOTATION
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesQuotation
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmEXSalesQuotation(clsUserMgtCode.frmEXSalesQuotation)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.EXPORT_PROFORMA
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXPorformaInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXPorformaInvoice(clsUserMgtCode.frmEXPorformaInvoice)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Export_Commercial_Inv
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXCommercialInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXCommercialInvoice(clsUserMgtCode.frmEXCommercialInvoice)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Fresh_Sale
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmInvoiceFreshSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmInvoiceFreshSale()
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()

'                Case EnumTransType.Sale_Return
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSaleReturnFreshSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSaleReturnFreshSale()
'                    'frm.strSRNno = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                    '=====================================================================================================
'                Case EnumTransType.Product_Invoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSaleInvoiceProductSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSaleInvoiceProductSale()
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Product_Return_Sale
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSaleReturnProductSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmSaleReturnProductSale()
'                    'frm.strSRNno = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.CSA_Invoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCSASaleInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmCSASaleInvoice()
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.EXPORT_Invoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXSalesInvoice(clsUserMgtCode.frmEXSalesInvoice)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Bulk_Return
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmBulkSaleReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmBulkSaleReturn()
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Bulk_Invoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmInvoiceBulkSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmInvoiceBulkSale()
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.SD_CSATRANS_RETURN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCSATransferReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmCSATransferReturn()
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PP_STDN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmProcessProductionStandardization
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmProcessProductionStandardization()
'                    'frm.strDocumentCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PP_SP
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmProcessProductionStageProcess
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmProcessProductionStandardization()
'                    'frm.strDocumentCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.BulkSRNTrade
'                    'Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSaleReturnFreshSale
'                    'Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmBulkTradeSRN
'                    'frm.strDocumentCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.DispatchBSTrade
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmDispatchBulkSaleTrade
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmDispatchBulkSaleTrade
'                    'frm.strDocumentCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.DispatchBS
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmDispatchBulkSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmDispatchBulkSale
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.BulkSRN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmBulkMilkSRN
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmBulkMilkSRN
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized

'                    'frm.Show()
'                Case EnumTransType.PRD_STG_PROC
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmProcessProductionStageProcess
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmProcessProductionStageProcess
'                    'frm.strDocumentCode = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.VSPTRAN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmVSPItemIssue
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmVSPItemIssue
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PROD_ENTRY
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmProductionEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmProductionEntry
'                    'frm.strDocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Export_Sale_Return
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesReturn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXSalesReturn(clsUserMgtCode.frmEXSalesReturn)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.FS_SH
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmDispatchMultipleFreshSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmDispatchMultipleFreshSale
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PS_SH
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmShipmentProductSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmShipmentProductSale()
'                    'frm.DocumentNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MT_Sale_Order
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSalesOrderMT
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXSalesOrder(clsUserMgtCode.frmSalesOrderMT)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MT_Proforma
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmProformaInvoiceMT
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXPorformaInvoice(clsUserMgtCode.frmProformaInvoiceMT)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MT_Comm_Inv
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmCommercialInvoiceMT
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXCommercialInvoice(clsUserMgtCode.frmCommercialInvoiceMT)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MT_Sale_Inv
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSalesInvoiceMT
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXSalesInvoice(clsUserMgtCode.frmSalesInvoiceMT)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MT_Sale_Ret
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmSalesReturnMT
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmEXSalesReturn(clsUserMgtCode.frmSalesReturnMT)
'                    'frm.strSaleInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MT_Sale_Qu
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesQuotation
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmEXSalesQuotation(clsUserMgtCode.frmEXSalesQuotation)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PurchaseInvoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesQuotation
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmEXSalesQuotation(clsUserMgtCode.mbtnPurchaseInvoice)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.PurchaseInvoice
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesQuotation
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmEXSalesQuotation(clsUserMgtCode.mbtnPurchaseInvoice)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MilkReceipt
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesQuotation
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmEXSalesQuotation(clsUserMgtCode.frmMilkPurchaseInvoice)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.MilkTransferIn
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmEXSalesQuotation
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmEXSalesQuotation(clsUserMgtCode.mbtnPurchaseInvoice)
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Bulk_Purchase
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmBulkMilkPurchaseInvoice
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmMilkPurchaseInvoice
'                    'frm.tag = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.Mcc_transfer
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMilkTransferIn
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmMilkTransferIn
'                    'frm.StrDocNo = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.GRN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnGRN
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    ''frm = New frmGRN()
'                    ''frm.strGRN = DocumnetNo
'                    ''frm.WindowState = FormWindowState.Maximized
'                    ''frm.Show()
'                Case EnumTransType.MRN
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnMRN
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New frmMRN()
'                    'frm.strGRN = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.VendorServiceCharge
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.FrmVendorService
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmVendorService()
'                    'frm.strAPInvoice = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.ComplaintDetailEntry
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmComplaintDetailEntry
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                    'frm = New FrmComplaintDetailEntry()
'                    'frm.strComplaint = DocumnetNo
'                    'frm.WindowState = FormWindowState.Maximized
'                    'frm.Show()
'                Case EnumTransType.DeliveryOrderPS
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmDeliveryPrderProductSale
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo

'                Case EnumTransType.Jobwork_Transfer_Milk
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMilkJobWorkTransfer
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'                Case EnumTransType.Jobwork_Transfer_Other
'                    Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.frmMilkJobWorkTransferOther
'                    Application.OpenForms("MDI").Controls("__txtDocNo").Text = DocumnetNo
'            End Select
'        Catch ex As Exception

'        Finally
'            'clsCommon.ProgressBarHide()
'            'frm.focus()
'        End Try
'    End Sub

'End Class
