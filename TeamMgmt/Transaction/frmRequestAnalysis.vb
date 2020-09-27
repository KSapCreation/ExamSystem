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

Public Class FrmRequestAnalysis
    Inherits FrmMainTranScreen
    Dim frmHeading As String = ""
    Public strClickGrid As String = ""
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        LoadData()
        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub

    Sub SetGridFormationOFgv()
        gv.TableElement.TableHeaderHeight = 40
        gv.MasterTemplate.ShowRowHeaderColumn = False
        For ii As Integer = 0 To gv.Columns.Count - 1
            gv.Columns(ii).ReadOnly = True
            gv.Columns(ii).IsVisible = False
        Next

        'REQUEST_ANALYSIS_NO, REQUEST_ANALYSIS_DATE, ANALYSIS_DESCRIPTION,ANALYSIS_STATUS,REQUEST_NO,REQUEST_DESCRIPTION, CLIENT_CODE, Client_Name,
        'SCREEN_CODE, Screen_Name, Module_Code, MODULE_NAME, PROJECT_CODE, PROJECT_NAME
        'DEVELOPER_CODE, Developer_Name, TESTER_CODE, Tester_Name, Created_By_Code, Created_By_Name, TICKET_TYPE, DATA_ERROR_TYPE, SEVERITY, PRIORITY, ALLOCATED_TIME
        'TESTING_TIME, , TICKET_NO, 

        gv.Columns("REQUEST_ANALYSIS_NO").IsVisible = True
        gv.Columns("REQUEST_ANALYSIS_NO").Width = 130
        gv.Columns("REQUEST_ANALYSIS_NO").HeaderText = "ANALYSIS NO"

        gv.Columns("REQUEST_ANALYSIS_DATE").IsVisible = True
        gv.Columns("REQUEST_ANALYSIS_DATE").Width = 130
        gv.Columns("REQUEST_ANALYSIS_DATE").HeaderText = "ANALYSIS DATE"

        gv.Columns("ANALYSIS_DESCRIPTION").IsVisible = True
        gv.Columns("ANALYSIS_DESCRIPTION").Width = 250
        gv.Columns("ANALYSIS_DESCRIPTION").HeaderText = "ANALYSIS DESCRIPTION"

        gv.Columns("ANALYSIS_STATUS").IsVisible = True
        gv.Columns("ANALYSIS_STATUS").Width = 130
        gv.Columns("ANALYSIS_STATUS").HeaderText = "ANALYSIS STATUS"

        gv.Columns("REQUEST_NO").IsVisible = True
        gv.Columns("REQUEST_NO").Width = 130
        gv.Columns("REQUEST_NO").HeaderText = "REQUEST NO"

        gv.Columns("REQUEST_DESCRIPTION").IsVisible = True
        gv.Columns("REQUEST_DESCRIPTION").Width = 130
        gv.Columns("REQUEST_DESCRIPTION").HeaderText = "REQUEST DESCRIPTION"

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


       

        gv.Columns("TICKET_NO").IsVisible = True
        gv.Columns("TICKET_NO").Width = 130
        gv.Columns("TICKET_NO").HeaderText = "TICKET NO"

        gv.Columns("DEVELOPER_CODE").IsVisible = True
        gv.Columns("DEVELOPER_CODE").Width = 120
        gv.Columns("DEVELOPER_CODE").HeaderText = "DEVELOPER CODE"

        gv.Columns("Developer_Name").IsVisible = True
        gv.Columns("Developer_Name").Width = 120
        gv.Columns("Developer_Name").HeaderText = "DEVELOPER NAME"

        gv.Columns("TESTER_CODE").IsVisible = True
        gv.Columns("TESTER_CODE").Width = 100
        gv.Columns("TESTER_CODE").HeaderText = "TESTER CODE"

        

        gv.Columns("Tester_Name").IsVisible = True
        gv.Columns("Tester_Name").Width = 100
        gv.Columns("Tester_Name").HeaderText = "TESTER NAME"

        gv.Columns("Created_By_Code").IsVisible = True
        gv.Columns("Created_By_Code").Width = 140
        gv.Columns("Created_By_Code").HeaderText = "CREATED BY CODE"



        gv.Columns("Created_By_Name").IsVisible = True
        gv.Columns("Created_By_Name").Width = 140
        gv.Columns("Created_By_Name").HeaderText = "CREATED BY NAME"

        gv.Columns("TICKET_TYPE").IsVisible = True
        gv.Columns("TICKET_TYPE").Width = 100
        gv.Columns("TICKET_TYPE").HeaderText = "TICKET TYPE"

        gv.Columns("DATA_ERROR_TYPE").IsVisible = True
        gv.Columns("DATA_ERROR_TYPE").Width = 140
        gv.Columns("DATA_ERROR_TYPE").HeaderText = "DATA ERROR TYPE"

        

        gv.Columns("SEVERITY").IsVisible = True
        gv.Columns("SEVERITY").Width = 100
        gv.Columns("SEVERITY").HeaderText = "SEVERITY"

        gv.Columns("PRIORITY").IsVisible = True
        gv.Columns("PRIORITY").Width = 100
        gv.Columns("PRIORITY").HeaderText = "PRIORITY"

        gv.Columns("ALLOCATED_TIME").IsVisible = True
        gv.Columns("ALLOCATED_TIME").Width = 70
        gv.Columns("ALLOCATED_TIME").HeaderText = "ALLOCATED TIME"

    

        gv.Columns("TESTING_TIME").IsVisible = True
        gv.Columns("TESTING_TIME").Width = 130
        gv.Columns("TESTING_TIME").HeaderText = "TESTING TIME"

        gv.Columns("APPROVAL_STATUS").IsVisible = True
        gv.Columns("APPROVAL_STATUS").Width = 130
        gv.Columns("APPROVAL_STATUS").HeaderText = "APPROVAL STATUS"
        '

        gv.Columns("Analaysis_By_Code").IsVisible = True
        gv.Columns("Analaysis_By_Code").Width = 130
        gv.Columns("Analaysis_By_Code").HeaderText = "ANALYSIS BY CODE"

        gv.Columns("Analysis_By_Name").IsVisible = True
        gv.Columns("Analysis_By_Name").Width = 130
        gv.Columns("Analysis_By_Name").HeaderText = "ANALYSIS BY NAME"


        gv.EnableGrouping = False
    End Sub

    Sub LoadData()
        Try
            Dim fromdate As String = clsCommon.GetPrintDate(txtFromDate.Value, "dd/MMM/yyyy")
            Dim todate As String = clsCommon.GetPrintDate(txtToDate.Value, "dd/MMM/yyyy")
            Dim whre As String = " and 2=2 "
            'If clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then
            'whre = whre + " and TSPL_TICKET_MASTER.DEVELOPER_CODE = '" + objCommonVar.CurrentUserCode + "' and TSPL_TICKET_MASTER.TICKET_STATUS in ( 'Allocated', 'WIP','Pending' ) "
            'ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Then
            '    whre = whre + " and TSPL_TICKET_MASTER.TESTER_CODE = '" + objCommonVar.CurrentUserCode + "' and TSPL_TICKET_MASTER.TICKET_STATUS in ( 'Fixed', 'WIP') "
            'ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
            '    'dsfsfsdfds
            'ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then
            '    'dsfsfsdfds  
            'ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
            '    whre = whre + " and TSPL_TICKET_MASTER.CLIENT_CODE = '" + objCommonVar.CurrentClientCode + "' and TSPL_TICKET_MASTER.TICKET_STATUS in ('Closed') " '
            'End If
            Dim qry As String = " select TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,convert(varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) as REQUEST_ANALYSIS_DATE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_STATUS,'') as ANALYSIS_STATUS ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_REQUEST_CREATION_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.Created_By,'') as Analaysis_By_Code  ,isnull(TBL_USER_MASTER_Analysis_By.USER_NAME,'') as Analysis_By_Name     ,isnull( TSPL_REQUEST_ANALYSIS_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_REQUEST_ANALYSIS_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_REQUEST_ANALYSIS_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_DESCRIPTION,'') as ANALYSIS_DESCRIPTION , case when TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTING_TIME,'') as TESTING_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO,'') as REQUEST_NO,  isnull(TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO,'') as TICKET_NO ,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.APPROVAL_STATUS,'') as APPROVAL_STATUS from TSPL_REQUEST_ANALYSIS_MASTER   " & _
                                " left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO    " & _
                                " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE    " & _
                                " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE   " & _
                                " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE   " & _
                                " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.PROJECT_CODE " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE  " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE  " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Created_By   " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Analysis_By on TBL_USER_MASTER_Analysis_By.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.Created_By   " & _
                                " where convert(date,TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) > = '" + fromdate + "' and convert(date,TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) <='" + todate + "'  " + whre + " "

            Dim dt As DataTable = Nothing
            dt = New DataTable()
            dt = clsDBFuncationality.GetDataTable(qry, Nothing)
            gv.DataSource = Nothing
            gv.Columns.Clear()
            gv.Rows.Clear()
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                common.clsCommon.MyMessageBoxShow("No data found between {" + txtFromDate.Text + "- to -" + txtToDate.Text + "}", Me.Text)
                Exit Sub
            End If
            gv.DataSource = dt
            SetGridFormationOFgv()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub


    Private Sub gv_DoubleClick(sender As Object, e As EventArgs) Handles gv.DoubleClick
        Try

            If gv.Rows.Count > 0 Then
                Dim strDoc As String = Nothing
                strDoc = gv.CurrentRow.Cells("REQUEST_ANALYSIS_NO").Value
                If clsCommon.myLen(strDoc) > 0 Then
                    objCommonVar.CurrentTicketNo = strDoc
                    strClickGrid = "gv"
                    OpenForm()
                End If
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Sub OpenForm()
        Dim frm1 As RadForm = New FrmRequestAnalysisEntry()
        frm1.StartPosition = FormStartPosition.CenterScreen
        frm1.MaximizeBox = False
        frm1.MinimizeBox = False
        frm1.ControlBox = False
        frm1.Owner = Me
        objCommonVar.CurrentTicketOrAllocationScreen = frmHeading
        frm1.ShowDialog()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        OpenForm()
    End Sub

    Private Sub FrmRequestAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFromDate.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        txtToDate.Text = clsCommon.GETSERVERDATE
        frmHeading = Me.Text
        'If clsCommon.CompairString(frmHeading, "Request Analysis") = CompairStringResult.Equal Then
        '    btnAddNew.Visible = True
        'Else
        btnAddNew.Visible = False
        'End If
        LoadData()
        LoadDataOpenRequest()
        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub

    Public Sub LoadDataOpenRequest()
        Try
            Dim fromdate As String = clsCommon.GetPrintDate(txtFromDate.Value, "dd/MMM/yyyy") 'change in date format Monika
            Dim todate As String = clsCommon.GetPrintDate(txtToDate.Value, "dd/MMM/yyyy")
            Dim qry As String = " select TSPL_REQUEST_CREATION_MASTER.REQUEST_NO,convert(varchar, TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) as REQUEST_DATE,isnull(TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS,'') as REQUEST_STATUS,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION,isnull(TSPL_REQUEST_CREATION_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name from TSPL_REQUEST_CREATION_MASTER " & _
                            " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Created_By  " & _
                            " where convert(date,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) > = '" + fromdate + "' and convert(date,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) <='" + todate + "' and TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS in ('Open','Pending')  "

            Dim dt As DataTable = Nothing
            dt = New DataTable()
            dt = clsDBFuncationality.GetDataTable(qry, Nothing)
            gvOpen.DataSource = Nothing
            gvOpen.Columns.Clear()
            gvOpen.Rows.Clear()
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                ' common.clsCommon.MyMessageBoxShow("No data found between {" + txtFromDate.Text + "- to -" + txtToDate.Text + "}", Me.Text)
                Exit Sub
            End If
            gvOpen.DataSource = dt
            SetGridFormationOFgvOpen()
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub
    Sub SetGridFormationOFgvOpen()
        gvOpen.TableElement.TableHeaderHeight = 40
        gvOpen.MasterTemplate.ShowRowHeaderColumn = False
        For ii As Integer = 0 To gvOpen.Columns.Count - 1
            gvOpen.Columns(ii).ReadOnly = True
            gvOpen.Columns(ii).IsVisible = False
        Next

        gvOpen.Columns("REQUEST_NO").IsVisible = True
        gvOpen.Columns("REQUEST_NO").Width = 100
        gvOpen.Columns("REQUEST_NO").HeaderText = "REQUEST NO"

        gvOpen.Columns("REQUEST_DATE").IsVisible = True
        gvOpen.Columns("REQUEST_DATE").Width = 100
        gvOpen.Columns("REQUEST_DATE").HeaderText = "REQUEST DATE"

        gvOpen.Columns("CLIENT_CODE").IsVisible = True
        gvOpen.Columns("CLIENT_CODE").Width = 100
        gvOpen.Columns("CLIENT_CODE").HeaderText = "CLIENT CODE"

        gvOpen.Columns("Client_Name").IsVisible = True
        gvOpen.Columns("Client_Name").Width = 100
        gvOpen.Columns("Client_Name").HeaderText = "CLIENT NAME"

        gvOpen.Columns("REQUEST_STATUS").IsVisible = True
        gvOpen.Columns("REQUEST_STATUS").Width = 100
        gvOpen.Columns("REQUEST_STATUS").HeaderText = "REQUEST STATUS"

        gvOpen.Columns("REQUEST_DESCRIPTION").IsVisible = True
        gvOpen.Columns("REQUEST_DESCRIPTION").Width = 600
        gvOpen.Columns("REQUEST_DESCRIPTION").HeaderText = "REQUEST DESCRIPTION"

        gvOpen.Columns("Created_By_Code").IsVisible = True
        gvOpen.Columns("Created_By_Code").Width = 150
        gvOpen.Columns("Created_By_Code").HeaderText = "CREATED BY(CODE)"

        gvOpen.Columns("Created_By_Name").IsVisible = True
        gvOpen.Columns("Created_By_Name").Width = 150
        gvOpen.Columns("Created_By_Name").HeaderText = "CREATED BY (NAME)"
        gvOpen.EnableGrouping = False
    End Sub

    Private Sub gvOpen_DoubleClick(sender As Object, e As EventArgs) Handles gvOpen.DoubleClick
        Try
            If gvOpen.Rows.Count > 0 Then
                Dim strDoc As String = Nothing
                strDoc = gvOpen.CurrentRow.Cells("REQUEST_NO").Value
                If clsCommon.myLen(strDoc) > 0 Then
                    objCommonVar.CurrentOpenRequestNo = strDoc
                    strClickGrid = "gvOpen"
                    OpenForm()
                End If
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
