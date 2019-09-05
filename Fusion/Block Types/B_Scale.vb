
''' <summary>
''' scales an output between two inputs
''' </summary>
''' <remarks></remarks>
Public Class B_Scale
    Inherits Block


    Public MinDiv As Double
    Public MaxDiv As Double
    Public MinOut As Double
    Public MaxOut As Double

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)

        MinDiv = XHelper.Get(node, "MinDiv", 0.0)
        MaxDiv = XHelper.Get(node, "MaxDiv", 100.0)
        MinOut = XHelper.Get(node, "MinOut", 0.0)
        MaxOut = XHelper.Get(node, "MaxOut", 100.0)

        m_Inputs.Add(New Connector("Value", True, False, Me))
        m_Inputs.Add(New Connector("SP", True, False, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "MinDiv", MinDiv)
        XHelper.Set(node, "MaxDiv", MaxDiv)
        XHelper.Set(node, "MinOut", MinOut)
        XHelper.Set(node, "MaxOut", MaxOut)
    End Sub

    Public Overrides Sub Update()

        Dim r As Double = MaxDiv - MinDiv
        Dim p As Double = (m_Inputs(0).Value - (m_Inputs(1).Value + MinDiv)) / r
        Dim f As Double = MaxOut - MinOut
        Dim v As Double = (p * f) + MinOut

        'update the output
        m_outputs(0).Value = v

    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.Scale
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Return "Scale"
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_Scale_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
