Public Class PersonListView

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim p = New PersonMainListViewPresenter(MainFormListViewView)
        p.Initialise()

    End Sub

End Class