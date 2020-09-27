Imports common
Imports System.Data.SqlClient

Public Class clsRequestCreationEntry
#Region "Variables"
    Public REQUEST_NO As String = Nothing
    Public REQUEST_DATE As Date? = Nothing
    Public REQUEST_STATUS As String = Nothing
    Public CLIENT_CODE As String = Nothing
    Public CLIENT_NAME As String = Nothing
    Public REQUEST_DESCRIPTION As String = Nothing
    Public Created_By As String = Nothing
    Public Created_By_Name As String = Nothing
    Public Created_Date As Date? = Nothing
    Public Modify_By As String = Nothing
    Public Modify_By_Name As String = Nothing
    Public Modify_Date As Date? = Nothing
    Public PENDING_REMARKS As String = ""
    Public APPROVAL_STATUS As String = Nothing
#End Region

    Public Function SaveData(ByVal obj As clsRequestCreationEntry, ByVal isNewEntry As Boolean) As Boolean
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


    Public Function SaveData(ByVal obj As clsRequestCreationEntry, ByVal isNewEntry As Boolean, ByVal Trans As SqlTransaction) As Boolean
        ' Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", obj.CLIENT_CODE)
            clsCommon.AddColumnsForChange(coll, "REQUEST_STATUS", obj.REQUEST_STATUS)
            clsCommon.AddColumnsForChange(coll, "REQUEST_DESCRIPTION", obj.REQUEST_DESCRIPTION)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                clsCommon.AddColumnsForChange(coll, "REQUEST_DATE", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy hh:mm tt"))
                obj.REQUEST_NO = GetnrateRequestNo(obj.CLIENT_CODE, trans)
                If clsCommon.myLen(obj.REQUEST_NO) > 0 Then
                    clsCommon.AddColumnsForChange(coll, "REQUEST_NO", obj.REQUEST_NO)
                End If
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_CREATION_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_CREATION_MASTER", OMInsertOrUpdate.Update, "TSPL_REQUEST_CREATION_MASTER.REQUEST_NO='" + obj.REQUEST_NO + "'", trans)
            End If
            SaveEmailText(obj.REQUEST_NO, trans)
            ' trans.Commit()
        Catch err As Exception
            ' trans.Rollback()
            Throw New Exception(err.Message)
        End Try
        Return True
    End Function

    Public Function UpdateRequestStatus(ByVal obj As clsRequestCreationEntry, ByVal Trans As SqlTransaction) As Boolean
        Try
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "REQUEST_NO", obj.REQUEST_NO)
            clsCommon.AddColumnsForChange(coll, "REQUEST_STATUS", obj.REQUEST_STATUS)
            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MMM/yyyy hh:mm tt"))
            clsCommonFunctionality.UpdateDataTable(coll, "TSPL_REQUEST_CREATION_MASTER", OMInsertOrUpdate.Update, "TSPL_REQUEST_CREATION_MASTER.REQUEST_NO='" + obj.REQUEST_NO + "'", Trans)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function


    Function SaveEmailText(ByVal DocNo As String, ByVal trans As SqlTransaction) As Boolean
        Dim obj As clsRequestCreationEntry = clsRequestCreationEntry.GetData(DocNo, trans)
        Dim objES As clsESContent = clsESContent.GetData(clsUserMgtCode.frmRequestCreation, trans)
        If obj IsNot Nothing AndAlso objES IsNot Nothing Then
            Dim objSMSH As New clsEMailHead()
            objSMSH.Email_Subject = objES.EMail_Subject
            objSMSH.Email_Text = objES.EMail_Text
            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestNo, obj.REQUEST_NO)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestStatus, obj.REQUEST_STATUS)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestStatus, obj.REQUEST_STATUS)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestCreatedBy, obj.Created_By_Name)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestCreatedBy, obj.Created_By_Name)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestCreatedDate, clsCommon.GetPrintDate(obj.REQUEST_DATE, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestCreatedDate, clsCommon.GetPrintDate(obj.Created_Date, "dd/MMM/yyyy"))

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestModifydBy, obj.Modify_By_Name)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestModifydBy, obj.Modify_By_Name)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestModifyDate, clsCommon.GetPrintDate(obj.Modify_Date, "dd/MMM/yyyy"))
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestModifyDate, clsCommon.GetPrintDate(obj.Modify_Date, "dd/MMM/yyyy"))

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.Client, obj.CLIENT_NAME)

            objSMSH.Email_Text = objSMSH.Email_Text.Replace(frmEMailAndSMSSetting.RequestDesc, obj.REQUEST_DESCRIPTION)
            objSMSH.Email_Subject = objSMSH.Email_Subject.Replace(frmEMailAndSMSSetting.RequestDesc, obj.REQUEST_DESCRIPTION)

            objSMSH.arrEMail = New List(Of String)()

            Dim qry As String = "select PERSON_EMAIL from TSPL_CLIENT_DETAIL where len(isnull( PERSON_EMAIL,''))>0 and IS_SEND_MAIL=1  and CLIENT_CODE = (Select isnull(CLIENT_CODE,'') as CLIENT_CODE  from TSPL_USER_MASTER where USER_CODE ='" + objCommonVar.CurrentUserCode + "')"
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

    Public Shared Function GetnrateRequestNo(ByVal strClientCode As String, ByVal Trans As SqlTransaction) As String
        'Dim strRequestNo As String = Nothing
        'Try
        '    strRequestNo = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select max(REQUEST_NO) from TSPL_REQUEST_CREATION_MASTER where TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE = '" + strClientCode + "'", Trans))
        '    If clsCommon.myLen(strRequestNo) <= 0 Then
        '        strRequestNo = strClientCode + "-00000000001"
        '    Else
        '        strRequestNo = clsCommon.incval(strRequestNo)
        '    End If


        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try
        'Return strRequestNo

        Dim strRequestNo As String = ""
        Try
            Dim sno As String = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select case when len ( max( convert ( int, RIGHT(TSPL_REQUEST_CREATION_MASTER.REQUEST_NO,LEN(TSPL_REQUEST_CREATION_MASTER.REQUEST_NO)-CHARINDEX('-',TSPL_REQUEST_CREATION_MASTER.REQUEST_NO)) )) ) is null then '1' else max( convert ( int, RIGHT(TSPL_REQUEST_CREATION_MASTER.REQUEST_NO,LEN(TSPL_REQUEST_CREATION_MASTER.REQUEST_NO)-CHARINDEX('-',TSPL_REQUEST_CREATION_MASTER.REQUEST_NO)) )) end from TSPL_REQUEST_CREATION_MASTER where  TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE = '" + strClientCode + "'", Trans))
            Dim strRequest As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select ISNULL( right('000000' + convert(varchar(20), " + sno + "+1), 6),0) from TSPL_REQUEST_CREATION_MASTER where TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE = '" + strClientCode + "'  ", Trans))
            If clsCommon.myLen(strRequest) <= 0 Then
                strRequest = "000001"
            End If
            strRequestNo = "REQ/" + strClientCode.Substring(0, 3) + "/" + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(Trans), "dd/MM/yy") + "-" + strRequest
        Catch ex As Exception
        End Try
        Return strRequestNo
    End Function

   

    Public Shared Function GetData(ByVal strCode As String, ByVal Trans As SqlTransaction) As clsRequestCreationEntry
        Dim obj As clsRequestCreationEntry = Nothing
        Dim qry As String = " select TSPL_REQUEST_CREATION_MASTER.*,TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION as Client_Name from TSPL_REQUEST_CREATION_MASTER " & _
                            " left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE =TSPL_REQUEST_CREATION_MASTER.CLIENT_CODE " & _
                            " where TSPL_REQUEST_CREATION_MASTER.REQUEST_NO = '" + strCode + "'  "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, Trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            obj = New clsRequestCreationEntry
            obj.REQUEST_NO = clsCommon.myCstr(dt.Rows(0)("REQUEST_NO"))
            obj.REQUEST_DATE = clsCommon.myCDate(dt.Rows(0)("REQUEST_DATE"))
            obj.REQUEST_STATUS = clsCommon.myCstr(dt.Rows(0)("REQUEST_STATUS"))
            obj.CLIENT_CODE = clsCommon.myCstr(dt.Rows(0)("CLIENT_CODE"))
            obj.CLIENT_NAME = clsCommon.myCstr(dt.Rows(0)("Client_Name"))
            obj.REQUEST_DESCRIPTION = clsCommon.myCstr(dt.Rows(0)("REQUEST_DESCRIPTION"))
            obj.Created_Date = clsCommon.myCDate(dt.Rows(0)("Created_Date"))
            obj.Created_By = clsCommon.myCstr(dt.Rows(0)("Created_By"))
            obj.Created_By_Name = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select USER_NAME from TSPL_USER_MASTER where USER_CODE = '" + obj.Created_By + "'", Trans))
            obj.Modify_By = clsCommon.myCstr(dt.Rows(0)("Modify_By"))
            obj.Modify_By_Name = clsCommon.myCstr(clsDBFuncationality.getSingleValue(" select USER_NAME from TSPL_USER_MASTER where USER_CODE = '" + obj.Modify_By + "'", Trans))
            obj.Modify_Date = clsCommon.myCDate(dt.Rows(0)("Modify_Date"))
            obj.APPROVAL_STATUS = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select isnull(TSPL_REQUEST_ANALYSIS_MASTER.APPROVAL_STATUS,'') as APPROVAL_STATUS, * from TSPL_REQUEST_ANALYSIS_MASTER where REQUEST_NO = '" + obj.REQUEST_NO + "'", Trans))
        End If
        Return obj
    End Function
    Public Shared Function deleteData(ByVal strRequestNo As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim qry1 As String = "delete from TSPL_REQUEST_CREATION_MASTER where REQUEST_NO='" & strRequestNo & "'"
            Dim isDeleted As Boolean = True
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry1, trans)
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Shared Function LoadRequestStatus() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr("Code") = "Open"
        dr("Name") = "Open"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("Code") = "Close"
        dr("Name") = "Close"
        dt.Rows.Add(dr)
        Return dt
    End Function
End Class
