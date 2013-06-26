Public Class PersonService

    Public Sub Save(person As Person)

        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            Using transaction = session.BeginTransaction
                Dim q = New PersonQuery()
                q.Save(person, session)
                transaction.Commit()
            End Using
        End Using

    End Sub

    Public Sub Remove(person As Person)

        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            Using transaction = session.BeginTransaction
                Dim q = New PersonQuery
                q.Remove(person, session)
                transaction.Commit()
            End Using
        End Using

    End Sub

    Public Sub Remove(id As Integer)

        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            Using transaction = session.BeginTransaction
                Dim p = PersonQuery.GetById(id, session).SingleOrDefault()
                Dim q = New PersonQuery
                q.Remove(p, session)
                transaction.Commit()
            End Using
        End Using

    End Sub

    Public Sub Create()
        Throw New NotImplementedException
    End Sub

    Public Sub Open(id As Integer)

        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            Dim p = PersonQuery.GetById(id, session).SingleOrDefault()
            Dim pp = New PersonPresenter(p, New PersonView, session)
            pp.Initialise()
        End Using
    End Sub

End Class