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

Public Class FrmRequestApprovalEntry
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False
    Private strCureentScreenOpenByDilog As String = ""
    Private Sub FrmRequestApprovalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strCureentScreenOpenByDilog = CType(Me.Owner, FrmRequestApproval).Text
        MyBase.SetUserMgmt(clsUserMgtCode.frmRequestApproval)
        AddNew()
        If CType(Me.Owner, FrmRequestApproval).gv.Rows.Count > 0 Then
            If clsCommon.myLen(clsCommon.myCstr(CType(Me.Owner, FrmRequestApproval).gv.CurrentRow.Cells("REQUEST_ANALYSIS_NO").Value)) > 0 Then
                LoadData(CType(Me.Owner, FrmRequestApproval).gv.CurrentRow.Cells("REQUEST_ANALYSIS_NO").Value)
            End If
        End If

    End Sub

    Private Sub AddNew()
        txtRequestAnalysisNo.Value = ""
        txtRequestAnalysisNo.Enabled = False
        txtRequestAnalysisDate.Text = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE, "dd/MM/yyyy")
        txtRequestAnalysisDate.Enabled = False
        txtClient.Value = ""
        txtClient.Enabled = False
        lblClient.Text = ""
        txtScreen.Value = ""
        txtScreen.Enabled = False
        lblScreen.Text = ""
        txtModule.Value = ""
        txtModule.Enabled = False
        lblModule.Text = ""
        txtProject.Value = ""
        txtProject.Enabled = False
        lblProject.Text = ""
        cboAnalysisStatus.Text = ""
        txtDeveloper.Value = ""
        txtDeveloper.Enabled = False
        lblDeveloper.Text = ""
        txtTester.Value = ""
        txtTester.Value = False
        lblTester.Text = ""
        cboTicketType.Text = ""
        cboTicketType.Enabled = False
        cboDataErrorType.Text = ""
        cboDataErrorType.Enabled = False
        cboSeverity.Text = ""
        cboSeverity.Enabled = False
        cboPriority.Text = ""
        cboPriority.Enabled = False
        txtRequestAnalysisDescription.Text = ""
        txtRequestAnalysisDescription.Enabled = False
        txtAllocatedTime.Text = ""
        txtAllocatedTime.Enabled = False
        txtTestingTime.Text = ""
        txtTestingTime.Enabled = False
        txtRequestNo.Value = ""
        txtRequestNo.Enabled = False
        lblRequestDate.Text = ""
        txtCreatedBy.Enabled = False
        txtCreatedBy.Value = ""
        lblCreatedBy.Text = ""
        txtRequestDescription.Text = ""
        txtRequestDescription.ReadOnly = True
        cboAnalysisStatus.Text = ""
        cboAnalysisStatus.Enabled = False
        txtApprovedTime.Text = ""
        txtTotalTime.Text = ""

        txtTotalTime.Enabled = False
        btnApproved.Text = "Approved"
        btnApproved.Enabled = True
        txtApprovedTime.Focus()
        panelMain.Enabled = False
        If clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
            panelAllocatedTestingTime.Visible = False
            txtAllocatedTime.Enabled = False
            txtApprovedTime.ReadOnly = True
        End If
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
                txtAnalysisBy.Value = obj.Modify_By
                lblAnalysedBy.Text = obj.Analysis_By_Name
                txtDeveloper.Value = obj.DEVELOPER_CODE
                lblDeveloper.Text = obj.DEVELOPER_NAME
                txtTester.Value = obj.TESTER_CODE
                lblTester.Text = obj.TESTER_NAME
                cboAnalysisStatus.Text = obj.ANALYSIS_STATUS
                txtRequestAnalysisDescription.Text = obj.ANALYSIS_DESCRIPTION
                txtRequestDescription.Text = obj.REQUEST_DESCRIPTION
                txtAllocatedTime.Text = obj.ALLOCATED_TIME
                txtTestingTime.Text = obj.TESTING_TIME
                txtApprovedTime.Text = obj.APPROVED_TIME
                lblTicketNo.Text = obj.TICKET_NO
                txtTotalTime.Text = obj.TOTAL_TIME
                isInsideLoadData = False
                txtRequestAnalysisNo.MyReadOnly = True
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub


    Private Sub btnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        If myMessages.ApprovalConfirm() Then
            SaveData()
        End If
    End Sub
    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsRequestAnalysisEnry()


                obj.REQUEST_ANALYSIS_NO = txtRequestAnalysisNo.Value
                obj.REQUEST_NO = txtRequestNo.Value
                obj.REQUEST_DESCRIPTION = txtRequestDescription.Text
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
                obj.ANALYSIS_STATUS = cboAnalysisStatus.Text
                obj.TESTING_TIME = txtTestingTime.Text
                obj.APPROVED_TIME = txtApprovedTime.Text
                obj.TOTAL_TIME = txtTotalTime.Text
                obj.Form_Title_Name = strCureentScreenOpenByDilog
                If clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
                    obj.IS_CLIENT_APPROVED = 1
                    obj.IS_Mgmt_APPROVED = 1
                    obj.APPROVAL_STATUS = "Approved"
                Else
                    obj.IS_Mgmt_APPROVED = 1
                    obj.APPROVAL_STATUS = "Client Approval"
                End If
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_REQUEST_ANALYSIS_MASTER where REQUEST_ANALYSIS_NO='" & obj.REQUEST_ANALYSIS_NO & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    'LoadData(obj.REQUEST_ANALYSIS_NO)
                    Me.Close()
                    CType(Me.Owner, FrmRequestApproval).LoadData(False)
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Function AllowToSave() As Boolean
        Try
            If txtApprovedTime.Value <= 0 Then
                common.clsCommon.MyMessageBoxShow("Approved Time can not be blank.")
                txtApprovedTime.Focus()
                Return False
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        ' CType(Me.Owner, FrmRequestApproval).LoadData(False)
    End Sub
End Class
