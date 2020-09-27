Imports common
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Net.WebClient
Imports System.Net
Imports Telerik.WinControls.UI
Public Class FrmUserGroupMaster
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False
    Private Sub FrmUserGroupMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNew()
    End Sub
    Private Sub AddNew()
        txtGroupCode.Value = ""
        txtDesc.Text = ""
        txtGroupCode.MyReadOnly = False
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtGroupCode.Focus()
    End Sub
    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Private Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(clsCommon.myCstr(txtGroupCode.Value)) <= 0 Or clsCommon.myLen(clsCommon.myCstr(txtGroupCode.Text)) > 30 Then
                clsCommon.MyMessageBoxShow("Group Code cant not be blank/Group Code length can not greter then 30", Me.Text)
                txtGroupCode.Focus()
                txtGroupCode.Select()
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
                Dim obj As New clsUserGroupMaster()
                obj.USER_GROUP_CODE = txtGroupCode.Value
                obj.GROUP_DESCRIPTION = txtDesc.Text
                Dim qry As Integer = clsDBFuncationality.getSingleValue("select count(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER WHERE USER_GROUP_CODE='" + obj.USER_GROUP_CODE + "'")
                If (qry = 0) Then
                    isNewEntry = True
                Else
                    isNewEntry = False
                End If
                If (clsUserGroupMaster.SaveData(obj, isNewEntry)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.USER_GROUP_CODE, NavigatorType.Current)
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
        Dim obj As clsUserGroupMaster = clsUserGroupMaster.GetData(strCode, NavTyep)
        If obj IsNot Nothing Then
            isNewEntry = False
            txtGroupCode.Value = obj.USER_GROUP_CODE
            txtDesc.Text = obj.GROUP_DESCRIPTION
            txtGroupCode.MyReadOnly = True
            btnSave.Text = "Update"
            btnDelete.Enabled = True
        End If
    End Sub


    Private Sub txtGroupCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtGroupCode._MYNavigator
        Try
            LoadData(txtGroupCode.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub txtGroupCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtGroupCode._MYValidating
        Dim str As String = "select count(*) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE ='" + txtGroupCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtGroupCode.MyReadOnly = False
        Else
            txtGroupCode.MyReadOnly = True
        End If
        If txtGroupCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = "Select USER_GROUP_CODE As [Code],GROUP_DESCRIPTION As [Name] from TSPL_USER_GROUP_MASTER "
            txtGroupCode.Value = clsCommon.ShowSelectForm("TSPL_CLIENT_MASTER", qry, "Code", "", txtGroupCode.Value, "TSPL_USER_GROUP_MASTER.USER_GROUP_CODE", isButtonClicked)
            If clsCommon.myLen(txtGroupCode.Value) > 0 Then
                Dim objOT As clsUserGroupMaster
                objOT = clsUserGroupMaster.GetData(txtGroupCode.Value, NavigatorType.Current)
                If Not objOT Is Nothing Then
                    LoadData(txtGroupCode.Value, NavigatorType.Current)
                End If
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
            If clsCommon.myLen(txtGroupCode.Value) > 0 Then

                If clsUserGroupMaster.deleteData(txtGroupCode.Value, trans) Then
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
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        GC.Collect()
    End Sub

    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        Dim str As String
        str = "select USER_GROUP_CODE as [USER GROUP CODE],GROUP_DESCRIPTION as [USER GROUP DESCRIPTION] from TSPL_USER_GROUP_MASTER "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Dim IsNewEntry As Boolean
        Me.Controls.Add(gv)
        If transportSql.importExcel(gv, "USER GROUP CODE", "USER GROUP DESCRIPTION") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim obj As New clsUserGroupMaster()
                    Dim strCode As String = clsCommon.myCstr(grow.Cells("USER GROUP CODE").Value)
                    Dim strDescription As String = clsCommon.myCstr(grow.Cells("USER GROUP DESCRIPTION").Value)
                    linno += 1
                    If clsCommon.myLen(strCode) <= 0 Then
                        Throw New Exception("User Group Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strCode) > 30 Then
                        Throw New Exception("Please check ! length of User Group code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strDescription) <= 0 Then
                        Throw New Exception("User Group Description should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strDescription) > 200 Then
                        Throw New Exception("Please check ! length of User Group Description should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strCode) > 0 AndAlso clsDBFuncationality.getSingleValue("Select count(*) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE='" + strCode + "' ") > 0 Then
                        IsNewEntry = False
                    Else
                        IsNewEntry = True

                    End If

                    obj.USER_GROUP_CODE = strCode
                    obj.GROUP_DESCRIPTION = strDescription

                    clsUserGroupMaster.SaveData(obj, IsNewEntry)

                Next
                common.clsCommon.MyMessageBoxShow("Data Transfer Completed!", Me.Text, MessageBoxButtons.OK)
            Catch ex As Exception
                common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            End Try
        End If
        Me.Controls.Remove(gv)
    End Sub

    Private Sub RadMenuItem4_Click(sender As Object, e As EventArgs) Handles RadMenuItem4.Click
        Me.Close()
    End Sub
End Class
