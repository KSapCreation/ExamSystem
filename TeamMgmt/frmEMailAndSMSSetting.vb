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
    Public Const VLCDataUploaderDate As String = "$#DATE#$"
    Public Const VLCDataUploaderShift As String = "$#SHIFT#$"
    Public Const VLCDataUploaderMP As String = "$#MPName#$"
    Public Const VLCDataUploaderMilkType As String = "$#MILKTYPE#$"
    Public Const VLCDataUploaderQty As String = "$#QTY#$"
    Public Const VLCDataUploaderFat As String = "$#FAT#$"
    Public Const VLCDataUploaderSNF As String = "$#SNF#$"
    Public Const VLCDataUploaderRate As String = "$#RATE#$"
    Public Const VLCDataUploaderAmt As String = "$#AMOUNT#$"
    Public Const VSP As String = "$#VSP#$"
    Public Const MCCUploaderCode As String = "$#MCCUploaderCode#$"
    Public Const MCCCode As String = "$#MCCCode#$"
    Public Const MCCName As String = "$#MMCCName#$"
    Public Const State As String = "$#State#$"
    Public Const NoOfRoute As String = "$#NoOfRoute#$"
    Public Const NoOfVLC As String = "$#NoOfVLC#$"
    Public Const UOM As String = "$#UOM#$"

    '' Variables for Transaction Approval
    Public Const Doc_Date As String = "$#DATE#$"
    Public Const Doc_No As String = "$#DocNo#$"
    Public Const Doc_Type As String = "$#Doc_Type#$"
    Public Const Cust_Code As String = "$#Cust_Code#$"
    Public Const Cust_Name As String = "$#Cust_Name#$"
    Public Const Vendor_Code As String = "$#Vendor_Code#$"
    Public Const Vendor_Name As String = "$#Vendor_Name#$"
    Public Const Loc_Code As String = "$#Loc_Code#$"
    Public Const Loc_Name As String = "$#Loc_Name#$"
    Public Const ProdQty As String = "$#ProdQty#$"
    Public Const Approval_Type As String = "$#AType#$"
    Public Const DocAmount As String = "$#DocAmt#$"
    Public Const BookingAmount As String = "$#BookAmt#$"
    Public Const AvailBalance As String = "$#AvailBal#$"
    Public Const ShortExcess As String = "$#ShortExcess#$"
    Public Const CreditLimit As String = "$#CreditLim#$"
    Public Const Approval_By As String = "$#Approval_By#$"
    Public Const Approval_By_Name As String = "$#Approval_By_Name#$"
    Public Const TankerNo As String = "$#TankerNo#$"
    Public Const SupplierCode As String = "$#SupplierCode#$"
    Public Const SupplierName As String = "$#SupplierName#$"
    Public Const MilkTypeCode As String = "$#MilkTypeCode#$"
    Public Const MilkTypeName As String = "$#MilkTypeName#$"
    Public Const TotalQty As String = "$#TotalQty#$"
    Public Const PriceCode As String = "$#PriceCode#$"
    Public Const Rate As String = "$#Rate#$"
    Public Const VSPCode As String = "$#VSPCode#$"
    Public Const VSPUploaderCode As String = "$#VSPUploaderCode#$"

    Public Const CowQty As String = "$#CowQTY#$"
    Public Const CowFat As String = "$#CowFAT#$"
    Public Const CowSNF As String = "$#CowSNF#$"
    Public Const CowRate As String = "$#CowRATE#$"
    Public Const CowAmt As String = "$#CowAMOUNT#$"
    Public Const BuffaloQty As String = "$#BuffaloQTY#$"
    Public Const BuffaloFat As String = "$#BuffaloFAT#$"
    Public Const BuffaloSNF As String = "$#BuffaloSNF#$"
    Public Const BuffaloRate As String = "$#BuffaloRATE#$"
    Public Const BuffaloAmt As String = "$#BuffaloAmount#$"

    Public Const MilkTypeCB As String = "$#MilkTypeCB#$"
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
        If clsCommon.CompairString(Form_ID, clsUserMgtCode.frmVlcdataUploadar) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(VLCDataUploaderDate)
            ContextMenuStrip1.Items.Add(VLCDataUploaderShift)
            ContextMenuStrip1.Items.Add(VLCDataUploaderMP)
            ContextMenuStrip1.Items.Add(VLCDataUploaderMilkType)
            ContextMenuStrip1.Items.Add(VLCDataUploaderQty)
            ContextMenuStrip1.Items.Add(VLCDataUploaderFat)
            ContextMenuStrip1.Items.Add(VLCDataUploaderSNF)
            ContextMenuStrip1.Items.Add(VLCDataUploaderRate)
            ContextMenuStrip1.Items.Add(VLCDataUploaderAmt)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmMilkShiftEndMCC) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(State)
            ContextMenuStrip1.Items.Add(VLCDataUploaderShift)
            ContextMenuStrip1.Items.Add(MCCCode)
            ContextMenuStrip1.Items.Add(MCCName)
            ContextMenuStrip1.Items.Add(MCCUploaderCode)
            ContextMenuStrip1.Items.Add(VLCDataUploaderDate)
            ContextMenuStrip1.Items.Add(TotalQty)
            ContextMenuStrip1.Items.Add(UOM)
            ContextMenuStrip1.Items.Add(NoOfVLC)
            ContextMenuStrip1.Items.Add(NoOfRoute)
            ContextMenuStrip1.Items.Add(VLCDataUploaderFat)
            ContextMenuStrip1.Items.Add(VLCDataUploaderSNF)
            ContextMenuStrip1.Items.Add(VLCDataUploaderRate)
            ContextMenuStrip1.Items.Add(VLCDataUploaderAmt)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmMilkSample) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(VLCDataUploaderDate)
            ContextMenuStrip1.Items.Add(VLCDataUploaderShift)
            ContextMenuStrip1.Items.Add(MCCCode)
            ContextMenuStrip1.Items.Add(MCCName)
            ContextMenuStrip1.Items.Add(MCCUploaderCode)
            ContextMenuStrip1.Items.Add(VSPCode)
            ContextMenuStrip1.Items.Add(VSP)
            ContextMenuStrip1.Items.Add(VSPUploaderCode)
            ContextMenuStrip1.Items.Add(MilkTypeCB)
            ContextMenuStrip1.Items.Add(UOM)
            ContextMenuStrip1.Items.Add(VLCDataUploaderQty)
            ContextMenuStrip1.Items.Add(VLCDataUploaderFat)
            ContextMenuStrip1.Items.Add(VLCDataUploaderSNF)
            ContextMenuStrip1.Items.Add(VLCDataUploaderRate)
            ContextMenuStrip1.Items.Add(VLCDataUploaderAmt)

            
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.FrmTransactionApproval) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(Doc_Date)
            ContextMenuStrip1.Items.Add(Doc_No)
            ContextMenuStrip1.Items.Add(Cust_Code)
            ContextMenuStrip1.Items.Add(Cust_Name)
            ContextMenuStrip1.Items.Add(Loc_Code)
            ContextMenuStrip1.Items.Add(Loc_Name)
            ContextMenuStrip1.Items.Add(Approval_Type)
            ContextMenuStrip1.Items.Add(DocAmount)
            ContextMenuStrip1.Items.Add(BookingAmount)
            ContextMenuStrip1.Items.Add(AvailBalance)
            ContextMenuStrip1.Items.Add(ShortExcess)
            ContextMenuStrip1.Items.Add(CreditLimit)
            ContextMenuStrip1.Items.Add(Approval_By)
            ContextMenuStrip1.Items.Add(Approval_By_Name)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnPurchaseRequistion) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(clsEmailSMSConstants.DOC_NO)
            ContextMenuStrip1.Items.Add(clsEmailSMSConstants.DOC_Date)
            ContextMenuStrip1.Items.Add(clsEmailSMSConstants.Doc_Amount)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.mbtnIssueReturn) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(clsEmailSMSConstants.DOC_NO)
            ContextMenuStrip1.Items.Add(clsEmailSMSConstants.DOC_Date)
            ContextMenuStrip1.Items.Add(clsEmailSMSConstants.Doc_Amount)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmbookingdairy) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(Doc_Date)
            ContextMenuStrip1.Items.Add(Doc_No)
            ContextMenuStrip1.Items.Add(Cust_Code)
            ContextMenuStrip1.Items.Add(Cust_Name)
            ContextMenuStrip1.Items.Add(Loc_Code)
            ContextMenuStrip1.Items.Add(Loc_Name)
            ContextMenuStrip1.Items.Add(Approval_Type)
            ContextMenuStrip1.Items.Add(BookingAmount)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmGateEntry) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(Doc_Date)
            ContextMenuStrip1.Items.Add(Doc_No)
            ContextMenuStrip1.Items.Add(Doc_Type)
            ContextMenuStrip1.Items.Add(Vendor_Code)
            ContextMenuStrip1.Items.Add(Vendor_Name)
            ContextMenuStrip1.Items.Add(Loc_Code)
            ContextMenuStrip1.Items.Add(Loc_Name)
            ContextMenuStrip1.Items.Add(SupplierCode)
            ContextMenuStrip1.Items.Add(SupplierName)
            ContextMenuStrip1.Items.Add(TankerNo)
            ContextMenuStrip1.Items.Add(MilkTypeCode)
            ContextMenuStrip1.Items.Add(MilkTypeName)
            ContextMenuStrip1.Items.Add(TotalQty)
            ContextMenuStrip1.Items.Add(BookingAmount)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmPOBulkProc) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(Doc_Date)
            ContextMenuStrip1.Items.Add(Doc_No)
            ContextMenuStrip1.Items.Add(Vendor_Code)
            ContextMenuStrip1.Items.Add(Vendor_Name)
            ContextMenuStrip1.Items.Add(Loc_Code)
            ContextMenuStrip1.Items.Add(Loc_Name)
            ContextMenuStrip1.Items.Add(TotalQty)
            ContextMenuStrip1.Items.Add(PriceCode)
            ContextMenuStrip1.Items.Add(Rate)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmSaleDispatchDairy) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(Doc_No)
            ContextMenuStrip1.Items.Add(Doc_Date)
            ContextMenuStrip1.Items.Add(DocAmount)
            ContextMenuStrip1.Items.Add(Cust_Code)
            ContextMenuStrip1.Items.Add(Cust_Name)
        ElseIf clsCommon.CompairString(Form_ID, clsUserMgtCode.frmdispatchAdviceProductSale) = CompairStringResult.Equal Then
            ContextMenuStrip1.Items.Add(Doc_No)
            ContextMenuStrip1.Items.Add(Doc_Date)
            ContextMenuStrip1.Items.Add(DocAmount)
            ContextMenuStrip1.Items.Add(Cust_Code)
            ContextMenuStrip1.Items.Add(Cust_Name)
            ContextMenuStrip1.Items.Add(Loc_Code)
            ContextMenuStrip1.Items.Add(Loc_Name)
            ContextMenuStrip1.Items.Add(ProdQty)
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
            txtEmailText.Text = txtEmailText.Text.Insert(txtEmailText.SelectionStart, " " + e.ClickedItem.Text)
        ElseIf RadPageView1.SelectedPage Is RadPageViewPage4 Then
            txt_NotificationText.Text = txt_NotificationText.Text.Insert(txt_NotificationText.SelectionStart, " " + e.ClickedItem.Text)
        End If
    End Sub

    Private Sub RadPageView1_SelectedPageChanging(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.RadPageViewCancelEventArgs) Handles RadPageView1.SelectedPageChanging
        If e.Page Is RadPageViewPage3 AndAlso Not isConfigPwdEntered Then
            If isFormLoadOccured Then
                Dim frm As New FrmPWD(Nothing)
                frm.strType = "SIRC"
                frm.strCode = "SIReversAndCreate"
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
        Dim qry As String = "select EMP_CODE,Emp_Name,Phone from TSPL_EMPLOYEE_MASTER where LEN(isnull(Phone,''))>0"
        txtEmpSMSAlerts.arrValueMember = clsCommon.ShowMultipleSelectForm("EMPSMSAlertS", qry, "EMP_CODE", "", txtEmpSMSAlerts.arrValueMember, Nothing)
    End Sub

    Private Sub txtEmpEmailAlerts__My_Click(sender As Object, e As EventArgs) Handles txtEmpEmailAlerts._My_Click
        Dim qry As String = "select EMP_CODE, Emp_Name,EMail_ID from TSPL_EMPLOYEE_MASTER where LEN(isnull(EMail_ID,''))>0"
        txtEmpEmailAlerts.arrValueMember = clsCommon.ShowMultipleSelectForm("EMPEMAILAlertS", qry, "EMP_CODE", "", txtEmpEmailAlerts.arrValueMember, Nothing)
    End Sub

    Private Sub txtEmpNotificationAlerts__My_Click(sender As Object, e As EventArgs) Handles txtEmpNotificationAlerts._My_Click
        Dim qry As String = "select EMP_CODE, Emp_Name from TSPL_EMPLOYEE_MASTER"
        txtEmpNotificationAlerts.arrValueMember = clsCommon.ShowMultipleSelectForm("EMPNotificationAlertS", qry, "EMP_CODE", "", txtEmpNotificationAlerts.arrValueMember, Nothing)
    End Sub

    Private Sub ContextMenuStrip3_ItemClicked(sender As Object, e As Windows.Forms.ToolStripItemClickedEventArgs)
        If RadPageView1.SelectedPage Is RadPageViewPage4 Then
            txt_NotificationText.Text = txt_NotificationText.Text.Insert(txt_NotificationText.SelectionStart, " " + e.ClickedItem.Text)
        End If
    End Sub
End Class
