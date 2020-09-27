Imports System.Data.SqlClient
Imports common
Public Class clsScreenMaster
#Region "Variables"
    Public SCREEN_CODE As String = Nothing
    Public SCREEN_DESCRIPTION As String = Nothing
    Public TYPE As String = Nothing
    Public MODULE_CODE As String = Nothing
    Public MODULE_DESC As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
#End Region

    Public Shared Function SaveData(ByVal obj As clsScreenMaster, ByVal isNewEntry As Boolean) As Boolean
        Dim qry As String = ""
        Dim IsSaved As Boolean = False
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "SCREEN_DESCRIPTION", obj.SCREEN_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "TYPE", obj.TYPE)
            clsCommon.AddColumnsForChange(coll, "MODULE_CODE", obj.MODULE_CODE)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "SCREEN_CODE", obj.SCREEN_CODE)
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_SCREEN_MASTER", OMInsertOrUpdate.Insert, "")
            Else
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_SCREEN_MASTER", OMInsertOrUpdate.Update, "TSPL_SCREEN_MASTER.SCREEN_CODE='" + obj.SCREEN_CODE + "'")
            End If
        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return IsSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal NavType As NavigatorType) As clsScreenMaster
        Dim obj As clsScreenMaster = Nothing
        Dim Arr As List(Of clsScreenMaster) = Nothing
        Dim qry As String = " select SCREEN_CODE as [Code], SCREEN_DESCRIPTION as  [Name],TYPE,MODULE_CODE as [MODULE CODE] from TSPL_SCREEN_MASTER where 2=2 "
        Dim whrclas As String = ""
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_SCREEN_MASTER.SCREEN_CODE = (select MIN(SCREEN_CODE) from TSPL_SCREEN_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Last
                qry += " and TSPL_SCREEN_MASTER.SCREEN_CODE  = (select Max(SCREEN_CODE) from TSPL_SCREEN_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Current
                qry += " and TSPL_SCREEN_MASTER.SCREEN_CODE  = (select TOP 1 SCREEN_CODE from TSPL_SCREEN_MASTER WHERE 1=1 " + whrclas + " and SCREEN_CODE='" + strCode + "' )"
            Case NavigatorType.Next
                qry += " and TSPL_SCREEN_MASTER.SCREEN_CODE  = (select Min(SCREEN_CODE) from TSPL_SCREEN_MASTER where SCREEN_CODE > '" + strCode + "' " + whrclas + ")"
            Case NavigatorType.Previous
                qry += " and TSPL_SCREEN_MASTER.SCREEN_CODE  = (select Max(SCREEN_CODE) from TSPL_SCREEN_MASTER where SCREEN_CODE < '" + strCode + "' " + whrclas + ")"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsScreenMaster()
            obj.SCREEN_CODE = clsCommon.myCstr(dt.Rows(0)("Code"))
            obj.SCREEN_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("Name"))
            obj.TYPE = clsCommon.myCstr(dt.Rows(0)("TYPE"))
            obj.MODULE_CODE = clsCommon.myCstr(dt.Rows(0)("MODULE CODE"))
            obj.MODULE_DESC = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select MODULE_DESCRIPTION from TSPL_MODULE_MASTER where MODULE_CODE ='" + obj.MODULE_CODE + "' "))
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strScreenCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry2 As String = "delete from TSPL_SCREEN_MASTER where SCREEN_CODE='" & strScreenCode & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function LoadScreenType() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Master"
        dr("Name") = "Master"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Transaction"
        dr("Name") = "Transaction"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Report"
        dr("Name") = "Report"
        dt.Rows.Add(dr)
        Return dt
    End Function




End Class
