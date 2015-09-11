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

Friend Module OtherMethods

    Private PF As PopupForm
    Private Login As frmLogin

    Public Sub ExitApplication()
        'Perform any clean-up here
        'Then exit the application
        Application.Exit()
    End Sub

    Public Sub ShowDialog()
        'If PF IsNot Nothing AndAlso Not PF.IsDisposed Then Exit Sub
        If Login IsNot Nothing AndAlso Not Login.IsDisposed Then Exit Sub
        Dim CloseApp As Boolean = False

        'PF = New PopupForm
        'PF.ShowDialog()
        'CloseApp = (PF.DialogResult = DialogResult.Abort)
        'PF = Nothing

        Login = New frmLogin
        Login.ShowDialog()
        CloseApp = (Login.DialogResult = DialogResult.Abort)
        Login = Nothing
        If CloseApp Then Application.Exit()
    End Sub

End Module
