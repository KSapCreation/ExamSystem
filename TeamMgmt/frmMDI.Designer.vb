<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.pnlLogin = New Telerik.WinControls.UI.RadPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.cboMenu = New Telerik.WinControls.UI.RadDropDownList()
        Me.RTV2 = New Telerik.WinControls.UI.RadTreeView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.btnEditCaption = New Telerik.WinControls.UI.RadButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUserName = New common.Controls.MyLabel()
        Me.btnLogIn = New Telerik.WinControls.UI.RadButton()
        Me.cboCompany = New common.Controls.MyComboBox()
        Me.MyLabel3 = New common.Controls.MyLabel()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.txtUserName = New common.Controls.MyTextBox()
        Me.btnChangePassword = New Telerik.WinControls.UI.RadButton()
        Me.txtPassword = New common.Controls.MyTextBox()
        Me.lblPassword = New common.Controls.MyLabel()
        CType(Me.pnlLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLogin.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.cboMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RTV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEditCaption, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.lblUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLogIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnChangePassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLogin
        '
        Me.pnlLogin.Controls.Add(Me.SplitContainer1)
        Me.pnlLogin.Controls.Add(Me.Panel1)
        Me.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLogin.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(1057, 517)
        Me.pnlLogin.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1057, 517)
        Me.SplitContainer1.SplitterDistance = 207
        Me.SplitContainer1.TabIndex = 27
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.cboMenu)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.RTV2)
        Me.SplitContainer3.Size = New System.Drawing.Size(207, 492)
        Me.SplitContainer3.SplitterDistance = 25
        Me.SplitContainer3.TabIndex = 15
        '
        'cboMenu
        '
        Me.cboMenu.AutoCompleteDisplayMember = Nothing
        Me.cboMenu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMenu.AutoCompleteValueMember = Nothing
        Me.cboMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboMenu.Location = New System.Drawing.Point(0, 0)
        Me.cboMenu.Name = "cboMenu"
        Me.cboMenu.NullText = "Quick Menu"
        Me.cboMenu.Size = New System.Drawing.Size(207, 20)
        Me.cboMenu.TabIndex = 0
        '
        'RTV2
        '
        Me.RTV2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTV2.Location = New System.Drawing.Point(0, 0)
        Me.RTV2.Name = "RTV2"
        Me.RTV2.ShowDragHint = False
        Me.RTV2.ShowDropHint = False
        Me.RTV2.ShowExpandCollapse = False
        Me.RTV2.Size = New System.Drawing.Size(207, 463)
        Me.RTV2.SpacingBetweenNodes = -1
        Me.RTV2.TabIndex = 0
        Me.RTV2.Text = "RadTreeView2"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadButton2)
        Me.Panel2.Controls.Add(Me.btnEditCaption)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 492)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(207, 25)
        Me.Panel2.TabIndex = 14
        '
        'RadButton2
        '
        Me.RadButton2.Location = New System.Drawing.Point(83, 3)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(79, 19)
        Me.RadButton2.TabIndex = 1
        Me.RadButton2.Text = "Expand All"
        '
        'btnEditCaption
        '
        Me.btnEditCaption.Location = New System.Drawing.Point(3, 3)
        Me.btnEditCaption.Name = "btnEditCaption"
        Me.btnEditCaption.Size = New System.Drawing.Size(79, 19)
        Me.btnEditCaption.TabIndex = 0
        Me.btnEditCaption.Text = "Collapse All"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblUserName)
        Me.Panel1.Controls.Add(Me.btnLogIn)
        Me.Panel1.Controls.Add(Me.cboCompany)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.txtUserName)
        Me.Panel1.Controls.Add(Me.btnChangePassword)
        Me.Panel1.Controls.Add(Me.MyLabel3)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Location = New System.Drawing.Point(382, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 175)
        Me.Panel1.TabIndex = 26
        '
        'lblUserName
        '
        Me.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.FieldName = Nothing
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblUserName.Location = New System.Drawing.Point(27, 17)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(74, 21)
        Me.lblUserName.TabIndex = 22
        Me.lblUserName.Text = "User Name"
        '
        'btnLogIn
        '
        Me.btnLogIn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLogIn.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogIn.Location = New System.Drawing.Point(27, 131)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(83, 19)
        Me.btnLogIn.TabIndex = 20
        Me.btnLogIn.Text = "OK"
        '
        'cboCompany
        '
        Me.cboCompany.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboCompany.AutoCompleteDisplayMember = Nothing
        Me.cboCompany.AutoCompleteValueMember = Nothing
        Me.cboCompany.CalculationExpression = Nothing
        Me.cboCompany.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboCompany.FieldCode = Nothing
        Me.cboCompany.FieldDesc = Nothing
        Me.cboCompany.FieldMaxLength = 0
        Me.cboCompany.FieldName = Nothing
        Me.cboCompany.isCalculatedField = False
        Me.cboCompany.IsSourceFromTable = False
        Me.cboCompany.IsSourceFromValueList = False
        Me.cboCompany.IsUnique = False
        Me.cboCompany.Location = New System.Drawing.Point(123, 93)
        Me.cboCompany.MendatroryField = True
        Me.cboCompany.MyLinkLable1 = Me.MyLabel3
        Me.cboCompany.MyLinkLable2 = Nothing
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.NullText = "Select Company"
        Me.cboCompany.ReferenceFieldDesc = Nothing
        Me.cboCompany.ReferenceFieldName = Nothing
        Me.cboCompany.ReferenceTableName = Nothing
        Me.cboCompany.Size = New System.Drawing.Size(238, 20)
        Me.cboCompany.TabIndex = 19
        '
        'MyLabel3
        '
        Me.MyLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MyLabel3.BackColor = System.Drawing.Color.Transparent
        Me.MyLabel3.FieldName = Nothing
        Me.MyLabel3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MyLabel3.Location = New System.Drawing.Point(27, 93)
        Me.MyLabel3.Name = "MyLabel3"
        Me.MyLabel3.Size = New System.Drawing.Size(65, 21)
        Me.MyLabel3.TabIndex = 24
        Me.MyLabel3.Text = "Company"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(110, 131)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 19)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUserName.CalculationExpression = Nothing
        Me.txtUserName.FieldCode = Nothing
        Me.txtUserName.FieldDesc = Nothing
        Me.txtUserName.FieldMaxLength = 0
        Me.txtUserName.FieldName = Nothing
        Me.txtUserName.isCalculatedField = False
        Me.txtUserName.IsSourceFromTable = False
        Me.txtUserName.IsSourceFromValueList = False
        Me.txtUserName.IsUnique = False
        Me.txtUserName.Location = New System.Drawing.Point(123, 17)
        Me.txtUserName.MendatroryField = True
        Me.txtUserName.MyLinkLable1 = Me.lblUserName
        Me.txtUserName.MyLinkLable2 = Nothing
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.NullText = "User Name"
        Me.txtUserName.ReferenceFieldDesc = Nothing
        Me.txtUserName.ReferenceFieldName = Nothing
        Me.txtUserName.ReferenceTableName = Nothing
        Me.txtUserName.Size = New System.Drawing.Size(238, 20)
        Me.txtUserName.TabIndex = 17
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnChangePassword.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.Location = New System.Drawing.Point(193, 131)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(131, 19)
        Me.btnChangePassword.TabIndex = 25
        Me.btnChangePassword.Text = "Change Password"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPassword.CalculationExpression = Nothing
        Me.txtPassword.FieldCode = Nothing
        Me.txtPassword.FieldDesc = Nothing
        Me.txtPassword.FieldMaxLength = 0
        Me.txtPassword.FieldName = Nothing
        Me.txtPassword.isCalculatedField = False
        Me.txtPassword.IsSourceFromTable = False
        Me.txtPassword.IsSourceFromValueList = False
        Me.txtPassword.IsUnique = False
        Me.txtPassword.Location = New System.Drawing.Point(123, 55)
        Me.txtPassword.MendatroryField = True
        Me.txtPassword.MyLinkLable1 = Me.lblPassword
        Me.txtPassword.MyLinkLable2 = Nothing
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.NullText = "Password"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ReferenceFieldDesc = Nothing
        Me.txtPassword.ReferenceFieldName = Nothing
        Me.txtPassword.ReferenceTableName = Nothing
        Me.txtPassword.Size = New System.Drawing.Size(238, 20)
        Me.txtPassword.TabIndex = 18
        '
        'lblPassword
        '
        Me.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.FieldName = Nothing
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPassword.Location = New System.Drawing.Point(27, 55)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(64, 21)
        Me.lblPassword.TabIndex = 23
        Me.lblPassword.Text = "Password"
        '
        'MDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 517)
        Me.Controls.Add(Me.pnlLogin)
        Me.IsMdiContainer = True
        Me.Name = "MDI"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Team Mgmt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pnlLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLogin.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.cboMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RTV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEditCaption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.lblUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLogIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnChangePassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLogin As Telerik.WinControls.UI.RadPanel
    Friend WithEvents btnLogIn As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnChangePassword As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtPassword As common.Controls.MyTextBox
    Friend WithEvents lblPassword As common.Controls.MyLabel
    Friend WithEvents lblUserName As common.Controls.MyLabel
    Friend WithEvents MyLabel3 As common.Controls.MyLabel
    Friend WithEvents txtUserName As common.Controls.MyTextBox
    Friend WithEvents cboCompany As common.Controls.MyComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Public WithEvents RTV2 As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnEditCaption As Telerik.WinControls.UI.RadButton
    Friend WithEvents cboMenu As Telerik.WinControls.UI.RadDropDownList
End Class

