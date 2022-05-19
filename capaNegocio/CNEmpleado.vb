Imports capaEntidad
Imports capaDatos
'Importamos la clase llamada capaEntidad'
Public Class CNEmpleado

    'Creando una variable global de tipo CDEmpleado'
    Dim DatosEmpleado As New CDEmpleado

    'Creando un metodo publico'
    Public Function ValidarDatos(ByVal empleado As CEEmpleado) As Boolean
        Dim Resultado As Boolean = True

        'Validando que el nombre del empleado no este en blanco'
        If empleado.Nombre = "" Then
            'Estamos indicando que no paso la validacion'
            Resultado = False
            'Mostrando mensaje a pantalla en caso de que no haya ingresado el nombre'
            MessageBox.Show("El Nombre es Obligatorio")
        End If

        If empleado.Apellido = "" Then
            'Validando si paso'
            Resultado = False
            'Mostrando mensaje a pantalla en caso de que no haya ingresado el apellido'
            MessageBox.Show("El Apellido es Obligatorio")
        End If

        Return Resultado
    End Function

    Public Sub PruebaMysql()
        'Hacemos la prueba de la conexion de la base de datos'
        DatosEmpleado.ProbarConexion()
    End Sub

    'Este metodo nos servira para INSERTAR los datos de tipo CEEmpleado'
    Public Sub Insertar(ByVal empleado As CEEmpleado)
        DatosEmpleado.Insertar(empleado)
    End Sub

    'Este metodo nos servira para EDITAR los datos de tipo CEEmpleado'
    Public Sub Editar(ByVal empleado As CEEmpleado)
        DatosEmpleado.Modificar(empleado)
    End Sub

    'Este metodo nos servira para ELIMINAR los datos de tipo CEEmpleado'
    Public Sub Eliminar(ByVal empleado As CEEmpleado)
        'En la siguiente linea sucede lo siguiente'
        'Cuando el metodo Eliminar sea ejecutado lanzara una ventana preguntando si esta seguro de eliminar x registro'
        'Si la opcion es Si procedera a eliminarlo del GRID y de la BD , si oprime que no pues no lo va a eliminar'
        '***NOTA***'
        'Para que esta accion sea ejecutada perfectamente tiene que llevar el DIALOGRESULT.YES , ya que lo contrario en ambas opciones va a eliminar.'
        If MessageBox.Show("¿Estas seguro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DatosEmpleado.Eliminar(empleado)
        End If

    End Sub

    'Esta funcion nos ayudara a LISTAR los datos del Empleado'
    Public Function Listar() As DataSet
        Return DatosEmpleado.Listar()
    End Function

End Class
