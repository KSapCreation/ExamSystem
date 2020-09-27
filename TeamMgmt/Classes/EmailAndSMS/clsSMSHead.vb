Imports common
Imports System.Net.Mail
Imports System.Net.WebClient
Imports System.IO
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Outlook
Imports System
Imports System.Xml
Imports System.Net
Imports System.Net.WebRequest
Imports System.Net.WebResponse
Imports System.Web
Imports System.Configuration
Imports System.Data.SqlClient

Public Class clsSMSHead
#Region "Variables"
    Public Code As String = Nothing
    Public SMS_Text As String = Nothing
    Public arrMobilNo As List(Of String) = Nothing
#End Region

    Public Function SaveData(ByVal FormID As String, ByVal obj As clsSMSHead, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry As String = " select max(Code) from TSPL_SMS_HEAD where  Code like 'SMS%'"
            obj.Code = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
            If clsCommon.myLen(obj.Code) > 0 Then
                obj.Code = clsCommon.incval(obj.Code)
            Else
                Dim SMSPrefix As String = "SMS"
                If clsCommon.myLen(SMSPrefix) <= 0 Then
                    Throw New System.Exception("Please ask you administrator to set SMS Prefix")
                End If
                obj.Code = SMSPrefix + "0000000000001"
            End If

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Code", obj.Code)
            clsCommon.AddColumnsForChange(coll, "SMS_Text", obj.SMS_Text)
            clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_SMS_HEAD", OMInsertOrUpdate.Insert, "", trans)
            qry = "select TSPL_EMPLOYEE_MASTER.Phone from TSPL_ES_Content_Emp_Detail inner join TSPL_EMPLOYEE_MASTER  on TSPL_EMPLOYEE_MASTER.EMP_CODE = TSPL_ES_Content_Emp_Detail.Emp_code "
            qry += " where LEN(isnull( Phone,''))>0 and TSPL_ES_Content_Emp_Detail.Form_Id='" + FormID + "' and Alert_Type='0'"
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                If obj.arrMobilNo Is Nothing OrElse obj.arrMobilNo.Count <= 0 Then
                    obj.arrMobilNo = New List(Of String)
                End If
                For Each dr As DataRow In dt.Rows
                    obj.arrMobilNo.Add(clsCommon.myCstr(dr("Phone")))
                Next
            End If
            clsSMSDetail.SaveData(obj.Code, obj.arrMobilNo, trans)
        Catch err As System.Exception
            Throw New System.Exception(err.Message)
        End Try
        Return True
    End Function
End Class

Public Class clsSMSDetail
#Region "Variables"
    Public Code As String = Nothing
    Public Mobile_No As String = Nothing
#End Region

    Public Shared Function SaveData(ByVal strCode As String, ByVal Arr As List(Of String), ByVal trans As SqlTransaction) As Boolean
        Try
            Dim arrRepeat As New List(Of String)
            For Each Item As String In Arr
                If arrRepeat.Contains(Item) Then
                    Continue For
                Else
                    arrRepeat.Add(Item)
                End If

                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "Code", strCode)
                clsCommon.AddColumnsForChange(coll, "Mobile_No", Item)
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_SMS_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
            arrRepeat = Nothing
        Catch err As System.Exception
            Throw New System.Exception(err.Message)
        End Try
        Return True
    End Function
End Class

Public Class clsEMailHead
#Region "Variables"
    Public Code As String = Nothing
    Public Email_Subject As String = Nothing
    Public Email_Text As String = Nothing
    Public Attachment_1_Path As String = Nothing
    Public Attachment_2_Path As String = Nothing
    Public arrEMail As List(Of String) = Nothing
    Private Attachment_1_File_Name As String = Nothing
    Private Attachment_2_File_Name As String = Nothing
#End Region

    Public Function SaveData(ByVal FormID As String, ByVal obj As clsEMailHead, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry As String = " select max(Code) from TSPL_EMAIL_HEAD "
            obj.Code = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
            If clsCommon.myLen(obj.Code) > 0 Then
                obj.Code = clsCommon.incval(obj.Code)
            Else
                obj.Code = "EML0000000000001"
            End If

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Code", obj.Code)
            clsCommon.AddColumnsForChange(coll, "Email_Subject", obj.Email_Subject)
            clsCommon.AddColumnsForChange(coll, "Email_Text", obj.Email_Text)
            clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            Dim FileInfo As FileInfo
            If clsCommon.myLen(obj.Attachment_1_Path) > 0 Then
                FileInfo = New FileInfo(obj.Attachment_1_Path)
                obj.Attachment_1_File_Name = FileInfo.Name
                clsCommon.AddColumnsForChange(coll, "Attachment_1_File_Name", obj.Attachment_1_File_Name)
            End If
            If clsCommon.myLen(obj.Attachment_2_Path) > 0 Then
                FileInfo = New FileInfo(obj.Attachment_2_Path)
                obj.Attachment_2_File_Name = FileInfo.Name
                clsCommon.AddColumnsForChange(coll, "Attachment_2_File_Name", obj.Attachment_2_File_Name)
            End If
             If obj.arrEMail IsNot Nothing AndAlso obj.arrEMail.Count > 0 Then
                qry = " select TSPL_USER_MASTER.EMAIL from TSPL_ES_Content_Emp_Detail left outer join TSPL_USER_MASTER on TSPL_USER_MASTER.user_code=TSPL_ES_Content_Emp_Detail.EMP_CODE" + _
                " where Form_Id='" + FormID + "' and alert_type=1 and len(isnull(TSPL_USER_MASTER.EMAIL,''))>0"
                Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        For ii As Integer = obj.arrEMail.Count - 1 To 0
                            If clsCommon.CompairString(obj.arrEMail(ii), clsCommon.myCstr(dr("EMAIL"))) = CompairStringResult.Equal Then
                                obj.arrEMail.RemoveAt(ii)
                                Exit For
                            End If
                        Next
                    Next
                End If
            End If
            
            Dim strEmail As String = ""
            If obj.arrEMail Is Nothing OrElse obj.arrEMail.Count <= 0 Then
                Return True
            End If
            For Each Item As String In obj.arrEMail
                strEmail += Item + ";"
            Next
            clsCommon.AddColumnsForChange(coll, "EMail_ID", strEmail)
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_EMAIL_HEAD", OMInsertOrUpdate.Insert, "", trans)
            If clsCommon.myLen(obj.Attachment_1_Path) > 0 Then
                Dim bData As Byte()
                Dim br As BinaryReader = New BinaryReader(System.IO.File.OpenRead(obj.Attachment_1_Path))
                bData = br.ReadBytes(br.BaseStream.Length)
                Dim str As String = " UPDATE TSPL_EMAIL_HEAD set Attachment_1 = @BLOBData  where CODE='" + obj.Code + "'"
                Dim cmd As SqlCommand = New SqlCommand(str, clsDBFuncationality.GetConnnection, trans)
                Dim prm As New SqlParameter("@BLOBData", bData)
                cmd.Parameters.Add(prm)
                cmd.ExecuteNonQuery()
                br.Close() ' done by stuti reagrding memory leakage
            End If
            If clsCommon.myLen(obj.Attachment_2_Path) > 0 Then
                Dim bData As Byte()
                Dim br As BinaryReader = New BinaryReader(System.IO.File.OpenRead(obj.Attachment_2_Path))
                bData = br.ReadBytes(br.BaseStream.Length)
                Dim str As String = " UPDATE TSPL_EMAIL_HEAD set Attachment_2 = @BLOBData  where CODE='" + obj.Code + "'"
                Dim cmd As SqlCommand = New SqlCommand(str, clsDBFuncationality.GetConnnection, trans)
                Dim prm As New SqlParameter("@BLOBData", bData)
                cmd.Parameters.Add(prm)
                cmd.ExecuteNonQuery()
                br.Close() ' done by stuti reagrding memory leakage
            End If
        Catch err As System.Exception
            Throw New System.Exception(err.Message)
        End Try
        Return True
    End Function
End Class