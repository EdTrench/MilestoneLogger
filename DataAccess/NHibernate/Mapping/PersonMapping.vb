Public Class PersonMapping
    Inherits FluentNHibernate.Mapping.ClassMap(Of Person)

    Public Sub New()

        Table("dbo.Person")
        Id(Function(x) x.Id).Column("PersonId").GeneratedBy.Identity()
        Map(Function(x) x.Firstname).Column("PersonFirstname")
        Map(Function(x) x.Surname).Column("PersonSurname")
        Map(Function(x) x.DOB).Column("PersonDOB")

    End Sub

End Class