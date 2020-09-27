Imports common
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class RptExamListReport
    Dim ButtonToolTip As ToolTip = New ToolTip()
   
    Sub Print(ByVal IsPrint As Exporter)

        Dim Query As String = ""
        Dim dt As DataTable
      

       
        Query = " select FBNPC_EXAMLISTNAME.ExamID,FBNPC_EXAMLISTNAME.ExamName,fbnpc_subjects.SubjectName as [Subject Name],fbnpc_sections.SectionName as [Section Name],FBNPC_AUDIO_VIDEO_MASTER.SubjectName as [Audio Name],FBNPC_VIDEO_MASTER.SubjectName as [Video Name],FBNPC_COMPREHENSION_MASTER.ComprehensionName as [Comrehension Name],FBNPC_QUSTIONSSHEET.Question,FBNPC_QUSTIONSSHEET.CorrectAns as [Correct Answer] from FBNPC_PAPER_SET_HEAD"
        Query += " left outer join FBNPC_PAPER_SET_detail on FBNPC_PAPER_SET_detail.PaperID=FBNPC_PAPER_SET_HEAD.PaperID"
        Query += " left outer join fbnpc_sections on fbnpc_sections.sectionID=FBNPC_PAPER_SET_HEAD.section"
        Query += " left outer join fbnpc_subjects on fbnpc_subjects.subjectID=FBNPC_PAPER_SET_HEAD.subject"
        Query += " left outer join FBNPC_EXAMLISTNAME on FBNPC_EXAMLISTNAME.ExamID=FBNPC_PAPER_SET_HEAD.ExamID"
        Query += " left outer join FBNPC_QUSTIONSSHEET on FBNPC_QUSTIONSSHEET.QuestionID=FBNPC_PAPER_SET_detail.QuestionID"
        Query += " left outer join FBNPC_AUDIO_VIDEO_MASTER on FBNPC_AUDIO_VIDEO_MASTER.AVID=FBNPC_PAPER_SET_detail.AVID"
        Query += " left outer join FBNPC_VIDEO_MASTER on FBNPC_VIDEO_MASTER.AudioID=FBNPC_PAPER_SET_detail.VideoID"
        Query += " left outer join FBNPC_COMPREHENSION_MASTER on FBNPC_COMPREHENSION_MASTER.ReadingID=FBNPC_PAPER_SET_detail.ComprehensionID "
        Query += " where 2=2"

            If txtExamMulti.arrValueMember IsNot Nothing AndAlso txtExamMulti.arrValueMember.Count > 0 Then
            Query += " and  FBNPC_EXAMLISTNAME.ExamID in (" + clsCommon.GetMulcallString(txtExamMulti.arrValueMember) + ")  "
            End If

            If TxtMultiSection.arrValueMember IsNot Nothing AndAlso TxtMultiSection.arrValueMember.Count > 0 Then
            Query += " and fbnpc_sections.SectionID in (" + clsCommon.GetMulcallString(TxtMultiSection.arrValueMember) + ")  "
            End If
            If txtSubSubject.arrValueMember IsNot Nothing AndAlso txtSubSubject.arrValueMember.Count > 0 Then
            Query += " and fbnpc_subjects.SubjectID in (" + clsCommon.GetMulcallString(txtSubSubject.arrValueMember) + ")  "
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
        TxtMultiSection.arrValueMember = Nothing
        txtSubSubject.arrValueMember = Nothing

    End Sub
    Private Sub txtItemMult__My_Click(sender As Object, e As EventArgs) Handles txtExamMulti._My_Click
        Dim qry As String = " select ExamID as Code,ExamName as Name from FBNPC_EXAMLISTNAME "
        txtExamMulti.arrValueMember = clsCommon.ShowMultipleSelectForm("txtMultItemNo", qry, "Code", "Name", txtExamMulti.arrValueMember, txtExamMulti.arrDispalyMember)
    End Sub

    Private Sub TxtMultiLocation__My_Click(sender As Object, e As EventArgs) Handles TxtMultiSection._My_Click
        Dim qry As String = "select SectionID as [Code] ,SectionName as [Name] from fbnpc_sections "
        TxtMultiSection.arrValueMember = clsCommon.ShowMultipleSelectForm("Pro", qry, "Code", "Name", TxtMultiSection.arrValueMember, TxtMultiSection.arrDispalyMember)
    End Sub
    Private Sub txtSubLocation__My_Click(sender As Object, e As EventArgs) Handles txtSubSubject._My_Click
        Dim qry As String = "select SubjectID as [Code] ,SubjectName as [Name] from fbnpc_subjects "
        txtSubSubject.arrValueMember = clsCommon.ShowMultipleSelectForm("ProSub", qry, "Code", "Name", txtSubSubject.arrValueMember, txtSubSubject.arrDispalyMember)
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
                arrHeader.Add(" Item : " + clsCommon.GetMulcallStringWithComma(txtExamMulti.arrDispalyMember))
            End If

            If TxtMultiSection.arrValueMember IsNot Nothing AndAlso TxtMultiSection.arrValueMember.Count > 0 Then
                arrHeader.Add(" Location : " + clsCommon.GetMulcallStringWithComma(TxtMultiSection.arrDispalyMember))
            End If

            clsCommon.MyExportToExcelGrid("Standardization QC Report", gv1, arrHeader, Me.Text)


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
