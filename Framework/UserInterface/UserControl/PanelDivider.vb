Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DividePanel
    Public Class PanelDivider
        Inherits System.Windows.Forms.Panel
        Private m_borderSide As System.Windows.Forms.Border3DSide
        Private m_border3DStyle As System.Windows.Forms.Border3DStyle
        Public Property BorderSide() As System.Windows.Forms.Border3DSide

            Get
                Return Me.m_borderSide
            End Get
            Set(value As System.Windows.Forms.Border3DSide)
                If Me.m_borderSide <> value Then
                    Me.m_borderSide = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Public Property Border3DStyle() As System.Windows.Forms.Border3DStyle
            Get
                Return Me.m_border3DStyle
            End Get
            Set(value As System.Windows.Forms.Border3DStyle)
                If Me.m_border3DStyle <> value Then
                    Me.m_border3DStyle = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Public Sub New()
            ' Set default values for our control's properties
            Me.m_borderSide = System.Windows.Forms.Border3DSide.All
            Me.m_border3DStyle = System.Windows.Forms.Border3DStyle.Etched
            Me.Height = 3
        End Sub

        Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
            ' allow normal control painting to occur first
            MyBase.OnPaint(e)

            ' add our custom border
            System.Windows.Forms.ControlPaint.DrawBorder3D(e.Graphics, Me.ClientRectangle, Me.m_border3DStyle, Me.m_borderSide)
        End Sub
    End Class

End Namespace

