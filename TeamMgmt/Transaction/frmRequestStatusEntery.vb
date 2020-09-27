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
Public Class FrmRequestStatusEntery
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False
    Private strCureentScreenOpenByDilog As String = ""

    Private Sub FrmRequestStatusEntery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UcAttachment1.Form_ID = MyBase.Form_ID
        AddNew()
        If CType(Me.Owner, FrmRequestStatus).gv.Rows.Count > 0 Then
            If clsCommon.myLen(clsCommon.myCstr(CType(Me.Owner, FrmRequestStatus).gv.CurrentRow.Cells(0).Value)) > 0 Then
                LoadData(CType(Me.Owner, FrmRequestStatus).gv.CurrentRow.Cells(0).Value)
            End If
        End If

    End Sub

    Private Sub AddNew()
        txtRequestNo.Value = ""
        txtRequestNo.Enabled = False
        lblRequestDate.Text = ""
        LoadRequestStatus()
        txtAnalysisNo.Value = ""
        txtAnalysisNo.Enabled = False
        lblAnalysisDate.Text = ""
        lblApprovalTime.Text = ""
        txtClient.Value = ""
        txtClient.Enabled = False
        lblClient.Text = ""
        txtScreen.Value = ""
        txtScreen.Enabled = False
        lblScreen.Text = ""
        txtModule.Value = ""
        lblModule.Enabled = False
        lblModule.Text = ""
        txtProject.Value = ""
        txtProject.Enabled = False
        lblProject.Text = ""
        txtCreatedBy.Enabled = False
        txtCreatedBy.Value = ""
        lblCreatedBy.Text = ""
        cboTicketType.Text = ""
        cboTicketType.Enabled = False
        cboDataErrorType.Text = ""
        cboDataErrorType.Enabled = False
        cboSeverity.Text = ""
        cboSeverity.Enabled = False
        cboPriority.Text = ""
        cboPriority.Enabled = False
        lblTicketNo.Text = ""
        lblTicketStatus.Text = ""
        lblDevelopmentVersionInfo.Text = ""
        lblTestingVersionInfo.Text = ""
        txtRequestAnalysisDescription.Text = ""
        txtRequestAnalysisDescription.ReadOnly = True
        txtPendingRemarks .Text =""
        txtRequestDescription.Text = ""
        txtRequestDescription.ReadOnly = True
        btnSave.Text = "Save"
        btnSave.Enabled = True
        txtRequestNo.Focus()
        UcAttachment1.BlankAllControls()
        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub

    Sub LoadRequestStatus()
        cboRequestStatus.DataSource = GetRequestStatus()
        cboRequestStatus.ValueMember = "Code"
        cboRequestStatus.DisplayMember = "Code"
        cboRequestStatus.SelectedIndex = 0
    End Sub
    Private Function GetRequestStatus() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Code", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "-Select-"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Complete"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Pending"
        dt.Rows.Add(dr)

        Return dt
    End Function

    Sub LoadData(ByVal strRequestNo As String)
        Try
            AddNew()
            isInsideLoadData = True
            Dim obj As clsRequestStatusEntry = clsRequestStatusEntry.GetData(strRequestNo, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then

                txtRequestNo.Value = obj.REQUEST_NO
                If clsCommon.myLen(obj.REQUEST_DATE) > 0 Then
                    lblRequestDate.Text = obj.REQUEST_DATE
                End If
                txtAnalysisNo.Value = obj.REQUEST_ANALYSIS_NO
                If clsCommon.myLen(obj.REQUEST_ANALYSIS_DATE) > 0 Then
                    lblAnalysisDate.Text = obj.REQUEST_ANALYSIS_DATE
                End If
                txtRequestNo.Value = obj.REQUEST_NO
                lblRequestDate.Text = obj.REQUEST_DATE
                lblApprovalTime.Text = obj.APPROVED_TIME
                txtClient.Value = obj.CLIENT_CODE
                lblClient.Text = obj.CLIENT_NAME
                txtScreen.Value = obj.SCREEN_CODE
                lblScreen.Text = obj.SCREEN_NAME
                txtModule.Value = obj.MODULE_CODE
                lblModule.Text = obj.MODULE_NAME
                txtProject.Value = obj.PROJECT_CODE
                lblProject.Text = obj.PROJECT_NAME
                txtCreatedBy.Value = obj.Created_By
                lblCreatedBy.Text = obj.Created_By_Name

                cboTicketType.Text = obj.TICKET_TYPE
                cboDataErrorType.Text = obj.DATA_ERROR_TYPE
                cboSeverity.Text = obj.SEVERITY
                cboPriority.Text = obj.PRIORITY
                lblTicketNo.Text = obj.TICKET_NO
                lblTicketStatus.Text = obj.TICKET_STATUS
                lblDevelopmentVersionInfo.Text = obj.DEVELOPMENT_EXE_VERSION
                lblTestingVersionInfo.Text = obj.TESTING_EXE_VERSION
                txtPendingRemarks.Text = obj.PENDING_REMARKS
                txtRequestAnalysisDescription.Text = obj.ANALYSIS_DESCRIPTION
                txtRequestDescription.Text = obj.REQUEST_DESCRIPTION
                isInsideLoadData = False

                UcAttachment1.Form_ID = MyBase.Form_ID
                UcAttachment1.LoadData(obj.REQUEST_ANALYSIS_NO)
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        CType(Me.Owner, FrmRequestStatus).LoadData(False)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsRequestStatusEntry()
                obj.REQUEST_NO = txtRequestNo.Value
                'If clsCommon.CompairString(clsCommon.myCstr(cboRequestStatus.SelectedValue), "Pending") = CompairStringResult.Equal Then
                '    obj.REQUEST_STATUS = "Open"
                'Else
                '    obj.REQUEST_STATUS = cboRequestStatus.SelectedValue
                'End If
                obj.REQUEST_STATUS = cboRequestStatus.SelectedValue
                obj.PENDING_REMARKS = txtPendingRemarks.Text
                obj.TICKET_NO = lblTicketNo.Text
                obj.TICKET_STATUS = obj.REQUEST_STATUS
                obj.REQUEST_ANALYSIS_NO = txtAnalysisNo.Value

                If (obj.SaveData(obj, False)) Then
                    UcAttachment1.SaveData(obj.REQUEST_ANALYSIS_NO)
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    'LoadData(obj.REQUEST_NO)
                    Me.Close()
                    CType(Me.Owner, FrmRequestStatus).LoadData(False)
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Function AllowToSave() As Boolean
        Try
            If clsCommon.CompairString(cboRequestStatus.SelectedValue, "-Select-") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please Select Request Status.")
                Return False
            End If
            If clsCommon.CompairString(cboRequestStatus.SelectedValue, "Pending") = CompairStringResult.Equal Then
                If clsCommon.myLen(txtPendingRemarks.Text) <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Please enter Pending Remarks.")
                    Return False
                End If
            End If
            UcAttachment1.AllowToSave()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function


End Class
