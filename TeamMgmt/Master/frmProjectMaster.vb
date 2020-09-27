Imports common
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Net.WebClient
Imports System.Net
Imports Telerik.WinControls.UI

Public Class FrmProjectMaster
    Private isNewEntry As Boolean = False
    Private Sub FrmProjectMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Private Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(clsCommon.myCstr(txtProjectCode.Value)) <= 0 Or clsCommon.myLen(clsCommon.myCstr(txtProjectCode.Text)) > 30 Then
                clsCommon.MyMessageBoxShow("Project Code cant not be blank", Me.Text)
                txtProjectCode.Focus()
                txtProjectCode.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtDesc.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Description cant not be blank", Me.Text)
                txtDesc.Focus()
                txtDesc.Select()
                Return False
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
        Return True
    End Function
    Sub SaveData()
        Try
            If AllowToSave() Then
                Dim obj As New clsProjectMaster()
                obj.PROJECT_CODE = txtProjectCode.Value
                obj.PROJECT_DESCRIPTION = txtDesc.Text
                Dim qry As Integer = clsDBFuncationality.getSingleValue("select count(PROJECT_CODE) from TSPL_PROJECT_MASTER WHERE PROJECT_CODE='" + obj.PROJECT_CODE + "'")
                If (qry = 0) Then
                    isNewEntry = True
                Else
                    isNewEntry = False
                End If
                If (clsProjectMaster.SaveData(obj, isNewEntry)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.PROJECT_CODE, NavigatorType.Current)
                    btnSave.Text = "Update"
                    btnDelete.Enabled = True
                Else
                    btnSave.Text = "Save"
                    btnDelete.Enabled = False
                End If
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub
    Sub LoadData(ByVal strCode As String, ByVal NavTyep As NavigatorType)
        Dim obj As clsProjectMaster = clsProjectMaster.GetData(strCode, NavTyep)
        If obj IsNot Nothing Then
            isNewEntry = False
            txtProjectCode.Value = obj.PROJECT_CODE
            txtDesc.Text = obj.PROJECT_DESCRIPTION
            txtProjectCode.MyReadOnly = True
            btnSave.Text = "Update"
            btnDelete.Enabled = True
        End If
    End Sub
    Private Sub AddNew()
        txtProjectCode.Value = ""
        txtDesc.Text = ""
        txtProjectCode.MyReadOnly = False
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtProjectCode.Focus()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        AddNew()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteData()
    End Sub
    Private Sub DeleteData()
        Try
            If clsCommon.myLen(txtProjectCode.Value) <= 0 Then
                Throw New Exception("Code not found to delete")
            End If
            If clsCommon.MyMessageBoxShow("Are you sure? do you want to delete this Code ('" + txtProjectCode.Value + "')", Me.Text, MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

                Dim qry As String = "DELETE FROM TSPL_PROJECT_MASTER WHERE PROJECT_CODE='" + txtProjectCode.Value + "'"
                clsDBFuncationality.ExecuteNonQuery(qry)
                clsCommon.MyMessageBoxShow("Deleted Successfully", Me.Text)
                AddNew()
            End If
        Catch ex As Exception
            If (clsCommon.CompairString(clsCommon.myCstr(ex.Message), "Code not found to delete") <> CompairStringResult.Equal) Then
                clsCommon.MyMessageBoxShow("Current Code is in use")
            Else
                clsCommon.MyMessageBoxShow(ex.Message)
            End If
        End Try
    End Sub

    Private Sub txtProjectCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtProjectCode._MYNavigator
        Try
            LoadData(txtProjectCode.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub txtProjectCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtProjectCode._MYValidating
        Dim str As String = "select count(*) from TSPL_PROJECT_MASTER where PROJECT_CODE ='" + txtProjectCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtProjectCode.MyReadOnly = False
        Else
            txtProjectCode.MyReadOnly = True
        End If

        If txtProjectCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = "Select PROJECT_CODE As [Code],PROJECT_DESCRIPTION As [Name] from TSPL_PROJECT_MASTER "
            txtProjectCode.Value = clsCommon.ShowSelectForm("TSPL_PROJECT_MASTER", qry, "Code", "", txtProjectCode.Value, "TSPL_PROJECT_MASTER.PROJECT_CODE", isButtonClicked)
            If clsCommon.myLen(txtProjectCode.Value) > 0 Then
                Dim objOT As clsProjectMaster
                objOT = clsProjectMaster.GetData(txtProjectCode.Value, NavigatorType.Current)
                If Not objOT Is Nothing Then
                    LoadData(txtProjectCode.Value, NavigatorType.Current)
                End If
            Else
                AddNew()
            End If
        End If
    End Sub

    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        Dim str As String
        str = " select PROJECT_CODE as [PROJECT CODE] , PROJECT_DESCRIPTION as [PROJECT DESCRIPTION] from TSPL_PROJECT_MASTER "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Dim IsNewEntry As Boolean
        Me.Controls.Add(gv)
        If transportSql.importExcel(gv, "PROJECT CODE", "PROJECT DESCRIPTION") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim obj As New clsProjectMaster()
                    Dim strCode As String = clsCommon.myCstr(grow.Cells("PROJECT CODE").Value)
                    Dim strDescription As String = clsCommon.myCstr(grow.Cells("PROJECT DESCRIPTION").Value)
                    linno += 1
                    If clsCommon.myLen(strCode) <= 0 Then
                        Throw New Exception("Project Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strCode) > 30 Then
                        Throw New Exception("Please check ! length of Project code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strDescription) <= 0 Then
                        Throw New Exception("Project Description should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strDescription) > 200 Then
                        Throw New Exception("Please check ! length of Project description should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strCode) > 0 AndAlso clsDBFuncationality.getSingleValue("Select count(*) from TSPL_PROJECT_MASTER where PROJECT_CODE='" + strCode + "' ") > 0 Then
                        IsNewEntry = False
                    Else
                        IsNewEntry = True

                    End If

                    obj.PROJECT_CODE = strCode
                    obj.PROJECT_DESCRIPTION = strDescription
                    clsProjectMaster.SaveData(obj, IsNewEntry)

                Next
                common.clsCommon.MyMessageBoxShow("Data Transfer Completed!", Me.Text, MessageBoxButtons.OK)
            Catch ex As Exception
                common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            End Try
        End If
        Me.Controls.Remove(gv)
    End Sub

    Private Sub rMenuExit_Click(sender As Object, e As EventArgs) Handles rMenuExit.Click
        Me.Close()
    End Sub
End Class
