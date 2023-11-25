<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class param
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.allaghKodikoy = New System.Windows.Forms.Button()
        Me.UpdateMem = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SHOWOLATRAP = New System.Windows.Forms.CheckBox()
        Me.LOGPRINPLIR = New System.Windows.Forms.CheckBox()
        Me.EKTPRINPLIR = New System.Windows.Forms.CheckBox()
        Me.RESERVEDBYONE = New System.Windows.Forms.CheckBox()
        Me.CANOPENBARDIA = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'allaghKodikoy
        '
        Me.allaghKodikoy.Location = New System.Drawing.Point(371, 67)
        Me.allaghKodikoy.Name = "allaghKodikoy"
        Me.allaghKodikoy.Size = New System.Drawing.Size(240, 42)
        Me.allaghKodikoy.TabIndex = 0
        Me.allaghKodikoy.Text = "Αλλαγή κωδικού χρήστη"
        Me.allaghKodikoy.UseVisualStyleBackColor = True
        '
        'UpdateMem
        '
        Me.UpdateMem.Location = New System.Drawing.Point(371, 461)
        Me.UpdateMem.Name = "UpdateMem"
        Me.UpdateMem.Size = New System.Drawing.Size(240, 42)
        Me.UpdateMem.TabIndex = 1
        Me.UpdateMem.Text = "Ενημέρωση Παραμέτρων"
        Me.UpdateMem.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.SHOWOLATRAP, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LOGPRINPLIR, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.EKTPRINPLIR, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RESERVEDBYONE, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CANOPENBARDIA, 1, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(45, 127)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 305)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Δείχνει όλα τα τραπέζια όλων των σερβιτόρων"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Θελει εκτύπωση λογαριασμου πριν την πληρωμη"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Θελει εκτύπωση ειδών πριν την πληρωμη"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(239, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Το τραπέζι είναι αποκλειστικό του σερβιτόρου"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Μπορεί να ανοιξει βάρδια"
        '
        'SHOWOLATRAP
        '
        Me.SHOWOLATRAP.AutoSize = True
        Me.SHOWOLATRAP.Location = New System.Drawing.Point(285, 3)
        Me.SHOWOLATRAP.Name = "SHOWOLATRAP"
        Me.SHOWOLATRAP.Size = New System.Drawing.Size(29, 17)
        Me.SHOWOLATRAP.TabIndex = 5
        Me.SHOWOLATRAP.Text = " "
        Me.SHOWOLATRAP.UseVisualStyleBackColor = True
        '
        'LOGPRINPLIR
        '
        Me.LOGPRINPLIR.AutoSize = True
        Me.LOGPRINPLIR.Location = New System.Drawing.Point(285, 64)
        Me.LOGPRINPLIR.Name = "LOGPRINPLIR"
        Me.LOGPRINPLIR.Size = New System.Drawing.Size(29, 17)
        Me.LOGPRINPLIR.TabIndex = 6
        Me.LOGPRINPLIR.Text = " "
        Me.LOGPRINPLIR.UseVisualStyleBackColor = True
        '
        'EKTPRINPLIR
        '
        Me.EKTPRINPLIR.AutoSize = True
        Me.EKTPRINPLIR.Location = New System.Drawing.Point(285, 125)
        Me.EKTPRINPLIR.Name = "EKTPRINPLIR"
        Me.EKTPRINPLIR.Size = New System.Drawing.Size(29, 17)
        Me.EKTPRINPLIR.TabIndex = 7
        Me.EKTPRINPLIR.Text = " "
        Me.EKTPRINPLIR.UseVisualStyleBackColor = True
        '
        'RESERVEDBYONE
        '
        Me.RESERVEDBYONE.AutoSize = True
        Me.RESERVEDBYONE.Location = New System.Drawing.Point(285, 186)
        Me.RESERVEDBYONE.Name = "RESERVEDBYONE"
        Me.RESERVEDBYONE.Size = New System.Drawing.Size(29, 17)
        Me.RESERVEDBYONE.TabIndex = 8
        Me.RESERVEDBYONE.Text = " "
        Me.RESERVEDBYONE.UseVisualStyleBackColor = True
        '
        'CANOPENBARDIA
        '
        Me.CANOPENBARDIA.AutoSize = True
        Me.CANOPENBARDIA.Location = New System.Drawing.Point(285, 247)
        Me.CANOPENBARDIA.Name = "CANOPENBARDIA"
        Me.CANOPENBARDIA.Size = New System.Drawing.Size(29, 17)
        Me.CANOPENBARDIA.TabIndex = 9
        Me.CANOPENBARDIA.Text = " "
        Me.CANOPENBARDIA.UseVisualStyleBackColor = True
        '
        'param
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 705)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.UpdateMem)
        Me.Controls.Add(Me.allaghKodikoy)
        Me.Name = "param"
        Me.Text = "Form8"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents allaghKodikoy As Button
    Friend WithEvents UpdateMem As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents SHOWOLATRAP As CheckBox
    Friend WithEvents LOGPRINPLIR As CheckBox
    Friend WithEvents EKTPRINPLIR As CheckBox
    Friend WithEvents RESERVEDBYONE As CheckBox
    Friend WithEvents CANOPENBARDIA As CheckBox
End Class
