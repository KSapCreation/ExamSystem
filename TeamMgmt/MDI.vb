'Imports common
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.IO
Imports common
Imports System.Environment
Imports System.Net
Imports Microsoft.Win32
'Imports Link.AppShortcut
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Telerik.WinControls.Primitives


Public Class MDI
#Region "Varaibles"
    Public Shared blnShowAllMenu As Boolean = False
    Private isUtilityAdded As Boolean = False
    Private ArrImageList As New Dictionary(Of String, Integer)
    Private ArrBold As New List(Of String)
    Public arrExcluded As New List(Of String)

    'Public Shared IsLoc_Third_Party As String = "NO"
    'Public Shared IsLoaction_NLevel As String = "NO"
    'Public Shared IsVendor_NLevel As String = "NO"
    'Public Shared IsCustomer_NLevel As String = "NO"
    Dim OldThemeName As String = ""
    Public frm
    Public Shared isAutoClosing As Boolean = False

    Public isIdle As Integer = 0
    Public IdleTimeinSeconds As Integer = 0
    Dim Qry As String = ""
    Dim dt As DataTable

    Dim IsDBRestored As Boolean = False
    Public isApplicationRun As Boolean = False
    Public isLoadAppIntegrator As Boolean = False
    Public isLoadBulkPurchaseUploader As Boolean = False
    Public IsLoadMccBugReports As Boolean = False

    '' For Multithreading
    Dim th As Threading.Thread = Nothing
    Dim th1 As Threading.Thread = Nothing
    ''
    Dim OLDshortDate As String = ""
#End Region

#Region "RadButtons"
    Dim arralert As New Dictionary(Of String, RadDesktopAlert)()
    Dim radbuttonelement As New RadButtonElement("Snooze")
    Dim radbuttonDontShow As New RadButtonElement("Don't Show Again")
#End Region


    Private Sub MDI_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            FrmMainTranScreen.LastWorkingTime = DateTime.Now()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MDI_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Dim strQ As String = "update tspl_user_master set IP_Address=NULL,Login_Status=0 where user_code='" + objCommonVar.CurrentUserCode + "'"
        'clsDBFuncationality.ExecuteNonQuery(strQ)

        'If Not IsDBRestored Then
        '    strQ = "Update TSPL_UserLogin_Info set Logout_DateTime=' " + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt") + "'  where Login_Code ='" + objCommonVar.CurrentLoginID + "'"
        '    connectSql.RunSql(strQ)
        'End If
        'If clsCommon.CompairString(OLDshortDate, "MM/dd/yyyy") = CompairStringResult.Equal Then
        '    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", OLDshortDate)
        'End If
        GC.Collect()
    End Sub

    Public Function IsProcessRunning(name As String) As Boolean

        'here we're going to get a list of all running processes on  

        'the computer  

        For Each clsProcess As Process In Process.GetProcesses()

            If clsProcess.ProcessName.StartsWith(name) Then

                'process found so it's running so return true  

                Return True

            End If

        Next

        'process not found, return false  

        Return False

    End Function

    Private Sub MDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CheckConfigFile() Then
            LoadTheme()
            LoadWelcomeScreen()
            'If clsCommon.CompairString(clsFixedParameter.GetData(clsFixedParameterType.AutoBackUp, clsFixedParameterCode.AutoBackUp, Nothing), "0") = CompairStringResult.Equal Then
            '    Timer2.Enabled = False
            'End If

            'ReminderTimer.Enabled = False
            'blnShowAllMenu = clsCommon.myCBool(IIf(clsCommon.myCstr(clsFixedParameter.GetData(clsFixedParameterType.ShowAllMenu, clsFixedParameterCode.ShowAllMenu, Nothing)) = "1", True, False))
            'IsLoaction_NLevel = clsCommon.myCstr(IIf(clsFixedParameter.GetData(clsFixedParameterType.NLevelAtLocation, clsFixedParameterCode.NLevelAtLocation, Nothing) = "1", "YES", "NO"))
            'IsVendor_NLevel = clsCommon.myCstr(IIf(clsFixedParameter.GetData(clsFixedParameterType.NLevelAtVendor, clsFixedParameterCode.NLevelAtVendor, Nothing) = "1", "YES", "NO"))
            'IsCustomer_NLevel = clsCommon.myCstr(IIf(clsFixedParameter.GetData(clsFixedParameterType.NLevelAtCustomer, clsFixedParameterCode.NLevelAtCustomer, Nothing) = "1", "YES", "NO"))

        Else
            IsDBRestored = True
            isAutoClosing = True
            Me.Close()
        End If
    End Sub

    Sub LoadClientImage()
        Try
            Dim img As Byte() = DirectCast(clsDBFuncationality.getSingleValue("select top 1 Logo_Img  from tspl_company_master "), Byte())
            Dim ms As MemoryStream = New MemoryStream(img)
            PicClient.Image = Image.FromStream(ms)
        Catch ex As Exception

        End Try

    End Sub

    Function CheckConfigFile() As Boolean
        If Not File.Exists("config.Txp") Then
            Dim frm As New FrmServerConfig
            frm.ShowDialog()
            If Not File.Exists("config.Txp") Then
                Return False
            End If
        End If
        Return True
    End Function

    Sub LoadWelcomeScreen()
        SplitPanel2.Collapsed = True
        SplitPanel3.Collapsed = True
        SplitPanel4.Collapsed = True
        SplitPanel1.Collapsed = False
        Dim myAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim myAssemblyName As AssemblyName = myAssembly.GetName()
        lblVersion.Text = clsCommon.myCstr(myAssemblyName.Version).Trim()
        Dim aDescAttr As AssemblyDescriptionAttribute = AssemblyDescriptionAttribute.GetCustomAttribute(myAssembly, GetType(AssemblyDescriptionAttribute)) ' clsCommon.GetPrintDate(File.GetCreationTime(Application.StartupPath + "\ERP.exe"), "dd-MMM-yyyy")
        lblCreatedDate.Text = aDescAttr.Description.ToString
        lblUser.Text = objCommonVar.CurrentUserCode
        lblLocation.Text = objCommonVar.CurrLocationName
        lblCompany.Text = objCommonVar.CurrentCompanyName
        SetConnectionWithCommonDLL("")
        LoadClientImage()
        CallCreateTableFunction()

        '' Added By Pankaj Jha As suggested by balwinder sir, to bring login screen directly after startup based on setting
        'If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.LoadLoginScreen, clsFixedParameterCode.LoadLoginScreenDirectlyAfterStartup, Nothing)) = 0 Then
        '    RadCarousel1.AutoLoopPauseCondition = Telerik.WinControls.UI.AutoLoopPauseConditions.None
        '    Dim carouselEllipsePath1 As New Telerik.WinControls.UI.CarouselEllipsePath()
        '    carouselEllipsePath1.Center = New Telerik.WinControls.UI.Point3D(49.358974358974358, 46.315789473684212, -20)
        '    carouselEllipsePath1.FinalAngle = 60
        '    carouselEllipsePath1.InitialAngle = 60
        '    carouselEllipsePath1.U = New Telerik.WinControls.UI.Point3D(37.93530426465815, -18.191666666666663, 0)
        '    carouselEllipsePath1.V = New Telerik.WinControls.UI.Point3D(-11.489983091663683, -15.391666666666662, -20)
        '    carouselEllipsePath1.ZScale = 60
        '    RadCarousel1.CarouselPath = carouselEllipsePath1
        '    RadCarousel1.Dock = System.Windows.Forms.DockStyle.Fill
        '    RadCarousel1.EnableAutoLoop = True
        '    RadCarousel1.AutoLoopDirection = AutoLoopDirections.Forward
        '    RadCarousel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
        '    RadCarousel1.ForeColor = System.Drawing.Color.Black
        '    RadCarousel1.ImageScalingSize = New System.Drawing.Size(0, 0)
        '    'RadCarousel1.Items.AddRange(New Telerik.WinControls.RadItem() {radButtonElement1, radButtonElement2, radButtonElement3, radButtonElement4, radButtonElement5, radButtonElement6, radButtonElement7, radButtonElement8, radButtonElement9})
        '    RadCarousel1.Location = New System.Drawing.Point(0, 132)
        '    RadCarousel1.MinFadeOpacity = 0.5
        '    'RadCarousel1.Name = "RadCarousel1"
        '    RadCarousel1.NavigationButtonsOffset = New System.Drawing.Size(15, 15)
        '    Dim imagePrimitive = New ImagePrimitive()
        '    ' imagePrimitive.Image = Global.ERP.My.Resources.Resources.BackImageXpertERP
        '    imagePrimitive.Alignment = ContentAlignment.TopRight
        '    imagePrimitive.StretchHorizontally = False
        '    imagePrimitive.StretchVertically = False
        '    imagePrimitive.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        '    RadCarousel1.CarouselElement.Children.Insert(1, imagePrimitive)
        '    MyLabel2.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '    llblLogin.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Else
        '    LoadLoginScreen()
        'End If
        ''Check Licence
        'CheckLicence()
        ''End of Check Licence
        LoadLoginScreen()
    End Sub

    Private Sub llblLogin_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblLogin.LinkClicked
        LoadLoginScreen()
    End Sub

    Sub LoadLoginScreen()
        SplitPanel1.Collapsed = True
        SplitPanel3.Collapsed = True
        SplitPanel4.Collapsed = True
        SplitPanel2.Collapsed = False

        LoadCompany()
        LoadDataBase()
        'ddllocationfill()

        'Dim VarREGS As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern

        Dim myCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        OLDshortDate = myCulture.DateTimeFormat.ShortDatePattern

        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
        txtUserName.Focus()

    End Sub

    Private Const LOCALE_USER_DEFAULT = &H400
    Private Const LOCALE_SSHORTDATE = &H1F ' short date format string
    Private Const LOCALE_SLONGDATE = &H20 ' long date format string
    Private Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Long, ByVal LCType As Long, ByVal lpLCData As String, ByVal cchData As Long) As Long


    Private Sub SetConnectionWithCommonDLL(ByVal strDatabase As String)
        Try
            Dim line As String
            Dim objReader As New System.IO.StreamReader("config.Txp")
            Do While objReader.Peek() <> -1
                line = objReader.ReadLine()
                '-------------change the existing dbname with dbname comes from company master-BM00000003569------------
                Dim indexofhash As Integer = line.IndexOf("#")
                objCommonVar.Database_Server = line.Substring(0, indexofhash).Trim
                Dim reststr As String = line.Substring(indexofhash + 1, line.Length - indexofhash - 1)
                indexofhash = reststr.IndexOf("#")
                reststr = reststr.Substring(0, indexofhash)

                If clsCommon.myLen(objCommonVar.CurrDatabase) > 0 Then
                    line = line.Replace(reststr, "  " + objCommonVar.CurrDatabase + " ")
                Else
                    objCommonVar.CurrDatabase = reststr
                End If
                '--------------------------------------------------------------------------------------------
                clsDBFuncationality.SetConnectionEncryptFormat(line)
                objCommonVar.ConnString = clsDBFuncationality.connectionString

                ''-----------------------------set values in objcommor for application server--------------------------------
                'If System.IO.File.Exists("AppConfig.Txp") = False Then                   
                '    System.IO.File.Create("AppConfig.Txp").Dispose()
                'End If
                'Dim objReaderApp As New System.IO.StreamReader("AppConfig.Txp")
                'objCommonVar.App_ServerId = clsCommon.myCdbl(objReaderApp.ReadLine)
                'Dim objAppConn As clsApplicationServerConfig
                'If clsCommon.CompairString(clsCommon.myCstr(objCommonVar.App_ServerId), "0") = CompairStringResult.Equal Then
                '    objCommonVar.Application_Server = "(local)"
                '    objCommonVar.App_IP = "localhost"
                'Else
                '    objAppConn = clsApplicationServerConfig.GetData(objCommonVar.App_ServerId, NavigatorType.Current)
                '    objCommonVar.Application_Server = objAppConn.Server_Name
                '    objCommonVar.App_IP = objAppConn.Domain_IP
                '    Dim binding As System.ServiceModel.Channels.Binding
                '    Dim address As New ServiceModel.EndpointAddress("http://localhost:8090/XpertERPServices")
                '    '' set default value to binding
                '    Dim Basichttp As New System.ServiceModel.BasicHttpBinding
                '    binding = Basichttp
                '    If clsCommon.CompairString(objAppConn.Comm_Protocol, "HTTP") = CompairStringResult.Equal Then
                '        Dim basicbinding As New System.ServiceModel.BasicHttpBinding
                '        basicbinding.OpenTimeout = New TimeSpan(0, objAppConn.Conn_Open_Timeout, 0)
                '        basicbinding.CloseTimeout = New TimeSpan(0, objAppConn.Conn_Close_Timeout, 0)
                '        basicbinding.SendTimeout = New TimeSpan(0, objAppConn.Conn_Send_Timeout, 0)
                '        basicbinding.ReceiveTimeout = New TimeSpan(0, objAppConn.Conn_Receive_Timeout, 0)
                '        basicbinding.AllowCookies = True
                '        If clsCommon.CompairString(objAppConn.transferMode, "0") = CompairStringResult.Equal Then
                '            basicbinding.TransferMode = ServiceModel.TransferMode.Buffered
                '            basicbinding.MaxBufferPoolSize = objAppConn.maxBufferPoolSize
                '            basicbinding.MaxBufferSize = objAppConn.maxBufferPoolSize
                '        ElseIf clsCommon.CompairString(objAppConn.transferMode, "1") = CompairStringResult.Equal Then
                '            basicbinding.TransferMode = ServiceModel.TransferMode.Streamed
                '        ElseIf clsCommon.CompairString(objAppConn.transferMode, "2") = CompairStringResult.Equal Then
                '            basicbinding.TransferMode = ServiceModel.TransferMode.StreamedRequest
                '        ElseIf clsCommon.CompairString(objAppConn.transferMode, "3") = CompairStringResult.Equal Then
                '            basicbinding.TransferMode = ServiceModel.TransferMode.StreamedResponse
                '        End If
                '        basicbinding.MaxReceivedMessageSize = objAppConn.maxReceivedMessageSize
                '        basicbinding.MaxReceivedMessageSize = objAppConn.maxReceivedMessageSize
                '        basicbinding.Security.Mode = ServiceModel.SecurityMode.None
                '        basicbinding.ReaderQuotas.MaxArrayLength = objAppConn.maxArrayLength
                '        basicbinding.ReaderQuotas.MaxBytesPerRead = objAppConn.maxBytesPerRead
                '        basicbinding.ReaderQuotas.MaxNameTableCharCount = objAppConn.maxNameTableCharCount
                '        basicbinding.ReaderQuotas.MaxStringContentLength = objAppConn.maxStringContentLength

                '        binding = basicbinding

                '        address = New ServiceModel.EndpointAddress("http://" & objAppConn.Domain_IP & ":" & objAppConn.Port_No & "/XpertERPServices")
                '        objCommonVar.Binding = binding
                '        objCommonVar.EndPointAddress = address
                '        objCommonVar.OperationTimeout = objAppConn.Operation_Timeout
                '        objCommonVar.maxArrayLength = objAppConn.maxArrayLength
                '        objCommonVar.maxBufferPoolSize = objAppConn.maxBufferPoolSize
                '        objCommonVar.maxBytesPerRead = objAppConn.maxBytesPerRead
                '        objCommonVar.maxNameTableCharCount = objAppConn.maxNameTableCharCount
                '        objCommonVar.maxReceivedMessageSize = objAppConn.maxReceivedMessageSize
                '        objCommonVar.maxStringContentLength = objAppConn.maxStringContentLength
                '    ElseIf clsCommon.CompairString(objAppConn.Comm_Protocol, "TCP") = CompairStringResult.Equal Then
                '        Dim netTcp As New System.ServiceModel.NetTcpBinding(ServiceModel.SecurityMode.Transport)
                '        netTcp.TransferMode = ServiceModel.TransferMode.Buffered
                '        netTcp.OpenTimeout = New TimeSpan(0, objAppConn.Conn_Open_Timeout, 0)
                '        netTcp.CloseTimeout = New TimeSpan(0, objAppConn.Conn_Close_Timeout, 0)
                '        netTcp.SendTimeout = New TimeSpan(0, objAppConn.Conn_Send_Timeout, 0)
                '        netTcp.ReceiveTimeout = New TimeSpan(0, objAppConn.Conn_Receive_Timeout, 0)

                '        If clsCommon.CompairString(objAppConn.transferMode, "0") = CompairStringResult.Equal Then
                '            netTcp.TransferMode = ServiceModel.TransferMode.Buffered
                '            netTcp.MaxBufferPoolSize = objAppConn.maxBufferPoolSize
                '            netTcp.MaxBufferSize = objAppConn.maxBufferPoolSize
                '        ElseIf clsCommon.CompairString(objAppConn.transferMode, "1") = CompairStringResult.Equal Then
                '            netTcp.TransferMode = ServiceModel.TransferMode.Streamed
                '        ElseIf clsCommon.CompairString(objAppConn.transferMode, "2") = CompairStringResult.Equal Then
                '            netTcp.TransferMode = ServiceModel.TransferMode.StreamedRequest
                '        ElseIf clsCommon.CompairString(objAppConn.transferMode, "3") = CompairStringResult.Equal Then
                '            netTcp.TransferMode = ServiceModel.TransferMode.StreamedResponse
                '        End If
                '        netTcp.MaxReceivedMessageSize = objAppConn.maxReceivedMessageSize
                '        netTcp.Security.Mode = ServiceModel.SecurityMode.None
                '        netTcp.ReaderQuotas.MaxArrayLength = objAppConn.maxArrayLength
                '        netTcp.ReaderQuotas.MaxBytesPerRead = objAppConn.maxBytesPerRead
                '        netTcp.ReaderQuotas.MaxNameTableCharCount = objAppConn.maxNameTableCharCount
                '        netTcp.ReaderQuotas.MaxStringContentLength = objAppConn.maxStringContentLength

                '        binding = netTcp

                '        address = New ServiceModel.EndpointAddress("net.tcp://" & objAppConn.Domain_IP & ":" & objAppConn.Port_No & "/XpertERPServices")
                '        objCommonVar.Binding = binding
                '        objCommonVar.EndPointAddress = address
                '        objCommonVar.OperationTimeout = objAppConn.Operation_Timeout
                '        objCommonVar.maxArrayLength = objAppConn.maxArrayLength
                '        objCommonVar.maxBufferPoolSize = objAppConn.maxBufferPoolSize
                '        objCommonVar.maxBytesPerRead = objAppConn.maxBytesPerRead
                '        objCommonVar.maxNameTableCharCount = objAppConn.maxNameTableCharCount
                '        objCommonVar.maxReceivedMessageSize = objAppConn.maxReceivedMessageSize
                '        objCommonVar.maxStringContentLength = objAppConn.maxStringContentLength
                '    End If

                '    Dim svc As New XpertERPServices.XpertERPServicesClient(binding, address)                   
                '    If clsCommon.myLen(objCommonVar.CurrentUserCode) > 0 Then
                '        svc.SetObjCommonVar(objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode, objCommonVar.CurrLocationCode)
                '    End If

                'End If

            Loop
            ''stuti regarding memory leakage
            objReader.Close()
            objReader.Dispose()
            connectSql.strConn = clsDBFuncationality.connectionString
        Catch ex As Exception
            '  common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Sub test()
        Dim coll As Dictionary(Of String, String)
        Try
            coll = New Dictionary(Of String, String)()
            coll.Add("Transporter", "char(1) not null")
            coll.Add("Is_Gross_Receipt", "int NOT NULL default 0")
            coll.Add("CURRENCY_CODE", "VARCHAR(30)  NULL REFERENCES TSPL_CURRENCY_MASTER(CURRENCY_CODE) ")
            coll.Add("franchise_yn", "char(1) not null default 'N'")
            coll.Add("Form_Type", "Varchar(10) NOT NULL Default 'ALL'")
            coll.Add("State_Code", "varchar(30) NULL")
            coll.Add("Country_Code", "varchar(30) NULL")
            coll.Add("Service_charges", "Decimal(18,2) NULL")
            coll.Add("commision_pers", "float NULL")
            coll.Add("incentive", "varchar(20) NULL")
            coll.Add("incentive_days", "float NULL")
            coll.Add("vsp_payment", "varchar(10) NULL")
            coll.Add("VSP_Payee_Name", "varchar(100) NULL")
            coll.Add("Zila", "varchar(100) NULL")
            coll.Add("Tehsil", "varchar(100) NULL")
            coll.Add("Branch_Name", "varchar(150) NULL")
            coll.Add("IFCI_Code", "varchar(50) NULL")
            coll.Add("Account_No", "varchar(50) NULL")
            coll.Add("Industry_Type", "varchar(15) NULL")
            coll.Add("Industry_Person", "varchar(100) NULL")
            coll.Add("Agreement", "varchar(3) NOT NULL Default 'NO'")
            coll.Add("Security_Cheque", "varchar(3) NULL")
            coll.Add("No_of_Installment", "float NULL")
            coll.Add("Amount_of_Installment", "float NULL")
            coll.Add("IsPermanent", "char(1) NOT NULL Default '0'")
            coll.Add("IsTemporary", "char(1) NOT NULL Default '0'")
            coll.Add("Joint_Name", "varchar(100) NULL")
            coll.Add("Service_Charge_Type", "varchar(20) NULL")
            coll.Add("Is_Parent_Vendor", "char(1) NOT NULL DEFAULT '0'")
            coll.Add("Parent_Vendor_Code", "varchar(12) NULL")
            coll.Add("branch_code", "varchar(30) NULL")
            coll.Add("Category_Struct_Code", "VARCHAR(30)")
            coll.Add("Bank_Name", "varchar(50) NULL ")
            coll.Add("IFSC_Code", "varchar(50) NULL")
            coll.Add("Account_Type", "varchar(10) NULL")
            coll.Add("Vendor_Type", "varchar(10) NULL")
            coll.Add("payment_commision_pers", "float NULL")
            coll.Add("comp_code", "varchar(8) NULL")
            coll.Add("Pin_Code", "VARCHAR(20) NULL")
            coll.Add("Security_Amount", "Decimal(18,3) NULL")
            coll.Add("AMC_Charge", "Decimal(18,3) NULL")
            coll.Add("AMCU", "Varchar(20) Null")
            coll.Add("Billing_Date", "DateTime Null")
            coll.Add("Is_Chilling_vendor", "Varchar(1) Null")
            coll.Add("TDS_Branch_Code", "VARCHAR(12)  NULL REFERENCES TSPL_TDS_BRANCH_MASTER(Branch_Code)")
            coll.Add("Deduction_Code", "varchar(12) NULL References TSPL_TDS_DEDUCTION_HEAD(Deduction_Code)")
            coll.Add("TDS_State_Code", "VARCHAR(12)  NULL ")
            coll.Add("TDS_Vendor_Type", "varchar(20) NULL")
            coll.Add("TDS_Status", "varchar(20) NULL")
            coll.Add("Is_TDS_Applicable", "INTEGER NOT NULL DEFAULT 0")
            coll.Add("Nature", "Varchar(1) Null")
            coll.Add("Actual_charges", "Decimal(18,3) Null")
            coll.Add("Joint_Bank_Code", "Varchar(12) Null")
            coll.Add("Joint_Account_No", "Varchar(30) Null")
            coll.Add("Start_Date", "Date NULL")
            coll.Add("End_Date", "Date NULL")
            coll.Add("CSA_Type", "char(1) not Null default 'N'")
            coll.Add("Start_Period", "Date NULL") ' Defined For Tanker Transporter master and only used when type is temporary
            coll.Add("Expired_Period", "Date NULL") 'Defined For Tanker Transporter master and only used when type is temporary
            coll.Add("PC_CODE", "varchar(30) Null References TSPL_PAYMENT_CYCLE_MASTER(PC_coDE)")
            coll.Add("IsBlankCheque", "int NOT NULL default 0")
            coll.Add("Alies_Name", "varchar(200) NOT NULL Default ''")
            coll.Add("Vendor_Type_CHA", "varchar(50) NULL")
            coll.Add("Is_Head_Load", "varchar(1) NULL")
            coll.Add("Rate_Head_Load", "Decimal(18,3) NULL")
            coll.Add("Service_Basis_Head_Load", "varchar(1) NULL")
            coll.Add("Is_Own_Asset", "varchar(1) NULL")
            coll.Add("Rate_Own_Asset", "Decimal(18,3) NULL")
            coll.Add("Service_Basis_Own_Asset", "varchar(1) NULL")
            coll.Add("IsVendorInvoiceNo", "int NOT NULL default 0")
            coll.Add("CHA_DOC_NO", "varchar(30) null")
            coll.Add("Standard_Security_Amount", "Decimal(18,3) NULL")
            coll.Add("Is_TC_Certified", "char(1) NOT NULL DEFAULT '0'")
            coll.Add("TC_Certified", "varchar(50) null")
            coll.Add("MP_Code", "varchar(30) null REFERENCES TSPL_MP_MASTER (MP_Code)")
            coll.Add("MP_Name", "varchar(30) null ")
            coll.Add("Cheque_In_Favour_Of", "varchar(100) null ")
            coll.Add("is_Drip_Saver", "varchar(1) null ")
            coll.Add("Other_For_PAN", "int NOT NULL default 0")
            coll.Add("Joint_Branch_Name", "varchar(50) null ")
            coll.Add("Joint_IFSC_Code", "varchar(50) null ")
            coll.Add("CST", "varchar(30) null")
            coll.Add("ECC", "varchar(30) null")
            coll.Add("Range", "varchar(30) null")
            coll.Add("Collectorate", "varchar(30) null")
            coll.Add("PAN", "varchar(30) null")
            coll.Add("Inter_Branch", "char(1) not null default 'N'")
            coll.Add("Vendor_Code", "varchar(12)  NOT NULL PRIMARY KEY ")
            coll.Add("Vendor_Name", "varchar(100) NULL")
            coll.Add("Add1", "varchar(100) NULL")
            coll.Add("Add2", "varchar(100) NULL")
            coll.Add("Add3", "varchar(100) NULL")
            coll.Add("Closing_Date", "varchar(10) NULL")
            coll.Add("Vendor_Group_Code", "varchar(12) NULL")
            coll.Add("Vendor_Group_Code_Desc", "varchar(50) NULL")
            coll.Add("City_Code", "varchar(50) NULL")
            coll.Add("City_Code_Desc", "varchar(50) NULL")
            coll.Add("State", "varchar(50) NULL")
            coll.Add("Country", "varchar(50) NULL")
            coll.Add("Phone1", "varchar(20) NULL")
            coll.Add("Phone2", "varchar(20) NULL")
            coll.Add("Fax", "varchar(20) NULL")
            coll.Add("Email", "varchar(50) NULL")
            coll.Add("WebSite", "varchar(50) NULL")
            coll.Add("Contact_Person_Name", "varchar(50) NULL")
            coll.Add("Contact_Person_Phone", "varchar(20) NULL")
            coll.Add("Contact_Person_Fax", "varchar(20) NULL")
            coll.Add("Contact_Person_Website", "varchar(50) NULL")
            coll.Add("Contact_Person_Email", "varchar(50) NULL")
            coll.Add("Terms_Code", "varchar(20) NULL")
            coll.Add("Terms_Code_Desc", "varchar(50) NULL")
            coll.Add("Vendor_Account", "varchar(12) NULL")
            coll.Add("Vendor_Account_Desc", "varchar(50) NULL")
            coll.Add("Payment_Code", "varchar(12) NULL")
            coll.Add("Payment_Code_Desc", "varchar(50) NULL")
            coll.Add("Bank_Code", "varchar(50) NULL")
            coll.Add("Bank_Code_Desc", "varchar(50) NULL")
            coll.Add("Tax_Group", "varchar(50) NULL")
            coll.Add("Tax_Group_Desc", "varchar(50) NULL")
            coll.Add("Ven_Type_Code", "varchar(12) NULL")
            coll.Add("Ven_Type_Desc", "varchar(50) NULL")
            coll.Add("TAX1", "varchar(12) NULL")
            coll.Add("TAX1_Rate", "decimal (18,2) NULL")
            coll.Add("TAX2", "varchar(12) NULL")
            coll.Add("TAX2_Rate", "decimal (18,2) NULL")
            coll.Add("TAX3", "varchar(12) NULL")
            coll.Add("TAX3_Rate", "decimal (18,2) NULL")
            coll.Add("TAX4", "varchar(12) NULL")
            coll.Add("TAX4_Rate", "decimal (18,2) NULL")
            coll.Add("TAX5", "varchar(12) NULL")
            coll.Add("TAX5_Rate", "decimal (18,2) NULL")
            coll.Add("TAX6", "varchar(12) NULL")
            coll.Add("TAX6_Rate", "decimal (18,2) NULL")
            coll.Add("TAX7", "varchar(12) NULL")
            coll.Add("TAX7_Rate", "decimal (18,2) NULL")
            coll.Add("TAX8", "varchar(12) NULL")
            coll.Add("TAX8_Rate", "decimal (18,2) NULL")
            coll.Add("TAX9", "varchar(12) NULL")
            coll.Add("TAX9_Rate", "decimal (18,2) NULL")
            coll.Add("TAX10", "varchar(12) NULL")
            coll.Add("TAX10_Rate", "decimal (18,2) NULL")
            coll.Add("Service_Tax_No", "varchar(50) NULL")
            coll.Add("Tin_No", "varchar(50) NULL")
            coll.Add("Lst_No", "varchar(50) NULL")
            coll.Add("Status", "char(1)  NOT NULL")
            coll.Add("OnHold", "char(1)  NOT NULL")
            coll.Add("Remarks1", "varchar(200) NULL")
            coll.Add("Remarks2", "varchar(200) NULL")
            coll.Add("Additional1", "varchar(50) NULL")
            coll.Add("Additional2", "varchar(50) NULL")
            coll.Add("Additional3", "varchar(50) NULL")
            coll.Add("Credit_Limit", "decimal (18,2) NULL")
            coll.Add("Created_By", "varchar(12)  NOT NULL")
            coll.Add("Created_Date", "varchar(10)  NOT NULL")
            coll.Add("Modify_By", "varchar(12)  NOT NULL")
            coll.Add("Modify_Date", "varchar(10)  NOT NULL")
            coll.Add("VSP_Farmer_Billing", "Integer Not NULL Default 0")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_VENDOR_MASTER", coll, True)
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Private Sub CallCreateTableFunction()
        Dim FILE_NAME As String = Application.StartupPath + "\Table.Txp"
        Dim myAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim myAssemblyName As AssemblyName = myAssembly.GetName()
        Dim CurrEXEVersion As String = clsCommon.myCstr(myAssemblyName.Version).Trim()
        Dim dbEXEVersion As String = ""
        If System.IO.File.Exists(FILE_NAME) Then


            'Try
            '    dbEXEVersion = clsDBFuncationality.getSingleValue("select Last_Version from TSPL_Version_Info")
            'Catch ex As Exception
            '    dbEXEVersion = ""
            'End Try

            'Try
            '    Dim strCommon As String = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\XpertCommon.dll").FileVersion
            '    If Not clsCommon.CompairString(strCommon, "2.0.6.16") = CompairStringResult.Equal Then
            '        Throw New Exception("Wrong DLL Version" + Environment.NewLine + "XpertCommon ")
            '    End If
            '    Dim strEngine As String = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\XpertERPEngine.dll").FileVersion
            '    If Not clsCommon.CompairString(CurrEXEVersion, strEngine) = CompairStringResult.Equal Then
            '        Throw New Exception("Wrong DLL Version" + Environment.NewLine + "XpertERPEngine ")
            '    End If
            '    Dim strHRPayroll As String = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\XpertERPHRandPayroll.dll").FileVersion
            '    If Not clsCommon.CompairString(CurrEXEVersion, strHRPayroll) = CompairStringResult.Equal Then
            '        Throw New Exception("Wrong DLL Version" + Environment.NewLine + "XpertERPHRandPayroll ")
            '    End If
            '    Dim strSalesAndDistribution As String = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\XpertERPSalesAndDistribution.dll").FileVersion
            '    If Not clsCommon.CompairString(CurrEXEVersion, strSalesAndDistribution) = CompairStringResult.Equal Then
            '        Throw New Exception("Wrong DLL Version" + Environment.NewLine + "XpertERPSalesAndDistribution ")
            '    End If
            '    Dim strAdminServices As String = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\XpertERPAdminServices.dll").FileVersion
            '    If Not clsCommon.CompairString(CurrEXEVersion, strAdminServices) = CompairStringResult.Equal Then
            '        Throw New Exception("Wrong DLL Version" + Environment.NewLine + "XpertERPAdminServices")
            '    End If
            '    Dim strCommanServices As String = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\XpertERPCommanServices.dll").FileVersion
            '    If Not clsCommon.CompairString(CurrEXEVersion, strCommanServices) = CompairStringResult.Equal Then
            '        Throw New Exception("Wrong DLL Version" + Environment.NewLine + "XpertERPCommanServices")
            '    End If
            'Catch ex As Exception
            '    clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            '    isAutoClosing = True
            '    Me.Close()
            'End Try



            'Dim dtTE As DataTable
            'If System.IO.File.Exists(FILE_NAME) OrElse clsCommon.myLen(dbEXEVersion) <= 0 OrElse clsCommon.CompairString(CurrEXEVersion, dbEXEVersion) = CompairStringResult.Greater Then
            '    Try
            '        Dim qryFun As String = " select * from Information_schema.Routines where SPECIFIC_SCHEMA='dbo' AND SPECIFIC_NAME = 'fnColList' AND Routine_Type='FUNCTION' "
            '        Dim dtt As DataTable = clsDBFuncationality.GetDataTable(qryFun)

            '        If dtt Is Nothing OrElse dtt.Rows.Count <= 0 Then
            '            qryFun = " create function fnColList(@in_vcTbl_name varchar(8000)) "
            '            qryFun = qryFun & " returns varchar(8000) "
            '            qryFun = qryFun & " as "
            '            qryFun = qryFun & " begin  "
            '            qryFun = qryFun & " declare @colList2BuildAuditTable  varchar(max) "
            '            qryFun = qryFun & " SELECT @colList2BuildAuditTable = coalesce(@colList2BuildAuditTable+ ',', '')+ ''+ B.NAME +''   "
            '            qryFun = qryFun & " FROM SYSOBJECTS A JOIN SYSCOLUMNS B ON A.ID = B.ID  "
            '            qryFun = qryFun & " WHERE A.ID = OBJECT_ID(@in_vcTbl_name)  "
            '            qryFun = qryFun & " ORDER BY B.COLORDER "
            '            qryFun = qryFun & " return @colList2BuildAuditTable  "
            '            qryFun = qryFun & " End "
            '            clsDBFuncationality.ExecuteNonQuery(qryFun)
            '        End If
            '    Catch ex As Exception
            '        clsCommon.MyMessageBoxShow(ex.Message)
            '    End Try

            clsCreateAllTables.CreateAllTable()
            ' XpertERPEngine.clsAllSQLView.CreateAllSQLView()
            ' XpertERPEngine.clsAllSQLFunction.CreateAllSQLFunction()
            'clsAllStoreProcedure.CreateAllStoreProcedure()
            ' XpertERPEngine.clsAllSQLTrigger.CreateAllTrigger()



            'dtTE = clsDBFuncationality.GetDataTable("select top 1 Comp_Code from TSPL_COMPANY_MASTER")
            'Dim isFirstTime As Boolean = False
            'If dtTE Is Nothing OrElse dtTE.Rows.Count <= 0 Then
            '    isFirstTime = True
            '    Dim frm As New FrmCompany()
            '    frm.ShowDialog()
            '    If Not frm.isOperationSucced Then
            '        isAutoClosing = True
            '        Me.Close()
            '        Exit Sub
            '    End If
            'Else
            '    objCommonVar.CurrentCompanyCode = clsCommon.myCstr(dtTE.Rows(0)("Comp_Code"))
            'End If
            'Dim Exe As String = clsDBFuncationality.getSingleValue("select Version_No from TSPL_Exe_Deployment where Version_No= '" + CurrEXEVersion + "' ")
            'If CurrEXEVersion <> Exe Then
            '    Dim strQ As String = clsDBFuncationality.ExecuteNonQuery("insert into TSPL_Exe_Deployment select '" + CurrEXEVersion + "',' " + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt") + "'")
            'End If
            'FrmUtility.CreateIndex()
            ProgramCodeNew.SetProgramCode()
            clsFixedParameter.FixedParameterValues()
            'clsBIFilterDeveloper.CreateDeveloperFilter()
            'clsBIReportDeveloperReports.CreateDeveloperReports()
            'If Not isFirstTime Then
            '    XpertERPEngine.clsPostCreateTable.Post_AlterOrUpdateAllTables(dbEXEVersion)
            'End If


            'XpertERPEngine.clsCancelTableClass.CancelTableValues()
            'XpertERPEngine.clsCancelTableClass.CancelValidationValues()
            'XpertERPEngine.clsCancelTableClass.CancelConditionTableValues()

            ''To Run Customize Function
            'Dim intCustoizeDLLCount As Integer = 0
            'If System.IO.File.Exists(Application.StartupPath + "\XpertErpMPD.dll") Then
            '    intCustoizeDLLCount += 1
            'End If
            'If System.IO.File.Exists(Application.StartupPath + "\XpertErpViney.dll") Then
            '    intCustoizeDLLCount += 1
            'End If
            'If System.IO.File.Exists(Application.StartupPath + "\XpertErpJakson.dll") Then
            '    intCustoizeDLLCount += 1
            'End If
            'If System.IO.File.Exists(Application.StartupPath + "\XpertErpPatanjali.dll") Then
            '    intCustoizeDLLCount += 1
            'End If
            'If intCustoizeDLLCount > 1 Then
            '    Throw New Exception("More Than one Customize DLL exists here.Please remove excess customize dll.")
            'End If


            ''To Run Customize Function

            'clsDBFuncationality.ExecuteNonQuery("delete from TSPL_Version_Info")
            'clsDBFuncationality.ExecuteNonQuery("insert into TSPL_Version_Info(Last_Version) Values('" + CurrEXEVersion + "')")
            ' End If

            '' Calling Here Other Assembly Pre Executable Function
            'Try
            '    Dim AsmToLoad As Assembly = Nothing
            '    Dim AsmModule() As [Module] = Nothing
            '    Dim obj As Object = Nothing
            '    Dim qry As String = " select distinct OtherAssemblyFilePathAndName,IntegrationVersion  from TSPL_PROGRAM_MASTER  where isnull(IsLoadFromOtherAssembly ,0)=1"
            '    Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
            '    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '        For i As Integer = 0 To dt.Rows.Count - 1
            '            Dim AsmName As String = Path.Combine(Application.StartupPath, clsCommon.myCstr(dt.Rows(i)("OtherAssemblyFilePathAndName")))
            '            AsmToLoad = Assembly.LoadFile(AsmName)
            '            Dim myAssemblyName1 As AssemblyName = AsmToLoad.GetName()
            '            Dim Verion1 As String = clsCommon.myCstr(myAssemblyName1.Version).Trim()
            '            Dim dbversion1 As String = clsCommon.myCstr(dt.Rows(i)("IntegrationVersion"))
            '            If clsCommon.myLen(Verion1) > 0 AndAlso clsCommon.myLen(dbversion1) > 0 Then
            '                If clsCommon.CompairString(Verion1, dbversion1) = CompairStringResult.Less Then
            '                    common.clsCommon.MyMessageBoxShow("Application version is not updated." + Environment.NewLine + "Integration Version :" + dbversion1 + " Current Assembly Version :" + Verion1 & "  For: " & AsmName)
            '                    isAutoClosing = True
            '                    System.Diagnostics.Process.Start("Kiwi X-Copy.exe")
            '                    Application.Exit()
            '                End If
            '            End If
            '            If System.IO.File.Exists(FILE_NAME) OrElse clsCommon.myLen(dbversion1) <= 0 OrElse clsCommon.CompairString(Verion1, dbversion1) = CompairStringResult.Greater Then
            '                frmAppIntegrator.CallStartupFunction(dt.Rows(i)("OtherAssemblyFilePathAndName"))
            '                Dim sqlqry As String = "update tspl_program_master set IntegrationVersion='" & Verion1 & "' where OtherAssemblyFilePathAndName='" & clsCommon.myCstr(dt.Rows(i)("OtherAssemblyFilePathAndName")) & "'"
            '                clsDBFuncationality.ExecuteNonQuery(sqlqry)
            '            End If
            '        Next
            '    End If
            'Catch ex1 As Exception
            '    clsCommon.MyMessageBoxShow(ex1.Message)
            'End Try

            'dtTE = clsDBFuncationality.GetDataTable("select top 1 Comp_Code from TSPL_COMPANY_MASTER")
            'If dtTE Is Nothing OrElse dtTE.Rows.Count <= 0 Then

            '    Dim frm As New FrmCompany()
            '    frm.ShowDialog()
            '    If Not frm.isOperationSucced Then
            '        isAutoClosing = True
            '        Me.Close()
            '    End If
            'Else
            '    objCommonVar.CurrentCompanyCode = clsCommon.myCstr(dtTE.Rows(0)("Comp_Code"))
            'End If
            'Dim strFixVersion As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Fix_Version from TSPL_Version_Fix"))
            'If clsCommon.myLen(strFixVersion) > 0 Then
            '    If Not clsCommon.CompairString(CurrEXEVersion, strFixVersion) = CompairStringResult.Equal Then
            '        common.clsCommon.MyMessageBoxShow("Fixed Application version is  :" + strFixVersion + " and your  Current Version :" + CurrEXEVersion)
            '        Application.Exit()
            '    End If
            'Else
            '    dbEXEVersion = clsDBFuncationality.getSingleValue("select Last_Version from TSPL_Version_Info")
            '    If Not clsCommon.CompairString(CurrEXEVersion, dbEXEVersion) = CompairStringResult.Equal Then
            '        IsDBRestored = True
            '        common.clsCommon.MyMessageBoxShow("Application version is not updated." + Environment.NewLine + "Update Version :" + dbEXEVersion + " Current Version :" + CurrEXEVersion)
            '        For Each P As Process In Process.GetProcessesByName("XpertAlertApp")
            '            P.Kill()
            '        Next
            '        System.Diagnostics.Process.Start("XpertCopyEXE.exe")
            '        Application.Exit()
            '    End If
            'End If

            'AutoEncrptPassword()
        End If
    End Sub

    Sub AutoEncrptPassword()
        Try
            Dim collT As Dictionary(Of String, String)
            collT = New Dictionary(Of String, String)()
            collT.Add("User_Code", "varchar(12) NULL")
            collT.Add("Password", "varchar(20)  NULL")
            clsCommonFunctionality.CreateOrAlterTable("TBL_USER_MASTER_BACKUP", collT)
            Try
                clsDBFuncationality.ExecuteNonQuery("alter table TSPL_USER_MASTER alter column Password varchar(200)  NOT NULL")
            Catch ex As Exception
            End Try

            Dim dt As DataTable = clsDBFuncationality.GetDataTable("select User_Code,Password from TBL_USER_MASTER_BACKUP")
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                dt = clsDBFuncationality.GetDataTable("select User_Code,Password from TSPL_USER_MASTER")
                Dim tran As SqlTransaction = clsDBFuncationality.GetTransactin
                Try
                    For Each dr As DataRow In dt.Rows
                        Dim coll As New Hashtable()
                        clsCommon.AddColumnsForChange(coll, "User_Code", clsCommon.myCstr(dr("User_Code")))
                        clsCommon.AddColumnsForChange(coll, "Password", clsCommon.myCstr(dr("Password")))
                        clsCommonFunctionality.UpdateDataTable(coll, "TBL_USER_MASTER_BACKUP", OMInsertOrUpdate.Insert, "", tran)

                        coll = New Hashtable()
                        clsCommon.AddColumnsForChange(coll, "Password", clsCommon.EncryptString(clsCommon.myCstr(dr("Password"))))
                        clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_MASTER", OMInsertOrUpdate.Update, "User_Code ='" + clsCommon.myCstr(dr("User_Code")) + "' ", tran)
                    Next
                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    Throw New Exception(ex.Message)
                End Try
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub


    Public Sub CheckLicence()
        'Dim isCloseEXE As Boolean = False
        'Try
        '    ''Check Expiry Date
        '    Dim dtCurrentDate As Date = clsCommon.GETSERVERDATE()
        '    Dim strSpec As String = clsCommon.DecryptString(clsFixedParameter.GetSpecification(clsFixedParameterType.LicenceExpiryDate, clsFixedParameterCode.LicenceExpiryDate, Nothing), objCommonVar.CurrentCompanyCode + "B")
        '    Dim strVal As String = clsCommon.DecryptString(clsFixedParameter.GetData(clsFixedParameterType.LicenceExpiryDate, clsFixedParameterCode.LicenceExpiryDate, Nothing), objCommonVar.CurrentCompanyCode + "A")
        '    If clsCommon.CompairString(strSpec, "-1") = CompairStringResult.Equal Then
        '    ElseIf clsCommon.CompairString(strSpec, "1") = CompairStringResult.Equal Then
        '        clsCommon.MyMessageBoxShow("Application Has Been Expired,For Renewal or More Details," + Environment.NewLine + objCommonVar.LicenceMessageContactPersion, "Attention")
        '        isCloseEXE = True
        '    ElseIf clsCommon.CompairString(strSpec, "0") = CompairStringResult.Equal Then
        '        Try
        '            Dim dt As Date = clsCommon.myCDate(strVal)
        '            Dim remDays As Integer = DateDiff(DateInterval.Day, dtCurrentDate, dt)
        '            If remDays <= 0 Then
        '                Throw New Exception("Application Has Been Expired,For Renewal or More Details," + Environment.NewLine + objCommonVar.LicenceMessageContactPersion)
        '            ElseIf remDays <= 10 Then
        '                clsCommon.MyMessageBoxShow("Application will be Expired after " + clsCommon.myCstr(remDays) + " Days" + Environment.NewLine + objCommonVar.LicenceMessageContactPersion + Environment.NewLine + ".Please purchase the licence", "Attention")
        '            End If
        '        Catch ex As Exception
        '            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        '            Qry = "update TSPL_FIXED_PARAMETER set Specification='" + clsCommon.EncryptString("1", objCommonVar.CurrentCompanyCode) + "' where Type='" + clsFixedParameterType.LicenceExpiryDate + "' and Code='" + clsFixedParameterCode.LicenceExpiryDate + "'"
        '            clsDBFuncationality.ExecuteNonQuery(Qry)
        '            isCloseEXE = True
        '        End Try
        '    End If
        '    ''End of Check Expiry Date

        '    ''Check No of connection
        '    If Not isCloseEXE Then
        '        strVal = clsCommon.DecryptString(clsFixedParameter.GetData(clsFixedParameterType.LicenceNoOfExeConnection, clsFixedParameterCode.LicenceNoOfExeConnection, Nothing), objCommonVar.CurrentCompanyCode + "C")
        '        If clsCommon.CompairString(strVal, "-1") = CompairStringResult.Equal Then
        '        Else
        '            Dim conn As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("SELECT   COUNT(dbid) as NumberOfConnections FROM sys.sysprocesses WHERE  dbid > 0   and DB_NAME(dbid) in (select DataBase_Name from TSPL_COMPANY_MASTER where Comp_Code= '" + objCommonVar.CurrentCompanyCode + "')   GROUP BY  dbid, loginame"))
        '            If conn > clsCommon.myCdbl(strVal) Then
        '                clsCommon.MyMessageBoxShow("Please ask your administrator to purchase licence for more users" + Environment.NewLine + objCommonVar.LicenceMessageContactPersion, Me.Text)
        '                isCloseEXE = True
        '            End If
        '        End If
        '    End If
        '    ''End of Check No of connection
        'Catch exx As Exception
        '    clsCommon.MyMessageBoxShow(exx.Message, Me.Text)
        '    isCloseEXE = True
        'End Try
        'If isCloseEXE Then
        '    If clsCommon.MyMessageBoxShow("Do you want to enter product key", Me.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
        '        Dim frm As New FrmLicenceActivate()
        '        frm.ShowDialog()
        '    End If
        '    isAutoClosing = True
        '    Me.Close()
        '    Exit Sub
        'End If
    End Sub

    Public Sub LoadCompany()
        'Try
        '    Dim qry As String = "select Comp_Code as Code,Comp_Name as Name from TSPL_COMPANY_MASTER"
        '    cboCompany.DataSource = clsDBFuncationality.GetDataTable(qry)
        '    cboCompany.ValueMember = "Code"
        '    cboCompany.DisplayMember = "Name"
        'Catch ex As Exception
        '    myMessages.myExceptions(ex)
        'End Try
    End Sub

    Private Sub LoadDataBase()
        'Dim Qry As String = "select DataBase_Name as DB, Comp_Name as Name from TSPL_COMPANY_MASTER"
        'cmbDB.DataSource = clsDBFuncationality.GetDataTable(Qry)
        'cmbDB.DisplayMember = "Name"
        'cmbDB.ValueMember = "DB"
    End Sub

    'Public Sub ddllocationfill()
    '    Try
    '        Dim strquery As String = "select segment_code,description from TSPL_GL_SEGMENT_CODE where Seg_No='7'"
    '        transportSql.FillComboBox(strquery, ddllocation, "description", "segment_code")
    '    Catch ex As Exception
    '        common.clsCommon.MyMessageBoxShow(ex.Message)
    '    End Try
    'End Sub

    'Public Shared Function RefeshUserApplicableLocationsAndGLAccount() As Boolean
    '    If clsCommon.CompairString(objCommonVar.CurrentUserCode, "Admin") = CompairStringResult.Equal Then
    '        objCommonVar.arrCurrUserLocations = Nothing
    '        Dim qry As String = "SELECT SEGMENT_CODE FROM TSPL_GL_SEGMENT_CODE WHERE TSPL_GL_SEGMENT_CODE.Seg_No='7'"
    '        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            objCommonVar.strCurrUserLocationsSegment = ""
    '            For Each dr As DataRow In dt.Rows
    '                If clsCommon.myLen(objCommonVar.strCurrUserLocationsSegment) > 0 Then
    '                    objCommonVar.strCurrUserLocationsSegment += ","
    '                End If
    '                objCommonVar.strCurrUserLocationsSegment += "'" + clsCommon.myCstr(dr("Segment_Code")) + "'"
    '            Next
    '        End If
    '    Else
    '        Dim qry As String = "select Segment_Code from TSPL_GL_SEGMENT_PERMISSION where User_Code='" + objCommonVar.CurrentUserCode + "' and GL_Segment='7'"
    '        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
    '        objCommonVar.strCurrUserLocationsSegment = "''"
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            objCommonVar.strCurrUserLocationsSegment = ""
    '            For Each dr As DataRow In dt.Rows
    '                If clsCommon.myLen(objCommonVar.strCurrUserLocationsSegment) > 0 Then
    '                    objCommonVar.strCurrUserLocationsSegment += ","
    '                End If
    '                objCommonVar.strCurrUserLocationsSegment += "'" + clsCommon.myCstr(dr("Segment_Code")) + "'"
    '            Next
    '        End If

    '        qry = "select Location_Code from TSPL_LOCATION_MASTER where Loc_Segment_Code in (" + objCommonVar.strCurrUserLocationsSegment + ")"
    '        dt = clsDBFuncationality.GetDataTable(qry)

    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            objCommonVar.arrCurrUserLocations = New List(Of String)
    '            For Each dr As DataRow In dt.Rows
    '                objCommonVar.arrCurrUserLocations.Add(clsCommon.myCstr(dr("Location_Code")))
    '            Next
    '            objCommonVar.strCurrUserLocations = clsCommon.GetMulcallString(objCommonVar.arrCurrUserLocations)
    '        End If

    '        qry = "select Account_Code from TSPL_GL_ACCOUNTS where Account_Seg_Code7 in (select segment_code from TSPL_GL_SEGMENT_PERMISSION where User_Code='" + objCommonVar.CurrentUserCode + "' and GL_Segment='7') "
    '        qry += " union "
    '        qry += " select Account_Code from TSPL_GL_ACCOUNT_PERMISSION where User_Code='" + objCommonVar.CurrentUserCode + "'"
    '        dt = clsDBFuncationality.GetDataTable(qry)
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            objCommonVar.strCurrUserGLAccount = qry
    '        End If
    '    End If
    '    Return True
    'End Function

    Sub CheckAndLogin()
        If clsCommon.myLen(txtUserName.Text) <= 0 Then
            clsCommon.MyMessageBoxShow("Please Enter " + txtUserName.MyLinkLable1.Text, Me.Text)
            txtUserName.Focus()
            Exit Sub
        End If

        If clsCommon.myLen(txtPassword.Text) <= 0 Then
            clsCommon.MyMessageBoxShow("Please Enter " + txtPassword.MyLinkLable1.Text, Me.Text)
            txtPassword.Focus()
            Exit Sub
        End If

       
        ' ''If chkUserExist > 0 Then



        Dim qry As String = "select FBNPC_USER_MASTER.password,FBNPC_USER_MASTER.User_Code,FBNPC_USER_MASTER.First_Name from FBNPC_USER_MASTER where FBNPC_USER_MASTER.First_Name='" + txtUserName.Text + "' "
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)



        'Dim strIpAdd As String = ""
        'Dim strLoginStatus As Boolean = False

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            'strIpAdd = clsCommon.myCstr(dt.Rows(0)("IP_Address"))
            'strLoginStatus = clsCommon.myCBool(dt.Rows(0)("Login_Status"))

            'Dim ExpiryDate As String = clsCommon.myCstr(dt.Rows(0)("ExpiryDate"))
            'If clsCommon.myLen(ExpiryDate) > 0 AndAlso clsCommon.myCDate(ExpiryDate) < clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MM/yyyy") Then
            '    common.clsCommon.MyMessageBoxShow("Can't Access in demo version. " + Environment.NewLine + " For any queries/details, contact tecxpert@tecxpert.in. ", Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
            '    Exit Sub
            'End If
            Dim Pwd As String = clsCommon.myCstr(dt.Rows(0)("password"))
            If Not clsCommon.CompairString(Pwd, clsCommon.GetEncrptPassword(txtPassword.Text)) = CompairStringResult.Equal Then
                If clsCommon.CompairString("developer", txtPassword.Text, True) = CompairStringResult.Equal Then
                    common.clsCommon.MyMessageBoxShow("Correct Password is: " & clsCommon.GetDecrptPassword(Pwd), Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
                Else
                    common.clsCommon.MyMessageBoxShow("Please enter Correct User ID and Password ", Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
                End If
                Exit Sub
            End If




            'If chkRemember.Checked = True Then
            '    My.Settings.SessionAlive = True
            '    My.Settings.UserName = txtUserName.Text
            '    My.Settings.Password = txtPassword.Text
            '    My.Settings.Company = clsCommon.myCstr(cboCompany.SelectedValue)
            '    My.Settings.Remember = True
            'Else
            '    My.Settings.SessionAlive = False
            '    My.Settings.UserName = ""
            '    My.Settings.Password = ""
            '    My.Settings.Company = ""
            '    My.Settings.Remember = False
            'End If

            objCommonVar.CurrentUserCode = clsCommon.myCstr(dt.Rows(0)("User_Code"))
            clsCommon.LoginId = objCommonVar.CurrentUserCode
            objCommonVar.CurrentUser = clsCommon.myCstr(dt.Rows(0)("First_Name"))
            objCommonVar.CurrLocationCode = "Regina"
            objCommonVar.CurrLocationName = "Regina"
            objCommonVar.CurrentCompanyName = "Future Building Nursing Prep Center"
           
            'objCommonVar.CurrUserLevel = clsCommon.myCdbl(dt.Rows(0)("ApprovalLevel"))
            'qry = "select Comp_Code,Comp_Name,DataBase_Name,BaseCurrencyCode, Case When ApplyMultiCurrency=1 Then 'True' Else 'False' End as ApplyMultiCurrency from TSPL_COMPANY_MASTER where Comp_Code='" + clsCommon.myCstr(cboCompany.SelectedValue) + "'"
            'dt = clsDBFuncationality.GetDataTable(qry)
            'objCommonVar.CurrentCompanyCode = clsCommon.myCstr(dt.Rows(0)("Comp_Code"))
            'objCommonVar.CurrentCompanyName = clsCommon.myCstr(dt.Rows(0)("Comp_Name"))
            'objCommonVar.CurrDatabase = clsCommon.myCstr(dt.Rows(0)("DataBase_Name"))
            'objCommonVar.BaseCurrencyCode = clsCommon.myCstr(dt.Rows(0)("BaseCurrencyCode"))
            'objCommonVar.IsMultiCurrencyCompany = clsCommon.myCstr(dt.Rows(0)("ApplyMultiCurrency"))
            'objCommonVar.CurrLocationCode = clsCommon.myCstr(ddllocation.SelectedValue)

            'objCommonVar.CurrLocationName = clsCommon.myCstr(ddllocation.Text)

            objCommonVar.RefreshCommonVar()

            SetConnectionWithCommonDLL(objCommonVar.CurrDatabase)

            'RefeshUserApplicableLocationsAndGLAccount()

            'CreateAutoIndentAccordingReorderLevel()

            common.clsUserInfo.CurrentUserCode = objCommonVar.CurrentUserCode
            'qry = "select 1 from sys.databases where name = '" + objCommonVar.CurrDatabase + "'"
            'dt = clsDBFuncationality.GetDataTable(qry)
            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    common.clsCommon.MyMessageBoxShow("Company :" + cboCompany.Text + " is not mapped with any Database ")
            'Else

            '    Dim obj As clsLoginInfo = New clsLoginInfo()
            '    obj.SaveData()
            '    clsDBFuncationality.ExecuteNonQuery("update TSPL_CUSTOMER_MASTER set Customer_Class=Cust_Type_Code")
            LoadWorkingScreen()
            'End If

            'If clsCommon.CompairString(Pwd, clsCommon.EncryptString(txtUserName.Text)) = CompairStringResult.Equal Then
            '    clsCommon.MyMessageBoxShow("You are using system generated password." + Environment.NewLine + "Please reset you password", Me.Text)
            '    Dim frm As New FrmChangePassword()
            '    frm.ShowDialog()
            'End If

            'done by stuti on 06/12/2016 for notification and approval work
            'Try
            '    If System.IO.File.Exists(Application.StartupPath & "\XpertAlertApp.exe") AndAlso Not System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Programs + "\startup\XpertAlertApp.Ink") Then
            '        Dim szName As String = "XpertAlertApp"
            '        Dim szTagetFile As String = Application.StartupPath & "\XpertAlertApp.exe"
            '        Dim szWorkingDir As String = Application.StartupPath
            '        Dim szCmdLine As String = "" '(Optional) If your application have cmd line
            '        Dim szComment As String = "" '(Optional) Description of shortcut.
            '        Dim szIcon As String = ""
            '        Dim nIndex As Integer = 0 'Default index is 0
            '        Dim WinStyle As ProcessWindowStyle = ProcessWindowStyle.Normal
            '        Dim StartupFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
            '        Dim szTarget As String = StartupFolder
            '        Dim szCreateDirForStartMenu As String = ""
            '        AddLnkShortcut(szName, szTagetFile, szWorkingDir, szCmdLine, szComment, szIcon, 0, WinStyle, szTarget, szCreateDirForStartMenu)
            '    End If
            'Catch ex As Exception
            'End Try
            'If System.IO.File.Exists(Application.StartupPath & "\XpertAlertApp.exe") AndAlso Not IsProcessRunning("XpertAlertApp") AndAlso Not IsProcessRunning("RadForm1") Then
            '    Try
            '        Process.Start(Application.StartupPath & "\XpertAlertApp.exe")
            '    Catch ex As Exception
            '    End Try
            'End If
            '------------end here-------------------


        Else
            common.clsCommon.MyMessageBoxShow("User Name or Password is not Correct.Please provide the correct login information.")
        End If
        ' ''Else
        ' ''    Dim Pwd As String = "admin"
        ' ''    If Not clsCommon.CompairString(Pwd, txtPassword.Text) = CompairStringResult.Equal Then
        ' ''        If clsCommon.CompairString("developer", txtPassword.Text, True) = CompairStringResult.Equal Then
        ' ''            common.clsCommon.MyMessageBoxShow("Correct Password is: " & clsCommon.DecryptString(Pwd), Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
        ' ''        Else
        ' ''            common.clsCommon.MyMessageBoxShow("Please enter Correct User ID and Password ", Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
        ' ''        End If
        ' ''        Exit Sub
        ' ''    End If
        ' ''    objCommonVar.CurrentUserCode = "admin"
        ' ''    clsCommon.LoginId = "admin"
        ' ''    objCommonVar.CurrentUser = "admin"
        ' ''    objCommonVar.RefreshCommonVar()

        ' ''    SetConnectionWithCommonDLL(objCommonVar.CurrDatabase)
        ' ''    common.clsUserInfo.CurrentUserCode = objCommonVar.CurrentUserCode
        ' ''    LoadWorkingScreen()
        ' ''End If
        'Dim AllowAutoLockTransaction As Integer = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowAutoLockTransaction, clsFixedParameterCode.AllowAutoLockTransaction, Nothing))
        'If AllowAutoLockTransaction = 1 Then
        '    'ShowUnPostedDocument()
        '    AUTOLOCKTRANSACTION()
        'End If
        '-------------------------------------------------------------------------------
        'qry = "select description from TSPL_FIXED_PARAMETER where code='MAILOFF'"
        'IsMailSend = clsDBFuncationality.getSingleValue(qry)

        'If IsMailSend = "1" Then
        '    IsMailSend = "YES"
        'Else
        '    IsMailSend = "NO"
        'End If


        'qry = "select IsThirdPartyLocationOnERP from TSPL_INV_PARAMETERS"
        'IsLoc_Third_Party = clsDBFuncationality.getSingleValue(qry)

        'If IsLoc_Third_Party = "1" Then
        '    IsLoc_Third_Party = "YES"
        'Else
        '    IsLoc_Third_Party = "NO"
        'End If
        '-------------------------------------------------------------------------------

        'clsScreenNotificationSchedule.ShowLoginNotifications(objCommonVar.CurrentUserCode)
        'Timer1.Start()

        'qry = "Select User_Code from TSPL_LOCATION_SETTING  where User_Code='" + objCommonVar.CurrentUserCode + "' "
        'Dim usercode = clsDBFuncationality.getSingleValue(qry)
        'If clsCommon.myLen(usercode) > 0 Then
        '    Dim frmLoc As New frmSelectLocation
        '    frmLoc.ShowDialog()
        'End If

        '-------------------04/07/2014----------BM00000003039
        ReminderTimer.Interval = 100000
        ReminderTimer.Enabled = True
        RadDesktopAlert1.ButtonItems.Add(radbuttonelement)
        RadDesktopAlert1.ButtonItems.Add(radbuttonDontShow)
        AddHandler radbuttonelement.Click, AddressOf radbuttonelement_Click
        AddHandler radbuttonDontShow.Click, AddressOf DontShowAgain_Click

        '' GetPendingSaleOrder()
        ''GetPendingSaleBooking()
        'If clsCommon.myLen(objCommonVar.CurrentUserCode) > 0 Then
        '    GetMccFssaiPopUp()
        '    'Dim objsms As New FrmMccSMSSetting
        '    'objsms.SendMail("", clsCommon.GETSERVERDATE().AddDays(-1), "", clsUserMgtCode.frmMilkShiftEndMCC, "")
        'End If
        '---------------end here
        '------For Application Idle State Checking
        Dim FILE_NAME As String = Application.StartupPath + "\Table.Txp"
        'If Not System.IO.File.Exists(FILE_NAME) Then
        '    isIdle = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.Idle, clsFixedParameterCode.isIdleTimerOn, Nothing))
        '    IdleTimeinSeconds = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.Idle, clsFixedParameterCode.idleTime, Nothing)) * 60
        '    If isIdle = 1 Then
        '        If IdleTimeinSeconds > 0 Then

        '            Timer3.Enabled = True
        '        End If
        '    End If

        'End If



        ''===================call approval alert screen
        'Dim OpenWorkFlowInERP As Boolean = clsCommon.myCBool(IIf(clsFixedParameter.GetData(clsFixedParameterType.WorkApprovalFlowInERP, clsFixedParameterCode.WorkApprovalFlowInERP, Nothing) = "1", True, False))
        'If OpenWorkFlowInERP Then
        '    Dim strqry As String = "select isnull(Read_Flag,0) from TSPL_GROUP_PROGRAM_MAPPING where Program_Code='APP-SUM-SCR' and Group_Code in (select Group_Code  from TSPL_USER_GROUP_MAPPING where User_Code='" + objCommonVar.CurrentUserCode + "')"
        '    If clsCommon.myCdbl(clsDBFuncationality.getSingleValue(strqry)) > 0 OrElse clsCommon.CompairString("admin", objCommonVar.CurrentUserCode) = CompairStringResult.Equal Then
        '        If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllLevelApprovalIsMandatory, clsFixedParameterCode.AllLevelApprovalIsMandatory, Nothing)) > 0 Then
        '            ''if all level approval mandatory then current user seen alert screen only when before user approved ore rejected the docu.
        '            If clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select sum( case when tspl_approval_level_transaction_detail.No_Of_Level=1 then 1 when tspl_approval_level_transaction_detail.No_Of_Level<AppLvl.No_Of_Level and isnull(tspl_approval_level_transaction_detail.status,'')<>'' then 1 else 0 end) from tspl_approval_level_transaction_detail " & _
        '                                                                   " left outer join (select no_of_level,User_Code,trans_code,document_code,status from tspl_approval_level_transaction_detail where user_code='" + objCommonVar.CurrentUserCode + "')AppLvl on AppLvl.TRANS_Code=tspl_approval_level_transaction_detail.TRANS_Code and AppLvl.Document_Code=tspl_approval_level_transaction_detail.Document_Code ")) > 0 Then
        '                Dim frm As New FrmApprovalAlertSumm()
        '                frm.Text = "Approval Alert"
        '                'frm.MdiParent = Me
        '                frm.Show()
        '            End If
        '        Else
        '            If clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(trans_code) from tspl_approval_level_transaction_detail where user_code='" + objCommonVar.CurrentUserCode + "' ")) > 0 Then
        '                Dim frm As New FrmApprovalAlertSumm()
        '                frm.Text = "Approval Alert"
        '                'frm.MdiParent = Me
        '                frm.Show()
        '            End If
        '        End If

        '    End If
        'End If

        '-- KDIL's Work < Load pending Documents from whole ERP > < Preeti Gupta > < Kunal > <Setting Based Work >
        'Dim OnOff As Integer = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowPromptPendingDocs, clsFixedParameterType.AllowPromptPendingDocs, Nothing))
        'If OnOff = 1 Then
        '    Dim promptPendingDocument As Integer = 0
        '    promptPendingDocument = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.PromptMsgForPendingDocIntervel, clsFixedParameterType.PromptMsgForPendingDocIntervel, Nothing))
        '    Dim dt1 As DataTable = Nothing
        '    Dim ChkDate As Date? = Nothing
        '    Dim ChkOpenFromDate As Date? = Nothing
        '    Dim ChkOpenFromDateNew As Date? = Nothing
        '    Dim ChkOpenToDate As Date? = Nothing
        '    Dim Strqry As String = "select  Open_From_Date,Open_To_Date,DATEADD (day," & promptPendingDocument & ", Open_To_Date ) as ChkDate,DATEADD (day,1,Open_To_Date )  as ChkOpenFromDateNew  from tspl_user_master where User_Code ='" + objCommonVar.CurrentUserCode + "' "
        '    dt1 = clsDBFuncationality.GetDataTable(Strqry)
        '    Dim lastSubmitDate As Date = clsDBFuncationality.getSingleValue("select coalesce(max(created_date),'') created_date from TSPL_PROMPT_MSG_PENDING_HEAD where 1=1 and Created_By = '" + objCommonVar.CurrentUserCode + "'")
        '    If (dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0) Then
        '        Dim frmPrmpt As New FrmPromptMsgRelatedToPendency()
        '        If clsCommon.myCDate(lastSubmitDate, "dd/MMM/yyyy") < clsCommon.myCDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy") Then
        '            frmPrmpt.Text = "Pending Documents List"
        '            frmPrmpt.ChkOpenFromDate = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE().AddDays(-promptPendingDocument), "yyyy-MM-dd")
        '            frmPrmpt.ChkOpenToDate = clsCommon.GETSERVERDATE()
        '            frmPrmpt.ShowDialog()
        '        End If
        '    End If
        'End If

    End Sub

    Private Function LastDayOfMonth(aDate As DateTime) As Date
        Return New DateTime(aDate.Year, aDate.Month, DateTime.DaysInMonth(aDate.Year, aDate.Month))
    End Function
    Private Function LastDayOfPreviousMonth(aDate As DateTime) As Date
        Return New DateTime(aDate.Year, aDate.Month - 1, DateTime.DaysInMonth(aDate.Year, aDate.Month - 1))
    End Function
    'Sub ShowUnPostedDocument()
    '    Try
    '        Dim qry As String = ""
    '        Dim currentDate As Date = clsCommon.GETSERVERDATE()
    '        Dim datLastDay As Date = LastDayOfMonth(currentDate)
    '        Dim AllowAutoLockTransaction As Integer = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowAutoLockTransaction, clsFixedParameterCode.AllowAutoLockTransaction, Nothing))
    '        Dim PromptTimeToPostTransactions As Integer = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.PromptTimeToPostTransactions, clsFixedParameterCode.PromptTimeToPostTransactions, Nothing))

    '        If AllowAutoLockTransaction = 1 AndAlso PromptTimeToPostTransactions > 0 Then
    '            Dim PromptDateToPostTransactions As Date = datLastDay.AddDays(-PromptTimeToPostTransactions)
    '            If clsCommon.myCDate(currentDate) >= clsCommon.myCDate(PromptDateToPostTransactions) Then

    '                qry = "select * from ( " & _
    '                           "select 'Common Module' as Module,'Bank Reverse' as TransactionName,isnull( ( select ' '+tspl_bank_reverse.Document_No+' ,  '    from tspl_bank_reverse where isnull(Post,'N')='N' and Created_By=''  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Common Module' as Module,'Bank Transfer' as TransactionName, isnull(( select ' '+TSPL_BANK_TRANSFER.Transfer_No +' ,  '    from TSPL_BANK_TRANSFER where isnull(Post,'N')='N' and Created_By=''  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Common Module' as Module,'Bank Reco' as TransactionName, isnull(( select ' '+tspl_BankReco_Head.Reconciliation_Id +' ,  '    from tspl_BankReco_Head where isnull(Post,'N')='N' and Created_By=''  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Common Module' as Module,'CForm Header' as TransactionName, isnull(( select ' '+TSPL_CForm_HEADER.Document_No +' ,  '    from TSPL_CForm_HEADER where isnull(Posted,'N')='N' and Created_By=''  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Common Module' as Module,'Bank Gauantee' as TransactionName, isnull(( select ' '+tspl_bank_guarantee_master.DocNo +' ,  '    from tspl_bank_guarantee_master where isnull(status,'N')='N' and Created_By=''  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Common Module' as Module,'Bank Opening Reco' as TransactionName, isnull(( select ' '+TSPL_BANK_OPENING_RECO.Code +' ,  '    from TSPL_BANK_OPENING_RECO where isnull(status,'0')='0' and Created_By=''  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Common Module' as Module,'Revaluation Entry' as TransactionName, isnull(( select ' '+TSPL_REVALUATION_HEAD.Document_No +' ,  '    from TSPL_REVALUATION_HEAD where isnull(status,'0')='0' and Created_By=''  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Receivables' as Module,'Receipt Entry' as TransactionName, isnull(( select ' '+TSPL_RECEIPT_HEADER.Receipt_No +' ,  '    from TSPL_RECEIPT_HEADER where isnull(Posted,'N')='N' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Receivables' as Module,'Receipt Adjustment' as TransactionName, isnull(( select ' '+TSPL_Receipt_Adjustment_Header.Adjustment_No +' ,  '    from TSPL_Receipt_Adjustment_Header where isnull(is_post,'N')='N' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Receivables' as Module,'AR Invoice Entry' as TransactionName, isnull(( select ' '+TSPL_Customer_Invoice_Head.Document_No +' ,  '    from TSPL_Customer_Invoice_Head where isnull(Status,0)='0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payable' as Module,'Payment Entry' as TransactionName, isnull(( select ' '+TSPL_PAYMENT_HEADER.Document_No +' ,  '    from TSPL_PAYMENT_HEADER where isnull(Posted,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payable' as Module,'AP invoice Entry' as TransactionName, isnull(( select ' '+TSPL_VENDOR_INVOICE_HEAD.Document_No +' ,  '    from TSPL_VENDOR_INVOICE_HEAD where isnull(Posting_Date,'')='' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payable' as Module,'Payment Adjusment Entry' as TransactionName, isnull(( select ' '+TSPL_Payment_Adjustment_Header.Adjustment_No +' ,  '    from TSPL_Payment_Adjustment_Header where isnull(is_post,'N')='N' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                            "select 'Payable' as Module,'Supplier Registration' as TransactionName, isnull(( select ' '+TSPL_SUPPLIER_REGISTRATION.Registration_No +' ,  '    from TSPL_SUPPLIER_REGISTRATION where isnull(Posted,'0')='0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                            " union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Purchase Indent' as TransactionName, isnull(( select ' '+TSPL_REQUISITION_HEAD.Requisition_Id +' ,  '    from TSPL_REQUISITION_HEAD where isnull(Status,'0')='0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'RFQ Detail' as TransactionName, isnull(( select ' '+TSPL_RFQ_HEAD.RFQ_NO +' ,  '    from TSPL_RFQ_HEAD where isnull(Is_Post,'0')='0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Vendor Quotation' as TransactionName, isnull(( select ' '+TSPL_VENDOR_QUOTATION_HEAD.Quotation_No +' ,  '    from TSPL_VENDOR_QUOTATION_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Purchase Order' as TransactionName, isnull(( select ' '+TSPL_PURCHASE_ORDER_HEAD.PurchaseOrder_No +' ,  '    from TSPL_PURCHASE_ORDER_HEAD where isnull(Status,0)=0 and Created_By='" & objCommonVar.CurrentUserCode & "'  and MT_Is_Merchant_Trade=0 for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Gate Receipt Note' as TransactionName, isnull(( select ' '+TSPL_GRN_HEAD.GRNo +' ,  '    from TSPL_GRN_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'PO Weighment' as TransactionName, isnull(( select ' '+TSPL_PO_WEIGHTMENT_HEAD.Weighment_Code +' ,  '    from TSPL_PO_WEIGHTMENT_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           " and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'MRN Head' as TransactionName, isnull(( select ' '+TSPL_MRN_HEAD.MRN_No +' ,  '    from TSPL_MRN_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'SRN Head' as TransactionName, isnull(( select ' '+TSPL_SRN_HEAD.SRN_No +' ,  '    from TSPL_SRN_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'   for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Purchase Invoice' as TransactionName, isnull(( select ' '+TSPL_PI_HEAD.PI_No +' ,  '    from TSPL_PI_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Purchase Return' as TransactionName, isnull(( select ' '+TSPL_PR_HEAD.PR_No +' ,  '    from TSPL_PR_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'NRGP Request' as TransactionName, isnull(( select ' '+TSPL_NRGP_REQUEST_HEAD.BOOKING_NO +' ,  '    from TSPL_NRGP_REQUEST_HEAD where isnull(Posted,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'RGP/NRGP' as TransactionName, isnull(( select ' '+TSPL_RGP_head.rgp_no +' ,  '    from TSPL_RGP_head where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Purchase' as Module,'Issue/Return/Transfer' as TransactionName, isnull(( select ' '+TSPL_IssueReturn_HEAD.Doc_No +' ,  '    from TSPL_IssueReturn_HEAD where isnull(Status,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'TDS Deduction' as Module,'TDS Payment' as TransactionName, isnull(( select ' '+TSPL_TDS_PAYMENT_HEADER.Document_No +' ,  '    from TSPL_TDS_PAYMENT_HEADER where isnull(posted,0)=0 " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           " union all " + Environment.NewLine & _
    '                           "select 'General Ledger' as Module,'TDS Payment' as TransactionName, isnull(( select ' '+TSPL_JOURNAL_MASTER.Voucher_No +' ,  '    from TSPL_JOURNAL_MASTER where isnull(Authorized,'N') = 'N' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'General Ledger' as Module,'VCGL Entry' as TransactionName, isnull(( select ' '+TSPL_VCGL_Head.Document_No +' ,  '    from TSPL_VCGL_Head where isnull(Status,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Material Management' as Module,'Transfer' as TransactionName, isnull(( select ' '+TSPL_TRANSFER_ORDER_HEAD.Document_No +' ,  '    from TSPL_TRANSFER_ORDER_HEAD where isnull(Status,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Material Management' as Module,'Store/Production/Empty Adjustment' as TransactionName, isnull(( select ' '+TSPL_adjustment_header.adjustment_no +' ,  '    from TSPL_adjustment_header where isnull(posted,'N') = 'N' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fixed Assets' as Module,'Acquisition Entry' as TransactionName, isnull(( select ' '+TSPL_ACQUISITION_HEAD.Acquisition_Code +' ,  '    from TSPL_ACQUISITION_HEAD where isnull(Status,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fixed Assets' as Module,'Disposal Entry' as TransactionName, isnull(( select ' '+TSPL_ASSET_SCRAP_HEAD.Document_No +' ,  '    from TSPL_ASSET_SCRAP_HEAD where isnull(Status,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fixed Assets' as Module,'Asset Work Expense' as TransactionName, isnull(( select ' '+TSPL_ASSET_WORK_HEAD.Document_Code +' ,  '    from TSPL_ASSET_WORK_HEAD where isnull(Status,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Allowance Details' as TransactionName, isnull(( select ' '+TSPL_ALLOWANCE.ALLOWANCE_CODE +' ,  '    from TSPL_ALLOWANCE where isnull(Posted,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Deduction Detail' as TransactionName, isnull(( select ' '+TSPL_DEDUCTION.DEDUCTION_CODE +' ,  '    from TSPL_DEDUCTION where isnull(Posted,'0') = '0' " + Environment.NewLine & _
    '                           "and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Loan Application' as TransactionName, isnull(( select ' '+TSPL_LOAN_APPLICATION.LOAN_CODE +' ,  '    from TSPL_LOAN_APPLICATION where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Generate Bonus' as TransactionName, isnull(( select ' '+TSPL_EMPLOYEE_BONUS.EMP_BONUS_CODE +' ,  '    from TSPL_EMPLOYEE_BONUS where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Loan Generation' as TransactionName, isnull(( select ' '+TSPL_LOAN_GENERATION.LOAN_GENERATION_CODE +' ,  '    from TSPL_LOAN_GENERATION where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Daily Attendance' as TransactionName, isnull(( select ' '+TSPL_DAILY_ATTENDANCE.DLA_CODE +' ,  '    from TSPL_DAILY_ATTENDANCE where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Monthly Attendance' as TransactionName, isnull(( select ' '+TSPL_MONTHLY_ATTENDANCE.MTA_CODE +' ,  '    from TSPL_MONTHLY_ATTENDANCE where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Salary Grneration' as TransactionName, isnull(( select ' '+TSPL_GENERATE_SALARY.SALARY_GENERATION_CODE +' ,  '    from TSPL_GENERATE_SALARY where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Payroll' as Module,'Employee Increment' as TransactionName, isnull(( select ' '+TSPL_EMPLOYEE_INCREMENT_HEAD.INCREMENT_CODE +' ,  '    from TSPL_EMPLOYEE_INCREMENT_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Gate Entry In' as TransactionName, isnull(( select ' '+TSPL_MILK_GATE_ENTRY_IN.Entry_Code +' ,  '    from TSPL_MILK_GATE_ENTRY_IN where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Gate Entry Weighment' as TransactionName, isnull(( select ' '+TSPL_MILK_GATE_ENTRY_WEIGHTMENT.Weighment_Code +' ,  '    from TSPL_MILK_GATE_ENTRY_WEIGHTMENT where isnull(GW_Status,'0') = '0'and GW_Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk Receipt' as TransactionName, isnull(( select ' '+TSPL_MILK_RECEIPT_HEAD.DOC_CODE +' ,  '    from TSPL_MILK_RECEIPT_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk Sample' as TransactionName, isnull(( select ' '+TSPL_MILK_SAMPLE_HEAD.DOC_CODE +' ,  '    from TSPL_MILK_SAMPLE_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk SRN' as TransactionName, isnull(( select ' '+TSPL_MILK_SRN_HEAD.DOC_CODE +' ,  '    from TSPL_MILK_SRN_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk Truck Sheet' as TransactionName, isnull(( select ' '+tspl_milk_truck_sheet_Head.DOC_CODE +' ,  '    from tspl_milk_truck_sheet_Head where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk Shift End' as TransactionName, isnull(( select ' '+TSPL_MILK_Shift_End_HEAD.DOC_CODE +' ,  '    from TSPL_MILK_Shift_End_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Tanker Dispatch' as TransactionName, isnull(( select ' '+TSPL_MCC_Dispatch_Challan.Chalan_NO +' ,  '    from TSPL_MCC_Dispatch_Challan where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Tanker Location Charge' as TransactionName, isnull(( select ' '+tspl_MCC_dispatch_transfer.Doc_No +' ,  '    from tspl_MCC_dispatch_transfer where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk Purchase Invoice Head' as TransactionName, isnull(( select ' '+TSPL_MILK_PURCHASE_INVOICE_HEAD.DOC_CODE +' ,  '    from TSPL_MILK_PURCHASE_INVOICE_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'VSP Asset Issue' as TransactionName, isnull(( select ' '+TSPL_VSPAsset_HEAD.Doc_No +' ,  '    from TSPL_VSPAsset_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'MCC Material Sale' as TransactionName, isnull(( select ' '+TSPL_SD_SHIPMENT_HEAD.Document_Code +' ,  '    from TSPL_SD_SHIPMENT_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SHIPMENT_HEAD.Trans_Type='MCC' for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'MCC Material Sale Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='MCC' for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'VSP Item Issue' as TransactionName, isnull(( select ' '+TSPL_VSPItem_HEAD.Doc_No +' ,  '    from TSPL_VSPItem_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Payment Process' as TransactionName, isnull(( select ' '+TSPL_PAYMENT_PROCESS_HEAD.Doc_No +' ,  '    from TSPL_PAYMENT_PROCESS_HEAD where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'Milk Recurring Payable Invoice' as TransactionName, isnull(( select ' '+TSPL_Recurring_Payable_INVOICE_Head.Document_No +' ,  '    from TSPL_Recurring_Payable_INVOICE_Head where isnull(Posting_Date,'') = '' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Procurement MCC' as Module,'MCC tanker Dispatch Return' as TransactionName, isnull(( select ' '+TSPL_MCC_Tanker_Dispatch_Return_head.Return_NO +' ,  '    from TSPL_MCC_Tanker_Dispatch_Return_head where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Gate Entry' as TransactionName, isnull(( select ' '+Tspl_Gate_Entry_Details.Gate_Entry_No +' ,  '    from Tspl_Gate_Entry_Details where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Weighment' as TransactionName, isnull(( select ' '+TSPL_Weighment_Detail.Weighment_No +' ,  '    from TSPL_Weighment_Detail where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Quality Check' as TransactionName, isnull(( select ' '+TSPL_QUALITY_CHECK.QC_No +' ,  '    from TSPL_QUALITY_CHECK where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Unloading' as TransactionName, isnull(( select ' '+TSPL_MILK_UNLOADING.Unloading_No +' ,  '    from TSPL_MILK_UNLOADING where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Unloading' as TransactionName, isnull(( select ' '+TSPL_MILK_UNLOADING.Unloading_No +' ,  '    from TSPL_MILK_UNLOADING where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Cleaning' as TransactionName, isnull(( select ' '+TSPL_Cleaning.Doc_No +' ,  '    from TSPL_Cleaning where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Bulk Milk SRN' as TransactionName, isnull(( select ' '+TSPL_Bulk_MILK_SRN.SRN_NO +' ,  '    from TSPL_Bulk_MILK_SRN where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Bulk Milk Purchase Invoice' as TransactionName, isnull(( select ' '+tspl_Bulk_milk_purchase_Invoice_head.DOC_NO +' ,  '    from tspl_Bulk_milk_purchase_Invoice_head where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Milk Transfer In' as TransactionName, isnull(( select ' '+TSPL_MILK_TRANSFER_IN.Receipt_Challan_No +' ,  '    from TSPL_MILK_TRANSFER_IN where isnull(isPosted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Bulk Procurement' as Module,'Provision Entry' as TransactionName, isnull(( select ' '+TSPL_PROVISION_ENTRY.Doc_No +' ,  '    from TSPL_PROVISION_ENTRY where isnull(isPosted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Gate Entry' as TransactionName, isnull(( select ' '+TSPL_GATEENTRY_SALE.Document_No +' ,  '    from TSPL_GATEENTRY_SALE where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Weighment' as TransactionName, isnull(( select ' '+TSPL_WEIGHMENT_DETAIL_BULKSALE.Weighment_No +' ,  '    from TSPL_WEIGHMENT_DETAIL_BULKSALE where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'LoadIn Tanker Detais' as TransactionName, isnull(( select ' '+TSPL_LOADING_TANKER_DETAIL_BULKSALE.LoadingTanker_No +' ,  '    from TSPL_LOADING_TANKER_DETAIL_BULKSALE where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Fat/SNF Check  /  QC Details' as TransactionName, isnull(( select ' '+TSPL_QUALITY_CHECK_BULKSALE.QC_No +' ,  '    from TSPL_QUALITY_CHECK_BULKSALE where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Bulk Dispatch' as TransactionName, isnull(( select ' '+TSPL_Dispatch_BulkSale.Document_No +' ,  '    from TSPL_Dispatch_BulkSale where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Bulk Invoice' as TransactionName, isnull(( select ' '+TSPL_INVOICE_MASTER_BULKSALE.Document_No +' ,  '    from TSPL_INVOICE_MASTER_BULKSALE where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Bulk Dispatch Trade' as TransactionName, isnull(( select ' '+TSPL_Dispatch_BulkSale_Trade.Document_No +' ,  '    from TSPL_Dispatch_BulkSale_Trade where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Bulk Sale' as Module,'Bulk Sale Return' as TransactionName, isnull(( select ' '+TSPL_SALE_RETURN_MASTER_BULKSALE.Document_No +' ,  '    from TSPL_SALE_RETURN_MASTER_BULKSALE where isnull(Posted,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'CSA Sale' as Module,'CSA Delivery Order' as TransactionName, isnull(( select ' '+TSPL_CSA_DO_HEAD.Doc_No +' ,  '    from TSPL_CSA_DO_HEAD where isnull(Is_Post,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'CSA Sale' as Module,'CSA Transfer' as TransactionName, isnull(( select ' '+TSPL_CSA_transfer_head.DOC_CODE +' ,  '    from TSPL_CSA_transfer_head where isnull(Status,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'CSA Sale' as Module,'Sale Patti' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_INVOICE_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_INVOICE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_INVOICE_HEAD.Trans_Type='CSA' for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'CSA Sale' as Module,'CSA Transfer Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='CSA'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'CSA Sale' as Module,'CSA Sale Patti Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0' and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='CPR'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fresh Sale' as Module,'Fresh  Booking' as TransactionName, isnull(( select ' '+TSPL_BOOKING_MATSER.Document_No +' ,  '    from TSPL_BOOKING_MATSER where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fresh Sale' as Module,'Fresh  Delivery Order' as TransactionName, isnull(( select ' '+TSPL_DELIVERY_NOTE_MASTER_FRESHSALE.Document_No +' ,  '    from TSPL_DELIVERY_NOTE_MASTER_FRESHSALE where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fresh Sale' as Module,'Fresh  Dispatch' as TransactionName, isnull(( select ' '+TSPL_SD_SHIPMENT_HEAD.Document_Code +' ,  '    from TSPL_SD_SHIPMENT_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SHIPMENT_HEAD.Trans_Type='FS'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fresh Sale' as Module,'Fresh Sale Invoice' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_INVOICE_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_INVOICE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_INVOICE_HEAD.Trans_Type='FS'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fresh Sale' as Module,'Fresh Sale Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='FS'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Fresh Sale' as Module,'Fresh Crate Received' as TransactionName, isnull(( select ' '+TSPL_CRATE_RECEIVED_HEAD_FRESHSALE.Document_No +' ,  '    from TSPL_CRATE_RECEIVED_HEAD_FRESHSALE where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Product Sale' as Module,'Product  Booking' as TransactionName, isnull(( select ' '+TSPL_BOOKING_MASTER_PRODUCTSALE.Document_Code +' ,  '    from TSPL_BOOKING_MASTER_PRODUCTSALE where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Product Sale' as Module,'Product  Delivery Order' as TransactionName, isnull(( select ' '+TSPL_DELIVERY_ORDER_HEAD_PRODUCTSALE.Document_Code +' ,  '    from TSPL_DELIVERY_ORDER_HEAD_PRODUCTSALE where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Product Sale' as Module,'Product  Dispatch' as TransactionName, isnull(( select ' '+TSPL_SD_SHIPMENT_HEAD.Document_Code +' ,  '    from TSPL_SD_SHIPMENT_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SHIPMENT_HEAD.Trans_Type='PS'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Product Sale' as Module,'Product Sale Invoice' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_INVOICE_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_INVOICE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_INVOICE_HEAD.Trans_Type='PS'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Product Sale' as Module,'Product Sale Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='PS'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Product Sale' as Module,'Sale Order' as TransactionName, isnull(( select ' '+TSPL_SD_SALES_ORDER_HEAD.Document_Code +' ,  '    from TSPL_SD_SALES_ORDER_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALES_ORDER_HEAD.Trans_Type='PS'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Export Sale' as Module,'Sale Quotaion' as TransactionName, isnull(( select ' '+TSPL_SD_QUOTATION_HEAD.Document_Code +' ,  '    from TSPL_SD_QUOTATION_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_QUOTATION_HEAD.Trans_Type='EXP'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Export Sale' as Module,'Export Sale Order' as TransactionName, isnull(( select ' '+TSPL_SD_SALES_ORDER_HEAD.Document_Code +' ,  '    from TSPL_SD_SALES_ORDER_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALES_ORDER_HEAD.Trans_Type='EXP'  and TSPL_SD_SALES_ORDER_HEAD.salesorder_type='EX'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Export Sale' as Module,'Export  Performa Invoice' as TransactionName, isnull(( select ' '+TSPL_EX_PI_HEAD.Document_Code +' ,  '    from TSPL_EX_PI_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_EX_PI_HEAD.document_type='EX'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Export Sale' as Module,'Export Commercial Invoice' as TransactionName, isnull(( select ' '+TSPL_EX_COMMERCIAL_INVOICE_HEAD.Document_Code +' ,  '    from TSPL_EX_COMMERCIAL_INVOICE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and document_type='EX'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Export Sale' as Module,'Export Sale Invoice' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_INVOICE_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_INVOICE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_INVOICE_HEAD.Trans_Type='EXP' and TSPL_SD_SALE_INVOICE_HEAD.Document_Type='EX'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Export Sale' as Module,'Export Sale Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='EXP' and TSPL_SD_SALE_RETURN_HEAD.Document_Code='EX'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Trade' as Module,'Merchant Purchase Order' as TransactionName, isnull(( select ' '+TSPL_PURCHASE_ORDER_HEAD.PurchaseOrder_No +' ,  '    from TSPL_PURCHASE_ORDER_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and  TSPL_PURCHASE_ORDER_HEAD.MT_Is_Merchant_Trade=1  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'Merchant Sale Order' as TransactionName, isnull(( select ' '+TSPL_SD_SALES_ORDER_HEAD.Document_Code +' ,  '    from TSPL_SD_SALES_ORDER_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALES_ORDER_HEAD.Trans_Type='EXP'  and TSPL_SD_SALES_ORDER_HEAD.salesorder_type='MT'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'Merchant  Performa Invoice' as TransactionName, isnull(( select ' '+TSPL_EX_PI_HEAD.Document_Code +' ,  '    from TSPL_EX_PI_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_EX_PI_HEAD.document_type='MT'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'LC Request' as TransactionName, isnull(( select ' '+TSPL_LC_REQUEST_MT.LCRequestNo +' ,  '    from TSPL_LC_REQUEST_MT where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'LC Creation' as TransactionName, isnull(( select ' '+TSPL_LC_CREATION_MT.LCCreationNo +' ,  '    from TSPL_LC_CREATION_MT where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'Document Acceptance' as TransactionName, isnull(( select ' '+TSPL_DOCUMENT_ACCEPTANCE_MT.DocumentAcceptanceNo +' ,  '    from TSPL_DOCUMENT_ACCEPTANCE_MT where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'   for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'Merchant Sale Invoice' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_INVOICE_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_INVOICE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_INVOICE_HEAD.Trans_Type='EXP' and TSPL_SD_SALE_INVOICE_HEAD.Document_Type='MT'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Merchant Sale' as Module,'Merchant Sale Return' as TransactionName, isnull(( select ' '+TSPL_SD_SALE_RETURN_HEAD.Document_Code +' ,  '    from TSPL_SD_SALE_RETURN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "' and TSPL_SD_SALE_RETURN_HEAD.Trans_Type='EXP' and TSPL_SD_SALE_RETURN_HEAD.Document_Code='MT'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Production Planning' as TransactionName, isnull(( select ' '+TSPL_PP_PRODUCTION_PLAN_HEAD.Plan_Code +' ,  '    from TSPL_PP_PRODUCTION_PLAN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Production Planning' as TransactionName, isnull(( select ' '+TSPL_PP_PRODUCTION_PLAN_HEAD.Plan_Code +' ,  '    from TSPL_PP_PRODUCTION_PLAN_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Production Batch Order' as TransactionName, isnull(( select ' '+TSPL_PP_BATCH_ORDER_HEAD.Plan_Code +' ,  '    from TSPL_PP_BATCH_ORDER_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Production Issue Entry' as TransactionName, isnull(( select ' '+TSPL_PP_ISSUE_HEAD.Issue_Code +' ,  '    from TSPL_PP_ISSUE_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Production Standardization' as TransactionName, isnull(( select ' '+TSPL_PP_STANDARDIZATION_HEAD.Standardization_Code +' ,  '    from TSPL_PP_STANDARDIZATION_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Stage Process' as TransactionName, isnull(( select ' '+TSPL_PP_STAGE_PROCESS_HEAD.STAGE_PROCESS_CODE +' ,  '    from TSPL_PP_STAGE_PROCESS_HEAD where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Production Entry' as TransactionName, isnull(( select ' '+TSPL_PP_PRODUCTION_ENTRY.PROD_ENTRY_CODE +' ,  '    from TSPL_PP_PRODUCTION_ENTRY where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No] " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'Assemblies' as TransactionName, isnull(( select ' '+TSPL_PROD_ASSEMBLIES.CODE +' ,  '    from TSPL_PROD_ASSEMBLIES where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Production' as Module,'WRECKAGE ENTRY' as TransactionName, isnull(( select ' '+TSPL_WRECKAGE_ENTRY.WRECKAGE_ENTRY_CODE +' ,  '    from TSPL_WRECKAGE_ENTRY where isnull(Posted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Job Work' as Module,'Milk RGP' as TransactionName, isnull(( select ' '+TSPL_Milk_RGP_HEAD.RGP_No +' ,  '    from TSPL_Milk_RGP_HEAD where isnull(Status,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Job Work' as Module,'Milk Gate Entry' as TransactionName, isnull(( select ' '+TSPL_MILK_GATE_ENTRY_DETAILS.Gate_Entry_No +' ,  '    from TSPL_MILK_GATE_ENTRY_DETAILS where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Job Work' as Module,'Weighment Detail' as TransactionName, isnull(( select ' '+tspl_Milk_weighment_detail.Weighment_No +' ,  '    from tspl_Milk_weighment_detail where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Job Work' as Module,'Quality Check' as TransactionName, isnull(( select ' '+tspl_Milk_quality_check.QC_No +' ,  '    from tspl_Milk_quality_check where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Job Work' as Module,'Unloading' as TransactionName, isnull(( select ' '+TSPL_JOB_MILK_UNLOADING.Unloading_No +' ,  '    from TSPL_JOB_MILK_UNLOADING where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  " + Environment.NewLine & _
    '                           "union all " + Environment.NewLine & _
    '                           "select 'Milk Job Work' as Module,'Milk SRN' as TransactionName, isnull(( select ' '+tspl_Job_milk_srn.SRN_NO +' ,  '    from tspl_Job_milk_srn where isnull(isPosted,'0') = '0'and Created_By='" & objCommonVar.CurrentUserCode & "'  for xml path('')  ),'') as [Document No]  )  aa  where [Document No] <> ''"
    '                Dim msg As String = ""
    '                Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
    '                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                    Dim strModule As String = ""
    '                    Dim strTrans As String = ""
    '                    Dim strDocument As String = ""
    '                    For Each dr As DataRow In dt.Rows
    '                        strModule = clsCommon.myCstr(dr("Module"))
    '                        strTrans = clsCommon.myCstr(dr("TransactionName"))
    '                        strDocument = clsCommon.myCstr(dr("Document No"))
    '                        msg += "Module - " + strModule + "  Transaction - " + strTrans + "  Document - " + clsCommon.myCstr(strDocument) + Environment.NewLine
    '                    Next
    '                    clsCommon.MyMessageBoxShow(msg)
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '        common.clsCommon.MyMessageBoxShow(ex.Message)
    '    End Try
    'End Sub
    '' TO Auto Lock All Transaction location and location segment wise
    'Function AUTOLOCKTRANSACTION() As Boolean
    '    Dim qry As String = ""
    '    Dim currentDate As Date = clsCommon.GETSERVERDATE()
    '    Dim dblLockdays As Double = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.DaysToStartAutoLock, clsFixedParameterCode.DaysToStartAutoLock, Nothing))
    '    Dim datLastDay As Date = currentDate.AddDays(-dblLockdays)
    '    'Dim datLastDay As Date = LastDayOfPreviousMonth(currentDate)
    '    Dim intCount As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(*) from TSPL_LOCK_LOCATION where End_Date='" & clsCommon.GetPrintDate(datLastDay, "dd/MMM/yyyy") & "'"))

    '    If intCount <= 0 Then
    '        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()

    '        Try
    '            Dim ArrLoc As New ArrayList

    '            '' Location Segement wise
    '            clsDBFuncationality.ExecuteNonQuery("Delete from TSPL_LOCK_LOCATION_SEGMENT ", trans)
    '            clsDBFuncationality.ExecuteNonQuery("Delete from TSPL_LOCK_LOCATION_SEGMENT_USER ", trans)
    '            qry = " Select Segment_code as Code, Description from TSPL_GL_SEGMENT_CODE where Seg_No=7 "
    '            Dim dtLoc As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

    '            Dim FrmLockTransaction As New FrmLockTransaction1
    '            qry = " Select * from (" + FrmLockTransaction.LockTransactionNameLocationSegwise() + ") xxx order by Module, [Transaction]"
    '            Dim dtTrans As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

    '            If (dtLoc IsNot Nothing AndAlso dtLoc.Rows.Count > 0) Then
    '                For Each dr As DataRow In dtLoc.Rows
    '                    Dim arr As New List(Of clsLockTransactionLocationSegmentwise)
    '                    Dim obj As New clsLockTransactionLocationSegmentwise
    '                    For Each dr1 As DataRow In dtTrans.Rows
    '                        obj = New clsLockTransactionLocationSegmentwise
    '                        obj.Location_Segment_Code = clsCommon.myCstr(dr("Code"))
    '                        obj.Module_Name = clsCommon.myCstr(dr1("Module"))
    '                        obj.Trans_Name = clsCommon.myCstr(dr1("Transaction"))
    '                        obj.Is_Locked = 1
    '                        obj.Start_Date = clsCommon.GetPrintDate("01-01-2001", "dd/MMM/yyyy")
    '                        obj.End_Date = datLastDay
    '                        arr.Add(obj)
    '                    Next
    '                    clsLockTransactionLocationSegmentwise.SaveData(obj.Location_Segment_Code, "", arr, trans)
    '                Next
    '            End If

    '            '' Location wise
    '            clsDBFuncationality.ExecuteNonQuery("Delete from TSPL_LOCK_LOCATION ", trans)
    '            clsDBFuncationality.ExecuteNonQuery("Delete from TSPL_LOCK_LOCATION_USER ", trans)
    '            qry = " Select Location_Code as Code from TSPL_LOCATION_MASTER Where Location_Type='Physical' "
    '            Dim dtLocSeg As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

    '            qry = " Select * from (" + FrmLockTransaction.LockTransactionNameLocationwise() + ") xxx order by Module, [Transaction]"
    '            dtTrans = clsDBFuncationality.GetDataTable(qry, trans)

    '            If (dtLocSeg IsNot Nothing AndAlso dtLocSeg.Rows.Count > 0) Then

    '                For Each dr As DataRow In dtLocSeg.Rows
    '                    Dim obj As New clsLockTransactionLocationwise
    '                    Dim arr1 As New List(Of clsLockTransactionLocationwise)
    '                    For Each dr1 As DataRow In dtTrans.Rows
    '                        obj = New clsLockTransactionLocationwise
    '                        obj.Location_Code = clsCommon.myCstr(dr("Code"))
    '                        obj.Module_Name = clsCommon.myCstr(dr1("Module"))
    '                        obj.Trans_Name = clsCommon.myCstr(dr1("Transaction"))
    '                        obj.Is_Locked = 1
    '                        obj.Start_Date = clsCommon.GetPrintDate("01-01-2001", "dd/MMM/yyyy")
    '                        obj.End_Date = datLastDay
    '                        arr1.Add(obj)
    '                    Next
    '                    clsLockTransactionLocationwise.SaveData(obj.Location_Code, "", arr1, trans)
    '                Next
    '            End If
    '            trans.Commit()
    '            clsCommon.MyMessageBoxShow("Transaction Locked Successfully", Me.Text)
    '        Catch ex As Exception
    '            trans.Rollback()
    '            common.clsCommon.MyMessageBoxShow(ex.Message)
    '        End Try
    '    End If

    'End Function
    'Public Shared Sub CreateAutoIndentAccordingReorderLevel()
    '    Try
    '        Dim EnableMsgPopupforReorderLevel As Boolean = False
    '        Dim qry As String = Nothing
    '        Dim dt As New DataTable()
    '        Dim strlocation = Nothing
    '        EnableMsgPopupforReorderLevel = clsCommon.myCBool(clsDBFuncationality.getSingleValue("Select TSPL_PURCHASE_SETTINGS.ENABLE_POPUP_REORDERLEVEL from TSPL_PURCHASE_SETTINGS", Nothing))
    '        If EnableMsgPopupforReorderLevel Then
    '            strlocation = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select TSPL_USER_MASTER.Default_Location from TSPL_USER_MASTER where TSPL_USER_MASTER.User_Code='" + objCommonVar.CurrentUserCode + "'", Nothing))
    '            qry = "select z.ItemCode,z.ItemType,z.ItemDesc ,z.Qty,z.Unit  from (select xx.ItemCode as ItemCode,(((TSPL_ITEM_REORDER_LEVEL_NEW.Reorder_Qty)*uom1.Conversion_Factor)/TSPL_ITEM_UOM_DETAIL.Conversion_Factor-isnull(xxx.Qty,0)) as Qty,TSPL_ITEM_MASTER.Item_Type as ItemType," & _
    '                    " TSPL_ITEM_MASTER.Item_Desc as ItemDesc ,TSPL_ITEM_UOM_DETAIL.UOM_Code as Unit from TSPL_ITEM_REORDER_LEVEL_NEW left outer join (select TSPL_INVENTORY_MOVEMENT.Item_Code as ItemCode," & _
    '                    " (SUM(TSPL_INVENTORY_MOVEMENT.Stock_Qty * case when TSPL_INVENTORY_MOVEMENT.InOut ='I' then 1 else -1 end)) as Balance from TSPL_INVENTORY_MOVEMENT where TSPL_INVENTORY_MOVEMENT.Location_Code='" + strlocation + "'  group by TSPL_INVENTORY_MOVEMENT.Item_Code)xx on xx.ItemCode=TSPL_ITEM_REORDER_LEVEL_NEW.Item_Code" & _
    '                    " left outer join TSPL_ITEM_MASTER ON TSPL_ITEM_MASTER.Item_Code=TSPL_ITEM_REORDER_LEVEL_NEW.Item_Code" & _
    '                    " left outer join (select TSPL_REQUISITION_DETAIL.Item_Code,SUM(TSPL_REQUISITION_DETAIL.Requisition_Qty) AS Qty from TSPL_REQUISITION_DETAIL " & _
    '                    " left outer join TSPL_REQUISITION_HEAD ON TSPL_REQUISITION_HEAD.Requisition_Id=TSPL_REQUISITION_DETAIL.Requisition_Id " & _
    '                    " WHERE TSPL_REQUISITION_HEAD.Status=0  group by TSPL_REQUISITION_DETAIL.Item_Code)xxx on xxx.Item_Code = TSPL_ITEM_REORDER_LEVEL_NEW.Item_Code" & _
    '                    " left outer join TSPL_ITEM_UOM_DETAIL on TSPL_ITEM_UOM_DETAIL.Item_Code=TSPL_ITEM_REORDER_LEVEL_NEW.Item_Code left outer join TSPL_ITEM_UOM_DETAIL uom1 on uom1.Item_Code = TSPL_ITEM_REORDER_LEVEL_NEW.Item_Code and uom1.UOM_Code=(case when isnull(TSPL_ITEM_REORDER_LEVEL_NEW.UOM_Code,'')='' then uom1.UOM_Code else TSPL_ITEM_REORDER_LEVEL_NEW.Uom_Code end)" & _
    '                    " where TSPL_ITEM_REORDER_LEVEL_NEW.Location_Code='" + strlocation + "' and TSPL_ITEM_REORDER_LEVEL_NEW.Reorder_Level>xx.Balance" & _
    '                    " and TSPL_ITEM_UOM_DETAIL.Stocking_Unit='Y' and TSPL_ITEM_REORDER_LEVEL_NEW.Apply='Y')z where z.Qty>0"

    '            dt = clsDBFuncationality.GetDataTable(qry, Nothing)
    '            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                If clsCommon.CompairString(objCommonVar.CurrentCompanyCode, "KL") = CompairStringResult.Equal Then
    '                    clsCommon.MyMessageBoxShow("Some items reached their re-order level.", "Warning", MessageBoxButtons.OK)
    '                    Exit Sub
    '                End If
    '                If clsCommon.MyMessageBoxShow("Some items reached their re-order level. Do you want to create auto indent ?", "Question", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

    '                    Dim frm As New frmItemReorder()
    '                    frm.strLocation = strlocation
    '                    frm.ShowDialog()
    '                    'Dim obj As New clsRequistionHead()
    '                    'Dim drrow As DataRow() = Nothing
    '                    'For i As Integer = 0 To 6
    '                    '    If i = 0 Then
    '                    '        drrow = dt.Select("ItemType = 'F'")
    '                    '        obj.Item_Type = "F"
    '                    '    ElseIf i = 1 Then
    '                    '        drrow = dt.Select("ItemType = 'S'")
    '                    '        obj.Item_Type = "S"
    '                    '    ElseIf i = 2 Then
    '                    '        drrow = dt.Select("ItemType = 'R'")
    '                    '        obj.Item_Type = "R"
    '                    '    ElseIf i = 3 Then
    '                    '        drrow = dt.Select("ItemType = 'A'")
    '                    '        obj.Item_Type = "A"
    '                    '    ElseIf i = 4 Then
    '                    '        drrow = dt.Select("ItemType = 'T'")
    '                    '        obj.Item_Type = "T"
    '                    '    ElseIf i = 5 Then
    '                    '        drrow = dt.Select("ItemType = 'N'")
    '                    '        obj.Item_Type = "N"
    '                    '    ElseIf i = 6 Then
    '                    '        drrow = dt.Select("ItemType = 'O'")
    '                    '        obj.Item_Type = "O"
    '                    '    End If
    '                    '    If drrow IsNot Nothing AndAlso drrow.Count > 0 Then
    '                    '        obj.Requisition_Id = ""
    '                    '        obj.Requisition_Date = clsCommon.GETSERVERDATE(Nothing)
    '                    '        obj.On_Hold = 0
    '                    '        obj.Location = strlocation
    '                    '        obj.RQ_Detail_Total_Amt = 0
    '                    '        obj.Total_RQ_Amt = 0
    '                    '        obj.Mode_Of_Transport = "By Road"
    '                    '        obj.Is_Internal = "N"
    '                    '        'obj.Item_Type = clsCommon.myCstr(cboItemType.SelectedValue)
    '                    '        'obj.Dept = txtDept.Value
    '                    '        'obj.Dept_Desc = lblDept.Text
    '                    '        obj.Requisition_Type = "L"
    '                    '        obj.Category = "Regular"
    '                    '        obj.close_yn = "N"
    '                    '        obj.Approvel_Level_Required = 2

    '                    '        obj.ArrTr = New List(Of clsRequistionDetail)
    '                    '        For Each drow As DataRow In drrow
    '                    '            Dim objTr As New clsRequistionDetail()
    '                    '            objTr.Item_Code = clsCommon.myCstr(drow("ItemCode"))
    '                    '            objTr.Item_Desc = clsCommon.myCstr(drow("ItemDesc"))
    '                    '            objTr.Requisition_Qty = clsCommon.myCdbl(drow("Qty"))
    '                    '            objTr.Balance_Qty = clsCommon.myCdbl(drow("Qty"))
    '                    '            objTr.Item_Cost = 0
    '                    '            objTr.Item_Net_Amt = 0
    '                    '            objTr.Location = strlocation
    '                    '            objTr.Unit_Code = clsCommon.myCstr(drow("Unit"))
    '                    '            objTr.Status = "N"
    '                    '            If (clsCommon.myLen(objTr.Item_Code) > 0) Then
    '                    '                obj.ArrTr.Add(objTr)
    '                    '            End If
    '                    '        Next
    '                    '        If obj.ArrTr IsNot Nothing AndAlso obj.ArrTr.Count > 0 Then
    '                    '            obj.SaveData(obj, "True")
    '                    '        End If
    '                    '    End If
    '                    'Next
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        clsCommon.MyMessageBoxShow(ex.Message.ToString())
    '    End Try
    'End Sub

    'Private Sub SystemIdleTimer1_OnEnterIdleState(ByVal sender As System.Object, ByVal e As IdleEventArgs) Handles SystemIdleTimer1.OnEnterIdleState
    '    isAutoClosing = True
    '    clsERPFuncationality.closeForm(Me)
    'End Sub

    'Private Sub SystemIdleTimer1_OnExitIdleState(ByVal sender As System.Object, ByVal e As IdleEventArgs) Handles SystemIdleTimer1.OnExitIdleState
    '    GC.Collect()
    '    GC.WaitForPendingFinalizers()
    '    isAutoClosing = False
    'End Sub

    'Public Sub GetMccFssaiPopUp()
    '    Dim obj As New FrmMCCMaster
    '    obj.GetMccFssai()
    'End Sub

    'Public Sub GetPendingSaleOrder()
    '    Try
    '        Dim qry As String = "select isnull((Select distinct '['+TSPL_SD_SALES_ORDER_HEAD.Document_Code+']  ' from TSPL_SD_SALES_ORDER_HEAD left outer join TSPL_DELIVERY_ORDER_HEAD_PRODUCTSALE on TSPL_SD_SALES_ORDER_HEAD.Document_Code=TSPL_DELIVERY_ORDER_HEAD_PRODUCTSALE.Against_Sales_Order where  TSPL_SD_SALES_ORDER_HEAD.Status=1 and TSPL_SD_SALES_ORDER_HEAD.Delivery_date > '" & clsCommon.GetPrintDate(clsCommon.GETSERVERDATE, "dd/MMM/yyyy") & "' and TSPL_DELIVERY_ORDER_HEAD_PRODUCTSALE.Document_Code not in (select isnull(Delivery_Code_PS,'')   from TSPL_SD_SHIPMENT_HEAD ) for xml path('')),'')  as DocNo "
    '        Dim strDocNo As String = clsDBFuncationality.getSingleValue(qry)
    '        If clsCommon.myLen(strDocNo) > 0 Then
    '            clsCommon.MyMessageBoxShow("Delivery Date will expired for these Sales order " & strDocNo & " ")
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub

    'Public Sub GetPendingSaleBooking()
    '    Try
    '        Dim qry As String = "select isnull((Select distinct '['+TSPL_BOOKING_MASTER_PRODUCTSALE.Document_Code+']  ' from TSPL_BOOKING_MASTER_PRODUCTSALE left outer join TSPL_SD_SALES_ORDER_HEAD on TSPL_BOOKING_MASTER_PRODUCTSALE.Document_Code=TSPL_SD_SALES_ORDER_HEAD.Against_Booking_No where  TSPL_BOOKING_MASTER_PRODUCTSALE.Status=1 and TSPL_BOOKING_MASTER_PRODUCTSALE.BookValidity_date > '" & clsCommon.GetPrintDate(clsCommon.GETSERVERDATE, "dd/MMM/yyyy") & "' and ( TSPL_BOOKING_MASTER_PRODUCTSALE.Document_Code not in (select isnull(Against_Booking_No,'')   from TSPL_SD_SALES_ORDER_HEAD ) or TSPL_BOOKING_MASTER_PRODUCTSALE.Document_Code not in (select isnull(Against_Booking_No,'')   from TSPL_DELIVERY_ORDER_HEAD_PRODUCTSALE ) ) for xml path('')),'')  as DocNo "
    '        Dim strDocNo As String = clsDBFuncationality.getSingleValue(qry)
    '        If clsCommon.myLen(strDocNo) > 0 Then
    '            clsCommon.MyMessageBoxShow("Booking Date will expired for these Booking " & strDocNo & " ")
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        CheckAndLogin()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Sub LoadWorkingScreen()
        SplitPanel1.Collapsed = True
        SplitPanel2.Collapsed = True
        SplitPanel4.Collapsed = True
        SplitPanel3.Collapsed = False
        ' LoadImageList()
        LoadMenu()




        Dim splitPanelElement = TryCast(RadDock1.RootElement.Children(0), SplitPanelElement)
        Dim imagePrimitive = New ImagePrimitive()
        imagePrimitive.Image = Global.TeamMgmt.My.Resources.Resources.B11 'BackImageDemo
        'If Not objCommonVar.IsDemoERP Then
        '    imagePrimitive.Image = Global.ERP.My.Resources.Resources.BackImageXpertERPFMCGN
        'End If


        imagePrimitive.Alignment = ContentAlignment.TopRight
        imagePrimitive.StretchHorizontally = False
        imagePrimitive.StretchVertically = False

        imagePrimitive.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        RadDock1.MainDocumentContainer.SplitPanelElement.Children.Add(imagePrimitive)

        Try
            imagePrimitive = New ImagePrimitive()
            '   Dim img As Byte() = DirectCast(clsDBFuncationality.getSingleValue("select top 1 Logo_Img  from tspl_company_master "), Byte())
            '  Dim ms As MemoryStream = New MemoryStream(img)
            imagePrimitive.Image = Global.TeamMgmt.My.Resources.Resources.Comp_logo
            imagePrimitive.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
            imagePrimitive.Alignment = ContentAlignment.TopLeft
            imagePrimitive.Size = New Point(84, 12)

            RadDock1.MainDocumentContainer.SplitPanelElement.Children.Add(imagePrimitive)
        Catch ex As Exception

        End Try


        lblUserCode.Text = objCommonVar.CurrentUserCode
        lblUser.Text = objCommonVar.CurrentUser
        lblCompanyCode.Text = objCommonVar.CurrentCompanyCode
        lblCompany.Text = objCommonVar.CurrentCompanyName.Trim()
        'strUserCode = objCommonVar.CurrentUserCode
        'strCompany = objCommonVar.CurrentCompanyCode
        lblDataBase.Text = objCommonVar.CurrDatabase.Trim()
        lblLocation.Text = objCommonVar.CurrLocationName.Trim()
        'lblLocation.Text = clsLocation.GetName(clsGateEntry.getUsersDefaultLocation(), Nothing)
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.Location = New Point(0, 0)
        RadDock1.BackColor = Color.Transparent
        RadDock1.BackgroundImage = ImageList2.Images.Item(0)
        RadDock1.BackgroundImageLayout = ImageLayout.Center
        If lblCompany.Text <> "" Then
            Me.Text = Me.Text + "-" + lblCompany.Text
        End If
        'If lblCompany.Text = "" Then
        '    RTV2.Visible = False
        'Else
        RTV2.Visible = True
        'End If

        LoadMenuInCombo()
        ' '' alert reminder for bday/anniversary 
        'Dim UserCode As String = objCommonVar.CurrentUserCode
        'If clsFixedParameter.GetData(clsFixedParameterType.AllowToDispalyAlertForBDayAnniversary, clsFixedParameterType.AllowToDispalyAlertForBDayAnniversary, Nothing) = "1" Then
        '    If clsEmployeeMaster.CheckUserForHRDepartment(UserCode) Then
        '        Dim msg As String = clsEmployeeMaster.GetBdayAnniversaryMSG()
        '        If clsCommon.myLen(msg) > 0 Then
        '            clsERPFuncationality.ShowAlert(msg, "B'Day/Anniversary Reminder")
        '        End If
        '    End If
        'End If
        ' '' email reminder for bday/anniversary 
        'If clsFixedParameter.GetData(clsFixedParameterType.AllowToSendEmailForBDayAnniversary, clsFixedParameterType.AllowToSendEmailForBDayAnniversary, Nothing) = "1" Then
        '    If clsEmployeeMaster.CheckUserForHRDepartment(UserCode) Then
        '        clsEmployeeMaster.SendBdayAnniversaryEmail("Employee Master")
        '    End If
        'End If


    End Sub

    Public Sub LoadMenu()
        Try
            'arrExcluded.Clear()
            'If Not isUtilityAdded Then
            '    arrExcluded.Add(clsUserMgtCode.ModuleUtility)
            'End If
            'arrExcluded.Add(clsUserMgtCode.frmJEReverse)
            'If objCommonVar.IsDemoERP Then
            '    ''Menu item Only for  FMCG  
            '    arrExcluded.Add(clsUserMgtCode.ModuleSales)
            '    arrExcluded.Add(clsUserMgtCode.Indent)
            '    'arrExcluded.Add(clsUserMgtCode.Transfer)
            '    arrExcluded.Add(clsUserMgtCode.CreateTransfer)
            '    arrExcluded.Add(clsUserMgtCode.FrmItemMcMapping)
            '    arrExcluded.Add(clsUserMgtCode.mbtnEmptyTrans)
            '    arrExcluded.Add(clsUserMgtCode.frmMorningReport)
            '    arrExcluded.Add(clsUserMgtCode.StockStatement)

            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.SHowBulkMilkWeighment, clsFixedParameterCode.SHowBulkMilkWeighment, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.frmWeighment)
            '    End If
            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.isIntimationRequired, clsFixedParameterCode.isIntimationRequired, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.frmIntimation)
            '    End If
            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowGateEntryAgainstPO, clsFixedParameterCode.AllowGateEntryAgainstPO, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.frmPOBulkProc)
            '    End If
            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowFreshPriceChartOnProductSale, clsFixedParameterCode.AllowFreshPriceChartOnProductSale, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.frmdispatchAdviceProductSale)
            '    End If
            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.AllowGateReturn, clsFixedParameterCode.AllowGateReturn, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.frmGateEntryReturnTransfer)
            '        arrExcluded.Add(clsUserMgtCode.frmGateEntryReturnPS)
            '        arrExcluded.Add(clsUserMgtCode.frmGateEntryReturnCS)
            '    End If
            '    arrExcluded.Add(clsUserMgtCode.packType)
            '    'arrExcluded.Add(clsUserMgtCode.PriceMaster)
            '    arrExcluded.Add(clsUserMgtCode.SchemeMaster)
            '    arrExcluded.Add(clsUserMgtCode.mbtnBreakageHead1)
            '    arrExcluded.Add(clsUserMgtCode.ItemExciseMapping)
            '    arrExcluded.Add(clsUserMgtCode.ItemBasicPrice)

            '    arrExcluded.Add(clsUserMgtCode.ItemPrice)
            '    arrExcluded.Add(clsUserMgtCode.StockRecoReport)
            '    arrExcluded.Add(clsUserMgtCode.FrmStockDispatchReport)
            '    arrExcluded.Add(clsUserMgtCode.FrmAdjustmentStatusReport1)
            '    arrExcluded.Add(clsUserMgtCode.BreakageReportSummary)
            '    arrExcluded.Add(clsUserMgtCode.mbtnBreakageReport)
            '    arrExcluded.Add(clsUserMgtCode.RoutewiseBreakageReport)
            '    arrExcluded.Add(clsUserMgtCode.SchemeReport)
            '    arrExcluded.Add(clsUserMgtCode.StockReportForFinishedGoods)
            '    arrExcluded.Add(clsUserMgtCode.FrmAdjustmentReport)
            '    arrExcluded.Add(clsUserMgtCode.rptVehicleWiseLoadout)
            '    arrExcluded.Add(clsUserMgtCode.FrmPendingIndentTransferReport)
            '    arrExcluded.Add(clsUserMgtCode.FrmExpiredItemDetails)
            '    arrExcluded.Add(clsUserMgtCode.itemMaster)
            '    arrExcluded.Add(clsUserMgtCode.ShiptoLocation)
            '    'KUNAL > KDIL > REMOVED THE EMPTY LINK AS PER RANJANA MADAM DISCUSSION. > DATE 11-NOV-2016
            '    arrExcluded.Add(clsUserMgtCode.RptPaymentRelization)
            '    If clsCommon.CompairString(objCommonVar.CurrentIndustryType, "D") = CompairStringResult.Equal Then
            '        'arrExcluded.Add(clsUserMgtCode.ACCSETMFG)
            '        'arrExcluded.Add(clsUserMgtCode.COSTMAINTAIN)
            '        'arrExcluded.Add(clsUserMgtCode.SETT)
            '        'arrExcluded.Add(clsUserMgtCode.EXPENSE)
            '        'arrExcluded.Add(clsUserMgtCode.PRO)
            '        'arrExcluded.Add(clsUserMgtCode.ITEMCATEGORY)
            '        'arrExcluded.Add(clsUserMgtCode.frmBOMImport)
            '        'arrExcluded.Add(clsUserMgtCode.ALTER)
            '        'arrExcluded.Add(clsUserMgtCode.frmBillOfMaterial)

            '        'arrExcluded.Add(clsUserMgtCode.frmProductionPlanning)
            '        'arrExcluded.Add(clsUserMgtCode.frmBatchOrder)
            '        'arrExcluded.Add(clsUserMgtCode.frmProductionRequisition)
            '        'arrExcluded.Add(clsUserMgtCode.frmStoreIssue)
            '        'arrExcluded.Add(clsUserMgtCode.frmProductionReturn)
            '        'arrExcluded.Add(clsUserMgtCode.frmProductionReceipt)

            '        'arrExcluded.Add(clsUserMgtCode.LALT)
            '        'arrExcluded.Add(clsUserMgtCode.LACCt)
            '        'arrExcluded.Add(clsUserMgtCode.frmListOfBOM)
            '        'arrExcluded.Add(clsUserMgtCode.LOIC)
            '        'arrExcluded.Add(clsUserMgtCode.PRODREPORT)
            '        'arrExcluded.Add(clsUserMgtCode.frmListofRequisition)
            '        'arrExcluded.Add(clsUserMgtCode.Resource)
            '    End If
            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.ShowGRN, clsFixedParameterCode.ShowGRN, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.mbtnGRN)
            '    End If
            '    If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.ShowMRN, clsFixedParameterCode.ShowMRN, Nothing)) = 0 Then
            '        arrExcluded.Add(clsUserMgtCode.mbtnMRN)
            '    End If
            '    arrExcluded.Add(clsUserMgtCode.frmMilkCollectionArea)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkVehicleTypeMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkTransportRateMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkComponentMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkComponentRateList)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkAdvanceMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkRateTypeMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkShiftMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmSeasonMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmUOMMaster)

            '    arrExcluded.Add(clsUserMgtCode.frmMilkSuppliers)
            '    arrExcluded.Add(clsUserMgtCode.frmMCCRouteMapping)
            '    arrExcluded.Add(clsUserMgtCode.frmMCCSuperwiserMapping)
            '    arrExcluded.Add(clsUserMgtCode.frmMCCSupplierMapping)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkCollection)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkQualityCheck)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkRateProcessingScheme)
            '    arrExcluded.Add(clsUserMgtCode.frmVehicleMovement)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkBillGeneration)

            '    If IsLoaction_NLevel = "NO" Then
            '        arrExcluded.Add(clsUserMgtCode.frmLocationCategoryLevel)
            '        arrExcluded.Add(clsUserMgtCode.frmLocationCategoryStructure)
            '    End If
            '    If IsCustomer_NLevel = "NO" Then
            '        arrExcluded.Add(clsUserMgtCode.frmCustomerCategoryLevel)
            '        arrExcluded.Add(clsUserMgtCode.frmCustomerCategoryStructure)
            '    End If
            '    If IsVendor_NLevel = "NO" Then
            '        arrExcluded.Add(clsUserMgtCode.frmVendorCategoryLevel)
            '        arrExcluded.Add(clsUserMgtCode.frmVendorCategoryStructure)
            '    End If
            '    arrExcluded.Add(clsUserMgtCode.AssetSegment)
            '    'arrExcluded.Add(clsUserMgtCode.frmSecondaryCustomer)

            'Else

            '    ''Menu item Only for Xpert ERP
            '    arrExcluded.Add(clsUserMgtCode.frmProductionReceiptDemo)
            '    arrExcluded.Add(clsUserMgtCode.frmProductionItemSerialReplace)
            '    arrExcluded.Add(clsUserMgtCode.frmProductionSerializedReport)

            '    arrExcluded.Add(clsUserMgtCode.DVAT30)
            '    arrExcluded.Add(clsUserMgtCode.DVAT31)
            '    'arrExcluded.Add(clsUserMgtCode.frmBalanceSheetPerforma)
            '    'arrExcluded.Add(clsUserMgtCode.rptBalanceSheet)
            '    arrExcluded.Add(clsUserMgtCode.ModuleSalesNew)
            '    arrExcluded.Add(clsUserMgtCode.frmBarCodeGenerator)
            '    arrExcluded.Add(clsUserMgtCode.frmRequisitionApproval)
            '    arrExcluded.Add(clsUserMgtCode.RequisitSubTypeMaster)
            '    arrExcluded.Add(clsUserMgtCode.mbtnPendingApprovalOfReq)
            '    arrExcluded.Add(clsUserMgtCode.RFQ)
            '    arrExcluded.Add(clsUserMgtCode.VendorQuotation)
            '    arrExcluded.Add(clsUserMgtCode.VendorComparison)
            '    arrExcluded.Add(clsUserMgtCode.VendorComparisonApproval)
            '    arrExcluded.Add(clsUserMgtCode.ModuleBI)
            '    arrExcluded.Add(clsUserMgtCode.FrmCFormEntry)
            '    arrExcluded.Add(clsUserMgtCode.frmMapLedgerAccToTally)
            '    arrExcluded.Add(clsUserMgtCode.frmPostAllGLToTally)
            '    arrExcluded.Add(clsUserMgtCode.frmCFormReport)
            '    arrExcluded.Add(clsUserMgtCode.frmPurchaseOrderList)
            '    arrExcluded.Add(clsUserMgtCode.FrmUserApproval)
            '    arrExcluded.Add(clsUserMgtCode.FrmBudgetMaintenance)
            '    arrExcluded.Add(clsUserMgtCode.ModuleProjectManagement)
            '    arrExcluded.Add(clsUserMgtCode.FrmExpenseType)
            '    arrExcluded.Add(clsUserMgtCode.FrmProjectStatus)
            '    arrExcluded.Add(clsUserMgtCode.FrmPJCExpense)
            '    arrExcluded.Add(clsUserMgtCode.stockRecoNew)
            '    arrExcluded.Add(clsUserMgtCode.FrmProcessMaster1)
            '    arrExcluded.Add(clsUserMgtCode.frmLabourWorkingSheet)
            '    arrExcluded.Add(clsUserMgtCode.frmOperaterEfficiencyReport)
            '    'arrExcluded.Add(clsUserMgtCode.ACCSETMFG)
            '    arrExcluded.Add(clsUserMgtCode.frmDemoProductionPlanning)
            '    arrExcluded.Add(clsUserMgtCode.COSTMAINTAIN)
            '    'arrExcluded.Add(clsUserMgtCode.SETT)
            '    arrExcluded.Add(clsUserMgtCode.EXPENSE)
            '    arrExcluded.Add(clsUserMgtCode.TOOLTYPE)
            '    arrExcluded.Add(clsUserMgtCode.frmWorkCenterMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmResourceMaster)
            '    arrExcluded.Add(clsUserMgtCode.TOOL)
            '    arrExcluded.Add(clsUserMgtCode.frmOperationMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmBOMImport)
            '    arrExcluded.Add(clsUserMgtCode.ALTER)
            '    arrExcluded.Add(clsUserMgtCode.FrmProcessMaster1)
            '    arrExcluded.Add(clsUserMgtCode.frmBillOfMaterialCosting)
            '    arrExcluded.Add(clsUserMgtCode.frmManufacturingOrder)
            '    arrExcluded.Add(clsUserMgtCode.AssetSegment)
            '    arrExcluded.Add(clsUserMgtCode.FrmApprovalSetting)
            '    arrExcluded.Add(clsUserMgtCode.frmBarCodeGenerator1)
            '    arrExcluded.Add(clsUserMgtCode.WarrantyMaster)
            '    arrExcluded.Add(clsUserMgtCode.FrmItemSerialTrackingReport)
            '    arrExcluded.Add(clsUserMgtCode.ChangeItemSerialNumber)
            '    arrExcluded.Add(clsUserMgtCode.frmSchemeMasterNew) ' New Scheme Master @ Material Mgmt>>Master
            '    arrExcluded.Add(clsUserMgtCode.frmWeightConversion) ' New Scheme Master @ Material Mgmt>>Master

            '    '' SETUP REPORTS PRODUCTION DEMO
            '    arrExcluded.Add(clsUserMgtCode.LALT)
            '    arrExcluded.Add(clsUserMgtCode.LACCt)
            '    arrExcluded.Add(clsUserMgtCode.LOIC)
            '    arrExcluded.Add(clsUserMgtCode.LOPER)
            '    arrExcluded.Add(clsUserMgtCode.Resource)
            '    arrExcluded.Add(clsUserMgtCode.LToolT)
            '    arrExcluded.Add(clsUserMgtCode.LTOOL)
            '    arrExcluded.Add(clsUserMgtCode.LWC)

            '    arrExcluded.Add(clsUserMgtCode.frmMilkCollectionArea)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkVehicleTypeMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkTransportRateMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkComponentMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkComponentRateList)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkAdvanceMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkRateTypeMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkShiftMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmSeasonMaster)
            '    arrExcluded.Add(clsUserMgtCode.frmUOMMaster)

            '    arrExcluded.Add(clsUserMgtCode.frmMilkSuppliers)
            '    arrExcluded.Add(clsUserMgtCode.frmMCCRouteMapping)
            '    arrExcluded.Add(clsUserMgtCode.frmMCCSuperwiserMapping)
            '    arrExcluded.Add(clsUserMgtCode.frmMCCSupplierMapping)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkCollection)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkQualityCheck)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkRateProcessingScheme)
            '    arrExcluded.Add(clsUserMgtCode.frmVehicleMovement)
            '    arrExcluded.Add(clsUserMgtCode.frmMilkBillGeneration)
            '    If IsLoaction_NLevel = "NO" Then
            '        arrExcluded.Add(clsUserMgtCode.frmLocationCategoryLevel)
            '        arrExcluded.Add(clsUserMgtCode.frmLocationCategoryStructure)
            '    End If
            '    If IsCustomer_NLevel = "NO" Then
            '        arrExcluded.Add(clsUserMgtCode.frmCustomerCategoryLevel)
            '        arrExcluded.Add(clsUserMgtCode.frmCustomerCategoryStructure)
            '    End If
            '    If IsVendor_NLevel = "NO" Then
            '        arrExcluded.Add(clsUserMgtCode.frmVendorCategoryLevel)
            '        arrExcluded.Add(clsUserMgtCode.frmVendorCategoryStructure)
            '    End If
            'End If

            'If clsCommon.CompairString(objCommonVar.CurrentIndustryType, "R") <> CompairStringResult.Equal Then
            '    arrExcluded.Add(clsUserMgtCode.frmRiceBOM)
            '    arrExcluded.Add(clsUserMgtCode.frmRiceMixingEntry)
            '    arrExcluded.Add(clsUserMgtCode.frmRiceProcessingEntry)
            'End If

            'If clsCommon.CompairString(clsFixedParameter.GetData("MilkProc", "EnableMilkProc", Nothing), "1") = CompairStringResult.Equal Then
            '    arrExcluded.Add(clsUserMgtCode.ModuleMilkProcurement)
            'End If

            '' Hiding Redundant Copy of Price Chart Master , Done By Pankaj Jha As suggested by Ranjana MAM
            'arrExcluded.Add(clsUserMgtCode.frmPriceChartMaster_Bulk)
            'arrExcluded.Add(clsUserMgtCode.rptDailyProgressReport)
            'arrExcluded.Add(clsUserMgtCode.rptShiftCodeWise)
            ''arrExcluded.Add(clsUserMgtCode.RptBulkMilkRegister)
            'arrExcluded.Add(clsUserMgtCode.rptSectionWiseStockReport)
            'arrExcluded.Add(clsUserMgtCode.frmAssetRequisition)

            ' '' payroll reports 
            'arrExcluded.Add(clsUserMgtCode.frmAditionalEarning_DeductionReport)
            'arrExcluded.Add(clsUserMgtCode.frmAttendedDaysReport)
            'arrExcluded.Add(clsUserMgtCode.frmDeductionDetailsReport)
            'arrExcluded.Add(clsUserMgtCode.frmOT_Reports)
            'arrExcluded.Add(clsUserMgtCode.frmSalaryComponentDetails)
            'arrExcluded.Add(clsUserMgtCode.frmSalaryIncrementReport)
            'arrExcluded.Add(clsUserMgtCode.frmSalarySheet_Reports)
            'arrExcluded.Add(clsUserMgtCode.frmSalaryVoucher_Reports)
            'arrExcluded.Add(clsUserMgtCode.frmVarianceReport)
            'arrExcluded.Add(clsUserMgtCode.FrmSalarySlipRpt)
            'arrExcluded.Add(clsUserMgtCode.FrmAMAcquisitionCode)

            ''===shivani against ticket[BM00000009243,BM00000009240] 
            'arrExcluded.Add(clsUserMgtCode.RptMultiplePaymentAdvice1)
            'arrExcluded.Add(clsUserMgtCode.RptVehicleWiseReport)
            ''==============
            ''arrExcluded.Add(clsUserMgtCode.FrmEmployeePFRpt)
            '' arrExcluded.Add(clsUserMgtCode.RptBOILetterReport)
            ''arrExcluded.Add(clsUserMgtCode.frmSalaryCertificate)
            ''arrExcluded.Add(clsUserMgtCode.frmNewSalCertificate)
            'arrExcluded.Add(clsUserMgtCode.frmEmployeeIncrement)
            ''arrExcluded.Add(clsUserMgtCode.rptMCCMilkRegisterDripSaver)
            'arrExcluded.Add(clsUserMgtCode.rptVSPOrVLCVarationRpt)
            ''=======================
            'arrExcluded.Add(clsUserMgtCode.frmLeaveAllotment)
            'arrExcluded.Add(clsUserMgtCode.frmLeaveOpeningBalance)
            ' ''===against [BM00000008017]
            'arrExcluded.Add(clsUserMgtCode.frmVisi_Install_Pullout_Report)
            'arrExcluded.Add(clsUserMgtCode.frmDistributor_VS_SecondaryCustomer_Sale)
            'arrExcluded.Add(clsUserMgtCode.frmSecondaryCustomer)
            'arrExcluded.Add(clsUserMgtCode.frmSecondaryCustomerSale)
            'arrExcluded.Add(clsUserMgtCode.frmVisi_Install_Pullout)

            'arrExcluded.Add(clsUserMgtCode.mbtnItemMovement)
            'arrExcluded.Add(clsUserMgtCode.DVAT30)
            'arrExcluded.Add(clsUserMgtCode.DVAT31)
            'arrExcluded.Add(clsUserMgtCode.CrptRG1Detail1)
            'arrExcluded.Add(clsUserMgtCode.frmExciseChapterWise)
            'arrExcluded.Add(clsUserMgtCode.FrmPurchasebookReport1)
            'arrExcluded.Add(clsUserMgtCode.frmEmp_Id)
            'arrExcluded.Add(clsUserMgtCode.frmLabelPrinting)
            'arrExcluded.Add(clsUserMgtCode.frmPF_Covering_Letter)
            'arrExcluded.Add(clsUserMgtCode.frmPF_Covering_Letter)
            'arrExcluded.Add(clsUserMgtCode.frmBankStatement_Reports)
            'arrExcluded.Add(clsUserMgtCode.frmSalaryCertificate)
            'arrExcluded.Add(clsUserMgtCode.frmESICRpt)
            'arrExcluded.Add(clsUserMgtCode.frmNewSalCertificate)
            'arrExcluded.Add(clsUserMgtCode.RptBOILetterReport)
            'arrExcluded.Add(clsUserMgtCode.rptMilkPaymentRegister)
            'arrExcluded.Add(clsUserMgtCode.rptCollectionCenterChart)
            'arrExcluded.Add(clsUserMgtCode.rptCollectionLevelChart)
            'arrExcluded.Add(clsUserMgtCode.CustomerDetails)
            'arrExcluded.Add(clsUserMgtCode.mbtnCustomerEmptyTrial)
            ' '' TDS EXCLUSION -Master
            'arrExcluded.Add(clsUserMgtCode.FinancialYear)
            'arrExcluded.Add(clsUserMgtCode.BranchDetails)
            'arrExcluded.Add(clsUserMgtCode.ResponsiblePerson)
            'arrExcluded.Add(clsUserMgtCode.StateCode)

            ' '' TDS EXCLUSION -Transaction
            'arrExcluded.Add(clsUserMgtCode.mbtnCreateRemittance)
            'arrExcluded.Add(clsUserMgtCode.remittanceentry)

            ' '' TDS EXCLUSION -Reports
            'arrExcluded.Add(clsUserMgtCode.TDSForm26Q)
            'arrExcluded.Add(clsUserMgtCode.Form16AReport)
            'arrExcluded.Add(clsUserMgtCode.TDSSectionSummaryReport)
            ' ''Purchase Report
            'arrExcluded.Add(clsUserMgtCode.Parti_VS_Rejected)
            'arrExcluded.Add(clsUserMgtCode.frmPendingSaleInvoiceforChilpPO)
            'If Not clsCommon.CompairString(objCommonVar.CurrentUserCode, "Admin") = CompairStringResult.Equal Then
            '    Dim dtNEWSC As DataTable = clsDBFuncationality.GetDataTable("select TSPL_USER_MASTER.Default_Location,TSPL_Mcc_MASTER.MCC_NAME,TSPL_MCC_MASTER.is_Reuired_Gate_Entry from TSPL_USER_MASTER  inner join TSPL_Mcc_MASTER on TSPL_Mcc_MASTER.mcc_code=Default_Location where TSPL_USER_MASTER.User_Code='" + objCommonVar.CurrentUserCode + "' and isnull( is_Reuired_Gate_Entry,0)=1")
            '    If dtNEWSC Is Nothing OrElse dtNEWSC.Rows.Count <= 0 Then
            '        arrExcluded.Add(clsUserMgtCode.MilkGateEntryIn)
            '        arrExcluded.Add(clsUserMgtCode.MilkGateEntryWeightment)
            '        arrExcluded.Add(clsUserMgtCode.MilkGateEntryOut)
            '        arrExcluded.Add(clsUserMgtCode.MilkReject)
            '    Else
            '        dtNEWSC = Nothing
            '    End If
            'End If


            'If Not isLoadAppIntegrator Then
            '    arrExcluded.Add(clsUserMgtCode.frmAppIntegrator)
            'End If
            'If Not IsLoadMccBugReports Then
            '    arrExcluded.Add("SRNWtSample")
            '    arrExcluded.Add("SAMWTSRNRPT")
            '    arrExcluded.Add("RecWtSmpRpt")
            '    arrExcluded.Add("RcpWtDifRpt")
            'End If

            'If Not isLoadBulkPurchaseUploader Then
            '    arrExcluded.Add(clsUserMgtCode.frmBulkPurchaseUploader)
            'End If


            'If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.OpenPOforRejectShortageQty, clsFixedParameterCode.OpenPOforRejectShortageQty, Nothing)) = 0 Then
            '    arrExcluded.Add(clsUserMgtCode.RptPendingPO)
            'End If

            ''End Of code 
            ''-----------------------------If not Process Production then Excluded menu's---------------------------------
            ''Dim OpenProcessProductionBOm As Boolean = clsDBFuncationality.getSingleValue("select IsBOMFromProcessProduction from TSPL_INV_PARAMETERS")
            ''If Not OpenProcessProductionBOm Then
            ''    arrExcluded.Add(clsUserMgtCode.frmProcessProductionIssueEntry)
            ''End If
            ''----------------------------------------------------------------------------------------------------------------

            ''======================exclude schedule form is po scheduling off---
            'If clsCommon.CompairString(clsCommon.myCstr(clsFixedParameter.GetData(clsFixedParameterType.AllowPOScheduling, clsFixedParameterCode.AllowPOScheduling, Nothing)), "0") = CompairStringResult.Equal Then
            '    arrExcluded.Add(clsUserMgtCode.frmPurchaseSchedule)
            'End If
            'arrExcluded.Add(clsUserMgtCode.frmProductionEntryWithoutBatch)


            ''=======================================================

            'Dim strGrpWhrClas As String = ""
            'Dim strReadPermission As String = ""
            'If blnShowAllMenu = False Then
            '    strReadPermission = "TSPL_GROUP_PROGRAM_MAPPING.Read_Flag=1 and "
            'End If
            'If Not clsCommon.CompairString(objCommonVar.CurrentUserCode, "Admin") = CompairStringResult.Equal Then
            '    strGrpWhrClas += " and exists(select 1 from TSPL_GROUP_PROGRAM_MAPPING where " & strReadPermission & " TSPL_GROUP_PROGRAM_MAPPING.Program_Code=TSPL_PROGRAM_MASTER.Program_Code and TSPL_GROUP_PROGRAM_MAPPING.Group_Code in (select Group_Code  from TSPL_USER_GROUP_MAPPING where User_Code='" + objCommonVar.CurrentUserCode + "')) " + Environment.NewLine
            'End If
            ''===========Updated by rohit on may 27,2014. form will display according to module permission ===========
            'Dim sQuery As String = "select Module_Name from TSPL_MODULE_PERMISSION"
            'Dim dtmodule As DataTable = clsDBFuncationality.GetDataTable(sQuery)
            'For Each rowModule As DataRow In dtmodule.Rows()
            '    If arrExcluded.Contains(rowModule("Module_Name")) Then
            '        arrExcluded.Remove(rowModule("Module_Name"))
            '    End If
            'Next

            'If clsCommon.CompairString(clsCommon.myCstr(clsFixedParameter.GetData(clsFixedParameterType.INDUSTRYTYPE, clsFixedParameterCode.INDUSTRYTYPE, Nothing)), "A") <> CompairStringResult.Equal Then
            '    'arrExcluded.Add(clsUserMgtCode.frmPartNoMaster)
            '    arrExcluded.Add(clsUserMgtCode.ModuleServiceAndWarranty)
            'End If

            'If clsCommon.CompairString(clsCommon.myCstr(clsFixedParameter.GetData(clsFixedParameterType.AllowQualityModuleInERP, clsFixedParameterCode.AllowQualityModuleInERP, Nothing)), "1") <> CompairStringResult.Equal Then
            '    arrExcluded.Add(clsUserMgtCode.ModuleQualityControl)
            'End If
            'arrExcluded.Add(clsUserMgtCode.frmPaySlip_Reports)
            'arrExcluded.Add(clsUserMgtCode.rptFromNO21)
            'arrExcluded.Add(clsUserMgtCode.rptFARReport)
            '' arrExcluded.Add(clsUserMgtCode.FrmItemTypeMaster)
            'arrExcluded.Add(clsUserMgtCode.rptVLCwiseTPTimeTable)
            
            Dim qry As String = "select distinct tt.* from (select sno AS [SERNO],Program_Code,Name,Parent_Code from (" + Environment.NewLine '"select Program_Code,Name,Parent_Code from (" + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where 2=2 and  Parent_Code is null " + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where 2=2 and  Type In ('SM') and Program_Code in (select distinct Parent_Code from TSPL_PROGRAM_MASTER where 2=2  )" + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where 2=2 and  Type In ('M') and Program_Code in (select distinct Parent_Code from TSPL_PROGRAM_MASTER where Program_Code in (select distinct Parent_Code from TSPL_PROGRAM_MASTER where 2=2 ))" + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where Program_Code='" + clsUserMgtCode.ModuleFavourite + "' " + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER where 2=2 " + Environment.NewLine
            qry += " union all " + Environment.NewLine
            qry += " select TSPL_FAVOURITE_MENU.Program_Code,case when LEN(isnull(TSPL_PROGRAM_MASTER.Re_Name,''))>0 then TSPL_PROGRAM_MASTER.Re_Name else TSPL_PROGRAM_MASTER.Program_Name end as Name,'" + clsUserMgtCode.ModuleFavourite + "' as Parent_Code,TSPL_FAVOURITE_MENU.SNo from TSPL_FAVOURITE_MENU " + Environment.NewLine
            qry += " left outer join  TSPL_PROGRAM_MASTER on TSPL_PROGRAM_MASTER.Program_Code= TSPL_FAVOURITE_MENU.Program_Code  where 2=2 and TSPL_FAVOURITE_MENU.User_Code='" + objCommonVar.CurrentUserCode + "' " + Environment.NewLine
            qry += " )xxx where 2=2 "
            

            qry += ") tt     "
            '' Stop User Rights code
            If Not clsCommon.CompairString(objCommonVar.CurrentUserCode, "Parteek") = CompairStringResult.Equal Then
                '  qry += " where  tt.SERNO in ( select distinct TSPL_PROGRAM_MASTER.SNo  from TSPL_MAPPING_USER_GROUP_DETAIL inner join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_GROUP_DETAIL on TSPL_PROGRAM_GROUP_DETAIL.PROGRAM_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_MASTER on   TSPL_PROGRAM_MASTER.Program_Code =  TSPL_PROGRAM_GROUP_DETAIL.Program_Code where TSPL_PROGRAM_GROUP_DETAIL.isREAD=1 and TSPL_MAPPING_USER_GROUP_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "')  or  tt.SERNO in (select distinct TSPL_PROGRAM_MASTER.SNo from TSPL_PROGRAM_MASTER where Program_Code in ( select distinct TSPL_PROGRAM_MASTER.Parent_Code from TSPL_PROGRAM_MASTER inner join TSPL_PROGRAM_MASTER as TSPL_PROGRAM_MASTER_2 on TSPL_PROGRAM_MASTER.Program_Code= TSPL_PROGRAM_MASTER_2.Program_Code  where TSPL_PROGRAM_MASTER.SNo in (( select  distinct TSPL_PROGRAM_MASTER.SNo  from TSPL_MAPPING_USER_GROUP_DETAIL inner join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_GROUP_DETAIL on TSPL_PROGRAM_GROUP_DETAIL.PROGRAM_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_MASTER on   TSPL_PROGRAM_MASTER.Program_Code =  TSPL_PROGRAM_GROUP_DETAIL.Program_Code where TSPL_PROGRAM_GROUP_DETAIL.isREAD=1 and TSPL_MAPPING_USER_GROUP_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "')))) or tt.SERNO in (select distinct TSPL_PROGRAM_MASTER.SNo from TSPL_PROGRAM_MASTER where Program_Code in ( select distinct TSPL_PROGRAM_MASTER.Parent_Code from TSPL_PROGRAM_MASTER inner join TSPL_PROGRAM_MASTER as TSPL_PROGRAM_MASTER_2 on TSPL_PROGRAM_MASTER.Program_Code= TSPL_PROGRAM_MASTER_2.Program_Code  where TSPL_PROGRAM_MASTER.SNo in (select distinct TSPL_PROGRAM_MASTER.SNo  from TSPL_PROGRAM_MASTER where Program_Code in ( select distinct TSPL_PROGRAM_MASTER.Parent_Code from TSPL_PROGRAM_MASTER inner join TSPL_PROGRAM_MASTER as TSPL_PROGRAM_MASTER_2 on TSPL_PROGRAM_MASTER.Program_Code= TSPL_PROGRAM_MASTER_2.Program_Code  where TSPL_PROGRAM_MASTER.SNo in (( select distinct TSPL_PROGRAM_MASTER.SNo  from TSPL_MAPPING_USER_GROUP_DETAIL inner join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_GROUP_DETAIL on TSPL_PROGRAM_GROUP_DETAIL.PROGRAM_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_MASTER on   TSPL_PROGRAM_MASTER.Program_Code =  TSPL_PROGRAM_GROUP_DETAIL.Program_Code where TSPL_PROGRAM_GROUP_DETAIL.isREAD=1 and TSPL_MAPPING_USER_GROUP_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "'))))))  or  tt.SERNO in (  select SNo from TSPL_PROGRAM_MASTER  where 2=2 and  Parent_Code is null )"
            End If
            '' end
            qry += "  order by SERNO" '" order by SNo"
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)


            RTV2.DataSource = Nothing
            RTV2.TreeViewElement.AutoSizeItems = True
            RTV2.ShowLines = True
            RTV2.ShowRootLines = True
            RTV2.TreeViewElement.ViewElement.Margin = New Padding(4)
            RTV2.ShowExpandCollapse = True
            RTV2.TreeIndent = 15
            RTV2.FullRowSelect = False
            RTV2.ShowLines = True
            RTV2.LineStyle = TreeLineStyle.Dot
            RTV2.LineColor = Color.FromArgb(110, 153, 210)
            RTV2.ExpandAnimation = ExpandAnimation.Opacity
            RTV2.AllowEdit = False
            RTV2.ShowRootLines = False
            'RTV2.TreeViewElement.AllowAlternatingRowColor = True
            'RTV2.TreeViewElement.AlternatingRowColor = Color.AliceBlue
            'RTV2.TreeViewElement.AngleTransform = 270
            'RTV2.TreeViewElement.RightToLeft = True
            'RTV2.TreeViewElement.DrawBorder = True
            RTV2.ValueMember = "Program_Code"
            RTV2.DisplayMember = "Name"
            RTV2.ChildMember = "Program_Code"
            RTV2.ParentMember = "Parent_Code"
            RTV2.DataSource = dt

            'LoadMenuInCombo()
            '' Set Image
            'For i As Integer = 0 To RTV2.Nodes.Count - 1
            '    SetImage(RTV2.Nodes(i))
            'Next
            RTV2.Nodes.Add("")
            RTV2.Nodes.Add("")
            RTV2.Nodes.Add("")
            RTV2.AllowEdit = False
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

        RTV2.CollapseAll()
        If RTV2.Nodes.Count > 0 Then
            RTV2.Nodes(0).Expand()
        End If

    End Sub

    Protected Sub SetImage(ByVal subRoot As RadTreeNode)
        ' check for null (this can be removed since within th
        If (subRoot Is Nothing) Then
            Exit Sub
        End If
        If ArrImageList.ContainsKey(clsCommon.myCstr(subRoot.Value)) Then
            subRoot.Image = ImageList1.Images.Item(ArrImageList(clsCommon.myCstr(subRoot.Value)))
        End If
        ' add all it's children
        For i As Integer = 0 To subRoot.Nodes.Count - 1
            SetImage(subRoot.Nodes(i))
        Next
    End Sub

    Public Sub LoadImageList()
        ArrImageList.Clear()
        Dim qry As String = "select Program_Code,Image_Number from TSPL_PROGRAM_MASTER"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        For Each dr As DataRow In dt.Rows
            ArrImageList.Add(clsCommon.myCstr(dr("Program_Code")), clsCommon.myCdbl(dr("Image_Number")))
        Next

        qry = "select Program_Code  from TSPL_PROGRAM_MASTER where Parent_Code is null or Type in ('M')"
        dt = clsDBFuncationality.GetDataTable(qry)
        For Each dr As DataRow In dt.Rows
            ArrBold.Add(clsCommon.myCstr(dr("Program_Code")))
        Next
    End Sub

    Sub LoadMenuInCombo()
        'GC.Collect()
        Try
            If clsCommon.myLen(clsDBFuncationality.connectionString) > 0 Then
                'Dim strGrpWhrClas As String = ""
                'Dim strReadPermission As String = ""
                'If blnShowAllMenu = False Then
                '    strReadPermission = "TSPL_GROUP_PROGRAM_MAPPING.Read_Flag=1 and "
                'End If
                'If Not clsCommon.CompairString(objCommonVar.CurrentUserCode, "Admin") = CompairStringResult.Equal Then
                '    strGrpWhrClas += " and exists(select 1 from TSPL_GROUP_PROGRAM_MAPPING where " & strReadPermission & " TSPL_GROUP_PROGRAM_MAPPING.Program_Code=TSPL_PROGRAM_MASTER.Program_Code and TSPL_GROUP_PROGRAM_MAPPING.Group_Code in (select Group_Code  from TSPL_USER_GROUP_MAPPING where User_Code='" + objCommonVar.CurrentUserCode + "')) " + Environment.NewLine
                'End If
                'Dim qry As String = "select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as PROGRAM_NAME from TSPL_PROGRAM_MASTER  inner join (select Module_Name,Program_Code as [prg_Code] from tspl_Program_Master tpm inner join tspl_Module_Permission tmm on tpm.Parent_Code=tmm.Module_Name" _
                '& " union select 'MFavourite','MFavourite' " & IIf(isUtilityAdded, "Union select Program_Code as [Module_Name],Program_Code as [prg_Code] from tspl_Program_Master where Parent_Code ='Mutility'", "") & ") tmm on tspl_Program_Master.Parent_Code=tmm.prg_Code where 2=2 and  TSPL_PROGRAM_MASTER.Program_Code not in (" + Environment.NewLine
                'qry += " select Program_Code from TSPL_PROGRAM_MASTER where Parent_Code in (select Program_Code from TSPL_PROGRAM_MASTER where Parent_Code in (select Program_Code from TSPL_PROGRAM_MASTER as innerProgramMaster where innerProgramMaster.Program_Code in (" + clsCommon.GetMulcallString(arrExcluded) + ") and Type='M') and Type='SM')"
                'qry += " union "
                'qry += " select Program_Code from TSPL_PROGRAM_MASTER where Program_Code in (" + clsCommon.GetMulcallString(arrExcluded) + ") and type=''"

                'qry += " )  " + strGrpWhrClas + " and Type Not in ('M','SM')  and Parent_Code is not null   order by PROGRAM_NAME "
                'Dim qry As String = "  select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as PROGRAM_NAME from TSPL_PROGRAM_MASTER where Type Not in ('M','SM')  and Parent_Code is not null  and sno in (select distinct TSPL_PROGRAM_MASTER.SNo  from TSPL_MAPPING_USER_GROUP_DETAIL inner join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_GROUP_DETAIL on TSPL_PROGRAM_GROUP_DETAIL.PROGRAM_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_MASTER on   TSPL_PROGRAM_MASTER.Program_Code =  TSPL_PROGRAM_GROUP_DETAIL.Program_Code where TSPL_PROGRAM_GROUP_DETAIL.isREAD=1 and TSPL_MAPPING_USER_GROUP_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "')  order by PROGRAM_NAME "

                Dim qry As String = "  select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as PROGRAM_NAME from TSPL_PROGRAM_MASTER where Type Not in ('M','SM')  and Parent_Code is not null  "

                'and sno in (select distinct TSPL_PROGRAM_MASTER.SNo  from TSPL_MAPPING_USER_GROUP_DETAIL inner join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_GROUP_DETAIL on TSPL_PROGRAM_GROUP_DETAIL.PROGRAM_GROUP_CODE = TSPL_MAPPING_USER_GROUP_DETAIL.USER_GROUP_CODE inner join TSPL_PROGRAM_MASTER on   TSPL_PROGRAM_MASTER.Program_Code =  TSPL_PROGRAM_GROUP_DETAIL.Program_Code where TSPL_PROGRAM_GROUP_DETAIL.isREAD=1 and TSPL_MAPPING_USER_GROUP_DETAIL.USER_CODE ='" + objCommonVar.CurrentUserCode + "')  
                qry += " order by PROGRAM_NAME "

                Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
                Dim dr As DataRow = dt.NewRow()
                dr("Program_Code") = Nothing
                dr("PROGRAM_NAME") = Nothing
                dt.Rows.InsertAt(dr, 0)
                cboMenu.DataSource = dt
                cboMenu.ValueMember = "Program_Code"
                cboMenu.DisplayMember = "PROGRAM_NAME"
                cboMenu.SelectedIndex = 0
                cboMenu.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains
            End If
        Catch ex As Exception

        End Try
        cboMenu.NullText = "Quick Menu"

    End Sub

    Private Sub MDI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.F12 Then
        '    If lblDataBase.Visibility = ElementVisibility.Visible Then
        '        lblDataBase.Visibility = ElementVisibility.Hidden
        '        RadLabelElement1.Visibility = ElementVisibility.Hidden
        '    Else
        '        lblDataBase.Visibility = ElementVisibility.Visible
        '        RadLabelElement1.Visibility = ElementVisibility.Visible
        '    End If
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.U Then
        '    isUtilityAdded = Not isUtilityAdded
        '    LoadMenu()
        'ElseIf e.Control AndAlso e.KeyCode = Keys.U Then
        '    Dim frm As New FrmItemConverion()
        '    frm.Show()
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.C AndAlso clsCommon.CompairString(objCommonVar.CurrentUserCode, "pankajjha") = CompairStringResult.Equal Then
        '    Dim s As String = InputBox("Enter Query")
        '    clsCommon.MyMessageBoxShow(MSSQLTOORACLE.Covert(s))
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.M Then
        '    Dim dbpwd As String = clsDBFuncationality.getSingleValue("select Description from TSPL_FIXED_PARAMETER where Code='USERPWD' and TYPE='PWD'")
        '    Dim pwd As New FrmPWD(Nothing)
        '    pwd.strCode = "USERPWD"
        '    pwd.strType = "PWD"
        '    pwd.ShowDialog()
        '    If pwd.isPasswordCorrect Then
        '        Dim frmmodule As New frmModuleScreen
        '        frmmodule.ShowDialog()
        '        LoadMenu()
        '    End If
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.I Then
        '    Dim dbpwd As String = clsDBFuncationality.getSingleValue("select Description from TSPL_FIXED_PARAMETER where Code='USERPWD' and TYPE='PWD'")
        '    Dim pwd As New FrmPWD(Nothing)
        '    pwd.strCode = "USERPWD"
        '    pwd.strType = "PWD"
        '    pwd.ShowDialog()
        '    If pwd.isPasswordCorrect Then
        '        isLoadAppIntegrator = True
        '        LoadMenu()
        '    Else
        '        isLoadAppIntegrator = False
        '    End If
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.P Then
        '    Dim dbpwd As String = clsDBFuncationality.getSingleValue("select Description from TSPL_FIXED_PARAMETER where Code='USERPWD' and TYPE='PWD'")
        '    Dim pwd As New FrmPWD(Nothing)
        '    pwd.strCode = clsFixedParameterCode.UploaderPassword
        '    pwd.strType = clsFixedParameterType.UploaderPassword
        '    pwd.ShowDialog()
        '    If pwd.isPasswordCorrect Then
        '        isLoadBulkPurchaseUploader = True
        '        LoadMenu()
        '    Else
        '        isLoadBulkPurchaseUploader = False
        '    End If

        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.W Then
        '    Dim dbpwd As String = clsDBFuncationality.getSingleValue("select Description from TSPL_FIXED_PARAMETER where Code='USERPWD' and TYPE='PWD'")
        '    Dim pwd As New FrmPWD(Nothing)
        '    pwd.strCode = "USERPWD"
        '    pwd.strType = "PWD"
        '    pwd.ShowDialog()
        '    If pwd.isPasswordCorrect Then
        '        IsLoadMccBugReports = True
        '        LoadMenu()
        '    Else
        '        IsLoadMccBugReports = False
        '    End If
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.Y Then
        '    Dim pwd As New FrmPWD(Nothing)
        '    pwd.strCode = clsFixedParameterCode.DocumentSequence
        '    pwd.strType = clsFixedParameterType.DocumentSequence
        '    pwd.ShowDialog()
        '    If pwd.isPasswordCorrect Then
        '        Dim frm As New frmDocumentSequence()
        '        frm.MdiParent = Me
        '        frm.Show()
        '    End If
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.Z Then

        '    Dim frmPWD As New FrmPWD(Nothing)
        '    frmPWD.strType = clsFixedParameterType.SettlementBankOnlyPWD
        '    frmPWD.strCode = clsFixedParameterCode.SettlementBankOnlyPWD
        '    frmPWD.ShowDialog()
        '    If frmPWD.isPasswordCorrect Then
        '        Dim frm As New frmUnCleardDoc()
        '        frm.MdiParent = Me
        '        frm.Show()
        '    End If
        'ElseIf e.Control AndAlso e.Alt AndAlso e.Shift AndAlso e.KeyCode = Keys.B Then
        '    Dim pwd As New FrmPWD(Nothing)
        '    pwd.strCode = clsFixedParameterCode.MilkProcurementUploader
        '    pwd.strType = clsFixedParameterType.MilkProcurementUploader
        '    pwd.ShowDialog()
        '    If pwd.isPasswordCorrect Then
        '        Dim frm As New frmMilkProcurementUploader()
        '        frm.MdiParent = Me
        '        frm.Show()
        '    End If
        'End If
    End Sub

    Private Sub cboMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMenu.KeyDown
        Try

            If clsCommon.myLen(clsCommon.myCstr(cboMenu.SelectedValue)) > 0 AndAlso clsCommon.myLen(clsCommon.myCstr(cboMenu.Text)) > 0 Then
                If e.KeyCode = Keys.Enter Then
                    ShowForm(clsCommon.myCstr(cboMenu.SelectedValue), clsCommon.myCstr(cboMenu.SelectedText), True)
                    RTV2.CollapseAll()
                    RTV2.Nodes(0).Expand()
                    Try
                        RTV2.SelectedNode = RTV2.Nodes(0)
                        RTV2.SelectedNode = RTV2.Find(cboMenu.SelectedText)
                        RTV2.SelectedNode.Expand()
                    Catch ex As Exception
                    End Try
                End If
            Else
                cboMenu.SelectedIndex = 0
            End If

        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub RTV2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RTV2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If RTV2.SelectedNode IsNot Nothing Then
                Dim strCode As String = clsCommon.myCstr(RTV2.SelectedNode.Value)
                If clsCommon.myLen(strCode) > 0 Then
                    ShowForm(strCode, clsCommon.myCstr(RTV2.SelectedNode.Text), True)
                End If
            End If
        End If
    End Sub

    Public Sub ShowForm(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal isOpenInMDI As Boolean)
        ShowForm(strProgramCode, strProgramName, isOpenInMDI, "")
    End Sub
    Public Sub ShowForm(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal isOpenInMDI As Boolean, ByVal strDocNo As String, Optional ByVal IFTrueShowFormElseShowDialog As Boolean = True, Optional ByVal IsAllowModificationByApprovalUser As Boolean = False)
        GC.Collect()

        If Not strProgramCode Is Nothing Then
            strProgramName = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select case when LEN(ISNULL(Re_Name,''))>0 then Re_Name else Program_Name end as Program_Name from TSPL_PROGRAM_MASTER where Program_Code='" + strProgramCode + "'"))

            Dim qry As String = " select * from tspl_Program_master where Program_code='" & strProgramCode & "'"

            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim IsRunFromOtherAsm As Integer = clsCommon.myCdbl(dt.Rows(0)("IsLoadFromOtherAssembly"))
                If IsRunFromOtherAsm = 1 Then
                    Dim FormName As String = clsCommon.myCstr(dt.Rows(0)("FormName"))
                    Dim AsmName As String = clsCommon.myCstr(Application.StartupPath & "\" & dt.Rows(0)("OtherAssemblyFilePathAndName"))
                    Dim AsmToLoad As Assembly = Nothing
                    Dim obj As Object = Nothing
                    AsmToLoad = Assembly.LoadFile(AsmName)
                    Dim classType As Type = AsmToLoad.[GetType](FormName)
                    'obj = AsmToLoad.CreateInstance("ERP." & FormName, True)
                    ' Dim M As Assembly.Module = AsmToLoad.FrmMainTranScreen
                    obj = AsmToLoad.CreateInstance(FormName, True)
                    Dim frm As RadForm = TryCast(obj, RadForm)
                    If isOpenInMDI Then
                        frm.MdiParent = Me
                        frm.Text = strProgramName
                        frm.Show()
                    Else
                        If clsCommon.myLen(strDocNo) > 0 Then
                            frm.Tag = strDocNo
                        End If
                        frm.WindowState = FormWindowState.Maximized
                        frm.Text = strProgramName
                        frm.ShowDialog()
                    End If
                    Exit Sub
                End If
            End If


            ''Dipti----------------------Utility---------------------------------------------------------
            'If clsCommon.CompairString(strProgramCode, clsUserMgtCode.mbtnCreateReceiptAgainstSale) = CompairStringResult.Equal Then
            '    frm = New FrmCreateReceiptAgainstSales()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.mbtnCreateReceiptAgainstInvoice) = CompairStringResult.Equal Then
            '    frm = New FrmCreateReceiptAgainstInvoice()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.mbtnTakeBackup) = CompairStringResult.Equal Then
            '    frm = New FrmBackup()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.mbtnRestoreDB) = CompairStringResult.Equal Then
            '    Dim strMsg As String = "Your current tasks will be closed." + Environment.NewLine
            '    strMsg += "Do you want to continue?"
            '    If clsCommon.MyMessageBoxShow(strMsg, Me.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
            '        RadDock1.RemoveAllDocumentWindows()
            '        SplitPanel3.Collapsed = True
            '        SplitPanel2.Collapsed = True
            '        SplitPanel3.Collapsed = True
            '        SplitPanel4.Collapsed = False
            '    End If
            'ElseIf clsCommon.CompairString(strProgramCode, "calc") = CompairStringResult.Equal Then
            '    System.Diagnostics.Process.Start("calc.exe")
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.mbtnPendingApproval1) = CompairStringResult.Equal Then
            '    frm = New FrmPendingAproval()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmBulkPostingNew) = CompairStringResult.Equal Then
            '    frm = New FrmBulkPostingNew()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.lockTransaction) = CompairStringResult.Equal Then
            '    frm = New FrmLockTransaction1()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmUserPerformanceDetail) = CompairStringResult.Equal Then
            '    frm = New FrmUserPerformanceDetail()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmStockReport) = CompairStringResult.Equal Then
            '    frm = New FrmStockReport(lblUserCode.Text, lblCompanyCode.Text)
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmReconciliationSetting) = CompairStringResult.Equal Then
            '    frm = New FrmReconciliationSetting()
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)





            'ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.rptCustomerAdvanceReg) = CompairStringResult.Equal Then
            '    frm = New frmAdvanceRegister
            '    formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)

            'End If

            If clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmClientMaster) = CompairStringResult.Equal Then
                frm = New FrmClientMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmExamMaster) = CompairStringResult.Equal Then
                frm = New frmExamSet
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmExamStudent) = CompairStringResult.Equal Then
                frm = New frmExamStudentMapping
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.RptExamList) = CompairStringResult.Equal Then
                frm = New RptExamListReport
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.RptExamResult) = CompairStringResult.Equal Then
                frm = New RptExamResult
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.RptStudentHistoy) = CompairStringResult.Equal Then
                frm = New RptStudnetHistory
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmExamReloader) = CompairStringResult.Equal Then
                frm = New frmExamReloader
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmModuleMaster) = CompairStringResult.Equal Then
                frm = New FrmModuleMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmScreenMaster) = CompairStringResult.Equal Then
                frm = New FrmScreenMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmUserGroupMaster) = CompairStringResult.Equal Then
                frm = New FrmUserGroupMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmGroupProgramMapping) = CompairStringResult.Equal Then
                frm = New FrmGroupProgramMapping
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmUserMaster) = CompairStringResult.Equal Then
                frm = New FrmUserMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmTimeMaster) = CompairStringResult.Equal Then
                frm = New FrmTimeMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmUserGroupMaping) = CompairStringResult.Equal Then
                frm = New FrmUserGroupMaping
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmTicketMaster) = CompairStringResult.Equal Then
                frm = New FrmTicketMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmTicketAllocation) = CompairStringResult.Equal Then
                frm = New FrmTicketMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmRequestCreation) = CompairStringResult.Equal Then
                frm = New FrmRequestCreation
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmTimeSheet) = CompairStringResult.Equal Then
                frm = New FrmTicketMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmRequestAnalysis) = CompairStringResult.Equal Then
                frm = New FrmRequestAnalysis
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmRequestApproval) = CompairStringResult.Equal Then
                frm = New FrmRequestApproval
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmRequestStatus) = CompairStringResult.Equal Then
                frm = New FrmRequestStatus
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmCreateEXE) = CompairStringResult.Equal Then
                frm = New frmCreateEXE
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmCompanyMaster) = CompairStringResult.Equal Then
                frm = New FrmCompanyMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmActivationKey) = CompairStringResult.Equal Then
                frm = New frmActivationKey
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            End If
        End If

        frm = Nothing
    End Sub

    Private Sub RadContextMenu2_DropDownOpening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RadContextMenu2.DropDownOpening
        Try
            RadContextMenu2.Items.Clear()
            If clsCommon.CompairString(clsCommon.myCstr(RTV2.SelectedNode.Value), clsUserMgtCode.TeamMgmt) = CompairStringResult.Equal OrElse clsCommon.CompairString(clsCommon.myCstr(RTV2.SelectedNode.Value), clsUserMgtCode.ModuleFavourite) = CompairStringResult.Equal Then
                e.Cancel = True
            End If

            Dim mbtnChangeCaption As New RadMenuItem("Change Caption")
            AddHandler mbtnChangeCaption.Click, AddressOf ChangeCaption
            RadContextMenu2.Items.Add(mbtnChangeCaption)
            If Not clsCommon.CompairString(clsCommon.myCstr(RTV2.SelectedNode.Value), clsUserMgtCode.TeamMgmt) = CompairStringResult.Equal Then
                If clsCommon.CompairString(clsCommon.myCstr(RTV2.SelectedNode.Parent.Value), clsUserMgtCode.ModuleFavourite) = CompairStringResult.Equal Then
                    Dim mbtnRemoveFromFavourite As New RadMenuItem("Remove from Favourite")
                    AddHandler mbtnRemoveFromFavourite.Click, AddressOf RemoveFromFavourite
                    RadContextMenu2.Items.Add(mbtnRemoveFromFavourite)
                Else
                    Dim mbtnAddToFavourite As New RadMenuItem("Add To Favourite")
                    AddHandler mbtnAddToFavourite.Click, AddressOf AddToFavourite
                    RadContextMenu2.Items.Add(mbtnAddToFavourite)
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub ChangeCaption()
        'Dim frm As New frmChangeCaption()
        'frm.strProgramCode = clsCommon.myCstr(RTV2.SelectedNode.Value)
        'frm.ShowDialog()
        'LoadMenu()
    End Sub

    Private Sub AddToFavourite()
        Try
            clsFavouriteMenu.SaveData(RTV2.SelectedNode.Value)
            LoadMenu()
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Sub RemoveFromFavourite()
        Try
            clsFavouriteMenu.DeleteData(RTV2.SelectedNode.Value)
            LoadMenu()
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Public Sub formShow(ByVal frm As FrmMainTranScreen, ByVal strProgramCode As String, ByVal strProgramName As String, ByVal isOpenInMDI As Boolean, ByVal strDocNo As String, Optional ByVal IFTrueShowFormElseShowDialog As Boolean = True)
        Try
            frm.Tag = strDocNo
            frm.Text = strProgramName
            'frm.SetUserMgmt(strProgramCode)

            If IFTrueShowFormElseShowDialog Then
                If isOpenInMDI Then
                    frm.MdiParent = Me
                Else
                    frm.WindowState = FormWindowState.Maximized
                End If
                frm.Focus()
                frm.Show()
                If isApplicationRun Then
                    isApplicationRun = False
                    'frm.WindowState = FormWindowState.Maximized
                    Application.Run(frm)
                Else
                    'frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                End If
            Else
                frm.ShowDialog(Me)
                frm.TopMost = True


            End If
        Catch ex As Exception
            If Not ex.Message.Contains("Object reference not set to an instance of an object.") Then ''becuase when need to close the form this message come.
                common.clsCommon.MyMessageBoxShow(ex.Message)
                frm.Close()
            End If
        End Try
    End Sub

    Private Sub btnEditCaption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCaption.Click
        RTV2.CollapseAll()
        RTV2.Nodes(0).Expand()
    End Sub

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click
        RTV2.ExpandAll()
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New FrmCarousal(Me)
        'frm.MdiParent = Me
        'frm.Show()
        'frm.Focus()
    End Sub

    Private Sub txtUserName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckAndLogin()
        End If
    End Sub

    Private Sub RTV2_NodeFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.TreeNodeFormattingEventArgs) Handles RTV2.NodeFormatting
        If ArrBold.Contains(clsCommon.myCstr(e.Node.Value)) Then
            e.NodeElement.ContentElement.Text = "<html><b>" & e.Node.Text
        End If
    End Sub

    Private Sub RadMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadMenuItem1.Click
        'Dim objLogin As UserLoginInfo = New UserLoginInfo
        'objLogin.Show()
    End Sub

    Private Sub RadMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadMenuItem2.Click
        RadDock1.RemoveAllDocumentWindows()
        SplitPanel3.Collapsed = True
        SplitPanel1.Collapsed = True
        SplitPanel4.Collapsed = True
        SplitPanel2.Collapsed = False

        txtUserName.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub RadMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadMenuItem3.Click
        Me.Close()
        'txtPassword.Text = String.Empty
        'txtUserName.Text = String.Empty
        'LoadLoginScreen()
    End Sub

    Private Sub RadDock1_DockStateChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Docking.DockWindowEventArgs) Handles RadDock1.DockStateChanged
        ' Set Image
        For i As Integer = 0 To RTV2.Nodes.Count - 1
            SetImage(RTV2.Nodes(i))
        Next
    End Sub

    Private Sub MDI_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Try
        '    Dim strQ As String = "update tspl_user_master set IP_Address=NULL,Login_Status=0 where user_code='" + objCommonVar.CurrentUserCode + "'"
        '    clsDBFuncationality.ExecuteNonQuery(strQ)

        '    Dim frmCollection As New FormCollection()
        '    frmCollection = Application.OpenForms()
        '    If frmCollection.Item("frmMccDispatch").IsHandleCreated Then
        '        If FrmMccDispatch.isPortOpened Then
        '            e.Cancel = True
        '            clsCommon.MyMessageBoxShow("Can not Close Application. Please Close MCC Dispatch Form because it uses an Opened Serial Port")
        '            Exit Sub
        '        End If
        '    End If

        '    If frmCollection.Item("frmQualityCheck").IsHandleCreated Then
        '        If FrmQualityCheck.isPortOpened Then
        '            e.Cancel = True
        '            clsCommon.MyMessageBoxShow("Can not Close Application. Please Close Quality Check Form because it uses an Opened Serial Port")
        '            Exit Sub
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try

        If Not IsDBRestored Then
            If Not isAutoClosing Then
                If clsCommon.MyMessageBoxShow("Do you want to close the Exam ERP", Me.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                    'Else
                    '    'GC.Collect()
                Else

                End If
            End If
        End If

        If th IsNot Nothing Then
            Try
                th.Abort()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub SplitPanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitPanel2.Click

    End Sub

    Private Sub RadMenuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadMenuItem4.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\KIWI help.chm")
    End Sub

    Private Function GetMasterDBConnectionStr(ByVal strDBName As String) As String
        Try
            Dim strConn As String = clsDBFuncationality.connectionString ''clsCommon.myCstr(Configuration.ConfigurationSettings.AppSettings("connectionString"))
            strConn = clsCommon.ReplaceString(strConn, strDBName, "Master")
            Return strConn
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        Try
            If clsCommon.myLen(txtDBSource.Text) <= 0 Then
                bDestination.Focus()
                Throw New Exception("Please select source file.")
            End If

            Dim strMsg As String = "You are going to restore" + Environment.NewLine
            strMsg += " DataBase : - '" + cmbDB.SelectedValue + "'" + Environment.NewLine
            strMsg += " Company : - '" + cmbDB.SelectedText + "'" + Environment.NewLine
            strMsg += " Are you sure?"
            If clsCommon.MyMessageBoxShow(strMsg, Me.Text, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                If RestoreDataBase("" + cmbDB.SelectedValue + "") Then
                    clsCommon.ProgressBarHide()
                    common.clsCommon.MyMessageBoxShow("DataBase Restored Sucessfully.")
                    IsDBRestored = True
                    Application.Restart()
                End If
            End If
        Catch ex As Exception
            clsCommon.ProgressBarHide()
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Private Function RestoreDataBase(ByVal strDBName As String) As Boolean
        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand
        Try
            clsDBFuncationality.ExecuteNonQuery("Update TSPL_UserLogin_Info set Logout_DateTime=' " + clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm tt") + "'  where Login_Code ='" + objCommonVar.CurrentLoginID + "'")
            clsDBFuncationality.ExecuteNonQuery("ALTER DATABASE " + cmbDB.SelectedValue + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE")
            Dim ConStr As String = GetMasterDBConnectionStr(strDBName)
            conn = clsDBFuncationality.GetConnnection()
            If conn.State = ConnectionState.Open Then
                conn.Close()
                conn.Dispose()
            End If
            conn = New SqlConnection(ConStr)
            cmd = New SqlCommand("sp_StopDBProcess", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn
            conn.Open()
            cmd.Parameters.Add("@strDBName", SqlDbType.VarChar).Value = strDBName
            cmd.ExecuteNonQuery()
            Dim qry As String = "Restore database " + strDBName + " from Disk = '" + txtDBSource.Text + "'"
            cmd = New SqlCommand(qry, conn)
            cmd.CommandTimeout = 3600
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            clsCommon.ProgressBarHide()
            cmd = New SqlCommand("ALTER DATABASE " + cmbDB.SelectedValue + "  SET MULTI_USER", conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            clsDBFuncationality.SetConnection(objCommonVar.ConnString)
        End Try
        Return True
    End Function

    Private Sub bDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDestination.Click
        Try
            OpenFileDialog1.InitialDirectory = "C:\"
            OpenFileDialog1.Title = "Open a DataBase File"
            OpenFileDialog1.Filter = "DataBase Files|*.bak"
            If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtDBSource.Text = OpenFileDialog1.FileName
            Else
                txtDBSource.Text = ""
            End If
        Catch ex As Exception
            RadMessageBox.Show("Error: " + ex.Message)
        End Try
    End Sub

    Private Sub RadButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton13.Click
        LoadLoginScreen()
    End Sub

    Private Sub RTV2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles RTV2.DoubleClick


    End Sub

    Private Sub RTV2_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles RTV2.NodeMouseDoubleClick
        Try
            Dim strCode As String = clsCommon.myCstr(RTV2.SelectedNode.Value)
            If clsCommon.myLen(strCode) > 0 Then
                ShowForm(strCode, RTV2.SelectedNode.Text, True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MDI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub mnuRefreshMem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefreshMem.Click
        GC.Collect()
        GC.WaitForPendingFinalizers()
        clsCommon.MyMessageBoxShow("Memory Refreshed ")
    End Sub

    Private Sub RadMenuItem3_Disposing(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadMenuItem3.Disposing

    End Sub

#Region "Reminder Code" '-----------By Monika--------04/07/2014----------BM00000003039
    'Private Sub ReminderTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReminderTimer.Tick
    '    Try
    '        Dim ccccc As Integer = 0
    '        Dim cn As SqlConnection = clsDBFuncationality.GetConnnection()
    '        Dim Qry As String = "select count(*) from sys.dm_tran_database_transactions where isnull(database_transaction_status,0)>0"
    '        Dim cmd As SqlCommand = New SqlCommand(Qry, cn)
    '        cn.Close()
    '        cn.Open()
    '        Try
    '            ccccc = CInt(cmd.ExecuteScalar())
    '        Catch exx As Exception
    '            ccccc = 0
    '        End Try
    '        cn.Close()

    '        If ccccc > 0 Then
    '            Exit Sub
    '        End If

    '        Qry = "select count(*) from information_schema.TABLES where table_name='TSPL_DISPLAY_NOTIFICATIONS'"
    '        ccccc = clsDBFuncationality.getSingleValue(Qry)
    '        If ccccc <= 0 Then
    '            Return
    '        End If

    '        Dim xtime As String = ""
    '        xtime = clsCommon.myCstr(clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(), "dd/MMM/yyyy hh:mm:ss tt"))
    '        Qry = "select 'Trans_Id : '+doc_id+' Notification : '+message+'(Detail :'+item_name+ ')' as values1 from TSPL_DISPLAY_NOTIFICATIONS where user_code='" + objCommonVar.CurrentUserCode + "' and status<>'1' and isnull(snooze_time,'')<='" + xtime + "'"
    '        Dim dt As DataTable = clsDBFuncationality.GetDataTable(Qry)
    '        Dim str As String = ""

    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            For Each dr As DataRow In dt.Rows()
    '                str = clsCommon.myCstr(dr("values1"))
    '                If clsCommon.myLen(str) > 0 Then
    '                    RadDesktopAlert1.AutoClose = False
    '                    RadDesktopAlert1.ShowOptionsButton = False
    '                    RadDesktopAlert1.ShowCloseButton = False


    '                    radbuttonelement.Tag = str
    '                    radbuttonDontShow.Tag = str


    '                    RadDesktopAlert1.FixedSize = New Size(529, 100)
    '                    RadDesktopAlert1.CaptionText = "Notification :"
    '                    RadDesktopAlert1.PopupAnimation = True
    '                    RadDesktopAlert1.ContentText = str
    '                    RadDesktopAlert1.Show()

    '                    arralert.Add(str, RadDesktopAlert1)
    '                    ReminderTimer.Enabled = False
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub radbuttonelement_Click(ByVal sender As Object, ByVal e As EventArgs)
        'snoozeOrDontShowAgain(sender, True)
        'ReminderTimer.Enabled = True
    End Sub

    Private Sub DontShowAgain_Click(ByVal sender As Object, ByVal e As EventArgs)
        'snoozeOrDontShowAgain(sender, False)
        'ReminderTimer.Enabled = True
    End Sub

    'Sub snoozeOrDontShowAgain(ByVal sender As Object, ByVal issnoozed As Boolean)
    '    Dim radButtonElement As RadButtonElement = TryCast(sender, RadButtonElement)
    '    Dim strCode As String = clsCommon.myCstr(radButtonElement.Tag)
    '    If clsCommon.myLen(strCode) > 0 Then
    '        If arralert.ContainsKey(strCode) Then
    '            arralert(strCode).Hide()
    '            arralert.Remove(strCode)
    '            If issnoozed Then
    '                clsfrmNotificationScreen.Snooze(strCode)
    '            Else
    '                clsfrmNotificationScreen.DontShowAgain(strCode)
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region

    Private Sub RadMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadMenuItem6.Click, RadMenuItem7.Click, RadMenuItem8.Click, RadMenuItem9.Click, RadMenuItem10.Click, RadMenuItem11.Click, RadMenuItem12.Click, RadMenuItem13.Click, RadMenuItem14.Click, RadMenuItem15.Click, RadMenuItem16.Click, RadMenuItem17.Click, RadMenuItem18.Click, RadMenuItem19.Click, RadMenuItem20.Click, RadMenuItem21.Click, RadMenuItem22.Click
        Try
            Dim OldThemeName As String = ""
            Dim clickedCtrl As Telerik.WinControls.UI.RadMenuItem = DirectCast(sender, Telerik.WinControls.UI.RadMenuItem)
            ThemeResolutionService.ApplicationThemeName = clickedCtrl.Text
            OldThemeName = ""
            Dim FILE_NAME As String = Application.StartupPath + "\Theme.Txp"
            If System.IO.File.Exists(FILE_NAME) Then
                '==============read theme name from existing file============
                Dim objreader As New System.IO.StringReader(FILE_NAME)
                If objreader IsNot Nothing AndAlso clsCommon.myLen(objreader) > 0 Then
                    OldThemeName = clsCommon.myCstr(objreader.ReadToEnd())

                End If
                '==================================
                System.IO.File.Delete(FILE_NAME)
            End If
            File.Create(FILE_NAME).Dispose()
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            objWriter.Write(clickedCtrl.Text)
            Me.OldThemeName = clickedCtrl.Text
            objWriter.Close()
            'Me.OldThemeName = FILE_NAME
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try
    End Sub

    Sub LoadTheme()
        Try
            Dim line As String
            Dim objReader As New System.IO.StreamReader("Theme.Txp")
            Do While objReader.Peek() <> -1
                line = objReader.ReadLine()
                ThemeResolutionService.ApplicationThemeName = line
                OldThemeName = line
            Loop
            ''stuti regarding memory leakage
            objReader.Close()
            objReader.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadMenuItem5_DropDownOpening()
        Try

            If OldThemeName IsNot Nothing AndAlso OldThemeName.Length > 0 Then
                RadMenuItem6.IsChecked = False
                RadMenuItem7.IsChecked = False
                RadMenuItem8.IsChecked = False
                RadMenuItem9.IsChecked = False
                RadMenuItem10.IsChecked = False
                RadMenuItem11.IsChecked = False
                RadMenuItem12.IsChecked = False
                RadMenuItem13.IsChecked = False
                RadMenuItem14.IsChecked = False
                RadMenuItem15.IsChecked = False
                RadMenuItem16.IsChecked = False
                RadMenuItem17.IsChecked = False
                RadMenuItem18.IsChecked = False
                RadMenuItem19.IsChecked = False
                RadMenuItem20.IsChecked = False
                RadMenuItem21.IsChecked = False
                RadMenuItem22.IsChecked = False
                If clsCommon.CompairString(RadMenuItem6.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem6.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem7.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem7.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem8.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem8.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem9.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem9.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem10.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem10.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem11.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem11.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem12.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem12.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem13.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem13.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem14.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem14.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem15.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem15.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem16.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem16.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem17.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem17.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem18.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem18.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem19.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem19.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem20.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem20.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem21.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem21.IsChecked = True
                ElseIf clsCommon.CompairString(RadMenuItem22.Text, OldThemeName) = CompairStringResult.Equal Then
                    RadMenuItem22.IsChecked = True


                End If
            End If

        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub

    Private Sub RadMenuItem5_DropDownOpening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RadMenuItem5.DropDownOpening
        RadMenuItem5_DropDownOpening()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Try
            If clsDBFuncationality.isQueryRun Then
                FrmMainTranScreen.LastWorkingTime = DateTime.Now()
            End If
            Dim IdleSec As Long = DateDiff(DateInterval.Second, FrmMainTranScreen.LastWorkingTime, DateTime.Now)
            '    Me.Text = IdleSec
            If IdleSec > 0 Then
                If IdleSec > IdleTimeinSeconds Then
                    isAutoClosing = True
                    'clsERPFuncationality.closeForm(Me)
                    Application.Restart()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MDI_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Try
            FrmMainTranScreen.LastWorkingTime = DateTime.Now()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MDI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            FrmMainTranScreen.LastWorkingTime = DateTime.Now()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadDock1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RadDock1.MouseMove

    End Sub

    Private Sub lblChangePWD_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Try
            If clsCommon.myLen(txtUserName.Text) <= 0 Then
                Throw New Exception("Please Enter User Name")
            End If
            Dim isUserfound As Integer = 0
            isUserfound = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(*) from TSPL_USER_MASTER where user_code='" & txtUserName.Text & "'"))
            If isUserfound = 0 Then
                Throw New Exception("Invalid User Name")
            End If
            objCommonVar.CurrentUserCode = txtUserName.Text
            objCommonVar.CurrentUser = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select user_name from TSPL_USER_MASTER where user_code='" & txtUserName.Text & "'"))

            Dim frm1 As RadForm = New FrmChangePassword()
            frm1.StartPosition = FormStartPosition.CenterScreen
            frm1.MaximizeBox = False
            frm1.MinimizeBox = False
            frm1.ControlBox = False
            frm1.Location = Me.PictureBox1.Location
            frm1.Height = Me.PictureBox1.Height + 50
            frm1.Width = Me.PictureBox1.Width + 50
            frm1.ShowDialog()


        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Private Sub Receipt_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadMenuItem23_Click(sender As Object, e As EventArgs) Handles RadMenuItem23.Click
        'Dim frm As New FrmLicenceActivate()
        'frm.ShowDialog()
    End Sub

    Private Sub OpenFormFromOtherDLL()
        Try
            th = New Threading.Thread(AddressOf OpenFormFromOtherDLLMain)
            th.Start()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenFormFromOtherDLLMain()
        If clsCommon.myLen(objCommonVar.ScreenToOpen) > 0 Then
            th1 = New Threading.Thread(AddressOf ShowFormFinal)
            th1.Start()
        End If

        Dim i As Int64 = 0
        While i <= 400000000
            i = i + 1
        End While
        'Try
        '    th1.Abort()
        'Catch ex As Exception
        'End Try

        OpenFormFromOtherDLLMain()
    End Sub
    Sub ShowFormFinal()
        'Dim localScreenToOpen As String = objCommonVar.ScreenToOpen
        'Dim localDocToOpen As String = objCommonVar.ScreenToOpenDocNo
        'objCommonVar.ScreenToOpenDocNo = ""
        'objCommonVar.ScreenToOpen = ""
        '__txtDocNo.Text = ""
        '__txtScreenID.Text = ""
        'If objCommonVar.ScreenToOpen_Text <> "" Then
        '    Dim frm As New frmBalanceQty
        '    frm.strUOM = objCommonVar.ScreenToOpenUOM
        '    frm.IsMRPMandatory = objCommonVar.ScreenToOpenIsMRPMandatory
        '    frm._METEXT = "Order Quantity"
        '    'If _IsMRPMandatory Then
        '    frm.qry = objCommonVar.ScreenToOpenQry
        '    'End If
        '    frm.Show()
        'Else
        '    If clsCommon.myLen(localScreenToOpen) > 0 Then
        '        isApplicationRun = False
        '        ShowForm(localScreenToOpen, "", False, IIf(clsCommon.myLen(localDocToOpen) > 0, localDocToOpen, ""))
        '    End If
        'End If

    End Sub

    Private Sub __txtDocNo_TextChanged(sender As Object, e As EventArgs) Handles __txtDocNo.TextChanged
        If clsCommon.myLen(__txtDocNo.Text) > 0 AndAlso clsCommon.myLen(__txtScreenID.Text) > 0 Then
            objCommonVar.ScreenToOpen = __txtScreenID.Text
            objCommonVar.ScreenToOpenDocNo = __txtDocNo.Text
            ShowFormFinal()
        End If
    End Sub

    Private Sub __txtScreenID_TextChanged(sender As Object, e As EventArgs) Handles __txtScreenID.TextChanged
        If clsCommon.myLen(__txtDocNo.Text) > 0 AndAlso clsCommon.myLen(__txtScreenID.Text) > 0 Then
            objCommonVar.ScreenToOpen = __txtScreenID.Text
            objCommonVar.ScreenToOpenDocNo = __txtDocNo.Text
            ShowFormFinal()
        End If
    End Sub










End Class
