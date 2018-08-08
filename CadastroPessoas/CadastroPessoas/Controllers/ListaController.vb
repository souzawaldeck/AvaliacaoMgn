Imports System.Web.Mvc

Namespace Controllers
    Public Class ListaController
        Inherits Controller

        ' GET: Lista
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace