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


Public Class FrmRequestCreation
    Inherits FrmMainTranScreen
    Const colRequestNo As String = "Request No"
    Const colRequestDate As String = "Request Date"
    Const colClientCode As String = "Client Code"
    Const colClientName As String = "Client Name"
    Const colRequestStatus As String = "Request Status"
    Const colRequestDescription As String = "Request Description"

    Dim frmHeading As String = ""
    Public isNewEntry As Boolean = False
    Private Sub FrmRequestCreation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtFromDate.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        'txtToDate.Text = clsCommon.GETSERVERDATE
        txtToDate.Text = clsCommon.GETSERVERDATE
        txtFromDate.Value = txtToDate.Value.AddMonths(-1)
        LoadData(True)
    End Sub


    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        isNewEntry = True
        OpenForm()
    End Sub
    Sub OpenForm()
        Dim frm1 As FrmRuestCreationEntry = New FrmRuestCreationEntry()
        frm1.StartPosition = FormStartPosition.CenterScreen
        frm1.MaximizeBox = False
        frm1.MinimizeBox = False
        frm1.ControlBox = False
        frm1.Owner = Me
        frm1.ShowDialog()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        LoadData(False)
    End Sub
    Sub LoadData(ByVal isLoadData As Boolean)
        Try
            Dim fromdate As String = clsCommon.GetPrintDate(txtFromDate.Value, "dd/MMM/yyyy")
            Dim todate As String = clsCommon.GetPrintDate(txtToDate.Value, "dd/MMM/yyyy")
            Dim qry As String = " select TSPL_REQUEST_CREATION_MASTER.REQUEST_NO,convert(varchar, TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) as REQUEST_DATE,isnull(TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS,'') as REQUEST_STATUS,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION,isnull(TSPL_REQUEST_CREATION_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name, Convert(varchar, TSPL_REQUEST_CREATION_MASTER.Created_Date,103) as Created_Date , isnull(TSPL_REQUEST_CREATION_MASTER.Modify_By,'') as Modify_By_Code,isnull(TBL_USER_MASTER_Modify_By.USER_NAME,'') as Modify_By_Name ,Convert(varchar,TSPL_REQUEST_ANALYSIS_MASTER.Modify_Date,103) as Modify_Date  , isnull(TSPL_REQUEST_ANALYSIS_MASTER.APPROVAL_STATUS,'') as APPROVAL_STATUS from TSPL_REQUEST_CREATION_MASTER " & _
                            " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Created_By  " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Modify_By on TBL_USER_MASTER_Modify_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Modify_By " & _
                            " left outer join TSPL_REQUEST_ANALYSIS_MASTER on TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO = TSPL_REQUEST_CREATION_MASTER.REQUEST_NO  " & _
                            " where convert(date,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) > = '" + fromdate + "' and convert(date,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) <='" + todate + "' and TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE = '" + objCommonVar.CurrentClientCode + "' "

            Dim dt As DataTable = Nothing
            dt = New DataTable()
            dt = clsDBFuncationality.GetDataTable(qry, Nothing)
            gv.DataSource = Nothing
            gv.Columns.Clear()
            gv.Rows.Clear()
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                If isLoadData = False Then
                    common.clsCommon.MyMessageBoxShow("No data found between {" + txtFromDate.Text + "- to -" + txtToDate.Text + "}", Me.Text)
                End If
                Exit Sub
            End If
            gv.DataSource = dt
            SetGridFormationOFgv()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Sub SetGridFormationOFgv()
        gv.TableElement.TableHeaderHeight = 40
        gv.MasterTemplate.ShowRowHeaderColumn = False
        For ii As Integer = 0 To gv.Columns.Count - 1
            gv.Columns(ii).ReadOnly = True
            gv.Columns(ii).IsVisible = False
        Next

        gv.Columns("REQUEST_NO").IsVisible = True
        gv.Columns("REQUEST_NO").Width = 100
        gv.Columns("REQUEST_NO").HeaderText = "REQUEST NO"

        gv.Columns("REQUEST_DATE").IsVisible = True
        gv.Columns("REQUEST_DATE").Width = 100
        gv.Columns("REQUEST_DATE").HeaderText = "REQUEST DATE"

        gv.Columns("CLIENT_CODE").IsVisible = True
        gv.Columns("CLIENT_CODE").Width = 100
        gv.Columns("CLIENT_CODE").HeaderText = "CLIENT CODE"

        gv.Columns("Client_Name").IsVisible = True
        gv.Columns("Client_Name").Width = 100
        gv.Columns("Client_Name").HeaderText = "CLIENT NAME"

        gv.Columns("REQUEST_STATUS").IsVisible = True
        gv.Columns("REQUEST_STATUS").Width = 100
        gv.Columns("REQUEST_STATUS").HeaderText = "REQUEST STATUS"

        gv.Columns("REQUEST_DESCRIPTION").IsVisible = True
        gv.Columns("REQUEST_DESCRIPTION").Width = 600
        gv.Columns("REQUEST_DESCRIPTION").HeaderText = "REQUEST DESCRIPTION"

        gv.Columns("Created_By_Code").IsVisible = True
        gv.Columns("Created_By_Code").Width = 150
        gv.Columns("Created_By_Code").HeaderText = "CREATED BY(CODE)"

        gv.Columns("Created_By_Name").IsVisible = True
        gv.Columns("Created_By_Name").Width = 150
        gv.Columns("Created_By_Name").HeaderText = "CREATED BY (NAME)"

        gv.Columns("Created_Date").IsVisible = True
        gv.Columns("Created_Date").Width = 150
        gv.Columns("Created_Date").HeaderText = "CREATED DATE"

        gv.Columns("Modify_By_Code").IsVisible = False
        gv.Columns("Modify_By_Code").Width = 150
        gv.Columns("Modify_By_Code").HeaderText = "MODIFY BY(CODE)"

        gv.Columns("Modify_By_Name").IsVisible = False
        gv.Columns("Modify_By_Name").Width = 150
        gv.Columns("Modify_By_Name").HeaderText = "MODIFY BY (NAME)"

        gv.Columns("Modify_Date").IsVisible = False
        gv.Columns("Modify_Date").Width = 150
        gv.Columns("Modify_Date").HeaderText = "MODIFY DATE"

        gv.Columns("APPROVAL_STATUS").IsVisible = True
        gv.Columns("APPROVAL_STATUS").Width = 150
        gv.Columns("APPROVAL_STATUS").HeaderText = "APPROVAL STATUS"


    End Sub

    Private Sub gv_DoubleClick(sender As Object, e As EventArgs) Handles gv.DoubleClick
        Try
            isNewEntry = False
            If gv.Rows.Count > 0 Then
                OpenForm()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try

    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
