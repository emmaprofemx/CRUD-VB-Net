Imports MySql.Data.MySqlClient
Imports capaEntidad
Public Class CDEmpleado
    'Creacion de variable cadenaConexion'
    '*********NOTA IMPORTANTE*********'
    'Es importante tener todos los valores correctos de nuestra conexion , ya que si por una letra o numero'
    'Si en cualquiera de nuestros campos estan mal los datos , no podra hacer la conexion a la BD.Tiene que tener:'
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

    'Creacion de metodo insertar'

    Public Sub Insertar(ByVal empleado As CEEmpleado)
        'Creando '
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        'Abrimos la conexion'
        Conexion.Open()
        'Definimos una variable llamada Query la cual utilizaremos como parametro'
        'Dentro del STRING agregamos el script INSERT INTO el cual en la parter de values haremos lo siguente...'
        'En el caso de la foto se tuvo que implementar esa sintaxis ya que va a recibir la ruta de la foto , por eso se utiliza de esa manera'
        Dim Query As String = "INSERT INTO `empleados` (`nombre`, `apellido`, `foto`) VALUES ('" & empleado.Nombre & "', '" & empleado.Apellido & "', '" & MySql.Data.MySqlClient.MySqlHelper.EscapeString(empleado.Foto) & "');"
        'Pasamos Query y Conexiion como parametro'
        Dim Comando As New MySqlCommand(Query, Conexion)
        'El metodo ExecuteNo Query es una ejecucion que no devuelve ningun resultado'
        Comando.ExecuteNonQuery()
        'Cerramos la conexion ya que se completaron los pasos anteriores'
        Conexion.Close()
        'Mostramos un mensaje diciendo que el registro ha sido creado'
        MessageBox.Show("Registro Creado")
    End Sub

    'Metodo para modificar los valores de un elemento'
    Public Sub Modificar(ByVal empleado As CEEmpleado)
        'Creando la conexion a MYSQL'
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        'Abrimos la conexion'
        Conexion.Open()
        'Definimos una variable llamada Query la cual utilizaremos como parametro'
        'Dentro del STRING agregamos el script UPDATE INTO el cual en la parter de values haremos lo siguente...'
        'En el caso de la foto se tuvo que implementar esa sintaxis ya que va a recibir la ruta de la foto , por eso se utiliza de esa manera'
        Dim Query As String = "UPDATE`empleados` SET `nombre`='" & empleado.Nombre & "', `apellido`='" & empleado.Apellido & "', `foto`='" & MySql.Data.MySqlClient.MySqlHelper.EscapeString(empleado.Foto) & "' WHERE  `id`=" & empleado.Id & ";"
        'Pasamos Query y Conexiion como parametro'
        Dim Comando As New MySqlCommand(Query, Conexion)
        'El metodo ExecuteNo Query es una ejecucion que no devuelve ningun resultado'
        Comando.ExecuteNonQuery()
        'Cerramos la conexion ya que se completaron los pasos anteriores'
        Conexion.Close()
        'Mostramos un mensaje diciendo que el registro ha sido creado'
        MessageBox.Show("Registro Editado")
    End Sub

    Public Sub Eliminar(ByVal empleado As CEEmpleado)
        'Creando la conexion '
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        'Abrimos la conexion'
        Conexion.Open()
        'Definimos una variable llamada Query la cual utilizaremos como parametro'
        'Dentro del STRING agregamos el script DELETAE FROM el cual solo vamos a concatenar el id del empleado...'
        Dim Query As String = "DELETE FROM `empleados` WHERE  `id`=" & empleado.Id & ";"
        'Pasamos Query y Conexiion como parametro'
        Dim Comando As New MySqlCommand(Query, Conexion)
        'El metodo ExecuteNo Query es una ejecucion que no devuelve ningun resultado'
        Comando.ExecuteNonQuery()
        'Cerramos la conexion ya que se completaron los pasos anteriores'
        Conexion.Close()
        'Mostramos un mensaje diciendo que el registro ha sido creado'
        MessageBox.Show("Registro Eliminado")
    End Sub


    Public Function Listar() As DataSet
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        'Ahora en el STRING implementamos el siguiente script para visualizar los valores en el CRID'
        Dim Query As String = "SELECT * FROM `empleados` LIMIT 1000;"
        Dim Adaptador As MySqlDataAdapter
        Dim dataSet As New DataSet
        Adaptador = New MySqlDataAdapter(Query, Conexion)
        Adaptador.Fill(dataSet, "empleado")
        Return dataSet
    End Function

End Class
