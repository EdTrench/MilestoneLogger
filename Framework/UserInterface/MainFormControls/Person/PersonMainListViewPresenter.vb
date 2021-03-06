﻿Public Class PersonMainListViewPresenter
    Inherits MainListViewPresenter(Of Person)

    Private m_personService As PersonService
    Private m_personActionPanelBuilder As PersonActionPanelBuilder

    Public Sub New(mainForm As IMainFormListViewView)
        MyBase.New(mainForm)
        m_personService = New PersonService()
        m_personActionPanelBuilder = New PersonActionPanelBuilder()
    End Sub

    Friend Overrides Function GetDescription() As String
        Return "List of Persons"
    End Function

    Friend Overrides Function GetListBuilder() As IListBuilder
        Return New PersonListViewBuilder(ObjectList)
    End Function

    Friend Overrides Sub SetQuery()
        QueryHelper = New PersonQuery()
    End Sub

    Friend Overrides Function GetActionPanelBuilder() As IActionPanelBuildable
        Return m_personActionPanelBuilder
    End Function

    Friend Overrides Sub OnSelectListItem(ids As System.Collections.Generic.List(Of Integer))
        m_personActionPanelBuilder = New PersonActionPanelBuilder(ids)
        BuildActionPanel()
    End Sub

    'Friend Overrides Function GetFilterPanelBuilder() As IFilterPanelBuildable
    '    Return New PersonFilterPanelBuilder()
    'End Function

    Friend Overrides Function GetIcon() As Image
        Return My.Resources.RefreshSmall
    End Function

    Friend Overrides Function GetTitle() As String
        Return "Persons Title"
    End Function

    Friend Overrides Sub OnOpenListItem(id As Integer)
        m_personService.Open(id)
    End Sub
End Class
