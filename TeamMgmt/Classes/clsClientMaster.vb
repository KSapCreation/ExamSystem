Imports System.Data.SqlClient
Imports common
Public Class clsClientMaster
#Region "Variables"
    Public CLIENT_CODE As String = Nothing
    Public CLIENT_DESCRIPTION As String = Nothing
    Public VERTICAL As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public Arr As List(Of clsClientDetail) = Nothing
#End Region

    Public Shared Function SaveData(ByVal obj As clsClientMaster, ByVal isNewEntry As Boolean, ByVal Arr As List(Of clsClientDetail)) As Boolean
        Dim qry As String = ""
        Dim IsSaved As Boolean = False
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            Dim qry1 As String = " delete from TSPL_CLIENT_DETAIL where CLIENT_CODE='" + obj.CLIENT_CODE + "'"
            clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "CLIENT_DESCRIPTION", obj.CLIENT_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "VERTICAL", obj.VERTICAL)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", obj.CLIENT_CODE)
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_CLIENT_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_CLIENT_MASTER", OMInsertOrUpdate.Update, "TSPL_CLIENT_MASTER.CLIENT_CODE='" + obj.CLIENT_CODE + "'", trans)
            End If
            IsSaved = IsSaved AndAlso clsClientDetail.SaveData(obj.CLIENT_CODE, Arr, trans)
            If IsSaved Then
                trans.Commit()
            End If
        Catch err As Exception
            trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return IsSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal NavType As NavigatorType) As clsClientMaster
        Dim obj As clsClientMaster = Nothing
        Dim Arr As List(Of clsClientMaster) = Nothing
        Dim qry As String = " select CLIENT_CODE as [Code], CLIENT_DESCRIPTION as  [Name],VERTICAL from TSPL_CLIENT_MASTER where 2=2 "
        Dim whrclas As String = ""
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_CLIENT_MASTER.CLIENT_CODE = (select MIN(CLIENT_CODE) from TSPL_CLIENT_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Last
                qry += " and TSPL_CLIENT_MASTER.CLIENT_CODE  = (select Max(CLIENT_CODE) from TSPL_CLIENT_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Current
                qry += " and TSPL_CLIENT_MASTER.CLIENT_CODE  = (select TOP 1 CLIENT_CODE from TSPL_CLIENT_MASTER WHERE 1=1 " + whrclas + " and CLIENT_CODE='" + strCode + "' )"
            Case NavigatorType.Next
                qry += " and TSPL_CLIENT_MASTER.CLIENT_CODE  = (select Min(CLIENT_CODE) from TSPL_CLIENT_MASTER where CLIENT_CODE > '" + strCode + "' " + whrclas + ")"
            Case NavigatorType.Previous
                qry += " and TSPL_CLIENT_MASTER.CLIENT_CODE  = (select Max(CLIENT_CODE) from TSPL_CLIENT_MASTER where CLIENT_CODE < '" + strCode + "' " + whrclas + ")"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsClientMaster()
            obj.CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("Code"))
            obj.CLIENT_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("Name"))
            obj.VERTICAL = clsCommon.myCstr(dt.Rows(0)("VERTICAL"))

            qry = " select CLIENT_CODE,PERSON_NAME,PERSON_EMAIL,PERSON_PHONE,IS_SEND_MAIL  from TSPL_CLIENT_DETAIL where  CLIENT_CODE ='" + obj.CLIENT_CODE + "' order by CLIENT_CODE"
            dt = clsDBFuncationality.GetDataTable(qry)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                obj.Arr = New List(Of clsClientDetail)
                For Each dr As DataRow In dt.Rows
                    Dim objtr As clsClientDetail = New clsClientDetail()
                    objtr.PERSON_NAME = clsCommon.myCstr(dr("PERSON_NAME"))
                    objtr.PERSON_EMAIL = clsCommon.myCstr(dr("PERSON_EMAIL"))
                    objtr.PERSON_PHONE = clsCommon.myCstr(dr("PERSON_PHONE"))
                    objtr.IS_SEND_MAIL = clsCommon.myCstr(dr("IS_SEND_MAIL"))
                    obj.Arr.Add(objtr)
                Next
            End If

        End If
        Return obj
    End Function
End Class

Public Class clsClientDetail
    Public PERSON_NAME As String = Nothing
    Public PERSON_EMAIL As String = Nothing
    Public PERSON_PHONE As String = Nothing
    Public IS_SEND_MAIL As String = Nothing

    Public Shared Function SaveData(ByVal strClientCode As String, ByVal Arr As List(Of clsClientDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsClientDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", strClientCode)
                clsCommon.AddColumnsForChange(coll, "PERSON_NAME", obj.PERSON_NAME)
                clsCommon.AddColumnsForChange(coll, "PERSON_EMAIL", obj.PERSON_EMAIL)
                clsCommon.AddColumnsForChange(coll, "PERSON_PHONE", obj.PERSON_PHONE)
                clsCommon.AddColumnsForChange(coll, "IS_SEND_MAIL", obj.IS_SEND_MAIL)
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_CLIENT_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class
