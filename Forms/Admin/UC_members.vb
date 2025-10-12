Imports System.Data.OleDb

Public Class UC_Members

    Private Sub UC_Members_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up DataGridView
        dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMembers.MultiSelect = False
        dgvMembers.ReadOnly = True
        dgvMembers.AllowUserToAddRows = False

        ' Combo box items
        cmbDateFilterJoined.Items.Clear()
        cmbDateFilterJoined.Items.AddRange({"All", "Today", "Yesterday", "This Week"})
        cmbDateFilterJoined.SelectedItem = "All"

        ' Load all members initially
        LoadMembers()
    End Sub

    ' Load members with optional search
    Private Sub LoadMembers(Optional searchTerm As String = "")
        Try
            Dim query As String = "SELECT ID, StudentID, FirstName, LastName, Email, ContactNumber, CreatedDate FROM Students WHERE 1=1"

            ' Date filter
            Select Case cmbDateFilterJoined.SelectedItem.ToString()
                Case "Today"
                    query &= " AND CreatedDate = Date()"
                Case "Yesterday"
                    query &= " AND CreatedDate = DateAdd('d', -1, Date())"
                Case "This Week"
                    query &= " AND CreatedDate >= DateAdd('d', -7, Date())"
                Case "All"
                    ' no additional filter
            End Select

            ' Search filter
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                query &= " AND (StudentID LIKE @search OR FirstName & ' ' & LastName LIKE @search)"
            End If

            Dim parameters As New List(Of OleDbParameter)
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                parameters.Add(New OleDbParameter("@search", "%" & searchTerm & "%"))
            End If

            Dim dt As DataTable = DatabaseConnection.Instance.ExecuteQuery(query, parameters.ToArray())
            dgvMembers.DataSource = dt

            ' Optionally highlight new members if you want
            ' For Each row As DataGridViewRow In dgvMembers.Rows
            '     If CDate(row.Cells("CreatedDate").Value) = Date.Today Then
            '         row.DefaultCellStyle.ForeColor = Color.Green
            '     End If
            ' Next

            dgvMembers.ClearSelection()

        Catch ex As Exception
            MessageBox.Show("Error loading members: " & ex.Message)
        End Try
    End Sub

    ' Real-time search
    Private Sub txtSearchStudents_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStudents.TextChanged
        LoadMembers(txtSearchStudents.Text.Trim())
    End Sub

    ' Date filter changed
    Private Sub cmbDateFilterJoined_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDateFilterJoined.SelectedIndexChanged
        LoadMembers(txtSearchStudents.Text.Trim())
    End Sub

End Class
