<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTicketMasterNewEntry
    Inherits TeamMgmt.FrmMainTranScreen

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lblTotalTestingTime = New common.Controls.MyLabel()
        Me.lblTotalDevelopmentTime = New common.Controls.MyLabel()
        Me.txtActualTestedTime = New common.MyNumBox()
        Me.MyLabel20 = New common.Controls.MyLabel()
        Me.RadGroupBox6 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtTestingExeVersion = New common.Controls.MyTextBox()
        Me.txtDevelopmentExeVersion = New common.Controls.MyTextBox()
        Me.MyLabel4 = New common.Controls.MyLabel()
        Me.MyLabel6 = New common.Controls.MyLabel()
        Me.txtTestingTime = New common.MyNumBox()
        Me.txtDevelopmentTime = New common.MyNumBox()
        Me.txtAllocatedTime = New common.MyNumBox()
        Me.cboTicketStatus = New common.Controls.MyComboBox()
        Me.MyLabel21 = New common.Controls.MyLabel()
        Me.MyLabel16 = New common.Controls.MyLabel()
        Me.MyLabel18 = New common.Controls.MyLabel()
        Me.lblScreen = New common.Controls.MyLabel()
        Me.MyLabel19 = New common.Controls.MyLabel()
        Me.txtScreen = New common.UserControls.txtFinder()
        Me.lblTester = New common.Controls.MyLabel()
        Me.txtTester = New common.UserControls.txtFinder()
        Me.RadLabel2 = New common.Controls.MyLabel()
        Me.MyLabel17 = New common.Controls.MyLabel()
        Me.lblDeveloper = New common.Controls.MyLabel()
        Me.txtDeveloper = New common.UserControls.txtFinder()
        Me.MyLabel15 = New common.Controls.MyLabel()
        Me.lblCreatedBy = New common.Controls.MyLabel()
        Me.txtCreatedBy = New common.UserControls.txtFinder()
        Me.MyLabel5 = New common.Controls.MyLabel()
        Me.lblAnalysisDate = New common.Controls.MyLabel()
        Me.lblAnalysisNo = New common.Controls.MyLabel()
        Me.lblRequestDate = New common.Controls.MyLabel()
        Me.lblRequestNo = New common.Controls.MyLabel()
        Me.cboPriority = New common.Controls.MyComboBox()
        Me.cboSeverity = New common.Controls.MyComboBox()
        Me.cboDataErrorType = New common.Controls.MyComboBox()
        Me.cboTicketType = New common.Controls.MyComboBox()
        Me.MyLabel14 = New common.Controls.MyLabel()
        Me.MyLabel13 = New common.Controls.MyLabel()
        Me.MyLabel12 = New common.Controls.MyLabel()
        Me.MyLabel11 = New common.Controls.MyLabel()
        Me.MyLabel10 = New common.Controls.MyLabel()
        Me.MyLabel9 = New common.Controls.MyLabel()
        Me.MyLabel8 = New common.Controls.MyLabel()
        Me.MyLabel7 = New common.Controls.MyLabel()
        Me.lblProject = New common.Controls.MyLabel()
        Me.txtProject = New common.UserControls.txtFinder()
        Me.lblModule = New common.Controls.MyLabel()
        Me.txtModule = New common.UserControls.txtFinder()
        Me.MyLabel3 = New common.Controls.MyLabel()
        Me.MyLabel2 = New common.Controls.MyLabel()
        Me.MyLabel1 = New common.Controls.MyLabel()
        Me.lblClient = New common.Controls.MyLabel()
        Me.txtClient = New common.UserControls.txtFinder()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTicketDate = New common.Controls.MyDateTimePicker()
        Me.txtTicketNo = New common.UserControls.txtNavigator()
        Me.btnreset1 = New Telerik.WinControls.UI.RadButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtAllocationRemarks = New common.Controls.MyTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTicketDescription = New common.Controls.MyTextBox()
        Me.RadPageViewPage4 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtDeveloperYourRemarks = New common.Controls.MyTextBox()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtDeveloperRreviousRemarks = New common.Controls.MyTextBox()
        Me.RadPageViewPage5 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadGroupBox5 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTesterYourRemarks = New common.Controls.MyTextBox()
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtTesterPreviousRemarks = New common.Controls.MyTextBox()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.RadPageViewPage3 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.UcAttachment1 = New TeamMgmt.ucAttachment()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        CType(Me.lblTotalTestingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalDevelopmentTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActualTestedTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox6.SuspendLayout()
        CType(Me.txtTestingExeVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDevelopmentExeVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTestingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDevelopmentTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAllocatedTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTicketStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTester, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDeveloper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCreatedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnalysisDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnalysisNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRequestDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRequestNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSeverity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDataErrorType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTicketType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblModule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTicketDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage2.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.txtAllocationRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtTicketDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage4.SuspendLayout()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.txtDeveloperYourRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.txtDeveloperRreviousRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage5.SuspendLayout()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTesterYourRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.txtTesterPreviousRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage3.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadPageView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDelete)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Size = New System.Drawing.Size(683, 516)
        Me.SplitContainer1.SplitterDistance = 478
        Me.SplitContainer1.TabIndex = 0
        '
        'RadPageView1
        '
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage4)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage5)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage3)
        Me.RadPageView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView1.Location = New System.Drawing.Point(0, 0)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.RadPageViewPage1
        Me.RadPageView1.Size = New System.Drawing.Size(683, 478)
        Me.RadPageView1.TabIndex = 0
        Me.RadPageView1.Text = "RadPageView1"
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.lblTotalTestingTime)
        Me.RadPageViewPage1.Controls.Add(Me.lblTotalDevelopmentTime)
        Me.RadPageViewPage1.Controls.Add(Me.txtActualTestedTime)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel20)
        Me.RadPageViewPage1.Controls.Add(Me.RadGroupBox6)
        Me.RadPageViewPage1.Controls.Add(Me.txtTestingTime)
        Me.RadPageViewPage1.Controls.Add(Me.txtDevelopmentTime)
        Me.RadPageViewPage1.Controls.Add(Me.txtAllocatedTime)
        Me.RadPageViewPage1.Controls.Add(Me.cboTicketStatus)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel21)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel16)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel18)
        Me.RadPageViewPage1.Controls.Add(Me.lblScreen)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel19)
        Me.RadPageViewPage1.Controls.Add(Me.txtScreen)
        Me.RadPageViewPage1.Controls.Add(Me.lblTester)
        Me.RadPageViewPage1.Controls.Add(Me.txtTester)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel17)
        Me.RadPageViewPage1.Controls.Add(Me.lblDeveloper)
        Me.RadPageViewPage1.Controls.Add(Me.txtDeveloper)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel15)
        Me.RadPageViewPage1.Controls.Add(Me.lblCreatedBy)
        Me.RadPageViewPage1.Controls.Add(Me.txtCreatedBy)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel5)
        Me.RadPageViewPage1.Controls.Add(Me.lblAnalysisDate)
        Me.RadPageViewPage1.Controls.Add(Me.lblAnalysisNo)
        Me.RadPageViewPage1.Controls.Add(Me.lblRequestDate)
        Me.RadPageViewPage1.Controls.Add(Me.lblRequestNo)
        Me.RadPageViewPage1.Controls.Add(Me.cboPriority)
        Me.RadPageViewPage1.Controls.Add(Me.cboSeverity)
        Me.RadPageViewPage1.Controls.Add(Me.cboDataErrorType)
        Me.RadPageViewPage1.Controls.Add(Me.cboTicketType)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel14)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel13)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel12)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel11)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel10)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel9)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel8)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel7)
        Me.RadPageViewPage1.Controls.Add(Me.lblProject)
        Me.RadPageViewPage1.Controls.Add(Me.txtProject)
        Me.RadPageViewPage1.Controls.Add(Me.lblModule)
        Me.RadPageViewPage1.Controls.Add(Me.txtModule)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel3)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel2)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel1)
        Me.RadPageViewPage1.Controls.Add(Me.lblClient)
        Me.RadPageViewPage1.Controls.Add(Me.RadLabel2)
        Me.RadPageViewPage1.Controls.Add(Me.txtClient)
        Me.RadPageViewPage1.Controls.Add(Me.Label3)
        Me.RadPageViewPage1.Controls.Add(Me.txtTicketDate)
        Me.RadPageViewPage1.Controls.Add(Me.txtTicketNo)
        Me.RadPageViewPage1.Controls.Add(Me.btnreset1)
        Me.RadPageViewPage1.Controls.Add(Me.Label1)
        Me.RadPageViewPage1.ItemSize = New System.Drawing.SizeF(103.0!, 28.0!)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(662, 430)
        Me.RadPageViewPage1.Text = "Basic Information"
        '
        'lblTotalTestingTime
        '
        Me.lblTotalTestingTime.AutoSize = False
        Me.lblTotalTestingTime.BorderVisible = True
        Me.lblTotalTestingTime.FieldName = Nothing
        Me.lblTotalTestingTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTestingTime.Location = New System.Drawing.Point(288, 405)
        Me.lblTotalTestingTime.Name = "lblTotalTestingTime"
        Me.lblTotalTestingTime.Size = New System.Drawing.Size(76, 18)
        Me.lblTotalTestingTime.TabIndex = 236
        Me.lblTotalTestingTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotalTestingTime.TextWrap = False
        '
        'lblTotalDevelopmentTime
        '
        Me.lblTotalDevelopmentTime.AutoSize = False
        Me.lblTotalDevelopmentTime.BorderVisible = True
        Me.lblTotalDevelopmentTime.FieldName = Nothing
        Me.lblTotalDevelopmentTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDevelopmentTime.Location = New System.Drawing.Point(288, 366)
        Me.lblTotalDevelopmentTime.Name = "lblTotalDevelopmentTime"
        Me.lblTotalDevelopmentTime.Size = New System.Drawing.Size(76, 18)
        Me.lblTotalDevelopmentTime.TabIndex = 235
        Me.lblTotalDevelopmentTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotalDevelopmentTime.TextWrap = False
        '
        'txtActualTestedTime
        '
        Me.txtActualTestedTime.BackColor = System.Drawing.Color.White
        Me.txtActualTestedTime.CalculationExpression = Nothing
        Me.txtActualTestedTime.DecimalPlaces = 2
        Me.txtActualTestedTime.FieldCode = Nothing
        Me.txtActualTestedTime.FieldDesc = Nothing
        Me.txtActualTestedTime.FieldMaxLength = 5
        Me.txtActualTestedTime.FieldName = Nothing
        Me.txtActualTestedTime.isCalculatedField = False
        Me.txtActualTestedTime.IsSourceFromTable = False
        Me.txtActualTestedTime.IsSourceFromValueList = False
        Me.txtActualTestedTime.IsUnique = False
        Me.txtActualTestedTime.Location = New System.Drawing.Point(192, 405)
        Me.txtActualTestedTime.MendatroryField = False
        Me.txtActualTestedTime.MyLinkLable1 = Nothing
        Me.txtActualTestedTime.MyLinkLable2 = Nothing
        Me.txtActualTestedTime.Name = "txtActualTestedTime"
        Me.txtActualTestedTime.ReferenceFieldDesc = Nothing
        Me.txtActualTestedTime.ReferenceFieldName = Nothing
        Me.txtActualTestedTime.ReferenceTableName = Nothing
        Me.txtActualTestedTime.Size = New System.Drawing.Size(89, 20)
        Me.txtActualTestedTime.TabIndex = 233
        Me.txtActualTestedTime.Text = "0"
        Me.txtActualTestedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtActualTestedTime.Value = 0.0R
        '
        'MyLabel20
        '
        Me.MyLabel20.FieldName = Nothing
        Me.MyLabel20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel20.Location = New System.Drawing.Point(7, 407)
        Me.MyLabel20.Name = "MyLabel20"
        Me.MyLabel20.Size = New System.Drawing.Size(106, 16)
        Me.MyLabel20.TabIndex = 234
        Me.MyLabel20.Text = "Actual Testing Time"
        '
        'RadGroupBox6
        '
        Me.RadGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox6.Controls.Add(Me.txtTestingExeVersion)
        Me.RadGroupBox6.Controls.Add(Me.txtDevelopmentExeVersion)
        Me.RadGroupBox6.Controls.Add(Me.MyLabel4)
        Me.RadGroupBox6.Controls.Add(Me.MyLabel6)
        Me.RadGroupBox6.HeaderText = "ERP Exe Version Info"
        Me.RadGroupBox6.Location = New System.Drawing.Point(302, 172)
        Me.RadGroupBox6.Name = "RadGroupBox6"
        Me.RadGroupBox6.Size = New System.Drawing.Size(357, 64)
        Me.RadGroupBox6.TabIndex = 232
        Me.RadGroupBox6.Text = "ERP Exe Version Info"
        '
        'txtTestingExeVersion
        '
        Me.txtTestingExeVersion.CalculationExpression = Nothing
        Me.txtTestingExeVersion.FieldCode = Nothing
        Me.txtTestingExeVersion.FieldDesc = Nothing
        Me.txtTestingExeVersion.FieldMaxLength = 0
        Me.txtTestingExeVersion.FieldName = Nothing
        Me.txtTestingExeVersion.isCalculatedField = False
        Me.txtTestingExeVersion.IsSourceFromTable = False
        Me.txtTestingExeVersion.IsSourceFromValueList = False
        Me.txtTestingExeVersion.IsUnique = False
        Me.txtTestingExeVersion.Location = New System.Drawing.Point(148, 39)
        Me.txtTestingExeVersion.MendatroryField = False
        Me.txtTestingExeVersion.MyLinkLable1 = Nothing
        Me.txtTestingExeVersion.MyLinkLable2 = Nothing
        Me.txtTestingExeVersion.Name = "txtTestingExeVersion"
        Me.txtTestingExeVersion.ReferenceFieldDesc = Nothing
        Me.txtTestingExeVersion.ReferenceFieldName = Nothing
        Me.txtTestingExeVersion.ReferenceTableName = Nothing
        Me.txtTestingExeVersion.Size = New System.Drawing.Size(196, 20)
        Me.txtTestingExeVersion.TabIndex = 236
        '
        'txtDevelopmentExeVersion
        '
        Me.txtDevelopmentExeVersion.CalculationExpression = Nothing
        Me.txtDevelopmentExeVersion.FieldCode = Nothing
        Me.txtDevelopmentExeVersion.FieldDesc = Nothing
        Me.txtDevelopmentExeVersion.FieldMaxLength = 0
        Me.txtDevelopmentExeVersion.FieldName = Nothing
        Me.txtDevelopmentExeVersion.isCalculatedField = False
        Me.txtDevelopmentExeVersion.IsSourceFromTable = False
        Me.txtDevelopmentExeVersion.IsSourceFromValueList = False
        Me.txtDevelopmentExeVersion.IsUnique = False
        Me.txtDevelopmentExeVersion.Location = New System.Drawing.Point(148, 17)
        Me.txtDevelopmentExeVersion.MendatroryField = False
        Me.txtDevelopmentExeVersion.MyLinkLable1 = Nothing
        Me.txtDevelopmentExeVersion.MyLinkLable2 = Nothing
        Me.txtDevelopmentExeVersion.Name = "txtDevelopmentExeVersion"
        Me.txtDevelopmentExeVersion.ReferenceFieldDesc = Nothing
        Me.txtDevelopmentExeVersion.ReferenceFieldName = Nothing
        Me.txtDevelopmentExeVersion.ReferenceTableName = Nothing
        Me.txtDevelopmentExeVersion.Size = New System.Drawing.Size(196, 20)
        Me.txtDevelopmentExeVersion.TabIndex = 235
        '
        'MyLabel4
        '
        Me.MyLabel4.FieldName = Nothing
        Me.MyLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel4.Location = New System.Drawing.Point(5, 41)
        Me.MyLabel4.Name = "MyLabel4"
        Me.MyLabel4.Size = New System.Drawing.Size(105, 16)
        Me.MyLabel4.TabIndex = 222
        Me.MyLabel4.Text = "Tested Exe Version"
        '
        'MyLabel6
        '
        Me.MyLabel6.FieldName = Nothing
        Me.MyLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel6.Location = New System.Drawing.Point(5, 20)
        Me.MyLabel6.Name = "MyLabel6"
        Me.MyLabel6.Size = New System.Drawing.Size(140, 16)
        Me.MyLabel6.TabIndex = 221
        Me.MyLabel6.Text = "Development Exe Version "
        '
        'txtTestingTime
        '
        Me.txtTestingTime.BackColor = System.Drawing.Color.White
        Me.txtTestingTime.CalculationExpression = Nothing
        Me.txtTestingTime.DecimalPlaces = 2
        Me.txtTestingTime.FieldCode = Nothing
        Me.txtTestingTime.FieldDesc = Nothing
        Me.txtTestingTime.FieldMaxLength = 5
        Me.txtTestingTime.FieldName = Nothing
        Me.txtTestingTime.isCalculatedField = False
        Me.txtTestingTime.IsSourceFromTable = False
        Me.txtTestingTime.IsSourceFromValueList = False
        Me.txtTestingTime.IsUnique = False
        Me.txtTestingTime.Location = New System.Drawing.Point(192, 384)
        Me.txtTestingTime.MendatroryField = False
        Me.txtTestingTime.MyLinkLable1 = Nothing
        Me.txtTestingTime.MyLinkLable2 = Nothing
        Me.txtTestingTime.Name = "txtTestingTime"
        Me.txtTestingTime.ReferenceFieldDesc = Nothing
        Me.txtTestingTime.ReferenceFieldName = Nothing
        Me.txtTestingTime.ReferenceTableName = Nothing
        Me.txtTestingTime.Size = New System.Drawing.Size(89, 20)
        Me.txtTestingTime.TabIndex = 70
        Me.txtTestingTime.Text = "0"
        Me.txtTestingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTestingTime.Value = 0.0R
        '
        'txtDevelopmentTime
        '
        Me.txtDevelopmentTime.BackColor = System.Drawing.Color.White
        Me.txtDevelopmentTime.CalculationExpression = Nothing
        Me.txtDevelopmentTime.DecimalPlaces = 2
        Me.txtDevelopmentTime.FieldCode = Nothing
        Me.txtDevelopmentTime.FieldDesc = Nothing
        Me.txtDevelopmentTime.FieldMaxLength = 5
        Me.txtDevelopmentTime.FieldName = Nothing
        Me.txtDevelopmentTime.isCalculatedField = False
        Me.txtDevelopmentTime.IsSourceFromTable = False
        Me.txtDevelopmentTime.IsSourceFromValueList = False
        Me.txtDevelopmentTime.IsUnique = False
        Me.txtDevelopmentTime.Location = New System.Drawing.Point(192, 364)
        Me.txtDevelopmentTime.MendatroryField = False
        Me.txtDevelopmentTime.MyLinkLable1 = Nothing
        Me.txtDevelopmentTime.MyLinkLable2 = Nothing
        Me.txtDevelopmentTime.Name = "txtDevelopmentTime"
        Me.txtDevelopmentTime.ReferenceFieldDesc = Nothing
        Me.txtDevelopmentTime.ReferenceFieldName = Nothing
        Me.txtDevelopmentTime.ReferenceTableName = Nothing
        Me.txtDevelopmentTime.Size = New System.Drawing.Size(89, 20)
        Me.txtDevelopmentTime.TabIndex = 16
        Me.txtDevelopmentTime.Text = "0"
        Me.txtDevelopmentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDevelopmentTime.Value = 0.0R
        '
        'txtAllocatedTime
        '
        Me.txtAllocatedTime.BackColor = System.Drawing.Color.White
        Me.txtAllocatedTime.CalculationExpression = Nothing
        Me.txtAllocatedTime.DecimalPlaces = 2
        Me.txtAllocatedTime.FieldCode = Nothing
        Me.txtAllocatedTime.FieldDesc = Nothing
        Me.txtAllocatedTime.FieldMaxLength = 5
        Me.txtAllocatedTime.FieldName = Nothing
        Me.txtAllocatedTime.isCalculatedField = False
        Me.txtAllocatedTime.IsSourceFromTable = False
        Me.txtAllocatedTime.IsSourceFromValueList = False
        Me.txtAllocatedTime.IsUnique = False
        Me.txtAllocatedTime.Location = New System.Drawing.Point(192, 343)
        Me.txtAllocatedTime.MendatroryField = False
        Me.txtAllocatedTime.MyLinkLable1 = Nothing
        Me.txtAllocatedTime.MyLinkLable2 = Nothing
        Me.txtAllocatedTime.Name = "txtAllocatedTime"
        Me.txtAllocatedTime.ReferenceFieldDesc = Nothing
        Me.txtAllocatedTime.ReferenceFieldName = Nothing
        Me.txtAllocatedTime.ReferenceTableName = Nothing
        Me.txtAllocatedTime.Size = New System.Drawing.Size(89, 20)
        Me.txtAllocatedTime.TabIndex = 15
        Me.txtAllocatedTime.Text = "0"
        Me.txtAllocatedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAllocatedTime.Value = 0.0R
        '
        'cboTicketStatus
        '
        Me.cboTicketStatus.AutoCompleteDisplayMember = Nothing
        Me.cboTicketStatus.AutoCompleteValueMember = Nothing
        Me.cboTicketStatus.CalculationExpression = Nothing
        Me.cboTicketStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboTicketStatus.FieldCode = Nothing
        Me.cboTicketStatus.FieldDesc = Nothing
        Me.cboTicketStatus.FieldMaxLength = 0
        Me.cboTicketStatus.FieldName = Nothing
        Me.cboTicketStatus.isCalculatedField = False
        Me.cboTicketStatus.IsSourceFromTable = False
        Me.cboTicketStatus.IsSourceFromValueList = False
        Me.cboTicketStatus.IsUnique = False
        Me.cboTicketStatus.Location = New System.Drawing.Point(560, 10)
        Me.cboTicketStatus.MendatroryField = True
        Me.cboTicketStatus.MyLinkLable1 = Nothing
        Me.cboTicketStatus.MyLinkLable2 = Nothing
        Me.cboTicketStatus.Name = "cboTicketStatus"
        Me.cboTicketStatus.ReferenceFieldDesc = Nothing
        Me.cboTicketStatus.ReferenceFieldName = Nothing
        Me.cboTicketStatus.ReferenceTableName = Nothing
        Me.cboTicketStatus.Size = New System.Drawing.Size(99, 20)
        Me.cboTicketStatus.TabIndex = 3
        '
        'MyLabel21
        '
        Me.MyLabel21.FieldName = Nothing
        Me.MyLabel21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel21.Location = New System.Drawing.Point(7, 345)
        Me.MyLabel21.Name = "MyLabel21"
        Me.MyLabel21.Size = New System.Drawing.Size(179, 16)
        Me.MyLabel21.TabIndex = 90
        Me.MyLabel21.Text = "Allocated Time (For Development)"
        '
        'MyLabel16
        '
        Me.MyLabel16.FieldName = Nothing
        Me.MyLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel16.Location = New System.Drawing.Point(7, 386)
        Me.MyLabel16.Name = "MyLabel16"
        Me.MyLabel16.Size = New System.Drawing.Size(121, 16)
        Me.MyLabel16.TabIndex = 86
        Me.MyLabel16.Text = "Allocated Testing Time"
        '
        'MyLabel18
        '
        Me.MyLabel18.FieldName = Nothing
        Me.MyLabel18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel18.Location = New System.Drawing.Point(7, 366)
        Me.MyLabel18.Name = "MyLabel18"
        Me.MyLabel18.Size = New System.Drawing.Size(101, 16)
        Me.MyLabel18.TabIndex = 87
        Me.MyLabel18.Text = "Development Time"
        '
        'lblScreen
        '
        Me.lblScreen.AutoSize = False
        Me.lblScreen.BorderVisible = True
        Me.lblScreen.FieldName = Nothing
        Me.lblScreen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreen.Location = New System.Drawing.Point(303, 52)
        Me.lblScreen.Name = "lblScreen"
        Me.lblScreen.Size = New System.Drawing.Size(356, 18)
        Me.lblScreen.TabIndex = 85
        Me.lblScreen.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblScreen.TextWrap = False
        '
        'MyLabel19
        '
        Me.MyLabel19.FieldName = Nothing
        Me.MyLabel19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel19.Location = New System.Drawing.Point(7, 52)
        Me.MyLabel19.Name = "MyLabel19"
        Me.MyLabel19.Size = New System.Drawing.Size(42, 16)
        Me.MyLabel19.TabIndex = 84
        Me.MyLabel19.Text = "Screen"
        '
        'txtScreen
        '
        Me.txtScreen.CalculationExpression = Nothing
        Me.txtScreen.FieldCode = Nothing
        Me.txtScreen.FieldDesc = Nothing
        Me.txtScreen.FieldMaxLength = 0
        Me.txtScreen.FieldName = Nothing
        Me.txtScreen.isCalculatedField = False
        Me.txtScreen.IsSourceFromTable = False
        Me.txtScreen.IsSourceFromValueList = False
        Me.txtScreen.IsUnique = False
        Me.txtScreen.Location = New System.Drawing.Point(106, 52)
        Me.txtScreen.MendatroryField = True
        Me.txtScreen.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScreen.MyLinkLable1 = Me.MyLabel19
        Me.txtScreen.MyLinkLable2 = Me.lblScreen
        Me.txtScreen.MyReadOnly = False
        Me.txtScreen.MyShowMasterFormButton = False
        Me.txtScreen.Name = "txtScreen"
        Me.txtScreen.ReferenceFieldDesc = Nothing
        Me.txtScreen.ReferenceFieldName = Nothing
        Me.txtScreen.ReferenceTableName = Nothing
        Me.txtScreen.Size = New System.Drawing.Size(190, 18)
        Me.txtScreen.TabIndex = 5
        Me.txtScreen.Value = ""
        '
        'lblTester
        '
        Me.lblTester.AutoSize = False
        Me.lblTester.BorderVisible = True
        Me.lblTester.FieldName = Nothing
        Me.lblTester.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTester.Location = New System.Drawing.Point(303, 152)
        Me.lblTester.Name = "lblTester"
        Me.lblTester.Size = New System.Drawing.Size(356, 18)
        Me.lblTester.TabIndex = 82
        Me.lblTester.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTester.TextWrap = False
        '
        'txtTester
        '
        Me.txtTester.CalculationExpression = Nothing
        Me.txtTester.FieldCode = Nothing
        Me.txtTester.FieldDesc = Nothing
        Me.txtTester.FieldMaxLength = 0
        Me.txtTester.FieldName = Nothing
        Me.txtTester.isCalculatedField = False
        Me.txtTester.IsSourceFromTable = False
        Me.txtTester.IsSourceFromValueList = False
        Me.txtTester.IsUnique = False
        Me.txtTester.Location = New System.Drawing.Point(106, 152)
        Me.txtTester.MendatroryField = True
        Me.txtTester.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTester.MyLinkLable1 = Me.RadLabel2
        Me.txtTester.MyLinkLable2 = Me.lblTester
        Me.txtTester.MyReadOnly = False
        Me.txtTester.MyShowMasterFormButton = False
        Me.txtTester.Name = "txtTester"
        Me.txtTester.ReferenceFieldDesc = Nothing
        Me.txtTester.ReferenceFieldName = Nothing
        Me.txtTester.ReferenceTableName = Nothing
        Me.txtTester.Size = New System.Drawing.Size(190, 18)
        Me.txtTester.TabIndex = 10
        Me.txtTester.Value = ""
        '
        'RadLabel2
        '
        Me.RadLabel2.FieldName = Nothing
        Me.RadLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(7, 31)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(38, 16)
        Me.RadLabel2.TabIndex = 48
        Me.RadLabel2.Text = "Client "
        '
        'MyLabel17
        '
        Me.MyLabel17.FieldName = Nothing
        Me.MyLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel17.Location = New System.Drawing.Point(7, 157)
        Me.MyLabel17.Name = "MyLabel17"
        Me.MyLabel17.Size = New System.Drawing.Size(38, 16)
        Me.MyLabel17.TabIndex = 80
        Me.MyLabel17.Text = "Tester"
        '
        'lblDeveloper
        '
        Me.lblDeveloper.AutoSize = False
        Me.lblDeveloper.BorderVisible = True
        Me.lblDeveloper.FieldName = Nothing
        Me.lblDeveloper.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeveloper.Location = New System.Drawing.Point(303, 132)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(356, 18)
        Me.lblDeveloper.TabIndex = 79
        Me.lblDeveloper.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDeveloper.TextWrap = False
        '
        'txtDeveloper
        '
        Me.txtDeveloper.CalculationExpression = Nothing
        Me.txtDeveloper.FieldCode = Nothing
        Me.txtDeveloper.FieldDesc = Nothing
        Me.txtDeveloper.FieldMaxLength = 0
        Me.txtDeveloper.FieldName = Nothing
        Me.txtDeveloper.isCalculatedField = False
        Me.txtDeveloper.IsSourceFromTable = False
        Me.txtDeveloper.IsSourceFromValueList = False
        Me.txtDeveloper.IsUnique = False
        Me.txtDeveloper.Location = New System.Drawing.Point(106, 132)
        Me.txtDeveloper.MendatroryField = True
        Me.txtDeveloper.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeveloper.MyLinkLable1 = Me.RadLabel2
        Me.txtDeveloper.MyLinkLable2 = Me.lblDeveloper
        Me.txtDeveloper.MyReadOnly = False
        Me.txtDeveloper.MyShowMasterFormButton = False
        Me.txtDeveloper.Name = "txtDeveloper"
        Me.txtDeveloper.ReferenceFieldDesc = Nothing
        Me.txtDeveloper.ReferenceFieldName = Nothing
        Me.txtDeveloper.ReferenceTableName = Nothing
        Me.txtDeveloper.Size = New System.Drawing.Size(190, 18)
        Me.txtDeveloper.TabIndex = 9
        Me.txtDeveloper.Value = ""
        '
        'MyLabel15
        '
        Me.MyLabel15.FieldName = Nothing
        Me.MyLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel15.Location = New System.Drawing.Point(7, 136)
        Me.MyLabel15.Name = "MyLabel15"
        Me.MyLabel15.Size = New System.Drawing.Size(58, 16)
        Me.MyLabel15.TabIndex = 77
        Me.MyLabel15.Text = "Developer"
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = False
        Me.lblCreatedBy.BorderVisible = True
        Me.lblCreatedBy.FieldName = Nothing
        Me.lblCreatedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedBy.Location = New System.Drawing.Point(303, 112)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(356, 18)
        Me.lblCreatedBy.TabIndex = 76
        Me.lblCreatedBy.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCreatedBy.TextWrap = False
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.CalculationExpression = Nothing
        Me.txtCreatedBy.FieldCode = Nothing
        Me.txtCreatedBy.FieldDesc = Nothing
        Me.txtCreatedBy.FieldMaxLength = 0
        Me.txtCreatedBy.FieldName = Nothing
        Me.txtCreatedBy.isCalculatedField = False
        Me.txtCreatedBy.IsSourceFromTable = False
        Me.txtCreatedBy.IsSourceFromValueList = False
        Me.txtCreatedBy.IsUnique = False
        Me.txtCreatedBy.Location = New System.Drawing.Point(106, 112)
        Me.txtCreatedBy.MendatroryField = True
        Me.txtCreatedBy.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreatedBy.MyLinkLable1 = Me.RadLabel2
        Me.txtCreatedBy.MyLinkLable2 = Me.lblCreatedBy
        Me.txtCreatedBy.MyReadOnly = False
        Me.txtCreatedBy.MyShowMasterFormButton = False
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReferenceFieldDesc = Nothing
        Me.txtCreatedBy.ReferenceFieldName = Nothing
        Me.txtCreatedBy.ReferenceTableName = Nothing
        Me.txtCreatedBy.Size = New System.Drawing.Size(190, 18)
        Me.txtCreatedBy.TabIndex = 8
        Me.txtCreatedBy.Value = ""
        '
        'MyLabel5
        '
        Me.MyLabel5.FieldName = Nothing
        Me.MyLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel5.Location = New System.Drawing.Point(7, 115)
        Me.MyLabel5.Name = "MyLabel5"
        Me.MyLabel5.Size = New System.Drawing.Size(63, 16)
        Me.MyLabel5.TabIndex = 74
        Me.MyLabel5.Text = "Created By"
        '
        'lblAnalysisDate
        '
        Me.lblAnalysisDate.AutoSize = False
        Me.lblAnalysisDate.BorderVisible = True
        Me.lblAnalysisDate.FieldName = Nothing
        Me.lblAnalysisDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnalysisDate.Location = New System.Drawing.Point(106, 324)
        Me.lblAnalysisDate.Name = "lblAnalysisDate"
        Me.lblAnalysisDate.Size = New System.Drawing.Size(190, 18)
        Me.lblAnalysisDate.TabIndex = 73
        Me.lblAnalysisDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAnalysisDate.TextWrap = False
        '
        'lblAnalysisNo
        '
        Me.lblAnalysisNo.AutoSize = False
        Me.lblAnalysisNo.BorderVisible = True
        Me.lblAnalysisNo.FieldName = Nothing
        Me.lblAnalysisNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnalysisNo.Location = New System.Drawing.Point(106, 303)
        Me.lblAnalysisNo.Name = "lblAnalysisNo"
        Me.lblAnalysisNo.Size = New System.Drawing.Size(190, 18)
        Me.lblAnalysisNo.TabIndex = 72
        Me.lblAnalysisNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAnalysisNo.TextWrap = False
        '
        'lblRequestDate
        '
        Me.lblRequestDate.AutoSize = False
        Me.lblRequestDate.BorderVisible = True
        Me.lblRequestDate.FieldName = Nothing
        Me.lblRequestDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestDate.Location = New System.Drawing.Point(106, 280)
        Me.lblRequestDate.Name = "lblRequestDate"
        Me.lblRequestDate.Size = New System.Drawing.Size(190, 18)
        Me.lblRequestDate.TabIndex = 71
        Me.lblRequestDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRequestDate.TextWrap = False
        '
        'lblRequestNo
        '
        Me.lblRequestNo.AutoSize = False
        Me.lblRequestNo.BorderVisible = True
        Me.lblRequestNo.FieldName = Nothing
        Me.lblRequestNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRequestNo.Location = New System.Drawing.Point(106, 260)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(190, 18)
        Me.lblRequestNo.TabIndex = 70
        Me.lblRequestNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRequestNo.TextWrap = False
        '
        'cboPriority
        '
        Me.cboPriority.AutoCompleteDisplayMember = Nothing
        Me.cboPriority.AutoCompleteValueMember = Nothing
        Me.cboPriority.CalculationExpression = Nothing
        Me.cboPriority.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboPriority.FieldCode = Nothing
        Me.cboPriority.FieldDesc = Nothing
        Me.cboPriority.FieldMaxLength = 0
        Me.cboPriority.FieldName = Nothing
        Me.cboPriority.isCalculatedField = False
        Me.cboPriority.IsSourceFromTable = False
        Me.cboPriority.IsSourceFromValueList = False
        Me.cboPriority.IsUnique = False
        Me.cboPriority.Location = New System.Drawing.Point(106, 238)
        Me.cboPriority.MendatroryField = True
        Me.cboPriority.MyLinkLable1 = Nothing
        Me.cboPriority.MyLinkLable2 = Nothing
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.ReferenceFieldDesc = Nothing
        Me.cboPriority.ReferenceFieldName = Nothing
        Me.cboPriority.ReferenceTableName = Nothing
        Me.cboPriority.Size = New System.Drawing.Size(190, 20)
        Me.cboPriority.TabIndex = 14
        '
        'cboSeverity
        '
        Me.cboSeverity.AutoCompleteDisplayMember = Nothing
        Me.cboSeverity.AutoCompleteValueMember = Nothing
        Me.cboSeverity.CalculationExpression = Nothing
        Me.cboSeverity.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboSeverity.FieldCode = Nothing
        Me.cboSeverity.FieldDesc = Nothing
        Me.cboSeverity.FieldMaxLength = 0
        Me.cboSeverity.FieldName = Nothing
        Me.cboSeverity.isCalculatedField = False
        Me.cboSeverity.IsSourceFromTable = False
        Me.cboSeverity.IsSourceFromValueList = False
        Me.cboSeverity.IsUnique = False
        Me.cboSeverity.Location = New System.Drawing.Point(106, 216)
        Me.cboSeverity.MendatroryField = True
        Me.cboSeverity.MyLinkLable1 = Nothing
        Me.cboSeverity.MyLinkLable2 = Nothing
        Me.cboSeverity.Name = "cboSeverity"
        Me.cboSeverity.ReferenceFieldDesc = Nothing
        Me.cboSeverity.ReferenceFieldName = Nothing
        Me.cboSeverity.ReferenceTableName = Nothing
        Me.cboSeverity.Size = New System.Drawing.Size(190, 20)
        Me.cboSeverity.TabIndex = 13
        '
        'cboDataErrorType
        '
        Me.cboDataErrorType.AutoCompleteDisplayMember = Nothing
        Me.cboDataErrorType.AutoCompleteValueMember = Nothing
        Me.cboDataErrorType.CalculationExpression = Nothing
        Me.cboDataErrorType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboDataErrorType.FieldCode = Nothing
        Me.cboDataErrorType.FieldDesc = Nothing
        Me.cboDataErrorType.FieldMaxLength = 0
        Me.cboDataErrorType.FieldName = Nothing
        Me.cboDataErrorType.isCalculatedField = False
        Me.cboDataErrorType.IsSourceFromTable = False
        Me.cboDataErrorType.IsSourceFromValueList = False
        Me.cboDataErrorType.IsUnique = False
        Me.cboDataErrorType.Location = New System.Drawing.Point(106, 194)
        Me.cboDataErrorType.MendatroryField = True
        Me.cboDataErrorType.MyLinkLable1 = Nothing
        Me.cboDataErrorType.MyLinkLable2 = Nothing
        Me.cboDataErrorType.Name = "cboDataErrorType"
        Me.cboDataErrorType.ReferenceFieldDesc = Nothing
        Me.cboDataErrorType.ReferenceFieldName = Nothing
        Me.cboDataErrorType.ReferenceTableName = Nothing
        Me.cboDataErrorType.Size = New System.Drawing.Size(190, 20)
        Me.cboDataErrorType.TabIndex = 12
        '
        'cboTicketType
        '
        Me.cboTicketType.AutoCompleteDisplayMember = Nothing
        Me.cboTicketType.AutoCompleteValueMember = Nothing
        Me.cboTicketType.CalculationExpression = Nothing
        Me.cboTicketType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboTicketType.FieldCode = Nothing
        Me.cboTicketType.FieldDesc = Nothing
        Me.cboTicketType.FieldMaxLength = 0
        Me.cboTicketType.FieldName = Nothing
        Me.cboTicketType.isCalculatedField = False
        Me.cboTicketType.IsSourceFromTable = False
        Me.cboTicketType.IsSourceFromValueList = False
        Me.cboTicketType.IsUnique = False
        Me.cboTicketType.Location = New System.Drawing.Point(106, 172)
        Me.cboTicketType.MendatroryField = True
        Me.cboTicketType.MyLinkLable1 = Nothing
        Me.cboTicketType.MyLinkLable2 = Nothing
        Me.cboTicketType.Name = "cboTicketType"
        Me.cboTicketType.ReferenceFieldDesc = Nothing
        Me.cboTicketType.ReferenceFieldName = Nothing
        Me.cboTicketType.ReferenceTableName = Nothing
        Me.cboTicketType.Size = New System.Drawing.Size(190, 20)
        Me.cboTicketType.TabIndex = 11
        '
        'MyLabel14
        '
        Me.MyLabel14.FieldName = Nothing
        Me.MyLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel14.Location = New System.Drawing.Point(7, 325)
        Me.MyLabel14.Name = "MyLabel14"
        Me.MyLabel14.Size = New System.Drawing.Size(75, 16)
        Me.MyLabel14.TabIndex = 64
        Me.MyLabel14.Text = "Analysis Date"
        '
        'MyLabel13
        '
        Me.MyLabel13.FieldName = Nothing
        Me.MyLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel13.Location = New System.Drawing.Point(7, 304)
        Me.MyLabel13.Name = "MyLabel13"
        Me.MyLabel13.Size = New System.Drawing.Size(66, 16)
        Me.MyLabel13.TabIndex = 64
        Me.MyLabel13.Text = "Analysis No"
        '
        'MyLabel12
        '
        Me.MyLabel12.FieldName = Nothing
        Me.MyLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel12.Location = New System.Drawing.Point(7, 283)
        Me.MyLabel12.Name = "MyLabel12"
        Me.MyLabel12.Size = New System.Drawing.Size(75, 16)
        Me.MyLabel12.TabIndex = 63
        Me.MyLabel12.Text = "Request Date"
        '
        'MyLabel11
        '
        Me.MyLabel11.FieldName = Nothing
        Me.MyLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel11.Location = New System.Drawing.Point(7, 262)
        Me.MyLabel11.Name = "MyLabel11"
        Me.MyLabel11.Size = New System.Drawing.Size(66, 16)
        Me.MyLabel11.TabIndex = 62
        Me.MyLabel11.Text = "Request No"
        '
        'MyLabel10
        '
        Me.MyLabel10.FieldName = Nothing
        Me.MyLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel10.Location = New System.Drawing.Point(7, 241)
        Me.MyLabel10.Name = "MyLabel10"
        Me.MyLabel10.Size = New System.Drawing.Size(41, 16)
        Me.MyLabel10.TabIndex = 61
        Me.MyLabel10.Text = "Priority"
        '
        'MyLabel9
        '
        Me.MyLabel9.FieldName = Nothing
        Me.MyLabel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel9.Location = New System.Drawing.Point(7, 220)
        Me.MyLabel9.Name = "MyLabel9"
        Me.MyLabel9.Size = New System.Drawing.Size(47, 16)
        Me.MyLabel9.TabIndex = 60
        Me.MyLabel9.Text = "Severity"
        '
        'MyLabel8
        '
        Me.MyLabel8.FieldName = Nothing
        Me.MyLabel8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel8.Location = New System.Drawing.Point(7, 199)
        Me.MyLabel8.Name = "MyLabel8"
        Me.MyLabel8.Size = New System.Drawing.Size(87, 16)
        Me.MyLabel8.TabIndex = 59
        Me.MyLabel8.Text = "Data Error Type"
        '
        'MyLabel7
        '
        Me.MyLabel7.FieldName = Nothing
        Me.MyLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel7.Location = New System.Drawing.Point(7, 178)
        Me.MyLabel7.Name = "MyLabel7"
        Me.MyLabel7.Size = New System.Drawing.Size(65, 16)
        Me.MyLabel7.TabIndex = 58
        Me.MyLabel7.Text = "Ticket Type"
        '
        'lblProject
        '
        Me.lblProject.AutoSize = False
        Me.lblProject.BorderVisible = True
        Me.lblProject.FieldName = Nothing
        Me.lblProject.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.Location = New System.Drawing.Point(303, 92)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(356, 18)
        Me.lblProject.TabIndex = 56
        Me.lblProject.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProject.TextWrap = False
        '
        'txtProject
        '
        Me.txtProject.CalculationExpression = Nothing
        Me.txtProject.FieldCode = Nothing
        Me.txtProject.FieldDesc = Nothing
        Me.txtProject.FieldMaxLength = 0
        Me.txtProject.FieldName = Nothing
        Me.txtProject.isCalculatedField = False
        Me.txtProject.IsSourceFromTable = False
        Me.txtProject.IsSourceFromValueList = False
        Me.txtProject.IsUnique = False
        Me.txtProject.Location = New System.Drawing.Point(106, 92)
        Me.txtProject.MendatroryField = True
        Me.txtProject.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProject.MyLinkLable1 = Me.RadLabel2
        Me.txtProject.MyLinkLable2 = Me.lblProject
        Me.txtProject.MyReadOnly = False
        Me.txtProject.MyShowMasterFormButton = False
        Me.txtProject.Name = "txtProject"
        Me.txtProject.ReferenceFieldDesc = Nothing
        Me.txtProject.ReferenceFieldName = Nothing
        Me.txtProject.ReferenceTableName = Nothing
        Me.txtProject.Size = New System.Drawing.Size(189, 18)
        Me.txtProject.TabIndex = 7
        Me.txtProject.Value = ""
        '
        'lblModule
        '
        Me.lblModule.AutoSize = False
        Me.lblModule.BorderVisible = True
        Me.lblModule.FieldName = Nothing
        Me.lblModule.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModule.Location = New System.Drawing.Point(303, 72)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(356, 18)
        Me.lblModule.TabIndex = 54
        Me.lblModule.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblModule.TextWrap = False
        '
        'txtModule
        '
        Me.txtModule.CalculationExpression = Nothing
        Me.txtModule.FieldCode = Nothing
        Me.txtModule.FieldDesc = Nothing
        Me.txtModule.FieldMaxLength = 0
        Me.txtModule.FieldName = Nothing
        Me.txtModule.isCalculatedField = False
        Me.txtModule.IsSourceFromTable = False
        Me.txtModule.IsSourceFromValueList = False
        Me.txtModule.IsUnique = False
        Me.txtModule.Location = New System.Drawing.Point(106, 72)
        Me.txtModule.MendatroryField = True
        Me.txtModule.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModule.MyLinkLable1 = Me.RadLabel2
        Me.txtModule.MyLinkLable2 = Me.lblModule
        Me.txtModule.MyReadOnly = False
        Me.txtModule.MyShowMasterFormButton = False
        Me.txtModule.Name = "txtModule"
        Me.txtModule.ReferenceFieldDesc = Nothing
        Me.txtModule.ReferenceFieldName = Nothing
        Me.txtModule.ReferenceTableName = Nothing
        Me.txtModule.Size = New System.Drawing.Size(189, 18)
        Me.txtModule.TabIndex = 6
        Me.txtModule.Value = ""
        '
        'MyLabel3
        '
        Me.MyLabel3.FieldName = Nothing
        Me.MyLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel3.Location = New System.Drawing.Point(482, 11)
        Me.MyLabel3.Name = "MyLabel3"
        Me.MyLabel3.Size = New System.Drawing.Size(72, 16)
        Me.MyLabel3.TabIndex = 52
        Me.MyLabel3.Text = "Ticket Status"
        '
        'MyLabel2
        '
        Me.MyLabel2.FieldName = Nothing
        Me.MyLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel2.Location = New System.Drawing.Point(7, 94)
        Me.MyLabel2.Name = "MyLabel2"
        Me.MyLabel2.Size = New System.Drawing.Size(41, 16)
        Me.MyLabel2.TabIndex = 51
        Me.MyLabel2.Text = "Project"
        '
        'MyLabel1
        '
        Me.MyLabel1.FieldName = Nothing
        Me.MyLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel1.Location = New System.Drawing.Point(7, 73)
        Me.MyLabel1.Name = "MyLabel1"
        Me.MyLabel1.Size = New System.Drawing.Size(43, 16)
        Me.MyLabel1.TabIndex = 50
        Me.MyLabel1.Text = "Module"
        '
        'lblClient
        '
        Me.lblClient.AutoSize = False
        Me.lblClient.BorderVisible = True
        Me.lblClient.FieldName = Nothing
        Me.lblClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(303, 32)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(356, 18)
        Me.lblClient.TabIndex = 49
        Me.lblClient.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClient.TextWrap = False
        '
        'txtClient
        '
        Me.txtClient.CalculationExpression = Nothing
        Me.txtClient.FieldCode = Nothing
        Me.txtClient.FieldDesc = Nothing
        Me.txtClient.FieldMaxLength = 0
        Me.txtClient.FieldName = Nothing
        Me.txtClient.isCalculatedField = False
        Me.txtClient.IsSourceFromTable = False
        Me.txtClient.IsSourceFromValueList = False
        Me.txtClient.IsUnique = False
        Me.txtClient.Location = New System.Drawing.Point(106, 32)
        Me.txtClient.MendatroryField = True
        Me.txtClient.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClient.MyLinkLable1 = Me.RadLabel2
        Me.txtClient.MyLinkLable2 = Me.lblClient
        Me.txtClient.MyReadOnly = False
        Me.txtClient.MyShowMasterFormButton = False
        Me.txtClient.Name = "txtClient"
        Me.txtClient.ReferenceFieldDesc = Nothing
        Me.txtClient.ReferenceFieldName = Nothing
        Me.txtClient.ReferenceTableName = Nothing
        Me.txtClient.Size = New System.Drawing.Size(190, 18)
        Me.txtClient.TabIndex = 4
        Me.txtClient.Value = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(358, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Date"
        '
        'txtTicketDate
        '
        Me.txtTicketDate.CalculationExpression = Nothing
        Me.txtTicketDate.CustomFormat = "dd/MM/yyyy"
        Me.txtTicketDate.FieldCode = Nothing
        Me.txtTicketDate.FieldDesc = Nothing
        Me.txtTicketDate.FieldMaxLength = 0
        Me.txtTicketDate.FieldName = Nothing
        Me.txtTicketDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTicketDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtTicketDate.isCalculatedField = False
        Me.txtTicketDate.IsSourceFromTable = False
        Me.txtTicketDate.IsSourceFromValueList = False
        Me.txtTicketDate.IsUnique = False
        Me.txtTicketDate.Location = New System.Drawing.Point(395, 11)
        Me.txtTicketDate.MendatroryField = False
        Me.txtTicketDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtTicketDate.MyLinkLable1 = Nothing
        Me.txtTicketDate.MyLinkLable2 = Nothing
        Me.txtTicketDate.Name = "txtTicketDate"
        Me.txtTicketDate.NullDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtTicketDate.ReferenceFieldDesc = Nothing
        Me.txtTicketDate.ReferenceFieldName = Nothing
        Me.txtTicketDate.ReferenceTableName = Nothing
        Me.txtTicketDate.Size = New System.Drawing.Size(83, 18)
        Me.txtTicketDate.TabIndex = 2
        Me.txtTicketDate.TabStop = False
        Me.txtTicketDate.Text = "13/06/2011"
        Me.txtTicketDate.Value = New Date(2011, 6, 13, 11, 29, 49, 421)
        '
        'txtTicketNo
        '
        Me.txtTicketNo.FieldName = Nothing
        Me.txtTicketNo.Location = New System.Drawing.Point(106, 9)
        Me.txtTicketNo.MendatroryField = True
        Me.txtTicketNo.MyCharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTicketNo.MyFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtTicketNo.MyLinkLable1 = Nothing
        Me.txtTicketNo.MyLinkLable2 = Nothing
        Me.txtTicketNo.MyMaxLength = 32767
        Me.txtTicketNo.MyReadOnly = False
        Me.txtTicketNo.Name = "txtTicketNo"
        Me.txtTicketNo.Size = New System.Drawing.Size(224, 21)
        Me.txtTicketNo.TabIndex = 0
        Me.txtTicketNo.Value = ""
        '
        'btnreset1
        '
        Me.btnreset1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnreset1.Location = New System.Drawing.Point(330, 9)
        Me.btnreset1.Name = "btnreset1"
        Me.btnreset1.Size = New System.Drawing.Size(22, 21)
        Me.btnreset1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Ticket No"
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.RadGroupBox1)
        Me.RadPageViewPage2.Controls.Add(Me.GroupBox1)
        Me.RadPageViewPage2.ItemSize = New System.Drawing.SizeF(82.0!, 28.0!)
        Me.RadPageViewPage2.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(662, 414)
        Me.RadPageViewPage2.Text = "Ticket Details"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.txtAllocationRemarks)
        Me.RadGroupBox1.HeaderText = "Allocation Remarks"
        Me.RadGroupBox1.Location = New System.Drawing.Point(3, 202)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(659, 209)
        Me.RadGroupBox1.TabIndex = 38
        Me.RadGroupBox1.Text = "Allocation Remarks"
        '
        'txtAllocationRemarks
        '
        Me.txtAllocationRemarks.AcceptsReturn = True
        Me.txtAllocationRemarks.AutoSize = False
        Me.txtAllocationRemarks.CalculationExpression = Nothing
        Me.txtAllocationRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAllocationRemarks.FieldCode = Nothing
        Me.txtAllocationRemarks.FieldDesc = Nothing
        Me.txtAllocationRemarks.FieldMaxLength = 0
        Me.txtAllocationRemarks.FieldName = Nothing
        Me.txtAllocationRemarks.isCalculatedField = False
        Me.txtAllocationRemarks.IsSourceFromTable = False
        Me.txtAllocationRemarks.IsSourceFromValueList = False
        Me.txtAllocationRemarks.IsUnique = False
        Me.txtAllocationRemarks.Location = New System.Drawing.Point(2, 18)
        Me.txtAllocationRemarks.MaxLength = 5000
        Me.txtAllocationRemarks.MendatroryField = True
        Me.txtAllocationRemarks.Multiline = True
        Me.txtAllocationRemarks.MyLinkLable1 = Nothing
        Me.txtAllocationRemarks.MyLinkLable2 = Nothing
        Me.txtAllocationRemarks.Name = "txtAllocationRemarks"
        Me.txtAllocationRemarks.ReferenceFieldDesc = Nothing
        Me.txtAllocationRemarks.ReferenceFieldName = Nothing
        Me.txtAllocationRemarks.ReferenceTableName = Nothing
        Me.txtAllocationRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAllocationRemarks.Size = New System.Drawing.Size(655, 189)
        Me.txtAllocationRemarks.TabIndex = 37
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTicketDescription)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(662, 193)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ticket Details"
        '
        'txtTicketDescription
        '
        Me.txtTicketDescription.AcceptsReturn = True
        Me.txtTicketDescription.AutoSize = False
        Me.txtTicketDescription.CalculationExpression = Nothing
        Me.txtTicketDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTicketDescription.FieldCode = Nothing
        Me.txtTicketDescription.FieldDesc = Nothing
        Me.txtTicketDescription.FieldMaxLength = 0
        Me.txtTicketDescription.FieldName = Nothing
        Me.txtTicketDescription.isCalculatedField = False
        Me.txtTicketDescription.IsSourceFromTable = False
        Me.txtTicketDescription.IsSourceFromValueList = False
        Me.txtTicketDescription.IsUnique = False
        Me.txtTicketDescription.Location = New System.Drawing.Point(3, 18)
        Me.txtTicketDescription.MaxLength = 5000
        Me.txtTicketDescription.MendatroryField = True
        Me.txtTicketDescription.Multiline = True
        Me.txtTicketDescription.MyLinkLable1 = Nothing
        Me.txtTicketDescription.MyLinkLable2 = Nothing
        Me.txtTicketDescription.Name = "txtTicketDescription"
        Me.txtTicketDescription.ReferenceFieldDesc = Nothing
        Me.txtTicketDescription.ReferenceFieldName = Nothing
        Me.txtTicketDescription.ReferenceTableName = Nothing
        Me.txtTicketDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTicketDescription.Size = New System.Drawing.Size(656, 172)
        Me.txtTicketDescription.TabIndex = 36
        '
        'RadPageViewPage4
        '
        Me.RadPageViewPage4.Controls.Add(Me.RadGroupBox3)
        Me.RadPageViewPage4.Controls.Add(Me.RadGroupBox2)
        Me.RadPageViewPage4.ItemSize = New System.Drawing.SizeF(113.0!, 28.0!)
        Me.RadPageViewPage4.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage4.Name = "RadPageViewPage4"
        Me.RadPageViewPage4.Size = New System.Drawing.Size(662, 414)
        Me.RadPageViewPage4.Text = "Developer Remarks"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Controls.Add(Me.txtDeveloperYourRemarks)
        Me.RadGroupBox3.HeaderText = "Your Remarks"
        Me.RadGroupBox3.Location = New System.Drawing.Point(3, 212)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(656, 199)
        Me.RadGroupBox3.TabIndex = 39
        Me.RadGroupBox3.Text = "Your Remarks"
        '
        'txtDeveloperYourRemarks
        '
        Me.txtDeveloperYourRemarks.AcceptsReturn = True
        Me.txtDeveloperYourRemarks.AutoSize = False
        Me.txtDeveloperYourRemarks.CalculationExpression = Nothing
        Me.txtDeveloperYourRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDeveloperYourRemarks.FieldCode = Nothing
        Me.txtDeveloperYourRemarks.FieldDesc = Nothing
        Me.txtDeveloperYourRemarks.FieldMaxLength = 0
        Me.txtDeveloperYourRemarks.FieldName = Nothing
        Me.txtDeveloperYourRemarks.isCalculatedField = False
        Me.txtDeveloperYourRemarks.IsSourceFromTable = False
        Me.txtDeveloperYourRemarks.IsSourceFromValueList = False
        Me.txtDeveloperYourRemarks.IsUnique = False
        Me.txtDeveloperYourRemarks.Location = New System.Drawing.Point(2, 18)
        Me.txtDeveloperYourRemarks.MaxLength = 5000
        Me.txtDeveloperYourRemarks.MendatroryField = True
        Me.txtDeveloperYourRemarks.Multiline = True
        Me.txtDeveloperYourRemarks.MyLinkLable1 = Nothing
        Me.txtDeveloperYourRemarks.MyLinkLable2 = Nothing
        Me.txtDeveloperYourRemarks.Name = "txtDeveloperYourRemarks"
        Me.txtDeveloperYourRemarks.ReferenceFieldDesc = Nothing
        Me.txtDeveloperYourRemarks.ReferenceFieldName = Nothing
        Me.txtDeveloperYourRemarks.ReferenceTableName = Nothing
        Me.txtDeveloperYourRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeveloperYourRemarks.Size = New System.Drawing.Size(652, 179)
        Me.txtDeveloperYourRemarks.TabIndex = 38
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.txtDeveloperRreviousRemarks)
        Me.RadGroupBox2.HeaderText = "Previous Remarks"
        Me.RadGroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(656, 203)
        Me.RadGroupBox2.TabIndex = 38
        Me.RadGroupBox2.Text = "Previous Remarks"
        '
        'txtDeveloperRreviousRemarks
        '
        Me.txtDeveloperRreviousRemarks.AcceptsReturn = True
        Me.txtDeveloperRreviousRemarks.AutoSize = False
        Me.txtDeveloperRreviousRemarks.CalculationExpression = Nothing
        Me.txtDeveloperRreviousRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDeveloperRreviousRemarks.FieldCode = Nothing
        Me.txtDeveloperRreviousRemarks.FieldDesc = Nothing
        Me.txtDeveloperRreviousRemarks.FieldMaxLength = 0
        Me.txtDeveloperRreviousRemarks.FieldName = Nothing
        Me.txtDeveloperRreviousRemarks.isCalculatedField = False
        Me.txtDeveloperRreviousRemarks.IsSourceFromTable = False
        Me.txtDeveloperRreviousRemarks.IsSourceFromValueList = False
        Me.txtDeveloperRreviousRemarks.IsUnique = False
        Me.txtDeveloperRreviousRemarks.Location = New System.Drawing.Point(2, 18)
        Me.txtDeveloperRreviousRemarks.MaxLength = 5000
        Me.txtDeveloperRreviousRemarks.MendatroryField = True
        Me.txtDeveloperRreviousRemarks.Multiline = True
        Me.txtDeveloperRreviousRemarks.MyLinkLable1 = Nothing
        Me.txtDeveloperRreviousRemarks.MyLinkLable2 = Nothing
        Me.txtDeveloperRreviousRemarks.Name = "txtDeveloperRreviousRemarks"
        Me.txtDeveloperRreviousRemarks.ReferenceFieldDesc = Nothing
        Me.txtDeveloperRreviousRemarks.ReferenceFieldName = Nothing
        Me.txtDeveloperRreviousRemarks.ReferenceTableName = Nothing
        Me.txtDeveloperRreviousRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDeveloperRreviousRemarks.Size = New System.Drawing.Size(652, 183)
        Me.txtDeveloperRreviousRemarks.TabIndex = 37
        '
        'RadPageViewPage5
        '
        Me.RadPageViewPage5.Controls.Add(Me.RadGroupBox5)
        Me.RadPageViewPage5.Controls.Add(Me.RadGroupBox4)
        Me.RadPageViewPage5.ItemSize = New System.Drawing.SizeF(92.0!, 28.0!)
        Me.RadPageViewPage5.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage5.Name = "RadPageViewPage5"
        Me.RadPageViewPage5.Size = New System.Drawing.Size(662, 414)
        Me.RadPageViewPage5.Text = "Tester Remarks"
        '
        'RadGroupBox5
        '
        Me.RadGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox5.Controls.Add(Me.Panel1)
        Me.RadGroupBox5.HeaderText = "Your Remarks"
        Me.RadGroupBox5.Location = New System.Drawing.Point(3, 217)
        Me.RadGroupBox5.Name = "RadGroupBox5"
        Me.RadGroupBox5.Size = New System.Drawing.Size(656, 197)
        Me.RadGroupBox5.TabIndex = 40
        Me.RadGroupBox5.Text = "Your Remarks"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtTesterYourRemarks)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(652, 177)
        Me.Panel1.TabIndex = 40
        '
        'txtTesterYourRemarks
        '
        Me.txtTesterYourRemarks.AcceptsReturn = True
        Me.txtTesterYourRemarks.AutoSize = False
        Me.txtTesterYourRemarks.CalculationExpression = Nothing
        Me.txtTesterYourRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTesterYourRemarks.FieldCode = Nothing
        Me.txtTesterYourRemarks.FieldDesc = Nothing
        Me.txtTesterYourRemarks.FieldMaxLength = 0
        Me.txtTesterYourRemarks.FieldName = Nothing
        Me.txtTesterYourRemarks.isCalculatedField = False
        Me.txtTesterYourRemarks.IsSourceFromTable = False
        Me.txtTesterYourRemarks.IsSourceFromValueList = False
        Me.txtTesterYourRemarks.IsUnique = False
        Me.txtTesterYourRemarks.Location = New System.Drawing.Point(0, 0)
        Me.txtTesterYourRemarks.MaxLength = 5000
        Me.txtTesterYourRemarks.MendatroryField = True
        Me.txtTesterYourRemarks.Multiline = True
        Me.txtTesterYourRemarks.MyLinkLable1 = Nothing
        Me.txtTesterYourRemarks.MyLinkLable2 = Nothing
        Me.txtTesterYourRemarks.Name = "txtTesterYourRemarks"
        Me.txtTesterYourRemarks.ReferenceFieldDesc = Nothing
        Me.txtTesterYourRemarks.ReferenceFieldName = Nothing
        Me.txtTesterYourRemarks.ReferenceTableName = Nothing
        Me.txtTesterYourRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTesterYourRemarks.Size = New System.Drawing.Size(652, 177)
        Me.txtTesterYourRemarks.TabIndex = 39
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox4.Controls.Add(Me.txtTesterPreviousRemarks)
        Me.RadGroupBox4.HeaderText = "Previous Remarks"
        Me.RadGroupBox4.Location = New System.Drawing.Point(0, 3)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Size = New System.Drawing.Size(659, 208)
        Me.RadGroupBox4.TabIndex = 39
        Me.RadGroupBox4.Text = "Previous Remarks"
        '
        'txtTesterPreviousRemarks
        '
        Me.txtTesterPreviousRemarks.AcceptsReturn = True
        Me.txtTesterPreviousRemarks.AutoSize = False
        Me.txtTesterPreviousRemarks.CalculationExpression = Nothing
        Me.txtTesterPreviousRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTesterPreviousRemarks.FieldCode = Nothing
        Me.txtTesterPreviousRemarks.FieldDesc = Nothing
        Me.txtTesterPreviousRemarks.FieldMaxLength = 0
        Me.txtTesterPreviousRemarks.FieldName = Nothing
        Me.txtTesterPreviousRemarks.isCalculatedField = False
        Me.txtTesterPreviousRemarks.IsSourceFromTable = False
        Me.txtTesterPreviousRemarks.IsSourceFromValueList = False
        Me.txtTesterPreviousRemarks.IsUnique = False
        Me.txtTesterPreviousRemarks.Location = New System.Drawing.Point(2, 18)
        Me.txtTesterPreviousRemarks.MaxLength = 5000
        Me.txtTesterPreviousRemarks.MendatroryField = True
        Me.txtTesterPreviousRemarks.Multiline = True
        Me.txtTesterPreviousRemarks.MyLinkLable1 = Nothing
        Me.txtTesterPreviousRemarks.MyLinkLable2 = Nothing
        Me.txtTesterPreviousRemarks.Name = "txtTesterPreviousRemarks"
        Me.txtTesterPreviousRemarks.ReferenceFieldDesc = Nothing
        Me.txtTesterPreviousRemarks.ReferenceFieldName = Nothing
        Me.txtTesterPreviousRemarks.ReferenceTableName = Nothing
        Me.txtTesterPreviousRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTesterPreviousRemarks.Size = New System.Drawing.Size(655, 188)
        Me.txtTesterPreviousRemarks.TabIndex = 38
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(599, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 18)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(82, 8)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 18)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(2, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 18)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        '
        'RadPageViewPage3
        '
        Me.RadPageViewPage3.Controls.Add(Me.UcAttachment1)
        Me.RadPageViewPage3.ItemSize = New System.Drawing.SizeF(79.0!, 28.0!)
        Me.RadPageViewPage3.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage3.Name = "RadPageViewPage3"
        Me.RadPageViewPage3.Size = New System.Drawing.Size(662, 430)
        Me.RadPageViewPage3.Text = "Attachments"
        '
        'UcAttachment1
        '
        Me.UcAttachment1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAttachment1.Location = New System.Drawing.Point(0, 0)
        Me.UcAttachment1.Name = "UcAttachment1"
        Me.UcAttachment1.Size = New System.Drawing.Size(662, 430)
        Me.UcAttachment1.TabIndex = 1
        '
        'FrmTicketMasterNewEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 516)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmTicketMasterNewEntry"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Ticket Master Entry"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage1.PerformLayout()
        CType(Me.lblTotalTestingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalDevelopmentTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActualTestedTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox6.ResumeLayout(False)
        Me.RadGroupBox6.PerformLayout()
        CType(Me.txtTestingExeVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDevelopmentExeVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTestingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDevelopmentTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAllocatedTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTicketStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTester, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDeveloper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCreatedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnalysisDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnalysisNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRequestDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRequestNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPriority, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSeverity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDataErrorType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTicketType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblModule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTicketDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage2.ResumeLayout(False)
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me.txtAllocationRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.txtTicketDescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage4.ResumeLayout(False)
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        CType(Me.txtDeveloperYourRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        CType(Me.txtDeveloperRreviousRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage5.ResumeLayout(False)
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtTesterYourRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        CType(Me.txtTesterPreviousRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage3.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents txtTicketNo As common.UserControls.txtNavigator
    Friend WithEvents btnreset1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTicketDate As common.Controls.MyDateTimePicker
    Friend WithEvents MyLabel1 As common.Controls.MyLabel
    Friend WithEvents lblClient As common.Controls.MyLabel
    Friend WithEvents RadLabel2 As common.Controls.MyLabel
    Friend WithEvents txtClient As common.UserControls.txtFinder
    Friend WithEvents MyLabel14 As common.Controls.MyLabel
    Friend WithEvents MyLabel13 As common.Controls.MyLabel
    Friend WithEvents MyLabel12 As common.Controls.MyLabel
    Friend WithEvents MyLabel11 As common.Controls.MyLabel
    Friend WithEvents MyLabel10 As common.Controls.MyLabel
    Friend WithEvents MyLabel9 As common.Controls.MyLabel
    Friend WithEvents MyLabel8 As common.Controls.MyLabel
    Friend WithEvents MyLabel7 As common.Controls.MyLabel
    Friend WithEvents lblProject As common.Controls.MyLabel
    Friend WithEvents txtProject As common.UserControls.txtFinder
    Friend WithEvents lblModule As common.Controls.MyLabel
    Friend WithEvents txtModule As common.UserControls.txtFinder
    Friend WithEvents MyLabel3 As common.Controls.MyLabel
    Friend WithEvents MyLabel2 As common.Controls.MyLabel
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents lblAnalysisDate As common.Controls.MyLabel
    Friend WithEvents lblAnalysisNo As common.Controls.MyLabel
    Friend WithEvents lblRequestDate As common.Controls.MyLabel
    Friend WithEvents lblRequestNo As common.Controls.MyLabel
    Friend WithEvents cboPriority As common.Controls.MyComboBox
    Friend WithEvents cboSeverity As common.Controls.MyComboBox
    Friend WithEvents cboDataErrorType As common.Controls.MyComboBox
    Friend WithEvents cboTicketType As common.Controls.MyComboBox
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTester As common.Controls.MyLabel
    Friend WithEvents txtTester As common.UserControls.txtFinder
    Friend WithEvents MyLabel17 As common.Controls.MyLabel
    Friend WithEvents lblDeveloper As common.Controls.MyLabel
    Friend WithEvents txtDeveloper As common.UserControls.txtFinder
    Friend WithEvents MyLabel15 As common.Controls.MyLabel
    Friend WithEvents lblCreatedBy As common.Controls.MyLabel
    Friend WithEvents txtCreatedBy As common.UserControls.txtFinder
    Friend WithEvents MyLabel5 As common.Controls.MyLabel
    Friend WithEvents lblScreen As common.Controls.MyLabel
    Friend WithEvents MyLabel19 As common.Controls.MyLabel
    Friend WithEvents txtScreen As common.UserControls.txtFinder
    Friend WithEvents txtTicketDescription As common.Controls.MyTextBox
    Friend WithEvents RadPageViewPage4 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents txtDeveloperRreviousRemarks As common.Controls.MyTextBox
    Friend WithEvents RadPageViewPage5 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents txtTesterPreviousRemarks As common.Controls.MyTextBox
    Friend WithEvents MyLabel21 As common.Controls.MyLabel
    Friend WithEvents MyLabel16 As common.Controls.MyLabel
    Friend WithEvents MyLabel18 As common.Controls.MyLabel
    Friend WithEvents cboTicketStatus As common.Controls.MyComboBox
    Friend WithEvents txtTestingTime As common.MyNumBox
    Friend WithEvents txtDevelopmentTime As common.MyNumBox
    Friend WithEvents txtAllocatedTime As common.MyNumBox
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtAllocationRemarks As common.Controls.MyTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtDeveloperYourRemarks As common.Controls.MyTextBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox5 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtTesterYourRemarks As common.Controls.MyTextBox
    Friend WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadGroupBox6 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents MyLabel4 As common.Controls.MyLabel
    Friend WithEvents MyLabel6 As common.Controls.MyLabel
    Friend WithEvents txtActualTestedTime As common.MyNumBox
    Friend WithEvents MyLabel20 As common.Controls.MyLabel
    Friend WithEvents txtDevelopmentExeVersion As common.Controls.MyTextBox
    Friend WithEvents txtTestingExeVersion As common.Controls.MyTextBox
    Friend WithEvents lblTotalTestingTime As common.Controls.MyLabel
    Friend WithEvents lblTotalDevelopmentTime As common.Controls.MyLabel
    Friend WithEvents RadPageViewPage3 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents UcAttachment1 As TeamMgmt.ucAttachment
End Class

