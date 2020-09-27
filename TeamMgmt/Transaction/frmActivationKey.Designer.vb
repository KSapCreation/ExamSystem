<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivationKey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivationKey))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCompany = New common.Controls.MyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStudent = New common.Controls.MyLabel()
        Me.RadLabel2 = New common.Controls.MyLabel()
        Me.txtFromDate = New common.Controls.MyDateTimePicker()
        Me.txtStudent = New common.UserControls.txtFinder()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCode = New common.UserControls.txtNavigator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gv = New common.UserControls.MyRadGridView()
        Me.RadSplitContainer1 = New Telerik.WinControls.UI.RadSplitContainer()
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.SplitPanel2 = New Telerik.WinControls.UI.SplitPanel()
        Me.SplitPanel3 = New Telerik.WinControls.UI.SplitPanel()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnReset = New Telerik.WinControls.UI.RadButton()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblStudent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnReset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadButton1)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblStudent)
        Me.GroupBox1.Controls.Add(Me.RadLabel2)
        Me.GroupBox1.Controls.Add(Me.txtFromDate)
        Me.GroupBox1.Controls.Add(Me.txtStudent)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1228, 144)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Product Key"
        '
        'txtCompany
        '
        Me.txtCompany.CalculationExpression = Nothing
        Me.txtCompany.FieldCode = Nothing
        Me.txtCompany.FieldDesc = Nothing
        Me.txtCompany.FieldMaxLength = 0
        Me.txtCompany.FieldName = Nothing
        Me.txtCompany.isCalculatedField = False
        Me.txtCompany.IsSourceFromTable = False
        Me.txtCompany.IsSourceFromValueList = False
        Me.txtCompany.IsUnique = False
        Me.txtCompany.Location = New System.Drawing.Point(124, 100)
        Me.txtCompany.MaxLength = 50
        Me.txtCompany.MendatroryField = True
        Me.txtCompany.MyLinkLable1 = Nothing
        Me.txtCompany.MyLinkLable2 = Nothing
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReferenceFieldDesc = Nothing
        Me.txtCompany.ReferenceFieldName = Nothing
        Me.txtCompany.ReferenceTableName = Nothing
        Me.txtCompany.Size = New System.Drawing.Size(248, 20)
        Me.txtCompany.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Company"
        '
        'lblStudent
        '
        Me.lblStudent.AutoSize = False
        Me.lblStudent.BorderVisible = True
        Me.lblStudent.FieldName = Nothing
        Me.lblStudent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudent.Location = New System.Drawing.Point(291, 53)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Size = New System.Drawing.Size(264, 18)
        Me.lblStudent.TabIndex = 46
        Me.lblStudent.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStudent.TextWrap = False
        '
        'RadLabel2
        '
        Me.RadLabel2.FieldName = Nothing
        Me.RadLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(13, 53)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(79, 16)
        Me.RadLabel2.TabIndex = 45
        Me.RadLabel2.Text = "Student Name"
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
        Me.txtFromDate.Location = New System.Drawing.Point(124, 76)
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
        'txtStudent
        '
        Me.txtStudent.CalculationExpression = Nothing
        Me.txtStudent.FieldCode = Nothing
        Me.txtStudent.FieldDesc = Nothing
        Me.txtStudent.FieldMaxLength = 0
        Me.txtStudent.FieldName = Nothing
        Me.txtStudent.isCalculatedField = False
        Me.txtStudent.IsSourceFromTable = False
        Me.txtStudent.IsSourceFromValueList = False
        Me.txtStudent.IsUnique = False
        Me.txtStudent.Location = New System.Drawing.Point(124, 52)
        Me.txtStudent.MendatroryField = True
        Me.txtStudent.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStudent.MyLinkLable1 = Me.RadLabel2
        Me.txtStudent.MyLinkLable2 = Me.lblStudent
        Me.txtStudent.MyReadOnly = False
        Me.txtStudent.MyShowMasterFormButton = False
        Me.txtStudent.Name = "txtStudent"
        Me.txtStudent.ReferenceFieldDesc = Nothing
        Me.txtStudent.ReferenceFieldName = Nothing
        Me.txtStudent.ReferenceTableName = Nothing
        Me.txtStudent.Size = New System.Drawing.Size(166, 18)
        Me.txtStudent.TabIndex = 44
        Me.txtStudent.Value = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Activation Date End"
        '
        'txtCode
        '
        Me.txtCode.FieldName = Nothing
        Me.txtCode.Location = New System.Drawing.Point(124, 21)
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
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Activation Code"
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
        Me.gv.Size = New System.Drawing.Size(1228, 348)
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
        Me.SplitPanel1.Size = New System.Drawing.Size(1228, 144)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, -0.06112162!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, -32)
        Me.SplitPanel1.TabIndex = 0
        Me.SplitPanel1.TabStop = False
        Me.SplitPanel1.Text = "SplitPanel1"
        '
        'SplitPanel2
        '
        Me.SplitPanel2.Controls.Add(Me.gv)
        Me.SplitPanel2.Location = New System.Drawing.Point(0, 148)
        Me.SplitPanel2.Name = "SplitPanel2"
        '
        '
        '
        Me.SplitPanel2.RootElement.MinSize = New System.Drawing.Size(0, 0)
        Me.SplitPanel2.Size = New System.Drawing.Size(1228, 348)
        Me.SplitPanel2.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, 0.3245116!)
        Me.SplitPanel2.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, 172)
        Me.SplitPanel2.TabIndex = 1
        Me.SplitPanel2.TabStop = False
        Me.SplitPanel2.Text = "SplitPanel2"
        '
        'SplitPanel3
        '
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
        'RadButton1
        '
        Me.RadButton1.Image = CType(resources.GetObject("RadButton1.Image"), System.Drawing.Image)
        Me.RadButton1.Location = New System.Drawing.Point(351, 22)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(14, 21)
        Me.RadButton1.TabIndex = 49
        Me.RadButton1.Text = " "
        '
        'frmActivationKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 537)
        Me.Controls.Add(Me.RadSplitContainer1)
        Me.Name = "frmActivationKey"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FBNPC"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblStudent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnReset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gv As common.UserControls.MyRadGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCode As common.UserControls.txtNavigator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFromDate As common.Controls.MyDateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStudent As common.Controls.MyLabel
    Friend WithEvents RadLabel2 As common.Controls.MyLabel
    Friend WithEvents txtStudent As common.UserControls.txtFinder
    Friend WithEvents txtCompany As common.Controls.MyTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadSplitContainer1 As Telerik.WinControls.UI.RadSplitContainer
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel2 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitPanel3 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnReset As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
End Class

