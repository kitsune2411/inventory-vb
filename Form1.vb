
Public Class Form1
    Dim query As String

    Sub buat_tabel()
        With LV
            .Columns.Add("Kode", 100, HorizontalAlignment.Left)
            .Columns.Add("Nama", 200, HorizontalAlignment.Left)
            .Columns.Add("Satuan", 80, HorizontalAlignment.Left)
            .Columns.Add("Harga", 100, HorizontalAlignment.Left)
            .Columns.Add("Stok", 100, HorizontalAlignment.Left)
            .GridLines = True
            .FullRowSelect = True
            .View = View.Details
        End With
    End Sub
    Sub isi_tabel()
        query = "Select * from tb_barang order by nama asc"
        cmd = New MySql.Data.MySqlClient.MySqlCommand(query, db)
        dr = cmd.ExecuteReader
        While dr.Read
            Dim row As New ListViewItem
            row.Text = dr("kode")
            row.SubItems.Add(dr("nama"))
            row.SubItems.Add(dr("satuan"))
            row.SubItems.Add("Rp " & dr("harga"))
            row.SubItems.Add(dr("stok"))
            LV.Items.Add(row)
        End While
        dr.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call dbconnect()
        buat_tabel()
        isi_tabel()

    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV.SelectedIndexChanged

    End Sub
End Class
