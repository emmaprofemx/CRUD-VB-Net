Imports capaEntidad
Imports capaNegocio
'Hacemos las importaciones necesarias'
Public Class frEmpleados

    'Creacion de variable Global'
    Dim NegocioEmpleado As New CNEmpleado()

    Private Sub frEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrid()
    End Sub

    Private Sub frEmpleados_Load_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub frEmpleados_Load_2(sender As Object, e As EventArgs) Handles MyBase.Load
        'Con la ayuda de esta linea sera posible ver los datos que hemos estado ingresando'
        gridDatos.DataSource = NegocioEmpleado.Listar().Tables("empleado")
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click

        'Configurando el boton Nuevo , lo cual hara que cuando el usuario lo presione se limpien los campos'
        'Esto involucra a ID , NOMBRE , APELLIDO , y la foto'
        txtId.Value = 0
        txtNombre.Text = ""
        txtApellido.Text = ""
        'Lo que hara es quitar cualquier elemento que se situe en dicho objeto'
        picFoto.Image = Nothing


    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles txtId.ValueChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles picFoto.Click

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Cracion de un objeto de tipo CEEmpleado'
        Dim empleado As New CEEmpleado()
        'Creacion de variable booleana'
        Dim Validacion As Boolean

        empleado.Id = txtId.Value
        empleado.Nombre = txtNombre.Text
        empleado.Apellido = txtApellido.Text
        empleado.Foto = picFoto.ImageLocation

        'Accediendo a la variable NegocioEmpleado'
        Validacion = NegocioEmpleado.ValidarDatos(empleado)
        'Si la valdicacion es False , salimos de nuestro boton'
        'Si el metodo validarDatos obtiene falso , se saldra del boton'
        If Validacion = False Then Exit Sub
        'Si no es falso , continuara la sentencia de codigo'
        'Mostramos un mensaje verificando que se han guardado los datos'
        'MessageBox.Show("Se guardaron correctamente")'
        If empleado.Id = 0 Then
            NegocioEmpleado.Insertar(empleado)
        Else
            NegocioEmpleado.Editar(empleado)
        End If

        CargarGrid()
        'Limpia los campos'
        ' txtNombre.Text = "" '
        ' txtApellido.Text = "" '
        'Lo que hara es limpiar la imagen que se situe en dicho objeto'
        ' picFoto.Image = Nothing '

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        NegocioEmpleado.PruebaMysql()


    End Sub

    Private Sub lnkFoto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFoto.LinkClicked
        'La siguiente linea es una ventana de dialogo'
        'El cual cuando seleccionemos el link nos mostrara una ventana para elegir la imagen'
        openFoto.ShowDialog()
        'De momento aun no la carga , lo haremos a continuacion'
        'Se hace una validacion del objeto foto el cual evalua si esta vacia seleccionamos una foto'
        If openFoto.FileName <> "" Then
            picFoto.Load(openFoto.FileName)
        End If
        'Ya elegida la limpia'
        openFoto.FileName = ""

    End Sub

    'Funcion que sirve para cargar en ese preciso momento el nuevo registro en el GRID'
    Private Sub CargarGrid()
        gridDatos.DataSource = NegocioEmpleado.Listar().Tables("empleado")
    End Sub


    Private Sub gridDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridDatos.CellDoubleClick

        'Lo que hacemos a continuacion es lo siguiente '
        'Cuando hagamos doble click en el GRID , se llenaran los campos de acuerdo al elemento seleccionado'
        'Esto involucra el ID , NOMBRE , Y APELLIDO'
        txtId.Value = gridDatos.CurrentRow.Cells("id").Value
        txtNombre.Text = gridDatos.CurrentRow.Cells("nombre").Value
        txtApellido.Text = gridDatos.CurrentRow.Cells("apellido").Value

        'Lo que hacemos en la siguiente linea es lo siguiente , verificamos en la celda foto no esta vacia'
        If gridDatos.CurrentRow.Cells("foto").Value <> "" Then
            'Si no lo esta procede a cargar la imagen en el objeto donde mostramos la imagen.'
            If System.IO.File.Exists(gridDatos.CurrentRow.Cells("foto").Value) Then
                picFoto.Load(gridDatos.CurrentRow.Cells("foto").Value)
            End If
        End If
    End Sub
End Class
