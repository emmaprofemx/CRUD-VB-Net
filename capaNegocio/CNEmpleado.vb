Imports capaEntidad
'Importamos la clase llamada capaEntidad'
Public Class CNEmpleado

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

End Class
