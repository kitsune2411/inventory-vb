<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.LV = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'LV
        '
        Me.LV.HideSelection = False
        Me.LV.Location = New System.Drawing.Point(33, 169)
        Me.LV.Name = "LV"
        Me.LV.Size = New System.Drawing.Size(778, 252)
        Me.LV.TabIndex = 0
        Me.LV.UseCompatibleStateImageBehavior = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 464)
        Me.Controls.Add(Me.LV)
        Me.Name = "Form1"
        Me.Text = "Data Barang"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LV As ListView
End Class
