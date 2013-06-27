Public Class PersonView
    Implements IPersonView

    Public Event Save() Implements IPersonView.Save
    Public Event Remove() Implements IPersonView.Remove

    Public Property Title As String Implements IPersonView.Title
        Get
            Return Me.cboTitle.Text
        End Get
        Set(value As String)
            Me.cboTitle.Text = value
        End Set
    End Property

    Public Property DOB As Date Implements IPersonView.DOB
        Get
            Return Me.dtpDOB.Value
        End Get
        Set(value As Date)
            Me.dtpDOB.Value = value
        End Set
    End Property

    Public Property Firstname As String Implements IPersonView.Firstname
        Get
            Return Me.txtFirstname.Text
        End Get
        Set(value As String)
            Me.txtFirstname.Text = value
        End Set
    End Property

    Public Property Surname As String Implements IPersonView.Surname
        Get
            Return Me.txtSurname.Text
        End Get
        Set(value As String)
            Me.txtSurname.Text = value
        End Set
    End Property

    Private Sub RegisterHandlers()
        AddHandler Me.lnkSave.Click,
            AddressOf SaveClick
        AddHandler Me.lnkRemove.Click,
            AddressOf RemoveClick
    End Sub

    Private Sub SaveClick()
        RaiseEvent Save()
    End Sub

    Private Sub RemoveClick()
        RaiseEvent Remove()
    End Sub

    Public Sub ShowPerson() Implements IPersonView.ShowPerson
        Me.RegisterHandlers()
        Me.ShowDialog()
    End Sub

    Public Sub ClosePerson() Implements IPersonView.ClosePerson
        Me.Close()
    End Sub

End Class