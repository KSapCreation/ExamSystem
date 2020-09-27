Imports common
Imports System.Data.SqlClient




Public Class clsCompanyMaster
#Region "Varaibles"
    Public CustCode As String = ""
    Public CustName As String = ""
    Public Add1 As String = ""
    Public Add2 As String = ""
    Public Add3 As String = ""
    Public CityCode As String = ""
    Public PInCode As String = ""
    Public Telephone1 As String = ""
    Public Telephone2 As String = ""

    Public State As String = ""
    Public TinNo As String = ""
    Public TinDate As String = ""
    Public Fax As String = ""
    Public CST_LST As String = ""
    Public Email As String = ""

    Public Regd_No As String = ""
    Public VAtRegistrationNo As String = ""
    Public PanNo As String = ""
    Public PanDate As String = ""
    Public WebSite As String = ""
    Public TanNo As String = ""

   
#End Region
    '----------------Code For Get Finder--------------------------------------------------------------------'
    Public Shared Function getFinder(ByVal whrcls As String, ByVal curcode As String, ByVal isButtonClicked As Boolean) As String
        Dim str As String = ""
        Dim qry As String = " select Comp_Code as [Code],Comp_Name as [Company Name],Add1,Add2,Add3,City_Code as [City Code],Phone1,Phone2,Fax,Email,Pincode,State,Tin_No as [Tin No],CST_LST as [CST LST],Regn_No as [Registration No],Cform as [C Form],Mode_of_Trans as [Mode Of Trans],Created_By as [Created By],Created_Date as [Created Date],Modify_By as [Modify By],Modify_Date as [Modify Date],Comp_Code1 as [Company Code1],DataBase_Name as [Database Name],Vat_Reg_No as [VAT Registration No],ServiceTax_Reg_No as [Service Tax Registration No],Ecc_No as [ECC No],CE_Range as [CE Range],CE_Commissionerate as [CE Commission Rate],CE_Division as [CE Division],Pan_No as [PAN No],Tan_No as [TAN NO],Tcan_No as [TCAN No],Circle_No as [Circle No],Ward_No as [Ward No],Access_Officer as [Access Officer],NameInTally as [Name In Tally],IntegrateWithTally as [Integrate With Tally],BaseCurrencyCode as [Base Currency Code],ApplyMultiCurrency  as [Apply Multi Currency],GSTReg_No as [GST Regisrtation No],GSTINNo as [GSTIn No] from COMPANY_MASTER   "
        str = clsCommon.ShowSelectForm("RPTCPMSTFND", qry, "Code", whrcls, curcode, "Code", isButtonClicked)
        Return str
    End Function
    Public Shared Function deleteData(ByVal strScreenCode As String, ByVal trans As SqlTransaction) As Boolean
        Try
            Dim isDeleted As Boolean = True
            Dim qry2 As String = "delete from COMPANY_MASTER where COMP_CODE='" & strScreenCode & "'"
            isDeleted = isDeleted AndAlso clsDBFuncationality.ExecuteNonQuery(qry2, trans)
      
            Return isDeleted
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Shared Function CheckExistence(ByVal strCode As String, ByVal trans As SqlTransaction) As String
        Dim qry As String = "select COMP_CODE from TSPL_COMPANY_MASTER where COMP_CODE='" & strCode & "' "
        Return clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
    End Function
    Public Function SaveData(ByVal obj As clsCompanyMaster, ByVal isNewEntry As Boolean, Optional ByVal isamendment As Boolean = False) As Boolean
        Dim trans As SqlTransaction = clsDBFuncationality.GetTransactin()
        Try
            SaveData(obj, isNewEntry, trans)
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function

    Public Function SaveData(ByVal obj As clsCompanyMaster, ByVal isNewEntry As Boolean, ByVal trans As SqlTransaction) As Boolean
        Dim isSaved As Boolean = True
        Try
            Dim coll As New Hashtable()

            clsCommon.AddColumnsForChange(coll, "Comp_Name", obj.CustName)
            clsCommon.AddColumnsForChange(coll, "Add1", obj.Add1)
            clsCommon.AddColumnsForChange(coll, "Add2", obj.Add2)
            clsCommon.AddColumnsForChange(coll, "Add3", obj.Add3)
            clsCommon.AddColumnsForChange(coll, "City_Code", obj.CityCode)
            clsCommon.AddColumnsForChange(coll, "Pincode", obj.PInCode)
            clsCommon.AddColumnsForChange(coll, "Email", obj.Email)
            clsCommon.AddColumnsForChange(coll, "Fax", obj.Fax)
            clsCommon.AddColumnsForChange(coll, "Tin_No", obj.TinNo)
            clsCommon.AddColumnsForChange(coll, "CST_LST", obj.CST_LST)
            clsCommon.AddColumnsForChange(coll, "Regn_No", obj.Regd_No)
            clsCommon.AddColumnsForChange(coll, "Vat_Reg_No", obj.VAtRegistrationNo)
            clsCommon.AddColumnsForChange(coll, "Pan_No", obj.PanNo)
            clsCommon.AddColumnsForChange(coll, "Tan_No", obj.TanNo)
            clsCommon.AddColumnsForChange(coll, "Tcan_No", obj.WebSite)
            clsCommon.AddColumnsForChange(coll, "Comp_code1", obj.CustCode)
            'clsCommon.AddColumnsForChange(coll, "TinNo_Issue_Date", clsCommon.myCDate(obj.TinDate))
            'clsCommon.AddColumnsForChange(coll, "PanNo_Issue_Date", clsCommon.myCDate(obj.PanDate))

            clsCommon.AddColumnsForChange(coll, "Modify_By", objCommonVar.CurrentUserCode)
            clsCommon.AddColumnsForChange(coll, "Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MM/yyyy"))

            If isNewEntry Then
                clsCommon.AddColumnsForChange(coll, "Comp_Code", obj.CustCode)
                clsCommon.AddColumnsForChange(coll, "Created_By", objCommonVar.CurrentUserCode)
                clsCommon.AddColumnsForChange(coll, "Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MM/yyyy"))
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "COMPANY_MASTER", OMInsertOrUpdate.Insert, "", trans)
            Else
                isSaved = isSaved AndAlso clsCommonFunctionality.UpdateDataTable(coll, "COMPANY_MASTER", OMInsertOrUpdate.Update, "COMPANY_MASTER.Comp_Code='" + obj.CustCode + "'", trans)
            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
        Return isSaved
    End Function
    Public Shared Function GetData(ByVal strDocumentNo As String, ByVal NavType As NavigatorType) As clsCompanyMaster
        Return GetData(strDocumentNo, NavType, Nothing)
    End Function
    Public Shared Function GetData(ByVal strPONo As String, ByVal NavType As NavigatorType, ByVal trans As SqlTransaction) As clsCompanyMaster
        Dim obj As clsCompanyMaster = Nothing
        Dim qry As String = "Select * from COMPANY_MASTER where 2=2"
        Dim whrCls As String = ""

        Select Case NavType
            Case NavigatorType.First
                qry += " and COMPANY_MASTER.Comp_Code = (select MIN(Comp_Code) from COMPANY_MASTER WHERE 1=1 )"
            Case NavigatorType.Last
                qry += " and COMPANY_MASTER.Comp_Code = (select Max(Comp_Code) from COMPANY_MASTER WHERE 1=1  )"
            Case NavigatorType.Next
                qry += " and COMPANY_MASTER.Comp_Code = (select Min(Comp_Code) from COMPANY_MASTER where Comp_Code>'" + strPONo + "')"
            Case NavigatorType.Previous
                qry += " and COMPANY_MASTER.Comp_Code = (select Max(Comp_Code) from COMPANY_MASTER where Comp_Code<'" + strPONo + "')"
            Case NavigatorType.Current
                qry += " and COMPANY_MASTER.Comp_Code = '" + strPONo + "'"
        End Select
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)

        If (dt IsNot Nothing AndAlso dt.Rows.Count > 0) Then
            obj = New clsCompanyMaster()
            obj.CustCode = clsCommon.myCstr(dt.Rows(0)("Comp_Code"))
            obj.CustName = clsCommon.myCstr(dt.Rows(0)("Comp_Name"))
            obj.Add1 = clsCommon.myCstr(dt.Rows(0)("Add1"))
            obj.Add2 = clsCommon.myCstr(dt.Rows(0)("Add2"))
            obj.Add3 = clsCommon.myCstr(dt.Rows(0)("Add3"))
            obj.CityCode = clsCommon.myCstr(dt.Rows(0)("City_Code"))
            obj.PInCode = clsCommon.myCstr(dt.Rows(0)("Pincode"))
            obj.Email = clsCommon.myCstr(dt.Rows(0)("Email"))
            obj.Fax = clsCommon.myCstr(dt.Rows(0)("Fax"))
            obj.TinNo = clsCommon.myCstr(dt.Rows(0)("Tin_No"))
            obj.CST_LST = clsCommon.myCstr(dt.Rows(0)("CST_LST"))
            obj.Regd_No = clsCommon.myCstr(dt.Rows(0)("Regn_No"))
            obj.VAtRegistrationNo = clsCommon.myCstr(dt.Rows(0)("Vat_Reg_No"))
            obj.PanNo = clsCommon.myCstr(dt.Rows(0)("Pan_No"))
            obj.TanNo = clsCommon.myCstr(dt.Rows(0)("Tan_No"))
            obj.WebSite = clsCommon.myCstr(dt.Rows(0)("Tcan_No"))
            obj.TinDate = clsCommon.myCstr(dt.Rows(0)("TinNo_Issue_Date"))
            obj.PanDate = clsCommon.myCstr(dt.Rows(0)("PanNo_Issue_Date"))

        End If

        Return obj
    End Function
End Class
