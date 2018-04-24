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
                    _toolboxControl = CType(FindDesignerElement(Function(child)
                        Return child.GetType() Is GetType(LayoutPanel)
                    End Function}), LayoutPanel)

                Return _toolboxControl
                End If
            End Get

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        protected TabbedGroup SidePanelControl
'        {
'            get
'            {
'                if (_sidePanelControl == Nothing)
'                    _sidePanelControl = (TabbedGroup)FindDesignerElement((child) =>
'                    {
'                        Return child.GetType() == typeof(TabbedGroup);
'                    }
'                   );
'
'                Return _sidePanelControl;
'            }
'        }

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        public ReportDesigner Designer
'        {
'            get
'            {
'                Return _designer;
'            }
'        }

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        public bool IsToolboxVisible
'        {
'            get
'            {
'                Return ToolboxControl != Nothing ? ToolboxControl.Visibility == Visibility.Visible : False;
'            }
'            set
'            {
'                if (value != IsToolboxVisible)
'                {
'                    if (value)
'                        ToolboxControl.SetBinding(LayoutPanel.VisibilityProperty, New Binding() { Path = New PropertyPath("(0).PreviewIsOpen", ReportDesigner.DocumentSelectorProperty), RelativeSource = New RelativeSource(RelativeSourceMode.Self), Converter = New BooleanToVisibilityConverter() { Inverse = True } });
'                    else
'                        ToolboxControl.Visibility = Visibility.Collapsed;
'
'                    RaisePropertyChanged("IsToolboxVisible");
'                }
'            }
'        }

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        public bool IsSidePanelVisible
'        {
'            get
'            {
'                Return SidePanelControl != Nothing ? SidePanelControl.Visibility == Visibility.Visible : False;
'            }
'            set
'            {
'                if (value != IsSidePanelVisible)
'                {
'                    if (value)
'                        SidePanelControl.SetBinding(LayoutPanel.VisibilityProperty, New Binding() { Path = New PropertyPath("(0).PreviewIsOpen", ReportDesigner.DocumentSelectorProperty), RelativeSource = New RelativeSource(RelativeSourceMode.Self), Converter = New BooleanToVisibilityConverter() { Inverse = True } });
'                    else
'                        SidePanelControl.Visibility = Visibility.Collapsed;
'
'                    RaisePropertyChanged("IsSidePanelVisible");
'                }
'            }
'        }

        public event PropertyChangedEventHandler PropertyChangedEvent

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        public CustomizedRibbonCommands(ReportDesigner designer)
'        {
'            Me._designer = designer;
'        }

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        private DependencyObject FindElement(DependencyObject parent, Func(Of DependencyObject, bool) condition)
'        {
'            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
'            {
'                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
'                if (condition(child))
'                    Return child;
'                DependencyObject result = FindElement(child, condition);
'                if (result != Nothing)
'                    Return result;
'            }
'            Return Nothing;
'        }

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        protected DependencyObject FindDesignerElement(Func(Of DependencyObject, bool) condition)
'        {
'            Return FindElement(Designer, condition);
'        }

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'        protected void RaisePropertyChanged(string propertyName)
'        {
'            if (PropertyChanged != Nothing)
'            {
'                PropertyChanged(Me, New PropertyChangedEventArgs(propertyName));
'            }
'        }
        End Property
    End Class
