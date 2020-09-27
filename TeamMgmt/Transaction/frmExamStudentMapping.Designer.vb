<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExamStudentMapping
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
        Me.SplitPanel1 = New Telerik.WinControls.UI.SplitPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtDocNo = New common.UserControls.txtNavigator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadGroupBox8 = New Telerik.WinControls.UI.RadGroupBox()
        Me.gv1 = New common.UserControls.MyRadGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSection = New common.Controls.MyLabel()
        Me.RadLabel18 = New common.Controls.MyLabel()
        Me.txtsSection = New common.UserControls.txtFinder()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.btnGo = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox8.SuspendLayout()
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitPanel1
        '
        Me.SplitPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel1.Name = "SplitPanel1"
        '
        '
        '
        Me.SplitPanel1.RootElement.MinSize = New System.Drawing.Size(25, 25)
        Me.SplitPanel1.Size = New System.Drawing.Size(200, 200)
        Me.SplitPanel1.SizeInfo.AutoSizeScale = New System.Drawing.SizeF(0.0!, 0.5!)
        Me.SplitPanel1.SizeInfo.SplitterCorrection = New System.Drawing.Size(0, 98)
        Me.SplitPanel1.TabIndex = 0
        Me.SplitPanel1.TabStop = False
        Me.SplitPanel1.Text = "SplitPanel1"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDocNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadGroupBox8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSection)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadLabel18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtsSection)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDelete)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadButton1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGo)
        Me.SplitContainer1.Size = New System.Drawing.Size(906, 504)
        Me.SplitContainer1.SplitterDistance = 474
        Me.SplitContainer1.TabIndex = 0
        '
        'txtDocNo
        '
        Me.txtDocNo.FieldName = Nothing
        Me.txtDocNo.Location = New System.Drawing.Point(125, 16)
        Me.txtDocNo.MendatroryField = True
        Me.txtDocNo.MyCharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocNo.MyFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtDocNo.MyLinkLable1 = Nothing
        Me.txtDocNo.MyLinkLable2 = Nothing
        Me.txtDocNo.MyMaxLength = 32767
        Me.txtDocNo.MyReadOnly = False
        Me.txtDocNo.Name = "txtDocNo"
        Me.txtDocNo.Size = New System.Drawing.Size(266, 21)
        Me.txtDocNo.TabIndex = 338
        Me.txtDocNo.Value = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 341
        Me.Label1.Text = "Document No"
        '
        'RadGroupBox8
        '
        Me.RadGroupBox8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox8.Controls.Add(Me.gv1)
        Me.RadGroupBox8.Controls.Add(Me.Panel1)
        Me.RadGroupBox8.HeaderText = "Question"
        Me.RadGroupBox8.Location = New System.Drawing.Point(28, 65)
        Me.RadGroupBox8.Name = "RadGroupBox8"
        Me.RadGroupBox8.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox8.Size = New System.Drawing.Size(739, 367)
        Me.RadGroupBox8.TabIndex = 337
        Me.RadGroupBox8.Text = "Question"
        '
        'gv1
        '
        Me.gv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.gv1.Cursor = System.Windows.Forms.Cursors.Default
        Me.gv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gv1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.gv1.ForeColor = System.Drawing.Color.Black
        Me.gv1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gv1.Location = New System.Drawing.Point(10, 30)
        '
        'gv1
        '
        Me.gv1.MasterTemplate.AllowDeleteRow = False
        Me.gv1.MasterTemplate.EnableFiltering = True
        Me.gv1.MasterTemplate.ShowHeaderCellButtons = True
        Me.gv1.Name = "gv1"
        Me.gv1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gv1.ShowGroupPanel = False
        Me.gv1.ShowHeaderCellButtons = True
        Me.gv1.Size = New System.Drawing.Size(719, 327)
        Me.gv1.TabIndex = 1
        Me.gv1.Text = "RadGridView1"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 10)
        Me.Panel1.TabIndex = 0
        '
        'lblSection
        '
        Me.lblSection.AutoSize = False
        Me.lblSection.BorderVisible = True
        Me.lblSection.FieldName = Nothing
        Me.lblSection.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblSection.Location = New System.Drawing.Point(399, 40)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(362, 18)
        Me.lblSection.TabIndex = 326
        Me.lblSection.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSection.TextWrap = False
        '
        'RadLabel18
        '
        Me.RadLabel18.FieldName = Nothing
        Me.RadLabel18.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadLabel18.Location = New System.Drawing.Point(28, 42)
        Me.RadLabel18.Name = "RadLabel18"
        Me.RadLabel18.Size = New System.Drawing.Size(79, 16)
        Me.RadLabel18.TabIndex = 327
        Me.RadLabel18.Text = "Student Name"
        '
        'txtsSection
        '
        Me.txtsSection.CalculationExpression = Nothing
        Me.txtsSection.FieldCode = Nothing
        Me.txtsSection.FieldDesc = Nothing
        Me.txtsSection.FieldMaxLength = 0
        Me.txtsSection.FieldName = Nothing
        Me.txtsSection.isCalculatedField = False
        Me.txtsSection.IsSourceFromTable = False
        Me.txtsSection.IsSourceFromValueList = False
        Me.txtsSection.IsUnique = False
        Me.txtsSection.Location = New System.Drawing.Point(125, 40)
        Me.txtsSection.MendatroryField = False
        Me.txtsSection.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsSection.MyLinkLable1 = Me.RadLabel18
        Me.txtsSection.MyLinkLable2 = Me.lblSection
        Me.txtsSection.MyReadOnly = False
        Me.txtsSection.MyShowMasterFormButton = False
        Me.txtsSection.Name = "txtsSection"
        Me.txtsSection.ReferenceFieldDesc = Nothing
        Me.txtsSection.ReferenceFieldName = Nothing
        Me.txtsSection.ReferenceTableName = Nothing
        Me.txtsSection.Size = New System.Drawing.Size(264, 19)
        Me.txtsSection.TabIndex = 325
        Me.txtsSection.Value = ""
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(823, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(71, 22)
        Me.btnClose.TabIndex = 341
        Me.btnClose.Text = "Close"
        '
        'RadButton1
        '
        Me.RadButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadButton1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButton1.Location = New System.Drawing.Point(93, 2)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(71, 22)
        Me.RadButton1.TabIndex = 340
        Me.RadButton1.Text = "Reset"
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.Location = New System.Drawing.Point(14, 2)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(71, 22)
        Me.btnGo.TabIndex = 338
        Me.btnGo.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(170, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(71, 22)
        Me.btnDelete.TabIndex = 339
        Me.btnDelete.Text = "Delete"
        '
        'frmExamStudentMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 504)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmExamStudentMapping"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Exam Student Mapping"
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox8.ResumeLayout(False)
        CType(Me.gv1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadGroupBox8 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSection As common.Controls.MyLabel
    Friend WithEvents RadLabel18 As common.Controls.MyLabel
    Friend WithEvents txtsSection As common.UserControls.txtFinder
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnGo As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtDocNo As common.UserControls.txtNavigator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gv1 As common.UserControls.MyRadGridView
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
End Class

