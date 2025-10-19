Public Enum FineStatus
    Pending = 0
    PartiallyPaid = 1
    Paid = 2
    Waived = 3
End Enum

Public Class Transaction
    Private _transactionID As Integer
    Private _accountID As Integer
    Private _bookID As Integer?
    Private _fineAmount As Decimal
    Private _amountPaid As Decimal
    Private _reason As String
    Private _status As FineStatus
    Private _createdDate As DateTime
    Private _paidDate As DateTime?
    Private _isDeleted As Boolean

    Public Property TransactionID As Integer
        Get
            Return _transactionID
        End Get
        Friend Set(value As Integer)
            _transactionID = value
        End Set
    End Property

    Public Property AccountID As Integer
        Get
            Return _accountID
        End Get
        Friend Set(value As Integer)
            If value <= 0 Then
                Throw New ArgumentException("AccountID must be positive")
            End If
            _accountID = value
        End Set
    End Property

    Public Property BookID As Integer?
        Get
            Return _bookID
        End Get
        Friend Set(value As Integer?)
            _bookID = value
        End Set
    End Property

    Public Property FineAmount As Decimal
        Get
            Return _fineAmount
        End Get
        Friend Set(value As Decimal)
            If value < 0 Then
                Throw New ArgumentException("Fine amount cannot be negative")
            End If
            _fineAmount = value
        End Set
    End Property

    Public Property AmountPaid As Decimal
        Get
            Return _amountPaid
        End Get
        Private Set(value As Decimal)
            If value < 0 Then
                Throw New ArgumentException("Amount paid cannot be negative")
            End If
            If value > _fineAmount Then
                Throw New ArgumentException("Amount paid cannot exceed fine amount")
            End If
            _amountPaid = value
        End Set
    End Property

    Public Property Reason As String
        Get
            Return _reason
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentException("Reason cannot be empty")
            End If
            _reason = value.Trim()
        End Set
    End Property

    Public Property Status As FineStatus
        Get
            Return _status
        End Get
        Private Set(value As FineStatus)
            _status = value
        End Set
    End Property

    Public Property CreatedDate As DateTime
        Get
            Return _createdDate
        End Get
        Friend Set(value As DateTime)
            _createdDate = value
        End Set
    End Property

    Public Property PaidDate As DateTime?
        Get
            Return _paidDate
        End Get
        Private Set(value As DateTime?)
            _paidDate = value
        End Set
    End Property

    Public Property IsDeleted As Boolean
        Get
            Return _isDeleted
        End Get
        Friend Set(value As Boolean)
            _isDeleted = value
        End Set
    End Property

    Public ReadOnly Property RemainingBalance As Decimal
        Get
            Return _fineAmount - _amountPaid
        End Get
    End Property

    Public ReadOnly Property StatusDescription As String
        Get
            Select Case _status
                Case FineStatus.Pending
                    Return "Pending"
                Case FineStatus.PartiallyPaid
                    Return "Partially Paid"
                Case FineStatus.Paid
                    Return "Paid"
                Case FineStatus.Waived
                    Return "Waived"
                Case Else
                    Return "Unknown"
            End Select
        End Get
    End Property

    ' Constructors
    Public Sub New()
    End Sub

    Public Sub New(accountID As Integer, fineAmount As Decimal, reason As String, Optional bookID As Integer? = Nothing)
        If accountID <= 0 Then
            Throw New ArgumentException("AccountID must be positive")
        End If
        If fineAmount <= 0 Then
            Throw New ArgumentException("Fine amount must be positive")
        End If
        If String.IsNullOrWhiteSpace(reason) Then
            Throw New ArgumentException("Reason cannot be empty")
        End If

        _accountID = accountID
        _fineAmount = fineAmount
        _amountPaid = 0
        Me.Reason = reason
        _bookID = bookID
        _status = FineStatus.Pending
        _createdDate = DateTime.Now
        _paidDate = Nothing
        _isDeleted = False
    End Sub

    ' Pay fine (full or partial)
    Public Sub PayFine(amount As Decimal)
        If _isDeleted Then
            Throw New InvalidOperationException("Cannot pay a deleted transaction")
        End If
        If _status = FineStatus.Paid Then
            Throw New InvalidOperationException("Fine is already fully paid")
        End If
        If _status = FineStatus.Waived Then
            Throw New InvalidOperationException("Fine has been waived")
        End If
        If amount <= 0 Then
            Throw New ArgumentException("Payment amount must be positive")
        End If
        If amount > RemainingBalance Then
            Throw New ArgumentException($"Payment amount (${amount:F2}) exceeds remaining balance (${RemainingBalance:F2})")
        End If

        _amountPaid += amount

        ' Update status
        If _amountPaid >= _fineAmount Then
            _status = FineStatus.Paid
            _paidDate = DateTime.Now
        ElseIf _amountPaid > 0 Then
            _status = FineStatus.PartiallyPaid
        End If
    End Sub

    ' Waive fine
    Public Sub WaiveFine()
        If _isDeleted Then
            Throw New InvalidOperationException("Cannot waive a deleted transaction")
        End If
        If _status = FineStatus.Paid Then
            Throw New InvalidOperationException("Cannot waive a fully paid fine")
        End If
        If _status = FineStatus.Waived Then
            Throw New InvalidOperationException("Fine is already waived")
        End If

        _status = FineStatus.Waived
        _paidDate = DateTime.Now
    End Sub

    ' Add late fee
    Public Sub AddLateFee(lateFeeAmount As Decimal)
        If _isDeleted Then
            Throw New InvalidOperationException("Cannot add late fee to deleted transaction")
        End If
        If _status = FineStatus.Paid Then
            Throw New InvalidOperationException("Cannot add late fee to paid transaction")
        End If
        If _status = FineStatus.Waived Then
            Throw New InvalidOperationException("Cannot add late fee to waived transaction")
        End If
        If lateFeeAmount <= 0 Then
            Throw New ArgumentException("Late fee amount must be positive")
        End If

        _fineAmount += lateFeeAmount

        ' Update status if needed
        If _amountPaid > 0 AndAlso _amountPaid < _fineAmount Then
            _status = FineStatus.PartiallyPaid
        End If
    End Sub

    ' Soft delete
    Public Sub Delete()
        If _isDeleted Then
            Throw New InvalidOperationException("Transaction is already deleted")
        End If
        _isDeleted = True
    End Sub

    ' Restore
    Public Sub Restore()
        If Not _isDeleted Then
            Throw New InvalidOperationException("Transaction is not deleted")
        End If
        _isDeleted = False
    End Sub

    Public Overrides Function ToString() As String
        Dim deleteStatus = If(_isDeleted, " [DELETED]", "")
        Return $"Transaction #{TransactionID} - Account {AccountID}: ${AmountPaid:F2}/${FineAmount:F2} ({StatusDescription}){deleteStatus}"
    End Function
End Class