Imports common
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class frmPracticeExmReloader
    Dim ButtonToolTip As ToolTip = New ToolTip()

    
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
        TxtMultiStudent.arrValueMember = Nothing
        txtToDate.Value = clsCommon.GETSERVERDATE()
        txtfromDate.Value = txtToDate.Value
        lblQuestions.Text = ""

    End Sub
    Private Sub txtItemMult__My_Click(sender As Object, e As EventArgs) Handles txtExamMulti._My_Click
        Dim qry As String = " select ExamID as Code,ExamName as Name from FBNPC_EXAMLISTNAME "
        txtExamMulti.arrValueMember = clsCommon.ShowMultipleSelectForm("txtMultItemNo", qry, "Code", "Name", txtExamMulti.arrValueMember, txtExamMulti.arrDispalyMember)
    End Sub

    Private Sub TxtMultiLocation__My_Click(sender As Object, e As EventArgs) Handles TxtMultiStudent._My_Click
        Dim qry As String = "select user_Code as [Code] ,First_Name as [Name],E_mail,Phone from fbnpc_user_Master "
        TxtMultiStudent.arrValueMember = clsCommon.ShowMultipleSelectForm("Pro", qry, "Code", "Name", TxtMultiStudent.arrValueMember, TxtMultiStudent.arrDispalyMember)
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
                arrHeader.Add(" Exam : " + clsCommon.GetMulcallStringWithComma(txtExamMulti.arrDispalyMember))
            End If

            If TxtMultiStudent.arrValueMember IsNot Nothing AndAlso TxtMultiStudent.arrValueMember.Count > 0 Then
                arrHeader.Add(" Student : " + clsCommon.GetMulcallStringWithComma(TxtMultiStudent.arrDispalyMember))
            End If

            clsCommon.MyExportToExcelGrid("Exam Attempted Student List", gv1, arrHeader, Me.Text)


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
        rmExportToExcel.Visible = False
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
    End Sub


End Class
