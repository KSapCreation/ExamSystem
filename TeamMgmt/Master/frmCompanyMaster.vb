
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports Telerik.WinControls.Data
Imports Telerik.Data
Imports Telerik.WinControls.Enumerations
Imports System.Text.RegularExpressions
Imports common
Imports System.IO


Public Class FrmCompanyMaster
    Inherits FrmMainTranScreen

    Dim ButtonToolTip As ToolTip = New ToolTip()
    Dim userCode, companyCode As String

   
#Region "Variables"
    Dim sql As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim isInsideLoadData As Boolean = False
    Dim strRemarks As String = Nothing
    Dim IsModifyOnPwd As Boolean = False
    Dim AllowGSTApplicable As Boolean = False
    Dim isNewEntry As Boolean = False
#End Region

#Region "keyPress Event"
    'Private Sub txtCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress
    '    If IsNumeric(e.KeyChar) = True Then
    '        e.Handled = False
    '    ElseIf Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub
    Private Sub fndCompanyCode_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Microsoft.VisualBasic.Asc(e.KeyChar) = 39 Then
            e.Handled = True
        End If

    End Sub
#End Region

#Region "Page Load"
    Public Sub SetLength()
        fndCompanyCode.MyMaxLength = 8
        txtCompanyName.MaxLength = 100
        txtAdd1.MaxLength = 50
        txtAdd2.MaxLength = 50
        txtAdd3.MaxLength = 50
        txtCity.MaxLength = 50
        txtFax.MaxLength = 12
        txtEmail.MaxLength = 50
        txtPinCode.MaxLength = 20
        'txtState.MaxLength = 30
        txtTinNo.MaxLength = 20
        txtCstLst.MaxLength = 30
        txtRegdNo.MaxLength = 30
        txtVatRegNo.MaxLength = 30
       
        txtPanNo.MaxLength = 30
        txtTanNo.MaxLength = 30
        txtTcanNo.MaxLength = 30
     
      

        TxtEmployerDesg.Text = 50
        TxtEmployerAdd1.Text = 50
        TxtEmployerAdd2.Text = 50
        TxtEmployerAdd3.Text = 50
    End Sub
    Private Sub FrmCompanyMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetLength()
        RadPageView1.SelectedPage = RadPageViewPage1
        ButtonToolTip.SetToolTip(btnSave, "Press Alt+S for Save/Update Trasnaction")
        ButtonToolTip.SetToolTip(btnDelete, "Press Alt+D Delete Trasnaction")
        ButtonToolTip.SetToolTip(btnClose, "Press Alt+C Close the Window")
        ButtonToolTip.SetToolTip(btnNew, "Press Alt+N Adding New Trasnaction")
        AddHandler fndCompanyCode.KeyPress, AddressOf fndCompanyCode_keypress
        AddHandler fndCompanyCode.TextChanged, AddressOf fndCompanyCode_textchanged
        fndCompanyCode.Focus()
        btnDelete.Enabled = False
     
        dtTinIssueDate.Text = clsCommon.GETSERVERDATE()
        dtPanIssueDate.Text = clsCommon.GETSERVERDATE()
        '===========================
        RadPageView1.Pages("RadPageViewPage4").Item.Visibility = ElementVisibility.Hidden
        RadPageView1.Pages("RadPageViewPage3").Item.Visibility = ElementVisibility.Hidden
        RadPageView1.Pages("RadPageViewPage2").Item.Visibility = ElementVisibility.Hidden
        RadPageView1.Pages("RadPageViewPage7").Item.Visibility = ElementVisibility.Hidden
        RadPageView1.Pages("RadPageViewPage6").Item.Visibility = ElementVisibility.Hidden
        RadPageView1.Pages("RadPageViewPage5").Item.Visibility = ElementVisibility.Hidden
        Reset()
    End Sub
#End Region
    'Private Function funSetUserAccess() As Boolean
    '    Try
    '        Dim strRights As String
    '        Dim strTemp() As String
    '        Dim strProgCode = "COMPANY-M"
    '        strRights = enuUserRights.enuRead & "," & enuUserRights.enuModify & "," & enuUserRights.enuDelete & "," & enuUserRights.enuAuthorised
    '        strRights = modUserMgt.funGetPermissions(strRights, strProgCode)
    '        strTemp = Split(strRights, ",")
    '        If strTemp(0) = "0" Then
    '            MsgBox("Permission Denied", MsgBoxStyle.Critical, Me.Text)
    '            funSetUserAccess = False
    '            blnRead = False
    '            Me.Close()
    '            Exit Function
    '        Else
    '            blnRead = True
    '        End If
    '        If strTemp(1) = "0" Then 'Grant modify access
    '            btnSave.Enabled = False
    '        End If
    '        If strTemp(2) = "0" Then 'Grant modify access
    '            btnDelete.Enabled = False
    '        End If
    '        If strTemp(3) = "0" Then 'Grant Authorize access
    '            ' btnPost.Enabled = False
    '        End If
    '        funSetUserAccess = True
    '    Catch er As Exception
    '        common.clsCommon.MyMessageBoxShow(er.Message.ToString())
    '    End Try
    'End Function

   

#Region "TextChanged Event"

    Private Sub fndCompanyCode_textchanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dt = clsDBFuncationality.GetDataTable("select   Comp_Code from TSPL_COMPANY_MASTER where Comp_Code='" + fndCompanyCode.Value + "'")
        Dim s As String = ""
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                'While dr.Read()
                s = dr(0).ToString()
                ' End While
            Next
        End If

        If s <> fndCompanyCode.Value Then
            txtCompanyName.Text = ""
            txtAdd1.Text = ""
            txtAdd2.Text = ""
            txtAdd3.Text = ""
            txtCity.Text = ""
            txtEmail.Text = ""
            txtFax.Text = ""
            txtTelephone1.Text = ""
            txtTelephone2.Text = ""
            txtPinCode.Text = ""
            txtState.Value = Nothing
            txtTinNo.Text = ""
            txtCstLst.Text = ""
            txtRegdNo.Text = ""

            txtVatRegNo.Text = ""
            txtPanNo.Text = ""

            txtTanNo.Text = ""

            txtTcanNo.Text = ""
        

        
            btnSave.Enabled = True
            btnSave.Text = "&Save"
    
        End If
      
    End Sub
#End Region

#Region "Export"
    ''export company details 
    'Anubhooti 02-Sep-2014 BM00000003428 (Fetch CINNo.)
    Private Sub menuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExport.Click
        sql = "select Comp_Code,Comp_Name,Add1,Add2,Add3,City_Code,Phone1,Phone2,Fax,Email,Pincode,State,Tin_No,Cst_Lst,Regn_No,Cform,Mode_of_Trans,CINNo,IECode,Insurance_Comp_name,Insurance_No,Insurance_Valid_Date from TSPL_COMPANY_MASTER"
        transportSql.ExporttoExcel(sql, Me)
    End Sub
#End Region

#Region "Finder Load"
    'Private Sub fndCompanyCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    fndCompanyCode.ConnectionString = connectSql.SqlCon()
    '    fndCompanyCode.Query = "select Comp_Code as [Company Code],Comp_Name  as [Company Name] from TSPL_COMPANY_MASTER order by Comp_Code"
    '    fndCompanyCode.ValueToSelect = "Company Code"
    '    fndCompanyCode.ValueToSelect1 = "Company Name"
    '    fndCompanyCode.Caption = "Company Details"
    'End Sub
#End Region

#Region "Button Click Event"
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteData()
    End Sub
    Public Sub DeleteData()
        Try
            Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
            If clsCommon.myLen(fndCompanyCode.Value) <= 0 Then
                Throw New Exception(" Select Company Code")
            End If

            If clsCompanyMaster.deleteData(fndCompanyCode.Value, trans) Then
                myMessages.delete()
                trans.Commit()
                Reset()
            Else
                clsCommon.MyMessageBoxShow("Can't delete the record")
                trans.Rollback()
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveData()
    End Sub
    Public Sub SaveData()
        Dim obj As New clsCompanyMaster()
        Try
            If clsCommon.myLen(fndCompanyCode.Value) <= 0 Then
                Throw New Exception(" Fill Company Code")
            End If
            If clsCommon.myLen(txtCompanyName.Text) <= 0 Then
                Throw New Exception(" Fill Company Name")
            End If
            obj.CustCode = fndCompanyCode.Value
            obj.CustName = txtCompanyName.Text
            obj.Add1 = txtAdd1.Text
            obj.Add2 = txtAdd2.Text
            obj.Add3 = txtAdd3.Text
            obj.CityCode = txtCity.Text
            obj.PInCode = txtPinCode.Text
            obj.Telephone1 = txtTelephone1.Text
            obj.Telephone2 = txtTelephone2.Text
            obj.State = txtState.Value
            obj.TinNo = txtTinNo.Text
            obj.TinDate = dtTinIssueDate.Value
            obj.Fax = txtFax.Text
            obj.Email = txtEmail.Text
            obj.CST_LST = txtCstLst.Text
            obj.Regd_No = txtRegdNo.Text
            obj.VAtRegistrationNo = txtVatRegNo.Text
            obj.PanNo = txtPanNo.Text
            obj.PanDate = dtPanIssueDate.Value
            obj.WebSite = txtTcanNo.Text
            obj.TanNo = txtTanNo.Text
            If (obj.SaveData(obj, isNewEntry)) Then
                common.clsCommon.MyMessageBoxShow("Data Saved Successfully")
                LoadData(obj.CustCode, NavigatorType.Current)
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow(ex.Message)
        End Try
    End Sub
    Sub LoadData(ByVal strCode As String, ByVal NavTyep As NavigatorType)
        Dim obj As New clsCompanyMaster()
        Try
           
            obj = clsCompanyMaster.GetData(strCode, NavTyep)
            If (obj IsNot Nothing AndAlso clsCommon.myLen(obj.CustCode) > 0) Then
                isNewEntry = False
                txtCompanyName.Text = obj.CustName
                txtAdd1.Text = obj.Add1
                txtAdd2.Text = obj.Add2
                txtAdd3.Text = obj.Add3
                txtCity.Text = obj.CityCode
                txtState.Value = obj.State
                txtTelephone1.Text = obj.Telephone1
                txtTelephone2.Text = obj.Telephone2
                txtPinCode.Text = obj.PInCode
                txtFax.Text = obj.Fax
                txtEmail.Text = obj.Email
                txtCstLst.Text = obj.CST_LST
                txtRegdNo.Text = obj.Regd_No
                txtVatRegNo.Text = obj.VAtRegistrationNo
                txtPanNo.Text = obj.PanNo
                txtTcanNo.Text = obj.WebSite
                obj.TanNo = obj.TanNo
                btnSave.Text = "Update"
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            isNewEntry = True
            common.clsCommon.MyMessageBoxShow(ex.Message)
        Finally
            obj = Nothing
        End Try
    End Sub
    Sub Reset()
        isNewEntry = True
        txtAdd1.Text = ""
        txtAdd2.Text = ""
        txtAdd3.Text = ""
        txtCompanyName.Text = ""
        txtCstLst.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        txtPinCode.Text = ""
        txtPanNo.Text = ""
        txtTanNo.Text = ""
        txtTcanNo.Text = ""
        txtTelephone1.Text = ""
        txtTelephone2.Text = ""
        txtTinNo.Text = ""
        txtRegdNo.Text = ""
        txtState.Text = ""
        fndCompanyCode.Value = ""
        txtVatRegNo.Text = ""
        txtCity.Text = ""
        btnSave.Text = "Save"
        btnDelete.Enabled = False
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub menuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuClose.Click
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        closeform()
    End Sub
    Public Sub closeform()
        Me.Close()
    End Sub
#End Region

    Private Sub FrmCompanyMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.S AndAlso MyBase.isModifyFlag AndAlso btnSave.Enabled Then
            SaveData()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D AndAlso MyBase.isDeleteFlag AndAlso btnDelete.Enabled Then
            DeleteData()
        ElseIf e.Alt And e.KeyCode = Keys.C Then
            closeform()

        ElseIf e.Alt And e.KeyCode = Keys.N Then

        End If
    End Sub

    Private Sub fndCompanyCode__MYValidating(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal isButtonClicked As System.Boolean) Handles fndCompanyCode._MYValidating
        Dim qst As String = "select count(*) from COMPANY_MASTER where Comp_Code='" + fndCompanyCode.Value + "'"
        Dim count As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(qst))
        If count = 0 Then
            fndCompanyCode.MyReadOnly = False
        Else
            fndCompanyCode.MyReadOnly = True
        End If

        If fndCompanyCode.MyReadOnly OrElse isButtonClicked Then
            Dim qry As String 
            fndCompanyCode.Value = clsCompanyMaster.getFinder("", fndCompanyCode.Value, isButtonClicked)
            qry = "select Comp_Name  from COMPANY_MASTER where Comp_Code ='" + fndCompanyCode.Value + "'"
            Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry)
            If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
                txtCompanyName.Text = clsCommon.myCstr(dt.Rows(0)("Comp_Name"))
            Else
                txtCompanyName.Text = ""
            End If
            LoadData(fndCompanyCode.Value, NavigatorType.Current)
        End If
    End Sub

    Private Sub fndCompanyCode__MYNavigator(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal NavType As common.NavigatorType) Handles fndCompanyCode._MYNavigator
        Dim qst As String = " select Comp_Code as [Company Code],Comp_Name  as [Company Name] from COMPANY_MASTER  where 2=2"
        Select Case NavType
            Case NavigatorType.Current
                qst += " and COMPANY_MASTER .Comp_Code in ('" + fndCompanyCode.Value + "')"
            Case NavigatorType.Next
                qst += " and COMPANY_MASTER .Comp_Code in (select min(Comp_Code) from COMPANY_MASTER where Comp_Code  >'" + fndCompanyCode.Value + "')"
            Case NavigatorType.First
                qst += " and COMPANY_MASTER .Comp_Code in (select MIN(Comp_Code) from COMPANY_MASTER)"

            Case NavigatorType.Last
                qst += " and COMPANY_MASTER .Comp_Code in (select Max(Comp_Code) from COMPANY_MASTER)"
            Case NavigatorType.Previous
                qst += " and COMPANY_MASTER .Comp_Code in (select Max(Comp_Code) from COMPANY_MASTER where Comp_Code  <'" + fndCompanyCode.Value + "')"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qst)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            fndCompanyCode.Value = clsCommon.myCstr(dt.Rows(0)("Company Code"))
            txtCompanyName.Text = clsCommon.myCstr(dt.Rows(0)("Company Name"))
        End If
        LoadData(fndCompanyCode.Value, NavigatorType.Current)
    End Sub
  


End Class
