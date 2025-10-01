Public Class UC_dashboard
    Inherits UserControl

    Public Sub New()
        ' Required by designer
        InitializeComponent()
    End Sub

    Private Sub UC_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStats()
    End Sub

    Private Sub LoadStats()
        Try
            ' ------------------------
            ' Total Books
            ' ------------------------
            Dim totalBooks As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books"))

            Dim newBooks As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books WHERE CreatedDate >= DateAdd('d', -7, Date())"))

            lblTotalBooks.Text = totalBooks.ToString()
            lblUpdateTotalBooks.Text = "+" & newBooks.ToString() & " this week"

            ' ------------------------
            ' Total Students
            ' ------------------------
            Dim totalStudents As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Students"))

            Dim newStudents As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Students WHERE CreatedDate >= DateAdd('d', -7, Date())"))

            lblTotalStudents.Text = totalStudents.ToString()
            lblUpdateTotalStudents.Text = "+" & newStudents.ToString() & " this week"

            ' ------------------------
            ' Books Issued Today / Yesterday
            ' ------------------------
            ' Assuming 'BorrowedBy' is NOT NULL when issued
            Dim todayIssued As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books WHERE BorrowedBy IS NOT NULL AND DueDate = Date()"))

            Dim yesterdayIssued As Integer = Convert.ToInt32(DatabaseConnection.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Books WHERE BorrowedBy IS NOT NULL AND DueDate = DateAdd('d', -1, Date())"))

            If todayIssued > 0 Then
                lblBooksIssued.Text = todayIssued.ToString() & " Today"
            ElseIf yesterdayIssued > 0 Then
                lblBooksIssued.Text = yesterdayIssued.ToString() & " Yesterday"
            Else
                lblBooksIssued.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading dashboard stats: " & ex.Message)
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub
End Class
