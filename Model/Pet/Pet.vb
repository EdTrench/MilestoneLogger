Public MustInherit Class Pet
    Implements IPlayable, IPhotographable

    Public Overridable Property Name As String

    Public MustOverride Sub MakeSound()

End Class
