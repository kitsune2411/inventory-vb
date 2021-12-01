
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
        LV.Items.Clear()
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

    Sub aktif_tombol(ByVal a As Boolean, ByVal b As Boolean, ByVal c As Boolean,
                     ByVal d As Boolean, ByVal e As Boolean)
        btnTambah.Enabled = a
        btnSimpan.Enabled = b
        btnEdit.Enabled = c
        btnHapus.Enabled = d
        btnBatal.Enabled = e

    End Sub

    Sub aktif_isi(ByVal a As Boolean, ByVal b As Boolean)
        txtKodeBarang.Enabled = a
        txtNamaBarang.Enabled = b
        txtSatuan.Enabled = b
        txtHarga.Enabled = b
        txtStok.Enabled = b
    End Sub

    Sub clear()
        aktif_tombol(True, False, False, False, False)
        aktif_isi(False, False)
        txtKodeBarang.Text = ""
        txtNamaBarang.Text = ""
        txtSatuan.Text = ""
        txtHarga.Text = ""
        txtStok.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call dbconnect()
        buat_tabel()
        isi_tabel()
        clear()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        aktif_isi(True, False)
        aktif_tombol(False, False, False, False, True)
        txtKodeBarang.Focus()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        clear()
    End Sub

    Private Sub txtKodeBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeBarang.KeyPress
        If Asc(e.KeyChar) = 13 Then
            query = "Select * from tb_barang where kode='" & txtKodeBarang.Text & "'"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(query, db)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                txtNamaBarang.Text = dr("nama")
                txtSatuan.Text = dr("satuan")
                txtHarga.Text = dr("harga")
                txtStok.Text = dr("stok")
                aktif_tombol(False, False, True, True, True)
            Else
                aktif_tombol(False, True, False, False, True)

            End If
            aktif_isi(False, True)
            txtNamaBarang.Focus()
            dr.Close()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        query = "insert into tb_barang values('" &
                txtKodeBarang.Text & "', '" &
                txtNamaBarang.Text & "', '" &
                txtSatuan.Text & "', '" &
                txtHarga.Text & "', '" &
                txtStok.Text & "')"

        cmd = New MySql.Data.MySqlClient.MySqlCommand(query, db)
        cmd.ExecuteNonQuery()
        clear()
        isi_tabel()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        query = "update tb_barang set " &
                "nama='" & txtNamaBarang.Text & "', " &
                "satuan='" & txtSatuan.Text & "', " &
                "harga='" & txtHarga.Text & "', " &
                "stok='" & txtStok.Text & "' where " &
                "kode='" & txtKodeBarang.Text & "'"
        cmd = New MySql.Data.MySqlClient.MySqlCommand(query, db)
        cmd.ExecuteNonQuery()
        clear()
        isi_tabel()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        query = "delete from tb_barang where " &
                "kode='" & txtKodeBarang.Text & "'"
        cmd = New MySql.Data.MySqlClient.MySqlCommand(query, db)
        cmd.ExecuteNonQuery()
        clear()
        isi_tabel()
    End Sub
End Class
