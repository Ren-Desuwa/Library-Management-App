Imports System.Linq

Public Class Log
    Public Property LogID As Integer
    Public Property AccountID As Integer?
    Public Property Action As String
    Public Property Timestamp As DateTime
    Public Property Details As String
    Public Property IPAddress As String
    Public Property Severity As String ' "Info", "Warning", "Error"

    Public Sub New()
        Timestamp = DateTime.Now
        Severity = "Info"
    End Sub

    ' Record a new action
    Public Shared Function RecordAction(accountID As Integer?, action As String, details As String, Optional severity As String = "Info") As Log
        Return New Log With {
            .AccountID = accountID,
            .Action = action,
            .Details = details,
            .Severity = severity
        }
    End Function
End Class