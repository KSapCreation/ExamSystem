Imports System.Data.SqlClient
Imports common
Public Class clsUserGroupMaster
#Region "Variables"
    Public USER_GROUP_CODE As String = Nothing
    Public GROUP_DESCRIPTION As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
#End Region
    Public Shared Function SaveData(ByVal obj As clsUserGroupMaster, ByVal isNewEntry As Boolean) As Boolean
        Dim qry As String = ""
        Dim IsSaved As Boolean = False
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "GROUP_DESCRIPTION", obj.GROUP_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "USER_GROUP_CODE", obj.USER_GROUP_CODE)
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_GROUP_MASTER", OMInsertOrUpdate.Insert, "")
            Else
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_GROUP_MASTER", OMInsertOrUpdate.Update, "TSPL_USER_GROUP_MASTER.USER_GROUP_CODE='" + obj.USER_GROUP_CODE + "'")
            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return IsSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal NavType As NavigatorType) As clsUserGroupMaster
        Dim obj As clsUserGroupMaster = Nothing
        Dim Arr As List(Of clsUserGroupMaster) = Nothing
        Dim qry As String = " select USER_GROUP_CODE as [Code], GROUP_DESCRIPTION as  [Name]  from TSPL_USER_GROUP_MASTER where 2=2 "
        Dim whrclas As String = ""
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = (select MIN(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Last
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE  = (select Max(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Current
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE  = (select TOP 1 USER_GROUP_CODE from TSPL_USER_GROUP_MASTER WHERE 1=1 " + whrclas + " and USER_GROUP_CODE='" + strCode + "' )"
            Case NavigatorType.Next
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE  = (select Min(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE > '" + strCode + "' " + whrclas + ")"
            Case NavigatorType.Previous
                qry += " and TSPL_USER_GROUP_MASTER.USER_GROUP_CODE  = (select Max(USER_GROUP_CODE) from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE < '" + strCode + "' " + whrclas + ")"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsUserGroupMaster()
            obj.USER_GROUP_CODE = clsCommon.myCstr(dt.Rows(0)("Code"))
            obj.GROUP_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("Name"))
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strUserGroupCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry1 As String = "delete from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE='" & strUserGroupCode & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
