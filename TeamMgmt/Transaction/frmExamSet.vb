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

Public Class frmExamSet
    Inherits FrmMainTranScreen
    Public EntryNo As String = ""
    Const colQCStatus As String = "COLQCSTATUS"
    Const colQuestionCode As String = "COLICODE"
    Const colQuestion As String = "COLIName"
    Private isNewEntry As Boolean = False

    Private Sub FrmRequestAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBlankGrid()
        LoadCustomer()
        isNewEntry = True

        ' rbtnCustomerSelect.IsChecked = True
    End Sub
    Sub LoadBlankGrid()
        gv1.Rows.Clear()
        gv1.Columns.Clear()

        Dim repoQCStatus As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        repoQCStatus.HeaderText = "QC Status"
        repoQCStatus.Name = colQCStatus
        repoQCStatus.ReadOnly = False
        repoQCStatus.IsVisible = True
        repoQCStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        gv1.MasterTemplate.Columns.Add(repoQCStatus)


        Dim repoICode As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        repoICode.FormatString = ""
        repoICode.HeaderText = "Question Code"
        repoICode.Name = colQuestionCode
        repoICode.TextImageRelation = TextImageRelation.TextBeforeImage
        repoICode.Width = 100
        gv1.MasterTemplate.Columns.Add(repoICode)

        Dim repoQuestion As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        repoQuestion.FormatString = ""
        repoQuestion.HeaderText = "Question Name"
        repoQuestion.Name = colQuestion
        repoQuestion.TextImageRelation = TextImageRelation.TextBeforeImage
        repoQuestion.Width = 500
        gv1.MasterTemplate.Columns.Add(repoQuestion)

        gv1.AllowDeleteRow = True
        gv1.AllowAddNewRow = False
        gv1.ShowGroupPanel = False
        gv1.AllowColumnReorder = False
        gv1.AllowRowReorder = False
        gv1.EnableSorting = False
        gv1.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv1.MasterTemplate.ShowRowHeaderColumn = False
        gv1.TableElement.TableHeaderHeight = 40
    End Sub
    Sub LoadCustomer()
        LoadBlankGrid()
        Dim qry As String = "SELECT CAST(0 as BIT ) as Status,FBNPC_QUSTIONSSHEET.QuestionID as Code,FBNPC_QUSTIONSSHEET.Question FROM FBNPC_QUSTIONSSHEET "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            Dim ii As Integer = 1
            For Each dr As DataRow In dt.Rows
                gv1.Rows.AddNew()
                gv1.Rows(gv1.Rows.Count - 1).Cells(colQCStatus).Value = clsCommon.myCBool(dr("Status"))
                gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestionCode).Value = clsCommon.myCstr(dr("Code"))
                gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestion).Value = clsCommon.myCstr(dr("Question"))
                ii = ii + 1
            Next

        End If
        gv1.MasterTemplate.SummaryRowsBottom.Clear()
        gv1.BestFitColumns()
        gv1.AllowAddNewRow = False

    End Sub
    Private Sub txtsSection__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtsSection._MYValidating
        Try
            Dim qry As String = "select SectionID as Code ,SectionName as [Section Name]  from FBNPC_Sections "

            txtsSection.Value = clsCommon.ShowSelectForm("sections", qry, "Code", "", txtsSection.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtsSection.Value)) > 0 Then
                lblSection.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT SectionName FROM FBNPC_Sections WHERE SectionID ='" & clsCommon.myCstr(txtsSection.Value) & "'"))
            Else
                lblSection.Text = ""
            End If
            If clsCommon.CompairString(lblSection.Text, "Reading") = CompairStringResult.Equal Then
                txtAV.Enabled = False
                txtVideo.Enabled = False
            Else
                txtAV.Enabled = True
                txtVideo.Enabled = True
            End If
            'If clsCommon.CompairString(lblSection.Text, "Listening") = CompairStringResult.Equal Then
            '    txtComprehension.Enabled = False
            '    txtVideo.Enabled = False
            'Else
            '    txtComprehension.Enabled = True
            '    txtVideo.Enabled = True
            'End If
            'If clsCommon.CompairString(lblSection.Text, "Speaking") = CompairStringResult.Equal Then
            '    txtComprehension.Enabled = False
            '    txtAV.Enabled = False
            'Else
            '    txtComprehension.Enabled = True
            '    txtAV.Enabled = True
            'End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub txtSubject__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtSubject._MYValidating
        Try
            Dim qry As String = "select SubjectID as Code ,SubjectName as [Section Name]  from FBNPC_SUBJECTS "

            txtSubject.Value = clsCommon.ShowSelectForm("Subject", qry, "Code", "", txtSubject.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtSubject.Value)) > 0 Then
                lblSubject.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT SubjectName FROM FBNPC_SUBJECTS WHERE SubjectID ='" & clsCommon.myCstr(txtSubject.Value) & "'"))
            Else
                lblSubject.Text = ""
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub txtExam__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtExam._MYValidating
        Try
            Dim qry As String = "select ExamID as Code ,ExamName as [Exam Name]  from FBNPC_ExamListName "

            txtExam.Value = clsCommon.ShowSelectForm("Exam", qry, "Code", "", txtExam.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtsSection.Value)) > 0 Then
                lblExamName.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT Description FROM FBNPC_ExamListName WHERE ExamID ='" & clsCommon.myCstr(txtExam.Value) & "'"))
            Else
                lblExamName.Text = ""
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub txtAV__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtAV._MYValidating
        Try
            Dim qry As String = "select AVID as Code ,SubjectName as [Audio Video Name]  from FBNPC_AUDIO_VIDEO_MASTER "

            txtAV.Value = clsCommon.ShowSelectForm("AVID", qry, "Code", "", txtAV.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtAV.Value)) > 0 Then
                lblAudioVideo.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT SubjectName FROM FBNPC_AUDIO_VIDEO_MASTER WHERE AVID ='" & clsCommon.myCstr(txtAV.Value) & "'"))
            Else
                lblAudioVideo.Text = ""
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub txtComprehension__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtComprehension._MYValidating
        Try
            Dim qry As String = "select ReadingID as Code ,ComprehensionName as [Comprehension Name]  from FBNPC_COMPREHENSION_MASTER "

            txtComprehension.Value = clsCommon.ShowSelectForm("sections", qry, "Code", "", txtComprehension.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtComprehension.Value)) > 0 Then
                lblComprehension.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT ComprehensionName FROM FBNPC_COMPREHENSION_MASTER WHERE ReadingID ='" & clsCommon.myCstr(txtComprehension.Value) & "'"))
            Else
                lblComprehension.Text = ""
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub txtVideo__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtVideo._MYValidating
        Try
            Dim qry As String = "select AudioID as Code ,SubjectName as [Video Name]  from FBNPC_VIDEO_MASTER "

            txtVideo.Value = clsCommon.ShowSelectForm("AVID", qry, "Code", "", txtVideo.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtAV.Value)) > 0 Then
                lblVideoName.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT SubjectName FROM FBNPC_VIDEO_MASTER WHERE AudioID ='" & clsCommon.myCstr(txtVideo.Value) & "'"))
            Else
                lblVideoName.Text = ""
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click

        txtExam.Value = ""
        txtSubject.Value = ""
        btnGo.Text = "Save"
        txtExam.Value = ""
        txtAV.Value = ""
        lblAudioVideo.Text = ""
        lblExamName.Text = ""
        lblSection.Text = ""
        lblSubject.Text = ""
        txtDocNo.Value = ""
        isNewEntry = True
        btnGo.Enabled = True
        btnPost.Enabled = True
        'rbtnCustomerAll.IsChecked = True
        LoadCustomer()
        txtsSection.Value = ""
        txtAV.Enabled = True
        txtVideo.Value = ""
        lblVideoName.Text = ""
        txtComprehension.Value = ""
        lblComprehension.Text = ""
        'rbtnCustomerSelect.IsChecked = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        SaveData(False)
    End Sub
    Sub LoadData(ByVal strCode As String, ByVal NavTyep As NavigatorType)
        Dim obj As New clsExamSet()
        Try
            btnGo.Enabled = True
            LoadBlankGrid()
            obj = clsExamSet.GetData(strCode, NavTyep)
            If (obj IsNot Nothing AndAlso clsCommon.myLen(obj.DocNo) > 0) Then
                btnGo.Text = "Update"
                If clsCommon.CompairString(obj.posted, "1") = CompairStringResult.Equal Then
                    btnGo.Enabled = False
                    btnPost.Enabled = False
                Else
                    btnGo.Enabled = True
                    btnPost.Enabled = True
                End If
                txtDocNo.Value = obj.DocNo
                txtsSection.Value = obj.Section
                lblSection.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SectionName from FBNPC_SECTIONS where SectionID='" + txtsSection.Value + "'"))
                txtSubject.Value = obj.Subject
                lblSubject.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SubjectName from FBNPC_SUBJECTS where SubjectID='" + txtSubject.Value + "'"))
                txtExam.Value = obj.ExamName
                lblExamName.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select ExamName from FBNPC_EXAMLISTNAME where ExamID='" + txtExam.Value + "'"))
                txtAV.Value = obj.AVName
                lblAudioVideo.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SubjectName from FBNPC_AUDIO_VIDEO_MASTER where AVID='" + txtAV.Value + "'"))
                isNewEntry = False
                If obj.Arr IsNot Nothing AndAlso obj.Arr.Count > 0 Then
                    For Each objTr As clsExamSetDetail In obj.Arr
                        gv1.Rows.AddNew()
                        gv1.Rows(gv1.Rows.Count - 1).Cells(colQCStatus).Value = objTr.QusSelect

                        gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestionCode).Value = objTr.QuestionID
                        gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestion).Value = objTr.QuestionDesc
                        txtVideo.Value = obj.VideoName
                        lblVideoName.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SubjectName from FBNPC_VIDEO_MASTER where AudioID='" + txtVideo.Value + "'"))
                        txtComprehension.Value = objTr.ComprehensionID
                        lblComprehension.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select ComprehensionName from FBNPC_COMPREHENSION_MASTER where ReadingID='" + txtComprehension.Value + "'"))
                    Next
                End If
            End If
        Catch ex As Exception
            isNewEntry = True
            common.clsCommon.MyMessageBoxShow(ex.Message)
        Finally
            obj = Nothing
        End Try
    End Sub
    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        txtExam.Value = ""
        txtsSection.Value = ""
        txtSubject.Value = ""
        btnGo.Text = "Save"
        txtExam.Value = ""
        txtAV.Value = ""
        lblAudioVideo.Text = ""
        lblExamName.Text = ""
        lblSection.Text = ""
        lblSubject.Text = ""
        txtDocNo.Value = ""
        isNewEntry = True
        btnGo.Enabled = True
        btnPost.Enabled = True
        LoadCustomer()
        txtAV.Enabled = True
        txtVideo.Value = ""
        lblVideoName.Text = ""
        txtComprehension.Value = ""
        lblComprehension.Text = ""
    End Sub
    Private Sub txtDocNo__MYNavigator(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal NavType As common.NavigatorType) Handles txtDocNo._MYNavigator
        Try
            Dim qst As String = "select count(*) from FBNPC_PAPER_SET_HEAD where PaperID='" + txtDocNo.Value + "' "
            Dim count As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(qst))
            LoadData(txtDocNo.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub txtDocNo__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtDocNo._MYValidating
        Dim qry As String = "select FBNPC_PAPER_SET_HEAD.PaperID as Code,fbnpc_sections.description,fbnpc_subjects.Subjectname as [Subject Name],FBNPC_EXAMLISTNAME.ExamName as [Exam Name] from FBNPC_PAPER_SET_HEAD "
        qry += " left outer join fbnpc_sections on fbnpc_sections.sectionID=FBNPC_PAPER_SET_HEAD.section"
        qry += " left outer join fbnpc_subjects on fbnpc_subjects.subjectID=FBNPC_PAPER_SET_HEAD.subject"
        qry += " left outer join FBNPC_EXAMLISTNAME on FBNPC_EXAMLISTNAME.ExamID=FBNPC_PAPER_SET_HEAD.ExamID "

        LoadData(clsCommon.ShowSelectForm("GRNFilterFND", qry, "Code", "", txtDocNo.Value, "Code", isButtonClicked), NavigatorType.Current)
    End Sub
    Sub SaveData(ByVal ChekBtnPost As Boolean, Optional ByVal isamendment As Boolean = False)
        Dim issaved As Boolean = False
        Dim obj As New clsExamSet()
        Try
            If clsCommon.myLen(txtsSection.Value) <= 0 Then
                Throw New Exception(" Select Section Name")
            End If
            If clsCommon.myLen(txtSubject.Value) <= 0 Then
                Throw New Exception(" Select Subject Name")
            End If
            If clsCommon.myLen(txtExam.Value) <= 0 Then
                Throw New Exception(" Select Exam Name")
            End If

            obj.Subject = txtSubject.Value
            obj.Section = txtsSection.Value
            obj.ExamName = txtExam.Value
            obj.AVName = txtAV.Value
            obj.DocNo = txtDocNo.Value
            If isNewEntry Then
                Dim Sql As String = "SELECT MAX(PaperID) as document_No from FBNPC_PAPER_SET_HEAD "
                obj.DocNo = clsCommon.myCstr(clsDBFuncationality.getSingleValue(Sql))
                If clsCommon.myLen(obj.DocNo) > 0 Then
                    obj.DocNo = clsCommon.incval(obj.DocNo)
                Else
                    obj.DocNo = "EPS0000000001"
                End If
            End If
            obj.Arr = New List(Of clsExamSetDetail)
            For Each grow As GridViewRowInfo In gv1.Rows
                Dim objTr As New clsExamSetDetail()
                If clsCommon.myCBool(grow.Cells(colQCStatus).Value) = True Then
                    objTr.QuestionID = clsCommon.myCstr(grow.Cells(colQuestionCode).Value)
                    objTr.QusSelect = clsCommon.myCBool(grow.Cells(colQCStatus).Value)
                    objTr.ExamID = txtExam.Value
                    objTr.AVID = txtAV.Value
                    objTr.VideoName = txtVideo.Value
                    objTr.ComprehensionID = txtComprehension.Value
                    obj.Arr.Add(objTr)
                End If
            Next
            If (obj.Arr Is Nothing OrElse obj.Arr.Count <= 0) Then
                common.clsCommon.MyMessageBoxShow("Please Fill at list one Item")
                Return
            End If
            If (obj.SaveData(obj, isNewEntry)) Then
                common.clsCommon.MyMessageBoxShow("Data Saved Successfully")
                LoadData(obj.DocNo, NavigatorType.Current)
            End If

        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        PostData()
    End Sub

    Sub PostData()
        Try
            If (myMessages.postConfirm()) Then
                SaveData(True)
                If (clsExamSet.PostData(txtDocNo.Value)) Then
                    common.clsCommon.MyMessageBoxShow("Successfully Posted")
                    LoadData(txtDocNo.Value, NavigatorType.Current)

                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
End Class
