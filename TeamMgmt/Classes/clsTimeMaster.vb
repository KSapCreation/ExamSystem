Imports System.Data.SqlClient
Imports common
Public Class clsTimeMaster
#Region "Variables"
    Public Tester_Time As Double = Nothing
    Public Debugging_Time As Double = Nothing
    Public Additional_Time As Double = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
#End Region

    Public Shared Function SaveData(ByVal obj As clsTimeMaster, ByVal isNewEntry As Boolean) As Boolean
        Dim qry As String = ""
        Dim IsSaved As Boolean = False
        Try
            Dim strQry As String = " truncate table TSPL_TIME_MASTER "
            clsDBFuncationality.ExecuteNonQuery(strQry)
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Tester_Time", obj.Tester_Time)
            clsCommon.AddColumnsForChange(coll, "Debugging_Time", obj.Debugging_Time)
            clsCommon.AddColumnsForChange(coll, "Additional_Time", obj.Additional_Time)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_TIME_MASTER", OMInsertOrUpdate.Insert, "")
            Else
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_TIME_MASTER", OMInsertOrUpdate.Insert, "")
            End If
        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return IsSaved
    End Function

End Class
