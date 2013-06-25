Public Class PersonListViewBuilder
    Implements IListBuilder

    Private m_itemsList As IList(Of Person)

    Public Sub New(persons As IList(Of Person))
        m_itemsList = persons
    End Sub

    Public Sub BuildListView(TargetControl As ListView) Implements IListBuilder.BuildListView
        TargetControl.Columns.Clear()
        TargetControl.Items.Clear()

        AddlistviewColumns(TargetControl)

        If Not m_itemsList Is Nothing Then
            For Each p In m_itemsList
                TargetControl.Items.Add(AddListViewItem(p))
            Next
        End If
    End Sub

    Private Sub AddlistviewColumns(target As ListView)
        With target.Columns
            .Add("Id", 50)
            .Add("Firstname", 100)
            .Add("Surname", 150)
            .Add("Date Of Birth", 90)
        End With
    End Sub

    Private Function AddListViewItem(person As Person) As ListViewItem
        Dim newListItem As New ListViewItem() With {
            .Name = person.Id.ToString(),
            .Text = CStr(person.Id),
            .ImageKey = "Person",
            .UseItemStyleForSubItems = False
        }

        With newListItem.SubItems
            .Add(person.Firstname)
            .Add(person.Surname).ForeColor = Color.DimGray
            .Add(person.DOB.ToShortDateString()).ForeColor = Color.DimGray
        End With

        Return newListItem
    End Function

    Public Function OrderBy(index As Integer) As String Implements IListBuilder.OrderBy
        Throw New NotImplementedException
    End Function
End Class