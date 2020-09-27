Imports common
Imports System.Data.SqlClient
Public Class clsUserMaster
#Region "Variables"
    Public USER_CODE As String = Nothing
    Public USER_NAME As String = Nothing
    Public PASSWORD As String = Nothing
    Public TYPE As String = Nothing
    Public CLIENT_CODE As String = Nothing
    Public CLIENT_NAME As String = Nothing
    Public USER_GROUP_CODE As String = Nothing
    Public USER_GROUP_NAME As String = Nothing
    Public EMAIL As String = Nothing
    Public PHONE As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public USER_TYPE As String = Nothing
    Public Arr As List(Of clsMappingUserDetail) = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsUserMaster, ByVal isNewEntry As Boolean, ByVal Arr As List(Of clsMappingUserDetail)) As Boolean

        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            Dim qry As String = "delete from TSPL_MAPPING_USER_DETAIL where USER_CODE='" + obj.USER_CODE + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "USER_NAME", obj.USER_NAME)
            clsCommon.AddColumnsForChange(coll, "PASSWORD", obj.PASSWORD)
            clsCommon.AddColumnsForChange(coll, "TYPE", obj.TYPE)
            clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", obj.CLIENT_CODE, True)
            clsCommon.AddColumnsForChange(coll, "USER_GROUP_CODE", obj.USER_GROUP_CODE, True)
            clsCommon.AddColumnsForChange(coll, "EMAIL", obj.EMAIL)
            clsCommon.AddColumnsForChange(coll, "PHONE", obj.PHONE)
            clsCommon.AddColumnsForChange(coll, "USER_TYPE", obj.USER_TYPE)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "USER_CODE", obj.USER_CODE)
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_MASTER", OMInsertOrUpdate.Update, "TSPL_USER_MASTER.USER_CODE='" + obj.USER_CODE + "'", trans)
            End If
            isSaved = isSaved AndAlso clsMappingUserDetail.SaveData(obj.USER_CODE, Arr, trans)
            If isSaved Then
                trans.Commit()
            End If
        Catch err As Exception
            trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsUserMaster
        Dim obj As clsUserMaster = Nothing
        Dim qry As String = " select USER_CODE, USER_NAME,PASSWORD,TYPE,CLIENT_CODE,EMAIL,PHONE,USER_GROUP_CODE,USER_TYPE from TSPL_USER_MASTER  where USER_CODE = '" + strCode + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsUserMaster
            obj.USER_CODE = clsCommon.myCstr(dt.Rows(0)("USER_CODE"))
            obj.USER_NAME = clsCommon.myCstr(dt.Rows(0)("USER_NAME"))
            obj.PASSWORD = clsCommon.myCstr(dt.Rows(0)("PASSWORD"))
            obj.TYPE = clsCommon.myCstr(dt.Rows(0)("TYPE"))
            obj.CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("CLIENT_CODE"))
            obj.CLIENT_NAME = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE = '" + obj.CLIENT_CODE + "' "))
            obj.EMAIL = clsCommon.myCstr(dt.Rows(0)("EMAIL"))
            obj.PHONE = clsCommon.myCstr(dt.Rows(0)("PHONE"))
            obj.USER_TYPE = clsCommon.myCstr(dt.Rows(0)("USER_TYPE"))
            obj.USER_GROUP_CODE = clsCommon.myCstr(dt.Rows(0)("USER_GROUP_CODE"))
            obj.USER_GROUP_NAME = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select GROUP_DESCRIPTION from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE = '" + obj.USER_GROUP_CODE + "' "))

            qry = " select USER_CODE,MAPPING_USER_CODE  from TSPL_MAPPING_USER_DETAIL where  USER_CODE ='" + strCode + "' order by USER_CODE"
            dt = clsDBFuncationality.GetDataTable(qry, Trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                obj.Arr = New List(Of clsMappingUserDetail)
                For Each dr As DataRow In dt.Rows
                    Dim objtr As clsMappingUserDetail = New clsMappingUserDetail()
                    objtr.USER_CODE = clsCommon.myCstr(dr("USER_CODE"))
                    objtr.MAPPING_USER_CODE = clsCommon.myCstr(dr("MAPPING_USER_CODE"))
                    objtr.MAPPING_USER_NAME = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select USER_NAME from TSPL_USER_MASTER where USER_CODE = '" + objtr.MAPPING_USER_CODE + "' "))
                    objtr.CLIENT_CODE = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select CLIENT_CODE from TSPL_USER_MASTER where USER_CODE = '" + objtr.MAPPING_USER_CODE + "' "))
                    objtr.CLIENT_NAME = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE = '" + objtr.CLIENT_CODE + "' "))
                    obj.Arr.Add(objtr)
                Next
            End If
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strUserCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry2 As String = "delete from TSPL_USER_MASTER where USER_CODE='" & strUserCode & "'"
            Dim qry1 As String = "delete from TSPL_MAPPING_USER_DETAIL where USER_CODE='" & strUserCode & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function LoadType() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Internal"
        dr("Name") = "Internal"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "External"
        dr("Name") = "External"
        dt.Rows.Add(dr)
        Return dt
    End Function

    Public Shared Function LoadUserType() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Developer"
        dr("Name") = "Developer"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Tester"
        dr("Name") = "Tester"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Implementation"
        dr("Name") = "Implementation"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Management"
        dr("Name") = "Management"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Other"
        dr("Name") = "Other"
        dt.Rows.Add(dr)
        Return dt
    End Function

End Class
Public Class clsMappingUserDetail
#Region "Variables"
    Public USER_CODE As String = Nothing
    Public MAPPING_USER_CODE As String = Nothing
    Public MAPPING_USER_NAME As String = Nothing
    Public CLIENT_CODE As String = Nothing
    Public CLIENT_NAME As String = Nothing
#End Region
    Public Shared Function SaveData(ByVal strUserCode As String, ByVal Arr As List(Of clsMappingUserDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsMappingUserDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "USER_CODE", strUserCode)
                clsCommon.AddColumnsForChange(coll, "MAPPING_USER_CODE", obj.MAPPING_USER_CODE)
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_MAPPING_USER_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class
