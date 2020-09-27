Imports common
Imports System.Data.SqlClient
Public Class clsRequestAnalysisEnry
#Region "Variables"

    Public REQUEST_ANALYSIS_NO As String = Nothing
    Public REQUEST_ANALYSIS_DATE As Date? = Nothing
    Public REQUEST_NO As String = Nothing
    Public REQUEST_DESCRIPTION As String = Nothing
    Public REQUEST_DATE As Date? = Nothing
    Public CLIENT_CODE As String = Nothing
    Public CLIENT_NAME As String = Nothing
    Public SCREEN_CODE As String = Nothing
    Public SCREEN_NAME As String = Nothing
    Public MODULE_CODE As String = Nothing
    Public MODULE_NAME As String = Nothing
    Public PROJECT_CODE As String = Nothing
    Public PROJECT_NAME As String = Nothing
    Public ANALYSIS_STATUS As String = Nothing
    Public DEVELOPER_CODE As String = Nothing
    Public DEVELOPER_NAME As String = Nothing
    Public TESTER_CODE As String = Nothing
    Public TESTER_NAME As String = Nothing
    Public TICKET_TYPE As String = Nothing
    Public DATA_ERROR_TYPE As String = Nothing
    Public SEVERITY As String = Nothing
    Public PRIORITY As String = Nothing
    Public ANALYSIS_DESCRIPTION As String = Nothing
    Public TICKET_NO As String = Nothing
    Public ALLOCATED_TIME As String = Nothing
    Public TESTING_TIME As String = Nothing
    Public Created_By As String = Nothing
    Public Created_By_Name As String = Nothing

    Public Analysis_By As String = Nothing
    Public Analysis_By_Name As String = Nothing

    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public APPROVED_TIME As String = Nothing
    Public IS_Mgmt_APPROVED As Integer = 0
    Public IS_Mgmt_APPROVED_DATE As Date? = Nothing
    Public IS_CLIENT_APPROVED As Integer = 0
    Public IS_CLIENT_APPROVED_DATE As Date? = Nothing
    Public Form_Title_Name As String = ""
    Public TOTAL_TIME As String = Nothing
    Public APPROVAL_STATUS As String = Nothing
    Public APPROVED_BY_MGMT_NAME As String = Nothing
    Public APPROVED_BY_MGMT_CODE As String = Nothing
    Public APPROVED_BY_CLIENT_NAME As String = Nothing
    Public APPROVED_BY_CLIENT_CODE As String = Nothing
#End Region
    Public Function SaveData(ByVal obj As clsRequestAnalysisEnry, ByVal isNewEntry As Boolean) As Boolean

        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try

            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "REQUEST_NO", obj.REQUEST_NO)
            clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", obj.CLIENT_CODE)
            clsCommon.AddColumnsForChange(coll, "SCREEN_CODE", obj.SCREEN_CODE)
            clsCommon.AddColumnsForChange(coll, "MODULE_CODE", obj.MODULE_CODE)
            clsCommon.AddColumnsForChange(coll, "PROJECT_CODE", obj.PROJECT_CODE)
            clsCommon.AddColumnsForChange(coll, "ANALYSIS_STATUS", obj.ANALYSIS_STATUS)
            clsCommon.AddColumnsForChange(coll, "DEVELOPER_CODE", obj.DEVELOPER_CODE, True)
            clsCommon.AddColumnsForChange(coll, "TESTER_CODE", obj.TESTER_CODE, True)
            clsCommon.AddColumnsForChange(coll, "TICKET_TYPE", obj.TICKET_TYPE)
            clsCommon.AddColumnsForChange(coll, "DATA_ERROR_TYPE", obj.DATA_ERROR_TYPE)
            clsCommon.AddColumnsForChange(coll, "SEVERITY", obj.SEVERITY)
            clsCommon.AddColumnsForChange(coll, "PRIORITY", obj.PRIORITY)
            clsCommon.AddColumnsForChange(coll, "ANALYSIS_DESCRIPTION", obj.ANALYSIS_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "ALLOCATED_TIME", obj.ALLOCATED_TIME)
            clsCommon.AddColumnsForChange(coll, "TESTING_TIME", obj.TESTING_TIME)
            clsCommon.AddColumnsForChange(coll, "TOTAL_TIME", obj.TOTAL_TIME)
            clsCommon.AddColumnsForChange(coll, "TICKET_NO", obj.TICKET_NO, True)
            clsCommon.AddColumnsForChange(coll, "APPROVED_TIME", obj.APPROVED_TIME)
            clsCommon.AddColumnsForChange(coll, "IS_Mgmt_APPROVED", obj.IS_Mgmt_APPROVED)
            clsCommon.AddColumnsForChange(coll, "APPROVAL_STATUS", obj.APPROVAL_STATUS)
            If obj.IS_Mgmt_APPROVED = 1 AndAlso obj.IS_CLIENT_APPROVED = 0 Then
                clsCommon.AddColumnsForChange(coll, "IS_Mgmt_APPROVED_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"), True)
                clsCommon.AddColumnsForChange(coll, "APPROVED_BY_MGMT", objCommonVar.CurrentUserCode)
            End If
            clsCommon.AddColumnsForChange(coll, "IS_CLIENT_APPROVED", obj.IS_CLIENT_APPROVED)
            If obj.IS_CLIENT_APPROVED = 1 Then
                clsCommon.AddColumnsForChange(coll, "IS_CLIENT_APPROVED_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"), True)
                clsCommon.AddColumnsForChange(coll, "APPROVED_BY_CLIENT", objCommonVar.CurrentUserCode)
            End If

            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "REQUEST_ANALYSIS_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                obj.REQUEST_ANALYSIS_NO = GetnrateReqAnalysisNo(obj.CLIENT_CODE, trans)
                If clsCommon.myLen(obj.REQUEST_ANALYSIS_NO) > 0 Then
                    clsCommon.AddColumnsForChange(coll, "REQUEST_ANALYSIS_NO", obj.REQUEST_ANALYSIS_NO)
                End If

                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_ANALYSIS_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_ANALYSIS_MASTER", OMInsertOrUpdate.Update, "TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO='" + obj.REQUEST_ANALYSIS_NO + "'", trans)
            End If
            'Dim qry As String = " update TSPL_REQUEST_CREATION_MASTER set REQUEST_STATUS = 'Analysed' where REQUEST_NO = '" + obj.REQUEST_NO + "' "
            Dim qry As String = " update TSPL_REQUEST_CREATION_MASTER set REQUEST_STATUS = '" + obj.ANALYSIS_STATUS + "' where REQUEST_NO = '" + obj.REQUEST_NO + "' "
            isSaved = clsDBFuncationality.ExecuteNonQuery(qry, trans)
            If clsCommon.CompairString(obj.ANALYSIS_STATUS, "Analysed") = CompairStringResult.Equal Then

                If clsCommon.CompairString(obj.TICKET_TYPE, "Bug") = CompairStringResult.Equal Or (clsCommon.CompairString(obj.TICKET_TYPE, "Data Correction") = CompairStringResult.Equal AndAlso clsCommon.CompairString(obj.TICKET_TYPE, "Internal") = CompairStringResult.Equal) Or (obj.IS_CLIENT_APPROVED = 1) Then

                    Dim objTicket As New clsTicketMasterEntry()
                    objTicket.TICKET_NO = obj.TICKET_NO
                    objTicket.CLIENT_CODE = obj.CLIENT_CODE
                    objTicket.SCREEN_CODE = obj.SCREEN_CODE
                    objTicket.MODULE_CODE = obj.MODULE_CODE
                    objTicket.PROJECT_CODE = obj.PROJECT_CODE

                    If clsCommon.myLen(obj.DEVELOPER_CODE) > 0 AndAlso clsCommon.myLen(obj.TESTER_CODE) > 0 Then
                        objTicket.TICKET_STATUS = "Allocated"
                        objTicket.DEVELOPER_CODE = obj.DEVELOPER_CODE
                        objTicket.TESTER_CODE = obj.TESTER_CODE
                        objTicket.ALLOCATED_TIME = obj.ALLOCATED_TIME
                        objTicket.TESTING_TIME = obj.TESTING_TIME

                    Else
                        objTicket.TICKET_STATUS = "Open"
                    End If
                    objTicket.TICKET_TYPE = obj.TICKET_TYPE
                    objTicket.DATA_ERROR_TYPE = obj.DATA_ERROR_TYPE
                    objTicket.SEVERITY = obj.SEVERITY
                    objTicket.PRIORITY = obj.PRIORITY
                    objTicket.TICKET_DESCRIPTION = obj.REQUEST_DESCRIPTION
                    objTicket.ALLOCATION_REMARKS = obj.ANALYSIS_DESCRIPTION
                    objTicket.REQUEST_NO = obj.REQUEST_NO
                    objTicket.ANALYSIS_NO = obj.REQUEST_ANALYSIS_NO
                    Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_TICKET_MASTER where TICKET_NO='" & objTicket.TICKET_NO & "'", trans)
                    If ChkNewEntry > 0 Then
                        isNewEntry = False
                    Else
                        isNewEntry = True
                    End If
                    isSaved = objTicket.SaveData(objTicket, isNewEntry, trans)
                    qry = "update TSPL_REQUEST_ANALYSIS_MASTER set TICKET_NO = '" + objTicket.TICKET_NO + "' where REQUEST_ANALYSIS_NO = '" + obj.REQUEST_ANALYSIS_NO + "' "
                    isSaved = clsDBFuncationality.ExecuteNonQuery(qry, trans)
                End If
            End If
            SaveEmailText(obj.REQUEST_ANALYSIS_NO, trans)
            If isSaved Then
                trans.Commit()
            End If
        Catch err As Exception
            trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function

    Function SaveEmailText(ByVal DocNo As String, ByVal trans As SqlTransaction) As Boolean
        Dim obj As clsRequestAnalysisEnry = clsRequestAnalysisEnry.GetData(DocNo, trans)
        Dim objES As clsESContent
        If clsCommon.CompairString(Form_Title_Name, "Request Approval") = CompairStringResult.Equal Then
            objES = clsESContent.GetData(clsUserMgtCode.frmRequestApproval, trans)
        Else
            objES = clsESContent.GetData(clsUserMgtCode.frmRequestAnalysis, trans)
        End If

        If obj IsNot Nothing AndAlso objES IsNot Nothing Then
            Dim objSMSH As New clsEMailHead()
            objSMSH.Email_Subject = objES.EMail_Subject
            objSMSH.Email_Text = objES.EMail_Text

            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DocumentNo, obj.REQUEST_ANALYSIS_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.DocumentDate, clsCommon.GetPrintDate(obj.REQUEST_ANALYSIS_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Status, obj.ANALYSIS_STATUS)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.CreatedBy, obj.Created_By_Name)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.CreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModifyBy, obj.Modify_By)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ModifyDate, clsCommon.GetPrintDate(obj.Modify_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Description, obj.ANALYSIS_DESCRIPTION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDesc, obj.REQUEST_DESCRIPTION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.TicketType, obj.TICKET_TYPE)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.AnalysisBy, obj.Analysis_By_Name)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DocumentNo, obj.REQUEST_ANALYSIS_NO)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.DocumentDate, clsCommon.GetPrintDate(obj.REQUEST_ANALYSIS_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Status, obj.ANALYSIS_STATUS)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.CreatedBy, obj.Created_By_Name)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.CreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModifyBy, obj.Modify_By)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ModifyDate, clsCommon.GetPrintDate(obj.Modify_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Description, obj.ANALYSIS_DESCRIPTION)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDesc, obj.REQUEST_DESCRIPTION)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.TicketType, obj.TICKET_TYPE)
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.AnalysisBy, obj.Analysis_By_Name)


            If clsCommon.CompairString(Form_Title_Name, "Request Approval") = CompairStringResult.Equal Then

                'If clsCommon.myLen(obj.IS_Mgmt_APPROVED) > 0 Then
                '    If clsCommon.CompairString(obj.IS_Mgmt_APPROVED, "1") = CompairStringResult.Equal Then
                '        objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ManagmentApprovedStatus, "Approved")
                '        If clsCommon.myLen(obj.IS_Mgmt_APPROVED_DATE) > 0 Then
                '            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ManagmentApprovedDate, clsCommon.GetPrintDate(obj.IS_Mgmt_APPROVED_DATE, "dd/MMM/yyyy"))
                '        End If

                '    Else
                '        objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ManagmentApprovedStatus, "Not Approved")
                '        objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ManagmentApprovedDate, "NA")
                '    End If
                'End If

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

                If clsCommon.CompairString(objCommonVar.CurrentUserType, "Other") = CompairStringResult.Equal Then
                    If clsCommon.myLen(obj.IS_CLIENT_APPROVED) > 0 Then
                        If clsCommon.CompairString(obj.IS_CLIENT_APPROVED, "1") = CompairStringResult.Equal Then
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "Approved")
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, obj.APPROVED_BY_CLIENT_NAME)

                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "Approved")
                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, obj.APPROVED_BY_CLIENT_NAME)

                            If clsCommon.myLen(obj.IS_CLIENT_APPROVED_DATE) > 0 Then
                                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, clsCommon.GetPrintDate(obj.IS_CLIENT_APPROVED_DATE, "dd/MMM/yyyy"))

                                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, clsCommon.GetPrintDate(obj.IS_CLIENT_APPROVED_DATE, "dd/MMM/yyyy"))
                            End If
                        Else
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, " Not Approved")
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, "NA")
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, "NA")

                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "NA")
                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, obj.APPROVED_BY_CLIENT_NAME)
                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, "NA")


                        End If
                    End If
                Else
                    If clsCommon.myLen(obj.IS_Mgmt_APPROVED) > 0 Then
                        If clsCommon.CompairString(obj.IS_Mgmt_APPROVED, "1") = CompairStringResult.Equal Then
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "Approved")
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, obj.APPROVED_BY_MGMT_NAME)

                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "Approved")
                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, obj.APPROVED_BY_MGMT_NAME)

                            If clsCommon.myLen(obj.IS_Mgmt_APPROVED_DATE) > 0 Then
                                objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, clsCommon.GetPrintDate(obj.IS_Mgmt_APPROVED_DATE, "dd/MMM/yyyy"))

                                objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, clsCommon.GetPrintDate(obj.IS_Mgmt_APPROVED_DATE, "dd/MMM/yyyy"))
                            End If
                        Else
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "Not Approved")
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, "NA")
                            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, "NA")

                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalStatus, "Not Approved")
                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalBy, "NA")
                            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.ClientMangmentApprovalDate, "NA")
                        End If
                    End If


                End If
            End If

            objSMSH.arrEMail = New List(Of String)()

            Dim qry As String = "select PERSON_EMAIL from TSPL_CLIENT_DETAIL where len(isnull( PERSON_EMAIL,''))>0 and IS_SEND_MAIL=1 and CLIENT_CODE = '" + obj.CLIENT_CODE + "' "
            qry += "Union "
            qry += " select TSPL_USER_MASTER.EMAIL as PERSON_EMAIL from TSPL_USER_MASTER where len(isnull( TSPL_USER_MASTER.EMAIL,''))>0 and TSPL_USER_MASTER.USER_CODE in (  select TSPL_MAPPING_USER_DETAIL.MAPPING_USER_CODE from TSPL_MAPPING_USER_DETAIL inner join TSPL_USER_MASTER on TSPL_USER_MASTER.USER_CODE =TSPL_MAPPING_USER_DETAIL.USER_CODE where  TSPL_MAPPING_USER_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "' ) "
            If clsCommon.myLen(obj.DEVELOPER_CODE) > 0 Then
                qry += "Union "
                qry += "select TSPL_USER_MASTER.EMAIL as PERSON_EMAIL from TSPL_REQUEST_ANALYSIS_MASTER inner join TSPL_USER_MASTER on TSPL_USER_MASTER.USER_CODE = TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE where len(isnull( TSPL_USER_MASTER.EMAIL,''))>0 and TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE = '" + obj.DEVELOPER_CODE + "' and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO = '" + obj.REQUEST_ANALYSIS_NO + "'  "
            End If
            If clsCommon.myLen(obj.TESTER_CODE) > 0 Then
                qry += "Union "
                qry += " select TSPL_USER_MASTER.EMAIL as PERSON_EMAIL from TSPL_REQUEST_ANALYSIS_MASTER inner join TSPL_USER_MASTER on TSPL_USER_MASTER.USER_CODE = TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE where len(isnull( TSPL_USER_MASTER.EMAIL,''))>0 and TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE = '" + obj.TESTER_CODE + "'  and TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO = '" + obj.REQUEST_ANALYSIS_NO + "' "
            End If
            'If clsCommon.CompairString(obj.TICKET_TYPE, "Open") <> CompairStringResult.Equal Then

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



    Public Shared Function GetnrateReqAnalysisNo(ByVal strClientCode As String, ByVal Trans As SqlTransaction) As String
        Dim strRequestAnalysisNo As String = ""
        Try
            Dim sno As String = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select case when len ( max( convert ( int, RIGHT(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,LEN(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO)-CHARINDEX('-',TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO)) )) ) is null then '1' else max( convert ( int, RIGHT(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,LEN(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO)-CHARINDEX('-',TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO)) )) end from TSPL_REQUEST_ANALYSIS_MASTER where  TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE = '" + strClientCode + "'", Trans))
            Dim strReqAnalysis As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select ISNULL( right('000000' + convert(varchar(20), " + sno + "+1), 6),0) from TSPL_REQUEST_ANALYSIS_MASTER where TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE = '" + strClientCode + "'  ", Trans))
            If clsCommon.myLen(strReqAnalysis) <= 0 Then
                strReqAnalysis = "000001"
            End If
            strRequestAnalysisNo = "RA/" + strClientCode.Substring(0, 3) + "/" + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MM/yy") + "-" + strReqAnalysis
        Catch ex As Exception
        End Try
        Return strRequestAnalysisNo
    End Function

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsRequestAnalysisEnry
        Dim obj As clsRequestAnalysisEnry = Nothing

        Dim qry As String = " select TSPL_TICKET_MASTER.TICKET_STATUS, isnull(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO,'') as REQUEST_NO,case when TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE is null then '' else  convert (varchar,TSPL_REQUEST_CREATION_MASTER.REQUEST_DATE,103) end as REQUEST_DATE, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,convert(varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) as REQUEST_ANALYSIS_DATE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_STATUS,'') as ANALYSIS_STATUS ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_REQUEST_CREATION_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.Created_By,'') as Analaysis_By_Code  ,isnull(TBL_USER_MASTER_Analysis_By.USER_NAME,'') as Analysis_By_Name     ,isnull( TSPL_REQUEST_ANALYSIS_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_REQUEST_ANALYSIS_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_REQUEST_ANALYSIS_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_DESCRIPTION,'') as ANALYSIS_DESCRIPTION , case when TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTING_TIME,'') as TESTING_TIME ,  isnull(TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO,'') as TICKET_NO ,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION ,'' as PENDING_REMARKS, '-Select-' as Request_Status,TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION,TSPL_TICKET_MASTER.TESTING_EXE_VERSION,TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_PENDING_REMARKS,TSPL_REQUEST_ANALYSIS_MASTER.Modify_By ,TSPL_REQUEST_ANALYSIS_MASTER.Modify_Date,TSPL_REQUEST_ANALYSIS_MASTER.Created_Date,TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_TIME,TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED,case when TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED_DATE is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED_DATE,103) end as IS_Mgmt_APPROVED_DATE  ,TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED,case when TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED_DATE is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED_DATE ,103) end as IS_CLIENT_APPROVED_DATE, isnull(TSPL_REQUEST_ANALYSIS_MASTER.TOTAL_TIME,'') as TOTAL_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.APPROVAL_STATUS,'') as APPROVAL_STATUS,isnull (TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_BY_CLIENT,'') as APPROVED_BY_CLIENT_CODE, isnull(TBL_USER_MASTER_APPROVED_BY_CLIENT.USER_NAME,'') as APPROVED_BY_CLIENT_NAME  ,isnull (TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_BY_MGMT ,'') as APPROVED_BY_MGMT_CODE ,isnull(TBL_USER_MASTER_APPROVED_BY_MGMT.USER_NAME,'') as APPROVED_BY_MGMT_NAME      from TSPL_REQUEST_ANALYSIS_MASTER   " & _
                                " left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO    " & _
                                " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE    " & _
                                " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE   " & _
                                " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE   " & _
                                " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.PROJECT_CODE " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE  " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE  " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_CREATION_MASTER.Created_By   " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Analysis_By on TBL_USER_MASTER_Analysis_By.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.Created_By   " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_APPROVED_BY_MGMT on TBL_USER_MASTER_APPROVED_BY_MGMT.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_BY_MGMT   " & _
                                " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_APPROVED_BY_CLIENT on TBL_USER_MASTER_APPROVED_BY_CLIENT.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_BY_CLIENT   " & _
                                " left outer join TSPL_TICKET_MASTER on TSPL_TICKET_MASTER.TICKET_NO = TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO  " & _
                                "  where TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO = '" + strCode + "'  "

        'Dim qry As String = " select TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO,convert(varchar, TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_DATE,103) as REQUEST_ANALYSIS_DATE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE,'') as CLIENT_CODE ,isnull(TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION,'') as Client_Name,isNull(TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE,'') as SCREEN_CODE,isnull(TSPL_SCREEN_MASTER.SCREEN_DESCRIPTION,'') as Screen_Name, isnull(TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE,'') as MODULE_CODE,isnull(TSPL_MODULE_MASTER.MODULE_DESCRIPTION,'') as MODULE_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER .PROJECT_CODE,'') as PROJECT_CODE,isnull(TSPL_PROJECT_MASTER.PROJECT_DESCRIPTION,'') as PROJECT_NAME,isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_STATUS,'') as ANALYSIS_STATUS ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE,'') as DEVELOPER_CODE ,isnull(TBL_USER_MASTER_Developer.USER_NAME,'') as Developer_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE,'') as TESTER_CODE,isnull(TBL_USER_MASTER_Tester.USER_NAME,'') as Tester_Name,isnull(TSPL_REQUEST_ANALYSIS_MASTER.Created_By,'') as Created_By_Code,isnull(TBL_USER_MASTER_Created_By.USER_NAME,'') as Created_By_Name,isnull( TSPL_REQUEST_ANALYSIS_MASTER.TICKET_TYPE,'') as TICKET_TYPE,isnull(TSPL_REQUEST_ANALYSIS_MASTER.DATA_ERROR_TYPE,'') as DATA_ERROR_TYPE, isnull(TSPL_REQUEST_ANALYSIS_MASTER.SEVERITY ,'') as SEVERITY, isnull(TSPL_REQUEST_ANALYSIS_MASTER.PRIORITY,'') as [PRIORITY],isnull(TSPL_REQUEST_ANALYSIS_MASTER.ANALYSIS_DESCRIPTION,'') as ANALYSIS_DESCRIPTION , case when TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.ALLOCATED_TIME,103)  end as ALLOCATED_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.TESTING_TIME,'') as TESTING_TIME ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO,'') as REQUEST_NO,  isnull(TSPL_REQUEST_ANALYSIS_MASTER.TICKET_NO,'') as TICKET_NO ,isnull(TSPL_REQUEST_CREATION_MASTER.REQUEST_DESCRIPTION,'') as REQUEST_DESCRIPTION ,convert (varchar, convert (date, REQUEST_DATE,103),103) as REQUEST_DATE ,isnull(TSPL_REQUEST_ANALYSIS_MASTER.APPROVED_TIME,'')as APPROVED_TIME,TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED,case when TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED_DATE is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.IS_Mgmt_APPROVED_DATE,103) end as IS_Mgmt_APPROVED_DATE  ,TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED,case when TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED_DATE is null then '' else convert (varchar,TSPL_REQUEST_ANALYSIS_MASTER.IS_CLIENT_APPROVED_DATE ,103) end as IS_CLIENT_APPROVED_DATE,TSPL_REQUEST_ANALYSIS_MASTER.Modify_By ,TSPL_REQUEST_ANALYSIS_MASTER.Modify_Date,TSPL_REQUEST_ANALYSIS_MASTER.Created_Date,TSPL_TICKET_MASTER.DEVELOPMENT_EXE_VERSION,TSPL_TICKET_MASTER.TESTING_EXE_VERSION, TSPL_REQUEST_CREATION_MASTER.PENDING_REMARKS from TSPL_REQUEST_ANALYSIS_MASTER " & _
        '                    " left outer join TSPL_REQUEST_CREATION_MASTER on TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_NO " & _
        '                    " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.CLIENT_CODE " & _
        '                    " left outer join TSPL_SCREEN_MASTER on TSPL_SCREEN_MASTER.SCREEN_CODE = TSPL_REQUEST_ANALYSIS_MASTER.SCREEN_CODE " & _
        '                    " left outer join TSPL_MODULE_MASTER on TSPL_MODULE_MASTER.MODULE_CODE = TSPL_REQUEST_ANALYSIS_MASTER.MODULE_CODE " & _
        '                    " left outer join TSPL_PROJECT_MASTER on TSPL_PROJECT_MASTER.PROJECT_CODE =TSPL_REQUEST_ANALYSIS_MASTER.PROJECT_CODE " & _
        '                    " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Developer on TBL_USER_MASTER_Developer.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.DEVELOPER_CODE " & _
        '                    " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Tester on TBL_USER_MASTER_Tester.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.TESTER_CODE " & _
        '                    " left outer join TSPL_USER_MASTER as TBL_USER_MASTER_Created_By on TBL_USER_MASTER_Created_By.USER_CODE =TSPL_REQUEST_ANALYSIS_MASTER.Created_By where TSPL_REQUEST_ANALYSIS_MASTER.REQUEST_ANALYSIS_NO = '" + strCode + "'  "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsRequestAnalysisEnry
            obj.REQUEST_ANALYSIS_NO = clsCommon.myCstr(dt.Rows(0)("REQUEST_ANALYSIS_NO"))
            obj.REQUEST_ANALYSIS_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_ANALYSIS_DATE"))
            obj.REQUEST_NO = clsCommon.myCstr(dt.Rows(0)("REQUEST_NO"))
            If clsCommon.myLen(clsCommon.myCstr(dt.Rows(0)("REQUEST_DATE"))) > 0 Then
                obj.REQUEST_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_DATE"))
            End If
            obj.REQUEST_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("REQUEST_DESCRIPTION"))
            obj.CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("CLIENT_CODE"))
            obj.CLIENT_NAME = clsCommon.myCstr(dt.Rows(0)("Client_Name"))
            obj.SCREEN_CODE = clsCommon.myCstr(dt.Rows(0)("SCREEN_CODE"))
            obj.SCREEN_NAME = clsCommon.myCstr(dt.Rows(0)("Screen_Name"))
            obj.MODULE_CODE = clsCommon.myCstr(dt.Rows(0)("MODULE_CODE"))
            obj.MODULE_NAME = clsCommon.myCstr(dt.Rows(0)("MODULE_NAME"))
            obj.PROJECT_CODE = clsCommon.myCstr(dt.Rows(0)("PROJECT_CODE"))
            obj.PROJECT_NAME = clsCommon.myCstr(dt.Rows(0)("PROJECT_NAME"))
            obj.ANALYSIS_STATUS = clsCommon.myCstr(dt.Rows(0)("ANALYSIS_STATUS"))
            obj.DEVELOPER_CODE = clsCommon.myCstr(dt.Rows(0)("DEVELOPER_CODE"))
            obj.DEVELOPER_NAME = clsCommon.myCstr(dt.Rows(0)("Developer_Name"))
            obj.TESTER_CODE = clsCommon.myCstr(dt.Rows(0)("TESTER_CODE"))
            obj.TESTER_NAME = clsCommon.myCstr(dt.Rows(0)("Tester_Name"))
            obj.Created_By = clsCommon.myCstr(dt.Rows(0)("Created_By_Code"))
            obj.Created_By_Name = clsCommon.myCstr(dt.Rows(0)("Created_By_Code"))

            obj.Analysis_By = clsCommon.myCstr(dt.Rows(0)("Analaysis_By_Code"))
            obj.Analysis_By_Name = clsCommon.myCstr(dt.Rows(0)("Analysis_By_Name"))

            obj.Modify_By = clsCommon.myCstr(dt.Rows(0)("Modify_By"))
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
            obj.ALLOCATED_TIME = clsCommon.myCstr(dt.Rows(0)("ALLOCATED_TIME"))
            obj.TESTING_TIME = clsCommon.myCstr(dt.Rows(0)("TESTING_TIME"))
            obj.APPROVED_TIME = clsCommon.myCstr(dt.Rows(0)("APPROVED_TIME"))
            obj.TOTAL_TIME = clsCommon.myCstr(dt.Rows(0)("TOTAL_TIME"))
            obj.IS_Mgmt_APPROVED = clsCommon.myCstr(dt.Rows(0)("IS_Mgmt_APPROVED"))

            If clsCommon.CompairString(obj.IS_Mgmt_APPROVED, "1") = CompairStringResult.Equal Then
                obj.IS_Mgmt_APPROVED_DATE = clsCommon.myCDate(dt.Rows(0)("IS_Mgmt_APPROVED_DATE"))
                obj.APPROVED_BY_MGMT_NAME = clsCommon.myCstr(dt.Rows(0)("APPROVED_BY_MGMT_NAME"))
                obj.APPROVED_BY_MGMT_CODE = clsCommon.myCstr(dt.Rows(0)("APPROVED_BY_MGMT_CODE"))
            End If
           
            obj.IS_CLIENT_APPROVED = clsCommon.myCstr(dt.Rows(0)("IS_CLIENT_APPROVED"))

            If clsCommon.CompairString(obj.IS_CLIENT_APPROVED, "1") = CompairStringResult.Equal Then
                obj.IS_CLIENT_APPROVED_DATE = clsCommon.myCDate(dt.Rows(0)("IS_CLIENT_APPROVED_DATE"))
                obj.APPROVED_BY_CLIENT_NAME = clsCommon.myCstr(dt.Rows(0)("APPROVED_BY_CLIENT_NAME"))
                obj.APPROVED_BY_CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("APPROVED_BY_CLIENT_CODE"))

            End If
            obj.APPROVAL_STATUS = clsCommon.myCstr(dt.Rows(0)("APPROVAL_STATUS"))

        End If
        Return obj
    End Function

    Public Shared Function deleteData(ByVal strAnalysisNo As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry1 As String = "delete from TSPL_REQUEST_ANALYSIS_MASTER where REQUEST_ANALYSIS_NO='" & strAnalysisNo & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    


End Class
