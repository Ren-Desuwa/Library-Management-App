Imports System.Data.OleDb

Public Class TransactionDatabase
    Private ReadOnly _dbConnection As DatabaseConnection

    Public Sub New(dbConnection As DatabaseConnection)
        _dbConnection = dbConnection
    End Sub

    ' Create Tables
    Public Sub CreateTables()
        Try
            Dim createTransactionsTable As String = "CREATE TABLE Transactions (
                TransactionID AUTOINCREMENT PRIMARY KEY,
                AccountID INTEGER NOT NULL,
                BookID INTEGER,
                FineAmount CURRENCY NOT NULL,
                AmountPaid CURRENCY NOT NULL DEFAULT 0,
                Reason MEMO NOT NULL,
                Status INTEGER NOT NULL,
                CreatedDate DATETIME NOT NULL,
                PaidDate DATETIME,
                IsDeleted BIT NOT NULL DEFAULT 0
            )"

            _dbConnection.ExecuteNonQuery(createTransactionsTable)
            DatabaseLogger.LogOperation("TransactionDatabase.CreateTables", "Transactions table created")
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.CreateTables", ex)
            Throw New Exception($"Error creating transactions table: {ex.Message}", ex)
        End Try
    End Sub

    ' Create Transaction (Fine)
    Public Function CreateTransaction(accountID As Integer, fineAmount As Decimal, reason As String, Optional bookID As Integer? = Nothing) As Integer
        Try
            Dim query = "INSERT INTO Transactions (AccountID, BookID, FineAmount, AmountPaid, Reason, Status, CreatedDate, IsDeleted) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)
                    DatabaseHelper.AddParameter(cmd, "@BookID", bookID)
                    cmd.Parameters.AddWithValue("@FineAmount", fineAmount)
                    cmd.Parameters.AddWithValue("@AmountPaid", 0D)
                    cmd.Parameters.AddWithValue("@Reason", reason)
                    cmd.Parameters.AddWithValue("@Status", CInt(FineStatus.Pending))
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@IsDeleted", False)

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "SELECT @@IDENTITY"
                    Dim transactionID = Convert.ToInt32(cmd.ExecuteScalar())

                    DatabaseLogger.LogOperation("TransactionDatabase.CreateTransaction", $"Created transaction #{transactionID} for account #{accountID}, amount: ${fineAmount}")
                    Return transactionID
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.CreateTransaction", ex)
            Throw New Exception($"Error creating transaction: {ex.Message}", ex)
        End Try
    End Function

    ' Get Transaction by ID
    Public Function GetTransactionByID(transactionID As Integer) As Transaction
        Try
            Dim query = "SELECT * FROM Transactions WHERE TransactionID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return MapReaderToTransaction(reader)
                        End If
                    End Using
                End Using

                Return Nothing
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.GetTransactionByID", ex)
            Throw New Exception($"Error getting transaction by ID: {ex.Message}", ex)
        End Try
    End Function

    ' Get All Transactions
    Public Function GetAllTransactions(Optional includeDeleted As Boolean = False) As List(Of Transaction)
        Dim transactions As New List(Of Transaction)()

        Try
            Dim query = If(includeDeleted,
                "SELECT * FROM Transactions ORDER BY CreatedDate DESC",
                "SELECT * FROM Transactions WHERE IsDeleted = 0 ORDER BY CreatedDate DESC")

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            transactions.Add(MapReaderToTransaction(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.GetAllTransactions", ex)
            Throw New Exception($"Error getting all transactions: {ex.Message}", ex)
        End Try

        Return transactions
    End Function

    ' Get Transactions by Account
    Public Function GetTransactionsByAccount(accountID As Integer) As List(Of Transaction)
        Dim transactions As New List(Of Transaction)()

        Try
            Dim query = "SELECT * FROM Transactions WHERE AccountID = ? AND IsDeleted = 0 ORDER BY CreatedDate DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            transactions.Add(MapReaderToTransaction(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.GetTransactionsByAccount", ex)
            Throw New Exception($"Error getting transactions by account: {ex.Message}", ex)
        End Try

        Return transactions
    End Function

    ' Get Pending Transactions by Account
    Public Function GetPendingTransactionsByAccount(accountID As Integer) As List(Of Transaction)
        Dim transactions As New List(Of Transaction)()

        Try
            Dim query = "SELECT * FROM Transactions WHERE AccountID = ? AND Status IN (?, ?) AND IsDeleted = 0 ORDER BY CreatedDate DESC"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)
                    cmd.Parameters.AddWithValue("@Pending", CInt(FineStatus.Pending))
                    cmd.Parameters.AddWithValue("@PartiallyPaid", CInt(FineStatus.PartiallyPaid))

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            transactions.Add(MapReaderToTransaction(reader))
                        End While
                    End Using
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.GetPendingTransactionsByAccount", ex)
            Throw New Exception($"Error getting pending transactions: {ex.Message}", ex)
        End Try

        Return transactions
    End Function

    ' Get Total Outstanding Fines
    Public Function GetTotalOutstandingFines(accountID As Integer) As Decimal
        Try
            Dim query = "SELECT SUM(FineAmount - AmountPaid) FROM Transactions WHERE AccountID = ? AND Status IN (?, ?) AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AccountID", accountID)
                    cmd.Parameters.AddWithValue("@Pending", CInt(FineStatus.Pending))
                    cmd.Parameters.AddWithValue("@PartiallyPaid", CInt(FineStatus.PartiallyPaid))

                    Dim result = cmd.ExecuteScalar()
                    If IsDBNull(result) OrElse result Is Nothing Then
                        Return 0D
                    End If
                    Return Convert.ToDecimal(result)
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.GetTotalOutstandingFines", ex)
            Return 0D
        End Try
    End Function

    ' Pay Fine
    Public Sub PayFine(transactionID As Integer, amount As Decimal)
        Try
            _dbConnection.OpenConnection()
            Try
                ' Get current transaction
                Dim transaction = GetTransactionByID(transactionID)
                If transaction Is Nothing Then
                    Throw New Exception("Transaction not found")
                End If

                ' Calculate new amount paid
                Dim newAmountPaid = transaction.AmountPaid + amount
                Dim newStatus As FineStatus

                ' Determine new status
                If newAmountPaid >= transaction.FineAmount Then
                    newStatus = FineStatus.Paid
                ElseIf newAmountPaid > 0 Then
                    newStatus = FineStatus.PartiallyPaid
                Else
                    newStatus = FineStatus.Pending
                End If

                ' Update transaction
                Dim query = "UPDATE Transactions SET AmountPaid = ?, Status = ?, PaidDate = ? WHERE TransactionID = ?"
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@AmountPaid", newAmountPaid)
                    cmd.Parameters.AddWithValue("@Status", CInt(newStatus))
                    DatabaseHelper.AddParameter(cmd, "@PaidDate", If(newStatus = FineStatus.Paid, CType(DateTime.Now, Object), Nothing))
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID)

                    cmd.ExecuteNonQuery()
                End Using

                DatabaseLogger.LogOperation("TransactionDatabase.PayFine", $"Paid ${amount} on transaction #{transactionID}")
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.PayFine", ex)
            Throw New Exception($"Error paying fine: {ex.Message}", ex)
        End Try
    End Sub

    ' Waive Fine
    Public Sub WaiveFine(transactionID As Integer)
        Try
            Dim query = "UPDATE Transactions SET Status = ?, PaidDate = ? WHERE TransactionID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@Status", CInt(FineStatus.Waived))
                    cmd.Parameters.AddWithValue("@PaidDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Throw New Exception("Transaction not found or already deleted")
                    End If

                    DatabaseLogger.LogOperation("TransactionDatabase.WaiveFine", $"Waived fine for transaction #{transactionID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.WaiveFine", ex)
            Throw New Exception($"Error waiving fine: {ex.Message}", ex)
        End Try
    End Sub

    ' Add Late Fee
    Public Sub AddLateFee(transactionID As Integer, lateFeeAmount As Decimal)
        Try
            Dim query = "UPDATE Transactions SET FineAmount = FineAmount + ? WHERE TransactionID = ? AND IsDeleted = 0"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@LateFee", lateFeeAmount)
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Throw New Exception("Transaction not found or already deleted")
                    End If

                    DatabaseLogger.LogOperation("TransactionDatabase.AddLateFee", $"Added late fee of ${lateFeeAmount} to transaction #{transactionID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.AddLateFee", ex)
            Throw New Exception($"Error adding late fee: {ex.Message}", ex)
        End Try
    End Sub

    ' Soft Delete Transaction
    Public Sub DeleteTransaction(transactionID As Integer)
        Try
            Dim query = "UPDATE Transactions SET IsDeleted = 1 WHERE TransactionID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID)
                    cmd.ExecuteNonQuery()

                    DatabaseLogger.LogOperation("TransactionDatabase.DeleteTransaction", $"Deleted transaction #{transactionID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.DeleteTransaction", ex)
            Throw New Exception($"Error deleting transaction: {ex.Message}", ex)
        End Try
    End Sub

    ' Restore Transaction
    Public Sub RestoreTransaction(transactionID As Integer)
        Try
            Dim query = "UPDATE Transactions SET IsDeleted = 0 WHERE TransactionID = ?"

            _dbConnection.OpenConnection()
            Try
                Using cmd As New OleDbCommand(query, _dbConnection.Connection)
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID)
                    cmd.ExecuteNonQuery()

                    DatabaseLogger.LogOperation("TransactionDatabase.RestoreTransaction", $"Restored transaction #{transactionID}")
                End Using
            Finally
                _dbConnection.CloseConnection()
            End Try
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.RestoreTransaction", ex)
            Throw New Exception($"Error restoring transaction: {ex.Message}", ex)
        End Try
    End Sub

    ' Get Transaction Count
    Public Function GetTransactionCount(Optional includeDeleted As Boolean = False) As Integer
        Try
            Dim query = If(includeDeleted,
                "SELECT COUNT(*) FROM Transactions",
                "SELECT COUNT(*) FROM Transactions WHERE IsDeleted = 0")

            Dim result = _dbConnection.ExecuteScalar(query)
            Return Convert.ToInt32(result)
        Catch ex As Exception
            DatabaseLogger.LogError("TransactionDatabase.GetTransactionCount", ex)
            Return 0
        End Try
    End Function

    ' Helper Method - Map Reader to Transaction
    Private Function MapReaderToTransaction(reader As OleDbDataReader) As Transaction
        Dim accountID = Convert.ToInt32(reader("AccountID"))
        Dim fineAmount = Convert.ToDecimal(reader("FineAmount"))
        Dim reason = reader("Reason").ToString()
        Dim bookID = DatabaseHelper.GetSafeNullableValue(Of Integer)(reader, "BookID")

        Dim transaction As New Transaction(accountID, fineAmount, reason, bookID)
        transaction.TransactionID = Convert.ToInt32(reader("TransactionID"))
        transaction.CreatedDate = Convert.ToDateTime(reader("CreatedDate"))
        transaction.PaidDate = DatabaseHelper.GetSafeNullableValue(Of DateTime)(reader, "PaidDate")
        transaction.IsDeleted = Convert.ToBoolean(reader("IsDeleted"))

        ' Set amount paid and status using reflection
        Dim amountPaidField = GetType(Transaction).GetField("_amountPaid", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        amountPaidField?.SetValue(transaction, Convert.ToDecimal(reader("AmountPaid")))

        Dim statusField = GetType(Transaction).GetField("_status", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        statusField?.SetValue(transaction, CType(Convert.ToInt32(reader("Status")), FineStatus))

        Return transaction
    End Function
End Class