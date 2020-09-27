Imports common
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Telerik.WinControls
Public Class clsExamReloader
#Region "Varibles"
    Public ArrExamSubmit As List(Of clsExamSubmit) = Nothing
    Public ArrExamMapping As List(Of clsExamMapping) = Nothing
    Public DocNo As String = Nothing
    Public ExamName As String = Nothing
    Public StudentName As String = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsExamReloader, ByVal isNewEntry As Boolean, Optional ByVal isamendment As Boolean = False) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            clsExamSubmit.SaveData(obj.DocNo, ArrExamSubmit, trans)

            '' after marge delete data for main table
            Dim qry As String = "delete from FBNPC_Submit_Exam where studentname='" + obj.StudentName + "' and ExamName='" + obj.ExamName + "'"
            clsDBFuncationality.ExecuteNonQuery(qry, trans)

            clsExamMapping.SaveData(obj.DocNo, ArrExamMapping, trans)

            '' after marge records delete data for main table
            Dim qryValidation As String = "delete from FBNPC_Exam_Question_Validtion where studentname='" + obj.StudentName + "' and ExamName='" + obj.ExamName + "'"
            clsDBFuncationality.ExecuteNonQuery(qryValidation, trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
End Class
Public Class clsExamSubmit
#Region "Variable"
    Public Hist_By As String = Nothing
    Public Hist_Date As Date?
    Public Hist_Version As String = Nothing
    Public Examname As String = Nothing
    Public OptionD As String = Nothing
    Public QuestionID As String = Nothing
    Public OptionC As String = Nothing
    Public OptionB As String = Nothing
    Public OptionA As String = Nothing
    Public StudentName As String = Nothing
    Public paperID As String = Nothing
#End Region
    Public Shared Function SaveData(ByVal strDocNo As String, ByVal Arr As List(Of clsExamSubmit), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsExamSubmit In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "Hist_By", obj.Hist_By)
                clsCommon.AddColumnsForChange(coll, "Hist_Version", strDocNo)
                clsCommon.AddColumnsForChange(coll, "Hist_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "QuestionID", obj.QuestionID)
                clsCommon.AddColumnsForChange(coll, "OptionA", obj.OptionA)
                clsCommon.AddColumnsForChange(coll, "Optionb", obj.OptionB)
                clsCommon.AddColumnsForChange(coll, "Optionc", obj.OptionC)
                clsCommon.AddColumnsForChange(coll, "OptionD", obj.OptionD)
                clsCommon.AddColumnsForChange(coll, "ExamName", obj.Examname)
                clsCommon.AddColumnsForChange(coll, "StudentName", obj.StudentName)
                clsCommon.AddColumnsForChange(coll, "PaperID", obj.paperID)
                clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_Submit_Exam_History", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class
Public Class clsExamMapping
#Region "variable"
    Public Hist_By As String = Nothing
    Public Hist_Date As Date?
    Public Hist_Version As String = Nothing
    Public Examname As String = Nothing
    Public StudentName As String = Nothing
    Public paperID As String = Nothing
#End Region
    Public Shared Function SaveData(ByVal strDocNo As String, ByVal Arr As List(Of clsExamMapping), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsExamMapping In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "Hist_By", obj.Hist_By)
                clsCommon.AddColumnsForChange(coll, "Hist_Version", strDocNo)
                clsCommon.AddColumnsForChange(coll, "Hist_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "ExamName", obj.Examname)
                clsCommon.AddColumnsForChange(coll, "StudentName", obj.StudentName)
                clsCommon.AddColumnsForChange(coll, "PaperID", obj.paperID)
                clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_Exam_Question_Validtion_History", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function
End Class
