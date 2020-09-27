﻿Imports common

Public Class FrmChangePassword
    'Inherits FrmMainTranScreen
    Public password As String
    Dim ButtonTooltip As ToolTip = New ToolTip()
    'Private Sub SetUserMgmtNew()
    '    'MyBase.SetUserMgmt(clsUserMgtCode.FrmChangePassword)
    '    If Not (MyBase.isReadFlag) Then
    '        common.clsCommon.MyMessageBoxShow("Permission Denied")
    '        Me.Close()
    '        Exit Function
    '    End If
    '    'btnsave.Visible = MyBase.isModifyFlag
    '    'btnPost.Visible = MyBase.isPostFlag
    '    'btndelete.Visible = MyBase.isDeleteFlag
    'End Function
    Private Sub FrmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblusercode.Text = objCommonVar.CurrentUserCode
        lblusername.Text = objCommonVar.CurrentUser
        password = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select password from TSPL_USER_MASTER where user_code='" + objCommonVar.CurrentUserCode + "' "))
        ButtonTooltip.SetToolTip(btnsave, "Press Alt+S for Save")
        ButtonTooltip.SetToolTip(btnclose, "Press Alt+C for Close")

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Savedata()

    End Sub
    Sub Savedata()

        If allowtosave() = True Then
            Try

                Dim code As String = objCommonVar.CurrentUserCode
                If SavePswd(code, (txtnewpassword.Text)) = True Then

                    common.clsCommon.MyMessageBoxShow("Password Changed Successfully")
                    Close()
                End If
            Catch ex As Exception
                common.clsCommon.MyMessageBoxShow(ex.Message)
            End Try
        End If

    End Sub

    Public Function SavePswd(ByVal code As String, ByVal pass As String)
        Try
            Dim isSaved As Boolean = True
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "User_code", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "User_Name", objCommonVar.CurrentUser)
            'clsCommon.AddColumnsForChange(coll, "Password", clsCommon.EncryptString(pass))
            clsCommon.AddColumnsForChange(coll, "Password", pass)
            clsCommonFunctionality.UpdateDataTableInSelectedDatabase(coll, GetReplecateCompaniesDataBase(), "TSPL_USER_MASTER", OMInsertOrUpdate.Update, "User_code='" + code + "'")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return True
    End Function
    Private Function GetReplecateCompaniesDataBase() As List(Of String)
        'Dim qry As String = "SELECT Comp_Code,Comp_Name,DataBase_Name from TSPL_COMPANY_MASTER where len(isnull(DataBase_Name,''))>0 and Comp_Code not in ('" + objCommonVar.CurrentCompanyCode + "')"
        'Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        Dim arrDBName As New List(Of String)
        arrDBName.Add(objCommonVar.CurrDatabase)
        'For ii As Integer = 0 To dt.Rows.Count - 1
        '    arrDBName.Add(clsCommon.myCstr(dt.Rows(ii)("DataBase_Name")))

        'Next
        Return arrDBName
    End Function
   
    Public Function allowtosave() As Boolean
        Try


            If (clsCommon.myLen(txtnewpassword.Text) <= 0) Then
                common.clsCommon.MyMessageBoxShow("Please  fill  New Password")
                txtnewpassword.Text = ""
                txtnewpassword.Focus()
                Return False
            ElseIf (clsCommon.myLen(txtconfpassword.Text) <= 0) Then
                common.clsCommon.MyMessageBoxShow(" Please  fill  Confirm Password")
                txtconfpassword.Text = ""
                txtconfpassword.Focus()
                Return False
            ElseIf (clsCommon.myLen(txtcurpassword.Text) <= 0) Then
                common.clsCommon.MyMessageBoxShow(" Please  fill Current Password")
                txtcurpassword.Text = ""
                txtcurpassword.Focus()
                Return False

            End If
            If Not clsCommon.CompairString(txtnewpassword.Text, txtconfpassword.Text, True) = CompairStringResult.Equal Then

                common.clsCommon.MyMessageBoxShow(" Confirm Password should  be same as new password")
                txtconfpassword.Text = ""
                txtnewpassword.Text = ""
                txtnewpassword.Focus()
                Return False

            End If
            'If Not clsCommon.CompairString(clsCommon.EncryptString(txtcurpassword.Text), password, True) = CompairStringResult.Equal Then
            If Not clsCommon.CompairString(txtcurpassword.Text, password, True) = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Current Password is incorrect please insert valid Password")
                txtcurpassword.Text = ""
                txtcurpassword.Focus()
                Return False
            End If
            'If (clsCommon.myLen(txtconfpassword.Text) < 6) Then
            '    common.clsCommon.MyMessageBoxShow("Password length should be greater than 6 letters")
            '    txtconfpassword.Text = ""
            '    txtnewpassword.Text = ""
            '    txtnewpassword.Focus()
            '    Return False
            'End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
        Return True
    End Function

    Private Sub FrmChangePassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.S AndAlso MyBase.isModifyFlag AndAlso btnsave.Enabled Then
            Savedata()
        ElseIf e.KeyCode = Keys.Enter AndAlso clsCommon.myLen(txtcurpassword.Text) > 0 AndAlso clsCommon.myLen(txtnewpassword.Text) > 0 AndAlso clsCommon.myLen(txtconfpassword.Text) Then
            Savedata()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.C Then
            Close()
        End If
    End Sub

    
End Class
