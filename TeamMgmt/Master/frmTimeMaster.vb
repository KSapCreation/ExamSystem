Imports System.Data.Sql
Imports common
Public Class FrmTimeMaster
    Inherits FrmMainTranScreen
    Private isNewEntry As Boolean = False

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Private Function AllowToSave() As Boolean
        Try
            If clsCommon.myLen(clsCommon.myCstr(txt_TesterTime.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Tester Time cant not be blank", Me.Text)
                txt_TesterTime.Focus()
                txt_TesterTime.Select()
                Return False
            End If
            If clsCommon.myCdbl(txt_TesterTime.Text) >= 100 Then
                clsCommon.MyMessageBoxShow("Tester Time can not greter then 100", Me.Text)
                txt_TesterTime.Focus()
                txt_TesterTime.Select()
                Return False
            End If

            If clsCommon.myLen(clsCommon.myCstr(txtAdditionalTime.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Additional Time cant not be blank", Me.Text)
                txtAdditionalTime.Focus()
                txtAdditionalTime.Select()
                Return False
            End If
            If clsCommon.myCdbl(txtAdditionalTime.Text) >= 100 Then
                clsCommon.MyMessageBoxShow("Additional Time can not greter then 100", Me.Text)
                txtAdditionalTime.Focus()
                txtAdditionalTime.Select()
                Return False
            End If
            If clsCommon.myLen(clsCommon.myCstr(txtDebuggingTime.Text)) <= 0 Then
                clsCommon.MyMessageBoxShow("Debugging Time cant not be blank", Me.Text)
                txtDebuggingTime.Focus()
                txtDebuggingTime.Select()
                Return False
            End If
            If clsCommon.myCdbl(txtDebuggingTime.Text) >= 100 Then
                clsCommon.MyMessageBoxShow("Debugging Time can not greter then 100", Me.Text)
                txtDebuggingTime.Focus()
                txtDebuggingTime.Select()
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
                Dim obj As New clsTimeMaster()
                obj.Tester_Time = txt_TesterTime.Value
                obj.Additional_Time = txtAdditionalTime.Text
                obj.Debugging_Time = txtDebuggingTime.Text
                Dim qry As Integer = clsDBFuncationality.getSingleValue("select count(*) from TSPL_TIME_MASTER ")
                If (qry = 0) Then
                    isNewEntry = True
                Else
                    isNewEntry = False
                End If
                If (clsTimeMaster.SaveData(obj, isNewEntry)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData()
                    btnSave.Text = "Update"
                Else
                    btnSave.Text = "Save"
                End If
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub
    Sub LoadData()
        Dim qry As String = " Select Tester_Time,Debugging_Time,Additional_Time from TSPL_TIME_MASTER "

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then

            txt_TesterTime.Text = clsCommon.myCstr(dt.Rows(0)("Tester_Time"))
            txtDebuggingTime.Text = clsCommon.myCstr(dt.Rows(0)("Debugging_Time"))
            txtAdditionalTime.Text = clsCommon.myCstr(dt.Rows(0)("Additional_Time"))
            isNewEntry = False
            btnSave.Text = "Update"
        Else
            isNewEntry = True
            btnSave.Text = "Save"
        End If

    End Sub
    Private Sub FrmTimeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
