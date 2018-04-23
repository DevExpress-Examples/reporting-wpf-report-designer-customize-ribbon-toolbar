Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.PropertyGrid
Imports DevExpress.Xpf.Reports.UserDesigner
Imports DevExpress.XtraReports.UI


Namespace WpfApplicationEUDCustomPropertiesWindow
	''' <summary>
	''' Interaction logic for DXWindow1.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DXWindow

		Public Shared ReadOnly CustomRibbonCommandsProperty As DependencyProperty = DependencyProperty.Register("CustomRibbonCommands", GetType(CustomizedRibbonCommands), GetType(MainWindow), New PropertyMetadata(Nothing))
		Public Property CustomRibbonCommands() As CustomizedRibbonCommands
			Get
				Return CType(GetValue(CustomRibbonCommandsProperty), CustomizedRibbonCommands)
			End Get
			Set(ByVal value As CustomizedRibbonCommands)
				SetValue(CustomRibbonCommandsProperty, value)
			End Set
		End Property
		Public Sub New()
			InitializeComponent()
			CustomRibbonCommands = New CustomizedRibbonCommands(reportDesigner)
			reportDesigner.OpenDocument(New XtraReport())
		End Sub
	End Class
End Namespace
