Public Delegate Sub SaveHandler()
Public Delegate Sub DeleteHandler()

Public Interface IPersonView

    Property Title As String
    Property Firstname As String
    Property Surname As String
    Property DOB As Date

    Event Save As SaveHandler
    Event Remove As DeleteHandler

    Sub ShowPerson()

End Interface
