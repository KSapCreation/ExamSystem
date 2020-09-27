
Imports common
Imports System.Data.SqlClient


Public Class clsFixedParameterType
    Public Const QuickExport As String = "Q_EX"
    Public Const SMSEMailPassword As String = "SMS EMail Password"
    Public Const SMSEMailConfigPassword As String = "SMS EMail Config Password"
End Class

Public Class clsFixedParameterCode
    Public Const MaxRowsForQuickExport As String = "Q-EXP-MX-RW"
    Public Const SMSEMailPassword As String = "SMS EMail Password"
    Public Const SMSEMailConfigPassword As String = "SMS EMail Config Password"
End Class


Public Class clsFixedParameter
#Region "Variables"
    Public Type As String = ""
    Public Code As String = ""
    Public Description As String = ""
    Public Specification As String = ""
#End Region

    Public Shared Function GetData(ByVal strType As String, ByVal strCode As String, ByVal trans As SqlTransaction) As String
        Return clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Description from TSPL_FIXED_PARAMETER where TYPE='" + strType + "' and Code='" + strCode + "'", trans))
    End Function

    Public Shared Function GetSpecification(ByVal strType As String, ByVal strCode As String, ByVal trans As SqlTransaction) As String
        Return clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Specification from TSPL_FIXED_PARAMETER where TYPE='" + strType + "' and Code='" + strCode + "'", trans))
    End Function
    Public Shared Function GetCboDataTable(ByVal strType As String, ByVal trans As SqlTransaction) As DataTable
        Dim qry As String = "SELECT Code,DESCRIPTION FROM TSPL_FIXED_PARAMETER where Type= '" + strType + "' "
        Dim dt_Cbo As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
        Return dt_Cbo
    End Function

    Public Shared Sub UpdateData(ByVal Type As String, ByVal Code As String, ByVal Description As String, ByVal trans As SqlTransaction)
        Dim qry As String = "Update TSPL_FIXED_PARAMETER Set Description='" + Description + "' where TYPE='" + Type + "'"
        If clsCommon.myLen(Code) > 0 Then
            qry += " and Code='" + Code + "'"
        End If
        clsDBFuncationality.ExecuteNonQuery(qry, trans)
        qry = String.Empty
    End Sub

    Public Shared Function UpdateFixedParameter(ByVal obj As clsFixedParameter, ByVal trans As SqlTransaction, ByVal isNewEntry As Boolean) As Boolean
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Description", obj.Description)
            clsCommon.AddColumnsForChange(coll, "Specification", obj.Specification)
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Type", obj.Type)
                clsCommon.AddColumnsForChange(coll, "Code", obj.Code)
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "", trans)
            Else
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Update, "Type='" + obj.Type + "' AND Code='" + obj.Code + "'", trans)
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function GetFixedParameter(ByVal trans As SqlTransaction) As DataTable
        Try
            Dim Qry As String = "select Type, Code, Description, Specification  from TSPL_FIXED_PARAMETER"
            Return clsDBFuncationality.GetDataTable(Qry)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Shared Function FixedParameterValues() As Boolean

        InsertDefaultValueFixedParameter(clsFixedParameterType.QuickExport, clsFixedParameterCode.MaxRowsForQuickExport, "25000", "Number of rows to be Saved at once when using Quick Export")
        InsertDefaultValueFixedParameter(clsFixedParameterType.SMSEMailPassword, clsFixedParameterCode.SMSEMailPassword, "tecxpert", "SMS/Email Setting Password")
        InsertDefaultValueFixedParameter(clsFixedParameterType.SMSEMailConfigPassword, clsFixedParameterCode.SMSEMailConfigPassword, "tecxpert@123", "SMS/Email Config Password")
        Dim dt As Date = clsCommon.GETSERVERDATE()
        dt = dt.AddDays(30)
        clsFixedParameterProgramMapping.SetDefaultValues()
        Return True
    End Function
    'DEBUG
    Public Shared Function InsertDefaultValueFixedParameter(ByVal strType As String, ByVal strCode As String, ByVal strDescription As String, ByVal strSpecification As String) As Boolean
        Dim qry As String = "select Type from TSPL_FIXED_PARAMETER where Code='" + strCode + "' and Type ='" + strType + "'"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

        Dim coll As New Hashtable()
        clsCommon.AddColumnsForChange(coll, "Type", strType)
        clsCommon.AddColumnsForChange(coll, "Code", strCode)
        clsCommon.AddColumnsForChange(coll, "Description", strDescription)
        clsCommon.AddColumnsForChange(coll, "Specification", strSpecification, True)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER", OMInsertOrUpdate.Insert, "")
        End If
        Return True
    End Function

End Class

Public Class clsFixedParameterProgramMapping
    Public Shared Function InsertDefaultValue(ByVal strProgramCode As String, ByVal strType As String, ByVal strCode As String, ByVal ControlType As EnumControlType) As Boolean
        Dim coll As New Hashtable()
        clsCommon.AddColumnsForChange(coll, "Program_Code", strProgramCode)
        clsCommon.AddColumnsForChange(coll, "FP_Type", strType)
        clsCommon.AddColumnsForChange(coll, "FP_Code", strCode)
        clsCommon.AddColumnsForChange(coll, "Control_Type", clsCommon.myCdbl(ControlType))
        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_FIXED_PARAMETER_PROGRAM_MAPPING", OMInsertOrUpdate.Insert, "")
        Return True
    End Function

    Public Shared Sub SetDefaultValues()
        clsDBFuncationality.ExecuteNonQuery("Delete from TSPL_FIXED_PARAMETER_PROGRAM_MAPPING")
    End Sub
End Class