Public Class PersonQuery
    Implements IListViewQueryable

    Public Function QuickSearchQuery(currentCriteria As NHibernate.ICriteria, searchString As String) As NHibernate.ICriteria Implements IListViewQueryable.QuickSearchQuery

        Dim OrStatement = NHibernate.Criterion.Expression.Disjunction()

        OrStatement.Add(NHibernate.Criterion.Expression.Like(NHibernate.Criterion.Projections.Property(Of Person)(Function(x) x.Firstname),
                                        searchString,
                                        NHibernate.Criterion.MatchMode.Anywhere))

        OrStatement.Add(NHibernate.Criterion.Expression.Like(NHibernate.Criterion.Projections.Property(Of Person)(Function(x) x.Surname),
                                        searchString,
                                        NHibernate.Criterion.MatchMode.Anywhere))

        If IsDate(searchString) Then
            OrStatement.Add(NHibernate.Criterion.Expression.Eq(NHibernate.Criterion.Projections.Property(Of Person)(Function(x) x.DOB), Date.Parse(searchString)))
        End If

        Return currentCriteria.Add(OrStatement)

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

    Public Function CriteriaCount(currentCriteria As NHibernate.ICriteria) As Integer Implements IListViewQueryable.CriteriaCount
        Return currentCriteria.SetProjection(NHibernate.Criterion.Projections.RowCount).FutureValue(Of Int32).Value
    End Function

    Public Function CreateListViewQuery(currentNHibernateSession As NHibernate.ISession) As NHibernate.ICriteria Implements IListViewQueryable.CreateListViewQuery
        Return currentNHibernateSession.CreateCriteria(Of Person)()
        '_
        '.SetFetchMode("Address", NHibernate.FetchMode.Join) _
        '.SetFetchMode("Address.County", NHibernate.FetchMode.Join) _
        '.SetFetchMode("Region", NHibernate.FetchMode.Join)
    End Function
End Class