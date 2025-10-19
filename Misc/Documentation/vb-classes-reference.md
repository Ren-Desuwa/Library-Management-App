# Library Management System - Class Reference

## Account.vb

### Type Enum
```
Visitor = 0
User = 1
Librarian = 2
Admin = 3
```

### Account Class
Represents a user account in the library system.

**Properties:**
- `AccountID` (Integer) - Unique account identifier
- `Username` (String) - User's login name (validated: non-empty)
- `PasswordHash` (String) - Hashed password
- `Email` (String) - User's email (validated format)
- `Type` (Type) - Account type enum
- `CreatedDate` (Date) - Account creation timestamp
- `LastLoginDate` (Date?) - Last login timestamp (nullable)
- `FirstName` (String) - User's first name
- `LastName` (String) - User's last name
- `FullName` (String, ReadOnly) - Returns "{FirstName} {LastName}"
- `AccountType` (String, ReadOnly) - Returns string representation of Type

**Constructors:**
- `New()` - Empty constructor
- `New(username As String, password As String, email As String, type As Type)` - Creates account with hashed password

**Methods:**
- `SetPassword(password As String)` - Hashes and sets new password
- `VerifyPassword(password As String) As Boolean` - Verifies password against hash
- `RecordLogin()` - Updates LastLoginDate to now
- `HashPassword(password As String) As String` (Shared) - Returns SHA256 hash as Base64 string
- `ToString() As String` - Returns "{Username} ({Type}) - ID: {AccountID}"

---

## Announcement.vb

### Announcement Class
Represents system announcements with soft-delete support.

**Properties:**
- `AnnouncementID` (Integer) - Unique identifier
- `Title` (String) - Announcement title (max 60 chars, validated)
- `Message` (String) - Announcement content (validated: non-empty)
- `PostedBy` (Integer) - AccountID of creator (validated: > 0)
- `PostedDate` (DateTime) - Creation timestamp
- `IsDeleted` (Boolean) - Soft-delete flag

**Constructors:**
- `New()` - Empty constructor
- `New(title As String, message As String, postedBy As Integer)` - Creates announcement with current timestamp

**Methods:**
- `Edit(newTitle As String, newMessage As String)` - Updates title and message (throws if deleted)
- `Delete()` - Soft-deletes announcement (throws if already deleted)
- `Restore()` - Restores soft-deleted announcement (throws if not deleted)
- `ToString() As String` - Returns "{Title} - Posted on {PostedDate:yyyy-MM-dd} [DELETED]"

---

## Book.vb

### Book Class
Represents a single book with borrowing functionality and history tracking.

**Properties:**
- `BookID` (Integer, ReadOnly) - Unique book identifier (must be positive)
- `Title` (String) - Book title (validated: non-empty)
- `Author` (String) - Book author (validated: non-empty)
- `ISBN` (String) - ISBN number (validated: non-empty)
- `BorrowedBy` (Integer?, ReadOnly) - AccountID of current borrower (nullable)
- `DueDate` (Date?, ReadOnly) - Return due date (nullable)
- `Details` (String) - Additional book information
- `History` (List(Of String), ReadOnly) - Returns copy of history entries
- `IsAvailable` (Boolean, ReadOnly) - True if not borrowed
- `IsOverdue` (Boolean, ReadOnly) - True if has due date and past today

**Constructor:**
- `New(bookID As Integer, title As String, author As String, isbn As String, Optional details As String = "")` - Creates book and adds "Book created" history entry

**Methods:**
- `BorrowBook(memberID As Integer, dueDate As Date)` - Assigns book to member (throws if unavailable or dueDate invalid)
- `ReturnBook()` - Returns book and marks as available (throws if not borrowed)
- `RenewBook(newDueDate As Date)` - Extends due date (throws if not borrowed or invalid date)
- `ToString() As String` - Returns "{Title} by {Author} (ID: {BookID})"

**History Format:** Each entry is timestamped as "yyyy-MM-dd HH:mm:ss - {description}"

---

## Books.vb

### Books Class
Manages a collection of books (series) with search and filtering capabilities.

**Properties:**
- `SeriesTitle` (String) - Collection name (validated: non-empty)
- `BookCount` (Integer, ReadOnly) - Total number of books
- `AvailableCount` (Integer, ReadOnly) - Number of available books
- `BorrowedCount` (Integer, ReadOnly) - Number of borrowed books

**Constructor:**
- `New(seriesTitle As String)` - Creates empty collection with title

**Methods:**
- `AddBook(book As Book)` - Adds book (throws if null or duplicate BookID)
- `RemoveBook(bookID As Integer) As Boolean` - Removes book if available (throws if borrowed), returns success
- `GetBookByID(bookID As Integer) As Book` - Returns book or Nothing
- `GetAllBooks() As List(Of Book)` - Returns copy of all books
- `GetAvailableBooks() As List(Of Book)` - Returns available books
- `GetBorrowedBooks() As List(Of Book)` - Returns borrowed books
- `GetOverdueBooks() As List(Of Book)` - Returns overdue books
- `SearchByTitle(searchTerm As String) As List(Of Book)` - Case-insensitive title search
- `SearchByAuthor(searchTerm As String) As List(Of Book)` - Case-insensitive author search
- `GetBooksBorrowedByMember(memberID As Integer) As List(Of Book)` - Returns books borrowed by specific member
- `ToString() As String` - Returns "{SeriesTitle} ({BookCount} books, {AvailableCount} available)"

---

## Log.vb

### LogType Enum
```
Login = 0, Logout = 1
BookAdded = 10, BookEdited = 11, BookDeleted = 12, BookMarkedLost = 13
BookBorrowed = 14, BookReturned = 15, BookRenewed = 16
AccountCreated = 20, AccountEdited = 21, AccountDeleted = 22, AccountVerified = 23
FineAdded = 30, FinePaid = 31, FineWaived = 32
AnnouncementCreated = 40, AnnouncementEdited = 41, AnnouncementDeleted = 42
NotificationSent = 50, NotificationDeleted = 51
SystemError = 60, DatabaseBackup = 61, SystemMaintenance = 62
```

### TargetTableType Enum
```
None = 0, Account = 1, Book = 2, BorrowedBook = 3
Transaction = 4, Announcement = 5, Notification = 6
```

### Log Class
Immutable audit log entries with soft-delete support.

**Properties (All ReadOnly except LogID and IsDeleted):**
- `LogID` (Integer) - Unique log identifier
- `LogType` (LogType) - Type of action logged
- `AccountID` (Integer?) - Actor's account ID (nullable for system actions)
- `TargetID` (Integer?) - ID of affected record (nullable)
- `TargetTable` (TargetTableType) - Table containing target record
- `Description` (String) - Log entry description
- `Timestamp` (DateTime) - When action occurred
- `IsDeleted` (Boolean) - Soft-delete flag
- `LogTypeDescription` (String, ReadOnly) - Human-readable log type
- `TargetTableDescription` (String, ReadOnly) - Human-readable table name

**Constructors:**
- `New()` - Empty constructor
- `New(logType As LogType, description As String, Optional accountID As Integer? = Nothing, Optional targetID As Integer? = Nothing, Optional targetTable As TargetTableType = TargetTableType.None)` - Creates log with current timestamp

**Factory Methods (All Shared):**
- `CreateLoginLog(accountID As Integer) As Log`
- `CreateLogoutLog(accountID As Integer) As Log`
- `CreateBookBorrowedLog(accountID As Integer, borrowID As Integer, bookTitle As String) As Log`
- `CreateBookReturnedLog(accountID As Integer, borrowID As Integer, bookTitle As String) As Log`
- `CreateBookAddedLog(accountID As Integer, bookID As Integer, bookTitle As String) As Log`
- `CreateAccountCreatedLog(creatorAccountID As Integer?, newAccountID As Integer, username As String) As Log`
- `CreateFineAddedLog(accountID As Integer, transactionID As Integer, amount As Decimal, reason As String) As Log`

**Methods:**
- `Delete()` - Soft-deletes log (throws if already deleted)
- `Restore()` - Restores soft-deleted log (throws if not deleted)
- `CreateCorrectedLog(newDescription As String) As Log` - Creates new log with "[CORRECTED]" prefix
- `ToString() As String` - Returns "[{Timestamp}] {LogType} by {Account} -> {Target}: {Description} [DELETED]"

### LogQuery Class
Helper class for querying log collections.

**Constructor:**
- `New(logs As List(Of Log))` - Initializes with log list

**Methods (All exclude IsDeleted logs):**
- `GetLogsByAccount(accountID As Integer) As List(Of Log)` - Logs by specific account
- `GetLogsByType(logType As LogType) As List(Of Log)` - Logs by type
- `GetLogsByDateRange(startDate As DateTime, endDate As DateTime) As List(Of Log)` - Logs in date range
- `GetLogsByTarget(targetTable As TargetTableType, targetID As Integer) As List(Of Log)` - Logs for specific target
- `GetRecentLogs(count As Integer) As List(Of Log)` - Most recent N logs
- `GetTodaysLogs() As List(Of Log)` - Today's logs
- `SearchLogs(searchTerm As String) As List(Of Log)` - Case-insensitive description search

---

## Notification.vb

### NotificationType Enum
```
BookReminder = 0, OverdueReminder = 1
AdminNotice = 2, LibrarianNotice = 3, SystemNotice = 4
BookAvailable = 5, AccountUpdate = 6, FineNotice = 7
```

### Notification Class
Represents user notifications with read/unread tracking.

**Properties:**
- `NotificationID` (Integer) - Unique identifier
- `AccountID` (Integer?) - Recipient account ID (nullable for broadcasts)
- `Title` (String) - Notification title (max 100 chars, validated)
- `Content` (String) - Notification content (validated: non-empty)
- `CreatedBy` (Integer?) - Creator's account ID (-1 or Nothing = system)
- `NotifType` (NotificationType) - Notification type enum
- `Attachments` (String) - Attachment data or URLs
- `NotifDate` (DateTime) - Creation timestamp
- `IsRead` (Boolean) - Read status flag
- `IsDeleted` (Boolean) - Soft-delete flag
- `IsSystemNotification` (Boolean, ReadOnly) - True if CreatedBy is Nothing or -1
- `NotificationTypeDescription` (String, ReadOnly) - Human-readable type

**Constructors:**
- `New()` - Empty constructor
- `New(accountID As Integer?, title As String, content As String, createdBy As Integer?, notifType As NotificationType)` - Creates notification with current timestamp

**Factory Method:**
- `CreateSystemNotification(accountID As Integer?, title As String, content As String, notifType As NotificationType) As Notification` (Shared) - Creates system notification (CreatedBy = -1)

**Methods:**
- `MarkAsRead()` - Sets IsRead to True (throws if deleted)
- `MarkAsUnread()` - Sets IsRead to False (throws if deleted)
- `Delete()` - Soft-deletes notification (throws if already deleted)
- `Restore()` - Restores soft-deleted notification (throws if not deleted)
- `ToString() As String` - Returns "[{Type}] {Title} - {Read/Unread} ({NotifDate}) [DELETED]"

---

## Transaction.vb

### FineStatus Enum
```
Pending = 0
PartiallyPaid = 1
Paid = 2
Waived = 3
```

### Transaction Class
Represents financial transactions (fines) with payment tracking.

**Properties:**
- `TransactionID` (Integer) - Unique identifier
- `AccountID` (Integer) - Account owing fine (must be positive)
- `BookID` (Integer?) - Related book ID (nullable)
- `FineAmount` (Decimal) - Total fine amount (non-negative)
- `AmountPaid` (Decimal) - Amount paid so far (non-negative, ≤ FineAmount)
- `Reason` (String) - Fine description (validated: non-empty)
- `Status` (FineStatus) - Payment status enum
- `CreatedDate` (DateTime) - Fine creation timestamp
- `PaidDate` (DateTime?) - When fully paid or waived (nullable)
- `IsDeleted` (Boolean) - Soft-delete flag
- `RemainingBalance` (Decimal, ReadOnly) - Returns FineAmount - AmountPaid
- `StatusDescription` (String, ReadOnly) - Human-readable status

**Constructors:**
- `New()` - Empty constructor
- `New(accountID As Integer, fineAmount As Decimal, reason As String, Optional bookID As Integer? = Nothing)` - Creates pending fine with current timestamp

**Methods:**
- `PayFine(amount As Decimal)` - Adds payment, updates status (throws if deleted/paid/waived or amount exceeds balance)
- `WaiveFine()` - Waives remaining balance, sets PaidDate (throws if deleted/paid/already waived)
- `AddLateFee(lateFeeAmount As Decimal)` - Increases FineAmount (throws if deleted/paid/waived or amount ≤ 0)
- `Delete()` - Soft-deletes transaction (throws if already deleted)
- `Restore()` - Restores soft-deleted transaction (throws if not deleted)
- `ToString() As String` - Returns "Transaction #{ID} - Account {AccountID}: ${Paid}/{Total} ({Status}) [DELETED]"

---

## Common Patterns

### Validation
- All classes validate inputs in property setters
- String properties are trimmed automatically
- Most throw `ArgumentException` for invalid inputs
- ID properties typically require positive values

### Soft Deletes
- Most classes support soft-delete via `IsDeleted` property
- `Delete()` and `Restore()` methods throw `InvalidOperationException` if called inappropriately
- Query methods typically filter out deleted items

### Timestamps
- Creation timestamps are set automatically to `DateTime.Now` or `Date.Now`
- Timestamp properties use `DateTime` for time precision, `Date` for date-only values

### Immutability
- `Log` class is immutable after creation (properties are ReadOnly)
- Most ID properties have `Friend Set` to prevent external modification
- Collections returned are copies to prevent external modification