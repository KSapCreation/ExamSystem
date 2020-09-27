Imports common
Imports System.Net.Mail
Imports System.Net.WebClient
Imports System.IO

Public Class frmEMailAndSMSSetting
#Region "Variables Setting"
    Public isForEMail As Boolean = False
    Public isForSMS As Boolean = False
    Public isForNotification As Boolean = False
    Public isConfigPwdEntered As Boolean = False

    Public Form_ID As String = ""
    Public Const SMSStringMobileNo As String = "$#MOBILENO#$"
    Public Const SMSStringConstSMSText As String = "$#SMSTEXT#$"
    Public isFormLoadOccured As Boolean = False
#End Region

#Region "Variables"
    Public Const DocumentNo As String = "$#DOCUMENTNO#$"
    Public Const DocumentDate As String = "$#DOCUMENTDATE#$"
    Public Const Status As String = "$#STATUS#$"
    Public Const CreatedBy As String = "$#CREATEDBY#$"
    Public Const CreatedDate As String = "$#CREATEDDATE#$"
    Public Const ModifyBy As String = "$#MODIFYBY#$"
    Public Const ModifyDate As String = "$#MODIFYDATE#$"
    Public Const Client As String = "$#CLIENT#$"
    Public Const Description As String = "$#DESCRIPTION#$"
    Public Const ManagmentApprovedStatus As String = "$#MANAGMENTAPPROVEDSTATUS#$"
    Public Const ManagmentApprovedDate As String = "$#MANAGMENTAPPROVEDDATE#$"
    Public Const ClientApprovedStatus As String = "$#CLIENTAPPROVEDSTATUS#$"
    Public Const ClientApprovedDate As String = "$#CLIENTAPPROVEDDATE#$"
    Public Const RequestNo As String = "$#REQUESTNO#$"
    Public Const RequestDate As String = "$#REQUESTDATE#$"
    Public Const RequestDesc As String = "$#REQUESTDESCRIPTION#$"
    Public Const TicketNo As String = "$#TICKETNO#$"
    Public Const TicketDate As String = "$#TICKETDATE#$"
    Public Const TicketStatus As String = "$#TICKETSTATUS#$"
    Public Const TicketType As String = "$#TICKETTYPE#$"
    Public Const Severity As String = "$#SERVERITY#$"
    Public Const Priority As String = "$#PRIORITY#$"
    Public Const TicketDetails As String = "$#TICKETDETAILS#$"
    Public Const TicketAllocationDetails As String = "$#TICKEALLOCATIONTDETAILS#$"
    Public Const AllocationTime As String = "$#ALLOCATIONTIME#$"
    Public Const DeveloperName As String = "$#DEVELOPERNAME#$"
    Public Const DevelopmentTime As String = "$#DEVELOPMENTTIME#$"
    Public Const TesterName As String = "$#TESTERNAME#$"
    Public Const TesterTime As String = "$#TESTERTIME#$"
    Public Const ScreenName As String = "$#SCREENNAME#$"
    Public Const ModuleName As String = "$#MODULENAME#$"
    Public Const ProjectName As String = "$#PROJECTNAME#$"
    Public Const AnalysisNo As String = "$#ANALYSISNO#$"
    Public Const AnalysisDesc As String = "$#ANALYSISNO#$"
    Public Const AnalysisDate As String = "$#ANALYSISDATE#$"
    Public Const DeveloperRemarks As String = "$#DEVELOPERREMARKS#$"
    Public Const TesterRemarks As String = "$#TESTERREMARKS#$"
    Public Const DevelopmentVerstion As String = "$#DEVELOPMENTVERSTION#$"
    Public Const TestingVerstion As String = "$#TESTINGVERSTION#$"
    Public Const PendingRemarks As String = "$#PENDINGREMARKS#$"
    Public Const ActualTestingTime As String = "$#ACTUALTESTINGTIME#$"
    Public Const ClientMangmentApprovalStatus As String = "$#CLINETMANAGEMNTAPRROVALSTATUS#$"
    Public Const ClientMangmentApprovalDate As String = "$#CLINETMANAGEMNTAPRROVALDATE#$"
    Public Const ClientMangmentApprovalBy As String = "$#CLINETMANAGEMNTAPRROVALBY#$"
    Public Const AnalysisBy As String = "$#ANALYSISBY#$"

    Public Const RequestCompletePendingByCode As String = "$#REQUEST_COMPLETE_PENDING_BY_CODE#$"
    Public Const RequestCompletePendingByName As String = "$#REQUEST_COMPLETE_PENDING_BY_NAME#$"
    Public Const RequestCompletePendingDate As String = "$#REQUEST_COMPLETE_PENDING_DATE#$"
    Public Const RequestStatus As String = "$#REQUESTSTATUS#$"
    Public Const RequestCreatedBy As String = "$#REQUEST_CREATED_BY#$"
    Public Const RequestCreatedDate As String = "$#REQUEST_CREATED_DATE#$"
    Public Const RequestModifydBy As String = "$#REQUEST_MODIFY_BY#$"
    Public Const RequestModifyDate As String = "$#REQUEST_MODIFY_DATE#$"
    Public Const AnalysisStatus As String = "$#ANALYSIS_STATUS#$"
    Public Const ExeVersion As String = "$#EXEVERSION#$"


#End Region

    Private Sub frmEMailAndSMSSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not isForEMail Then
            RadPageView1.Pages("RadPageViewPage1").Item.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        Else
            RadPageView1.SelectedPage = RadPageViewPage1
        End If
        If Not isForSMS Then
            RadPageView1.Pages("RadPageViewPage2").Item.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        Else
            RadPageView1.SelectedPage = RadPageViewPage2
        End If

        If Not isForNotification Then
            RadPageView1.Pages("RadPageViewPage4").Item.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        Else
            RadPageView1.SelectedPage = RadPageViewPage4
        End If
        LoadNotificationsOn()
        ContextMenuStrip2.Items.Add(SMSStringMobileNo)
        ContextMenuStrip2.Items.Add(SMSStringConstSMSText)
        If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRequestCreation) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
            ContextMenuStrip1.Items.Add(RequestStatus)
            ContextMenuStrip1.Items.Add(RequestCreatedBy)
            ContextMenuStrip1.Items.Add(RequestCreatedDate)
            ContextMenuStrip1.Items.Add(RequestModifydBy)
            ContextMenuStrip1.Items.Add(RequestModifyDate)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(RequestDesc)
        End If

        If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRequestAnalysis) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(DocumentNo)
            ContextMenuStrip1.Items.Add(DocumentDate)
            ContextMenuStrip1.Items.Add(Status)
            ContextMenuStrip1.Items.Add(CreatedBy)
            ContextMenuStrip1.Items.Add(CreatedDate)
            ContextMenuStrip1.Items.Add(ModifyBy)
            ContextMenuStrip1.Items.Add(ModifyDate)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(Description)
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
            ContextMenuStrip1.Items.Add(RequestDesc)
            ContextMenuStrip1.Items.Add(TicketType)
            ContextMenuStrip1.Items.Add(AnalysisBy)
        End If

        If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRequestApproval) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(DocumentNo)
            ContextMenuStrip1.Items.Add(DocumentDate)
            ContextMenuStrip1.Items.Add(Status)
            ContextMenuStrip1.Items.Add(CreatedBy)
            ContextMenuStrip1.Items.Add(CreatedDate)
            ContextMenuStrip1.Items.Add(ModifyBy)
            ContextMenuStrip1.Items.Add(ModifyDate)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(Description)
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
            ContextMenuStrip1.Items.Add(RequestDesc)
            ContextMenuStrip1.Items.Add(ManagmentApprovedStatus)
            ContextMenuStrip1.Items.Add(ManagmentApprovedDate)
            ContextMenuStrip1.Items.Add(ClientApprovedStatus)
            ContextMenuStrip1.Items.Add(ClientApprovedDate)
            ContextMenuStrip1.Items.Add(ClientMangmentApprovalStatus)
            ContextMenuStrip1.Items.Add(ClientMangmentApprovalDate)
            ContextMenuStrip1.Items.Add(ClientMangmentApprovalBy)
        End If

        If clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmTicketMaster) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(TicketNo)
            ContextMenuStrip1.Items.Add(TicketDate)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(ScreenName)
            ContextMenuStrip1.Items.Add(ModuleName)
            ContextMenuStrip1.Items.Add(ProjectName)
            ContextMenuStrip1.Items.Add(CreatedBy)
            ContextMenuStrip1.Items.Add(CreatedDate)
            ContextMenuStrip1.Items.Add(ModifyBy)
            ContextMenuStrip1.Items.Add(ModifyDate)
            ContextMenuStrip1.Items.Add(TicketDetails)
            ContextMenuStrip1.Items.Add(TicketType)
            ContextMenuStrip1.Items.Add(TicketStatus)
            ContextMenuStrip1.Items.Add(AnalysisNo)
            ContextMenuStrip1.Items.Add(AnalysisDate)
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
        End If

        If clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmTicketAllocation) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(TicketNo)
            ContextMenuStrip1.Items.Add(TicketDate)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(ScreenName)
            ContextMenuStrip1.Items.Add(ModuleName)
            ContextMenuStrip1.Items.Add(ProjectName)
            ContextMenuStrip1.Items.Add(CreatedBy)
            ContextMenuStrip1.Items.Add(CreatedDate)
            ContextMenuStrip1.Items.Add(ModifyBy)
            ContextMenuStrip1.Items.Add(ModifyDate)
            ContextMenuStrip1.Items.Add(TicketType)
            ContextMenuStrip1.Items.Add(TicketStatus)
            ContextMenuStrip1.Items.Add(AnalysisNo)
            ContextMenuStrip1.Items.Add(AnalysisDate)
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
            ContextMenuStrip1.Items.Add(DeveloperName)
            ContextMenuStrip1.Items.Add(TesterName)
            ContextMenuStrip1.Items.Add(AllocationTime)
            ContextMenuStrip1.Items.Add(TicketAllocationDetails)
            ContextMenuStrip1.Items.Add(TicketDetails)
        End If

        If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmTimeSheet) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(TicketNo)
            ContextMenuStrip1.Items.Add(TicketDate)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(ScreenName)
            ContextMenuStrip1.Items.Add(ModuleName)
            ContextMenuStrip1.Items.Add(ProjectName)
            ContextMenuStrip1.Items.Add(CreatedBy)
            ContextMenuStrip1.Items.Add(CreatedDate)
            ContextMenuStrip1.Items.Add(ModifyBy)
            ContextMenuStrip1.Items.Add(ModifyDate)
            ContextMenuStrip1.Items.Add(TicketType)
            ContextMenuStrip1.Items.Add(TicketStatus)
            ContextMenuStrip1.Items.Add(AnalysisNo)
            ContextMenuStrip1.Items.Add(AnalysisDate)
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
            ContextMenuStrip1.Items.Add(DeveloperName)
            ContextMenuStrip1.Items.Add(TesterName)
            ContextMenuStrip1.Items.Add(AllocationTime)
            ContextMenuStrip1.Items.Add(TicketAllocationDetails)
            ContextMenuStrip1.Items.Add(DeveloperRemarks)
            ContextMenuStrip1.Items.Add(TesterRemarks)
            ContextMenuStrip1.Items.Add(ExeVersion)
            ContextMenuStrip1.Items.Add(TicketDetails)
        End If
        If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmRequestStatus) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(RequestNo)
            ContextMenuStrip1.Items.Add(RequestDate)
            ContextMenuStrip1.Items.Add(RequestStatus)
            ContextMenuStrip1.Items.Add(AnalysisNo)
            ContextMenuStrip1.Items.Add(AnalysisDate)
            ContextMenuStrip1.Items.Add(AnalysisStatus)
            ContextMenuStrip1.Items.Add(Client)
            ContextMenuStrip1.Items.Add(ScreenName)
            ContextMenuStrip1.Items.Add(ModuleName)
            ContextMenuStrip1.Items.Add(ProjectName)
            ContextMenuStrip1.Items.Add(CreatedBy)
            ContextMenuStrip1.Items.Add(TicketType)
            ContextMenuStrip1.Items.Add(Severity)
            ContextMenuStrip1.Items.Add(Priority)
            ContextMenuStrip1.Items.Add(TicketNo)
            ContextMenuStrip1.Items.Add(TicketStatus)
            ContextMenuStrip1.Items.Add(DevelopmentVerstion)
            ContextMenuStrip1.Items.Add(TestingVerstion)
            ContextMenuStrip1.Items.Add(PendingRemarks)
            ContextMenuStrip1.Items.Add(RequestDesc)
            ContextMenuStrip1.Items.Add(AnalysisDesc)
            ContextMenuStrip1.Items.Add(ModifyBy)
            ContextMenuStrip1.Items.Add(RequestCompletePendingByCode)
            ContextMenuStrip1.Items.Add(RequestCompletePendingByName)
            ContextMenuStrip1.Items.Add(RequestCompletePendingDate)


        End If

        Dim obj As clsESConfig = clsESConfig.GetData()
        If obj IsNot Nothing Then
            txtMailSMTPClient.Text = obj.EMail_SMTP_Client
            txtMailPort.Text = obj.EMail_Port
            txtMailID.Text = obj.EMail_ID
            txtMailPwd.Text = obj.EMail_Pwd
            chkMailEnableSSL.Checked = obj.EMail_Enabel_SSL
            txtSMSString.Text = obj.SMS_String
        End If
        Dim objContent As clsESContent = clsESContent.GetData(Form_ID)
        If objContent IsNot Nothing Then
            txtEmailText.Text = objContent.EMail_Text
            txtSMSText.Text = objContent.SMS_Text
            txtSubject.Text = objContent.EMail_Subject

            txt_NotificationText.Text = objContent.Notification_Text
            txt_NotificationCaption.Text = objContent.Notification_Caption
            If clsCommon.myLen(objContent.Notification_On) > 0 Then
                ddl_notificationon.SelectedValue = objContent.Notification_On
            End If

            txtEmpSMSAlerts.arrValueMember = objContent.arrAlertEmployeeSMS
            txtEmpEmailAlerts.arrValueMember = objContent.arrAlertEmployeeEMail
            txtEmpNotificationAlerts.arrValueMember = objContent.arrAlertEmployeeNotification
        End If
        isFormLoadOccured = True
    End Sub

    Sub LoadNotificationsOn()
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        Dim dr As DataRow = dt.NewRow()

        dr("Code") = "S"
        dr("Name") = "Save"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "P"
        dr("Name") = "Post"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Code") = "A"
        dr("Name") = "Amendment"
        dt.Rows.Add(dr)

        ddl_notificationon.DataSource = dt
        ddl_notificationon.ValueMember = "Code"
        ddl_notificationon.DisplayMember = "Name"
        ddl_notificationon.SelectedValue = "S"
    End Sub

    Private Sub btnSaveConfiguration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveConfiguration.Click
        If AllowToSave() Then
            Try
                If isConfigPwdEntered Then
                    Dim obj As New clsESConfig()
                    obj.EMail_SMTP_Client = txtMailSMTPClient.Text
                    obj.EMail_Port = txtMailPort.Text
                    obj.EMail_ID = txtMailID.Text
                    obj.EMail_Pwd = txtMailPwd.Text
                    obj.EMail_Enabel_SSL = chkMailEnableSSL.Checked
                    obj.SMS_String = txtSMSString.Text
                    obj.SaveData(obj)
                End If

                Dim objContent As New clsESContent()
                objContent.EMail_Text = txtEmailText.Text
                objContent.SMS_Text = txtSMSText.Text
                objContent.EMail_Subject = txtSubject.Text
                'done by stuti on 23/11/2016 regarding notifications
                objContent.Notification_Caption = txt_NotificationCaption.Text
                objContent.Notification_Text = txt_NotificationText.Text
                objContent.Notification_On = clsCommon.myCstr(ddl_notificationon.SelectedValue)

                objContent.Form_ID = Form_ID
                If clsCommon.myLen(objContent.SMS_Text) > 0 Then
                    objContent.arrAlertEmployeeSMS = txtEmpSMSAlerts.arrValueMember
                End If
                If clsCommon.myLen(objContent.EMail_Text) > 0 Then
                    objContent.arrAlertEmployeeEMail = txtEmpEmailAlerts.arrValueMember
                End If

                If clsCommon.myLen(objContent.Notification_Text) > 0 Then
                    objContent.arrAlertEmployeeNotification = txtEmpNotificationAlerts.arrValueMember
                End If

                If objContent.SaveData(objContent) Then
                    clsCommon.MyMessageBoxShow("Data Saved successfully", Me.Text)
                End If

            Catch ex As Exception
                clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            End Try
        End If
    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        If RadPageView1.SelectedPage Is RadPageViewPage2 Then
            txtSMSText.Text = txtSMSText.Text.Insert(txtSMSText.SelectionStart, " " + e.ClickedItem.Text)
        ElseIf RadPageView1.SelectedPage Is RadPageViewPage1 Then
            Dim cms As ContextMenuStrip = CType(sender, ContextMenuStrip)
            If clsCommon.CompairString(cms.SourceControl.Name, "txtSubject") = CompairStringResult.Equal Then
                txtSubject.Text = txtSubject.Text.Insert(txtSubject.SelectionStart, " " + e.ClickedItem.Text)
            Else
                txtEmailText.Text = txtEmailText.Text.Insert(txtEmailText.SelectionStart, " " + e.ClickedItem.Text)
            End If
            cms = Nothing
        ElseIf RadPageView1.SelectedPage Is RadPageViewPage4 Then
            txt_NotificationText.Text = txt_NotificationText.Text.Insert(txt_NotificationText.SelectionStart, " " + e.ClickedItem.Text)
        End If
    End Sub

    Private Sub RadPageView1_SelectedPageChanging(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.RadPageViewCancelEventArgs) Handles RadPageView1.SelectedPageChanging
        If e.Page Is RadPageViewPage3 AndAlso Not isConfigPwdEntered Then
            If isFormLoadOccured Then
                Dim frm As New FrmPWD(Nothing)
                frm.strCode = clsFixedParameterCode.SMSEMailConfigPassword
                frm.strType = clsFixedParameterType.SMSEMailConfigPassword
                frm.ShowDialog()
                If frm.isPasswordCorrect Then
                    isConfigPwdEntered = True
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub btnSendTestEMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTestEMail.Click
        Try
            If Not clsCommon.myInternetWork() Then
                clsCommon.MyMessageBoxShow("Internet is Not Working properly")
                Exit Sub
            End If
            If clsCommon.myLen(txtMailSMTPClient.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter SMTP Client")
                txtMailSMTPClient.Focus()
                Exit Sub
            End If

            If clsCommon.myLen(txtMailPort.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter Port")
                txtMailPort.Focus()
                Exit Sub
            End If

            If clsCommon.myLen(txtMailID.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter Email ID (From)")
                txtMailID.Focus()
                Exit Sub
            End If

            If clsCommon.myLen(txtMailPwd.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter Email Password")
                txtMailPwd.Focus()
                Exit Sub
            End If
            If clsCommon.myLen(txtEmailTo.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter Email ID (To)")
                txtEmailTo.Focus()
                Exit Sub
            End If



            Dim MailMsg As New MailMessage()
            MailMsg.Subject = txtSubject.Text
            MailMsg.From = New MailAddress(txtMailID.Text)
            MailMsg.To.Add(txtEmailTo.Text)
            MailMsg.Body = txtEmailText.Text
            MailMsg.Priority = MailPriority.High
            MailMsg.IsBodyHtml = False

            Dim SmtpMail As New SmtpClient(txtMailSMTPClient.Text)
            SmtpMail.Port = clsCommon.myCdbl(txtMailPort.Text)
            SmtpMail.Credentials = New System.Net.NetworkCredential(txtMailID.Text, txtMailPwd.Text)
            SmtpMail.EnableSsl = chkMailEnableSSL.Checked
            SmtpMail.Send(MailMsg)

            clsCommon.MyMessageBoxShow("Successfully send the Test Email", Me.Text)
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub

    Private Function AllowToSave() As Boolean
        If isForEMail Then
            If isConfigPwdEntered Then
                If clsCommon.myLen(txtMailSMTPClient.Text) <= 0 Then
                    clsCommon.MyMessageBoxShow("Please Enter SMTP Client")
                    txtMailSMTPClient.Focus()
                    Return False
                End If

                If clsCommon.myLen(txtMailPort.Text) <= 0 Then
                    clsCommon.MyMessageBoxShow("Please Enter Port")
                    txtMailPort.Focus()
                    Return False
                End If

                If clsCommon.myLen(txtMailID.Text) <= 0 Then
                    clsCommon.MyMessageBoxShow("Please Enter Email ID (From)")
                    txtMailID.Focus()
                    Return False
                End If

                If clsCommon.myLen(txtMailPwd.Text) <= 0 Then
                    clsCommon.MyMessageBoxShow("Please Enter Email Password")
                    txtMailPwd.Focus()
                    Return False
                End If
            End If
            ''Because Blank string can enter in text box
            'If clsCommon.myLen(txtEmailText.Text) <= 0 Then 
            '    clsCommon.MyMessageBoxShow("Please Enter Email Text")
            '    txtEmailText.Focus()
            '    Return False
            'End If
        End If

        If isForSMS Then
            If isConfigPwdEntered Then
                If clsCommon.myLen(txtSMSString.Text) <= 0 Then
                    clsCommon.MyMessageBoxShow("Please Enter SMS String")
                    txtSMSString.Focus()
                    Return False
                End If
            End If
            ''Because Blank string can enter in text box
            'If clsCommon.myLen(txtSMSText.Text) <= 0 Then
            '    clsCommon.MyMessageBoxShow("Please Enter SMS Text")
            '    txtSMSText.Focus()
            '    Return False
            'End If
        End If

        If isForNotification Then
            ''Because Blank string can enter in text box
            'If clsCommon.myLen(txt_NotificationText.Text) <= 0 Then
            '    clsCommon.MyMessageBoxShow("Please Enter Notification Text")
            '    txt_NotificationText.Focus()
            '    Return False
            'End If
        End If
        Return True
    End Function

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Try
            If Not clsCommon.myInternetWork() Then
                clsCommon.MyMessageBoxShow("Internet is Not Working properly")
                Exit Sub
            End If

            If clsCommon.myLen(txtSMSTestText.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter Test SMS Text")
                Exit Sub
            End If

            If clsCommon.myLen(txtSMSMobileNo.Text) <= 0 Then
                clsCommon.MyMessageBoxShow("Please Enter Test SMS Mobile No")
                Exit Sub
            End If

            Dim client As New System.Net.WebClient()
            'Dim baseurl As String = txtSMSString.Text + "?username=" + txtSMSUserName.Text + "&password=" + txtSMSPWD.Text + "&sendername=" + txtSMSSenderName.Text + "&mobileno=91" + txtSMSMobileNo.Text + "&message=" + txtSMSText.Text
            Dim baseurl As String = txtSMSString.Text
            baseurl = baseurl.Replace(SMSStringConstSMSText, txtSMSTestText.Text)
            baseurl = baseurl.Replace(SMSStringMobileNo, txtSMSMobileNo.Text)

            Dim data As Stream = client.OpenRead(baseurl)
            Dim reader As StreamReader = New StreamReader(data)
            Dim s As String = reader.ReadToEnd()
            data.Close()
            reader.Close()
            clsCommon.MyMessageBoxShow("Successfully send the Test SMS" + Environment.NewLine + s, Me.Text)
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ContextMenuStrip2_ItemClicked(sender As Object, e As Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip2.ItemClicked
        txtSMSString.Text = txtSMSString.Text.Insert(txtSMSString.SelectionStart, " " + e.ClickedItem.Text)
    End Sub

    Private Sub txtEmpSMSAlerts__My_Click(sender As Object, e As EventArgs) Handles txtEmpSMSAlerts._My_Click
        Dim qry As String = "select USER_CODE, USER_NAME,EMAIL from TSPL_USER_MASTER "
        txtEmpSMSAlerts.arrValueMember = clsCommon.ShowMultipleSelectForm("EMPSMSAlertS", qry, "USER_CODE", "", txtEmpSMSAlerts.arrValueMember, Nothing)
    End Sub

    Private Sub txtEmpEmailAlerts__My_Click(sender As Object, e As EventArgs) Handles txtEmpEmailAlerts._My_Click
        Dim qry As String = "select USER_CODE, USER_NAME,EMAIL from TSPL_USER_MASTER "
        txtEmpEmailAlerts.arrValueMember = clsCommon.ShowMultipleSelectForm("EMPEMAILAlertS", qry, "USER_CODE", "", txtEmpEmailAlerts.arrValueMember, Nothing)
    End Sub

    Private Sub txtEmpNotificationAlerts__My_Click(sender As Object, e As EventArgs) Handles txtEmpNotificationAlerts._My_Click
        Dim qry As String = "select USER_CODE, USER_NAME,EMAIL from TSPL_USER_MASTER "
        txtEmpNotificationAlerts.arrValueMember = clsCommon.ShowMultipleSelectForm("EMPNotificationAlertS", qry, "USER_CODE", "", txtEmpNotificationAlerts.arrValueMember, Nothing)
    End Sub

    Private Sub ContextMenuStrip3_ItemClicked(sender As Object, e As Windows.Forms.ToolStripItemClickedEventArgs)
        If RadPageView1.SelectedPage Is RadPageViewPage4 Then
            txt_NotificationText.Text = txt_NotificationText.Text.Insert(txt_NotificationText.SelectionStart, " " + e.ClickedItem.Text)
        End If
    End Sub
End Class
