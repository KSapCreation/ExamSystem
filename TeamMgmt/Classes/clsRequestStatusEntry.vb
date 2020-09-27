Imports common
Imports System.Data.SqlClient
Public Class clsRequestStatusEntry
#Region "Variables"

    Public REQUEST_NO As String = Nothing
    Public REQUEST_DATE As Date? = Nothing
    Public REQUEST_STATUS As String = Nothing

    Public REQUEST_ANALYSIS_NO As String = Nothing
    Public REQUEST_ANALYSIS_DATE As Date? = Nothing
    Public APPROVED_TIME As String = Nothing



    Public CLIENT_CODE As String = Nothing
    Public CLIENT_NAME As String = Nothing
    Public SCREEN_CODE As String = Nothing
    Public SCREEN_NAME As String = Nothing
    Public MODULE_CODE As String = Nothing
    Public MODULE_NAME As String = Nothing
    Public PROJECT_CODE As String = Nothing
    Public PROJECT_NAME As String = Nothing
    Public Created_By As String = Nothing
    Public Created_By_Name As String = Nothing
    Public TICKET_TYPE As String = Nothing
    Public DATA_ERROR_TYPE As String = Nothing
    Public SEVERITY As String = Nothing
    Public PRIORITY As String = Nothing
    Public TICKET_NO As String = Nothing
    Public TICKET_STATUS As String = Nothing
    Public DEVELOPMENT_EXE_VERSION As String = Nothing
    Public TESTING_EXE_VERSION As String = Nothing
    Public PENDING_REMARKS As String = Nothing
    Public REQUEST_DESCRIPTION As String = Nothing
    Public ANALYSIS_DESCRIPTION As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_By_Name As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public REQUEST_COMPLETE_PENDING_BY_CODE As String = Nothing
    Public REQUEST_COMPLETE_PENDING_DATE As Date? = Nothing
    Public REQUEST_COMPLETE_PENDING_BY_NAME As String = Nothing


#End Region
    Public Function SaveData(ByVal obj As clsRequestStatusEntry, ByVal isNewEntry As Boolean) As Boolean
        Dim isSaved As Boolean = True
        Dim Trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            UpdateRequestStatus(obj, Trans)
            Trans.Commit()
        Catch err As Exception
            Trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    
    Public Function UpdateRequestStatus(ByVal obj As clsRequestStatusEntry, ByVal Trans As SqlTransaction) As Boolean
        Try
            'Dim coll As New Hashtable()

            'clsCommon.AddColumnsForChange(coll, "REQUEST_NO", obj.REQUEST_NO)
            'clsCommon.AddColumnsForChange(coll, "REQUEST_STATUS", obj.REQUEST_STATUS)
            'clsCommon.AddColumnsForChange(coll, "PENDING_REMARKS", obj.PENDING_REMARKS)
            'clsCommon.AddColumnsForChange(coll, "REQUEST_COMPLETE_PENDING_BY", objCommonVar.CurrentUserCode)
            'clsCommon.AddColumnsForChange(coll, "REQUEST_COMPLETE_PENDING_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            'clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            'clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            'clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_CREATION_MASTER", OMInsertOrUpdate.Update, "TSPL_REQUEST_CREATION_MASTER.REQUEST_NO='" + obj.REQUEST_NO + "'", Trans)


            'Dim objTicketMasterEntery As New clsTicketMasterEntry()
            'objTicketMasterEntery.TICKET_NO = obj.TICKET_NO
            'objTicketMasterEntery.TICKET_STATUS = "Complete"
            'objTicketMasterEntery.UpdateTicketStatus(objTicketMasterEntery, Trans)

            'Dim qry As String = " update TSPL_REQUEST_ANALYSIS_MASTER set ANALYSIS_STATUS = '" + obj.REQUEST_STATUS + "' and CLIENT_PENDING_REMARKS = '" + obj.PENDING_REMARKS + "'  and CLIENT_PENDING_REMARKS_DATE = '" + +"' where REQUEST_NO = '" + obj.REQUEST_NO + "' and REQUEST_ANALYSIS_NO = '" + obj.REQUEST_ANALYSIS_NO + "' "
            'clsDBFuncationality.ExecuteNonQuery(qry, Trans)

            'Dim strStatusForRequest As String = ""
            'If clsCommon.CompairString(obj.REQUEST_STATUS, "Pending") = CompairStringResult.Equal Then
            '    strStatusForRequest = "Open"
            'Else
            '    strStatusForRequest = obj.REQUEST_STATUS
            'End If
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "REQUEST_NO", obj.REQUEST_NO)
            clsCommon.AddColumnsForChange(coll, "REQUEST_STATUS", obj.REQUEST_STATUS)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_CREATION_MASTER", OMInsertOrUpdate.Update, "TSPL_REQUEST_CREATION_MASTER.REQUEST_NO='" + obj.REQUEST_NO + "'", Trans)


            Dim coll2 As New Hashtable()
            clsCommon.AddColumnsForChange(coll2, "ANALYSIS_STATUS", obj.REQUEST_STATUS)
            clsCommon.AddColumnsForChange(coll2, "CLIENT_PENDING_REMARKS", obj.PENDING_REMARKS)
            clsCommon.AddColumnsForChange(coll2, "REQUEST_COMPLETE_PENDING_BY", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll2, "REQUEST_COMPLETE_PENDING_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommon.AddColumnsForChange(coll2, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll2, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_REQUEST_ANALYSIS_MASTER", OMInsertOrUpdate.Update, "TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO='" + obj.REQUEST_NO + "' and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO='" + obj.REQUEST_ANALYSIS_NO + "' ", Trans)
            SaveEmailText(obj.REQUEST_NO, Trans)
            

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function

            
            
           

    Function SaveEmailText(ByVal DocNo As String, ByVal trans As SqlTransaction) As Boolean
        Dim obj As clsRequestStatusEntry = clsRequestStatusEntry.GetData(DocNo, trans)
        Dim objES As clsESContent = clsESContent.GetData(clsUserMgtCode.frmRequestStatus, trans)
        If obj IsNot Nothing AndAlso objES IsNot Nothing Then
            Dim objSMSH As New clsEMailHead()
            objSMSH.Email_Subject = objES.EMail_Subject
            objSMSH.Email_Text = objES.EMail_Text
            ' For Subject
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestStatus, obj.REQUEST_STATUS)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisNo, obj.REQUEST_ANALYSIS_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisDate, obj.REQUEST_ANALYSIS_DATE)

            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ScreenName, obj.SCREEN_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ProjectName, obj.PROJECT_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModuleName, obj.MODULE_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.CreatedBy, obj.Created_By_Name)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.CreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketType, obj.TICKET_TYPE)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Severity, obj.SEVERITY)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Priority, obj.PRIORITY)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketNo, obj.TICKET_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketStatus, obj.TICKET_STATUS)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DevelopmentVerstion, obj.DEVELOPMENT_EXE_VERSION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TestingVerstion, obj.TESTING_EXE_VERSION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.PendingRemarks, obj.PENDING_REMARKS)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDesc, obj.REQUEST_DESCRIPTION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisDesc, obj.ANALYSIS_DESCRIPTION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModifyBy, obj.Modify_By_Name)

            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestCompletePendingByCode, obj.REQUEST_COMPLETE_PENDING_BY_CODE)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestCompletePendingByName, obj.REQUEST_COMPLETE_PENDING_BY_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestCompletePendingDate, obj.REQUEST_COMPLETE_PENDING_DATE)

            ' For Body
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestStatus, obj.REQUEST_STATUS)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisNo, obj.REQUEST_ANALYSIS_NO)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisDate, obj.REQUEST_ANALYSIS_DATE)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ScreenName, obj.SCREEN_NAME)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ProjectName, obj.PROJECT_NAME)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModuleName, obj.MODULE_NAME)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.CreatedBy, obj.Created_By_Name)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.CreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketType, obj.TICKET_TYPE)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Severity, obj.SEVERITY)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Priority, obj.PRIORITY)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketNo, obj.TICKET_NO)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketStatus, obj.TICKET_STATUS)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DevelopmentVerstion, obj.DEVELOPMENT_EXE_VERSION)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TestingVerstion, obj.TESTING_EXE_VERSION)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.PendingRemarks, obj.PENDING_REMARKS)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDesc, obj.REQUEST_DESCRIPTION)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisDesc, obj.ANALYSIS_DESCRIPTION)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModifyBy, obj.Modify_By_Name)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestCompletePendingByCode, obj.REQUEST_COMPLETE_PENDING_BY_CODE)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestCompletePendingByName, obj.REQUEST_COMPLETE_PENDING_BY_NAME)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestCompletePendingDate, obj.REQUEST_COMPLETE_PENDING_DATE)

            objSMSH.arrEMail = New List(Of String)()


            Dim qry As String = " select PERSON_EMAIL from TSPL_CLIENT_DETAIL where len(isnull( PERSON_EMAIL,''))>0 and IS_SEND_MAIL=1  and CLIENT_CODE = (Select isnull(CLIENT_CODE,'') as CLIENT_CODE  from TSPL_USER_MASTER where USER_CODE ='" + objCommonVar.CurrentUserCode + "')"
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




    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsRequestStatusEntry
        Dim obj As clsRequestStatusEntry = Nothing
        Dim qry As String = " select TSPL_TICKET_MASTER.TICKET_STATUS, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,convert(varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) as REQUEST_ANALYSIS_DATE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_STATUS,'') as ANALYSIS_STATUS ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_REQUEST_CREATION_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name,isnull(TSPL_REQUEST_CREATION_MASTER.Modify_By,'') as Modify_By_Code,   isnull(TBL_USER_MASTER_Modify_By.USER_NAME,'') as Modify_By_Name       ,isnull( TSPL_REQUEST_ANALYSIS_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_REQUEST_ANALYSIS_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_REQUEST_ANALYSIS_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_DESCRIPTION,'') as ANALYSIS_DESCRIPTION , case when TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTING_TIME,'') as TESTING_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO,'') as REQUEST_NO,  isnull(TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO,'') as TICKET_NO ,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION ,convert (varchar, convert (date, TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103),103) as REQUEST_DATE ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_TIME,'')as APPROVED_TIME,TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED,case when TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED_DATE is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED_DATE,103) end as IS_Mgmt_APPROVED_DATE  ,TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED,case when TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED_DATE is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED_DATE ,103) end as IS_CLIENT_APPROVED_DATE,TSPL_REQUEST_ANALYSIS_MASTER.Modify_Date,TSPL_REQUEST_ANALYSIS_MASTER.Created_Date,isnull(TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION,'') as DEVELOPMENT_EXE_VERSION,isnull(TSPL_TICKET_MASTER.TESTING_EXE_VERSION,'') as TESTING_EXE_VERSION , isnull( TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_PENDING_REMARKS,'') as CLIENT_PENDING_REMARKS,isNull(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_COMPLETE_PENDING_BY,'') as REQUEST_COMPLETE_PENDING_BY_CODE, case when TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_COMPLETE_PENDING_DATE is null then '' else convert(varchar,TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_COMPLETE_PENDING_DATE ,103) end as REQUEST_COMPLETE_PENDING_DATE , isnull(TBL_USER_MASTER_REQUEST_COMPLETE_PENDING_BY.USER_NAME,'') as REQUEST_COMPLETE_PENDING_BY_NAME,TSPL_REQUEST_CREATION_MASTER.REQUEST_STATUS from TSPL_REQUEST_ANALYSIS_MASTER " & _
                            " left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO " & _
                            " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE " & _
                            " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE " & _
                            " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE " & _
                            " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.PROJECT_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE " & _
                            " left outer join TSPL_TICKET_MASTER on TSPL_TICKET_MASTER.TICKET_NO = TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO  " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Created_By " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Modify_By on TBL_USER_MASTER_Modify_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Modify_By " & _
                            " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_REQUEST_COMPLETE_PENDING_BY on TBL_USER_MASTER_REQUEST_COMPLETE_PENDING_BY.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_COMPLETE_PENDING_BY " & _
                            "  where TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = '" + strCode + "'  "
        'REQUEST_COMPLETE_PENDING_BY
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsRequestStatusEntry
            obj.REQUEST_ANALYSIS_NO = clsCommon.myCstr(dt.Rows(0)("REQUEST_ANALYSIS_NO"))
            obj.REQUEST_ANALYSIS_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_ANALYSIS_DATE"))
            obj.REQUEST_NO = clsCommon.myCstr(dt.Rows(0)("REQUEST_NO"))
            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("REQUEST_DATE"))) > 0 Then
                obj.REQUEST_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_DATE"))
            End If
            obj.REQUEST_STATUS = clsCommon.myCstr(dt.Rows(0)("REQUEST_STATUS"))
            obj.REQUEST_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("REQUEST_DESCRIPTION"))
            obj.CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("CLIENT_CODE"))
            obj.CLIENT_NAME = clsCommon.myCstr(dt.Rows(0)("Client_Name"))
            obj.SCREEN_CODE = clsCommon.myCstr(dt.Rows(0)("SCREEN_CODE"))
            obj.SCREEN_NAME = clsCommon.myCstr(dt.Rows(0)("Screen_Name"))
            obj.MODULE_CODE = clsCommon.myCstr(dt.Rows(0)("MODULE_CODE"))
            obj.MODULE_NAME = clsCommon.myCstr(dt.Rows(0)("MODULE_NAME"))
            obj.PROJECT_CODE = clsCommon.myCstr(dt.Rows(0)("PROJECT_CODE"))
            obj.PROJECT_NAME = clsCommon.myCstr(dt.Rows(0)("PROJECT_NAME"))
            
            obj.Created_By = clsCommon.myCstr(dt.Rows(0)("Created_By_Code"))
            obj.Created_By_Name = clsCommon.myCstr(dt.Rows(0)("Created_By_Name"))

            obj.Modify_By = clsCommon.myCstr(dt.Rows(0)("Modify_By_Code"))
            obj.Modify_By_Name = clsCommon.myCstr(dt.Rows(0)("Modify_By_Name"))
            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("Modify_Date"))) > 0 Then
                obj.Modify_Date = clsCommon.myCDate(dt.Rows(0)("Modify_Date"))
            End If
            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("Created_Date"))) > 0 Then
                obj.Created_Date = clsCommon.myCDate(dt.Rows(0)("Created_Date"))
            End If
            obj.TICKET_TYPE = clsCommon.myCstr(dt.Rows(0)("TICKET_TYPE"))
            obj.DATA_ERROR_TYPE = clsCommon.myCstr(dt.Rows(0)("DATA_ERROR_TYPE"))
            obj.SEVERITY = clsCommon.myCstr(dt.Rows(0)("SEVERITY"))
            obj.PRIORITY = clsCommon.myCstr(dt.Rows(0)("PRIORITY"))
            obj.ANALYSIS_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("ANALYSIS_DESCRIPTION"))
            obj.TICKET_NO = clsCommon.myCstr(dt.Rows(0)("TICKET_NO"))
            obj.TICKET_STATUS = clsCommon.myCstr(dt.Rows(0)("TICKET_STATUS"))
            obj.PENDING_REMARKS = clsCommon.myCstr(dt.Rows(0)("CLIENT_PENDING_REMARKS"))
            obj.DEVELOPMENT_EXE_VERSION = clsCommon.myCstr(dt.Rows(0)("DEVELOPMENT_EXE_VERSION"))
            obj.TESTING_EXE_VERSION = clsCommon.myCstr(dt.Rows(0)("TESTING_EXE_VERSION"))

            obj.REQUEST_COMPLETE_PENDING_BY_CODE = clsCommon.myCstr(dt.Rows(0)("REQUEST_COMPLETE_PENDING_BY_CODE"))
            obj.REQUEST_COMPLETE_PENDING_BY_NAME = clsCommon.myCstr(dt.Rows(0)("REQUEST_COMPLETE_PENDING_BY_NAME"))
            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("REQUEST_COMPLETE_PENDING_DATE"))) > 0 Then
                obj.REQUEST_COMPLETE_PENDING_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_COMPLETE_PENDING_DATE"))
            End If
          
        End If
        Return obj
    End Function



End Class
