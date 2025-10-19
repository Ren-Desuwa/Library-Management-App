Public Class LibraryService
    Private _db As LibraryDatabase

    Public Sub New()
        _db = LibraryDatabase.Instance
    End Sub

    ' Borrow a book
    Public Function BorrowBook(accountID As Integer, copyID As Integer) As (Success As Boolean, Message As String)
        Try
            ' Get the book copy
            Dim copy = _db.BookCopyDAO.GetById(copyID)
            If copy Is Nothing Then
                Return (False, "Book copy not found.")
            End If

            ' Check if copy is available
            If Not copy.CanBeBorrowed() Then
                Return (False, "This book copy is not available for borrowing.")
            End If

            ' Create transaction
            Dim transaction As New Transaction With {
                .AccountID = accountID,
                .CopyID = copyID,
                .TransactionType = "Borrow",
                .DateBorrowed = DateTime.Now,
                .DateDue = DateTime.Now.AddDays(14),
                .Status = "Active",
                .Fine = 0
            }

            Dim transactionID = _db.TransactionDAO.Insert(transaction)

            ' Update copy status
            copy.UpdateStatus("Borrowed")
            _db.BookCopyDAO.Update(copy)

            ' Update book available copies
            Dim book = _db.BookDAO.GetById(copy.BookID)
            book.AvailableCopies -= 1
            _db.BookDAO.Update(book)

            ' Create notification
            Dim notification = notification.CreateDueReminder(accountID, transactionID, transaction.DateDue.Value)
            _db.NotificationDAO.Insert(notification)

            ' Log the action
            Dim log = log.RecordAction(accountID, "BORROW_BOOK", $"Borrowed book copy {copyID}")
            _db.LogDAO.Insert(log)

            Return (True, "Book borrowed successfully!")
        Catch ex As Exception
            Return (False, $"Error borrowing book: {ex.Message}")
        End Try
    End Function

    ' Return a book
    Public Function ReturnBook(transactionID As Integer) As (Success As Boolean, Message As String)
        Try
            ' Get the transaction
            Dim transaction = _db.TransactionDAO.GetById(transactionID)
            If transaction Is Nothing Then
                Return (False, "Transaction not found.")
            End If

            If transaction.Status <> "Active" Then
                Return (False, "This transaction is not active.")
            End If

            ' Calculate fine if overdue
            transaction.DateReturned = DateTime.Now
            If transaction.IsOverdue() Then
                transaction.Fine = transaction.CalculateFine()
                transaction.Status = "Completed-Overdue"
            Else
                transaction.Status = "Completed"
            End If

            _db.TransactionDAO.Update(transaction)

            ' Update copy status
            Dim copy = _db.BookCopyDAO.GetById(transaction.CopyID)
            copy.UpdateStatus("Available")
            _db.BookCopyDAO.Update(copy)

            ' Update book available copies
            Dim book = _db.BookDAO.GetById(copy.BookID)
            book.AvailableCopies += 1
            _db.BookDAO.Update(book)

            ' Create notification if there was a fine
            If transaction.Fine > 0 Then
                Dim notification As New Notification With {
                    .AccountID = transaction.AccountID,
                    .TransactionID = transactionID,
                    .Message = $"Book returned with late fee: ${transaction.Fine:F2}",
                    .NotificationType = "Overdue"
                }
                _db.NotificationDAO.Insert(notification)
            End If

            ' Log the action
            Dim log = log.RecordAction(transaction.AccountID, "RETURN_BOOK", $"Returned book copy {transaction.CopyID}")
            _db.LogDAO.Insert(log)

            Dim message As String = "Book returned successfully!"
            If transaction.Fine > 0 Then
                message &= $" Late fee: ${transaction.Fine:F2}"
            End If

            Return (True, message)
        Catch ex As Exception
            Return (False, $"Error returning book: {ex.Message}")
        End Try
    End Function

    ' Search for books
    Public Function SearchBooks(searchTerm As String) As List(Of Book)
        Return _db.BookDAO.Search(searchTerm)
    End Function

    ' Get account's active transactions
    Public Function GetActiveTransactions(accountID As Integer) As List(Of Transaction)
        Dim allTransactions = _db.TransactionDAO.GetByAccountID(accountID)
        Return allTransactions.Where(Function(t) t.Status = "Active").ToList()
    End Function

    ' Check for overdue books and send notifications
    Public Sub CheckOverdueBooks()
        ' This would typically be called by a scheduled task
        ' Implementation would query all active transactions and check due dates
    End Sub
End Class