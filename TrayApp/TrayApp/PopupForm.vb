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
Imports System.Xml
Imports System.Data
Imports System.IO
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports ExcelLibrary.SpreadSheet



Public Class PopupForm
    Dim varSelectedYear As Integer
    Dim varSelectedMonth As Integer
    Dim varSelectedday As Integer
    Dim varSelectedDate As Date

    Public Sub New()
        InitializeComponent()
        Icon = My.Resources.TrayIcon
        Me.SuspendLayout()

        VerticalSplitContainer.SuspendLayout()
        VerticalSplitContainer.BorderStyle = BorderStyle.Fixed3D
        ' The vertical splitter moves in 10 pixel increments
        VerticalSplitContainer.SplitterIncrement = 10

        ' Create a horizontally aligned SplitContainer.
        Dim HorizontalSplitContainer As New System.Windows.Forms.SplitContainer()
        HorizontalSplitContainer.Name = "HorizontalSplitContainer"
        HorizontalSplitContainer.Orientation = Orientation.Horizontal
        HorizontalSplitContainer.SuspendLayout()
        HorizontalSplitContainer.BorderStyle = BorderStyle.FixedSingle
        HorizontalSplitContainer.SplitterWidth = 6

        ' The VerticalSplitContainer fills the form.
        VerticalSplitContainer.Dock = DockStyle.Fill

        ' TreeView fills the left panel of VerticalSplitContainer.
        VerticalSplitContainer.Panel1.Controls.Add(ClosePanel)
        ClosePanel.Dock = DockStyle.Fill

        ' Require a minimum size of 100 pixels for the width of the left panel.
        VerticalSplitContainer.Panel1MinSize = 75
        ' HorizontalSplitContainer fills the right panel of VerticalSplitContainer.
        VerticalSplitContainer.Panel2.Controls.Add(HorizontalSplitContainer)
        HorizontalSplitContainer.Dock = DockStyle.Fill

        'Provide a graphical backdrop on the top panel of the HorizontalSplitContainer.        
        HorizontalSplitContainer.Panel1.BackgroundImageLayout = ImageLayout.Tile
        HorizontalSplitContainer.Panel1.Margin = New System.Windows.Forms.Padding(25)
        HorizontalSplitContainer.Panel1MinSize = 50

        ' The top panel should not resize during form resizing.
        HorizontalSplitContainer.FixedPanel = FixedPanel.Panel1

        'details fill the lower panel of HorizontalSplitContainer.
        HorizontalSplitContainer.Panel1.Controls.Add(PanelENTRY)
        PanelENTRY.Dock = DockStyle.Fill

        HorizontalSplitContainer.Panel2.Controls.Add(PanelSHOW)
        PanelSHOW.Dock = DockStyle.Fill
        grdTask.Dock = DockStyle.Fill

        ' Add the VerticalSplitContainer to the form.
        Me.Controls.Add(VerticalSplitContainer)

        ' Turn on layout.

        VerticalSplitContainer.ResumeLayout()
        HorizontalSplitContainer.ResumeLayout()
        Me.ResumeLayout()

        ' Set the initial size of the panels.
        VerticalSplitContainer.SplitterDistance = 150
        HorizontalSplitContainer.SplitterDistance = 125

        Dim tt As New ToolTip()
        tt.SetToolTip(PictureBox2, "refresh " & gblUser)
        tt.SetToolTip(PictureBox1, "Logout " & gblUser)
        tt.SetToolTip(PictureBox3, "Export to XLS ")

        Dim thisDate1 As Date = Date.Today
        lblDate.Text = thisDate1.ToString("MMMM dd, yyyy") + "."
        txtdate.Text = thisDate1.ToString("MMMM dd, yyyy") + "."
        varSelectedday = thisDate1.Day
        varSelectedMonth = thisDate1.Month
        varSelectedYear = thisDate1.Year

        MonthCalendar1.SetDate(New Date(varSelectedYear, varSelectedMonth, varSelectedday))

        Call RecordView()
    End Sub
    Private Sub RecordView()
        Try
            cmbType.SelectedIndex = 0
            Me.Text = "T A S K  S H E E T "
            lblUser.Text = gblUser.ToUpper.ToUpper

            gblDT = CreatDataTable()
            'Call grid_setting()


            Dim objnodelist As XmlNodeList
            Dim objDR As DataRow
            Dim objNode As XmlNode

            objXmldocs = ShowResult()
            'DATE,TASKDESCRIPTION,TYPE,ID,WORKINGHR
            If objXmldocs.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE" Then
                lblCountTOTAL.Text = "Total Count : " & objXmldocs.DocumentElement.SelectSingleNode("Count").Attributes("Total").InnerText
                lblCountCR.Text = "Count CR : " & objXmldocs.DocumentElement.SelectSingleNode("Count").Attributes("CR").InnerText
                lblCountPR.Text = "Count PR : " & objXmldocs.DocumentElement.SelectSingleNode("Count").Attributes("PR").InnerText
                lblCountGR.Text = "Count GR : " & objXmldocs.DocumentElement.SelectSingleNode("Count").Attributes("GR").InnerText

                lbltotalhr.Text = "Total : " & objXmldocs.DocumentElement.SelectSingleNode("Hr").Attributes("Total").InnerText
                lblCRhr.Text = "Total CR  : " & objXmldocs.DocumentElement.SelectSingleNode("Hr").Attributes("CR").InnerText
                lblprhr.Text = "Total PR  : " & objXmldocs.DocumentElement.SelectSingleNode("Hr").Attributes("PR").InnerText
                lblgrhr.Text = "Total GR  : " & objXmldocs.DocumentElement.SelectSingleNode("Hr").Attributes("GR").InnerText
                lblmnthlyhr.Text = "Monthly total : " & objXmldocs.DocumentElement.SelectSingleNode("Hr").Attributes("TOTALMONTHLYHR").InnerText

                objnodelist = objXmldocs.SelectNodes("TEAMTASK/Details")
                For Each objNode In objnodelist
                    objDR = gblDT.NewRow
                    objDR("Rowid") = objNode.Attributes("ROWID").InnerText
                    objDR("Date") = objNode.Attributes("DATE").InnerText
                    objDR("TaskDescription") = objNode.Attributes("TASKDESCRIPTION").InnerText
                    objDR("Type") = objNode.Attributes("TYPE").InnerText
                    objDR("Id") = objNode.Attributes("ID").InnerText
                    objDR("Wrk hour") = objNode.Attributes("WORKINGHR").InnerText
                    gblDT.Rows.Add(objDR)
                Next
                gblDT.AcceptChanges()
                gblDT.DefaultView.Sort = "DATE"
            End If

            If gblDT.Rows.Count >= 1 Then
                grdTask.Visible = True
                grdTask.DataSource = gblDT.DefaultView
                'grdTask.Columns(2).Width = 600
                grid_setting()
            Else
                grdTask.Visible = True
                grdTask.DataSource = Nothing
                btnAdd.Text = "Add"
            End If
        Catch ex As Exception
            MsgBox("Error while retriving records from database", MsgBoxStyle.Information)
        End Try
    End Sub
    Private Sub CloseAppButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles CloseAppButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Me.Close()
        End
    End Sub
    Private Sub grid_setting()
        Try
            Me.grdTask.Columns(0).Width = 0     'ROWID
            Me.grdTask.Columns(1).Width = 100     'DATE
            Me.grdTask.Columns(2).Width = 600    'TASKDESCRIPTION
            Me.grdTask.Columns(3).Width = 100    'TYPE
            Me.grdTask.Columns(4).Width = 100     'ID
            Me.grdTask.Columns(5).Width = 100     'WORKINGHR
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("PopupForm", "grid_setting", exc.GetBaseException)
        End Try
    End Sub

    Private Sub grdTask_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTask.CellClick
        Try
            If e.RowIndex <> -1 Then
                gblRowId = grdTask.Rows(e.RowIndex).Cells(0).Value
                gblSelectedDate = ConvertTextDate((CDate(grdTask.Rows(e.RowIndex).Cells(1).Value)).ToString("dd/MM/yyyy"))
                txtdate.Text = CDate(grdTask.Rows(e.RowIndex).Cells(1).Value).ToString("MMMM dd, yyyy")
                varSelectedDate = CDate(grdTask.Rows(e.RowIndex).Cells(1).Value).ToString("MMMM dd, yyyy")
                varSelectedday = varSelectedDate.Day
                varSelectedMonth = varSelectedDate.Month
                varSelectedYear = varSelectedDate.Year
                MonthCalendar1.SetDate(New Date(varSelectedYear, varSelectedMonth, varSelectedday))


                cmbType.Text = grdTask.Rows(e.RowIndex).Cells(3).Value
                txtID.Text = grdTask.Rows(e.RowIndex).Cells(4).Value
                txtDesc.Text = grdTask.Rows(e.RowIndex).Cells(2).Value
                txtWrhr.Text = grdTask.Rows(e.RowIndex).Cells(5).Value
                btnAdd.Text = "Update"
            End If
        Catch ex As Exception
            MsgBox("Error", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub grdTask_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTask.CellEnter
        Try
            If e.RowIndex <> -1 Then
                gblRowId = grdTask.Rows(e.RowIndex).Cells(0).Value
                gblSelectedDate = ConvertTextDate((CDate(grdTask.Rows(e.RowIndex).Cells(1).Value)).ToString("dd/MM/yyyy"))
                txtdate.Text = CDate(grdTask.Rows(e.RowIndex).Cells(1).Value).ToString("MMMM dd, yyyy")

                varSelectedDate = CDate(grdTask.Rows(e.RowIndex).Cells(1).Value).ToString("MMMM dd, yyyy")
                varSelectedday = varSelectedDate.Day
                varSelectedMonth = varSelectedDate.Month
                varSelectedYear = varSelectedDate.Year
                MonthCalendar1.SetDate(New Date(varSelectedYear, varSelectedMonth, varSelectedday))

                cmbType.Text = grdTask.Rows(e.RowIndex).Cells(3).Value
                txtID.Text = grdTask.Rows(e.RowIndex).Cells(4).Value
                txtDesc.Text = grdTask.Rows(e.RowIndex).Cells(2).Value
                txtWrhr.Text = grdTask.Rows(e.RowIndex).Cells(5).Value
                btnAdd.Text = "Update"
            End If
        Catch ex As Exception
            MsgBox("Error", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim strInputXml As New XmlDocument
        Dim strOutputXml As New XmlDocument

        Dim intDate As Integer = 0
        Dim strLoginName As String = gblUser.ToString
        If txtDesc.Text.Trim.ToString() = "" Then
            MsgBox("Please enter description ", MsgBoxStyle.Critical, "Task Sheet Entry System")
            Exit Sub
        End If
        If cmbType.Text = "Select one" Then
            MsgBox("Please select type ", MsgBoxStyle.Critical, "Task Sheet Entry System")
            cmbType.Focus()
            Exit Sub
        End If
        If txtWrhr.Text = "" Then
            MsgBox("Please enter working Hr ", MsgBoxStyle.Critical, "Task Sheet Entry System")
            txtWrhr.Focus()
            Exit Sub
        End If
        If txtdate.Text = "" Then
            MsgBox("Please select date ", MsgBoxStyle.Critical, "Task Sheet Entry System")
            txtdate.Focus()
            Exit Sub
        End If
        Dim numericCheck As Boolean
        numericCheck = IsNumeric(txtID.Text)
        If numericCheck = 0 Then
            MsgBox("Please enter valid id ", MsgBoxStyle.Critical, "Task Sheet Entry System")
            txtID.Focus()
            Exit Sub
        End If

        numericCheck = IsNumeric(txtWrhr.Text)
        If numericCheck = 0 Then
            MsgBox("Please enter valid working hr.", MsgBoxStyle.Critical, "Task Sheet Entry System")
            txtWrhr.Focus()
            Exit Sub
        End If

        strInputXml.LoadXml("<UP_UPDATE_TEAMTASK_INPUT><Details  ROWID='' LOGINNAME=''  DATE='' TASKDESCRIPTION='' TYPE='' ID='' WORKINGHR='' /></UP_UPDATE_TEAMTASK_INPUT>")
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("ROWID").InnerText = gblRowId
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("LOGINNAME").InnerText = strLoginName.ToString()
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("DATE").InnerText = ConvertTextDate((CDate(txtdate.Text)).ToString("dd/MM/yyyy"))
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("TASKDESCRIPTION").InnerText = txtDesc.Text.ToString()
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("TYPE").InnerText = cmbType.Text.ToString()
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("ID").InnerText = txtID.Text.ToString()
        strInputXml.DocumentElement.SelectSingleNode("Details").Attributes("WORKINGHR").InnerText = txtWrhr.Text.ToString()

        strOutputXml = UpdateTask(strInputXml)


        If strOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE" Then
            MsgBox("record added successfully !", MsgBoxStyle.Information, "Task Sheet Entry System")
        End If

        Call refreshControl()
        Call RecordView()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        refreshControl()
        btnAdd.Text = "Add"
        Dim thisDate1 As Date = Date.Today
        txtdate.Text = thisDate1.ToString("MMMM dd, yyyy") + "."
    End Sub
    Private Sub refreshControl()
        cmbType.SelectedIndex = -1
        txtDesc.Text = ""
        txtID.Text = ""
        txtWrhr.Text = ""
        gblSelectedDate = 0
        gblRowId = 0
        txtdate.Text = ""

        lblCountTOTAL.Text = "Total Count : ?"
        lblCountCR.Text = "Count CR : ?"
        lblCountPR.Text = "Count PR : ?"
        lblCountGR.Text = "Count GR : ?"

        lbltotalhr.Text = "Total : ?"
        lblCRhr.Text = "Total CR  : ?"
        lblprhr.Text = "Total PR  : ?"
        lblgrhr.Text = "Total GR  : ?"
        lblmnthlyhr.Text = "Monthly total : ?"

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim strDel As String = "Are you sure want to delete this record ? "
        Dim intAns As Integer
        intAns = MsgBox(strDel, MsgBoxStyle.YesNo, "Task Sheet Entry System")
        If intAns = 6 Then
            MsgBox("permission denied pls contact to Neeraj/tapan", MsgBoxStyle.Critical, "Task Sheet Entry System")
        End If
    End Sub

    Private Sub btnReferesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferesh.Click
        Call RecordView()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Me.Close()
        End
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim dtTemp As DataTable = New DataTable()
        'dtTemp = CType(grdTask.DataSource, DataTable)
        dtTemp = gblDT '.DefaultView.Sort = "DATE"

        Try
            'dtTemp.Columns.Remove(dtTemp.Columns(0))
        Catch ex As Exception
        End Try

        dtTemp.DefaultView.Sort = "DATE"

        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Excel File|*.xls"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            Try

                wBook = excel.Workbooks.Add()
                wSheet = wBook.ActiveSheet()

                Dim dt As System.Data.DataTable = dtTemp
                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    excel.Cells(1, colIndex) = dc.ColumnName
                Next

                For Each dr In dt.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In dt.Columns
                        colIndex = colIndex + 1
                        excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
                Dim strFileName As String = saveFileDialog1.FileName
                wBook.SaveAs(strFileName)
                'wBook.Close()
                'excel.Quit()
                'releaseObject(excel)
                'releaseObject(wBook)
                'releaseObject(wSheet)

                MsgBox("Sucessfully saved : " + strFileName)

            Catch ex As Exception

                MsgBox(ex.Message)
                Exit Sub

            Finally
                wBook.Close()
                excel.Quit()
                releaseObject(excel)
                releaseObject(wBook)
                releaseObject(wSheet)
            End Try
        End If
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Call RecordView()
    End Sub

    'Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
    '    Dim dtTemp As DataTable = New DataTable()
    '    'dtTemp = CType(grdTask.DataSource, DataTable)
    '    dtTemp = gblDT '.DefaultView.Sort = "DATE"

    '    Try
    '        'dtTemp.Columns.Remove(dtTemp.Columns(0))
    '    Catch ex As Exception
    '    End Try

    '    dtTemp.DefaultView.Sort = "DATE"

    '    Dim saveFileDialog1 As New SaveFileDialog()
    '    saveFileDialog1.Filter = "Excel File|*.xls"
    '    saveFileDialog1.Title = "Save an Excel File"
    '    saveFileDialog1.ShowDialog()

    '    If saveFileDialog1.FileName <> "" Then
    '        Dim strFileName As String = saveFileDialog1.FileName
    '        Dim OExcelHandler As New ExcelHandler()
    '        Dim blnExport As Boolean = OExcelHandler.ExportToExcel(strFileName, dtTemp, "Task Sheet", "Error exporting to Excel")
    '        MsgBox("Sucessfully saved : " + strFileName)
    '    End If


    '    'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
    '    'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
    '    'Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

    '    'Dim saveFileDialog1 As New SaveFileDialog()
    '    'saveFileDialog1.Filter = "Excel File|*.xls"
    '    'saveFileDialog1.Title = "Save an Excel File"
    '    'saveFileDialog1.ShowDialog()

    '    '' If the file name is not an empty string open it for saving.
    '    'If saveFileDialog1.FileName <> "" Then
    '    '    Try

    '    '        wBook = excel.Workbooks.Add()
    '    '        wSheet = wBook.ActiveSheet()

    '    '        Dim dt As System.Data.DataTable = dtTemp
    '    '        Dim dc As System.Data.DataColumn
    '    '        Dim dr As System.Data.DataRow
    '    '        Dim colIndex As Integer = 0
    '    '        Dim rowIndex As Integer = 0

    '    '        For Each dc In dt.Columns
    '    '            colIndex = colIndex + 1
    '    '            excel.Cells(1, colIndex) = dc.ColumnName
    '    '        Next

    '    '        For Each dr In dt.Rows
    '    '            rowIndex = rowIndex + 1
    '    '            colIndex = 0
    '    '            For Each dc In dt.Columns
    '    '                colIndex = colIndex + 1
    '    '                excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
    '    '            Next
    '    '        Next
    '    '        Dim strFileName As String = saveFileDialog1.FileName
    '    '        wBook.SaveAs(strFileName)
    '    '        'wBook.Close()
    '    '        'excel.Quit()
    '    '        'releaseObject(excel)
    '    '        'releaseObject(wBook)
    '    '        'releaseObject(wSheet)

    '    '        MsgBox("Sucessfully saved : " + strFileName)

    '    '    Catch ex As Exception

    '    '        MsgBox(ex.Message)
    '    '        Exit Sub

    '    '    Finally
    '    '        wBook.Close()
    '    '        excel.Quit()
    '    '        releaseObject(excel)
    '    '        releaseObject(wBook)
    '    '        releaseObject(wSheet)
    '    '    End Try
    '    'End If
    'End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged

        txtdate.Text = CDate(MonthCalendar1.SelectionStart.ToShortDateString()).ToString("MMMM dd, yyyy")
        gblResultDate = CDate(MonthCalendar1.SelectionStart.ToShortDateString()).ToString("yyyyMMdd")

    End Sub
   
    Private Sub grdTask_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTask.CellDoubleClick
        Dim strDel As String = "Are you sure want to delete this record ? "
        Dim intAns As Integer
        Dim strInputXml As New XmlDocument
        Dim strOutputXml As New XmlDocument
        Dim strLoginName As String = gblUser.ToString
        intAns = MsgBox(strDel, MsgBoxStyle.YesNo, "Task Sheet Entry System")
        If intAns = 6 Then
            Try
                If e.RowIndex <> -1 Then
                    gblRowId = grdTask.Rows(e.RowIndex).Cells(0).Value
                    strInputXml.LoadXml("<TEAMTASK_DELETE_INPUT><Rowid></Rowid><LOGINNAME></LOGINNAME></TEAMTASK_DELETE_INPUT>")
                    strInputXml.DocumentElement.SelectSingleNode("Rowid").InnerText = gblRowId
                    strInputXml.DocumentElement.SelectSingleNode("LOGINNAME").InnerText = gblUser

                    strOutputXml = Delete(strInputXml)

                    If strOutputXml.DocumentElement.SelectSingleNode("Errors").Attributes("Status").InnerText = "FALSE" Then
                        MsgBox("record successfully deleted !", MsgBoxStyle.Information, "Task Sheet Entry System")
                    End If
                    Call refreshControl()
                    Call RecordView()
                End If
            Catch ex As Exception
                MsgBox("Error", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim objExport As New ExportExcel
        Dim objOutputXml As New XmlDocument
        Dim ds As DataSet

        '---------------------
        Dim dtTemp As DataTable = New DataTable()
        dtTemp = gblDT
        Try
            'dtTemp.Columns.Remove(dtTemp.Columns(0))
        Catch ex As Exception
        End Try

        dtTemp.DefaultView.Sort = "DATE"

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Excel File|*.xls"
        saveFileDialog1.Title = "Save an Excel File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            Dim strFilePath As String = saveFileDialog1.FileName
            Dim strFileName As String = ExtractFilename(strFilePath)
            strFilePath = strFilePath.Replace(strFileName, "")

            Dim strArray() As String = {"ROWID", "DATE", "TASKDESCRIPTION", "TYPE", "ID", "WORKINGHR"}
            Dim intArray() As Integer = {0, 1, 2, 3, 4, 5}
            objExport.ExportDetails(objXmldocs, "Details", intArray, strArray, ExportExcel.ExportFormat.Excel, strFileName, strFilePath)
            MsgBox("Task Sheet exported to : " + strFilePath + "/" + strFileName, MsgBoxStyle.Information, "Task Sheet Entry System")
        End If
        '---------------------
    End Sub
    Public Function ExtractFilename(ByVal filepath As String) As String
        ' If path ends with a "\", it's a path only so return String.Empty. 
        If filepath.Trim().EndsWith("\") Then Return String.Empty

        ' Determine where last backslash is. 
        Dim position As Integer = filepath.LastIndexOf("\"c)
        ' If there is no backslash, assume that this is a filename. 
        If position = -1 Then
            ' Determine whether file exists in the current directory. 
            If File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filepath) Then
                Return filepath
            Else
                Return String.Empty
            End If
        Else
            ' Determine whether file exists using filepath. 
            If File.Exists(filepath) Then
                ' Return filename without file path. 
                Return filepath.Substring(position + 1)
            Else
                'Return String.Empty
                Return filepath.Substring(position + 1)
            End If
        End If
    End Function

End Class