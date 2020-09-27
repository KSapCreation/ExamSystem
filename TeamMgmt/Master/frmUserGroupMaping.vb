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

Public Class FrmUserGroupMaping
    Inherits FrmMainTranScreen
    Const colUserGroupCode As String = "User Group Code"
    Const colUserGroupDesc As String = "User Group Description"
    Const colStatus As String = "Status"
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False

    Sub LoadBlankGrid()

        gv.Rows.Clear()
        gv.Columns.Clear()

        Dim User_Group_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        User_Group_Code.FormatString = ""
        User_Group_Code.HeaderText = "User Group Code"
        User_Group_Code.Name = colUserGroupCode
        User_Group_Code.Width = 120
        User_Group_Code.ReadOnly = True
        gv.MasterTemplate.Columns.Add(User_Group_Code)

        Dim User_Group_Desc As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        User_Group_Desc.FormatString = ""
        User_Group_Desc.HeaderText = "User Group Description"
        User_Group_Desc.Name = colUserGroupDesc
        User_Group_Desc.Width = 150
        User_Group_Desc.ReadOnly = True
        gv.MasterTemplate.Columns.Add(User_Group_Desc)

        Dim User_Group_Code_Status As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        User_Group_Code_Status.FormatString = ""
        User_Group_Code_Status.HeaderText = "Status"
        User_Group_Code_Status.Name = colStatus
        User_Group_Code_Status.Width = 70
        User_Group_Code_Status.ReadOnly = False
        gv.MasterTemplate.Columns.Add(User_Group_Code_Status)

        gv.AllowAddNewRow = False
        gv.ShowGroupPanel = False
        gv.AllowColumnReorder = False
        gv.AllowRowReorder = False
        gv.EnableSorting = False
        gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv.MasterTemplate.ShowRowHeaderColumn = False
    End Sub
    Sub FillUserGroupInGrid()
        Dim dt As DataTable
        Dim qry As String = "  select USER_GROUP_CODE,GROUP_DESCRIPTION  from TSPL_USER_GROUP_MASTER "
        dt = clsDBFuncationality.GetDataTable(qry)
        If dt.Rows.Count > 0 Then
            gv.DataSource = Nothing
            For Each dr As DataRow In dt.Rows
                gv.Rows.AddNew()
                gv.Rows(gv.Rows.Count - 1).Cells(colUserGroupCode).Value = clsCommon.myCstr(dr("USER_GROUP_CODE"))
                gv.Rows(gv.Rows.Count - 1).Cells(colUserGroupDesc).Value = clsCommon.myCstr(dr("GROUP_DESCRIPTION"))
            Next
        End If
    End Sub
    Private Sub FrmUserGroupMaping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBlankGrid()
        FillUserGroupInGrid()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(txtUserCode.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("User Code can not be blank.")
                txtUserCode.Focus()
                Return False
            End If
            If clsCommon.myLen(txtUserCode.Value) > 0 Then
                Dim chkUser As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(" select count(*) from TSPL_USER_MASTER where USER_CODE ='" + txtUserCode.Value + "'"))
                If chkUser <= 0 Then
                    common.clsCommon.MyMessageBoxShow("Invalid User Code.")
                    txtUserCode.Focus()
                    Return False
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function
    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsUserGroupMappingMaster()
                obj.USER_CODE = txtUserCode.Value

                Dim Arr As New List(Of clsUserGroupMappingDetail)
                For Each grow As GridViewRowInfo In gv.Rows
                    Dim objTr As New clsUserGroupMappingDetail()
                    objTr.USER_GROUP_CODE = clsCommon.myCstr(grow.Cells(colUserGroupCode).Value)
                    Dim strStatus As Boolean = clsCommon.myCBool(grow.Cells(colStatus).Value)
                    If strStatus Then
                        Arr.Add(objTr)
                    End If
                Next

                'If (Arr Is Nothing OrElse Arr.Count <= 0) Then
                '    common.clsCommon.MyMessageBoxShow("Please select at least one Project")
                '    Return
                'End If
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_MAPPING_USER_GROUP_MASTER where USER_CODE='" & obj.USER_CODE & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry, Arr)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.USER_CODE)
                    btnSave.Text = "Update"
                    btnDelete.Enabled = True
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Sub LoadData(ByVal strUserCode As String)
        Try
            LoadBlankGrid()
            FillUserGroupInGrid()
            isInsideLoadData = True
            Dim obj As clsUserGroupMappingMaster = clsUserGroupMappingMaster.GetData(strUserCode, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then
                txtUserCode.Value = obj.USER_CODE
                lblUserName.Text = obj.USER_NAME
                'FillProjectInGrid2(obj.USER_CODE)
                Dim count As Integer = clsDBFuncationality.getSingleValue(" select count(*) from TSPL_MAPPING_USER_GROUP_DETAIL where  USER_CODE ='" + txtUserCode.Value + "' ")
                If count > 0 Then
                    For Each objtr As clsUserGroupMappingDetail In obj.Arr
                        For ii As Integer = 0 To gv.Rows.Count - 1
                            If clsCommon.myCstr(gv.Rows(ii).Cells(colUserGroupCode).Value) = objtr.USER_GROUP_CODE Then
                                gv.Rows(ii).Cells(colStatus).Value = 1
                            End If
                        Next
                    Next
                End If
                isInsideLoadData = False
                txtUserCode.MyReadOnly = True
                btnSave.Text = "Update"
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub txtUserCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtUserCode._MYNavigator
        Dim WhrCls As String = ""

        Dim qry As String = "select USER_CODE  from TSPL_USER_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_USER_MASTER.USER_CODE=(select MIN(USER_CODE) from TSPL_USER_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_USER_MASTER.USER_CODE=(select MAX(USER_CODE) from TSPL_USER_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_USER_MASTER.USER_CODE=(select Min(USER_CODE) from TSPL_USER_MASTER where USER_CODE > '" + txtUserCode.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_USER_MASTER.USER_CODE=(select Max(USER_CODE) from TSPL_USER_MASTER where USER_CODE < '" + txtUserCode.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_USER_MASTER.USER_CODE='" + txtUserCode.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtUserCode.Value = clsCommon.myCstr(dt.Rows(0)("USER_CODE"))
        End If
        LoadData(txtUserCode.Value)
    End Sub

    Private Sub txtUserCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtUserCode._MYValidating

        Dim str As String = "select count(*) from TSPL_USER_MASTER where USER_CODE = '" + txtUserCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtUserCode.MyReadOnly = False
        Else
            txtUserCode.MyReadOnly = True
        End If

        If txtUserCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = " select USER_CODE as Code,USER_NAME as Name ,TYPE,CLIENT_CODE,USER_GROUP_CODE,EMAIL,PHONE  from TSPL_USER_MASTER "
            txtUserCode.Value = clsCommon.ShowSelectForm("TSPL_USER_MASTER", qry, "Code", "", txtUserCode.Value, "TSPL_USER_MASTER.USER_CODE", isButtonClicked)
            If clsCommon.myLen(txtUserCode.Value) > 0 Then
                LoadData(txtUserCode.Value)
            Else
                LoadBlankGrid()
                FillUserGroupInGrid()
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
            If clsCommon.myLen(txtUserCode.Value) > 0 Then

                If clsUserGroupMappingMaster.deleteData(txtUserCode.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    LoadBlankGrid()
                    FillUserGroupInGrid()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a User Code to delete")
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

    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        txtUserCode.Value = ""
        txtUserCode.MyReadOnly = False
        lblUserName.Text = ""
        LoadBlankGrid()
        FillUserGroupInGrid()
        btnSave.Text = "Save"
    End Sub

    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        Dim str As String
        str = " select TSPL_USER_MASTER.USER_CODE as [USER CODE], TSPL_USER_MASTER.USER_NAME as [USER NAME],TSPL_USER_MASTER.PASSWORD as [PASSWORD], TSPL_USER_MASTER.TYPE as [TYPE],isnull(TSPL_USER_MASTER.CLIENT_CODE,'') as [CLIENT CODE],TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION as [CLIENT NAME],isnull( TSPL_USER_MASTER.USER_GROUP_CODE,'') as [USER GROUP CODE] ,TSPL_USER_GROUP_MASTER.GROUP_DESCRIPTION as [USER GROUP DESCRIPTION],TSPL_USER_MASTER.EMAIL, TSPL_USER_MASTER.PHONE , isnull( TSPL_MAPPING_USER_DETAIL.MAPPING_USER_CODE,'') as [MAPPING USER CODE]   from TSPL_USER_MASTER left outer join TSPL_MAPPING_USER_DETAIL on TSPL_MAPPING_USER_DETAIL.USER_CODE =TSPL_USER_MASTER.USER_CODE left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE = TSPL_USER_MASTER.CLIENT_CODE left outer join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_USER_MASTER.USER_GROUP_CODE    "
        transportSql.ExporttoExcel(str, Me)
    End Sub
End Class
