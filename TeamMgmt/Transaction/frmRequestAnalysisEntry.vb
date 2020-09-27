Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Threading
Imports System.Data.Sql
Imports common

Public Class FrmRequestAnalysisEntry
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False
    Private strCureentScreenOpenByDilog As String = ""

    Private Sub FrmRequestAnalysisEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        strCureentScreenOpenByDilog = CType(Me.Owner, FrmRequestAnalysis).Text
        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
            MyBase.SetUserMgmt(clsUserMgtCode.frmRequestAnalysis)
        Else
            MyBase.SetUserMgmt(clsUserMgtCode.frmRequestApproval)
        End If
        UcAttachment1.Form_ID = MyBase.Form_ID
        AddNew()

        LoadTicketType()
        LoadSeverity()
        LoadPriority()

        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
            If CType(Me.Owner, FrmRequestAnalysis).strClickGrid = "gv" Then
                If CType(Me.Owner, FrmRequestAnalysis).gv.Rows.Count > 0 Then
                    If clsCommon.myLen(clsCommon.myCstr(CType(Me.Owner, FrmRequestAnalysis).gv.CurrentRow.Cells("REQUEST_ANALYSIS_NO").Value)) > 0 Then
                        LoadData(CType(Me.Owner, FrmRequestAnalysis).gv.CurrentRow.Cells("REQUEST_ANALYSIS_NO").Value)
                    End If
                End If
            End If
            If CType(Me.Owner, FrmRequestAnalysis).strClickGrid = "gvOpen" Then
                If CType(Me.Owner, FrmRequestAnalysis).gvOpen.Rows.Count > 0 Then
                    If clsCommon.myLen(clsCommon.myCstr(CType(Me.Owner, FrmRequestAnalysis).gvOpen.CurrentRow.Cells("REQUEST_NO").Value)) > 0 Then
                        RequestDetailsFill(CType(Me.Owner, FrmRequestAnalysis).gvOpen.CurrentRow.Cells("REQUEST_NO").Value)
                    End If
                End If
            End If
        ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Approval") = CompairStringResult.Equal Then

        End If









        'If clsCommon.myLen(objCommonVar.CurrentTicketNo) > 0 Then
        '    LoadData(clsCommon.myCstr(objCommonVar.CurrentTicketNo))
        '    objCommonVar.CurrentTicketNo = ""
        'End If
        ''
        'If clsCommon.myLen(objCommonVar.CurrentOpenRequestNo) > 0 Then
        '    RequestDetailsFill(objCommonVar.CurrentOpenRequestNo)
        '    objCommonVar.CurrentOpenRequestNo = ""
        'End If
    End Sub
    Sub LoadTicketType()
        cboTicketType.DataSource = clsTicketMasterEntry.LoadTicketType()
        cboTicketType.ValueMember = "Code"
        cboTicketType.DisplayMember = "Name"
        cboTicketType.SelectedIndex = 0
    End Sub

    Sub LoadDataErrorType()
        cboDataErrorType.DataSource = clsTicketMasterEntry.LoadDataErrorType()
        cboDataErrorType.ValueMember = "Code"
        cboDataErrorType.DisplayMember = "Name"
    End Sub

    Sub LoadSeverity()
        cboSeverity.DataSource = clsTicketMasterEntry.LoadSeverity()
        cboSeverity.ValueMember = "Code"
        cboSeverity.DisplayMember = "Name"
    End Sub

    Sub LoadPriority()
        cboPriority.DataSource = clsTicketMasterEntry.LoadPriority()
        cboPriority.ValueMember = "Code"
        cboPriority.DisplayMember = "Name"
    End Sub
    Sub LoadTicketStatus()
        cboAnalysisStatus.DataSource = clsTicketMasterEntry.LoadTicketStatus()
        cboAnalysisStatus.ValueMember = "Code"
        cboAnalysisStatus.DisplayMember = "Name"
    End Sub

    Sub LoadAnalysisStatus()
        cboAnalysisStatus.DataSource = GetRequestAnalysisStatus()
        cboAnalysisStatus.ValueMember = "Code"
        cboAnalysisStatus.DisplayMember = "Code"
    End Sub

    Private Function GetRequestAnalysisStatus() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Code", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Analysed"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Closed"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Cancel"
        dt.Rows.Add(dr)

        Return dt
    End Function

    Private Sub cboTicketType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTicketType.SelectedValueChanged
        If clsCommon.CompairString(cboTicketType.Text, "Data Correction") = CompairStringResult.Equal Then
            LoadDataErrorType()
        Else
            cboDataErrorType.DataSource = Nothing
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsRequestAnalysisEnry()

                ' REQUEST_NO ,CLIENT_CODE ,SCREEN_CODE,MODULE_CODE,PROJECT_CODE,ANALYSIS_STATUS,DEVELOPER_CODE,
                'TESTER_CODE,TICKET_TYPE,DATA_ERROR_TYPE,SEVERITY,PRIORITY,ANALYSIS_DESCRIPTION
                ' TICKET_NO,ALLOCATED_TIME,TESTING_TIME

                obj.REQUEST_ANALYSIS_NO = txtRequestAnalysisNo.Value
                obj.REQUEST_NO = txtRequestNo.Value
                obj.CLIENT_CODE = txtClient.Value
                obj.SCREEN_CODE = txtScreen.Value
                obj.SCREEN_NAME = lblScreen.Text
                obj.MODULE_CODE = txtModule.Value
                obj.MODULE_NAME = lblModule.Text
                obj.PROJECT_CODE = txtProject.Value
                obj.PROJECT_NAME = lblProject.Text
                'obj.ANALYSIS_STATUS = cboAnalysisStatus.Text
                obj.DEVELOPER_CODE = txtDeveloper.Value
                obj.DEVELOPER_NAME = lblDeveloper.Text
                obj.TESTER_CODE = txtTester.Value
                obj.TESTER_NAME = lblTester.Text
                obj.TICKET_TYPE = cboTicketType.Text
                obj.DATA_ERROR_TYPE = cboDataErrorType.Text
                obj.SEVERITY = cboSeverity.Text
                obj.PRIORITY = cboPriority.Text
                obj.ANALYSIS_DESCRIPTION = txtRequestAnalysisDescription.Text
                obj.TICKET_NO = lblTicketNo.Text
                obj.ALLOCATED_TIME = txtAllocatedTime.Text
                obj.APPROVED_TIME = txtApprovedTime.Text
                obj.Form_Title_Name = strCureentScreenOpenByDilog
                obj.REQUEST_DESCRIPTION = txtRequestDescription.Text
                'obj.TESTING_TIME = txtTestingTime.Text
                If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
                    ' obj.ANALYSIS_STATUS = "Analysed"
                    obj.ANALYSIS_STATUS = cboAnalysisStatus.Text
                Else
                    obj.ANALYSIS_STATUS = cboAnalysisStatus.Text
                End If

                If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
                    Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
                    If clsCommon.myLen(strTestingTime) > 0 Then
                        'obj.TESTING_TIME = FormatNumber(CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strTestingTime) / 100)), 2)
                        obj.TESTING_TIME = FormatNumber(CDbl(CalculateTestingTime(obj.ALLOCATED_TIME)), 2)
                    End If
                Else
                    obj.TESTING_TIME = txtTestingTime.Text
                End If

                ' ----------------------************************************************************-------------------------------------
                If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
                    'Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
                    'Dim strDebuggingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Debugging_Time from TSPL_TIME_MASTER"))
                    'Dim strAdditionalTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Additional_Time from TSPL_TIME_MASTER"))
                    If clsCommon.myLen(txtAllocatedTime.Text) > 0 Then
                        'Dim TotalAllocatedTime As Double = obj.ALLOCATED_TIME 'FormatNumber(CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strTestingTime) / 100)) + CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strDebuggingTime) / 100)) + CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strDebuggingTime) / 100)), 2)
                        'Dim d1 As Double = FormatNumber(CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strTestingTime) / 100)), 2)
                        'Dim d2 As Double = FormatNumber(CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strDebuggingTime) / 100)), 2)
                        'Dim d3 As Double = FormatNumber(CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strAdditionalTime) / 100)), 2)
                        'TotalAllocatedTime = TotalAllocatedTime + d1 + d2 + d3
                        obj.TOTAL_TIME = FormatNumber(CDbl(CalculateTotalTimeFinal(obj.ALLOCATED_TIME)), 2)
                    End If
                Else
                    obj.TOTAL_TIME = txtTotalTime.Text
                End If
                If clsCommon.CompairString(obj.TICKET_TYPE, "Bug") = CompairStringResult.Equal Or (clsCommon.CompairString(obj.TICKET_TYPE, "Data Correction") = CompairStringResult.Equal AndAlso clsCommon.CompairString(obj.TICKET_TYPE, "Internal") = CompairStringResult.Equal) Then
                    obj.APPROVAL_STATUS = "NA"
                Else
                    obj.APPROVAL_STATUS = "Management Approval"
                End If
                ' -----------------------************************************************************------------------------------------

                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_REQUEST_ANALYSIS_MASTER where REQUEST_ANALYSIS_NO='" & obj.REQUEST_ANALYSIS_NO & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry)) Then

                    UcAttachment1.Form_ID = MyBase.Form_ID
                    UcAttachment1.SaveData(obj.REQUEST_ANALYSIS_NO)
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.REQUEST_ANALYSIS_NO)

                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Public Function CalculateTestingTime(ByVal strTotalTime As String) As String

        Dim totalTime As String = strTotalTime
        If clsCommon.myLen(totalTime) > 0 Then
            Dim strArr() As String
            strArr = totalTime.Split(".")
            Dim strConvertHourToMinute As Double = clsCommon.myCdbl(strArr(0)) * 60
            Dim finalMinute As Integer = 0
            If strArr.Count = 2 Then 'totalTime.Contains(".") = True And 
                finalMinute = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
            Else
                finalMinute = strConvertHourToMinute
            End If
            'Dim finalMinute As Double = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
            Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
            finalMinute = FormatNumber(CDbl(((clsCommon.myCdbl(finalMinute) * strTestingTime) / 100)), 2)
            'Dim strHours As Integer = finalMinute / 60
            'Dim strMinutes As Integer = finalMinute Mod 60
            'Dim strTotalFinaltime As String = clsCommon.myCstr(strHours) + "." + clsCommon.myCstr(strMinutes)


            Dim Duration = New TimeSpan(0, finalMinute, 0)
            Dim Day = Duration.Days * 24
            Dim Hours = Duration.Hours + Day
            Dim Minutes = Duration.Minutes
            Dim strTotalFinaltime As String = clsCommon.myCstr(Hours) + "." + clsCommon.myCstr(Minutes)

            Return strTotalFinaltime
        End If
        Return "0"
    End Function

    Public Function CalculateTotalTimeFinal(ByVal strTotalTime As String) As String

        Dim totalTime As String = strTotalTime
        If clsCommon.myLen(totalTime) > 0 Then
            Dim strArr() As String
            strArr = totalTime.Split(".")
            Dim strConvertHourToMinute As Double = clsCommon.myCdbl(strArr(0)) * 60
            Dim finalMinute As Integer = 0
            If strArr.Count = 2 Then 'totalTime.Contains(".") = True And 
                finalMinute = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
            Else
                finalMinute = strConvertHourToMinute
            End If
            'Dim finalMinute As Double = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))

            Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
            Dim strDebuggingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Debugging_Time from TSPL_TIME_MASTER"))
            Dim strAdditionalTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Additional_Time from TSPL_TIME_MASTER"))

            Dim final As Integer = FormatNumber(CDbl(((clsCommon.myCdbl(finalMinute) * strTestingTime) / 100)), 2)
            final = final + FormatNumber(CDbl(((clsCommon.myCdbl(finalMinute) * strDebuggingTime) / 100)), 2)
            final = final + FormatNumber(CDbl(((clsCommon.myCdbl(finalMinute) * strAdditionalTime) / 100)), 2)
            final = finalMinute + final
            'Dim strHours As Integer = final / 60
            'Dim strMinutes As Integer = final Mod 60
            'Dim strTotalFinaltime As String = clsCommon.myCstr(strHours) + "." + clsCommon.myCstr(strMinutes)

            Dim Duration = New TimeSpan(0, final, 0)
            Dim Day = Duration.Days * 24
            Dim Hours = Duration.Hours + Day
            Dim Minutes = Duration.Minutes
            Dim strTotalFinaltime As String = clsCommon.myCstr(Hours) + "." + clsCommon.myCstr(Minutes)

            Return strTotalFinaltime
        End If
        Return "0"
    End Function


    'Public Function CalculateTotalTime(ByVal TotalTime As String) As String

    '    If clsCommon.myLen(totalTime) > 0 Then
    '        Dim strArr() As String
    '        strArr = totalTime.Split(".")
    '        Dim strConvertHourToMinute As Double = clsCommon.myCdbl(strArr(0)) * 60
    '        Dim finalMinute As Double = 0.0
    '        If strArr.Count = 2 Then
    '            finalMinute = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
    '        Else
    '            finalMinute = strConvertHourToMinute
    '        End If

    '        Dim Duration = New TimeSpan(0, finalMinute, 0)
    '        Dim Day = Duration.Days * 24
    '        Dim Hours = Duration.Hours + Day
    '        Dim Minutes = Duration.Minutes
    '        Dim strTotalAmount As String = clsCommon.myCstr(Hours) + "." + clsCommon.myCstr(Minutes)

    '        Return strTotalAmount
    '    End If
    '    Return ""
    'End Function

    Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(txtRequestNo.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Request No can not be blank.")
                txtRequestNo.Focus()
                Return False
            End If
            If clsCommon.myLen(txtClient.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Client code can not be blank.")
                txtRequestNo.Focus()
                Return False
            End If

            If clsCommon.myLen(txtScreen.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Screen code can not be blank.")
                txtScreen.Focus()
                Return False
            End If

            If clsCommon.myLen(txtModule.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Module code can not be blank.")
                txtScreen.Focus()
                Return False
            End If

            If clsCommon.myLen(txtProject.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Project code can not be blank.")
                txtProject.Focus()
                Return False
            End If

            If clsCommon.myLen(cboTicketType.Text) <= 0 Or clsCommon.CompairString(cboTicketType.Text, "-Select-") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketType.Text, "Select") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please select ticket type.")
                cboTicketType.Focus()
                Return False
            End If

            If clsCommon.myLen(cboSeverity.Text) <= 0 Or clsCommon.CompairString(cboSeverity.Text, "Select") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please select Severity.")
                cboSeverity.Focus()
                Return False
            End If

            If clsCommon.myLen(cboPriority.Text) <= 0 Or clsCommon.CompairString(cboPriority.Text, "Select") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please select Priority.")
                cboPriority.Focus()
                Return False
            End If
            If clsCommon.myLen(txtRequestAnalysisDescription.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Request Analysis Description can not be blank.")
                RadPageView1.SelectedPage = RadPageViewPage2
                txtRequestAnalysisDescription.Focus()
                Return False
            End If
            If clsCommon.myLen(txtDeveloper.Value) > 0 Or clsCommon.myLen(txtTester.Value) > 0 Then
                If clsCommon.myLen(txtDeveloper.Value) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Developer can not be blank.")
                    txtDeveloper.Focus()
                    Return False
                End If
                If clsCommon.myLen(txtTester.Value) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Tester can not be blank.")
                    txtTester.Focus()
                    Return False
                End If

            End If

            If clsCommon.CompairString(cboTicketType.Text, "Bug") = CompairStringResult.Equal Or (clsCommon.CompairString(cboTicketType.Text, "Data Correction") = CompairStringResult.Equal AndAlso clsCommon.CompairString(cboDataErrorType.Text, "Internal") = CompairStringResult.Equal) Then
                'If clsCommon.myLen(txtDeveloper.Value) <= 0 Then
                '    common.clsCommon.MyMessageBoxShow("Developer can not be blank.")
                '    txtDeveloper.Focus()
                '    Return False
                'End If
                'If clsCommon.myLen(txtTester.Value) <= 0 Then
                '    common.clsCommon.MyMessageBoxShow("Tester can not be blank.")
                '    txtTester.Focus()
                '    Return False
                'End If
                If clsCommon.myLen(txtDeveloper.Value) > 0 AndAlso clsCommon.myLen(txtTester.Value) > 0 Then
                    If clsCommon.myLen(txtAllocatedTime.Text) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Allocated Time can not be blank.")
                        txtAllocatedTime.Focus()
                        Return False
                    End If

                    Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
                    If clsCommon.myLen(strTestingTime) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Please Enter Testing Time in Time Master.")
                        txtTestingTime.Focus()
                        Return False
                    End If
                End If
            Else
                If clsCommon.myLen(txtAllocatedTime.Text) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Allocated Time can not be blank.")
                    txtAllocatedTime.Focus()
                    Return False
                End If

            End If
            'If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Approval") = CompairStringResult.Equal Then
            '    If clsCommon.myLen(txtApprovedTime.Text) <= 0 Then
            '        common.clsCommon.MyMessageBoxShow("Approval Time can not be blank.")
            '        txtApprovedTime.Focus()
            '        Return False
            '    End If
            'End If
            UcAttachment1.AllowToSave()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function

    Private Sub AddNew()

        txtRequestAnalysisNo.Value = ""
        txtRequestAnalysisNo.Enabled = False
        txtRequestAnalysisDate.Text = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE, "dd/MM/yyyy")
        txtRequestAnalysisDate.ReadOnly = True
        txtClient.Value = ""
        lblClient.Text = ""
        txtScreen.Value = ""
        lblScreen.Text = ""
        txtModule.Value = ""
        lblModule.Text = ""
        txtProject.Value = ""
        lblProject.Text = ""
        cboAnalysisStatus.Text = ""
        txtDeveloper.Value = ""
        lblDeveloper.Text = ""
        txtTester.Value = ""
        lblTester.Text = ""
        cboTicketType.Text = "Select"
        cboDataErrorType.Text = ""
        cboSeverity.Text = "Select"
        cboPriority.Text = "Select"
        txtRequestAnalysisDescription.Text = ""
        txtAllocatedTime.Text = ""
        txtTestingTime.Text = ""
        txtTestingTime.Enabled = False
        txtRequestNo.Value = ""
        lblRequestDate.Text = ""
        txtCreatedBy.Enabled = False
        txtCreatedBy.Value = ""
        lblCreatedBy.Text = ""
        txtRequestDescription.Text = ""
        txtApprovedTime.Text = ""
        txtTotalTime.Text = ""
        txtTotalTime.Enabled = False
        txtRequestDescription.ReadOnly = True
        cboAnalysisStatus.Text = "Open"
        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
            cboAnalysisStatus.Enabled = True
            LoadAnalysisStatus()
            lblApprovalStatus.Visible = True
            lblApprovalStatusName.Visible = True
        Else
            cboAnalysisStatus.Enabled = False
            lblApprovalStatus.Visible = False
            lblApprovalStatusName.Visible = False
        End If

        btnSave.Text = "Save"
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnreset1.Visible = False
        txtRequestAnalysisNo.Focus()
        UcAttachment1.BlankAllControls()
        UcAttachment1.isDeleteTheAttachment = False

        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub

    Sub LoadData(ByVal strRequestAnalysisNo As String)
        Try
            AddNew()
            isInsideLoadData = True
            Dim obj As clsRequestAnalysisEnry = clsRequestAnalysisEnry.GetData(strRequestAnalysisNo, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then

                txtRequestAnalysisNo.Value = obj.REQUEST_ANALYSIS_NO
                If clsCommon.myLen(obj.REQUEST_ANALYSIS_DATE) > 0 Then
                    txtRequestAnalysisDate.Text = obj.REQUEST_ANALYSIS_DATE
                End If
                txtRequestNo.Value = obj.REQUEST_NO
                lblRequestDate.Text = obj.REQUEST_DATE
                txtClient.Value = obj.CLIENT_CODE
                lblClient.Text = obj.CLIENT_NAME
                txtScreen.Value = obj.SCREEN_CODE
                lblScreen.Text = obj.SCREEN_NAME
                txtModule.Value = obj.MODULE_CODE
                lblModule.Text = obj.MODULE_NAME
                txtProject.Value = obj.PROJECT_CODE
                lblProject.Text = obj.PROJECT_NAME
                cboTicketType.Text = obj.TICKET_TYPE
                cboDataErrorType.Text = obj.DATA_ERROR_TYPE
                cboSeverity.Text = obj.SEVERITY
                cboPriority.Text = obj.PRIORITY
                txtRequestNo.Text = obj.REQUEST_NO
                If clsCommon.myLen(obj.REQUEST_DATE) > 0 Then
                    lblRequestDate.Text = obj.REQUEST_DATE
                End If
                txtCreatedBy.Value = obj.Created_By
                lblCreatedBy.Text = obj.Created_By_Name
                txtDeveloper.Value = obj.DEVELOPER_CODE
                lblDeveloper.Text = obj.DEVELOPER_NAME
                txtTester.Value = obj.TESTER_CODE
                lblTester.Text = obj.TESTER_NAME
                cboAnalysisStatus.Text = obj.ANALYSIS_STATUS
                txtRequestAnalysisDescription.Text = obj.ANALYSIS_DESCRIPTION
                txtRequestDescription.Text = obj.REQUEST_DESCRIPTION
                txtAllocatedTime.Text = obj.ALLOCATED_TIME
                txtTotalTime.Text = obj.TOTAL_TIME
                txtTestingTime.Text = obj.TESTING_TIME
                lblTicketNo.Text = obj.TICKET_NO
                lblApprovalStatus.Text = obj.APPROVAL_STATUS
                txtAnalysisBy.Value = obj.Analysis_By
                lblAnalysedBy.Text = obj.Analysis_By_Name
                isInsideLoadData = False
                txtRequestAnalysisNo.MyReadOnly = True
                SaveUpdateButtonStatus()

                UcAttachment1.Form_ID = MyBase.Form_ID
                UcAttachment1.LoadData(txtRequestAnalysisNo.Value)
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub
    Public Sub SaveUpdateButtonStatus()
        btnDelete.Enabled = False
        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Request Analysis") = CompairStringResult.Equal Then
            If clsCommon.CompairString(cboAnalysisStatus.Text, "Open") = CompairStringResult.Equal Then
                btnSave.Text = "Save"
                btnSave.Enabled = True
                btnDelete.Enabled = True
            ElseIf clsCommon.CompairString(cboAnalysisStatus.Text, "Analysed") = CompairStringResult.Equal AndAlso clsCommon.CompairString(lblApprovalStatus.Text, "Management Approval") = CompairStringResult.Equal Then
                btnSave.Text = "Update"
                btnSave.Enabled = True
                btnDelete.Enabled = False
            Else
                btnSave.Text = "Update"
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        CType(Me.Owner, FrmRequestAnalysis).LoadData()
        CType(Me.Owner, FrmRequestAnalysis).LoadDataOpenRequest()
    End Sub

    Private Sub txtRequestNo__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtRequestNo._MYValidating
        'Try
        '    Dim qry As String = "select REQUEST_NO as [REQUEST NO] ,convert(varchar, REQUEST_DATE,103) as [REQUEST DATE] , REQUEST_DESCRIPTION  as [REQUEST DESCRIPTION], CLIENT_CODE as [CLIENT CODE] ,REQUEST_DESCRIPTION as [REQUEST DESCRIPTION] from TSPL_REQUEST_CREATION_MASTER "
        '    Dim WhrCls As String = " TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS = 'Open' "
        '    txtRequestNo.Value = clsCommon.ShowSelectForm("TSPL_REQUEST_CREATION_MASTER@CODE", qry, "REQUEST NO", WhrCls, txtClient.Value, "TSPL_REQUEST_CREATION_MASTER.REQUEST_NO", isButtonClicked)
        '    txtRequestDescription.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select REQUEST_DESCRIPTION from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" + txtRequestNo.Value + "'"))
        '    lblRequestDate.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select convert (varchar, convert (date, REQUEST_DATE,103),103) from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" + txtRequestNo.Value + "'"))
        '    txtClient.Value = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select ClIENT_CODE from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" + txtRequestNo.Value + "'"))
        '    lblClient.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE='" + txtClient.Value + "'"))
        'Catch ex As Exception
        '    common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        'End Try

    End Sub

    Public Sub RequestDetailsFill(ByVal strRequestNo As String)
        Try
            Dim checkOpenRequest As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Count(*) from TSPL_REQUEST_CREATION_MASTER where TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS in ('Open','Pending') and REQUEST_NO = '" + strRequestNo + "' "))
            If checkOpenRequest > 0 Then
                txtRequestNo.Value = strRequestNo
                txtRequestDescription.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select REQUEST_DESCRIPTION from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" + txtRequestNo.Value + "'"))
                lblRequestDate.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select convert (varchar, convert (date, REQUEST_DATE,103),103) from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" + txtRequestNo.Value + "'"))
                txtClient.Value = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select ClIENT_CODE from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" + txtRequestNo.Value + "'"))
                lblClient.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE='" + txtClient.Value + "'"))
                UcAttachment1.Form_ID = "REQST_CRT"
                UcAttachment1.LoadData(txtRequestNo.Value)
            Else
                common.clsCommon.MyMessageBoxShow("Request No Already Accepted.Please Refresh screen.", Me.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtScreen__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtScreen._MYValidating
        Try
            Dim qry As String = " select TSPL_SCREEN_MASTER.SCREEN_CODE as [SCREEN CODE] , TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION as [SCREEN DESCRIPTION],TSPL_SCREEN_MASTER.TYPE as [TYPE],TSPL_SCREEN_MASTER.MODULE_CODE as [MODULE CODE],TSPL_MODULE_MASTER.MODULE_DESCRIPTION as [MODULE DESCRIPTION],TSPL_MODULE_DETAIL.PROJECT_CODE as [PROJECT CODE],TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION as [PROJECT DESCRIPTION],TSPL_SCREEN_MASTER.SCREEN_CODE +','+TSPL_SCREEN_MASTER.MODULE_CODE + +',' +TSPL_MODULE_DETAIL.PROJECT_CODE + ','+TSPL_SCREEN_MASTER.TYPE as [All DETAILS]  from TSPL_SCREEN_MASTER  " & _
                           " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE =TSPL_SCREEN_MASTER.MODULE_CODE " & _
                           " left outer join TSPL_MODULE_DETAIL on TSPL_MODULE_DETAIL.MODULE_CODE =TSPL_SCREEN_MASTER.MODULE_CODE " & _
                           " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_MODULE_DETAIL.PROJECT_CODE "
            ' txtScreen.Value = clsCommon.ShowSelectForm("TBL@SCREEN_CODE", qry, "SCREEN CODE", "", txtScreen.Value, "TSPL_SCREEN_MASTER.SCREEN_CODE", isButtonClicked)
            Dim strAllDetails = clsCommon.ShowSelectForm("TBL@SCREEN_CODE", qry, "All DETAILS", "", txtScreen.Value, "TSPL_SCREEN_MASTER.SCREEN_CODE", isButtonClicked)
            Dim strArr() As String
            strArr = strAllDetails.Split(",")
            txtScreen.Value = strArr(0)
            lblScreen.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SCREEN_DESCRIPTION from  TSPL_SCREEN_MASTER where SCREEN_CODE = '" + txtScreen.Value + "'"))
            txtModule.Value = strArr(1)
            lblModule.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select MODULE_DESCRIPTION from TSPL_MODULE_MASTER where MODULE_CODE='" + txtModule.Value + "'"))
            txtProject.Value = strArr(2)
            lblProject.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select PROJECT_DESCRIPTION from TSPL_PROJECT_MASTER where PROJECT_CODE='" + txtProject.Value + "'"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub txtRequestAnalysisNo__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtRequestAnalysisNo._MYNavigator
        Dim WhrCls As String = ""

        Dim qry As String = "select REQUEST_ANALYSIS_NO  from TSPL_REQUEST_ANALYSIS_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO=(select MIN(REQUEST_ANALYSIS_NO) from TSPL_REQUEST_ANALYSIS_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO=(select MAX(REQUEST_ANALYSIS_NO) from TSPL_REQUEST_ANALYSIS_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO=(select Min(REQUEST_ANALYSIS_NO) from TSPL_REQUEST_ANALYSIS_MASTER where REQUEST_ANALYSIS_NO > '" + txtRequestAnalysisNo.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO=(select Max(REQUEST_ANALYSIS_NO) from TSPL_REQUEST_ANALYSIS_MASTER where REQUEST_ANALYSIS_NO < '" + txtRequestAnalysisNo.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO='" + txtRequestAnalysisNo.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtRequestAnalysisNo.Value = clsCommon.myCstr(dt.Rows(0)("REQUEST_ANALYSIS_NO"))
        End If
        LoadData(txtRequestAnalysisNo.Value)
    End Sub

    Private Sub txtRequestAnalysisNo__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtRequestAnalysisNo._MYValidating
        'Dim str As String = "select count(*) from TSPL_TICKET_MASTER where TICKET_NO = '" + txtTicketNo.Value + "' "
        'Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        'If no = 0 AndAlso isButtonClicked = False Then
        '    txtTicketNo.MyReadOnly = False
        'Else
        '    txtTicketNo.MyReadOnly = True
        'End If

        'If txtTicketNo.MyReadOnly OrElse isButtonClicked Then
        '    Dim qry As String = " select TSPL_TICKET_MASTER.TICKET_NO as [TICKET NO],convert(varchar, TSPL_TICKET_MASTER.TICKET_DATE,103) as [TICKET DATE],TSPL_TICKET_MASTER.CLIENT_CODE as [CLIENT CODE],TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION as [Client Name],TSPL_TICKET_MASTER.SCREEN_CODE as [SCREEN CODE],TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION as [Screen Name], TSPL_TICKET_MASTER.MODULE_CODE as [MODULE CODE],TSPL_MODULE_MASTER.MODULE_DESCRIPTION as [MODULE NAME],TSPL_TICKET_MASTER .PROJECT_CODE as [PROJECT CODE] ,TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION as [PROJECT NAME],TSPL_TICKET_MASTER.TICKET_STATUS as [TICKET STATUS] ,TSPL_TICKET_MASTER.DEVELOPER_CODE as [DEVELOPER CODE],TBL_USER_MASTER_Developer.USER_NAME as [DEVELOPER NAME],TSPL_TICKET_MASTER.TESTER_CODE as [TESTER CODE],TBL_USER_MASTER_Tester.USER_NAME as [TESTER NAME],TSPL_TICKET_MASTER.Created_By as [CREATED BY CODE],TBL_USER_MASTER_Created_By.USER_NAME as [CREATED BY NAME], TSPL_TICKET_MASTER.TICKET_TYPE as [TICKET TYPE],TSPL_TICKET_MASTER.DATA_ERROR_TYPE as [DATA ERROR TYPE], TSPL_TICKET_MASTER.SEVERITY , TSPL_TICKET_MASTER.PRIORITY as [PRIORITY],TSPL_TICKET_MASTER.TICKET_DESCRIPTION as [TICKET DESCRIPTION],TSPL_TICKET_MASTER.ALLOCATION_REMARKS as [ALLOCATION REMARKS], case when TSPL_TICKET_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_TICKET_MASTER.ALLOCATED_TIME,103)  end as [ALLOCATED TIME] ,TSPL_TICKET_MASTER.DEVELOPER_REMARKS as [DEVELOPER REMARKS],TSPL_TICKET_MASTER.DEVELOPMENT_TIME as [DEVELOPMENT TIME] ,TSPL_TICKET_MASTER.TESTER_REMARKS as [TESTER REMARKS],TSPL_TICKET_MASTER.TESTING_TIME as [TESTING TIME],TSPL_TICKET_MASTER.REQUEST_NO as [REQUEST NO], case when TSPL_TICKET_MASTER.REQUEST_DATE is null then '' else  convert (varchar,TSPL_TICKET_MASTER.REQUEST_DATE,103) end as [REQUEST DATE],TSPL_TICKET_MASTER.ANALYSIS_NO as [ANALYSIS NO],case when TSPL_TICKET_MASTER.ANALYSIS_DATE is null then '' else   convert (varchar, TSPL_TICKET_MASTER.ANALYSIS_DATE,103) end as  [ANALYSIS DATE]  from TSPL_TICKET_MASTER " & _
        '                   " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_TICKET_MASTER.CLIENT_CODE " & _
        '                   " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_TICKET_MASTER.SCREEN_CODE " & _
        '                   " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_TICKET_MASTER.MODULE_CODE " & _
        '                   " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_TICKET_MASTER.PROJECT_CODE " & _
        '                   " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE " & _
        '                   " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE " & _
        '                   " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE "
        '    txtTicketNo.Value = clsCommon.ShowSelectForm("TSPL_USER_MASTER", qry, "TICKET NO", "", txtTicketNo.Value, "TSPL_TICKET_MASTER.TICKET_NO", isButtonClicked)
        '    If clsCommon.myLen(txtTicketNo.Value) > 0 Then
        '        LoadData(txtTicketNo.Value)
        '    Else
        '        AddNew()
        '    End If
        'End If
    End Sub

    Private Sub txtDeveloper__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtDeveloper._MYValidating
        Dim qry As String = "select USER_CODE as Code,USER_NAME as Name ,TYPE,CLIENT_CODE,USER_GROUP_CODE,EMAIL,PHONE  from TSPL_USER_MASTER "
        Dim WhrCls As String = " USER_TYPE ='Developer' "
        txtDeveloper.Value = clsCommon.ShowSelectForm("CLIENT@CODE", qry, "Code", WhrCls, txtDeveloper.Value, "Code", isButtonClicked)
        lblDeveloper.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select USER_NAME from TSPL_USER_MASTER where USER_CODE='" + txtDeveloper.Value + "'"))
    End Sub

    Private Sub txtTester__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtTester._MYValidating
        Dim qry As String = "select USER_CODE as Code,USER_NAME as Name ,TYPE,CLIENT_CODE,USER_GROUP_CODE,EMAIL,PHONE  from TSPL_USER_MASTER  "
        Dim WhrCls As String = " USER_TYPE in ('Tester','Implementation') "
        txtTester.Value = clsCommon.ShowSelectForm("CLIENT@CODE", qry, "Code", WhrCls, txtTester.Value, "Code", isButtonClicked)
        lblTester.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select USER_NAME from TSPL_USER_MASTER where USER_CODE='" + txtTester.Value + "'"))
    End Sub

   
    
End Class
