

''' <summary>
''' compaires on analog to another and outputs the winner
''' </summary>
''' <remarks></remarks>
Public Class B_CompareAnalog
    Inherits Block

    Public Enum CompareType
        Greater = 3
        Less = 4
    End Enum

    Public Compare As CompareType

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        Compare = XHelper.Get(node, "Compaire", 0)

        m_Inputs.Add(New Connector("i_0", True, False, Me))
        m_Inputs.Add(New Connector("i_1", True, False, Me))
        m_outputs.Add(New Connector("o_0", False, False, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Compaire", CInt(Compare))
    End Sub

    Public Overrides Sub Update()
        Dim b As Double = 0.0

        Select Case Compare
            Case CompareType.Greater
                b = If(m_Inputs(0).Value > m_Inputs(1).Value, m_Inputs(0).Value, m_Inputs(1).Value)
            Case CompareType.Less
                b = If(m_Inputs(0).Value < m_Inputs(1).Value, m_Inputs(0).Value, m_Inputs(1).Value)
        End Select

        m_outputs(0).Value = b
    End Sub



    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.CompareA
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            If Compare = CompareType.Greater Then
                Return "Comp >"
            Else
                Return "Comp <"
            End If
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_CompareAnalog_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class
