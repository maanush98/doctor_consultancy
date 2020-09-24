﻿Imports MySql.Data.MySqlClient
Public Class login
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Application.Exit()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New connection()
        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()
        Dim command As New MySqlCommand("SELECT `username`, `password` FROM `doctor` WHERE `username` = @usn AND `password` = @pass", conn.getConnection())

        command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = TextBoxusername.Text
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextBoxpassword.Text

        If TextBoxusername.Text.Trim() = "" Or TextBoxusername.Text.Trim().ToLower() = "username" Then

            MessageBox.Show("Enter Your Username To Login", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf TextBoxpassword.Text.Trim() = "" Or TextBoxpassword.Text.Trim().ToLower() = "password" Then

            MessageBox.Show("Enter Your Password To Login", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            adapter.SelectCommand = command
            adapter.Fill(table)

            If table.Rows.Count > 0 Then

                Me.Hide()
                Chat1.Show()

            Else

                MessageBox.Show("This Username Or/And Password Doesn't Exists", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Hide()
        register.Show()

    End Sub

    Private Sub TextBoxusername_Enter(sender As Object, e As EventArgs) Handles TextBoxusername.Enter
        Dim username As String = TextBoxusername.Text

        If username.Trim().ToLower() = "username" Or username.Trim() = "" Then

            TextBoxusername.Text = ""
            TextBoxusername.ForeColor = Color.Silver


        End If
    End Sub

    Private Sub TextBoxusername_Leave(sender As Object, e As EventArgs) Handles TextBoxusername.Leave
        Dim username As String = TextBoxusername.Text

        If username.Trim().ToLower() = "username" Or username.Trim() = "" Then

            TextBoxusername.Text = "username"
            TextBoxusername.ForeColor = Color.Silver


        End If
    End Sub

    Private Sub TextBoxpassword_Enter(sender As Object, e As EventArgs) Handles TextBoxpassword.Enter
        Dim pass As String = TextBoxpassword.Text
        If pass.Trim().ToLower() = "password" Or pass.Trim() = "" Then

            ' clear the textbox text
            TextBoxpassword.Text = ""
            ' change the textbox font color
            TextBoxpassword.ForeColor = Color.Silver

            ' use system password
            TextBoxpassword.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub TextBoxpassword_Leave(sender As Object, e As EventArgs) Handles TextBoxpassword.Leave
        Dim pass As String = TextBoxpassword.Text
        If pass.Trim().ToLower() = "password" Or pass.Trim() = "" Then
            ' set the textbox text
            TextBoxpassword.Text = "password"
            ' change the textbox font color
            TextBoxpassword.ForeColor = Color.Silver

            ' set system password to false
            TextBoxpassword.UseSystemPasswordChar = False

        End If


    End Sub
End Class
