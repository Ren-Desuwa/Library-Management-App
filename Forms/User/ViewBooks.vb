Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms ' Required for Forms and controls

Public Class ViewBooks

    ' !!! CRITICAL FIX: REPLACE THE PATH BELOW WITH YOUR ACTUAL, ABSOLUTE PATH !!!
    Private Const DB_FILE_PATH As String = "C:\Users\xx\source\repos\Library-Management-App\TestDB.accdb"
    Private Const CONNECTION_STRING As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DB_FILE_PATH

    ''' <summary>
    ''' Public method called by SearchBooks.vb to load the details of the selected book.
    ''' </summary>
    ''' <param name="bookID">The BookID of the record to load.</param>
    Public Sub LoadBookDetails(ByVal bookID As Integer)
        ' SQL query to retrieve all details for the given BookID from the BookDetails table
        Dim sql As String = "SELECT Title, Author, ShelfLocation, ISBN, Publisher, Edition, Description, PlotSummary, Status, CopiesAvailable " &
                            "FROM BookDetails WHERE BookID = @BookID"

        Using conn As New OleDbConnection(CONNECTION_STRING)
            Using cmd As New OleDbCommand(sql, conn)
                ' Use parameter for security and correctness
                cmd.Parameters.AddWithValue("@BookID", bookID)

                Try
                    conn.Open()
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Populate Labels with textual data
                            lblTitle.Text = reader("Title").ToString()
                            lblAuthor.Text = reader("Author").ToString()
                            LblShelfLocation.Text = reader("ShelfLocation").ToString()
                            lblISBN.Text = reader("ISBN").ToString()
                            lblPublisher.Text = reader("Publisher").ToString()
                            lblEdition.Text = reader("Edition").ToString()
                            lblDescription.Text = reader("Description").ToString()
                            lblPlotSummary.Text = reader("PlotSummary").ToString()

                            Dim status As String = reader("Status").ToString()
                            ' Access the CopiesAvailable column by name, confirming the type is Number (Integer)
                            Dim copies As Integer = 0
                            If Not IsDBNull(reader("CopiesAvailable")) Then
                                copies = CInt(reader("CopiesAvailable"))
                            End If

                            ' Handle Status and Copies Display
                            UpdateStatusDisplay(status, copies)

                            ' Load the Cover Image separately
                            LoadBookCover(bookID)
                        Else
                            MessageBox.Show($"Book with ID {bookID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error loading book details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Loads the cover image attachment for the given BookID and displays it in the DataGridView.
    ''' </summary>
    Private Sub LoadBookCover(ByVal bookID As Integer)
        Dim bookCoverImage As Image = Nothing
        CoverPicture.Rows.Clear() ' Clear the DataGridView

        Try
            ' SQL to fetch the attachment data from the BookDetails.CoverImage sub-table
            Dim attachmentQuery As String = $"SELECT FileData FROM BookDetails.CoverImage WHERE ParentID = {bookID}"

            Using attachmentConn As New OleDbConnection(CONNECTION_STRING)
                attachmentConn.Open()
                Using attachmentCmd As New OleDbCommand(attachmentQuery, attachmentConn)
                    Using reader As OleDbDataReader = attachmentCmd.ExecuteReader()
                        If reader.Read() Then
                            ' Read the raw file data (the image bytes)
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
            ' Show a warning but don't stop the form from loading if the image fails
            MessageBox.Show($"Error loading cover image for BookID {bookID}: {ex.Message}", "Attachment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ' Add the image to the single-column DataGridView
        If bookCoverImage IsNot Nothing Then
            ' Ensure the column is named colCoverImage
            CoverPicture.Rows.Add(New Object() {bookCoverImage})
        End If
    End Sub

    ''' <summary>
    ''' Dynamically creates controls within the lblStatusCopy (FlowLayoutPanel) 
    ''' to show the colored status and copies count.
    ''' </summary>
    Private Sub UpdateStatusDisplay(ByVal status As String, ByVal copies As Integer)
        ' Assuming lblStatusCopy is a FlowLayoutPanel
        If lblStatusCopy Is Nothing Then Return

        lblStatusCopy.Controls.Clear()

        ' 1. Status Indicator Panel (Colored Box)
        Dim pnlStatus As New Panel() With {
            .Size = New Size(15, 15),
            .Margin = New Padding(0, 5, 5, 0),
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' 2. Status Label (Text)
        Dim statusLabel As New Label() With {
            .AutoSize = True,
            .Text = status,
            .Font = New Font(Me.Font.FontFamily, 10, FontStyle.Bold),
            .Margin = New Padding(0, 5, 15, 0)
        }

        Select Case status
            Case "Available"
                pnlStatus.BackColor = Color.Green
                statusLabel.ForeColor = Color.Green
            Case "Checked Out"
                pnlStatus.BackColor = Color.Red
                statusLabel.ForeColor = Color.Red
            Case Else
                pnlStatus.BackColor = Color.Gray
                statusLabel.ForeColor = Color.Black
        End Select

        lblStatusCopy.Controls.Add(pnlStatus)
        lblStatusCopy.Controls.Add(statusLabel)

        ' 3. Copies Available Text
        If status = "Available" AndAlso copies > 0 Then
            Dim copiesLabel As New Label() With {
                .AutoSize = True,
                .Text = $"{copies} copies Available",
                .Margin = New Padding(0, 5, 0, 0)
            }
            lblStatusCopy.Controls.Add(copiesLabel)
        End If

    End Sub

    ' Handler for the Close button
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class