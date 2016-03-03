Public Class frmMain
    'khai bao toancuc
    Private _LoginResult As DialogResult
    Private Sub ThêmSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmSảnPhẩmToolStripMenuItem.Click
        frmCapnhatsanpham.Show()
    End Sub

    Private Sub XemKhácHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemKhácHàngToolStripMenuItem.Click
        frmKH.Show()
    End Sub

    Private Sub ChỉnhSữaKHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChỉnhSữaKHToolStripMenuItem.Click
        frmDieuchinhKH.Show()
    End Sub

    Private Sub XemSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemSảnPhẩmToolStripMenuItem.Click
        frmXemsanpham.Show()
    End Sub

    Private Sub LoạiSànPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmLoaisanpham.Show()
    End Sub



    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _LoginResult <> Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub CậpNhậtToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmLoaisanpham.Show()
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim frm As New frmLogin
        frm.ShowDialog()
        _LoginResult = frm.DialogResult
    End Sub

    Private Sub LiênHệToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiênHệToolStripMenuItem.Click
        frmlienhe.show()
    End Sub

    Private Sub GiớiThiệuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiớiThiệuToolStripMenuItem.Click
        frmgioithieu.show()
    End Sub
End Class
