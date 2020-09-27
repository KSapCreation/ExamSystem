Imports common
Imports System.Data.SqlClient

Public Class clsUserGroupMappingMaster
#Region "Variables"
    Public USER_CODE As String = Nothing
    Public USER_NAME As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public Arr As List(Of clsUserGroupMappingDetail) = Nothing
#End Region
    Public Function SaveData(ByVal obj As clsUserGroupMappingMaster, ByVal isNewEntry As Boolean, ByVal Arr As List(Of clsUserGroupMappingDetail)) As Boolean

        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            Dim qry As String = "delete from TSPL_MAPPING_USER_GROUP_DETAIL where USER_CODE='" + obj.USER_CODE + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "USER_CODE", obj.USER_CODE)
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MAPPING_USER_GROUP_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MAPPING_USER_GROUP_MASTER", OMInsertOrUpdate.Update, "TSPL_MAPPING_USER_GROUP_MASTER.USER_CODE='" + obj.USER_CODE + "'", trans)
            End If
            isSaved = isSaved AndAlso clsUserGroupMappingDetail.SaveData(obj.USER_CODE, Arr, trans)
            If isSaved Then
                trans.Commit()
            End If
        Catch err As Exception
            trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsUserGroupMappingMaster
        Dim obj As clsUserGroupMappingMaster = Nothing
        Dim qry As String = " select USER_CODE, USER_NAME from TSPL_USER_MASTER  where USER_CODE = '" + strCode + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsUserGroupMappingMaster
            obj.USER_CODE = clsCommon.myCstr(dt.Rows(0)("USER_CODE"))
            obj.USER_NAME = clsCommon.myCstr(dt.Rows(0)("USER_NAME"))

            qry = " select USER_CODE,USER_GROUP_CODE  from TSPL_MAPPING_USER_GROUP_DETAIL where  USER_CODE ='" + strCode + "' order by USER_CODE"
            dt = clsDBFuncationality.GetDataTable(qry, Trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                obj.Arr = New List(Of clsUserGroupMappingDetail)
                For Each dr As DataRow In dt.Rows
                    Dim objtr As clsUserGroupMappingDetail = New clsUserGroupMappingDetail()
                    objtr.USER_CODE = clsCommon.myCstr(dr("USER_CODE"))
                    objtr.USER_GROUP_CODE = clsCommon.myCstr(dr("USER_GROUP_CODE"))
                    objtr.USER_GROUP_CODE_DESC = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select GROUP_DESCRIPTION from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE = '" + objtr.USER_GROUP_CODE + "' "))
                    obj.Arr.Add(objtr)
                Next
            End If
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strUserCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry2 As String = "delete from TSPL_MAPPING_USER_GROUP_MASTER where USER_CODE='" & strUserCode & "'"
            Dim qry1 As String = "delete from TSPL_MAPPING_USER_GROUP_DETAIL where USER_CODE='" & strUserCode & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class

Public Class clsUserGroupMappingDetail
#Region "Variables"
    Public USER_CODE As String = Nothing
    Public USER_GROUP_CODE As String = Nothing
    Public USER_GROUP_CODE_DESC As String = Nothing
#End Region
    Public Shared Function SaveData(ByVal strUserCode As String, ByVal Arr As List(Of clsUserGroupMappingDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsUserGroupMappingDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "USER_CODE", strUserCode)
                clsCommon.AddColumnsForChange(coll, "USER_GROUP_CODE", obj.USER_GROUP_CODE)
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MAPPING_USER_GROUP_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class
