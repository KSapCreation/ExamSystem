<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRuestCreationEntry
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
        Me.lblApprovalStatus = New common.Controls.MyLabel()
        Me.lblApprovalStatusName = New common.Controls.MyLabel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtRequestDescription = New common.Controls.MyTextBox()
        Me.lblCreatedBy = New common.Controls.MyLabel()
        Me.txtCreatedBy = New common.UserControls.txtFinder()
        Me.RadLabel2 = New common.Controls.MyLabel()
        Me.MyLabel5 = New common.Controls.MyLabel()
        Me.lblClient = New common.Controls.MyLabel()
        Me.txtClient = New common.UserControls.txtFinder()
        Me.cboRequestStatus = New common.Controls.MyComboBox()
        Me.MyLabel3 = New common.Controls.MyLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRequestDate = New common.Controls.MyDateTimePicker()
        Me.txtRequestNo = New common.UserControls.txtNavigator()
        Me.btnreset1 = New Telerik.WinControls.UI.RadButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.UcAttachment1 = New TeamMgmt.ucAttachment()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        CType(Me.lblApprovalStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblApprovalStatusName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.txtRequestDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCreatedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRequestStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRequestDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage2.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(721, 522)
        Me.SplitContainer1.SplitterDistance = 493
        Me.SplitContainer1.TabIndex = 0
        '
        'RadPageView1
        '
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView1.Location = New System.Drawing.Point(0, 0)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.RadPageViewPage2
        Me.RadPageView1.Size = New System.Drawing.Size(721, 493)
        Me.RadPageView1.TabIndex = 1
        Me.RadPageView1.Text = "RadPageView1"
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.lblApprovalStatus)
        Me.RadPageViewPage1.Controls.Add(Me.lblApprovalStatusName)
        Me.RadPageViewPage1.Controls.Add(Me.RadGroupBox1)
        Me.RadPageViewPage1.Controls.Add(Me.lblCreatedBy)
        Me.RadPageViewPage1.Controls.Add(Me.txtCreatedBy)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel5)
        Me.RadPageViewPage1.Controls.Add(Me.lblClient)
        Me.RadPageViewPage1.Controls.Add(Me.RadLabel2)
        Me.RadPageViewPage1.Controls.Add(Me.txtClient)
        Me.RadPageViewPage1.Controls.Add(Me.cboRequestStatus)
        Me.RadPageViewPage1.Controls.Add(Me.MyLabel3)
        Me.RadPageViewPage1.Controls.Add(Me.Label3)
        Me.RadPageViewPage1.Controls.Add(Me.txtRequestDate)
        Me.RadPageViewPage1.Controls.Add(Me.txtRequestNo)
        Me.RadPageViewPage1.Controls.Add(Me.btnreset1)
        Me.RadPageViewPage1.Controls.Add(Me.Label1)
        Me.RadPageViewPage1.ItemSize = New System.Drawing.SizeF(103.0!, 28.0!)
        Me.RadPageViewPage1.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(700, 445)
        Me.RadPageViewPage1.Text = "Basic Information"
        '
        'lblApprovalStatus
        '
        Me.lblApprovalStatus.AutoSize = False
        Me.lblApprovalStatus.BorderVisible = True
        Me.lblApprovalStatus.FieldName = Nothing
        Me.lblApprovalStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovalStatus.Location = New System.Drawing.Point(101, 72)
        Me.lblApprovalStatus.Name = "lblApprovalStatus"
        Me.lblApprovalStatus.Size = New System.Drawing.Size(271, 18)
        Me.lblApprovalStatus.TabIndex = 205
        Me.lblApprovalStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblApprovalStatus.TextWrap = False
        '
        'lblApprovalStatusName
        '
        Me.lblApprovalStatusName.FieldName = Nothing
        Me.lblApprovalStatusName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovalStatusName.Location = New System.Drawing.Point(3, 72)
        Me.lblApprovalStatusName.Name = "lblApprovalStatusName"
        Me.lblApprovalStatusName.Size = New System.Drawing.Size(92, 16)
        Me.lblApprovalStatusName.TabIndex = 204
        Me.lblApprovalStatusName.Text = "Approval Status :"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.txtRequestDescription)
        Me.RadGroupBox1.HeaderText = "Request Description"
        Me.RadGroupBox1.Location = New System.Drawing.Point(3, 94)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(694, 351)
        Me.RadGroupBox1.TabIndex = 103
        Me.RadGroupBox1.Text = "Request Description"
        '
        'txtRequestDescription
        '
        Me.txtRequestDescription.AcceptsReturn = True
        Me.txtRequestDescription.AutoSize = False
        Me.txtRequestDescription.CalculationExpression = Nothing
        Me.txtRequestDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRequestDescription.FieldCode = Nothing
        Me.txtRequestDescription.FieldDesc = Nothing
        Me.txtRequestDescription.FieldMaxLength = 0
        Me.txtRequestDescription.FieldName = Nothing
        Me.txtRequestDescription.isCalculatedField = False
        Me.txtRequestDescription.IsSourceFromTable = False
        Me.txtRequestDescription.IsSourceFromValueList = False
        Me.txtRequestDescription.IsUnique = False
        Me.txtRequestDescription.Location = New System.Drawing.Point(2, 18)
        Me.txtRequestDescription.MaxLength = 5000
        Me.txtRequestDescription.MendatroryField = True
        Me.txtRequestDescription.Multiline = True
        Me.txtRequestDescription.MyLinkLable1 = Nothing
        Me.txtRequestDescription.MyLinkLable2 = Nothing
        Me.txtRequestDescription.Name = "txtRequestDescription"
        Me.txtRequestDescription.ReferenceFieldDesc = Nothing
        Me.txtRequestDescription.ReferenceFieldName = Nothing
        Me.txtRequestDescription.ReferenceTableName = Nothing
        Me.txtRequestDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRequestDescription.Size = New System.Drawing.Size(690, 331)
        Me.txtRequestDescription.TabIndex = 102
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = False
        Me.lblCreatedBy.BorderVisible = True
        Me.lblCreatedBy.FieldName = Nothing
        Me.lblCreatedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedBy.Location = New System.Drawing.Point(384, 51)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(311, 18)
        Me.lblCreatedBy.TabIndex = 100
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
        Me.txtCreatedBy.Location = New System.Drawing.Point(102, 51)
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
        Me.txtCreatedBy.Size = New System.Drawing.Size(270, 18)
        Me.txtCreatedBy.TabIndex = 99
        Me.txtCreatedBy.Value = ""
        '
        'RadLabel2
        '
        Me.RadLabel2.FieldName = Nothing
        Me.RadLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(3, 32)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(38, 16)
        Me.RadLabel2.TabIndex = 96
        Me.RadLabel2.Text = "Client "
        '
        'MyLabel5
        '
        Me.MyLabel5.FieldName = Nothing
        Me.MyLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel5.Location = New System.Drawing.Point(3, 54)
        Me.MyLabel5.Name = "MyLabel5"
        Me.MyLabel5.Size = New System.Drawing.Size(63, 16)
        Me.MyLabel5.TabIndex = 98
        Me.MyLabel5.Text = "Created By"
        '
        'lblClient
        '
        Me.lblClient.AutoSize = False
        Me.lblClient.BorderVisible = True
        Me.lblClient.FieldName = Nothing
        Me.lblClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(384, 31)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(311, 18)
        Me.lblClient.TabIndex = 97
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
        Me.txtClient.Location = New System.Drawing.Point(102, 31)
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
        Me.txtClient.Size = New System.Drawing.Size(270, 18)
        Me.txtClient.TabIndex = 95
        Me.txtClient.Value = ""
        '
        'cboRequestStatus
        '
        Me.cboRequestStatus.AutoCompleteDisplayMember = Nothing
        Me.cboRequestStatus.AutoCompleteValueMember = Nothing
        Me.cboRequestStatus.CalculationExpression = Nothing
        Me.cboRequestStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboRequestStatus.FieldCode = Nothing
        Me.cboRequestStatus.FieldDesc = Nothing
        Me.cboRequestStatus.FieldMaxLength = 0
        Me.cboRequestStatus.FieldName = Nothing
        Me.cboRequestStatus.isCalculatedField = False
        Me.cboRequestStatus.IsSourceFromTable = False
        Me.cboRequestStatus.IsSourceFromValueList = False
        Me.cboRequestStatus.IsUnique = False
        Me.cboRequestStatus.Location = New System.Drawing.Point(597, 10)
        Me.cboRequestStatus.MendatroryField = True
        Me.cboRequestStatus.MyLinkLable1 = Nothing
        Me.cboRequestStatus.MyLinkLable2 = Nothing
        Me.cboRequestStatus.Name = "cboRequestStatus"
        Me.cboRequestStatus.ReferenceFieldDesc = Nothing
        Me.cboRequestStatus.ReferenceFieldName = Nothing
        Me.cboRequestStatus.ReferenceTableName = Nothing
        Me.cboRequestStatus.Size = New System.Drawing.Size(99, 20)
        Me.cboRequestStatus.TabIndex = 94
        '
        'MyLabel3
        '
        Me.MyLabel3.FieldName = Nothing
        Me.MyLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel3.Location = New System.Drawing.Point(507, 11)
        Me.MyLabel3.Name = "MyLabel3"
        Me.MyLabel3.Size = New System.Drawing.Size(84, 16)
        Me.MyLabel3.TabIndex = 93
        Me.MyLabel3.Text = "Request Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(381, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Date"
        '
        'txtRequestDate
        '
        Me.txtRequestDate.CalculationExpression = Nothing
        Me.txtRequestDate.CustomFormat = "dd/MM/yyyy"
        Me.txtRequestDate.FieldCode = Nothing
        Me.txtRequestDate.FieldDesc = Nothing
        Me.txtRequestDate.FieldMaxLength = 0
        Me.txtRequestDate.FieldName = Nothing
        Me.txtRequestDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtRequestDate.isCalculatedField = False
        Me.txtRequestDate.IsSourceFromTable = False
        Me.txtRequestDate.IsSourceFromValueList = False
        Me.txtRequestDate.IsUnique = False
        Me.txtRequestDate.Location = New System.Drawing.Point(418, 8)
        Me.txtRequestDate.MendatroryField = False
        Me.txtRequestDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtRequestDate.MyLinkLable1 = Nothing
        Me.txtRequestDate.MyLinkLable2 = Nothing
        Me.txtRequestDate.Name = "txtRequestDate"
        Me.txtRequestDate.NullDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtRequestDate.ReferenceFieldDesc = Nothing
        Me.txtRequestDate.ReferenceFieldName = Nothing
        Me.txtRequestDate.ReferenceTableName = Nothing
        Me.txtRequestDate.Size = New System.Drawing.Size(83, 18)
        Me.txtRequestDate.TabIndex = 40
        Me.txtRequestDate.TabStop = False
        Me.txtRequestDate.Text = "13/06/2011"
        Me.txtRequestDate.Value = New Date(2011, 6, 13, 11, 29, 49, 421)
        '
        'txtRequestNo
        '
        Me.txtRequestNo.FieldName = Nothing
        Me.txtRequestNo.Location = New System.Drawing.Point(101, 6)
        Me.txtRequestNo.MendatroryField = True
        Me.txtRequestNo.MyCharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRequestNo.MyFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtRequestNo.MyLinkLable1 = Nothing
        Me.txtRequestNo.MyLinkLable2 = Nothing
        Me.txtRequestNo.MyMaxLength = 32767
        Me.txtRequestNo.MyReadOnly = False
        Me.txtRequestNo.Name = "txtRequestNo"
        Me.txtRequestNo.Size = New System.Drawing.Size(249, 21)
        Me.txtRequestNo.TabIndex = 38
        Me.txtRequestNo.Value = ""
        '
        'btnreset1
        '
        Me.btnreset1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnreset1.Location = New System.Drawing.Point(350, 6)
        Me.btnreset1.Name = "btnreset1"
        Me.btnreset1.Size = New System.Drawing.Size(22, 21)
        Me.btnreset1.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Request No"
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.UcAttachment1)
        Me.RadPageViewPage2.ItemSize = New System.Drawing.SizeF(79.0!, 28.0!)
        Me.RadPageViewPage2.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(700, 445)
        Me.RadPageViewPage2.Text = "Attachments"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(638, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 18)
        Me.btnClose.TabIndex = 30
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(89, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 18)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(3, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 18)
        Me.btnSave.TabIndex = 28
        Me.btnSave.Text = "Save"
        '
        'UcAttachment1
        '
        Me.UcAttachment1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcAttachment1.Location = New System.Drawing.Point(0, 0)
        Me.UcAttachment1.Name = "UcAttachment1"
        Me.UcAttachment1.Size = New System.Drawing.Size(700, 445)
        Me.UcAttachment1.TabIndex = 0
        '
        'FrmRuestCreationEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 522)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmRuestCreationEntry"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Request Creation Entry"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage1.PerformLayout()
        CType(Me.lblApprovalStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblApprovalStatusName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me.txtRequestDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCreatedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRequestStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRequestDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage2.ResumeLayout(False)
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtRequestDescription As common.Controls.MyTextBox
    Friend WithEvents lblCreatedBy As common.Controls.MyLabel
    Friend WithEvents txtCreatedBy As common.UserControls.txtFinder
    Friend WithEvents RadLabel2 As common.Controls.MyLabel
    Friend WithEvents MyLabel5 As common.Controls.MyLabel
    Friend WithEvents lblClient As common.Controls.MyLabel
    Friend WithEvents txtClient As common.UserControls.txtFinder
    Friend WithEvents cboRequestStatus As common.Controls.MyComboBox
    Friend WithEvents MyLabel3 As common.Controls.MyLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRequestDate As common.Controls.MyDateTimePicker
    Friend WithEvents txtRequestNo As common.UserControls.txtNavigator
    Friend WithEvents btnreset1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblApprovalStatus As common.Controls.MyLabel
    Friend WithEvents lblApprovalStatusName As common.Controls.MyLabel
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents UcAttachment1 As TeamMgmt.ucAttachment
End Class

