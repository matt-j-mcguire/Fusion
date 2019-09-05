
''' <summary>
''' compaires on analog to another and outputs the truth
''' </summary>
''' <remarks></remarks>
Public Class B_CompareDigital
    Inherits Block

    Public Enum CompareType
        Equal = 0
        EqualGreater = 1
        EqualLess = 2
        Greater = 3
        Less = 4
    End Enum

    Public Compare As CompareType

    Public Sub New(nd As XmlNode)
        MyBase.New(nd)
        Compare = XHelper.Get(node, "Compaire", 0)

        m_Inputs.Add(New Connector("i_0", True, False, Me))
        m_Inputs.Add(New Connector("i_1", True, False, Me))
        m_outputs.Add(New Connector("o_0", False, True, Me))
    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        XHelper.Set(node, "Compaire", CInt(Compare))
    End Sub

    Public Overrides Sub Update()
        Dim b As Boolean = True

        Select Case Compare
            Case CompareType.Equal
                b = (m_Inputs(0).Value = m_Inputs(1).Value)
            Case CompareType.EqualGreater
                b = (m_Inputs(0).Value >= m_Inputs(1).Value)
            Case CompareType.EqualLess
                b = (m_Inputs(0).Value <= m_Inputs(1).Value)
            Case CompareType.Greater
                b = (m_Inputs(0).Value > m_Inputs(1).Value)
            Case CompareType.Less
                b = (m_Inputs(0).Value < m_Inputs(1).Value)
        End Select

        m_outputs(0).DigValue = b
    End Sub

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return Fusion.BlockType.CompareD
        End Get
    End Property

    Public Overrides ReadOnly Property TextForBlock_UI As String
        Get
            Select Case Compare
                Case CompareType.Equal
                    Return "Comp ="
                Case CompareType.EqualGreater
                    Return "Comp =>"
                Case CompareType.EqualLess
                    Return "Comp =<"
                Case CompareType.Greater
                    Return "Comp >"
                Case Else ' CompareType.Less
                    Return "Comp <"
            End Select
        End Get
    End Property

    Public Overrides Function GetPropsPage() As BaseItemProp
        Dim ex As New B_CompareDigital_Props
        ex.Loaditem(me.getui)
        Return ex
    End Function

End Class

