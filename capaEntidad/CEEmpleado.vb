Public Class CEEmpleado
    'Creando variables privadas'
    Private _id As Integer
    Private _nombre As String
    Private _apellido As String
    Private _foto As String

    'Creacion del constructor'
    Public Sub New()

    End Sub


    'Creacion de los Metodos GETTERS AND SETTERS'
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property

    Public Property Foto As String
        Get
            Return _foto
        End Get
        Set(value As String)
            _foto = value
        End Set
    End Property





End Class
