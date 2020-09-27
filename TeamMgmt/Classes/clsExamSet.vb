Imports common
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Telerik.WinControls

Public Class clsExamSet
#Region "Varibles"
    Public Arr As List(Of clsExamSetDetail) = Nothing
    Public ArrChkList As List(Of clsExamSetDetail) = Nothing
    Public Subject As String = Nothing
    Public Section As String = Nothing
    Public ExamName As String = Nothing
    Public AVName As String = Nothing
    Public DocNo As String = Nothing
    Public posted As String = Nothing
    Public VideoName As String = Nothing
    Public QuestionDesc As String = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsExamSet, ByVal isNewEntry As Boolean, Optional ByVal isamendment As Boolean = False) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            SaveData(obj, isNewEntry, trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function

    Public Function SaveData(ByVal obj As clsExamSet, ByVal isNewEntry As Boolean, ByVal trans As SqlTransaction) As Boolean
        Dim isSaved As Boolean = True
        Try

            Dim qry As String = "delete from FBNPC_PAPER_SET_detail where PaperID='" + obj.DocNo + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)

            Dim strDocNo As String = ""

            If (clsCommon.myLen(obj.DocNo) <= 0) Then
                Throw New Exception("Error in Document Code Generation")
            End If

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Subject", obj.Subject)
            clsCommon.AddColumnsForChange(coll, "Section", obj.Section)
            clsCommon.AddColumnsForChange(coll, "ExamID", obj.ExamName)
            clsCommon.AddColumnsForChange(coll, "ModifyBy", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "ModifyDate", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))

            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "PaperID", obj.DocNo)
                clsCommon.AddColumnsForChange(coll, "CreatedBy", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "CreatedDate", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_PAPER_SET_HEAD", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_PAPER_SET_HEAD", OMInsertOrUpdate.Update, "FBNPC_PAPER_SET_HEAD.PaperID='" + obj.DocNo + "'", trans)
            End If
            isSaved = isSaved AndAlso clsExamSetDetail.SaveData(obj.DocNo, obj.Section, obj.ExamName, Arr, trans)

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function
    Public Shared Function GetData(ByVal strDocumentNo As String, ByVal NavType As NavigatorType) As clsExamSet
        Return GetData(strDocumentNo, NavType, Nothing)
    End Function
    Public Shared Function GetData(ByVal strPONo As String, ByVal NavType As NavigatorType, ByVal trans As SqlTransaction) As clsExamSet
        Dim obj As clsExamSet = Nothing
        Dim qry As String = "Select * from FBNPC_PAPER_SET_HEAD where 2=2"
        Dim whrCls As String = ""
     
        Select Case NavType
            Case NavigatorType.First
                qry += " and FBNPC_PAPER_SET_HEAD.PaperID = (select MIN(PaperID) from FBNPC_PAPER_SET_HEAD WHERE 1=1 )"
            Case NavigatorType.Last
                qry += " and FBNPC_PAPER_SET_HEAD.PaperID = (select Max(PaperID) from FBNPC_PAPER_SET_HEAD WHERE 1=1  )"
            Case NavigatorType.Next
                qry += " and FBNPC_PAPER_SET_HEAD.PaperID = (select Min(PaperID) from FBNPC_PAPER_SET_HEAD where PaperID>'" + strPONo + "')"
            Case NavigatorType.Previous
                qry += " and FBNPC_PAPER_SET_HEAD.PaperID = (select Max(PaperID) from FBNPC_PAPER_SET_HEAD where PaperID<'" + strPONo + "')"
            Case NavigatorType.Current
                qry += " and FBNPC_PAPER_SET_HEAD.PaperID = '" + strPONo + "'"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsExamSet()
            obj.Subject = clsCommon.myCstr(dt.Rows(0)("Subject"))
            obj.Section = clsCommon.myCstr(dt.Rows(0)("Section"))
            obj.ExamName = clsCommon.myCstr(dt.Rows(0)("ExamID"))
            obj.DocNo = clsCommon.myCstr(dt.Rows(0)("PaperID"))
            obj.posted = clsCommon.myCstr(dt.Rows(0)("Posted"))

            qry = "SELECT FBNPC_PAPER_SET_DETAIL.*,FBNPC_QUSTIONSSHEET.Question from FBNPC_PAPER_SET_detail left outer join FBNPC_QUSTIONSSHEET on FBNPC_QUSTIONSSHEET.questionID=FBNPC_PAPER_SET_detail.QuestionID where PaperID='" + obj.DocNo + "'"
            dt = New DataTable()
            dt = clsDBFuncationality.GetDataTable(qry, trans)
            If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
                obj.Arr = New List(Of clsExamSetDetail)
                Dim objTr As clsExamSetDetail
                For Each dr As DataRow In dt.Rows
                    objTr = New clsExamSetDetail
                    objTr.Section = clsCommon.myCstr(dr("Section"))
                    objTr.ExamID = clsCommon.myCstr(dr("ExamID"))
                    objTr.AVID = clsCommon.myCstr(dr("AVID"))
                    objTr.QuestionID = clsCommon.myCstr(dr("QuestionID"))
                    objTr.QusSelect = clsCommon.myCBool(dr("QusSelect"))
                    objTr.QuestionDesc = clsCommon.myCstr(dr("Question"))
                    obj.AVName = clsCommon.myCstr(dr("AVID"))
                    obj.VideoName = clsCommon.myCstr(dr("VideoID"))
                    objTr.ComprehensionID = clsCommon.myCstr(dr("ComprehensionID"))
                    obj.Arr.Add(objTr)
                Next

            End If
        End If

        Return obj
    End Function
    Public Shared Function PostData(ByVal strDocNo As String) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            PostData(strDocNo, trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
    Public Shared Function PostData(ByVal strDocNo As String, ByVal trans As SqlTransaction) As Boolean
        Return PostData(strDocNo, True, trans)
    End Function
    Public Shared Function PostData(ByVal strDocNo As String, ByVal isCheckForPosted As Boolean, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim isSaved As Boolean = True
            If (clsCommon.myLen(strDocNo) <= 0) Then
                Throw New Exception("Exam ID not found to Post")
            End If

            Dim obj As clsExamSet = clsExamSet.GetData(strDocNo, NavigatorType.Current, trans)

            If (obj Is Nothing OrElse clsCommon.myLen(obj.DocNo) <= 0) Then
                Throw New Exception("No Data found to Post")
            End If

            Dim qry As String = ""
            qry = "Update FBNPC_PAPER_SET_HEAD set Posted=1 where PaperID='" + strDocNo + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)


        Catch ex As Exception

            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
End Class
Public Class clsExamSetDetail
#Region "Varibles"
    Public ExamID As String = Nothing
    Public Section As String = Nothing
    Public QuestionID As String = Nothing
    Public QuestionDesc As String = Nothing
    Public QusSelect As Boolean = False
    Public AVID As String = Nothing
    Public VideoName As String = Nothing
    Public ComprehensionID As String = Nothing
#End Region

    Public Shared Function SaveData(ByVal strDocNo As String, ByVal Section As String, ByVal ExamID As String, ByVal Arr As List(Of clsExamSetDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsExamSetDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "QuestionID", obj.QuestionID)
                clsCommon.AddColumnsForChange(coll, "Section", Section)
                clsCommon.AddColumnsForChange(coll, "AVID", obj.AVID)
                clsCommon.AddColumnsForChange(coll, "ExamID", ExamID)
                clsCommon.AddColumnsForChange(coll, "QusSelect", obj.QusSelect)
                clsCommon.AddColumnsForChange(coll, "PaperID", strDocNo)
                clsCommon.AddColumnsForChange(coll, "VideoID", obj.VideoName)
                clsCommon.AddColumnsForChange(coll, "ComprehensionID", obj.ComprehensionID)
                clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_PAPER_SET_detail", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function

End Class

Public Class clsExamStudentMapping
#Region "Varibles"
    Public Arr As List(Of clsExamStudentMappingDetail) = Nothing
    Public ArrChkList As List(Of clsExamStudentMappingDetail) = Nothing
    Public StudentName As String = Nothing
    Public DocNo As String = Nothing
    Public posted As String = Nothing
    
#End Region

    Public Function SaveData(ByVal obj As clsExamStudentMapping, ByVal isNewEntry As Boolean, Optional ByVal isamendment As Boolean = False) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            SaveData(obj, isNewEntry, trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function

    Public Function SaveData(ByVal obj As clsExamStudentMapping, ByVal isNewEntry As Boolean, ByVal trans As SqlTransaction) As Boolean
        Dim isSaved As Boolean = True
        Try

            Dim qry As String = "delete from FBNPC_EXAM_STUDENT_MAPPING_Detail where ESM_Code='" + obj.DocNo + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)

            Dim strDocNo As String = ""

            If (clsCommon.myLen(obj.DocNo) <= 0) Then
                Throw New Exception("Error in Document Code Generation")
            End If

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "StudentName", obj.StudentName)
            clsCommon.AddColumnsForChange(coll, "ModifyBy", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "ModifyDate", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))

            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "ESM_Code", obj.DocNo)
                clsCommon.AddColumnsForChange(coll, "CreatedBy", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "CreatedDate", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_EXAM_STUDENT_MAPPING_HEAD", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_EXAM_STUDENT_MAPPING_HEAD", OMInsertOrUpdate.Update, "FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESM_Code='" + obj.DocNo + "'", trans)
            End If
            isSaved = isSaved AndAlso clsExamStudentMappingDetail.SaveData(obj.DocNo, Arr, trans)

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function
    Public Shared Function GetData(ByVal strDocumentNo As String, ByVal NavType As NavigatorType) As clsExamStudentMapping
        Return GetData(strDocumentNo, NavType, Nothing)
    End Function
    Public Shared Function GetData(ByVal strPONo As String, ByVal NavType As NavigatorType, ByVal trans As SqlTransaction) As clsExamStudentMapping
        Dim obj As clsExamStudentMapping = Nothing
        Dim qry As String = "Select * from FBNPC_EXAM_STUDENT_MAPPING_HEAD where 2=2"
        Dim whrCls As String = ""

        Select Case NavType
            Case NavigatorType.First
                qry += " and FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESM_Code = (select MIN(ESM_Code) from FBNPC_EXAM_STUDENT_MAPPING_HEAD WHERE 1=1 )"
            Case NavigatorType.Last
                qry += " and FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESM_Code = (select Max(ESM_Code) from FBNPC_EXAM_STUDENT_MAPPING_HEAD WHERE 1=1  )"
            Case NavigatorType.Next
                qry += " and FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESM_Code = (select Min(ESM_Code) from FBNPC_EXAM_STUDENT_MAPPING_HEAD where ESM_Code>'" + strPONo + "')"
            Case NavigatorType.Previous
                qry += " and FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESM_Code = (select Max(ESM_Code) from FBNPC_EXAM_STUDENT_MAPPING_HEAD where ESM_Code<'" + strPONo + "')"
            Case NavigatorType.Current
                qry += " and FBNPC_EXAM_STUDENT_MAPPING_HEAD.ESM_Code = '" + strPONo + "'"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsExamStudentMapping()

            obj.StudentName = clsCommon.myCstr(dt.Rows(0)("StudentName"))
            obj.DocNo = clsCommon.myCstr(dt.Rows(0)("ESM_Code"))

            qry = "SELECT FBNPC_EXAM_STUDENT_MAPPING_detail.*,FBNPC_EXAMLISTNAME.ExamName from FBNPC_EXAM_STUDENT_MAPPING_detail left outer join FBNPC_EXAMLISTNAME on FBNPC_EXAMLISTNAME.ExamID=FBNPC_EXAM_STUDENT_MAPPING_detail.ExamCode where ESM_Code='" + obj.DocNo + "'"
            dt = New DataTable()
            dt = clsDBFuncationality.GetDataTable(qry, trans)
            If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
                obj.Arr = New List(Of clsExamStudentMappingDetail)
                Dim objTr As clsExamStudentMappingDetail
                For Each dr As DataRow In dt.Rows
                    objTr = New clsExamStudentMappingDetail
                    objTr.QusSelect = clsCommon.myCstr(dr("QusSelect"))
                    objTr.ExamCode = clsCommon.myCstr(dr("ExamCode"))
                    objTr.ExamName = clsCommon.myCstr(dr("ExamName"))
                    obj.Arr.Add(objTr)
                Next

            End If
        End If

        Return obj
    End Function
    Public Shared Function DeleteData(ByVal strCode As String) As Boolean
        Dim isSaved As Boolean = False
        If (clsCommon.myLen(strCode) <= 0) Then
            Throw New Exception("Document No not found to Delete")
        End If
        Dim obj As clsExamStudentMapping = clsExamStudentMapping.GetData(strCode, NavigatorType.Current)
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        If (obj IsNot Nothing AndAlso clsCommon.myLen(obj.DocNo) > 0) Then
            Try
                Dim qry As String = "delete from FBNPC_EXAM_STUDENT_MAPPING_detail where ESM_Code='" + strCode + "'"
                isSaved = clsDBFuncationality.ExecuteNonQuery(qry, trans)

                qry = "delete from FBNPC_EXAM_STUDENT_MAPPING_Head where ESM_Code='" + strCode + "'"
                isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)
                If (isSaved) Then
                    trans.Commit()
                Else
                    trans.Rollback()
                End If
            Catch ex As Exception
                trans.Rollback()
                Throw New Exception(ex.Message)
            End Try
        End If
        Return isSaved
    End Function
    Public Shared Function PostData(ByVal strDocNo As String) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            PostData(strDocNo, trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
    Public Shared Function PostData(ByVal strDocNo As String, ByVal trans As SqlTransaction) As Boolean
        Return PostData(strDocNo, True, trans)
    End Function
    Public Shared Function PostData(ByVal strDocNo As String, ByVal isCheckForPosted As Boolean, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim isSaved As Boolean = True
            If (clsCommon.myLen(strDocNo) <= 0) Then
                Throw New Exception("Exam ID not found to Post")
            End If

            Dim obj As clsExamSet = clsExamSet.GetData(strDocNo, NavigatorType.Current, trans)

            If (obj Is Nothing OrElse clsCommon.myLen(obj.DocNo) <= 0) Then
                Throw New Exception("No Data found to Post")
            End If

            Dim qry As String = ""
            qry = "Update FBNPC_PAPER_SET_HEAD set Posted=1 where PaperID='" + strDocNo + "'"
            isSaved = isSaved AndAlso clsDBFuncationality.ExecuteNonQuery(qry, trans)


        Catch ex As Exception

            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
End Class
Public Class clsExamStudentMappingDetail
#Region "Varibles"
    Public ESM_Code As String = Nothing
    Public ExamCode As String = Nothing
    Public ExamName As String = Nothing
    Public QusSelect As Boolean = False
#End Region

    Public Shared Function SaveData(ByVal strDocNo As String, ByVal Arr As List(Of clsExamStudentMappingDetail), ByVal trans As SqlTransaction) As Boolean
        If (Arr IsNot Nothing AndAlso Arr.Count > 0) Then
            For Each obj As clsExamStudentMappingDetail In Arr
                Dim coll As New Hashtable()
                clsCommon.AddColumnsForChange(coll, "ESM_Code", strDocNo)
                clsCommon.AddColumnsForChange(coll, "ExamCode", obj.ExamCode)
                clsCommon.AddColumnsForChange(coll, "QusSelect", obj.QusSelect)
                clsCommonFunctionality.UpdateDataTable(coll, "FBNPC_EXAM_STUDENT_MAPPING_DETAIL", OMInsertOrUpdate.Insert, "", trans)
            Next
        End If
        Return True
    End Function

End Class