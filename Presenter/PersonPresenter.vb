Public Class PersonPresenter

    Private WithEvents m_currentView As IPersonView
    Private m_currentPerson As Person
    Private m_service As PersonService

    Public Sub New(person As Person, view As IPersonView, session As NHibernate.ISession)

        m_currentView = view
        m_currentPerson = person
        m_service = New PersonService()

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
        If m_currentPerson.Id = 0 Then
            m_service.Save(m_currentPerson)
        Else
            m_service.Update(m_currentPerson)
        End If
    End Sub

    Private Sub RemoveModel()

        MapViewToModel()
        m_service.Remove(m_currentPerson)

    End Sub

End Class