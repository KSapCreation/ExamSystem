Imports common


Public Class clsUserMgtCode

    Public Const TeamMgmt As String = "TEAM_MGMT"
    Public Const ModuleFavourite As String = "MOD_FAV"
    Public Const ModuleSystemAdmin As String = "MOD_SYS_MAST"
    Public Const SubModuleSystemAdminSetup As String = "SUB_MOD_SET"

    Public Const ModuleTicketTracker As String = "MOD_TICK_TRK"
    Public Const SubModuleTicketTracker As String = "SUB_MOD_TIMT"
    Public Const SubModuleTicketTrackerTran As String = "SUB_TRK_TRAN"
    Public Const FrmExamStudent As String = "Std_Exm_Map"

    Public Const frmExamReloader As String = "Exam_LD"
    Public Const RptStudentHistoy As String = "STD_HIS"

    Public Const frmProjectMaster As String = "PRO_MASTER"
    Public Const frmExamMaster As String = "EXM_MASTER"
    Public Const frmClientMaster As String = "CLIENT_MST"
    Public Const frmCompanyMaster As String = "COM_MST"
    Public Const frmModuleMaster As String = "MODULE_MST"
    Public Const FrmScreenMaster As String = "SCREEN_MST"
    Public Const FrmUserGroupMaster As String = "UGRPOP_MST"
    Public Const frmActivationKey As String = "Act_Key"
    Public Const FrmGroupProgramMapping As String = "GRP_PRO_MAP"
    Public Const FrmUserMaster As String = "USER_MST"
    Public Const FrmTimeMaster As String = "TIME_MST"
    Public Const FrmUserGroupMaping As String = "USR_GRP_MAP"
    Public Const FrmTicketMaster As String = "TICKET_MST"
    Public Const FrmTicketAllocation As String = "TICKET_ALLO"
    Public Const frmRequestCreation As String = "REQST_CRT"
    Public Const frmTimeSheet As String = "TIME_SHEET"
    Public Const frmRequestAnalysis As String = "REQ_ANYLS"
    Public Const frmRequestApproval As String = "REQ_APPROVAL"
    Public Const frmRequestStatus As String = "REQ_STATUS"
    Public Const frmCreateEXE As String = "CRE-EXE"
    Public Const RptExamList As String = "EXM-LST"
    Public Const RptExamResult As String = "EXM-RST"

    'Private Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal strLevel1 As String, ByVal strLevel2 As String) As Boolean
    '    Dim qry As String = "select PROGRAM_NAME from TSPL_PROGRAM_MASTER where Program_Code='" + strProgramCode + "' "
    '    Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
    '    Dim coll As New Hashtable()
    '    clsCommon.AddColumnsForChange(coll, "Program_Name", strProgramName)
    '    clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
    '    clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy"))
    '    clsCommon.AddColumnsForChange(coll, "Comp_Code", objCommonVar.CurrentCompanyCode)
    '    clsCommon.AddColumnsForChange(coll, "Level_1", strLevel1)
    '    clsCommon.AddColumnsForChange(coll, "Level_2", strLevel2)
    '    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '        clsCommon.AddColumnsForChange(coll, "Program_Code", strProgramCode)
    '        clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
    '        clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy"))
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_MASTER", OMInsertOrUpdate.Insert, "")
    '    Else ''If Not clsCommon.CompairString(strProgramName, clsCommon.myCstr(dt.Rows(0)("PROGRAM_NAME"))) = CompairStringResult.Equal Then
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_MASTER", OMInsertOrUpdate.Update, "Program_Code='" + strProgramCode + "'")
    '    End If
    '    Return True
    'End Function


    'Public Shared Sub InsertDefaultValueIn_TSPL_FIXED_PARAMETER()
    '    Dim coll As New Hashtable()
    '    Dim qry As String = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'CboRound' "
    '    Dim check As Double = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "CboRound")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Lower")
    '        clsCommon.AddColumnsForChange(coll, "Code", "L")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "CboRound")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Upper")
    '        clsCommon.AddColumnsForChange(coll, "Code", "U")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "CboRound")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Round")
    '        clsCommon.AddColumnsForChange(coll, "Code", "R")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Monthly")
    '        clsCommon.AddColumnsForChange(coll, "Code", "M")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If

    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'cboPeriodicity' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Monthly")
    '        clsCommon.AddColumnsForChange(coll, "Code", "M")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Quarterly")
    '        clsCommon.AddColumnsForChange(coll, "Code", "Q")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Half Yearly")
    '        clsCommon.AddColumnsForChange(coll, "Code", "HY")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Annually")
    '        clsCommon.AddColumnsForChange(coll, "Code", "A")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "cboPeriodicity")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Other")
    '        clsCommon.AddColumnsForChange(coll, "Code", "OTH")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '    End If
    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'PayHeadSubHead' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Employee PF")
    '        clsCommon.AddColumnsForChange(coll, "Code", "EPF")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Company PF")
    '        clsCommon.AddColumnsForChange(coll, "Code", "COPF")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Company EPS")
    '        clsCommon.AddColumnsForChange(coll, "Code", "COEPS")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Company ESI")
    '        clsCommon.AddColumnsForChange(coll, "Code", "COESI")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Employee ESI")
    '        clsCommon.AddColumnsForChange(coll, "Code", "EMPESI")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "TDS")
    '        clsCommon.AddColumnsForChange(coll, "Code", "TDS")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Reimbursement")
    '        clsCommon.AddColumnsForChange(coll, "Code", "RMBT")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Allowance")
    '        clsCommon.AddColumnsForChange(coll, "Code", "ALLOW")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Deduction")
    '        clsCommon.AddColumnsForChange(coll, "Code", "DEDUCT")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Loan")
    '        clsCommon.AddColumnsForChange(coll, "Code", "LOAN")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Bonus")
    '        clsCommon.AddColumnsForChange(coll, "Code", "BONUS")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "OT")
    '        clsCommon.AddColumnsForChange(coll, "Code", "OT")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Other")
    '        clsCommon.AddColumnsForChange(coll, "Code", "OTHER")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Basic")
    '        clsCommon.AddColumnsForChange(coll, "Code", "BASIC")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "HRA")
    '        clsCommon.AddColumnsForChange(coll, "Code", "HRA")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "TA")
    '        clsCommon.AddColumnsForChange(coll, "Code", "TA")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "DA")
    '        clsCommon.AddColumnsForChange(coll, "Code", "DA")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PayHeadSubHead")
    '        clsCommon.AddColumnsForChange(coll, "Description", "Professional Tax")
    '        clsCommon.AddColumnsForChange(coll, "Code", "PT")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")

    '    End If

    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'PromptForTally' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "PromptForTally")
    '        clsCommon.AddColumnsForChange(coll, "Description", "0")
    '        clsCommon.AddColumnsForChange(coll, "Code", "PromptForTally")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If
    '    '' create po without requisition
    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'CreatePOWithRequisition' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "CreatePOWithRequisition")
    '        clsCommon.AddColumnsForChange(coll, "Description", "0")
    '        clsCommon.AddColumnsForChange(coll, "Code", "POWITHREQ")
    '        clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if off then user can create PO without selecting Req No else REq No is mandatory to create PO")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If

    '    '' Popup enabler for Reorder level of items.
    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'EnablePopupItemReorderLevel' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "EnablePopupItemReorderLevel")
    '        clsCommon.AddColumnsForChange(coll, "Description", "0")
    '        clsCommon.AddColumnsForChange(coll, "Code", "POPUPITEMREORDERLEVEL")
    '        clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if off then Popup for item reorder level will not displayed  else displayed during login of erp")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If

    '    '' Ask for reason on delete of records.
    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'DisplayReasonOnDelete' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "DisplayReasonOnDelete")
    '        clsCommon.AddColumnsForChange(coll, "Description", "0")
    '        clsCommon.AddColumnsForChange(coll, "Code", "DisplayReasonOnDelete")
    '        clsCommon.AddColumnsForChange(coll, "Specification", "0-OFF;1-On: if on then Reason will be asked during delete of records else will not asked.")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If

    '    '' "DISCRETE" AND "PROCESS" Manufacturing.
    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'ManufacturingType' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "ManufacturingType")
    '        clsCommon.AddColumnsForChange(coll, "Description", "D")
    '        clsCommon.AddColumnsForChange(coll, "Code", "ManufacturingType")
    '        clsCommon.AddColumnsForChange(coll, "Specification", "D-DISCRETE Manufacturing; P-PROCESS Manufacturing")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If

    '    '' ENABLE MILK PROCUREMENT MODULE.
    '    qry = "SELECT Count(*) FROM TSPL_FIXED_PARAMETER where Type= 'MilkProc' "
    '    check = clsDBFuncationality.getSingleValue(qry)
    '    If check = 0 Then
    '        coll = New Hashtable()
    '        clsCommon.AddColumnsForChange(coll, "Type", "MilkProc")
    '        clsCommon.AddColumnsForChange(coll, "Description", "0")
    '        clsCommon.AddColumnsForChange(coll, "Code", "EnableMilkProc")
    '        clsCommon.AddColumnsForChange(coll, "Specification", "1-Enable Milk Procurement Module; 0-Disable Milk Procurement Module")
    '        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
    '    End If

    'End Sub

    Public Shared Function GetUserLevels() As DataTable
        Dim dt As New DataTable
        Try
            dt.Columns.Add("Code", GetType(Integer))
            dt.Columns.Add("Description", GetType(String))

            dt.Rows.Add(0, "Select")
            dt.Rows.Add(1, "Budgetary")
            dt.Rows.Add(2, "Finance")
            dt.Rows.Add(3, "Level1")
            dt.Rows.Add(4, "Level2")
            dt.Rows.Add(5, "Level3")
            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class