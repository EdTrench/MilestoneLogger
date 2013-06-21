Public Enum ListViewSortMode
    None
    Group
    Sort
End Enum

Public Enum ListViewGroupMode
    None
    Collapsed
    Expanded
End Enum

Public Class ExtendedListView

    Public Delegate Sub ColumnRightClickEventHandler(sender As Object, column As ColumnHeader)
    Public Event ColumnRightClick As ColumnRightClickEventHandler

    Private m_mouseIsOverItemsArea As Boolean = False
    Protected Overrides Sub OnMouseEnter(e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        m_mouseIsOverItemsArea = True
    End Sub

    Protected Overrides Sub OnMouseLeave(e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        m_mouseIsOverItemsArea = False
    End Sub

    Private Sub ExtendedListView_HandleCreated(sender As Object, e As System.EventArgs) Handles MyBase.HandleCreated
        SetWindowTheme(Me.Handle, "Explorer", Nothing)
    End Sub

    <DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_CONTEXTMENU As Integer = &H7B

        Select Case m.Msg
            Case Win32.WM_LBUTTONUP
                MyClass.DefWndProc(m)

            Case WM_CONTEXTMENU
                If Not m_mouseIsOverItemsArea Then
                    Dim p = MyBase.PointToClient(MousePosition)

                    Dim totalColumnWidth As Integer
                    For Each c As ColumnHeader In MyBase.Columns
                        totalColumnWidth += c.Width
                        If p.X < totalColumnWidth Then
                            RaiseEvent ColumnRightClick(Me, c)
                            Exit For
                        End If
                    Next

                End If
        End Select

        MyBase.WndProc(m)

    End Sub

    Public Property SortMode As ListViewSortMode
    Public Property GroupMode As ListViewGroupMode = ListViewGroupMode.Expanded

    Private m_currentSort As SortOrder
    Private m_currentSortColumn As Integer = -1

    Private Sub ExtendedListView_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles MyBase.ColumnClick
        Dim newGroup As ListViewGroup
        Dim imageKey As String = String.Empty

        If SortMode <> ListViewSortMode.None Then
            Try
                Cursor.Current = Cursors.WaitCursor
                'Prevent listview repainting during update
                MyBase.BeginUpdate()

                'Clear any existing groups.
                MyBase.Groups.Clear()

                'Check if it's the same column, if so invert the sort order
                If e.Column = m_currentSortColumn Then
                    If m_currentSort = SortOrder.Ascending Then
                        m_currentSort = SortOrder.Descending
                        imageKey = "SortDescending"

                    Else
                        m_currentSort = SortOrder.Ascending
                        imageKey = "SortAscending"
                    End If

                Else
                    'Different column, or first sort. Assume ascending sort.
                    If m_currentSort = SortOrder.None Then
                        m_currentSort = SortOrder.Descending
                        imageKey = "SortDescending"

                    Else
                        'Invert
                        If m_currentSort = SortOrder.Ascending Then
                            m_currentSort = SortOrder.Descending
                            imageKey = "SortDescending"

                        Else
                            m_currentSort = SortOrder.Ascending
                            imageKey = "SortAscending"
                        End If
                    End If

                    'Clear column image of existing sorted column
                    If m_currentSortColumn >= 0 AndAlso m_currentSortColumn < MyBase.Columns.Count Then
                        MyBase.Columns(m_currentSortColumn).ImageKey = Nothing
                        MyBase.Columns(m_currentSortColumn).TextAlign = MyBase.Columns(m_currentSortColumn).TextAlign
                    End If
                End If

                'Set the column image
                MyBase.Columns(e.Column).ImageKey = imageKey

                If SortMode = ListViewSortMode.Group Then
                    'Group
                    Dim items = From i In MyBase.Items
                                Group By groupedValue = DirectCast(i, ListViewItem).SubItems(e.Column).Text Into Group

                    'Sort
                    MyBase.ListViewItemSorter = DirectCast(New ListViewItemComparer(e.Column, m_currentSort), IComparer)

                    For Each i In items
                        newGroup = MyBase.Groups.Add(i.groupedValue, i.groupedValue)
                        MyBase.Groups.Add(newGroup)

                        If GroupMode = ListViewGroupMode.Collapsed Then
                            CreateCollapsibleGroup(newGroup, True)

                        ElseIf GroupMode = ListViewGroupMode.Expanded Then
                            CreateCollapsibleGroup(newGroup, False)
                        End If

                        For Each g As ListViewItem In i.Group
                            g.Group = newGroup
                        Next
                    Next

                Else
                    'Sort
                    MyBase.ListViewItemSorter = DirectCast(New ListViewItemComparer(e.Column, m_currentSort), IComparer)
                End If

                'Cache the sorted column
                m_currentSortColumn = e.Column

            Finally
                'Allow listview to repaint
                MyBase.EndUpdate()
                Cursor.Current = Cursors.Default
            End Try
        End If



    End Sub

    Public Sub CreateCollapsibleGroup(ByVal group As ListViewGroup, ByVal collapsed As Boolean)
        Dim groupInfo = New Win32.LVGROUP()

        Dim p = group.GetType() _
                     .GetProperty("ID", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)

        Dim groupId As Object = p.GetValue(group, Nothing)

        With groupInfo
            .CbSize = Runtime.InteropServices.Marshal.SizeOf(groupInfo)
            .State = Win32.ListViewGroupState.Collapsible

            If collapsed Then
                .State = .State Or Win32.ListViewGroupState.Collapsed
            End If

            .Mask = Win32.ListViewGroupMask.State
            .IGroupId = CInt(groupId)
        End With

        Win32.SendMessage(MyBase.Handle, Win32.LVM_SETGROUPINFO, New IntPtr(CInt(groupId)), groupInfo)

    End Sub
End Class
