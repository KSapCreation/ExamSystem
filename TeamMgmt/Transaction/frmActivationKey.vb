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

Public Class frmActivationKey
    Inherits FrmMainTranScreen

    Dim frmHeading As String = ""
    Public isNewEntry As Boolean = False

    Private Sub FrmActivationKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
    End Sub
   
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub reset()
        txtFromDate.Text = clsCommon.GETSERVERDATE
        frmHeading = Me.Text
        txtStudent.Value = ""
        txtCompany.Text = ""
        lblStudent.Text = ""
        txtCode.Value = ""
        gv.DataSource = Nothing
        gv.Rows.Clear()
        gv.Columns.Clear()
        isNewEntry = True
        btnSave.Text = "Save"
        btnSave.Enabled = True
        btnDelete.Enabled = True
    
        btnReset.Enabled = True
    End Sub
    Sub LoadData(ByVal strCode As String, ByVal NavTyep As NavigatorType)
        btnSave.Text = "Update"
        isNewEntry = False
        gv.DataSource = Nothing
        Dim obj As New clsCreateExe()
        obj = clsCreateExe.GetData(strCode, NavigatorType.Current)
        If (obj IsNot Nothing AndAlso clsCommon.myLen(obj.Version_No) > 0) Then
            txtStudent.Value = obj.Client_Code
            txtCompany.Text = obj.Version_No
            txtFromDate.Value = obj.Doc_Date
            txtCode.Value = obj.DocNo

            If obj.Arr IsNot Nothing AndAlso obj.Arr.Count > 0 Then
                For Each objTr As clsCreateExeDetail In obj.Arr
                    gv.Rows.AddNew()
                    'LoadGrid()
                Next
                LoadGrid()
            End If
        End If
        Dim qry As String = clsDBFuncationality.getSingleValue("select Version_Code from tspl_version_head order by Version_Code desc")
        If clsCommon.CompairString(txtCode.Value, qry) <> CompairStringResult.Equal Then
            btnSave.Enabled = False
            btnDelete.Enabled = False
        
            btnReset.Enabled = False
        End If

    End Sub
    Private Sub txtDocNo__MYNavigator(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal NavType As common.NavigatorType) Handles txtCode._MYNavigator
        Try
            Dim qst As String = "select count(*) from TSPL_VERSION_HEAD where VERSION_Code='" + txtCode.Value + "'"
            LoadData(txtCode.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub txtDocNo__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtCode._MYValidating
        Dim qry As String = "select Version_Code as Code,Client_Code as Client,Version from TSPL_VERSION_HEAD "
        Dim whrClas As String = ""

        LoadData(clsCommon.ShowSelectForm("VesinCode", qry, "Code", "", txtCode.Value, "Code", isButtonClicked), NavigatorType.Current)

    End Sub
    Private Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(clsCommon.myCstr(txtStudent.Value)) <= 0 Then
                clsCommon.MyMessageBoxShow("Client Code cant not be blank.", Me.Text)
                txtStudent.Focus()
                txtStudent.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtCompany.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Version can not be blank.", Me.Text)
                txtCompany.Focus()
                txtCompany.Select()
                Return False
            End If
          
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
        Return True
    End Function
    Sub LoadGrid()
        Dim dt As New DataTable
        Dim qry As String = "  select cast(TSPL_VERSION_DETAIL.Active as bit) as Active,TSPL_TICKET_MASTER.TICKET_NO as [Ticket No],TSPL_TICKET_MASTER.TICKET_DESCRIPTION as Description,TSPL_TICKET_MASTER.client_code as [Client],TSPL_TICKET_MASTER.Screen_Code as [Screen Code],TSPL_TICKET_MASTER.MODULE_CODE as [Module Code] ,TSPL_TICKET_MASTER.PROJECT_CODE as [Project Code],TSPL_TICKET_MASTER.TICKET_TYPE,TSPL_TICKET_MASTER.DATA_ERROR_TYPE,TSPL_TICKET_MASTER.SEVERITY,TSPL_TICKET_MASTER.PRIORITY ,TSPL_TICKET_MASTER.ALLOCATION_REMARKS as [Allocation Remarks],TSPL_TICKET_MASTER.ALLOCATED_TIME as [Allocated Time],TSPL_TICKET_MASTER.DEVELOPER_REMARKS as [Developer Remarks],TSPL_TICKET_MASTER.DEVELOPMENT_TIME as [Development Time],TSPL_TICKET_MASTER.TESTER_REMARKS,TSPL_TICKET_MASTER.TESTING_TIME as [Testing Time],TSPL_TICKET_MASTER.REQUEST_NO as [Request No],TSPL_TICKET_MASTER.REQUEST_DATE as [Request Date],TSPL_TICKET_MASTER.ANALYSIS_NO as [Analysis No],TSPL_TICKET_MASTER.ANALYSIS_DATE as [Analysis Date],TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION as [Development Version],TSPL_TICKET_MASTER.TESTING_EXE_VERSION as [Testing Version],TSPL_TICKET_MASTER.ACTUAL_TESTING_TIME as [Actual Testing Time] from TSPL_VERSION_HEAD "
        qry += " left outer join TSPL_VERSION_DETAIL on TSPL_VERSION_DETAIL.Version_CODE=TSPL_VERSION_HEAD.Version_CODE "
        qry += " left outer join TSPL_TICKET_MASTER on TSPL_TICKET_MASTER.TICKET_NO=TSPL_VERSION_DETAIL.Ticket_Code"
        qry += " where TSPL_VERSION_HEAD.Version_CODE='" & txtCode.Value & "'"
        dt = clsDBFuncationality.GetDataTable(qry, Nothing)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            gv.DataSource = dt
            gv.BestFitColumns()
        End If
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs)
        Try
            Dim qry As String = ""
            Dim dt As New DataTable

            Dim BackVersion As String = clsDBFuncationality.getSingleValue("select top 1 Version from TSPL_VERSION_HEAD where client_code='" & txtStudent.Value & "' and type='E' order by Version_date desc")
            qry = " select distinct cast(0 as bit) as sel,TSPL_TICKET_MASTER.TICKET_NO as [Ticket No],TSPL_TICKET_MASTER.TICKET_DESCRIPTION as Description,TSPL_TICKET_MASTER.client_code as [Client],TSPL_TICKET_MASTER.Screen_Code as [Screen Code],TSPL_TICKET_MASTER.MODULE_CODE as [Module Code]"
            qry += " ,TSPL_TICKET_MASTER.PROJECT_CODE as [Project Code],TSPL_TICKET_MASTER.TICKET_TYPE,TSPL_TICKET_MASTER.DATA_ERROR_TYPE,TSPL_TICKET_MASTER.SEVERITY,TSPL_TICKET_MASTER.PRIORITY"
            qry += " ,TSPL_TICKET_MASTER.ALLOCATION_REMARKS as [Allocation Remarks],TSPL_TICKET_MASTER.ALLOCATED_TIME as [Allocated Time],TSPL_TICKET_MASTER.DEVELOPER_REMARKS as [Developer Remarks],TSPL_TICKET_MASTER.DEVELOPMENT_TIME as [Development Time],TSPL_TICKET_MASTER.TESTER_REMARKS,TSPL_TICKET_MASTER.TESTING_TIME as [Testing Time],TSPL_TICKET_MASTER.REQUEST_NO as [Request No],TSPL_TICKET_MASTER.REQUEST_DATE as [Request Date],TSPL_TICKET_MASTER.ANALYSIS_NO as [Analysis No],TSPL_TICKET_MASTER.ANALYSIS_DATE as [Analysis Date],TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION as [Development Version],TSPL_TICKET_MASTER.TESTING_EXE_VERSION as [Testing Version],TSPL_TICKET_MASTER.ACTUAL_TESTING_TIME as [Actual Testing Time]"
            qry += " from TSPL_TICKET_MASTER"
            qry += " left outer join TSPL_TIME_SHEET_DETAIL on TSPL_TIME_SHEET_DETAIL.TICKET_NO=TSPL_TICKET_MASTER.TICKET_NO"
            qry += " left outer join TSPL_VERSION_HEAD on TSPL_VERSION_HEAD.Version=TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION  "
            qry += " left outer join TSPL_VERSION_DETAIL on TSPL_VERSION_DETAIL.Version_CODE=TSPL_VERSION_HEAD.Version_CODE "
            qry += " where 2=2 and TSPL_TIME_SHEET_DETAIL.status in ('Fixed','Closed') and coalesce(TSPL_VERSION_DETAIL.Active,0)=0 and TSPL_VERSION_DETAIL.Ticket_Code is null "
            If clsCommon.myLen(BackVersion) > 0 Then
                qry += "  and TSPL_TIME_SHEET_DETAIL.EXE_VERSION>='" & BackVersion & "' and TSPL_TIME_SHEET_DETAIL.EXE_VERSION<='" & txtCompany.Text & "'"
            End If

            dt = clsDBFuncationality.GetDataTable(qry, Nothing)
            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                gv.DataSource = dt
                gv.BestFitColumns()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub SelectAll(ByVal val As Boolean)
        If gv.Rows.Count > 0 Then
            'For I = 0 To gv.Rows.Count - 1
            '     gv.Rows(I).Cells(0).Value = True
            ' Next
        End If

    End Sub
    Public Sub UnselectAll()
        If gv.Rows.Count > 0 Then
            Dim I As Integer
            For I = 0 To gv.Rows.Count - 1
                gv.Rows(I).Cells(0).Value = False
            Next
        End If
    End Sub
    Sub LoadBlankGrid()
        gv.Rows.Clear()
        gv.Columns.Clear()
        Dim chkTicket_No As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        chkTicket_No.FormatString = ""
        chkTicket_No.HeaderText = "Select"
        gv.MasterTemplate.Columns.Add(chkTicket_No)

        gv.AllowAddNewRow = False
        gv.ShowGroupPanel = False
        gv.AllowColumnReorder = False
        gv.AllowRowReorder = False
        gv.EnableSorting = False
        gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv.MasterTemplate.ShowRowHeaderColumn = False

    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        reset()
    End Sub
    Private Sub txtClient__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtStudent._MYValidating
        Dim qry As String = "select CLIENT_CODE as Code,CLIENT_DESCRIPTION as Name from TSPL_CLIENT_MASTER "
        Dim WhrCls As String = String.Empty
        txtStudent.Value = clsCommon.ShowSelectForm("Clit@Type", qry, "Code", WhrCls, txtStudent.Value, "Code", isButtonClicked)
        lblStudent.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE='" + txtStudent.Value + "'"))
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        reset()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            SaveData()
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Sub SaveData()
        Try
            If AllowToSave() Then
                Dim obj As New clsCreateExe()
                obj.Client_Code = txtStudent.Value
                obj.Version_No = txtCompany.Text
                obj.Doc_Date = txtFromDate.Value

                obj.Arr = New List(Of clsCreateExeDetail)
                For Each grow As GridViewRowInfo In gv.Rows
                    Dim objTr As New clsCreateExeDetail()
                    objTr.TicketNo = clsCommon.myCstr(grow.Cells(1).Value)
                    objTr.Status = clsCommon.myCBool(grow.Cells(0).Value)
                    If (clsCommon.myLen(objTr.TicketNo) > 0) Then
                        obj.Arr.Add(objTr)
                    End If
                Next
                Dim isSaved As Boolean = True
                isSaved = isSaved AndAlso clsCreateExe.SaveData(obj, isNewEntry)
                txtCode.Value = obj.DocNo
                LoadData(txtCode.Value, NavigatorType.Current)
                If isSaved = True Then
                    clsCommon.MyMessageBoxShow("Data Saved", Me.Text)
                End If
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs)
        SelectAll(True)
    End Sub

    Private Sub btnUnselect_Click_1(sender As Object, e As EventArgs)
        UnselectAll()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If myMessages.deleteConfirm() Then
            deleteData()
        End If
    End Sub

    Sub deleteData()
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            If clsCommon.myLen(txtCode.Value) > 0 Then

                If clsCreateExe.deleteData(txtCode.Value, trans) Then
                    myMessages.delete()
                    trans.Commit()
                    reset()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a Code to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub
End Class
