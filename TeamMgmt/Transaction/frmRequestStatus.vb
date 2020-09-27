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

Public Class FrmRequestStatus
    Inherits FrmMainTranScreen
#Region "Variables"
    Const colRequestNo As String = "COLL_REQUEST_NO"
    Const colRequestDate As String = "COLL_REQUEST_DATE"
    Const colRequestDesc As String = "COL_REQUEST_DESC"
    Const colAnalysisNo As String = "COL_ANALYSIS_NO"
    Const colAnalysisDate As String = "COL_ANALYSIS_DATE"
    Const colAnalysisDesc As String = "COL_ANALYSIS_DESC"
    Const colClientCode As String = "COL_CLIENT_CODE"
    Const colClientName As String = "COL_CLIENT_NAME"
    Const colScreenName As String = "COL_SCREEN_NAME"
    Const colModuleName As String = "COL_MODULE_NAME"
    Const colProjectName As String = "COL_PROJECT_NAME"
    Const colCreatedBy As String = "COL_CREATED_BY"
    Const colTicketNo As String = "COL_TICKET_NO"
    Const colTicketType As String = "COL_TICKET_TYPE"
    Const colDataErrorType As String = "COL_DATA_ERROR_TYPE"
    Const colSeverity As String = "COL_SEVERITY"
    Const colPriority As String = "COL_PRIORITY"
    Const colAllocatedTime As String = "COL_ALLOCATED_TIME"
    Const colPendingRemarks As String = "COL_PENDING_REMARKS"
    Const colTicketStatus As String = "COL_TICKET_STATUS"
    Const colRequestStatus As String = "COL_REQUEST_STATus"


#End Region
    

    Private Sub FrmRequestStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.SetUserMgmt(clsUserMgtCode.frmRequestStatus)
        txtToDate.Text = clsCommon.GETSERVERDATE
        txtFromDate.Value = txtToDate.Value.AddMonths(-1)
        LoadData(True)
        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub

    'Sub SetGridFormationOFgv()
    '    gv.TableElement.TableHeaderHeight = 40
    '    gv.MasterTemplate.ShowRowHeaderColumn = False
    '    For ii As Integer = 0 To gv.Columns.Count - 1
    '        gv.Columns(ii).ReadOnly = True
    '        gv.Columns(ii).IsVisible = False
    '    Next
    '    gv.Columns("REQUEST_ANALYSIS_NO").IsVisible = True
    '    gv.Columns("REQUEST_ANALYSIS_NO").Width = 130
    '    gv.Columns("REQUEST_ANALYSIS_NO").HeaderText = "ANALYSIS NO"

    '    gv.Columns("REQUEST_ANALYSIS_DATE").IsVisible = True
    '    gv.Columns("REQUEST_ANALYSIS_DATE").Width = 130
    '    gv.Columns("REQUEST_ANALYSIS_DATE").HeaderText = "ANALYSIS DATE"

    '    gv.Columns("ANALYSIS_DESCRIPTION").IsVisible = True
    '    gv.Columns("ANALYSIS_DESCRIPTION").Width = 250
    '    gv.Columns("ANALYSIS_DESCRIPTION").HeaderText = "ANALYSIS DESCRIPTION"

    '    gv.Columns("ANALYSIS_STATUS").IsVisible = True
    '    gv.Columns("ANALYSIS_STATUS").Width = 130
    '    gv.Columns("ANALYSIS_STATUS").HeaderText = "ANALYSIS STATUS"

    '    gv.Columns("REQUEST_NO").IsVisible = True
    '    gv.Columns("REQUEST_NO").Width = 130
    '    gv.Columns("REQUEST_NO").HeaderText = "REQUEST NO"

    '    gv.Columns("REQUEST_DATE").IsVisible = True
    '    gv.Columns("REQUEST_DATE").Width = 130
    '    gv.Columns("REQUEST_DATE").HeaderText = "REQUEST DATE"

    '    gv.Columns("REQUEST_DESCRIPTION").IsVisible = True
    '    gv.Columns("REQUEST_DESCRIPTION").Width = 130
    '    gv.Columns("REQUEST_DESCRIPTION").HeaderText = "REQUEST DESCRIPTION"

    '    gv.Columns("CLIENT_CODE").IsVisible = True
    '    gv.Columns("CLIENT_CODE").Width = 100
    '    gv.Columns("CLIENT_CODE").HeaderText = "CLIENT CODE"

    '    gv.Columns("Client_Name").IsVisible = True
    '    gv.Columns("Client_Name").Width = 100
    '    gv.Columns("Client_Name").HeaderText = "CLIENT NAME"

    '    gv.Columns("SCREEN_CODE").IsVisible = True
    '    gv.Columns("SCREEN_CODE").Width = 100
    '    gv.Columns("SCREEN_CODE").HeaderText = "SCREEN CODE"

    '    gv.Columns("Screen_Name").IsVisible = True
    '    gv.Columns("Screen_Name").Width = 100
    '    gv.Columns("Screen_Name").HeaderText = "SCREEN NAME"

    '    gv.Columns("MODULE_CODE").IsVisible = True
    '    gv.Columns("MODULE_CODE").Width = 100
    '    gv.Columns("MODULE_CODE").HeaderText = "MODULE CODE"


    '    gv.Columns("MODULE_NAME").IsVisible = True
    '    gv.Columns("MODULE_NAME").Width = 100
    '    gv.Columns("MODULE_NAME").HeaderText = "MODULE NAME"

    '    gv.Columns("PROJECT_CODE").IsVisible = True
    '    gv.Columns("PROJECT_CODE").Width = 100
    '    gv.Columns("PROJECT_CODE").HeaderText = "PROJECT CODE"


    '    gv.Columns("PROJECT_NAME").IsVisible = True
    '    gv.Columns("PROJECT_NAME").Width = 130
    '    gv.Columns("PROJECT_NAME").HeaderText = "PROJECT NAME"




    '    gv.Columns("TICKET_NO").IsVisible = True
    '    gv.Columns("TICKET_NO").Width = 130
    '    gv.Columns("TICKET_NO").HeaderText = "TICKET NO"

    '    gv.Columns("DEVELOPER_CODE").IsVisible = False
    '    gv.Columns("DEVELOPER_CODE").Width = 120
    '    gv.Columns("DEVELOPER_CODE").HeaderText = "DEVELOPER CODE"

    '    gv.Columns("Developer_Name").IsVisible = False
    '    gv.Columns("Developer_Name").Width = 120
    '    gv.Columns("Developer_Name").HeaderText = "DEVELOPER NAME"

    '    gv.Columns("TESTER_CODE").IsVisible = False
    '    gv.Columns("TESTER_CODE").Width = 100
    '    gv.Columns("TESTER_CODE").HeaderText = "TESTER CODE"



    '    gv.Columns("Tester_Name").IsVisible = False
    '    gv.Columns("Tester_Name").Width = 100
    '    gv.Columns("Tester_Name").HeaderText = "TESTER NAME"

    '    gv.Columns("Created_By_Code").IsVisible = True
    '    gv.Columns("Created_By_Code").Width = 140
    '    gv.Columns("Created_By_Code").HeaderText = "CREATED BY CODE"



    '    gv.Columns("Created_By_Name").IsVisible = True
    '    gv.Columns("Created_By_Name").Width = 140
    '    gv.Columns("Created_By_Name").HeaderText = "CREATED BY NAME"

    '    gv.Columns("TICKET_TYPE").IsVisible = True
    '    gv.Columns("TICKET_TYPE").Width = 100
    '    gv.Columns("TICKET_TYPE").HeaderText = "TICKET TYPE"

    '    gv.Columns("DATA_ERROR_TYPE").IsVisible = True
    '    gv.Columns("DATA_ERROR_TYPE").Width = 140
    '    gv.Columns("DATA_ERROR_TYPE").HeaderText = "DATA ERROR TYPE"

    '    'SEVERITY,PRIORITY,ALLOCATED_TIME,PENDING_REMARKS,Ticket_Status

    '    gv.Columns("SEVERITY").IsVisible = True
    '    gv.Columns("SEVERITY").Width = 100
    '    gv.Columns("SEVERITY").HeaderText = "SEVERITY"

    '    gv.Columns("PRIORITY").IsVisible = True
    '    gv.Columns("PRIORITY").Width = 100
    '    gv.Columns("PRIORITY").HeaderText = "PRIORITY"

    '    gv.Columns("ALLOCATED_TIME").IsVisible = True
    '    gv.Columns("ALLOCATED_TIME").Width = 70
    '    gv.Columns("ALLOCATED_TIME").HeaderText = "ALLOCATED TIME"

    '    gv.Columns("PENDING_REMARKS").IsVisible = True
    '    gv.Columns("PENDING_REMARKS").Width = 120
    '    gv.Columns("PENDING_REMARKS").HeaderText = "PENDING REMARKS"

    '    gv.Columns("Ticket_Status").IsVisible = True
    '    gv.Columns("Ticket_Status").Width = 120
    '    gv.Columns("Ticket_Status").HeaderText = "TICKET STATUS"

    '    gv.EnableGrouping = False
    'End Sub

    Sub LoadBlankGrid()
        gv.Rows.Clear()
        gv.Columns.Clear()


        Dim repoColumn As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "REQUEST NO"
        repoColumn.Name = colRequestNo
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "REQUEST DATE"
        repoColumn.Name = colRequestDate
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        'Const colRequestDesc As String = "COL_REQUEST_DESC"
        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "REQUEST DESC"
        repoColumn.Name = colRequestDesc
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)


        ' Const colAnalysisNo As String = "COL_ANALYSIS_NO"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "ANALYSIS NO"
        repoColumn.Name = colAnalysisNo
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        ' Const colAnalysisDate As String = "COL_ANALYSIS_DATE"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "ANALYSIS DATE"
        repoColumn.Name = colAnalysisDate
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        'Const colAnalysisDesc As String = "COL_ANALYSIS_DESC"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "ANALYSIS DESC"
        repoColumn.Name = colAnalysisDesc
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        'Const colClientName As String = "COL_CLIENT_NAME"
        'colClientCode
        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "CLIENT CODE"
        repoColumn.Name = colClientCode
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "CLIENT NAME"
        repoColumn.Name = colClientName
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)


        ' Const colScreenName As String = "COL_SCREEN_NAME"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "SCREEN NAME"
        repoColumn.Name = colScreenName
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)



        ' Const colModuleName As String = "COL_MODULE_NAME"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "MODULE NAME"
        repoColumn.Name = colModuleName
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)


        'Const colProjectName As String = "COL_PROJECT_NAME"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "PROJECT NAME"
        repoColumn.Name = colProjectName
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)


        'Const colCreatedBy As String = "COL_CREATED_BY"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "CREATED BY"
        repoColumn.Name = colCreatedBy
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        'Const colTicketNo As String = "COL_TICKET_NO"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "TICKET NO"
        repoColumn.Name = colTicketNo
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "TICKET STATUS"
        repoColumn.Name = colTicketStatus
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        'Const colTicketType As String = "COL_TICKET_TYPE"
        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "TICKET TYPE"
        repoColumn.Name = colTicketType
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        ' Const colDataErrorType As String = "COL_DATA_ERROR_TYPE"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "DATA ERROR TYPE"
        repoColumn.Name = colDataErrorType
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)


        'Const colSeverity As String = "COL_SEVERITY"
        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "SEVERITY"
        repoColumn.Name = colSeverity
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)


        'Const colPriority As String = "COL_PRIORITY"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "PRIORITY"
        repoColumn.Name = colPriority
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        ' Const colAllocatedTime As String = "COL_ALLOCATED_TIME"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "ALLOCATED TIME"
        repoColumn.Name = colAllocatedTime
        repoColumn.Width = 150
        repoColumn.ReadOnly = True
        gv.MasterTemplate.Columns.Add(repoColumn)

        ' Const colPendingRemarks As String = "COL_PENDING_REMARKS"

        repoColumn = New GridViewTextBoxColumn()
        repoColumn.FormatString = ""
        repoColumn.HeaderText = "PENDING REMARKS"
        repoColumn.Name = colPendingRemarks
        repoColumn.Width = 300
        repoColumn.ReadOnly = False
        gv.MasterTemplate.Columns.Add(repoColumn)


        'Const colTicketStatus As String = "COL_TICKET_STATUS"
        

        Dim repoRequestStatus As GridViewComboBoxColumn = New GridViewComboBoxColumn()
        repoRequestStatus.FormatString = ""
        repoRequestStatus.HeaderText = "REQUEST STATUS"
        repoRequestStatus.Name = colRequestStatus
        repoRequestStatus.Width = 150
        repoRequestStatus.ReadOnly = False
        repoRequestStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        repoRequestStatus.DataSource = GetRequestStatus()
        repoRequestStatus.ValueMember = "Code"
        repoRequestStatus.DisplayMember = "Code"
        gv.MasterTemplate.Columns.Add(repoRequestStatus)

        gv.AllowAddNewRow = False
        gv.ShowGroupPanel = False
        gv.AllowColumnReorder = False
        gv.AllowRowReorder = False
        gv.EnableSorting = False
        gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv.MasterTemplate.ShowRowHeaderColumn = False

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

    'Analysed
    Sub LoadData(ByVal isLoadData As Boolean)
        Try
            Dim fromdate As String = clsCommon.GetPrintDate(txtFromDate.Value, "dd/MMM/yyyy")
            Dim todate As String = clsCommon.GetPrintDate(txtToDate.Value, "dd/MMM/yyyy")
            Dim whre As String = " and 2=2 and TICKET_STATUS in ('Fixed','Closed') and TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_STATUS in ('Analysed')   and TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE = (select isnull(CLIENT_CODE,'') as CLIENT_CODE  from TSPL_USER_MASTER where USER_CODE = '" + objCommonVar.CurrentUserCode + "') "

            Dim qry As String = " select TSPL_TICKET_MASTER.TICKET_STATUS, isnull(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO,'') as REQUEST_NO,case when TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE is null then '' else  convert (varchar,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) end as REQUEST_DATE, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,convert(varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) as REQUEST_ANALYSIS_DATE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_STATUS,'') as ANALYSIS_STATUS ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name,isnull( TSPL_REQUEST_ANALYSIS_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_REQUEST_ANALYSIS_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_REQUEST_ANALYSIS_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_DESCRIPTION,'') as ANALYSIS_DESCRIPTION , case when TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTING_TIME,'') as TESTING_TIME ,  isnull(TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO,'') as TICKET_NO ,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION ,'' as PENDING_REMARKS, '-Select-' as Request_Status from TSPL_REQUEST_ANALYSIS_MASTER   " & _
                                " left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO    " & _
                                " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE    " & _
                                " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE   " & _
                                " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE   " & _
                                " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.PROJECT_CODE " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE  " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE  " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.Created_By   " & _
                                " left outer join TSPL_TICKET_MASTER on TSPL_TICKET_MASTER.TICKET_NO = TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO  " & _
                                " where convert(date,TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) > = '" + fromdate + "' and convert(date,TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) <='" + todate + "'  " + whre + " "

            Dim dt As DataTable = Nothing
            dt = New DataTable()
            dt = clsDBFuncationality.GetDataTable(qry, Nothing)
            gv.DataSource = Nothing
            gv.Columns.Clear()
            gv.Rows.Clear()
            LoadBlankGrid()
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                If isLoadData = False Then
                    common.clsCommon.MyMessageBoxShow("No data found between {" + txtFromDate.Text + "- to -" + txtToDate.Text + "}", Me.Text)
                End If
                Exit Sub
            End If
            '  '' as PENDING_REMARKS, '' as Ticket_Status from TSPL_REQUEST_ANALYSIS_MASTER   " & _
            gv.Rows.Clear()
            gv.DataSource = Nothing
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    gv.Rows.AddNew()
                    gv.Rows(gv.Rows.Count - 1).Cells(colRequestNo).Value = clsCommon.myCstr(dr("REQUEST_NO"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colRequestDate).Value = clsCommon.myCstr(dr("REQUEST_DATE"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colAnalysisNo).Value = clsCommon.myCstr(dr("REQUEST_ANALYSIS_NO"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colAnalysisDate).Value = clsCommon.myCstr(dr("REQUEST_ANALYSIS_DATE"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colClientCode).Value = clsCommon.myCstr(dr("Client_Code"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colClientName).Value = clsCommon.myCstr(dr("Client_Name"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colScreenName).Value = clsCommon.myCstr(dr("Screen_Name"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colModuleName).Value = clsCommon.myCstr(dr("MODULE_NAME"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colProjectName).Value = clsCommon.myCstr(dr("PROJECT_NAME"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colCreatedBy).Value = clsCommon.myCstr(dr("Created_By_Name"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colTicketType).Value = clsCommon.myCstr(dr("TICKET_TYPE"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colTicketNo).Value = clsCommon.myCstr(dr("TICKET_NO"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colTicketStatus).Value = clsCommon.myCstr(dr("TICKET_STATUS"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colDataErrorType).Value = clsCommon.myCstr(dr("DATA_ERROR_TYPE"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colSeverity).Value = clsCommon.myCstr(dr("SEVERITY"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colPriority).Value = clsCommon.myCstr(dr("PRIORITY"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colAllocatedTime).Value = clsCommon.myCstr(dr("ALLOCATED_TIME"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colAnalysisDesc).Value = clsCommon.myCstr(dr("ANALYSIS_DESCRIPTION"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colRequestDesc).Value = clsCommon.myCstr(dr("REQUEST_DESCRIPTION"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colPendingRemarks).Value = clsCommon.myCstr(dr("PENDING_REMARKS"))
                    gv.Rows(gv.Rows.Count - 1).Cells(colRequestStatus).Value = clsCommon.myCstr(dr("Request_Status"))

                Next
            End If

            'gv.DataSource = dt
            'SetGridFormationOFgv()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        LoadData(False)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()

        Dim isSaved As Boolean = False
        Try
            If (AllowToSave()) Then
                If gv.Rows.Count > 0 Then
                    For Each grow As GridViewRowInfo In gv.Rows
                        If clsCommon.CompairString(clsCommon.myCstr(grow.Cells(colRequestStatus).Value), "-Select-") <> CompairStringResult.Equal Then
                            'Dim obj As New clsRequestCreationEntry()
                            'obj.CLIENT_CODE = clsCommon.myCstr(grow.Cells(colClientCode).Value)
                            'obj.REQUEST_NO = clsCommon.myCstr(grow.Cells(colRequestNo).Value)
                            'If clsCommon.CompairString(clsCommon.myCstr(grow.Cells(colRequestStatus).Value), "Pending") = CompairStringResult.Equal Then
                            '    obj.REQUEST_STATUS = "Open"
                            'Else
                            '    obj.REQUEST_STATUS = clsCommon.myCstr(grow.Cells(colRequestStatus).Value)
                            'End If
                            'obj.REQUEST_DESCRIPTION = clsCommon.myCstr(grow.Cells(colRequestDesc).Value)
                            'obj.PENDING_REMARKS = clsCommon.myCstr(grow.Cells(colPendingRemarks).Value)
                            'isSaved = obj.SaveData(obj, False, trans)
                            'Dim objTicketMasterEntery As New clsTicketMasterEntry()
                            'objTicketMasterEntery.TICKET_NO = clsCommon.myCstr(grow.Cells(colTicketNo).Value)
                            'objTicketMasterEntery.TICKET_STATUS = obj.REQUEST_STATUS
                            'isSaved = objTicketMasterEntery.UpdateTicketStatus(objTicketMasterEntery, trans)
                            Dim obj As New clsRequestStatusEntry()
                            obj.REQUEST_NO = clsCommon.myCstr(grow.Cells(colRequestNo).Value)
                            'If clsCommon.CompairString(clsCommon.myCstr(grow.Cells(colRequestStatus).Value), "Pending") = CompairStringResult.Equal Then
                            '    obj.REQUEST_STATUS = "Open"
                            'Else
                            '    obj.REQUEST_STATUS = clsCommon.myCstr(grow.Cells(colRequestStatus).Value)
                            'End If
                            obj.REQUEST_ANALYSIS_NO = clsCommon.myCstr(grow.Cells(colAnalysisNo).Value)
                            obj.REQUEST_STATUS = clsCommon.myCstr(grow.Cells(colRequestStatus).Value)
                            obj.PENDING_REMARKS = clsCommon.myCstr(grow.Cells(colPendingRemarks).Value)
                            obj.TICKET_NO = clsCommon.myCstr(grow.Cells(colTicketNo).Value)
                            obj.TICKET_STATUS = obj.REQUEST_STATUS
                            isSaved = obj.UpdateRequestStatus(obj, trans)
                        End If
                    Next
                End If
                If isSaved = True Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                Else
                    clsCommon.MyMessageBoxShow("Please Select Request Status for Saving Data.", Me.Text)
                End If

                trans.Commit()
                LoadData(True)
            End If
            
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.ToString())
        End Try


    End Sub
    Function AllowToSave() As Boolean
        Try
            If gv.Rows.Count > 0 Then
                For ii As Integer = 0 To gv.Rows.Count - 1
                    Dim strReqNo As String = clsCommon.myCstr(gv.Rows(ii).Cells(colRequestNo).Value)
                    Dim strStatus As String = clsCommon.myCstr(gv.Rows(ii).Cells(colRequestStatus).Value)
                    Dim strPendingRemarks As String = clsCommon.myCstr(gv.Rows(ii).Cells(colPendingRemarks).Value)
                    If clsCommon.CompairString(strStatus, "Pending") = CompairStringResult.Equal Then
                        If clsCommon.myLen(strPendingRemarks) <= 0 Then
                            common.clsCommon.MyMessageBoxShow("Please enter Pending Remarks for Request No  : " + strReqNo)
                            Return False
                        End If
                    End If

                Next
            End If
           
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function

    Sub OpenForm()
        Dim frm1 As RadForm = New FrmRequestStatusEntery()
        frm1.StartPosition = FormStartPosition.CenterScreen
        frm1.MaximizeBox = False
        frm1.MinimizeBox = False
        frm1.ControlBox = False
        frm1.Owner = Me
        frm1.ShowDialog()
    End Sub

    Private Sub gv_DoubleClick(sender As Object, e As EventArgs) Handles gv.DoubleClick
         Try
            If gv.Rows.Count > 0 Then
                OpenForm()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
