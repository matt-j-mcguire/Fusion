

Public Class Wire
    Implements iBaseItem

    Private _owner As Page
    Private _wireName As String
    Private m_UIElement As Wire_UI

    ''' <summary>
    ''' loads up the connection for the wire
    ''' </summary>
    ''' <param name="nd">xml information node</param>
    ''' <param name="Owner">the page owner</param>
    ''' <remarks></remarks>
    Public Sub New(nd As XmlNode, Owner As Page)
        node = nd
        _owner = Owner
        [To] = New List(Of Connector)

        Dim c As Connector = Owner.GetConnector(XHelper.Get(node, "from", ""))
        Try
            c.Connect(Me)
            Dim cnt As Integer = XHelper.Get(node, "to_cnt", 1)
            For xloop As Integer = 0 To cnt - 1
                c = Owner.GetConnector(XHelper.Get(node, "to" & xloop, ""))
                c.Connect(Me)
            Next
            _wireName = XHelper.Get(node, "Name", "")
        Catch ex As Exception
        End Try

    End Sub

 

    ''' <summary>
    ''' for creating a brand new wire with 1 input and 1 output
    ''' </summary>
    ''' <param name="nd">new node to save information to</param>
    ''' <param name="Owner">the page owning this item</param>
    ''' <param name="cFrom">the connector it comes from</param>
    ''' <param name="cTo">the connector it goes to</param>
    ''' <remarks></remarks>
    Public Sub New(nd As XmlNode, Owner As Page, cFrom As Connector, cTo As Connector)
        node = nd
        _owner = Owner
        [To] = New List(Of Connector)
        cFrom.Connect(Me)
        cTo.Connect(Me)
    End Sub

    ''' <summary>
    ''' saves the connections back to file
    ''' </summary>
    ''' <remarks>saved like longNumber.connectorName</remarks>
    Public Sub Save() Implements iBaseItem.Save
        If Me.From IsNot Nothing Then
            XHelper.Set(node, "from", Me.From.SaveString)
        End If

        XHelper.Set(node, "to_cnt", Me.To.Count)
        For xloop As Integer = 0 To Me.To.Count - 1
            XHelper.Set(node, "to" & xloop, Me.To(xloop).SaveString)
        Next
        XHelper.Set(node, "Name", _wireName)

    End Sub

    ''' <summary>
    ''' after loading if the wire is a valid one or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property isValid() As Boolean
        Get
            Return (Me.From IsNot Nothing AndAlso Me.To.Count > 0)
        End Get
    End Property

    Public Property [From] As Connector

    Public Property [To] As List(Of Connector)


    ''' <summary>
    ''' update copies the incomming value to the out value(s)
    ''' </summary>
    ''' <returns>true if allowed to process any other block down the chain</returns>
    ''' <remarks></remarks>
    Public Function Update() As Boolean
        'default on first pass is no flag so the 
        'return value should be true, but if it
        'has been flagged before then default is
        'false unless the input "from" has changed
        'value then the result is true
        Dim ret As Boolean = Not Flagged
        If Not Flagged Then Flagged = True


        For xloop As Integer = 0 To [To].Count - 1
            If Flagged AndAlso [From].Value <> [To](xloop).Value Then
                ret = True
                [To](xloop).Value = [From].Value
            End If
        Next
        Return ret
    End Function

    ''' <summary>
    ''' sets the flag if the update has already been called on
    ''' this pass
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Flagged() As Boolean

    Public Function GetUI() As i_UIelement Implements iBaseItem.GetUI
        If m_UIElement IsNot Nothing Then
            Return m_UIElement
        Else
            Dim ex As New Wire_UI(Me)
            m_UIElement = ex
            Return ex
        End If
    End Function


    Public Property node As XmlNode Implements iBaseItem.node

    Public ReadOnly Property Type As BaseType Implements iBaseItem.Type
        Get
            Return BaseType.Wire
        End Get
    End Property


End Class


''' <summary>
''' some quick settings for when drawing a  wire
''' </summary>
''' <remarks></remarks>
Public Class WireStyle

    Public Sub New()
        Size = 1
        style = DashStyle.Solid
        Color = WireColor.Black
    End Sub

    ''' <summary>
    ''' size of the wire
    ''' </summary>
    ''' <remarks></remarks>
    Public Size As Integer
    ''' <summary>
    ''' drawing style
    ''' </summary>
    ''' <remarks></remarks>
    Public style As DashStyle
    ''' <summary>
    ''' color of the wire
    ''' </summary>
    ''' <remarks></remarks>
    Public Color As WireColor
End Class