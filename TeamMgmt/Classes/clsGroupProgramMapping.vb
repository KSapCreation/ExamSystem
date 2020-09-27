Imports common
Imports System.Data.SqlClient
Public Class clsGroupProgramMappingMaster
#Region "Variables"
    Public PROGRAM_GROUP_CODE As String = Nothing
    Public GROUP_DESCRIPTION As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public Arr As List(Of clsGroupProgramMappingDetail) = Nothing
#End Region
    Public Function SaveData(ByVal obj As clsGroupProgramMappingMaster, ByVal isNewEntry As Boolean, ByVal Arr As List(Of clsGroupProgramMappingDetail)) As Boolean

        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()

        Try
            Dim qry As String = "delete from TSPL_PROGRAM_GROUP_DETAIL where PROGRAM_GROUP_CODE='" + obj.PROGRAM_GROUP_CODE + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "GROUP_DESCRIPTION", obj.GROUP_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "PROGRAM_GROUP_CODE", obj.PROGRAM_GROUP_CODE)
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_GROUP_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_GROUP_MASTER", OMInsertOrUpdate.Update, "TSPL_PROGRAM_GROUP_MASTER.PROGRAM_GROUP_CODE='" + obj.PROGRAM_GROUP_CODE + "'", trans)
            End If

            isSaved = isSaved AndAlso clsGroupProgramMappingDetail.SaveData(obj.PROGRAM_GROUP_CODE, Arr, trans)

            If isSaved Then
                trans.Commit()
            End If
        Catch err As Exception
            trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsGroupProgramMappingMaster
        Dim obj As clsGroupProgramMappingMaster = Nothing
        ' Dim qry As String = " select PROGRAM_GROUP_CODE, GROUP_DESCRIPTION from TSPL_PROGRAM_GROUP_MASTER  where PROGRAM_GROUP_CODE = '" + strCode + "'"
        Dim qry As String = " select TSPL_USER_GROUP_MASTER.USER_GROUP_CODE as PROGRAM_GROUP_CODE ,TSPL_USER_GROUP_MASTER.GROUP_DESCRIPTION as GROUP_DESCRIPTION   from TSPL_USER_GROUP_MASTER  where TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = '" + strCode + "'"

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsGroupProgramMappingMaster
            obj.PROGRAM_GROUP_CODE = clsCommon.myCstr(dt.Rows(0)("PROGRAM_GROUP_CODE"))
            obj.GROUP_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("GROUP_DESCRIPTION"))

            qry = " select PROGRAM_GROUP_CODE,Program_Code,isREAD ,isSAVE,isDELETE,isREPORT from TSPL_PROGRAM_GROUP_DETAIL where  PROGRAM_GROUP_CODE ='" + strCode + "' order by PROGRAM_GROUP_CODE"
            dt = clsDBFuncationality.GetDataTable(qry, Trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                obj.Arr = New List(Of clsGroupProgramMappingDetail)
                For Each dr As DataRow In dt.Rows
                    Dim objtr As clsGroupProgramMappingDetail = New clsGroupProgramMappingDetail()
                    objtr.PROGRAM_GROUP_CODE = clsCommon.myCstr(dr("PROGRAM_GROUP_CODE"))
                    objtr.Program_Code = clsCommon.myCstr(dr("Program_Code"))
                    objtr.Program_Code_Desc = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select Program_Name from TSPL_PROGRAM_MASTER where Program_Code = '" + objtr.Program_Code + "' "))
                    objtr.READ = dr("isREAD") 'clsCommon.myCstr(dr("isREAD"))
                    objtr.SAVE = dr("isSAVE") 'clsCommon.myCstr(dr("isSAVE"))
                    objtr.DELETE = dr("isDELETE") 'clsCommon.myCstr(dr("isDELETE"))
                    objtr.REPORT = dr("isREPORT") 'clsCommon.myCstr(dr("isREPORT"))
                    obj.Arr.Add(objtr)
                Next
            End If
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strProgramGroupCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry2 As String = "delete from TSPL_PROGRAM_GROUP_MASTER where PROGRAM_GROUP_CODE='" & strProgramGroupCode & "'"
            Dim qry1 As String = "delete from TSPL_PROGRAM_GROUP_DETAIL where PROGRAM_GROUP_CODE='" & strProgramGroupCode & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class

Public Class clsGroupProgramMappingDetail
#Region "Variables"
    Public PROGRAM_GROUP_CODE As String = Nothing
    Public Program_Code As String = Nothing
    Public Program_Code_Desc As String = Nothing
    Public READ As Integer = 0
    Public SAVE As Integer = 0
    Public DELETE As Integer = 0
    Public REPORT As Integer = 0

#End Region
    Public Shared Function SaveData(ByVal strProgramGroupCode As String, ByVal Arr As List(Of clsGroupProgramMappingDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsGroupProgramMappingDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "PROGRAM_GROUP_CODE", strProgramGroupCode)
                clsCommon.AddColumnsForChange(coll, "Program_Code", obj.Program_Code)
                clsCommon.AddColumnsForChange(coll, "isREAD", clsCommon.myCdbl(obj.READ))
                clsCommon.AddColumnsForChange(coll, "isSAVE", clsCommon.myCdbl(obj.SAVE))
                clsCommon.AddColumnsForChange(coll, "isDELETE", clsCommon.myCdbl(obj.DELETE))
                clsCommon.AddColumnsForChange(coll, "isREPORT", clsCommon.myCdbl(obj.REPORT))
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROGRAM_GROUP_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class
