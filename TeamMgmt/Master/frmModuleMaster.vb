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

Public Class FrmModuleMaster
    Inherits FrmMainTranScreen
    Const colPojectCode As String = "Project Code"
    Const colProjectName As String = "Project Description"
    Const colStatus As String = "Status"
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False


    Private Sub FrmModuleMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNew()
    End Sub

    Private Sub AddNew()
        txtModuleCode.Value = ""
        txtModuleCode.MyReadOnly = False
        txtDesc.Text = ""
        gv.DataSource = Nothing
        LoadBlankGrid()
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtModuleCode.Focus()
        gv.DataSource = Nothing
        FillProjectInGrid()
    End Sub

    Sub LoadBlankGrid()

        gv.Rows.Clear()
        gv.Columns.Clear()

        Dim Project_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Project_Code.FormatString = ""
        Project_Code.HeaderText = "Project Code"
        Project_Code.Name = colPojectCode
        Project_Code.Width = 120
        Project_Code.ReadOnly = True
        gv.MasterTemplate.Columns.Add(Project_Code)

        Dim Project_Desc As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Project_Desc.FormatString = ""
        Project_Desc.HeaderText = "Project Description"
        Project_Desc.Name = colProjectName
        Project_Desc.Width = 150
        Project_Desc.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Project_Desc)


        Dim Project_Status As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Project_Status.FormatString = ""
        Project_Status.HeaderText = "Status"
        Project_Status.Name = colStatus
        Project_Status.Width = 70
        Project_Status.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Project_Status)

        gv.AllowAddNewRow = False
        gv.ShowGroupPanel = False
        gv.AllowColumnReorder = False
        gv.AllowRowReorder = False
        gv.EnableSorting = False
        gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv.MasterTemplate.ShowRowHeaderColumn = False
    End Sub
   

    Sub FillProjectInGrid()
        Dim dt As DataTable
        Dim qry As String = "select project_code , project_description  from TSPL_PROJECT_MASTER"
        dt = clsDBFuncationality.GetDataTable(qry)
        If dt.Rows.Count > 0 Then
            gv.DataSource = Nothing
            For Each dr As DataRow In dt.Rows
                gv.Rows.AddNew()
                gv.Rows(gv.Rows.Count - 1).Cells(colPojectCode).Value = clsCommon.myCstr(dr("project_code"))
                gv.Rows(gv.Rows.Count - 1).Cells(colPojectCode).ReadOnly = True
                gv.Rows(gv.Rows.Count - 1).Cells(colProjectName).Value = clsCommon.myCstr(dr("project_description"))
                gv.Rows(gv.Rows.Count - 1).Cells(colProjectName).ReadOnly = True
            Next
        End If
    End Sub
    Sub SetGridFormationOFgv()
        gv.TableElement.TableHeaderHeight = 40
        gv.MasterTemplate.ShowRowHeaderColumn = False
        'For ii As Integer = 0 To gv.Columns.Count - 1
        '    gv.Columns(ii).ReadOnly = True
        '    gv.Columns(ii).IsVisible = False
        'Next

        gv.Columns("Project Code").IsVisible = True
        gv.Columns("Project Code").Width = 100
        gv.Columns("Project Code").HeaderText = "Project Code"

        gv.Columns("Project Description").IsVisible = True
        gv.Columns("Project Description").Width = 100
        gv.Columns("Project Description").HeaderText = "Project Description"

        gv.Columns("Status").IsVisible = True
        gv.Columns("Status").Width = 100
        gv.Columns("Status").HeaderText = "Status"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsModuleMaster()
                obj.MODULE_CODE = txtModuleCode.Value
                obj.MODULE_DESCRIPTION = txtDesc.Text

                Dim Arr As New List(Of clsModuleDetail)
                For Each grow As GridViewRowInfo In gv.Rows
                    Dim objTr As New clsModuleDetail()
                    objTr.PROJECT_CODE = clsCommon.myCstr(grow.Cells(colPojectCode).Value)
                    Dim strStatus As Boolean = clsCommon.myCBool(grow.Cells(colStatus).Value)
                    If strStatus Then
                        Arr.Add(objTr)
                    End If
                Next

                If (Arr Is Nothing OrElse Arr.Count <= 0) Then
                    common.clsCommon.MyMessageBoxShow("Please select at least one Project")
                    Return
                End If
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_MODULE_MASTER where MODULE_CODE='" & obj.MODULE_CODE & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry, Arr)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.MODULE_CODE) 'LoadData(obj.Service_Order_No, NavigatorType.Current)
                    btnSave.Text = "Update"
                    btnDelete.Enabled = True
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Function AllowToSave() As Boolean
        Try

            If clsCommon.myLen(txtModuleCode.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Module Code can not be blank.")
                txtModuleCode.Focus()
                Return False
            End If
            If clsCommon.myLen(txtDesc.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Module Description can not be blank.")
                txtDesc.Focus()
                Return False
            End If

        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Sub LoadData(ByVal strFarmerOrderNo As String)
        AddNew()
        isInsideLoadData = True
        'LoadBlankGrid()
        Dim obj As clsModuleMaster = clsModuleMaster.GetData(strFarmerOrderNo, Nothing)
        isNewEntry = False
        If obj IsNot Nothing Then
            txtModuleCode.Value = obj.MODULE_CODE
            txtDesc.Text = obj.MODULE_DESCRIPTION

            For Each objtr As clsModuleDetail In obj.Arr
                'Dim grow As GridViewRowInfo = gv.Rows.AddNew()
                'grow.Cells(colPojectCode).Value = objtr.PROJECT_CODE
                'grow.Cells(colProjectName).Value = objtr.PROJECT_DESCRIPTION
                'grow.Cells(colStatus).Value = 1
                For ii As Integer = 0 To gv.Rows.Count - 1
                    If clsCommon.myCstr(gv.Rows(ii).Cells(colPojectCode).Value) = objtr.PROJECT_CODE Then
                        gv.Rows(ii).Cells(colStatus).Value = 1
                    End If
                Next
            Next
            isInsideLoadData = False
            txtModuleCode.MyReadOnly = True
            btnSave.Text = "Update"
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub txtModuleCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtModuleCode._MYNavigator
        Dim WhrCls As String = ""

        Dim qry As String = "select MODULE_CODE  from TSPL_MODULE_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_MODULE_MASTER.MODULE_CODE=(select MIN(MODULE_CODE) from TSPL_MODULE_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_MODULE_MASTER.MODULE_CODE=(select MAX(MODULE_CODE) from TSPL_MODULE_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_MODULE_MASTER.MODULE_CODE=(select Min(MODULE_CODE) from TSPL_MODULE_MASTER where MODULE_CODE > '" + txtModuleCode.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_MODULE_MASTER.MODULE_CODE=(select Max(MODULE_CODE) from TSPL_MODULE_MASTER where MODULE_CODE < '" + txtModuleCode.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_MODULE_MASTER.MODULE_CODE='" + txtModuleCode.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtModuleCode.Value = clsCommon.myCstr(dt.Rows(0)("MODULE_CODE"))
        End If
        LoadData(txtModuleCode.Value)


    End Sub

    Private Sub txtModuleCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtModuleCode._MYValidating
        Dim str As String = "select count(*) from TSPL_MODULE_MASTER where MODULE_CODE = '" + txtModuleCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtModuleCode.MyReadOnly = False
        Else
            txtModuleCode.MyReadOnly = True
        End If

        If txtModuleCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = " select MODULE_CODE as Code,MODULE_DESCRIPTION as Name  from TSPL_MODULE_MASTER "
            txtModuleCode.Value = clsCommon.ShowSelectForm("TSPL_MODULE_MASTER", qry, "Code", "", txtModuleCode.Value, "TSPL_MODULE_MASTER.MODULE_CODE", isButtonClicked)
            If clsCommon.myLen(txtModuleCode.Value) > 0 Then
                LoadData(txtModuleCode.Value)
            Else
                AddNew()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If myMessages.deleteConfirm() Then
            deleteData()
        End If

    End Sub
    Sub deleteData()
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            If clsCommon.myLen(txtModuleCode.Value) > 0 Then

                If clsModuleMaster.deleteData(txtModuleCode.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    AddNew()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a Module to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        GC.Collect()
    End Sub


    Private Sub RadMenuItem2_Click(sender As Object, e As EventArgs) Handles RadMenuItem2.Click
        Dim str As String
        str = " select TSPL_MODULE_MASTER.MODULE_CODE as [MODULE CODE],TSPL_MODULE_MASTER.MODULE_DESCRIPTION as [MODULE DESCRIPTION],TSPL_MODULE_DETAIL.PROJECT_CODE as [PROJECT CODE], TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION as [PROJECT DESCRIPTION] from TSPL_MODULE_MASTER left outer join TSPL_MODULE_DETAIL on TSPL_MODULE_DETAIL.MODULE_CODE = TSPL_MODULE_MASTER.MODULE_CODE left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE=TSPL_MODULE_DETAIL.PROJECT_CODE    "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Me.Controls.Add(gv)
        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        If transportSql.importExcel(gv, "MODULE CODE", "MODULE DESCRIPTION", "PROJECT CODE", "PROJECT DESCRIPTION") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim strModuleCode As String = clsCommon.myCstr(grow.Cells("MODULE CODE").Value)
                    Dim strModuleDesc As String = clsCommon.myCstr(grow.Cells("MODULE DESCRIPTION").Value)
                    Dim strProjectCode As String = clsCommon.myCstr(grow.Cells("PROJECT CODE").Value)

                    linno += 1
                    clsCommon.ProgressBarPercentUpdate((linno * 100) / gv.RowCount - 1, "Importing " + clsCommon.myCstr(linno) + "/" + clsCommon.myCstr(gv.RowCount - 1))
                    Dim coll As New Hashtable()
                    Dim coll2 As New Hashtable()
                    If clsCommon.myLen(strModuleCode) <= 0 Then
                        Throw New Exception("Module Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strModuleCode) > 30 Then
                        Throw New Exception("Please check ! length of Module Code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "MODULE_CODE", strModuleCode)
                    clsCommon.AddColumnsForChange(coll2, "MODULE_CODE", strModuleCode)

                    If clsCommon.myLen(strModuleDesc) <= 0 Then
                        Throw New Exception("Module Description should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strModuleDesc) > 200 Then
                        Throw New Exception("Please check ! length of Module Description should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "MODULE_DESCRIPTION", strModuleDesc)
                    Dim strCreatedBy As String = clsCommon.myCstr(objCommonVar.CurrentUserCode)
                    Dim strCreatedDate As String = Nothing
                    strCreatedDate = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy") ' clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt")
                    Dim Count As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select Count(*) from TSPL_MODULE_MASTER Where MODULE_CODE='" + strModuleCode + "'", trans))

                    clsCommon.AddColumnsForChange(coll, "Modify_By", strCreatedBy)
                    clsCommon.AddColumnsForChange(coll, "Modify_Date", strCreatedDate)
                    If Count <= 0 Then
                        clsCommon.AddColumnsForChange(coll, "Created_By", strCreatedBy)
                        clsCommon.AddColumnsForChange(coll, "Created_Date", strCreatedDate)
                    End If

                    If clsCommon.myLen(strProjectCode) > 0 Then
                        Dim chkProgramCode As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select count(*) from TSPL_PROJECT_MASTER where PROJECT_CODE = '" + strProjectCode + "'", trans))
                        If chkProgramCode <= 0 Then
                            Throw New Exception("Invalid Program Code. line no. " + clsCommon.myCstr(linno) + ".")
                        End If
                        clsCommon.AddColumnsForChange(coll2, "PROJECT_CODE", strProjectCode)
                    End If




                    If Count <= 0 Then
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MODULE_MASTER", OMInsertOrUpdate.Insert, "", trans)
                    Else
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MODULE_MASTER", OMInsertOrUpdate.Update, "MODULE_CODE='" + strModuleCode + "'", trans)
                    End If
                    Dim Count2 As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select Count(*) from TSPL_MODULE_DETAIL Where MODULE_CODE= '" + strModuleCode + "' and PROJECT_CODE='" + strProjectCode + "'", trans))
                    If Count <= 0 Then
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_MODULE_DETAIL", OMInsertOrUpdate.Insert, "", trans)
                    Else
                        clsDBFuncationality.ExecuteNonQuery("delete TSPL_MODULE_DETAIL where  MODULE_CODE= '" + strModuleCode + "' and PROJECT_CODE='" + strProjectCode + "'", trans)
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_MODULE_DETAIL", OMInsertOrUpdate.Insert, "", trans)
                    End If
                Next
                If isSaved Then
                    trans.Commit()
                    clsCommon.ProgressBarPercentHide()
                    RadMessageBox.Show("Data Imported Successfully ...")
                Else
                    Throw New Exception("Error in Import")
                End If
            Catch ex As Exception
                trans.Rollback()
                clsCommon.ProgressBarPercentHide()
                RadMessageBox.Show(ex.Message)
            Finally
                Me.Controls.Remove(gv)

            End Try
        End If
        Me.Controls.Remove(gv)
    End Sub
    Private Sub rMenuExit_Click(sender As Object, e As EventArgs) Handles rMenuExit.Click
        Me.Close()
    End Sub

End Class
