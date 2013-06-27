Public Interface IListViewQueryable
    Function CreateListViewQuery(currentNHibernateSession As NHibernate.ISession) As NHibernate.ICriteria
    Function QuickSearchQuery(CurrentCriteria As NHibernate.ICriteria, QuickSearch As String) As NHibernate.ICriteria
    Function CriteriaCount(CurrentCriteria As NHibernate.ICriteria) As Integer
End Interface
