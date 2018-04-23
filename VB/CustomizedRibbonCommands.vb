Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Reports.UserDesigner
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Media

Namespace WpfApplicationEUDCustomPropertiesWindow
	Public Class CustomizedRibbonCommands
		Implements INotifyPropertyChanged

		Private _designer As ReportDesigner
		Private _toolboxControl As LayoutPanel
		Private _sidePanelControl As DevExpress.Xpf.Docking.TabbedGroup

		Protected ReadOnly Property ToolboxControl() As LayoutPanel
			Get
				If _toolboxControl Is Nothing Then
                    _toolboxControl = CType(FindDesignerElement(Function(child) child.GetType() Is GetType(LayoutPanel)), LayoutPanel)
                End If

				Return _toolboxControl
			End Get
		End Property

		Protected ReadOnly Property SidePanelControl() As TabbedGroup
			Get
				If _sidePanelControl Is Nothing Then
                    _sidePanelControl = CType(FindDesignerElement(Function(child) child.GetType() Is GetType(TabbedGroup)), TabbedGroup)
				End If

				Return _sidePanelControl
			End Get
		End Property

		Public ReadOnly Property Designer() As ReportDesigner
			Get
				Return _designer
			End Get
		End Property

		Public Property IsToolboxVisible() As Boolean
			Get
				Return If(ToolboxControl IsNot Nothing, ToolboxControl.Visibility = Visibility.Visible, False)
			End Get
			Set(ByVal value As Boolean)
				If value <> IsToolboxVisible Then
					If value Then
						ToolboxControl.SetBinding(LayoutPanel.VisibilityProperty, New Binding() With {
							.Path = New PropertyPath("(0).PreviewIsOpen", ReportDesigner.DocumentSelectorProperty), .RelativeSource = New RelativeSource(RelativeSourceMode.Self), .Converter = New BooleanToVisibilityConverter() With {.Inverse = True}
						})
					Else
						ToolboxControl.Visibility = Visibility.Collapsed
					End If

					RaisePropertyChanged("IsToolboxVisible")
				End If
			End Set
		End Property

		Public Property IsSidePanelVisible() As Boolean
			Get
				Return If(SidePanelControl IsNot Nothing, SidePanelControl.Visibility = Visibility.Visible, False)
			End Get
			Set(ByVal value As Boolean)
				If value <> IsSidePanelVisible Then
					If value Then
						SidePanelControl.SetBinding(LayoutPanel.VisibilityProperty, New Binding() With {
							.Path = New PropertyPath("(0).PreviewIsOpen", ReportDesigner.DocumentSelectorProperty), .RelativeSource = New RelativeSource(RelativeSourceMode.Self), .Converter = New BooleanToVisibilityConverter() With {.Inverse = True}
						})
					Else
						SidePanelControl.Visibility = Visibility.Collapsed
					End If

					RaisePropertyChanged("IsSidePanelVisible")
				End If
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Public Sub New(ByVal designer As ReportDesigner)
			Me._designer = designer
		End Sub

		Private Function FindElement(ByVal parent As DependencyObject, ByVal condition As Func(Of DependencyObject, Boolean)) As DependencyObject
			For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(parent) - 1
				Dim child As DependencyObject = VisualTreeHelper.GetChild(parent, i)
				If condition(child) Then
					Return child
				End If
				Dim result As DependencyObject = FindElement(child, condition)
				If result IsNot Nothing Then
					Return result
				End If
			Next i
			Return Nothing
		End Function

		Protected Function FindDesignerElement(ByVal condition As Func(Of DependencyObject, Boolean)) As DependencyObject
			Return FindElement(Designer, condition)
		End Function

		Protected Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
	End Class
End Namespace
