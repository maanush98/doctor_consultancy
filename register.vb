Imports MySql.Data.MySqlClient
Public Class register
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        login.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = Textboxname.Text
        Dim number As String = Textboxnumber.Text
        Dim address As String = Textboxaddress.Text
        Dim prof As String = Textboxprof.Text
        Dim username As String = Textboxusername.Text
        Dim password As String = Textboxpassword.Text


        If name.Trim() = "" Or number.Trim() = "" Or address.Trim() = "" Or prof.Trim() = "" Or username.Trim() = "" Or password.Trim() = "" Then

            MessageBox.Show("One Or More Fields Are Empty", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)


        ElseIf usernameExist(username) Then

            MessageBox.Show("This Username Already Exists, Choose Another One", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            ' add the new user
            Dim conn As New connection()
            Dim command As New MySqlCommand("INSERT INTO `doctor`(`name`, `number`, `address`, `profession`, `username`, `password`) VALUES (@name, @num, @add, @prof, @usn, @pass)", conn.getConnection)

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name
            command.Parameters.Add("@num", MySqlDbType.VarChar).Value = number
            command.Parameters.Add("@add", MySqlDbType.VarChar).Value = address
            command.Parameters.Add("@prof", MySqlDbType.VarChar).Value = prof
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password


            conn.OpenConnection()

            If command.ExecuteNonQuery() = 1 Then

                MessageBox.Show("Registration Completed Successfully", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conn.CloseConnection()

                Textboxname.Clear()
                Textboxnumber.Clear()
                Textboxaddress.Clear()
                Textboxprof.Clear()
                Textboxusername.Clear()
                Textboxpassword.Clear()


            Else

                MessageBox.Show("Something Happen", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.CloseConnection()

            End If


        End If

    End Sub

    ' create a function to check if the username already exists
    Public Function usernameExist(ByVal username As String) As Boolean

        Dim con As New connection()
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter()
        Dim command As New MySqlCommand("SELECT * FROM `doctor` WHERE `username` = @usn", con.getConnection())
        command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username

        adapter.SelectCommand = command
        adapter.Fill(table)

        ' if the username exist return true
        If table.Rows.Count > 0 Then

            Return True

            ' if not return false  
        Else

            Return False

        End If

    End Function
End Class