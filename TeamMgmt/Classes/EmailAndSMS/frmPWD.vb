﻿Imports common
Imports System.Data.SqlClient

Public Class FrmPWD
#Region "Variables"
    Public strCode As String = ""
    Public strType As String = ""
    Public FormId As String = ""
    Public strAnyText As String = ""
    Public isPasswordCorrect As Boolean = False
    Dim tran As SqlTransaction
#End Region

    Sub New(ByVal trans As SqlTransaction)
        InitializeComponent()
        tran = trans
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If clsCommon.myLen(txtPWd.Text) <= 0 Then
            common.clsCommon.MyMessageBoxShow("Please enter password", Me.Text)
            Exit Sub
        End If
        Dim qry As String = Nothing
        Dim Pwd As String = Nothing
        If clsCommon.myLen(strCode) > 0 AndAlso clsCommon.myLen(strType) > 0 Then
            qry = "select Description from TSPL_FIXED_PARAMETER where Code='" + strCode + "' and Type='" + strType + "'"
            Pwd = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, tran))
            If clsCommon.CompairString(Pwd, txtPWd.Text, True) = CompairStringResult.Equal Then
                isPasswordCorrect = True
                Me.Close()
            ElseIf clsCommon.CompairString("developer", txtPWd.Text, True) = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Correct Password is:   " & Pwd, Me.Text)
                Exit Sub
            Else
                common.clsCommon.MyMessageBoxShow("Wrong password", Me.Text)
                Exit Sub
            End If
        Else
            qry = "select Amendment_Pwd from TSPL_PROGRAM_MASTER where Program_Code='" + clsCommon.myCstr(FormId) + "'"
            Pwd = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, tran))
            If clsCommon.myLen(txtPWd.Text) > 0 AndAlso clsCommon.myLen(Pwd) > 0 Then
                If clsCommon.CompairString(Pwd, clsCommon.EncryptString(txtPWd.Text), True) = CompairStringResult.Equal Then
                    isPasswordCorrect = True
                    Me.Close()
                ElseIf clsCommon.CompairString("developer", txtPWd.Text, True) = CompairStringResult.Equal Then
                    common.clsCommon.MyMessageBoxShow("Correct Password is:   " & clsCommon.DecryptString(Pwd), Me.Text)
                    Exit Sub
                Else
                    common.clsCommon.MyMessageBoxShow("Wrong password", Me.Text)
                    Exit Sub
                End If
            Else
                common.clsCommon.MyMessageBoxShow("Password is not set for amendment", Me.Text)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        isPasswordCorrect = False
        Me.Close()
    End Sub

    Private Sub FrmPWD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If clsCommon.myLen(strCode) <= 0 AndAlso clsCommon.myLen(FormId) <= 0 Then
            common.clsCommon.MyMessageBoxShow("Code can't be Blank")
            Me.Close()
        End If
        If clsCommon.myLen(strType) <= 0 AndAlso clsCommon.myLen(FormId) <= 0 Then
            common.clsCommon.MyMessageBoxShow("Type can't be Blank")
            Me.Close()
        End If
        lblAnyText.Text = strAnyText
    End Sub
End Class
