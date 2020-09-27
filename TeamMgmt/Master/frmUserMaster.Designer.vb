<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserMaster
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
        Me.txtUserType = New common.Controls.MyComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblUserGroup = New common.Controls.MyLabel()
        Me.MyLabel4 = New common.Controls.MyLabel()
        Me.txtUserGroup = New common.UserControls.txtFinder()
        Me.txtPhone = New common.Controls.MyTextBox()
        Me.MyLabel2 = New common.Controls.MyLabel()
        Me.txtEmailId = New common.Controls.MyTextBox()
        Me.MyLabel1 = New common.Controls.MyLabel()
        Me.lblClient = New common.Controls.MyLabel()
        Me.RadLabel2 = New common.Controls.MyLabel()
        Me.txtClient = New common.UserControls.txtFinder()
        Me.cboType = New common.Controls.MyComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPasswordUser = New common.Controls.MyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUserCode = New common.UserControls.txtNavigator()
        Me.btnreset1 = New Telerik.WinControls.UI.RadButton()
        Me.txtUserName = New common.Controls.MyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.gv = New common.UserControls.MyRadGridView()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.munuExport = New Telerik.WinControls.UI.RadMenuItem()
        Me.rMenuExport = New Telerik.WinControls.UI.RadMenuItem()
        Me.rMenuImport = New Telerik.WinControls.UI.RadMenuItem()
        Me.rMenuExit = New Telerik.WinControls.UI.RadMenuItem()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        CType(Me.txtUserType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUserGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmailId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPasswordUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage2.SuspendLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
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
        Me.SplitContainer1.Size = New System.Drawing.Size(685, 533)
        Me.SplitContainer1.SplitterDistance = 504
        Me.SplitContainer1.TabIndex = 0
        '
        'RadPageView1
        '
        Me.RadPageView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Location = New System.Drawing.Point(3, 26)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.RadPageViewPage1
        Me.RadPageView1.Size = New System.Drawing.Size(682, 475)
        Me.RadPageView1.TabIndex = 0
        Me.RadPageView1.Text = "RadPageView1"
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.txtUserType)
        Me.RadPageViewPage1.Controls.Add(Me.Label5)
        Me.RadPageViewPage1.Controls.Add(Me.lblUserGroup)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel4)
        Me.RadPageViewPage1.Controls.Add(Me.txtUserGroup)
        Me.RadPageViewPage1.Controls.Add(Me.txtPhone)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel2)
        Me.RadPageViewPage1.Controls.Add(Me.txtEmailId)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel1)
        Me.RadPageViewPage1.Controls.Add(Me.lblClient)
        Me.RadPageViewPage1.Controls.Add(Me.RadLabel2)
        Me.RadPageViewPage1.Controls.Add(Me.txtClient)
        Me.RadPageViewPage1.Controls.Add(Me.cboType)
        Me.RadPageViewPage1.Controls.Add(Me.Label4)
        Me.RadPageViewPage1.Controls.Add(Me.txtPasswordUser)
        Me.RadPageViewPage1.Controls.Add(Me.Label3)
        Me.RadPageViewPage1.Controls.Add(Me.txtUserCode)
        Me.RadPageViewPage1.Controls.Add(Me.btnreset1)
        Me.RadPageViewPage1.Controls.Add(Me.txtUserName)
        Me.RadPageViewPage1.Controls.Add(Me.Label2)
        Me.RadPageViewPage1.Controls.Add(Me.Label1)
        Me.RadPageViewPage1.ItemSize = New System.Drawing.SizeF(55.0!, 28.0!)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(661, 427)
        Me.RadPageViewPage1.Text = "General"
        '
        'txtUserType
        '
        Me.txtUserType.AutoCompleteDisplayMember = Nothing
        Me.txtUserType.AutoCompleteValueMember = Nothing
        Me.txtUserType.CalculationExpression = Nothing
        Me.txtUserType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.txtUserType.FieldCode = Nothing
        Me.txtUserType.FieldDesc = Nothing
        Me.txtUserType.FieldMaxLength = 0
        Me.txtUserType.FieldName = Nothing
        Me.txtUserType.isCalculatedField = False
        Me.txtUserType.IsSourceFromTable = False
        Me.txtUserType.IsSourceFromValueList = False
        Me.txtUserType.IsUnique = False
        Me.txtUserType.Location = New System.Drawing.Point(82, 146)
        Me.txtUserType.MendatroryField = True
        Me.txtUserType.MyLinkLable1 = Nothing
        Me.txtUserType.MyLinkLable2 = Nothing
        Me.txtUserType.Name = "txtUserType"
        Me.txtUserType.ReferenceFieldDesc = Nothing
        Me.txtUserType.ReferenceFieldName = Nothing
        Me.txtUserType.ReferenceTableName = Nothing
        Me.txtUserType.Size = New System.Drawing.Size(269, 20)
        Me.txtUserType.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "User Type"
        '
        'lblUserGroup
        '
        Me.lblUserGroup.AutoSize = False
        Me.lblUserGroup.BorderVisible = True
        Me.lblUserGroup.FieldName = Nothing
        Me.lblUserGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserGroup.Location = New System.Drawing.Point(313, 319)
        Me.lblUserGroup.Name = "lblUserGroup"
        Me.lblUserGroup.Size = New System.Drawing.Size(264, 18)
        Me.lblUserGroup.TabIndex = 54
        Me.lblUserGroup.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUserGroup.TextWrap = False
        Me.lblUserGroup.Visible = False
        '
        'MyLabel4
        '
        Me.MyLabel4.FieldName = Nothing
        Me.MyLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel4.Location = New System.Drawing.Point(76, 320)
        Me.MyLabel4.Name = "MyLabel4"
        Me.MyLabel4.Size = New System.Drawing.Size(65, 16)
        Me.MyLabel4.TabIndex = 53
        Me.MyLabel4.Text = "User Group"
        Me.MyLabel4.Visible = False
        '
        'txtUserGroup
        '
        Me.txtUserGroup.CalculationExpression = Nothing
        Me.txtUserGroup.FieldCode = Nothing
        Me.txtUserGroup.FieldDesc = Nothing
        Me.txtUserGroup.FieldMaxLength = 0
        Me.txtUserGroup.FieldName = Nothing
        Me.txtUserGroup.isCalculatedField = False
        Me.txtUserGroup.IsSourceFromTable = False
        Me.txtUserGroup.IsSourceFromValueList = False
        Me.txtUserGroup.IsUnique = False
        Me.txtUserGroup.Location = New System.Drawing.Point(142, 319)
        Me.txtUserGroup.MendatroryField = True
        Me.txtUserGroup.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserGroup.MyLinkLable1 = Me.MyLabel4
        Me.txtUserGroup.MyLinkLable2 = Me.lblUserGroup
        Me.txtUserGroup.MyReadOnly = False
        Me.txtUserGroup.MyShowMasterFormButton = False
        Me.txtUserGroup.Name = "txtUserGroup"
        Me.txtUserGroup.ReferenceFieldDesc = Nothing
        Me.txtUserGroup.ReferenceFieldName = Nothing
        Me.txtUserGroup.ReferenceTableName = Nothing
        Me.txtUserGroup.Size = New System.Drawing.Size(166, 18)
        Me.txtUserGroup.TabIndex = 52
        Me.txtUserGroup.Value = ""
        Me.txtUserGroup.Visible = False
        '
        'txtPhone
        '
        Me.txtPhone.CalculationExpression = Nothing
        Me.txtPhone.FieldCode = Nothing
        Me.txtPhone.FieldDesc = Nothing
        Me.txtPhone.FieldMaxLength = 0
        Me.txtPhone.FieldName = Nothing
        Me.txtPhone.isCalculatedField = False
        Me.txtPhone.IsSourceFromTable = False
        Me.txtPhone.IsSourceFromValueList = False
        Me.txtPhone.IsUnique = False
        Me.txtPhone.Location = New System.Drawing.Point(82, 124)
        Me.txtPhone.MendatroryField = False
        Me.txtPhone.MyLinkLable1 = Nothing
        Me.txtPhone.MyLinkLable2 = Nothing
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReferenceFieldDesc = Nothing
        Me.txtPhone.ReferenceFieldName = Nothing
        Me.txtPhone.ReferenceTableName = Nothing
        Me.txtPhone.Size = New System.Drawing.Size(268, 20)
        Me.txtPhone.TabIndex = 6
        '
        'MyLabel2
        '
        Me.MyLabel2.FieldName = Nothing
        Me.MyLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel2.Location = New System.Drawing.Point(18, 126)
        Me.MyLabel2.Name = "MyLabel2"
        Me.MyLabel2.Size = New System.Drawing.Size(39, 16)
        Me.MyLabel2.TabIndex = 49
        Me.MyLabel2.Text = "Phone"
        '
        'txtEmailId
        '
        Me.txtEmailId.CalculationExpression = Nothing
        Me.txtEmailId.FieldCode = Nothing
        Me.txtEmailId.FieldDesc = Nothing
        Me.txtEmailId.FieldMaxLength = 0
        Me.txtEmailId.FieldName = Nothing
        Me.txtEmailId.isCalculatedField = False
        Me.txtEmailId.IsSourceFromTable = False
        Me.txtEmailId.IsSourceFromValueList = False
        Me.txtEmailId.IsUnique = False
        Me.txtEmailId.Location = New System.Drawing.Point(82, 102)
        Me.txtEmailId.MendatroryField = False
        Me.txtEmailId.MyLinkLable1 = Nothing
        Me.txtEmailId.MyLinkLable2 = Nothing
        Me.txtEmailId.Name = "txtEmailId"
        Me.txtEmailId.ReferenceFieldDesc = Nothing
        Me.txtEmailId.ReferenceFieldName = Nothing
        Me.txtEmailId.ReferenceTableName = Nothing
        Me.txtEmailId.Size = New System.Drawing.Size(269, 20)
        Me.txtEmailId.TabIndex = 5
        '
        'MyLabel1
        '
        Me.MyLabel1.FieldName = Nothing
        Me.MyLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel1.Location = New System.Drawing.Point(18, 104)
        Me.MyLabel1.Name = "MyLabel1"
        Me.MyLabel1.Size = New System.Drawing.Size(34, 16)
        Me.MyLabel1.TabIndex = 47
        Me.MyLabel1.Text = "Email"
        '
        'lblClient
        '
        Me.lblClient.AutoSize = False
        Me.lblClient.BorderVisible = True
        Me.lblClient.FieldName = Nothing
        Me.lblClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(256, 169)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(264, 18)
        Me.lblClient.TabIndex = 9
        Me.lblClient.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClient.TextWrap = False
        '
        'RadLabel2
        '
        Me.RadLabel2.FieldName = Nothing
        Me.RadLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(18, 170)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(38, 16)
        Me.RadLabel2.TabIndex = 45
        Me.RadLabel2.Text = "Client "
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
        Me.txtClient.Location = New System.Drawing.Point(82, 169)
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
        Me.txtClient.Size = New System.Drawing.Size(166, 18)
        Me.txtClient.TabIndex = 8
        Me.txtClient.Value = ""
        '
        'cboType
        '
        Me.cboType.AutoCompleteDisplayMember = Nothing
        Me.cboType.AutoCompleteValueMember = Nothing
        Me.cboType.CalculationExpression = Nothing
        Me.cboType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboType.FieldCode = Nothing
        Me.cboType.FieldDesc = Nothing
        Me.cboType.FieldMaxLength = 0
        Me.cboType.FieldName = Nothing
        Me.cboType.isCalculatedField = False
        Me.cboType.IsSourceFromTable = False
        Me.cboType.IsSourceFromValueList = False
        Me.cboType.IsUnique = False
        Me.cboType.Location = New System.Drawing.Point(82, 80)
        Me.cboType.MendatroryField = True
        Me.cboType.MyLinkLable1 = Nothing
        Me.cboType.MyLinkLable2 = Nothing
        Me.cboType.Name = "cboType"
        Me.cboType.ReferenceFieldDesc = Nothing
        Me.cboType.ReferenceFieldName = Nothing
        Me.cboType.ReferenceTableName = Nothing
        Me.cboType.Size = New System.Drawing.Size(269, 20)
        Me.cboType.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Type"
        '
        'txtPasswordUser
        '
        Me.txtPasswordUser.CalculationExpression = Nothing
        Me.txtPasswordUser.FieldCode = Nothing
        Me.txtPasswordUser.FieldDesc = Nothing
        Me.txtPasswordUser.FieldMaxLength = 0
        Me.txtPasswordUser.FieldName = Nothing
        Me.txtPasswordUser.isCalculatedField = False
        Me.txtPasswordUser.IsSourceFromTable = False
        Me.txtPasswordUser.IsSourceFromValueList = False
        Me.txtPasswordUser.IsUnique = False
        Me.txtPasswordUser.Location = New System.Drawing.Point(82, 57)
        Me.txtPasswordUser.MaxLength = 50
        Me.txtPasswordUser.MendatroryField = True
        Me.txtPasswordUser.MyLinkLable1 = Nothing
        Me.txtPasswordUser.MyLinkLable2 = Nothing
        Me.txtPasswordUser.Name = "txtPasswordUser"
        Me.txtPasswordUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordUser.ReferenceFieldDesc = Nothing
        Me.txtPasswordUser.ReferenceFieldName = Nothing
        Me.txtPasswordUser.ReferenceTableName = Nothing
        Me.txtPasswordUser.Size = New System.Drawing.Size(269, 20)
        Me.txtPasswordUser.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Password"
        '
        'txtUserCode
        '
        Me.txtUserCode.FieldName = Nothing
        Me.txtUserCode.Location = New System.Drawing.Point(82, 10)
        Me.txtUserCode.MendatroryField = True
        Me.txtUserCode.MyCharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserCode.MyFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtUserCode.MyLinkLable1 = Nothing
        Me.txtUserCode.MyLinkLable2 = Nothing
        Me.txtUserCode.MyMaxLength = 32767
        Me.txtUserCode.MyReadOnly = False
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.Size = New System.Drawing.Size(248, 21)
        Me.txtUserCode.TabIndex = 0
        Me.txtUserCode.Value = ""
        '
        'btnreset1
        '
        Me.btnreset1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnreset1.Location = New System.Drawing.Point(331, 11)
        Me.btnreset1.Name = "btnreset1"
        Me.btnreset1.Size = New System.Drawing.Size(22, 21)
        Me.btnreset1.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.CalculationExpression = Nothing
        Me.txtUserName.FieldCode = Nothing
        Me.txtUserName.FieldDesc = Nothing
        Me.txtUserName.FieldMaxLength = 0
        Me.txtUserName.FieldName = Nothing
        Me.txtUserName.isCalculatedField = False
        Me.txtUserName.IsSourceFromTable = False
        Me.txtUserName.IsSourceFromValueList = False
        Me.txtUserName.IsUnique = False
        Me.txtUserName.Location = New System.Drawing.Point(82, 34)
        Me.txtUserName.MaxLength = 50
        Me.txtUserName.MendatroryField = True
        Me.txtUserName.MyLinkLable1 = Nothing
        Me.txtUserName.MyLinkLable2 = Nothing
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReferenceFieldDesc = Nothing
        Me.txtUserName.ReferenceFieldName = Nothing
        Me.txtUserName.ReferenceTableName = Nothing
        Me.txtUserName.Size = New System.Drawing.Size(269, 20)
        Me.txtUserName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "User Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "User Code "
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.gv)
        Me.RadPageViewPage2.ItemSize = New System.Drawing.SizeF(128.0!, 28.0!)
        Me.RadPageViewPage2.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(661, 427)
        Me.RadPageViewPage2.Text = "Internal User Mapping"
        '
        'gv
        '
        Me.gv.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.gv.Cursor = System.Windows.Forms.Cursors.Default
        Me.gv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.gv.ForeColor = System.Drawing.Color.Black
        Me.gv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gv.Location = New System.Drawing.Point(0, 0)
        '
        'gv
        '
        Me.gv.MasterTemplate.AllowAddNewRow = False
        Me.gv.MasterTemplate.AllowDragToGroup = False
        Me.gv.MasterTemplate.EnableFiltering = True
        Me.gv.MasterTemplate.ShowHeaderCellButtons = True
        Me.gv.Name = "gv"
        Me.gv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gv.ShowHeaderCellButtons = True
        Me.gv.Size = New System.Drawing.Size(661, 427)
        Me.gv.TabIndex = 9
        Me.gv.Text = "RadGridView1"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(605, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 18)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(83, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 18)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 18)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.munuExport})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Size = New System.Drawing.Size(685, 20)
        Me.RadMenu1.TabIndex = 3
        Me.RadMenu1.Text = "RadMenu1"
        '
        'munuExport
        '
        Me.munuExport.AccessibleDescription = "File"
        Me.munuExport.AccessibleName = "File"
        Me.munuExport.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rMenuExport, Me.rMenuImport, Me.rMenuExit})
        Me.munuExport.Name = "munuExport"
        Me.munuExport.Text = "File"
        '
        'rMenuExport
        '
        Me.rMenuExport.AccessibleDescription = "Export"
        Me.rMenuExport.AccessibleName = "Export"
        Me.rMenuExport.Name = "rMenuExport"
        Me.rMenuExport.Text = "Export"
        '
        'rMenuImport
        '
        Me.rMenuImport.AccessibleDescription = "Import"
        Me.rMenuImport.AccessibleName = "Import"
        Me.rMenuImport.Name = "rMenuImport"
        Me.rMenuImport.Text = "Import"
        '
        'rMenuExit
        '
        Me.rMenuExit.AccessibleDescription = "Exit"
        Me.rMenuExit.AccessibleName = "Exit"
        Me.rMenuExit.Name = "rMenuExit"
        Me.rMenuExit.Text = "Exit"
        '
        'FrmUserMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 533)
        Me.Controls.Add(Me.RadMenu1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmUserMaster"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "User Master"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage1.PerformLayout()
        CType(Me.txtUserType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUserGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmailId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPasswordUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage2.ResumeLayout(False)
        CType(Me.gv.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents munuExport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordUser As common.Controls.MyTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUserCode As common.UserControls.txtNavigator
    Friend WithEvents btnreset1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtUserName As common.Controls.MyTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboType As common.Controls.MyComboBox
    Friend WithEvents txtPhone As common.Controls.MyTextBox
    Friend WithEvents MyLabel2 As common.Controls.MyLabel
    Friend WithEvents txtEmailId As common.Controls.MyTextBox
    Friend WithEvents MyLabel1 As common.Controls.MyLabel
    Friend WithEvents lblClient As common.Controls.MyLabel
    Friend WithEvents RadLabel2 As common.Controls.MyLabel
    Friend WithEvents txtClient As common.UserControls.txtFinder
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents lblUserGroup As common.Controls.MyLabel
    Friend WithEvents MyLabel4 As common.Controls.MyLabel
    Friend WithEvents txtUserGroup As common.UserControls.txtFinder
    Friend WithEvents rMenuExport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents rMenuImport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents rMenuExit As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents txtUserType As common.Controls.MyComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gv As common.UserControls.MyRadGridView
End Class

