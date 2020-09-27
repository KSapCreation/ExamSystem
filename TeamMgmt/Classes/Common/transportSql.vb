Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.Data
Imports Telerik.WinControls.Enumerations
Imports Telerik.WinControls
Imports System.Text.RegularExpressions
Imports Telerik.WinControls.UI.Export
Imports Telerik.WinControls.UI.Export.ExportToExcelML
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine
Imports common
Imports Microsoft.Office.Interop
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Windows.Forms

Public Module transportSql

    Dim ds As New DataSet()

    Public Sub FillGridView(ByVal sql As String, ByVal gv As RadGridView)
        Dim bs As New BindingSource()
        ds = connectSql.RunSQLReturnDS(sql)
        bs.DataSource = ds.Tables(0)
        gv.DataSource = bs
    End Sub
    Public Sub FillGridViewWithDt(ByVal Dt As DataTable, ByVal gv As RadGridView)
        Dim bs As New BindingSource()
        bs.DataSource = Dt
        gv.DataSource = Dt
    End Sub
    Public Sub FillComboBox(ByVal sql As String, ByVal ddl As RadDropDownList, ByVal dispMember As String, ByVal valueMember As String)
        ds = connectSql.RunSQLReturnDS(sql)
        ddl.DataSource = ds.Tables(0)
        ddl.DisplayMember = dispMember
        ddl.ValueMember = valueMember
        ddl.Text = "Select"
    End Sub
    Public Sub FillMultiColumnComboBox(ByVal sql As String, ByVal ddl As RadMultiColumnComboBox, ByVal dispMember As String, ByVal valueMember As String)
        ds = connectSql.RunSQLReturnDS(sql)
        ddl.DataSource = ds.Tables(0)
        ddl.DisplayMember = dispMember
        ddl.ValueMember = valueMember
        ddl.Text = "Select"
    End Sub
    

    Public Function OpenExporttoExcel(ByVal sql As String, ByVal frm As RadForm) As Boolean
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        Dim path As String
        sfd.FileName = frm.Text
        sfd.Filter = "Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
        If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path = sfd.FileName
        Else
            Return False
        End If
        If Not path.Equals(String.Empty) Then
            Dim gv As New RadGridView()
            Try
                ''''' Dim exporter As New RadGridViewExcelExporter()
                gv.Name = "gTax"
                frm.Controls.Add(gv)
                FillGridView(sql, gv)
                If gv.Rows.Count = 0 Then
                    common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                    Return False
                End If
                Dim i As Integer = 0
                For i = 0 To gv.ColumnCount - 1
                    Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                    If TypeOf grow.Cells(i).Value Is DateTime Then
                        Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                        datecol.ExcelExportType = DisplayFormatType.ShortDate
                    End If
                Next i
                '    exporter.Export(gv, path, frm.Text)

                Dim exporter As New ExportToExcelML(gv)
                ' exporter.SummariesExportOption = SummariesOption.ExportAll
                exporter.ExportVisualSettings = True
                AddHandler exporter.ExcelCellFormatting, AddressOf exporter_ExcelCellFormattingForOpen
                'AddHandler exporter.ExcelTableCreated, AddressOf exporter_ExcelTableCreated
                'exporter.RunExport(fileName.ToString())
                'RadMessageBox.SetThemeName("Breeze")
                exporter.ExportHierarchy = True
                exporter.SheetMaxRows = ExcelMaxRows._65536
                exporter.SheetName = frm.Text
                exporter.RunExport(path)

                frm.Controls.Remove(gv)
                Dim xlApp As Excel.Application
                'Dim xlWorkBook As Excel.Workbook
                'Dim xlWorkSheet As Excel.Worksheet

                xlApp = New Excel.Application
                Process.Start(path)
                'xlWorkBook = xlApp.Workbooks.Open(path)
                'System.Diagnostics.Process.Start(path)
                'xlWorkSheet = xlWorkBook.Worksheets(frm.Text)
                'xlWorkBook.Close()
                'xlApp.Quit()
                ' common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
            Catch ex As Exception
                frm.Controls.Remove(gv)
                common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
                Return False
            End Try
        End If
        Return True
    End Function

    Public Function ExporttoExcel(ByVal sql As String, ByVal frm As RadForm) As Boolean
        Return ExporttoExcel(sql, "", "", frm)
    End Function

    Public Function ExporttoExcel(ByVal sql As String, ByVal whrClaus As String, ByVal frm As RadForm) As Boolean
        Return ExporttoExcel(sql, whrClaus, "", frm)
    End Function

    Public Function ExporttoExcel(ByVal sql As String, ByVal whrClaus As String, ByVal OrderByClaus As String, ByVal frm As RadForm) As Boolean
        Return ExporttoExcel(sql, whrClaus, OrderByClaus, frm, Nothing)
    End Function
    Public Function ExporttoExcel(ByVal sql As String, ByVal whrClaus As String, ByVal OrderByClaus As String, ByVal frm As RadForm, ByVal ParamArray manadatoryField As String()) As Boolean
        Try
            ''************* Filter Block Start
            '============Add By Rohit on June 17,2014 to show column Filter========
            'Dim Goinside As Boolean = True
            Dim frmFilterCol As New frmFilterColumnsToExport()
            frmFilterCol.qry = sql
            frmFilterCol.whrCls = " Where 2=2 " + whrClaus
            'If clsCommon.myLen(OrderByClaus) > 0 Then
            '    frmFilterCol.orderByClause = " Order by " + OrderByClaus
            'End If
            frmFilterCol.ShowDialog()
            If frmFilterCol.isCancel Then
                '   Goinside = False
                GoTo a
                'Return False
            End If
            sql = frmFilterCol.qry
            'Goinside = True
            '========================================================================
a:          Dim frmFilter As New frmFilterToExport()
            frmFilter.qry = sql
            'If Goinside = True AndAlso Not frmFilter.qry.ToUpper().Contains("ORDER BY") Then
            '    frmFilter.whrCls = " Where 2=2 "
            'ElseIf Goinside = False AndAlso Not frmFilter.qry.ToUpper().Contains("ORDER BY") Then
            '    frmFilter.whrCls = " Where 2=2 " + whrClaus
            'End If

            'If Not frmFilter.qry.ToUpper().Contains("ORDER BY") AndAlso clsCommon.myLen(OrderByClaus) > 0 Then
            '    frmFilter.orderByClause = " Order by " + OrderByClaus
            'End If
            frmFilter.ShowDialog()
            If frmFilter.isCancel Then
                Return False
            End If
            sql = frmFilter.qry
            If Not frmFilter.qry.ToUpper().Contains("ORDER BY") AndAlso clsCommon.myLen(OrderByClaus) > 0 Then
                sql = sql & " Order by " + OrderByClaus
            End If
            ''************* Filter Block End

            Dim sfd As SaveFileDialog = New SaveFileDialog()
            Dim filePath As String
            sfd.FileName = frm.Text
            '  sfd.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls"
            sfd.Filter = "Excel 97-2003 (*.xls) |*.xls;|Excel 2007 (*.xlsx)|*.xlsx;|CSV Files (*.csv) |*.csv"
            If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                filePath = sfd.FileName
            Else
                Return False
            End If

            'If InStr(path, ".xlsx") <> -1 Then
            '    path = Replace(path, ".xlsx", ".xls")
            'End If
            If Not filePath.Equals(String.Empty) Then
                Dim gv As New RadGridView()
                Try
                    'Dim exporter As New RadGridViewExcelExporter()
                    gv.Name = "gTax"
                    frm.Controls.Add(gv)
                    FillGridView(sql, gv)
                    gv.Visible = False
                    If gv.Rows.Count = 0 And frmFilter.chkBlankSheet.Checked = False Then
                        common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                        Return False
                    End If

                    Dim i As Integer = 0
                    '===============Add If Condition For Row Count by Rohit on june 05,2014 If Sheet is Blank then This Loop should not execute===
                    If gv.Rows.Count > 0 Then
                        For i = 0 To gv.ColumnCount - 1
                            Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                            If TypeOf grow.Cells(i).Value Is DateTime Then
                                Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                                datecol.ExcelExportType = DisplayFormatType.ShortDate
                            End If
                        Next i
                    End If
                    '==================================================================
                    'AddHandler exporter.Progress, AddressOf PB.exporter_Progress
                    'ShowPb(gv.Rows.Count)

                    'exporter.Export(gv, path, frm.Text)
                    'HidePb()
                    'clsCommon.ProgressBarShow()
                    '================ADD IIF (Blank Sheet) Condition to Save Blank Excel Sheet=========
                    Dim ext As String = Path.GetExtension(filePath)
                    If clsCommon.CompairString(ext, ".csv") = CompairStringResult.Equal Then
                        exportdataInCSV(gv, filePath, filePath.Substring(filePath.LastIndexOf("\") + 1, filePath.Length - filePath.LastIndexOf("\") - 1), IIf(frmFilter.chkBlankSheet.Checked, True, False)) 'frm.Text)
                    Else
                        exportdata(gv, filePath, filePath.Substring(filePath.LastIndexOf("\") + 1, filePath.Length - filePath.LastIndexOf("\") - 1), IIf(frmFilter.chkBlankSheet.Checked, True, False)) 'frm.Text)
                    End If

                    '============================================================
                    'Dim exporter1 As New ExportToExcelML(gv)

                    '' AddHandler exporter1.ExcelCellFormatting, AddressOf exporter_ExcelCellFormatting
                    ''exporter1.ExportHierarchy = True
                    ''exporter1.ExportVisualSettings = True
                    ''exporter1.SheetMaxRows = ExcelMaxRows._1048576
                    'exporter1.SheetName = frm.Text
                    'exporter1.RunExport(path)
                    'frm.Controls.Remove(gv)
                    If clsCommon.CompairString(ext, ".csv") = CompairStringResult.Equal Then
                        GoTo xxx
                    End If

                    If manadatoryField IsNot Nothing AndAlso manadatoryField.Length > 0 Then
                        Dim oApp As Excel.Application
                        Dim oWB As Excel.Workbook
                        oApp = New Excel.Application
                        oWB = oApp.Workbooks.Open(filePath)
                        oApp.DisplayAlerts = False
                        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet = oWB.Worksheets(filePath.Substring(filePath.LastIndexOf("\") + 1, filePath.Length - filePath.LastIndexOf("\") - 1)) 'oWB.Worksheets(frm.Text)

                        For c As Integer = 0 To wSheet.Columns.Count - 1
                            If clsCommon.myLen(wSheet.Cells(1, c + 1).value) <= 0 Then
                                Exit For
                            End If

                            If isManadatory(wSheet.Cells(1, c + 1).value, manadatoryField) Then
                                wSheet.Cells(1, c + 1).interior.color = RGB(Color.LightGoldenrodYellow.R, Color.LightGoldenrodYellow.G, Color.LightGoldenrodYellow.B)
                            End If
                        Next
                        oWB.SaveAs(filePath)
                        oWB.Close()
                        oApp.Quit()
                    End If

xxx:
                    'My.Computer.FileSystem.RenameFile(Microsoft.VisualBasic.Left(path, Len(path) - 1), path.Substring(path.LastIndexOf("\") + 1, path.Length - path.LastIndexOf("\") - 1))
                    'clsCommon.ProgressBarHide()
                    common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
                    System.Diagnostics.Process.Start(filePath)
                    'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
                    'excel.Workbooks.Open(path)
                    'excel.Visible = True


                Catch ex As Exception
                    'clsCommon.ProgressBarHide()
                    frm.Controls.Remove(gv)

                    'HidePb()
                    Throw New Exception(ex.Message)
                    Return False
                End Try
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
        End Try
        Return True
    End Function
    Function isManadatory(ByVal colName As String, ByVal ParamArray fieldNames As String()) As Boolean
        For Each field As String In fieldNames
            If clsCommon.CompairString(field, colName) = CompairStringResult.Equal Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    ''''''''''''''''''''' function to export data with custom field
    Public Function ExporttoExcelWithCustomField(ByVal sql As String, ByVal whrClaus As String, ByVal OrderByClaus As String, ByVal frm As RadForm, ByVal formid As String) As Boolean

        ''************* Filter Block Start
        Dim frmFilter As New frmFilterToExport()
        frmFilter.qry = sql
        frmFilter.whrCls = " Where 2=2 " + whrClaus
        If clsCommon.myLen(OrderByClaus) > 0 Then
            frmFilter.orderByClause = " Order by " + OrderByClaus
        End If
        frmFilter.ShowDialog()
        If frmFilter.isCancel Then
            Return False
        End If
        sql = frmFilter.qry
        ''************* Filter Block End

        Dim sfd As SaveFileDialog = New SaveFileDialog()
        Dim path As String
        sfd.FileName = frm.Text
        sfd.Filter = "Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
        If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path = sfd.FileName
        Else
            Return False
        End If
        If Not path.Equals(String.Empty) Then
            Dim gv As New RadGridView()
            Try
                ''''' Dim exporter As New RadGridViewExcelExporter()
                gv.Name = "gTax"
                frm.Controls.Add(gv)
                FillGridView(sql, gv)
                If gv.Rows.Count = 0 Then
                    common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                    Return False
                End If

                Dim i As Integer = 0
                For i = 0 To gv.ColumnCount - 1
                    Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                    If TypeOf grow.Cells(i).Value Is DateTime Then
                        Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                        datecol.ExcelExportType = DisplayFormatType.ShortDate
                    End If
                Next i
                'exporter.Export(gv, path, frm.Text)

                clsCommon.ProgressBarShow()
                exportdatawithcustomfield(gv, path, frm.Text, formid)
                'Dim exporter As New ExportToExcelML(gv)
                'AddHandler exporter.ExcelCellFormatting, AddressOf exporter_ExcelCellFormatting
                'exporter.ExportHierarchy = True
                '' exporter.ExportVisualSettings = True
                'exporter.SheetMaxRows = ExcelMaxRows._65536
                'exporter.SheetName = frm.Text
                'exporter.RunExport(path)

                frm.Controls.Remove(gv)
                clsCommon.ProgressBarHide()
                common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
                Dim excel As New Microsoft.Office.Interop.Excel.Application
                excel.Workbooks.Open(path)
                excel.Visible = True


            Catch ex As Exception
                frm.Controls.Remove(gv)
                clsCommon.ProgressBarHide()
                common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
                Return False
            End Try
        End If
        Return True
    End Function
    Public Function ImportCustomFields(grow As GridViewRowInfo, FormId As String, UniqueColName As String, trans As SqlTransaction) As Boolean
        Dim isSaved As Boolean = True
        Try
            'Dim ChkCustomField As String = clsDBFuncationality.getSingleValue("select TSPL_CUSTOM_FIELD_HEAD.name,TSPL_CUSTOM_FIELD_HEAD.code from TSPL_CUSTOM_FIELD_MAPPING left join TSPL_CUSTOM_FIELD_HEAD on TSPL_CUSTOM_FIELD_HEAD.Code =TSPL_CUSTOM_FIELD_MAPPING.Custom_Field_Code where Program_Code ='" + clsUserMgtCode.frmMPMaster + "' ", trans)
            Dim dt As DataTable = clsDBFuncationality.GetDataTable("select TSPL_CUSTOM_FIELD_HEAD.name,TSPL_CUSTOM_FIELD_HEAD.code from TSPL_CUSTOM_FIELD_MAPPING left join TSPL_CUSTOM_FIELD_HEAD on TSPL_CUSTOM_FIELD_HEAD.Code =TSPL_CUSTOM_FIELD_MAPPING.Custom_Field_Code where Program_Code ='" + FormId + "' ", trans)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                For j As Integer = 0 To dt.Rows.Count - 1
                    Try
                        Dim value As String = grow.Cells(dt.Rows(j)("name")).value
                        If clsCommon.myLen(value) > 0 Then
                            Dim chk As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(*) from TSPL_CUSTOM_FIELD_VALUES where Program_Code='" & FormId & "' and Transaction_Code='" & clsCommon.myCstr(grow.Cells(UniqueColName).Value) & "' and Custom_Field_Code ='" & dt.Rows(j)("Code") & "'", trans))
                            Dim qry As String = ""
                            If chk > 0 Then
                                ''Update query
                                qry = "update TSPL_CUSTOM_FIELD_VALUES set value='" & value & "' where Program_Code='" & FormId & "' and Transaction_Code='" & clsCommon.myCstr(grow.Cells(UniqueColName).Value) & "' and Custom_Field_Code ='" & dt.Rows(j)("Code") & "'"
                                isSaved = clsDBFuncationality.ExecuteNonQuery(qry, trans)

                            Else
                                ''Insert Query
                                qry = "insert into TSPL_CUSTOM_FIELD_VALUES  values('" & FormId & "','" & clsCommon.myCstr(grow.Cells(UniqueColName).Value) & "','" & dt.Rows(j)("Code") & "','" & value & "',0)"
                                isSaved = clsDBFuncationality.ExecuteNonQuery(qry, trans)
                            End If
                        End If
                    Catch ex1 As Exception
                    End Try
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return isSaved
    End Function
    '-------------Overloaded By Pankaj Jha for Custom Filed Query Optimization on 30.05.2014
    Public Function ExporttoExcelWithCustomField(ByVal sql As String, ByVal whrClaus As String, ByVal OrderByClaus As String, ByVal frm As RadForm, ByVal formid As String, ByVal transCodeColumnName As String) As Boolean

        '-Getting Custom Fields Name
        Dim CustFldNames As String = clsDBFuncationality.getSingleValue("select isnull( left(fields,len(fields)-1),'') as Fields  from (select     ( select '['+Name  +'],'   from (select TSPL_CUSTOM_FIELD_HEAD.Name,TSPL_CUSTOM_FIELD_HEAD.Code  from TSPL_CUSTOM_FIELD_MAPPING  left outer join TSPL_CUSTOM_FIELD_HEAD on TSPL_CUSTOM_FIELD_HEAD.Code = TSPL_CUSTOM_FIELD_MAPPING.Custom_Field_Code  where TSPL_CUSTOM_FIELD_MAPPING.Program_Code='" & formid & "') xx  FOR XML PATH ('')) Fields ) yy")
        If clsCommon.myLen(CustFldNames) > 0 Then
            sql = " select *  from ( select xxxx.*,  TSPL_CUSTOM_FIELD_HEAD.Name as Field_heading,TSPL_CUSTOM_FIELD_VALUES.Value as Field_Value from (  " & sql & " ) xxxx left outer join  TSPL_CUSTOM_FIELD_VALUES on TSPL_CUSTOM_FIELD_VALUES.Transaction_Code= " & transCodeColumnName & " left outer join  TSPL_CUSTOM_FIELD_MAPPING on TSPL_CUSTOM_FIELD_MAPPING.Custom_Field_Code =  TSPL_CUSTOM_FIELD_VALUES.Custom_Field_Code and TSPL_CUSTOM_FIELD_MAPPING.Program_Code='" & formid & "' left outer join TSPL_CUSTOM_FIELD_HEAD on TSPL_CUSTOM_FIELD_HEAD.Code=TSPL_CUSTOM_FIELD_MAPPING.Custom_Field_Code  )  xx Pivot (MAX(field_value) for Field_Heading in (" & CustFldNames & " )) ZZZ "
        End If
        ''************* Filter Block Start
        Dim frmFilter As New frmFilterToExport()
        frmFilter.qry = sql
        frmFilter.whrCls = " Where 2=2 " + whrClaus
        If clsCommon.myLen(OrderByClaus) > 0 Then
            frmFilter.orderByClause = " Order by " + OrderByClaus
        End If
        frmFilter.ShowDialog()
        If frmFilter.isCancel Then
            Return False
        End If
        sql = frmFilter.qry
        ''************* Filter Block End

        Dim sfd As SaveFileDialog = New SaveFileDialog()
        Dim path As String
        sfd.FileName = frm.Text
        sfd.Filter = "Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
        If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path = sfd.FileName
        Else
            Return False
        End If
        If Not path.Equals(String.Empty) Then
            Dim gv As New RadGridView()
            Try
                ''''' Dim exporter As New RadGridViewExcelExporter()
                gv.Name = "gTax"
                frm.Controls.Add(gv)
                FillGridView(sql, gv)
                If gv.Rows.Count = 0 Then
                    common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                    Return False
                End If

                Dim i As Integer = 0
                For i = 0 To gv.ColumnCount - 1
                    Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                    If TypeOf grow.Cells(i).Value Is DateTime Then
                        Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                        datecol.ExcelExportType = DisplayFormatType.ShortDate
                    End If
                Next i
                'exporter.Export(gv, path, frm.Text)

                clsCommon.ProgressBarShow()
                exportdata(gv, path, frm.Text)
                'Dim exporter As New ExportToExcelML(gv)
                'AddHandler exporter.ExcelCellFormatting, AddressOf exporter_ExcelCellFormatting
                'exporter.ExportHierarchy = True
                '' exporter.ExportVisualSettings = True
                'exporter.SheetMaxRows = ExcelMaxRows._65536
                'exporter.SheetName = frm.Text
                'exporter.RunExport(path)

                frm.Controls.Remove(gv)
                clsCommon.ProgressBarHide()
                common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
                Dim excel As New Microsoft.Office.Interop.Excel.Application
                excel.Workbooks.Open(path)
                excel.Visible = True


            Catch ex As Exception
                frm.Controls.Remove(gv)
                clsCommon.ProgressBarHide()
                common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
                Return False
            End Try
        End If
        Return True
    End Function

    Public Sub exportdata(ByVal gv As RadGridView, ByVal flname As String, ByVal sname As String, Optional ByVal isblanksheet As Boolean = False, Optional ByVal arrHeader As List(Of String) = Nothing, Optional ExportWithoutHeader As Boolean = False, Optional FormatCellofExcel As Boolean = False, Optional doubleheadershowninExcel As Boolean = False)
        Try
            '==========================Add isblanksheet Variable in Function to Save Blank Excel Sheet===================
            If ((gv.Columns.Count = 0) Or (gv.ChildRows.Count = 0)) And isblanksheet = False Then
                Exit Sub
            End If
            '========================================================================================
            'Creating dataset to export
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            Dim IndexList As List(Of String) = New List(Of String)
            For i As Integer = 0 To gv.Columns.Count - 1
                If Not gv.Columns(i).IsVisible Then
                    IndexList.Add(gv.Columns(i).Name)
                End If
            Next

            For i As Integer = 0 To IndexList.Count - 1
                gv.Columns.Remove(IndexList.Item(i).ToString())
            Next

            clsCommon.ProgressBarPercentShow()
            'add column to that table
            For i As Integer = 0 To gv.ColumnCount - 1
                'dset.Tables(0).Columns.Add(gv.Columns(i).HeaderText)
                dset.Tables(0).Columns.Add("Column" & (i + 1))
                dset.Tables(0).Columns("Column" & (i + 1)).Caption = IIf(ExportWithoutHeader, "", gv.Columns(i).HeaderText)
            Next
            'add rows to the table
            'dset.Tables(0).Rows(0).Delete()

            Dim dr1 As DataRow


            'For row = 0 To dt.Rows.Count - 1
            '    For col = 0 To dt.Columns.Count - 1
            '        rawData(row, col) = dt.Rows(row).ItemArray(col)
            '    Next
            '    clsCommon.ProgressBarPercentUpdate((row * 100) / dt.Rows.Count, " Exporting Record  " & row & "  Out of " & dt.Rows.Count)
            'Next
            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            Dim GridCurrentRowIndex As Int64 = -1
            Dim GridLastSavedRowIndex As Int64 = -1

            wBook = excel.Workbooks.Add()
            Dim rawData(gv.ChildRows.Count, gv.Columns.Count - 1) As Object
            wSheet = wBook.ActiveSheet()
            If clsCommon.myLen(sname) > 31 Then
                sname = sname.Substring(0, 31)
            End If
            'Dim dp As Object
            ' dp = wBook.BuiltinDocumentProperties
            'dp("Tags").Value = clsUserMgtCode.frmComplaintMaster
            wSheet.Name = sname
            Dim flag As Boolean = False
            Dim colnum As Integer = -1
            Dim PrevCol As Integer = -1
            Dim isResteRawData As Boolean = True
            Dim ColNums(0 To gv.Columns.Count - 1) As Integer
            Dim MaxRowsToExport As Integer = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.QuickExport, clsFixedParameterCode.MaxRowsForQuickExport, Nothing))
            Dim jk As Integer = 0
            For i As Integer = 0 To gv.Columns.Count - 1
                jk += 1
                ''richa agarwal 12jan BM00000008685
                If FormatCellofExcel = False Then
                    If TypeOf gv.Columns(i) Is GridViewTextBoxColumn Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "@"
                    ElseIf TypeOf gv.Columns(i) Is GridViewDecimalColumn AndAlso gv.Columns(i).FormatString = "{0:n2}" Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "0.00"
                    ElseIf TypeOf gv.Columns(i) Is GridViewDecimalColumn Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "0"
                    End If
                Else
                    ''richa agarwal 08-jan-2015 format for excel sheet cell format @ as text,General as for General, 0 as numnber,0.00 as decimal against ticket no BM00000008659,BM00000008854
                    If clsCommon.CompairString(gv.Columns(i).Name, "ColAcNo") = CompairStringResult.Equal Or clsCommon.CompairString(gv.Columns(i).Name, "ColPAYEEACNO") = CompairStringResult.Equal Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "@"
                    ElseIf clsCommon.CompairString(gv.Columns(i).Name, "colSCACNO") = CompairStringResult.Equal Or clsCommon.CompairString(gv.Columns(i).Name, "colBeniACNO") = CompairStringResult.Equal Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "@"
                    ElseIf TypeOf gv.Columns(i) Is GridViewTextBoxColumn Then
                        ' wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "@"
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "General"
                    ElseIf TypeOf gv.Columns(i) Is GridViewDecimalColumn AndAlso gv.Columns(i).FormatString = "{0:n2}" Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "0.00"
                    ElseIf TypeOf gv.Columns(i) Is GridViewDecimalColumn Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "0"
                    ElseIf TypeOf gv.Columns(i) Is GridViewDateTimeColumn Then
                        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "dd/mmm/yyyy"
                    End If
                    ''-------------------
                End If
            Next

            Dim colIndex As Integer = 1
            Dim rowIndex As Integer = 1

            If Not IsNothing(arrHeader) Then
                For Each Str As String In arrHeader
                    excel.Cells(rowIndex, colIndex) = Str
                    rowIndex += 1
                Next
            End If

            'If doubleheaderforvlc_vspddr = True Then
            '    Dim chartRange As Excel.Range

            '    excel.Cells(rowIndex, 1) = "MCC Receipt" 'Then


            '    excel.Cells(rowIndex, 11) = "Variation from Last day"

            '    chartRange = wSheet.Range("a5", "j5")
            '    chartRange.Merge()
            '    chartRange.VerticalAlignment = 2
            '    chartRange.HorizontalAlignment = 3

            '    chartRange = wSheet.Range("k5", "m5")
            '    chartRange.Merge()
            '    chartRange.VerticalAlignment = 2
            '    chartRange.HorizontalAlignment = 3

            '    chartRange = wSheet.Range("a6")
            '    chartRange.EntireColumn.ColumnWidth = 15

            '    rowIndex += 1
            'End If
            ''richa agarwal 09-feb-2016 to show double header in excel BM00000008811
            If doubleheadershowninExcel = True Then
                Dim view As New ColumnGroupsViewDefinition()
                view = gv.ViewDefinition
                Dim j1 As Integer = 1
                Dim k As Integer = 0
                If view.ColumnGroups.Count > 0 Then
                    Dim chartRange As Excel.Range
                    For i As Integer = 0 To view.ColumnGroups.Count - 1
                        excel.Cells(rowIndex, j1) = clsCommon.myCstr(view.ColumnGroups(i).Text)
                        Dim l As Integer = 0
                        For m As Integer = 0 To clsCommon.myCdbl(view.ColumnGroups(i).Rows(0).Columns.Count) - 1
                            If view.ColumnGroups(i).Rows(0).Columns(m).IsVisible = False Then
                                l = l + 1
                            End If
                        Next

                        k = k + clsCommon.myCdbl(view.ColumnGroups(i).Rows(0).Columns.Count) - l
                        chartRange = wSheet.Range(wSheet.Cells(rowIndex, j1), wSheet.Cells(rowIndex, k))
                        chartRange.Merge()
                        chartRange.VerticalAlignment = 2
                        chartRange.HorizontalAlignment = 3


                        j1 = clsCommon.myCdbl(view.ColumnGroups(i).Rows(0).Columns.Count) + 1 - l
                    Next

                    rowIndex += 1
                End If

            End If
            ''------------------------------------------
            While isResteRawData
                If gv.ChildRows.Count <= MaxRowsToExport Then

                    ReDim rawData(gv.ChildRows.Count, gv.Columns.Count - 1)
                    GridCurrentRowIndex = 0
                    GridLastSavedRowIndex = gv.ChildRows.Count - 1
                    isResteRawData = False
                Else
                    GridCurrentRowIndex = GridLastSavedRowIndex + 1
                    If GridLastSavedRowIndex + MaxRowsToExport <= gv.ChildRows.Count Then
                        ReDim rawData(MaxRowsToExport, gv.Columns.Count - 1)
                        GridLastSavedRowIndex = (GridLastSavedRowIndex + MaxRowsToExport)
                        isResteRawData = True
                    Else
                        ReDim rawData(gv.ChildRows.Count - GridLastSavedRowIndex, gv.Columns.Count - 1)
                        GridLastSavedRowIndex = (GridLastSavedRowIndex + (gv.Rows.Count - GridLastSavedRowIndex))
                        isResteRawData = False
                    End If
                    'GridLastSavedRowIndex = (GridLastSavedRowIndex + MaxRowsToExport)
                End If
                Dim RowDataRIndix As Integer = 0
                For i As Integer = GridCurrentRowIndex To GridLastSavedRowIndex
                    'gv.RowCount, gv.Columns.Count - 1
                    dr1 = dset.Tables(0).NewRow
                    clsCommon.ProgressBarPercentUpdate(((i + 1) * 100) / gv.ChildRows.Count, " Exporting Record  " & (i + 1) & "  Out of " & gv.ChildRows.Count)
                    Try
                        For j As Integer = 0 To gv.Columns.Count - 1
                            dr1(j) = clsCommon.myCstr(gv.ChildRows(i).Cells(j).Value)
                            rawData(RowDataRIndix, j) = dr1(j).ToString()
                        Next
                    Catch ex As Exception
                    End Try
                    dset.Tables(0).Rows.Add(dr1)
                    RowDataRIndix = RowDataRIndix + 1
                Next
                Try
                    CType(wBook.Sheets("Sheet2"), Excel.Worksheet).Delete()
                    CType(wBook.Sheets("Sheet3"), Excel.Worksheet).Delete()
                Catch ex As Exception
                End Try

                Dim dt As System.Data.DataTable = dset.Tables(0)
                Dim dc As System.Data.DataColumn
                ' Dim dr As System.Data.DataRow
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    excel.Cells(rowIndex, colIndex) = dc.Caption
                Next

                Dim LastColumn As String = ColumnIndexToColumnLetter(dt.Columns.Count)
                Dim Lastrow As Integer = dt.Rows.Count + 1 ''change

                Dim row As Integer = 0
                Dim col As Integer = 0
                If Not isblanksheet Then
                    wSheet.Range("A" & (GridCurrentRowIndex + rowIndex + 1), LastColumn & (GridLastSavedRowIndex + rowIndex + 1)).Value2 = rawData
                End If
                rawData = Nothing
                dt = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                If gv.ChildRows.Count - 1 > (GridLastSavedRowIndex + 1) Then
                    isResteRawData = True
                Else
                    isResteRawData = False
                End If
            End While
            'Dim jj As Integer = -1
            'For i As Integer = 0 To gv.Columns.Count - 1
            '    If gv.Columns(i).IsVisible Then
            '        jj = jj + 1
            '        If TypeOf gv.Columns(i) Is GridViewTextBoxColumn Then
            '            wSheet.Range(ColumnIndexToColumnLetter(jj + 1) & ":" & ColumnIndexToColumnLetter(jj + 1)).Cells.NumberFormat = "@"
            '        End If
            '    End If
            'Next

            clsCommon.ProgressBarPercentUpdate(100, "Wait Adjusting Columns Autofit ")

            If doubleheadershowninExcel = False Then
                wSheet.Columns.AutoFit()
            End If

            Dim strFileName As String = flname
            Dim blnFileOpen As Boolean = False
            clsCommon.ProgressBarPercentUpdate(100, "Wait Saving Excel file in expected Format ")
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()

            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If

            clsCommon.ProgressBarPercentUpdate(100, "Wait Opening Excel file ")
            wBook.SaveAs(strFileName)
            wBook.Close(True)

            clsCommon.ProgressBarPercentHide()
            wBook = Nothing
            wSheet = Nothing
            excel.Quit()
            excel = Nothing
            rawData = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
        Catch ex As Exception
            clsCommon.ProgressBarPercentHide()
            Throw New Exception(ex.Message)
        End Try


    End Sub

    Public Sub exportdataChilRows(ByVal gv As RadGridView, ByVal flname As String, ByVal sname As String, Optional ByVal isblanksheet As Boolean = False, Optional ByVal arrHeader As List(Of String) = Nothing)
        Try
            ''==========================Add isblanksheet Variable in Function to Save Blank Excel Sheet===================
            'If ((gv.Columns.Count = 0) Or (gv.ChildRows.Count = 0)) And isblanksheet = False Then
            '    Exit Sub
            'End If
            ''========================================================================================
            ''Creating dataset to export
            'Dim dset As New DataSet
            ''add table to dataset
            'dset.Tables.Add()
            'Dim IndexList As List(Of String) = New List(Of String)
            'For i As Integer = 0 To gv.Columns.Count - 1
            '    If Not gv.Columns(i).IsVisible Then
            '        IndexList.Add(gv.Columns(i).Name)
            '    End If
            'Next

            'For i As Integer = 0 To IndexList.Count - 1
            '    gv.Columns.Remove(IndexList.Item(i).ToString())
            'Next

            'clsCommon.ProgressBarPercentShow()
            ''add column to that table
            'For i As Integer = 0 To gv.ColumnCount - 1
            '    'dset.Tables(0).Columns.Add(gv.Columns(i).HeaderText)
            '    dset.Tables(0).Columns.Add("Column" & (i + 1))
            '    dset.Tables(0).Columns("Column" & (i + 1)).Caption = gv.Columns(i).HeaderText
            'Next
            ''add rows to the table

            'Dim dr1 As DataRow


            ''For row = 0 To dt.Rows.Count - 1
            ''    For col = 0 To dt.Columns.Count - 1
            ''        rawData(row, col) = dt.Rows(row).ItemArray(col)
            ''    Next
            ''    clsCommon.ProgressBarPercentUpdate((row * 100) / dt.Rows.Count, " Exporting Record  " & row & "  Out of " & dt.Rows.Count)
            ''Next
            'Dim excel As New Microsoft.Office.Interop.Excel.Application
            'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            'Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            'Dim GridCurrentRowIndex As Int64 = -1
            'Dim GridLastSavedRowIndex As Int64 = -1

            'wBook = excel.Workbooks.Add()
            'Dim rawData(gv.RowCount, gv.Columns.Count - 1) As Object
            'wSheet = wBook.ActiveSheet()
            'If clsCommon.myLen(sname) > 31 Then
            '    sname = sname.Substring(0, 31)
            'End If
            ''Dim dp As Object
            '' dp = wBook.BuiltinDocumentProperties
            ''dp("Tags").Value = clsUserMgtCode.frmComplaintMaster
            'wSheet.Name = sname
            'Dim flag As Boolean = False
            'Dim colnum As Integer = -1
            'Dim PrevCol As Integer = -1
            'Dim isResteRawData As Boolean = True
            'Dim ColNums(0 To gv.Columns.Count - 1) As Integer
            'Dim MaxRowsToExport As Integer = clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.QuickExport, clsFixedParameterCode.MaxRowsForQuickExport, Nothing))
            'Dim jk As Integer = 0
            'For i As Integer = 0 To gv.Columns.Count - 1
            '    jk += 1
            '    If TypeOf gv.Columns(i) Is GridViewTextBoxColumn Then
            '        wSheet.Range(ColumnIndexToColumnLetter(jk) & ":" & ColumnIndexToColumnLetter(jk)).Cells.NumberFormat = "@"
            '    End If
            'Next
            'While isResteRawData
            '    If gv.ChildRows.Count <= MaxRowsToExport Then
            '        ReDim rawData(gv.ChildRows.Count, gv.Columns.Count - 1)
            '        'If Not IsNothing(arrHeader) Then
            '        '    GridCurrentRowIndex = 0 + arrHeader.Count
            '        '    GridLastSavedRowIndex = gv.ChildRows.Count - 1 + arrHeader.Count
            '        'Else
            '        GridCurrentRowIndex = 0
            '        GridLastSavedRowIndex = gv.ChildRows.Count - 1
            '        ' End If

            '        isResteRawData = False
            '    Else
            '        GridCurrentRowIndex = GridLastSavedRowIndex + 1
            '        If GridLastSavedRowIndex + MaxRowsToExport <= gv.ChildRows.Count Then
            '            ReDim rawData(MaxRowsToExport, gv.Columns.Count - 1)
            '            GridLastSavedRowIndex = (GridLastSavedRowIndex + MaxRowsToExport)
            '            isResteRawData = True
            '        Else
            '            ReDim rawData(gv.ChildRows.Count - GridLastSavedRowIndex, gv.Columns.Count - 1)
            '            GridLastSavedRowIndex = (GridLastSavedRowIndex + (gv.ChildRows.Count - GridLastSavedRowIndex))
            '            isResteRawData = False
            '        End If
            '        'GridLastSavedRowIndex = (GridLastSavedRowIndex + MaxRowsToExport)
            '    End If
            '    Dim RowDataRIndix As Integer = 0
            '    For i As Integer = GridCurrentRowIndex To GridLastSavedRowIndex
            '        'gv.RowCount, gv.Columns.Count - 1
            '        dr1 = dset.Tables(0).NewRow
            '        clsCommon.ProgressBarPercentUpdate(((i + 1) * 100) / gv.ChildRows.Count, " Exporting Record  " & (i + 1) & "  Out of " & gv.ChildRows.Count)
            '        Try
            '            For j As Integer = 0 To gv.Columns.Count - 1
            '                dr1(j) = clsCommon.myCstr(gv.ChildRows(i).Cells(j).Value)
            '                rawData(RowDataRIndix, j) = dr1(j).ToString()
            '            Next
            '        Catch ex As Exception
            '        End Try
            '        dset.Tables(0).Rows.Add(dr1)
            '        RowDataRIndix = RowDataRIndix + 1
            '    Next
            '    Try
            '        CType(wBook.Sheets("Sheet2"), Excel.Worksheet).Delete()
            '        CType(wBook.Sheets("Sheet3"), Excel.Worksheet).Delete()
            '    Catch ex As Exception
            '    End Try

            '    Dim dt As System.Data.DataTable = dset.Tables(0)
            '    Dim dc As System.Data.DataColumn
            '    ' Dim dr As System.Data.DataRow
            '    Dim colIndex As Integer = 1
            '    Dim rowIndex As Integer = 1

            '    If Not IsNothing(arrHeader) Then
            '        For Each Str As String In arrHeader
            '            excel.Cells(rowIndex, colIndex) = Str
            '            rowIndex += 1
            '        Next

            '    End If
            '    For Each dc In dt.Columns
            '        ' colIndex = colIndex + 1
            '        excel.Cells(rowIndex, colIndex) = dc.Caption
            '        colIndex = colIndex + 1
            '    Next

            '    Dim LastColumn As String = ColumnIndexToColumnLetter(dt.Columns.Count)
            '    Dim Lastrow As Integer = dt.Rows.Count + 1 ''change

            '    Dim row As Integer = 0
            '    Dim col As Integer = 0
            '    If Not IsNothing(arrHeader) Then
            '        GridCurrentRowIndex = GridCurrentRowIndex + arrHeader.Count
            '        GridLastSavedRowIndex = GridLastSavedRowIndex + arrHeader.Count
            '    End If
            '    wSheet.Range("A" & (GridCurrentRowIndex + 2), LastColumn & (GridLastSavedRowIndex + 2)).Value2 = rawData
            '    rawData = Nothing
            '    dt = Nothing
            '    GC.Collect()
            '    GC.WaitForPendingFinalizers()
            '    If gv.ChildRows.Count - 1 > (GridLastSavedRowIndex + 1) Then
            '        isResteRawData = True
            '    Else
            '        isResteRawData = False
            '    End If
            'End While
            ''Dim jj As Integer = -1
            ''For i As Integer = 0 To gv.Columns.Count - 1
            ''    If gv.Columns(i).IsVisible Then
            ''        jj = jj + 1
            ''        If TypeOf gv.Columns(i) Is GridViewTextBoxColumn Then
            ''            wSheet.Range(ColumnIndexToColumnLetter(jj + 1) & ":" & ColumnIndexToColumnLetter(jj + 1)).Cells.NumberFormat = "@"
            ''        End If
            ''    End If
            ''Next

            'clsCommon.ProgressBarPercentUpdate(100, "Wait Adjusting Columns Autofit ")

            'wSheet.Columns.AutoFit()
            'Dim strFileName As String = flname
            'Dim blnFileOpen As Boolean = False
            'clsCommon.ProgressBarPercentUpdate(100, "Wait Saving Excel file in expected Format ")
            'Try
            '    Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            '    fileTemp.Close()

            'Catch ex As Exception
            '    blnFileOpen = False
            'End Try

            'If System.IO.File.Exists(strFileName) Then
            '    System.IO.File.Delete(strFileName)
            'End If

            'clsCommon.ProgressBarPercentUpdate(100, "Wait Opening Excel file ")
            'wBook.SaveAs(strFileName)
            'wBook.Close(True)

            'clsCommon.ProgressBarPercentHide()
            'wBook = Nothing
            'wSheet = Nothing
            'excel.Quit()
            'excel = Nothing
            'rawData = Nothing
            'GC.Collect()
            'GC.WaitForPendingFinalizers()
            exportdata(gv, flname, sname, isblanksheet, arrHeader)
        Catch ex As Exception
            clsCommon.ProgressBarPercentHide()
            Throw New Exception(ex.Message)
        End Try


    End Sub


    Private Function ColumnIndexToColumnLetter(ByVal colIndex As Integer) As String
        Dim div As Integer = colIndex
        Dim colLetter As String = [String].Empty
        Dim [mod] As Integer = 0
        While div > 0
            [mod] = (div - 1) Mod 26
            colLetter = (Convert.ToChar(65 + [mod])).ToString & colLetter
            div = CInt((div - [mod]) / 26)
        End While
        Return colLetter
    End Function
    Public Sub exportdataInCSV(ByVal gv As RadGridView, ByVal flname As String, ByVal sname As String, Optional ByVal isblanksheet As Boolean = False)
        '==========================Add isblanksheet Variable in Function to Save Blank Excel Sheet===================
        If ((gv.Columns.Count = 0) Or (gv.Rows.Count = 0)) And isblanksheet = False Then
            Exit Sub
        End If
        '========================================================================================
        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i As Integer = 0 To gv.ColumnCount - 1
            dset.Tables(0).Columns.Add(gv.Columns(i).HeaderText)
        Next
        'add rows to the table
        Dim dr1 As DataRow
        For i As Integer = 0 To gv.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j As Integer = 0 To gv.Columns.Count - 1
                dr1(j) = gv.Rows(i).Cells(j).Value.ToString
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        'wBook = excel.Workbooks.Add()

        'wSheet = wBook.ActiveSheet()
        'If clsCommon.myLen(sname) > 31 Then
        '    sname = sname.Substring(0, 31)
        'End If
        'Dim dp As Object
        ' dp = wBook.BuiltinDocumentProperties
        'dp("Tags").Value = clsUserMgtCode.frmComplaintMaster
        'wSheet.Name = sname
        'wSheet.Cells.NumberFormat = "@"
        'Try
        '    CType(wBook.Sheets("Sheet2"), Excel.Worksheet).Delete()
        '    CType(wBook.Sheets("Sheet3"), Excel.Worksheet).Delete()
        'Catch ex As Exception

        'End Try

        Dim dt As System.Data.DataTable = dset.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim strData As String = String.Empty
        For Each dc In dt.Columns
            colIndex = colIndex + 1
            strData = strData & dc.ColumnName
            If colIndex <> (dt.Columns.Count) Then
                strData = strData & ","
            Else
                strData = strData & Environment.NewLine
            End If
        Next
        clsCommon.ProgressBarPercentShow()
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1

            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                'excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName).ToString
                strData = strData & dr(dc.ColumnName).ToString
                If colIndex <> (dt.Columns.Count) Then
                    strData = strData & ","
                Else
                    strData = strData & Environment.NewLine
                End If
            Next
            clsCommon.ProgressBarPercentUpdate(rowIndex * 100 / dt.Rows.Count, "Exporting " + clsCommon.myCstr(rowIndex) + "/" + clsCommon.myCstr(dt.Rows.Count))
        Next
        clsCommon.ProgressBarPercentHide()
        'Dim fl As System.IO.File
        'fl.Create(flname)
        File.WriteAllText(flname, strData)
        'fl.c


        'wSheet.Columns.AutoFit()
        'Dim strFileName As String = flname
        'Dim blnFileOpen As Boolean = False
        'Try
        '    Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
        '    fileTemp.Close()

        'Catch ex As Exception
        '    blnFileOpen = False
        'End Try

        'If System.IO.File.Exists(strFileName) Then
        '    System.IO.File.Delete(strFileName)

        'End If


        'wBook.SaveAs(strFileName)
        'Dim dp As Object = wBook.BuiltinDocumentProperties
        'dp("Keywords").Value = clsUserMgtCode.frmComplaintMaster
        'excel.DisplayAlerts = False
        'wBook.Close(True)




    End Sub
    ''''''Function to export data with custom filed
    Public Sub exportdatawithcustomfield(ByVal gv As RadGridView, ByVal flname As String, ByVal sname As String, ByVal formid As String)
        If ((gv.Columns.Count = 0) Or (gv.Rows.Count = 0)) Then
            Exit Sub
        End If

        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i As Integer = 0 To gv.ColumnCount - 1
            dset.Tables(0).Columns.Add(gv.Columns(i).HeaderText)
        Next
        Dim drr As DataTable
        Dim qry1 As String = "select TSPL_CUSTOM_FIELD_HEAD.Name,TSPL_CUSTOM_FIELD_HEAD.Code,TSPL_CUSTOM_FIELD_MAPPING.Program_Code  from TSPL_CUSTOM_FIELD_HEAD left outer join TSPL_CUSTOM_FIELD_MAPPING on TSPL_CUSTOM_FIELD_MAPPING.Custom_Field_Code =TSPL_CUSTOM_FIELD_HEAD.Code WHERE PROGRAM_CODE='" & formid & "'"
        drr = clsDBFuncationality.GetDataTable(qry1)
        Dim j As Integer = gv.Columns.Count
        'Dim i As Integer = 0
        For Each row As DataRow In drr.Rows
            dset.Tables(0).Columns.Add(row(1).ToString)
            dset.Tables(0).Columns(j).ColumnName = row(1).ToString
            dset.Tables(0).Columns(j).Caption = row(0).ToString
            j = j + 1
        Next


        'add rows to the table
        Dim dr1 As DataRow
        For i As Integer = 0 To gv.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j = 0 To gv.Columns.Count - 1
                dr1(j) = gv.Rows(i).Cells(j).Value.ToString
            Next
            For j = gv.Columns.Count To dset.Tables(0).Columns.Count - 1

                Dim q1 As String = "select value from tspl_custom_field_values where program_code='" & formid & "' and transaction_code='" & dr1(0).ToString & "' and custom_field_code='" & dset.Tables(0).Columns(j).ColumnName & "'"

                dr1(j) = clsDBFuncationality.getSingleValue(q1)
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        Dim excel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        wBook = excel.Workbooks.Add()

        wSheet = wBook.ActiveSheet()
        wSheet.Cells.NumberFormat = "@"
        wSheet.Name = sname
        CType(wBook.Sheets("Sheet2"), Excel.Worksheet).Delete()
        CType(wBook.Sheets("Sheet3"), Excel.Worksheet).Delete()
        Dim dt As System.Data.DataTable = dset.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            If colIndex >= gv.Columns.Count Then
                excel.Cells(1, colIndex) = dc.Caption
            Else
                excel.Cells(1, colIndex) = dc.ColumnName
            End If

        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName).ToString

            Next
        Next

        wSheet.Columns.AutoFit()
        Dim strFileName As String = flname
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)

        End If


        wBook.SaveAs(strFileName)

        excel.DisplayAlerts = False
        wBook.Close()

    End Sub

    Private Sub exporter_ExcelCellFormatting(ByVal sender As Object, ByVal e As ExcelML.ExcelCellFormattingEventArgs)
        If e.GridRowInfoType Is GetType(GridViewTableHeaderRowInfo) Then
            e.ExcelStyleElement.FontStyle.Bold = True
            e.ExcelStyleElement.FontStyle.Size = 10
            ''e.ExcelStyleElement.FontStyle.Color = Color.AliceBlue
        ElseIf e.GridRowInfoType Is GetType(GridViewDataRowInfo) Then
            e.ExcelStyleElement.FontStyle.Size = 9
            'Else
            '    e.ExcelCellElement.MergeAcross = 2
        End If
    End Sub
    Private Sub exporter_ExcelCellFormattingForOpen(ByVal sender As Object, ByVal e As ExcelML.ExcelCellFormattingEventArgs)
        If e.GridRowInfoType Is GetType(GridViewTableHeaderRowInfo) Then
            e.ExcelStyleElement.FontStyle.Bold = True
            e.ExcelStyleElement.FontStyle.Size = 10
            e.ExcelStyleElement.InteriorStyle.Color = Color.LightBlue
            e.ExcelStyleElement.FontStyle.Color = Color.AliceBlue
        ElseIf e.GridRowInfoType Is GetType(GridViewDataRowInfo) Then
            e.ExcelStyleElement.FontStyle.Size = 9
            'Else
            '    e.ExcelCellElement.MergeAcross = 2
        End If
    End Sub

    Dim count As Integer = 0

    Public Function importExcelForItemMaster(ByVal strSheetName As String, ByVal gv As RadGridView, ByVal gv1 As RadGridView, ByVal gv2 As RadGridView, ByVal filePath As String, ByVal ParamArray fieldNames As String()) As Boolean
        count += 1
        Try
            Dim Extension As String = Path.GetExtension(filePath)
            Dim conStr As String = ""
            'Select Case Extension
            '   Case ".xls"
            'Excel 97-03 
            'conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
            'Exit Select
            '    Case ".xlsx"
            'Excel 07  
            'conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"";"
            'Exit Select
            'End Select
            conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;"
            conStr = [String].Format(conStr, filePath)
            Dim connExcel As New OleDbConnection(conStr)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            Dim ds As New DataTable()
            cmdExcel.Connection = connExcel

            'Get the name of First Sheet  
            connExcel.Open()
            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String
            Dim isFound As Boolean = False
            For Each dr As DataRow In dtExcelSchema.Rows
                SheetName = clsCommon.myCstr(dr("TABLE_NAME"))

                If ((clsCommon.CompairString(SheetName, strSheetName) = CompairStringResult.Equal) AndAlso (clsCommon.CompairString(SheetName, "ItemMaster$") = CompairStringResult.Equal)) Then
                    isFound = True
                    connExcel.Close()
                    connExcel.Open()
                    cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
                    oda.SelectCommand = cmdExcel
                    oda.Fill(ds)
                    connExcel.Close()
                    gv.DataSource = ds.DefaultView
                    gv.AllowColumnReorder = True
                    Dim fieldCount As Integer = fieldNames.Length
                    Dim strfields As String = ""
                    For Each field As String In fieldNames
                        strfields = strfields + field + ","
                    Next
                    If fieldCount <= gv.ColumnCount Then
                        Dim i As Integer = 0
                        Dim arr As ArrayList = New ArrayList()
                        For Each GC As GridViewColumn In gv.Columns
                            arr.Add(GC.HeaderText)
                        Next
                        For Each field As String In fieldNames
                            If arr.Contains(field) Then
                                For Each GC As GridViewColumn In gv.Columns
                                    If GC.HeaderText = field Then
                                        gv.Columns.Move(GC.Index, i)
                                        Exit For
                                    End If
                                Next
                            Else
                                Throw New Exception("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
                            End If
                            i = i + 1
                        Next
                    Else
                        Throw New Exception("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
                    End If
                    connExcel.Close()
                ElseIf ((clsCommon.CompairString(SheetName, strSheetName) = CompairStringResult.Equal) AndAlso (clsCommon.CompairString(SheetName, "ItemDetails$") = CompairStringResult.Equal)) Then
                    isFound = True
                    connExcel.Close()
                    'Read Data from First Sheet  
                    connExcel.Open()
                    cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
                    oda.SelectCommand = cmdExcel
                    ds.Dispose()

                    oda.Fill(ds)
                    connExcel.Close()
                    gv1.DataSource = ds.DefaultView
                    gv1.AllowColumnReorder = True

                    Dim fieldCount As Integer = fieldNames.Length
                    Dim strfields As String = ""
                    For Each field As String In fieldNames
                        strfields = strfields + field + ","
                    Next
                    If fieldCount <= gv1.ColumnCount Then
                        Dim i As Integer = 0
                        Dim arr As ArrayList = New ArrayList()
                        For Each GC As GridViewColumn In gv1.Columns
                            arr.Add(GC.HeaderText)
                        Next
                        For Each field As String In fieldNames
                            If arr.Contains(field) Then
                                For Each GC As GridViewColumn In gv1.Columns
                                    If GC.HeaderText = field Then
                                        gv1.Columns.Move(GC.Index, i)
                                        Exit For
                                    End If
                                Next
                            Else
                                Throw New Exception("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
                            End If
                            i = i + 1
                        Next
                    Else
                        Throw New Exception("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
                    End If
                    connExcel.Close()
                ElseIf ((clsCommon.CompairString(SheetName, strSheetName) = CompairStringResult.Equal) AndAlso (clsCommon.CompairString(SheetName, "ItemUOMDetails$") = CompairStringResult.Equal)) Then
                    isFound = True
                    connExcel.Close()
                    connExcel.Open()
                    cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
                    oda.SelectCommand = cmdExcel
                    oda.Fill(ds)
                    connExcel.Close()
                    gv2.DataSource = ds.DefaultView
                    gv2.AllowColumnReorder = True
                    Dim fieldCount As Integer = fieldNames.Length
                    Dim strfields As String = ""
                    For Each field As String In fieldNames
                        strfields = strfields + field + ","
                    Next
                    If fieldCount <= gv2.ColumnCount Then
                        Dim i As Integer = 0
                        Dim arr As ArrayList = New ArrayList()
                        For Each GC As GridViewColumn In gv2.Columns
                            arr.Add(GC.HeaderText)
                        Next
                        For Each field As String In fieldNames
                            If arr.Contains(field) Then
                                For Each GC As GridViewColumn In gv2.Columns
                                    If GC.HeaderText = field Then
                                        gv2.Columns.Move(GC.Index, i)
                                        Exit For
                                    End If
                                Next
                            Else
                                Throw New Exception("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
                            End If
                            i = i + 1
                        Next
                    Else
                        Throw New Exception("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
                    End If
                End If
            Next
            If isFound Then
                Return True
            Else
                Throw New Exception(strSheetName + "Excel Sheet not found- ")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function getColumns(ByVal fileName As String) As String()
        Try
            Dim fileReader As New StreamReader(fileName)
            Dim line As String = fileReader.ReadLine
            fileReader.Close()
            Dim Columns() As String = line.Split(",")
            Return Columns
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function ReturnData(ByVal fileName As String) As DataTable
        Try
            Dim dt As New DataTable
            For Each columnName As String In getColumns(fileName)
                dt.Columns.Add(columnName)
            Next
            Dim fileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(fileName)
            ' If ColumnNames Then
            fileReader.SetDelimiters(",")
            'fileReader.ReadLine()
            fileReader.ReadFields()
            'End If
            Dim line() As String
            While Not fileReader.EndOfData
                'line = line.Replace(Chr(34), "")
                line = fileReader.ReadFields()
                dt.Rows.Add(line)
                'line = fileReader.ReadLine
            End While
            fileReader.Close()
            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function importExcelFromCSV(ByVal gv As RadGridView, ByVal filePath As String, ByVal ParamArray fieldNames As String()) As Boolean
        Dim ds As DataTable = ReturnData(filePath)
        gv.DataSource = ds
        gv.AllowColumnReorder = True
        Dim fieldCount As Integer = fieldNames.Length
        Dim strfields As String = ""
        For Each field As String In fieldNames
            strfields = strfields + field + ","
        Next

        If fieldCount <= gv.ColumnCount Then
            Dim i As Integer = 0
            Dim arr As ArrayList = New ArrayList()
            For Each GC As GridViewColumn In gv.Columns
                arr.Add(GC.HeaderText)
            Next
            For Each field As String In fieldNames
                If arr.Contains(field.Trim()) Then

                    For Each GC As GridViewColumn In gv.Columns
                        If GC.HeaderText = field Then
                            gv.Columns.Move(GC.Index, i)
                            Exit For
                        End If
                    Next
                Else
                    common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
                    Return False
                End If
                i = i + 1
            Next
        Else
            common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
            Return False
        End If
        Return True
    End Function
    'Public Function importExcel(ByVal gv As RadGridView, ByVal ParamArray fieldNames As String()) As Boolean
    '    Try

    '        Dim ofd As OpenFileDialog = New OpenFileDialog()
    '        Dim filePath As String
    '        ofd.Filter = "Excel 97-2003 (*.xls) |*.xls;|Excel 2007 (*.xlsx)|*.xlsx;|CSV Files (*.csv) |*.csv"
    '        If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '            filePath = ofd.FileName
    '        Else
    '            Return False
    '        End If
    '        Dim Extension As String = Path.GetExtension(filePath)
    '        Dim conStr As String = ""


    '        'Dim oApp As Excel.Application
    '        'Dim oWB As Excel.Workbook
    '        'oApp = New Excel.Application
    '        'oWB = oApp.Workbooks.Open(filePath)
    '        'MessageBox.Show(oWB.FileFormat.ToString)
    '        Dim rvalue As Boolean = False
    '        If clsCommon.CompairString(Extension, ".csv") = CompairStringResult.Equal Then
    '            rvalue = importExcelFromCSV(gv, filePath, fieldNames)
    '            Return rvalue
    '        End If

    '        Select Case Extension
    '            Case ".xls"
    '                '        'Excel 97-03 
    '                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
    '                Exit Select
    '            Case ".xlsx"
    '                '        'Excel 07  
    '                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"";"
    '                Exit Select
    '        End Select
    '        'conStr = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=NO;IMEX=1"";"
    '        conStr = [String].Format(conStr, filePath)

    '        Dim connExcel As New OleDbConnection(conStr)
    '        Dim cmdExcel As New OleDbCommand()
    '        Dim oda As New OleDbDataAdapter()
    '        Dim ds As New DataTable()
    '        cmdExcel.Connection = connExcel

    '        'Get the name of First Sheet  
    '        connExcel.Open()
    '        Dim dtExcelSchema As DataTable
    '        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
    '        connExcel.Close()

    '        'Read Data from First Sheet  
    '        connExcel.Open()
    '        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
    '        oda.SelectCommand = cmdExcel
    '        oda.Fill(ds)
    '        connExcel.Close()
    '        gv.DataSource = ds.DefaultView
    '        gv.AllowColumnReorder = True
    '        Dim fieldCount As Integer = fieldNames.Length
    '        Dim strfields As String = ""
    '        For Each field As String In fieldNames
    '            strfields = strfields + field + ","
    '        Next

    '        If fieldCount <= gv.ColumnCount Then
    '            Dim i As Integer = 0
    '            Dim arr As ArrayList = New ArrayList()
    '            For Each GC As GridViewColumn In gv.Columns
    '                arr.Add(GC.HeaderText)
    '            Next
    '            For Each field As String In fieldNames
    '                If arr.Contains(field.Trim()) Then

    '                    For Each GC As GridViewColumn In gv.Columns
    '                        If GC.HeaderText = field Then
    '                            gv.Columns.Move(GC.Index, i)
    '                            Exit For
    '                        End If
    '                    Next
    '                Else
    '                    common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
    '                    Return False
    '                End If
    '                i = i + 1
    '            Next
    '        Else
    '            common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
    '            Return False
    '        End If
    '       Return True

    '    Catch ex As Exception
    '        'common.clsCommon.MyMessageBoxShow("No data transfered.", "Import Error", MessageBoxButtons.OK)
    '        clsCommon.MyMessageBoxShow(ex.Message)
    '    End Try
    'End Function
    Public Function importExcelPivot(ByVal gv As RadGridView, ByVal strPivotCount As Integer, ByVal strPivot As String, ByVal ParamArray fieldNames As String()) As Boolean
        Try
            If Not LoadDocument(gv, "", fieldNames) Then
                Return False
            End If

            'Dim fieldCount As Integer = fieldNames.Length
            'fieldCount = fieldCount + strPivotCount
            'Dim strfields As String = ""
            'For Each field As String In fieldNames
            '    strfields = strfields + field + ","
            'Next
            'strfields = strfields.Substring(0, strfields.Length - 1)
            'strfields = strfields + "," + strPivot

            'If fieldCount <= gv.ColumnCount Then
            '    Dim i As Integer = 0
            '    Dim arr As ArrayList = New ArrayList()
            '    For Each GC As GridViewColumn In gv.Columns
            '        arr.Add(GC.HeaderText)
            '    Next
            '    For Each field As String In fieldNames
            '        If arr.Contains(field.Trim()) Then

            '            For Each GC As GridViewColumn In gv.Columns
            '                If GC.HeaderText = field Then
            '                    gv.Columns.Move(GC.Index, i)
            '                    Exit For
            '                End If
            '            Next
            '        Else
            '            common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
            '            Return False
            '        End If
            '        i = i + 1
            '    Next
            'Else
            '    common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
            '    Return False
            'End If


        Catch ex As Exception
            'common.clsCommon.MyMessageBoxShow("No data transfered.", "Import Error", MessageBoxButtons.OK)
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
        Return True
    End Function

    Public Function importExcel(ByVal gv As RadGridView, ByVal ParamArray fieldNames As String()) As Boolean
        Try

            'Dim ofd As OpenFileDialog = New OpenFileDialog()
            'Dim filepath As String
            'ofd.Filter = "excel 97-2003 (*.xls) |*.xls;|excel 2007 (*.xlsx)|*.xlsx;|csv files (*.csv) |*.csv"
            'If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            '    filepath = ofd.FileName
            'Else
            '    Return False
            'End If
            'Dim extension As String = Path.GetExtension(filepath)
            'Dim constr As String = ""


            ''dim oapp as excel.application
            ''dim owb as excel.workbook
            ''oapp = new excel.application
            ''owb = oapp.workbooks.open(filepath)
            ''messagebox.show(owb.fileformat.tostring)
            'Dim rvalue As Boolean = False
            'If clsCommon.CompairString(extension, ".csv") = CompairStringResult.Equal Then
            '    rvalue = importExcelFromCSV(gv, filepath, fieldNames)
            '    Return rvalue
            'End If

            'Select Case extension
            '    Case ".xls"
            '        '        'excel 97-03 
            '        constr = "provider=microsoft.ace.oledb.12.0;data source=" & filepath & ";extended properties=""excel 8.0;hdr=yes;imex=1"";"
            '        Exit Select
            '    Case ".xlsx"
            '        '        'excel 07  
            '        constr = "provider=microsoft.ace.oledb.12.0;data source=" & filepath & ";extended properties=""excel 12.0;hdr=yes;imex=1"";"
            '        Exit Select
            'End Select
            ''constr = "provider=microsoft.jet.oledb.4.0;data source=" & filepath & ";extended properties=""excel 8.0;hdr=no;imex=1"";"
            'constr = [String].Format(constr, filepath)

            'Dim connexcel As New OleDbConnection(constr)
            'Dim cmdexcel As New OleDbCommand()
            'Dim oda As New OleDbDataAdapter()
            'Dim ds As New DataTable()
            'cmdexcel.Connection = connexcel

            ''get the name of first sheet  
            'connexcel.Open()
            'Dim dtexcelschema As DataTable
            'dtexcelschema = connexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            'Dim sheetname As String = dtexcelschema.Rows(0)("table_name").ToString()
            'connexcel.Close()

            ''read data from first sheet  
            'connexcel.Open()
            'cmdexcel.CommandText = "select * from [" & sheetname & "]"
            'oda.SelectCommand = cmdexcel
            'oda.Fill(ds)
            'connexcel.Close()
            'gv.DataSource = ds.DefaultView
            'gv.AllowColumnReorder = True
            If Not LoadDocument(gv, "", fieldNames) Then
                Return False
            End If
            Dim fieldCount As Integer = fieldNames.Length
            Dim strfields As String = ""
            For Each field As String In fieldNames
                strfields = strfields + field + ","
            Next

            If fieldCount <= gv.ColumnCount Then
                Dim i As Integer = 0
                Dim arr As ArrayList = New ArrayList()
                For Each GC As GridViewColumn In gv.Columns
                    arr.Add(GC.HeaderText.Trim().ToUpper())
                Next
                For Each field As String In fieldNames
                    If arr.Contains(field.Trim().ToUpper()) Then
                        For Each GC As GridViewColumn In gv.Columns
                            If GC.HeaderText = field Then
                                gv.Columns.Move(GC.Index, i)
                                Exit For
                            End If
                        Next
                    Else
                        common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
                        Return False
                    End If
                    i = i + 1
                Next
            Else
                common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
                Return False
            End If


        Catch ex As Exception
            'common.clsCommon.MyMessageBoxShow("No data transfered.", "Import Error", MessageBoxButtons.OK)
            clsCommon.MyMessageBoxShow(ex.Message)
        End Try
        Return True
    End Function


    '====================Made By Monika For getting runtime excel sheet Columns Name===============02/06/2014===
    Public Function GetExcelColumnsName(ByVal gv1 As RadGridView) As String
        Return GetExcelColumnsName(gv1, "", "")
    End Function
    Public Function GetExcelColumnsName(ByVal gv1 As RadGridView, ByRef FileName As String, ByRef SafeFileName As String) As String
        Dim columnsname As String = ""
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog()
            Dim filePath As String
            ofd.Filter = "Excel 97-2003 (*.xls) |*.xls;|Excel 2007 (*.xlsx)|*.xlsx;|CSV Files (*.csv) |*.csv"
            If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                filePath = ofd.FileName
            Else
                Return columnsname
            End If
            Dim Extension As String = Path.GetExtension(filePath)
            Dim conStr As String = ""

            FileName = ofd.FileName
            SafeFileName = ofd.SafeFileName

            If clsCommon.CompairString(Extension, ".CSV") = CompairStringResult.Equal Then
                gv1.DataSource = ReturnData(filePath)
            Else
                Select Case Extension
                    Case ".xls"
                        '        'Excel 97-03 
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
                        Exit Select
                    Case ".xlsx"
                        '        'Excel 07  
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=Excel 12.0 Xml;HDR=Yes;IMEX=1"";"
                        Exit Select
                End Select

                'Select Case Extension
                '    Case ".xls"
                '        '        'Excel 97-03 
                '        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
                '        Exit Select
                '    Case ".xlsx"
                '        '        'Excel 07  
                '        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"";"
                '        Exit Select
                'End Select
                conStr = [String].Format(conStr, filePath)
                Dim connExcel As New OleDbConnection(conStr)
                Dim cmdExcel As New OleDbCommand()
                Dim oda As New OleDbDataAdapter()
                Dim ds As New DataTable()
                cmdExcel.Connection = connExcel
                'Get the name of First Sheet  
                connExcel.Open()
                Dim dtExcelSchema As DataTable
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
                connExcel.Close()
                'Read Data from First Sheet  
                connExcel.Open()
                cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
                oda.SelectCommand = cmdExcel
                oda.Fill(ds)
                connExcel.Close()
                gv1.DataSource = ds.DefaultView
                gv1.AllowColumnReorder = True
            End If
            columnsname = ""
            If gv1.Rows.Count > 0 Then
                For Each GC As GridViewColumn In gv1.Columns
                    columnsname = columnsname + "," + Chr(34) + clsCommon.myCstr(GC.HeaderText) + Chr(34)
                Next
            End If

            Try
                If columnsname.Substring(0, 1) = "," Then
                    columnsname = columnsname.Substring(1, columnsname.Length - 1).Replace("#", ".")
                End If
            Catch exx As Exception
            End Try
            Return columnsname
        Catch ex As Exception
            Return columnsname
            Throw New Exception(ex.Message)
        End Try
    End Function
    '==========================================================================

    'Public Function importExcel(ByVal gv As RadGridView, ByVal ParamArray fieldNames As String()) As Boolean
    '    Try
    '        Dim ofd As OpenFileDialog = New OpenFileDialog()
    '        Dim filePath As String
    '        ofd.Filter = "Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
    '        If ofd.ShowDialog() = System.System.Windows.Forms.DialogResult.OK Then
    '            filePath = ofd.FileName
    '        Else
    '            Return False
    '        End If
    '        Dim Extension As String = Path.GetExtension(filePath)
    '        Dim conStr As String = ""
    '        Select Case Extension
    '            Case ".xls"
    '                'Excel 97-03 
    '                conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filePath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
    '                Exit Select
    '            Case ".xlsx"
    '                'Excel 07  
    '                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"";"
    '                Exit Select
    '        End Select
    '        conStr = [String].Format(conStr, filePath)
    '        Dim connExcel As New OleDbConnection(conStr)
    '        Dim cmdExcel As New OleDbCommand()
    '        Dim oda As New OleDbDataAdapter()
    '        Dim ds As New DataTable()
    '        cmdExcel.Connection = connExcel

    '        'Get the name of First Sheet  
    '        connExcel.Open()
    '        Dim dtExcelSchema As DataTable
    '        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
    '        connExcel.Close()

    '        'Read Data from First Sheet  
    '        connExcel.Open()
    '        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
    '        oda.SelectCommand = cmdExcel

    '        ds.Dispose()
    '        oda.Fill(ds)
    '        connExcel.Close()
    '        gv.DataSource = ds.DefaultView
    '        gv.AllowColumnReorder = True
    '        Dim fieldCount As Integer = fieldNames.Length
    '        Dim strfields As String = ""
    '        For Each field As String In fieldNames
    '            strfields = strfields + field + ","
    '        Next
    '        If fieldCount <= gv.ColumnCount Then
    '            Dim i As Integer = 0
    '            Dim arr As ArrayList = New ArrayList()
    '            For Each GC As GridViewColumn In gv.Columns
    '                arr.Add(GC.HeaderText)
    '            Next
    '            For Each field As String In fieldNames
    '                If arr.Contains(field) Then
    '                    For Each GC As GridViewColumn In gv.Columns
    '                        If GC.HeaderText = field Then
    '                            gv.Columns.Move(GC.Index, i)
    '                            Exit For
    '                        End If
    '                    Next
    '                Else
    '                    common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format.It should have the columns named - " + strfields)
    '                    Return False
    '                End If
    '                i = i + 1
    '            Next
    '        Else
    '            common.clsCommon.MyMessageBoxShow("Excel Sheet is not in expected format. It should have the columns named - " + strfields)
    '            Return False
    '        End If
    '        Return True

    '    Catch ex As Exception
    '        'common.clsCommon.MyMessageBoxShow("No data transfered.", "Import Error", MessageBoxButtons.OK)
    '        Throw ex
    '    End Try
    'End Function
    'Public Sub generateReport(ByVal sql As String, ByVal reportName As String, ByVal caption As String)
    '    Dim crptReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    '    Dim strFormCaption As String = "1.0.0.1"
    '    ds = connectSql.RunSQLReturnDS(sql)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim rpDoc As New ReportDocument()
    '        reportName = "crptARInvoice"
    '        Dim strReportPath As String = Application.StartupPath & "\Reports\" & reportName & ".rpt"
    '        rpDoc.Load(strReportPath)
    '        rpDoc.SetDataSource(ds.Tables(0))
    '        FrmReportViewer.Text = "AR Invoice " & "-" & strFormCaption
    '        crptReportViewer.ReportSource = rpDoc
    '        FrmReportViewer.Show()
    '    Else
    '        common.clsCommon.MyMessageBoxShow("No Data found", FrmReportViewer.Text, MessageBoxButtons.OK)
    '        FrmReportViewer.Close()

    '    End If
    'End Sub

    Public Sub generateReport(ByVal reportName As String, ByVal caption As String, Optional ByVal StrClause As String = vbNullString, Optional ByVal StrClause1 As String = vbNullString, Optional ByVal StrClause2 As String = vbNullString, Optional ByVal StrClause3 As String = vbNullString, Optional ByVal StrClause4 As String = vbNullString, Optional ByVal StrClause5 As String = vbNullString, Optional ByVal StrClause6 As String = vbNullString, Optional ByVal StrClause7 As String = vbNullString, Optional ByVal StrClause8 As String = vbNullString, Optional ByVal strReportTitle As String = vbNullString)
        ''To be Uncomment
        'Dim frm As New FrmReportViewer()
        'frm.Text = caption
        'frm.proShowReport(reportName, StrClause, StrClause1, StrClause2, StrClause3, StrClause4, StrClause5, StrClause6, StrClause7, StrClause8, strReportTitle)
        'frm.ShowDialog()
    End Sub

    'Public Function FunGrnlEntry(ByVal EntryDt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = Nothing, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing) As Boolean
    '    Dim arr As List(Of clsJournalDetailTemp) = GetMergedAccCode(StrAccCode, SrcType)
    '    Dim jrnlObj As New frmJournalEntry(User, CompCode)
    '    Dim StrVoucher As String = jrnlObj.fnAutoGenerateNo(Nothing, EntryDt,FA
    '    Dim EntryDate As String = clsCommon.GetPrintDate(clsCommon.myCDate(EntryDt), "dd/MMM/yyyy")
    '    Dim strJrnl As String = "select (case when max(journal_no) is not null then max(journal_no) else 0 end) from TSPL_JOURNAL_MASTER "
    '    Dim Jrnl As String = CInt(connectSql.RunScalar(strJrnl)) + 1

    '    If strReference = Nothing Then
    '        strReference = ""
    '    End If
    '    If strremarks = Nothing Then
    '        strremarks = ""
    '    End If

    '    Dim SrcTypeFlag As String = connectSql.RunScalar("select SourceCode  from TSPL_GL_SOURCECODE where SourceCode='" + SrcType + "'")
    '    If SrcTypeFlag = "" OrElse SrcTypeFlag = Nothing Then
    '        common.clsCommon.MyMessageBoxShow("Source Code '" + SrcType + "' Not Exist In Master!", "Journal Entry", MessageBoxButtons.OK)
    '        Return False
    '    End If


    '    connectSql.RunSp("sp_TSPL_JOURNAL_MASTER_INSERT", New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Source_Code", SrcType), New SqlParameter("@Source_Desc", SrcTypeDesc), New SqlParameter("@Source_Doc_No", SrcDocNo), New SqlParameter("@Source_Doc_Date", EntryDate), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Voucher_Desc", EntryDesc), New SqlParameter("@Source_Narration", SrcDocDesc), New SqlParameter("@Remarks", strremarks), New SqlParameter("@Comments", strReference), New SqlParameter("@Auto_Reverse", "N"), New SqlParameter("@Reverse_Date", EntryDate), New SqlParameter("@Source_Type", strSrcType), New SqlParameter("@CustVend_Code", strSrcTypeCode), New SqlParameter("@CustVend_Name", strSrcTypeDesc), New SqlParameter("@Transaction_Type", "N"), New SqlParameter("@Total_Debit_Amt", 0.0), New SqlParameter("@Total_Credit_Amt", 0.0), New SqlParameter("@Created_By", User), New SqlParameter("@Created_Date", connectSql.serverDate()), New SqlParameter("@Modify_By", User), New SqlParameter("@Modify_Date", connectSql.serverDate()), New SqlParameter("@Comp_Code", CompCode))
    '    Dim strJrnl1 As String = "select journal_no from TSPL_JOURNAL_MASTER where Voucher_No='" + StrVoucher + "'"
    '    Dim Jrnl1 As String
    '    Jrnl1 = connectSql.RunScalar(strJrnl1)

    '    Dim AccountCode As String = ""
    '    Dim i As Integer = 1
    '    Dim AmtPlus As Decimal = 0.0
    '    Dim AmtMinus As Decimal = 0.0
    '    For Each AccCode1() As String In StrAccCode
    '        Dim Amt As Decimal = Convert.ToDecimal(AccCode1(1))

    '        If Amt >= 0 Then
    '            AmtPlus = AmtPlus + Amt
    '        ElseIf Amt < 0 Then
    '            AmtMinus = AmtMinus + Amt
    '        End If

    '    Next
    '    If AmtPlus <> AmtMinus * -1 Then

    '        common.clsCommon.MyMessageBoxShow("Credit & Debit Balance is Out of Balance!", "Journal Entry", MessageBoxButtons.OK)
    '        Return False
    '    End If
    '    Dim count As Decimal = 0
    '    For Each obj As clsJournalDetailTemp In arr
    '        Dim Query As String = "Select Description  from TSPL_GL_ACCOUNTS where Account_Code ='" + obj.Account_code + "' "
    '        count = count + 1
    '        Dim strAccDesc As String = connectSql.RunScalar(Query)
    '        If clsCommon.myLen(strAccDesc) = 0 Then
    '            common.clsCommon.MyMessageBoxShow("'" + obj.Account_code + "' Account does not exixt.")
    '            Return False
    '        End If

    '        Dim Amt As Decimal = Convert.ToDecimal(obj.Amount)


    '        Dim strQ1 As String = " SELECT     Account_Type, Account_Group_Code, Account_Seg_Code1, Account_Seg_Desc1, Account_Seg_Code2, Account_Seg_Desc2, Account_Seg_Code3, " & _
    '                " Account_Seg_Desc3, Account_Seg_Code4, Account_Seg_Desc4, Account_Seg_Code5, Account_Seg_Desc5, Account_Seg_Code6, Account_Seg_Desc6," & _
    '                " Account_Seg_Code7, Account_Seg_Desc7, Account_Seg_Code8, Account_Seg_Desc8, Account_Seg_Code9, Account_Seg_Desc9, " & _
    '                " Account_Seg_Code10, Account_Seg_Desc10 FROM  TSPL_GL_ACCOUNTS where Account_Code='" + obj.Account_code + "'"

    '        Dim myreader As DataTable = clsDBFuncationality.GetDataTable(strQ1)
    '        If myreader IsNot Nothing AndAlso myreader.Rows.Count > 0 Then


    '            Dim AccType As String = myreader.Rows(0)(0).ToString()
    '            Dim AccGrp As String = myreader.Rows(0)(1).ToString()

    '            Dim SegC1 As String = myreader.Rows(0)(2).ToString()
    '            Dim SegDesc1 As String = myreader.Rows(0)(3).ToString()

    '            Dim SegC2 As String = myreader.Rows(0)(4).ToString()
    '            Dim SegDesc2 As String = myreader.Rows(0)(5).ToString()

    '            Dim SegC3 As String = myreader.Rows(0)(6).ToString()
    '            Dim SegDesc3 As String = myreader.Rows(0)(7).ToString()

    '            Dim SegC4 As String = myreader.Rows(0)(8).ToString()
    '            Dim SegDesc4 As String = myreader.Rows(0)(9).ToString()

    '            Dim SegC5 As String = myreader.Rows(0)(10).ToString()
    '            Dim SegDesc5 As String = myreader.Rows(0)(11).ToString()

    '            Dim SegC6 As String = myreader.Rows(0)(12).ToString()
    '            Dim SegDesc6 As String = myreader.Rows(0)(13).ToString()

    '            Dim SegC7 As String = myreader.Rows(0)(14).ToString()
    '            Dim SegDesc7 As String = myreader.Rows(0)(15).ToString()

    '            Dim SegC8 As String = myreader.Rows(0)(16).ToString()
    '            Dim SegDesc8 As String = myreader.Rows(0)(17).ToString()

    '            Dim SegC9 As String = myreader.Rows(0)(18).ToString()
    '            Dim SegDesc9 As String = myreader.Rows(0)(19).ToString()

    '            Dim SegC10 As String = myreader.Rows(0)(20).ToString()
    '            Dim SegDesc10 As String = myreader.Rows(0)(21).ToString()

    '            If Not (clsCommon.myCdbl(Amt) = 0) Then
    '                connectSql.RunSp("sp_TSPL_JOURNAL_DETAILS_INSERT", New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Detail_Line_No", i), New SqlParameter("@Account_code", obj.Account_code), New SqlParameter("@Account_Desc", strAccDesc), New SqlParameter("@Amount", Amt), New SqlParameter("@Description", obj.Description), New SqlParameter("@Reference", obj.Reference), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Account_Type", AccType), New SqlParameter("@Account_Group_Code", AccGrp), New SqlParameter("@Account_Seg_Code1", SegC1), New SqlParameter("@Account_Seg_Desc1", SegDesc1), New SqlParameter("@Account_Seg_Code2", SegC2), New SqlParameter("@Account_Seg_Desc2", SegDesc2), New SqlParameter("@Account_Seg_Code3", SegC3), New SqlParameter("@Account_Seg_Desc3", SegDesc3), New SqlParameter("@Account_Seg_Code4", SegC4), New SqlParameter("@Account_Seg_Desc4", SegDesc4), New SqlParameter("@Account_Seg_Code5", SegC5), New SqlParameter("@Account_Seg_Desc5", SegDesc5), New SqlParameter("@Account_Seg_Code6", SegC6), New SqlParameter("@Account_Seg_Desc6", SegDesc6), New SqlParameter("@Account_Seg_Code7", SegC7), New SqlParameter("@Account_Seg_Desc7", SegDesc7), New SqlParameter("@Account_Seg_Code8", SegC8), New SqlParameter("@Account_Seg_Desc8", SegDesc8), New SqlParameter("@Account_Seg_Code9", SegC9), New SqlParameter("@Account_Seg_Desc9", SegDesc9), New SqlParameter("@Account_Seg_Code10", SegC10), New SqlParameter("@Account_Seg_Desc10", SegDesc10))
    '                i = i + 1
    '            End If
    '        End If


    '    Next
    '    Dim Sql As String = "update TSPL_JOURNAL_MASTER SET Authorized = 'A',Total_Credit_Amt=-1*(select sum(amount* case when Amount >0 then 0 else 1 end) as CreditAmt from TSPL_JOURNAL_DETAILS where Voucher_No='" + StrVoucher + "') ,Total_Debit_Amt=(select sum(amount* case when Amount >0 then 1 else 0 end) as DebitAmt from TSPL_JOURNAL_DETAILS where Voucher_No='" + StrVoucher + "') WHERE Voucher_No='" + StrVoucher + "' "
    '    connectSql.RunSql(Sql)
    '    Return True
    'End Function

    'Public Function FunGrnlEntryWithTrans(ByVal trans As SqlTransaction, ByVal EntryDate As String, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing) As Boolean
    '    Dim jrnlObj As New frmJournalEntry(User, CompCode)
    '    Dim StrVoucher As String = jrnlObj.fnAutoGenerateNo(trans)
    '    Dim strJrnl As String = "select (case when max(journal_no) is not null then max(journal_no) else 0 end) from TSPL_JOURNAL_MASTER "
    '    Dim Jrnl As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(strJrnl, trans)) + 1
    '    If strReference = Nothing Then
    '        strReference = ""
    '    End If
    '    If strremarks = Nothing Then
    '        strremarks = ""
    '    End If
    '    Dim SrcTypeFlag As String = connectSql.RunScalar(trans, "select SourceCode  from TSPL_GL_SOURCECODE where SourceCode='" + SrcType + "'")
    '    If SrcTypeFlag = "" OrElse SrcTypeFlag = Nothing Then
    '        Throw New Exception("Source Code '" + SrcType + "' Not Exist In Master!")
    '        Return False
    '    End If
    '    clsDBFuncationality.SaveAStorePorcedure(trans, "sp_TSPL_JOURNAL_MASTER_INSERT", New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Source_Code", SrcType), New SqlParameter("@Source_Desc", SrcTypeDesc), New SqlParameter("@Source_Doc_No", SrcDocNo), New SqlParameter("@Source_Doc_Date", EntryDate), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Voucher_Desc", EntryDesc), New SqlParameter("@Source_Narration", SrcDocDesc), New SqlParameter("@Remarks", strremarks), New SqlParameter("@Comments", strReference), New SqlParameter("@Auto_Reverse", "N"), New SqlParameter("@Reverse_Date", EntryDate), New SqlParameter("@Source_Type", strSrcType), New SqlParameter("@CustVend_Code", strSrcTypeCode), New SqlParameter("@CustVend_Name", strSrcTypeDesc), New SqlParameter("@Transaction_Type", "N"), New SqlParameter("@Total_Debit_Amt", 0.0), New SqlParameter("@Total_Credit_Amt", 0.0), New SqlParameter("@Created_By", User), New SqlParameter("@Created_Date", connectSql.serverDate(trans)), New SqlParameter("@Modify_By", User), New SqlParameter("@Modify_Date", connectSql.serverDate(trans)), New SqlParameter("@Comp_Code", CompCode))
    '    ''clsDBFuncationality.SaveAStorePorcedure(trans, "sp_TSPL_JOURNAL_MASTER_INSERT", New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Source_Code", SrcType), New SqlParameter("@Source_Desc", SrcTypeDesc), New SqlParameter("@Source_Doc_No", SrcDocNo), New SqlParameter("@Source_Doc_Date", EntryDate), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Voucher_Desc", EntryDesc), New SqlParameter("@Source_Narration", EntryDesc), New SqlParameter("@Remarks", narration), New SqlParameter("@Comments", strReference), New SqlParameter("@Auto_Reverse", "N"), New SqlParameter("@Reverse_Date", EntryDate), New SqlParameter("@Source_Type", strSrcType), New SqlParameter("@CustVend_Code", strSrcTypeCode), New SqlParameter("@CustVend_Name", strSrcTypeDesc), New SqlParameter("@Transaction_Type", "N"), New SqlParameter("@Total_Debit_Amt", 0.0), New SqlParameter("@Total_Credit_Amt", 0.0), New SqlParameter("@Created_By", User), New SqlParameter("@Created_Date", connectSql.serverDate()), New SqlParameter("@Modify_By", User), New SqlParameter("@Modify_Date", connectSql.serverDate()), New SqlParameter("@Comp_Code", CompCode)))
    '    Dim strJrnl1 As String = "select journal_no from TSPL_JOURNAL_MASTER where Voucher_No='" + StrVoucher + "'"
    '    Dim Jrnl1 As String
    '    Jrnl1 = clsDBFuncationality.getSingleValue(strJrnl1, trans)
    '    Dim AccountCode As String = ""
    '    Dim i As Integer = 1
    '    For Each AccCode() As String In StrAccCode
    '        Dim Query As String = "Select Description  from TSPL_GL_ACCOUNTS where Account_Code ='" + AccCode(0) + "' "
    '        Dim strAccDesc As String = connectSql.RunScalar(trans, Query)
    '        If clsCommon.myLen(strAccDesc) = 0 Then
    '            Throw New Exception("'" + AccCode(0) + "' Account does not exixt.")
    '            Return False
    '        End If
    '        Dim strDesc As String
    '        Dim strRef As String
    '        Dim Amt As Decimal = Convert.ToDecimal(AccCode(1))
    '        If AccCode.Length = 3 Then
    '            strDesc = Convert.ToString(AccCode(2))
    '        ElseIf AccCode.Length = 4 Then
    '            strDesc = Convert.ToString(AccCode(2))
    '            strRef = Convert.ToString(AccCode(3))
    '        Else
    '            strDesc = ""
    '            strRef = ""
    '        End If
    '        Dim strQ1 As String = " SELECT     Account_Type, Account_Group_Code, Account_Seg_Code1, Account_Seg_Desc1, Account_Seg_Code2, Account_Seg_Desc2, Account_Seg_Code3, " & _
    '              " Account_Seg_Desc3, Account_Seg_Code4, Account_Seg_Desc4, Account_Seg_Code5, Account_Seg_Desc5, Account_Seg_Code6, Account_Seg_Desc6," & _
    '              " Account_Seg_Code7, Account_Seg_Desc7, Account_Seg_Code8, Account_Seg_Desc8, Account_Seg_Code9, Account_Seg_Desc9, " & _
    '              " Account_Seg_Code10, Account_Seg_Desc10 FROM  TSPL_GL_ACCOUNTS where Account_Code='" + AccCode(0) + "'"
    '        Dim AccType As String
    '        Dim AccGrp As String
    '        Dim SegC1 As String
    '        Dim SegDesc1 As String
    '        Dim SegC2 As String
    '        Dim SegDesc2 As String
    '        Dim SegC3 As String
    '        Dim SegDesc3 As String
    '        Dim SegC4 As String
    '        Dim SegDesc4 As String
    '        Dim SegC5 As String
    '        Dim SegDesc5 As String
    '        Dim SegC6 As String
    '        Dim SegDesc6 As String
    '        Dim SegC7 As String
    '        Dim SegDesc7 As String
    '        Dim SegC8 As String
    '        Dim SegDesc8 As String
    '        Dim SegC9 As String
    '        Dim SegDesc9 As String

    '        Dim SegC10 As String
    '        Dim SegDesc10 As String

    '        Dim myreader As DataTable = clsDBFuncationality.GetDataTable(strQ1, trans)
    '        If myreader IsNot Nothing AndAlso myreader.Rows.Count > 0 Then

    '            AccType = myreader.Rows(0)(0).ToString()
    '            AccGrp = myreader.Rows(0)(1).ToString()

    '            SegC1 = myreader.Rows(0)(2).ToString()
    '            SegDesc1 = myreader.Rows(0)(3).ToString()

    '            SegC2 = myreader.Rows(0)(4).ToString()
    '            SegDesc2 = myreader.Rows(0)(5).ToString()

    '            SegC3 = myreader.Rows(0)(6).ToString()
    '            SegDesc3 = myreader.Rows(0)(7).ToString()

    '            SegC4 = myreader.Rows(0)(8).ToString()
    '            SegDesc4 = myreader.Rows(0)(9).ToString()

    '            SegC5 = myreader.Rows(0)(10).ToString()
    '            SegDesc5 = myreader.Rows(0)(11).ToString()

    '            SegC6 = myreader.Rows(0)(12).ToString()
    '            SegDesc6 = myreader.Rows(0)(13).ToString()

    '            SegC7 = myreader.Rows(0)(14).ToString()
    '            SegDesc7 = myreader.Rows(0)(15).ToString()

    '            SegC8 = myreader.Rows(0)(16).ToString()
    '            SegDesc8 = myreader.Rows(0)(17).ToString()

    '            SegC9 = myreader.Rows(0)(18).ToString()
    '            SegDesc9 = myreader.Rows(0)(19).ToString()

    '            SegC10 = myreader.Rows(0)(20).ToString()
    '            SegDesc10 = myreader.Rows(0)(21).ToString()

    '        End If
    '        'connectSql.RunSp("sp_TSPL_JOURNAL_DETAILS_INSERT", New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Detail_Line_No", i), New SqlParameter("@Account_code", AccCode(0)), New SqlParameter("@Account_Desc", strAccDesc), New SqlParameter("@Amount", Amt), New SqlParameter("@Description", ""), New SqlParameter("@Reference", ""), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Account_Type", AccType), New SqlParameter("@Account_Group_Code", AccGrp), New SqlParameter("@Account_Seg_Code1", SegC1), New SqlParameter("@Account_Seg_Desc1", SegDesc1), New SqlParameter("@Account_Seg_Code2", SegC2), New SqlParameter("@Account_Seg_Desc2", SegDesc2), New SqlParameter("@Account_Seg_Code3", SegC3), New SqlParameter("@Account_Seg_Desc3", SegDesc3), New SqlParameter("@Account_Seg_Code4", SegC4), New SqlParameter("@Account_Seg_Desc4", SegDesc4), New SqlParameter("@Account_Seg_Code5", SegC5), New SqlParameter("@Account_Seg_Desc5", SegDesc5), New SqlParameter("@Account_Seg_Code6", SegC6), New SqlParameter("@Account_Seg_Desc6", SegDesc6), New SqlParameter("@Account_Seg_Code7", SegC7), New SqlParameter("@Account_Seg_Desc7", SegDesc7), New SqlParameter("@Account_Seg_Code8", SegC8), New SqlParameter("@Account_Seg_Desc8", SegDesc8), New SqlParameter("@Account_Seg_Code9", SegC9), New SqlParameter("@Account_Seg_Desc9", SegDesc9), New SqlParameter("@Account_Seg_Code10", SegC10), New SqlParameter("@Account_Seg_Desc10", SegDesc10))
    '        clsDBFuncationality.SaveAStorePorcedure(trans, "sp_TSPL_JOURNAL_DETAILS_INSERT", New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Detail_Line_No", i), New SqlParameter("@Account_code", AccCode(0)), New SqlParameter("@Account_Desc", strAccDesc), New SqlParameter("@Amount", Amt), New SqlParameter("@Description", strDesc), New SqlParameter("@Reference", strRef), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Account_Type", AccType), New SqlParameter("@Account_Group_Code", AccGrp), New SqlParameter("@Account_Seg_Code1", SegC1), New SqlParameter("@Account_Seg_Desc1", SegDesc1), New SqlParameter("@Account_Seg_Code2", SegC2), New SqlParameter("@Account_Seg_Desc2", SegDesc2), New SqlParameter("@Account_Seg_Code3", SegC3), New SqlParameter("@Account_Seg_Desc3", SegDesc3), New SqlParameter("@Account_Seg_Code4", SegC4), New SqlParameter("@Account_Seg_Desc4", SegDesc4), New SqlParameter("@Account_Seg_Code5", SegC5), New SqlParameter("@Account_Seg_Desc5", SegDesc5), New SqlParameter("@Account_Seg_Code6", SegC6), New SqlParameter("@Account_Seg_Desc6", SegDesc6), New SqlParameter("@Account_Seg_Code7", SegC7), New SqlParameter("@Account_Seg_Desc7", SegDesc7), New SqlParameter("@Account_Seg_Code8", SegC8), New SqlParameter("@Account_Seg_Desc8", SegDesc8), New SqlParameter("@Account_Seg_Code9", SegC9), New SqlParameter("@Account_Seg_Desc9", SegDesc9), New SqlParameter("@Account_Seg_Code10", SegC10), New SqlParameter("@Account_Seg_Desc10", SegDesc10))
    '        i = i + 1
    '    Next
    '    Dim Sql As String = "update TSPL_JOURNAL_MASTER SET Total_Credit_Amt=-1*(select sum(amount* case when Amount >0 then 0 else 1 end) as CreditAmt from TSPL_JOURNAL_DETAILS where Voucher_No='" + StrVoucher + "') ,Total_Debit_Amt=(select sum(amount* case when Amount >0 then 1 else 0 end) as DebitAmt from TSPL_JOURNAL_DETAILS where Voucher_No='" + StrVoucher + "') WHERE Voucher_No='" + StrVoucher + "' "
    '    clsDBFuncationality.ExecuteNonQuery(Sql, trans)
    '    Sql = "select sum(amount) from tspl_journal_details where voucher_no='" + StrVoucher + "'"
    '    If clsCommon.myCdbl(clsDBFuncationality.getSingleValue(Sql, trans)) = 0 Then
    '        Sql = "update TSPL_JOURNAL_MASTER SET Authorized = 'A' WHERE Voucher_No='" + StrVoucher + "' "
    '        clsDBFuncationality.ExecuteNonQuery(Sql, trans)
    '        Dim objSendToTally As New clsSendToTally()
    '        objSendToTally.SendToTally_JournalEntry(StrVoucher, trans)
    '    Else
    '        Throw New Exception(GetJounalEntryException(StrVoucher, trans))
    '    End If
    '    ''Throw New Exception(GetJounalEntryException(StrVoucher, trans))
    '    Return True
    'End Function

    Private Function GetMergedAccCode(ByVal StrAccCode As ArrayList, ByVal SrcType As String, ByVal trans As SqlTransaction) As List(Of clsJournalDetailTemp)
        Dim ArrReturn As List(Of clsJournalDetailTemp) = Nothing
        Dim arrLocSeg As New List(Of String)
        If StrAccCode IsNot Nothing AndAlso StrAccCode.Count > 0 Then
            Dim dtSourceCode As DataTable = clsDBFuncationality.GetDataTable("select 1 from TSPL_GL_SOURCECODE where Do_Not_Merge=1 and SourceCode='" + SrcType + "'", trans)
            ArrReturn = New List(Of clsJournalDetailTemp)

            For Each Str() As String In StrAccCode
                Dim strCode As String = clsCommon.myCstr(Str(0))
                Dim Amount As Double = Math.Round(clsCommon.myCdbl(Str(1)), 2, MidpointRounding.ToEven)
                Dim strDesc As String = ""
                Dim strRef As String = ""
                Dim strHierarchyCode As String = ""
                Dim strCostCenterCode As String = ""

                If Str.Length = 3 Then
                    strDesc = Convert.ToString(Str(2))
                ElseIf Str.Length = 4 Then
                    strDesc = Convert.ToString(Str(2))
                    strRef = Convert.ToString(Str(3))
                ElseIf Str.Length = 6 Then
                    strDesc = Convert.ToString(Str(2))
                    strRef = Convert.ToString(Str(3))
                    strHierarchyCode = Convert.ToString(Str(4))
                    strCostCenterCode = Convert.ToString(Str(5))
                End If
                Dim isFound As Boolean = False
                Dim segCode As String = strCode.Substring(clsCommon.myLen(strCode) - 3, 3)
                If Not arrLocSeg.Contains(segCode) Then
                    arrLocSeg.Add(segCode)
                End If

                If dtSourceCode Is Nothing OrElse dtSourceCode.Rows.Count <= 0 Then
                    If ArrReturn IsNot Nothing AndAlso ArrReturn.Count > 0 Then
                        For ii As Integer = 0 To ArrReturn.Count - 1
                            If clsCommon.CompairString(ArrReturn(ii).Account_code, strCode) = CompairStringResult.Equal And Not (clsCommon.CompairString(SrcType, "VC-GL") = CompairStringResult.Equal) Then
                                If clsCommon.CompairString(ArrReturn(ii).Hierarchy_Code, strHierarchyCode) = CompairStringResult.Equal AndAlso clsCommon.CompairString(ArrReturn(ii).Cost_Center_Code, strCostCenterCode) = CompairStringResult.Equal Then
                                    isFound = True
                                    ArrReturn(ii).Amount += Amount

                                    If clsCommon.myLen(ArrReturn(ii).Description) > 0 Then
                                        ArrReturn(ii).Description += ", "
                                    End If
                                    ArrReturn(ii).Description += strDesc
                                    If clsCommon.myLen(strHierarchyCode) > 0 Then
                                        ArrReturn(ii).Hierarchy_Code = strHierarchyCode
                                    End If
                                    If clsCommon.myLen(strCostCenterCode) > 0 Then
                                        ArrReturn(ii).Cost_Center_Code = strCostCenterCode
                                    End If

                                    If clsCommon.myLen(ArrReturn(ii).Reference) > 0 Then
                                        ArrReturn(ii).Reference += ", "
                                    End If
                                    ArrReturn(ii).Reference += strRef
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If
                If Not isFound Then
                    Dim obj As clsJournalDetailTemp = New clsJournalDetailTemp()
                    obj.Account_code = strCode
                    obj.Amount = Amount
                    obj.Description = strDesc
                    obj.Reference = strRef
                    obj.Hierarchy_Code = strHierarchyCode
                    obj.Cost_Center_Code = strCostCenterCode
                    ArrReturn.Add(obj)
                End If
            Next

            For Each Str As String In arrLocSeg
                Dim dblTotDrAmt As Decimal = 0
                Dim dblTotCrAmt As Decimal = 0
                Dim firstAccountindex As Integer = -1

                For ii As Integer = 0 To ArrReturn.Count - 1
                    Dim segCode As String = ArrReturn(ii).Account_code.Substring(clsCommon.myLen(ArrReturn(ii).Account_code) - 3, 3)
                    If clsCommon.CompairString(segCode, Str) = CompairStringResult.Equal Then
                        If firstAccountindex < 0 Then
                            firstAccountindex = ii
                        End If
                        If ArrReturn(ii).Amount > 0 Then
                            dblTotDrAmt += Math.Round(clsCommon.myCdbl(ArrReturn(ii).Amount), 2, MidpointRounding.ToEven)
                        Else
                            dblTotCrAmt += -1 * Math.Round(clsCommon.myCdbl(ArrReturn(ii).Amount), 2, MidpointRounding.ToEven)
                        End If
                    End If
                Next
                Dim dblDiffence As Double = dblTotDrAmt - dblTotCrAmt
                dblDiffence = Math.Round(dblDiffence, 2, MidpointRounding.ToEven)
                If Math.Abs(dblDiffence) <= 0.99 Then
                    ArrReturn(firstAccountindex).Amount = ArrReturn(firstAccountindex).Amount - dblDiffence ''Working for all four conditions.
                End If
            Next


        End If
        Return ArrReturn
    End Function

    'Public Function fnAutoGenerateNo(ByVal trans As SqlTransaction, ByVal TranDate As Date, ByVal strPrefixTransType As String, ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean) As String
    '    Return fnAutoGenerateNo(False, trans, TranDate, strPrefixTransType, strLocationCode, isLocationCodeisSegment)
    'End Function
    'Public Function fnAutoGenerateNo(ByVal JEWithOPTables As Boolean, ByVal trans As SqlTransaction, ByVal TranDate As Date, ByVal strPrefixTransType As String, ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean) As String
    '    If clsCommon.myLen(strLocationCode) <= 0 Then
    '        Throw New Exception("First Account Should have location Segment")
    '    End If
    '    Return clsERPFuncationality.GetNextCode(trans, TranDate, IIf(JEWithOPTables, clsDocType.JournalEntryOP, clsDocType.JournalEntry), strPrefixTransType, strLocationCode, isLocationCodeisSegment)
    'End Function

    Public Function FunGrnlEntryWithTrans(ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean, ByVal trans As SqlTransaction, ByVal dt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing, Optional ByVal coll As Hashtable = Nothing) As Boolean
        Return FunGrnlEntryWithTrans(strLocationCode, isLocationCodeisSegment, "", trans, dt, EntryDesc, SrcType, SrcTypeDesc, SrcDocNo, SrcDocDesc, strSrcType, strSrcTypeCode, strSrcTypeDesc, User, CompCode, StrAccCode, narration, strremarks, strReference, coll)
    End Function
    Public Function FunGrnlEntryWithTrans(ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean, ByVal strVourcherNoForRecreateOnly As String, ByVal trans As SqlTransaction, ByVal dt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing, Optional ByVal coll As Hashtable = Nothing) As Boolean
        Return FunGrnlEntryWithTrans(strLocationCode, isLocationCodeisSegment, False, strVourcherNoForRecreateOnly, trans, dt, EntryDesc, SrcType, SrcTypeDesc, SrcDocNo, SrcDocDesc, strSrcType, strSrcTypeCode, strSrcTypeDesc, User, CompCode, StrAccCode, narration, strremarks, strReference, coll)
    End Function
    Public Function FunGrnlEntryWithTrans(ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean, ByVal isForUnpostedTransaction As Boolean, ByVal strVourcherNoForRecreateOnly As String, ByVal trans As SqlTransaction, ByVal dt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing, Optional ByVal coll As Hashtable = Nothing) As Boolean
        Return FunGrnlEntryWithTrans("", "N", strLocationCode, isLocationCodeisSegment, isForUnpostedTransaction, strVourcherNoForRecreateOnly, trans, dt, EntryDesc, SrcType, SrcTypeDesc, SrcDocNo, SrcDocDesc, strSrcType, strSrcTypeCode, strSrcTypeDesc, User, CompCode, StrAccCode, narration, strremarks, strReference, coll)
    End Function

    Public Function FunGrnlEntryWithTrans(ByVal strPrefixTransType As String, ByVal strTransType As String, ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean, ByVal isForUnpostedTransaction As Boolean, ByVal strVourcherNoForRecreateOnly As String, ByVal trans As SqlTransaction, ByVal dt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing, Optional ByVal coll As Hashtable = Nothing) As Boolean
        Return FunGrnlEntryWithTrans(0, strPrefixTransType, strTransType, strLocationCode, isLocationCodeisSegment, isForUnpostedTransaction, strVourcherNoForRecreateOnly, trans, dt, EntryDesc, SrcType, SrcTypeDesc, SrcDocNo, SrcDocDesc, strSrcType, strSrcTypeCode, strSrcTypeDesc, User, CompCode, StrAccCode, narration, strremarks, strReference, coll)
    End Function

    Public Function FunGrnlEntryWithTrans(ByVal intIND_AS As Integer, ByVal strPrefixTransType As String, ByVal strTransType As String, ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean, ByVal isForUnpostedTransaction As Boolean, ByVal strVourcherNoForRecreateOnly As String, ByVal trans As SqlTransaction, ByVal dt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing, Optional ByVal coll As Hashtable = Nothing) As Boolean
        Dim strERPStartDate As String = False 'clsFixedParameter.GetData(clsFixedParameterType.ERPStartDate, clsFixedParameterCode.ERPStartDate, trans)
        Dim JEWithOPTables As Boolean = False
        If clsCommon.myLen(strERPStartDate) > 0 Then
            If Not clsCommon.CompairString(SrcType, "JL-JE") = CompairStringResult.Equal Then
                Dim dtERPStartDate As DateTime = clsCommon.GetDateWithEndTime(strERPStartDate).AddDays(-1)
                If dt <= dtERPStartDate Then
                    JEWithOPTables = True
                End If
            End If
        End If
        If JEWithOPTables Then
            strVourcherNoForRecreateOnly = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Voucher_No from TSPL_JOURNAL_MASTER_OP where Source_Doc_No='" + SrcDocNo + "'", trans))
            JEMainFunction(intIND_AS, "TSPL_JOURNAL_MASTER_OP", "TSPL_JOURNAL_DETAILS_OP", "sp_TSPL_JOURNAL_MASTER_OP_INSERT", "sp_TSPL_JOURNAL_DETAILS_OP_INSERT", JEWithOPTables, strPrefixTransType, strTransType, strLocationCode, isLocationCodeisSegment, isForUnpostedTransaction, strVourcherNoForRecreateOnly, trans, dt, EntryDesc, SrcType, SrcTypeDesc, SrcDocNo, SrcDocDesc, strSrcType, strSrcTypeCode, strSrcTypeDesc, User, CompCode, StrAccCode, narration, strremarks, strReference, coll)
        Else
            JEMainFunction(intIND_AS, "TSPL_JOURNAL_MASTER", "TSPL_JOURNAL_DETAILS", "sp_TSPL_JOURNAL_MASTER_INSERT", "sp_TSPL_JOURNAL_DETAILS_INSERT", JEWithOPTables, strPrefixTransType, strTransType, strLocationCode, isLocationCodeisSegment, isForUnpostedTransaction, strVourcherNoForRecreateOnly, trans, dt, EntryDesc, SrcType, SrcTypeDesc, SrcDocNo, SrcDocDesc, strSrcType, strSrcTypeCode, strSrcTypeDesc, User, CompCode, StrAccCode, narration, strremarks, strReference, coll)
        End If
        Return True
    End Function

    Private Function JEMainFunction(ByVal intIND_AS As Integer, ByVal strJEHead As String, ByVal strJEDetail As String, ByVal strJEHeadStoreProcudureName As String, ByVal strJEDetailStoreProcudureName As String, ByVal JEWithOPTables As Boolean, ByVal strPrefixTransType As String, ByVal strTransType As String, ByVal strLocationCode As String, ByVal isLocationCodeisSegment As Boolean, ByVal isForUnpostedTransaction As Boolean, ByVal strVourcherNoForRecreateOnly As String, ByVal trans As SqlTransaction, ByVal dt As Date, ByVal EntryDesc As String, ByVal SrcType As String, ByVal SrcTypeDesc As String, ByVal SrcDocNo As String, ByVal SrcDocDesc As String, ByVal strSrcType As String, ByVal strSrcTypeCode As String, ByVal strSrcTypeDesc As String, ByVal User As String, ByVal CompCode As String, ByVal StrAccCode As ArrayList, Optional ByVal narration As String = vbNullString, Optional ByVal strremarks As String = Nothing, Optional ByVal strReference As String = Nothing, Optional ByVal coll As Hashtable = Nothing) As Boolean
        'Dim dblTotal As Double = 0
        'Dim arr As List(Of clsJournalDetailTemp) = GetMergedAccCode(StrAccCode, SrcType, trans)
        'Dim StrVoucher As String = ""
        'Dim Sql As String = ""
        'Dim EntryDate As String = clsCommon.GetPrintDate(dt, "dd/MMM/yyyy")
        'If arr IsNot Nothing AndAlso arr.Count > 0 Then
        '    For Each objTotal As clsJournalDetailTemp In arr
        '        If objTotal.Amount > 0 Then
        '            dblTotal += objTotal.Amount
        '        End If
        '    Next
        '    If dblTotal > 0 Then
        '        If clsCommon.myLen(strVourcherNoForRecreateOnly) > 0 Then
        '            Dim qry1 As String = "delete from " + strJEDetail + " where Voucher_No='" + strVourcherNoForRecreateOnly + "'"
        '            clsDBFuncationality.ExecuteNonQuery(qry1, trans)
        '            qry1 = "delete from " + strJEHead + " where Voucher_No='" + strVourcherNoForRecreateOnly + "'"
        '            clsDBFuncationality.ExecuteNonQuery(qry1, trans)
        '            StrVoucher = strVourcherNoForRecreateOnly
        '        Else
        '            Dim strLocalPrefixTransType As String = clsDocTransactionType.JournalEntryOther
        '            If clsCommon.CompairString(strSrcType, "MI-SR") = CompairStringResult.Equal Then
        '                strLocalPrefixTransType = clsDocTransactionType.JournalEntryMilkSRN
        '            ElseIf clsCommon.myLen(strPrefixTransType) > 0 Then
        '                strLocalPrefixTransType = strPrefixTransType
        '            End If
        '            StrVoucher = fnAutoGenerateNo(JEWithOPTables, trans, dt, strLocalPrefixTransType, strLocationCode, isLocationCodeisSegment)
        '        End If



        '        Dim strJrnl As String = "select (case when max(journal_no) is not null then max(journal_no) else 0 end) from " + strJEHead + " "
        '        Dim Jrnl As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(strJrnl, trans)) + 1
        '        If strReference = Nothing Then
        '            strReference = ""
        '        End If
        '        If strremarks = Nothing Then
        '            strremarks = ""
        '        End If
        '        Dim SrcTypeFlag As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select SourceCode  from TSPL_GL_SOURCECODE where SourceCode='" + SrcType + "'", trans))
        '        If SrcTypeFlag = "" OrElse SrcTypeFlag = Nothing Then
        '            Throw New Exception("Source Code '" + SrcType + "' Not Exist In Master!")
        '            Return False
        '        End If
        '        SrcType = SrcTypeFlag

        '        clsDBFuncationality.SaveAStorePorcedure(trans, strJEHeadStoreProcudureName, New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Source_Code", SrcType), New SqlParameter("@Source_Desc", SrcTypeDesc), New SqlParameter("@Source_Doc_No", SrcDocNo), New SqlParameter("@Source_Doc_Date", EntryDate), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Voucher_Desc", EntryDesc), New SqlParameter("@Source_Narration", SrcDocDesc), New SqlParameter("@Remarks", strremarks), New SqlParameter("@Comments", strReference), New SqlParameter("@Auto_Reverse", "N"), New SqlParameter("@Reverse_Date", EntryDate), New SqlParameter("@Source_Type", strSrcType), New SqlParameter("@CustVend_Code", strSrcTypeCode), New SqlParameter("@CustVend_Name", strSrcTypeDesc), New SqlParameter("@Transaction_Type", strTransType), New SqlParameter("@Total_Debit_Amt", 0.0), New SqlParameter("@Total_Credit_Amt", 0.0), New SqlParameter("@Created_By", User), New SqlParameter("@Created_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MM/yyyy")), New SqlParameter("@Modify_By", User), New SqlParameter("@Modify_Date", clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MM/yyyy")), New SqlParameter("@Comp_Code", CompCode))

        '        Dim qry As String = "Update " + strJEHead + " set "
        '        If isLocationCodeisSegment Then
        '            qry += "Segment_code= '" + strLocationCode + "'"
        '        Else
        '            qry += "Segment_code= (select Loc_Segment_Code from TSPL_LOCATION_MASTER where Location_Code='" + strLocationCode + "')"
        '        End If
        '        qry += ",IND_AS='" + clsCommon.myCstr(intIND_AS) + "' where Voucher_No='" + StrVoucher + "' "
        '        clsDBFuncationality.ExecuteNonQuery(qry, trans)

        '        Dim strJrnl1 As String = "select journal_no from " + strJEHead + " where Voucher_No='" + StrVoucher + "'"
        '        Dim Jrnl1 As String
        '        Jrnl1 = clsDBFuncationality.getSingleValue(strJrnl1, trans)
        '        Dim AccountCode As String = ""
        '        Dim i As Integer = 1
        '        For Each obj As clsJournalDetailTemp In arr
        '            Dim Query As String = "Select Description  from TSPL_GL_ACCOUNTS where Account_Code ='" + obj.Account_code + "' "
        '            Dim strAccDesc As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(Query, trans))
        '            If clsCommon.myLen(strAccDesc) = 0 Then
        '                Throw New Exception("'" + obj.Account_code + "' Account does not exist.")
        '                Return False
        '            End If
        '            ''richa 03/03/2015
        '            Dim Amt As Double = clsCommon.myCdbl(obj.Amount)
        '            ''------------------
        '            Dim strQ1 As String = " SELECT Account_Type, Account_Group_Code, Account_Seg_Code1, Account_Seg_Desc1, Account_Seg_Code2, Account_Seg_Desc2, Account_Seg_Code3, " & _
        '                  " Account_Seg_Desc3, Account_Seg_Code4, Account_Seg_Desc4, Account_Seg_Code5, Account_Seg_Desc5, Account_Seg_Code6, Account_Seg_Desc6," & _
        '                  " Account_Seg_Code7, Account_Seg_Desc7, Account_Seg_Code8, Account_Seg_Desc8, Account_Seg_Code9, Account_Seg_Desc9, " & _
        '                  " Account_Seg_Code10, Account_Seg_Desc10 FROM  TSPL_GL_ACCOUNTS where Account_Code='" + obj.Account_code + "'"
        '            Dim AccType As String = ""
        '            Dim AccGrp As String = ""
        '            Dim SegC1 As String = ""
        '            Dim SegDesc1 As String = ""
        '            Dim SegC2 As String = ""
        '            Dim SegDesc2 As String = ""
        '            Dim SegC3 As String = ""
        '            Dim SegDesc3 As String = ""
        '            Dim SegC4 As String = ""
        '            Dim SegDesc4 As String = ""
        '            Dim SegC5 As String = ""
        '            Dim SegDesc5 As String = ""
        '            Dim SegC6 As String = ""
        '            Dim SegDesc6 As String = ""
        '            Dim SegC7 As String = ""
        '            Dim SegDesc7 As String = ""
        '            Dim SegC8 As String = ""
        '            Dim SegDesc8 As String = ""
        '            Dim SegC9 As String = ""
        '            Dim SegDesc9 As String = ""
        '            Dim SegC10 As String = ""
        '            Dim SegDesc10 As String = ""
        '            Dim myreader As DataTable = clsDBFuncationality.GetDataTable(strQ1, trans)
        '            If myreader IsNot Nothing AndAlso myreader.Rows.Count > 0 Then
        '                AccType = myreader.Rows(0)(0).ToString()
        '                AccGrp = myreader.Rows(0)(1).ToString()

        '                SegC1 = myreader.Rows(0)(2).ToString()
        '                SegDesc1 = myreader.Rows(0)(3).ToString()

        '                SegC2 = myreader.Rows(0)(4).ToString()
        '                SegDesc2 = myreader.Rows(0)(5).ToString()

        '                SegC3 = myreader.Rows(0)(6).ToString()
        '                SegDesc3 = myreader.Rows(0)(7).ToString()

        '                SegC4 = myreader.Rows(0)(8).ToString()
        '                SegDesc4 = myreader.Rows(0)(9).ToString()

        '                SegC5 = myreader.Rows(0)(10).ToString()
        '                SegDesc5 = myreader.Rows(0)(11).ToString()

        '                SegC6 = myreader.Rows(0)(12).ToString()
        '                SegDesc6 = myreader.Rows(0)(13).ToString()

        '                SegC7 = myreader.Rows(0)(14).ToString()
        '                SegDesc7 = myreader.Rows(0)(15).ToString()

        '                SegC8 = myreader.Rows(0)(16).ToString()
        '                SegDesc8 = myreader.Rows(0)(17).ToString()

        '                SegC9 = myreader.Rows(0)(18).ToString()
        '                SegDesc9 = myreader.Rows(0)(19).ToString()

        '                SegC10 = myreader.Rows(0)(20).ToString()
        '                SegDesc10 = myreader.Rows(0)(21).ToString()

        '            End If
        '            If Not (clsCommon.myCdbl(Amt) = 0) Then
        '                clsDBFuncationality.SaveAStorePorcedure(trans, strJEDetailStoreProcudureName, New SqlParameter("@Journal_No", Jrnl), New SqlParameter("@Voucher_No", StrVoucher), New SqlParameter("@Voucher_Date", EntryDate), New SqlParameter("@Detail_Line_No", i), New SqlParameter("@Account_code", obj.Account_code), New SqlParameter("@Account_Desc", strAccDesc), New SqlParameter("@Amount", Amt), New SqlParameter("@Description", obj.Description), New SqlParameter("@Reference", obj.Reference), New SqlParameter("@Posting_Date", EntryDate), New SqlParameter("@Account_Type", AccType), New SqlParameter("@Account_Group_Code", AccGrp), New SqlParameter("@Account_Seg_Code1", SegC1), New SqlParameter("@Account_Seg_Desc1", SegDesc1), New SqlParameter("@Account_Seg_Code2", SegC2), New SqlParameter("@Account_Seg_Desc2", SegDesc2), New SqlParameter("@Account_Seg_Code3", SegC3), New SqlParameter("@Account_Seg_Desc3", SegDesc3), New SqlParameter("@Account_Seg_Code4", SegC4), New SqlParameter("@Account_Seg_Desc4", SegDesc4), New SqlParameter("@Account_Seg_Code5", SegC5), New SqlParameter("@Account_Seg_Desc5", SegDesc5), New SqlParameter("@Account_Seg_Code6", SegC6), New SqlParameter("@Account_Seg_Desc6", SegDesc6), New SqlParameter("@Account_Seg_Code7", SegC7), New SqlParameter("@Account_Seg_Desc7", SegDesc7), New SqlParameter("@Account_Seg_Code8", SegC8), New SqlParameter("@Account_Seg_Desc8", SegDesc8), New SqlParameter("@Account_Seg_Code9", SegC9), New SqlParameter("@Account_Seg_Desc9", SegDesc9), New SqlParameter("@Account_Seg_Code10", SegC10), New SqlParameter("@Account_Seg_Desc10", SegDesc10))
        '                If clsCommon.myLen(obj.Hierarchy_Code) > 0 OrElse clsCommon.myLen(obj.Cost_Center_Code) > 0 Then
        '                    If clsCommon.CompairString(strJEDetail, "TSPL_JOURNAL_DETAILS") = CompairStringResult.Equal Then
        '                        Sql = "update TSPL_JOURNAL_DETAILS SET Hirerachy_Code='" + obj.Hierarchy_Code + "',Cost_Centre_Code='" + obj.Cost_Center_Code + "' WHERE Voucher_No='" + StrVoucher + "' and Detail_Line_No='" + clsCommon.myCstr(i) + "' "
        '                        clsDBFuncationality.ExecuteNonQuery(Sql, trans)
        '                    End If
        '                End If
        '                i = i + 1
        '            End If
        '        Next


        '        '' multicurrency done for conversion value in base currency 15/04/2015 (Monika)
        '        If Not coll Is Nothing AndAlso coll.Count > 0 Then
        '            clsCommonFunctionality.UpdateDataTable(coll, "" + strJEHead + "", OMInsertOrUpdate.Update, "" + strJEHead + ".Voucher_No='" + StrVoucher + "'", trans)
        '            Dim cnvrsnrate As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select ConvRate from " + strJEHead + " where Voucher_No='" + StrVoucher + "'", trans))
        '            Dim strsource As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select Source_Code from " + strJEHead + " where Voucher_No='" + StrVoucher + "'", trans))
        '            If cnvrsnrate > 0 AndAlso (clsCommon.CompairString(strsource, "AP-PY") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-MI") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-MR") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-RF") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-OA") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-PY") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-PI") <> CompairStringResult.Equal And clsCommon.CompairString(strsource, "AR-DC") <> CompairStringResult.Equal) Then
        '                Sql = "update " + strJEDetail + " SET amount=(amount * " + clsCommon.myCstr(cnvrsnrate) + ") WHERE Voucher_No='" + StrVoucher + "' "
        '                clsDBFuncationality.ExecuteNonQuery(Sql, trans)
        '            End If
        '        End If
        '        '' end multicurrency


        '        UpdateRecoControlAccount(SrcType, StrVoucher, SrcDocNo, strJEDetail, trans, strSrcTypeCode, strSrcType)


        '        Sql = "update " + strJEHead + " SET Total_Credit_Amt=-1*(select ISNULL(sum(amount* case when Amount >0 then 0 else 1 end),0) as CreditAmt from " + strJEDetail + " where Voucher_No='" + StrVoucher + "') ,Total_Debit_Amt=(select ISNULL(sum(amount* case when Amount >0 then 1 else 0 end),0) as DebitAmt from " + strJEDetail + " where Voucher_No='" + StrVoucher + "') WHERE Voucher_No='" + StrVoucher + "' "
        '        clsDBFuncationality.ExecuteNonQuery(Sql, trans)

        '        Sql = "select sum(amount) from " + strJEDetail + " where voucher_no='" + StrVoucher + "'"
        '        If clsCommon.myCdbl(clsDBFuncationality.getSingleValue(Sql, trans)) = 0 Then
        '            If Not isForUnpostedTransaction Then
        '                Try
        '                    Sql = "update " + strJEHead + " SET Authorized = 'A' WHERE Voucher_No='" + StrVoucher + "' "
        '                    clsDBFuncationality.ExecuteNonQuery(Sql, trans)
        '                    Dim objSendToTally As New clsSendToTally()
        '                    objSendToTally.SendToTally_JournalEntry(StrVoucher, trans)
        '                Catch ex As Exception
        '                    If clsCommon.CompairString(ex.Message, "Location Wise Debit is not Equal To Credit.Voucher Cannot Be Posted.") = CompairStringResult.Equal Then
        '                        Throw New Exception(ex.Message + Environment.NewLine + GetJounalEntryException(strJEDetail, StrVoucher, trans))
        '                    Else
        '                        Throw New Exception(ex.Message)
        '                    End If
        '                End Try

        '            End If
        '        Else
        '            Throw New Exception(GetJounalEntryException(strJEDetail, StrVoucher, trans))
        '        End If

        '        If clsCommon.myCdbl(clsFixedParameter.GetData(clsFixedParameterType.PopupJE, clsFixedParameterCode.PopupJE, trans)) = 1 Then
        '            Throw New Exception(GetJounalEntryException(strJEDetail, StrVoucher, trans))
        '        End If
        '    Else
        '        Return False
        '    End If
        '    If Not clsCommon.CompairString(strTransType, "X") = CompairStringResult.Equal Then
        '        Dim qry As String = "select is_End_Year_Proceed from TSPL_Fiscal_Year_Master where convert(date, '" + EntryDate + "',103)>= convert(date, Start_Date,103) and convert(date, '" + EntryDate + "',103)<=CONVERT(date, End_Date,103)"
        '        Dim dtable As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
        '        If dtable Is Nothing OrElse dtable.Rows.Count <= 0 Then
        '            Throw New Exception("Please create financial year which contains " + EntryDate)
        '        End If
        '        clsGLAccount.CheckYearEndAccountFilledInSegment(StrVoucher, trans)
        '        If clsCommon.myCdbl(dtable.Rows(0)("is_End_Year_Proceed")) = 1 Then
        '            ''richa agarwal changes done against ticket no.BM00000009404 on 4Aug,2016
        '            CreateJEForEndYear(StrVoucher, EntryDate, trans)
        '            '------------
        '        End If
        '    End If
        'End If
        'If Not objCommonVar.NoOfJournalEnteryLicence = -1 Then
        '    If clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select count(1) from " + strJEHead + "", trans)) > objCommonVar.NoOfJournalEnteryLicence Then
        '        Throw New Exception("Please ask your administrator to purchase licence" + Environment.NewLine + objCommonVar.LicenceMessageContactPersion)
        '    End If
        'End If

        Return True
    End Function

    Private Function UpdateRecoControlAccount(ByVal SrcType As String, ByVal strVoucherNo As String, ByVal SrcDocNo As String, ByVal strJEDetail As String, ByVal trans As SqlTransaction, ByVal strVendorCustomerCode As String, ByVal strSrcType As String)
        Dim strRecoControlAccount As String = Nothing
        Dim strControlAccountSeg1 As String = Nothing

        Select Case SrcType
            Case "AP-CN", "AP-IN", "AP-DN"
                strRecoControlAccount = "V"
                strControlAccountSeg1 = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select TSPL_GL_ACCOUNTS.Account_Seg_Code1 from TSPL_VENDOR_INVOICE_HEAD left outer join TSPL_GL_ACCOUNTS on TSPL_GL_ACCOUNTS.Account_Code=TSPL_VENDOR_INVOICE_HEAD.Vendor_Control_AC where Document_No='" + SrcDocNo + "'", trans))
            Case "AP-PY", "AP-AD"
                strRecoControlAccount = "V"
                strControlAccountSeg1 = clsCommon.myCstr(clsDBFuncationality.getSingleValue(GetVendorQuery(strVendorCustomerCode), trans))
            Case "RV-TA"
                If clsCommon.CompairString(strSrcType, "C") = CompairStringResult.Equal Then
                    strRecoControlAccount = "C"
                    strControlAccountSeg1 = clsCommon.myCstr(clsDBFuncationality.getSingleValue(GetCustomerQuery(strVendorCustomerCode), trans))
                ElseIf clsCommon.CompairString(strSrcType, "V") = CompairStringResult.Equal Then
                    strRecoControlAccount = "V"
                    strControlAccountSeg1 = clsCommon.myCstr(clsDBFuncationality.getSingleValue(GetVendorQuery(strVendorCustomerCode), trans))
                End If
            Case "AR-CR", "AR-IN", "AR-DN"
                strRecoControlAccount = "C"
                strControlAccountSeg1 = clsCommon.myCstr(clsDBFuncationality.getSingleValue("select TSPL_GL_ACCOUNTS.Account_Seg_Code1  from TSPL_Customer_Invoice_Head  left outer join TSPL_GL_ACCOUNTS on TSPL_GL_ACCOUNTS.Account_Code=TSPL_Customer_Invoice_Head.Customer_Control_AC where Document_No='" + SrcDocNo + "'", trans))
            Case "AR-DC", "AR-AD", "AR-MI", "AR-OA", "AR-PI", "AR-PY", "AR-RF"
                strRecoControlAccount = "C"
                strControlAccountSeg1 = clsCommon.myCstr(clsDBFuncationality.getSingleValue(GetCustomerQuery(strVendorCustomerCode), trans))
        End Select
        If clsCommon.myLen(strRecoControlAccount) > 0 AndAlso clsCommon.myLen(strControlAccountSeg1) > 0 Then
            Dim coll As New Hashtable()
            clsCommon.AddColumnsForChange(coll, "Reco_Control_Account", strRecoControlAccount)
            clsCommonFunctionality.UpdateDataTable(coll, strJEDetail, OMInsertOrUpdate.Update, "Voucher_No='" + strVoucherNo + "' and Account_Seg_Code1='" + strControlAccountSeg1 + "'", trans)
        End If
        Return True
    End Function


    Function GetVendorQuery(ByVal strVendorCustomerCode As String) As String
        Return "select Account_Seg_Code1 from TSPL_VENDOR_MASTER left outer join TSPL_VENDOR_ACCOUNT_SET on TSPL_VENDOR_ACCOUNT_SET.Acct_Set_Code=TSPL_VENDOR_MASTER.Vendor_Account left outer join TSPL_GL_ACCOUNTS on TSPL_GL_ACCOUNTS.Account_Code=TSPL_VENDOR_ACCOUNT_SET.Payable_Account where Vendor_Code='" + strVendorCustomerCode + "'"
    End Function

    Function GetCustomerQuery(ByVal strVendorCustomerCode As String) As String
        Return "select Account_Seg_Code1 from TSPL_CUSTOMER_MASTER left outer join TSPL_CUSTOMER_ACCOUNT_SET on TSPL_CUSTOMER_ACCOUNT_SET.Cust_Account=TSPL_CUSTOMER_MASTER.Cust_Account left outer join TSPL_GL_ACCOUNTS on TSPL_GL_ACCOUNTS.Account_Code=TSPL_CUSTOMER_ACCOUNT_SET.Receivable_Control_acct  where Cust_Code='" + strVendorCustomerCode + "'"
    End Function

    Public Function CreateJEForEndYear(ByVal strVoucherNo As String, ByVal strEntryDate As Date, ByVal trans As SqlTransaction) As Boolean
        Dim qry As String = "select Account_code,SUM(-1*Amount) as Amount,max(Account_Seg_Code7) as SegCode,IND_AS from (" + Environment.NewLine & _
                        " select TSPL_JOURNAL_MASTER.Voucher_No,TSPL_JOURNAL_MASTER.Voucher_Date,TSPL_JOURNAL_DETAILS.Account_code ,Amount,TSPL_GL_ACCOUNTS.Account_Seg_Code7,TSPL_JOURNAL_MASTER.IND_AS" + Environment.NewLine & _
                        " from TSPL_JOURNAL_DETAILS " + Environment.NewLine & _
                        " left outer join TSPL_JOURNAL_MASTER on TSPL_JOURNAL_MASTER.Voucher_No=TSPL_JOURNAL_DETAILS.Voucher_No" + Environment.NewLine & _
                        " left outer join TSPL_GL_ACCOUNTS on TSPL_GL_ACCOUNTS.Account_Code=TSPL_JOURNAL_DETAILS.Account_code" + Environment.NewLine & _
                        " left outer join TSPL_ACCOUNT_MAIN_GL_ACCOUNT on TSPL_ACCOUNT_MAIN_GL_ACCOUNT.Main_GL_Account=TSPL_GL_ACCOUNTS.GL_Main_Code  " + Environment.NewLine & _
                        " left outer join TSPL_ACCOUNT_SUB_GROUPS on TSPL_ACCOUNT_SUB_GROUPS.Account_Sub_Group_Code=TSPL_ACCOUNT_MAIN_GL_ACCOUNT.Sub_Group_Code  " + Environment.NewLine & _
                        " left outer join TSPL_ACCOUNT_GROUPS on TSPL_ACCOUNT_GROUPS.Account_Group_Code= TSPL_ACCOUNT_SUB_GROUPS.Account_Group_Code " + Environment.NewLine & _
                        " left outer join  TSPL_ACCOUNT_MAIN_GROUPS on TSPL_ACCOUNT_MAIN_GROUPS.Account_Main_Group_Code=TSPL_ACCOUNT_GROUPS.Account_Main_Group_Code" + Environment.NewLine & _
                        " where 2=2 "
        ''richa agarwal changes done against ticket no.BM00000009404 on 4Aug,2016
        Dim strcurrentfisyearenddate As DateTime? = Nothing
        Dim strCurrentfinancialYear As String = String.Empty
        Dim dt1 As DataTable = clsDBFuncationality.GetDataTable("select End_Date,Fiscal_Code from TSPL_Fiscal_Year_Master where convert(date, '" + strEntryDate + "',103)>= convert(date, Start_Date,103) and convert(date, '" + strEntryDate + "',103)<=CONVERT(date, End_Date,103)", trans)
        If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
            strcurrentfisyearenddate = dt1.Rows(0)("End_Date")
            strCurrentfinancialYear = clsCommon.myCstr(dt1.Rows(0)("Fiscal_Code"))
        End If
        ''-------------------------


        If clsCommon.myLen(strVoucherNo) > 0 Then
            qry += " and TSPL_JOURNAL_MASTER.Voucher_No = '" + strVoucherNo + "'"
        Else
            qry += " and TSPL_JOURNAL_MASTER.Voucher_Date>='" + clsCommon.GetPrintDate(clsCommon.GetDateWithStartTime(objCommonVar.CurrFiscalStartDate), "dd/MMM/yyyy hh:mm tt") + "' and TSPL_JOURNAL_MASTER.Voucher_Date<='" + clsCommon.GetPrintDate(clsCommon.GetDateWithEndTime(strcurrentfisyearenddate), "dd/MMM/yyyy hh:mm tt") + "' " + Environment.NewLine
        End If
        qry += " and TSPL_ACCOUNT_MAIN_GROUPS.Group_Type='Income Statement' and TSPL_JOURNAL_MASTER.Authorized='A' " + Environment.NewLine & _
                " )xxx" + Environment.NewLine & _
                " group by Account_code,IND_AS " + Environment.NewLine & _
                " order by SegCode,IND_AS"
        Dim dt As DataTable = clsDBFuncationality.GetDataTable(qry, trans)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim strSegCode As String = clsCommon.myCstr(dt.Rows(0)("SegCode"))
            Dim intINDAs As Integer = clsCommon.myCdbl(dt.Rows(0)("IND_AS"))
            Dim ArryLstNew As ArrayList = New ArrayList()
            Dim dblbal As Double = 0
            For Each dr As DataRow In dt.Rows
                If Not (clsCommon.CompairString(strSegCode, clsCommon.myCstr(dr("SegCode"))) = CompairStringResult.Equal AndAlso intINDAs = clsCommon.myCstr(dr("IND_AS"))) Then
                    ''Create Journal Entry
                    qry = "select Account_Code from TSPL_GL_SEGMENT_CODE where Seg_No='7' and Segment_code='" + strSegCode + "'"
                    Dim strCode As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
                    If clsCommon.myLen(strCode) <= 0 Then
                        Throw New Exception("Please set gl account in Segment code master for segment : " + strSegCode)
                    End If

                    Dim Acc2() As String = {strCode, -1 * dblbal}
                    ArryLstNew.Add(Acc2)
                    transportSql.FunGrnlEntryWithTrans(intINDAs, "", "X", strSegCode, True, False, "", trans, strcurrentfisyearenddate, "Fiscal Year End for " + strCurrentfinancialYear, "GL-JE", "", "", "", "O", "", "", objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode, ArryLstNew)
                    ''Reset Variables
                    ArryLstNew = New ArrayList()
                    dblbal = 0
                    strSegCode = clsCommon.myCstr(dr("SegCode"))
                    intINDAs = clsCommon.myCdbl(dr("IND_AS"))
                End If
                Dim Acc1() As String = {clsCommon.myCstr(dr("Account_code")), clsCommon.myCdbl(dr("Amount"))}
                dblbal += clsCommon.myCdbl(dr("Amount"))
                ArryLstNew.Add(Acc1)
            Next

            ''Create Journal Entry of Last Segment
            If ArryLstNew IsNot Nothing AndAlso ArryLstNew.Count > 0 Then
                qry = "select Account_Code from TSPL_GL_SEGMENT_CODE where Seg_No='7' and Segment_code='" + strSegCode + "'"
                Dim strCode As String = clsCommon.myCstr(clsDBFuncationality.getSingleValue(qry, trans))
                If clsCommon.myLen(strCode) <= 0 Then
                    Throw New Exception("Please set gl account in Segment code master for segment")
                End If

                Dim Acc2() As String = {strCode, -1 * dblbal}
                ArryLstNew.Add(Acc2)
                '  transportSql.FunGrnlEntryWithTrans("", "X", strSegCode, True, False, "", trans, objCommonVar.CurrFiscalEndDate, "Fiscal Year End for " + objCommonVar.CurrFiscalYear, "GL-JE", "", "", "", "O", "", "", objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode, ArryLstNew)
                transportSql.FunGrnlEntryWithTrans(intINDAs, "", "X", strSegCode, True, False, "", trans, strcurrentfisyearenddate, "Fiscal Year End for " + strCurrentfinancialYear, "GL-JE", "", "", "", "O", "", "", objCommonVar.CurrentUserCode, objCommonVar.CurrentCompanyCode, ArryLstNew)
            End If
        End If
        Return True
    End Function

    Public Function GetJounalEntryException(ByVal strJEDetail As String, ByVal VoucherNo As String, ByVal trans As SqlTransaction) As String
        Dim sql As String = "Select Account_code,Account_Desc,case when Amount>0 then Amount end as DrAmt,case when Amount<0 then -1*Amount end as CrAmt from " + strJEDetail + " WHERE Voucher_No='" + VoucherNo + "'"
        Dim dtError As DataTable = clsDBFuncationality.GetDataTable(sql, trans)
        Dim msg As String = "Please Check Journal Entry" + Environment.NewLine
        Dim counter As Integer = 1
        Dim TotDrAmt As Double = 0
        Dim TotCrAmt As Double = 0
        For Each dr As DataRow In dtError.Rows
            msg += clsCommon.myCstr(counter) + GetBlankSpace(clsCommon.myCstr(counter), 3)
            msg += GetBlankSpace(clsCommon.myCstr(dr("DrAmt")), 10) + clsCommon.myCstr(dr("DrAmt"))
            msg += GetBlankSpace(clsCommon.myCstr(dr("CrAmt")), 10) + clsCommon.myCstr(dr("CrAmt")) + "   "
            msg += clsCommon.myCstr(dr("Account_code")) + GetBlankSpace(clsCommon.myCstr(dr("Account_code")), 20)
            msg += clsCommon.myCstr(dr("Account_Desc")) + GetBlankSpace(clsCommon.myCstr(dr("Account_Desc")), 50) + Environment.NewLine
            TotDrAmt += clsCommon.myCdbl(dr("DrAmt"))
            TotCrAmt += clsCommon.myCdbl(dr("CrAmt"))
            counter += 1
        Next
        msg += "-------------------------------------------------------------------------------------------------------------------" + Environment.NewLine
        msg += clsCommon.myCstr("Tot")
        msg += GetBlankSpace(clsCommon.myCstr(counter), 10) + clsCommon.myCstr(TotDrAmt)
        msg += GetBlankSpace(clsCommon.myCstr(counter), 10) + clsCommon.myCstr(TotCrAmt) + Environment.NewLine
        msg += "-------------------------------------------------------------------------------------------------------------------"
        Return msg
    End Function

    Private Function GetBlankSpace(ByVal str As String, ByVal Length As Integer) As String
        Dim strBlankSpace As String = ""
        For ii As Integer = clsCommon.myLen(str) To Length - 1
            strBlankSpace += " "
        Next
        Return strBlankSpace
    End Function
    ' ------------- 24-July-2014 -----------------'
    Public Function ExporttoExcelNew(ByVal sql As String, ByVal frm As RadForm, Optional ByVal pivotCols As String = "", Optional ByVal whrClaus As String = "", Optional ByVal OrderByClaus As String = "") As Boolean
        Try
            ''************* Filter Block Start
            '============Add By Rohit on June 17,2014 to show column Filter========
            Dim frmFilterCol As New frmFilterColumnsToExport()
            frmFilterCol.qry = sql
            frmFilterCol.pivotCols = pivotCols
            frmFilterCol.whrCls = " Where 2=2 " + whrClaus
            If clsCommon.myLen(OrderByClaus) > 0 Then
                frmFilterCol.orderByClause = " Order by " + OrderByClaus
            End If
            frmFilterCol.ShowDialog()
            If frmFilterCol.isCancel Then
                GoTo a
                'Return False
            End If
            sql = frmFilterCol.qry
            '========================================================================
a:          Dim frmFilter As New frmFilterToExport()
            frmFilter.qry = sql
            frmFilter.whrCls = " Where 2=2 " + whrClaus
            If clsCommon.myLen(OrderByClaus) > 0 Then
                frmFilter.orderByClause = " Order by " + OrderByClaus
            End If
            frmFilter.ShowDialog()
            If frmFilter.isCancel Then
                Return False
            End If
            sql = frmFilter.qry
            ''************* Filter Block End

            Dim sfd As SaveFileDialog = New SaveFileDialog()
            Dim path As String
            sfd.FileName = frm.Text
            sfd.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls"
            If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = sfd.FileName
            Else
                Return False
            End If
            If InStr(path, ".xlsx") <> -1 Then
                path = Replace(path, ".xlsx", ".xls")
            End If
            If Not path.Equals(String.Empty) Then
                Dim gv As New RadGridView()
                Try
                    'Dim exporter As New RadGridViewExcelExporter()
                    gv.Name = "gTax"
                    frm.Controls.Add(gv)
                    FillGridView(sql, gv)
                    'gv.MasterGridViewTemplate.AllowAddNewRow = False
                    'gv.MasterGridViewTemplate.AutoGenerateColumns = True
                    'gv.DataSource = Nothing
                    'gv.DataSource = clsDBFuncationality.GetDataTable(sql)
                    If gv.Rows.Count = 0 And frmFilter.chkBlankSheet.Checked = False Then
                        common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                        Return False
                    End If

                    Dim i As Integer = 0
                    '===============Add If Condition For Row Count by Rohit on june 05,2014 If Sheet is Blank then This Loop should not execute===
                    If gv.Rows.Count > 0 Then
                        For i = 0 To gv.ColumnCount - 1
                            Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                            If TypeOf grow.Cells(i).Value Is DateTime Then
                                Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                                datecol.ExcelExportType = DisplayFormatType.ShortDate
                            End If
                        Next i
                    End If
                    '==================================================================
                    'AddHandler exporter.Progress, AddressOf PB.exporter_Progress
                    'ShowPb(gv.Rows.Count)

                    'exporter.Export(gv, path, frm.Text)
                    'HidePb()
                    clsCommon.ProgressBarShow()
                    '================ADD IIF (Blank Sheet) Condition to Save Blank Excel Sheet=========
                    'exportdata(gv, path, path.Substring(path.LastIndexOf("\") + 1, path.Length - path.LastIndexOf("\") - 1), IIf(frmFilter.chkBlankSheet.Checked, True, False)) 'frm.Text)
                    '============================================================
                    Dim exporter1 As New ExportToExcelML(gv)

                    ' AddHandler exporter1.ExcelCellFormatting, AddressOf exporter_ExcelCellFormatting
                    'exporter1.ExportHierarchy = True
                    'exporter1.ExportVisualSettings = True
                    'exporter1.SheetMaxRows = ExcelMaxRows._1048576
                    exporter1.SheetName = frm.Text
                    exporter1.RunExport(path)
                    frm.Controls.Remove(gv)
                    Dim oApp As Excel.Application
                    Dim oWB As Excel.Workbook
                    oApp = New Excel.Application
                    oWB = oApp.Workbooks.Open(path)
                    oApp.DisplayAlerts = False
                    oWB.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal)
                    oWB.Close()
                    oApp.Quit()

                    'My.Computer.FileSystem.RenameFile(Microsoft.VisualBasic.Left(path, Len(path) - 1), path.Substring(path.LastIndexOf("\") + 1, path.Length - path.LastIndexOf("\") - 1))
                    clsCommon.ProgressBarHide()
                    common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
                    System.Diagnostics.Process.Start(path)
                    'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
                    'excel.Workbooks.Open(path)
                    'excel.Visible = True


                Catch ex As Exception
                    frm.Controls.Remove(gv)
                    clsCommon.ProgressBarHide()
                    'HidePb()
                    Throw New Exception(ex.Message)
                    Return False
                End Try
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
        End Try
        Return True
    End Function
    '======shivani

    Public Function ExporttoExcelForPivot(ByVal sql As String, ByVal frm As RadForm, Optional ByVal pivotCols As String = "", Optional ByVal whrClaus As String = "", Optional ByVal OrderByClaus As String = "") As Boolean
        Try
            ''************* Filter Block Start
            '============Add By Rohit on June 17,2014 to show column Filter========
            'Dim frmFilterCol As New frmFilterColumnsToExport()
            'frmFilterCol.qry = sql
            'frmFilterCol.pivotCols = pivotCols
            'frmFilterCol.whrCls = " Where 2=2 " + whrClaus
            'If clsCommon.myLen(OrderByClaus) > 0 Then
            '    frmFilterCol.orderByClause = " Order by " + OrderByClaus
            'End If
            ''frmFilterCol.ShowDialog()
            'If frmFilterCol.isCancel Then
            '    GoTo a
            '    'Return False
            'End If
            'sql = frmFilterCol.qry
            '========================================================================
a:          Dim frmFilter As New frmFilterToExport()
            frmFilter.qry = sql
            frmFilter.whrCls = " Where 2=2 " + whrClaus
            If clsCommon.myLen(OrderByClaus) > 0 Then
                frmFilter.orderByClause = " Order by " + OrderByClaus
            End If
            frmFilter.ShowDialog()
            If frmFilter.isCancel Then
                Return False
            End If
            sql = frmFilter.qry
            ''************* Filter Block End

            Dim sfd As SaveFileDialog = New SaveFileDialog()
            Dim path As String
            sfd.FileName = frm.Text
            sfd.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls"
            If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = sfd.FileName
            Else
                Return False
            End If
            If InStr(path, ".xlsx") <> -1 Then
                path = Replace(path, ".xlsx", ".xls")
            End If
            If Not path.Equals(String.Empty) Then
                Dim gv As New RadGridView()
                Try
                    'Dim exporter As New RadGridViewExcelExporter()
                    gv.Name = "gTax"
                    frm.Controls.Add(gv)
                    FillGridView(sql, gv)
                    'gv.MasterGridViewTemplate.AllowAddNewRow = False
                    'gv.MasterGridViewTemplate.AutoGenerateColumns = True
                    'gv.DataSource = Nothing
                    'gv.DataSource = clsDBFuncationality.GetDataTable(sql)
                    If gv.Rows.Count = 0 And frmFilter.chkBlankSheet.Checked = False Then
                        common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                        Return False
                    End If

                    Dim i As Integer = 0
                    '===============Add If Condition For Row Count by Rohit on june 05,2014 If Sheet is Blank then This Loop should not execute===
                    If gv.Rows.Count > 0 Then
                        For i = 0 To gv.ColumnCount - 1
                            Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                            If TypeOf grow.Cells(i).Value Is DateTime Then
                                Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                                datecol.ExcelExportType = DisplayFormatType.ShortDate
                            End If
                        Next i
                    End If
                    '==================================================================
                    'AddHandler exporter.Progress, AddressOf PB.exporter_Progress
                    'ShowPb(gv.Rows.Count)

                    'exporter.Export(gv, path, frm.Text)
                    'HidePb()
                    clsCommon.ProgressBarShow()
                    '================ADD IIF (Blank Sheet) Condition to Save Blank Excel Sheet=========
                    'exportdata(gv, path, path.Substring(path.LastIndexOf("\") + 1, path.Length - path.LastIndexOf("\") - 1), IIf(frmFilter.chkBlankSheet.Checked, True, False)) 'frm.Text)
                    '============================================================
                    Dim exporter1 As New ExportToExcelML(gv)

                    ' AddHandler exporter1.ExcelCellFormatting, AddressOf exporter_ExcelCellFormatting
                    'exporter1.ExportHierarchy = True
                    'exporter1.ExportVisualSettings = True
                    'exporter1.SheetMaxRows = ExcelMaxRows._1048576
                    exporter1.SheetName = frm.Text
                    exporter1.RunExport(path)
                    frm.Controls.Remove(gv)
                    Dim oApp As Excel.Application
                    Dim oWB As Excel.Workbook
                    oApp = New Excel.Application
                    oWB = oApp.Workbooks.Open(path)
                    oApp.DisplayAlerts = False
                    oWB.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal)
                    oWB.Close()
                    oApp.Quit()

                    'My.Computer.FileSystem.RenameFile(Microsoft.VisualBasic.Left(path, Len(path) - 1), path.Substring(path.LastIndexOf("\") + 1, path.Length - path.LastIndexOf("\") - 1))
                    clsCommon.ProgressBarHide()
                    common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
                    System.Diagnostics.Process.Start(path)
                    'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
                    'excel.Workbooks.Open(path)
                    'excel.Visible = True


                Catch ex As Exception
                    frm.Controls.Remove(gv)
                    clsCommon.ProgressBarHide()
                    'HidePb()
                    Throw New Exception(ex.Message)
                    Return False
                End Try
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
        End Try
        Return True
    End Function
    '================

    Public Function ExporttoExcelWithoutFilter(ByVal sql As String, ByVal whrClaus As String, ByVal OrderByClaus As String, ByVal frm As RadForm, Optional Display_Firstrow As Boolean = False) As Boolean
        Try
            '            ''************* Filter Block Start
            '            '============Add By Rohit on June 17,2014 to show column Filter========
            '            'Dim Goinside As Boolean = True
            '            Dim frmFilterCol As New frmFilterColumnsToExport()
            '            frmFilterCol.qry = sql
            '            frmFilterCol.whrCls = " Where 2=2 " + whrClaus
            '            'If clsCommon.myLen(OrderByClaus) > 0 Then
            '            '    frmFilterCol.orderByClause = " Order by " + OrderByClaus
            '            'End If
            '            frmFilterCol.ShowDialog()
            '            If frmFilterCol.isCancel Then
            '                '   Goinside = False
            '                GoTo a
            '                'Return False
            '            End If
            '            sql = frmFilterCol.qry
            '            'Goinside = True
            '            '========================================================================
            'a:          Dim frmFilter As New frmFilterToExport()
            '            frmFilter.qry = sql
            '            'If Goinside = True AndAlso Not frmFilter.qry.ToUpper().Contains("ORDER BY") Then
            '            '    frmFilter.whrCls = " Where 2=2 "
            '            'ElseIf Goinside = False AndAlso Not frmFilter.qry.ToUpper().Contains("ORDER BY") Then
            '            '    frmFilter.whrCls = " Where 2=2 " + whrClaus
            '            'End If

            '            'If Not frmFilter.qry.ToUpper().Contains("ORDER BY") AndAlso clsCommon.myLen(OrderByClaus) > 0 Then
            '            '    frmFilter.orderByClause = " Order by " + OrderByClaus
            '            'End If
            '            frmFilter.ShowDialog()
            '            If frmFilter.isCancel Then
            '                Return False
            '            End If
            'sql = frmFilter.qry
            'If Not frmFilter.qry.ToUpper().Contains("ORDER BY") AndAlso clsCommon.myLen(OrderByClaus) > 0 Then
            '    sql = sql & " Order by " + OrderByClaus
            'End If
            ''************* Filter Block End

            Dim sfd As SaveFileDialog = New SaveFileDialog()
            Dim filePath As String
            sfd.FileName = frm.Text
            '  sfd.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls"
            sfd.Filter = "Excel 97-2003 (*.xls) |*.xls;|Excel 2007 *.xlsx|(*.xlsx);|CSV Files (*.csv) |*.csv"
            If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                filePath = sfd.FileName
            Else
                Return False
            End If
            'If InStr(path, ".xlsx") <> -1 Then
            '    path = Replace(path, ".xlsx", ".xls")
            'End If
            If Not filePath.Equals(String.Empty) Then
                Dim gv As New RadGridView()
                Try
                    'Dim exporter As New RadGridViewExcelExporter()
                    gv.Name = "gTax"
                    frm.Controls.Add(gv)
                    FillGridView(sql, gv)
                    If gv.Rows.Count = 0 Then
                        common.clsCommon.MyMessageBoxShow("There is no data to transfer.")
                        Return False
                    End If

                    Dim i As Integer = 0
                    '===============Add If Condition For Row Count by Rohit on june 05,2014 If Sheet is Blank then This Loop should not execute===
                    If gv.Rows.Count > 0 Then
                        For i = 0 To gv.ColumnCount - 1
                            Dim grow As GridViewRowInfo = TryCast(gv.Rows(0), GridViewRowInfo)
                            If TypeOf grow.Cells(i).Value Is DateTime Then
                                Dim datecol As GridViewDateTimeColumn = TryCast(gv.Columns(i), GridViewDateTimeColumn)
                                datecol.ExcelExportType = DisplayFormatType.ShortDate
                            End If
                        Next i
                    End If
                    '==================================================================
                    'AddHandler exporter.Progress, AddressOf PB.exporter_Progress
                    'ShowPb(gv.Rows.Count)

                    'exporter.Export(gv, path, frm.Text)
                    'HidePb()
                    '            clsCommon.ProgressBarShow()
                    '================ADD IIF (Blank Sheet) Condition to Save Blank Excel Sheet=========
                    Dim ext As String = Path.GetExtension(filePath)
                    If clsCommon.CompairString(ext, ".csv") = CompairStringResult.Equal Then
                        exportdataInCSV(gv, filePath, filePath.Substring(filePath.LastIndexOf("\") + 1, filePath.Length - filePath.LastIndexOf("\") - 1), False) 'frm.Text)
                    Else
                        exportdata(gv, filePath, filePath.Substring(filePath.LastIndexOf("\") + 1, filePath.Length - filePath.LastIndexOf("\") - 1), False, , Display_Firstrow) 'frm.Text)
                    End If

                    '============================================================
                    'Dim exporter1 As New ExportToExcelML(gv)

                    '' AddHandler exporter1.ExcelCellFormatting, AddressOf exporter_ExcelCellFormatting
                    ''exporter1.ExportHierarchy = True
                    ''exporter1.ExportVisualSettings = True
                    ''exporter1.SheetMaxRows = ExcelMaxRows._1048576
                    'exporter1.SheetName = frm.Text
                    'exporter1.RunExport(path)
                    'frm.Controls.Remove(gv)
                    If clsCommon.CompairString(ext, ".csv") = CompairStringResult.Equal Then
                        GoTo xxx
                    End If
                    Dim oApp As Excel.Application
                    Dim oWB As Excel.Workbook
                    oApp = New Excel.Application
                    oWB = oApp.Workbooks.Open(filePath)
                    oApp.DisplayAlerts = False
                    'If manadatoryField IsNot Nothing AndAlso manadatoryField.Length > 0 Then
                    '    Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet = oWB.Worksheets(frm.Text)
                    '    For c As Integer = 0 To wSheet.Columns.Count - 1
                    '        If clsCommon.myLen(wSheet.Cells(1, c + 1).value) <= 0 Then
                    '            Exit For
                    '        End If

                    '        If isManadatory(wSheet.Cells(1, c + 1).value, manadatoryField) Then
                    '            wSheet.Cells(1, c + 1).interior.color = RGB(Color.LightGoldenrodYellow.R, Color.LightGoldenrodYellow.G, Color.LightGoldenrodYellow.B)
                    '        End If
                    '    Next
                    'End If
                    oWB.SaveAs(filePath)
                    oWB.Close()
                    oApp.Quit()
xxx:
                    'My.Computer.FileSystem.RenameFile(Microsoft.VisualBasic.Left(path, Len(path) - 1), path.Substring(path.LastIndexOf("\") + 1, path.Length - path.LastIndexOf("\") - 1))
                    'clsCommon.ProgressBarHide()
                    common.clsCommon.MyMessageBoxShow("Data transfer Completed!", "Export", MessageBoxButtons.OK)
                    System.Diagnostics.Process.Start(filePath)
                    'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
                    'excel.Workbooks.Open(path)
                    'excel.Visible = True

                    Return True
                Catch ex As Exception
                    frm.Controls.Remove(gv)
                    'clsCommon.ProgressBarHide()
                    'HidePb()
                    Throw New Exception(ex.Message)
                    Return False
                End Try
            End If
        Catch ex As Exception
            common.clsCommon.MyMessageBoxShow("No data transfered." + Environment.NewLine + ex.Message, "Export Error", MessageBoxButtons.OK)
        End Try
        Return True
    End Function
    Public Function LoadDocument(ByVal gv As RadGridView, sheetName As String, ByVal ParamArray fieldNames As String()) As Boolean
        Dim workbook As Excel.Workbook = Nothing
        Dim rvalue As Boolean = False
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        Dim filePath As String
        If clsCommon.myLen(sheetName) <= 0 Then
            sheetName = "Sheet1"
        End If
        ofd.Filter = "Excel 97-2003 (*.xls) |*.xls;|Excel 2007 (*.xlsx)|*.xlsx;|CSV Files (*.csv) |*.csv"
        If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            filePath = ofd.FileName
        Else
            Return False
        End If
        Dim Extension As String = Path.GetExtension(filePath)
        Dim conStr As String = ""
        Dim selectedFormat As String = Extension
        'Dim formatProvider As IWorkbookFormatProvider = GetFormatProvider(selectedFormat)
        Dim dt As DataTable = New DataTable()
        'If formatProvider Is Nothing Then
        '    Return False
        'End If
        Dim colCount As Integer = 0
        If True Then
            Try

                'workbook = formatProvider.Import(stream)
                'Dim worksheet As Worksheet = workbook.Worksheets(0)
                Dim oApp As Excel.Application
                oApp = New Excel.Application
                oApp.Visible = False
                oApp.DisplayAlerts = False
                workbook = oApp.Workbooks.Open(filePath)
                Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = workbook.Worksheets(1)
                clsCommon.ProgressBarPercentShow()
                'wSheet.Range(ColumnIndexToColumnLetter(i + 1) & ":" & ColumnIndexToColumnLetter(i + 1)).Cells.NumberFormat = "@"

                Dim r As Microsoft.Office.Interop.Excel.Range = worksheet.UsedRange

                Dim array(,) As Object = r.Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault)

                Dim bound0 As Integer = array.GetUpperBound(0)
                Dim bound1 As Integer = array.GetUpperBound(1)

                'Dim properties As PropertyInfo() = array.[GetType]().GetElementType().GetProperties()

                For i As Integer = 1 To bound1
                    clsCommon.ProgressBarPercentUpdate(((i) * 100 / bound1), "Getting Field List " & (i) & " Of Total " & bound1 & " From Excel Sheet")
                    dt.Columns.Add(array(1, i), "".GetType())
                    dt.Columns(array(1, i)).Caption = array(1, i)
                Next

                For j As Integer = 2 To bound0
                    clsCommon.ProgressBarPercentUpdate(((j) * 100 / bound0), "Getting Record List " & (j) & " Of Total " & bound0 & " From Excel Sheet")
                    Dim dr As DataRow = dt.NewRow()
                    For x As Integer = 1 To bound1
                        dr(array(1, x)) = array(j, x)
                    Next
                    dt.Rows.Add(dr)
                Next
                'For Each arr As Object() In array
                '    Dim arr() As Object = array(j)
                '    dt.Rows.Add(arr)
                'Next



                'dt = ConvertToDataTable(array)

                ' dt = GetDataTableFromArray(array)


                'For i As Integer = 0 To worksheet.UsedRange.Columns.Count - 1
                '    colCount = i + 1
                '    clsCommon.ProgressBarPercentUpdate(((i + 1) * 100 / worksheet.UsedRange.Columns.Count), "Getting Field List " & (i + 1) & " Of Total " & worksheet.UsedRange.Columns.Count & " From Excel Sheet")
                '    If clsCommon.myLen(worksheet.Range(ColumnIndexToColumnLetter(i + 1) & "1").Text) <= 0 Then
                '        Exit For
                '    End If
                '    dt.Columns.Add(worksheet.Range(ColumnIndexToColumnLetter(i + 1) & "1").Text, worksheet.Range(ColumnIndexToColumnLetter(i + 1) & "1").Text.GetType)
                '    dt.Columns(worksheet.Range(ColumnIndexToColumnLetter(i + 1) & "1").Text).Caption = worksheet.Range(ColumnIndexToColumnLetter(i + 1) & "1").Text
                'Next
                'Dim RowCount As Integer = 0
                'For i As Integer = 1 To worksheet.Rows.Count - 1
                '    If clsCommon.myLen(worksheet.Range(ColumnIndexToColumnLetter(1) & (i + 1)).Text) <= 0 Then
                '        Exit For
                '    End If
                '    RowCount = RowCount + 1
                'Next



                'For i As Integer = 1 To RowCount
                '    clsCommon.ProgressBarPercentUpdate(((i + 1) * 100 / RowCount), "Getting Record List " & (i + 1) & " Of Total " & RowCount & " From Excel Sheet")
                '    If clsCommon.myLen(worksheet.Range(ColumnIndexToColumnLetter(1) & (i + 1)).Text) <= 0 Then
                '        ' Throw New Exception("First Column of Excel Sheet Found Blank")
                '        Exit For
                '    End If
                '    Dim dr As DataRow = dt.NewRow()
                '    For j As Integer = 0 To dt.Columns.Count - 1
                '        Dim colName As String = worksheet.Range(ColumnIndexToColumnLetter(j + 1) & "1").Text 'worksheet.Cells(0, j).Value
                '        dr(colName) = worksheet.Range(ColumnIndexToColumnLetter(j + 1) & (i + 1)).Text ' worksheet.Cells(i, j).Value
                '    Next
                '    dt.Rows.Add(dr)
                'Next
                oApp.Workbooks.Close()
                clsCommon.ProgressBarPercentHide()
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    rvalue = False
                Else
                    gv.DataSource = dt
                    rvalue = True
                End If
            Catch ex As IOException
                Try
                    clsCommon.ProgressBarPercentHide()
                Catch ex1 As Exception
                End Try
                Throw New Exception(ex.Message)
            End Try
            Return rvalue
        End If
        Return True
    End Function
    Public Function BulkExport(ByVal ReportName As String, ByVal _Query As String, ByVal OrderByClause As String, ByVal File_Type As String, Optional ByVal CTE_Separater As String = "") As String
        Dim FinalQuery As String = String.Empty
        Dim OrderBy As String = String.Empty
        Dim subPath As String = "C:\\ERPTempFolder"
        Dim ReportPath As String = "C:\\ERPTempFolder"
        Dim NetworkSubPath As String = "ERPTempFolder"
        'Dim subPath As String = "E:\\DataBase"
        'Dim ReportPath As String = "E:\\DataBase"
        'Dim NetworkSubPath As String = "DataBase"
        ''E:\DataBase
        Dim ReportPathLog As String = String.Empty
        ReportName = ReportName.Replace(" ", "_")
        ReportName = ReportName.Replace(",", "")
        ReportName = ReportName.Replace(".", "")
        If clsCommon.myLen(File_Type) <= 0 Then
            File_Type = "csv"
        ElseIf Not (clsCommon.CompairString(File_Type, "csv") = CompairStringResult.Equal OrElse clsCommon.CompairString(File_Type, "xls") = CompairStringResult.Equal) Then
            Throw New Exception("File format must be xls or csv")
        End If
        Try
            '' find order by clause 
            'clsCommon.ProgressBarShow()
            'Dim arr() As String
            If clsCommon.myLen(OrderByClause) > 0 Then
                If Not OrderByClause.ToLower.Contains("order by") Then
                    Throw New Exception("order by clause must start from order by")
                End If
                If _Query.ToLower.Contains(OrderByClause.ToLower) Then
                    _Query = _Query.Replace(OrderByClause, "")
                    'If arr.Length > 0 Then
                    '    _Query = arr(0)
                    'End If
                End If
                If _Query.ToLower.Contains("order by".ToLower) Then
                    Dim subQery As String = _Query
                    Dim indx As Integer = 0
                    Dim FinalLength As Integer = 0

                    'Dim Indx As Integer = _Query.ToLower.LastIndexOf("order by")

                    ''check if partition by cntains then first resolve this
                    If subQery.ToLower.Contains("partition by") Then
                        indx = subQery.ToLower.LastIndexOf("partition by")
                        If indx > 0 Then
                            FinalLength += indx
                            If clsCommon.myLen(subQery) > indx Then
                                subQery = subQery.Substring(indx, clsCommon.myLen(subQery) - (indx + 1))
                            Else
                                subQery = subQery.Substring(indx, clsCommon.myLen(subQery) - indx)
                            End If
                        End If
                        indx = 0

                        ''=======get first index of order by
                        indx = subQery.ToLower.IndexOf("order by")
                        If indx > 0 Then
                            FinalLength += indx
                            If clsCommon.myLen(subQery) > indx Then
                                subQery = subQery.Substring(indx, clsCommon.myLen(subQery) - (indx + 1))
                            Else
                                subQery = subQery.Substring(indx, clsCommon.myLen(subQery) - indx)
                            End If
                        End If
                        indx = 0

                        ''============now check for last index of order by, if exist
                        indx = subQery.ToLower.LastIndexOf("order by")

                        If indx > 0 Then
                            FinalLength += indx
                            _Query = _Query.ToLower.Substring(0, FinalLength)
                        End If
                    Else
                        indx = subQery.ToLower.LastIndexOf("order by")

                        If indx >= 0 Then
                            _Query = _Query.ToLower.Substring(0, indx)
                        End If
                    End If
                End If
            Else
                Dim indx As Integer = _Query.ToLower.LastIndexOf("order by")
                If indx >= 0 Then
                    _Query = _Query.ToLower.Substring(0, indx)
                End If
                'Dim strTemp As String = ""
                'For intChar As Integer = _Query.Length - 1 To 0 Step -1
                '    If Not strTemp.Contains("from") Then
                '        strTemp = strTemp & _Query.Chars(intChar)
                '    Else
                '        If Not strTemp.Trim.Contains("order by") Then
                '            Throw New Exception("Query must not contain order by ")
                '        End If
                '    End If
                'Next
            End If


            Dim qry As String = "SELECT CONVERT(INT, ISNULL(value, value_in_use)) AS config_value FROM sys.configurations WHERE  name = 'xp_cmdshell' "
            Dim Check As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(qry))
            If Check = 0 Then
                qry = " EXEC sp_configure 'show advanced options', 1;" & _
                      " RECONFIGURE " & _
                      " EXEC sp_configure 'xp_cmdshell', 1 ;" & _
                      " RECONFIGURE "
                clsDBFuncationality.ExecuteNonQuery(qry)
            End If
            Dim Col As String = "select "
            Dim ColNew As String = "select "
            Dim dt As New DataTable
            Dim colNo As Integer = 0
            If clsCommon.myLen(CTE_Separater) > 0 Then
                qry = " begin tran" & _
                  " SET FMTONLY ON; " & _
                  " " & _Query & " " & _
                  " SET FMTONLY OFF " & _
                  " commit tran"
            Else
                qry = " begin tran" & _
                      " SET FMTONLY ON " & _
                      " " & _Query & " " & _
                      " SET FMTONLY OFF " & _
                      " commit tran"
            End If


            dt = clsDBFuncationality.GetDataTable(qry)
            clsCommon.ProgressBarPercentUpdate(30, "Report Header Constructed")
            For Each dc As DataColumn In dt.Columns
                If colNo = 0 Then
                    Col = Col & "" & "'" & dc.ColumnName & "'as [" & dc.ColumnName & "]"
                    If clsCommon.CompairString(File_Type, "csv") = CompairStringResult.Equal Then
                        ColNew = ColNew & "(case when [" & dc.ColumnName & "] like '0%' then '=""'+ replace(cast([" & dc.ColumnName & "] as varchar(max)),',',' ')+ '""' else replace(cast([" & dc.ColumnName & "] as varchar(max)),',',' ') end) "
                    Else
                        ColNew = ColNew & "(case when [" & dc.ColumnName & "] like '0%' then '=""'+ coalesce(cast([" & dc.ColumnName & "] as varchar(max)),'')+ '""' else coalesce(cast([" & dc.ColumnName & "] as varchar(max)),'') end) "
                    End If

                Else
                    Col = Col & "," & "'" & dc.ColumnName & "'as [" & dc.ColumnName & "]"
                    If clsCommon.CompairString(File_Type, "csv") = CompairStringResult.Equal Then
                        ColNew = ColNew & "," & "(case when [" & dc.ColumnName & "] like '0%' then '=""'+ replace(cast([" & dc.ColumnName & "]  as varchar(max)),',',' ') + '""' else replace(cast([" & dc.ColumnName & "]  as varchar(max)),',',' ') end)"
                    Else
                        ColNew = ColNew & "," & "(case when [" & dc.ColumnName & "] like '0%' then '=""'+ coalesce(cast([" & dc.ColumnName & "]  as varchar(max)),'') + '""' else coalesce(cast([" & dc.ColumnName & "]  as varchar(max)),'') end)"
                    End If

                End If
                colNo = colNo + 1
            Next
            '' get path of the exported file

            '' your code goes here
            Dim IsExists As Boolean = System.IO.Directory.Exists(subPath)
            If IsExists Then
                System.IO.Directory.CreateDirectory(subPath)
            End If
            Dim Networkpath As String = ""
            Dim currTime As DateTime = DateTime.Now
            ReportPath = ReportPath & "\" & ReportName & clsCommon.GetPrintDate(currTime, "yyyyMMddhhmmss")
            Networkpath = NetworkSubPath & "\" & ReportName & clsCommon.GetPrintDate(currTime, "yyyyMMddhhmmss")
            subPath = ReportPath
            ReportPath = subPath & "." & File_Type
            ReportPathLog = subPath & ".txt"
            If System.IO.File.Exists(ReportPath) = True Then
                System.IO.File.Delete(ReportPath)
            End If
            '' export data
            If clsCommon.myLen(CTE_Separater) > 0 Then
                Dim InnerQry As String = ""
                Dim cteQry As String = ""
                Dim CteIndex As Integer = _Query.ToLower.LastIndexOf(CTE_Separater.ToLower)
                If CteIndex >= 0 Then
                    InnerQry = _Query.Substring(CteIndex, (_Query.Length - CteIndex))
                    cteQry = _Query.Substring(0, CteIndex)
                Else
                    Throw New Exception("CTE separater passed does not exists in Query.")
                End If
                FinalQuery = cteQry & "" & Environment.NewLine & Col & " union all " & ColNew & " from (" & InnerQry & ") Final"
            Else
                FinalQuery = Col & "union all " & ColNew & " from (" & _Query & ") Final"
            End If

            qry = String.Empty
            Dim Rpt_view_Name As String = "view_temp_" & ReportName
            qry = String.Empty
            qry = "SELECT count(*) FROM sys.views where name='" & Rpt_view_Name & "'"
            If clsCommon.myCdbl(clsDBFuncationality.getSingleValue(qry)) <= 0 Then
                qry = "create view " & Rpt_view_Name & " as " & FinalQuery
            Else
                qry = "alter view " & Rpt_view_Name & " as " & FinalQuery
            End If
            clsDBFuncationality.ExecuteNonQuery(qry)
            clsCommon.ProgressBarPercentUpdate(40, "Report View Created")
            qry = String.Empty
            Dim Server As String = objCommonVar.Database_Server ''clsCommon.myCstr(clsDBFuncationality.getSingleValue("SELECT SERVERPROPERTY('MachineName')"))            
            qry = "select * from " & objCommonVar.CurrDatabase & ".dbo." & Rpt_view_Name & ""
            If clsCommon.CompairString(File_Type, "xls") = CompairStringResult.Equal Then
                FinalQuery = "exec master..xp_cmdshell'bcp """ & qry & """ queryout " & ReportPath & " -o " & ReportPathLog & " -c -C RAW, -T -S " & Server & "'"
            Else
                FinalQuery = "exec master..xp_cmdshell'bcp """ & qry & """ queryout " & ReportPath & " -o " & ReportPathLog & " -c -t, -T -S " & Server & "'"
            End If

            clsDBFuncationality.ExecuteNonQuery(FinalQuery)
            '' check for operation is performed on database server or local network system

            If clsCommon.CompairString(Server.Substring(0, IIf(Server.Contains("\"), Server.IndexOf("\"), Server.Length)), Environment.MachineName, False) <> CompairStringResult.Equal Then
                Dim SrcPath As String = "\\" & Server & "\" & Networkpath & "." & File_Type
                System.IO.File.Copy(SrcPath, ReportPath, True)
            End If
            clsCommon.ProgressBarPercentUpdate(95, "Data transfered to file.")
            '' open excel file
            Process.Start(ReportPath)
            clsCommon.ProgressBarPercentUpdate(100, "File Opened.")
        Catch ex As Exception
            clsCommon.ProgressBarHide()
            Throw New Exception(ex.Message)
        Finally
            clsCommon.ProgressBarHide()
        End Try
        Return ReportPath
    End Function
    'Private Function ConvertToDataTable(array() As Object) As DataTable
    '    Dim properties As PropertyInfo() = array.[GetType]().GetElementType().GetProperties()
    '    Dim dt As DataTable = CreateDataTable(properties)
    '    If array.Length <> 0 Then
    '        For Each o As Object In array
    '            FillData(properties, dt, o)
    '        Next
    '    End If
    '    Return dt
    'End Function
    'Private Function CreateDataTable(properties As PropertyInfo()) As DataTable
    '    Dim dt As New DataTable()
    '    Dim dc As DataColumn = Nothing
    '    For Each pi As PropertyInfo In properties
    '        dc = New DataColumn()
    '        dc.ColumnName = pi.Name
    '        dc.DataType = pi.PropertyType
    '        dt.Columns.Add(dc)
    '    Next
    '    Return dt
    'End Function

    'Private Sub FillData(properties As PropertyInfo(), dt As DataTable, o As [Object])
    '    Dim dr As DataRow = dt.NewRow()
    '    For Each pi As PropertyInfo In properties
    '        dr(pi.Name) = pi.GetValue(o, Nothing)
    '    Next
    '    dt.Rows.Add(dr)
    'End Sub
    'Public Function GetDataTableFromArray(ByVal array As Object(,)) As DataTable
    '    Dim dataTable As New DataTable()
    '    dataTable.LoadDataRow(array, True) 'Pass array object to LoadDataRow 
    '    Return dataTable
    'End Function


End Module

Public Class clsJournalDetailTemp
    Public Account_code As String = Nothing
    Public Amount As String = Nothing
    Public Description As String = Nothing
    Public Reference As String = Nothing
    Public Hierarchy_Code As String = Nothing
    Public Cost_Center_Code As String = Nothing
End Class
