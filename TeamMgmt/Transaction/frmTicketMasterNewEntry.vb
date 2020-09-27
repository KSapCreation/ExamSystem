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

Public Class FrmTicketMasterNewEntry
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False
    Private strCureentScreenOpenByDilog As String = ""

    Public Sub SaveUpdateButtonStatus()
        btnDelete.Enabled = False
        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Master") = CompairStringResult.Equal Then
            If clsCommon.CompairString(cboTicketStatus.Text, "Open") = CompairStringResult.Equal Then
                btnSave.Text = "Save"
                btnSave.Enabled = True
                If clsCommon.myLen(lblRequestNo.Text) > 0 Then
                    btnDelete.Enabled = False
                Else
                    btnDelete.Enabled = True
                End If
                
                'ElseIf clsCommon.CompairString(cboTicketStatus.Text, "Closed") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Allocated") = CompairStringResult.Equal Then
                '    btnSave.Text = "Update"
                '    btnSave.Enabled = False
            Else
                btnSave.Text = "Update"
                btnSave.Enabled = False
            End If
        ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
            If clsCommon.CompairString(cboTicketStatus.Text, "Open") = CompairStringResult.Equal Then
                btnSave.Text = "Save"
                btnSave.Enabled = True
            ElseIf clsCommon.CompairString(cboTicketStatus.Text, "On Hold") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Cancel") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Allocated") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Pending") = CompairStringResult.Equal Then
                btnSave.Text = "Update"
                btnSave.Enabled = True
            Else
                btnSave.Text = "Update"
                btnSave.Enabled = False
            End If
        ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Time Sheet") = CompairStringResult.Equal Then
            If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                If clsCommon.CompairString(cboTicketStatus.Text, "Allocated") = CompairStringResult.Equal Then
                    cboTicketStatus.Text = "-Select-"
                    btnSave.Text = "Save"
                    btnSave.Enabled = True
                ElseIf clsCommon.CompairString(cboTicketStatus.Text, "Pending") = CompairStringResult.Equal Then
                    cboTicketStatus.Text = "-Select-"
                    btnSave.Text = "Update"
                    btnSave.Enabled = True
                ElseIf clsCommon.CompairString(cboTicketStatus.Text, "WIP") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Pending") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Fixed") = CompairStringResult.Equal Then
                    cboTicketStatus.Text = "-Select-"
                    btnSave.Text = "Update"
                    btnSave.Enabled = True
                Else

                    btnSave.Text = "Update"
                    btnSave.Enabled = False
                End If
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Or clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
                If clsCommon.CompairString(cboTicketStatus.Text, "Fixed") = CompairStringResult.Equal Then
                    cboTicketStatus.Text = "-Select-"
                    btnSave.Text = "Save"
                    btnSave.Enabled = True
                ElseIf clsCommon.CompairString(cboTicketStatus.Text, "Pending") = CompairStringResult.Equal Then
                    cboTicketStatus.Text = "-Select-"
                    btnSave.Text = "Update"
                    btnSave.Enabled = True
                Else

                    btnSave.Text = "Update"
                    btnSave.Enabled = False
                End If
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then
                'sdff
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
                If clsCommon.CompairString(cboTicketStatus.Text, "Closed") = CompairStringResult.Equal Then
                    cboTicketStatus.Text = "-Select-"
                    cboTicketStatus.Text = "Approved"
                    btnSave.Text = "Save"
                    btnSave.Enabled = True
                Else
                    btnSave.Text = "Update"
                    btnSave.Enabled = False
                End If

            End If

        End If
    End Sub
    Private Sub FrmTicketMasterNewEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UcAttachment1.Form_ID = "TICKET_MST"
        strCureentScreenOpenByDilog = CType(Me.Owner, FrmTicketMaster).Text

        LoadTicketType()
        ' LoadTicketType()
        LoadSeverity()
        LoadPriority()
        LoadTicketStatus()
        AddNew()

        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
            'cboTicketStatus.Enabled = False
            'cboTicketStatus.Text = "Allocated"
            MyBase.SetUserMgmt(clsUserMgtCode.FrmTicketAllocation)
            txtClient.Enabled = True
            txtScreen.Enabled = True
            txtProject.Enabled = True
            txtDeveloper.Enabled = True
            txtTester.Enabled = True
            cboDataErrorType.Enabled = True
            cboPriority.Enabled = True
            cboSeverity.Enabled = True
            txtModule.Enabled = True
            cboTicketType.Enabled = True
            txtTicketNo.MyReadOnly = False

            cboTicketStatus.Enabled = True
            txtDevelopmentTime.Enabled = False
            txtTestingTime.Enabled = False
            txtAllocatedTime.Enabled = True
            txtDeveloper.Enabled = True
            txtTester.Enabled = True
            txtAllocationRemarks.ReadOnly = False
            txtTicketDescription.ReadOnly = True
            txtTesterPreviousRemarks.ReadOnly = True
            txtTesterYourRemarks.ReadOnly = True
            txtDeveloperRreviousRemarks.ReadOnly = True
            txtDeveloperYourRemarks.ReadOnly = True
            txtTicketNo.Enabled = False
            btnDelete.Visible = False
            btnreset1.Visible = False
            txtDevelopmentExeVersion.ReadOnly = True
            txtTestingExeVersion.ReadOnly = True
            txtActualTestedTime.ReadOnly = True
            Me.Text = "For Ticket Allocation"

        ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Master") = CompairStringResult.Equal Then
            MyBase.SetUserMgmt(clsUserMgtCode.FrmTicketMaster)
            cboTicketStatus.Enabled = False
            cboTicketStatus.Text = "Open"

            txtClient.Enabled = True
            txtScreen.Enabled = True
            txtProject.Enabled = True
            txtDeveloper.Enabled = True
            txtTester.Enabled = True
            cboDataErrorType.Enabled = True
            cboPriority.Enabled = True
            cboSeverity.Enabled = True
            txtModule.Enabled = True
            cboTicketType.Enabled = True
            txtTicketNo.MyReadOnly = True

            txtDevelopmentTime.Enabled = False
            txtTestingTime.Enabled = False
            txtAllocatedTime.Enabled = False
            txtDeveloper.Enabled = False
            txtTester.Enabled = False
            txtAllocationRemarks.ReadOnly = True
            txtTicketDescription.ReadOnly = False
            txtTesterPreviousRemarks.ReadOnly = True
            txtTesterYourRemarks.ReadOnly = True
            txtDeveloperRreviousRemarks.ReadOnly = True
            txtDeveloperYourRemarks.ReadOnly = True
            txtDevelopmentExeVersion.ReadOnly = True
            txtTestingExeVersion.ReadOnly = True
            txtActualTestedTime.ReadOnly = True
            btnDelete.Visible = True
            btnreset1.Visible = True
            Me.Text = "For Ticket Master"
        ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Time Sheet") = CompairStringResult.Equal Then
            MyBase.SetUserMgmt(clsUserMgtCode.frmTimeSheet)
            cboTicketStatus.Enabled = True
            txtClient.Enabled = False
            txtScreen.Enabled = False
            txtProject.Enabled = False
            txtDeveloper.Enabled = False
            txtTester.Enabled = False
            cboDataErrorType.Enabled = False
            cboPriority.Enabled = False
            cboSeverity.Enabled = False
            txtModule.Enabled = False
            cboTicketType.Enabled = False
            txtTicketNo.MyReadOnly = True

            txtDevelopmentTime.Enabled = False
            txtTestingTime.Enabled = False
            txtAllocatedTime.Enabled = False
            txtDeveloper.Enabled = False
            txtTester.Enabled = False
            txtAllocationRemarks.ReadOnly = True
            txtTicketDescription.ReadOnly = True
            txtTesterPreviousRemarks.ReadOnly = True
            txtTesterYourRemarks.ReadOnly = True
            txtDeveloperRreviousRemarks.ReadOnly = True
            txtDeveloperYourRemarks.ReadOnly = True
            txtDevelopmentExeVersion.ReadOnly = True
            txtTestingExeVersion.ReadOnly = True
            txtActualTestedTime.ReadOnly = True
            btnDelete.Visible = False
            btnreset1.Visible = False
            txtTicketNo.Enabled = False

            Me.Text = "For Time Sheet"
            If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                txtDevelopmentTime.Enabled = True
                txtDeveloperYourRemarks.ReadOnly = False
                txtDevelopmentExeVersion.ReadOnly = False
                lblTotalDevelopmentTime.Visible = True
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Or clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
                txtTesterYourRemarks.ReadOnly = False
                txtTestingExeVersion.ReadOnly = False
                txtActualTestedTime.ReadOnly = False
                lblTotalTestingTime.Enabled = True
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then
                'sdff
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
                'jghg
            End If

        End If

        If CType(Me.Owner, FrmTicketMaster).isNewEntry = False Then
            If CType(Me.Owner, FrmTicketMaster).gv.Rows.Count > 0 Then
                If clsCommon.myLen(clsCommon.myCstr(CType(Me.Owner, FrmTicketMaster).gv.CurrentRow.Cells("TICKET_NO").Value)) > 0 Then
                    LoadData(CType(Me.Owner, FrmTicketMaster).gv.CurrentRow.Cells("TICKET_NO").Value)
                End If
            End If
        End If
        

    End Sub

    Private Sub AddNew()
        txtTicketNo.Value = ""
        txtTicketNo.MyReadOnly = False
        txtTicketDate.Text = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE, "dd/MM/yyyy")
        txtTicketDate.ReadOnly = True
        txtClient.Value = ""
        lblClient.Text = ""
        txtScreen.Value = ""
        lblScreen.Text = ""
        txtModule.Value = ""
        lblModule.Text = ""
        txtProject.Value = ""
        lblProject.Text = ""
        cboTicketStatus.Text = "Open"
        txtDeveloper.Value = ""
        lblDeveloper.Text = ""
        txtTester.Value = ""
        lblTester.Text = ""
        cboTicketType.Text = "Select"
        cboDataErrorType.Text = ""
        cboSeverity.Text = "Select"
        cboPriority.Text = "Select"
        txtTicketDescription.Text = ""
        txtAllocationRemarks.Text = ""
        txtAllocatedTime.Text = ""
        txtTestingTime.Text = ""
        txtDevelopmentTime.Text = ""
        txtDeveloperRreviousRemarks.Text = ""
        txtTesterPreviousRemarks.Text = ""
        lblRequestNo.Text = ""
        lblRequestDate.Text = ""
        lblAnalysisNo.Text = ""
        lblAnalysisDate.Text = ""
        txtCreatedBy.Enabled = False
        'txtDeveloper.MyReadOnly = True
        'txtTester.MyReadOnly = True
        txtCreatedBy.Value = ""
        lblCreatedBy.Text = ""
        txtDeveloperYourRemarks.Text = ""
        txtTesterYourRemarks.Text = ""
        txtTestingExeVersion.Text = ""
        'txtTestingExeVersion.ReadOnly = True
        txtDevelopmentExeVersion.Text = ""
        'txtDevelopmentExeVersion.ReadOnly = True
        txtActualTestedTime.Text = ""
        lblTotalDevelopmentTime.Text = ""
        lblTotalTestingTime.Text = ""
        lblTotalDevelopmentTime.Visible = False
        lblTotalTestingTime.Visible = False
        ' txtActualTestedTime.ReadOnly = True
        'txtModule.MyReadOnly = True
        'txtProject.MyReadOnly = True
        'txtAllocationRemarks.ReadOnly = True
        'txtDeveloperRemarks.ReadOnly = True
        'txtTesterRemarks.ReadOnly = True

        UcAttachment1.BlankAllControls()
        UcAttachment1.isDeleteTheAttachment = False

        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtTicketNo.Focus()

        RadPageView1.SelectedPage = RadPageViewPage1
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
        cboTicketStatus.DataSource = clsTicketMasterEntry.LoadTicketStatus()
        cboTicketStatus.ValueMember = "Code"
        cboTicketStatus.DisplayMember = "Name"
    End Sub

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
                Dim obj As New clsTicketMasterEntry()
                obj.TICKET_NO = txtTicketNo.Value
                obj.CLIENT_CODE = txtClient.Value
                obj.SCREEN_CODE = txtScreen.Value
                obj.MODULE_CODE = txtModule.Value
                obj.PROJECT_CODE = txtProject.Value

                If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal AndAlso clsCommon.CompairString(cboTicketStatus.Text, "Open") = CompairStringResult.Equal Then
                    obj.TICKET_STATUS = "Allocated"
                    'obj.TICKET_STATUS = cboTicketStatus.Text
                ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Master") = CompairStringResult.Equal Then
                    obj.TICKET_STATUS = "Open"
                Else
                    obj.TICKET_STATUS = cboTicketStatus.Text
                End If
                obj.TICKET_TYPE = cboTicketType.Text
                obj.DATA_ERROR_TYPE = cboDataErrorType.Text
                obj.SEVERITY = cboSeverity.Text
                obj.PRIORITY = cboPriority.Text
                obj.TICKET_DESCRIPTION = txtTicketDescription.Text
                If clsCommon.myLen(txtDeveloperYourRemarks.Text) > 0 Then
                    obj.DEVELOPER_REMARKS = txtDeveloperRreviousRemarks.Text + "  " + objCommonVar.CurrentUser + " Remarks : " + txtDeveloperYourRemarks.Text + "   "
                Else
                    obj.DEVELOPER_REMARKS = txtDeveloperRreviousRemarks.Text
                End If
                If clsCommon.myLen(txtTesterYourRemarks.Text) > 0 Then
                    obj.TESTER_REMARKS = txtTesterPreviousRemarks.Text + "  " + objCommonVar.CurrentUser + " Remarks : " + txtTesterYourRemarks.Text + "   "
                Else
                    obj.TESTER_REMARKS = txtTesterPreviousRemarks.Text
                End If
                obj.DEVELOPER_YOUR_REMARKS = txtDeveloperYourRemarks.Text
                obj.TESTER_YOUR_REMARKS = txtTesterYourRemarks.Text
                'obj.DEVELOPMENT_TIME = obj.DEVELOPMENT_TIME
                'obj.TESTER_REMARKS = obj.TESTER_REMARKS
                'obj.TESTING_TIME = obj.TESTING_TIME
                If clsCommon.myLen(lblRequestNo.Text) > 0 Then
                    obj.REQUEST_NO = lblRequestNo.Text
                End If
                If clsCommon.myLen(lblRequestDate.Text) > 0 Then
                    obj.REQUEST_DATE = lblRequestDate.Text
                End If
                If clsCommon.myLen(lblAnalysisNo.Text) > 0 Then
                    obj.ANALYSIS_NO = lblAnalysisNo.Text
                End If
                If clsCommon.myLen(lblAnalysisDate.Text) > 0 Then
                    obj.ANALYSIS_DATE = lblAnalysisDate.Text
                End If

                obj.DEVELOPMENT_TIME = txtDevelopmentTime.Text
                obj.ALLOCATED_TIME = txtAllocatedTime.Text
                If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
                    Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
                    If clsCommon.myLen(strTestingTime) > 0 Then
                        ' obj.TESTING_TIME = FormatNumber(CDbl(((clsCommon.myCdbl(obj.ALLOCATED_TIME) * strTestingTime) / 100)), 2)
                        obj.TESTING_TIME = FormatNumber(CDbl(CalculateTestingTime(obj.ALLOCATED_TIME)), 2)

                    End If
                Else
                    obj.TESTING_TIME = txtTestingTime.Text
                End If


                obj.DEVELOPER_CODE = txtDeveloper.Value
                obj.TESTER_CODE = txtTester.Value
                obj.ALLOCATION_REMARKS = txtAllocationRemarks.Text
                obj.Form_Title_Name = strCureentScreenOpenByDilog
                obj.DEVELOPMENT_EXE_VERSION = txtDevelopmentExeVersion.Text
                obj.TESTING_EXE_VERSION = txtTestingExeVersion.Text
                obj.ACTUAL_TESTING_TIME = txtActualTestedTime.Text
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_TICKET_MASTER where TICKET_NO='" & obj.TICKET_NO & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry)) Then

                    UcAttachment1.Form_ID = "TICKET_MST"
                    If clsCommon.myLen(lblAnalysisNo.Text) > 0 Then
                        UcAttachment1.SaveData(obj.ANALYSIS_NO)
                    Else
                        UcAttachment1.SaveData(obj.TICKET_NO)
                    End If
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.TICKET_NO)
                    'btnSave.Text = "Update"
                    'If cboTicketStatus.Text = "Allocated" Then
                    '    btnSave.Enabled = False
                    'Else
                    '    btnSave.Enabled = True
                    'End If
                    'btnDelete.Enabled = True
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

    Function AllowToSave() As Boolean
        Try
            If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal AndAlso (clsCommon.CompairString(cboTicketStatus.Text, "On Hold") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketStatus.Text, "Cancel") = CompairStringResult.Equal) Then
                Return True
            End If
            'If clsCommon.myLen(txtTicketNo.Value) <= 0 Then
            '    common.clsCommon.MyMessageBoxShow("Ticket No can not be blank.")
            '    txtTicketNo.Focus()
            '    Return False
            'End If
            If clsCommon.myLen(txtClient.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Client code can not be blank.")
                txtClient.Focus()
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

            If clsCommon.myLen(cboTicketType.Text) <= 0 Or clsCommon.CompairString(cboTicketType.Text, "Select") = CompairStringResult.Equal Or clsCommon.CompairString(cboTicketType.Text, "-Select-") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please select ticket type.")
                txtProject.Focus()
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
            If clsCommon.myLen(txtTicketDescription.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Ticket Details can not be blank.")
                RadPageView1.SelectedPage = RadPageViewPage2
                txtTicketDescription.Focus()
                Return False
            End If
            If clsCommon.myLen(cboTicketStatus.Text) <= 0 Or clsCommon.CompairString(cboTicketStatus.Text, "-Select-") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please Select Ticket Status.")
                cboPriority.Focus()
                Return False
            End If
            If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
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
                If clsCommon.myLen(txtAllocatedTime.Text) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Allocated Time can not be blank.")
                    txtAllocatedTime.Focus()
                    Return False
                End If
                'If clsCommon.myLen(txtDevelopmentTime.Text) <= 0 Then
                '    common.clsCommon.MyMessageBoxShow("Development Time can not be blank.")
                '    txtDevelopmentTime.Focus()
                '    Return False
                'End If
                Dim strTestingTime As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select Tester_Time from TSPL_TIME_MASTER"))
                If clsCommon.myLen(strTestingTime) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Please Enter Testing Time in Time Master.")
                    txtTestingTime.Focus()
                    Return False
                End If
                'If clsCommon.myLen(txtTestingTime.Text) <= 0 Then
                '    common.clsCommon.MyMessageBoxShow("Testing Time can not be blank.")
                '    txtTestingTime.Focus()
                '    Return False
                'End If
                If clsCommon.myLen(txtAllocationRemarks.Text) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Allocation Remarks can not be blank.")
                    RadPageView1.SelectedPage = RadPageViewPage2
                    txtAllocationRemarks.Focus()
                    Return False
                End If
                'If clsCommon.myLen(cboTicketStatus.Text) <= 0 Or clsCommon.CompairString(cboTicketStatus.Text, "Allocated") <> CompairStringResult.Equal Then
                '    common.clsCommon.MyMessageBoxShow("Please select Ticket status 'Allocated' .")
                '    txtAllocationRemarks.Focus()
                '    Return False
                'End If
            ElseIf clsCommon.CompairString(strCureentScreenOpenByDilog, "Time Sheet") = CompairStringResult.Equal Then
                If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                    If clsCommon.myLen(txtDevelopmentTime.Text) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Development Time can not be blank.")
                        RadPageView1.SelectedPage = RadPageViewPage1
                        txtDevelopmentTime.Focus()
                        Return False
                    End If
                    If clsCommon.myLen(txtDeveloperYourRemarks.Text) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Development Your Remarks can not be blank.")
                        RadPageView1.SelectedPage = RadPageViewPage4
                        txtDeveloperYourRemarks.Focus()
                        Return False
                    End If
                    If clsCommon.CompairString(cboTicketStatus.Text, "Fixed") = CompairStringResult.Equal Then
                        If clsCommon.myLen(txtDevelopmentExeVersion.Text) <= 0 Then
                            common.clsCommon.MyMessageBoxShow("Development Exe Verstion  can not be blank.")
                            RadPageView1.SelectedPage = RadPageViewPage1
                            txtDevelopmentExeVersion.Focus()
                            Return False
                        End If
                    End If
                    

                ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Or clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
                    If clsCommon.myLen(txtTesterYourRemarks.Text) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Testing Your Remarks can not be blank.")
                        RadPageView1.SelectedPage = RadPageViewPage5
                        txtTesterYourRemarks.Focus()
                        Return False
                    End If
                    If clsCommon.myLen(txtTestingExeVersion.Text) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Tested Exe Version can not be blank.")
                        RadPageView1.SelectedPage = RadPageViewPage1
                        txtTestingExeVersion.Focus()
                        Return False
                    End If
                    If clsCommon.myLen(txtActualTestedTime.Text) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Actual Testing Time can not be blank.")
                        RadPageView1.SelectedPage = RadPageViewPage1
                        txtActualTestedTime.Focus()
                        Return False
                    End If
                ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then

                ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then

                End If
            End If
            UcAttachment1.AllowToSave()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function

    Sub LoadData(ByVal strTicketCode As String)
        Try
            AddNew()
            isInsideLoadData = True
            Dim obj As clsTicketMasterEntry = clsTicketMasterEntry.GetData(strTicketCode, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then

                txtTicketNo.Value = obj.TICKET_NO
                txtTicketDate.Text = obj.TICKET_DATE
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
                lblRequestNo.Text = obj.REQUEST_NO
                If clsCommon.myLen(obj.REQUEST_DATE) > 0 Then
                    lblRequestDate.Text = obj.REQUEST_DATE
                End If

                lblAnalysisNo.Text = obj.ANALYSIS_NO
                If clsCommon.myLen(obj.ANALYSIS_DATE) > 0 Then
                    lblAnalysisDate.Text = obj.ANALYSIS_DATE
                End If
                txtCreatedBy.Value = obj.Created_By
                lblCreatedBy.Text = obj.Created_By_Name
                txtDeveloper.Value = obj.DEVELOPER_CODE
                lblDeveloper.Text = obj.DEVELOPER_NAME
                txtTester.Value = obj.TESTER_CODE
                lblTester.Text = obj.TESTER_NAME
                cboTicketStatus.Text = obj.TICKET_STATUS
                txtTicketDescription.Text = obj.TICKET_DESCRIPTION
                txtAllocationRemarks.Text = obj.ALLOCATION_REMARKS
                txtAllocatedTime.Text = obj.ALLOCATED_TIME
                txtDeveloperRreviousRemarks.Text = obj.DEVELOPER_REMARKS
                txtDevelopmentTime.Text = ""  'obj.DEVELOPMENT_TIME
                txtTesterPreviousRemarks.Text = obj.TESTER_REMARKS
                txtTestingTime.Text = obj.TESTING_TIME
                txtDevelopmentExeVersion.Text = obj.DEVELOPMENT_EXE_VERSION
                txtTestingExeVersion.Text = obj.TESTING_EXE_VERSION
                txtActualTestedTime.Text = "" 'obj.ACTUAL_TESTING_TIME
                If clsCommon.myLen(lblRequestNo.Text) > 0 Then
                    cboTicketType.Enabled = False
                Else
                    cboTicketType.Enabled = True
                End If
                isInsideLoadData = False
                txtTicketNo.MyReadOnly = True

                If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                    Dim strTotalDevelopmentTimeUserBy As String = clsDBFuncationality.getSingleValue(" select  isnull( sum(convert (decimal(10,2),isnull(time,0))),0) from TSPL_TIME_SHEET_DETAIL where TICKET_NO = '" + obj.TICKET_NO + "' and  Created_By = '" + objCommonVar.CurrentUserCode + "'")
                    lblTotalDevelopmentTime.Text = CalculateTotalTimeUserBy(strTotalDevelopmentTimeUserBy)
                    lblTotalDevelopmentTime.Visible = True
                    txtDevelopmentExeVersion.Text = ""
                ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Then
                    Dim strTotalTestingTimeUserBy As String = clsDBFuncationality.getSingleValue(" select  isnull( sum(convert (decimal(10,2),isnull(time,0))),0) from TSPL_TIME_SHEET_DETAIL where TICKET_NO = '" + obj.TICKET_NO + "' and  Created_By = '" + objCommonVar.CurrentUserCode + "'")
                    lblTotalTestingTime.Text = CalculateTotalTimeUserBy(strTotalTestingTimeUserBy)
                    lblTotalTestingTime.Visible = True
                    txtTestingExeVersion.Text = ""
                End If



                'If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
                '    btnSave.Text = "Save"
                '    If clsCommon.CompairString(cboTicketStatus.Text, "Open") = CompairStringResult.Equal Then
                '        btnSave.Enabled = True
                '    Else
                '        btnSave.Enabled = False
                '    End If
                'Else
                '    btnSave.Enabled = True
                '    btnSave.Text = "Update"
                'End If
                SaveUpdateButtonStatus()
                UcAttachment1.Form_ID = "TICKET_MST"
                If clsCommon.myLen(lblAnalysisNo.Text) > 0 Then
                    UcAttachment1.LoadData(lblAnalysisNo.Text)
                Else
                    UcAttachment1.LoadData(txtTicketNo.Text)
                End If

            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub

    Public Function CalculateTotalTimeUserBy(ByVal strTotalTime As String) As String

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
            Dim Duration = New TimeSpan(0, finalMinute, 0)
            Dim Day = Duration.Days * 24
            Dim Hours = Duration.Hours + Day
            Dim Minutes = Duration.Minutes
            Dim strTotalFinaltime As String = clsCommon.myCstr(Hours) + "." + clsCommon.myCstr(Minutes)

            Return strTotalFinaltime
        End If
        Return "0"
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        CType(Me.Owner, FrmTicketMaster).LoadData(True)
    End Sub

    Private Sub txtClient__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtClient._MYValidating
        Dim qry As String = "select CLIENT_CODE as Code,CLIENT_DESCRIPTION as Name ,VERTICAL from TSPL_CLIENT_MASTER "
        Dim WhrCls As String = String.Empty
        txtClient.Value = clsCommon.ShowSelectForm("CLIENT@CODE", qry, "Code", WhrCls, txtClient.Value, "Code", isButtonClicked)
        lblClient.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE='" + txtClient.Value + "'"))
    End Sub

    Private Sub txtModule__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtModule._MYValidating
        Dim qry As String = "select MODULE_CODE as Code,MODULE_DESCRIPTION as Name from TSPL_MODULE_MASTER "
        Dim WhrCls As String = String.Empty
        txtModule.Value = clsCommon.ShowSelectForm("Module@Type", qry, "Code", WhrCls, txtModule.Value, "Code", isButtonClicked)
        lblModule.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select MODULE_DESCRIPTION from TSPL_MODULE_MASTER where MODULE_CODE='" + txtModule.Value + "'"))
    End Sub
    Private Sub txtProject__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtProject._MYValidating
        Dim qry As String = "Select PROJECT_CODE As [Code],PROJECT_DESCRIPTION As [Name] from TSPL_PROJECT_MASTER "
        txtProject.Value = clsCommon.ShowSelectForm("TBL@PROJECT_MASTER", qry, "Code", "", txtProject.Value, "TSPL_PROJECT_MASTER.PROJECT_CODE", isButtonClicked)
        lblProject.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select PROJECT_DESCRIPTION from TSPL_PROJECT_MASTER where PROJECT_CODE='" + txtModule.Value + "'"))
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

    Private Sub txtTicketNo__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtTicketNo._MYNavigator
        Dim WhrCls As String = ""

        Dim qry As String = "select TICKET_NO  from TSPL_TICKET_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_TICKET_MASTER.TICKET_NO=(select MIN(TICKET_NO) from TSPL_TICKET_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_TICKET_MASTER.TICKET_NO=(select MAX(TICKET_NO) from TSPL_TICKET_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_TICKET_MASTER.TICKET_NO=(select Min(TICKET_NO) from TSPL_TICKET_MASTER where TICKET_NO > '" + txtTicketNo.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_TICKET_MASTER.TICKET_NO=(select Max(TICKET_NO) from TSPL_TICKET_MASTER where TICKET_NO < '" + txtTicketNo.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_TICKET_MASTER.TICKET_NO='" + txtTicketNo.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtTicketNo.Value = clsCommon.myCstr(dt.Rows(0)("TICKET_NO"))
        End If
        LoadData(txtTicketNo.Value)
    End Sub

    Private Sub txtTicketNo__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtTicketNo._MYValidating
        Dim str As String = "select count(*) from TSPL_TICKET_MASTER where TICKET_NO = '" + txtTicketNo.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtTicketNo.MyReadOnly = False
        Else
            txtTicketNo.MyReadOnly = True
        End If

        If txtTicketNo.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = " select TSPL_TICKET_MASTER.TICKET_NO as [TICKET NO],convert(varchar, TSPL_TICKET_MASTER.TICKET_DATE,103) as [TICKET DATE],TSPL_TICKET_MASTER.CLIENT_CODE as [CLIENT CODE],TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION as [Client Name],TSPL_TICKET_MASTER.SCREEN_CODE as [SCREEN CODE],TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION as [Screen Name], TSPL_TICKET_MASTER.MODULE_CODE as [MODULE CODE],TSPL_MODULE_MASTER.MODULE_DESCRIPTION as [MODULE NAME],TSPL_TICKET_MASTER .PROJECT_CODE as [PROJECT CODE] ,TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION as [PROJECT NAME],TSPL_TICKET_MASTER.TICKET_STATUS as [TICKET STATUS] ,TSPL_TICKET_MASTER.DEVELOPER_CODE as [DEVELOPER CODE],TBL_USER_MASTER_Developer.USER_NAME as [DEVELOPER NAME],TSPL_TICKET_MASTER.TESTER_CODE as [TESTER CODE],TBL_USER_MASTER_Tester.USER_NAME as [TESTER NAME],TSPL_TICKET_MASTER.Created_By as [CREATED BY CODE],TBL_USER_MASTER_Created_By.USER_NAME as [CREATED BY NAME], TSPL_TICKET_MASTER.TICKET_TYPE as [TICKET TYPE],TSPL_TICKET_MASTER.DATA_ERROR_TYPE as [DATA ERROR TYPE], TSPL_TICKET_MASTER.SEVERITY , TSPL_TICKET_MASTER.PRIORITY as [PRIORITY],TSPL_TICKET_MASTER.TICKET_DESCRIPTION as [TICKET DESCRIPTION],TSPL_TICKET_MASTER.ALLOCATION_REMARKS as [ALLOCATION REMARKS], case when TSPL_TICKET_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_TICKET_MASTER.ALLOCATED_TIME,103)  end as [ALLOCATED TIME] ,TSPL_TICKET_MASTER.DEVELOPER_REMARKS as [DEVELOPER REMARKS],TSPL_TICKET_MASTER.DEVELOPMENT_TIME as [DEVELOPMENT TIME] ,TSPL_TICKET_MASTER.TESTER_REMARKS as [TESTER REMARKS],TSPL_TICKET_MASTER.TESTING_TIME as [TESTING TIME],TSPL_TICKET_MASTER.REQUEST_NO as [REQUEST NO], case when TSPL_TICKET_MASTER.REQUEST_DATE is null then '' else  convert (varchar,TSPL_TICKET_MASTER.REQUEST_DATE,103) end as [REQUEST DATE],TSPL_TICKET_MASTER.ANALYSIS_NO as [ANALYSIS NO],case when TSPL_TICKET_MASTER.ANALYSIS_DATE is null then '' else   convert (varchar, TSPL_TICKET_MASTER.ANALYSIS_DATE,103) end as  [ANALYSIS DATE]  from TSPL_TICKET_MASTER " & _
                           " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_TICKET_MASTER.CLIENT_CODE " & _
                           " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_TICKET_MASTER.SCREEN_CODE " & _
                           " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_TICKET_MASTER.MODULE_CODE " & _
                           " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_TICKET_MASTER.PROJECT_CODE " & _
                           " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE " & _
                           " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE " & _
                           " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE "
            txtTicketNo.Value = clsCommon.ShowSelectForm("TSPL_USER_MASTER", qry, "TICKET NO", "", txtTicketNo.Value, "TSPL_TICKET_MASTER.TICKET_NO", isButtonClicked)
            If clsCommon.myLen(txtTicketNo.Value) > 0 Then
                LoadData(txtTicketNo.Value)
            Else
                AddNew()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If myMessages.deleteConfirm() Then
            deleteData()
        End If
    End Sub

    Sub deleteData()
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            If clsCommon.myLen(txtTicketNo.Value) > 0 Then

                If clsTicketMasterEntry.deleteData(txtTicketNo.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    AddNew()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a Ticket No to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub

    Private Sub txtDeveloper__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtDeveloper._MYValidating
        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
            Dim qry As String = "select USER_CODE as Code,USER_NAME as Name ,TYPE,CLIENT_CODE,USER_GROUP_CODE,EMAIL,PHONE  from TSPL_USER_MASTER "
            Dim WhrCls As String = " USER_TYPE ='Developer' "
            txtDeveloper.Value = clsCommon.ShowSelectForm("CLIENT@CODE", qry, "Code", WhrCls, txtDeveloper.Value, "Code", isButtonClicked)
            lblDeveloper.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select USER_NAME from TSPL_USER_MASTER where USER_CODE='" + txtDeveloper.Value + "'"))

        End If

    End Sub

    Private Sub txtTester__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtTester._MYValidating
        If clsCommon.CompairString(strCureentScreenOpenByDilog, "Ticket Allocation") = CompairStringResult.Equal Then
            Dim qry As String = "select USER_CODE as Code,USER_NAME as Name ,TYPE,CLIENT_CODE,USER_GROUP_CODE,EMAIL,PHONE  from TSPL_USER_MASTER  "
            Dim WhrCls As String = " USER_TYPE in ('Tester','Implementation') "
            txtTester.Value = clsCommon.ShowSelectForm("CLIENT@CODE", qry, "Code", WhrCls, txtTester.Value, "Code", isButtonClicked)
            lblTester.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select USER_NAME from TSPL_USER_MASTER where USER_CODE='" + txtTester.Value + "'"))
        End If

    End Sub

    
End Class
