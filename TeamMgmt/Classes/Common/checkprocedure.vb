
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports Telerik.Collections.Generic
'Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Globalization
Imports common



Public Class checkprocedure
    Public Shared Sub adjustment()
        Dim dic As New Hashtable()
        dic.Add("", "")

    End Sub

End Class

Public Class ProgramCodeNew
    Public Shared Sub SetProgramCode()

        InsertDefaultValue(clsUserMgtCode.TeamMgmt, "Exam System", "0", Nothing, 32)
        '--------------Favourite----------------------------------
        InsertDefaultValue(clsUserMgtCode.ModuleFavourite, "Favourite", "0.1", clsUserMgtCode.TeamMgmt, "M", 31)
        '--------------System Administrator----------------------------------
        InsertDefaultValue(clsUserMgtCode.ModuleSystemAdmin, "System Administrator", "1.00", clsUserMgtCode.TeamMgmt, "M", 23)

        InsertDefaultValue(clsUserMgtCode.frmActivationKey, "Activation key", "1.00.01.01", clsUserMgtCode.SubModuleSystemAdminSetup, 28)
        InsertDefaultValue(clsUserMgtCode.frmCompanyMaster, "Company Master", "1.01.00.01", clsUserMgtCode.SubModuleSystemAdminSetup, 24)
        'InsertDefaultValue(clsUserMgtCode.FrmGroupProgramMapping, "Group Program Mapping", "1.00.01.02", clsUserMgtCode.SubModuleSystemAdminSetup, 28)
        'InsertDefaultValue(clsUserMgtCode.FrmUserMaster, "User Master", "1.00.01.03", clsUserMgtCode.SubModuleSystemAdminSetup, 28)
        'InsertDefaultValue(clsUserMgtCode.FrmUserGroupMaping, "User Group Mapping", "1.00.01.04", clsUserMgtCode.SubModuleSystemAdminSetup, 28)

        InsertDefaultValue(clsUserMgtCode.ModuleTicketTracker, "Exam Selector", "1.01", clsUserMgtCode.TeamMgmt, "M", 24)


        InsertDefaultValue(clsUserMgtCode.SubModuleTicketTracker, "Report", "1.01.01", clsUserMgtCode.ModuleTicketTracker, "SM", 29)
        InsertDefaultValue(clsUserMgtCode.RptExamList, "List of Exam", "1.01.01.01", clsUserMgtCode.SubModuleTicketTracker, 29)
        InsertDefaultValue(clsUserMgtCode.RptExamResult, "Exam Attempt List ", "1.01.01.02", clsUserMgtCode.SubModuleTicketTracker, 29)
        InsertDefaultValue(clsUserMgtCode.RptStudentHistoy, "Student Login History ", "1.01.01.03", clsUserMgtCode.SubModuleTicketTracker, 29)
       
        InsertDefaultValue(clsUserMgtCode.SubModuleTicketTrackerTran, "Transaction", "1.01.02", clsUserMgtCode.ModuleTicketTracker, "SM", 25)
        InsertDefaultValue(clsUserMgtCode.frmExamMaster, "Exam Set", "1.01.02.09", clsUserMgtCode.SubModuleTicketTrackerTran, "", 30, False, "", "", "", False, True, Nothing)
        InsertDefaultValue(clsUserMgtCode.FrmExamStudent, "Student Exam Mapping", "1.01.02.08", clsUserMgtCode.SubModuleTicketTrackerTran, "", 30, False, "", "", "", False, True, Nothing)
        InsertDefaultValue(clsUserMgtCode.frmExamReloader, "Exam Re-Loader", "1.01.02.09", clsUserMgtCode.SubModuleTicketTrackerTran, "", 30, False, "", "", "", False, True, Nothing)

         

    End Sub

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal ImageNumber As Integer) As Boolean
        Return InsertDefaultValue(strProgramCode, strProgramName, strSNo, strParent_Code, "", ImageNumber)
    End Function

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal strType As String, ByVal ImageNumber As Integer) As Boolean
        Return InsertDefaultValue(strProgramCode, strProgramName, strSNo, strParent_Code, strType, ImageNumber, Nothing)
    End Function

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal strType As String, ByVal ImageNumber As Integer, ByVal trans As SqlTransaction) As Boolean
        Return InsertDefaultValue(strProgramCode, strProgramName, strSNo, strParent_Code, strType, ImageNumber, False, "", "", "", trans)
    End Function

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal strType As String, ByVal ImageNumber As Integer, IsRunFromOtherAsm As Integer, AddAs As String, AsmPath As String, FormName As String, ByVal trans As SqlTransaction) As Boolean
        Return InsertDefaultValue(strProgramCode, strProgramName, strSNo, strParent_Code, strType, ImageNumber, IsRunFromOtherAsm, AddAs, AsmPath, FormName, False, False, trans)
    End Function

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal strType As String, ByVal ImageNumber As Integer, IsRunFromOtherAsm As Integer, AddAs As String, AsmPath As String, FormName As String, ByVal Is_SMS_Applied As Boolean, ByVal Is_EMAIL_Applied As Boolean, ByVal trans As SqlTransaction) As Boolean
        Return InsertDefaultValue(strProgramCode, strProgramName, strSNo, strParent_Code, strType, ImageNumber, IsRunFromOtherAsm, AddAs, AsmPath, FormName, Is_SMS_Applied, Is_EMAIL_Applied, False, trans)
    End Function

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal strType As String, ByVal ImageNumber As Integer, IsRunFromOtherAsm As Integer, AddAs As String, AsmPath As String, FormName As String, ByVal Is_SMS_Applied As Boolean, ByVal Is_EMAIL_Applied As Boolean, ByVal Is_Notification_Applied As Boolean, ByVal trans As SqlTransaction) As Boolean
        Return InsertDefaultValue(strProgramCode, strProgramName, strSNo, strParent_Code, strType, ImageNumber, IsRunFromOtherAsm, AddAs, AsmPath, FormName, Is_SMS_Applied, Is_EMAIL_Applied, Is_Notification_Applied, "", trans)
    End Function

    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strSNo As String, ByVal strParent_Code As String, ByVal strType As String, ByVal ImageNumber As Integer, IsRunFromOtherAsm As Integer, AddAs As String, AsmPath As String, FormName As String, ByVal Is_SMS_Applied As Boolean, ByVal Is_EMAIL_Applied As Boolean, ByVal Is_Notification_Applied As Boolean, ByVal AmdPassword As String, ByVal trans As SqlTransaction) As Boolean
        Dim qry As String = "select PROGRAM_NAME from TSPL_PROGRAM_MASTER where Program_Code='" + strProgramCode + "' "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

        Dim coll As New Hashtable()
        clsCommon.AddColumnsForChange(coll, "Program_Name", strProgramName)
        clsCommon.AddColumnsForChange(coll, "SNo", strSNo)
        clsCommon.AddColumnsForChange(coll, "Type", strType)
        clsCommon.AddColumnsForChange(coll, "Parent_Code", strParent_Code, True)
        clsCommon.AddColumnsForChange(coll, "Image_Number", ImageNumber)
        clsCommon.AddColumnsForChange(coll, "IsLoadFromOtherAssembly", clsCommon.myCdbl(IsRunFromOtherAsm))
        clsCommon.AddColumnsForChange(coll, "OtherAssemblyFilePathAndName", clsCommon.myCstr(AsmPath))
        clsCommon.AddColumnsForChange(coll, "FormName", clsCommon.myCstr(FormName))
        clsCommon.AddColumnsForChange(coll, "addAs", clsCommon.myCstr(AddAs))
        clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
        clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy"))

        clsCommon.AddColumnsForChange(coll, "Is_SMS_Applied", IIf(Is_SMS_Applied, 1, 0))
        clsCommon.AddColumnsForChange(coll, "Is_EMAIL_Applied", IIf(Is_EMAIL_Applied, 1, 0))
        clsCommon.AddColumnsForChange(coll, "Is_Notification_Applied", IIf(Is_Notification_Applied, 1, 0))
        'done by stuti on 07/03/2017
        If clsCommon.myLen(AmdPassword) > 0 Then
            clsCommon.AddColumnsForChange(coll, "Amendment_Pwd", clsCommon.EncryptString(AmdPassword))
        End If


        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            clsCommon.AddColumnsForChange(coll, "Program_Code", strProgramCode)
            clsCommon.AddColumnsForChange(coll, "Comp_Code", objCommonVar.CurrentCompanyCode)
            clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy"))
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_MASTER", OMInsertOrUpdate.Insert, "", trans)
        Else
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_MASTER", OMInsertOrUpdate.Update, "Program_Code='" + strProgramCode + "'", trans)
        End If
        Return True
    End Function

    Public Shared Function AddCustomLinks(ByVal strProgramCode As String, ByVal strProgramDescription As String, ByVal strParent_Code As String, ByVal trans As SqlTransaction) As Boolean
        Dim strParentSNo As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SNo from TSPL_PROGRAM_MASTER where Program_Code='" + strParent_Code + "'", trans))
        Dim qry As String = "select MAX(SNo) from TSPL_PROGRAM_MASTER where SNo like   '" + strParentSNo + "+.100%'"
        Dim strSNo As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
        If clsCommon.myLen(strSNo) <= 0 Then
            strSNo = strParentSNo + ".1001"
        Else
            strSNo = clsCommon.incval(strSNo)
        End If
        ProgramCodeNew.InsertDefaultValue(strProgramCode, strProgramDescription, strSNo, strParent_Code, "", 30, trans)
        Return True
    End Function

    Public Shared Function GetProgramName(ByVal strProgramCode As String) As String
        Dim ProgramName As String = String.Empty
        ProgramName = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select case when LEN(ISNULL(Re_Name,''))>0 then Re_Name else Program_Name end as Program_Name from TSPL_PROGRAM_MASTER where Program_Code='" + strProgramCode + "'"))
        Return ProgramName
    End Function

    'This function is create in  clsFixedParameter 
    ''  This function created by Pradeep Sharma on 14/06/13 11.34 AM
    ''  to insert default values in table TSPL_FIXED_PARAMETER
    ''  ONE TIME ONLY
    '    Public Shared Function InsertDefaultValueIn_TSPL_FIXED_PARAMETER()
    '        Dim coll As New Hashtable()
    '        Dim qry As String = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'CboRound' "
    '        Dim check As Double = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "CboRound")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Lower")
    '            clsCommon.AddColumnsForChange(coll, "Code", "L")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "CboRound")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Upper")
    '            clsCommon.AddColumnsForChange(coll, "Code", "U")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "CboRound")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Round")
    '            clsCommon.AddColumnsForChange(coll, "Code", "R")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Monthly")
    '            clsCommon.AddColumnsForChange(coll, "Code", "M")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'cboPeriodicity' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Monthly")
    '            clsCommon.AddColumnsForChange(coll, "Code", "M")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Quarterly")
    '            clsCommon.AddColumnsForChange(coll, "Code", "Q")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Half Yearly")
    '            clsCommon.AddColumnsForChange(coll, "Code", "HY")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Annually")
    '            clsCommon.AddColumnsForChange(coll, "Code", "A")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Other")
    '            clsCommon.AddColumnsForChange(coll, "Code", "OTH")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        End If
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'PayHeadSubHead' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Employee PF")
    '            clsCommon.AddColumnsForChange(coll, "Code", "EPF")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Company PF")
    '            clsCommon.AddColumnsForChange(coll, "Code", "COPF")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Company EPS")
    '            clsCommon.AddColumnsForChange(coll, "Code", "COEPS")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Company ESI")
    '            clsCommon.AddColumnsForChange(coll, "Code", "COESI")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Employee ESI")
    '            clsCommon.AddColumnsForChange(coll, "Code", "EMPESI")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "TDS")
    '            clsCommon.AddColumnsForChange(coll, "Code", "TDS")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Reimbursement")
    '            clsCommon.AddColumnsForChange(coll, "Code", "RMBT")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Allowance")
    '            clsCommon.AddColumnsForChange(coll, "Code", "ALLOW")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Deduction")
    '            clsCommon.AddColumnsForChange(coll, "Code", "DEDUCT")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Loan")
    '            clsCommon.AddColumnsForChange(coll, "Code", "LOAN")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Bonus")
    '            clsCommon.AddColumnsForChange(coll, "Code", "BONUS")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "OT")
    '            clsCommon.AddColumnsForChange(coll, "Code", "OT")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Other")
    '            clsCommon.AddColumnsForChange(coll, "Code", "OTHER")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Basic")
    '            clsCommon.AddColumnsForChange(coll, "Code", "BASIC")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "HRA")
    '            clsCommon.AddColumnsForChange(coll, "Code", "HRA")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "TA")
    '            clsCommon.AddColumnsForChange(coll, "Code", "TA")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "DA")
    '            clsCommon.AddColumnsForChange(coll, "Code", "DA")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '            clsCommon.AddColumnsForChange(coll, "Description", "Professional Tax")
    '            clsCommon.AddColumnsForChange(coll, "Code", "PT")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        End If

    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'PromptForTally' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "PromptForTally")
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", "PromptForTally")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If
    '        '' create po without requisition
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'CreatePOWithRequisition' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "CreatePOWithRequisition")
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", "POWITHREQ")
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if off then user can create PO without selecting Req No else REq No is mandatory to create PO")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        '' Popup enabler for Reorder level of items.
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'EnablePopupItemReorderLevel' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "EnablePopupItemReorderLevel")
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", "POPUPITEMREORDERLEVEL")
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if off then Popup for item reorder level will not displayed  else displayed during login of erp")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        '' Ask for reason on delete of records.
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'DisplayReasonOnDelete' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "DisplayReasonOnDelete")
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", "DisplayReasonOnDelete")
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if on then Reason will be asked during delete of records else will not asked.")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        '' run demo erp
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'RunDemoERP' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", "RunDemoERP")
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", "RunDemoERP")
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if on then Demo erp(Our Standard) will be executed else customized erp will be executed.")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If


    '        '' Ask for reason on delete of records.
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterType.isBatchApplyOnInventoryMovement + "' and Code='" + clsFixedParameterCode.isBatchApplyOnInventoryMovement + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterType.isBatchApplyOnInventoryMovement)
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.isBatchApplyOnInventoryMovement)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF   1-On")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        '' Ask for reason on delete of records.
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterType.BlankDatabase + "' and Code='" + clsFixedParameterCode.BlankDatabase + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterType.BlankDatabase)
    '            clsCommon.AddColumnsForChange(coll, "Description", "NAPOLEON")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.BlankDatabase)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        '' run demo erp
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterCode.ServiceDealer + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterCode.ServiceDealer)
    '            clsCommon.AddColumnsForChange(coll, "Description", "Employee Type")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.ServiceDealer)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "Employee Type")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If
    '        '' run demo erp
    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterCode.TDM + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterCode.TDM)
    '            clsCommon.AddColumnsForChange(coll, "Description", "Employee Type")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.TDM)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "Employee Type")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterType.PurchasePickItemFromVendorItemDetails + "' and Code='" + clsFixedParameterCode.PurchasePickItemFromVendorItemDetails + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterType.PurchasePickItemFromVendorItemDetails)
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.PurchasePickItemFromVendorItemDetails)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-Off 1-ON")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterType.PurchaseOneItemOneVendor + "' and Code='" + clsFixedParameterCode.PurchaseOneItemOneVendor + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterType.PurchaseOneItemOneVendor)
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.PurchaseOneItemOneVendor)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-Off 1-ON")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '        qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= '" + clsFixedParameterType.MAILOFF + "' and Code='" + clsFixedParameterCode.MAILOFF + "' "
    '        check = clsDBFuncationality.getSingleValue(qry)
    '        If check = 0 Then
    '            coll = New Hashtable()
    '            clsCommon.AddColumnsForChange(coll, "Type", clsFixedParameterType.MAILOFF)
    '            clsCommon.AddColumnsForChange(coll, "Description", "0")
    '            clsCommon.AddColumnsForChange(coll, "Code", clsFixedParameterCode.MAILOFF)
    '            clsCommon.AddColumnsForChange(coll, "Specification", "0-Off 1-ON")
    '            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '        End If

    '    End Function
End Class

Public Class clsFavouriteMenu
    Public Program_Code As String = Nothing
    Public User_Code As String = Nothing
    Public SNo As String = Nothing

    Public Shared Function SaveData(ByVal strProgramCode As String) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            Dim qry As String = "select 1 from TSPL_FAVOURITE_MENU where Program_Code='" + strProgramCode + "' and User_Code='" + objCommonVar.CurrentUserCode + "'"
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Throw New Exception("Already added in favourite")
            End If
            qry = "select 1 from TSPL_PROGRAM_MASTER where Program_Code='" + strProgramCode + "' and Type in ('M','SM')"
            dt = clsDBFuncationality.GetDataTable(qry, trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Throw New Exception("Module or Submodule can not be entered into favourite")
            End If

            Dim IntSNo As Integer = 1
            qry = "select 1 from TSPL_FAVOURITE_MENU where User_Code='" + objCommonVar.CurrentUserCode + "'"
            dt = clsDBFuncationality.GetDataTable(qry, trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                IntSNo = dt.Rows.Count + 1
            End If
            Dim strSNo As String = ""
            For ii As Integer = 1 To 3 - clsCommon.myLen(IntSNo)
                strSNo += "0"
            Next
            strSNo += clsCommon.myCstr(IntSNo)

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Program_Code", strProgramCode)
            clsCommon.AddColumnsForChange(coll, "User_Code", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "SNo", "0.1." + strSNo)
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FAVOURITE_MENU", OMInsertOrUpdate.Insert, "", trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try

        Return True
    End Function

    Public Shared Function DeleteData(ByVal strProgramCode As String) As Boolean
        Dim qry As String = "delete from TSPL_FAVOURITE_MENU where Program_Code='" + strProgramCode + "' and User_Code='" + objCommonVar.CurrentUserCode + "'"
        clsDBFuncationality.ExecuteNonQuery(qry)
        Return True
    End Function
End Class
Public Class clsProgramIdFormNameMapping

    Public Shared Sub setAllProgramFormName()
        UpdateFormName(clsUserMgtCode.frmProjectMaster, "frmProjectMaster", "TEAMMGMT.EXE")
    End Sub

    Public Shared Sub UpdateFormName(ProgramId As String, FormName As String, AssamblyName As String)
        Dim qry As String = " update tspl_program_master set MainFormName='" & FormName & "',AsmName='" & AssamblyName & "' where Program_code='" & ProgramId & "'"
        clsDBFuncationality.ExecuteNonQuery(qry)
    End Sub

End Class

'Public Class clsStandardMethods

'    Public Const XpertERPEngineclsCreateAllTable As String = "XpertERPEngine.clsCreateAllTables"
'    Public Const testMethod As String = "testMethod"
'    Public Const testMethodArg As String = "arg1,arg2"

'    Public Shared Sub AddStandardFunction()
'        Try
'            ' Insert Method for Recognization
'            '           for Example
'            insertDefaultValue("MethodForTest", XpertERPEngineclsCreateAllTable, testMethod, testMethodArg)

'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try

'    End Sub
'    Public Shared Sub insertDefaultValue(MethodUniqueCode As String, ClassName As String, MethodName As String, Optional MethodArg As String = Nothing)
'        Try
'            MethodArg = clsCommon.myCstr(testMethodArg)
'            If clsCommon.myLen(MethodUniqueCode) <= 0 Then
'                Throw New Exception("Please Specify Mehod Unique Code")
'            End If
'            If clsCommon.myLen(ClassName) <= 0 Then
'                Throw New Exception("Please Specify Class Name")
'            End If
'            If clsCommon.myLen(MethodName) <= 0 Then
'                Throw New Exception("Please Specify Method Name")
'            End If
'            Dim qry As String = ""
'            Dim cnt As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(*) from tspl_Standard_Method where MethodCode='" & MethodUniqueCode & "'"))
'            If cnt > 0 Then
'                qry = " update tspl_Standard_Method set ClassName='" & ClassName & "',MethodName='" & MethodName & "',MethodArg='" & MethodArg & "' where MethodCode='" & MethodUniqueCode & "'"
'            Else
'                qry = " Insert into tspl_Standard_Method(MethodCode,ClassName,MethodName,MethodArg) values('" & MethodUniqueCode & "','" & ClassName & "','" & MethodName & "','" & MethodArg & "')"

'            End If
'            clsDBFuncationality.ExecuteNonQuery(qry)
'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try
'    End Sub
'End Class