<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTicketMaster
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
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.txtFromDate = New common.Controls.MyDateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddNew = New Telerik.WinControls.UI.RadButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtToDate = New common.Controls.MyDateTimePicker()
        Me.btnGo = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalActuralTestingTime = New common.Controls.MyLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTestingTime = New common.Controls.MyLabel()
        Me.lblTotalAllocatdTime = New common.Controls.MyLabel()
        Me.lblDevelopmentTime = New common.Controls.MyLabel()
        Me.gv = New common.UserControls.MyRadGridView()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAddNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.lblTotalActuralTestingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTestingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalAllocatdTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDevelopmentTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gv)
        Me.SplitContainer1.Size = New System.Drawing.Size(1228, 537)
        Me.SplitContainer1.SplitterDistance = 48
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnClose)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtFromDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAddNew)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtToDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnGo)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.RadGroupBox1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1228, 48)
        Me.SplitContainer2.SplitterDistance = 500
        Me.SplitContainer2.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnClose.Location = New System.Drawing.Point(425, 22)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(57, 19)
        Me.btnClose.TabIndex = 99
        Me.btnClose.Text = "Close"
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
        Me.txtFromDate.Location = New System.Drawing.Point(65, 22)
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
        Me.txtFromDate.TabIndex = 21
        Me.txtFromDate.TabStop = False
        Me.txtFromDate.Text = "13/06/2011"
        Me.txtFromDate.Value = New Date(2011, 6, 13, 11, 29, 49, 421)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "From Date"
        '
        'btnAddNew
        '
        Me.btnAddNew.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddNew.Location = New System.Drawing.Point(341, 22)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(57, 19)
        Me.btnAddNew.TabIndex = 31
        Me.btnAddNew.Text = "Add New"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "To Date"
        '
        'txtToDate
        '
        Me.txtToDate.CalculationExpression = Nothing
        Me.txtToDate.CustomFormat = "dd/MM/yyyy"
        Me.txtToDate.FieldCode = Nothing
        Me.txtToDate.FieldDesc = Nothing
        Me.txtToDate.FieldMaxLength = 0
        Me.txtToDate.FieldName = Nothing
        Me.txtToDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtToDate.isCalculatedField = False
        Me.txtToDate.IsSourceFromTable = False
        Me.txtToDate.IsSourceFromValueList = False
        Me.txtToDate.IsUnique = False
        Me.txtToDate.Location = New System.Drawing.Point(198, 22)
        Me.txtToDate.MendatroryField = False
        Me.txtToDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtToDate.MyLinkLable1 = Nothing
        Me.txtToDate.MyLinkLable2 = Nothing
        Me.txtToDate.Name = "txtToDate"
        Me.txtToDate.NullDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.txtToDate.ReferenceFieldDesc = Nothing
        Me.txtToDate.ReferenceFieldName = Nothing
        Me.txtToDate.ReferenceTableName = Nothing
        Me.txtToDate.Size = New System.Drawing.Size(83, 18)
        Me.txtToDate.TabIndex = 23
        Me.txtToDate.TabStop = False
        Me.txtToDate.Text = "13/06/2011"
        Me.txtToDate.Value = New Date(2011, 6, 13, 11, 29, 49, 421)
        '
        'btnGo
        '
        Me.btnGo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnGo.Location = New System.Drawing.Point(284, 22)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(57, 19)
        Me.btnGo.TabIndex = 30
        Me.btnGo.Text = ">>>"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.Label10)
        Me.RadGroupBox1.Controls.Add(Me.Label9)
        Me.RadGroupBox1.Controls.Add(Me.Label8)
        Me.RadGroupBox1.Controls.Add(Me.lblTotalActuralTestingTime)
        Me.RadGroupBox1.Controls.Add(Me.Label6)
        Me.RadGroupBox1.Controls.Add(Me.lblTestingTime)
        Me.RadGroupBox1.Controls.Add(Me.lblTotalAllocatdTime)
        Me.RadGroupBox1.Controls.Add(Me.lblDevelopmentTime)
        Me.RadGroupBox1.HeaderText = "Total Time"
        Me.RadGroupBox1.Location = New System.Drawing.Point(369, 0)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(352, 46)
        Me.RadGroupBox1.TabIndex = 98
        Me.RadGroupBox1.Text = "Total Time"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(214, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "TESTING"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "DEVELOPMENT"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "ALLOCATED"
        '
        'lblTotalActuralTestingTime
        '
        Me.lblTotalActuralTestingTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalActuralTestingTime.AutoSize = False
        Me.lblTotalActuralTestingTime.BorderVisible = True
        Me.lblTotalActuralTestingTime.FieldName = Nothing
        Me.lblTotalActuralTestingTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalActuralTestingTime.Location = New System.Drawing.Point(267, 26)
        Me.lblTotalActuralTestingTime.Name = "lblTotalActuralTestingTime"
        Me.lblTotalActuralTestingTime.Size = New System.Drawing.Size(83, 18)
        Me.lblTotalActuralTestingTime.TabIndex = 98
        Me.lblTotalActuralTestingTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotalActuralTestingTime.TextWrap = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(179, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "ACTUAL TESTING"
        '
        'lblTestingTime
        '
        Me.lblTestingTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTestingTime.AutoSize = False
        Me.lblTestingTime.BorderVisible = True
        Me.lblTestingTime.FieldName = Nothing
        Me.lblTestingTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestingTime.Location = New System.Drawing.Point(266, 9)
        Me.lblTestingTime.Name = "lblTestingTime"
        Me.lblTestingTime.Size = New System.Drawing.Size(83, 18)
        Me.lblTestingTime.TabIndex = 96
        Me.lblTestingTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTestingTime.TextWrap = False
        '
        'lblTotalAllocatdTime
        '
        Me.lblTotalAllocatdTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAllocatdTime.AutoSize = False
        Me.lblTotalAllocatdTime.BorderVisible = True
        Me.lblTotalAllocatdTime.FieldName = Nothing
        Me.lblTotalAllocatdTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAllocatdTime.Location = New System.Drawing.Point(91, 9)
        Me.lblTotalAllocatdTime.Name = "lblTotalAllocatdTime"
        Me.lblTotalAllocatdTime.Size = New System.Drawing.Size(83, 18)
        Me.lblTotalAllocatdTime.TabIndex = 92
        Me.lblTotalAllocatdTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotalAllocatdTime.TextWrap = False
        '
        'lblDevelopmentTime
        '
        Me.lblDevelopmentTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDevelopmentTime.AutoSize = False
        Me.lblDevelopmentTime.BorderVisible = True
        Me.lblDevelopmentTime.FieldName = Nothing
        Me.lblDevelopmentTime.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevelopmentTime.Location = New System.Drawing.Point(91, 26)
        Me.lblDevelopmentTime.Name = "lblDevelopmentTime"
        Me.lblDevelopmentTime.Size = New System.Drawing.Size(83, 18)
        Me.lblDevelopmentTime.TabIndex = 94
        Me.lblDevelopmentTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDevelopmentTime.TextWrap = False
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
        Me.gv.Size = New System.Drawing.Size(1228, 485)
        Me.gv.TabIndex = 9
        Me.gv.Text = "RadGridView1"
        '
        'FrmTicketMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 537)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmTicketMaster"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Ticket Master"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAddNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.lblTotalActuralTestingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTestingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalAllocatdTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDevelopmentTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gv As common.UserControls.MyRadGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtToDate As common.Controls.MyDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFromDate As common.Controls.MyDateTimePicker
    Friend WithEvents btnAddNew As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnGo As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTotalAllocatdTime As common.Controls.MyLabel
    Friend WithEvents lblTestingTime As common.Controls.MyLabel
    Friend WithEvents lblDevelopmentTime As common.Controls.MyLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTotalActuralTestingTime As common.Controls.MyLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class

