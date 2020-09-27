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

Public Class FrmTicketMaster
    Inherits FrmMainTranScreen
    'Const colTicketNo As String = "Ticket No"
    'Const colTicketDescription As String = "Ticket Description"
    'Const colClientCode As String = "Client Code"
    'Const colClientName As String = "Client Name"
    'Const colScreenCode As String = "Screen Code"
    'Const colScreenName As String = "Screen Name"
    'Const colModuleCode As String = "Module Code"
    'Const colModuleName As String = "Module Name"
    'Const colProjectCode As String = "Project Code"
    'Const colProjectName As String = "Project Name"
    'Const colTicketStatus As String = "Ticket Status"
    'Const colTicketType As String = "Ticket Type"
    'Const colDataErrorType As String = "Data Error Type"
    'Const colSeverity As String = "Severity"
    'Const colPriority As String = "Priority"

    'Const colRequestNo As String = "Request No"
    'Const colRequestDate As String = "Request Date"
    'Const colAnalysisNo As String = "Analysis No"
    'Const colAnalysisDate As String = "Analysis Date"
    Dim frmHeading As String = ""
    Public isNewEntry As Boolean = False


    Private Sub FrmTicketMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'txtFromDate.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        'txtToDate.Text = clsCommon.GETSERVERDATE
        txtToDate.Text = clsCommon.GETSERVERDATE
        txtFromDate.Value = txtToDate.Value.AddMonths(-1)
        frmHeading = Me.Text

        If clsCommon.CompairString(frmHeading, "Ticket Allocation") = CompairStringResult.Equal Or clsCommon.CompairString(frmHeading, "Time Sheet") = CompairStringResult.Equal Then
            btnAddNew.Visible = False
        Else
            btnAddNew.Visible = True
        End If
        LoadData(True)
    End Sub
    Public Function CalculateTotalTime(ByVal TimeColumn As String) As String
        Dim strTotalTime As Double = 0.0
        Dim sss As String = gv.MasterView.Rows.Count

        If gv.MasterView.Rows.Count > 0 Then
            For value As Integer = 0 To gv.MasterView.Rows.Count - 1
                strTotalTime = strTotalTime + clsCommon.myCdbl(gv.MasterView.Rows(value).Cells("" + TimeColumn + "").Value)
            Next
        End If
        'For Each grow As GridViewRowInfo In gv.Rows
        '    strTotalTime = strTotalTime + clsCommon.myCdbl(grow.Cells("" + TimeColumn + "").Value)
        'Next
        Dim totalTime As String = strTotalTime
        If clsCommon.myLen(totalTime) > 0 Then
            Dim strArr() As String
            strArr = totalTime.Split(".")
            Dim strConvertHourToMinute As Double = clsCommon.myCdbl(strArr(0)) * 60
            Dim finalMinute As Double = 0.0
            If strArr.Count = 2 Then 'totalTime.Contains(".") = True And 
                finalMinute = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
            Else
                finalMinute = strConvertHourToMinute
            End If
            'Dim finalMinute As Double = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
            Dim Duration = New TimeSpan(0, finalMinute, 0)
            Dim Day = Duration.Days * 24
            Dim Hours = Duration.Hours + Day
            Dim Minutes = Duration.Minutes
            Dim strTotalAmount As String = clsCommon.myCstr(Hours) + "." + clsCommon.myCstr(Minutes)

            Return strTotalAmount
        End If
        Return ""
    End Function
    Sub AllCalculateTotalTime()
        lblTotalAllocatdTime.Text = FormatNumber(CDbl(CalculateTotalTime("ALLOCATED_TIME")), 2)
        lblDevelopmentTime.Text = FormatNumber(CDbl(CalculateTotalTime("DEVELOPMENT_TIME")), 2)
        lblTestingTime.Text = FormatNumber(CDbl(CalculateTotalTime("TESTING_TIME")), 2)
        lblTotalActuralTestingTime.Text = FormatNumber(CDbl(CalculateTotalTime("ACTUAL_TESTING_TIME")), 2)
    End Sub
    'Sub TotalAllocatedTime()
    '    If gv.Rows.Count > 0 Then
    '        Dim strTotalTime As Double = 0.0
    '        For Each grow As GridViewRowInfo In gv.Rows
    '            strTotalTime = strTotalTime + clsCommon.myCdbl(grow.Cells("ALLOCATED_TIME").Value)
    '        Next
    '        Dim totalTime As String = strTotalTime
    '        Dim strArr() As String
    '        strArr = totalTime.Split(".")
    '        Dim strConvertHourToMinute As Double = clsCommon.myCdbl(strArr(0)) * 60
    '        Dim finalMinute As Double = strConvertHourToMinute + clsCommon.myCdbl(strArr(1))
    '        Dim Duration = New TimeSpan(0, finalMinute, 0)
    '        Dim Hours = Duration.Hours
    '        Dim Minutes = Duration.Minutes
    '        lblTotalAllocatdTime.Text = clsCommon.myCstr(Hours) + "." + clsCommon.myCstr(Minutes)
    '    End If
    'End Sub

    'Sub LoadBlankGrid()

    '    gv.Rows.Clear()
    '    gv.Columns.Clear()

    '    Dim Ticket_No As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Ticket_No.FormatString = ""
    '    Ticket_No.HeaderText = "Ticket No"
    '    Ticket_No.Name = colTicketNo
    '    Ticket_No.Width = 150
    '    Ticket_No.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Ticket_No)

    '    Dim Ticket_Description As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Ticket_Description.FormatString = ""
    '    Ticket_Description.HeaderText = "Ticket Description"
    '    Ticket_Description.Name = colTicketDescription
    '    Ticket_Description.Width = 150
    '    Ticket_Description.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Ticket_Description)

    '    Dim Client_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Client_Code.FormatString = ""
    '    Client_Code.HeaderText = "Client Code"
    '    Client_Code.Name = colClientCode
    '    Client_Code.Width = 150
    '    Client_Code.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Client_Code)

    '    Dim Client_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Client_Name.FormatString = ""
    '    Client_Name.HeaderText = "Client Name"
    '    Client_Name.Name = colClientName
    '    Client_Name.Width = 150
    '    Client_Name.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Client_Name)

    '    Dim Screen_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Screen_Code.FormatString = ""
    '    Screen_Code.HeaderText = "Screen Code"
    '    Screen_Code.Name = colScreenCode
    '    Screen_Code.Width = 150
    '    Screen_Code.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Screen_Code)

    '    Dim Screen_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Screen_Name.FormatString = ""
    '    Screen_Name.HeaderText = "Screen Name"
    '    Screen_Name.Name = colScreenName
    '    Screen_Name.Width = 150
    '    Screen_Name.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Screen_Name)

    '    Dim Module_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Module_Code.FormatString = ""
    '    Module_Code.HeaderText = "Module Code"
    '    Module_Code.Name = colModuleCode
    '    Module_Code.Width = 150
    '    Module_Code.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Module_Code)

    '    Dim Module_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Module_Name.FormatString = ""
    '    Module_Name.HeaderText = "Module Name"
    '    Module_Name.Name = colModuleName
    '    Module_Name.Width = 150
    '    Module_Name.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Module_Name)

    '    'Const colProjectCode As String = "Project Code"

    '    Dim Project_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Project_Code.FormatString = ""
    '    Project_Code.HeaderText = "Project Code"
    '    Project_Code.Name = colProjectCode
    '    Project_Code.Width = 150
    '    Project_Code.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Project_Code)

    '    'Const colProjectName As String = "Project Name"

    '    Dim Project_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Project_Name.FormatString = ""
    '    Project_Name.HeaderText = "Project Name"
    '    Project_Name.Name = colProjectName
    '    Project_Name.Width = 150
    '    Project_Name.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Project_Name)

    '    'Const colTicketStatus As String = "Ticket Status"

    '    Dim Ticket_Status As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Ticket_Status.FormatString = ""
    '    Ticket_Status.HeaderText = "Ticket Status"
    '    Ticket_Status.Name = colTicketStatus
    '    Ticket_Status.Width = 150
    '    Ticket_Status.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Ticket_Status)


    '    'Const colTicketType As String = "Ticket Type"

    '    Dim Ticket_Type As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Ticket_Type.FormatString = ""
    '    Ticket_Type.HeaderText = "Ticket Type"
    '    Ticket_Type.Name = colTicketType
    '    Ticket_Type.Width = 150
    '    Ticket_Type.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Ticket_Type)


    '    'Const colDataErrorType As String = "Data Error Type"

    '    Dim Data_Error_Type As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Data_Error_Type.FormatString = ""
    '    Data_Error_Type.HeaderText = "Data Error Type"
    '    Data_Error_Type.Name = colDataErrorType
    '    Data_Error_Type.Width = 150
    '    Data_Error_Type.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Data_Error_Type)

    '    'Const colSeverity As String = "Severity"
    '    Dim strSeverity As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    strSeverity.FormatString = ""
    '    strSeverity.HeaderText = "Severity"
    '    strSeverity.Name = colSeverity
    '    strSeverity.Width = 150
    '    strSeverity.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(strSeverity)


    '    'Const colPriority As String = "Priority"

    '    Dim strPriority As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    strPriority.FormatString = ""
    '    strPriority.HeaderText = "Priority"
    '    strPriority.Name = colPriority
    '    strPriority.Width = 150
    '    strPriority.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(strPriority)

    '    'Const colRequestNo As String = "Request No"

    '    Dim Request_No As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Request_No.FormatString = ""
    '    Request_No.HeaderText = "Request No"
    '    Request_No.Name = colRequestNo
    '    Request_No.Width = 150
    '    Request_No.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Request_No)

    '    'Const colRequestDate As String = "Request Date"

    '    Dim Request_Date As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Request_Date.FormatString = ""
    '    Request_Date.HeaderText = "Request Date"
    '    Request_Date.Name = colRequestDate
    '    Request_Date.Width = 150
    '    Request_Date.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Request_Date)


    '    'Const colAnalysisNo As String = "Analysis No"
    '    Dim Analysis_No As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Analysis_No.FormatString = ""
    '    Analysis_No.HeaderText = "Analysis No"
    '    Analysis_No.Name = colAnalysisNo
    '    Analysis_No.Width = 150
    '    Analysis_No.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Analysis_No)

    '    'Const colAnalysisDate As String = "Analysis Date"

    '    Dim Analysis_Date As GridViewTextBoxColumn = New GridViewTextBoxColumn()
    '    Analysis_Date.FormatString = ""
    '    Analysis_Date.HeaderText = "Analysis Date"
    '    Analysis_Date.Name = colAnalysisDate
    '    Analysis_Date.Width = 150
    '    Analysis_Date.ReadOnly = True
    '    gv.MasterTemplate.Columns.Add(Analysis_Date)


    '    gv.AllowAddNewRow = False
    '    gv.ShowGroupPanel = False
    '    gv.AllowColumnReorder = False
    '    gv.AllowRowReorder = False
    '    gv.EnableSorting = False
    '    gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
    '    gv.MasterTemplate.ShowRowHeaderColumn = False
    'End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'Dim frm1 As RadForm = New FrmTicketMasterNewEntry()
        'frm1.StartPosition = FormStartPosition.CenterScreen
        'frm1.MaximizeBox = False
        'frm1.MinimizeBox = False
        'frm1.ControlBox = False
        'frm1.ShowDialog()
        isNewEntry = True
        OpenForm()
    End Sub
    Sub OpenForm()
        Dim frm1 As RadForm = New FrmTicketMasterNewEntry()
        frm1.StartPosition = FormStartPosition.CenterScreen
        frm1.MaximizeBox = False
        frm1.MinimizeBox = False
        frm1.ControlBox = False
        frm1.Owner = Me
        'objCommonVar.CurrentTicketOrAllocationScreen = frmHeading
        frm1.ShowDialog()
    End Sub


    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        LoadData(False)
    End Sub

    Sub LoadData(ByVal isLoadData As Boolean)
        Try
            Dim fromdate As String = clsCommon.GetPrintDate(txtFromDate.Value, "dd/MMM/yyyy") 'change in date format Monika
            Dim todate As String = clsCommon.GetPrintDate(txtToDate.Value, "dd/MMM/yyyy")
            Dim whre As String = " and 2=2 "
            If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                whre = whre + " and TSPL_TICKET_MASTER.DEVELOPER_CODE = '" + objCommonVar.CurrentUserCode + "' and TSPL_TICKET_MASTER.TICKET_STATUS in ( 'Allocated', 'WIP','Fixed' ) "
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Or clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
                whre = whre + " and TSPL_TICKET_MASTER.TESTER_CODE = '" + objCommonVar.CurrentUserCode + "' and TSPL_TICKET_MASTER.TICKET_STATUS in ( 'Fixed','Pending') "
                ' ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
                'dsfsfsdfds
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then
                If clsCommon.CompairString(frmHeading, "Ticket Allocation") = CompairStringResult.Equal Then
                    ' whre = whre + " and  TSPL_TICKET_MASTER.TICKET_STATUS in ('Open') "
                End If
            ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
                whre = whre + " and TSPL_TICKET_MASTER.CLIENT_CODE = '" + objCommonVar.CurrentClientCode + "' and TSPL_TICKET_MASTER.TICKET_STATUS in ('Closed') " '
            End If
            Dim qry As String = "  select TSPL_TICKET_MASTER.TICKET_NO,convert(varchar, TSPL_TICKET_MASTER.TICKET_DATE,103) as TICKET_DATE,isnull(TSPL_TICKET_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_TICKET_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_TICKET_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_TICKET_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_TICKET_MASTER.TICKET_STATUS,'') as TICKET_STATUS ,isnull(TSPL_TICKET_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_TICKET_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_TICKET_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name,isnull( TSPL_TICKET_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_TICKET_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_TICKET_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_TICKET_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_TICKET_MASTER.TICKET_DESCRIPTION,'') as TICKET_DESCRIPTION ,isnull(TSPL_TICKET_MASTER.ALLOCATION_REMARKS,'') as ALLOCATION_REMARKS, case when TSPL_TICKET_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_TICKET_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_TICKET_MASTER.DEVELOPER_REMARKS,'') as DEVELOPER_REMARKS,isnull(TSPL_TICKET_MASTER.DEVELOPMENT_TIME,'') as DEVELOPMENT_TIME ,isnull(TSPL_TICKET_MASTER.TESTER_REMARKS,'') as TESTER_REMARKS,isnull(TSPL_TICKET_MASTER.TESTING_TIME,'') as TESTING_TIME ,isnull(TSPL_TICKET_MASTER.ACTUAL_TESTING_TIME,'') as ACTUAL_TESTING_TIME,isnull(TSPL_TICKET_MASTER.REQUEST_NO,'') as REQUEST_NO, case when TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE is null then '' else  convert (varchar,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) end as REQUEST_DATE,TSPL_REQUEST_CREATION_MASTER.Created_By as REQUEST_BY, isnull(TSPL_TICKET_MASTER.ANALYSIS_NO,'') as ANALYSIS_NO ,case when TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE is null then '' else   convert (varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) end as  ANALYSIS_DATE ,isnull (TSPL_REQUEST_ANALYSIS_MASTER.Created_By,'') as ANALYSIS_BY ,isnull( TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION,'') as DEVELOPMENT_EXE_VERSION ,isnull(TSPL_TICKET_MASTER.TESTING_EXE_VERSION,'') as TESTING_EXE_VERSION from TSPL_TICKET_MASTER  left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_TICKET_MASTER.CLIENT_CODE  left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_TICKET_MASTER.SCREEN_CODE  left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_TICKET_MASTER.MODULE_CODE  left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_TICKET_MASTER.PROJECT_CODE  left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE  left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_TICKET_MASTER.TESTER_CODE  left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_TICKET_MASTER.Created_By left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = TSPL_TICKET_MASTER.REQUEST_NO  left outer join TSPL_REQUEST_ANALYSIS_MASTER on TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO = TSPL_TICKET_MASTER.ANALYSIS_NO " & _
                                " where convert(date,TSPL_TICKET_MASTER.TICKET_DATE,103) > = '" + fromdate + "' and convert(date,TSPL_TICKET_MASTER.TICKET_DATE,103) <='" + todate + "'  " + whre + " order by convert(date, TSPL_TICKET_MASTER.TICKET_DATE,103) desc "

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
                lblTotalAllocatdTime.Text = ""
                lblDevelopmentTime.Text = ""
                lblTestingTime.Text = ""
                Exit Sub
            End If
            gv.DataSource = dt
            SetGridFormationOFgv()

            AllCalculateTotalTime()
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
        '  select TSPL_TICKET_MASTER.TICKET_NO,convert(varchar, TSPL_TICKET_MASTER.TICKET_DATE,103) as TICKET_DATE,
        'isnull(TSPL_TICKET_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,
        'isNull(TSPL_TICKET_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name,

        gv.Columns("TICKET_NO").IsVisible = True
        gv.Columns("TICKET_NO").Width = 130
        gv.Columns("TICKET_NO").HeaderText = "TICKET NO"

        gv.Columns("TICKET_DATE").IsVisible = True
        gv.Columns("TICKET_DATE").Width = 100
        gv.Columns("TICKET_DATE").HeaderText = "TICKET DATE"

        gv.Columns("TICKET_TYPE").IsVisible = True
        gv.Columns("TICKET_TYPE").Width = 100
        gv.Columns("TICKET_TYPE").HeaderText = "TICKET TYPE"

        gv.Columns("TICKET_STATUS").IsVisible = True
        gv.Columns("TICKET_STATUS").Width = 130
        gv.Columns("TICKET_STATUS").HeaderText = "TICKET STATUS"


        gv.Columns("CLIENT_CODE").IsVisible = True
        gv.Columns("CLIENT_CODE").Width = 100
        gv.Columns("CLIENT_CODE").HeaderText = "CLIENT CODE"

        gv.Columns("Client_Name").IsVisible = True
        gv.Columns("Client_Name").Width = 100
        gv.Columns("Client_Name").HeaderText = "CLIENT NAME"

        gv.Columns("SCREEN_CODE").IsVisible = True
        gv.Columns("SCREEN_CODE").Width = 100
        gv.Columns("SCREEN_CODE").HeaderText = "SCREEN CODE"

        gv.Columns("Screen_Name").IsVisible = True
        gv.Columns("Screen_Name").Width = 100
        gv.Columns("Screen_Name").HeaderText = "SCREEN NAME"

        ' isnull(TSPL_TICKET_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,
        'isnull(TSPL_TICKET_MASTER .PROJECT_CODE,'') as PROJECT_CODE,
        'isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,


        gv.Columns("MODULE_CODE").IsVisible = True
        gv.Columns("MODULE_CODE").Width = 100
        gv.Columns("MODULE_CODE").HeaderText = "MODULE CODE"


        gv.Columns("MODULE_NAME").IsVisible = True
        gv.Columns("MODULE_NAME").Width = 100
        gv.Columns("MODULE_NAME").HeaderText = "MODULE NAME"

        gv.Columns("PROJECT_CODE").IsVisible = True
        gv.Columns("PROJECT_CODE").Width = 100
        gv.Columns("PROJECT_CODE").HeaderText = "PROJECT CODE"


        gv.Columns("PROJECT_NAME").IsVisible = True
        gv.Columns("PROJECT_NAME").Width = 130
        gv.Columns("PROJECT_NAME").HeaderText = "PROJECT NAME"

        'isnull(TSPL_TICKET_MASTER.TICKET_STATUS,'') as TICKET_STATUS 

        ',isnull(TSPL_TICKET_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,

        'isnull(TSPL_TICKET_MASTER.TESTER_CODE,'') as TESTER_CODE,

        gv.Columns("DATA_ERROR_TYPE").IsVisible = True
        gv.Columns("DATA_ERROR_TYPE").Width = 140
        gv.Columns("DATA_ERROR_TYPE").HeaderText = "DATA ERROR TYPE"

        gv.Columns("SEVERITY").IsVisible = True
        gv.Columns("SEVERITY").Width = 100
        gv.Columns("SEVERITY").HeaderText = "SEVERITY"

        gv.Columns("PRIORITY").IsVisible = True
        gv.Columns("PRIORITY").Width = 100
        gv.Columns("PRIORITY").HeaderText = "PRIORITY"

        gv.Columns("Created_By_Code").IsVisible = True
        gv.Columns("Created_By_Code").Width = 140
        gv.Columns("Created_By_Code").HeaderText = "CREATED BY CODE"

        gv.Columns("Created_By_Name").IsVisible = True
        gv.Columns("Created_By_Name").Width = 140
        gv.Columns("Created_By_Name").HeaderText = "CREATED BY NAME"

        gv.Columns("ALLOCATED_TIME").IsVisible = True
        gv.Columns("ALLOCATED_TIME").Width = 70
        gv.Columns("ALLOCATED_TIME").HeaderText = "ALLOCATED TIME"
        

        gv.Columns("DEVELOPER_CODE").IsVisible = True
        gv.Columns("DEVELOPER_CODE").Width = 120
        gv.Columns("DEVELOPER_CODE").HeaderText = "DEVELOPER CODE"

        gv.Columns("Developer_Name").IsVisible = True
        gv.Columns("Developer_Name").Width = 120
        gv.Columns("Developer_Name").HeaderText = "DEVELOPER NAME"

        gv.Columns("DEVELOPMENT_TIME").IsVisible = True
        gv.Columns("DEVELOPMENT_TIME").Width = 130
        gv.Columns("DEVELOPMENT_TIME").HeaderText = "DEVELOPMENT TIME"

        gv.Columns("TESTER_CODE").IsVisible = True
        gv.Columns("TESTER_CODE").Width = 100
        gv.Columns("TESTER_CODE").HeaderText = "TESTER CODE"

        gv.Columns("Tester_Name").IsVisible = True
        gv.Columns("Tester_Name").Width = 100
        gv.Columns("Tester_Name").HeaderText = "TESTER NAME"

        gv.Columns("TESTING_TIME").IsVisible = True
        gv.Columns("TESTING_TIME").Width = 130
        gv.Columns("TESTING_TIME").HeaderText = "ALLOCATED TESTING TIME"

        gv.Columns("REQUEST_NO").IsVisible = True
        gv.Columns("REQUEST_NO").Width = 100
        gv.Columns("REQUEST_NO").HeaderText = "REQUEST NO"

        gv.Columns("REQUEST_DATE").IsVisible = True
        gv.Columns("REQUEST_DATE").Width = 70
        gv.Columns("REQUEST_DATE").HeaderText = "REQUEST DATE"

        gv.Columns("REQUEST_BY").IsVisible = True
        gv.Columns("REQUEST_BY").Width = 70
        gv.Columns("REQUEST_BY").HeaderText = "REQUEST BY"

        gv.Columns("ANALYSIS_NO").IsVisible = True
        gv.Columns("ANALYSIS_NO").Width = 100
        gv.Columns("ANALYSIS_NO").HeaderText = "ANALYSIS NO"

        gv.Columns("ANALYSIS_DATE").IsVisible = True
        gv.Columns("ANALYSIS_DATE").Width = 100
        gv.Columns("ANALYSIS_DATE").HeaderText = "ANALYSIS DATE"

        gv.Columns("ANALYSIS_BY").IsVisible = True
        gv.Columns("ANALYSIS_BY").Width = 100
        gv.Columns("ANALYSIS_BY").HeaderText = "ANALYSIS BY"

        gv.Columns("TICKET_DESCRIPTION").IsVisible = True
        gv.Columns("TICKET_DESCRIPTION").Width = 200
        gv.Columns("TICKET_DESCRIPTION").HeaderText = "TICKET DESCRIPTION"

        gv.Columns("ALLOCATION_REMARKS").IsVisible = True
        gv.Columns("ALLOCATION_REMARKS").Width = 200
        gv.Columns("ALLOCATION_REMARKS").HeaderText = "ALLOCATION REMARKS"

        gv.Columns("ALLOCATION_REMARKS").IsVisible = True
        gv.Columns("ALLOCATION_REMARKS").Width = 200
        gv.Columns("ALLOCATION_REMARKS").HeaderText = "ALLOCATION REMARKS"

        gv.Columns("DEVELOPER_REMARKS").IsVisible = True
        gv.Columns("DEVELOPER_REMARKS").Width = 200
        gv.Columns("DEVELOPER_REMARKS").HeaderText = "DEVELOPER REMARKS"

        gv.Columns("TESTER_REMARKS").IsVisible = True
        gv.Columns("TESTER_REMARKS").Width = 200
        gv.Columns("TESTER_REMARKS").HeaderText = "TESTER REMARKS"

        gv.Columns("DEVELOPMENT_EXE_VERSION").IsVisible = True
        gv.Columns("DEVELOPMENT_EXE_VERSION").Width = 200
        gv.Columns("DEVELOPMENT_EXE_VERSION").HeaderText = "DEVELOPMENT EXE VERSION"

        gv.Columns("TESTING_EXE_VERSION").IsVisible = True
        gv.Columns("TESTING_EXE_VERSION").Width = 200
        gv.Columns("TESTING_EXE_VERSION").HeaderText = "TESTING EXE VERSION"

        gv.Columns("ACTUAL_TESTING_TIME").IsVisible = True
        gv.Columns("ACTUAL_TESTING_TIME").Width = 200
        gv.Columns("ACTUAL_TESTING_TIME").HeaderText = "ACTUAL TESTING TIME"
    End Sub

    Private Sub gv_DoubleClick(sender As Object, e As EventArgs) Handles gv.DoubleClick
        'Try
        '    If gv.Rows.Count > 0 Then
        '        Dim strDoc As String = Nothing
        '        strDoc = gv.CurrentRow.Cells("TICKET_NO").Value
        '        If clsCommon.myLen(strDoc) > 0 Then
        '            objCommonVar.CurrentTicketNo = strDoc
        '            'objCommonVar.CurrentTicketOrAllocationScreen = frmHeading
        '            OpenForm()
        '        End If
        '    End If
        'Catch ex As Exception
        '    clsCommon.MyMessageBoxShow(ex.Message)
        'End Try
        isNewEntry = False
        Try
            If gv.Rows.Count > 0 Then
                OpenForm()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub gv_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles gv.CellValueChanged
        AllCalculateTotalTime()
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    
End Class
