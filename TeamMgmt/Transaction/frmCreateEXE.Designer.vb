<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateEXE
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboType = New common.Controls.MyComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGo = New Telerik.WinControls.UI.RadButton()
        Me.txtVersion = New common.Controls.MyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblClient = New common.Controls.MyLabel()
        Me.RadLabel2 = New common.Controls.MyLabel()
        Me.txtFromDate = New common.Controls.MyDateTimePicker()
        Me.txtClient = New common.UserControls.txtFinder()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNew = New Telerik.WinControls.UI.RadButton()
        Me.txtCode = New common.UserControls.txtNavigator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gv = New common.UserControls.MyRadGridView()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.SplitPanel3 = New Telerik.WinControls.UI.SplitPanel()
        Me.btnUnselect = New Telerik.WinControls.UI.RadButton()
        Me.btnSelectAll = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnReset = New Telerik.WinControls.UI.RadButton()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadSplitContainer1.SuspendLayout()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel1.SuspendLayout()
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel2.SuspendLayout()
        CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel3.SuspendLayout()
        CType(Me.btnUnselect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnReset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnGo)
        Me.GroupBox1.Controls.Add(Me.txtVersion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblClient)
        Me.GroupBox1.Controls.Add(Me.RadLabel2)
        Me.GroupBox1.Controls.Add(Me.txtFromDate)
        Me.GroupBox1.Controls.Add(Me.txtClient)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1228, 97)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create Version"
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
        Me.cboType.Location = New System.Drawing.Point(544, 22)
        Me.cboType.MendatroryField = True
        Me.cboType.MyLinkLable1 = Nothing
        Me.cboType.MyLinkLable2 = Nothing
        Me.cboType.Name = "cboType"
        Me.cboType.ReferenceFieldDesc = Nothing
        Me.cboType.ReferenceFieldName = Nothing
        Me.cboType.ReferenceTableName = Nothing
        Me.cboType.Size = New System.Drawing.Size(166, 20)
        Me.cboType.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(509, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Type"
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(354, 77)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(80, 18)
        Me.btnGo.TabIndex = 49
        Me.btnGo.Text = ">>>"
        '
        'txtVersion
        '
        Me.txtVersion.CalculationExpression = Nothing
        Me.txtVersion.FieldCode = Nothing
        Me.txtVersion.FieldDesc = Nothing
        Me.txtVersion.FieldMaxLength = 0
        Me.txtVersion.FieldName = Nothing
        Me.txtVersion.isCalculatedField = False
        Me.txtVersion.IsSourceFromTable = False
        Me.txtVersion.IsSourceFromValueList = False
        Me.txtVersion.IsUnique = False
        Me.txtVersion.Location = New System.Drawing.Point(100, 74)
        Me.txtVersion.MaxLength = 50
        Me.txtVersion.MendatroryField = True
        Me.txtVersion.MyLinkLable1 = Nothing
        Me.txtVersion.MyLinkLable2 = Nothing
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.ReferenceFieldDesc = Nothing
        Me.txtVersion.ReferenceFieldName = Nothing
        Me.txtVersion.ReferenceTableName = Nothing
        Me.txtVersion.Size = New System.Drawing.Size(248, 20)
        Me.txtVersion.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Version"
        '
        'lblClient
        '
        Me.lblClient.AutoSize = False
        Me.lblClient.BorderVisible = True
        Me.lblClient.FieldName = Nothing
        Me.lblClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(273, 50)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(264, 18)
        Me.lblClient.TabIndex = 46
        Me.lblClient.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClient.TextWrap = False
        '
        'RadLabel2
        '
        Me.RadLabel2.FieldName = Nothing
        Me.RadLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(23, 50)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(35, 16)
        Me.RadLabel2.TabIndex = 45
        Me.RadLabel2.Text = "Client"
        '
        'txtFromDate
        '
        Me.txtFromDate.CalculationExpression = Nothing
        Me.txtFromDate.CustomFormat = "dd/MM/yyyy"
        Me.txtFromDate.FieldCode = Nothing
        Me.txtFromDate.FieldDesc = Nothing
        Me.txtFromDate.FieldMaxLength = 0
        Me.txtFromDate.FieldName = Nothing
        Me.txtFromDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFromDate.isCalculatedField = False
        Me.txtFromDate.IsSourceFromTable = False
        Me.txtFromDate.IsSourceFromValueList = False
        Me.txtFromDate.IsUnique = False
        Me.txtFromDate.Location = New System.Drawing.Point(409, 22)
        Me.txtFromDate.MendatroryField = False
        Me.txtFromDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtFromDate.MyLinkLable1 = Nothing
        Me.txtFromDate.MyLinkLable2 = Nothing
        Me.txtFromDate.Name = "txtFromDate"
        Me.txtFromDate.NullDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtFromDate.ReferenceFieldDesc = Nothing
        Me.txtFromDate.ReferenceFieldName = Nothing
        Me.txtFromDate.ReferenceTableName = Nothing
        Me.txtFromDate.Size = New System.Drawing.Size(83, 18)
        Me.txtFromDate.TabIndex = 24
        Me.txtFromDate.TabStop = False
        Me.txtFromDate.Text = "13/06/2011"
        Me.txtFromDate.Value = New Date(2011, 6, 13, 11, 29, 49, 421)
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
        Me.txtClient.Location = New System.Drawing.Point(101, 49)
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
        Me.txtClient.TabIndex = 44
        Me.txtClient.Value = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(366, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Date"
        '
        'btnNew
        '
        Me.btnNew.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNew.Location = New System.Drawing.Point(328, 22)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(22, 20)
        Me.btnNew.TabIndex = 23
        Me.btnNew.Text = "N"
        '
        'txtCode
        '
        Me.txtCode.FieldName = Nothing
        Me.txtCode.Location = New System.Drawing.Point(102, 21)
        Me.txtCode.MendatroryField = True
        Me.txtCode.MyCharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.MyFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtCode.MyLinkLable1 = Nothing
        Me.txtCode.MyLinkLable2 = Nothing
        Me.txtCode.MyMaxLength = 32767
        Me.txtCode.MyReadOnly = False
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(224, 21)
        Me.txtCode.TabIndex = 21
        Me.txtCode.Value = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Code"
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
        Me.gv.Size = New System.Drawing.Size(1228, 395)
        Me.gv.TabIndex = 10
        Me.gv.Text = "RadGridView1"
        '
        'RadSplitContainer1
        '
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel1)
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel2)
        Me.RadSplitContainer1.Controls.Add(Me.SplitPanel3)
        Me.RadSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.RadSplitContainer1.Name = "RadSplitContainer1"
        Me.RadSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        '
        '
        Me.RadSplitContainer1.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.RadSplitContainer1.Size = New System.Drawing.Size(1228, 537)
        Me.RadSplitContainer1.TabIndex = 1
        Me.RadSplitContainer1.TabStop = False
        Me.RadSplitContainer1.Text = "RadSplitContainer1"
        '
        'SplitPanel1
        '
        Me.SplitPanel1.Controls.Add(Me.GroupBox1)
        Me.SplitPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel1.Name = "SplitPanel1"
        '
        '
        '
        Me.SplitPanel1.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.SplitPanel1.Size = New System.Drawing.Size(1228, 97)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.1499685!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -79)
        Me.SplitPanel1.TabIndex = 0
        Me.SplitPanel1.TabStop = False
        Me.SplitPanel1.Text = "SplitPanel1"
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.gv)
        Me.SplitPanel2.Location = New System.Drawing.Point(0, 101)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.SplitPanel2.Size = New System.Drawing.Size(1228, 395)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, 0.4133585!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, 219)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'SplitPanel3
        '
        Me.SplitPanel3.Controls.Add(Me.btnUnselect)
        Me.SplitPanel3.Controls.Add(Me.btnSelectAll)
        Me.SplitPanel3.Controls.Add(Me.btnDelete)
        Me.SplitPanel3.Controls.Add(Me.btnReset)
        Me.SplitPanel3.Controls.Add(Me.btnClose)
        Me.SplitPanel3.Controls.Add(Me.btnSave)
        Me.SplitPanel3.Location = New System.Drawing.Point(0, 500)
        Me.SplitPanel3.Name = "SplitPanel3"
        '
        '
        '
        Me.SplitPanel3.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.SplitPanel3.Size = New System.Drawing.Size(1228, 37)
        Me.SplitPanel3.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.2633901!)
        Me.SplitPanel3.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -140)
        Me.SplitPanel3.TabIndex = 2
        Me.SplitPanel3.TabStop = False
        Me.SplitPanel3.Text = "SplitPanel3"
        '
        'btnUnselect
        '
        Me.btnUnselect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUnselect.Location = New System.Drawing.Point(355, 11)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(80, 18)
        Me.btnUnselect.TabIndex = 10
        Me.btnUnselect.Text = "UnSelect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(269, 11)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(80, 18)
        Me.btnSelectAll.TabIndex = 10
        Me.btnSelectAll.Text = "Select All"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(183, 11)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 18)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(97, 11)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(80, 18)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "Reset"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1136, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 18)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(11, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 18)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        '
        'frmCreateEXE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 537)
        Me.Controls.Add(Me.RadSplitContainer1)
        Me.Name = "frmCreateEXE"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Create EXE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadSplitContainer1.ResumeLayout(False)
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel1.ResumeLayout(False)
        CType(Me.SplitPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel2.ResumeLayout(False)
        CType(Me.SplitPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel3.ResumeLayout(False)
        CType(Me.btnUnselect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnReset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gv As common.UserControls.MyRadGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCode As common.UserControls.txtNavigator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNew As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtFromDate As common.Controls.MyDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblClient As common.Controls.MyLabel
    Friend WithEvents RadLabel2 As common.Controls.MyLabel
    Friend WithEvents txtClient As common.UserControls.txtFinder
    Friend WithEvents txtVersion As common.Controls.MyTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel3 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnGo As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnReset As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnUnselect As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSelectAll As Telerik.WinControls.UI.RadButton
    Friend WithEvents cboType As common.Controls.MyComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

