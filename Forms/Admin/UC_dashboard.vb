Imports System.Data.OleDb

Public Class UC_dashboard
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub UC_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStats()
    End Sub

    ' ------------------------
    ' Dashboard stats
    ' ------------------------
    Private Sub LoadStats()
        Try
            ' Total Books
            Dim totalBooks As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books"))
            Dim newBooks As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books WHERE CreatedDate >= DateAdd('d', -7, Date())"))
            lblTotalBooks.Text = totalBooks.ToString()
            lblUpdateTotalBooks.Text = "+" & newBooks.ToString() & " this week"

            ' Total Students
            Dim totalStudents As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Students"))
            Dim newStudents As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Students WHERE CreatedDate >= DateAdd('d', -7, Date())"))
            lblTotalStudents.Text = totalStudents.ToString()
            lblUpdateTotalStudents.Text = "+" & newStudents.ToString() & " this week"

            ' Books Issued Today / Yesterday
            Dim todayIssued As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM BorrowedBooks WHERE BorrowDate = Date()"))
            Dim yesterdayIssued As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM BorrowedBooks WHERE BorrowDate = DateAdd('d', -1, Date())"))
            If todayIssued > 0 Then
                lblBooksIssued.Text = todayIssued.ToString() & " Today"
            ElseIf yesterdayIssued > 0 Then
                lblBooksIssued.Text = yesterdayIssued.ToString() & " Yesterday"
            Else
                lblBooksIssued.Text = "0"
            End If

            ' Overdue Books
            Dim totalOverdue As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM BorrowedBooks WHERE Status='Borrowed' AND DueDate < Date()"))
            lblOverdue.Text = totalOverdue.ToString()
            lblOverdue.ForeColor = If(totalOverdue > 0, Color.Red, Color.Green)

            ' Books Needing Attention
            Dim attentionCount As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM BorrowedBooks WHERE Status='Borrowed' AND DueDate <= Date()"))
            If attentionCount > 0 Then
                lblAttention.Text = attentionCount.ToString() & " Need Attention"
                lblAttention.ForeColor = Color.Red
            Else
                lblAttention.Text = "No Overdue Books!"
                lblAttention.ForeColor = Color.Green
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard stats: " & ex.Message)
        End Try
    End Sub

End Class
