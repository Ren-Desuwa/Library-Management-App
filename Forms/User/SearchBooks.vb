Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms ' Used for various WinForms types
Imports Guna.UI2.WinForms ' Required for Guna2Button and other Guna controls

Public Class SearchBooks

    ' === 1. Configuration Constants ===
    Private Const ROWS_PER_PAGE As Integer = 3
    Private Const MAX_PAGES_IN_WINDOW As Integer = 5

    ' !!! CRITICAL FIX: REPLACE THE PATH BELOW WITH YOUR ACTUAL, ABSOLUTE PATH !!!
    Private Const DB_FILE_PATH As String = "C:\Users\xx\Downloads\TestDB.accdb"
    Private Const CONNECTION_STRING As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DB_FILE_PATH

    ' === 2. Global State Variables for PAGING ===
    Private pageHistory As New List(Of Integer) From {0}
    Private currentPageIndex As Integer = 1
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0


    ' === 3. UserControl Load and Initial Data Fetch ===
    Private Sub SearchBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Guna2DataGridView1 IsNot Nothing Then
            Guna2DataGridView1.RowTemplate.Height = 180

            ' Set the ImageLayout to ZOOM (Value 3)
            If Guna2DataGridView1.Columns.Contains("Cover") Then
                DirectCast(Guna2DataGridView1.Columns("Cover"), DataGridViewImageColumn).ImageLayout = 3
            End If

            CalculateTotalResults()
            LoadPageData(0)
        End If
    End Sub

    ' === 4. Calculate Total Results (Run once at startup) ===
    Private Sub CalculateTotalResults()
        ' MODIFIED: Use the correct table name (BookDetails)
        Dim sqlCount As String = "SELECT COUNT(*) FROM BookDetails"

        Using conn As New OleDbConnection(CONNECTION_STRING)
            Using cmd As New OleDbCommand(sqlCount, conn)
                Try
                    conn.Open()
                    totalRecords = CInt(cmd.ExecuteScalar())
                    If totalRecords > 0 Then
                        totalPages = CInt(Math.Ceiling(totalRecords / ROWS_PER_PAGE))
                    Else
                        totalPages = 1
                    End If

                    If lblTotalResults IsNot Nothing Then
                        lblTotalResults.Text = $"{totalRecords} Books Found"
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Could not count total books: {ex.Message}", "Database Error")
                End Try
            End Using
        End Using
    End Sub

    ' === 5. Primary Data Retrieval and Paging Logic ===
    Private Sub LoadPageData(direction As Integer)
        Dim dtPage As New DataTable()
        Dim startID As Integer = 0
        Dim targetPage As Integer = 0

        ' --- 5A. Determine Action and History (Paging logic remains the same) ---
        If direction = 0 Then
            pageHistory.Clear()
            pageHistory.Add(0)
            currentPageIndex = 1
            startID = 0
        ElseIf direction = 1 Then
            startID = pageHistory(currentPageIndex)
            currentPageIndex += 1
        ElseIf direction = -1 Then
            currentPageIndex = Math.Max(1, currentPageIndex - 1)
            startID = pageHistory(currentPageIndex)
            pageHistory.RemoveAt(pageHistory.Count - 1)
        ElseIf direction > 1 Then
            targetPage = direction
            If targetPage < 1 OrElse targetPage > totalPages Then
                MessageBox.Show($"Page must be between 1 and {totalPages}.", "Invalid Page Number")
                Return
            End If
            If targetPage > currentPageIndex Then
                LoadPageData(0)
                For i As Integer = 1 To targetPage - 1
                    LoadPageData(1)
                Next
                Return
            ElseIf targetPage < currentPageIndex Then
                Do While currentPageIndex > targetPage
                    LoadPageData(-1)
                Loop
                Return
            End If
        End If

        ' --- 5B. Construct and Execute the SQL Query ---
        ' MODIFIED: Use BookDetails table and select BookID, Title, Author, Status
        Dim query As String = $"SELECT TOP {ROWS_PER_PAGE} BookID, Title, Author, Status FROM BookDetails WHERE BookID > {startID} ORDER BY BookID ASC"

        Using conn As New OleDbConnection(CONNECTION_STRING)
            Using cmd As New OleDbCommand(query, conn)
                Using adapter As New OleDbDataAdapter(cmd)
                    Try
                        conn.Open()
                        adapter.Fill(dtPage)
                    Catch ex As Exception
                        MessageBox.Show($"Database read error: {ex.Message}", "Error")
                        Return
                    End Try
                End Using
            End Using
        End Using

        ' --- 5C. Update DataGridView and State ---
        Guna2DataGridView1.Rows.Clear()

        If dtPage.Rows.Count > 0 Then
            Dim currentLastBookID As Integer = 0

            For Each row As DataRow In dtPage.Rows
                Dim bookCoverImage As Image = Nothing
                Dim bookID As Integer = CInt(row("BookID"))

                ' ===================================================================
                ' === ATTACHMENT RETRIEVAL LOGIC (Uses BookDetails.CoverImage) ===
                ' ===================================================================
                Try
                    ' The attachment sub-table is named BookDetails.CoverImage
                    Dim attachmentQuery As String = $"SELECT FileData FROM BookDetails.CoverImage WHERE ParentID = {bookID}"

                    Using attachmentConn As New OleDbConnection(CONNECTION_STRING)
                        attachmentConn.Open()
                        Using attachmentCmd As New OleDbCommand(attachmentQuery, attachmentConn)
                            Using reader As OleDbDataReader = attachmentCmd.ExecuteReader()
                                If reader.Read() Then
                                    Dim rawImageBytes As Byte() = DirectCast(reader("FileData"), Byte())

                                    If rawImageBytes IsNot Nothing AndAlso rawImageBytes.Length > 0 Then
                                        Using ms As New MemoryStream(rawImageBytes)
                                            bookCoverImage = Image.FromStream(ms)
                                        End Using
                                    End If
                                End If
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error loading attachment for BookID {bookID}: {ex.Message}", "Attachment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
                ' ===================================================================

                ' Populate Grid
                ' IMPORTANT: Ensure colBookID is the last (hidden) column in your DataGridView designer
                Guna2DataGridView1.Rows.Add(New Object() {
    bookCoverImage,                       ' Index 0: Cover Column
    bookID,                               ' Index 1: BookID (Hidden column)
    row("Title").ToString(),              ' Index 2: Title Column
    row("Author").ToString(),             ' Index 3: Author Column
    row("Status").ToString(),             ' Index 4: Status Column
    Nothing                               ' Index 5: Action Column (View button)
})

                currentLastBookID = bookID
            Next

            If direction = 1 AndAlso dtPage.Rows.Count > 0 Then
                pageHistory.Add(currentLastBookID)
            End If
        End If

        ' --- 5D. Update Navigation Controls ---
        If btnSuperPrev IsNot Nothing Then btnSuperPrev.Enabled = (currentPageIndex > 1)
        If btnPrev IsNot Nothing Then btnPrev.Enabled = (currentPageIndex > 1)

        Dim hasNextPage As Boolean = (dtPage.Rows.Count = ROWS_PER_PAGE)
        If btnNext IsNot Nothing Then btnNext.Enabled = hasNextPage
        If btnSuperNext IsNot Nothing Then btnSuperNext.Enabled = (currentPageIndex < totalPages)

        DrawPaginationWindow()
    End Sub

    ' === 6. Draw Pagination Window (Sliding 5-Page View) ===
    Private Sub DrawPaginationWindow()
        If pnlPageNumbers Is Nothing Then Return

        pnlPageNumbers.Controls.Clear()

        Dim startPage As Integer = currentPageIndex - (MAX_PAGES_IN_WINDOW \ 2)
        If startPage < 1 Then startPage = 1

        Dim endPage As Integer = startPage + MAX_PAGES_IN_WINDOW - 1

        If totalPages > 0 Then
            endPage = Math.Min(endPage, totalPages)
        End If

        For pageNum As Integer = startPage To endPage
            Dim btnPage As New Guna.UI2.WinForms.Guna2Button()
            With btnPage
                .Text = pageNum.ToString()
                .Tag = pageNum
                .Size = New Size(30, 30)
                .BorderRadius = 5
                If pageNum = currentPageIndex Then
                    .FillColor = Color.FromArgb(0, 150, 0)
                    .ForeColor = Color.White
                Else
                    .FillColor = Color.Transparent
                    .ForeColor = Color.Black
                    .BorderColor = Color.LightGray
                    .BorderThickness = 1
                End If
                AddHandler .Click, AddressOf PageNumber_Click
            End With
            pnlPageNumbers.Controls.Add(btnPage)
        Next
    End Sub

    ' === 7. Navigation Button Handlers (Handles all fixed buttons) ===
    Private Sub btnSuperPrev_Click(sender As Object, e As EventArgs) Handles btnSuperPrev.Click
        LoadPageData(0)
    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        LoadPageData(-1)
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        LoadPageData(1)
    End Sub
    Private Sub btnSuperNext_Click(sender As Object, e As EventArgs) Handles btnSuperNext.Click
        If totalPages > 0 Then
            LoadPageData(totalPages)
        Else
            MessageBox.Show("Total page count is not available.", "Info")
        End If
    End Sub
    Private Sub PageNumber_Click(sender As Object, e As EventArgs)
        Dim btn As Guna.UI2.WinForms.Guna2Button = DirectCast(sender, Guna.UI2.WinForms.Guna2Button)
        Dim targetPage As Integer = CInt(btn.Tag)
        If targetPage <> currentPageIndex Then
            LoadPageData(targetPage)
        End If
    End Sub
    Private Sub btnGoTo_Click(sender As Object, e As EventArgs) Handles btnGoTo.Click
        If txtGoToPage Is Nothing Then Return
        Dim targetPage As Integer = 0
        If Integer.TryParse(txtGoToPage.Text, targetPage) Then
            If targetPage >= 1 AndAlso targetPage <= totalPages Then
                LoadPageData(targetPage)
            Else
                MessageBox.Show($"Please enter a valid page number between 1 and {totalPages}.", "Invalid Input")
            End If
        Else
            MessageBox.Show("Invalid input. Please enter a number.", "Error")
        End If
    End Sub

    ' === 8. Conditional Status Coloring (FIXED) ===
    Private Sub Guna2DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Guna2DataGridView1.CellFormatting
        If e.RowIndex >= 0 AndAlso Guna2DataGridView1.Columns(e.ColumnIndex).Name = "colStatus" Then
            Dim statusValue As String = CStr(e.Value)

            Dim backColor As Color = Color.Empty
            Dim foreColor As Color = Color.Black

            Select Case statusValue
                Case "Available"
                    backColor = Color.FromArgb(170, 255, 170) ' Light Green
                    foreColor = Color.DarkGreen
                Case "Checked Out"
                    backColor = Color.FromArgb(220, 220, 220) ' Light Gray
                    foreColor = Color.Black
            End Select

            If backColor <> Color.Empty Then
                ' Apply to default cell style
                e.CellStyle.BackColor = backColor
                e.CellStyle.ForeColor = foreColor
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                ' FIX: Apply colors to the SELECTION style of the cell itself.
                e.CellStyle.SelectionBackColor = backColor
                e.CellStyle.SelectionForeColor = foreColor

                e.FormattingApplied = True
            End If
        End If
    End Sub

    ' === 9. "View" Button Click Handler (MODIFIED) ===
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        ' Check if the click was on the "colAction" (View button) column
        If e.RowIndex >= 0 AndAlso Guna2DataGridView1.Columns(e.ColumnIndex).Name = "colAction" Then

            Try
                ' Retrieve the BookID from the hidden column (assuming it's named colBookID)
                Dim bookID As Integer = CInt(Guna2DataGridView1.Rows(e.RowIndex).Cells("colBookID").Value)

                ' Instantiate and show the ViewBooks form
                Dim viewForm As New ViewBooks()
                viewForm.LoadBookDetails(bookID)
                viewForm.ShowDialog()

            Catch ex As Exception
                MessageBox.Show($"Error retrieving Book ID or opening form: {ex.Message}", "Action Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

End Class