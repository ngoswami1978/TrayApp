<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CloseAppButton = New System.Windows.Forms.Button
        Me.ClosePanel = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblmnthlyhr = New System.Windows.Forms.Label
        Me.lblCRhr = New System.Windows.Forms.Label
        Me.lblprhr = New System.Windows.Forms.Label
        Me.lblgrhr = New System.Windows.Forms.Label
        Me.lbltotalhr = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblCountCR = New System.Windows.Forms.Label
        Me.lblCountPR = New System.Windows.Forms.Label
        Me.lblCountGR = New System.Windows.Forms.Label
        Me.lblCountTOTAL = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnReferesh = New System.Windows.Forms.Button
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.VerticalSplitContainer = New System.Windows.Forms.SplitContainer
        Me.PanelENTRY = New System.Windows.Forms.Panel
        Me.txtdate = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.txtWrhr = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelSHOW = New System.Windows.Forms.Panel
        Me.grdTask = New System.Windows.Forms.DataGridView
        Me.ClosePanel.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VerticalSplitContainer.SuspendLayout()
        Me.PanelENTRY.SuspendLayout()
        Me.PanelSHOW.SuspendLayout()
        CType(Me.grdTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CloseAppButton
        '
        Me.CloseAppButton.Location = New System.Drawing.Point(3, 628)
        Me.CloseAppButton.Name = "CloseAppButton"
        Me.CloseAppButton.Size = New System.Drawing.Size(68, 23)
        Me.CloseAppButton.TabIndex = 8
        Me.CloseAppButton.Text = "LogOut me"
        Me.CloseAppButton.UseVisualStyleBackColor = True
        Me.CloseAppButton.Visible = False
        '
        'ClosePanel
        '
        Me.ClosePanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClosePanel.BackColor = System.Drawing.SystemColors.ControlText
        Me.ClosePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ClosePanel.Controls.Add(Me.Label6)
        Me.ClosePanel.Controls.Add(Me.GroupBox3)
        Me.ClosePanel.Controls.Add(Me.GroupBox1)
        Me.ClosePanel.Controls.Add(Me.GroupBox2)
        Me.ClosePanel.Controls.Add(Me.PictureBox1)
        Me.ClosePanel.Controls.Add(Me.btnSave)
        Me.ClosePanel.Controls.Add(Me.btnReferesh)
        Me.ClosePanel.Controls.Add(Me.lblDate)
        Me.ClosePanel.Controls.Add(Me.lblUser)
        Me.ClosePanel.Controls.Add(Me.CloseAppButton)
        Me.ClosePanel.Location = New System.Drawing.Point(973, 4)
        Me.ClosePanel.Name = "ClosePanel"
        Me.ClosePanel.Size = New System.Drawing.Size(142, 656)
        Me.ClosePanel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(25, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "LogOut"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblmnthlyhr)
        Me.GroupBox3.Controls.Add(Me.lblCRhr)
        Me.GroupBox3.Controls.Add(Me.lblprhr)
        Me.GroupBox3.Controls.Add(Me.lblgrhr)
        Me.GroupBox3.Controls.Add(Me.lbltotalhr)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Location = New System.Drawing.Point(4, 225)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(132, 144)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hours"
        '
        'lblmnthlyhr
        '
        Me.lblmnthlyhr.AutoSize = True
        Me.lblmnthlyhr.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmnthlyhr.ForeColor = System.Drawing.Color.Red
        Me.lblmnthlyhr.Location = New System.Drawing.Point(6, 116)
        Me.lblmnthlyhr.Name = "lblmnthlyhr"
        Me.lblmnthlyhr.Size = New System.Drawing.Size(115, 19)
        Me.lblmnthlyhr.TabIndex = 8
        Me.lblmnthlyhr.Text = "Monthly total : ?"
        '
        'lblCRhr
        '
        Me.lblCRhr.AutoSize = True
        Me.lblCRhr.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCRhr.ForeColor = System.Drawing.Color.Red
        Me.lblCRhr.Location = New System.Drawing.Point(6, 16)
        Me.lblCRhr.Name = "lblCRhr"
        Me.lblCRhr.Size = New System.Drawing.Size(87, 19)
        Me.lblCRhr.TabIndex = 4
        Me.lblCRhr.Text = "Total CR  : ?"
        '
        'lblprhr
        '
        Me.lblprhr.AutoSize = True
        Me.lblprhr.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprhr.ForeColor = System.Drawing.Color.Red
        Me.lblprhr.Location = New System.Drawing.Point(6, 41)
        Me.lblprhr.Name = "lblprhr"
        Me.lblprhr.Size = New System.Drawing.Size(86, 19)
        Me.lblprhr.TabIndex = 5
        Me.lblprhr.Text = "Total PR  : ?"
        '
        'lblgrhr
        '
        Me.lblgrhr.AutoSize = True
        Me.lblgrhr.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgrhr.ForeColor = System.Drawing.Color.Red
        Me.lblgrhr.Location = New System.Drawing.Point(6, 66)
        Me.lblgrhr.Name = "lblgrhr"
        Me.lblgrhr.Size = New System.Drawing.Size(88, 19)
        Me.lblgrhr.TabIndex = 6
        Me.lblgrhr.Text = "Total GR  : ?"
        '
        'lbltotalhr
        '
        Me.lbltotalhr.AutoSize = True
        Me.lbltotalhr.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalhr.ForeColor = System.Drawing.Color.Red
        Me.lbltotalhr.Location = New System.Drawing.Point(6, 91)
        Me.lbltotalhr.Name = "lbltotalhr"
        Me.lbltotalhr.Size = New System.Drawing.Size(61, 19)
        Me.lbltotalhr.TabIndex = 7
        Me.lbltotalhr.Text = "Total : ?"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(4, 373)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(67, 49)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = Global.AAMS.My.Resources.Resources.SaveExcel
        Me.PictureBox3.Location = New System.Drawing.Point(36, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.AAMS.My.Resources.Resources.refresh2
        Me.PictureBox2.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCountCR)
        Me.GroupBox2.Controls.Add(Me.lblCountPR)
        Me.GroupBox2.Controls.Add(Me.lblCountGR)
        Me.GroupBox2.Controls.Add(Me.lblCountTOTAL)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(4, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(132, 125)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Counting"
        '
        'lblCountCR
        '
        Me.lblCountCR.AutoSize = True
        Me.lblCountCR.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountCR.ForeColor = System.Drawing.Color.Red
        Me.lblCountCR.Location = New System.Drawing.Point(6, 16)
        Me.lblCountCR.Name = "lblCountCR"
        Me.lblCountCR.Size = New System.Drawing.Size(92, 19)
        Me.lblCountCR.TabIndex = 4
        Me.lblCountCR.Text = "Count CR  : ?"
        '
        'lblCountPR
        '
        Me.lblCountPR.AutoSize = True
        Me.lblCountPR.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountPR.ForeColor = System.Drawing.Color.Red
        Me.lblCountPR.Location = New System.Drawing.Point(6, 41)
        Me.lblCountPR.Name = "lblCountPR"
        Me.lblCountPR.Size = New System.Drawing.Size(91, 19)
        Me.lblCountPR.TabIndex = 5
        Me.lblCountPR.Text = "Count PR  : ?"
        '
        'lblCountGR
        '
        Me.lblCountGR.AutoSize = True
        Me.lblCountGR.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountGR.ForeColor = System.Drawing.Color.Red
        Me.lblCountGR.Location = New System.Drawing.Point(6, 66)
        Me.lblCountGR.Name = "lblCountGR"
        Me.lblCountGR.Size = New System.Drawing.Size(93, 19)
        Me.lblCountGR.TabIndex = 6
        Me.lblCountGR.Text = "Count GR  : ?"
        '
        'lblCountTOTAL
        '
        Me.lblCountTOTAL.AutoSize = True
        Me.lblCountTOTAL.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountTOTAL.ForeColor = System.Drawing.Color.Red
        Me.lblCountTOTAL.Location = New System.Drawing.Point(6, 91)
        Me.lblCountTOTAL.Name = "lblCountTOTAL"
        Me.lblCountTOTAL.Size = New System.Drawing.Size(118, 19)
        Me.lblCountTOTAL.TabIndex = 7
        Me.lblCountTOTAL.Text = "Total Request : ?"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.AAMS.My.Resources.Resources.LogOut
        Me.PictureBox1.Location = New System.Drawing.Point(7, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(4, 570)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save to Excel"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnReferesh
        '
        Me.btnReferesh.Location = New System.Drawing.Point(3, 599)
        Me.btnReferesh.Name = "btnReferesh"
        Me.btnReferesh.Size = New System.Drawing.Size(68, 23)
        Me.btnReferesh.TabIndex = 9
        Me.btnReferesh.Text = "Refresh"
        Me.btnReferesh.UseVisualStyleBackColor = True
        Me.btnReferesh.Visible = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblDate.Location = New System.Drawing.Point(7, 52)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(112, 23)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Today Date ?"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblUser.Location = New System.Drawing.Point(8, 35)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(118, 19)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Welcome User ?"
        '
        'VerticalSplitContainer
        '
        Me.VerticalSplitContainer.Location = New System.Drawing.Point(12, 12)
        Me.VerticalSplitContainer.Name = "VerticalSplitContainer"
        Me.VerticalSplitContainer.Size = New System.Drawing.Size(176, 90)
        Me.VerticalSplitContainer.SplitterDistance = 58
        Me.VerticalSplitContainer.TabIndex = 3
        '
        'PanelENTRY
        '
        Me.PanelENTRY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelENTRY.Controls.Add(Me.txtdate)
        Me.PanelENTRY.Controls.Add(Me.Label5)
        Me.PanelENTRY.Controls.Add(Me.MonthCalendar1)
        Me.PanelENTRY.Controls.Add(Me.btnDelete)
        Me.PanelENTRY.Controls.Add(Me.btnNew)
        Me.PanelENTRY.Controls.Add(Me.btnAdd)
        Me.PanelENTRY.Controls.Add(Me.txtDesc)
        Me.PanelENTRY.Controls.Add(Me.txtWrhr)
        Me.PanelENTRY.Controls.Add(Me.txtID)
        Me.PanelENTRY.Controls.Add(Me.cmbType)
        Me.PanelENTRY.Controls.Add(Me.Label4)
        Me.PanelENTRY.Controls.Add(Me.Label2)
        Me.PanelENTRY.Controls.Add(Me.Label3)
        Me.PanelENTRY.Controls.Add(Me.Label1)
        Me.PanelENTRY.Location = New System.Drawing.Point(10, 128)
        Me.PanelENTRY.Name = "PanelENTRY"
        Me.PanelENTRY.Size = New System.Drawing.Size(957, 141)
        Me.PanelENTRY.TabIndex = 4
        '
        'txtdate
        '
        Me.txtdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdate.Location = New System.Drawing.Point(49, 48)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.ReadOnly = True
        Me.txtdate.Size = New System.Drawing.Size(129, 22)
        Me.txtdate.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Date"
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(9, 112)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(861, 109)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 28)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(861, 51)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(90, 28)
        Me.btnNew.TabIndex = 5
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(861, 80)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 28)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(381, 20)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(394, 86)
        Me.txtDesc.TabIndex = 3
        '
        'txtWrhr
        '
        Me.txtWrhr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWrhr.Location = New System.Drawing.Point(871, 20)
        Me.txtWrhr.Name = "txtWrhr"
        Me.txtWrhr.Size = New System.Drawing.Size(80, 22)
        Me.txtWrhr.TabIndex = 4
        Me.txtWrhr.Text = "8"
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(188, 20)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(115, 22)
        Me.txtID.TabIndex = 2
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Select one", "CR", "GR", "PR"})
        Me.cmbType.Location = New System.Drawing.Point(49, 20)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(87, 22)
        Me.cmbType.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(781, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Working Hours"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(318, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type"
        '
        'PanelSHOW
        '
        Me.PanelSHOW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSHOW.Controls.Add(Me.grdTask)
        Me.PanelSHOW.Location = New System.Drawing.Point(10, 275)
        Me.PanelSHOW.Name = "PanelSHOW"
        Me.PanelSHOW.Size = New System.Drawing.Size(957, 385)
        Me.PanelSHOW.TabIndex = 5
        '
        'grdTask
        '
        Me.grdTask.AllowUserToAddRows = False
        Me.grdTask.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.grdTask.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTask.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdTask.Location = New System.Drawing.Point(0, 4)
        Me.grdTask.Name = "grdTask"
        Me.grdTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdTask.Size = New System.Drawing.Size(954, 379)
        Me.grdTask.TabIndex = 7
        '
        'PopupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 672)
        Me.Controls.Add(Me.PanelSHOW)
        Me.Controls.Add(Me.PanelENTRY)
        Me.Controls.Add(Me.VerticalSplitContainer)
        Me.Controls.Add(Me.ClosePanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PopupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome ?"
        Me.ClosePanel.ResumeLayout(False)
        Me.ClosePanel.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VerticalSplitContainer.ResumeLayout(False)
        Me.PanelENTRY.ResumeLayout(False)
        Me.PanelENTRY.PerformLayout()
        Me.PanelSHOW.ResumeLayout(False)
        CType(Me.grdTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CloseAppButton As System.Windows.Forms.Button
    Friend WithEvents ClosePanel As System.Windows.Forms.Panel
    Friend WithEvents VerticalSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents PanelENTRY As System.Windows.Forms.Panel
    Friend WithEvents PanelSHOW As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWrhr As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grdTask As System.Windows.Forms.DataGridView
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblCountGR As System.Windows.Forms.Label
    Friend WithEvents lblCountPR As System.Windows.Forms.Label
    Friend WithEvents lblCountCR As System.Windows.Forms.Label
    Friend WithEvents lblCountTOTAL As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnReferesh As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents txtdate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCRhr As System.Windows.Forms.Label
    Friend WithEvents lblprhr As System.Windows.Forms.Label
    Friend WithEvents lblgrhr As System.Windows.Forms.Label
    Friend WithEvents lbltotalhr As System.Windows.Forms.Label
    Friend WithEvents lblmnthlyhr As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
