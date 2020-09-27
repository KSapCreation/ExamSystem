Imports common
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Net.WebClient
Imports System.Net
Imports Telerik.WinControls.UI

Public Class FrmClientMaster
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False

    Const colName As String = "Name"
    Const colEmail As String = "Email"
    Const colPhone As String = "Phone"
    Const colIsSendMail As String = "Is Send Mail"
    Private isInsideLoadData As Boolean = False
    Sub LoadBlankGrid()

        gv.Rows.Clear()
        gv.Columns.Clear()

        Dim Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Name.FormatString = ""
        Name.HeaderText = "Name"
        Name.Name = colName
        Name.Width = 300
        Name.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Name)

        Dim Email As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Email.FormatString = ""
        Email.HeaderText = "Email"
        Email.Name = colEmail
        Email.Width = 200
        Email.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Email)

        Dim Phone As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        Phone.FormatString = ""
        Phone.HeaderText = "Phone"
        Phone.Name = colPhone
        Phone.Width = 150
        Phone.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Phone)

        Dim Is_Send_Mail As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Is_Send_Mail.FormatString = ""
        Is_Send_Mail.HeaderText = "Is Send Mail"
        Is_Send_Mail.Name = colIsSendMail
        Is_Send_Mail.Width = 80
        Is_Send_Mail.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Is_Send_Mail)

        gv.AllowAddNewRow = False
        gv.ShowGroupPanel = False
        gv.AllowColumnReorder = False
        gv.AllowRowReorder = False
        gv.EnableSorting = False
        gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv.MasterTemplate.ShowRowHeaderColumn = False
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub rMenuExit_Click(sender As Object, e As EventArgs) Handles rMenuExit.Click
        Me.Close()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Private Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(clsCommon.myCstr(txtClientCode.Value)) <= 0 Or clsCommon.myLen(clsCommon.myCstr(txtClientCode.Text)) > 30 Then
                clsCommon.MyMessageBoxShow("Client Code cant not be blank/Client Code length can not greter then 30.", Me.Text)
                txtClientCode.Focus()
                txtClientCode.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtClientCode.Value)) < 3 Then
                clsCommon.MyMessageBoxShow("Client Code length can not less then 3.", Me.Text)
                txtClientCode.Focus()
                txtClientCode.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtDesc.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Description cant not be blank.", Me.Text)
                txtDesc.Focus()
                txtDesc.Select()
                Return False
            End If
            For Each grow As GridViewRowInfo In gv.Rows
                If clsCommon.myLen(grow.Cells(colName).Value) > 0 Then

                    If clsCommon.myLen(grow.Cells(colEmail).Value) <= 0 Then
                        common.clsCommon.MyMessageBoxShow("Please Enter Email Id for Name: '" + clsCommon.myCstr(grow.Cells(colName).Value) + "'.")
                        Return False
                    Else
                        Dim check As Match = Regex.Match(grow.Cells(colEmail).Value, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                        If check.Success Then
                        Else
                            common.clsCommon.MyMessageBoxShow("Please Enter the proper format of e-mail address for name : '" + clsCommon.myCstr(grow.Cells(colName).Value) + "'. ")
                            Return False
                        End If
                    End If
                    If clsCommon.myLen(grow.Cells(colPhone).Value) > 0 Then
                        If clsCommon.myLen(grow.Cells(colPhone).Value) <> 10 Then
                            common.clsCommon.MyMessageBoxShow("Please Enter 10 digit phone No for Name: '" + clsCommon.myCstr(grow.Cells(colName).Value) + "'.")
                            Return False
                        End If
                    End If

                End If
            Next

           
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
        Return True
    End Function

    Sub SaveData()
        Try
            If AllowToSave() Then
                Dim obj As New clsClientMaster()
                obj.CLIENT_CODE = txtClientCode.Value
                obj.CLIENT_DESCRIPTION = txtDesc.Text
                obj.VERTICAL = txtVertical.Text
                Dim Arr As New List(Of clsClientDetail)
                For Each grow As GridViewRowInfo In gv.Rows
                    Dim objTr As New clsClientDetail()
                    objTr.PERSON_NAME = clsCommon.myCstr(grow.Cells(colName).Value)
                    objTr.PERSON_EMAIL = clsCommon.myCstr(grow.Cells(colEmail).Value)
                    objTr.PERSON_PHONE = clsCommon.myCstr(grow.Cells(colPhone).Value)
                    objTr.IS_SEND_MAIL = clsCommon.myCdbl(grow.Cells(colIsSendMail).Value)
                    If clsCommon.myLen(objTr.PERSON_NAME) > 0 Then
                        Arr.Add(objTr)
                    End If
                Next
                Dim qry As Integer = clsDBFuncationality.getSingleValue("select count(CLIENT_CODE) from TSPL_CLIENT_MASTER WHERE CLIENT_CODE='" + obj.CLIENT_CODE + "'")
                If (qry = 0) Then
                    isNewEntry = True
                Else
                    isNewEntry = False
                End If
                If (clsClientMaster.SaveData(obj, isNewEntry, Arr)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.CLIENT_CODE, NavigatorType.Current)
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
        AddNew()
        isInsideLoadData = True

        Dim obj As clsClientMaster = clsClientMaster.GetData(strCode, NavTyep)
        If obj IsNot Nothing Then
            isNewEntry = False
            txtClientCode.Value = obj.CLIENT_CODE
            txtDesc.Text = obj.CLIENT_DESCRIPTION
            txtVertical.Text = obj.VERTICAL
            Dim count As Integer = clsDBFuncationality.getSingleValue(" select count(*) from TSPL_CLIENT_DETAIL where  CLIENT_CODE ='" + txtClientCode.Value + "' ")
            If count > 0 Then
                gv.Rows.Clear()
                For Each objtr As clsClientDetail In obj.Arr
                    gv.Rows.AddNew()
                    gv.Rows(gv.Rows.Count - 1).Cells(colName).Value() = objtr.PERSON_NAME
                    gv.Rows(gv.Rows.Count - 1).Cells(colEmail).Value() = objtr.PERSON_EMAIL
                    gv.Rows(gv.Rows.Count - 1).Cells(colPhone).Value() = objtr.PERSON_PHONE
                    If objtr.IS_SEND_MAIL = 1 Then
                        gv.Rows(gv.Rows.Count - 1).Cells(colIsSendMail).Value() = True
                    Else
                        gv.Rows(gv.Rows.Count - 1).Cells(colIsSendMail).Value() = False
                    End If

                    'For ii As Integer = 0 To count - 1
                    '    gv.Rows(ii).Cells(colName).Value = objtr.PERSON_NAME
                    '    gv.Rows(ii).Cells(colEmail).Value = objtr.PERSON_EMAIL
                    '    gv.Rows(ii).Cells(colPhone).Value = objtr.PERSON_PHONE
                    '    If objtr.IS_SEND_MAIL = 1 Then
                    '        gv.Rows(ii).Cells(colIsSendMail).Value = True
                    '    Else
                    '        gv.Rows(ii).Cells(colIsSendMail).Value = False
                    '    End If

                    'Next
                Next
                gv.Rows.AddNew()
            End If

            txtClientCode.MyReadOnly = True
            btnSave.Text = "Update"
            btnDelete.Enabled = True
            isInsideLoadData = False
        End If
    End Sub
    Private Sub AddNew()
        txtClientCode.Value = ""
        txtDesc.Text = ""
        txtVertical.Text = ""
        txtClientCode.MyReadOnly = False
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtClientCode.Focus()
        LoadBlankGrid()
        'gv.Rows.Add()
        gv.Rows.AddNew()
        isInsideLoadData = True
    End Sub
    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub DeleteData()
        Try
            If clsCommon.myLen(txtClientCode.Value) <= 0 Then
                Throw New Exception("Client Code not found to delete")
            End If
            If clsCommon.MyMessageBoxShow("Are you sure? do you want to delete this Client Code ('" + txtClientCode.Value + "')", Me.Text, MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

                Dim qry As String = "DELETE FROM TSPL_CLIENT_MASTER WHERE CLIENT_CODE='" + txtClientCode.Value + "'"
                clsDBFuncationality.ExecuteNonQuery(qry)
                clsCommon.MyMessageBoxShow("Deleted Successfully", Me.Text)
                AddNew()
            End If
        Catch ex As Exception
            If (clsCommon.CompairString(clsCommon.myCstr(ex.Message), "Client Code not found to delete") <> CompairStringResult.Equal) Then
                clsCommon.MyMessageBoxShow("Current Client Code is in use")
            Else
                clsCommon.MyMessageBoxShow(ex.Message)
            End If
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteData()
    End Sub

    Private Sub txtClientCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtClientCode._MYNavigator
        Try
            LoadData(txtClientCode.Value, NavType)
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub txtClientCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtClientCode._MYValidating
        Dim str As String = "select count(*) from TSPL_CLIENT_MASTER where CLIENT_CODE ='" + txtClientCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtClientCode.MyReadOnly = False
        Else
            txtClientCode.MyReadOnly = True
        End If
        If txtClientCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = "Select CLIENT_CODE As [Code],CLIENT_DESCRIPTION As [Name], VERTICAL from TSPL_CLIENT_MASTER "
            txtClientCode.Value = clsCommon.ShowSelectForm("TSPL_CLIENT_MASTER", qry, "Code", "", txtClientCode.Value, "TSPL_CLIENT_MASTER.CLIENT_CODE", isButtonClicked)
            If clsCommon.myLen(txtClientCode.Value) > 0 Then
                Dim objOT As clsClientMaster
                objOT = clsClientMaster.GetData(txtClientCode.Value, NavigatorType.Current)
                If Not objOT Is Nothing Then
                    LoadData(txtClientCode.Value, NavigatorType.Current)
                End If
            Else
                AddNew()
            End If
        End If
    End Sub
    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        Dim str As String
        str = " select CLIENT_CODE as [CLIENT CODE] , CLIENT_DESCRIPTION as [CLIENT DESCRIPTION], VERTICAL from TSPL_CLIENT_MASTER "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Dim IsNewEntry As Boolean
        Me.Controls.Add(gv)
        If transportSql.importExcel(gv, "CLIENT CODE", "CLIENT DESCRIPTION", "VERTICAL") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim obj As New clsClientMaster()
                    Dim strCode As String = clsCommon.myCstr(grow.Cells("CLIENT CODE").Value)
                    Dim strDescription As String = clsCommon.myCstr(grow.Cells("CLIENT DESCRIPTION").Value)
                    Dim strVertical As String = clsCommon.myCstr(grow.Cells("VERTICAL").Value)
                    linno += 1
                    If clsCommon.myLen(strCode) <= 0 Then
                        Throw New Exception("Client Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strCode) > 30 Then
                        Throw New Exception("Please check ! length of Client code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.myLen(strDescription) <= 0 Then
                        Throw New Exception("Client Description should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strDescription) > 200 Then
                        Throw New Exception("Please check ! length of Client description should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    If clsCommon.myLen(strVertical) > 200 Then
                        Throw New Exception("Please check ! length of Vertical should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    If clsCommon.myLen(strCode) > 0 AndAlso clsDBFuncationality.getSingleValue("Select count(*) from TSPL_CLIENT_MASTER where CLIENT_CODE='" + strCode + "' ") > 0 Then
                        IsNewEntry = False
                    Else
                        IsNewEntry = True

                    End If

                    obj.CLIENT_CODE = strCode
                    obj.CLIENT_DESCRIPTION = strDescription
                    obj.VERTICAL = strVertical
                    'clsClientMaster.SaveData(obj, IsNewEntry)

                Next
                common.clsCommon.MyMessageBoxShow("Data Transfer Completed!", Me.Text, MessageBoxButtons.OK)
            Catch ex As Exception
                common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            End Try
        End If
        Me.Controls.Remove(gv)
    End Sub

    Private Sub FrmClientMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNew()
    End Sub

    Private Sub gv_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles gv.CellValueChanged
        If isInsideLoadData = False Then
            If e.Column Is gv.Columns(colName) Then
                If clsCommon.myLen(gv.CurrentRow.Cells(colName).Value) > 0 Then
                    Dim count As Integer = gv.Rows.Count - 1
                    If clsCommon.myLen(clsCommon.myCstr(gv.Rows(count).Cells(colName).Value)) > 0 Then
                        gv.Rows.AddNew()
                    End If
                End If
            End If

            'If e.Column Is gv.Columns(colEmail) Then
            '    If clsCommon.myLen(gv.CurrentRow.Cells(colName).Value) <= 0 Then
            '        common.clsCommon.MyMessageBoxShow("Please Enter Name first.")
            '        gv.CurrentRow.Cells(colEmail).Value = ""
            '        Return
            '    ElseIf clsCommon.myLen(gv.CurrentRow.Cells(colEmail).Value) Then
            '        Dim check As Match = Regex.Match(gv.CurrentRow.Cells(colEmail).Value, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            '        If check.Success Then
            '        Else
            '            common.clsCommon.MyMessageBoxShow("Please Enter the proper format of e-mail address.")
            '            Return
            '        End If
            '    End If
            'End If
            'If e.Column Is gv.Columns(colPhone) Then
            '    If clsCommon.myLen(gv.CurrentRow.Cells(colName).Value) <= 0 Then
            '        common.clsCommon.MyMessageBoxShow("Please Enter Name first.")
            '        gv.CurrentRow.Cells(colPhone).Value = ""
            '        Return
            '    ElseIf clsCommon.myLen(gv.CurrentRow.Cells(colPhone).Value) > 0 Then
            '        If clsCommon.myLen(gv.CurrentRow.Cells(colPhone).Value) <> 10 Then
            '            common.clsCommon.MyMessageBoxShow("Please Enter 10 digit phone No.")
            '            Return
            '        End If
            '    End If
            'End If
        End If
    End Sub
   
   
End Class
