<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTimeMaster
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
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.MyLabel5 = New common.Controls.MyLabel()
        Me.MyLabel4 = New common.Controls.MyLabel()
        Me.lblClient = New common.Controls.MyLabel()
        Me.MyLabel3 = New common.Controls.MyLabel()
        Me.txtAdditionalTime = New common.MyNumBox()
        Me.MyLabel2 = New common.Controls.MyLabel()
        Me.txtDebuggingTime = New common.MyNumBox()
        Me.MyLabel1 = New common.Controls.MyLabel()
        Me.txt_TesterTime = New common.MyNumBox()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.munuExport = New Telerik.WinControls.UI.RadMenuItem()
        Me.rMenuExport = New Telerik.WinControls.UI.RadMenuItem()
        Me.rMenuImport = New Telerik.WinControls.UI.RadMenuItem()
        Me.rMenuExit = New Telerik.WinControls.UI.RadMenuItem()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdditionalTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDebuggingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TesterTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadGroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadMenu1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Size = New System.Drawing.Size(662, 535)
        Me.SplitContainer1.SplitterDistance = 506
        Me.SplitContainer1.TabIndex = 0
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.MyLabel5)
        Me.RadGroupBox1.Controls.Add(Me.MyLabel4)
        Me.RadGroupBox1.Controls.Add(Me.lblClient)
        Me.RadGroupBox1.Controls.Add(Me.MyLabel3)
        Me.RadGroupBox1.Controls.Add(Me.txtAdditionalTime)
        Me.RadGroupBox1.Controls.Add(Me.MyLabel2)
        Me.RadGroupBox1.Controls.Add(Me.txtDebuggingTime)
        Me.RadGroupBox1.Controls.Add(Me.MyLabel1)
        Me.RadGroupBox1.Controls.Add(Me.txt_TesterTime)
        Me.RadGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(0, 20)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(662, 486)
        Me.RadGroupBox1.TabIndex = 5
        '
        'MyLabel5
        '
        Me.MyLabel5.AutoSize = False
        Me.MyLabel5.FieldName = Nothing
        Me.MyLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel5.Location = New System.Drawing.Point(211, 64)
        Me.MyLabel5.Name = "MyLabel5"
        Me.MyLabel5.Size = New System.Drawing.Size(22, 18)
        Me.MyLabel5.TabIndex = 196
        Me.MyLabel5.Text = "%"
        Me.MyLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyLabel5.TextWrap = False
        '
        'MyLabel4
        '
        Me.MyLabel4.AutoSize = False
        Me.MyLabel4.FieldName = Nothing
        Me.MyLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel4.Location = New System.Drawing.Point(211, 42)
        Me.MyLabel4.Name = "MyLabel4"
        Me.MyLabel4.Size = New System.Drawing.Size(22, 18)
        Me.MyLabel4.TabIndex = 195
        Me.MyLabel4.Text = "%"
        Me.MyLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.MyLabel4.TextWrap = False
        '
        'lblClient
        '
        Me.lblClient.AutoSize = False
        Me.lblClient.FieldName = Nothing
        Me.lblClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.Location = New System.Drawing.Point(211, 20)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(22, 18)
        Me.lblClient.TabIndex = 194
        Me.lblClient.Text = "%"
        Me.lblClient.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblClient.TextWrap = False
        '
        'MyLabel3
        '
        Me.MyLabel3.FieldName = Nothing
        Me.MyLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel3.Location = New System.Drawing.Point(16, 65)
        Me.MyLabel3.Name = "MyLabel3"
        Me.MyLabel3.Size = New System.Drawing.Size(84, 16)
        Me.MyLabel3.TabIndex = 193
        Me.MyLabel3.Text = "Additional Time"
        '
        'txtAdditionalTime
        '
        Me.txtAdditionalTime.BackColor = System.Drawing.Color.White
        Me.txtAdditionalTime.CalculationExpression = Nothing
        Me.txtAdditionalTime.DecimalPlaces = 2
        Me.txtAdditionalTime.FieldCode = Nothing
        Me.txtAdditionalTime.FieldDesc = Nothing
        Me.txtAdditionalTime.FieldMaxLength = 5
        Me.txtAdditionalTime.FieldName = Nothing
        Me.txtAdditionalTime.isCalculatedField = False
        Me.txtAdditionalTime.IsSourceFromTable = False
        Me.txtAdditionalTime.IsSourceFromValueList = False
        Me.txtAdditionalTime.IsUnique = False
        Me.txtAdditionalTime.Location = New System.Drawing.Point(119, 63)
        Me.txtAdditionalTime.MendatroryField = False
        Me.txtAdditionalTime.MyLinkLable1 = Nothing
        Me.txtAdditionalTime.MyLinkLable2 = Nothing
        Me.txtAdditionalTime.Name = "txtAdditionalTime"
        Me.txtAdditionalTime.ReferenceFieldDesc = Nothing
        Me.txtAdditionalTime.ReferenceFieldName = Nothing
        Me.txtAdditionalTime.ReferenceTableName = Nothing
        Me.txtAdditionalTime.Size = New System.Drawing.Size(89, 20)
        Me.txtAdditionalTime.TabIndex = 2
        Me.txtAdditionalTime.Text = "0"
        Me.txtAdditionalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAdditionalTime.Value = 0.0R
        '
        'MyLabel2
        '
        Me.MyLabel2.FieldName = Nothing
        Me.MyLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel2.Location = New System.Drawing.Point(16, 43)
        Me.MyLabel2.Name = "MyLabel2"
        Me.MyLabel2.Size = New System.Drawing.Size(89, 16)
        Me.MyLabel2.TabIndex = 191
        Me.MyLabel2.Text = "Debugging Time"
        '
        'txtDebuggingTime
        '
        Me.txtDebuggingTime.BackColor = System.Drawing.Color.White
        Me.txtDebuggingTime.CalculationExpression = Nothing
        Me.txtDebuggingTime.DecimalPlaces = 2
        Me.txtDebuggingTime.FieldCode = Nothing
        Me.txtDebuggingTime.FieldDesc = Nothing
        Me.txtDebuggingTime.FieldMaxLength = 5
        Me.txtDebuggingTime.FieldName = Nothing
        Me.txtDebuggingTime.isCalculatedField = False
        Me.txtDebuggingTime.IsSourceFromTable = False
        Me.txtDebuggingTime.IsSourceFromValueList = False
        Me.txtDebuggingTime.IsUnique = False
        Me.txtDebuggingTime.Location = New System.Drawing.Point(119, 41)
        Me.txtDebuggingTime.MendatroryField = False
        Me.txtDebuggingTime.MyLinkLable1 = Nothing
        Me.txtDebuggingTime.MyLinkLable2 = Nothing
        Me.txtDebuggingTime.Name = "txtDebuggingTime"
        Me.txtDebuggingTime.ReferenceFieldDesc = Nothing
        Me.txtDebuggingTime.ReferenceFieldName = Nothing
        Me.txtDebuggingTime.ReferenceTableName = Nothing
        Me.txtDebuggingTime.Size = New System.Drawing.Size(89, 20)
        Me.txtDebuggingTime.TabIndex = 1
        Me.txtDebuggingTime.Text = "0"
        Me.txtDebuggingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDebuggingTime.Value = 0.0R
        '
        'MyLabel1
        '
        Me.MyLabel1.FieldName = Nothing
        Me.MyLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyLabel1.Location = New System.Drawing.Point(16, 21)
        Me.MyLabel1.Name = "MyLabel1"
        Me.MyLabel1.Size = New System.Drawing.Size(67, 16)
        Me.MyLabel1.TabIndex = 189
        Me.MyLabel1.Text = "Tester Time"
        '
        'txt_TesterTime
        '
        Me.txt_TesterTime.BackColor = System.Drawing.Color.White
        Me.txt_TesterTime.CalculationExpression = Nothing
        Me.txt_TesterTime.DecimalPlaces = 2
        Me.txt_TesterTime.FieldCode = Nothing
        Me.txt_TesterTime.FieldDesc = Nothing
        Me.txt_TesterTime.FieldMaxLength = 5
        Me.txt_TesterTime.FieldName = Nothing
        Me.txt_TesterTime.isCalculatedField = False
        Me.txt_TesterTime.IsSourceFromTable = False
        Me.txt_TesterTime.IsSourceFromValueList = False
        Me.txt_TesterTime.IsUnique = False
        Me.txt_TesterTime.Location = New System.Drawing.Point(119, 19)
        Me.txt_TesterTime.MendatroryField = False
        Me.txt_TesterTime.MyLinkLable1 = Nothing
        Me.txt_TesterTime.MyLinkLable2 = Nothing
        Me.txt_TesterTime.Name = "txt_TesterTime"
        Me.txt_TesterTime.ReferenceFieldDesc = Nothing
        Me.txt_TesterTime.ReferenceFieldName = Nothing
        Me.txt_TesterTime.ReferenceTableName = Nothing
        Me.txt_TesterTime.Size = New System.Drawing.Size(89, 20)
        Me.txt_TesterTime.TabIndex = 0
        Me.txt_TesterTime.Text = "0"
        Me.txt_TesterTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_TesterTime.Value = 0.0R
        '
        'RadMenu1
        '
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.munuExport})
        Me.RadMenu1.Location = New System.Drawing.Point(0, 0)
        Me.RadMenu1.Name = "RadMenu1"
        Me.RadMenu1.Size = New System.Drawing.Size(662, 20)
        Me.RadMenu1.TabIndex = 4
        Me.RadMenu1.Text = "RadMenu1"
        Me.RadMenu1.Visible = False
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
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(579, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 18)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 18)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'FrmTimeMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 535)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmTimeMaster"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Time Master"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblClient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdditionalTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDebuggingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TesterTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents munuExport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents rMenuExport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents rMenuImport As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents rMenuExit As Telerik.WinControls.UI.RadMenuItem
    Friend WithEvents txt_TesterTime As common.MyNumBox
    Friend WithEvents MyLabel3 As common.Controls.MyLabel
    Friend WithEvents txtAdditionalTime As common.MyNumBox
    Friend WithEvents MyLabel2 As common.Controls.MyLabel
    Friend WithEvents txtDebuggingTime As common.MyNumBox
    Friend WithEvents MyLabel1 As common.Controls.MyLabel
    Friend WithEvents MyLabel5 As common.Controls.MyLabel
    Friend WithEvents MyLabel4 As common.Controls.MyLabel
    Friend WithEvents lblClient As common.Controls.MyLabel
End Class

