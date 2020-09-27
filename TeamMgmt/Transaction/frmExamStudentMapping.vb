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

Public Class frmExamStudentMapping
    Inherits FrmMainTranScreen
    Public EntryNo As String = ""
    Const colQCStatus As String = "COLQCSTATUS"
    Const colQuestionCode As String = "COLICODE"
    Const colQuestion As String = "COLIName"
    Const colDesc As String = "COLdesc"
    Private isNewEntry As Boolean = False

    Private Sub FrmRequestAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBlankGrid()
        LoadCustomer()
        isNewEntry = True

    End Sub
    Sub LoadBlankGrid()
        gv1.Rows.Clear()
        gv1.Columns.Clear()

        Dim repoQCStatus As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        repoQCStatus.HeaderText = "chk"
        repoQCStatus.Name = colQCStatus
        repoQCStatus.ReadOnly = False
        repoQCStatus.IsVisible = True
        repoQCStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        gv1.MasterTemplate.Columns.Add(repoQCStatus)


        Dim repoICode As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        repoICode.FormatString = ""
        repoICode.HeaderText = "Exam Code"
        repoICode.Name = colQuestionCode
        repoICode.TextImageRelation = TextImageRelation.TextBeforeImage
        repoICode.Width = 100
        gv1.MasterTemplate.Columns.Add(repoICode)

        Dim repoQuestion As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        repoQuestion.FormatString = ""
        repoQuestion.HeaderText = "Name"
        repoQuestion.Name = colQuestion
        repoQuestion.TextImageRelation = TextImageRelation.TextBeforeImage
        repoQuestion.Width = 50
        gv1.MasterTemplate.Columns.Add(repoQuestion)

        Dim repoDescription As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        repoDescription.FormatString = ""
        repoDescription.HeaderText = "Description"
        repoDescription.Name = colDesc
        repoDescription.TextImageRelation = TextImageRelation.TextBeforeImage
        repoDescription.Width = 200
        gv1.MasterTemplate.Columns.Add(repoDescription)

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
        Dim qry As String = "SELECT CAST(0 as BIT ) as Status,FBNPC_EXAMLISTNAME.ExamID as Code,FBNPC_EXAMLISTNAME.ExamName,FBNPC_EXAMLISTNAME.Description FROM FBNPC_EXAMLISTNAME "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            Dim ii As Integer = 1
            For Each dr As DataRow In dt.Rows
                gv1.Rows.AddNew()
                gv1.Rows(gv1.Rows.Count - 1).Cells(colQCStatus).Value = clsCommon.myCBool(dr("Status"))
                gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestionCode).Value = clsCommon.myCstr(dr("Code"))
                gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestion).Value = clsCommon.myCstr(dr("ExamName"))
                gv1.Rows(gv1.Rows.Count - 1).Cells(colDesc).Value = clsCommon.myCstr(dr("Description"))
                ii = ii + 1
            Next

        End If
        gv1.MasterTemplate.SummaryRowsBottom.Clear()
        gv1.AllowAddNewRow = False
        '  gv1.Columns("ExamName").Width = 50
        ' gv1.Columns("Description").Width = 100

    End Sub
    Private Sub txtsSection__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtsSection._MYValidating
        Try
            Dim qry As String = "select User_Code as Code ,First_Name as [First Name],Last_Name as [Last Name],E_mail as [Email ID],Phone as [Phone No]  from FBNPC_USER_MASTER "

            txtsSection.Value = clsCommon.ShowSelectForm("Users", qry, "Code", "", txtsSection.Value, "Code", isButtonClicked)
            If clsCommon.myLen(clsCommon.myCstr(txtsSection.Value)) > 0 Then
                lblSection.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT First_Name FROM FBNPC_USER_MASTER WHERE User_Code ='" & clsCommon.myCstr(txtsSection.Value) & "'"))
            Else
                lblSection.Text = ""
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
  
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        btnGo.Text = "Save"
        lblSection.Text = ""
        txtDocNo.Value = ""
        isNewEntry = True
        btnGo.Enabled = True
        LoadCustomer()
        txtsSection.Value = ""
 
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        SaveData(False)
    End Sub
    Sub LoadData(ByVal strCode As String, ByVal NavTyep As NavigatorType)
        Dim obj As New clsExamStudentMapping()
        Try
            btnGo.Enabled = True
            LoadBlankGrid()
            obj = clsExamStudentMapping.GetData(strCode, NavTyep)
            If (obj IsNot Nothing AndAlso clsCommon.myLen(obj.DocNo) > 0) Then
                btnGo.Text = "Update"
            
                txtDocNo.Value = obj.DocNo
                txtsSection.Value = obj.StudentName
                lblSection.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select First_Name from FBNPC_USER_MASTER where User_Code='" + txtsSection.Value + "'"))
             
                isNewEntry = False
                If obj.Arr IsNot Nothing AndAlso obj.Arr.Count > 0 Then
                    For Each objTr As clsExamStudentMappingDetail In obj.Arr
                        gv1.Rows.AddNew()
                        gv1.Rows(gv1.Rows.Count - 1).Cells(colQCStatus).Value = objTr.QusSelect
                        gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestionCode).Value = objTr.ExamCode
                        gv1.Rows(gv1.Rows.Count - 1).Cells(colQuestion).Value = objTr.ExamName
                        gv1.Rows(gv1.Rows.Count - 1).Cells(colDesc).Value = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Description from FBNPC_EXAMLISTNAME where ExamID='" + objTr.ExamCode + "'"))

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
    Sub Reset()
        txtsSection.Value = ""
        btnGo.Text = "Save"
        lblSection.Text = ""
        txtDocNo.Value = ""
        isNewEntry = True
        btnGo.Enabled = True
        LoadCustomer()

    End Sub
    Private Sub txtDocNo__MYNavigator(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal NavType As common.NavigatorType) Handles txtDocNo._MYNavigator
        Try
            Dim qst As String = "select count(*) from FBNPC_EXAM_STUDENT_MAPPING_HEAD where ESM_Code='" + txtDocNo.Value + "' "
            Dim count As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(qst))
            LoadData(txtDocNo.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub txtDocNo__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles txtDocNo._MYValidating
        Dim qry As String = "select FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESm_Code as Code,FBNPC_EXAM_STUDENT_MAPPING_HEAD.StudentName as [Student Code],FBNPC_USER_MASTER.First_Name as [Student Name] from FBNPC_EXAM_STUDENT_MAPPING_HEAD left outer join FBNPC_USER_MASTER on FBNPC_USER_MASTER.User_code=FBNPC_EXAM_STUDENT_MAPPING_HEAD.StudentName "
        LoadData(clsCommon.ShowSelectForm("GRNFilterFND", qry, "Code", "", txtDocNo.Value, "Code", isButtonClicked), NavigatorType.Current)
    End Sub
    Sub SaveData(ByVal ChekBtnPost As Boolean, Optional ByVal isamendment As Boolean = False)
        Dim issaved As Boolean = False
        Dim obj As New clsExamStudentMapping()
        Try
           
            obj.DocNo = txtDocNo.Value
            If isNewEntry Then
                Dim Sql As String = "SELECT MAX(ESM_Code) as document_No from FBNPC_EXAM_STUDENT_MAPPING_HEAD "
                obj.DocNo = clsCommon.myCstr(clsDBFuncationality.getSingleValue(Sql))
                If clsCommon.myLen(obj.DocNo) > 0 Then
                    obj.DocNo = clsCommon.incval(obj.DocNo)
                Else
                    obj.DocNo = "SEM0000000001"
                End If
            End If
            obj.StudentName = txtsSection.Value
            obj.Arr = New List(Of clsExamStudentMappingDetail)
            For Each grow As GridViewRowInfo In gv1.Rows
                Dim objTr As New clsExamStudentMappingDetail()
                If clsCommon.myCBool(grow.Cells(colQCStatus).Value) = True Then
                    objTr.ExamCode = clsCommon.myCstr(grow.Cells(colQuestionCode).Value)
                    objTr.QusSelect = clsCommon.myCBool(grow.Cells(colQCStatus).Value)
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
    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteData()
    End Sub

    Sub DeleteData()
        Try
            Dim Reason As String = ""
            If (myMessages.deleteConfirm()) Then
                If (clsExamStudentMapping.DeleteData(txtDocNo.Value)) Then
                    common.clsCommon.MyMessageBoxShow("Data Deleted Successfully ")
                    Reset()
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
End Class
