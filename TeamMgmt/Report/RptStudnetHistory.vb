Imports common
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class RptStudnetHistory
    Dim ButtonToolTip As ToolTip = New ToolTip()

    Sub Print(ByVal IsPrint As Exporter)

        Dim Query As String = ""
        Dim dt As DataTable

        Query = " select fbnpc_login_history.UserCode as [Student Code],fbnpc_login_history.UserName as [Student Name],fbnpc_user_master.Phone,fbnpc_login_history.ip_address as [IP Address],fbnpc_login_history.Macaddress as [Mac Address],fbnpc_login_history.logindate as [Login Date with Time]
        Query += " from fbnpc_login_history"
        Query += " left outer join fbnpc_user_master on fbnpc_user_master.user_code=fbnpc_login_history.usercode"
        Query += " left outer join fbnpc_user_master as emailUSer on emailUSer.e_mail=fbnpc_login_history.usercode "
        Query += " where 2=2 and convert(date,fbnpc_login_history.logindate,103) >= convert(date,('" + txtfromDate.Value + "'),103) and convert(date,fbnpc_login_history.logindate,103) <= convert(date,('" & txtToDate.Value & "'),103) "

        If txtExamMulti.arrValueMember IsNot Nothing AndAlso txtExamMulti.arrValueMember.Count > 0 Then
            Query += " and  UserName in (" + clsCommon.GetMulcallString(txtExamMulti.arrValueMember) + ")  "
        End If

        dt = clsDBFuncationality.GetDataTable(Query)

        If dt IsNot Nothing And dt.Rows.Count > 0 Then
            gv1.DataSource = Nothing
            gv1.Columns.Clear()
            gv1.Rows.Clear()
            gv1.GroupDescriptors.Clear()
            gv1.MasterTemplate.SummaryRowsBottom.Clear()
            gv1.ShowGroupPanel = False

            gv1.EnableFiltering = True



            RadPageView1.SelectedPage = RadPageViewPage2
        Else
            clsCommon.MyMessageBoxShow("No Data Found")
        End If

        gv1.DataSource = dt
        SetGridFormationOFGV1()
        gv1.BestFitColumns()

        ReStoreGridLayout()

    End Sub
    Private Sub ReStoreGridLayout()
        Try
            If clsCommon.myLen(MyBase.Form_ID) > 0 Then
                Dim obj As clsGridLayout = New clsGridLayout()
                obj = CType(obj.GetData(Form_ID, "", objCommonVar.CurrentUserCode), clsGridLayout)
                If Not obj Is Nothing AndAlso obj.GridColumns >= gv1.ColumnCount Then
                    Dim ii As Integer
                    For ii = 0 To gv1.Columns.Count - 1 Step ii + 1
                        gv1.Columns(ii).IsVisible = False
                        gv1.Columns(ii).VisibleInColumnChooser = True
                    Next
                    gv1.LoadLayout(obj.GridLayout)
                    obj.GridLayout.Seek(0, System.IO.SeekOrigin.Begin)
                End If
            End If
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Sub SetGridFormationOFGV1()
        gv1.TableElement.TableHeaderHeight = 40
        gv1.MasterTemplate.ShowRowHeaderColumn = False
        For ii As Integer = 0 To gv1.Columns.Count - 1
            gv1.Columns(ii).ReadOnly = True
            gv1.Columns(ii).IsVisible = True
            gv1.Columns(ii).BestFit()
        Next

    End Sub
    Sub Reset()

        gv1.DataSource = Nothing
        RadPageView1.SelectedPage = RadPageViewPage1
        txtExamMulti.arrValueMember = Nothing
        txtToDate.Value = clsCommon.GETSERVERDATE()
        txtfromDate.Value = txtToDate.Value

    End Sub
    Private Sub txtItemMult__My_Click(sender As Object, e As EventArgs) Handles txtExamMulti._My_Click
        Dim qry As String = " select User_Code as Code,First_Name as Name from FBNPC_User_Master "
        txtExamMulti.arrValueMember = clsCommon.ShowMultipleSelectForm("txtMultItemNo", qry, "Code", "Name", txtExamMulti.arrValueMember, txtExamMulti.arrDispalyMember)
    End Sub

 

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Print(Exporter.Refresh)
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Reset()
    End Sub

    Private Sub rmExportToExcel_Click(sender As Object, e As EventArgs) Handles rmExportToExcel.Click
        Try


            Dim arrHeader As List(Of String) = New List(Of String)()
            arrHeader.Add("Company : " & objCommonVar.CurrentCompanyName)


            If txtExamMulti.arrValueMember IsNot Nothing AndAlso txtExamMulti.arrValueMember.Count > 0 Then
                arrHeader.Add(" Student Name : " + clsCommon.GetMulcallStringWithComma(txtExamMulti.arrDispalyMember))
            End If

            clsCommon.MyExportToExcelGrid("Student Login History Report", gv1, arrHeader, Me.Text)


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub rptAvailableQtyForProduction_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt And e.KeyCode = Keys.R Then
            Print(Exporter.Refresh)
        ElseIf e.Alt And e.KeyCode = Keys.C Then
            Me.Close()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.N Then
            Reset()
        End If
    End Sub


    Private Sub rptAvailableQtyForProduction_Load(sender As Object, e As EventArgs) Handles Me.Load

        ButtonToolTip.SetToolTip(btnclose, "Press Alt+C Close the Window")
        ButtonToolTip.SetToolTip(btnGo, "Press Alt+R Refresh ")
        ButtonToolTip.SetToolTip(BtnReset, "Press Alt+N Adding New")
        Reset()
    End Sub

End Class
