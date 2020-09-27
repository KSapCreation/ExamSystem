Imports System.Data.SqlClient
Imports System.IO
Imports common
Imports Telerik.WinControls.UI
Imports System.Reflection

Public Class MDI
    Public frm
    Private Sub frmMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckConfigFile() Then
            SetConnectionWithCommonDLL("")
            clsCreateAllTables.CreateAllTable()
            clsFixedParameter.FixedParameterValues()
            ProgramCodeNew.SetProgramCode()
            SplitContainer1.Visible = False
        Else
            Me.Close()
        End If



    End Sub
    Function CheckConfigFile() As Boolean
        If Not File.Exists("config.Txp") Then
            Dim frm As New FrmServerConfig
            frm.ShowDialog()
            If Not File.Exists("config.Txp") Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SetConnectionWithCommonDLL(ByVal strDatabase As String)
        Try
            Dim line As String
            Dim objReader As New System.IO.StreamReader("config.Txp")
            Do While objReader.Peek() <> -1
                line = objReader.ReadLine()
                '-------------change the existing dbname with dbname comes from company master-BM00000003569------------
                Dim indexofhash As Integer = line.IndexOf("#")
                objCommonVar.Database_Server = line.Substring(0, indexofhash).Trim
                Dim reststr As String = line.Substring(indexofhash + 1, line.Length - indexofhash - 1)
                indexofhash = reststr.IndexOf("#")
                reststr = reststr.Substring(0, indexofhash)

                If clsCommon.myLen(objCommonVar.CurrDatabase) > 0 Then
                    line = line.Replace(reststr, "  " + objCommonVar.CurrDatabase + " ")
                Else
                    objCommonVar.CurrDatabase = reststr
                End If
                '--------------------------------------------------------------------------------------------
                clsDBFuncationality.SetConnectionEncryptFormat(line)
                objCommonVar.ConnString = clsDBFuncationality.connectionString


            Loop
            ''stuti regarding memory leakage
            objReader.Close()
            objReader.Dispose()
            connectSql.strConn = clsDBFuncationality.connectionString
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub


    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        CheckAndLogin()
    End Sub
    Sub CheckAndLogin()
        If clsCommon.myLen(txtUserName.Text) <= 0 Then
            clsCommon.MyMessageBoxShow("Please Enter " + txtUserName.MyLinkLable1.Text, Me.Text)
            txtUserName.Focus()
            Exit Sub
        End If

        If clsCommon.myLen(txtPassword.Text) <= 0 Then
            clsCommon.MyMessageBoxShow("Please Enter " + txtPassword.MyLinkLable1.Text, Me.Text)
            txtPassword.Focus()
            Exit Sub
        End If
        If clsCommon.CompairString(txtUserName.Text, "admin") = CompairStringResult.Equal AndAlso clsCommon.CompairString(txtPassword.Text, "admin") = CompairStringResult.Equal Then
            SplitContainer1.Visible = True
            LoadWorkingScreen()
        End If

        'Dim qry As String = "select TSPL_USER_MASTER.password,TSPL_USER_MASTER.User_Code,TSPL_USER_MASTER.User_Name,TSPL_USER_MASTER.Level, ApprovalLevel,ExpiryDate,TSPL_USER_MASTER.IP_Address,TSPL_USER_MASTER.Login_Status from TSPL_USER_MASTER where TSPL_USER_MASTER.User_Code='" + txtUserName.Text + "' "
        'Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

        'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        '    Dim Pwd As String = clsCommon.myCstr(dt.Rows(0)("password"))
        '    If Not clsCommon.CompairString(Pwd, clsCommon.EncryptString(txtPassword.Text)) = CompairStringResult.Equal Then
        '        If clsCommon.CompairString("developer", txtPassword.Text, True) = CompairStringResult.Equal Then
        '            common.clsCommon.MyMessageBoxShow("Correct Password is: " & clsCommon.DecryptString(Pwd), Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
        '        Else
        '            common.clsCommon.MyMessageBoxShow("Please enter Correct User ID and Password ", Me.Text, MessageBoxButtons.OK, RadMessageIcon.Error)
        '        End If
        '        Exit Sub
        '    Else
        '        LoadWorkingScreen()
        '    End If
        'Else
        '    If clsCommon.CompairString(txtUserName.Text, "admin") = CompairStringResult.Equal AndAlso clsCommon.CompairString(txtPassword.Text, "admin") = CompairStringResult.Equal Then
        '        LoadWorkingScreen()
        '    End If
        'End If
    End Sub

    Sub LoadWorkingScreen()
        RTV2.Visible = True
        LoadMenu()
        'LoadMenuInCombo()
    End Sub
    Public Sub LoadMenu()
        Try

            Dim qry As String = "select distinct tt.* from (select sno AS [SERNO],Program_Code,Name,Parent_Code from (" + Environment.NewLine '"select Program_Code,Name,Parent_Code from (" + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where 2=2 and  Parent_Code is null " + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where 2=2 and  Type In ('SM') and Program_Code in (select distinct Parent_Code from TSPL_PROGRAM_MASTER where 2=2  )" + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where 2=2 and  Type In ('M') and Program_Code in (select distinct Parent_Code from TSPL_PROGRAM_MASTER where Program_Code in (select distinct Parent_Code from TSPL_PROGRAM_MASTER where 2=2 ))" + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER " + Environment.NewLine
            qry += " where Program_Code='" + clsUserMgtCode.ModuleFavourite + "' " + Environment.NewLine
            qry += " union " + Environment.NewLine
            qry += " select Program_Code,case when LEN(isnull(Re_Name,''))>0 then Re_Name else Program_Name end as Name,Parent_Code,SNo from TSPL_PROGRAM_MASTER where 2=2 " + Environment.NewLine
            qry += " union all " + Environment.NewLine
            qry += " select TSPL_FAVOURITE_MENU.Program_Code,case when LEN(isnull(TSPL_PROGRAM_MASTER.Re_Name,''))>0 then TSPL_PROGRAM_MASTER.Re_Name else TSPL_PROGRAM_MASTER.Program_Name end as Name,'" + clsUserMgtCode.ModuleFavourite + "' as Parent_Code,TSPL_FAVOURITE_MENU.SNo from TSPL_FAVOURITE_MENU " + Environment.NewLine
            qry += " left outer join  TSPL_PROGRAM_MASTER on TSPL_PROGRAM_MASTER.Program_Code= TSPL_FAVOURITE_MENU.Program_Code  where 2=2 and TSPL_FAVOURITE_MENU.User_Code='" + objCommonVar.CurrentUserCode + "' " + Environment.NewLine
            qry += " )xxx where 2=2 "
            qry += ") tt  " _
            & "  order by SERNO" '" order by SNo"
            '============================================
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)


            RTV2.DataSource = Nothing
            RTV2.TreeViewElement.AutoSizeItems = True
            RTV2.ShowLines = True
            RTV2.ShowRootLines = True
            RTV2.TreeViewElement.ViewElement.Margin = New Padding(4)
            RTV2.ShowExpandCollapse = True
            RTV2.TreeIndent = 15
            RTV2.FullRowSelect = False
            RTV2.ShowLines = True
            RTV2.LineStyle = TreeLineStyle.Dot
            RTV2.LineColor = Color.FromArgb(110, 153, 210)
            RTV2.ExpandAnimation = ExpandAnimation.Opacity
            RTV2.AllowEdit = False
            RTV2.ShowRootLines = False
            'RTV2.TreeViewElement.AllowAlternatingRowColor = True
            'RTV2.TreeViewElement.AlternatingRowColor = Color.AliceBlue
            'RTV2.TreeViewElement.AngleTransform = 270
            'RTV2.TreeViewElement.RightToLeft = True
            'RTV2.TreeViewElement.DrawBorder = True
            RTV2.ValueMember = "Program_Code"
            RTV2.DisplayMember = "Name"
            RTV2.ChildMember = "Program_Code"
            RTV2.ParentMember = "Parent_Code"
            RTV2.DataSource = dt

            'LoadMenuInCombo()
            ' Set Image
            'For i As Integer = 0 To RTV2.Nodes.Count - 1
            '    SetImage(RTV2.Nodes(i))
            'Next
            RTV2.Nodes.Add("")
            RTV2.Nodes.Add("")
            RTV2.Nodes.Add("")
            RTV2.AllowEdit = False
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

        RTV2.CollapseAll()
        If RTV2.Nodes.Count > 0 Then
            RTV2.Nodes(0).Expand()
        End If

    End Sub

    Private Sub RTV2_NodeMouseDoubleClick(sender As Object, e As RadTreeViewEventArgs) Handles RTV2.NodeMouseDoubleClick
        Try
            Dim strCode As String = clsCommon.myCstr(RTV2.SelectedNode.Value)
            If clsCommon.myLen(strCode) > 0 Then
                ShowForm(strCode, RTV2.SelectedNode.Text, True)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ShowForm(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal isOpenInMDI As Boolean)
        ShowForm(strProgramCode, strProgramName, isOpenInMDI, "")
    End Sub

    Public Sub ShowForm(ByVal strProgramCode As String, ByVal strProgramName As String, ByVal isOpenInMDI As Boolean, ByVal strDocNo As String, Optional ByVal IFTrueShowFormElseShowDialog As Boolean = True, Optional ByVal IsAllowModificationByApprovalUser As Boolean = False)
        GC.Collect()

        If Not strProgramCode Is Nothing Then
            strProgramName = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select case when LEN(ISNULL(Re_Name,''))>0 then Re_Name else Program_Name end as Program_Name from TSPL_PROGRAM_MASTER where Program_Code='" + strProgramCode + "'"))

            Dim qry As String = " select * from tspl_Program_master where Program_code='" & strProgramCode & "'"

            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim IsRunFromOtherAsm As Integer = clsCommon.myCdbl(dt.Rows(0)("IsLoadFromOtherAssembly"))
                If IsRunFromOtherAsm = 1 Then
                    Dim FormName As String = clsCommon.myCstr(dt.Rows(0)("FormName"))
                    Dim AsmName As String = clsCommon.myCstr(Application.StartupPath & "\" & dt.Rows(0)("OtherAssemblyFilePathAndName"))
                    Dim AsmToLoad As Assembly = Nothing
                    Dim obj As Object = Nothing
                    AsmToLoad = Assembly.LoadFile(AsmName)
                    Dim classType As Type = AsmToLoad.[GetType](FormName)

                    obj = AsmToLoad.CreateInstance(FormName, True)
                    Dim frm As RadForm = TryCast(obj, RadForm)
                    If isOpenInMDI Then
                        frm.MdiParent = Me
                        frm.Text = strProgramName
                        frm.Show()
                    Else
                        If clsCommon.myLen(strDocNo) > 0 Then
                            frm.Tag = strDocNo
                        End If
                        frm.WindowState = FormWindowState.Maximized
                        frm.Text = strProgramName
                        frm.ShowDialog()

                    End If
                    Exit Sub
                End If
            End If

            If clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmProjectMaster) = CompairStringResult.Equal Then
                frm = New FrmProjectMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmClientMaster) = CompairStringResult.Equal Then
                frm = New FrmClientMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.frmModuleMaster) = CompairStringResult.Equal Then
                frm = New FrmModuleMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmScreenMaster) = CompairStringResult.Equal Then
                frm = New FrmScreenMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmUserGroupMaster) = CompairStringResult.Equal Then
                frm = New FrmUserGroupMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmGroupProgramMapping) = CompairStringResult.Equal Then
                frm = New FrmGroupProgramMapping
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            ElseIf clsCommon.CompairString(strProgramCode, clsUserMgtCode.FrmUserMaster) = CompairStringResult.Equal Then
                frm = New FrmUserMaster
                formShow(frm, strProgramCode, strProgramName, isOpenInMDI, strDocNo, IFTrueShowFormElseShowDialog)
            End If

        End If
        frm = Nothing
    End Sub

    Public Sub formShow(ByVal frm As FrmMainTranScreen, ByVal strProgramCode As String, ByVal strProgramName As String, ByVal isOpenInMDI As Boolean, ByVal strDocNo As String, Optional ByVal IFTrueShowFormElseShowDialog As Boolean = True)
        Try
            frm.Tag = strDocNo
            frm.Text = strProgramName
            ' frm.SetUserMgmt(strProgramCode)

            If IFTrueShowFormElseShowDialog Then
                If isOpenInMDI Then
                    frm.MdiParent = Me
                Else
                    frm.WindowState = FormWindowState.Maximized
                End If
                frm.Focus()
                frm.Show()
                'SplitContainer1.Visible = False
                'pnlLogin.Visible = False
                frm.WindowState = FormWindowState.Maximized
                frm.Show()

                SplitContainer1.Panel2.Controls.Add(frm)
                'If isApplicationRun Then
                '    isApplicationRun = False
                '    'frm.WindowState = FormWindowState.Maximized
                '    Application.Run(frm)
                'Else
                '    'frm.WindowState = FormWindowState.Maximized
                '    frm.Show()
                'End If
            Else
                frm.ShowDialog(Me)
                frm.TopMost = True


            End If
        Catch ex As Exception
            If Not ex.Message.Contains("Object reference not set to an instance of an object.") Then ''becuase when need to close the form this message come.
                common.clsCommon.MyMessageBoxShow(ex.Message)
                frm.Close()
            End If
        End Try
    End Sub

   
End Class
