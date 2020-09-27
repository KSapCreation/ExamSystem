Imports common
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Drawing
Imports System

Public Class clsCreateAllTables
    Public Shared Sub CreateAllTable()
        Dim timeSpam1 As TimeSpan = TimeSpan.FromMilliseconds(DateTime.Now.Millisecond)
        Try


            'clsCommon.ProgressBarShow()

            clsCommon.ProgressBarPercentShow()
            clsCommonFunctionality.TableCounter = 0
            clsCommonFunctionality.TableTotal = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select COUNT(1) from INFORMATION_SCHEMA.TABLES  where TABLE_TYPE='BASE TABLE'"))
            Dim chk As Integer = 0
            chk = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("SELECT COUNT(OBJECT_ID) AS TotalTables FROM sys.tables"))
            If chk = 0 Then
                ' Dim strScript As String = XpertERPBlankTableScript.MainClass.GetQry()
                'clsDBFuncationality.ExecuteNonQuery(strScript)
                clsCommonFunctionality.TableTotal = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("select COUNT(1) from INFORMATION_SCHEMA.TABLES  where TABLE_TYPE='BASE TABLE'"))
            End If
            Dim coll As Dictionary(Of String, String)

            coll = New Dictionary(Of String, String)()
            coll.Add("Comp_Code", "Varchar(30) NOT NULL Primary key")
            coll.Add("Name", "VARCHAR(200) NOT NULL")
            coll.Add("DataBase_Name", "Varchar(100) null")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_COMPANY_MASTER", coll)

            coll = New Dictionary(Of String, String)
            coll.Add("Level_1", "varchar(100) NULL")
            coll.Add("Level_2", "varchar(100) NULL")

            coll.Add("SNo", "varchar(500) NULL")
            coll.Add("Re_Name", "varchar(500) NULL")
            coll.Add("Parent_Code", "varchar(500) NULL")
            coll.Add("Type", "varchar(5) NULL")
            coll.Add("Image_Number", "integer not null default 0")

            coll.Add("Program_Code", "varchar(12)  NOT NULL PRIMARY KEY")
            coll.Add("Program_Name", "varchar(100) NULL")
            coll.Add("Created_By", "varchar(12)  NOT NULL")
            coll.Add("Created_Date", "date  NOT NULL")
            coll.Add("Modify_By", "varchar(12)  NOT NULL")
            coll.Add("Modify_Date", "date  NOT NULL")
            coll.Add("Comp_Code", "varchar(8)  NOT NULL")
            coll.Add("VPF_Active_Report", "INTEGER NOT NULL DEFAULT 0")
            coll.Add("IsLoadFromOtherAssembly", "integer not null default 0")
            coll.Add("OtherAssemblyFilePathAndName", "varchar(1000) null")
            coll.Add("FormName", "varchar(100) null")
            coll.Add("Addas", "varchar(1) null")
            coll.Add("IntegrationVersion", "varchar(30) null")
            coll.Add("AsmName", "varchar(1000) null")
            coll.Add("MainFormName", "varchar(100) null")
            coll.Add("Is_SMS_Applied", "integer not null default 0")
            coll.Add("Is_EMAIL_Applied", "integer not null default 0")
            coll.Add("Is_Notification_Applied", "integer not null default 0")
            coll.Add("Amendment_Pwd", "varchar(200) NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_PROGRAM_MASTER", coll)

            coll = New Dictionary(Of String, String)
            coll.Add("Specification", "Varchar(500) DEFAULT ''")
            coll.Add("Type", "varchar(50)  NOT NULL")
            coll.Add("Code", "varchar(50)  NOT NULL")
            coll.Add("Description", "varchar(50)  NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_FIXED_PARAMETER", coll, "PRIMARY KEY (Type, Code)")

            coll = New Dictionary(Of String, String)
            coll.Add("Program_Code", "Varchar(12) NOT NULL")
            coll.Add("FP_Type", "varchar(50)  NOT NULL")
            coll.Add("FP_Code", "varchar(50)  NOT NULL")
            coll.Add("Control_Type", "integer NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_FIXED_PARAMETER_PROGRAM_MAPPING", coll, "PRIMARY KEY (Program_Code,FP_Type, FP_Code)")

            coll = New Dictionary(Of String, String)
            coll.Add("Program_Code", "VARCHAR(12) NOT NULL REFERENCES TSPL_PROGRAM_MASTER(Program_Code)")
            coll.Add("User_Code", "varchar(12) NOT NULL")
            coll.Add("SNo", "varchar(100) Null")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_FAVOURITE_MENU", coll)





            coll = New Dictionary(Of String, String)()
            coll.Add("USER_GROUP_CODE", "Varchar(30) NOT NULL Primary key")
            coll.Add("GROUP_DESCRIPTION", "VARCHAR(200) NOT NULL")
            coll.Add("Created_By", "varchar(12)  NOT NULL")
            coll.Add("Created_Date", "datetime  NOT NULL")
            coll.Add("Modify_By", "varchar(12)  NOT NULL")
            coll.Add("Modify_Date", "datetime  NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_USER_GROUP_MASTER", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("PROGRAM_GROUP_CODE", "Varchar(30) NOT NULL Primary key")
            coll.Add("GROUP_DESCRIPTION", "VARCHAR(200) NOT NULL")
            coll.Add("Created_By", "varchar(12)  NOT NULL")
            coll.Add("Created_Date", "datetime  NOT NULL")
            coll.Add("Modify_By", "varchar(12)  NOT NULL")
            coll.Add("Modify_Date", "datetime  NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_PROGRAM_GROUP_MASTER", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("PROGRAM_GROUP_CODE", "Varchar(30) NOT NULL REFERENCES TSPL_PROGRAM_GROUP_MASTER (PROGRAM_GROUP_CODE)")
            coll.Add("Program_Code", "varchar(12) NOT NULL REFERENCES TSPL_PROGRAM_MASTER (Program_Code)")
            coll.Add("isREAD", "Integer NOT NULL Default 0")
            coll.Add("isSAVE", "Integer NOT NULL Default 0")
            coll.Add("isDELETE", "Integer NOT NULL Default 0")
            coll.Add("isREPORT", "Integer NOT NULL Default 0")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_PROGRAM_GROUP_DETAIL", coll)





            'USER_CODE,USER_NAME,PASSWORD,TYPE,TYPE,USER_TYPE,Created_By,Created_Date,Modify_By,Modify_Date

            coll = New Dictionary(Of String, String)()
            coll.Add("USER_CODE", "Varchar(12) NOT NULL REFERENCES FBNPC_USER_MASTER(USER_CODE)")
            coll.Add("MAPPING_USER_CODE", "Varchar(12) NOT NULL REFERENCES FBNPC_USER_MASTER(USER_CODE)")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_MAPPING_USER_DETAIL", coll)

            Dim chkUserExist As Double = clsCommon.myCdbl(clsDBFuncationality.getSingleValue("Select count(*) from FBNPC_USER_MASTER"))
            If chkUserExist = 0 Then
                Dim obj As New clsUserMaster
                obj.USER_CODE = "Parteek"
                obj.USER_NAME = "Parteek"
                obj.PASSWORD = "Parteek"
                obj.TYPE = "Internal"
                obj.USER_TYPE = "Managment"
                obj.SaveData(obj, True, Nothing)
            End If

            coll = New Dictionary(Of String, String)()
            coll.Add("Tester_Time", "decimal (18,2) NOT NULL Default 0")
            coll.Add("Debugging_Time", "decimal (18,2) NOT NULL Default 0")
            coll.Add("Additional_Time", "decimal (18,2) NOT NULL Default 0")
            coll.Add("Created_By", "varchar(12)  NOT NULL")
            coll.Add("Created_Date", "datetime  NOT NULL")
            coll.Add("Modify_By", "varchar(12)  NOT NULL")
            coll.Add("Modify_Date", "datetime  NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_TIME_MASTER", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("USER_CODE", "Varchar(12) NOT NULL REFERENCES FBNPC_USER_MASTER(USER_CODE)")
            coll.Add("Created_By", "varchar(12)  NOT NULL")
            coll.Add("Created_Date", "datetime  NOT NULL")
            coll.Add("Modify_By", "varchar(12)  NOT NULL")
            coll.Add("Modify_Date", "datetime  NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_MAPPING_USER_GROUP_MASTER", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("USER_CODE", "Varchar(12) NOT NULL REFERENCES FBNPC_USER_MASTER(USER_CODE)")
            coll.Add("USER_GROUP_CODE", "Varchar(30) NOT NULL REFERENCES TSPL_USER_GROUP_MASTER(USER_GROUP_CODE)")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_MAPPING_USER_GROUP_DETAIL", coll)



            coll = New Dictionary(Of String, String)()
            coll.Add("Code", "varchar(30) not null primary key")
            coll.Add("SMS_Text", "varchar(5000) NOT NULL")
            coll.Add("Created_By", "varchar(12) NOT NULL")
            coll.Add("Created_Date", "datetime not null")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_SMS_HEAD", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("Code", "varchar(30) not null references TSPL_SMS_HEAD(Code)")
            coll.Add("Mobile_No", "varchar(20) NOT NULL")
            coll.Add("Send_On", "datetime null")
            coll.Add("Sender_Replay", "varchar(100) NULL")
            coll.Add("PK_Id", "integer NOT NULL  identity NOT FOR REPLICATION")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_SMS_DETAIL", coll, "Primary Key (Code,PK_Id)")


            coll = New Dictionary(Of String, String)()
            coll.Add("EMail_SMTP_Client", "Varchar(50) NULL")
            coll.Add("EMail_Port", "varchar(50) NULL")
            coll.Add("EMail_ID", "varchar(50) NULL ")
            coll.Add("EMail_Pwd", "varchar(50) NULL")
            coll.Add("EMail_Enabel_SSL", "integer not null Default 0")
            coll.Add("SMS_String", "Varchar(1000) NULL")
            coll.Add("Modified_By", "varchar(12) NOT NULL")
            coll.Add("Modified_Date", "Datetime NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_ES_Config", coll)


            coll = New Dictionary(Of String, String)()
            coll.Add("Form_Id", "varchar(20) not null primary Key")
            coll.Add("EMail_Subject", "Varchar(200) NULL")
            coll.Add("EMail_Text", "Text null")
            coll.Add("SMS_Text", "Varchar(2000) null")
            coll.Add("Notification_Caption", "Varchar(200) NULL")
            coll.Add("Notification_Text", "Varchar(2000) null")
            coll.Add("Notification_On", "char(1) null") 'S-Save, P-Post, A-Amendment
            coll.Add("Created_By", "varchar(12) NOT NULL")
            coll.Add("Created_Date", "Datetime NOT NULL")
            coll.Add("Modified_By", "varchar(12) NOT NULL")
            coll.Add("Modified_Date", "Datetime NOT NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_ES_Content", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("Form_Id", "varchar(20) not null REFERENCES TSPL_ES_Content(Form_Id)")
            coll.Add("EMP_CODE", "Varchar(12) NOT NULL REFERENCES FBNPC_USER_MASTER(USER_CODE)")
            coll.Add("Alert_Type", "integer null")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_ES_Content_Emp_Detail", coll)

            coll = New Dictionary(Of String, String)()
            coll.Add("Code", "varchar(30) not null primary key")
            coll.Add("Email_Subject", "varchar(5000) NOT NULL")
            coll.Add("Email_Text", "varchar(max) NOT NULL")
            coll.Add("EMail_ID", "varchar(5000) NOT NULL")
            coll.Add("Attachment_1_File_Name", "varchar(50) null")
            coll.Add("Attachment_1", "VarBinary(Max) null ")
            coll.Add("Attachment_2_File_Name", "varchar(50) null")
            coll.Add("Attachment_2", "VarBinary(Max) null ")
            coll.Add("Created_By", "varchar(12) NOT NULL")
            coll.Add("Created_Date", "datetime not null")
            coll.Add("Send_On", "datetime null")
            coll.Add("Sender_Replay", "varchar(100) NULL")
            clsCommonFunctionality.CreateOrAlterTable("TSPL_EMAIL_HEAD", coll)



            clsCommon.ProgressBarPercentHide()

        Catch ex As Exception
            clsCommon.ProgressBarPercentHide()
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
