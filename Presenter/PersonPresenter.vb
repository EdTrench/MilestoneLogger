Public Class PersonPresenter

    Private WithEvents m_currentView As IPersonView
    Private m_currentPerson As Person
    Private m_service As PersonService
    Private m_session As NHibernate.ISession

    Public Sub New(person As Person, view As IPersonView, session As NHibernate.ISession)

        m_currentView = view
        m_currentPerson = person
        m_service = New PersonService()
        m_session = session

    End Sub

    Public Sub Initialise()
        AddEventHandlers()
        MapModelToView()
        m_currentView.ShowPerson()
    End Sub

    Private Sub AddEventHandlers()

        AddHandler m_currentView.Save,
            AddressOf SaveModel
        AddHandler m_currentView.Remove,
            AddressOf RemoveModel

    End Sub

    Private Sub MapModelToView()

        m_currentView.Title = m_currentPerson.Title
        m_currentView.Firstname = m_currentPerson.Firstname
        m_currentView.Surname = m_currentPerson.Surname
        m_currentView.DOB = m_currentPerson.DOB

    End Sub

    Private Sub MapViewToModel()

        m_currentPerson.Title = m_currentView.Title
        m_currentPerson.Firstname = m_currentView.Firstname
        m_currentPerson.Surname = m_currentView.Surname
        m_currentPerson.DOB = m_currentView.DOB

    End Sub

    Private Sub SaveModel()

        MapViewToModel()
        m_service.Save(m_currentPerson, m_session)

    End Sub

    Private Sub RemoveModel()

        MapViewToModel()
        m_service.Remove(m_currentPerson, m_session)

    End Sub

End Class