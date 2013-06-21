Public Class PersonMainListViewPresenter
    Inherits MainListViewPresenter(Of Person)

    Private m_personQuery As PersonQuery

    Public Sub New(mainForm As IMainFormListViewView)
        MyBase.New(mainForm)
    End Sub

    Friend Overrides ReadOnly Property Description As String
        Get
            Return "List of Persons"
        End Get
    End Property

    Friend Overrides Function GetListBuilder() As IListBuilder
        Return New PersonListViewBuilder(ObjectList)
    End Function

    Friend Overrides Function GetObjectList() As IList(Of Person)
        Return QueryCiteria.List(Of Person)()
    End Function

    Friend Overrides Function QuickSearchQuery(searchString As String) As NHibernate.ICriteria
        Return m_personQuery.QuickSearchQuery(session, searchString)
    End Function

    Friend Overrides Function RefreshQuery() As NHibernate.ICriteria
        Return m_personQuery.CreateQuery(session)
    End Function

    Friend Overrides Function SetObjectCount() As Integer
        Return m_personQuery.CountAll(session)
    End Function

    Friend Overrides Sub SetQuery()
        m_personQuery = New PersonQuery()
    End Sub

    Friend Overrides ReadOnly Property Title As String
        Get
            Return "Persons"
        End Get
    End Property

    Friend Overrides Function SetDescription() As String
        Return "Persons"
    End Function

    Friend Overrides Function SetIcon() As Image
        Return My.Resources.RefreshSmall
    End Function

    Friend Overrides Function SetTitle() As String
        Return "Persons Title"
    End Function

    Friend Overrides Function GetActionPanelBuilder() As IActionPanelBuildable
        Return New PersonActionPanelBuilder()
    End Function
End Class
