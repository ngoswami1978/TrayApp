'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: neeraj goswami $
'$Workfile: 
'$Revision:$
'$Archive:$
'$Modtime:$

Imports System
Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.Data
Imports AAMS.bizShared
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports ExcelLibrary.SpreadSheet


Module Module1
    Public SecurityXml As String
    Public SecurityAdminXml As String
    Public gblLcode As Integer
    Public m_file_no As Integer
    Public strOrderId As String
    Public strOrderNumber As String
    Public strOrderType As String
    Public strFilePath As String = System.Configuration.ConfigurationSettings.AppSettings("ScanFolder")
    Public strZoomPercentage As String = System.Configuration.ConfigurationSettings.AppSettings("ZoomPercentage")
    Public strPdfFolderName As String
    Public gblstrOfficeid As String
    Public strEmpId As String
    Public gblBCID As String
    Public gblChainCode As String
    Public gblChainName As String
    Public gblUser As String
    Public gblDT As New DataTable
    Public gblCurrentDate As Integer
    Public gblSelectedDate As Integer
    Public gblRowId As Integer
    Public objXmldocs As New XmlDocument
    Public gblResultDate As Integer



    Public Sub BindDropDown(ByVal drpDownList As ComboBox, ByVal strType As String, ByVal bolSelect As Boolean)
        Dim objOutputXml As XmlDocument
        Dim objXmlReader As XmlNodeReader
        Dim ds As New Data.DataSet
        Select Case strType

            Case "AOFFICE"

                Dim objbzAOffice As New AAMS.bizMaster.bzAOffice
                objOutputXml = New XmlDocument
                objOutputXml = objbzAOffice.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AOFFICE")
                    drpDownList.DisplayMember = "AOFFICE"
                    drpDownList.ValueMember = "AOFFICE"

                End If
            Case "AIRLINE"
                Dim objbzAOffice As New AAMS.bizMaster.bzAirline
                objOutputXml = New XmlDocument
                objOutputXml = objbzAOffice.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AIRLINE")
                    drpDownList.DisplayMember = "NAME"
                    drpDownList.ValueMember = "Airline_Code"

                End If
            Case "AGROUP"
                Dim objbzAgencyGroup As New AAMS.bizMaster.bzAgencyGroup
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyGroup.ListGroupType()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("GROUP_TYPE")
                    drpDownList.DisplayMember = "GroupTypeName"
                    drpDownList.ValueMember = "GroupTypeID"

                End If
            Case "CITY"
                Dim objbzCity As New AAMS.bizMaster.bzCity
                objOutputXml = New XmlDocument
                objOutputXml = objbzCity.List()

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("CITY")
                    drpDownList.DisplayMember = "City_Name"
                    drpDownList.ValueMember = "CityID"

                End If
            Case "COUNTRY"
                Dim objbzCountry As New AAMS.bizMaster.bzCountry
                objOutputXml = New XmlDocument
                objOutputXml = objbzCountry.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("COUNTRY")
                    drpDownList.DisplayMember = "Country_Name"
                    drpDownList.ValueMember = "CountryID"

                End If
            Case "DESIGNATION"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("DESIGNATION")
                    drpDownList.DisplayMember = "Designation"
                    drpDownList.ValueMember = "DesignationID"

                End If
            Case "EMPLOYEE"
                Dim objbzEmployee As New AAMS.bizMaster.bzEmployee
                Dim objInputXml As New XmlDocument
                objOutputXml = objbzEmployee.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("EMPLOYEE")
                    drpDownList.DisplayMember = "Employee_Name"
                    drpDownList.ValueMember = "EmployeeID"

                End If


            Case "FileNo"
                Dim objbzAFileno As New AAMS.bizTravelAgency.bzAgency
                objOutputXml = New XmlDocument
                objOutputXml = objbzAFileno.GetFileNumber()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DisplayMember = "FileNo"
                    drpDownList.ValueMember = "FileNo"
                    drpDownList.DataSource = ds.Tables("FILENUMBER")
                End If


            Case "FileNoTCFilling"
                Dim bzOrder As New AAMS.bizTravelAgency.bzOrder
                objOutputXml = New XmlDocument
                objOutputXml = bzOrder.GetFileNumber()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then

                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    ' Dim dView As New DataView
                    ' dView = ds.Tables("FILENUMBER").DefaultView
                    'dView.Sort = "FileNo asc"
                    'dView.RowFilter = "0"
                    'dView.RowFilter = "FileNo<>0"
                    drpDownList.DisplayMember = "FileNo"
                    drpDownList.ValueMember = "FileNo"
                    drpDownList.DataSource = ds.Tables("FILENUMBER")
                End If


            Case "IPPOOL"
                Dim objbzIPPool As New AAMS.bizMaster.bzIPPool
                Dim objInputXml As New XmlDocument
                objOutputXml = New XmlDocument
                objInputXml.LoadXml("<MS_SEARCHIPPOOL_INPUT><PoolName></PoolName><Aoffice></Aoffice><Department_Name></Department_Name></MS_SEARCHIPPOOL_INPUT>")
                objOutputXml = objbzIPPool.Search(objInputXml)
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("IPPOOL")
                    drpDownList.DisplayMember = "PoolName"
                    drpDownList.ValueMember = "PoolID"

                End If
            Case "PRIORITY"
                Dim objbzAgencyGroup As New AAMS.bizMaster.bzAgencyGroup
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyGroup.ListPriority()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("PRIORITY")
                    drpDownList.DisplayMember = "PriorityName"
                    drpDownList.ValueMember = "PriorityID"

                End If
            Case "REGION"
                Dim objbzRegion As New AAMS.bizMaster.bzRegion
                objOutputXml = New XmlDocument

                objOutputXml = objbzRegion.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("REGION_DET")
                    drpDownList.DisplayMember = "Region_Name"
                    drpDownList.ValueMember = "Region_Name"

                End If
            Case "REGIONHQ"
                Dim objbzAOffice As New AAMS.bizMaster.bzAOffice
                objOutputXml = New XmlDocument
                objOutputXml = objbzAOffice.ListHQ()

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("Detail")
                    drpDownList.DisplayMember = "Name"
                    drpDownList.ValueMember = "ID"

                End If
            Case "STATE"
                Dim objbzCountryState As New AAMS.bizMaster.bzCountryState
                objOutputXml = New XmlDocument
                objOutputXml = objbzCountryState.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("STATE")
                    drpDownList.DisplayMember = "StateName"
                    drpDownList.ValueMember = "StateID"

                End If
            Case "SECURITYREGION"
                Dim objbzSecurityRegion As New AAMS.bizMaster.bzSecurityRegion
                objOutputXml = New XmlDocument
                objOutputXml = objbzSecurityRegion.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("SECURITYREGION")
                    drpDownList.DisplayMember = "Name"
                    drpDownList.ValueMember = "RegionID"

                End If
            Case "ManagerName"
                Dim objbzEmployee As New AAMS.bizMaster.bzEmployee
                objOutputXml = New XmlDocument
                objOutputXml = objbzEmployee.ListManager()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("EMPLOYEE")
                    drpDownList.DisplayMember = "Employee_Name"
                    drpDownList.ValueMember = "EmployeeID"

                End If
            Case "DepartmentName"
                Dim objbzDepartment As New AAMS.bizMaster.bzDepartment
                objOutputXml = New XmlDocument
                objOutputXml = objbzDepartment.List

                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("DEPARTMENT")
                    drpDownList.DisplayMember = "Department_Name"
                    drpDownList.ValueMember = "DepartmentID"

                End If
            Case "DESIGNATION"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("DESIGNATION")
                    drpDownList.DisplayMember = "Designation"
                    drpDownList.ValueMember = "DesignationID"

                End If
            Case "PRODUCTGROUP"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("PRODUCTGROUP")
                    drpDownList.DisplayMember = "ProductGroupName"
                    drpDownList.ValueMember = "ProductGroupId"

                End If
            Case "PROVIDERCRS"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("PROVIDERCRS")
                    drpDownList.DisplayMember = "CRSCodeText"
                    drpDownList.ValueMember = "Name"

                End If
            Case "OS"
                Dim objbzDesignation As New AAMS.bizMaster.bzDesignation
                objOutputXml = New XmlDocument
                objOutputXml = objbzDesignation.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("OS")
                    drpDownList.DisplayMember = "ProductGroupName"
                    drpDownList.ValueMember = "ProductGroupId"
                End If
            Case "CRS"
                Dim objbzCRS As New AAMS.bizMaster.bzCRS
                objOutputXml = New XmlDocument
                objOutputXml = objbzCRS.List()
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("CRS")
                    drpDownList.DisplayMember = "Name"
                    drpDownList.ValueMember = "CRSCodeText"
                End If

            Case "ATYPE"
                Dim objbzAgencyType As New AAMS.bizTravelAgency.bzAgencyType
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyType.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AGENCYTYPE")
                    drpDownList.DisplayMember = "Agency_Type_Name"
                    drpDownList.ValueMember = "AgencyTypeId"
                End If

            Case "ASTATUS"
                Dim objbzAgencyStatus As New AAMS.bizTravelAgency.bzAgencyStatus
                objOutputXml = New XmlDocument
                objOutputXml = objbzAgencyStatus.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("AGENCYSTATUS")
                    drpDownList.DisplayMember = "Agency_Status_Name"
                    drpDownList.ValueMember = "AgencyStatusId"
                End If

            Case "ONLINESTATUS"

                'AAMS.bizTravelAgency.bzOnlineStatus()
                '.List()


                Dim objOnlineStatus As New AAMS.bizTravelAgency.bzOnlineStatus
                objOutputXml = New XmlDocument
                objOutputXml = objOnlineStatus.List
                If objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").Value.ToUpper = "FALSE" Then
                    objXmlReader = New XmlNodeReader(objOutputXml)
                    ds.ReadXml(objXmlReader)
                    drpDownList.DataSource = ds.Tables("Status")
                    drpDownList.DisplayMember = "StatusCode"
                    drpDownList.ValueMember = "StatusCode"
                End If
        End Select
    End Sub

    Public Function SecurityCheck(ByVal intValue As Integer) As System.Text.StringBuilder
        Dim builSecurity As New System.Text.StringBuilder

        Dim ViewRight, AddRight, ModifyRight, DeleteRight, PrintRight As String
        ViewRight = 0 : AddRight = 0 : ModifyRight = 0 : DeleteRight = 0 : PrintRight = 0
        Select Case intValue
            Case 1
                ViewRight = "1"
            Case 2, 3
                ViewRight = "1"
                AddRight = "1"
            Case 4, 5
                ViewRight = "1"
                ModifyRight = "1"
            Case 6, 7
                ViewRight = "1"
                ModifyRight = "1"
                AddRight = "1"
            Case 8, 9
                ViewRight = "1"
                DeleteRight = "1"
            Case 10, 11
                ViewRight = "1"
                DeleteRight = "1"
                AddRight = "1"
            Case 12, 13
                ViewRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
            Case 14, 15
                ViewRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
                AddRight = "1"
            Case 16, 17
                ViewRight = "1"
                PrintRight = "1"
            Case 18, 19
                ViewRight = "1"
                PrintRight = "1"
                AddRight = "1"
            Case 20, 21
                ViewRight = "1"
                PrintRight = "1"
                ModifyRight = "1"
            Case 22, 23
                ViewRight = "1"
                PrintRight = "1"
                AddRight = "1"
                ModifyRight = "1"
            Case 24, 25
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
            Case 26, 27
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
                AddRight = "1"
            Case 28, 29
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
            Case 30, 31
                ViewRight = "1"
                PrintRight = "1"
                DeleteRight = "1"
                ModifyRight = "1"
                AddRight = "1"
        End Select

        If SecurityAdminXml.ToString().Split("|").GetValue(1).ToString() = "1" Then
            builSecurity.Append(1)
            builSecurity.Append(1)
            builSecurity.Append(1)
            builSecurity.Append(1)
            builSecurity.Append(1)
            Return builSecurity
        Else
            'Index 0 View
            builSecurity.Append(ViewRight)
            'Index 1 Add
            builSecurity.Append(AddRight)
            'Index 2 Modify
            builSecurity.Append(ModifyRight)
            'Index 3 Delete
            builSecurity.Append(DeleteRight)
            'Index 4 Print
            builSecurity.Append(PrintRight)
            Return builSecurity
        End If
    End Function

    Function GetDateInt(ByVal dt As String) As Integer
        ''**********************************************************************
        '   Sub
        ''**********************************************************************
        'DESC :To make the date in a proper format
        'Input : string
        'Output: Integer

        Dim arrDate As Array
        arrDate = Split(dt, "/", -1, 1)
        Dim dt1 As String
        dt1 = arrDate(2)

        If CType(arrDate(1), Integer) < 10 Then
            dt1 = dt1 + "0" + CStr(CInt(arrDate(1)))
        Else
            dt1 = dt1 + arrDate(1)
        End If
        If CType(arrDate(0), Integer) < 10 Then
            dt1 = dt1 + "0" + CStr(CInt(arrDate(0)))
        Else
            dt1 = dt1 + arrDate(0)
        End If
        Return dt1
    End Function

    Public Function ConvertDateBlank(ByVal intDate As String) As String
        If intDate.Trim = "" Then
            Return intDate
        End If
        Try
            Dim dtDateFrom As New Date(Left(CType(intDate, String), 4), Mid(CType(intDate, String), 5, 2), Right(CType(intDate, String), 2))
            Return dtDateFrom.ToString("dd/MM/yyyy")
        Catch ex As Exception
            Return CDate("1/1/1900")
        End Try
    End Function

    Public Function GetDateFormat(ByVal objDate As Object, ByVal dateInFormat As String, ByVal dateOutFormat As String, ByVal dateSepChar As String) As String
        Dim str As String = ""
        If objDate.Trim = "" Then
        Else
            Try
                If dateInFormat.Equals("yyyyMMdd") Then
                    str = DateTime.ParseExact(objDate, dateInFormat, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat).ToString(dateOutFormat)
                Else
                    Dim ln As Integer = objDate.ToString().Length
                    If ln = 8 And dateInFormat.Equals("dd/MM/yyyy") Then
                        dateInFormat = "dd/MM/yy"
                    End If
                    Dim dt As New DateTime()
                    '  Dim dtfi As New DateTimeFormatInfo
                    Dim dtfi As New DateTimeFormatInfo
                    dtfi.ShortDatePattern = dateInFormat
                    dtfi.DateSeparator = dateSepChar
                    dt = Convert.ToDateTime(objDate, dtfi)
                    str = dt.ToString(dateOutFormat)
                End If

            Catch ex As Exception
                str = "0"
            End Try
        End If
        Return str
    End Function

    Public Function ShowResult() As XmlDocument

        Dim strCon = bzShared.GetConnectionString()
        Dim objSqlConnection As New SqlConnection(strCon)
        Dim objSqlCommand As New SqlCommand

        Dim gstrList_OUTPUT As String = "<TEAMTASK><Count Total='' CR= '' PR='' GR=''></Count><Hr Total='' CR= '' PR='' GR='' TOTALMONTHLYHR=''></Hr><Details ROWID='' DATE='' TASKDESCRIPTION='' TYPE='' ID='' WORKINGHR='' /><Errors Status=''><Error Code='' Description='' /></Errors></TEAMTASK>"
        Dim objOutputXml As New XmlDocument
        Dim objAptNode, objAptNodeClone As XmlNode
        Dim objSqlReader As SqlDataReader
        Dim blnRecordFound As Boolean = False
        Dim intRowsCount As Int32

        Dim intCRCount As Int32
        Dim intPRCount As Int32
        Dim intGRCount As Int32

        Dim intCRHR As Int32
        Dim intPRHR As Int32
        Dim intGRHR As Int32
        Dim intTOTALMONTHLYHR As Int32

        objOutputXml.LoadXml(gstrList_OUTPUT)
        Try
            With objSqlCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[UP_GET_AAMS_TEAM_TASK]"
                .Connection = objSqlConnection
                .CommandTimeout = 0


                .Parameters.Add(New SqlParameter("@EMPLOYEENAME", SqlDbType.VarChar, 50))
                .Parameters("@EMPLOYEENAME").Value = gblUser

                .Parameters.Add(New SqlParameter("@DATE", SqlDbType.Int))
                .Parameters("@DATE").Value = gblResultDate

                .Parameters.Add(New SqlParameter("@CRCOUNT", SqlDbType.Int))
                .Parameters("@CRCOUNT").Direction = ParameterDirection.Output
                .Parameters("@CRCOUNT").Value = 0

                .Parameters.Add(New SqlParameter("@PRCOUNT", SqlDbType.Int))
                .Parameters("@PRCOUNT").Direction = ParameterDirection.Output
                .Parameters("@PRCOUNT").Value = 0

                .Parameters.Add(New SqlParameter("@GRCOUNT", SqlDbType.Int))
                .Parameters("@GRCOUNT").Direction = ParameterDirection.Output
                .Parameters("@GRCOUNT").Value = 0

                .Parameters.Add(New SqlParameter("@CRHR", SqlDbType.Int))
                .Parameters("@CRHR").Direction = ParameterDirection.Output
                .Parameters("@CRHR").Value = 0

                .Parameters.Add(New SqlParameter("@PRHR", SqlDbType.Int))
                .Parameters("@PRHR").Direction = ParameterDirection.Output
                .Parameters("@PRHR").Value = 0

                .Parameters.Add(New SqlParameter("@GRHR", SqlDbType.Int))
                .Parameters("@GRHR").Direction = ParameterDirection.Output
                .Parameters("@GRHR").Value = 0

                .Parameters.Add(New SqlParameter("@TOTALMONTHLYHR", SqlDbType.Int))
                .Parameters("@TOTALMONTHLYHR").Direction = ParameterDirection.Output
                .Parameters("@TOTALMONTHLYHR").Value = 0

                .Parameters.Add(New SqlParameter("@ROWCOUNT", SqlDbType.Int))
                .Parameters("@ROWCOUNT").Direction = ParameterDirection.Output
                .Parameters("@ROWCOUNT").Value = 0

                objSqlCommand.Connection.Open()
                objSqlReader = objSqlCommand.ExecuteReader()
            End With
            If objSqlReader.HasRows = True Then
                blnRecordFound = True
                objAptNode = objOutputXml.DocumentElement.SelectSingleNode("Details")
                objAptNodeClone = objAptNode.CloneNode(True)
                objOutputXml.DocumentElement.RemoveChild(objAptNode)
                While objSqlReader.Read()
                    objAptNodeClone.Attributes("ROWID").InnerText = Trim(objSqlReader.GetValue(objSqlReader.GetOrdinal("ROWID")) & "")
                    objAptNodeClone.Attributes("DATE").InnerText = Trim(objSqlReader.GetValue(objSqlReader.GetOrdinal("DATE")) & "")
                    objAptNodeClone.Attributes("TASKDESCRIPTION").InnerText = Trim(objSqlReader.GetValue(objSqlReader.GetOrdinal("TASKDESCRIPTION")) & "")
                    objAptNodeClone.Attributes("TYPE").InnerText = Trim(objSqlReader.GetValue(objSqlReader.GetOrdinal("TYPE")) & "")
                    objAptNodeClone.Attributes("ID").InnerText = Trim(objSqlReader.GetValue(objSqlReader.GetOrdinal("ID")) & "")
                    objAptNodeClone.Attributes("WORKINGHR").InnerText = Trim(objSqlReader.GetValue(objSqlReader.GetOrdinal("WORKINGHR")) & "")
                    objOutputXml.DocumentElement.AppendChild(objAptNodeClone)
                    objAptNodeClone = objAptNode.CloneNode(True)
                End While
            End If
            objSqlCommand.Connection.Close()

            intRowsCount = Val(objSqlCommand.Parameters("@ROWCOUNT").Value & "")
            intCRCount = Val(objSqlCommand.Parameters("@CRCOUNT").Value & "")
            intPRCount = Val(objSqlCommand.Parameters("@PRCOUNT").Value & "")
            intGRCount = Val(objSqlCommand.Parameters("@GRCOUNT").Value & "")

            intCRHR = Val(objSqlCommand.Parameters("@CRHR").Value & "")
            intPRHR = Val(objSqlCommand.Parameters("@PRHR").Value & "")
            intGRHR = Val(objSqlCommand.Parameters("@GRHR").Value & "")
            intTOTALMONTHLYHR = Val(objSqlCommand.Parameters("@TOTALMONTHLYHR").Value & "")

            If blnRecordFound = False Then
                bzShared.FillErrorStatus(objOutputXml, "101", "No Record Found")
            Else
                objOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE"

                objOutputXml.DocumentElement.SelectSingleNode("Count").Attributes("Total").InnerText = intCRCount + intPRCount + intGRCount
                objOutputXml.DocumentElement.SelectSingleNode("Count").Attributes("CR").InnerText = intCRCount
                objOutputXml.DocumentElement.SelectSingleNode("Count").Attributes("PR").InnerText = intPRCount
                objOutputXml.DocumentElement.SelectSingleNode("Count").Attributes("GR").InnerText = intGRCount

                objOutputXml.DocumentElement.SelectSingleNode("Hr").Attributes("Total").InnerText = intCRHR + intPRHR + intGRHR
                objOutputXml.DocumentElement.SelectSingleNode("Hr").Attributes("CR").InnerText = intCRHR
                objOutputXml.DocumentElement.SelectSingleNode("Hr").Attributes("PR").InnerText = intPRHR
                objOutputXml.DocumentElement.SelectSingleNode("Hr").Attributes("GR").InnerText = intGRHR
                objOutputXml.DocumentElement.SelectSingleNode("Hr").Attributes("TOTALMONTHLYHR").InnerText = intTOTALMONTHLYHR
            End If

        Catch Exec As AAMSException
            'CATCHING AAMS EXCEPTIONS
            bzShared.FillErrorStatus(objOutputXml, "101", Exec.Message)
            Return objOutputXml
        Catch exec As Exception
            'msgbox(exec.ToString)
            bzShared.LogWrite("clsShowMissingMidtCRS", "ShowMissingMidtCRS", exec)
            bzShared.FillErrorStatus(objOutputXml, "103", exec.Message)
            Return objOutputXml
        Finally
            If objSqlConnection.State = ConnectionState.Open Then objSqlConnection.Close()
            objSqlCommand.Dispose()
        End Try
        Return objOutputXml
    End Function

    Public Function Delete(ByVal DeleteDoc As System.Xml.XmlDocument) As System.Xml.XmlDocument
        '***********************************************************************
        'Purpose:This function deletes a department.
        'Input:XmlDocument
        '<TEAMTASK_DELETE_INPUT>
        '<Rowid></Rowid>
        '</TEAMTASK_DELETE_INPUT>

        'Output :
        '<TEAMTASK_DELETE_OUTPUT>
        '	<Errors Status=''>
        '		<Error Code='' Description='' />
        '</Errors>
        '</TEAMTASK_DELETE_OUTPUT>

        '************************************************
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString())
        Dim objSqlCommand As New SqlCommand
        Dim intRecordsAffected As Integer
        Const strMETHOD_NAME As String = "Delete"
        Dim intDepartment_id As Integer
        Dim objDeleteDocOutput As New XmlDocument
        Dim strROWID As String = String.Empty

        objDeleteDocOutput.LoadXml("<TEAMTASK_DELETE_OUTPUT><Errors Status=''><Error Code='' Description='' /></Errors></TEAMTASK_DELETE_OUTPUT>")

        If DeleteDoc.DocumentElement.SelectSingleNode("Rowid") IsNot Nothing Then
            strROWID = DeleteDoc.DocumentElement.SelectSingleNode("Rowid").InnerText.Trim
        End If

        Try
            intRecordsAffected = 0

            If Len(strROWID) <= 0 Then
                Throw (New AAMSException("Incomplete Parameter Row id"))
            End If
            'Deleting the specific record

            With objSqlCommand
                .Connection = objSqlConnection
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[UP_SRO_AAMS_TEAM_TASK]"
                .Parameters.Add(New SqlParameter("@ACTION", SqlDbType.Char, 1))
                .Parameters("@ACTION").Value = "D"

                .Parameters.Add(New SqlParameter("@ROWID", SqlDbType.Int))
                .Parameters("@ROWID").Value = CInt(strROWID)

                .Parameters.Add(New SqlParameter("@LOGINNAME", SqlDbType.VarChar, 20))
                If DeleteDoc.DocumentElement.SelectSingleNode("LOGINNAME").InnerText = "" Then
                    .Parameters("@LOGINNAME").Value = DBNull.Value
                Else
                    .Parameters("@LOGINNAME").Value = DeleteDoc.DocumentElement.SelectSingleNode("LOGINNAME").InnerText
                End If

                objSqlCommand.Connection.Open()
                intRecordsAffected = .ExecuteNonQuery()
                objSqlCommand.Connection.Close()
            End With

            'Checking whether record is deleted successfully or not
            If intRecordsAffected > 0 Then
                objDeleteDocOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "False"
                Return (objDeleteDocOutput)
            Else
                objDeleteDocOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "True"
                Call bzShared.FillErrorStatus(objDeleteDocOutput, "101", "Record has not been deleted!")
                Return (objDeleteDocOutput)
            End If
        Catch Exec As AAMSException
            'CATCHING AAMS EXCEPTIONS
            bzShared.FillErrorStatus(objDeleteDocOutput, "101", Exec.Message)
        Catch Exec As Exception
            'CATCHING OTHER EXCEPTIONS
            'Fill Error Status
            bzShared.LogWrite("Delete", strMETHOD_NAME, Exec)
            bzShared.FillErrorStatus(objDeleteDocOutput, "101", Exec.Message)
        Finally
            If objSqlConnection.State = ConnectionState.Open Then objSqlConnection.Close()
            objSqlCommand.Dispose()
        End Try
        Return objDeleteDocOutput
    End Function


    Public Function GetUserList() As String()
        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objEmployee As New AAMS.bizMaster.bzEmployee
        Dim cmd As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString())  ''connection string from AAMS
        Dim mhostname As String = Dns.GetHostName()
        Dim strPermisionUserFromConfig As String
        Dim strArrUsers() As String
        Dim strGetUserNameFromConfig As String
        Dim count As Integer
        Dim blnAllowConfigUser As Boolean
        blnAllowConfigUser = False

        Try
            cmd.CommandText = "UP_GET_USERNAMEFORTASKSHEET"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objSqlConnection
            objSqlConnection.Open()
            strGetUserNameFromConfig = cmd.ExecuteScalar()
            strPermisionUserFromConfig = "Select one," + strGetUserNameFromConfig

            strArrUsers = strPermisionUserFromConfig.Split(",")

            'For count = 0 To strArrUsers.Length - 1
            '    If UCase(txtUsername.Text) = UCase(strArrUsers(count)) Then
            '        blnAllowConfigUser = True
            '        objSqlConnection.Close()
            '        Exit For
            '    End If
            'Next
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "Load", exc.GetBaseException)
        Finally

        End Try
        Return strArrUsers
    End Function

    Public Function CreatDataTable() As DataTable
        Dim dt As DataTable
        Dim dcol As DataColumn

        'DATE,TaskDescription,Type,ID,WORKINGHR

        dt = New DataTable("TaskDetail")

        dcol = New DataColumn("Rowid", GetType(Integer))
        dt.Columns.Add(dcol)

        dcol = New DataColumn("Date", GetType(String))
        dt.Columns.Add(dcol)

        dcol = New DataColumn("TaskDescription", GetType(String))
        dt.Columns.Add(dcol)

        dcol = New DataColumn("Type", GetType(String))
        dt.Columns.Add(dcol)

        dcol = New DataColumn("Id", GetType(Integer))
        dt.Columns.Add(dcol)

        dcol = New DataColumn("Wrk hour", GetType(Integer))
        dt.Columns.Add(dcol)

        Return dt
    End Function

    Public Function UpdateTask(ByVal UpdateDoc As System.Xml.XmlDocument) As System.Xml.XmlDocument

        Dim intRetId As Integer
        Dim strAction As String = ""
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString)
        Dim objSqlCommand As New SqlCommand
        Dim objUpdateDocOutput As New XmlDocument
        Dim intRecordsAffected As Int32
        Dim objxmlNodelist As XmlNodeList
        Dim objAptNode, objAptNodeClone As XmlNode
        Dim strDate As String = String.Empty
        Dim strType As String = String.Empty
        Dim strId As String = String.Empty
        Dim strdesc As String = String.Empty
        Dim strNoofHr As String = String.Empty
        Dim strROWID As String = String.Empty

        Dim strUPDATE_OUTPUT As String = "<UP_UPDATE_TEAMTASK_OUTPUT><Details  ROWID='' DATE='' TASKDESCRIPTION='' TYPE='' ID='' WORKINGHR='' /><Errors Status='FALSE'><Error Code='' Description='' /></Errors></UP_UPDATE_TEAMTASK_OUTPUT>"
        Const strMETHOD_NAME As String = "Update"
        Try

            objUpdateDocOutput.LoadXml(strUPDATE_OUTPUT)

            If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("ROWID") IsNot Nothing Then
                strROWID = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("ROWID").InnerText.Trim
            End If

            If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("DATE") IsNot Nothing Then
                strDate = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("DATE").InnerText.Trim
            End If
            If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("TASKDESCRIPTION") IsNot Nothing Then
                strdesc = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("TASKDESCRIPTION").InnerText.Trim
            End If
            If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("TYPE") IsNot Nothing Then
                strType = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("TYPE").InnerText.Trim
            End If
            If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("ID") IsNot Nothing Then
                strId = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("ID").InnerText.Trim
            End If
            If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("WORKINGHR") IsNot Nothing Then
                strNoofHr = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("WORKINGHR").InnerText.Trim
            End If

            'Retrieving & Checking Details from Input XMLDocument
            If strROWID = "" Or strROWID = "0" Then
                strAction = "I"
            Else
                strAction = "U"
            End If


            'ADDING PARAMETERS IN STORED PROCEDURE
            With objSqlCommand

                .Connection = objSqlConnection
                .CommandType = CommandType.StoredProcedure
                .CommandText = "[UP_SRO_AAMS_TEAM_TASK]"

                .Parameters.Add(New SqlParameter("@ACTION", SqlDbType.Char, 1))
                .Parameters("@ACTION").Value = strAction

                .Parameters.Add(New SqlParameter("@ROWID", SqlDbType.Int))
                If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("ROWID").InnerText = "" Or strROWID = "0" Then
                    .Parameters("@ROWID").Value = DBNull.Value
                Else
                    .Parameters("@ROWID").Value = CInt(strROWID)
                End If

                .Parameters.Add(New SqlParameter("@LOGINNAME", SqlDbType.VarChar, 20))
                If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("LOGINNAME").InnerText = "" Then
                    .Parameters("@LOGINNAME").Value = DBNull.Value
                Else
                    .Parameters("@LOGINNAME").Value = UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("LOGINNAME").InnerText
                End If

                .Parameters.Add(New SqlParameter("@DATE", SqlDbType.Int))
                .Parameters("@DATE").Value = CInt(strDate)

                'If strDate.ToString() = "" Or strDate.ToString() = "0" Then
                '    .Parameters("@DATE").Value = gblCurrentDate
                'Else
                '    If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("DATE").InnerText = "" Then
                '        .Parameters("@DATE").Value = DBNull.Value
                '    Else
                '        .Parameters("@DATE").Value = CInt(strDate)
                '    End If
                'End If

                .Parameters.Add(New SqlParameter("@TYPE", SqlDbType.Char, 2))
                If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("TYPE").InnerText = "" Then
                    .Parameters("@TYPE").Value = DBNull.Value
                Else
                    .Parameters("@TYPE").Value = strType
                End If

                .Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
                If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("ID").InnerText = "" Then
                    .Parameters("@ID").Value = DBNull.Value
                Else
                    .Parameters("@ID").Value = CInt(Val(strId & ""))
                End If

                .Parameters.Add(New SqlParameter("@TASKDESCRIPTION", SqlDbType.VarChar, 8000))
                If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("TASKDESCRIPTION").InnerText = "" Then
                    .Parameters("@TASKDESCRIPTION").Value = DBNull.Value
                Else
                    .Parameters("@TASKDESCRIPTION").Value = strdesc.ToString()
                End If

                .Parameters.Add(New SqlParameter("@WORKINGHR", SqlDbType.Int))
                If UpdateDoc.DocumentElement.SelectSingleNode("Details").Attributes("WORKINGHR").InnerText = "" Then
                    .Parameters("@WORKINGHR").Value = DBNull.Value
                Else
                    .Parameters("@WORKINGHR").Value = CInt(Val(strNoofHr & ""))
                End If

                '-------- OutPut Paramater--------------------------------------------------------------
                .Parameters.Add(New SqlParameter("@RETURNID", SqlDbType.Int))
                .Parameters("@RETURNID").Direction = ParameterDirection.Output
                .Parameters("@RETURNID").Value = 0

                'EXECUTING STORED PROCEDURE AND CHECKING IF RECORD IS INSERTED/UPDATED
                .Connection.Open()
                intRecordsAffected = .ExecuteNonQuery()
                intRetId = Val(.Parameters("@RETURNID").Value & "")

                If intRetId = 0 Then
                    Throw (New AAMSException("Task already Exists!"))
                Else
                    objUpdateDocOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE"
                End If
            End With

        Catch Exec As AAMSException
            'CATCHING AAMS EXCEPTIONS
            bzShared.FillErrorStatus(objUpdateDocOutput, "101", Exec.Message)
            bzShared.LogWrite("UpdateTask", strMETHOD_NAME, Exec)
            Return objUpdateDocOutput
        Catch Exec As Exception
            intRetId = Val(objSqlCommand.Parameters("@CONVERTID").Value & "")
            If intRetId = 100 Then
                'CATCHING AAMS EXCEPTIONS
                objUpdateDocOutput.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE"
            Else
                bzShared.LogWrite("UpdateTask", strMETHOD_NAME, Exec)
                bzShared.FillErrorStatus(objUpdateDocOutput, "101", Exec.Message)
            End If
            Return objUpdateDocOutput
        Finally
            If objSqlConnection.State = ConnectionState.Open Then objSqlConnection.Close()
            objSqlCommand.Dispose()
        End Try
        Return objUpdateDocOutput
    End Function

    Public Function ConvertTextDate(ByVal dt As String) As String '''''''to convert dd/mm/yyyy to yyyymmdd
        Dim lstrarrDate As Array
        Dim lstrdtyear As String
        Dim lstrdtmonth As String
        Dim lstrdtday As String
        Dim lstrDate As String
        If dt <> "" Then
            lstrarrDate = Split(dt, "/", -1, 1)
            lstrdtyear = lstrarrDate(2)
            lstrdtmonth = lstrarrDate(1)
            lstrdtday = lstrarrDate(0)
            If CType(lstrarrDate(1), String).Length = 1 Then
                lstrdtmonth = "0" + lstrarrDate(1)
            Else
                lstrdtmonth = lstrarrDate(1)
            End If
            If CType(lstrarrDate(0), String).Length = 1 Then
                lstrdtday = "0" + lstrarrDate(0)
            Else
                lstrdtday = lstrarrDate(0)
            End If

            lstrDate = lstrdtyear & lstrdtmonth & lstrdtday
            Return lstrDate
        Else
            Return dt
        End If
    End Function
    

    Public Class ExcelHandler

        ' Return data in dataset from excel file. '
        Public Function GetDataFromExcel(ByVal a_sFilepath As String) As DataSet
            Dim ds As DataSet = New DataSet()
            Dim cn As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & a_sFilepath & ";Extended Properties= Excel 8.0")
            'Provider=Microsoft.ACE.OLEDB.12.0
            'Dim cn As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & a_sFilepath & ";Extended Properties= Excel 8.0")
            Try
                cn.Open()
            Catch ex As OleDbException
                Console.WriteLine(ex.Message)
                cn.Close()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                cn.Close()
            End Try

            ' It Represents Excel data table Schema.'
            Dim dt As New System.Data.DataTable()


            dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            If dt IsNot Nothing OrElse dt.Rows.Count > 0 Then
                For sheet_count As Integer = 0 To 0
                    Try
                        ' Create Query to get Data from sheet. '
                        Dim sheetname As String = dt.Rows(sheet_count)("table_name").ToString()
                        'Dim oledbCmd As OleDbCommand
                        'oledbCmd = New OleDbCommand("SELECT * FROM [" & sheetname & "]", cn)
                        'Dim oledbReader As OleDbDataReader = oledbCmd.ExecuteReader()
                        Dim da As New OleDbDataAdapter("SELECT * FROM [" & sheetname & "]", cn)
                        Dim dt2 As System.Data.DataTable = New System.Data.DataTable()
                        dt2.Columns.Add("SNO", System.Type.GetType("System.Int32"))
                        dt2.Columns.Add("COURSE", System.Type.GetType("System.String"))
                        dt2.Columns.Add("PERIOD", System.Type.GetType("System.String"))
                        dt2.Columns.Add("INSTRUCTOR", System.Type.GetType("System.String"))
                        dt2.Columns.Add("AGENCY", System.Type.GetType("System.String"))
                        dt2.Columns.Add("NAME OF THE PARTICIPANT", System.Type.GetType("System.String"))
                        dt2.Columns.Add("MARKS", System.Type.GetType("System.String"))
                        dt2.Columns.Add("STATION", System.Type.GetType("System.String"))
                        dt2.Columns.Add("Login Id", System.Type.GetType("System.Int32"))
                        dt2.Columns.Add("Reason ", System.Type.GetType("System.String"))
                        ''dt2.Load(oledbReader)
                        dt2.TableName = sheetname
                        ds.Tables.Add(dt2)
                        da.Fill(ds.Tables(0))
                    Catch ex As DataException
                        Console.WriteLine(ex.Message)
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                Next
            End If
            cn.Close()
            Return ds
        End Function

        ' Write Excel file as given file name with given data.'
        Public Function ExportToExcel(ByVal a_sFilename As String, ByVal a_sData As DataTable, ByVal a_sFileTitle As String, ByRef a_sErrorMessage As String) As Boolean
            a_sErrorMessage = String.Empty
            Dim bRetVal As Boolean = False
            ' Dim dsDataSet As DataSet = Nothing
            Try
                'dsDataSet = a_sData

                Dim xlObject As Microsoft.Office.Interop.Excel.Application = Nothing
                Dim xlWB As Microsoft.Office.Interop.Excel.Workbook = Nothing
                Dim xlSh As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                Dim rg As Microsoft.Office.Interop.Excel.Range = Nothing
                Try
                    xlObject = New Microsoft.Office.Interop.Excel.Application()
                    xlObject.AlertBeforeOverwriting = False
                    xlObject.DisplayAlerts = False

                    ' This Adds a new woorkbook, you could open the workbook from file also '
                    xlWB = xlObject.Workbooks.Add(Type.Missing)
                    xlWB.SaveAs(a_sFilename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, _
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value)

                    xlSh = DirectCast(xlObject.ActiveWorkbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)

                    Dim sUpperRange As String = "A1"
                    Dim sLastCol As String = "E"
                    Dim sLowerRange As String = sLastCol + (a_sData.Rows.Count + 1).ToString()

                    rg = xlSh.Range(sUpperRange, sLowerRange)
                    rg.Value2 = GetData(a_sData)

                    ' formating '
                    'xlSh.Range("A1", sLastCol & "1").Font.Bold = True
                    'xlSh.Range("A1", sLastCol & "1").HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'xlSh.Range(sUpperRange, sLowerRange).EntireColumn.AutoFit()

                    If String.IsNullOrEmpty(a_sFileTitle) Then
                        xlObject.Caption = "untitled"
                    Else
                        xlObject.Caption = a_sFileTitle
                    End If

                    xlWB.Save()
                    bRetVal = True
                Catch ex As System.Runtime.InteropServices.COMException
                    If ex.ErrorCode = -2147221164 Then
                        a_sErrorMessage = "Error in export: Please install Microsoft Office (Excel) to use the Export to Excel feature."
                    ElseIf ex.ErrorCode = -2146827284 Then
                        a_sErrorMessage = "Error in export: Excel allows only 65,536 maximum rows in a sheet."
                    Else
                        a_sErrorMessage = (("Error in export: " & ex.Message) + Environment.NewLine & " Error: ") + ex.ErrorCode
                    End If
                Catch ex As Exception
                    a_sErrorMessage = "Error in export: " & ex.Message
                Finally
                    Try
                        If xlWB IsNot Nothing Then
                            xlWB.Close(Nothing, Nothing, Nothing)
                        End If
                        xlObject.Workbooks.Close()
                        xlObject.Quit()
                        If rg IsNot Nothing Then
                            Marshal.ReleaseComObject(rg)
                        End If
                        If xlSh IsNot Nothing Then
                            Marshal.ReleaseComObject(xlSh)
                        End If
                        If xlWB IsNot Nothing Then
                            Marshal.ReleaseComObject(xlWB)
                        End If
                        If xlObject IsNot Nothing Then
                            Marshal.ReleaseComObject(xlObject)
                        End If
                    Catch
                    End Try
                    xlSh = Nothing
                    xlWB = Nothing
                    xlObject = Nothing
                    ' force final cleanup! '
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                End Try
            Catch ex As Exception
                a_sErrorMessage = "Error in export: " & ex.Message
            End Try
            Return bRetVal
        End Function

        'returns data as two dimentional object array.
        Private Function GetData(ByVal a_dtData As System.Data.DataTable) As Object(,)
            Dim obj As Object(,) = New Object((a_dtData.Rows.Count + 1) - 1, a_dtData.Columns.Count - 1) {}

            Try
                For j As Integer = 0 To a_dtData.Columns.Count - 1
                    obj(0, j) = a_dtData.Columns(j).Caption
                Next

                Dim dt As New DateTime()
                Dim sTmpStr As String = String.Empty

                For i As Integer = 1 To a_dtData.Rows.Count
                    For j As Integer = 0 To a_dtData.Columns.Count - 1
                        If a_dtData.Columns(j).DataType Is dt.[GetType]() Then
                            If a_dtData.Rows(i - 1)(j) IsNot DBNull.Value Then
                                DateTime.TryParse(a_dtData.Rows(i - 1)(j).ToString(), dt)
                                obj(i, j) = dt.ToString("MM/dd/yy hh:mm tt")
                            Else
                                obj(i, j) = a_dtData.Rows(i - 1)(j)
                            End If
                        ElseIf a_dtData.Columns(j).DataType Is sTmpStr.[GetType]() Then
                            If a_dtData.Rows(i - 1)(j) IsNot DBNull.Value Then
                                sTmpStr = a_dtData.Rows(i - 1)(j).ToString().Replace(vbCr, "")
                                obj(i, j) = sTmpStr
                            Else
                                obj(i, j) = a_dtData.Rows(i - 1)(j)
                            End If
                        Else
                            obj(i, j) = a_dtData.Rows(i - 1)(j)
                        End If

                    Next
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Return obj
        End Function

    End Class


End Module
