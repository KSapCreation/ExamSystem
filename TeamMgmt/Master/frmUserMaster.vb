Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Threading
Imports System.Data.Sql
Imports common
Public Class FrmUserMaster
    Inherits FrmMainTranScreen
    Const colUserCode As String = "User Code"
    Const colUserName As String = "User Name"
    Const colClientCode As String = "Client Code"
    Const colClientName As String = "Client Name"
    Const colStatus As String = "Status"
    Private isNewEntry As Boolean = False
    Private isInsideLoadData As Boolean = False
    Private Sub FrmUserMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadType()
        LoadUserType()
        AddNew()
    End Sub
    Private Sub AddNew()
        txtUserCode.Value = ""
        txtUserCode.MyReadOnly = False
        txtUserName.Text = ""
        txtPasswordUser.Text = ""
        txtClient.Value = ""
        lblClient.Text = ""
        txtEmailId.Text = ""
        txtPhone.Text = ""
        txtUserType.Text = "Select"
        gv.DataSource = Nothing
        LoadBlankGrid()
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtUserCode.Focus()
        gv.DataSource = Nothing
        FillProjectInGrid()
        txtUserGroup.Value = ""
        lblUserGroup.Text = ""
    End Sub
    Sub LoadType()
        cboType.DataSource = clsUserMaster.LoadType()
        cboType.ValueMember = "Code"
        cboType.DisplayMember = "Name"
    End Sub

    Sub LoadUserType()
        txtUserType.DataSource = clsUserMaster.LoadUserType()
        txtUserType.ValueMember = "Code"
        txtUserType.DisplayMember = "Name"
    End Sub

    Sub LoadBlankGrid()
       
        gv.Rows.Clear()
        gv.Columns.Clear()

        Dim User_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        User_Code.FormatString = ""
        User_Code.HeaderText = "User Code"
        User_Code.Name = colUserCode
        User_Code.Width = 120
        User_Code.ReadOnly = True
        gv.MasterTemplate.Columns.Add(User_Code)

        Dim User_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        User_Name.FormatString = ""
        User_Name.HeaderText = "User Name"
        User_Name.Name = colUserName
        User_Name.Width = 150
        User_Name.ReadOnly = True
        gv.MasterTemplate.Columns.Add(User_Name)

        'Dim Client_Code As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        'Client_Code.FormatString = ""
        'Client_Code.HeaderText = "Client Code"
        'Client_Code.Name = colClientCode
        'Client_Code.Width = 150
        'Client_Code.ReadOnly = True
        'gv.MasterTemplate.Columns.Add(Client_Code)

        'Dim Client_Name As GridViewTextBoxColumn = New GridViewTextBoxColumn()
        'Client_Name.FormatString = ""
        'Client_Name.HeaderText = "Client Name"
        'Client_Name.Name = colClientName
        'Client_Name.Width = 150
        'Client_Name.ReadOnly = True
        'gv.MasterTemplate.Columns.Add(Client_Name)


        Dim Project_Status As GridViewCheckBoxColumn = New GridViewCheckBoxColumn()
        Project_Status.FormatString = ""
        Project_Status.HeaderText = "Status"
        Project_Status.Name = colStatus
        Project_Status.Width = 70
        Project_Status.ReadOnly = False
        gv.MasterTemplate.Columns.Add(Project_Status)

        gv.AllowAddNewRow = False
        gv.ShowGroupPanel = False
        gv.AllowColumnReorder = False
        gv.AllowRowReorder = False
        gv.EnableSorting = False
        gv.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        gv.MasterTemplate.ShowRowHeaderColumn = False
    End Sub

    Sub FillProjectInGrid()
        Dim dt As DataTable
        Dim qry As String = "select TSPL_USER_MASTER.USER_CODE,TSPL_USER_MASTER.[USER_NAME],TSPL_USER_MASTER.CLIENT_CODE,TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION from TSPL_USER_MASTER left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE = TSPL_USER_MASTER.CLIENT_CODE where TSPL_USER_MASTER.TYPE= 'Internal'"
        dt = clsDBFuncationality.GetDataTable(qry)
        If dt.Rows.Count > 0 Then
            gv.DataSource = Nothing
            For Each dr As DataRow In dt.Rows
                gv.Rows.AddNew()
                gv.Rows(gv.Rows.Count - 1).Cells(colUserCode).Value = clsCommon.myCstr(dr("USER_CODE"))
                gv.Rows(gv.Rows.Count - 1).Cells(colUserName).Value = clsCommon.myCstr(dr("USER_NAME"))
                'gv.Rows(gv.Rows.Count - 1).Cells(colClientCode).Value = clsCommon.myCstr(dr("CLIENT_CODE"))
                'gv.Rows(gv.Rows.Count - 1).Cells(colClientName).Value = clsCommon.myCstr(dr("CLIENT_DESCRIPTION"))
            Next
        End If
    End Sub

    Sub FillProjectInGrid2(ByVal strUserCode As String)
        Dim dt As DataTable
        Dim qry As String = "select TSPL_USER_MASTER.USER_CODE,TSPL_USER_MASTER.[USER_NAME],TSPL_USER_MASTER.CLIENT_CODE,TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION from TSPL_USER_MASTER left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE = TSPL_USER_MASTER.CLIENT_CODE where TSPL_USER_MASTER.TYPE= 'Internal' and TSPL_USER_MASTER.USER_CODE <> '" + strUserCode + "' "
        dt = clsDBFuncationality.GetDataTable(qry)
        gv.Rows.Clear()
        gv.DataSource = Nothing
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                gv.Rows.AddNew()
                gv.Rows(gv.Rows.Count - 1).Cells(colUserCode).Value = clsCommon.myCstr(dr("USER_CODE"))
                gv.Rows(gv.Rows.Count - 1).Cells(colUserName).Value = clsCommon.myCstr(dr("USER_NAME"))
                'gv.Rows(gv.Rows.Count - 1).Cells(colClientCode).Value = clsCommon.myCstr(dr("CLIENT_CODE"))
                'gv.Rows(gv.Rows.Count - 1).Cells(colClientName).Value = clsCommon.myCstr(dr("CLIENT_DESCRIPTION"))
            Next
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Sub SaveData()
        Try
            If (AllowToSave()) Then
                Dim obj As New clsUserMaster()
                obj.USER_CODE = txtUserCode.Value
                obj.USER_NAME = txtUserName.Text
                obj.PASSWORD = txtPasswordUser.Text
                obj.TYPE = cboType.Text
                obj.CLIENT_CODE = txtClient.Value
                obj.USER_GROUP_CODE = txtUserGroup.Value
                obj.EMAIL = txtEmailId.Text
                obj.PHONE = txtPhone.Text
                obj.USER_TYPE = txtUserType.Text

                Dim Arr As New List(Of clsMappingUserDetail)
                For Each grow As GridViewRowInfo In gv.Rows
                    Dim objTr As New clsMappingUserDetail()
                    objTr.MAPPING_USER_CODE = clsCommon.myCstr(grow.Cells(colUserCode).Value)
                    Dim strStatus As Boolean = clsCommon.myCBool(grow.Cells(colStatus).Value)
                    If strStatus Then
                        Arr.Add(objTr)
                    End If
                Next

                'If (Arr Is Nothing OrElse Arr.Count <= 0) Then
                '    common.clsCommon.MyMessageBoxShow("Please select at least one Project")
                '    Return
                'End If
                Dim ChkNewEntry As String = clsDBFuncationality.getSingleValue("select  count(*) from  TSPL_USER_MASTER where USER_CODE='" & obj.USER_CODE & "'")
                If ChkNewEntry > 0 Then
                    isNewEntry = False
                Else
                    isNewEntry = True
                End If
                If (obj.SaveData(obj, isNewEntry, Arr)) Then
                    clsCommon.MyMessageBoxShow("Data saved Successfully", Me.Text)
                    LoadData(obj.USER_CODE)
                    btnSave.Text = "Update"
                    btnDelete.Enabled = True
                End If
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub

    Function AllowToSave() As Boolean
        Try

            If clsCommon.myLen(txtUserCode.Value) <= 0 Then
                common.clsCommon.MyMessageBoxShow("User Code can not be blank.")
                txtUserCode.Focus()
                Return False
            End If
            If clsCommon.myLen(txtUserName.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("User Name can not be blank.")
                txtUserName.Focus()
                Return False
            End If

            If clsCommon.myLen(txtPasswordUser.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Password can not be blank.")
                txtPasswordUser.Focus()
                Return False
            End If

            If clsCommon.myLen(cboType.Text) <= 0 Then
                common.clsCommon.MyMessageBoxShow("Type can not be blank.")
                cboType.Focus()
                Return False
            End If

            If clsCommon.myLen(txtUserType.Text) <= 0 Or clsCommon.CompairString(txtUserType.Text, "Select") = CompairStringResult.Equal Then
                common.clsCommon.MyMessageBoxShow("Please select user type.")
                txtUserType.Focus()
                Return False
            End If

        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
            Return False
        End Try
        Return True
    End Function

    Sub LoadData(ByVal strUserCode As String)
        Try
            AddNew()
            isInsideLoadData = True
            Dim obj As clsUserMaster = clsUserMaster.GetData(strUserCode, Nothing)
            isNewEntry = False
            If obj IsNot Nothing Then
                txtUserCode.Value = obj.USER_CODE
                txtUserName.Text = obj.USER_NAME
                txtPasswordUser.Text = obj.PASSWORD
                cboType.Text = obj.TYPE
                txtClient.Value = obj.CLIENT_CODE
                lblClient.Text = obj.CLIENT_NAME
                txtUserGroup.Value = obj.USER_GROUP_CODE
                lblUserGroup.Text = obj.USER_GROUP_NAME
                txtEmailId.Text = obj.EMAIL
                txtPhone.Text = obj.PHONE
                txtUserType.Text = obj.USER_TYPE
                FillProjectInGrid2(obj.USER_CODE)
                Dim count As Integer = clsDBFuncationality.getSingleValue(" select count(*) from TSPL_MAPPING_USER_DETAIL where  USER_CODE ='" + txtUserCode.Value + "' ")
                If count > 0 Then
                    For Each objtr As clsMappingUserDetail In obj.Arr
                        For ii As Integer = 0 To gv.Rows.Count - 1
                            If clsCommon.myCstr(gv.Rows(ii).Cells(colUserCode).Value) = objtr.MAPPING_USER_CODE Then
                                gv.Rows(ii).Cells(colStatus).Value = 1
                            End If
                        Next
                    Next
                End If
                isInsideLoadData = False
                txtUserCode.MyReadOnly = True
                btnSave.Text = "Update"
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message, Me.Text)
        End Try

    End Sub

    Private Sub btnreset1_Click(sender As Object, e As EventArgs) Handles btnreset1.Click
        AddNew()
    End Sub

    Private Sub txtUserCode__MYNavigator(sender As Object, e As EventArgs, NavType As NavigatorType) Handles txtUserCode._MYNavigator
        Dim WhrCls As String = ""

        Dim qry As String = "select USER_CODE  from TSPL_USER_MASTER  Where 2=2  "
        Select Case NavType
            Case NavigatorType.First
                qry += " and TSPL_USER_MASTER.USER_CODE=(select MIN(USER_CODE) from TSPL_USER_MASTER)"
            Case NavigatorType.Last
                qry += " and TSPL_USER_MASTER.USER_CODE=(select MAX(USER_CODE) from TSPL_USER_MASTER)"
            Case NavigatorType.Next
                qry += " and TSPL_USER_MASTER.USER_CODE=(select Min(USER_CODE) from TSPL_USER_MASTER where USER_CODE > '" + txtUserCode.Value + "')"
            Case NavigatorType.Previous
                qry += " and TSPL_USER_MASTER.USER_CODE=(select Max(USER_CODE) from TSPL_USER_MASTER where USER_CODE < '" + txtUserCode.Value + "')"
            Case NavigatorType.Current
                qry += " and TSPL_USER_MASTER.USER_CODE='" + txtUserCode.Value + "'"
        End Select

        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            txtUserCode.Value = clsCommon.myCstr(dt.Rows(0)("USER_CODE"))
        End If
        LoadData(txtUserCode.Value)
    End Sub

    Private Sub txtUserCode__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtUserCode._MYValidating
        Dim str As String = "select count(*) from TSPL_USER_MASTER where USER_CODE = '" + txtUserCode.Value + "' "
        Dim no As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(str))
        If no = 0 AndAlso isButtonClicked = False Then
            txtUserCode.MyReadOnly = False
        Else
            txtUserCode.MyReadOnly = True
        End If

        If txtUserCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String = ""
            qry = " select USER_CODE as Code,USER_NAME as Name ,TYPE,CLIENT_CODE,USER_GROUP_CODE,EMAIL,PHONE  from TSPL_USER_MASTER "
            txtUserCode.Value = clsCommon.ShowSelectForm("TSPL_USER_MASTER", qry, "Code", "", txtUserCode.Value, "TSPL_USER_MASTER.USER_CODE", isButtonClicked)
            If clsCommon.myLen(txtUserCode.Value) > 0 Then
                LoadData(txtUserCode.Value)
            Else
                AddNew()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If myMessages.deleteConfirm() Then
            deleteData()
        End If
    End Sub

    Sub deleteData()
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            If clsCommon.myLen(txtUserCode.Value) > 0 Then

                If clsUserMaster.deleteData(txtUserCode.Value, trans) Then
                    myMessages.delete()

                    trans.Commit()
                    AddNew()
                Else
                    clsCommon.MyMessageBoxShow("Can't delete the record")
                    trans.Rollback()
                End If
            Else

                clsCommon.MyMessageBoxShow("Please Select a User Code to delete")
                trans.Rollback()
            End If
        Catch ex As Exception
            clsCommon.MyMessageBoxShow(ex.Message)
            trans.Rollback()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        GC.Collect()
    End Sub

    Private Sub txtClient__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtClient._MYValidating
        Dim qry As String = "select CLIENT_CODE as Code,CLIENT_DESCRIPTION as Name ,VERTICAL from TSPL_CLIENT_MASTER "
        Dim WhrCls As String = String.Empty
        txtClient.Value = clsCommon.ShowSelectForm("CLIENT@CODE", qry, "Code", WhrCls, txtClient.Value, "Code", isButtonClicked)
        lblClient.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select CLIENT_DESCRIPTION from TSPL_CLIENT_MASTER where CLIENT_CODE='" + txtClient.Value + "'"))
    End Sub

    Private Sub txtUserGroup__MYValidating(sender As Object, e As EventArgs, isButtonClicked As Boolean) Handles txtUserGroup._MYValidating
        Dim qry As String = "select USER_GROUP_CODE as Code,GROUP_DESCRIPTION as Name from TSPL_USER_GROUP_MASTER "
        Dim WhrCls As String = String.Empty
        txtUserGroup.Value = clsCommon.ShowSelectForm("USER@GROUP", qry, "Code", WhrCls, txtUserGroup.Value, "Code", isButtonClicked)
        lblUserGroup.Text = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select GROUP_DESCRIPTION from TSPL_USER_GROUP_MASTER where USER_GROUP_CODE='" + txtUserGroup.Value + "'"))
    End Sub

    Private Sub rMenuExport_Click(sender As Object, e As EventArgs) Handles rMenuExport.Click
        'Dim str As String
        'str = " select TSPL_USER_MASTER.USER_CODE as [USER CODE], TSPL_USER_MASTER.USER_NAME as [USER NAME],TSPL_USER_MASTER.PASSWORD as [PASSWORD], TSPL_USER_MASTER.TYPE as [TYPE],isnull(TSPL_USER_MASTER.CLIENT_CODE,'') as [CLIENT CODE],TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION as [CLIENT NAME],isnull( TSPL_USER_MASTER.USER_GROUP_CODE,'') as [USER GROUP CODE] ,TSPL_USER_GROUP_MASTER.GROUP_DESCRIPTION as [USER GROUP DESCRIPTION],TSPL_USER_MASTER.EMAIL, TSPL_USER_MASTER.PHONE , isnull( TSPL_MAPPING_USER_DETAIL.MAPPING_USER_CODE,'') as [MAPPING USER CODE]   from TSPL_USER_MASTER left outer join TSPL_MAPPING_USER_DETAIL on TSPL_MAPPING_USER_DETAIL.USER_CODE =TSPL_USER_MASTER.USER_CODE left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE = TSPL_USER_MASTER.CLIENT_CODE left outer join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_USER_MASTER.USER_GROUP_CODE    "
        'transportSql.ExporttoExcel(str, Me)
        Dim str As String
        str = " select TSPL_USER_MASTER.USER_CODE as [USER CODE], TSPL_USER_MASTER.USER_NAME as [USER NAME],TSPL_USER_MASTER.PASSWORD as [PASSWORD], TSPL_USER_MASTER.TYPE as [TYPE],isnull(TSPL_USER_MASTER.CLIENT_CODE,'') as [CLIENT CODE],TSPL_CLIENT_MASTER.CLIENT_DESCRIPTION as [CLIENT NAME],isnull( TSPL_USER_MASTER.USER_TYPE,'') as [USER TYPE] ,TSPL_USER_MASTER.EMAIL, TSPL_USER_MASTER.PHONE , isnull( TSPL_MAPPING_USER_DETAIL.MAPPING_USER_CODE,'') as [MAPPING USER CODE]   from TSPL_USER_MASTER left outer join TSPL_MAPPING_USER_DETAIL on TSPL_MAPPING_USER_DETAIL.USER_CODE =TSPL_USER_MASTER.USER_CODE left outer join TSPL_CLIENT_MASTER on TSPL_CLIENT_MASTER.CLIENT_CODE = TSPL_USER_MASTER.CLIENT_CODE left outer join TSPL_USER_GROUP_MASTER on TSPL_USER_GROUP_MASTER.USER_GROUP_CODE = TSPL_USER_MASTER.USER_GROUP_CODE    "
        transportSql.ExporttoExcel(str, Me)
    End Sub

    Private Sub rMenuImport_Click(sender As Object, e As EventArgs) Handles rMenuImport.Click
        Dim gv As New RadGridView()
        Me.Controls.Add(gv)
        Dim isSaved As Boolean = True
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        If transportSql.importExcel(gv, "USER CODE", "USER NAME", "PASSWORD", "TYPE", "CLIENT CODE", "CLIENT NAME", "USER TYPE", "EMAIL", "PHONE", "MAPPING USER CODE") Then
            Dim linno As Integer = 1
            Try
                For Each grow As GridViewRowInfo In gv.Rows

                    Dim strUserCode As String = clsCommon.myCstr(grow.Cells("USER CODE").Value)
                    Dim strUserName As String = clsCommon.myCstr(grow.Cells("USER NAME").Value)
                    Dim strPassword As String = clsCommon.myCstr(grow.Cells("PASSWORD").Value)
                    Dim strType As String = clsCommon.myCstr(grow.Cells("TYPE").Value)
                    Dim strClientCode As String = clsCommon.myCstr(grow.Cells("CLIENT CODE").Value)
                    Dim strClientName As String = clsCommon.myCstr(grow.Cells("CLIENT NAME").Value)
                    Dim strUserType As String = clsCommon.myCstr(grow.Cells("USER TYPE").Value)
                    Dim strEmail As String = clsCommon.myCstr(grow.Cells("EMAIL").Value)
                    Dim strPhone As String = clsCommon.myCstr(grow.Cells("PHONE").Value)
                    Dim strMappingUserCode As String = clsCommon.myCstr(grow.Cells("MAPPING USER CODE").Value)

                    linno += 1
                    clsCommon.ProgressBarPercentUpdate((linno * 100) / gv.RowCount - 1, "Importing " + clsCommon.myCstr(linno) + "/" + clsCommon.myCstr(gv.RowCount - 1))
                    Dim coll As New Hashtable()
                    Dim coll2 As New Hashtable()
                    If clsCommon.myLen(strUserCode) <= 0 Then
                        Throw New Exception("User Code should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strUserCode) > 30 Then
                        Throw New Exception("Please check ! length of User Code should be 30 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "USER_CODE", strUserCode)
                    clsCommon.AddColumnsForChange(coll2, "USER_CODE", strUserCode)

                    If clsCommon.myLen(strUserName) <= 0 Then
                        Throw New Exception("Program User Name should not be left blank at line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strUserName) > 200 Then
                        Throw New Exception("Please check ! length of User Name should be 200 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "USER_NAME", strUserName)

                    If clsCommon.myLen(strPassword) <= 0 Then
                        Throw New Exception("Password should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    ElseIf clsCommon.myLen(strUserCode) > 50 Then
                        Throw New Exception("Please check ! length of Password should be maximum 50 at line no. " + clsCommon.myCstr(linno) + ".")
                    End If
                    clsCommon.AddColumnsForChange(coll, "PASSWORD", strPassword)

                    If clsCommon.CompairString(strType, "Internal") = CompairStringResult.Equal Or clsCommon.CompairString(strType, "I") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll, "TYPE", "Internal")
                    ElseIf clsCommon.CompairString(strType, "External") = CompairStringResult.Equal Or clsCommon.CompairString(strType, "E") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll, "TYPE", "External")
                    Else
                        Throw New Exception("Please Enter Type as 'Internal' Or 'I' Or 'External' Or 'E' at Line No '" + linno + "'")
                    End If

                    If clsCommon.myLen(strClientCode) > 0 Then
                        Dim chkClintCode As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(" select count(*) from TSPL_CLIENT_MASTER where CLIENT_CODE ='" + strClientCode + "' ", trans))
                        If chkClintCode <= 0 Then
                            Throw New Exception("Invalid Client Code line no. " + clsCommon.myCstr(linno) + ".")
                        End If
                    End If
                    clsCommon.AddColumnsForChange(coll, "CLIENT_CODE", strClientCode, True)

                    If clsCommon.myLen(strUserType) <= 0 Then
                        Throw New Exception("User Type should not be left blankat line no. " + clsCommon.myCstr(linno) + ".")
                    End If

                    If clsCommon.CompairString(strUserType, "Developer") = CompairStringResult.Equal Or clsCommon.CompairString(strUserType, "Tester") = CompairStringResult.Equal Or clsCommon.CompairString(strUserType, "Implementation") = CompairStringResult.Equal Or clsCommon.CompairString(strUserType, "Management") = CompairStringResult.Equal Or clsCommon.CompairString(strUserType, "Other") = CompairStringResult.Equal Then
                        clsCommon.AddColumnsForChange(coll, "USER_TYPE", strUserType)
                    Else
                        Throw New Exception("Please Enter User Type as 'Developer' Or  'Tester' Or 'Implementation' or 'Management' or 'Other'  at Line No '" + linno + "'")
                    End If


                    '"EMAIL", "PHONE", "MAPPING USER CODE"

                    If clsCommon.myLen(strEmail) > 0 Then
                        Dim check As Match = Regex.Match(strEmail, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                        If check.Success Then
                            clsCommon.AddColumnsForChange(coll, "EMAIL", strEmail)
                        Else
                            Throw New Exception("Please Enter the proper format of e-mail address line no. " + clsCommon.myCstr(linno) + ".")
                        End If
                    End If

                    If clsCommon.myLen(strPhone) > 0 Then
                        If clsCommon.myLen(strPhone) <> 10 Then
                            Throw New Exception("Phone No should be 10 digit line no. " + clsCommon.myCstr(linno) + ".")
                        End If
                    End If
                    clsCommon.AddColumnsForChange(coll, "PHONE", strPhone)

                    Dim strCreatedBy As String = clsCommon.myCstr(objCommonVar.CurrentUserCode)
                    Dim strCreatedDate As String = Nothing
                    strCreatedDate = clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MMM/yyyy")
                    Dim Count As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select Count(*) from TSPL_USER_MASTER Where USER_CODE='" + strUserCode + "'", trans))
                    clsCommon.AddColumnsForChange(coll, "Modify_By", strCreatedBy)
                    clsCommon.AddColumnsForChange(coll, "Modify_Date", strCreatedDate)
                    If Count <= 0 Then
                        clsCommon.AddColumnsForChange(coll, "Created_By", strCreatedBy)
                        clsCommon.AddColumnsForChange(coll, "Created_Date", strCreatedDate)
                    End If

                    If clsCommon.myLen(strMappingUserCode) > 0 Then
                        Dim chkMappingUserCode As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(" select count(*) from TSPL_USER_MASTER   left outer join  TSPL_MAPPING_USER_DETAIL on TSPL_MAPPING_USER_DETAIL .USER_CODE =TSPL_USER_MASTER.USER_CODE where  TSPL_USER_MASTER.TYPE= 'External' and TSPL_USER_MASTER.USER_CODE <> '" + strUserCode + "' ", trans))
                        If chkMappingUserCode > 0 Then
                            clsCommon.AddColumnsForChange(coll2, "MAPPING_USER_CODE", strMappingUserCode)
                        Else
                            Throw New Exception("Invalid Mapping User Code at Line No '" + linno + "'")
                        End If
                    End If

                    If Count <= 0 Then
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_MASTER", OMInsertOrUpdate.Insert, "", trans)
                    Else
                        isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "TSPL_USER_MASTER", OMInsertOrUpdate.Update, "USER_CODE='" + strUserCode + "'", trans)
                    End If
                    If clsCommon.myLen(strMappingUserCode) > 0 Then
                        Dim Count2 As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select Count(*) from TSPL_MAPPING_USER_DETAIL Where USER_CODE= '" + strUserCode + "' and MAPPING_USER_CODE='" + strMappingUserCode + "'", trans))
                        If Count <= 0 Then
                            isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_MAPPING_USER_DETAIL", OMInsertOrUpdate.Insert, "", trans)
                        Else
                            clsDBFuncationality.ExecuteNonQuery("delete TSPL_MAPPING_USER_DETAIL where  USER_CODE= '" + strUserCode + "' and MAPPING_USER_CODE='" + strMappingUserCode + "'", trans)
                            isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll2, "TSPL_MAPPING_USER_DETAIL", OMInsertOrUpdate.Insert, "", trans)
                        End If
                    End If

                Next
                If isSaved Then
                    trans.Commit()
                    clsCommon.ProgressBarPercentHide()
                    RadMessageBox.Show("Data Imported Successfully ...")
                Else
                    Throw New Exception("Error in Import")
                End If
            Catch ex As Exception
                trans.Rollback()
                clsCommon.ProgressBarPercentHide()
                RadMessageBox.Show(ex.Message)
            Finally
                Me.Controls.Remove(gv)

            End Try
        End If
        Me.Controls.Remove(gv)
    End Sub

    Private Sub rMenuExit_Click(sender As Object, e As EventArgs) Handles rMenuExit.Click
        Me.Close()
    End Sub

    Private Sub txtEmailId_Leave(sender As Object, e As EventArgs) Handles txtEmailId.Leave
        If txtEmailId.Text = "" Then
        Else
            Dim check As Match = Regex.Match(txtEmailId.Text, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            If check.Success Then
            Else
                common.clsCommon.MyMessageBoxShow("Please Enter the proper format of e-mail address")
                txtEmailId.Text = ""
                txtEmailId.Focus()
            End If
        End If
    End Sub
End Class
