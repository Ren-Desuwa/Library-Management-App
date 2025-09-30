Imports System.Data.OleDb
Imports System.IO
Public Class DatabaseHandler
    '--- Simple configuration ---
    Private Shared ReadOnly dbPath As String = Path.Combine(Application.StartupPath, "..\..\..\Database\Library.accdb")
    Private Shared ReadOnly connectionString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};"

    '--- Get all records ---
    Public Shared Function GetAllRecords() As List(Of Books)
        Dim registrations As New List(Of Registration)

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim sql As String = "SELECT * FROM Registration ORDER BY LastName, FirstName"

                Using command As New OleDbCommand(sql, connection)
                    Using reader As OleDbDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim registration As New Registration() With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .FirstName = If(reader("FirstName") IsNot DBNull.Value, reader("FirstName").ToString(), ""),
                                .LastName = If(reader("LastName") IsNot DBNull.Value, reader("LastName").ToString(), ""),
                                .MiddleName = If(reader("MiddleName") IsNot DBNull.Value, reader("MiddleName").ToString(), ""),
                                .Suffix = If(reader("Suffix") IsNot DBNull.Value, reader("Suffix").ToString(), ""),
                                .BirthDate = If(reader("BirthDate") IsNot DBNull.Value, Convert.ToDateTime(reader("BirthDate")), Date.MinValue),
                                .Gender = If(reader("Gender") IsNot DBNull.Value, reader("Gender").ToString(), ""),
                                .CivilStatus = If(reader("CivilStatus") IsNot DBNull.Value, reader("CivilStatus").ToString(), ""),
                                .Nationality = If(reader("Nationality") IsNot DBNull.Value, reader("Nationality").ToString(), ""),
                                .ContactInfo = If(reader("ContactNo") IsNot DBNull.Value, reader("ContactNo").ToString(), ""),
                                .Address = If(reader("Address") IsNot DBNull.Value, reader("Address").ToString(), "")
                            }
                            registrations.Add(registration)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error getting records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return registrations
    End Function

    '--- Get record by ID ---
    Public Shared Function GetRecordById(id As Integer) As Registration
        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim sql As String = "SELECT * FROM Registration WHERE ID = @ID"

                Using command As New OleDbCommand(sql, connection)
                    command.Parameters.AddWithValue("@ID", id)

                    Using reader As OleDbDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Return New Registration() With {
                            .id = Convert.ToInt32(reader("ID")),
                            .FirstName = If(reader("FirstName") IsNot DBNull.Value, reader("FirstName").ToString(), ""),
                            .LastName = If(reader("LastName") IsNot DBNull.Value, reader("LastName").ToString(), ""),
                            .MiddleName = If(reader("MiddleName") IsNot DBNull.Value, reader("MiddleName").ToString(), ""),
                            .Suffix = If(reader("Suffix") IsNot DBNull.Value, reader("Suffix").ToString(), ""),
                            .BirthDate = If(reader("BirthDate") IsNot DBNull.Value, Convert.ToDateTime(reader("BirthDate")), Date.MinValue),
                            .Gender = If(reader("Gender") IsNot DBNull.Value, reader("Gender").ToString(), ""),
                            .CivilStatus = If(reader("CivilStatus") IsNot DBNull.Value, reader("CivilStatus").ToString(), ""),
                            .Nationality = If(reader("Nationality") IsNot DBNull.Value, reader("Nationality").ToString(), ""),
                            .ContactInfo = If(reader("ContactNo") IsNot DBNull.Value, reader("ContactNo").ToString(), ""),
                            .Address = If(reader("Address") IsNot DBNull.Value, reader("Address").ToString(), "")
                        }
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error getting record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return Nothing
    End Function

    '--- Add new record ---
    Public Shared Function AddRecord(registration As Registration) As Integer
        If registration Is Nothing Then
            MessageBox.Show("Registration data is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return -1
        End If

        If Not registration.IsValid() Then
            Dim errors = registration.GetValidationErrors()
            MessageBox.Show($"Invalid data: {String.Join(", ", errors)}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return -1
        End If

        Dim newId As Integer = -1

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()

                Dim sql As String = "INSERT INTO Registration (FirstName, LastName, MiddleName, Suffix, BirthDate, Gender, CivilStatus, Nationality, ContactNo, Address) " &
                                  "VALUES (@FirstName, @LastName, @MiddleName, @Suffix, @BirthDate, @Gender, @CivilStatus, @Nationality, @ContactNo, @Address)"

                Using command As New OleDbCommand(sql, connection)
                    command.Parameters.AddWithValue("@FirstName", registration.FirstName)
                    command.Parameters.AddWithValue("@LastName", registration.LastName)
                    command.Parameters.AddWithValue("@MiddleName", registration.MiddleName)
                    command.Parameters.AddWithValue("@Suffix", registration.Suffix)
                    command.Parameters.AddWithValue("@BirthDate", registration.BirthDate)
                    command.Parameters.AddWithValue("@Gender", registration.Gender)
                    command.Parameters.AddWithValue("@CivilStatus", registration.CivilStatus)
                    command.Parameters.AddWithValue("@Nationality", registration.Nationality)
                    command.Parameters.AddWithValue("@ContactNo", registration.ContactInfo)
                    command.Parameters.AddWithValue("@Address", registration.Address)

                    command.ExecuteNonQuery()

                    ' Get the new ID
                    Using idCommand As New OleDbCommand("SELECT @@IDENTITY", connection)
                        newId = Convert.ToInt32(idCommand.ExecuteScalar())
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show($"Error adding record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return newId
    End Function

    '--- Update existing record ---
    Public Shared Function UpdateRecord(registration As Registration) As Boolean
        If registration Is Nothing OrElse registration.ID <= 0 Then
            MessageBox.Show("Invalid registration data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not registration.IsValid() Then
            Dim errors = registration.GetValidationErrors()
            MessageBox.Show($"Invalid data: {String.Join(", ", errors)}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()

                Dim sql As String = "UPDATE Registration SET FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, " &
                                  "Suffix = @Suffix, BirthDate = @BirthDate, Gender = @Gender, CivilStatus = @CivilStatus, " &
                                  "Nationality = @Nationality, ContactNo = @ContactNo, Address = @Address WHERE ID = @ID"

                Using command As New OleDbCommand(sql, connection)
                    command.Parameters.AddWithValue("@FirstName", registration.FirstName)
                    command.Parameters.AddWithValue("@LastName", registration.LastName)
                    command.Parameters.AddWithValue("@MiddleName", registration.MiddleName)
                    command.Parameters.AddWithValue("@Suffix", registration.Suffix)
                    command.Parameters.AddWithValue("@BirthDate", registration.BirthDate)
                    command.Parameters.AddWithValue("@Gender", registration.Gender)
                    command.Parameters.AddWithValue("@CivilStatus", registration.CivilStatus)
                    command.Parameters.AddWithValue("@Nationality", registration.Nationality)
                    command.Parameters.AddWithValue("@ContactNo", registration.ContactInfo)
                    command.Parameters.AddWithValue("@Address", registration.Address)
                    command.Parameters.AddWithValue("@ID", registration.ID)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Else
                        MessageBox.Show("No record was updated. Record may not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show($"Error updating record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    '--- Delete record by ID ---
    Public Shared Function DeleteRecord(id As Integer) As Boolean
        If id <= 0 Then
            MessageBox.Show("Invalid ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim sql As String = "DELETE FROM Registration WHERE ID = @ID"

                Using command As New OleDbCommand(sql, connection)
                    command.Parameters.AddWithValue("@ID", id)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Else
                        MessageBox.Show("No record was deleted. Record may not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show($"Error deleting record: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    '--- Search records ---
    Public Shared Function SearchRecords(searchTerm As String) As List(Of Registration)
        Dim registrations As New List(Of Registration)

        If String.IsNullOrWhiteSpace(searchTerm) Then
            Return GetAllRecords()
        End If

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Dim sql As String =
                "SELECT * FROM Registration WHERE " &
                "FirstName LIKE @Search OR LastName LIKE @Search OR " &
                "Nationality LIKE @Search OR Address LIKE @Search " &
                "ORDER BY LastName, FirstName"

                Using command As New OleDbCommand(sql, connection)
                    command.Parameters.AddWithValue("@Search", $"*{searchTerm}*") ' For Access

                    Using reader As OleDbDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim registration As New Registration() With {
                            .ID = Convert.ToInt32(reader("ID")),
                            .FirstName = If(IsDBNull(reader("FirstName")), "", reader("FirstName").ToString()),
                            .LastName = If(IsDBNull(reader("LastName")), "", reader("LastName").ToString()),
                            .MiddleName = If(IsDBNull(reader("MiddleName")), "", reader("MiddleName").ToString()),
                            .Suffix = If(IsDBNull(reader("Suffix")), "", reader("Suffix").ToString()),
                            .BirthDate = If(IsDBNull(reader("BirthDate")), Date.MinValue, Convert.ToDateTime(reader("BirthDate"))),
                            .Gender = If(IsDBNull(reader("Gender")), "", reader("Gender").ToString()),
                            .CivilStatus = If(IsDBNull(reader("CivilStatus")), "", reader("CivilStatus").ToString()),
                            .Nationality = If(IsDBNull(reader("Nationality")), "", reader("Nationality").ToString()),
                            .ContactInfo = If(IsDBNull(reader("ContactNo")), "", reader("ContactNo").ToString()),
                            .Address = If(IsDBNull(reader("Address")), "", reader("Address").ToString())
                        }
                            registrations.Add(registration)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error searching records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return registrations
    End Function


    '--- Get record count ---
    Public Shared Function GetRecordCount() As Integer
        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Using command As New OleDbCommand("SELECT COUNT(*) FROM Registration", connection)
                    Return Convert.ToInt32(command.ExecuteScalar())
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error getting record count: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End Try
        End Using
    End Function
End Class
