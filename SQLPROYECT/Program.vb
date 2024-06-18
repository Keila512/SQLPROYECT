Imports System
Imports System.Windows.Forms

Namespace SQLPROYECT
    Friend Module Program
        ''' <summary>
        ''' Punto de entrada principal para la aplicación.
        ''' </summary>
        <STAThread>
        Private Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
