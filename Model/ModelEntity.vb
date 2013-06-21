Public MustInherit Class ModelEntity
#Region "Identity"
    Public Overridable ReadOnly Property UnallocatedId As Integer
        Get
            Return 0
        End Get
    End Property

    Private m_id As Integer = UnallocatedId
    Public Overridable Property Id As Integer
        Get
            Return m_id
        End Get
        Protected Friend Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property

#End Region

#Region "HashCode Generation"
    Private m_oldHashCode As Nullable(Of Integer)
    Public Overrides Function GetHashCode() As Integer

        If m_oldHashCode.HasValue Then Return m_oldHashCode.Value

        If Me.Id = UnallocatedId Then
            'This object is new
            m_oldHashCode = MyBase.GetHashCode()
            Return m_oldHashCode.Value
        End If

        Return Me.Id.GetHashCode()

    End Function
#End Region

End Class

Public MustInherit Class ModelEntity(Of T As ModelEntity(Of T))
    Inherits ModelEntity

#Region "Equality"
    Public Overrides Function Equals(obj As Object) As Boolean
        Dim other As T = TryCast(obj, T)

        If other Is Nothing Then Return False

        If (Me.Id = UnallocatedId) AndAlso (other.Id = UnallocatedId) Then
            'Both new objects without an Id yet. Same reference?
            Return ReferenceEquals(Me, other)
        End If

        Return Me.Id = other.Id

    End Function

    Public Shared Operator =(lhs As ModelEntity(Of T), rhs As ModelEntity(Of T)) As Boolean
        Return Equals(lhs, rhs)
    End Operator

    Public Shared Operator <>(lhs As ModelEntity(Of T), rhs As ModelEntity(Of T)) As Boolean
        Return Not Equals(lhs, rhs)
    End Operator
#End Region

End Class
