Imports System.Data.SqlClient
Imports common
Public Class clsCreateExe
#Region "Variables"
    Public Client_Code As String = Nothing
    Public Version_No As String = Nothing
    Public DocNo As String = Nothing
    Public Doc_Date As Date? = Nothing
    Public Ticket_No As String = Nothing
    Public Type As String = Nothing
    Public Ticket_Active As Integer = 0
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public Arr As List(Of clsCreateExeDetail) = Nothing
#End Region
    Public Shared Function SaveData(ByVal obj As clsCreateExe, ByVal isNewEntry As Boolean) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            If SaveData(obj, isNewEntry, trans) Then
                trans.Commit()
                Return True
            End If
        Catch ex As Exception
            trans.Rollback()
        End Try
        Return True
    End Function
    Public Shared Function SaveData(ByRef obj As clsCreateExe, ByVal isNewEntry As Boolean, ByVal trans As SqlTransaction) As Boolean
        Dim IsSaved As Boolean = False
        Try
            Dim qry As String = "delete from TSPL_VERSION_Detail where Version_CODE='" + obj.DocNo + "'"
            IsSaved = IsSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)
            If isNewEntry Then
                qry = "select  MAX(Version_CODE)  from TSPL_VERSION_HEAD"
                obj.DocNo = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
                If clsCommon.myLen(obj.DocNo) <= 0 Then
                    obj.DocNo = "V00000000001"
                Else
                    obj.DocNo = clsCommon.incval(obj.DocNo)
                End If
            End If
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Client_Code", obj.Client_Code)
            clsCommon.AddColumnsForChange(coll, "Version_Date", clsCommon.GetPrintDate(obj.Doc_Date, "dd/MMM/yyyy hh:mm tt"))
            clsCommon.AddColumnsForChange(coll, "Version", obj.Version_No)
            clsCommon.AddColumnsForChange(coll, "Type", obj.Type)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Version_CODE", obj.DocNo)
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_VERSION_HEAD", OMInsertOrUpdate.Insert, "", trans)
            Else
                IsSaved = IsSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_VERSION_HEAD", OMInsertOrUpdate.Update, "TSPL_VERSION_HEAD.Version_CODE='" + obj.DocNo + "'", trans)
            End If
            clsCreateExeDetail.SaveData(obj.DocNo, obj.Arr, trans)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
    Public Shared Function GetData(ByVal strDocumentNo As String, ByVal NavType As NavigatorType, Optional ByVal arrLoc As String = "") As clsCreateExe
        Return GetData(strDocumentNo, NavType, arrLoc, Nothing)
    End Function
    Public Shared Function GetData(ByVal strPONo As String, ByVal NavType As NavigatorType, ByVal arrLoc As String, ByVal trans As SqlTransaction) As clsCreateExe
        Dim obj As clsCreateExe = Nothing
        Dim whrClas As String = ""
        Dim qry As String = "select Client_Code,Version_CODE,Version_Date,Version,Type from TSPL_VERSION_HEAD where 2=2 "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_VERSION_HEAD.Version_Code = (select MIN(Version_Code) from TSPL_VERSION_HEAD where 1=1 " + whrClas + ")"
            Case NavigatorType.Last
                qry += " and TSPL_VERSION_HEAD.Version_Code = (select Max(Version_Code) from TSPL_VERSION_HEAD where 1=1 " + whrClas + ")"
            Case NavigatorType.Next
                qry += " and TSPL_VERSION_HEAD.Version_Code = (select Min(Version_Code) from TSPL_VERSION_HEAD where Version_Code>'" + strPONo + "' " + whrClas + ")"
            Case NavigatorType.Previous
                qry += " and TSPL_VERSION_HEAD.Version_Code = (select Max(Version_Code) from TSPL_VERSION_HEAD where Version_Code<'" + strPONo + "' " + whrClas + ")"
            Case NavigatorType.Current
                qry += " and TSPL_VERSION_HEAD.Version_Code = '" + strPONo + "'"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsCreateExe()
            obj.Client_Code = clsCommon.myCstr(dt.Rows(0)("Client_Code"))
            obj.Version_No = clsCommon.myCstr(dt.Rows(0)("Version"))
            obj.Doc_Date = clsCommon.myCDate(dt.Rows(0)("Version_Date"))
            obj.DocNo = clsCommon.myCstr(dt.Rows(0)("Version_Code"))
            obj.Type = clsCommon.myCstr(dt.Rows(0)("Type"))
        End If
        qry = "SELECT Ticket_Code,cast(Active as bit) as Active from TSPL_VERSION_detail where TSPL_VERSION_detail.Version_Code='" + strPONo + "'"
        dt = New DataTable()
        dt = clsDBFuncationality.GetDataTable(qry, trans)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj.Arr = New List(Of clsCreateExeDetail)
            Dim objTr As clsCreateExeDetail
            For Each dr As DataRow In dt.Rows
                objTr = New clsCreateExeDetail
                objTr.TicketNo = clsCommon.myCstr(dr("Ticket_Code"))
                objTr.Status = clsCommon.myCdbl(dr("Active"))
                obj.Arr.Add(objTr)

            Next

        End If
        Return obj
    End Function
    Public Shared Function deleteData(ByVal strScreenCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim isDeleted As Boolean = True
            Dim qry2 As String = "delete from TSPL_VERSION_detail where Version_CODE='" & strScreenCode & "'"
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
            qry2 = "delete from TSPL_VERSION_Head where Version_CODE='" & strScreenCode & "'"
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
        dr("Code") = "I"
        dr("Name") = "Internal"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "E"
        dr("Name") = "External"
        dt.Rows.Add(dr)

        Return dt
    End Function
End Class

<Serializable()> _
Public Class clsCreateExeDetail
    Public TicketNo As String = Nothing
    Public Status As Boolean = False
    Public Shared Function SaveData(ByVal strDocNo As String, ByVal Arr As List(Of clsCreateExeDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsCreateExeDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "Version_CODE", strDocNo)
                clsCommon.AddColumnsForChange(coll, "Ticket_Code", obj.TicketNo)
                clsCommon.AddColumnsForChange(coll, "Active", IIf(obj.Status = True, 1, 0))
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_VERSION_DETAIL", OMInsertOrUpdate.Insert, "", trans)

            Next
        End If
        Return True
    End Function
End Class