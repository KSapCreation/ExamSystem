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
Imports TeamMgmt


Public Class FrmRuestCreationEntry
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False

    Private Sub FrmRuestCreationEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.SetUserMgmt(clsUserMgtCode.frmRequestCreation)
        AddNew()
        If CType(Me.Owner, FrmRequestCreation).isNewEntry = False Then
            If CType(Me.Owner, FrmRequestCreation).gv.Rows.Count > 0 Then
                If clsCommon.myLen(clsCommon.myCstr(CType(Me.Owner, FrmRequestCreation).gv.CurrentRow.Cells("REQUEST_NO").Value)) > 0 Then
                    LoadData(CType(Me.Owner, FrmRequestCreation).gv.CurrentRow.Cells("REQUEST_NO").Value)
                End If
            End If
        End If
        UcAttachment1.Form_ID = MyBase.Form_ID
        ' UcAttachment1.LoadCustomControls()
    End Sub
    Private Sub AddNew()
        txtRequestNo.Value = ""
        txtRequestNo.MyReadOnly = False
        txtRequestDate.Text = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE, "dd/MM/yyyy")
        txtRequestDate.ReadOnly = True
        txtClient.Value = ""
        txtClient.Enabled = False
        lblClient.Text = ""
        cboRequestStatus.Text = "Open"
        cboRequestStatus.Enabled = False
        txtRequestDescription.Text = ""
        txtCreatedBy.Enabled = False
        txtCreatedBy.Value = ""
        lblCreatedBy.Text = ""
        lblApprovalStatus.Text = ""
        btnSave.Text = "Save"
        btnSave.Enabled = True
        btnDelete.Enabled = False
        FillClientDetails()
        txtRequestNo.Focus()
        UcAttachment1.BlankAllControls()
        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub
    'Sub LoadRequestStatus()
    '    cboRequestStatus.DataSource = clsTicketMasterEntry.LoadTicketStatus()
    '    cboRequestStatus.ValueMember = "Code"
    '    cboRequestStatus.DisplayMember = "Name"
    'End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Function AllowToSave() As Boolean
        Try

            If clsCommon.myLen(txtClient.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Client code can not be blank.")
                txtClient.Focus()
                Return False
            End If

            If clsCommon.myLen(txtRequestDescription.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Request Description can not be blank.")
                txtRequestDescription.Focus()
                Return False
            End If

            If clsCommon.myLen(cboRequestStatus.Text) <= 0 Or clsCommon.CompairString(cboRequestStatus.Text, "Open") <> CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please select Request status 'Open' .")
                cboRequestStatus.Focus()
                Return False
            End If
            UcAttachment1.AllowToSave()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function

    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsRequestCreationEntry()
                obj.REQUEST_NO = txtRequestNo.Value
                obj.CLIENT_CODE = txtClient.Value
                obj.REQUEST_STATUS = cboRequestStatus.Text
                obj.REQUEST_DESCRIPTION = txtRequestDescription.Text
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" & obj.REQUEST_NO & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry)) Then
                    UcAttachment1.SaveData(obj.REQUEST_NO)
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.REQUEST_NO)
                    btnSave.Text = "Update"
                    btnDelete.Enabled = True
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Sub LoadData(ByVal strRequestCode As String)
        Try
            AddNew()
            isInsideLoadData = True
            Dim obj As clsRequestCreationEntry = clsRequestCreationEntry.GetData(strRequestCode, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then
                txtRequestNo.Value = obj.REQUEST_NO
                txtRequestDate.Text = obj.REQUEST_DATE
                cboRequestStatus.Text = obj.REQUEST_STATUS
                txtClient.Value = obj.CLIENT_CODE
                lblClient.Text = obj.CLIENT_NAME
                txtRequestDescription.Text = obj.REQUEST_DESCRIPTION
                txtCreatedBy.Value = obj.Created_By
                lblCreatedBy.Text = obj.Created_By_Name
                lblApprovalStatus.Text = obj.APPROVAL_STATUS
                isInsideLoadData = False
                txtRequestNo.MyReadOnly = True
                btnSave.Text = "Update"
                btnDelete.Enabled = True
                If clsCommon.CompairString(cboRequestStatus.Text, "Open") = CompairStringResult.Equal Then
                    btnSave.Enabled = True
                    btnSave.Text = "Save"
                Else
                    btnSave.Enabled = False
                    btnSave.Text = "Update"
                    btnDelete.Enabled = False
                End If
                UcAttachment1.Form_ID = MyBase.Form_ID
                UcAttachment1.LoadData(txtRequestNo.Value)
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        CType(Me.Owner, FrmRequestCreation).LoadData(True)
    End Sub


    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub txtRequestNo__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtRequestNo._MYNavigator
        Dim WhrCls As String = ""

        Dim qry As String = "select REQUEST_NO  from TSPL_REQUEST_CREATION_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_REQUEST_CREATION_MASTER.REQUEST_NO=(select MIN(REQUEST_NO) from TSPL_REQUEST_CREATION_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_REQUEST_CREATION_MASTER.REQUEST_NO=(select MAX(REQUEST_NO) from TSPL_REQUEST_CREATION_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_REQUEST_CREATION_MASTER.REQUEST_NO=(select Min(REQUEST_NO) from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO > '" + txtRequestNo.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_REQUEST_CREATION_MASTER.REQUEST_NO=(select Max(REQUEST_NO) from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO < '" + txtRequestNo.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_REQUEST_CREATION_MASTER.REQUEST_NO='" + txtRequestNo.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtRequestNo.Value = clsCommon.myCstr(dt.Rows(0)("REQUEST_NO"))
        End If
        LoadData(txtRequestNo.Value)
    End Sub

    Private Sub txtRequestNo__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtRequestNo._MYValidating
        Dim str As String = "select count(*) from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO = '" + txtRequestNo.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtRequestNo.MyReadOnly = False
        Else
            txtRequestNo.MyReadOnly = True
        End If

        If txtRequestNo.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = " select TSPL_REQUEST_CREATION_MASTER.REQUEST_NO as [REQUEST NO],convert(varchar, TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) as REQUEST_DATE as [REQUEST DATE],isnull(TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE,'') as [CLIENT CODE] ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as [CLIENT NAME],isNull(TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS,'') as [REQUEST STATUS],isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as [REQUEST DESCRIPTION],isnull(TSPL_REQUEST_CREATION_MASTER.Created_By,'') as [CREATED BY CODE],isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as [CREATED BY NAME] from TSPL_REQUEST_CREATION_MASTER " & _
                            " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_TICKET_MASTER.CLIENT_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE  "
            txtRequestNo.Value = clsCommon.ShowSelectForm("TSPL_REQUEST_CREATION_MASTER", qry, "REQUEST NO", "", txtRequestNo.Value, "TSPL_REQUEST_CREATION_MASTER.REQUEST_NO", isButtonClicked)
            If clsCommon.myLen(txtRequestNo.Value) > 0 Then
                LoadData(txtRequestNo.Value)
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
            If clsCommon.myLen(txtRequestNo.Value) > 0 Then

                If clsRequestCreationEntry.deleteData(txtRequestNo.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    AddNew()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a Request No to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub


    Sub FillClientDetails()
        Dim qry As String = "  select  TSPL_USER_MASTER.CLIENT_CODE , TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION from TSPL_USER_MASTER left outer join TSPL_CLIENT_MASTER  on TSPL_CLIENT_MASTER.CLIENT_CODE = TSPL_USER_MASTER.CLIENT_CODE where TSPL_USER_MASTER.USER_CODE ='" + objCommonVar.CurrentUserCode + "' "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            txtClient.Value = clsCommon.myCstr(dt.Rows(0)("CLIENT_CODE"))
            lblClient.Text = clsCommon.myCstr(dt.Rows(0)("CLIENT_DESCRIPTION"))
        End If
    End Sub
End Class
