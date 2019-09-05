
''' <summary>
''' random number generator
''' </summary>
''' <remarks></remarks>
Public Class B_Random
    Inherits Block

    ''' <summary>
    ''' minimum range for the generator
    ''' </summary>
    ''' <remarks></remarks>
    Public Min As Integer
    ''' <summary>
    ''' maximum range for the generator
    ''' </summary>
    ''' <remarks></remarks>
    Public Max As Integer
    Private _random As Random

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        _random = New Random()

        Min = XHelper.Get(node, "Min", 0)
        Max = XHelper.Get(node, "Max", 100)
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Min", Min)
        XHelper.Set(node, "Max", Max)
    End Sub

    Public Overrides Sub Update()
        m_outputs(0).Value = _random.Next(Min, Max)
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Random
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Random"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Random_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
