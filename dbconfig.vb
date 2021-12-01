Imports MySql.Data.MySqlClient
Module dbconfig
    Public db As MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public config As String
    Sub dbconnect()
        config = "Server=localhost;user=root;password=;database=vb_crud"
        Try
            db = New MySqlConnection(config)

            If db.State = ConnectionState.Closed Then
                db.Open()
            End If

        Catch ex As Exception
            MessageBox.Show("Failed connect to database...", CStr(MsgBoxStyle.Critical))
        End Try
    End Sub
End Module
