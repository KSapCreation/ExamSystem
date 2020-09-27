Imports System.Data.SqlClient
Imports common
Public Class clsProjectMaster
#Region "Variables"
    Public PROJECT_CODE As String = Nothing
    Public PROJECT_DESCRIPTION As String = Nothing
    Public Created_By As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
#End Region
    Public Shared Function getFinder(ByVal whrcls As String, ByVal curcode As String, ByVal isButtonClicked As Boolean) As String
        Dim str As String = ""
        Dim qry As String = "  Select PROJECT_CODE as [Code],PROJECT_DESCRIPTION AS [Description] from TSPL_PROJECT_MASTER  "
        str = clsCommon.ShowSelectForm("FND@Project", qry, "Code", whrcls, curcode, "Code", isButtonClicked)
        Return str
    End Function

    Public Shared Function SaveData(ByVal obj As clsProjectMaster, ByVal isNewEntry As Boolean) As Boolean
        Dim qry As String = ""
        Dim IsSaved As Boolean = False
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "PROJECT_DESCRIPTION", obj.PROJECT_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "PROJECT_CODE", obj.PROJECT_CODE)
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROJECT_MASTER", OMInsertOrUpdate.Insert, "")
            Else
                IsSaved = clsCommonFunctionality.UpdateDataTable(coll, "TSPL_PROJECT_MASTER", OMInsertOrUpdate.Update, "TSPL_PROJECT_MASTER.PROJECT_CODE='" + obj.PROJECT_CODE + "'")
            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return IsSaved
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal NavType As NavigatorType) As clsProjectMaster
        Dim obj As clsProjectMaster = Nothing
        Dim Arr As List(Of clsProjectMaster) = Nothing
        Dim qry As String = " select PROJECT_CODE as [Code], PROJECT_DESCRIPTION as  [Name] from TSPL_PROJECT_MASTER where 2=2 "
        Dim whrclas As String = ""
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_PROJECT_MASTER.PROJECT_CODE = (select MIN(PROJECT_CODE) from TSPL_PROJECT_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Last
                qry += " and TSPL_PROJECT_MASTER.PROJECT_CODE  = (select Max(PROJECT_CODE) from TSPL_PROJECT_MASTER WHERE 1=1 " + whrclas + " )"
            Case NavigatorType.Current
                qry += " and TSPL_PROJECT_MASTER.PROJECT_CODE  = (select TOP 1 PROJECT_CODE from TSPL_PROJECT_MASTER WHERE 1=1 " + whrclas + " and PROJECT_CODE='" + strCode + "' )"
            Case NavigatorType.Next
                qry += " and TSPL_PROJECT_MASTER.PROJECT_CODE  = (select Min(PROJECT_CODE) from TSPL_PROJECT_MASTER where PROJECT_CODE > '" + strCode + "' " + whrclas + ")"
            Case NavigatorType.Previous
                qry += " and TSPL_PROJECT_MASTER.PROJECT_CODE  = (select Max(PROJECT_CODE) from TSPL_PROJECT_MASTER where PROJECT_CODE < '" + strCode + "' " + whrclas + ")"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsProjectMaster()
            obj.PROJECT_CODE = clsCommon.myCstr(dt.Rows(0)("Code"))
            obj.PROJECT_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("Name"))
        End If
        Return obj
    End Function
End Class
