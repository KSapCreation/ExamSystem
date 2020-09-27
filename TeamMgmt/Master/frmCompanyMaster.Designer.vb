<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompanyMaster
    Inherits FrmMainTranScreen

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompanyMaster))
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.dtPanIssueDate = New common.Controls.MyDateTimePicker()
        Me.MyLabel12 = New common.Controls.MyLabel()
        Me.dtTinIssueDate = New common.Controls.MyDateTimePicker()
        Me.MyLabel11 = New common.Controls.MyLabel()
        Me.txtTelephone2 = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtTelephone1 = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.chk_main_company = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtState = New common.UserControls.txtFinder()
        Me.fndCompanyCode = New common.UserControls.txtNavigator()
        Me.lblCompanyCode = New common.Controls.MyLabel()
        Me.txtRegdNo = New common.Controls.MyTextBox()
        Me.txtRegNo = New common.Controls.MyLabel()
        Me.txtTcanNo = New common.Controls.MyTextBox()
        Me.lblTcanNo = New common.Controls.MyLabel()
        Me.txtTanNo = New common.Controls.MyTextBox()
        Me.lblTanNo = New common.Controls.MyLabel()
        Me.txtPanNo = New common.Controls.MyTextBox()
        Me.lblPanNo = New common.Controls.MyLabel()
        Me.txtVatRegNo = New common.Controls.MyTextBox()
        Me.lblVatRegNo = New common.Controls.MyLabel()
        Me.txtCstLst = New common.Controls.MyTextBox()
        Me.lblCstLst = New common.Controls.MyLabel()
        Me.txtTinNo = New common.Controls.MyTextBox()
        Me.txtPinCode = New common.Controls.MyTextBox()
        Me.lblPinCode = New common.Controls.MyLabel()
        Me.lblTinNo = New common.Controls.MyLabel()
        Me.lblState = New common.Controls.MyLabel()
        Me.txtFax = New common.Controls.MyTextBox()
        Me.lblTax = New common.Controls.MyLabel()
        Me.btnNew = New Telerik.WinControls.UI.RadButton()
        Me.txtEmail = New common.Controls.MyTextBox()
        Me.lblEmail = New common.Controls.MyLabel()
        Me.lblTelephone2 = New common.Controls.MyLabel()
        Me.lblTelephone1 = New common.Controls.MyLabel()
        Me.txtCity = New common.Controls.MyTextBox()
        Me.lblCity = New common.Controls.MyLabel()
        Me.txtAdd3 = New common.Controls.MyTextBox()
        Me.lblAdress = New common.Controls.MyLabel()
        Me.txtAdd2 = New common.Controls.MyTextBox()
        Me.txtAdd1 = New common.Controls.MyTextBox()
        Me.txtCompanyName = New common.Controls.MyTextBox()
        Me.lblCompanyName = New common.Controls.MyLabel()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.RadMenuItem1 = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuImport = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuExport = New Telerik.WinControls.UI.RadMenuItem()
        Me.menuClose = New Telerik.WinControls.UI.RadMenuItem()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnClearLogo1 = New Telerik.WinControls.UI.RadButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSelectPath1 = New Telerik.WinControls.UI.RadButton()
        Me.RadPageViewPage3 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnClearLogo2 = New Telerik.WinControls.UI.RadButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnSelectPath2 = New Telerik.WinControls.UI.RadButton()
        Me.RadPageViewPage4 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.TxtEmployerDesg = New common.Controls.MyTextBox()
        Me.MyLabel5 = New common.Controls.MyLabel()
        Me.TxtEmployerAdd3 = New common.Controls.MyTextBox()
        Me.MyLabel6 = New common.Controls.MyLabel()
        Me.TxtEmployerAdd2 = New common.Controls.MyTextBox()
        Me.TxtEmployerAdd1 = New common.Controls.MyTextBox()
        Me.TxtEmployerName = New common.Controls.MyTextBox()
        Me.MyLabel7 = New common.Controls.MyLabel()
        Me.RadPageViewPage5 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.TxtGstInNo = New common.Controls.MyTextBox()
        Me.MyLabel14 = New common.Controls.MyLabel()
        Me.TxtGstReg = New common.Controls.MyTextBox()
        Me.MyLabel13 = New common.Controls.MyLabel()
        Me.RadPageViewPage6 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtbranchAddress = New common.Controls.MyTextBox()
        Me.MyLabel17 = New common.Controls.MyLabel()
        Me.txtifsccode = New common.Controls.MyTextBox()
        Me.MyLabel18 = New common.Controls.MyLabel()
        Me.TxtBankAccountNo = New common.Controls.MyTextBox()
        Me.MyLabel15 = New common.Controls.MyLabel()
        Me.txtBankName = New common.Controls.MyTextBox()
        Me.MyLabel16 = New common.Controls.MyLabel()
        Me.RadPageViewPage7 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnBGClear = New Telerik.WinControls.UI.RadButton()
        Me.BGImage = New System.Windows.Forms.PictureBox()
        Me.btnBackgroundselect = New Telerik.WinControls.UI.RadButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.dtPanIssueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTinIssueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelephone2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelephone1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_main_company, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCompanyCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegdNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTcanNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTcanNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTanNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTanNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPanNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPanNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVatRegNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVatRegNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCstLst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCstLst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTinNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPinCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPinCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTinNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelephone2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelephone1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdd3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAdress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCompanyName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        Me.RadPageViewPage2.SuspendLayout()
        CType(Me.btnClearLogo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectPath1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage3.SuspendLayout()
        CType(Me.btnClearLogo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectPath2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage4.SuspendLayout()
        CType(Me.TxtEmployerDesg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmployerAdd3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmployerAdd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmployerAdd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmployerName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage5.SuspendLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.TxtGstInNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtGstReg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage6.SuspendLayout()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.txtbranchAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtifsccode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBankAccountNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBankName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage7.SuspendLayout()
        CType(Me.btnBGClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBackgroundselect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.dtPanIssueDate)
        Me.RadGroupBox1.Controls.Add(Me.MyLabel12)
        Me.RadGroupBox1.Controls.Add(Me.dtTinIssueDate)
        Me.RadGroupBox1.Controls.Add(Me.MyLabel11)
        Me.RadGroupBox1.Controls.Add(Me.txtTelephone2)
        Me.RadGroupBox1.Controls.Add(Me.txtTelephone1)
        Me.RadGroupBox1.Controls.Add(Me.chk_main_company)
        Me.RadGroupBox1.Controls.Add(Me.txtState)
        Me.RadGroupBox1.Controls.Add(Me.fndCompanyCode)
        Me.RadGroupBox1.Controls.Add(Me.txtRegdNo)
        Me.RadGroupBox1.Controls.Add(Me.txtTcanNo)
        Me.RadGroupBox1.Controls.Add(Me.lblTcanNo)
        Me.RadGroupBox1.Controls.Add(Me.txtTanNo)
        Me.RadGroupBox1.Controls.Add(Me.lblTanNo)
        Me.RadGroupBox1.Controls.Add(Me.txtPanNo)
        Me.RadGroupBox1.Controls.Add(Me.lblPanNo)
        Me.RadGroupBox1.Controls.Add(Me.txtVatRegNo)
        Me.RadGroupBox1.Controls.Add(Me.lblVatRegNo)
        Me.RadGroupBox1.Controls.Add(Me.txtRegNo)
        Me.RadGroupBox1.Controls.Add(Me.txtCstLst)
        Me.RadGroupBox1.Controls.Add(Me.txtTinNo)
        Me.RadGroupBox1.Controls.Add(Me.txtPinCode)
        Me.RadGroupBox1.Controls.Add(Me.lblTinNo)
        Me.RadGroupBox1.Controls.Add(Me.lblCstLst)
        Me.RadGroupBox1.Controls.Add(Me.lblState)
        Me.RadGroupBox1.Controls.Add(Me.lblPinCode)
        Me.RadGroupBox1.Controls.Add(Me.txtFax)
        Me.RadGroupBox1.Controls.Add(Me.btnNew)
        Me.RadGroupBox1.Controls.Add(Me.txtEmail)
        Me.RadGroupBox1.Controls.Add(Me.lblEmail)
        Me.RadGroupBox1.Controls.Add(Me.lblTax)
        Me.RadGroupBox1.Controls.Add(Me.lblTelephone2)
        Me.RadGroupBox1.Controls.Add(Me.lblTelephone1)
        Me.RadGroupBox1.Controls.Add(Me.txtCity)
        Me.RadGroupBox1.Controls.Add(Me.lblCity)
        Me.RadGroupBox1.Controls.Add(Me.txtAdd3)
        Me.RadGroupBox1.Controls.Add(Me.txtAdd2)
        Me.RadGroupBox1.Controls.Add(Me.txtAdd1)
        Me.RadGroupBox1.Controls.Add(Me.lblAdress)
        Me.RadGroupBox1.Controls.Add(Me.txtCompanyName)
        Me.RadGroupBox1.Controls.Add(Me.lblCompanyName)
        Me.RadGroupBox1.Controls.Add(Me.lblCompanyCode)
        Me.RadGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(807, 488)
        Me.RadGroupBox1.TabIndex = 0
        '
        'dtPanIssueDate
        '
        Me.dtPanIssueDate.CalculationExpression = Nothing
        Me.dtPanIssueDate.CustomFormat = "dd/MM/yyyy"
        Me.dtPanIssueDate.FieldCode = Nothing
        Me.dtPanIssueDate.FieldDesc = Nothing
        Me.dtPanIssueDate.FieldMaxLength = 0
        Me.dtPanIssueDate.FieldName = Nothing
        Me.dtPanIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPanIssueDate.isCalculatedField = False
        Me.dtPanIssueDate.IsSourceFromTable = False
        Me.dtPanIssueDate.IsSourceFromValueList = False
        Me.dtPanIssueDate.IsUnique = False
        Me.dtPanIssueDate.Location = New System.Drawing.Point(699, 207)
        Me.dtPanIssueDate.MendatroryField = False
        Me.dtPanIssueDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtPanIssueDate.MyLinkLable1 = Nothing
        Me.dtPanIssueDate.MyLinkLable2 = Nothing
        Me.dtPanIssueDate.Name = "dtPanIssueDate"
        Me.dtPanIssueDate.NullDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtPanIssueDate.ReferenceFieldDesc = Nothing
        Me.dtPanIssueDate.ReferenceFieldName = Nothing
        Me.dtPanIssueDate.ReferenceTableName = Nothing
        Me.dtPanIssueDate.Size = New System.Drawing.Size(96, 20)
        Me.dtPanIssueDate.TabIndex = 303
        Me.dtPanIssueDate.TabStop = False
        Me.dtPanIssueDate.Text = "10/06/2011"
        Me.dtPanIssueDate.Value = New Date(2011, 6, 10, 11, 51, 56, 953)
        '
        'MyLabel12
        '
        Me.MyLabel12.FieldName = Nothing
        Me.MyLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel12.Location = New System.Drawing.Point(664, 209)
        Me.MyLabel12.Name = "MyLabel12"
        Me.MyLabel12.Size = New System.Drawing.Size(30, 16)
        Me.MyLabel12.TabIndex = 302
        Me.MyLabel12.Text = "Date"
        '
        'dtTinIssueDate
        '
        Me.dtTinIssueDate.CalculationExpression = Nothing
        Me.dtTinIssueDate.CustomFormat = "dd/MM/yyyy"
        Me.dtTinIssueDate.FieldCode = Nothing
        Me.dtTinIssueDate.FieldDesc = Nothing
        Me.dtTinIssueDate.FieldMaxLength = 0
        Me.dtTinIssueDate.FieldName = Nothing
        Me.dtTinIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTinIssueDate.isCalculatedField = False
        Me.dtTinIssueDate.IsSourceFromTable = False
        Me.dtTinIssueDate.IsSourceFromValueList = False
        Me.dtTinIssueDate.IsUnique = False
        Me.dtTinIssueDate.Location = New System.Drawing.Point(699, 145)
        Me.dtTinIssueDate.MendatroryField = False
        Me.dtTinIssueDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtTinIssueDate.MyLinkLable1 = Nothing
        Me.dtTinIssueDate.MyLinkLable2 = Nothing
        Me.dtTinIssueDate.Name = "dtTinIssueDate"
        Me.dtTinIssueDate.NullDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtTinIssueDate.ReferenceFieldDesc = Nothing
        Me.dtTinIssueDate.ReferenceFieldName = Nothing
        Me.dtTinIssueDate.ReferenceTableName = Nothing
        Me.dtTinIssueDate.Size = New System.Drawing.Size(96, 20)
        Me.dtTinIssueDate.TabIndex = 301
        Me.dtTinIssueDate.TabStop = False
        Me.dtTinIssueDate.Text = "10/06/2011"
        Me.dtTinIssueDate.Value = New Date(2011, 6, 10, 11, 51, 56, 953)
        '
        'MyLabel11
        '
        Me.MyLabel11.FieldName = Nothing
        Me.MyLabel11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel11.Location = New System.Drawing.Point(664, 147)
        Me.MyLabel11.Name = "MyLabel11"
        Me.MyLabel11.Size = New System.Drawing.Size(30, 16)
        Me.MyLabel11.TabIndex = 83
        Me.MyLabel11.Text = "Date"
        '
        'txtTelephone2
        '
        Me.txtTelephone2.Location = New System.Drawing.Point(167, 148)
        Me.txtTelephone2.Mask = "(+99)0000000000"
        Me.txtTelephone2.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtTelephone2.Name = "txtTelephone2"
        Me.txtTelephone2.Size = New System.Drawing.Size(292, 20)
        Me.txtTelephone2.TabIndex = 68
        Me.txtTelephone2.TabStop = False
        Me.txtTelephone2.Text = "(+__)__________"
        '
        'txtTelephone1
        '
        Me.txtTelephone1.Location = New System.Drawing.Point(167, 126)
        Me.txtTelephone1.Mask = "(+99)0000000000"
        Me.txtTelephone1.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.txtTelephone1.Name = "txtTelephone1"
        Me.txtTelephone1.Size = New System.Drawing.Size(292, 20)
        Me.txtTelephone1.TabIndex = 67
        Me.txtTelephone1.TabStop = False
        Me.txtTelephone1.Text = "(+__)__________"
        '
        'chk_main_company
        '
        Me.chk_main_company.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_main_company.Location = New System.Drawing.Point(470, 7)
        Me.chk_main_company.Name = "chk_main_company"
        Me.chk_main_company.Size = New System.Drawing.Size(108, 16)
        Me.chk_main_company.TabIndex = 63
        Me.chk_main_company.Text = "Is Main Company"
        '
        'txtState
        '
        Me.txtState.CalculationExpression = Nothing
        Me.txtState.FieldCode = Nothing
        Me.txtState.FieldDesc = Nothing
        Me.txtState.FieldMaxLength = 0
        Me.txtState.FieldName = Nothing
        Me.txtState.isCalculatedField = False
        Me.txtState.IsSourceFromTable = False
        Me.txtState.IsSourceFromValueList = False
        Me.txtState.IsUnique = False
        Me.txtState.Location = New System.Drawing.Point(533, 125)
        Me.txtState.MendatroryField = False
        Me.txtState.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.MyLinkLable1 = Nothing
        Me.txtState.MyLinkLable2 = Nothing
        Me.txtState.MyReadOnly = False
        Me.txtState.MyShowMasterFormButton = False
        Me.txtState.Name = "txtState"
        Me.txtState.ReferenceFieldDesc = Nothing
        Me.txtState.ReferenceFieldName = Nothing
        Me.txtState.ReferenceTableName = Nothing
        Me.txtState.Size = New System.Drawing.Size(262, 19)
        Me.txtState.TabIndex = 9
        Me.txtState.Value = ""
        '
        'fndCompanyCode
        '
        Me.fndCompanyCode.FieldName = Nothing
        Me.fndCompanyCode.Location = New System.Drawing.Point(167, 6)
        Me.fndCompanyCode.MendatroryField = True
        Me.fndCompanyCode.MyCharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.fndCompanyCode.MyFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.fndCompanyCode.MyLinkLable1 = Me.lblCompanyCode
        Me.fndCompanyCode.MyLinkLable2 = Nothing
        Me.fndCompanyCode.MyMaxLength = 32767
        Me.fndCompanyCode.MyReadOnly = False
        Me.fndCompanyCode.Name = "fndCompanyCode"
        Me.fndCompanyCode.Size = New System.Drawing.Size(272, 18)
        Me.fndCompanyCode.TabIndex = 0
        Me.fndCompanyCode.Value = ""
        '
        'lblCompanyCode
        '
        Me.lblCompanyCode.FieldName = Nothing
        Me.lblCompanyCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyCode.Location = New System.Drawing.Point(12, 6)
        Me.lblCompanyCode.Name = "lblCompanyCode"
        Me.lblCompanyCode.Size = New System.Drawing.Size(85, 16)
        Me.lblCompanyCode.TabIndex = 62
        Me.lblCompanyCode.Text = "Company Code"
        '
        'txtRegdNo
        '
        Me.txtRegdNo.CalculationExpression = Nothing
        Me.txtRegdNo.FieldCode = Nothing
        Me.txtRegdNo.FieldDesc = Nothing
        Me.txtRegdNo.FieldMaxLength = 0
        Me.txtRegdNo.FieldName = Nothing
        Me.txtRegdNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdNo.isCalculatedField = False
        Me.txtRegdNo.IsSourceFromTable = False
        Me.txtRegdNo.IsSourceFromValueList = False
        Me.txtRegdNo.IsUnique = False
        Me.txtRegdNo.Location = New System.Drawing.Point(533, 189)
        Me.txtRegdNo.MaxLength = 30
        Me.txtRegdNo.MendatroryField = False
        Me.txtRegdNo.MyLinkLable1 = Me.txtRegNo
        Me.txtRegdNo.MyLinkLable2 = Nothing
        Me.txtRegdNo.Name = "txtRegdNo"
        Me.txtRegdNo.ReferenceFieldDesc = Nothing
        Me.txtRegdNo.ReferenceFieldName = Nothing
        Me.txtRegdNo.ReferenceTableName = Nothing
        Me.txtRegdNo.Size = New System.Drawing.Size(262, 18)
        Me.txtRegdNo.TabIndex = 15
        '
        'txtRegNo
        '
        Me.txtRegNo.FieldName = Nothing
        Me.txtRegNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegNo.Location = New System.Drawing.Point(468, 191)
        Me.txtRegNo.Name = "txtRegNo"
        Me.txtRegNo.Size = New System.Drawing.Size(57, 16)
        Me.txtRegNo.TabIndex = 50
        Me.txtRegNo.Text = "Regd  No."
        '
        'txtTcanNo
        '
        Me.txtTcanNo.CalculationExpression = Nothing
        Me.txtTcanNo.FieldCode = Nothing
        Me.txtTcanNo.FieldDesc = Nothing
        Me.txtTcanNo.FieldMaxLength = 0
        Me.txtTcanNo.FieldName = Nothing
        Me.txtTcanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTcanNo.isCalculatedField = False
        Me.txtTcanNo.IsSourceFromTable = False
        Me.txtTcanNo.IsSourceFromValueList = False
        Me.txtTcanNo.IsUnique = False
        Me.txtTcanNo.Location = New System.Drawing.Point(167, 235)
        Me.txtTcanNo.MaxLength = 30
        Me.txtTcanNo.MendatroryField = False
        Me.txtTcanNo.MyLinkLable1 = Me.lblTcanNo
        Me.txtTcanNo.MyLinkLable2 = Nothing
        Me.txtTcanNo.Name = "txtTcanNo"
        Me.txtTcanNo.ReferenceFieldDesc = Nothing
        Me.txtTcanNo.ReferenceFieldName = Nothing
        Me.txtTcanNo.ReferenceTableName = Nothing
        Me.txtTcanNo.Size = New System.Drawing.Size(292, 18)
        Me.txtTcanNo.TabIndex = 21
        Me.txtTcanNo.Text = " "
        '
        'lblTcanNo
        '
        Me.lblTcanNo.FieldName = Nothing
        Me.lblTcanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTcanNo.Location = New System.Drawing.Point(16, 235)
        Me.lblTcanNo.Name = "lblTcanNo"
        Me.lblTcanNo.Size = New System.Drawing.Size(47, 16)
        Me.lblTcanNo.TabIndex = 45
        Me.lblTcanNo.Text = "Website"
        '
        'txtTanNo
        '
        Me.txtTanNo.CalculationExpression = Nothing
        Me.txtTanNo.FieldCode = Nothing
        Me.txtTanNo.FieldDesc = Nothing
        Me.txtTanNo.FieldMaxLength = 0
        Me.txtTanNo.FieldName = Nothing
        Me.txtTanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTanNo.isCalculatedField = False
        Me.txtTanNo.IsSourceFromTable = False
        Me.txtTanNo.IsSourceFromValueList = False
        Me.txtTanNo.IsUnique = False
        Me.txtTanNo.Location = New System.Drawing.Point(533, 229)
        Me.txtTanNo.MaxLength = 30
        Me.txtTanNo.MendatroryField = False
        Me.txtTanNo.MyLinkLable1 = Me.lblTanNo
        Me.txtTanNo.MyLinkLable2 = Nothing
        Me.txtTanNo.Name = "txtTanNo"
        Me.txtTanNo.ReferenceFieldDesc = Nothing
        Me.txtTanNo.ReferenceFieldName = Nothing
        Me.txtTanNo.ReferenceTableName = Nothing
        Me.txtTanNo.Size = New System.Drawing.Size(262, 18)
        Me.txtTanNo.TabIndex = 19
        Me.txtTanNo.Text = " "
        '
        'lblTanNo
        '
        Me.lblTanNo.FieldName = Nothing
        Me.lblTanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTanNo.Location = New System.Drawing.Point(468, 229)
        Me.lblTanNo.Name = "lblTanNo"
        Me.lblTanNo.Size = New System.Drawing.Size(50, 16)
        Me.lblTanNo.TabIndex = 46
        Me.lblTanNo.Text = "Tan  No."
        '
        'txtPanNo
        '
        Me.txtPanNo.CalculationExpression = Nothing
        Me.txtPanNo.FieldCode = Nothing
        Me.txtPanNo.FieldDesc = Nothing
        Me.txtPanNo.FieldMaxLength = 0
        Me.txtPanNo.FieldName = Nothing
        Me.txtPanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanNo.isCalculatedField = False
        Me.txtPanNo.IsSourceFromTable = False
        Me.txtPanNo.IsSourceFromValueList = False
        Me.txtPanNo.IsUnique = False
        Me.txtPanNo.Location = New System.Drawing.Point(533, 209)
        Me.txtPanNo.MaxLength = 30
        Me.txtPanNo.MendatroryField = False
        Me.txtPanNo.MyLinkLable1 = Me.lblPanNo
        Me.txtPanNo.MyLinkLable2 = Nothing
        Me.txtPanNo.Name = "txtPanNo"
        Me.txtPanNo.ReferenceFieldDesc = Nothing
        Me.txtPanNo.ReferenceFieldName = Nothing
        Me.txtPanNo.ReferenceTableName = Nothing
        Me.txtPanNo.Size = New System.Drawing.Size(127, 18)
        Me.txtPanNo.TabIndex = 17
        Me.txtPanNo.Text = " "
        '
        'lblPanNo
        '
        Me.lblPanNo.FieldName = Nothing
        Me.lblPanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanNo.Location = New System.Drawing.Point(468, 209)
        Me.lblPanNo.Name = "lblPanNo"
        Me.lblPanNo.Size = New System.Drawing.Size(47, 16)
        Me.lblPanNo.TabIndex = 49
        Me.lblPanNo.Text = "Pan No."
        '
        'txtVatRegNo
        '
        Me.txtVatRegNo.CalculationExpression = Nothing
        Me.txtVatRegNo.FieldCode = Nothing
        Me.txtVatRegNo.FieldDesc = Nothing
        Me.txtVatRegNo.FieldMaxLength = 0
        Me.txtVatRegNo.FieldName = Nothing
        Me.txtVatRegNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVatRegNo.isCalculatedField = False
        Me.txtVatRegNo.IsSourceFromTable = False
        Me.txtVatRegNo.IsSourceFromValueList = False
        Me.txtVatRegNo.IsUnique = False
        Me.txtVatRegNo.Location = New System.Drawing.Point(167, 211)
        Me.txtVatRegNo.MaxLength = 30
        Me.txtVatRegNo.MendatroryField = False
        Me.txtVatRegNo.MyLinkLable1 = Me.lblVatRegNo
        Me.txtVatRegNo.MyLinkLable2 = Nothing
        Me.txtVatRegNo.Name = "txtVatRegNo"
        Me.txtVatRegNo.ReferenceFieldDesc = Nothing
        Me.txtVatRegNo.ReferenceFieldName = Nothing
        Me.txtVatRegNo.ReferenceTableName = Nothing
        Me.txtVatRegNo.Size = New System.Drawing.Size(292, 18)
        Me.txtVatRegNo.TabIndex = 16
        Me.txtVatRegNo.Text = " "
        '
        'lblVatRegNo
        '
        Me.lblVatRegNo.FieldName = Nothing
        Me.lblVatRegNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVatRegNo.Location = New System.Drawing.Point(12, 212)
        Me.lblVatRegNo.Name = "lblVatRegNo"
        Me.lblVatRegNo.Size = New System.Drawing.Size(108, 16)
        Me.lblVatRegNo.TabIndex = 48
        Me.lblVatRegNo.Text = "Vat Registration No."
        '
        'txtCstLst
        '
        Me.txtCstLst.CalculationExpression = Nothing
        Me.txtCstLst.FieldCode = Nothing
        Me.txtCstLst.FieldDesc = Nothing
        Me.txtCstLst.FieldMaxLength = 0
        Me.txtCstLst.FieldName = Nothing
        Me.txtCstLst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCstLst.isCalculatedField = False
        Me.txtCstLst.IsSourceFromTable = False
        Me.txtCstLst.IsSourceFromValueList = False
        Me.txtCstLst.IsUnique = False
        Me.txtCstLst.Location = New System.Drawing.Point(533, 167)
        Me.txtCstLst.MaxLength = 30
        Me.txtCstLst.MendatroryField = False
        Me.txtCstLst.MyLinkLable1 = Me.lblCstLst
        Me.txtCstLst.MyLinkLable2 = Nothing
        Me.txtCstLst.Name = "txtCstLst"
        Me.txtCstLst.ReferenceFieldDesc = Nothing
        Me.txtCstLst.ReferenceFieldName = Nothing
        Me.txtCstLst.ReferenceTableName = Nothing
        Me.txtCstLst.Size = New System.Drawing.Size(262, 18)
        Me.txtCstLst.TabIndex = 13
        '
        'lblCstLst
        '
        Me.lblCstLst.FieldName = Nothing
        Me.lblCstLst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCstLst.Location = New System.Drawing.Point(468, 169)
        Me.lblCstLst.Name = "lblCstLst"
        Me.lblCstLst.Size = New System.Drawing.Size(41, 16)
        Me.lblCstLst.TabIndex = 53
        Me.lblCstLst.Text = "Cst/Lst"
        '
        'txtTinNo
        '
        Me.txtTinNo.CalculationExpression = Nothing
        Me.txtTinNo.FieldCode = Nothing
        Me.txtTinNo.FieldDesc = Nothing
        Me.txtTinNo.FieldMaxLength = 0
        Me.txtTinNo.FieldName = Nothing
        Me.txtTinNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTinNo.isCalculatedField = False
        Me.txtTinNo.IsSourceFromTable = False
        Me.txtTinNo.IsSourceFromValueList = False
        Me.txtTinNo.IsUnique = False
        Me.txtTinNo.Location = New System.Drawing.Point(533, 145)
        Me.txtTinNo.MaxLength = 20
        Me.txtTinNo.MendatroryField = False
        Me.txtTinNo.MyLinkLable1 = Me.lblTanNo
        Me.txtTinNo.MyLinkLable2 = Nothing
        Me.txtTinNo.Name = "txtTinNo"
        Me.txtTinNo.ReferenceFieldDesc = Nothing
        Me.txtTinNo.ReferenceFieldName = Nothing
        Me.txtTinNo.ReferenceTableName = Nothing
        Me.txtTinNo.Size = New System.Drawing.Size(127, 18)
        Me.txtTinNo.TabIndex = 11
        '
        'txtPinCode
        '
        Me.txtPinCode.CalculationExpression = Nothing
        Me.txtPinCode.FieldCode = Nothing
        Me.txtPinCode.FieldDesc = Nothing
        Me.txtPinCode.FieldMaxLength = 0
        Me.txtPinCode.FieldName = Nothing
        Me.txtPinCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPinCode.isCalculatedField = False
        Me.txtPinCode.IsSourceFromTable = False
        Me.txtPinCode.IsSourceFromValueList = False
        Me.txtPinCode.IsUnique = False
        Me.txtPinCode.Location = New System.Drawing.Point(533, 106)
        Me.txtPinCode.MaxLength = 20
        Me.txtPinCode.MendatroryField = False
        Me.txtPinCode.MyLinkLable1 = Me.lblPinCode
        Me.txtPinCode.MyLinkLable2 = Nothing
        Me.txtPinCode.Name = "txtPinCode"
        Me.txtPinCode.ReferenceFieldDesc = Nothing
        Me.txtPinCode.ReferenceFieldName = Nothing
        Me.txtPinCode.ReferenceTableName = Nothing
        Me.txtPinCode.Size = New System.Drawing.Size(262, 18)
        Me.txtPinCode.TabIndex = 7
        '
        'lblPinCode
        '
        Me.lblPinCode.FieldName = Nothing
        Me.lblPinCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPinCode.Location = New System.Drawing.Point(468, 108)
        Me.lblPinCode.Name = "lblPinCode"
        Me.lblPinCode.Size = New System.Drawing.Size(53, 16)
        Me.lblPinCode.TabIndex = 58
        Me.lblPinCode.Text = "Pin Code"
        '
        'lblTinNo
        '
        Me.lblTinNo.FieldName = Nothing
        Me.lblTinNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTinNo.Location = New System.Drawing.Point(468, 147)
        Me.lblTinNo.Name = "lblTinNo"
        Me.lblTinNo.Size = New System.Drawing.Size(40, 16)
        Me.lblTinNo.TabIndex = 54
        Me.lblTinNo.Text = "Tin No"
        '
        'lblState
        '
        Me.lblState.FieldName = Nothing
        Me.lblState.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblState.Location = New System.Drawing.Point(468, 129)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(33, 16)
        Me.lblState.TabIndex = 57
        Me.lblState.Text = "State"
        '
        'txtFax
        '
        Me.txtFax.CalculationExpression = Nothing
        Me.txtFax.FieldCode = Nothing
        Me.txtFax.FieldDesc = Nothing
        Me.txtFax.FieldMaxLength = 0
        Me.txtFax.FieldName = Nothing
        Me.txtFax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.isCalculatedField = False
        Me.txtFax.IsSourceFromTable = False
        Me.txtFax.IsSourceFromValueList = False
        Me.txtFax.IsUnique = False
        Me.txtFax.Location = New System.Drawing.Point(167, 170)
        Me.txtFax.MaxLength = 12
        Me.txtFax.MendatroryField = False
        Me.txtFax.MyLinkLable1 = Me.lblTax
        Me.txtFax.MyLinkLable2 = Nothing
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReferenceFieldDesc = Nothing
        Me.txtFax.ReferenceFieldName = Nothing
        Me.txtFax.ReferenceTableName = Nothing
        Me.txtFax.Size = New System.Drawing.Size(292, 18)
        Me.txtFax.TabIndex = 12
        '
        'lblTax
        '
        Me.lblTax.FieldName = Nothing
        Me.lblTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTax.Location = New System.Drawing.Point(12, 171)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(25, 16)
        Me.lblTax.TabIndex = 52
        Me.lblTax.Text = "Fax"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.Location = New System.Drawing.Point(445, 6)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(14, 21)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = " "
        Me.ToolTip1.SetToolTip(Me.btnNew, "New")
        '
        'txtEmail
        '
        Me.txtEmail.CalculationExpression = Nothing
        Me.txtEmail.FieldCode = Nothing
        Me.txtEmail.FieldDesc = Nothing
        Me.txtEmail.FieldMaxLength = 0
        Me.txtEmail.FieldName = Nothing
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.isCalculatedField = False
        Me.txtEmail.IsSourceFromTable = False
        Me.txtEmail.IsSourceFromValueList = False
        Me.txtEmail.IsUnique = False
        Me.txtEmail.Location = New System.Drawing.Point(167, 191)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.MendatroryField = False
        Me.txtEmail.MyLinkLable1 = Me.lblEmail
        Me.txtEmail.MyLinkLable2 = Nothing
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReferenceFieldDesc = Nothing
        Me.txtEmail.ReferenceFieldName = Nothing
        Me.txtEmail.ReferenceTableName = Nothing
        Me.txtEmail.Size = New System.Drawing.Size(292, 18)
        Me.txtEmail.TabIndex = 14
        '
        'lblEmail
        '
        Me.lblEmail.FieldName = Nothing
        Me.lblEmail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(12, 192)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(34, 16)
        Me.lblEmail.TabIndex = 51
        Me.lblEmail.Text = "Email"
        '
        'lblTelephone2
        '
        Me.lblTelephone2.FieldName = Nothing
        Me.lblTelephone2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelephone2.Location = New System.Drawing.Point(12, 148)
        Me.lblTelephone2.Name = "lblTelephone2"
        Me.lblTelephone2.Size = New System.Drawing.Size(66, 16)
        Me.lblTelephone2.TabIndex = 55
        Me.lblTelephone2.Text = "Telephone2"
        '
        'lblTelephone1
        '
        Me.lblTelephone1.FieldName = Nothing
        Me.lblTelephone1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelephone1.Location = New System.Drawing.Point(12, 128)
        Me.lblTelephone1.Name = "lblTelephone1"
        Me.lblTelephone1.Size = New System.Drawing.Size(66, 16)
        Me.lblTelephone1.TabIndex = 56
        Me.lblTelephone1.Text = "Telephone1"
        '
        'txtCity
        '
        Me.txtCity.CalculationExpression = Nothing
        Me.txtCity.FieldCode = Nothing
        Me.txtCity.FieldDesc = Nothing
        Me.txtCity.FieldMaxLength = 0
        Me.txtCity.FieldName = Nothing
        Me.txtCity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.isCalculatedField = False
        Me.txtCity.IsSourceFromTable = False
        Me.txtCity.IsSourceFromValueList = False
        Me.txtCity.IsUnique = False
        Me.txtCity.Location = New System.Drawing.Point(167, 107)
        Me.txtCity.MaxLength = 50
        Me.txtCity.MendatroryField = False
        Me.txtCity.MyLinkLable1 = Me.lblCity
        Me.txtCity.MyLinkLable2 = Nothing
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReferenceFieldDesc = Nothing
        Me.txtCity.ReferenceFieldName = Nothing
        Me.txtCity.ReferenceTableName = Nothing
        Me.txtCity.Size = New System.Drawing.Size(292, 18)
        Me.txtCity.TabIndex = 6
        '
        'lblCity
        '
        Me.lblCity.FieldName = Nothing
        Me.lblCity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCity.Location = New System.Drawing.Point(12, 109)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(56, 16)
        Me.lblCity.TabIndex = 59
        Me.lblCity.Text = "City Code"
        '
        'txtAdd3
        '
        Me.txtAdd3.CalculationExpression = Nothing
        Me.txtAdd3.FieldCode = Nothing
        Me.txtAdd3.FieldDesc = Nothing
        Me.txtAdd3.FieldMaxLength = 0
        Me.txtAdd3.FieldName = Nothing
        Me.txtAdd3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdd3.isCalculatedField = False
        Me.txtAdd3.IsSourceFromTable = False
        Me.txtAdd3.IsSourceFromValueList = False
        Me.txtAdd3.IsUnique = False
        Me.txtAdd3.Location = New System.Drawing.Point(167, 87)
        Me.txtAdd3.MaxLength = 50
        Me.txtAdd3.MendatroryField = False
        Me.txtAdd3.MyLinkLable1 = Me.lblAdress
        Me.txtAdd3.MyLinkLable2 = Nothing
        Me.txtAdd3.Name = "txtAdd3"
        Me.txtAdd3.ReferenceFieldDesc = Nothing
        Me.txtAdd3.ReferenceFieldName = Nothing
        Me.txtAdd3.ReferenceTableName = Nothing
        Me.txtAdd3.Size = New System.Drawing.Size(628, 18)
        Me.txtAdd3.TabIndex = 5
        '
        'lblAdress
        '
        Me.lblAdress.FieldName = Nothing
        Me.lblAdress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdress.Location = New System.Drawing.Point(12, 47)
        Me.lblAdress.Name = "lblAdress"
        Me.lblAdress.Size = New System.Drawing.Size(48, 16)
        Me.lblAdress.TabIndex = 60
        Me.lblAdress.Text = "Address"
        '
        'txtAdd2
        '
        Me.txtAdd2.CalculationExpression = Nothing
        Me.txtAdd2.FieldCode = Nothing
        Me.txtAdd2.FieldDesc = Nothing
        Me.txtAdd2.FieldMaxLength = 0
        Me.txtAdd2.FieldName = Nothing
        Me.txtAdd2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdd2.isCalculatedField = False
        Me.txtAdd2.IsSourceFromTable = False
        Me.txtAdd2.IsSourceFromValueList = False
        Me.txtAdd2.IsUnique = False
        Me.txtAdd2.Location = New System.Drawing.Point(167, 67)
        Me.txtAdd2.MaxLength = 50
        Me.txtAdd2.MendatroryField = False
        Me.txtAdd2.MyLinkLable1 = Me.lblAdress
        Me.txtAdd2.MyLinkLable2 = Nothing
        Me.txtAdd2.Name = "txtAdd2"
        Me.txtAdd2.ReferenceFieldDesc = Nothing
        Me.txtAdd2.ReferenceFieldName = Nothing
        Me.txtAdd2.ReferenceTableName = Nothing
        Me.txtAdd2.Size = New System.Drawing.Size(628, 18)
        Me.txtAdd2.TabIndex = 4
        '
        'txtAdd1
        '
        Me.txtAdd1.CalculationExpression = Nothing
        Me.txtAdd1.FieldCode = Nothing
        Me.txtAdd1.FieldDesc = Nothing
        Me.txtAdd1.FieldMaxLength = 0
        Me.txtAdd1.FieldName = Nothing
        Me.txtAdd1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdd1.isCalculatedField = False
        Me.txtAdd1.IsSourceFromTable = False
        Me.txtAdd1.IsSourceFromValueList = False
        Me.txtAdd1.IsUnique = False
        Me.txtAdd1.Location = New System.Drawing.Point(167, 47)
        Me.txtAdd1.MaxLength = 50
        Me.txtAdd1.MendatroryField = False
        Me.txtAdd1.MyLinkLable1 = Me.lblAdress
        Me.txtAdd1.MyLinkLable2 = Nothing
        Me.txtAdd1.Name = "txtAdd1"
        Me.txtAdd1.ReferenceFieldDesc = Nothing
        Me.txtAdd1.ReferenceFieldName = Nothing
        Me.txtAdd1.ReferenceTableName = Nothing
        Me.txtAdd1.Size = New System.Drawing.Size(628, 18)
        Me.txtAdd1.TabIndex = 3
        '
        'txtCompanyName
        '
        Me.txtCompanyName.CalculationExpression = Nothing
        Me.txtCompanyName.FieldCode = Nothing
        Me.txtCompanyName.FieldDesc = Nothing
        Me.txtCompanyName.FieldMaxLength = 0
        Me.txtCompanyName.FieldName = Nothing
        Me.txtCompanyName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyName.isCalculatedField = False
        Me.txtCompanyName.IsSourceFromTable = False
        Me.txtCompanyName.IsSourceFromValueList = False
        Me.txtCompanyName.IsUnique = False
        Me.txtCompanyName.Location = New System.Drawing.Point(167, 26)
        Me.txtCompanyName.MaxLength = 100
        Me.txtCompanyName.MendatroryField = False
        Me.txtCompanyName.MyLinkLable1 = Me.lblCompanyName
        Me.txtCompanyName.MyLinkLable2 = Nothing
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReferenceFieldDesc = Nothing
        Me.txtCompanyName.ReferenceFieldName = Nothing
        Me.txtCompanyName.ReferenceTableName = Nothing
        Me.txtCompanyName.Size = New System.Drawing.Size(628, 18)
        Me.txtCompanyName.TabIndex = 2
        '
        'lblCompanyName
        '
        Me.lblCompanyName.FieldName = Nothing
        Me.lblCompanyName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.Location = New System.Drawing.Point(12, 25)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(88, 16)
        Me.lblCompanyName.TabIndex = 61
        Me.lblCompanyName.Text = "Company Name"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(6, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 18)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(759, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 18)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        '
        'RadMenuItem1
        '
        Me.RadMenuItem1.AccessibleDescription = "File"
        Me.RadMenuItem1.AccessibleName = "File"
        Me.RadMenuItem1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.menuImport, Me.menuExport, Me.menuClose})
        Me.RadMenuItem1.Name = "RadMenuItem1"
        Me.RadMenuItem1.Text = "File"
        '
        'menuImport
        '
        Me.menuImport.AccessibleDescription = "Import.."
        Me.menuImport.AccessibleName = "Import.."
        Me.menuImport.Name = "menuImport"
        Me.menuImport.Text = "Print.."
        Me.menuImport.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
        '
        'menuExport
        '
        Me.menuExport.AccessibleDescription = "Export"
        Me.menuExport.AccessibleName = "Export"
        Me.menuExport.Name = "menuExport"
        Me.menuExport.Text = "Export"
        '
        'menuClose
        '
        Me.menuClose.AccessibleDescription = "Close"
        Me.menuClose.AccessibleName = "Close"
        Me.menuClose.Name = "menuClose"
        Me.menuClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(77, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(68, 18)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadMenuItem1})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Size = New System.Drawing.Size(830, 20)
        Me.RadMenu1.TabIndex = 1
        Me.RadMenu1.Text = "RadMenu1"
        '
        'RadPageView1
        '
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage3)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage4)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage5)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage6)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage7)
        Me.RadPageView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView1.Location = New System.Drawing.Point(1, 1)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.RadPageViewPage1
        Me.RadPageView1.Size = New System.Drawing.Size(828, 536)
        Me.RadPageView1.TabIndex = 0
        Me.RadPageView1.Text = "RadPageView1"
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.None
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.RadGroupBox1)
        Me.RadPageViewPage1.ItemSize = New System.Drawing.SizeF(101.0!, 28.0!)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage1.Text = "Company Details"
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.btnClearLogo1)
        Me.RadPageViewPage2.Controls.Add(Me.PictureBox1)
        Me.RadPageViewPage2.Controls.Add(Me.btnSelectPath1)
        Me.RadPageViewPage2.ItemSize = New System.Drawing.SizeF(51.0!, 28.0!)
        Me.RadPageViewPage2.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage2.Text = "Logo 1"
        '
        'btnClearLogo1
        '
        Me.btnClearLogo1.Location = New System.Drawing.Point(163, 15)
        Me.btnClearLogo1.Name = "btnClearLogo1"
        Me.btnClearLogo1.Size = New System.Drawing.Size(130, 24)
        Me.btnClearLogo1.TabIndex = 1
        Me.btnClearLogo1.Text = "Clear Logo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Location = New System.Drawing.Point(0, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(807, 440)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btnSelectPath1
        '
        Me.btnSelectPath1.Location = New System.Drawing.Point(27, 15)
        Me.btnSelectPath1.Name = "btnSelectPath1"
        Me.btnSelectPath1.Size = New System.Drawing.Size(130, 24)
        Me.btnSelectPath1.TabIndex = 0
        Me.btnSelectPath1.Text = "Select Logo"
        '
        'RadPageViewPage3
        '
        Me.RadPageViewPage3.Controls.Add(Me.btnClearLogo2)
        Me.RadPageViewPage3.Controls.Add(Me.PictureBox2)
        Me.RadPageViewPage3.Controls.Add(Me.btnSelectPath2)
        Me.RadPageViewPage3.ItemSize = New System.Drawing.SizeF(51.0!, 28.0!)
        Me.RadPageViewPage3.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage3.Name = "RadPageViewPage3"
        Me.RadPageViewPage3.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage3.Text = "Logo 2"
        '
        'btnClearLogo2
        '
        Me.btnClearLogo2.Location = New System.Drawing.Point(160, 10)
        Me.btnClearLogo2.Name = "btnClearLogo2"
        Me.btnClearLogo2.Size = New System.Drawing.Size(130, 24)
        Me.btnClearLogo2.TabIndex = 1
        Me.btnClearLogo2.Text = "Clear Logo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox2.Location = New System.Drawing.Point(0, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(807, 429)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'btnSelectPath2
        '
        Me.btnSelectPath2.Location = New System.Drawing.Point(24, 10)
        Me.btnSelectPath2.Name = "btnSelectPath2"
        Me.btnSelectPath2.Size = New System.Drawing.Size(130, 24)
        Me.btnSelectPath2.TabIndex = 0
        Me.btnSelectPath2.Text = "Select Logo"
        '
        'RadPageViewPage4
        '
        Me.RadPageViewPage4.Controls.Add(Me.TxtEmployerDesg)
        Me.RadPageViewPage4.Controls.Add(Me.MyLabel5)
        Me.RadPageViewPage4.Controls.Add(Me.TxtEmployerAdd3)
        Me.RadPageViewPage4.Controls.Add(Me.TxtEmployerAdd2)
        Me.RadPageViewPage4.Controls.Add(Me.TxtEmployerAdd1)
        Me.RadPageViewPage4.Controls.Add(Me.MyLabel6)
        Me.RadPageViewPage4.Controls.Add(Me.TxtEmployerName)
        Me.RadPageViewPage4.Controls.Add(Me.MyLabel7)
        Me.RadPageViewPage4.ItemSize = New System.Drawing.SizeF(100.0!, 28.0!)
        Me.RadPageViewPage4.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage4.Name = "RadPageViewPage4"
        Me.RadPageViewPage4.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage4.Text = "Employer Details"
        '
        'TxtEmployerDesg
        '
        Me.TxtEmployerDesg.CalculationExpression = Nothing
        Me.TxtEmployerDesg.FieldCode = Nothing
        Me.TxtEmployerDesg.FieldDesc = Nothing
        Me.TxtEmployerDesg.FieldMaxLength = 0
        Me.TxtEmployerDesg.FieldName = Nothing
        Me.TxtEmployerDesg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployerDesg.isCalculatedField = False
        Me.TxtEmployerDesg.IsSourceFromTable = False
        Me.TxtEmployerDesg.IsSourceFromValueList = False
        Me.TxtEmployerDesg.IsUnique = False
        Me.TxtEmployerDesg.Location = New System.Drawing.Point(155, 35)
        Me.TxtEmployerDesg.MaxLength = 50
        Me.TxtEmployerDesg.MendatroryField = False
        Me.TxtEmployerDesg.MyLinkLable1 = Me.MyLabel5
        Me.TxtEmployerDesg.MyLinkLable2 = Nothing
        Me.TxtEmployerDesg.Name = "TxtEmployerDesg"
        Me.TxtEmployerDesg.ReferenceFieldDesc = Nothing
        Me.TxtEmployerDesg.ReferenceFieldName = Nothing
        Me.TxtEmployerDesg.ReferenceTableName = Nothing
        Me.TxtEmployerDesg.Size = New System.Drawing.Size(292, 18)
        Me.TxtEmployerDesg.TabIndex = 66
        '
        'MyLabel5
        '
        Me.MyLabel5.FieldName = Nothing
        Me.MyLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel5.Location = New System.Drawing.Point(2, 36)
        Me.MyLabel5.Name = "MyLabel5"
        Me.MyLabel5.Size = New System.Drawing.Size(66, 16)
        Me.MyLabel5.TabIndex = 67
        Me.MyLabel5.Text = "Designation"
        '
        'TxtEmployerAdd3
        '
        Me.TxtEmployerAdd3.CalculationExpression = Nothing
        Me.TxtEmployerAdd3.FieldCode = Nothing
        Me.TxtEmployerAdd3.FieldDesc = Nothing
        Me.TxtEmployerAdd3.FieldMaxLength = 0
        Me.TxtEmployerAdd3.FieldName = Nothing
        Me.TxtEmployerAdd3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployerAdd3.isCalculatedField = False
        Me.TxtEmployerAdd3.IsSourceFromTable = False
        Me.TxtEmployerAdd3.IsSourceFromValueList = False
        Me.TxtEmployerAdd3.IsUnique = False
        Me.TxtEmployerAdd3.Location = New System.Drawing.Point(155, 98)
        Me.TxtEmployerAdd3.MaxLength = 50
        Me.TxtEmployerAdd3.MendatroryField = False
        Me.TxtEmployerAdd3.MyLinkLable1 = Me.MyLabel6
        Me.TxtEmployerAdd3.MyLinkLable2 = Nothing
        Me.TxtEmployerAdd3.Name = "TxtEmployerAdd3"
        Me.TxtEmployerAdd3.ReferenceFieldDesc = Nothing
        Me.TxtEmployerAdd3.ReferenceFieldName = Nothing
        Me.TxtEmployerAdd3.ReferenceTableName = Nothing
        Me.TxtEmployerAdd3.Size = New System.Drawing.Size(292, 18)
        Me.TxtEmployerAdd3.TabIndex = 65
        '
        'MyLabel6
        '
        Me.MyLabel6.FieldName = Nothing
        Me.MyLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel6.Location = New System.Drawing.Point(2, 57)
        Me.MyLabel6.Name = "MyLabel6"
        Me.MyLabel6.Size = New System.Drawing.Size(99, 16)
        Me.MyLabel6.TabIndex = 68
        Me.MyLabel6.Text = "Employer Address"
        '
        'TxtEmployerAdd2
        '
        Me.TxtEmployerAdd2.CalculationExpression = Nothing
        Me.TxtEmployerAdd2.FieldCode = Nothing
        Me.TxtEmployerAdd2.FieldDesc = Nothing
        Me.TxtEmployerAdd2.FieldMaxLength = 0
        Me.TxtEmployerAdd2.FieldName = Nothing
        Me.TxtEmployerAdd2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployerAdd2.isCalculatedField = False
        Me.TxtEmployerAdd2.IsSourceFromTable = False
        Me.TxtEmployerAdd2.IsSourceFromValueList = False
        Me.TxtEmployerAdd2.IsUnique = False
        Me.TxtEmployerAdd2.Location = New System.Drawing.Point(155, 77)
        Me.TxtEmployerAdd2.MaxLength = 50
        Me.TxtEmployerAdd2.MendatroryField = False
        Me.TxtEmployerAdd2.MyLinkLable1 = Me.MyLabel6
        Me.TxtEmployerAdd2.MyLinkLable2 = Nothing
        Me.TxtEmployerAdd2.Name = "TxtEmployerAdd2"
        Me.TxtEmployerAdd2.ReferenceFieldDesc = Nothing
        Me.TxtEmployerAdd2.ReferenceFieldName = Nothing
        Me.TxtEmployerAdd2.ReferenceTableName = Nothing
        Me.TxtEmployerAdd2.Size = New System.Drawing.Size(292, 18)
        Me.TxtEmployerAdd2.TabIndex = 64
        '
        'TxtEmployerAdd1
        '
        Me.TxtEmployerAdd1.CalculationExpression = Nothing
        Me.TxtEmployerAdd1.FieldCode = Nothing
        Me.TxtEmployerAdd1.FieldDesc = Nothing
        Me.TxtEmployerAdd1.FieldMaxLength = 0
        Me.TxtEmployerAdd1.FieldName = Nothing
        Me.TxtEmployerAdd1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployerAdd1.isCalculatedField = False
        Me.TxtEmployerAdd1.IsSourceFromTable = False
        Me.TxtEmployerAdd1.IsSourceFromValueList = False
        Me.TxtEmployerAdd1.IsUnique = False
        Me.TxtEmployerAdd1.Location = New System.Drawing.Point(155, 56)
        Me.TxtEmployerAdd1.MaxLength = 50
        Me.TxtEmployerAdd1.MendatroryField = False
        Me.TxtEmployerAdd1.MyLinkLable1 = Me.MyLabel6
        Me.TxtEmployerAdd1.MyLinkLable2 = Nothing
        Me.TxtEmployerAdd1.Name = "TxtEmployerAdd1"
        Me.TxtEmployerAdd1.ReferenceFieldDesc = Nothing
        Me.TxtEmployerAdd1.ReferenceFieldName = Nothing
        Me.TxtEmployerAdd1.ReferenceTableName = Nothing
        Me.TxtEmployerAdd1.Size = New System.Drawing.Size(292, 18)
        Me.TxtEmployerAdd1.TabIndex = 63
        '
        'TxtEmployerName
        '
        Me.TxtEmployerName.CalculationExpression = Nothing
        Me.TxtEmployerName.FieldCode = Nothing
        Me.TxtEmployerName.FieldDesc = Nothing
        Me.TxtEmployerName.FieldMaxLength = 0
        Me.TxtEmployerName.FieldName = Nothing
        Me.TxtEmployerName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployerName.isCalculatedField = False
        Me.TxtEmployerName.IsSourceFromTable = False
        Me.TxtEmployerName.IsSourceFromValueList = False
        Me.TxtEmployerName.IsUnique = False
        Me.TxtEmployerName.Location = New System.Drawing.Point(155, 14)
        Me.TxtEmployerName.MaxLength = 50
        Me.TxtEmployerName.MendatroryField = False
        Me.TxtEmployerName.MyLinkLable1 = Me.MyLabel7
        Me.TxtEmployerName.MyLinkLable2 = Nothing
        Me.TxtEmployerName.Name = "TxtEmployerName"
        Me.TxtEmployerName.ReferenceFieldDesc = Nothing
        Me.TxtEmployerName.ReferenceFieldName = Nothing
        Me.TxtEmployerName.ReferenceTableName = Nothing
        Me.TxtEmployerName.Size = New System.Drawing.Size(292, 18)
        Me.TxtEmployerName.TabIndex = 62
        '
        'MyLabel7
        '
        Me.MyLabel7.FieldName = Nothing
        Me.MyLabel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel7.Location = New System.Drawing.Point(2, 15)
        Me.MyLabel7.Name = "MyLabel7"
        Me.MyLabel7.Size = New System.Drawing.Size(87, 16)
        Me.MyLabel7.TabIndex = 69
        Me.MyLabel7.Text = "Employer Name"
        '
        'RadPageViewPage5
        '
        Me.RadPageViewPage5.Controls.Add(Me.RadGroupBox2)
        Me.RadPageViewPage5.Enabled = False
        Me.RadPageViewPage5.ItemSize = New System.Drawing.SizeF(36.0!, 28.0!)
        Me.RadPageViewPage5.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage5.Name = "RadPageViewPage5"
        Me.RadPageViewPage5.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage5.Text = "GST"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.TxtGstInNo)
        Me.RadGroupBox2.Controls.Add(Me.MyLabel14)
        Me.RadGroupBox2.Controls.Add(Me.TxtGstReg)
        Me.RadGroupBox2.Controls.Add(Me.MyLabel13)
        Me.RadGroupBox2.HeaderText = "GST"
        Me.RadGroupBox2.Location = New System.Drawing.Point(21, 14)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(457, 100)
        Me.RadGroupBox2.TabIndex = 0
        Me.RadGroupBox2.Text = "GST"
        '
        'TxtGstInNo
        '
        Me.TxtGstInNo.CalculationExpression = Nothing
        Me.TxtGstInNo.FieldCode = Nothing
        Me.TxtGstInNo.FieldDesc = Nothing
        Me.TxtGstInNo.FieldMaxLength = 0
        Me.TxtGstInNo.FieldName = Nothing
        Me.TxtGstInNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGstInNo.isCalculatedField = False
        Me.TxtGstInNo.IsSourceFromTable = False
        Me.TxtGstInNo.IsSourceFromValueList = False
        Me.TxtGstInNo.IsUnique = False
        Me.TxtGstInNo.Location = New System.Drawing.Point(126, 48)
        Me.TxtGstInNo.MaxLength = 50
        Me.TxtGstInNo.MendatroryField = False
        Me.TxtGstInNo.MyLinkLable1 = Me.MyLabel14
        Me.TxtGstInNo.MyLinkLable2 = Nothing
        Me.TxtGstInNo.Name = "TxtGstInNo"
        Me.TxtGstInNo.ReferenceFieldDesc = Nothing
        Me.TxtGstInNo.ReferenceFieldName = Nothing
        Me.TxtGstInNo.ReferenceTableName = Nothing
        Me.TxtGstInNo.Size = New System.Drawing.Size(292, 18)
        Me.TxtGstInNo.TabIndex = 62
        Me.TxtGstInNo.Visible = False
        '
        'MyLabel14
        '
        Me.MyLabel14.FieldName = Nothing
        Me.MyLabel14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel14.Location = New System.Drawing.Point(6, 50)
        Me.MyLabel14.Name = "MyLabel14"
        Me.MyLabel14.Size = New System.Drawing.Size(62, 16)
        Me.MyLabel14.TabIndex = 63
        Me.MyLabel14.Text = "GSTIN No."
        Me.MyLabel14.Visible = False
        '
        'TxtGstReg
        '
        Me.TxtGstReg.CalculationExpression = Nothing
        Me.TxtGstReg.FieldCode = Nothing
        Me.TxtGstReg.FieldDesc = Nothing
        Me.TxtGstReg.FieldMaxLength = 0
        Me.TxtGstReg.FieldName = Nothing
        Me.TxtGstReg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGstReg.isCalculatedField = False
        Me.TxtGstReg.IsSourceFromTable = False
        Me.TxtGstReg.IsSourceFromValueList = False
        Me.TxtGstReg.IsUnique = False
        Me.TxtGstReg.Location = New System.Drawing.Point(125, 24)
        Me.TxtGstReg.MaxLength = 50
        Me.TxtGstReg.MendatroryField = False
        Me.TxtGstReg.MyLinkLable1 = Me.MyLabel13
        Me.TxtGstReg.MyLinkLable2 = Nothing
        Me.TxtGstReg.Name = "TxtGstReg"
        Me.TxtGstReg.ReferenceFieldDesc = Nothing
        Me.TxtGstReg.ReferenceFieldName = Nothing
        Me.TxtGstReg.ReferenceTableName = Nothing
        Me.TxtGstReg.Size = New System.Drawing.Size(292, 18)
        Me.TxtGstReg.TabIndex = 60
        '
        'MyLabel13
        '
        Me.MyLabel13.FieldName = Nothing
        Me.MyLabel13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel13.Location = New System.Drawing.Point(5, 26)
        Me.MyLabel13.Name = "MyLabel13"
        Me.MyLabel13.Size = New System.Drawing.Size(111, 16)
        Me.MyLabel13.TabIndex = 61
        Me.MyLabel13.Text = "GST Registration No"
        '
        'RadPageViewPage6
        '
        Me.RadPageViewPage6.Controls.Add(Me.RadGroupBox3)
        Me.RadPageViewPage6.ItemSize = New System.Drawing.SizeF(77.0!, 28.0!)
        Me.RadPageViewPage6.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage6.Name = "RadPageViewPage6"
        Me.RadPageViewPage6.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage6.Text = "Bank Details"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Controls.Add(Me.txtbranchAddress)
        Me.RadGroupBox3.Controls.Add(Me.MyLabel17)
        Me.RadGroupBox3.Controls.Add(Me.txtifsccode)
        Me.RadGroupBox3.Controls.Add(Me.MyLabel18)
        Me.RadGroupBox3.Controls.Add(Me.TxtBankAccountNo)
        Me.RadGroupBox3.Controls.Add(Me.MyLabel15)
        Me.RadGroupBox3.Controls.Add(Me.txtBankName)
        Me.RadGroupBox3.Controls.Add(Me.MyLabel16)
        Me.RadGroupBox3.HeaderText = "Bank Details"
        Me.RadGroupBox3.Location = New System.Drawing.Point(19, 16)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(768, 122)
        Me.RadGroupBox3.TabIndex = 1
        Me.RadGroupBox3.Text = "Bank Details"
        '
        'txtbranchAddress
        '
        Me.txtbranchAddress.CalculationExpression = Nothing
        Me.txtbranchAddress.FieldCode = Nothing
        Me.txtbranchAddress.FieldDesc = Nothing
        Me.txtbranchAddress.FieldMaxLength = 0
        Me.txtbranchAddress.FieldName = Nothing
        Me.txtbranchAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbranchAddress.isCalculatedField = False
        Me.txtbranchAddress.IsSourceFromTable = False
        Me.txtbranchAddress.IsSourceFromValueList = False
        Me.txtbranchAddress.IsUnique = False
        Me.txtbranchAddress.Location = New System.Drawing.Point(127, 95)
        Me.txtbranchAddress.MaxLength = 50
        Me.txtbranchAddress.MendatroryField = False
        Me.txtbranchAddress.MyLinkLable1 = Me.MyLabel17
        Me.txtbranchAddress.MyLinkLable2 = Nothing
        Me.txtbranchAddress.Name = "txtbranchAddress"
        Me.txtbranchAddress.ReferenceFieldDesc = Nothing
        Me.txtbranchAddress.ReferenceFieldName = Nothing
        Me.txtbranchAddress.ReferenceTableName = Nothing
        Me.txtbranchAddress.Size = New System.Drawing.Size(618, 18)
        Me.txtbranchAddress.TabIndex = 66
        '
        'MyLabel17
        '
        Me.MyLabel17.FieldName = Nothing
        Me.MyLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel17.Location = New System.Drawing.Point(7, 97)
        Me.MyLabel17.Name = "MyLabel17"
        Me.MyLabel17.Size = New System.Drawing.Size(87, 16)
        Me.MyLabel17.TabIndex = 67
        Me.MyLabel17.Text = "Branch Address"
        '
        'txtifsccode
        '
        Me.txtifsccode.CalculationExpression = Nothing
        Me.txtifsccode.FieldCode = Nothing
        Me.txtifsccode.FieldDesc = Nothing
        Me.txtifsccode.FieldMaxLength = 0
        Me.txtifsccode.FieldName = Nothing
        Me.txtifsccode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtifsccode.isCalculatedField = False
        Me.txtifsccode.IsSourceFromTable = False
        Me.txtifsccode.IsSourceFromValueList = False
        Me.txtifsccode.IsUnique = False
        Me.txtifsccode.Location = New System.Drawing.Point(127, 71)
        Me.txtifsccode.MaxLength = 50
        Me.txtifsccode.MendatroryField = False
        Me.txtifsccode.MyLinkLable1 = Me.MyLabel18
        Me.txtifsccode.MyLinkLable2 = Nothing
        Me.txtifsccode.Name = "txtifsccode"
        Me.txtifsccode.ReferenceFieldDesc = Nothing
        Me.txtifsccode.ReferenceFieldName = Nothing
        Me.txtifsccode.ReferenceTableName = Nothing
        Me.txtifsccode.Size = New System.Drawing.Size(406, 18)
        Me.txtifsccode.TabIndex = 64
        '
        'MyLabel18
        '
        Me.MyLabel18.FieldName = Nothing
        Me.MyLabel18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel18.Location = New System.Drawing.Point(7, 73)
        Me.MyLabel18.Name = "MyLabel18"
        Me.MyLabel18.Size = New System.Drawing.Size(62, 16)
        Me.MyLabel18.TabIndex = 65
        Me.MyLabel18.Text = "IFSC Code"
        '
        'TxtBankAccountNo
        '
        Me.TxtBankAccountNo.CalculationExpression = Nothing
        Me.TxtBankAccountNo.FieldCode = Nothing
        Me.TxtBankAccountNo.FieldDesc = Nothing
        Me.TxtBankAccountNo.FieldMaxLength = 0
        Me.TxtBankAccountNo.FieldName = Nothing
        Me.TxtBankAccountNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankAccountNo.isCalculatedField = False
        Me.TxtBankAccountNo.IsSourceFromTable = False
        Me.TxtBankAccountNo.IsSourceFromValueList = False
        Me.TxtBankAccountNo.IsUnique = False
        Me.TxtBankAccountNo.Location = New System.Drawing.Point(127, 48)
        Me.TxtBankAccountNo.MaxLength = 50
        Me.TxtBankAccountNo.MendatroryField = False
        Me.TxtBankAccountNo.MyLinkLable1 = Me.MyLabel15
        Me.TxtBankAccountNo.MyLinkLable2 = Nothing
        Me.TxtBankAccountNo.Name = "TxtBankAccountNo"
        Me.TxtBankAccountNo.ReferenceFieldDesc = Nothing
        Me.TxtBankAccountNo.ReferenceFieldName = Nothing
        Me.TxtBankAccountNo.ReferenceTableName = Nothing
        Me.TxtBankAccountNo.Size = New System.Drawing.Size(406, 18)
        Me.TxtBankAccountNo.TabIndex = 62
        '
        'MyLabel15
        '
        Me.MyLabel15.FieldName = Nothing
        Me.MyLabel15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel15.Location = New System.Drawing.Point(7, 50)
        Me.MyLabel15.Name = "MyLabel15"
        Me.MyLabel15.Size = New System.Drawing.Size(97, 16)
        Me.MyLabel15.TabIndex = 63
        Me.MyLabel15.Text = "Bank Account No."
        '
        'txtBankName
        '
        Me.txtBankName.CalculationExpression = Nothing
        Me.txtBankName.FieldCode = Nothing
        Me.txtBankName.FieldDesc = Nothing
        Me.txtBankName.FieldMaxLength = 0
        Me.txtBankName.FieldName = Nothing
        Me.txtBankName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankName.isCalculatedField = False
        Me.txtBankName.IsSourceFromTable = False
        Me.txtBankName.IsSourceFromValueList = False
        Me.txtBankName.IsUnique = False
        Me.txtBankName.Location = New System.Drawing.Point(127, 24)
        Me.txtBankName.MaxLength = 50
        Me.txtBankName.MendatroryField = False
        Me.txtBankName.MyLinkLable1 = Me.MyLabel16
        Me.txtBankName.MyLinkLable2 = Nothing
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.ReferenceFieldDesc = Nothing
        Me.txtBankName.ReferenceFieldName = Nothing
        Me.txtBankName.ReferenceTableName = Nothing
        Me.txtBankName.Size = New System.Drawing.Size(406, 18)
        Me.txtBankName.TabIndex = 60
        '
        'MyLabel16
        '
        Me.MyLabel16.FieldName = Nothing
        Me.MyLabel16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel16.Location = New System.Drawing.Point(7, 26)
        Me.MyLabel16.Name = "MyLabel16"
        Me.MyLabel16.Size = New System.Drawing.Size(65, 16)
        Me.MyLabel16.TabIndex = 61
        Me.MyLabel16.Text = "Bank Name"
        '
        'RadPageViewPage7
        '
        Me.RadPageViewPage7.Controls.Add(Me.btnBGClear)
        Me.RadPageViewPage7.Controls.Add(Me.BGImage)
        Me.RadPageViewPage7.Controls.Add(Me.btnBackgroundselect)
        Me.RadPageViewPage7.ItemSize = New System.Drawing.SizeF(76.0!, 28.0!)
        Me.RadPageViewPage7.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage7.Name = "RadPageViewPage7"
        Me.RadPageViewPage7.Size = New System.Drawing.Size(807, 488)
        Me.RadPageViewPage7.Text = "Background"
        '
        'btnBGClear
        '
        Me.btnBGClear.Location = New System.Drawing.Point(158, 16)
        Me.btnBGClear.Name = "btnBGClear"
        Me.btnBGClear.Size = New System.Drawing.Size(130, 24)
        Me.btnBGClear.TabIndex = 4
        Me.btnBGClear.Text = "Clear Logo"
        '
        'BGImage
        '
        Me.BGImage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BGImage.Location = New System.Drawing.Point(0, 71)
        Me.BGImage.Name = "BGImage"
        Me.BGImage.Size = New System.Drawing.Size(807, 417)
        Me.BGImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.BGImage.TabIndex = 3
        Me.BGImage.TabStop = False
        '
        'btnBackgroundselect
        '
        Me.btnBackgroundselect.Location = New System.Drawing.Point(22, 16)
        Me.btnBackgroundselect.Name = "btnBackgroundselect"
        Me.btnBackgroundselect.Size = New System.Drawing.Size(130, 24)
        Me.btnBackgroundselect.TabIndex = 2
        Me.btnBackgroundselect.Text = "Select Logo"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 20)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadPageView1)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDelete)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer1.Size = New System.Drawing.Size(830, 567)
        Me.SplitContainer1.SplitterDistance = 538
        Me.SplitContainer1.TabIndex = 0
        '
        'FrmCompanyMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 587)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.RadMenu1)
        Me.Name = "FrmCompanyMaster"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Company Master"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.dtPanIssueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTinIssueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelephone2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelephone1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_main_company, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCompanyCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegdNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTcanNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTcanNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTanNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTanNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPanNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPanNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVatRegNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVatRegNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCstLst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCstLst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTinNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPinCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPinCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTinNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelephone2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelephone1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdd3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAdress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCompanyName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage2.ResumeLayout(False)
        CType(Me.btnClearLogo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectPath1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage3.ResumeLayout(False)
        CType(Me.btnClearLogo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectPath2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage4.ResumeLayout(False)
        Me.RadPageViewPage4.PerformLayout()
        CType(Me.TxtEmployerDesg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmployerAdd3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmployerAdd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmployerAdd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmployerName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage5.ResumeLayout(False)
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.TxtGstInNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtGstReg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage6.ResumeLayout(False)
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        Me.RadGroupBox3.PerformLayout()
        CType(Me.txtbranchAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtifsccode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBankAccountNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBankName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage7.ResumeLayout(False)
        CType(Me.btnBGClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBackgroundselect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtCompanyName As common.Controls.MyTextBox
    Friend WithEvents txtCity As common.Controls.MyTextBox
    Friend WithEvents txtAdd3 As common.Controls.MyTextBox
    Friend WithEvents txtAdd2 As common.Controls.MyTextBox
    Friend WithEvents txtAdd1 As common.Controls.MyTextBox
    Friend WithEvents txtEmail As common.Controls.MyTextBox
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadMenuItem1 As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuImport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuExport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents menuClose As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFax As common.Controls.MyTextBox
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents txtCstLst As common.Controls.MyTextBox
    Friend WithEvents txtTinNo As common.Controls.MyTextBox
    Friend WithEvents txtPinCode As common.Controls.MyTextBox
    Friend WithEvents txtRegdNo As common.Controls.MyTextBox
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage3 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectPath1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectPath2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClearLogo1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClearLogo2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtVatRegNo As common.Controls.MyTextBox
    Friend WithEvents txtPanNo As common.Controls.MyTextBox
    Friend WithEvents txtTcanNo As common.Controls.MyTextBox
    Friend WithEvents txtTanNo As common.Controls.MyTextBox
    Friend WithEvents lblCompanyName As common.Controls.MyLabel
    Friend WithEvents lblCompanyCode As common.Controls.MyLabel
    Friend WithEvents lblTelephone2 As common.Controls.MyLabel
    Friend WithEvents lblTelephone1 As common.Controls.MyLabel
    Friend WithEvents lblCity As common.Controls.MyLabel
    Friend WithEvents lblAdress As common.Controls.MyLabel
    Friend WithEvents lblEmail As common.Controls.MyLabel
    Friend WithEvents lblTax As common.Controls.MyLabel
    Friend WithEvents lblTinNo As common.Controls.MyLabel
    Friend WithEvents lblCstLst As common.Controls.MyLabel
    Friend WithEvents lblState As common.Controls.MyLabel
    Friend WithEvents lblPinCode As common.Controls.MyLabel
    Friend WithEvents txtRegNo As common.Controls.MyLabel
    Friend WithEvents lblVatRegNo As common.Controls.MyLabel
    Friend WithEvents lblPanNo As common.Controls.MyLabel
    Friend WithEvents lblTcanNo As common.Controls.MyLabel
    Friend WithEvents lblTanNo As common.Controls.MyLabel
    Friend WithEvents fndCompanyCode As common.UserControls.txtNavigator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtState As common.UserControls.txtFinder
    Friend WithEvents chk_main_company As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents txtTelephone2 As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtTelephone1 As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents RadPageViewPage4 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents TxtEmployerDesg As common.Controls.MyTextBox
    Friend WithEvents MyLabel5 As common.Controls.MyLabel
    Friend WithEvents TxtEmployerAdd3 As common.Controls.MyTextBox
    Friend WithEvents MyLabel6 As common.Controls.MyLabel
    Friend WithEvents TxtEmployerAdd2 As common.Controls.MyTextBox
    Friend WithEvents TxtEmployerAdd1 As common.Controls.MyTextBox
    Friend WithEvents TxtEmployerName As common.Controls.MyTextBox
    Friend WithEvents MyLabel7 As common.Controls.MyLabel
    Friend WithEvents MyLabel11 As common.Controls.MyLabel
    Friend WithEvents dtTinIssueDate As common.Controls.MyDateTimePicker
    Friend WithEvents dtPanIssueDate As common.Controls.MyDateTimePicker
    Friend WithEvents MyLabel12 As common.Controls.MyLabel
    Friend WithEvents RadPageViewPage5 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents TxtGstInNo As common.Controls.MyTextBox
    Friend WithEvents MyLabel14 As common.Controls.MyLabel
    Friend WithEvents TxtGstReg As common.Controls.MyTextBox
    Friend WithEvents MyLabel13 As common.Controls.MyLabel
    Friend WithEvents RadPageViewPage6 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtbranchAddress As common.Controls.MyTextBox
    Friend WithEvents MyLabel17 As common.Controls.MyLabel
    Friend WithEvents txtifsccode As common.Controls.MyTextBox
    Friend WithEvents MyLabel18 As common.Controls.MyLabel
    Friend WithEvents TxtBankAccountNo As common.Controls.MyTextBox
    Friend WithEvents MyLabel15 As common.Controls.MyLabel
    Friend WithEvents txtBankName As common.Controls.MyTextBox
    Friend WithEvents MyLabel16 As common.Controls.MyLabel
    Friend WithEvents RadPageViewPage7 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents btnBGClear As Telerik.WinControls.UI.RadButton
    Friend WithEvents BGImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnBackgroundselect As Telerik.WinControls.UI.RadButton
End Class

