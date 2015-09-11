'Copyright notice: ã 2004 by Bird Information Systems Pvt. Ltd. All rights reserved.
'********************************************************************************************
' This file contains trade secrets of Bird Information Systems. No part
' may be reproduced or transmitted in any form by any means or for any purpose
' without the express written permission of Bird Information Systems.
'********************************************************************************************
'$Author: Tapan $Logfile: /AAMS/Interface/ADMS/frmLogin.vb $
'$Workfile: frmLogin.vb $
'$Revision: 14 $
'$Archive: /AAMS/Interface/ADMS/frmLogin.vb $
'$Modtime: 22/02/12 3:38p $
Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports AAMS.bizShared
Imports System.Security


Public Class frmLogin
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strArrUsers() As String
        Try
            lblStatus.Text = String.Empty
            cmbUser.Focus()
            strArrUsers = GetUserList()

            If strArrUsers.Length <> 0 Then
                cmbUser.Items.AddRange(strArrUsers)
                cmbUser.SelectedIndex = 0
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "frmLogin_Load", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Dim mAns As Int16 = MsgBox("                do you want to exit ? ", MsgBoxStyle.OkCancel, "Amadeus Management Document System")
            If (mAns) = 1 Then
                Me.Close()
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "btnCancel_Click", exc.GetBaseException)
        End Try
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim objInputXml, objOutputXml As New XmlDocument
        Dim objEmployee As New AAMS.bizMaster.bzEmployee
        Dim cmd As New SqlCommand
        Dim objSqlConnection As New SqlConnection(bzShared.GetConnectionString())  ''connection string from AAMS
        'Dim objSqlConnectionLive As New SqlConnection(bzShared.GetDOCConnectionString)

        Dim mhostname As String = Dns.GetHostName()
        Dim strPermisionUserFromConfig As String
        Dim strArrUsers() As String
        Dim strGetUserNameFromConfig As String

        Dim count As Integer
        Dim blnAllowConfigUser As Boolean
        blnAllowConfigUser = False
        strPdfFolderName = ""

        Try
            If cmbUser.Text = "Select one" Then
                lblStatus.Text = "Please select user....."
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            lblStatus.Text = "Authenticating the user....."
            Dim mIpaddress As String = CType(Dns.GetHostByName(mhostname).AddressList.GetValue(0), IPAddress).ToString


            If Trim(cmbUser.Text) = "" Then
                MsgBox("Username is mandatory", MsgBoxStyle.Information)
                cmbUser.Focus()
                Exit Sub
            End If
            If Trim(txtPassword.Text) = "" Then
                MsgBox("Password is mandatory", MsgBoxStyle.Information)
                txtPassword.Focus()
                Exit Sub
            End If


            '############## THIS FOR ORDERING MODULE ####################################
            '##############  GET USE NAME FROM CONFIG FILE ####################################
            cmd.CommandText = "UP_GET_USERNAMEFORTASKSHEET"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = objSqlConnection
            objSqlConnection.Open()
            strGetUserNameFromConfig = cmd.ExecuteScalar()


            strPermisionUserFromConfig = strGetUserNameFromConfig
            strArrUsers = strPermisionUserFromConfig.Split(",")
            For count = 0 To strArrUsers.Length - 1
                'MsgBox(strArr(count))
                If UCase(cmbUser.Text) = UCase(strArrUsers(count)) Then
                    blnAllowConfigUser = True
                    objSqlConnection.Close()
                    Exit For
                End If
            Next

            If blnAllowConfigUser = False Then
                'MsgBox("Invalid User", MsgBoxStyle.Information, "ADMS")
                lblStatus.Text = "Access Permission Denied"
                objSqlConnection.Close()
                cmbUser.Focus()
                Exit Sub
            End If

            Dim thisDate1 As Date = Date.Today

            If blnAllowConfigUser = True Then
                Me.Hide()
                Me.Cursor = Cursors.WaitCursor
                gblUser = cmbUser.Text
                gblCurrentDate = ConvertTextDate(thisDate1.ToString("dd/MM/yyyy"))

                PopupForm.Show()
            Else
                lblStatus.Text = "Access Permission Denied"
            End If

        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "btnOk_Click", exc.GetBaseException)
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    'Private Sub txtUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If (e.KeyCode) = 13 Then
    '            Call btnOk_Click(sender, e)
    '        End If
    '    Catch exc As Exception
    '        MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
    '        Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "txtUsername_KeyDown", exc.GetBaseException)
    '    End Try
    'End Sub
    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        Try
            If (e.KeyCode) = 13 Then
                Call btnOk_Click(sender, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "txtUsername_KeyDown", exc.GetBaseException)
        End Try
    End Sub

    Private Sub cmbUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbUser.KeyDown
        Try
            If (e.KeyCode) = 13 Then
                Call btnOk_Click(sender, e)
            End If
        Catch exc As Exception
            MsgBox(exc.Message, MsgBoxStyle.Information, Application.ProductName)
            Call AAMS.bizShared.bzShared.LogWrite("frmLogin", "txtUsername_KeyDown", exc.GetBaseException)
        End Try
    End Sub
End Class