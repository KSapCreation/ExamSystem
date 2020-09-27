'==BM00000007778,BM00000007011===========================
Imports common
Imports System.IO
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Drawing

Public Class FrmMainTranScreen
#Region "Variables"
    Public isReadFlag As Boolean = False
    Public isModifyFlag As Boolean = False
    Public isDeleteFlag As Boolean = False
    Public isPostFlag As Boolean = False
    Public isReverse As Boolean = False
    Public isExport As Boolean = False
    ''===Parteek===''
    Public isPrintFlag As Boolean = False
    Public isQuickExportFlag As Boolean = False
    ''====End===''
    '==Sanjeet======
    Public isModifyonPasswordFlag As Boolean = False
    '=========
    Public isCancel_Flag As Boolean = False
    Public isCancel_Flag_After_Posting As Boolean = False
    Public customFieldTabProperty As ElementVisibility = ElementVisibility.Collapsed
    Public Form_ID As String = ""
    ' Public ArrDetailFields As List(Of clsCustomFieldMapping)
    Public Module_Code As String = ""
    Public Shared LastWorkingTime As Date = DateTime.Now()
    Public SendMailSms As String = "N"
    Public OldMouseX As Integer = 0
    Public OldMouseY As Integer = 0
    Public strDocNoForOpen As String = ""
    Dim is_Cancel_Allowed As String = String.Empty
    ' Public objCD As ControlDesigner = Nothing
    Public bolDesignMode As Boolean = False

    Public Is_SMS_Applied As Boolean = False
    Public Is_EMAIL_Applied As Boolean = False
    Public Is_Notification_Applied As Boolean = False
#End Region

    Private Sub FrmMainTranScreen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.F6 Then
            If Me.Is_EMAIL_Applied OrElse Me.Is_SMS_Applied OrElse Me.Is_Notification_Applied Then
                Dim frmPWD As New FrmPWD(Nothing)
                frmPWD.strCode = clsFixedParameterCode.SMSEMailPassword
                frmPWD.strType = clsFixedParameterType.SMSEMailPassword
                frmPWD.ShowDialog()
                If frmPWD.isPasswordCorrect Then
                    Dim frm As New frmEMailAndSMSSetting
                    frm.isForSMS = Me.Is_SMS_Applied
                    frm.isForEMail = Me.Is_EMAIL_Applied
                    frm.isForNotification = Me.Is_Notification_Applied
                    frm.Form_ID = Me.Form_ID
                    frm.ShowDialog()
                End If
            End If
        End If
    End Sub
    '''' <summary>

    '''' </summar---------Update By Preeti Guptay>
    '''' <param name="FormID"></param>
    '''' <remarks></remarks>

    Public Sub SetUserMgmt(ByVal FormID As String)
        '    Me.KeyPreview = True
        Dim qry As String = ""
        '    If clsCommon.myLen(FormID) <= 0 Then
        '        common.clsCommon.MyMessageBoxShow("Form ID not found")
        '        Me.Close()
        '        Exit Sub
        '    End If
        '    Me.Form_ID = FormID
        Me.Form_ID = FormID

        qry = " select (select inn.Parent_Code  from TSPL_PROGRAM_MASTER as inn where inn.program_code=TSPL_PROGRAM_MASTER.Parent_Code) as ModuleCode,Is_SMS_Applied,Is_EMAIL_Applied,Is_Notification_Applied from TSPL_PROGRAM_MASTER where program_code='" + FormID + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.Module_Code = clsCommon.myCstr(dt.Rows(0)("ModuleCode"))
            Me.Is_EMAIL_Applied = IIf(clsCommon.myCdbl(dt.Rows(0)("Is_EMAIL_Applied")) = 1, True, False)
            Me.Is_SMS_Applied = IIf(clsCommon.myCdbl(dt.Rows(0)("Is_SMS_Applied")) = 1, True, False)
            Me.Is_Notification_Applied = IIf(clsCommon.myCdbl(dt.Rows(0)("Is_Notification_Applied")) = 1, True, False)
        End If

        '    If clsCommon.CompairString(objCommonVar.CurrentUserCode, "Admin") = CompairStringResult.Equal Then
        '        isReadFlag = True
        '        isModifyFlag = True
        '        isDeleteFlag = True
        '        isPostFlag = True
        '        isReverse = True
        '        isExport = True
        '        isCancel_Flag = True
        '        isCancel_Flag_After_Posting = True
        '        isPrintFlag = True
        '        isQuickExportFlag = True
        '        isModifyonPasswordFlag = False

        '    Else
        '        qry = "select Read_Flag,Modify_Flag,Delete_Flag,Authorized_Flag, Reverse_Flag, Export_Flag,Print_Flag,cancel_Flag,cancel_Flag_After_Posting,QucikExport_Flag,isModifyonPassword from TSPL_GROUP_PROGRAM_MAPPING where Program_Code='" + FormID + "' and Group_Code in (select Group_Code  from TSPL_USER_GROUP_MAPPING where User_Code='" + objCommonVar.CurrentUserCode + "')"
        '        dt = clsDBFuncationality.GetDataTable(qry)
        '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        '            For Each dr As DataRow In dt.Rows
        '                If isReadFlag = False Then
        '                    isReadFlag = IIf(clsCommon.myCdbl(dr("Read_Flag")) = 1, True, False)
        '                End If
        '                If isModifyFlag = False Then
        '                    isModifyFlag = IIf(clsCommon.myCdbl(dr("Modify_Flag")) = 1, True, False)
        '                End If
        '                If isDeleteFlag = False Then
        '                    isDeleteFlag = IIf(clsCommon.myCdbl(dr("Delete_Flag")) = 1, True, False)
        '                End If
        '                If isPostFlag = False Then
        '                    isPostFlag = IIf(clsCommon.myCdbl(dr("Authorized_Flag")) = 1, True, False)
        '                End If
        '                If isReverse = False Then
        '                    isReverse = IIf(clsCommon.myCdbl(dr("Reverse_Flag")) = 1, True, False)
        '                End If
        '                If isExport = False Then
        '                    isExport = IIf(clsCommon.myCdbl(dr("Export_Flag")) = 1, True, False)
        '                End If
        '                If isPrintFlag = False Then
        '                    isPrintFlag = IIf(clsCommon.myCdbl(dr("Print_Flag")) = 1, True, False)
        '                End If
        '                If isQuickExportFlag = False Then
        '                    isQuickExportFlag = IIf(clsCommon.myCdbl(dr("QucikExport_Flag")) = 1, True, False)
        '                End If
        '                If isCancel_Flag = False Then
        '                    isCancel_Flag = IIf(clsCommon.myCdbl(dr("Cancel_Flag")) = 1, True, False)
        '                End If
        '                If isCancel_Flag_After_Posting = False Then
        '                    isCancel_Flag_After_Posting = IIf(clsCommon.myCdbl(dr("Cancel_Flag_After_Posting")) = 1, True, False)
        '                End If
        '                If isModifyonPasswordFlag = False Then
        '                    isModifyonPasswordFlag = IIf(clsCommon.myCdbl(dr("isModifyonPassword")) = 1, True, False)
        '                End If
        '            Next
        '        End If
        '    End If

        '    qry = "select 1 from TSPL_CUSTOM_FIELD_MAPPING where Program_Code='" + FormID + "' and Is_For_Detail_Level='0' "
        '    Dim dtNew As DataTable = clsDBFuncationality.GetDataTable(qry)
        '    If dtNew IsNot Nothing AndAlso dtNew.Rows.Count Then
        '        customFieldTabProperty = ElementVisibility.Visible
        '    End If
        '    ArrDetailFields = clsCustomFieldMapping.GetData(FormID, "D")



    End Sub
    ''---- Created By preeti gupta-----ticket no.BM00000003244 
    'Public Shared Function bankPermission(Optional ByVal trans As SqlTransaction = Nothing) As String
    '    Dim qry As String = ""
    '    Dim strvalue As String = ""
    '    qry = "select distinct bank_code from TSPL_User_Bank_mapping where Item_Code ='" + objCommonVar.CurrentUserCode + "'"
    '    Dim dtNew As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

    '    If dtNew IsNot Nothing AndAlso dtNew.Rows.Count > 0 Then
    '        For Each dr As DataRow In dtNew.Rows
    '            strvalue = strvalue + ",'" + clsCommon.myCstr(dr("bank_code")) + "'"
    '            If strvalue.Substring(0, 1) = "," Then

    '                strvalue = strvalue.Substring(1, strvalue.Length - 1)
    '            End If

    '        Next
    '    End If
    '    Try

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return strvalue
    'End Function
    ''---- Created By Richa Agarwal-----Ticket no. BM00000003242 on 29/07/2014
    'Public Shared Function CustomerPermission() As String
    '    Dim qry As String = ""
    '    Dim strvalue As String = ""
    '    qry = "select distinct Cust_Code from TSPL_CUSTOMER_MAPPING where User_Code ='" + objCommonVar.CurrentUserCode + "' and Comp_Code='" + objCommonVar.CurrentCompanyCode + "'"
    '    Dim dtNew As DataTable = clsDBFuncationality.GetDataTable(qry)

    '    If dtNew IsNot Nothing AndAlso dtNew.Rows.Count > 0 Then
    '        For Each dr As DataRow In dtNew.Rows
    '            strvalue = strvalue & "'" & clsCommon.myCstr(dr("Cust_Code")).Replace("'", "''").ToString() & "'" & ","
    '        Next

    '        If strvalue <> "" Then
    '            strvalue = strvalue.Substring(0, strvalue.Length - 1)
    '        End If

    '    End If
    '    Try

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return strvalue
    'End Function

    ''---- Created By Rohit-----16-Oct-2014=========
    'Public Function Cust_CustomerVendorMapping() As String
    '    Dim qry As String = ""
    '    Dim strvalue As String = ""
    '    qry = "select distinct Cust_Code from TSPL_CUSTOMER_VENDOR_MAPPING"
    '    Dim dtNew As DataTable = clsDBFuncationality.GetDataTable(qry)

    '    If dtNew IsNot Nothing AndAlso dtNew.Rows.Count > 0 Then
    '        For Each dr As DataRow In dtNew.Rows
    '            strvalue = strvalue & "'" & clsCommon.myCstr(dr("Cust_Code")).Replace("'", "''").ToString() & "'" & ","
    '        Next

    '        If strvalue <> "" Then
    '            strvalue = strvalue.Substring(0, strvalue.Length - 1)
    '        End If

    '    End If
    '    Try

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return strvalue
    'End Function


    'Private Sub FrmMainTranScreen_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated



    'End Sub

    'Private Sub FrmMainTranScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    'Try
    '    '    If clsCommon.CompairString(Me.Form_ID, clsUserMgtCode.frmMCCDispatch) = CompairStringResult.Equal Then
    '    '        If FrmMccDispatch.isPortOpened Then
    '    '            e.Cancel = True
    '    '            clsCommon.MyMessageBoxShow("Please stop the port before You close the MCC Dispatch Screen")
    '    '        End If
    '    '    End If
    '    '    If clsCommon.CompairString(Me.Form_ID, clsUserMgtCode.frmQualityCheck) = CompairStringResult.Equal Then
    '    '        If FrmQualityCheck.isPortOpened Then
    '    '            e.Cancel = True
    '    '            clsCommon.MyMessageBoxShow("Please stop the port before You close the Quality Check Screen")
    '    '        End If
    '    '    End If
    '    '    If clsCommon.CompairString(Me.Form_ID, clsUserMgtCode.frmMilkReceipt) = CompairStringResult.Equal Then
    '    '        If frmMilkReceiptMCC.isPortOpened Then
    '    '            e.Cancel = True
    '    '            clsCommon.MyMessageBoxShow("Please stop the port before You close the  Milk Receipt Screen")
    '    '        End If
    '    '    End If
    '    '    If clsCommon.CompairString(Me.Form_ID, clsUserMgtCode.frmMilkSample) = CompairStringResult.Equal Then
    '    '        If frmMilkSampleMCC.isPortOpened Then
    '    '            e.Cancel = True
    '    '            clsCommon.MyMessageBoxShow("Please stop the port before You close the  Milk Sample Screen")
    '    '        End If
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try
    '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowDesignAtRunTime, clsFixedParameterCode.AllowDesignAtRunTime, Nothing)) = 1 Then
    '        If objCD IsNot Nothing Then
    '            objCD.Dispose()
    '            objCD = Nothing
    '        End If
    '        'Create manager object that contains the load an save methods
    '        Dim objCM As New ControlManager

    '        'Save all supported properties of current form's controls (except btnDesigner) to config file
    '        If bolDesignMode Then
    '            If clsCommon.MyMessageBoxShow("Save Design Mode Data ?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '                objCM.SaveProperties(Me, New List(Of Control)({}))
    '            End If
    '        End If
    '        bolDesignMode = False
    '        'Close manager
    '        objCM.Dispose()
    '        objCM = Nothing
    '    End If
    'End Sub

    'Private Sub FrmMainTranScreen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown


    '    ' system administration start here
    '    If e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.DesignationMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/designation_master2.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.EmployeeMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/employee_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.userMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/user_master2.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.userGroupMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/user_group_master2.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.userGroupMapping) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/user_group_mapping2.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.groupProgramMapping) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/group_program_mapping2.htm")
    '        e.Handled = True

    '        '''' Common Servers start here
    '        '''' SetUp
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.taxAuthority) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tax_authority.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.taxRate) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tax_rate.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.taxGroup) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tax_group.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.paymentTerms) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/payment_terms.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.paymentCodes) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/payment_codes.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.cityMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/city_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmAbateMentMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/abatement_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmCompanyMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/company_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.AddCharge) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/additional_charge.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PrefixGeneration) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/prefix_generation.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FormMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/form_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ChangePwd) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/change_password.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmBulkPostingNew) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bulk_posting.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.bankMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_master.htm")
    '        e.Handled = True

    '        '''' Transaction
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.reverseTransaction) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_reverse_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.bankTransfer) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_transfer.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmBankReco) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_reconciliation.htm")
    '        e.Handled = True

    '        ''''Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmBankReverse) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_reverse.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmBankBook) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_cash_book.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmBankBookDayWise) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/bank_cash_book_day_wise.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCashVoucher) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/contra_voucher.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.TaxTracking) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tax_tracking.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ExciseSummary1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/excise_summary.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmExciseChapterWise) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/er1_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CrptRG1Detail1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/rg1_report.htm")
    '        e.Handled = True

    '        '''''' Receivable
    '        '''' Setup
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerType) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_type.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerAccountSet) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_account_set.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerGroup) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_group.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomeCategory) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_category.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ShiptoLocation) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/ship_to_location.htm")
    '        e.Handled = True

    '        '''' Transaction
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ReceiptEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/receipt_entry.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FinanceAdjustment) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/adjustment_entry.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ReceiptAdjustmentEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/adjustment_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnARInvoiceEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/ar_invoice_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmQuickBook) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/quick_book_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmCustomerInquiry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_enquiry.htm")
    '        e.Handled = True

    '        ''''Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerGroupReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_group_reports.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerDetails) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/outlet_details.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnCustomerLedger) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_ledger.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRoute_CustomerOutstanding) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/rg1_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmCustomerOutstanding) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_outstanding.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.receiptreport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/receipt_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomersListReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_list_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCustomerAgeing) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_ageing.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerRouteHistoryReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_route_history_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.cash_Register_Details4) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/cash_register_details.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnCustomerEmptyTrial) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_empty_trial.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmSecurityDeposit1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/security_deposit.htm")
    '        e.Handled = True


    '        '''' Payable
    '        '''' Setup
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.vendoraccountset) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_account_set.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.vendorgroup) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_group.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.vendormaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_master.htm")
    '        e.Handled = True

    '        ''''Transaction
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PaymentEntryNew) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/payment_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnAPInvoiceEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/ap_invoice_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmVendorInquiry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_inquiry.htm")
    '        e.Handled = True

    '        '''' Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmPaymentEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/payment_entry_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnAPInvoiceReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/ap_invoice_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.VendorLedgerReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_ledger_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmVendorsOutstandings) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_outstanding.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmAgingPayble) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/ap_aging_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRptVendorList) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_list_report.htm")
    '        e.Handled = True


    '        '''' General Ledger
    '        '''' Setup
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.glOptions) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gl_options.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.segmentCode) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/segment_codes.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.accountStructure) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/account_structure.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.accountGroup) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/account_group.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.glAccount) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gl_accounts.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.createAccounts) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/create_account.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.sourceCode) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/source_code.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.glsecurity) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gl_security.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmGL_account_excluded) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gl_account_excluded_for_trial_.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frm_Account_Mapping) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_inquiry.htm")
    '        '    e.Handled = True

    '        '''' Transaction

    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.journalEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/journal_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnVCGLEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_customer_gl_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmJEReverse) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/reverse_journal_entry.htm")
    '        e.Handled = True

    '        '''' Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmCostCenterAnalysisRpt) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/cost_center_analysis_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmGLTransReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/general_ledger2.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmJrnlVoucher) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/general_voucher_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.rptTrialBalance) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/trial_balance.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnJournalBook) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/journal_book.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmUnpostedJV) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_journal_voucher.htm")
    '        e.Handled = True

    '        '''' sale and distribution

    '        '''' setup
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.transportMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transport_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.routetypemaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.chm::/route_type_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.vhicleMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vehicle_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.transportType) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transport_type .htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.channelCategory) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/channel_category.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.channelMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/channel_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmSalesManHierarchy) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/salesman_hierarchy.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCommissionMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/commission_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.routeMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/route_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmSettlementMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/settlement_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.groupMasterRoute) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/group_masterroute.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.visiMaster) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_journal_voucher.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmDiscountCategoryMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/discount_categoryi_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmDiscountMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/discount_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.Sampling_Master) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sampling_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnTmplateCreation) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/template_creation.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmViewPunchingInvoice) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/view_punching_invoice.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnTargetMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/target_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRouteShifting) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/outlet_shifting.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CustomerVendorMapping) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_vendor_mapping.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.TDMTARGET) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tdm_wise_target.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCustomerTargetFixing) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_journal_voucher.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmClaimMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/claim_master.htm")
    '        e.Handled = True

    '        '''' Transaction
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.saleOrders) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sales_order.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.LoadOut) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/load_out.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.saleReturn) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sales_return.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SaleReturnInterCompany) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/claim_master.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmQuickSettlement) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/quick_settlement.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.LoadOutStatus) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/loadout_status.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmSettlementEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/settlement_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmCompleteTransfer) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/load_out_sale_incoice_reconcil.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmTransferIncompleteRemarks1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transfer_incomplete_remarks.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ReverseEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/reverse_quick_settlement.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ChangeInvoiceSalesman) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/change_invoice_salesman.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmGatePassENtry1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gate_pass_entry.htm")
    '        e.Handled = True

    '        '''' Sale Reports
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemDiscountReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_discount_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SaleAccountBreakDetail) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/trade_discount_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CashDiscount) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/cash_discount_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SaleAccountBreakage) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sale_account_breakup_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmMCDiscountReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/marginal_contributiuon_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmDiscountAnalysis) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/discount_analysis_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmSaleDiscount1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sale_reco_chart_report.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.crptLoadOut) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sale_reco_chart_report.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.nrptSales) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sales_register.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SaleReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/sales_volume_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.rptCreditSaleReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/credit_sales_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.NoSaleReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/no_sale_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.OtherPartySale) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/other_party_sale.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnNetSaleReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/net_sale_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.rptNetSaleDetailReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/net_sale_detail_wise.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmDistrbutorSaleTarget) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/distributor_wise_sale_target.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmDayReportDirectSale) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/day_report_direct_sale.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemCommissionSummary) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_commission_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.DailySettlement) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/salesman_shortage.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ProvisionalSaleReport) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gate_pass_entry.htm")
    '        '    e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ProvSaleDetail) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gate_pass_entry.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnCustomerRanking) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_ranking_report.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.rptPenetration) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_commission_report.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PrimarySales) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/primary_sales_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SecondarySales) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/secondary_sales.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnRouteSale) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/route_sale_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.receiptFillreport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/receipts_against_salesfilled.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.receiptWOTreport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/invoice_without_receipt.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmKPIReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/kpi_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmMismatchSettlement) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/mismatch_settlement.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmSaleOrderSummary) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_sale_order.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmSettlementSheetReconcilationeport) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transfer_register.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.TransferRegister) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transfer_register.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.RptPendingSettlement) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_settlement.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmLoadReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/combine_sale_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmLoadOutInvoiceRecoReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/loadout_sale_invoice_reconcili.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmSettlement_CashMemoStatus) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/target_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmReverseSettlementDetail) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/reverse_settlement_detail.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmMismatchCashMemo) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/mismatched_cash_memo.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCanceledSaleInvoice) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/canceled_sale_invoice.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmEmptyTransactionReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_revo_chart.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmpendingLoadin) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_loadin.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmRptSalesReturn) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/_sale_return_register.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmQuickSettlementHead) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/settlement_head_report.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.LO_vs_Vechile) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gate_pass_entry.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.KeyValue) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/key_sale_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmLeakageBreakage) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/leakage_breakage_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.GatePass_Vs_actual) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/gate_pass_v_s_actual_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.RptInvoiceAgainstInward) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/invoice_against_inward_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCustomerTargetReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/customer_target_report.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.rptClaimMaster) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tdm_report.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmTDMReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tdm_report.htm")
    '        e.Handled = True

    '        '''' Shipping Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FilloutwardRegisterReport1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/filloutward_register_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.vehicle_Details_Report1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vehicle_details_report.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.visiDetail1) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/tdm_report.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.OutletEmpty1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vehicle_details_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.VehiclewiseSale1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vehicle_wise_sale.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnVisiVPO1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/visi_vpo_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.Channelwisecustomer1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/channel_wise_customer_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.RouteListReport11) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/route_list_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.LoadOutStatusreport1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/loadout_status_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmTransitBreakageReport1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transit_breakage_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmFilledOutWard) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/filled_transaction_salesman.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.EmptyReportDetail) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_report_detail.htm")
    '        e.Handled = True



    '        '''' Material Mangament
    '        '''' Setup
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.itemMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_master_for_finished_goods.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmItemMasterRMOther) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_master_for_rm_other.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.inventorySetting) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/inventory_setting.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.itemGroups) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_group.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.itemStructure) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_structure.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.chapterhead) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/chapter_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnItemCategory) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_category.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnItemSubCategory) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_sub_category.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.packType) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pack_type.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PriceComponentMasters) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/price_component_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PriceComponentMapping) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/price_component_mapping.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PriceMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/price_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SchemeMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/scheme_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnBreakageHead1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/breakage_head.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.locationMaster) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/location_master.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemLocationDetails) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_location_details.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemReorderLevel) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_recorder_level.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemExciseMapping) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_report_detail.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemBasicPrice) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_basic_price.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmStandardscheme) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/standard_scheme.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmStandardRateItem) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/standard_rate_of_items.htm")
    '        e.Handled = True


    '        ''''Transaction
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.Transfer) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/transfer.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnEmptyTrans) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_transactions.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnProductionEntry) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/production_entry.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnStoreAdjustment) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/store_adjustment.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmWarehouseBreakage) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/warehouse_breakage.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmItemMcMapping) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_report_detail.htm")
    '        '    e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmExpiryDateEntry) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_report_detail.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmPhysicalStock) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/physical_stock.htm")
    '        e.Handled = True

    '        '''' Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnItemMovement) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/inventory_movement_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemLocationDetailsReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_location_details_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ItemPrice) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/item_price.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.StockRecoReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/stock_reconciliation_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmStockDispatchReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/stock_dispatch_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnStockAdjustmentReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/stock_adjustment_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmAdjustmentStatusReport1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/adjustment_status_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnBreakageReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/breakage_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.BreakageReportSummary) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/routewise_breakage_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.SchemeReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/scheme_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.StockReportForFinishedGoods) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/stock_report_for_finished_good.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmAdjustmentReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/adjustment_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.rptVehicleWiseLoadout) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vehicle_wise_loadout.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmIndentReport) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/empty_report_detail.htm")
    '        '    e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmPendingIndentTransferReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_indent_report.htm")
    '        e.Handled = True


    '        ''''Purchase
    '        '''' Setup
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.VendorItemDetails) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_item_details.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.CostCenter) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/cost_center.htm")
    '        e.Handled = True

    '        '''' Transaction
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnPurchaseRequistion) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_requisition.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnPurchaseOrder) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_order.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnSRN) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/store_received_note.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnPurchaseInvoice) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_invoice.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnPurchaseReturn) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_return.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnGatePass) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/rgp_nrgp.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnIssueReturn) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/issue_return_transfer.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.ScrapSale) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/material_sale.htm")
    '        e.Handled = True

    '        '''' Report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmPendingRequisitionQty) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_requisition.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmPo_action) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_order_tracking_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmPendingSrn_Qty) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_srn.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmPurchasebookReport1) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_book.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnStoreLedger) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/store_ledger.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnDailyRcptNoteSummary) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/daily_receipt_note_summary.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.Store_Receipt_Note) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/daily_receipt_detail_work.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmRGP_Register_NRGP) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/rgp_nrgp_register.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmVendorWiseReturnableGoodBalance) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_wise_returnable_goods_b.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmIssueOrReturnItemWiseSummary) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/net_issue_return_item_wise_sum.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.StockStatement) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/stock_statement_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmMorningReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/morning_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.RM_Consumption_Detail) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/rm_consumption_breakup.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.AddCharge) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/additional_charges_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.Vendor_Rating_Rejection) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/vendor_rating_rejection.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.Parti_VS_Rejected) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/partywise_receipt_v_s_rejectio.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmPurchaseOrderRegister) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/purchase_order_register.htm")
    '        e.Handled = True
    '        'ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.frmItemWiseDispatchLedger3) = CompairStringResult.Equal Then
    '        '    Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pending_indent_report.htm")
    '        '    e.Handled = True


    '        ''''Transaction report
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnRGP_NRGP_Rpt) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/rgp_nrgp_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.MRDAReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/mrda_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.DebitAdviseReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/debit_advise_report.htm")
    '        e.Handled = True
    '    ElseIf e.KeyCode = Keys.F1 And clsCommon.CompairString(Form_ID, clsUserMgtCode.PJVReport) = CompairStringResult.Equal Then
    '        Help.ShowHelp(Me, Application.StartupPath & "\KIWI help.chm", HelpNavigator.Topic, "mk:@MSITStore:" & Application.StartupPath & "\KIWIHE~1.CHM::/pjv_report.htm")
    '        e.Handled = True
    '    End If

    '    If e.Control And e.Shift And e.KeyCode = Keys.L Then
    '        LoadChangeLabel()
    '    End If
    '    If e.Control And e.Shift And e.Alt And e.KeyCode = Keys.T Then
    '        'FrmProgramMappingDetail.strFormID = Form_ID
    '        'FrmProgramMappingDetail.Show()
    '    End If
    '    If e.Control And e.Shift And e.Alt And e.KeyCode = Keys.J Then
    '        'If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmCSASaleInvoice) = CompairStringResult.Equal Then ''journal entry skip on Sale Patti[By Amit Sir 05/10/2015]
    '        '    Exit Sub
    '        'End If
    '        strRvalue = ""
    '        Dim strCode As String = getNavigatorValue(Me)
    '        If clsCommon.myLen(strCode) <= 0 Then
    '            clsCommon.MyMessageBoxShow("No Document Found on Current Screen")
    '            Exit Sub
    '        End If
    '        Dim qry As String = " select Voucher_No from TSPL_JOURNAL_MASTER where Source_Doc_No ='" & strCode & "' "
    '        strCode = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry))
    '        If clsCommon.myLen(strCode) <= 0 Then
    '            clsCommon.MyMessageBoxShow("No Journal Entry Found For Current Document")
    '            Exit Sub
    '        Else
    '            Application.OpenForms("MDI").Controls("__txtDocNo").Text = strCode
    '            Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.journalEntry
    '            strRvalue = ""
    '        End If
    '    End If

    '    If e.Control And e.Shift And e.Alt And e.KeyCode = Keys.A Then
    '        strRvalue = ""
    '        Dim strCode As String = getNavigatorValue(Me)
    '        If clsCommon.myLen(strCode) <= 0 Then
    '            clsCommon.MyMessageBoxShow("No Document Found on Current Screen")
    '            Exit Sub
    '        End If
    '        strCode = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select Document_No  from TSPL_VENDOR_INVOICE_HEAD where Description like'%" & strCode & "%' "))
    '        If clsCommon.myLen(strCode) <= 0 Then
    '            clsCommon.MyMessageBoxShow("No AP Invoice Entry Found For Current Document")
    '        Else

    '            Application.OpenForms("MDI").Controls("__txtDocNo").Text = strCode
    '            Application.OpenForms("MDI").Controls("__txtScreenID").Text = clsUserMgtCode.mbtnAPInvoiceEntry
    '            'objCommonVar.ScreenToOpen = clsUserMgtCode.mbtnAPInvoiceEntry
    '            'objCommonVar.ScreenToOpenDocNo = strCode
    '            strRvalue = ""
    '        End If
    '    End If

    '    If e.Control And e.Shift And e.KeyCode = Keys.S Then
    '        isSavedGrid = False
    '        FindAndSaveGridLayout(Me)
    '        If isSavedGrid Then
    '            clsCommon.MyMessageBoxShow(" Layout Saved Successfully ")
    '        End If
    '        isSavedGrid = False
    '    End If

    '    If e.Control And e.Shift And e.KeyCode = Keys.D Then
    '        isSavedGrid = False
    '        FindAndDeleteGridLayout(Me)
    '        If isSavedGrid Then
    '            clsCommon.MyMessageBoxShow(" Layout Deleted Successfully ")
    '        End If
    '        isSavedGrid = False
    '    End If
    '    If e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.F6 Then
    '        If Me.Is_EMAIL_Applied OrElse Me.Is_SMS_Applied OrElse Me.Is_Notification_Applied Then
    '            Dim frmPWD As New FrmPWD(Nothing)
    '            frmPWD.strType = clsFixedParameterType.SMSEMailPassword
    '            frmPWD.strCode = clsFixedParameterCode.SMSEMailPassword
    '            frmPWD.ShowDialog()
    '            If frmPWD.isPasswordCorrect Then
    '                Dim frm As New frmEMailAndSMSSetting
    '                frm.isForSMS = Me.Is_SMS_Applied
    '                frm.isForEMail = Me.Is_EMAIL_Applied
    '                frm.isForNotification = Me.Is_Notification_Applied
    '                frm.Form_ID = Me.Form_ID
    '                frm.ShowDialog()
    '            End If
    '        End If
    '    ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.F7 Then
    '        Dim frmPWD As New FrmPWD(Nothing)
    '        frmPWD.strType = clsFixedParameterType.SettlementBankOnlyPWD
    '        frmPWD.strCode = clsFixedParameterCode.SettlementBankOnlyPWD
    '        frmPWD.ShowDialog()
    '        If frmPWD.isPasswordCorrect Then
    '            Dim frm As New frmSetting
    '            frm.strFormID = Me.Form_ID
    '            frm.ShowDialog()
    '            If frm.isDataSaved Then
    '                clsCommon.MyMessageBoxShow("Setting saved successfully." + Environment.NewLine + Me.Text + " will close automatic For apply new settings")
    '                clsERPFuncationality.closeForm(Me)
    '            End If
    '        End If
    '    End If
    '    If e.Control And e.Shift And e.KeyCode = Keys.R Then
    '        FindAndRestoreGridLayout(Me)
    '    End If
    '    If e.Control And e.Shift And e.Alt And e.KeyCode = Keys.X Then
    '        If objCommonVar.is_Cancel_Allowed = "1" Then
    '            Dim obj As New FrmMainTranScreen
    '            obj.SetUserMgmt(Me.Form_ID)
    '            If obj.isCancel_Flag = True Then
    '                If clsCommon.MyMessageBoxShow("Do you want to cancel this Document.?", "cancel Docuement", MessageBoxButtons.YesNo, RadMessageIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
    '                    Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
    '                    Dim cancel_after_Posting_Date As Date = Nothing
    '                    If obj.isCancel_Flag_After_Posting Then
    '                        obj.isCancel_Flag_After_Posting = IIf(clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(*) from TSPL_Cancel_After_Posting_Tables_Details where form_id='" & Me.Form_ID & "'", trans)) > 0, True, False)
    '                        cancel_after_Posting_Date = clsCommon.myCDate(clsDBFuncationality.getSingleValue("select convert(date,starting_date,103) from TSPL_Cancel_After_Posting_Tables_Details where form_id='" & Me.Form_ID & "'", trans))
    '                    End If
    '                    frmClientFormLableDetails.CancelDocument(Me, Me.Form_ID, trans, cancel_after_Posting_Date, Me, obj.isCancel_Flag_After_Posting, True)
    '                End If
    '            End If
    '        End If

    '    End If
    '    If e.Alt And e.KeyCode = Keys.D Then
    '        If is_Cancel_Allowed = "1" Then
    '            Dim dt As DataTable = clsDBFuncationality.GetDataTable("select * from TSPL_Cancel_Table_Details where Form_Id='" & Me.Form_ID & "'")
    '            If dt.Rows.Count > 0 Then
    '                Me.isDeleteFlag = False
    '            End If
    '        End If
    '    End If


    '    If e.Alt AndAlso e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.X Then
    '        If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowDesignAtRunTime, clsFixedParameterCode.AllowDesignAtRunTime, Nothing)) = 1 Then
    '            Select Case bolDesignMode
    '                Case False
    '                    If clsCommon.MyMessageBoxShow("Proceed To Design Mode ?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '                        'Set some properties
    '                        bolDesignMode = True
    '                        'Activate design mode by creating designer class with current form but exclude btndesigner from beeing designed
    '                        objCD = New ControlDesigner(Me, New List(Of Control)({}), Color.LightYellow)
    '                    End If
    '                Case Else
    '                    If clsCommon.MyMessageBoxShow("Save and Exit Design Mode ?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '                        'Exit design mode by disposing the designer class
    '                        objCD.Dispose()
    '                        objCD = Nothing
    '                        'Reset some properties
    '                        bolDesignMode = False
    '                    End If
    '            End Select
    '        End If
    '    End If


    '    If e.Alt AndAlso e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.F4 Then
    '        clsCreateAllTables.IsShowMenuOnRightClick = Not clsCreateAllTables.IsShowMenuOnRightClick
    '    End If

    '    If e.Alt AndAlso e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.F5 Then
    '        Dim frm As New frmScreenControlMappingMultiple
    '        frm.formId = Me.Form_ID
    '        frm.WindowState = FormWindowState.Maximized
    '        frm.ShowDialog()
    '    End If

    'End Sub
    'Dim isSavedGrid As Boolean = False
    'Sub SaveLayout(ByRef gridName As Control)
    '    If clsCommon.myLen(Me.Form_ID) > 0 Then
    '        CType(gridName, RadGridView).MasterTemplate.FilterDescriptors.Clear()
    '        Dim obj As New clsGridLayout()
    '        obj.ReportID = Me.Form_ID & gridName.Name.ToString() & clsCommon.myCstr(gridName.Tag)
    '        'obj.ReportID = obj.ReportID
    '        obj.UserID = objCommonVar.CurrentUserCode
    '        obj.GridLayout = New MemoryStream()
    '        CType(gridName, RadGridView).SaveLayout(obj.GridLayout)
    '        obj.GridColumns = CType(gridName, RadGridView).ColumnCount
    '        obj.GridLayout.Seek(0, System.IO.SeekOrigin.Begin)
    '        isSavedGrid = obj.SaveData()

    '        ''richa agarwal regarding memory leakage
    '        obj.GridLayout.Close()
    '        obj.GridLayout.Dispose()
    '        ''---------------
    '    End If
    'End Sub

    'Sub setUpDownFalse(ByRef gridName As Control)

    '    For i As Integer = 0 To CType(gridName, RadGridView).Columns.Count - 1
    '        If TypeOf CType(gridName, RadGridView).Columns(i) Is GridViewDecimalColumn Then
    '            CType(CType(gridName, RadGridView).Columns(i), GridViewDecimalColumn).ShowUpDownButtons = False
    '            CType(CType(gridName, RadGridView).Columns(i), GridViewDecimalColumn).Step = 0
    '        End If
    '    Next
    '    'CurGrid = gridName
    '    'AddHandler CType(gridName, RadGridView).CellEditorInitialized, AddressOf CommonGridCellEditorInitialized

    'End Sub
    ''Dim CurGrid As Control = Nothing
    ''Private Sub CommonGridCellEditorInitialized(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs)
    ''    If TypeOf CType(CurGrid, RadGridView).CurrentColumn Is GridViewDecimalColumn Then
    ''        Dim gv As RadGridView = CType(CurGrid, RadGridView)

    ''        Dim editor As Telerik.WinControls.UI.RadTextBoxEditor = TryCast(gv.ActiveEditor, RadTextBoxEditor)
    ''        Dim oszlop As Telerik.WinControls.UI.GridViewDecimalColumn = TryCast(gv.CurrentColumn, Telerik.WinControls.UI.GridViewDecimalColumn)
    ''        If editor IsNot Nothing And oszlop IsNot Nothing Then
    ''            Dim editorElement As Telerik.WinControls.UI.RadTextBoxElement = TryCast(editor.EditorElement, RadTextBoxElement)

    ''            Try
    ''                RemoveHandler editorElement.KeyDown, AddressOf CommonGridKeyDown
    ''            Catch ex As Exception
    ''            End Try
    ''            AddHandler editorElement.KeyDown, AddressOf CommonGridKeyDown
    ''        End If
    ''    End If

    ''End Sub
    ''Private Sub CommonGridKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    ''    If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
    ''        e.Handled = True
    ''    End If
    ''End Sub
    'Sub BestFitGridColumn(ByRef gridName As Control)
    '    For i As Integer = 0 To CType(gridName, RadGridView).Columns.Count - 1
    '        CType(gridName, RadGridView).Columns(i).BestFit()
    '    Next
    'End Sub


    'Sub ReStoreGridLayoutMain(ByRef gridName As Control)
    '    Try
    '        If clsCommon.myLen(Me.Form_ID) > 0 Then
    '            Dim obj As clsGridLayout = New clsGridLayout()
    '            obj = CType(obj.GetData(Me.Form_ID & gridName.Name.ToString & clsCommon.myCstr(gridName.Tag), "", objCommonVar.CurrentUserCode), clsGridLayout)
    '            If Not obj Is Nothing AndAlso obj.GridColumns >= CType(gridName, RadGridView).ColumnCount Then
    '                Dim ii As Integer
    '                For ii = 0 To CType(gridName, RadGridView).Columns.Count - 1 Step ii + 1
    '                    CType(gridName, RadGridView).Columns(ii).IsVisible = False
    '                    CType(gridName, RadGridView).Columns(ii).VisibleInColumnChooser = True
    '                Next
    '                CType(gridName, RadGridView).LoadLayout(obj.GridLayout)
    '                obj.GridLayout.Seek(0, System.IO.SeekOrigin.Begin)
    '            End If
    '            '        BestFitGridColumn(gridName)
    '        End If
    '    Catch err As Exception
    '        MessageBox.Show(err.Message)
    '    End Try
    'End Sub
    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    '    GC.Collect()
    'End Sub

    'Dim strGridName As String = ""
    'Public Sub FindAndSaveGridLayout(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)
    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If Not (TypeOf (ctrl) Is MyCheckBoxGrid) Then
    '                If ctrl.HasChildren = True Then
    '                    FindAndSaveGridLayout(Me, ctrl)
    '                End If
    '                If TypeOf (ctrl) Is RadGridView Or TypeOf (ctrl) Is DataGridView Then
    '                    Try
    '                        SaveLayout(ctrl)
    '                        CType(ctrl, RadGridView).AutoSizeRows = True
    '                    Catch ex As Exception
    '                        MessageBox.Show(ex.ToString)
    '                    End Try
    '                End If
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If Not TypeOf (ctrl) Is MyCheckBoxGrid Then
    '                If ctrl.HasChildren = True Then
    '                    FindAndSaveGridLayout(Me, ctrl)
    '                End If
    '                If TypeOf (ctrl) Is RadGridView Or TypeOf (ctrl) Is DataGridView Or TypeOf (ctrl) Is common.UserControls.MyRadGridView Then
    '                    Try
    '                        SaveLayout(ctrl)
    '                        CType(ctrl, RadGridView).AutoSizeRows = True
    '                    Catch ex As Exception
    '                        MessageBox.Show(ex.ToString)
    '                    End Try
    '                End If
    '            End If
    '        Next
    '    End If
    'End Sub

    'Public Sub FindAndSetTabStopFalse(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)
    '    'MyreadOnly
    '    'common.UserControls.txtNavigator
    '    'common.UserControls.txtFinder

    '    'Readonly
    '    'common.Controls.MyCheckBox
    '    'common.Controls.MyComboBox
    '    'common.Controls.MyDateTimePicker
    '    'common.Controls.MyRadioButton
    '    'common.Controls.MyTextBox
    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If ctrl.HasChildren = True Then
    '                FindAndSetTabStopFalse(Me, ctrl)
    '            End If
    '            'If TypeOf (ctrl) Is common.UserControls.txtNavigator Then
    '            '    Try
    '            '        If CType(ctrl, common.UserControls.txtNavigator).MyReadOnly = True Then
    '            '            CType(ctrl, common.UserControls.txtNavigator).TabStop = False
    '            '            CType(ctrl, common.UserControls.txtNavigator).MendatroryField = False
    '            '            CType(ctrl, common.UserControls.txtNavigator).Enabled = False
    '            '        End If
    '            '    Catch ex As Exception
    '            '    End Try
    '            'End If

    '            If TypeOf (ctrl) Is common.UserControls.txtFinder Then
    '                Try
    '                    If CType(ctrl, common.UserControls.txtFinder).MyReadOnly = True Then
    '                        CType(ctrl, common.UserControls.txtFinder).TabStop = False
    '                        CType(ctrl, common.UserControls.txtFinder).MendatroryField = False
    '                        'CType(ctrl, common.UserControls.txtFinder).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyCheckBox Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyCheckBox).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyCheckBox).TabStop = False
    '                        'CType(ctrl, common.Controls.MyCheckBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyComboBox Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyComboBox).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyComboBox).TabStop = False
    '                        CType(ctrl, common.Controls.MyComboBox).MendatroryField = False
    '                        ' CType(ctrl, common.Controls.MyComboBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyDateTimePicker Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyDateTimePicker).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyDateTimePicker).TabStop = False
    '                        CType(ctrl, common.Controls.MyDateTimePicker).MendatroryField = False
    '                        ' CType(ctrl, common.Controls.MyDateTimePicker).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyRadioButton Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyRadioButton).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyRadioButton).TabStop = False
    '                        'CType(ctrl, common.Controls.MyRadioButton).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyTextBox Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyTextBox).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyTextBox).TabStop = False
    '                        CType(ctrl, common.Controls.MyTextBox).MendatroryField = False
    '                        ' CType(ctrl, common.Controls.MyTextBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If
    '            If TypeOf (ctrl) Is common.MyNumBox Then
    '                Try
    '                    If CType(ctrl, common.MyNumBox).ReadOnly = True Then
    '                        CType(ctrl, common.MyNumBox).TabStop = False
    '                        CType(ctrl, common.MyNumBox).MendatroryField = False
    '                        ' CType(ctrl, common.MyNumBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If ctrl.HasChildren = True Then
    '                FindAndSetTabStopFalse(Me, ctrl)
    '            End If
    '            'If TypeOf (ctrl) Is common.UserControls.txtNavigator Then
    '            '    Try
    '            '        If CType(ctrl, common.UserControls.txtNavigator).MyReadOnly = True Then
    '            '            CType(ctrl, common.UserControls.txtNavigator).TabStop = False
    '            '            CType(ctrl, common.UserControls.txtNavigator).MendatroryField = False
    '            '            CType(ctrl, common.UserControls.txtNavigator).Enabled = False
    '            '        End If
    '            '    Catch ex As Exception
    '            '    End Try
    '            'End If

    '            If TypeOf (ctrl) Is common.UserControls.txtFinder Then
    '                Try
    '                    If CType(ctrl, common.UserControls.txtFinder).MyReadOnly = True Then
    '                        CType(ctrl, common.UserControls.txtFinder).TabStop = False
    '                        CType(ctrl, common.UserControls.txtFinder).MendatroryField = False
    '                        ' CType(ctrl, common.UserControls.txtFinder).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyCheckBox Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyCheckBox).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyCheckBox).TabStop = False
    '                        'CType(ctrl, common.Controls.MyCheckBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyComboBox Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyComboBox).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyComboBox).TabStop = False
    '                        CType(ctrl, common.Controls.MyComboBox).MendatroryField = False
    '                        'CType(ctrl, common.Controls.MyComboBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyDateTimePicker Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyDateTimePicker).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyDateTimePicker).TabStop = False
    '                        CType(ctrl, common.Controls.MyDateTimePicker).MendatroryField = False
    '                        'CType(ctrl, common.Controls.MyDateTimePicker).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyRadioButton Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyRadioButton).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyRadioButton).TabStop = False
    '                        ' CType(ctrl, common.Controls.MyRadioButton).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.Controls.MyTextBox Then
    '                Try
    '                    If CType(ctrl, common.Controls.MyTextBox).ReadOnly = True Then
    '                        CType(ctrl, common.Controls.MyTextBox).TabStop = False
    '                        CType(ctrl, common.Controls.MyTextBox).MendatroryField = False
    '                        'CType(ctrl, common.Controls.MyTextBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            If TypeOf (ctrl) Is common.MyNumBox Then
    '                Try
    '                    If CType(ctrl, common.MyNumBox).ReadOnly = True Then
    '                        CType(ctrl, common.MyNumBox).TabStop = False
    '                        CType(ctrl, common.MyNumBox).MendatroryField = False
    '                        'CType(ctrl, common.MyNumBox).Enabled = False
    '                    End If
    '                Catch ex As Exception
    '                End Try
    '            End If
    '        Next
    '    End If
    'End Sub

    'Public Sub FindAndSetgridUpDownFalse(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)

    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If ctrl.HasChildren = True Then
    '                FindAndSetgridUpDownFalse(Me, ctrl)

    '            End If

    '            If TypeOf (ctrl) Is RadGridView Then
    '                Try
    '                    setUpDownFalse(ctrl)

    '                Catch ex As Exception
    '                End Try
    '            End If
    '        Next

    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If ctrl.HasChildren = True Then
    '                FindAndSetgridUpDownFalse(Me, ctrl)
    '            End If


    '            If TypeOf (ctrl) Is RadGridView Then
    '                Try
    '                    setUpDownFalse(ctrl)
    '                Catch ex As Exception
    '                End Try
    '            End If
    '        Next
    '    End If
    'End Sub

    'Public Sub AddMouseMove(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)
    '    Try
    '        If IsNothing(contrl) Then
    '            For Each ctrl As Control In formname.Controls
    '                If ctrl.HasChildren = True Then
    '                    AddMouseMove(Me, ctrl)
    '                End If
    '                AddHandler ctrl.MouseMove, AddressOf FrmMainTranScreen_MouseMove
    '            Next
    '        Else
    '            For Each ctrl As Control In contrl.Controls
    '                If ctrl.HasChildren = True Then
    '                    AddMouseMove(Me, ctrl)
    '                End If
    '                AddHandler ctrl.MouseMove, AddressOf FrmMainTranScreen_MouseMove
    '            Next
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Public Sub FindAndDeleteGridLayout(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)
    '    If IsNothing(contrl) Then


    '        For Each ctrl As Control In formname.Controls
    '            If ctrl.HasChildren = True Then
    '                FindAndDeleteGridLayout(Me, ctrl)
    '            End If
    '            If TypeOf (ctrl) Is RadGridView Or TypeOf (ctrl) Is DataGridView Then
    '                Try
    '                    clsGridLayout.DeleteData(Me.Form_ID & ctrl.Name & clsCommon.myCstr(ctrl.Tag), objCommonVar.CurrentUserCode)
    '                    isSavedGrid = True
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                End Try
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If ctrl.HasChildren = True Then
    '                FindAndDeleteGridLayout(Me, ctrl)
    '            End If
    '            If TypeOf (ctrl) Is RadGridView Or TypeOf (ctrl) Is DataGridView Then
    '                Try
    '                    clsGridLayout.DeleteData(Me.Form_ID & ctrl.Name & clsCommon.myCstr(ctrl.Tag), objCommonVar.CurrentUserCode)
    '                    isSavedGrid = True
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                End Try
    '            End If
    '        Next
    '    End If
    'End Sub
    'Public Sub FindAndRestoreGridLayout(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)
    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If Not (TypeOf (ctrl) Is MyCheckBoxGrid) Then
    '                If ctrl.HasChildren = True Then
    '                    FindAndRestoreGridLayout(Me, ctrl)
    '                End If
    '                If TypeOf (ctrl) Is RadGridView Or TypeOf (ctrl) Is DataGridView Then
    '                    Try
    '                        ReStoreGridLayoutMain(ctrl)
    '                    Catch ex As Exception
    '                        MessageBox.Show(ex.ToString)
    '                    End Try
    '                End If
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If Not (TypeOf (ctrl) Is MyCheckBoxGrid) Then
    '                If ctrl.HasChildren = True Then
    '                    FindAndRestoreGridLayout(Me, ctrl)
    '                End If
    '                If TypeOf (ctrl) Is RadGridView Or TypeOf (ctrl) Is DataGridView Then
    '                    Try
    '                        ReStoreGridLayoutMain(ctrl)
    '                    Catch ex As Exception
    '                        MessageBox.Show(ex.ToString)
    '                    End Try
    '                End If
    '            End If
    '        Next
    '    End If
    'End Sub
    'Private Sub LoadChangeLabel()
    '    'To be Uncomment
    '    Try
    '        Dim obj As New frmClientFormLableDetails
    '        obj.formnam = Me
    '        obj.formcode = Form_ID
    '        ' obj.LoadLableData(Me)
    '        obj.ShowDialog()
    '        ' Dim ee As System.EventArgs 
    '        FrmMainTranScreen_Shown("", Nothing)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub

    'Dim aa As String = objCommonVar.CurrDatabase

    'Private Sub FrmMainTranScreen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    FrmMainTranScreen.LastWorkingTime = DateTime.Now()
    'End Sub


    Private Sub FrmMainTranScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Me.DesignMode Then
        '    AddMouseUpEventHandlerToAllControl(Me)
        '    Dim isTabOrderOn As Boolean = objCommonVar.IsAutoTabOrdering
        '    If isTabOrderOn Then
        '        Dim tabOrderPattern As Integer = objCommonVar.CurrentTabOrderPattern
        '        Dim scheme As TabOrderManager.TabScheme
        '        If tabOrderPattern = 1 Then
        '            scheme = TabOrderManager.TabScheme.AcrossFirst
        '        ElseIf tabOrderPattern = 2 Then
        '            scheme = TabOrderManager.TabScheme.DownFirst
        '        Else
        '            scheme = TabOrderManager.TabScheme.None
        '        End If
        '        Dim tom As New TabOrderManager(Me)
        '        tom.SetTabOrder(scheme)
        '    End If
        '    If objCommonVar.AutoSetTabStopForReadOnlyControls = 1 Then
        '        FindAndSetTabStopFalse(Me)
        '    End If
        '    FrmMainTranScreen.LastWorkingTime = DateTime.Now()
        '    'Try
        '    '    FrmMainTranScreen.LastWorkingTime = DateTime.Now()
        '    '    'Me.Capture = True
        '    '    'Me.Cursor = Cursors.Default

        '    '    If clsCommon.myLen(is_Cancel_Allowed) <= 0 Then
        '    '        is_Cancel_Allowed = objCommonVar.is_Cancel_Allowed
        '    '    End If

        '    'Catch ex As Exception

        '    'End Try
        '    If Not Me.DesignMode Then
        '        AddMouseMove(Me)
        '    End If

        '    'If Not Me.DesignMode Then
        '    '    If objCommonVar.AllowDesignAtRunTime Then
        '    '        Try
        '    '            Dim objCM As New ControlManager
        '    '            objCM.RestoreProperties(Me)
        '    '            objCM.Dispose()
        '    '            objCM = Nothing
        '    '        Catch ex As Exception
        '    '        End Try
        '    '    End If
        '    'End If
        'End If

    End Sub

    'Dim strRvalue As String = ""
    'Function getNavigatorValue(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing) As String
    '    If clsCommon.myLen(strRvalue) > 0 Then
    '        Return strRvalue
    '        Exit Function
    '    End If

    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If ctrl.HasChildren = True Then
    '                getNavigatorValue(Me, ctrl)
    '            End If
    '            If TypeOf (ctrl) Is common.UserControls.txtNavigator Then
    '                Try
    '                    strRvalue = clsCommon.myCstr(CType(ctrl, common.UserControls.txtNavigator).Value)
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                End Try
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If ctrl.HasChildren = True Then
    '                getNavigatorValue(Me, ctrl)
    '            End If
    '            If TypeOf (ctrl) Is common.UserControls.txtNavigator Then
    '                Try
    '                    strRvalue = clsCommon.myCstr(CType(ctrl, common.UserControls.txtNavigator).Value)
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.ToString)
    '                End Try
    '            End If
    '        Next
    '    End If
    '    If clsCommon.myLen(strRvalue) > 0 Then
    '        Return strRvalue
    '        Exit Function
    '    End If
    '    Return ""
    'End Function

    'Private Sub FrmMainTranScreen_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

    'End Sub

    'Private Sub FrmMainTranScreen_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
    '    FrmMainTranScreen.LastWorkingTime = DateTime.Now()
    'End Sub

    'Private Sub FrmMainTranScreen_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
    '    If Not (OldMouseX = e.X AndAlso OldMouseY = e.Y) Then
    '        FrmMainTranScreen.LastWorkingTime = DateTime.Now()
    '    End If
    '    OldMouseX = e.X
    '    OldMouseY = e.Y
    '    'Me.Capture = True
    'End Sub
    'Public Sub AddSpecialAttributesToFormControl(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)

    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If ctrl.HasChildren = True AndAlso Not (TypeOf ctrl Is common.UserControls.txtFinder OrElse TypeOf ctrl Is common.UserControls.txtNavigator) Then
    '                AddSpecialAttributesToFormControl(formname, ctrl)
    '            End If
    '            If Not (TypeOf ctrl Is RadGroupBox OrElse TypeOf ctrl Is SplitContainer OrElse TypeOf ctrl Is RadPanel OrElse TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is common.UserControls.MyRadGridView) AndAlso clsCommon.myLen(ctrl.Name) > 0 Then
    '                Dim fieldName As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Description from tspl_screen_control_master where programCode in (select Program_code from tspl_program_master where mainFormName='" & formname.Name & "') and controlName='" & ctrl.Name & "'"))
    '                If TypeOf ctrl Is MyNumBox Then
    '                    TryCast(ctrl, MyNumBox).FieldName = fieldName
    '                End If
    '                If TypeOf ctrl Is common.Controls.MyTextBox Then
    '                    TryCast(ctrl, common.Controls.MyTextBox).FieldName = fieldName
    '                End If
    '                ctrl.Tag = fieldName
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If ctrl.HasChildren = True AndAlso Not (TypeOf ctrl Is common.UserControls.txtFinder OrElse TypeOf ctrl Is common.UserControls.txtNavigator) Then
    '                AddSpecialAttributesToFormControl(formname, ctrl)
    '            End If
    '            If Not (TypeOf ctrl Is RadGroupBox OrElse TypeOf ctrl Is SplitContainer OrElse TypeOf ctrl Is RadPanel OrElse TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is common.UserControls.MyRadGridView) AndAlso clsCommon.myLen(ctrl.Name) > 0 Then
    '                Dim fieldName As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Description from tspl_screen_control_master where programCode in (select Program_code from tspl_program_master where mainFormName='" & formname.Name & "') and controlName='" & ctrl.Name & "'"))
    '                If TypeOf ctrl Is MyNumBox Then
    '                    TryCast(ctrl, MyNumBox).FieldName = fieldName
    '                End If
    '                If TypeOf ctrl Is common.Controls.MyTextBox Then
    '                    TryCast(ctrl, common.Controls.MyTextBox).FieldName = fieldName
    '                End If
    '                ctrl.Tag = fieldName
    '            End If
    '        Next
    '    End If
    'End Sub

    'Public Sub AddMouseUpEventHandlerToAllControl(ByRef formname As XpertERPEngine.FrmMainTranScreen, Optional ByVal contrl As Control = Nothing)

    '    If IsNothing(contrl) Then
    '        For Each ctrl As Control In formname.Controls
    '            If ctrl.HasChildren = True AndAlso Not (TypeOf ctrl Is common.UserControls.txtFinder OrElse TypeOf ctrl Is common.UserControls.txtNavigator) Then
    '                AddMouseUpEventHandlerToAllControl(formname, ctrl)
    '            End If
    '            'If Not (TypeOf ctrl Is RadGroupBox OrElse TypeOf ctrl Is SplitContainer OrElse TypeOf ctrl Is RadPanel OrElse TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is common.UserControls.MyRadGridView) AndAlso clsCommon.myLen(ctrl.Name) > 0 Then
    '            '    AddHandler ctrl.MouseUp, AddressOf FrmMainTranScreen_MouseUp
    '            'End If
    '            If TypeOf ctrl Is common.UserControls.MyRadGridView AndAlso clsCommon.myLen(ctrl.Name) > 0 Then
    '                AddHandler ctrl.MouseUp, AddressOf FrmMainTranScreen_MouseUp
    '            End If
    '        Next
    '    Else
    '        For Each ctrl As Control In contrl.Controls
    '            If ctrl.HasChildren = True AndAlso Not (TypeOf ctrl Is common.UserControls.txtFinder OrElse TypeOf ctrl Is common.UserControls.txtNavigator) Then
    '                AddMouseUpEventHandlerToAllControl(formname, ctrl)
    '            End If
    '            'If Not (TypeOf ctrl Is RadGroupBox OrElse TypeOf ctrl Is SplitContainer OrElse TypeOf ctrl Is RadPanel OrElse TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is common.UserControls.MyRadGridView) AndAlso clsCommon.myLen(ctrl.Name) > 0 Then
    '            '    AddHandler ctrl.MouseUp, AddressOf FrmMainTranScreen_MouseUp
    '            'End If
    '            If TypeOf ctrl Is common.UserControls.MyRadGridView AndAlso clsCommon.myLen(ctrl.Name) > 0 Then
    '                AddHandler ctrl.MouseUp, AddressOf FrmMainTranScreen_MouseUp
    '            End If
    '        Next
    '    End If
    'End Sub
    'Public ctrlRightClicked As New Control
    'Private Sub FrmMainTranScreen_MouseUp(sender As Object, e As MouseEventArgs)

    '    If e.Button = Windows.Forms.MouseButtons.Right AndAlso clsCreateAllTables.IsShowMenuOnRightClick Then
    '        clsCommon.MyMessageBoxShow("Hi")
    '        Dim ctr As Control = sender 'clsCreateAllTables.FindControlAtCursor(Me)
    '        ctrlRightClicked = ctr
    '        If ctr IsNot Nothing Then
    '            ContextMenuStrip1.Show(ctr, e.Location)
    '        End If
    '    End If

    'End Sub



    ''Private Sub FrmMainTranScreen_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    ''End Sub
    'Private Sub FrmMainTranScreen_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    If Not Me.DesignMode Then
    '        Try
    '            If clsCommon.myLen(Form_ID) > 0 Then
    '                Dim obj As New frmClientFormLableDetails
    '                obj.formcode = Form_ID
    '                obj.formnam = Me
    '                obj.LoadLableChanged(Me, , True)
    '                'obj.Dispose()
    '                If objCommonVar.AutoRestoreGridLayout Then
    '                    FindAndRestoreGridLayout(Me)
    '                End If
    '                FindAndSetgridUpDownFalse(Me)
    '                'AddMouseMove(Me)

    '            End If
    '            If is_Cancel_Allowed = "1" Then
    '                frmClientFormLableDetails.HideDeleteButon(Me, Me.Form_ID, Nothing)
    '            End If
    '        Catch ex As Exception
    '            clsCommon.MyMessageBoxShow(ex.Message)
    '        End Try
    '    End If
    'End Sub
    ' '' Anubhooti 09-Sep-2014 Check Transactions For Financial Year--------------------------------------------
    'Public Shared Function ValidateTransactionAccToFinYear(ByVal Form_Name As String, ByVal DocDate As String) As Boolean
    '    'Try
    '    '    Dim Post_Previousyear As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Post_Previousyear From TSPL_GLSETTING"))
    '    '    If clsCommon.CompairString(Post_Previousyear, "Y") = CompairStringResult.Equal Then
    '    '        Dim QryCurrYear As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("  Select COUNT(Is_Current_Year) As Is_Current_Year  From TSPL_Fiscal_Year_Master where Comp_Code='" + objCommonVar.CurrentCompanyCode + "' and Is_Current_Year =1"))
    '    '        Dim Qry As String = "  Select COUNT(Fiscal_Code) As Fiscal_Code  From TSPL_Fiscal_Year_Master where Comp_Code='" + objCommonVar.CurrentCompanyCode + "' AND convert(Date, '" + DocDate + "', 103)>= CONVERT(date, Start_Date,103) AND convert(Date, '" + DocDate + "', 103) <= CONVERT(date, End_Date ,103) and Is_Current_Year =1"
    '    '        Dim DocDateWOTime As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("Select convert(Date, '" + DocDate + "', 103)"))
    '    '        Dim Fiscal_Code As Integer = clsCommon.myCstr(clsDBFuncationality.getSingleValue(Qry))
    '    '        If Fiscal_Code = 0 Then
    '    '            If common.clsCommon.MyMessageBoxShow("Document date " + DocDateWOTime + " does not exists in current financial year.Do you still want to continue ", Form_Name, MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
    '    '            Else
    '    '                Return False
    '    '            End If
    '    '        End If
    '    '    End If
    '    '    Return True
    '    'Catch ex As Exception
    '    '    Throw New Exception(ex.Message)
    '    'End Try

    '    Try
    '        Dim QryCurrYear As Integer
    '        QryCurrYear = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select COUNT(Is_Current_Year) As Is_Current_Year  From TSPL_Fiscal_Year_Master where Comp_Code='" + objCommonVar.CurrentCompanyCode + "' and Is_Current_Year =1"))
    '        Dim Post_Previousyear As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Post_Previousyear From TSPL_GLSETTING"))
    '        If clsCommon.CompairString(Post_Previousyear, "Y") = CompairStringResult.Equal Then
    '            If QryCurrYear > 0 Then
    '                Dim Qry As String = "  Select COUNT(Fiscal_Code) As Fiscal_Code  From TSPL_Fiscal_Year_Master where Comp_Code='" + objCommonVar.CurrentCompanyCode + "' AND convert(Date, '" + DocDate + "', 103)>= CONVERT(date, Start_Date,103) AND convert(Date, '" + DocDate + "', 103) <= CONVERT(date, End_Date ,103) and Is_Current_Year =1"
    '                Dim DocDateWOTime As Date = clsCommon.myCDate(clsDBFuncationality.getSingleValue("Select convert(Date, '" + DocDate + "', 103)"))
    '                Dim Fiscal_Code As Integer = clsCommon.myCstr(clsDBFuncationality.getSingleValue(Qry))
    '                If Fiscal_Code = 0 Then
    '                    If common.clsCommon.MyMessageBoxShow("Document date " + DocDateWOTime + " does not exists in current financial year.Do you still want to continue ", Form_Name, MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
    '                    Else
    '                        Return False
    '                    End If
    '                End If
    '            End If
    '            'ElseIf clsCommon.CompairString(Post_Previousyear, "N") = CompairStringResult.Equal Then
    '            '    If QryCurrYear > 0 Then
    '            '        Dim QrySettOff As String = "  Select COUNT(Fiscal_Code) As Fiscal_Code  From TSPL_Fiscal_Year_Master where Comp_Code='" + objCommonVar.CurrentCompanyCode + "' AND convert(Date, '" + DocDate + "', 103)>= CONVERT(date, Start_Date,103) AND convert(Date, '" + DocDate + "', 103) <= CONVERT(date, End_Date ,103) and Is_Current_Year =1"
    '            '        Dim DocDateWOTimeSettOff As Date = clsCommon.myCDate(clsDBFuncationality.getSingleValue("Select convert(Date, '" + DocDate + "', 103)"))
    '            '        Dim Fiscal_CodeSettOff As Integer = clsCommon.myCstr(clsDBFuncationality.getSingleValue(QrySettOff))
    '            '        If Fiscal_CodeSettOff = 0 Then
    '            '            clsCommon.MyMessageBoxShow("You can not make this entry beacuse document date " + DocDateWOTimeSettOff + " does not lie in current financial year")
    '            '            Return False
    '            '        End If
    '            '    End If
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Function
    ''-------------------------------------------------------------------------------

    'Private Sub GetControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetControlToolStripMenuItem.Click
    '    Try
    '        clsCommon.MyMessageBoxShow("Hi")
    '        If ctrlRightClicked IsNot Nothing Then
    '            Dim frm As New frmScreenControlDescriptionMapping
    '            frm.ctrl = ctrlRightClicked
    '            frm.formId = Me.Form_ID
    '            frm.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        clsCommon.MyMessageBoxShow(ex.Message)
    '    End Try
    'End Sub

    'Private Sub SetDescriptionForAllControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetDescriptionForAllControlToolStripMenuItem.Click
    '    Dim frm As New frmScreenControlMappingMultiple
    '    frm.formId = Me.Form_ID
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.ShowDialog()
    'End Sub

    'Private Sub AddForCustomFieldGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddForCustomFieldGridToolStripMenuItem.Click
    '    Try
    '        If ctrlRightClicked IsNot Nothing Then
    '            Dim qry As String = " delete from TSPL_SCREEN_Grid_CONTROL_MASTER where ProgramCode='" & Me.Form_ID & "'"
    '            clsDBFuncationality.ExecuteNonQuery(qry)
    '            Dim gv As common.UserControls.MyRadGridView = TryCast(ctrlRightClicked, common.UserControls.MyRadGridView)
    '            For i As Integer = 0 To gv.Columns.Count - 1
    '                qry = "insert into TSPL_SCREEN_Grid_CONTROL_MASTER(ProgramCode,GridName,ColumnName,ColumnDescription) values('" & Me.Form_ID & "','" & gv.Name & "','" & gv.Columns(i).Name & "','" & gv.Columns(i).HeaderText & "')"
    '                clsDBFuncationality.ExecuteNonQuery(qry)
    '            Next
    '            clsCommon.MyMessageBoxShow("Saved Successfully")
    '            clsCreateAllTables.IsShowMenuOnRightClick = False
    '        End If
    '    Catch ex As Exception
    '        clsCommon.MyMessageBoxShow(ex.Message)
    '    End Try
    'End Sub

    'Private Function btnDelete() As Object
    '    Throw New NotImplementedException
    'End Function

    'Public Sub New()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    'Public Sub SetUserMgmtCommonForScreenwithTelerikButton(ByVal FormID As String, Optional ByVal btnSave As Telerik.WinControls.UI.RadButton = Nothing, Optional ByVal btnDelete As Telerik.WinControls.UI.RadButton = Nothing, Optional ByVal btnPost As Button = Nothing, Optional ByVal btnReverse As Telerik.WinControls.UI.RadButton = Nothing, Optional ByVal btnImport As Telerik.WinControls.UI.RadMenuItem = Nothing, Optional ByVal btnExport As Telerik.WinControls.UI.RadMenuItem = Nothing)
    '    Me.KeyPreview = True
    '    'Me.WindowState = FormWindowState.Maximized
    '    Dim qry As String = ""
    '    If clsCommon.myLen(FormID) <= 0 Then
    '        common.clsCommon.MyMessageBoxShow("Form ID not found")
    '        Me.Close()
    '        Exit Sub
    '    End If
    '    Me.Form_ID = FormID
    '    qry = " select Parent_Code  from TSPL_PROGRAM_MASTER where program_code in (" & _
    '          " select Parent_Code from TSPL_PROGRAM_MASTER where program_code='" & Form_ID & "')"


    '    'strqModule = "WITH PROGRAM_HIERARCHY AS (" & _
    '    '            " SELECT TSPL_PROGRAM_MASTER.Program_Code, TSPL_PROGRAM_MASTER.Parent_Code ,1 AS PROGRAM_LEVEL,TSPL_PROGRAM_MASTER.Type" & _
    '    '            " FROM TSPL_PROGRAM_MASTER " & _
    '    '            " UNION ALL " & _
    '    '            " SELECT PROGRAM_HIERARCHY.Program_Code,TSPL_PROGRAM_MASTER.Parent_Code,(PROGRAM_LEVEL + 1) AS PROGRAM_LEVEL,TSPL_PROGRAM_MASTER.Type" & _
    '    '            " FROM PROGRAM_HIERARCHY JOIN TSPL_PROGRAM_MASTER ON PROGRAM_HIERARCHY.Parent_Code = TSPL_PROGRAM_MASTER.Program_Code" & _
    '    '            " )" & _
    '    '            " SELECT  DISTINCT PROGRAM_HIERARCHY.Parent_Code " & _
    '    '            " FROM PROGRAM_HIERARCHY " & _
    '    '            " WHERE PROGRAM_HIERARCHY.Program_Code='" & FormID & "' " & _
    '    '            " AND PROGRAM_HIERARCHY.Type='SM' AND PROGRAM_HIERARCHY.PROGRAM_LEVEL=2;"

    '    Me.Module_Code = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry))
    '    If clsCommon.CompairString(objCommonVar.CurrentUserCode, "Admin") = CompairStringResult.Equal Then
    '        isReadFlag = True
    '        isModifyFlag = True
    '        isDeleteFlag = True
    '        isPostFlag = True
    '        isReverse = True
    '        isExport = True
    '        isCancel_Flag = True
    '        isCancel_Flag_After_Posting = True
    '        btnSave.Visible = True
    '        btnDelete.Visible = True
    '        btnPost.Visible = True
    '        If btnSave.Visible Then
    '            btnReverse.Enabled = True
    '            btnImport.Enabled = True
    '            btnExport.Enabled = True
    '        End If

    '    Else
    '        qry = "select Read_Flag,Modify_Flag,Delete_Flag,Authorized_Flag, Reverse_Flag, Export_Flag,cancel_Flag,cancel_Flag_After_Posting from TSPL_GROUP_PROGRAM_MAPPING where Program_Code='" + FormID + "' and Group_Code in (select Group_Code  from TSPL_USER_GROUP_MAPPING where User_Code='" + objCommonVar.CurrentUserCode + "')"
    '        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            For Each dr As DataRow In dt.Rows
    '                If isReadFlag = False Then
    '                    Throw New Exception("Permission Denied")
    '                    isReadFlag = IIf(clsCommon.myCdbl(dr("Read_Flag")) = 1, True, False)
    '                End If

    '                If isModifyFlag = False Then
    '                    isModifyFlag = IIf(clsCommon.myCdbl(dr("Modify_Flag")) = 1, True, False)
    '                End If
    '                If isDeleteFlag = False Then
    '                    isDeleteFlag = IIf(clsCommon.myCdbl(dr("Delete_Flag")) = 1, True, False)
    '                End If
    '                If isPostFlag = False Then
    '                    isPostFlag = IIf(clsCommon.myCdbl(dr("Authorized_Flag")) = 1, True, False)
    '                End If
    '                If isReverse = False Then
    '                    isReverse = IIf(clsCommon.myCdbl(dr("Reverse_Flag")) = 1, True, False)
    '                End If
    '                If isExport = False Then
    '                    isExport = IIf(clsCommon.myCdbl(dr("Export_Flag")) = 1, True, False)
    '                End If
    '                If isCancel_Flag = False Then
    '                    isCancel_Flag = IIf(clsCommon.myCdbl(dr("Cancel_Flag")) = 1, True, False)
    '                End If
    '                If isCancel_Flag_After_Posting = False Then
    '                    isCancel_Flag_After_Posting = IIf(clsCommon.myCdbl(dr("Cancel_Flag_After_Posting")) = 1, True, False)
    '                End If

    '                btnSave.Visible = isReadFlag
    '                btnDelete.Visible = isModifyFlag
    '                btnPost.Visible = isPostFlag
    '                If btnSave.Visible Then
    '                    btnReverse.Enabled = isReverse
    '                    btnImport.Enabled = isExport
    '                    btnExport.Enabled = isExport
    '                End If
    '            Next
    '            'isReadFlag = IIf(clsCommon.myCdbl(dt.Rows(0)("Read_Flag")) = 1, True, False)
    '            'isModifyFlag = IIf(clsCommon.myCdbl(dt.Rows(0)("Modify_Flag")) = 1, True, False)
    '            'isDeleteFlag = IIf(clsCommon.myCdbl(dt.Rows(0)("Delete_Flag")) = 1, True, False)
    '            'isPostFlag = IIf(clsCommon.myCdbl(dt.Rows(0)("Authorized_Flag")) = 1, True, False)
    '            'isReverse = IIf(clsCommon.myCdbl(dt.Rows(0)("Reverse_Flag")) = 1, True, False)
    '            'isExport = IIf(clsCommon.myCdbl(dt.Rows(0)("Export_Flag")) = 1, True, False)

    '        End If
    '    End If

    '    qry = "select 1 from TSPL_CUSTOM_FIELD_MAPPING where Program_Code='" + FormID + "' and Is_For_Detail_Level='0' "
    '    Dim dtNew As DataTable = clsDBFuncationality.GetDataTable(qry)
    '    If dtNew IsNot Nothing AndAlso dtNew.Rows.Count Then
    '        customFieldTabProperty = ElementVisibility.Visible
    '    End If
    '    ArrDetailFields = clsCustomFieldMapping.GetData(FormID, "D")



    'End Sub

    ''== KUNAL > 5-SEP- 2016 ======
    'Dim IsSettingOn As Boolean = False
    'Public Function AllowFutureDateTransaction(ByVal docDate As Date, ByVal trans As SqlClient.SqlTransaction) As Boolean
    '    IsSettingOn = IIf(clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowFutureDateTransaction, clsFixedParameterType.AllowFutureDateTransaction, trans)) = 1, True, False)
    '    If IsSettingOn = False Then
    '        If docDate > clsCommon.GETSERVERDATE(trans) Then
    '            clsCommon.MyMessageBoxShow("Cannot allow future date -  " & docDate)
    '            Return False
    '        End If
    '    End If
    '    '===================added By preeti Gupta [01/02/2017]=================
    '    If AllowBackDateEntry(docDate, trans) = False Then
    '        Return False
    '    End If
    '    '======================================================================
    '    Return True
    'End Function

    ''done by stuti on 17/10/2016 against ticket no - BM00000009608
    'Dim BackDateEntry As Integer = 0
    'Public Function AllowBackDateEntry(ByVal docDate As Date, ByVal trans As SqlClient.SqlTransaction) As Boolean
    '    BackDateEntry = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowBackDateEntry, clsFixedParameterType.AllowBackDateEntry, trans))

    '    '================Added by preeti Gupta============================

    '    '=================================================================


    '    If clsCommon.GetPrintDate(docDate, "yyyy-MM-dd") < clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans).AddDays(-BackDateEntry), "yyyy-MM-dd") Then

    '        Dim frm As New FrmPWD(Nothing)
    '        frm.Text = "Please enter password for back date entry"
    '        frm.strType = "BackDateEntryPwd"
    '        frm.strCode = "BackDateEntryPwd"
    '        frm.ShowDialog()
    '        If frm.isPasswordCorrect Then
    '            Return True
    '        Else
    '            clsCommon.MyMessageBoxShow("Back date entry allowed to authorised user only.")
    '            Return False
    '        End If

    '    End If
    '    Return True
    'End Function

    'Public Function AllowAmendmentWithPasssword(ByVal FormId As String, ByVal trans As SqlClient.SqlTransaction) As Boolean
    '    Dim qry As String = Nothing
    '    Dim val As String = Nothing
    '    Dim dt As DataTable = New DataTable()
    '    qry = "select is_Amendment from TSPL_GROUP_PROGRAM_MAPPING left outer join TSPL_USER_GROUP_MAPPING on TSPL_GROUP_PROGRAM_MAPPING.Group_Code=TSPL_USER_GROUP_MAPPING.Group_Code where User_Code='" + clsCommon.myCstr(objCommonVar.CurrentUserCode) + "' and Program_Code='" + clsCommon.myCstr(FormId) + "' "
    '    val = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
    '    If clsCommon.myLen(val) > 0 AndAlso clsCommon.CompairString(val, "1") = CompairStringResult.Equal Then
    '        Dim frm As New FrmPWD(trans)
    '        frm.Text = "Please enter password for amendment"
    '        frm.strType = ""
    '        frm.strCode = ""
    '        frm.FormId = FormId
    '        frm.ShowDialog()
    '        If frm.isPasswordCorrect Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End If
    '    Return False
    'End Function
End Class
