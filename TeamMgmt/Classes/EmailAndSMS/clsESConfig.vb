Imports common
Imports System.Data.SqlClient

Public Class clsESConfig
#Region "Variables"
    Public EMail_SMTP_Client As String = Nothing
    Public EMail_Port As String = Nothing
    Public EMail_ID As String = Nothing
    Public EMail_Pwd As String = Nothing
    Public EMail_Enabel_SSL As Boolean = False
    Public SMS_String As String = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsESConfig) As Boolean
        Try
            Dim qry As String = "Delete from TSPL_ES_Config"
            clsDBFuncationality.ExecuteNonQuery(qry)
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "EMail_SMTP_Client", obj.EMail_SMTP_Client)
            clsCommon.AddColumnsForChange(coll, "EMail_Port", obj.EMail_Port)
            clsCommon.AddColumnsForChange(coll, "EMail_ID", obj.EMail_ID)
            clsCommon.AddColumnsForChange(coll, "EMail_Pwd", obj.EMail_Pwd)
            clsCommon.AddColumnsForChange(coll, "EMail_Enabel_SSL", IIf(obj.EMail_Enabel_SSL, 1, 0))
            clsCommon.AddColumnsForChange(coll, "SMS_String", obj.SMS_String)
            clsCommon.AddColumnsForChange(coll, "Modified_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modified_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_ES_Config", OMInsertOrUpdate.Insert, "")
        Catch err As System.Exception
            Throw New System.Exception(err.Message)
        End Try
        Return True
    End Function

    Public Shared Function GetData() As clsESConfig
        Dim obj As clsESConfig = Nothing
        Dim qry As String = "SELECT * from TSPL_ES_Config"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsESConfig()
            obj.EMail_SMTP_Client = clsCommon.myCstr(dt.Rows(0)("EMail_SMTP_Client"))
            obj.EMail_Port = clsCommon.myCstr(dt.Rows(0)("EMail_Port"))
            obj.EMail_ID = clsCommon.myCstr(dt.Rows(0)("EMail_ID"))
            obj.EMail_Pwd = clsCommon.myCstr(dt.Rows(0)("EMail_Pwd"))
            obj.EMail_Enabel_SSL = IIf(clsCommon.myCdbl(dt.Rows(0)("EMail_Enabel_SSL")) = 1, True, False)
            obj.SMS_String = clsCommon.myCstr(dt.Rows(0)("SMS_String"))
        End If
        Return obj
    End Function
End Class

Public Class clsESContent
#Region "Variables"
    Public Form_ID As String = Nothing
    Public EMail_Subject As String = Nothing
    Public EMail_Text As String = Nothing
    Public SMS_Text As String = Nothing
    Public Notification_Caption As String = Nothing
    Public Notification_Text As String = Nothing
    Public Notification_On As String = Nothing

    Public arrAlertEmployeeSMS As ArrayList = Nothing
    Public arrAlertEmployeeEMail As ArrayList = Nothing
    Public arrAlertEmployeeNotification As ArrayList = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsESContent) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            Dim qry As String = "delete from TSPL_ES_Content_Emp_Detail where Form_ID='" + obj.Form_ID + "'"
            clsDBFuncationality.ExecuteNonQuery(qry, trans)
            qry = "select 1 from TSPL_ES_Content where Form_ID='" + obj.Form_ID + "'"
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "EMail_Subject", obj.EMail_Subject)
            clsCommon.AddColumnsForChange(coll, "EMail_Text", obj.EMail_Text)
            clsCommon.AddColumnsForChange(coll, "Notification_Caption", obj.Notification_Caption)
            clsCommon.AddColumnsForChange(coll, "Notification_Text", obj.Notification_Text)
            clsCommon.AddColumnsForChange(coll, "Notification_On", obj.Notification_On)
            clsCommon.AddColumnsForChange(coll, "SMS_Text", obj.SMS_Text)
            clsCommon.AddColumnsForChange(coll, "Modified_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modified_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ''Old Entry
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_ES_Content", OMInsertOrUpdate.Update, "Form_ID='" + obj.Form_ID + "'", trans)
            Else
                ''New Entry
                clsCommon.AddColumnsForChange(coll, "Form_ID", obj.Form_ID)
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_ES_Content", OMInsertOrUpdate.Insert, "", trans)
            End If
            clsESContentEMPDetail.SaveData(obj.Form_ID, 0, arrAlertEmployeeSMS, trans) ''0 for SMS
            clsESContentEMPDetail.SaveData(obj.Form_ID, 1, arrAlertEmployeeEMail, trans) '' 1 for EMAIL
            clsESContentEMPDetail.SaveData(obj.Form_ID, 2, arrAlertEmployeeNotification, trans) '' 2 for Notification
            trans.Commit()
        Catch err As System.Exception
            trans.Rollback()
            Throw New System.Exception(err.Message)
        End Try
        Return True
    End Function

    Public Shared Function GetData(ByVal strFormID As String) As clsESContent
        Return GetData(strFormID, Nothing)
    End Function

    Public Shared Function GetData(ByVal strFormID As String, ByVal tran As SqlTransaction) As clsESContent
        Dim obj As clsESContent = Nothing
        Dim qry As String = "SELECT * from TSPL_ES_Content where Form_ID='" + strFormID + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, tran)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsESContent()
            obj.Form_ID = clsCommon.myCstr(dt.Rows(0)("Form_ID"))
            obj.EMail_Subject = clsCommon.myCstr(dt.Rows(0)("EMail_Subject"))
            obj.EMail_Text = clsCommon.myCstr(dt.Rows(0)("EMail_Text"))
            obj.Notification_Caption = clsCommon.myCstr(dt.Rows(0)("Notification_Caption"))
            obj.Notification_Text = clsCommon.myCstr(dt.Rows(0)("Notification_Text"))
            obj.Notification_On = clsCommon.myCstr(dt.Rows(0)("Notification_On"))
            obj.SMS_Text = clsCommon.myCstr(dt.Rows(0)("SMS_Text"))

            obj.arrAlertEmployeeSMS = clsESContentEMPDetail.GetData(strFormID, 0, tran)
            obj.arrAlertEmployeeEMail = clsESContentEMPDetail.GetData(strFormID, 1, tran)
            'done by stuti on 23/11/2016 regarding notification
            obj.arrAlertEmployeeNotification = clsESContentEMPDetail.GetData(strFormID, 2, tran)
        End If

        Return obj
    End Function
End Class

Public Class clsESContentEMPDetail
#Region "Variables"
    Public Form_ID As String = Nothing
    Public EMP_CODE As String = Nothing
    Public Alert_Type As Integer
#End Region

    Public Shared Function SaveData(ByVal strFormID As String, ByVal AlertType As Integer, ByVal arrEMP As ArrayList, ByVal trans As SqlTransaction) As Boolean
        Try
            ''Alert_Type  0--SMS,1-EMail
            If arrEMP IsNot Nothing AndAlso arrEMP.Count > 0 Then
                For Each StrEmp As String In arrEMP
                    Dim coll As New Hashtable()
                    clsCommon.AddColumnsForChange(coll, "Form_Id", strFormID)
                    clsCommon.AddColumnsForChange(coll, "Alert_Type", AlertType)
                    clsCommon.AddColumnsForChange(coll, "EMP_CODE", StrEmp)
                    clsCommonFunctionality.UpdateDataTable(coll, "TSPL_ES_Content_Emp_Detail", OMInsertOrUpdate.Insert, "", trans)
                Next
            End If
        Catch err As System.Exception
            Throw New System.Exception(err.Message)
        End Try
        Return True
    End Function

    Public Shared Function GetData(ByVal strFormID As String, ByVal AlertType As Integer) As ArrayList
        Return GetData(strFormID, AlertType, Nothing)
    End Function
    Public Shared Function GetData(ByVal strFormID As String, ByVal AlertType As Integer, ByVal trans As SqlTransaction) As ArrayList
        Dim arr As ArrayList = Nothing
        Dim qry As String = "SELECT EMP_CODE from TSPL_ES_Content_Emp_Detail where Form_ID='" + strFormID + "' and Alert_Type='" + clsCommon.myCstr(AlertType) + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            arr = New ArrayList()
            For Each dr As DataRow In dt.Rows
                arr.Add(clsCommon.myCstr(dr("EMP_CODE")))
            Next
        End If
        Return arr
    End Function
End Class