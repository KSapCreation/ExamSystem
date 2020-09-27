Imports common
Imports System.Data.SqlClient
Public Class clsTicketMasterEntry
#Region "Variables"
    Public TICKET_NO As String = Nothing
    Public TICKET_DATE As Date? = Nothing
    Public CLIENT_CODE As String = Nothing
    Public CLIENT_NAME As String = Nothing
    Public SCREEN_CODE As String = Nothing
    Public SCREEN_NAME As String = Nothing
    Public MODULE_CODE As String = Nothing
    Public MODULE_NAME As String = Nothing
    Public PROJECT_CODE As String = Nothing
    Public PROJECT_NAME As String = Nothing
    Public TICKET_STATUS As String = Nothing
    Public DEVELOPER_CODE As String = Nothing
    Public DEVELOPER_NAME As String = Nothing
    Public TESTER_CODE As String = Nothing
    Public TESTER_NAME As String = Nothing
    Public TICKET_TYPE As String = Nothing
    Public DATA_ERROR_TYPE As String = Nothing
    Public SEVERITY As String = Nothing
    Public PRIORITY As String = Nothing
    Public TICKET_DESCRIPTION As String = Nothing
    Public ALLOCATION_REMARKS As String = Nothing
    Public ALLOCATED_TIME As String = Nothing
    Public DEVELOPER_REMARKS As String = Nothing
    Public DEVELOPMENT_TIME As String = Nothing
    Public TESTER_REMARKS As String = Nothing
    Public TESTING_TIME As String = Nothing
    Public REQUEST_NO As String = Nothing
    Public REQUEST_DATE As Date? = Nothing
    Public ANALYSIS_NO As String = Nothing
    Public ANALYSIS_DATE As Date? = Nothing
    Public Created_By As String = Nothing
    Public Created_By_Name As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public Form_Title_Name As String = ""
    Public DEVELOPMENT_EXE_VERSION As String = Nothing
    Public TESTING_EXE_VERSION As String = Nothing
    Public ACTUAL_TESTING_TIME As String = Nothing

    ' For TimeSheet Details 
    Public DEVELOPER_YOUR_REMARKS As String = Nothing
    Public TESTER_YOUR_REMARKS As String = Nothing

#End Region

    Public Function SaveData(ByVal obj As clsTicketMasterEntry, ByVal isNewEntry As Boolean) As Boolean
        Dim isSaved As Boolean = True
        Dim Trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            isSaved = SaveData(obj, isNewEntry, Trans)
            If isSaved Then
                Trans.Commit()
            End If
        Catch err As Exception
            Trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Public Function UpdateTicketStatus(ByVal obj As clsTicketMasterEntry, ByVal Trans As SqlTransaction) As Boolean
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "TICKET_NO", obj.TICKET_NO)
            clsCommon.AddColumnsForChange(coll, "TICKET_STATUS", obj.TICKET_STATUS)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_TICKET_MASTER", OMInsertOrUpdate.Update, "TSPL_TICKET_MASTER.TICKET_NO='" + obj.TICKET_NO + "'", Trans)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function
    Public Function SaveTimeSheetDetaisl(ByVal obj As clsTicketMasterEntry, ByVal Trans As SqlTransaction) As Boolean
        Try
            Dim coll As New Hashtable()
            Dim strTimeSheetNo As String = GetnrateTimeSheetNo(Trans)
            clsCommon.AddColumnsForChange(coll, "TIME_SHEET_NO", strTimeSheetNo)
            clsCommon.AddColumnsForChange(coll, "TIME_SHEET_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommon.AddColumnsForChange(coll, "TICKET_NO", obj.TICKET_NO)
            clsCommon.AddColumnsForChange(coll, "STATUS", obj.TICKET_STATUS)
            If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                clsCommon.AddColumnsForChange(coll, "TIME", obj.DEVELOPMENT_TIME) '
                clsCommon.AddColumnsForChange(coll, "EXE_VERSION", obj.DEVELOPMENT_EXE_VERSION)
                clsCommon.AddColumnsForChange(coll, "REMARKS", obj.DEVELOPER_YOUR_REMARKS)
                clsCommon.AddColumnsForChange(coll, "ALLOCATED_TIME", obj.ALLOCATED_TIME)
                clsCommon.AddColumnsForChange(coll, "TYPE", "D")
            Else
                clsCommon.AddColumnsForChange(coll, "TIME", obj.ACTUAL_TESTING_TIME)
                clsCommon.AddColumnsForChange(coll, "EXE_VERSION", obj.TESTING_EXE_VERSION)
                clsCommon.AddColumnsForChange(coll, "REMARKS", obj.TESTER_YOUR_REMARKS)
                clsCommon.AddColumnsForChange(coll, "ALLOCATED_TIME", obj.TESTING_TIME)
                clsCommon.AddColumnsForChange(coll, "TYPE", "T")
            End If
            clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)

            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_TIME_SHEET_DETAIL", OMInsertOrUpdate.Insert, "", Trans)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return True
    End Function
    Public Function SaveData(ByVal obj As clsTicketMasterEntry, ByVal isNewEntry As Boolean, ByVal Trans As SqlTransaction) As Boolean

        Dim isSaved As Boolean = True
        'Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", obj.CLIENT_CODE)
            clsCommon.AddColumnsForChange(coll, "SCREEN_CODE", obj.SCREEN_CODE)
            clsCommon.AddColumnsForChange(coll, "MODULE_CODE", obj.MODULE_CODE)
            clsCommon.AddColumnsForChange(coll, "PROJECT_CODE", obj.PROJECT_CODE)
            clsCommon.AddColumnsForChange(coll, "TICKET_STATUS", obj.TICKET_STATUS)
            clsCommon.AddColumnsForChange(coll, "DEVELOPER_CODE", obj.DEVELOPER_CODE, True)
            clsCommon.AddColumnsForChange(coll, "TESTER_CODE", obj.TESTER_CODE, True)
            clsCommon.AddColumnsForChange(coll, "TICKET_TYPE", obj.TICKET_TYPE)
            clsCommon.AddColumnsForChange(coll, "DATA_ERROR_TYPE", obj.DATA_ERROR_TYPE)
            clsCommon.AddColumnsForChange(coll, "SEVERITY", obj.SEVERITY)
            clsCommon.AddColumnsForChange(coll, "PRIORITY", obj.PRIORITY)
            clsCommon.AddColumnsForChange(coll, "TICKET_DESCRIPTION", obj.TICKET_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "ALLOCATION_REMARKS", obj.ALLOCATION_REMARKS)
            clsCommon.AddColumnsForChange(coll, "ALLOCATED_TIME", obj.ALLOCATED_TIME)
            clsCommon.AddColumnsForChange(coll, "DEVELOPER_REMARKS", obj.DEVELOPER_REMARKS)
            clsCommon.AddColumnsForChange(coll, "DEVELOPMENT_TIME", obj.DEVELOPMENT_TIME)
            clsCommon.AddColumnsForChange(coll, "TESTER_REMARKS", obj.TESTER_REMARKS)
            clsCommon.AddColumnsForChange(coll, "TESTING_TIME", obj.TESTING_TIME)
            clsCommon.AddColumnsForChange(coll, "REQUEST_NO", obj.REQUEST_NO)
            clsCommon.AddColumnsForChange(coll, "DEVELOPMENT_EXE_VERSION", obj.DEVELOPMENT_EXE_VERSION)
            clsCommon.AddColumnsForChange(coll, "TESTING_EXE_VERSION", obj.TESTING_EXE_VERSION)
            clsCommon.AddColumnsForChange(coll, "ACTUAL_TESTING_TIME", obj.ACTUAL_TESTING_TIME)
            'TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION ,TSPL_TICKET_MASTER.TESTING_EXE_VERSION, ACTUAL_TESTING_TIME
            'clsCommon.AddColumnsForChange(coll, "REQUEST_DATE", obj.REQUEST_DATE)
            clsCommon.AddColumnsForChange(coll, "ANALYSIS_NO", obj.ANALYSIS_NO, True)
            'clsCommon.AddColumnsForChange(coll, "ANALYSIS_DATE", obj.ANALYSIS_DATE, True)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "TICKET_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
                obj.TICKET_NO = GetnrateTicketNo(obj.CLIENT_CODE, Trans)
                If clsCommon.myLen(obj.TICKET_NO) > 0 Then
                    clsCommon.AddColumnsForChange(coll, "TICKET_NO", obj.TICKET_NO)
                End If

                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_TICKET_MASTER", OMInsertOrUpdate.Insert, "", Trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_TICKET_MASTER", OMInsertOrUpdate.Update, "TSPL_TICKET_MASTER.TICKET_NO='" + obj.TICKET_NO + "'", Trans)
            End If
            If clsCommon.CompairString(Form_Title_Name, "Time Sheet") = CompairStringResult.Equal Then
                SaveTimeSheetDetaisl(obj, Trans)
            End If
            SaveEmailText(obj.TICKET_NO, Trans)
            'If isSaved Then
            '    Trans.Commit()
            'End If
        Catch err As Exception
            'Trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Function SaveEmailText(ByVal DocNo As String, ByVal trans As SqlTransaction) As Boolean
        Dim obj As clsTicketMasterEntry = clsTicketMasterEntry.GetData(DocNo, trans)
        Dim objES As clsESContent
        If clsCommon.CompairString(Form_Title_Name, "Ticket Master") = CompairStringResult.Equal Or (clsCommon.myLen(Form_Title_Name) <= 0 AndAlso clsCommon.myLen(obj.DEVELOPER_CODE) <= 0 AndAlso clsCommon.myLen(obj.TESTER_CODE) <= 0) Then
            objES = clsESContent.GetData(clsUserMgtCode.FrmTicketMaster, trans)
        ElseIf clsCommon.CompairString(Form_Title_Name, "Ticket Allocation") = CompairStringResult.Equal Or (clsCommon.myLen(Form_Title_Name) <= 0 AndAlso clsCommon.myLen(obj.DEVELOPER_CODE) > 0 AndAlso clsCommon.myLen(obj.TESTER_CODE) > 0) Then
            objES = clsESContent.GetData(clsUserMgtCode.FrmTicketAllocation, trans)
        ElseIf clsCommon.CompairString(Form_Title_Name, "Time Sheet") = CompairStringResult.Equal Then
            objES = clsESContent.GetData(clsUserMgtCode.frmTimeSheet, trans)
        End If

        If obj IsNot Nothing AndAlso objES IsNot Nothing Then
            Dim objSMSH As New clsEMailHead()
            objSMSH.Email_Subject = objES.EMail_Subject
            objSMSH.Email_Text = objES.EMail_Text

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketNo, obj.TICKET_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketNo, obj.TICKET_NO)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketDate, clsCommon.GetPrintDate(obj.TICKET_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketDate, clsCommon.GetPrintDate(obj.TICKET_DATE, "dd/MMM/yyyy"))


            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketStatus, obj.TICKET_STATUS)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketStatus, obj.TICKET_STATUS)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketType, obj.TICKET_TYPE)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketType, obj.TICKET_TYPE)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Priority, obj.PRIORITY)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Priority, obj.PRIORITY)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Severity, obj.SEVERITY)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Severity, obj.SEVERITY)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.CreatedBy, obj.Created_By)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.CreatedBy, obj.Created_By)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.CreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.CreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))


            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModifyBy, obj.Modify_By)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModifyBy, obj.Modify_By)


            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModifyDate, clsCommon.GetPrintDate(obj.Modify_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModifyDate, clsCommon.GetPrintDate(obj.Modify_Date, "dd/MMM/yyyy"))

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)


            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ProjectName, obj.PROJECT_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ProjectName, obj.PROJECT_NAME)


            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModuleName, obj.MODULE_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModuleName, obj.MODULE_NAME)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ScreenName, obj.SCREEN_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ScreenName, obj.SCREEN_NAME)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketDetails, obj.TICKET_DESCRIPTION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketDetails, obj.TICKET_DESCRIPTION)

            If clsCommon.myLen(obj.REQUEST_NO) > 0 Then
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDate, "NA") 'objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.myCstr(clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy")))

                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDate, "NA")
            Else
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestNo, "NA")
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDate, "NA")

                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestNo, "NA")
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDate, "NA")
            End If
            If clsCommon.myLen(obj.ANALYSIS_NO) > 0 Then
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisNo, obj.ANALYSIS_NO)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisDate, "NA") 'objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisDate, clsCommon.myCstr(clsCommon.GetPrintDate(obj.ANALYSIS_DATE, "dd/MMM/yyyy")))

                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisNo, obj.ANALYSIS_NO)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisDate, "NA")
            Else
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisNo, "NA")
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisDate, "NA")

                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisNo, "NA")
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisDate, "NA")
            End If


            If clsCommon.CompairString(Form_Title_Name, "Ticket Allocation") = CompairStringResult.Equal Then
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AllocationTime, obj.ALLOCATED_TIME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DeveloperName, obj.DEVELOPER_NAME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TesterName, obj.TESTER_NAME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketAllocationDetails, obj.ALLOCATION_REMARKS)

                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AllocationTime, obj.ALLOCATED_TIME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DeveloperName, obj.DEVELOPER_NAME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TesterName, obj.TESTER_NAME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketAllocationDetails, obj.ALLOCATION_REMARKS)

                'If clsCommon.myLen(obj.IS_CLIENT_APPROVED) > 0 Then
                '    If clsCommon.CompairString(obj.IS_CLIENT_APPROVED, "1") = CompairStringResult.Equal Then
                '        objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientApprovedStatus, "Approved")
                '        If clsCommon.myLen(obj.IS_CLIENT_APPROVED_DATE) > 0 Then
                '            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientApprovedDate, clsCommon.GetPrintDate(obj.IS_CLIENT_APPROVED_DATE, "dd/MMM/yyyy"))
                '        End If
                '    Else
                '        objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientApprovedStatus, "Not Approved")
                '        objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientApprovedDate, "NA")
                '    End If
                'End If

            End If

            If clsCommon.CompairString(Form_Title_Name, "Time Sheet") = CompairStringResult.Equal Then
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AllocationTime, obj.ALLOCATED_TIME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DeveloperName, obj.DEVELOPER_NAME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TesterName, obj.TESTER_NAME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketAllocationDetails, obj.ALLOCATION_REMARKS)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DeveloperRemarks, obj.DEVELOPER_REMARKS)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DevelopmentTime, obj.DEVELOPMENT_TIME)
                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ExeVersion, obj.DEVELOPMENT_EXE_VERSION)

                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AllocationTime, obj.ALLOCATED_TIME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DeveloperName, obj.DEVELOPER_NAME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TesterName, obj.TESTER_NAME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketAllocationDetails, obj.ALLOCATION_REMARKS)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DeveloperRemarks, obj.DEVELOPER_REMARKS)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DevelopmentTime, obj.DEVELOPMENT_TIME)
                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ExeVersion, obj.DEVELOPMENT_EXE_VERSION)

                If clsCommon.myLen(obj.TESTER_CODE) > 0 Then
                    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TesterRemarks, obj.TESTER_REMARKS)
                    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TesterTime, obj.TESTING_TIME)
                    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ExeVersion, obj.TESTING_EXE_VERSION)

                    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TesterRemarks, obj.TESTER_REMARKS)
                    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TesterTime, obj.TESTING_TIME)
                    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ExeVersion, obj.TESTING_EXE_VERSION)
                Else
                    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TesterRemarks, "NA")
                    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TesterTime, "NA")

                    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TesterRemarks, "NA")
                    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TesterTime, "NA")
                End If
                'If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
                '    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ExeVersion, obj.DEVELOPMENT_EXE_VERSION)
                '    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ExeVersion, obj.DEVELOPMENT_EXE_VERSION)
                'Else
                '    objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ExeVersion, obj.TESTING_EXE_VERSION)
                '    objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ExeVersion, obj.TESTING_EXE_VERSION)
                'End If

            End If

            objSMSH.arrEMail = New List(Of String)()

            
            Dim qry As String = " select TSPL_USER_MASTER.EMAIL as PERSON_EMAIL from TSPL_USER_MASTER where len(isnull( TSPL_USER_MASTER.EMAIL,''))>0 and TSPL_USER_MASTER.USER_CODE in (  select TSPL_MAPPING_USER_DETAIL.MAPPING_USER_CODE from TSPL_MAPPING_USER_DETAIL inner join TSPL_USER_MASTER on TSPL_USER_MASTER.USER_CODE =TSPL_MAPPING_USER_DETAIL.USER_CODE where  TSPL_MAPPING_USER_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "' ) "
            If clsCommon.CompairString(Form_Title_Name, "Ticket Allocation") = CompairStringResult.Equal Or clsCommon.CompairString(Form_Title_Name, "Time Sheet") = CompairStringResult.Equal Then
                qry += " Union "
                qry += " select TSPL_USER_MASTER.EMAIL as PERSON_EMAIL from TSPL_TICKET_MASTER inner join TSPL_USER_MASTER on TSPL_USER_MASTER.USER_CODE = TSPL_TICKET_MASTER.DEVELOPER_CODE where len(isnull( TSPL_USER_MASTER.EMAIL,''))>0 and TSPL_TICKET_MASTER.DEVELOPER_CODE = '" + obj.DEVELOPER_CODE + "' and TSPL_TICKET_MASTER.TICKET_NO = '" + obj.TICKET_NO + "'  "
                qry += " Union "
                qry += " select TSPL_USER_MASTER.EMAIL as PERSON_EMAIL from TSPL_TICKET_MASTER inner join TSPL_USER_MASTER on TSPL_USER_MASTER.USER_CODE = TSPL_TICKET_MASTER.TESTER_CODE where len(isnull( TSPL_USER_MASTER.EMAIL,''))>0 and TSPL_TICKET_MASTER.TESTER_CODE = '" + obj.TESTER_CODE + "' and TSPL_TICKET_MASTER.TICKET_NO = '" + obj.TICKET_NO + "'  "
            End If
            'If clsCommon.CompairString(Form_Title_Name, "Time Sheet") = CompairStringResult.Equal Then

            'End If
           
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    objSMSH.arrEMail.Add(clsCommon.myCstr(dr("PERSON_EMAIL")))
                Next
            End If
            objSMSH.SaveData(clsUserMgtCode.frmRequestCreation, objSMSH, trans)
            objSMSH = Nothing
        End If

    End Function

    Public Shared Function GetnrateTicketNo(ByVal strClientCode As String, ByVal Trans As SqlTransaction) As String
        Dim strTicketNo As String = ""
        Try
            Dim sno As String = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select case when len ( max( convert ( int, RIGHT(TSPL_TICKET_MASTER.TICKET_NO,LEN(TSPL_TICKET_MASTER.TICKET_NO)-CHARINDEX('-',TSPL_TICKET_MASTER.TICKET_NO)) )) ) is null then '1' else max( convert ( int, RIGHT(TSPL_TICKET_MASTER.TICKET_NO,LEN(TSPL_TICKET_MASTER.TICKET_NO)-CHARINDEX('-',TSPL_TICKET_MASTER.TICKET_NO)) )) end from TSPL_TICKET_MASTER where  TSPL_TICKET_MASTER.CLIENT_CODE = '" + strClientCode + "'", Trans))
            Dim strTicketSNo As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select ISNULL( right('000000' + convert(varchar(20), " + sno + "+1), 6),0) from TSPL_TICKET_MASTER where TSPL_TICKET_MASTER.CLIENT_CODE = '" + strClientCode + "'  ", Trans))
            If clsCommon.myLen(strTicketSNo) <= 0 Then
                strTicketSNo = "000001"
            End If
            strTicketNo = strClientCode.Substring(0, 3) + "/" + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MM/yy") + "-" + strTicketSNo
        Catch ex As Exception
        End Try
        Return strTicketNo
    End Function

    Public Shared Function GetnrateTimeSheetNo(ByVal Trans As SqlTransaction) As String

        Dim strTimeSheetNo As String = Nothing
        Try
            strTimeSheetNo = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select max(TIME_SHEET_NO) from TSPL_TIME_SHEET_DETAIL where TSPL_TIME_SHEET_DETAIL.Created_By = '" + objCommonVar.CurrentUserCode + "'", Trans))
            If clsCommon.myLen(strTimeSheetNo) <= 0 Then
                If clsCommon.myLen(objCommonVar.CurrentUserCode) >= 3 Then
                    strTimeSheetNo = objCommonVar.CurrentUserCode.Substring(0, 3) + "-000001"
                Else
                    strTimeSheetNo = objCommonVar.CurrentUserCode + "-000001"
                End If
            Else
                strTimeSheetNo = clsCommon.incval(strTimeSheetNo)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return strTimeSheetNo



        'Dim strTicketNo As String = ""
        'Try
        '    Dim sno As String = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select case when len ( max( convert ( int, RIGHT(TSPL_TICKET_MASTER.TICKET_NO,LEN(TSPL_TICKET_MASTER.TICKET_NO)-CHARINDEX('-',TSPL_TICKET_MASTER.TICKET_NO)) )) ) is null then '1' else max( convert ( int, RIGHT(TSPL_TICKET_MASTER.TICKET_NO,LEN(TSPL_TICKET_MASTER.TICKET_NO)-CHARINDEX('-',TSPL_TICKET_MASTER.TICKET_NO)) )) end from TSPL_TICKET_MASTER where  TSPL_TICKET_MASTER.CLIENT_CODE = '" + strClientCode + "'", Trans))
        '    Dim strTicketSNo As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select ISNULL( right('000000' + convert(varchar(20), " + sno + "+1), 6),0) from TSPL_TICKET_MASTER where TSPL_TICKET_MASTER.CLIENT_CODE = '" + strClientCode + "'  ", Trans))
        '    If clsCommon.myLen(strTicketSNo) <= 0 Then
        '        strTicketSNo = "000001"
        '    End If
        '    strTicketNo = strClientCode.Substring(0, 3) + "/" + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MM/yy") + "-" + strTicketSNo
        'Catch ex As Exception
        'End Try
        'Return strTicketNo
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsTicketMasterEntry
        Dim obj As clsTicketMasterEntry = Nothing
        Dim qry As String = " select TSPL_TICKET_MASTER.TICKET_NO,convert(varchar, TSPL_TICKET_MASTER.TICKET_DATE,103) as TICKET_DATE,isnull(TSPL_TICKET_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_TICKET_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_TICKET_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_TICKET_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_TICKET_MASTER.TICKET_STATUS,'') as TICKET_STATUS ,isnull(TSPL_TICKET_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_TICKET_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_TICKET_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name,convert(varchar, TSPL_TICKET_MASTER.Created_Date,103) as Created_Date,isnull( TSPL_TICKET_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_TICKET_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_TICKET_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_TICKET_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_TICKET_MASTER.TICKET_DESCRIPTION,'') as TICKET_DESCRIPTION ,isnull(TSPL_TICKET_MASTER.ALLOCATION_REMARKS,'') as ALLOCATION_REMARKS, case when TSPL_TICKET_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_TICKET_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_TICKET_MASTER.DEVELOPER_REMARKS,'') as DEVELOPER_REMARKS,isnull(TSPL_TICKET_MASTER.DEVELOPMENT_TIME,'') as DEVELOPMENT_TIME ,isnull(TSPL_TICKET_MASTER.TESTER_REMARKS,'') as TESTER_REMARKS,isnull(TSPL_TICKET_MASTER.TESTING_TIME,'') as TESTING_TIME ,isnull(TSPL_TICKET_MASTER.REQUEST_NO,'') as REQUEST_NO, case when TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE is null then '' else  convert (varchar,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) end as REQUEST_DATE, isnull(TSPL_TICKET_MASTER.ANALYSIS_NO,'') as ANALYSIS_NO ,case when TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE is null then '' else   convert (varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) end as  ANALYSIS_DATE, TSPL_TICKET_MASTER.Modify_By ,TSPL_TICKET_MASTER.Modify_Date ,isnull(TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION,'') as DEVELOPMENT_EXE_VERSION ,isnull(TSPL_TICKET_MASTER.TESTING_EXE_VERSION,'') as TESTING_EXE_VERSION, isnull( TSPL_TICKET_MASTER.ACTUAL_TESTING_TIME,'') as ACTUAL_TESTING_TIME from TSPL_TICKET_MASTER " & _
                            " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_TICKET_MASTER.CLIENT_CODE " & _
                            " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_TICKET_MASTER.SCREEN_CODE " & _
                            " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_TICKET_MASTER.MODULE_CODE " & _
                            " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_TICKET_MASTER.PROJECT_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_TICKET_MASTER.DEVELOPER_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_TICKET_MASTER.TESTER_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_TICKET_MASTER.Created_By " & _
                            " left outer join TSPL_REQUEST_ANALYSIS_MASTER on TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO = TSPL_TICKET_MASTER.ANALYSIS_NO " & _
                            " left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO =  TSPL_TICKET_MASTER.REQUEST_NO " & _
                            " where TSPL_TICKET_MASTER.TICKET_NO = '" + strCode + "'  "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsTicketMasterEntry
            obj.TICKET_NO = clsCommon.myCstr(dt.Rows(0)("TICKET_NO"))
            obj.TICKET_DATE = clsCommon.myCDate(dt.Rows(0)("TICKET_DATE"))
            obj.CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("CLIENT_CODE"))
            obj.CLIENT_NAME = clsCommon.myCstr(dt.Rows(0)("Client_Name"))
            obj.SCREEN_CODE = clsCommon.myCstr(dt.Rows(0)("SCREEN_CODE"))
            obj.SCREEN_NAME = clsCommon.myCstr(dt.Rows(0)("Screen_Name"))
            obj.MODULE_CODE = clsCommon.myCstr(dt.Rows(0)("MODULE_CODE"))
            obj.MODULE_NAME = clsCommon.myCstr(dt.Rows(0)("MODULE_NAME"))
            obj.PROJECT_CODE = clsCommon.myCstr(dt.Rows(0)("PROJECT_CODE"))
            obj.PROJECT_NAME = clsCommon.myCstr(dt.Rows(0)("PROJECT_NAME"))
            obj.TICKET_STATUS = clsCommon.myCstr(dt.Rows(0)("TICKET_STATUS"))
            obj.DEVELOPER_CODE = clsCommon.myCstr(dt.Rows(0)("DEVELOPER_CODE"))
            obj.DEVELOPER_NAME = clsCommon.myCstr(dt.Rows(0)("Developer_Name"))
            obj.TESTER_CODE = clsCommon.myCstr(dt.Rows(0)("TESTER_CODE"))
            obj.TESTER_NAME = clsCommon.myCstr(dt.Rows(0)("Tester_Name"))
            obj.Created_By = clsCommon.myCstr(dt.Rows(0)("Created_By_Code"))
            obj.Created_By_Name = clsCommon.myCstr(dt.Rows(0)("Created_By_Code"))
            obj.Created_Date = clsCommon.myCDate(dt.Rows(0)("Created_Date"))
            obj.Modify_By = clsCommon.myCstr(dt.Rows(0)("Modify_By"))
            obj.Modify_Date = clsCommon.myCDate(dt.Rows(0)("Modify_Date"))
            obj.TICKET_TYPE = clsCommon.myCstr(dt.Rows(0)("TICKET_TYPE"))
            obj.DATA_ERROR_TYPE = clsCommon.myCstr(dt.Rows(0)("DATA_ERROR_TYPE"))
            obj.SEVERITY = clsCommon.myCstr(dt.Rows(0)("SEVERITY"))
            obj.PRIORITY = clsCommon.myCstr(dt.Rows(0)("PRIORITY"))
            obj.TICKET_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("TICKET_DESCRIPTION"))
            obj.ALLOCATION_REMARKS = clsCommon.myCstr(dt.Rows(0)("ALLOCATION_REMARKS"))
            obj.ALLOCATED_TIME = clsCommon.myCstr(dt.Rows(0)("ALLOCATED_TIME"))
            obj.DEVELOPER_REMARKS = clsCommon.myCstr(dt.Rows(0)("DEVELOPER_REMARKS"))
            obj.DEVELOPMENT_TIME = clsCommon.myCstr(dt.Rows(0)("DEVELOPMENT_TIME"))
            obj.TESTER_REMARKS = clsCommon.myCstr(dt.Rows(0)("TESTER_REMARKS"))
            obj.TESTING_TIME = clsCommon.myCstr(dt.Rows(0)("TESTING_TIME"))
            obj.REQUEST_NO = clsCommon.myCstr(dt.Rows(0)("REQUEST_NO"))
            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("REQUEST_DATE"))) > 0 Then
                obj.REQUEST_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_DATE"))
            End If

            obj.ANALYSIS_NO = clsCommon.myCstr(dt.Rows(0)("ANALYSIS_NO"))

            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("ANALYSIS_DATE"))) > 0 Then
                obj.ANALYSIS_DATE = clsCommon.myCDate(dt.Rows(0)("ANALYSIS_DATE"))
            End If
            obj.DEVELOPMENT_EXE_VERSION = clsCommon.myCstr(dt.Rows(0)("DEVELOPMENT_EXE_VERSION"))
            obj.TESTING_EXE_VERSION = clsCommon.myCstr(dt.Rows(0)("TESTING_EXE_VERSION"))
            obj.ACTUAL_TESTING_TIME = clsCommon.myCstr(dt.Rows(0)("ACTUAL_TESTING_TIME"))
        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strTicketNo As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry1 As String = "delete from TSPL_TICKET_MASTER where TICKET_NO='" & strTicketNo & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Shared Function LoadTicketType() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "-Select-"
        dr("Name") = "-Select-"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Bug"
        dr("Name") = "Bug"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Change"
        dr("Name") = "Change"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "New Requirement"
        dr("Name") = "New Requirement"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Suggestion"
        dr("Name") = "Suggestion"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "Data Correction"
        dr("Name") = "Data Correction"
        dt.Rows.Add(dr)

        Return dt
    End Function

    Public Shared Function LoadDataErrorType() As DataTable
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
    Public Shared Function LoadSeverity() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Low"
        dr("Name") = "Low"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Medium"
        dr("Name") = "Medium"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "High"
        dr("Name") = "High"
        dt.Rows.Add(dr)
        Return dt
    End Function

    Public Shared Function LoadPriority() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Low"
        dr("Name") = "Low"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Medium"
        dr("Name") = "Medium"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "High"
        dr("Name") = "High"
        dt.Rows.Add(dr)
        Return dt
    End Function

    Public Shared Function LoadTicketStatus() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "-Select-"
        dr("Name") = "-Select-"
        dt.Rows.Add(dr)
        If clsCommon.CompairString(objCommonVar.CurrentUserType, "Developer") = CompairStringResult.Equal Then
            dr = dt.NewRow()
            dr("Code") = "Fixed"
            dr("Name") = "Fixed"
            dt.Rows.Add(dr)
            dr = dt.NewRow()
            dr("Code") = "WIP"
            dr("Name") = "WIP"
            dt.Rows.Add(dr)
        ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Tester") = CompairStringResult.Equal Or clsCommon.CompairString(objCommonVar.CurrentUserType, "Implementation") = CompairStringResult.Equal Then
            dr = dt.NewRow()
            dr("Code") = "Closed"
            dr("Name") = "Closed"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Code") = "Pending"
            dr("Name") = "Pending"
            dt.Rows.Add(dr)
        ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Management") = CompairStringResult.Equal Then
            'dr = dt.NewRow()
            'dr("Code") = "Open"
            'dr("Name") = "Open"
            'dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Code") = "Allocated"
            dr("Name") = "Allocated"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Code") = "On Hold"
            dr("Name") = "On Hold"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Code") = "Cancel"
            dr("Name") = "Cancel"
            dt.Rows.Add(dr)
        ElseIf clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
            dr = dt.NewRow()
            dr("Code") = "Approved"
            dr("Name") = "Approved"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Code") = "Not Approved"
            dr("Name") = "Not Approved"
            dt.Rows.Add(dr)

        End If
        Return dt
    End Function

End Class
