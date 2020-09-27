Imports common
Imports System.Data.SqlClient
Public Class clsModuleMaster
#Region "Variables"
    Public MODULE_CODE As String = Nothing
    Public MODULE_DESCRIPTION As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public Arr As List(Of clsModuleDetail) = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsModuleMaster, ByVal isNewEntry As Boolean, ByVal Arr As List(Of clsModuleDetail)) As Boolean

        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()

        Try
            Dim qry As String = "delete from TSPL_MODULE_DETAIL where MODULE_CODE='" + obj.MODULE_CODE + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "MODULE_DESCRIPTION", obj.MODULE_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "MODULE_CODE", obj.MODULE_CODE)
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MODULE_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MODULE_MASTER", OMInsertOrUpdate.Update, "TSPL_MODULE_MASTER.MODULE_CODE='" + obj.MODULE_CODE + "'", trans)
            End If


            isSaved = isSaved AndAlso clsModuleDetail.SaveData(obj.MODULE_CODE, Arr, trans)


            If isSaved Then
                trans.Commit()
            End If
        Catch err As Exception
            trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsModuleMaster
        Dim obj As clsModuleMaster = Nothing
        Dim qry As String = " select MODULE_CODE, MODULE_DESCRIPTION from TSPL_MODULE_MASTER  where MODULE_CODE = '" + strCode + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsModuleMaster
            obj.MODULE_CODE = clsCommon.myCstr(dt.Rows(0)("MODULE_CODE"))
            obj.MODULE_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("MODULE_DESCRIPTION"))

            qry = " select MODULE_CODE,PROJECT_CODE  from TSPL_MODULE_DETAIL where  MODULE_CODE ='" + strCode + "' order by MODULE_CODE"
            dt = clsDBFuncationality.GetDataTable(qry, Trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                obj.Arr = New List(Of clsModuleDetail)
                For Each dr As DataRow In dt.Rows
                    Dim objtr As clsModuleDetail = New clsModuleDetail()
                    objtr.MODULE_CODE = clsCommon.myCstr(dr("MODULE_CODE"))
                    objtr.PROJECT_CODE = clsCommon.myCstr(dr("PROJECT_CODE"))
                    objtr.PROJECT_DESCRIPTION = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select PROJECT_DESCRIPTION from TSPL_PROJECT_MASTER where PROJECT_CODE = '" + objtr.MODULE_CODE + "' "))
                    obj.Arr.Add(objtr)
                Next
            End If
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strModuleCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry2 As String = "delete from TSPL_MODULE_MASTER where MODULE_CODE='" & strModuleCode & "'"
            Dim qry1 As String = "delete from TSPL_MODULE_DETAIL where MODULE_CODE='" & strModuleCode & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
Public Class clsModuleDetail
#Region "Variables"
    Public MODULE_CODE As String = Nothing
    Public PROJECT_CODE As String = Nothing
    Public PROJECT_DESCRIPTION As String = Nothing
#End Region
    Public Shared Function SaveData(ByVal strModuleCode As String, ByVal Arr As List(Of clsModuleDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsModuleDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "MODULE_CODE", strModuleCode)
                clsCommon.AddColumnsForChange(coll, "PROJECT_CODE", obj.PROJECT_CODE)
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MODULE_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class

