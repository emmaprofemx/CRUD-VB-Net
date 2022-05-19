Imports MySql.Data.MySqlClient
Imports capaEntidad
Public Class CDEmpleado
    'Cracion de variable cadenaConexion'
    '*********NOTA IMPORTANTE*********'
    'Es importante tener todos los valores correctos de nuestra conexion , ya que si por una letra o numero'
    'En cualquiera de nuestros campos esta mal , no podra hacer la conexion a la BD.Tiene que tener:'
    '*La IP del Servidor(Por lo general esa esta por default)'
    '*El usuario que tiene asignado'
    '*La contrasena tiene que ser la misma cuando instalaste el mariaDB o otro gestor de BD'
    '*Y el mismo nombre de la base de datos'
    Private _cadenaConexion As String = "Server=127.0.0.1;User=root;Password=123456;Port=3308;database=curso_vb"

    Public Sub ProbarConexion()

        'Creando variable'
        Dim Conexion As New MySqlConnection(_cadenaConexion)

        'Agregamos un Try-catch por si hay algun problema al momento de establecer la conexion'
        Try
            Conexion.Open()
        Catch ex As Exception
            'En caso de que haya un error , lo mostramos'
            MessageBox.Show(ex.Message)
        End Try

        'Mostramos un mensaje para visualizar si ya estamos conectados'
        MessageBox.Show("Conectado")
        'Y tendra un boton de cerrar'
        Conexion.Close()
    End Sub

End Class
