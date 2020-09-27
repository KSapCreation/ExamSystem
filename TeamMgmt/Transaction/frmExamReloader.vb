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

Public Class frmExamReloader
    Inherits FrmMainTranScreen
    Public EntryNo As String = ""
    Const colQCStatus As String = "COLQCSTATUS"
    Const colQuestionCode As String = "COLICODE"
    Const colQuestion As String = "COLIName"
    Private isNewEntry As Boolean = False

    Private Sub FrmRequestAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isNewEntry = True
    End Sub
    
    
    
    Private Sub txtSubject__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtSubject._MYValidating
        Try
            Dim qry As String = "select user_Code as Code ,First_Name as [Name],Last_name as [last Name]  from FBNPC_USER_MASTER "
            Dim WhrCls As String = String.Empty
            WhrCls = " PraticeType=1  "

            txtSubject.Value = clsCommon.ShowSelectForm("Subject", qry, "Code", WhrCls, txtSubject.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtSubject.Value)) > 0 Then
                lblSubject.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT First_name FROM FBNPC_USER_MASTER WHERE user_Code ='" & clsCommon.myCstr(txtSubject.Value) & "'"))
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

            lblExamName.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT ExamName FROM FBNPC_ExamListName WHERE ExamID ='" & clsCommon.myCstr(txtExam.Value) & "'"))
            
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click

        txtExam.Value = ""
        txtSubject.Value = ""
        btnGo.Text = "Save"
        txtExam.Value = ""
        lblExamName.Text = ""
        lblSubject.Text = ""
        isNewEntry = True
        btnGo.Enabled = True
  
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        SaveData(False)
    End Sub
    
    Private Sub btnreset1_Click(sender As Object, e As EventArgs)
        txtExam.Value = ""

        txtSubject.Value = ""
        btnGo.Text = "Save"
        txtExam.Value = ""
    
        lblExamName.Text = ""

        lblSubject.Text = ""

        isNewEntry = True
        btnGo.Enabled = True
      
    End Sub
  
    Sub SaveData(ByVal ChekBtnPost As Boolean, Optional ByVal isamendment As Boolean = False)
        Dim issaved As Boolean = False
        Dim obj As New clsExamReloader()
        Dim dtMapping As New DataTable
        Try
          
            If clsCommon.myLen(txtSubject.Value) <= 0 Then
                Throw New Exception(" Select Student Name")
            End If
            If clsCommon.myLen(txtExam.Value) <= 0 Then
                Throw New Exception(" Select Exam Name")
            End If
            clsCommon.ProgressBarShow()

            Dim qry As String = "select questionid,optionA,optionB,OptionC,optionD,examName,studentName,paperid from FBNPC_SUBMIT_EXAM where studentname='" & clsCommon.myCstr(txtSubject.Value) & "' and examname='" & clsCommon.myCstr(txtExam.Value) & "'"
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

            obj.ArrExamSubmit = New List(Of clsExamSubmit)
            obj.ArrExamMapping = New List(Of clsExamMapping)


            Dim Sql As String = "SELECT MAX(hist_version) as hist_version from FBNPC_Submit_Exam_History "
            obj.DocNo = clsCommon.myCstr(clsDBFuncationality.getSingleValue(Sql))
            If clsCommon.myLen(obj.DocNo) > 0 Then
                obj.DocNo = clsCommon.incval(obj.DocNo)
            Else
                obj.DocNo = txtSubject.Value + "0000001"
            End If

            obj.ExamName = txtExam.Value
            obj.StudentName = txtSubject.Value

            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim objTr As New clsExamSubmit()
                    objTr.Hist_By = objCommonVar.CurrentUserCode
                    objTr.Hist_Version = obj.DocNo
                    objTr.QuestionID = clsCommon.myCstr(row("questionid"))
                    objTr.OptionA = clsCommon.myCstr(row("OptionA"))
                    objTr.OptionB = clsCommon.myCstr(row("OptionB"))
                    objTr.OptionC = clsCommon.myCstr(row("OptionC"))
                    objTr.OptionD = clsCommon.myCstr(row("OptionD"))
                    objTr.Examname = clsCommon.myCstr(row("Examname"))
                    objTr.StudentName = clsCommon.myCstr(row("StudentName"))
                    objTr.paperID = clsCommon.myCstr(row("paperID"))
                    obj.ArrExamSubmit.Add(objTr)
                Next

                Dim qryMapping As String = "select StudentNAme,Examname,paperid from FBNPC_Exam_Question_Validtion where studentname='" & clsCommon.myCstr(txtSubject.Value) & "' and examname='" & clsCommon.myCstr(txtExam.Value) & "'"
                dtMapping = clsDBFuncationality.GetDataTable(qryMapping)

                For Each row As DataRow In dtMapping.Rows
                    Dim objTr As New clsExamMapping()
                    objTr.Hist_By = objCommonVar.CurrentUserCode
                    objTr.Hist_Version = obj.DocNo
                    objTr.Examname = clsCommon.myCstr(row("Examname"))
                    objTr.StudentName = clsCommon.myCstr(row("StudentName"))
                    objTr.paperID = clsCommon.myCstr(row("paperid"))
                    obj.ArrExamMapping.Add(objTr)
                Next


                If (obj.SaveData(obj, isNewEntry)) Then
                    clsCommon.ProgressBarHide()
                    common.clsCommon.MyMessageBoxShow("Data Saved Successfully", Me.Text)
                End If
            Else
                clsCommon.ProgressBarHide()
                common.clsCommon.MyMessageBoxShow("No Data Found", Me.Text)
            End If

        Catch ex As Exception
            clsCommon.ProgressBarHide()
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    
End Class
