Imports common
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class RptExamResult
    Dim ButtonToolTip As ToolTip = New ToolTip()
    Const colIName As String = "COLINAME"

    Sub Print(ByVal IsPrint As Exporter)

        Dim Query As String = ""
        Dim dt As DataTable



        'Query = " select FBNPC_USER_MASTER.User_Code,FBNPC_USER_MASTER.First_Name as [Student Name],FBNPC_USER_MASTER.E_mail as [Email ID],FBNPC_USER_MASTER.Phone,FBNPC_EXAMLISTNAME.ExamID,FBNPC_EXAMLISTNAME.ExamName as [Exam Name],FBNPC_QUSTIONSSHEET.Question,FBNPC_Submit_Exam.OptionA A,FBNPC_Submit_Exam.OptionB as B,FBNPC_Submit_Exam.OptionC as C,FBNPC_Submit_Exam.OptionD as D,FBNPC_QUSTIONSSHEET.CorrectAns as [Correct Option] from FBNPC_Submit_Exam"
        'Query += " left outer join FBNPC_USER_MASTER on FBNPC_USER_MASTER.User_Code=FBNPC_Submit_Exam.studentname"
        'Query += " left outer join FBNPC_QUSTIONSSHEET on FBNPC_QUSTIONSSHEET.QuestionID=FBNPC_Submit_Exam.QuestionID"
        'Query += " left outer join FBNPC_EXAMLISTNAME on FBNPC_EXAMLISTNAME.ExamID=FBNPC_Submit_Exam.ExamName"
        'Query += " where 2=2 and convert(date,FBNPC_Submit_Exam.CreatedDate,103) >= convert(date,('" + txtfromDate.Value + "'),103) and convert(date,FBNPC_Submit_Exam.CreatedDate,103) <= convert(date,('" & txtToDate.Value & "'),103)"


        Query = "select FBNPC_EXAMLISTNAME.ExamName as [Exam Name],FBNPC_SUBMIT_EXAM.StudentName as [Student Name],FBNPC_QUSTIONSSHEET.Question,case when FBNPC_SUBMIT_EXAM.OptionA=1 then 'A' else case when OptionB=1 then 'B' else case when FBNPC_SUBMIT_EXAM.OptionC=1 then 'C' else case when FBNPC_SUBMIT_EXAM.OptionD=1 then 'D' end end end end as StudentANS"
        Query += " ,FBNPC_QUSTIONSSHEET.correctAns as [Correct ANS]  from FBNPC_SUBMIT_EXAM left outer join FBNPC_QUSTIONSSHEET on FBNPC_QUSTIONSSHEET.QuestionID=FBNPC_SUBMIT_EXAM.QuestionID left outer join FBNPC_EXAMLISTNAME on FBNPC_EXAMLISTNAME.ExamID=FBNPC_SUBMIT_EXAM.ExamName "
        Query += " where 2=2 and convert(date,FBNPC_Submit_Exam.CreatedDate,103) >= convert(date,('" + txtfromDate.Value + "'),103) and convert(date,FBNPC_Submit_Exam.CreatedDate,103) <= convert(date,('" & txtToDate.Value & "'),103) "


        If txtExamMulti.arrValueMember IsNot Nothing AndAlso txtExamMulti.arrValueMember.Count > 0 Then
            Query += " and  FBNPC_Submit_Exam.examname in (" + clsCommon.GetMulcallString(txtExamMulti.arrValueMember) + ")  "
        End If

        If TxtMultiStudent.arrValueMember IsNot Nothing AndAlso TxtMultiStudent.arrValueMember.Count > 0 Then
            Query += " and studentname in (" + clsCommon.GetMulcallString(TxtMultiStudent.arrValueMember) + ")  "
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

            gv1.DataSource = dt
            SetGridFormationOFGV1()
            gv1.BestFitColumns()
            lblQuestions.Text = clsCommon.myCdbl(dt.Rows.Count)
            LoadBlankGrid()
            For i As Integer = 0 To gv1.Rows.Count - 1
                If clsCommon.CompairString(clsCommon.myCstr(gv1.Rows(i).Cells("StudentANS").Value), clsCommon.myCstr(gv1.Rows(i).Cells("Correct ANS").Value)) = CompairStringResult.Equal Then
                    gv1.Rows(i).Cells(colIName).Value = Global.TeamMgmt.My.Resources.Resources.tick
                Else
                    If (clsCommon.myLen(gv1.Rows(i).Cells("StudentANS").Value)) <= 0 Then
                        gv1.Rows(i).Cells(colIName).Value = Global.TeamMgmt.My.Resources.Resources.NoResponse
                    Else
                        gv1.Rows(i).Cells(colIName).Value = Global.TeamMgmt.My.Resources.Resources.wrong
                    End If


                End If

            Next

            gv1.Columns("Correct ANS").IsVisible = False

            RadPageView1.SelectedPage = RadPageViewPage2
        Else
            clsCommon.MyMessageBoxShow("No Data Found", Me.Text)
        End If
        ReStoreGridLayout()
    End Sub
    Sub LoadBlankGrid()

        Dim repoIName As GridViewImageColumn = New GridViewImageColumn()
        repoIName.HeaderText = "Sign"
        repoIName.Name = colIName
        repoIName.Width = 50
        repoIName.ReadOnly = False
        repoIName.ImageLayout = ImageLayout.Zoom
        gv1.MasterTemplate.Columns.Add(repoIName) '4
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
