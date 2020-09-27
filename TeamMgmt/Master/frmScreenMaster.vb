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

Public Class FrmScreenMaster
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False

    Private Sub FrmScreenMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNew()
        LoadType()
    End Sub

    Sub LoadType()
        cboType.DataSource = clsScreenMaster.LoadScreenType()
        cboType.ValueMember = "Code"
        cboType.DisplayMember = "Name"
    End Sub

    Private Sub txtModule__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtModule._MYValidating
        Dim qry As String = "select MODULE_CODE as Code,MODULE_DESCRIPTION as Name from TSPL_MODULE_MASTER "
        Dim WhrCls As String = String.Empty
        txtModule.Value = clsCommon.ShowSelectForm("Module@Type", qry, "Code", WhrCls, txtModule.Value, "Code", isButtonClicked)
        lblModule.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select MODULE_DESCRIPTION from TSPL_MODULE_MASTER where MODULE_CODE='" + txtModule.Value + "'"))
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Private Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(clsCommon.myCstr(txtScreenCode.Value)) <= 0 Or clsCommon.myLen(clsCommon.myCstr(txtScreenCode.Text)) > 30 Then
                clsCommon.MyMessageBoxShow("Client Code cant not be blank/Client Code length can not greter then 30", Me.Text)
                txtScreenCode.Focus()
                txtScreenCode.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtDesc.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Description cant not be blank", Me.Text)
                txtDesc.Focus()
                txtDesc.Select()
                Return False
            End If
            If clsCommon.myCstr(clsCommon.myCstr(cboType.Text)) = "Select" Then
                clsCommon.MyMessageBoxShow("Please select type.", Me.Text)
                cboType.Focus()
                cboType.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtModule.Value)) <= 0 Then
                clsCommon.MyMessageBoxShow("Please select Module.", Me.Text)
                txtModule.Focus()
                txtModule.Select()
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
                Dim obj As New clsScreenMaster()
                obj.SCREEN_CODE = txtScreenCode.Value
                obj.SCREEN_DESCRIPTION = txtDesc.Text
                obj.TYPE = cboType.Text
                obj.MODULE_CODE = txtModule.Value
                Dim qry As Integer = clsDBFuncationality.getSingleValue("select count(SCREEN_CODE) from TSPL_SCREEN_MASTER WHERE SCREEN_CODE='" + obj.SCREEN_CODE + "'")
                If (qry = 0) Then
                    isNewEntry = True
                Else
                    isNewEntry = False
                End If
                If (clsScreenMaster.SaveData(obj, isNewEntry)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.SCREEN_CODE, NavigatorType.Current)
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
        Dim obj As clsScreenMaster = clsScreenMaster.GetData(strCode, NavTyep)
        If obj IsNot Nothing Then
            isNewEntry = False
            txtScreenCode.Value = obj.SCREEN_CODE
            txtDesc.Text = obj.SCREEN_DESCRIPTION
            cboType.Text = obj.TYPE
            txtModule.Value = obj.MODULE_CODE
            lblModule.Text = obj.MODULE_DESC
            txtScreenCode.MyReadOnly = True
            btnSave.Text = "Update"
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub AddNew()
        txtScreenCode.Value = ""
        txtDesc.Text = ""
        cboType.Text = "Select"
        txtModule.Value = ""
        lblModule.Text = ""
        txtScreenCode.MyReadOnly = False
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtScreenCode.Focus()
    End Sub

    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub txtScreenCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtScreenCode._MYNavigator
        Try
            LoadData(txtScreenCode.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub txtScreenCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtScreenCode._MYValidating
        Dim str As String = "select count(*) from TSPL_SCREEN_MASTER where SCREEN_CODE ='" + txtScreenCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtScreenCode.MyReadOnly = False
        Else
            txtScreenCode.MyReadOnly = True
        End If
        If txtScreenCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = "Select SCREEN_CODE As [Code],SCREEN_DESCRIPTION As [Name], TYPE ,MODULE_CODE as [Module Code] from TSPL_SCREEN_MASTER "
            txtScreenCode.Value = clsCommon.ShowSelectForm("TSPL_CLIENT_MASTER", qry, "Code", "", txtScreenCode.Value, "TSPL_SCREEN_MASTER.SCREEN_CODE", isButtonClicked)
            If clsCommon.myLen(txtScreenCode.Value) > 0 Then
                Dim objOT As clsScreenMaster
                objOT = clsScreenMaster.GetData(txtScreenCode.Value, NavigatorType.Current)
                If Not objOT Is Nothing Then
                    LoadData(txtScreenCode.Value, NavigatorType.Current)
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
            If clsCommon.myLen(txtScreenCode.Value) > 0 Then

                If clsScreenMaster.deleteData(txtScreenCode.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    AddNew()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a Screen Code to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub

    Private Sub rMenuExist_Click(sender As Object, e As EventArgs) Handles rMenuExist.Click
        Me.Close()
    End Sub
    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        Dim str As String
        str = " select TSPL_SCREEN_MASTER.SCREEN_CODE as [SCREEN CODE] , TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION as [SCREEN DESCRIPTION], TSPL_SCREEN_MASTER.[TYPE],TSPL_SCREEN_MASTER.MODULE_CODE as [MODULE CODE],TSPL_MODULE_MASTER.MODULE_DESCRIPTION as [MODULE DESCRIPTION] from TSPL_SCREEN_MASTER LEFT OUTER JOIN TSPL_MODULE_MASTER ON TSPL_MODULE_MASTER.MODULE_CODE =TSPL_SCREEN_MASTER.MODULE_CODE "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Dim IsNewEntry As Boolean
        Me.Controls.Add(gv)
        If transportSql.importExcel(gv, "SCREEN CODE", "SCREEN DESCRIPTION", "TYPE", "MODULE CODE", "MODULE DESCRIPTION") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim obj As New clsScreenMaster()
                    Dim strScreenCode As String = clsCommon.myCstr(grow.Cells("SCREEN CODE").Value)
                    Dim strScreenDescription As String = clsCommon.myCstr(grow.Cells("SCREEN DESCRIPTION").Value)
                    Dim strType As String = clsCommon.myCstr(grow.Cells("TYPE").Value)
                    Dim strModuleCode As String = clsCommon.myCstr(grow.Cells("MODULE CODE").Value)
                    linno += 1
                    If clsCommon.myLen(strScreenCode) <= 0 Then
                        Throw New Exception("Screen Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strScreenCode) > 30 Then
                        Throw New Exception("Please check ! length of Screen code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strScreenDescription) <= 0 Then
                        Throw New Exception("Screen Description should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strScreenDescription) > 200 Then
                        Throw New Exception("Please check ! length of Screen description should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.CompairString(strType, "Master") = CompairStringResult.Equal Then
                        strType = "Master"
                    ElseIf clsCommon.CompairString(strType, "Transaction") = CompairStringResult.Equal Then
                        strType = "Transaction"
                    ElseIf clsCommon.CompairString(strType, "Report") = CompairStringResult.Equal Then
                        strType = "Report"
                    Else
                        Throw New Exception("Please Enter Type as 'Master' Or 'Transaction' Or Report at Line No '" + linno + "'")
                    End If
                    If clsCommon.myLen(strModuleCode) <= 0 Then
                        Throw New Exception("Module Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    Dim chckModuleCode As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(" select count (*) from TSPL_MODULE_MASTER where MODULE_CODE ='" + strModuleCode + "' "))
                    If chckModuleCode <= 0 Then
                        Throw New Exception(" Invalid Module Code at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strScreenCode) > 0 AndAlso clsDBFuncationality.getSingleValue("Select count(*) from TSPL_SCREEN_MASTER where SCREEN_CODE='" + strScreenCode + "' ") > 0 Then
                        IsNewEntry = False
                    Else
                        IsNewEntry = True
                    End If

                    obj.SCREEN_CODE = strScreenCode
                    obj.SCREEN_DESCRIPTION = strScreenDescription
                    obj.TYPE = strType
                    obj.MODULE_CODE = strModuleCode
                    clsScreenMaster.SaveData(obj, IsNewEntry)

                Next
                common.clsCommon.MyMessageBoxShow("Data Transfer Completed!", Me.Text, MessageBoxButtons.OK)
            Catch ex As Exception
                common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            End Try
        End If
        Me.Controls.Remove(gv)
    End Sub
End Class
