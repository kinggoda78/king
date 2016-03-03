Imports System.Configuration
Imports System.Data.SqlClient
Public Class frmLogin

    'khai bao bien toan cuc
    Private _connectionstring As String = ConfigurationSettings.AppSettings("Myconnectionstring")
    Private conn As SqlConnection
    Private da As SqlDataAdapter
    'dinh nghia ham du lieu
    Private Function getDataTable(sqlQuery As String) As DataTable
        Dim dTable As New DataTable
        'khoi tao bien conn
        conn = New SqlConnection(_connectionstring)
        da = New SqlDataAdapter(sqlQuery, conn)
        Try
            'mo ket noi
            conn.Open()
            da.Fill(dTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        Finally
            conn.Close()

        End Try
        Return dTable
    End Function
    'kiem tra username
    Private Function CheckLogin(user As String, pass As String)
        Dim sqlQuery As String = String.Format("select * from dbo.Account where username = '{0}' and password = '{1}'", user, pass)
        Dim dTable As DataTable = getDataTable(sqlQuery)
        Return dTable.Rows.Count > 0
    End Function
    'kiem tra user pass co trong hay khong
    Private Function isEmpty() As Boolean
        Return String.IsNullOrEmpty(Me.txtUsername.Text) OrElse String.IsNullOrEmpty(Me.txtpassword.Text)
    End Function

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If isEmpty() Then
            MessageBox.Show("Tài Khoản Mật Khẩu Không Được Để Trống")
        Else
            If CheckLogin(Me.txtUsername.Text.ToLower, Me.txtpassword.Text.ToLower) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Tài Khoản Mật Khẩu Sai")
            End If
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class