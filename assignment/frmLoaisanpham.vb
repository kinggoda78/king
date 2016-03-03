Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmLoaisanpham
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=ASSFINAl.mssql.somee.com;packet size=4096;user id=kinggoda78_SQLLogin_1;pwd=nivoh34oy4;data source=ASSFINAl.mssql.somee.com;persist security info=False;initial catalog=ASSFINAl"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        'Dim xem As SqlDataAdapter = New SqlDataAdapter("select SANPHAM.MASP as 'Mã sản phẩm',SANPHAM.TENSP as 'Tên sản phẩm', LOAISANPHAM.MALOAI as 'Mã Loại', LOAISANPHAM.TENLOAI as 'Tên Loại',SANPHAM.SOLUONG as 'Số lượng' from SANPHAM inner join LOAISANPHAM on SANPHAM.MASP = LOAISANPHAM.MASP where LOAISANPHAM.MALOAI='" & txtMALOAI.Text & "'", connect)

        Dim xem As SqlDataAdapter = New SqlDataAdapter("select LOAISANPHAM.MALOAI as 'Mã Loại' ,LOAISANPHAM.MASP as 'Mã sản phẩm', LOAISANPHAM.TENLOAI as 'Tên Loại' from LOAISANPHAM where MALOAI=N'" & txtMALOAI.Text & "'", connect)
        Try
            If txtMALOAI.Text = "" Then
                MessageBox.Show("Bạn cần nhập MALOAI", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

            Else
                db.Clear()
                dgvloaisanpham.DataSource = Nothing
                xem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvloaisanpham.DataSource = db.DefaultView
                    txtMALOAI.Text = Nothing
                    btnXoa.Enabled = True
                Else
                    MessageBox.Show("Không tìm thấy")
                    txtMALOAI.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvloaisanpham_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvloaisanpham.CellContentClick
        Dim click As Integer = dgvloaisanpham.CurrentCell.RowIndex
        txtMALOAI.Text = dgvloaisanpham.Item(0, click).Value
        txtMASP.Text = dgvloaisanpham.Item(1, click).Value
        txtTENLOAI.Text = dgvloaisanpham.Item(2, click).Value
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "insert into LOAISANPHAM values(@MALOAI,@MASP,@TENLOAI)"
        Dim save As SqlCommand = New SqlCommand(query, conn)
        conn.Open()
        Try
            txtMALOAI.Focus()
            If txtMALOAI.Text = "" Then
                MessageBox.Show("Bạn chưa nhập Mã Loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMALOAI.Focus()
                If txtMASP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập Mã Sản Phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTENLOAI.Focus()
                    If txtTENLOAI.Text = "" Then
                        MessageBox.Show("Bạn chưa Tên Loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        save.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                        save.Parameters.AddWithValue("@MASP", txtMASP.Text)
                        save.Parameters.AddWithValue("@TENLOAI", txtTENLOAI.Text)
                        save.ExecuteNonQuery()
                        MessageBox.Show("Lưu thành công")
                        'Sau khi nhập thành công, tự động làm mới các khung textbox, combox và date....
                        txtMALOAI.Text = Nothing
                        txtMASP.Text = Nothing
                        txtTENLOAI.Text = Nothing


                    End If
                End If
            End If

        Catch ex As Exception  'Ngược lại báo lỗi
            MessageBox.Show("Không được trùng mã loại", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        'Làm mới lại bảng sau khi lưu thành công
        Dim refesh As SqlDataAdapter = New SqlDataAdapter("select MALOAI as 'Mã Loại' ,MASP as 'Mã Sản Phẩm', TENLOAI as 'Tên Loại' from LOAISANPHAM", conn)
        db.Clear()
        refesh.Fill(db)
        dgvloaisanpham.DataSource = db.DefaultView
    End Sub

    Private Sub btnCapnhat_Click(sender As Object, e As EventArgs) Handles btnCapnhat.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim updatequery As String = "update LOAISANPHAM set MALOAI=@MALOAI, MASP=@MASP, TENLOAI=@TENLOAI"
        Dim addupdate As SqlCommand = New SqlCommand(updatequery, conn)
        conn.Open()
        Try
            txtMALOAI.Focus()
            If txtMALOAI.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMALOAI.Focus()
                If txtMASP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập Mã Sản Phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtMASP.Focus()
                    If txtTENLOAI.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập Tên Loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtTENLOAI.Focus()


                        addupdate.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                        addupdate.Parameters.AddWithValue("@MASP", txtMASP.Text)
                        addupdate.Parameters.AddWithValue("@TENLOAI", txtTENLOAI.Text)

                        addupdate.ExecuteNonQuery()
                        conn.Close() 'đóng kết nối
                        MessageBox.Show("Cập nhật thành công")
                        txtMALOAI.Text = Nothing
                        txtMASP.Text = Nothing
                        txtTENLOAI.Text = Nothing

                    End If
                        End If
                    End If

        Catch ex As Exception
            MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        'Sau khi cập nhật xong sẽ tự làm mới lại bảng
        db.Clear()
        dgvloaisanpham.DataSource = db
        dgvloaisanpham.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim delquery As String = "delete from LOAISANPHAM where MALOAI=@MALOAI"
        Dim delete As SqlCommand = New SqlCommand(delquery, conn)
        Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        conn.Open()
        Try
            If txtMALOAI.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                txtMALOAI.Focus()
            Else
                If resulft = Windows.Forms.DialogResult.Yes Then
                    delete.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                    delete.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Xóa thành công")
                    'Sau khi xóa thành công, tự động làm mới các khung textbox, combox và date....
                    txtMALOAI.Text = Nothing
                    txtMASP.Text = Nothing
                    txtTENLOAI.Text = Nothing
                    txtMALOAI.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Nhập đúng Loại cần xóa", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        'làm mới bảng
        db.Clear()
        dgvloaisanpham.DataSource = db
        dgvloaisanpham.DataSource = Nothing
        LoadData()
    End Sub
    Private Sub LoadData()
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim load As SqlDataAdapter = New SqlDataAdapter("select MALOAI as 'Mã Loại' ,MASP as 'Mã Sản Phẩm', TENLOAI as 'Tên Loại' from LOAISANPHAM", conn)

        conn.Open()
        load.Fill(db)
        dgvloaisanpham.DataSource = db.DefaultView
    End Sub

    Private Sub frmLoaisanpham_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class