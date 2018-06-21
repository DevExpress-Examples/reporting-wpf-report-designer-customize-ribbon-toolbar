Imports System.Windows
Imports DevExpress.XtraReports.UI

Namespace CustomizeReportDesignerToolbar
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub CloseDocumentButton_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            If reportDesigner.ActiveDocument IsNot Nothing Then
                reportDesigner.ActiveDocument.Close()
            End If
        End Sub

        Private Sub AboutButton_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
            MessageBox.Show("This example demonstrates how to customize the Report Designer's toolbar.", "About")
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            reportDesigner.OpenDocument(New XtraReport())
        End Sub
    End Class
End Namespace
