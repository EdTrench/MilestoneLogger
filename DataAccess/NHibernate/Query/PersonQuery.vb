Imports NHibernate.Criterion

Public Class PersonQuery

    Function QuickSearchQuery(session As NHibernate.ISession, searchString As String) As NHibernate.ICriteria

        Dim OrStatement = NHibernate.Criterion.Expression.Disjunction()

        OrStatement.Add(Expression.Like(Projections.Property(Of Person)(Function(x) x.Firstname),
                                        searchString,
                                        NHibernate.Criterion.MatchMode.Anywhere))

        OrStatement.Add(Expression.Like(Projections.Property(Of Person)(Function(x) x.Surname),
                                        searchString,
                                        NHibernate.Criterion.MatchMode.Anywhere))

        If IsDate(searchString) Then
            OrStatement.Add(Expression.Eq(Projections.Property(Of Person)(Function(x) x.DOB), Date.Parse(searchString)))
        End If

        Return CreateQuery(session).Add(OrStatement)

    End Function

    Public Shared Function CreateQuery(session As Global.NHibernate.ISession) As NHibernate.ICriteria

        Return session.CreateCriteria(Of Person)()

    End Function

    Public Shared Function GetById(id As Integer, session As Global.NHibernate.ISession) As NHibernate.IQueryOver(Of Person)

        Return session.QueryOver(Of Person).Where(Function(x) x.Id = id)

    End Function

    Public Shared Function CountAll(session As Global.NHibernate.ISession) As Integer

        Return CreateQuery(session).SetProjection(NHibernate.Criterion.Projections.RowCount).FutureValue(Of Integer).Value

    End Function

    Public Sub Update(person As Person, session As Global.NHibernate.ISession)

        session.Update(person)

    End Sub

    Public Sub Save(person As Person, session As Global.NHibernate.ISession)

        session.Save(person)

    End Sub

    Public Sub Remove(person As Person, session As Global.NHibernate.ISession)

        session.Delete(person)

    End Sub

End Class