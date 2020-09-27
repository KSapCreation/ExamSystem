<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExamReloader
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
        Me.lblExamName = New common.Controls.MyLabel()
        Me.txtExam = New common.UserControls.txtFinder()
        Me.lblSubject = New common.Controls.MyLabel()
        Me.MyLabel2 = New common.Controls.MyLabel()
        Me.txtSubject = New common.UserControls.txtFinder()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.btnGo = New Telerik.WinControls.UI.RadButton()
        Me.MyLabel4 = New common.Controls.MyLabel()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.lblExamName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblExamName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtExam)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSubject)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadButton1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGo)
        Me.SplitContainer1.Size = New System.Drawing.Size(906, 504)
        Me.SplitContainer1.SplitterDistance = 474
        Me.SplitContainer1.TabIndex = 0
        '
        'lblExamName
        '
        Me.lblExamName.AutoSize = False
        Me.lblExamName.BorderVisible = True
        Me.lblExamName.FieldName = Nothing
        Me.lblExamName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblExamName.Location = New System.Drawing.Point(266, 43)
        Me.lblExamName.Name = "lblExamName"
        Me.lblExamName.Size = New System.Drawing.Size(287, 18)
        Me.lblExamName.TabIndex = 332
        Me.lblExamName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblExamName.TextWrap = False
        '
        'txtExam
        '
        Me.txtExam.CalculationExpression = Nothing
        Me.txtExam.FieldCode = Nothing
        Me.txtExam.FieldDesc = Nothing
        Me.txtExam.FieldMaxLength = 0
        Me.txtExam.FieldName = Nothing
        Me.txtExam.isCalculatedField = False
        Me.txtExam.IsSourceFromTable = False
        Me.txtExam.IsSourceFromValueList = False
        Me.txtExam.IsUnique = False
        Me.txtExam.Location = New System.Drawing.Point(121, 43)
        Me.txtExam.MendatroryField = False
        Me.txtExam.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExam.MyLinkLable1 = Me.MyLabel4
        Me.txtExam.MyLinkLable2 = Me.lblExamName
        Me.txtExam.MyReadOnly = False
        Me.txtExam.MyShowMasterFormButton = False
        Me.txtExam.Name = "txtExam"
        Me.txtExam.ReferenceFieldDesc = Nothing
        Me.txtExam.ReferenceFieldName = Nothing
        Me.txtExam.ReferenceTableName = Nothing
        Me.txtExam.Size = New System.Drawing.Size(143, 19)
        Me.txtExam.TabIndex = 331
        Me.txtExam.Value = ""
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = False
        Me.lblSubject.BorderVisible = True
        Me.lblSubject.FieldName = Nothing
        Me.lblSubject.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblSubject.Location = New System.Drawing.Point(266, 22)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(287, 18)
        Me.lblSubject.TabIndex = 329
        Me.lblSubject.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSubject.TextWrap = False
        '
        'MyLabel2
        '
        Me.MyLabel2.FieldName = Nothing
        Me.MyLabel2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MyLabel2.Location = New System.Drawing.Point(24, 24)
        Me.MyLabel2.Name = "MyLabel2"
        Me.MyLabel2.Size = New System.Drawing.Size(79, 16)
        Me.MyLabel2.TabIndex = 330
        Me.MyLabel2.Text = "Student Name"
        '
        'txtSubject
        '
        Me.txtSubject.CalculationExpression = Nothing
        Me.txtSubject.FieldCode = Nothing
        Me.txtSubject.FieldDesc = Nothing
        Me.txtSubject.FieldMaxLength = 0
        Me.txtSubject.FieldName = Nothing
        Me.txtSubject.isCalculatedField = False
        Me.txtSubject.IsSourceFromTable = False
        Me.txtSubject.IsSourceFromValueList = False
        Me.txtSubject.IsUnique = False
        Me.txtSubject.Location = New System.Drawing.Point(121, 22)
        Me.txtSubject.MendatroryField = False
        Me.txtSubject.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.MyLinkLable1 = Me.MyLabel2
        Me.txtSubject.MyLinkLable2 = Me.lblSubject
        Me.txtSubject.MyReadOnly = False
        Me.txtSubject.MyShowMasterFormButton = False
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.ReferenceFieldDesc = Nothing
        Me.txtSubject.ReferenceFieldName = Nothing
        Me.txtSubject.ReferenceTableName = Nothing
        Me.txtSubject.Size = New System.Drawing.Size(143, 19)
        Me.txtSubject.TabIndex = 328
        Me.txtSubject.Value = ""
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
        Me.RadButton1.Location = New System.Drawing.Point(92, 2)
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
        'MyLabel4
        '
        Me.MyLabel4.FieldName = Nothing
        Me.MyLabel4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MyLabel4.Location = New System.Drawing.Point(24, 45)
        Me.MyLabel4.Name = "MyLabel4"
        Me.MyLabel4.Size = New System.Drawing.Size(68, 16)
        Me.MyLabel4.TabIndex = 333
        Me.MyLabel4.Text = "Exam Name"
        '
        'frmExamReloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 504)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmExamReloader"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Exam Re-Loader"
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.lblExamName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblExamName As common.Controls.MyLabel
    Friend WithEvents txtExam As common.UserControls.txtFinder
    Friend WithEvents lblSubject As common.Controls.MyLabel
    Friend WithEvents MyLabel2 As common.Controls.MyLabel
    Friend WithEvents txtSubject As common.UserControls.txtFinder
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnGo As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents MyLabel4 As common.Controls.MyLabel
End Class

