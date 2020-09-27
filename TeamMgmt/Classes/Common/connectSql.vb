Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationSettings
Imports Telerik.WinControls
Imports System.Globalization
Imports System.Collections
Imports common
Public Module connectSql
    Public strConn As String = clsDBFuncationality.connectionString 'Configuration.ConfigurationSettings.AppSettings("connectionString").ToString()
    Dim sql As String

    Public Function SqlCon() As String

        Return clsDBFuncationality.connectionString
    End Function

    Public Function Connection() As SqlConnection
        Return clsDBFuncationality.GetConnnection
    End Function

    Public Function OpenConnection() As SqlConnection
        Dim conn As SqlConnection = Connection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Return conn
    End Function

  

    Public Sub CloseConnection(ByVal cnn As SqlConnection)
        Dim conn As SqlConnection = Connection()
        Try
            If (conn.State And ConnectionState.Open) = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RunSql(ByVal strSQL As String) As Boolean
        Return RunSqlTransaction(Nothing, strSQL)
    End Function

    Public Function RunSqlTransaction(ByVal trans As SqlTransaction, ByVal strSQL As String) As Boolean
        Return clsDBFuncationality.ExecuteNonQuery(strSQL, trans)
    End Function

    Public Function RunScalar(ByVal strSQL As String) As String

        Return RunScalar(Nothing, strSQL)
    End Function

    Public Function RunScalar(ByVal trans As SqlTransaction, ByVal strSQL As String) As String
        Return clsCommon.myCstr(clsDBFuncationality.getSingleValue(strSQL, trans))
    End Function

    Public Function RunSQLReturnDS(ByVal strSql As String) As DataSet
        Return RunSQLReturnDS(Nothing, strSql)
    End Function

    Public Function RunSQLReturnDS(ByVal trans As SqlTransaction, ByVal strSql As String) As DataSet
        Dim ds As New DataSet()
        ds.Tables.Add(clsDBFuncationality.GetDataTable(strSql, trans).Copy())
        Return ds
    End Function

   

    Public Function RunSp(ByVal StrSp As String, ByVal ParamArray CommandParameters As SqlParameter()) As Boolean
        Return RunSpTransaction(Nothing, StrSp, CommandParameters)
    End Function

    Public Function RunSpTransaction(ByVal StrSp As String, ByVal ParamArray CommandParameters As SqlParameter()) As Integer
        Return RunSpTransaction(Nothing, StrSp, CommandParameters)
    End Function

    Public Function RunSpTransaction(ByVal trans As SqlTransaction, ByVal StrSp As String, ByVal ParamArray CommandParameters As SqlParameter()) As Boolean
        Return clsDBFuncationality.SaveAStorePorcedure(trans, StrSp, CommandParameters)
    End Function

    Public Function autoNumber(ByVal tableName As String, ByVal trans As SqlTransaction) As Integer
        Dim tCode As Integer = 0
        Dim i As Integer = CountTableRows(tableName, trans)
        If i = 0 Then
            tCode = 1
        Else
            tCode = i + 1
        End If
        Return tCode
    End Function

    Private Function CountTableRows(ByVal tableName As String, ByVal trans As SqlTransaction) As Integer
        Dim sql As String = "select count(*) as count from " + tableName
        Dim i As Integer = clsCommon.myCdbl(clsDBFuncationality.getSingleValue(sql, trans))
        Return i
    End Function


   
    

    Public Function serverDate() As String
        Return serverDate(Nothing)
    End Function

    Public Function serverDate(ByVal trans As SqlTransaction) As String
        Return clsCommon.GetPrintDate(clsCommon.GETSERVERDATE(trans), "dd/MM/yyyy")
    End Function

    Public Function myDate() As Date
        Return myDate(Nothing)
    End Function

    Public Function myDate(ByVal trans As SqlTransaction) As Date
        Return clsCommon.myCDate(serverDate(trans))
    End Function

End Module
