Public Class PersonService

    Public Sub Save(id As Integer)

        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            Using transaction = session.BeginTransaction
                Dim q = New PersonQuery()
                Dim p = q.GetById(id, session)
                q.Save(p, session)
                transaction.Commit()
            End Using
        End Using

    End Sub

    Public Sub Remove(id As Integer)

        Using session As NHibernate.ISession = SessionManager.Factory.OpenSession()
            Using transaction = session.BeginTransaction
                Dim q = New PersonQuery
                Dim p = q.GetById(id, session)
                q.Remove(p, session)
                transaction.Commit()
            End Using
        End Using

    End Sub

    Public Sub Create()
        Throw New NotImplementedException
    End Sub

    Public Sub Open(id As Integer)
        Throw New NotImplementedException
    End Sub



End Class