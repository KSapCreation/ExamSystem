<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExamSet
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
        Me.lblVideoName = New common.Controls.MyLabel()
        Me.MyLabel5 = New common.Controls.MyLabel()
        Me.txtDocNo = New common.UserControls.txtNavigator()
        Me.txtVideo = New common.UserControls.txtFinder()
        Me.btnreset1 = New Telerik.WinControls.UI.RadButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadGroupBox8 = New Telerik.WinControls.UI.RadGroupBox()
        Me.gv1 = New common.UserControls.MyRadGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAudioVideo = New common.Controls.MyLabel()
        Me.MyLabel3 = New common.Controls.MyLabel()
        Me.txtAV = New common.UserControls.txtFinder()
        Me.lblExamName = New common.Controls.MyLabel()
        Me.MyLabel4 = New common.Controls.MyLabel()
        Me.txtExam = New common.UserControls.txtFinder()
        Me.lblSubject = New common.Controls.MyLabel()
        Me.MyLabel2 = New common.Controls.MyLabel()
        Me.txtSubject = New common.UserControls.txtFinder()
        Me.lblSection = New common.Controls.MyLabel()
        Me.RadLabel18 = New common.Controls.MyLabel()
        Me.txtsSection = New common.UserControls.txtFinder()
        Me.btnClose = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.btnPost = New Telerik.WinControls.UI.RadButton()
        Me.btnGo = New Telerik.WinControls.UI.RadButton()
        Me.lblComprehension = New common.Controls.MyLabel()
        Me.MyLabel6 = New common.Controls.MyLabel()
        Me.txtComprehension = New common.UserControls.txtFinder()
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.lblVideoName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox8.SuspendLayout()
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAudioVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblExamName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblComprehension, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblComprehension)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtComprehension)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblVideoName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDocNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtVideo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnreset1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadGroupBox8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAudioVideo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAV)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblExamName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtExam)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MyLabel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSection)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RadLabel18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtsSection)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadButton1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPost)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGo)
        Me.SplitContainer1.Size = New System.Drawing.Size(906, 504)
        Me.SplitContainer1.SplitterDistance = 474
        Me.SplitContainer1.TabIndex = 0
        '
        'lblVideoName
        '
        Me.lblVideoName.AutoSize = False
        Me.lblVideoName.BorderVisible = True
        Me.lblVideoName.FieldName = Nothing
        Me.lblVideoName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblVideoName.Location = New System.Drawing.Point(270, 125)
        Me.lblVideoName.Name = "lblVideoName"
        Me.lblVideoName.Size = New System.Drawing.Size(287, 18)
        Me.lblVideoName.TabIndex = 338
        Me.lblVideoName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVideoName.TextWrap = False
        '
        'MyLabel5
        '
        Me.MyLabel5.FieldName = Nothing
        Me.MyLabel5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MyLabel5.Location = New System.Drawing.Point(28, 127)
        Me.MyLabel5.Name = "MyLabel5"
        Me.MyLabel5.Size = New System.Drawing.Size(69, 16)
        Me.MyLabel5.TabIndex = 339
        Me.MyLabel5.Text = "Video Name"
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
        'txtVideo
        '
        Me.txtVideo.CalculationExpression = Nothing
        Me.txtVideo.FieldCode = Nothing
        Me.txtVideo.FieldDesc = Nothing
        Me.txtVideo.FieldMaxLength = 0
        Me.txtVideo.FieldName = Nothing
        Me.txtVideo.isCalculatedField = False
        Me.txtVideo.IsSourceFromTable = False
        Me.txtVideo.IsSourceFromValueList = False
        Me.txtVideo.IsUnique = False
        Me.txtVideo.Location = New System.Drawing.Point(125, 125)
        Me.txtVideo.MendatroryField = False
        Me.txtVideo.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVideo.MyLinkLable1 = Me.MyLabel5
        Me.txtVideo.MyLinkLable2 = Me.lblVideoName
        Me.txtVideo.MyReadOnly = False
        Me.txtVideo.MyShowMasterFormButton = False
        Me.txtVideo.Name = "txtVideo"
        Me.txtVideo.ReferenceFieldDesc = Nothing
        Me.txtVideo.ReferenceFieldName = Nothing
        Me.txtVideo.ReferenceTableName = Nothing
        Me.txtVideo.Size = New System.Drawing.Size(143, 19)
        Me.txtVideo.TabIndex = 337
        Me.txtVideo.Value = ""
        '
        'btnreset1
        '
        Me.btnreset1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnreset1.Location = New System.Drawing.Point(392, 17)
        Me.btnreset1.Name = "btnreset1"
        Me.btnreset1.Size = New System.Drawing.Size(20, 20)
        Me.btnreset1.TabIndex = 339
        Me.btnreset1.Text = "N"
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
        Me.RadGroupBox8.Location = New System.Drawing.Point(28, 172)
        Me.RadGroupBox8.Name = "RadGroupBox8"
        Me.RadGroupBox8.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox8.Size = New System.Drawing.Size(739, 260)
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
        Me.gv1.Size = New System.Drawing.Size(719, 220)
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
        'lblAudioVideo
        '
        Me.lblAudioVideo.AutoSize = False
        Me.lblAudioVideo.BorderVisible = True
        Me.lblAudioVideo.FieldName = Nothing
        Me.lblAudioVideo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblAudioVideo.Location = New System.Drawing.Point(270, 103)
        Me.lblAudioVideo.Name = "lblAudioVideo"
        Me.lblAudioVideo.Size = New System.Drawing.Size(287, 18)
        Me.lblAudioVideo.TabIndex = 335
        Me.lblAudioVideo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAudioVideo.TextWrap = False
        '
        'MyLabel3
        '
        Me.MyLabel3.FieldName = Nothing
        Me.MyLabel3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MyLabel3.Location = New System.Drawing.Point(28, 105)
        Me.MyLabel3.Name = "MyLabel3"
        Me.MyLabel3.Size = New System.Drawing.Size(69, 16)
        Me.MyLabel3.TabIndex = 336
        Me.MyLabel3.Text = "Audio Name"
        '
        'txtAV
        '
        Me.txtAV.CalculationExpression = Nothing
        Me.txtAV.FieldCode = Nothing
        Me.txtAV.FieldDesc = Nothing
        Me.txtAV.FieldMaxLength = 0
        Me.txtAV.FieldName = Nothing
        Me.txtAV.isCalculatedField = False
        Me.txtAV.IsSourceFromTable = False
        Me.txtAV.IsSourceFromValueList = False
        Me.txtAV.IsUnique = False
        Me.txtAV.Location = New System.Drawing.Point(125, 103)
        Me.txtAV.MendatroryField = False
        Me.txtAV.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAV.MyLinkLable1 = Me.MyLabel3
        Me.txtAV.MyLinkLable2 = Me.lblAudioVideo
        Me.txtAV.MyReadOnly = False
        Me.txtAV.MyShowMasterFormButton = False
        Me.txtAV.Name = "txtAV"
        Me.txtAV.ReferenceFieldDesc = Nothing
        Me.txtAV.ReferenceFieldName = Nothing
        Me.txtAV.ReferenceTableName = Nothing
        Me.txtAV.Size = New System.Drawing.Size(143, 19)
        Me.txtAV.TabIndex = 334
        Me.txtAV.Value = ""
        '
        'lblExamName
        '
        Me.lblExamName.AutoSize = False
        Me.lblExamName.BorderVisible = True
        Me.lblExamName.FieldName = Nothing
        Me.lblExamName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblExamName.Location = New System.Drawing.Point(270, 82)
        Me.lblExamName.Name = "lblExamName"
        Me.lblExamName.Size = New System.Drawing.Size(287, 18)
        Me.lblExamName.TabIndex = 332
        Me.lblExamName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblExamName.TextWrap = False
        '
        'MyLabel4
        '
        Me.MyLabel4.FieldName = Nothing
        Me.MyLabel4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MyLabel4.Location = New System.Drawing.Point(28, 84)
        Me.MyLabel4.Name = "MyLabel4"
        Me.MyLabel4.Size = New System.Drawing.Size(68, 16)
        Me.MyLabel4.TabIndex = 333
        Me.MyLabel4.Text = "Exam Name"
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
        Me.txtExam.Location = New System.Drawing.Point(125, 82)
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
        Me.lblSubject.Location = New System.Drawing.Point(270, 61)
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
        Me.MyLabel2.Location = New System.Drawing.Point(28, 63)
        Me.MyLabel2.Name = "MyLabel2"
        Me.MyLabel2.Size = New System.Drawing.Size(77, 16)
        Me.MyLabel2.TabIndex = 330
        Me.MyLabel2.Text = "Subject Name"
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
        Me.txtSubject.Location = New System.Drawing.Point(125, 61)
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
        'lblSection
        '
        Me.lblSection.AutoSize = False
        Me.lblSection.BorderVisible = True
        Me.lblSection.FieldName = Nothing
        Me.lblSection.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblSection.Location = New System.Drawing.Point(270, 40)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(287, 18)
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
        Me.RadLabel18.Size = New System.Drawing.Size(77, 16)
        Me.RadLabel18.TabIndex = 327
        Me.RadLabel18.Text = "Section Name"
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
        Me.txtsSection.Size = New System.Drawing.Size(143, 19)
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
        Me.RadButton1.Location = New System.Drawing.Point(169, 2)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(71, 22)
        Me.RadButton1.TabIndex = 340
        Me.RadButton1.Text = "Reset"
        '
        'btnPost
        '
        Me.btnPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPost.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(92, 2)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(71, 22)
        Me.btnPost.TabIndex = 339
        Me.btnPost.Text = "Post"
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
        'lblComprehension
        '
        Me.lblComprehension.AutoSize = False
        Me.lblComprehension.BorderVisible = True
        Me.lblComprehension.FieldName = Nothing
        Me.lblComprehension.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblComprehension.Location = New System.Drawing.Point(270, 146)
        Me.lblComprehension.Name = "lblComprehension"
        Me.lblComprehension.Size = New System.Drawing.Size(287, 18)
        Me.lblComprehension.TabIndex = 343
        Me.lblComprehension.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblComprehension.TextWrap = False
        '
        'MyLabel6
        '
        Me.MyLabel6.FieldName = Nothing
        Me.MyLabel6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.MyLabel6.Location = New System.Drawing.Point(28, 148)
        Me.MyLabel6.Name = "MyLabel6"
        Me.MyLabel6.Size = New System.Drawing.Size(86, 16)
        Me.MyLabel6.TabIndex = 344
        Me.MyLabel6.Text = "Comprehension"
        '
        'txtComprehension
        '
        Me.txtComprehension.CalculationExpression = Nothing
        Me.txtComprehension.FieldCode = Nothing
        Me.txtComprehension.FieldDesc = Nothing
        Me.txtComprehension.FieldMaxLength = 0
        Me.txtComprehension.FieldName = Nothing
        Me.txtComprehension.isCalculatedField = False
        Me.txtComprehension.IsSourceFromTable = False
        Me.txtComprehension.IsSourceFromValueList = False
        Me.txtComprehension.IsUnique = False
        Me.txtComprehension.Location = New System.Drawing.Point(125, 146)
        Me.txtComprehension.MendatroryField = False
        Me.txtComprehension.MyFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprehension.MyLinkLable1 = Me.MyLabel6
        Me.txtComprehension.MyLinkLable2 = Me.lblComprehension
        Me.txtComprehension.MyReadOnly = False
        Me.txtComprehension.MyShowMasterFormButton = False
        Me.txtComprehension.Name = "txtComprehension"
        Me.txtComprehension.ReferenceFieldDesc = Nothing
        Me.txtComprehension.ReferenceFieldName = Nothing
        Me.txtComprehension.ReferenceTableName = Nothing
        Me.txtComprehension.Size = New System.Drawing.Size(143, 19)
        Me.txtComprehension.TabIndex = 342
        Me.txtComprehension.Value = ""
        '
        'frmExamSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 504)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmExamSet"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Exam Setting"
        CType(Me.SplitPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.lblVideoName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnreset1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox8.ResumeLayout(False)
        CType(Me.gv1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAudioVideo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblExamName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblComprehension, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitPanel1 As Telerik.WinControls.UI.SplitPanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadGroupBox8 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblAudioVideo As common.Controls.MyLabel
    Friend WithEvents MyLabel3 As common.Controls.MyLabel
    Friend WithEvents txtAV As common.UserControls.txtFinder
    Friend WithEvents lblExamName As common.Controls.MyLabel
    Friend WithEvents MyLabel4 As common.Controls.MyLabel
    Friend WithEvents txtExam As common.UserControls.txtFinder
    Friend WithEvents lblSubject As common.Controls.MyLabel
    Friend WithEvents MyLabel2 As common.Controls.MyLabel
    Friend WithEvents txtSubject As common.UserControls.txtFinder
    Friend WithEvents lblSection As common.Controls.MyLabel
    Friend WithEvents RadLabel18 As common.Controls.MyLabel
    Friend WithEvents txtsSection As common.UserControls.txtFinder
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPost As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnGo As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtDocNo As common.UserControls.txtNavigator
    Friend WithEvents btnreset1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gv1 As common.UserControls.MyRadGridView
    Friend WithEvents lblVideoName As common.Controls.MyLabel
    Friend WithEvents MyLabel5 As common.Controls.MyLabel
    Friend WithEvents txtVideo As common.UserControls.txtFinder
    Friend WithEvents lblComprehension As common.Controls.MyLabel
    Friend WithEvents MyLabel6 As common.Controls.MyLabel
    Friend WithEvents txtComprehension As common.UserControls.txtFinder
End Class

