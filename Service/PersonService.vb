Public Class PersonService

    Public Sub Save(person As Person, session As NHibernate.ISession)

        Using transaction = session.BeginTransaction
            Dim q = New PersonQuery()
            q.Save(person, session)
            transaction.Commit()
        End Using

    End Sub

    Public Sub Remove(person As Person, session As NHibernate.ISession)

        Using transaction = session.BeginTransaction
            Dim q = New PersonQuery
            q.Remove(person, session)
            transaction.Commit()
        End Using

    End Sub

End Class