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
Public Class FrmGroupProgramMapping
    Inherits FrmMainTranScreen
    Const colProgramCode As String = "Program Code"
    Const colProgramName As String = "Program Name"
    Const colRead As String = "Read"
    Const colSave As String = "Save"
    Const colDelete As String = "Delete"
    Const colReport As String = "Report"
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False

    Private Sub FrmGroupProgramMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNew()
    End Sub
    Private Sub AddNew()
        txtProgramGroupCode.Value = ""
        txtProgramGroupCode.MyReadOnly = False
        txtDesc.Text = ""
        gv.DataSource = Nothing
        LoadBlankGrid()
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtProgramGroupCode.Focus()
        gv.DataSource = Nothing
        FillProjectInGrid()
        chkReadAll.Checked = False
        chkSave.Checked = False
        chkDelete.Checked = False
        chkReport.Checked = False
    End Sub

    Sub LoadBlankGrid()

        gv.Rows.Clear()
        gv.Columns.Clear()

        Dim Program_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Program_Code.FormatString = ""
        Program_Code.HeaderText = "Program Code"
        Program_Code.Name = colProgramCode
        Program_Code.Width = 120
        Program_Code.ReadOnly = True
        gv.MasterTemplate.Columns.Add(Program_Code)

        Dim Program_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Program_Name.FormatString = ""
        Program_Name.HeaderText = "Program Name"
        Program_Name.Name = colProgramName
        Program_Name.Width = 150
        Program_Name.ReadOnly = True
        gv.MasterTemplate.Columns.Add(Program_Name)


        Dim Program_Read As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Program_Read.FormatString = ""
        Program_Read.HeaderText = "Read"
        Program_Read.Name = colRead
        Program_Read.Width = 70
        Program_Read.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Program_Read)

        Dim Program_Save As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Program_Save.FormatString = ""
        Program_Save.HeaderText = "Save"
        Program_Save.Name = colSave
        Program_Save.Width = 70
        Program_Save.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Program_Save)

        Dim Program_Delete As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Program_Delete.FormatString = ""
        Program_Delete.HeaderText = "Delete"
        Program_Delete.Name = colDelete
        Program_Delete.Width = 70
        Program_Delete.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Program_Delete)

        Dim Program_Report As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Program_Report.FormatString = ""
        Program_Report.HeaderText = "Report"
        Program_Report.Name = colReport
        Program_Report.Width = 70
        Program_Report.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Program_Report)

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
        Dim qry As String = " select program_code,Program_Name  from TSPL_PROGRAM_MASTER where type = '' "
        dt = clsDBFuncationality.GetDataTable(qry)
        If dt.Rows.Count > 0 Then
            gv.DataSource = Nothing
            For Each dr As DataRow In dt.Rows
                gv.Rows.AddNew()
                gv.Rows(gv.Rows.Count - 1).Cells(colProgramCode).Value = clsCommon.myCstr(dr("program_code"))
                gv.Rows(gv.Rows.Count - 1).Cells(colProgramName).Value = clsCommon.myCstr(dr("Program_Name"))
            Next
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsGroupProgramMappingMaster()
                obj.PROGRAM_GROUP_CODE = txtProgramGroupCode.Value
                obj.GROUP_DESCRIPTION = txtDesc.Text

                Dim Arr As New List(Of clsGroupProgramMappingDetail)
                For Each grow As GridViewRowInfo In gv.Rows
                    Dim objTr As New clsGroupProgramMappingDetail()
                    objTr.Program_Code = clsCommon.myCstr(grow.Cells(colProgramCode).Value)
                    objTr.READ = IIf(clsCommon.myCBool(grow.Cells(colRead).Value), 1, 0)
                    objTr.SAVE = IIf(clsCommon.myCBool(grow.Cells(colSave).Value), 1, 0)
                    objTr.DELETE = IIf(clsCommon.myCBool(grow.Cells(colDelete).Value), 1, 0)
                    objTr.REPORT = IIf(clsCommon.myCBool(grow.Cells(colReport).Value), 1, 0)
                    Arr.Add(objTr)
                Next
                If (Arr Is Nothing OrElse Arr.Count <= 0) Then
                    common.clsCommon.MyMessageBoxShow("Please select at least one Program.")
                    Return
                End If
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_PROGRAM_GROUP_MASTER where PROGRAM_GROUP_CODE='" & obj.PROGRAM_GROUP_CODE & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry, Arr)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.PROGRAM_GROUP_CODE)
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

            If clsCommon.myLen(txtProgramGroupCode.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Group Code can not be blank.")
                txtProgramGroupCode.Focus()
                Return False
            End If
            If clsCommon.myLen(txtProgramGroupCode.Value) > 0 Then
                Dim chkGroupCode As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(*)  from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE ='" + txtProgramGroupCode.Value + "'"))
                If chkGroupCode <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Invalid Group Code.If you want to use this group first insert group in 'User Group Master screen'.")
                    txtProgramGroupCode.Focus()
                    Return False
                End If
            End If
            If clsCommon.myLen(txtDesc.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Description can not be blank.")
                txtDesc.Focus()
                Return False
            End If

        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Sub LoadData(ByVal strProgramGroupCode As String)
        Try
            AddNew()
            isInsideLoadData = True
            Dim obj As clsGroupProgramMappingMaster = clsGroupProgramMappingMaster.GetData(strProgramGroupCode, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then
                txtProgramGroupCode.Value = obj.PROGRAM_GROUP_CODE
                txtDesc.Text = obj.GROUP_DESCRIPTION
                Dim ii As Integer = 0
                Dim count As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(" select count(*) from TSPL_PROGRAM_GROUP_DETAIL where PROGRAM_GROUP_CODE ='" + obj.PROGRAM_GROUP_CODE + "' "))
                If count > 0 Then
                    For Each objtr As clsGroupProgramMappingDetail In obj.Arr
                        For Each grow As GridViewRowInfo In gv.Rows
                            If clsCommon.CompairString(clsCommon.myCstr(grow.Cells(colProgramCode).Value), objtr.Program_Code) = CompairStringResult.Equal Then
                                If objtr.READ = 1 Then
                                    gv.Rows(ii).Cells(colRead).Value = True
                                End If
                                If objtr.SAVE = 1 Then
                                    gv.Rows(ii).Cells(colSave).Value = True
                                End If
                                If objtr.DELETE = 1 Then
                                    gv.Rows(ii).Cells(colDelete).Value = True
                                End If
                                If objtr.REPORT = 1 Then
                                    gv.Rows(ii).Cells(colReport).Value = True
                                End If

                            End If
                        Next
                        ii += 1
                        

                    Next
                End If

                isInsideLoadData = False
                txtProgramGroupCode.MyReadOnly = True
                btnSave.Text = "Update"
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub txtProgramGroupCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtProgramGroupCode._MYNavigator

        'Dim WhrCls As String = ""

        'Dim qry As String = "select PROGRAM_GROUP_CODE  from TSPL_PROGRAM_GROUP_MASTER  Where 2=2  "
        'Select Case NavType
        '    Case NavigatorType.First
        '        qry += " and TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE=(select MIN(PROGRAM_GROUP_CODE) from TSPL_PROGRAM_GROUP_MASTER)"
        '    Case NavigatorType.Last
        '        qry += " and TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE=(select MAX(PROGRAM_GROUP_CODE) from TSPL_PROGRAM_GROUP_MASTER)"
        '    Case NavigatorType.Next
        '        qry += " and TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE=(select Min(PROGRAM_GROUP_CODE) from TSPL_PROGRAM_GROUP_MASTER where PROGRAM_GROUP_CODE > '" + txtProgramGroupCode.Value + "')"
        '    Case NavigatorType.Previous
        '        qry += " and TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE=(select Max(PROGRAM_GROUP_CODE) from TSPL_PROGRAM_GROUP_MASTER where PROGRAM_GROUP_CODE < '" + txtProgramGroupCode.Value + "')"
        '    Case NavigatorType.Current
        '        qry += " and TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE='" + txtProgramGroupCode.Value + "'"
        'End Select

        'Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        'If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
        '    txtProgramGroupCode.Value = clsCommon.myCstr(dt.Rows(0)("PROGRAM_GROUP_CODE"))
        'End If
        'LoadData(txtProgramGroupCode.Value)

        Dim WhrCls As String = ""

        Dim qry As String = "select USER_GROUP_CODE  from TSPL_USER_GROUP_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE=(select MIN(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE=(select MAX(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE=(select Min(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE > '" + txtProgramGroupCode.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE=(select Max(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE < '" + txtProgramGroupCode.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE='" + txtProgramGroupCode.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtProgramGroupCode.Value = clsCommon.myCstr(dt.Rows(0)("USER_GROUP_CODE"))
        End If
        LoadData(txtProgramGroupCode.Value)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If myMessages.deleteConfirm() Then
            deleteData()
        End If
    End Sub

    Sub deleteData()
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            If clsCommon.myLen(txtProgramGroupCode.Value) > 0 Then

                If clsGroupProgramMappingMaster.deleteData(txtProgramGroupCode.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    AddNew()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a Group Code to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            trans.Rollback()
        End Try
    End Sub

    Private Sub txtProgramGroupCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtProgramGroupCode._MYValidating

        ' Dim str As String = "select count(*) from TSPL_PROGRAM_GROUP_MASTER where PROGRAM_GROUP_CODE = '" + txtProgramGroupCode.Value + "' "
        Dim str As String = "select count(*) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE = '" + txtProgramGroupCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtProgramGroupCode.MyReadOnly = False
        Else
            txtProgramGroupCode.MyReadOnly = True
        End If

        If txtProgramGroupCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = " select USER_GROUP_CODE as Code,GROUP_DESCRIPTION as Name  from TSPL_USER_GROUP_MASTER "
            txtProgramGroupCode.Value = clsCommon.ShowSelectForm("TSPL_USER_GROUP_MASTER", qry, "Code", "", txtProgramGroupCode.Value, "TSPL_USER_GROUP_MASTER.USER_GROUP_CODE", isButtonClicked)
            If clsCommon.myLen(txtProgramGroupCode.Value) > 0 Then
                LoadData(txtProgramGroupCode.Value)
            Else
                AddNew()
            End If
        End If
    End Sub

    Private Sub rMenuExit_Click(sender As Object, e As EventArgs) Handles rMenuExit.Click
        Me.Close()
    End Sub

    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        Dim str As String
        str = " select TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE as [PROGRAM GROUP CODE] ,TSPL_PROGRAM_GROUP_MASTER.GROUP_DESCRIPTION as [PROGRAM GROUP DESC], TSPL_PROGRAM_GROUP_DETAIL.Program_Code as [PROGRAM CODE],TSPL_PROGRAM_MASTER.Program_Name as [PROGRAM NAME],isREAD,isSAVE,isDELETE,isREPORT from TSPL_PROGRAM_GROUP_MASTER left outer join TSPL_PROGRAM_GROUP_DETAIL on TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE =TSPL_PROGRAM_GROUP_DETAIL.PROGRAM_GROUP_CODE left outer join TSPL_PROGRAM_MASTER on TSPL_PROGRAM_MASTER.Program_Code =TSPL_PROGRAM_GROUP_DETAIL.Program_Code "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Me.Controls.Add(gv)
        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        If transportSql.importExcel(gv, "PROGRAM GROUP CODE", "PROGRAM GROUP DESC", "PROGRAM CODE", "PROGRAM NAME", "isREAD", "isSAVE", "isDELETE", "isREPORT") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim strProgramGroupCode As String = clsCommon.myCstr(grow.Cells("PROGRAM GROUP CODE").Value)
                    Dim strProgramGroupDesc As String = clsCommon.myCstr(grow.Cells("PROGRAM GROUP DESC").Value)
                    Dim strProgramCode As String = clsCommon.myCstr(grow.Cells("PROGRAM CODE").Value)
                    Dim strProgramName As String = clsCommon.myCstr(grow.Cells("PROGRAM NAME").Value)
                    Dim strIsRead As String = clsCommon.myCstr(grow.Cells("isREAD").Value)
                    Dim strIsSave As String = clsCommon.myCstr(grow.Cells("isSAVE").Value)
                    Dim strIsDelete As String = clsCommon.myCstr(grow.Cells("isDELETE").Value)
                    Dim strIsReport As String = clsCommon.myCstr(grow.Cells("isREPORT").Value)

                    linno += 1
                    clsCommon.ProgressBarPercentUpdate((linno * 100) / gv.RowCount - 1, "Importing " + clsCommon.myCstr(linno) + "/" + clsCommon.myCstr(gv.RowCount - 1))
                    Dim coll As New Hashtable()
                    Dim coll2 As New Hashtable()
                    If clsCommon.myLen(strProgramGroupCode) <= 0 Then
                        Throw New Exception("Program Group Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strProgramGroupCode) > 30 Then
                        Throw New Exception("Please check ! length of Program Group Code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "PROGRAM_GROUP_CODE", strProgramGroupCode)
                    clsCommon.AddColumnsForChange(coll2, "PROGRAM_GROUP_CODE", strProgramGroupCode)

                    If clsCommon.myLen(strProgramGroupDesc) <= 0 Then
                        Throw New Exception("Program Group Description should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strProgramGroupDesc) > 200 Then
                        Throw New Exception("Please check ! length of Program Group Description should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "GROUP_DESCRIPTION", strProgramGroupDesc)
                    Dim strCreatedBy As String = clsCommon.myCstr(objCommonVar.CurrentUserCode)
                    Dim strCreatedDate As String = Nothing
                    strCreatedDate = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy") ' clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt")
                    Dim Count As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select Count(*) from TSPL_PROGRAM_GROUP_MASTER Where PROGRAM_GROUP_CODE='" + strProgramGroupCode + "'", trans))
                    If Count > 0 Then
                        clsCommon.AddColumnsForChange(coll, "Modify_By", strCreatedBy)
                        clsCommon.AddColumnsForChange(coll, "Modify_Date", strCreatedDate)
                    Else
                        clsCommon.AddColumnsForChange(coll, "Created_By", strCreatedBy)
                        clsCommon.AddColumnsForChange(coll, "Created_Date", strCreatedDate)
                    End If

                    If clsCommon.myLen(strProgramCode) <= 0 Then
                        Throw New Exception("Program Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strProgramCode) > 0 Then
                        Dim chkProgramCode As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select count(*) from TSPL_PROGRAM_MASTER where Program_Code = '" + strProgramCode + "'", trans))
                        If chkProgramCode <= 0 Then
                            Throw New Exception("Invalid Program Code. line no. " + clsCommon.myCstr(linno) + ".")
                        End If
                    End If

                    clsCommon.AddColumnsForChange(coll2, "Program_Code", strProgramCode)

                    If clsCommon.CompairString(strIsRead, "1") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isREAD", "1")
                    ElseIf clsCommon.CompairString(strIsRead, "0") = CompairStringResult.Equal Or clsCommon.CompairString(strIsRead, " ") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isREAD", "0")
                    Else
                        Throw New Exception("Please Enter isRead as '1' Or '1' Or Leave Blank at Line No '" + linno + "'")
                    End If

                    If clsCommon.CompairString(strIsSave, "1") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isSAVE", "1")
                    ElseIf clsCommon.CompairString(strIsSave, "0") = CompairStringResult.Equal Or clsCommon.CompairString(strIsSave, " ") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isSAVE", "0")
                    Else
                        Throw New Exception("Please Enter isSAVE as '1' Or '1' Or Leave Blank at Line No '" + linno + "'")
                    End If

                    If clsCommon.CompairString(strIsDelete, "1") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isDELETE", "1")
                    ElseIf clsCommon.CompairString(strIsDelete, "0") = CompairStringResult.Equal Or clsCommon.CompairString(strIsDelete, " ") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isDELETE", "0")
                    Else
                        Throw New Exception("Please Enter isDELETE as '1' Or '1' Or Leave Blank at Line No '" + linno + "'")
                    End If

                    If clsCommon.CompairString(strIsReport, "1") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isREPORT", "1")
                    ElseIf clsCommon.CompairString(strIsReport, "0") = CompairStringResult.Equal Or clsCommon.CompairString(strIsReport, " ") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll2, "isREPORT", "0")
                    Else
                        Throw New Exception("Please Enter isREPORT as '1' Or '1' Or Leave Blank at Line No '" + linno + "'")
                    End If
                    If Count <= 0 Then
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_GROUP_MASTER", OMInsertOrUpdate.Insert, "", trans)
                    Else
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_GROUP_MASTER", OMInsertOrUpdate.Update, "PROGRAM_GROUP_CODE='" + strProgramGroupCode + "'", trans)
                    End If
                    Dim Count2 As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select Count(*) from TSPL_PROGRAM_GROUP_DETAIL Where PROGRAM_GROUP_CODE= '" + strProgramGroupCode + "' and Program_Code='" + strProgramCode + "'", trans))
                    If Count <= 0 Then
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_PROGRAM_GROUP_DETAIL", OMInsertOrUpdate.Insert, "", trans)
                    Else
                        clsDBFuncationality.ExecuteNonQuery("delete TSPL_PROGRAM_GROUP_DETAIL where  PROGRAM_GROUP_CODE= '" + strProgramGroupCode + "' and Program_Code='" + strProgramCode + "'", trans)
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_PROGRAM_GROUP_DETAIL", OMInsertOrUpdate.Insert, "", trans)
                        'isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_PROGRAM_GROUP_DETAIL", OMInsertOrUpdate.Insert, "PROGRAM_GROUP_CODE= '" + strProgramGroupCode + "' and Program_Code='" + strProgramCode + "'", trans)
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

    Private Sub chkReadAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkReadAll.CheckedChanged
        If gv.Rows.Count > 0 AndAlso isInsideLoadData = False Then
            Dim ii As Integer = 0
            If chkReadAll.Checked = True Then
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colRead).Value = True
                    ii = ii + 1
                Next
            Else
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colRead).Value = False
                    ii = ii + 1
                Next
            End If
        End If
    End Sub

    
    Private Sub chkSave_CheckedChanged(sender As Object, e As EventArgs) Handles chkSave.CheckedChanged
        If gv.Rows.Count > 0 AndAlso isInsideLoadData = False Then
            Dim ii As Integer = 0
            If chkSave.Checked = True Then
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colSave).Value = True
                    ii = ii + 1
                Next
            Else
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colSave).Value = False
                    ii = ii + 1
                Next
            End If
        End If
    End Sub

    Private Sub chkDelete_CheckedChanged(sender As Object, e As EventArgs) Handles chkDelete.CheckedChanged
        If gv.Rows.Count > 0 AndAlso isInsideLoadData = False Then
            Dim ii As Integer = 0
            If chkDelete.Checked = True Then
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colDelete).Value = True
                    ii = ii + 1
                Next
            Else
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colDelete).Value = False
                    ii = ii + 1
                Next
            End If
        End If
    End Sub

    Private Sub chkReport_CheckedChanged(sender As Object, e As EventArgs) Handles chkReport.CheckedChanged
        If gv.Rows.Count > 0 AndAlso isInsideLoadData = False Then
            Dim ii As Integer = 0
            If chkReport.Checked = True Then
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colReport).Value = True
                    ii = ii + 1
                Next
            Else
                For Each grow As GridViewRowInfo In gv.Rows
                    gv.Rows(ii).Cells(colReport).Value = False
                    ii = ii + 1
                Next
            End If
        End If
    End Sub
End Class
