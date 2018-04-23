using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Reports.UserDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplicationEUDCustomPropertiesWindow {
    public class CustomizedRibbonCommands :INotifyPropertyChanged {
        ReportDesigner _designer;
        LayoutPanel _toolboxControl;
        DevExpress.Xpf.Docking.TabbedGroup _sidePanelControl;

        protected LayoutPanel ToolboxControl {
            get {
                if (_toolboxControl == null)
                    _toolboxControl = (LayoutPanel)FindDesignerElement((child) => {
                        return child.GetType() == typeof(LayoutPanel);
                    });

                return _toolboxControl;
            }
        }

        protected TabbedGroup SidePanelControl {
            get {
                if (_sidePanelControl == null)
                    _sidePanelControl = (TabbedGroup)FindDesignerElement((child) => {
                        return child.GetType() == typeof(TabbedGroup);
                    });

                return _sidePanelControl;
            }
        }

        public ReportDesigner Designer {
            get { return _designer; }
        }

        public bool IsToolboxVisible {
            get { return ToolboxControl != null ? ToolboxControl.Visibility == Visibility.Visible : false; }
            set {
                if (value != IsToolboxVisible) {
                    if (value)
                        ToolboxControl.SetBinding(LayoutPanel.VisibilityProperty, new Binding() {
                            Path = new PropertyPath("(0).PreviewIsOpen", ReportDesigner.DocumentSelectorProperty),
                            RelativeSource = new RelativeSource(RelativeSourceMode.Self),
                            Converter = new BooleanToVisibilityConverter() { Inverse = true }
                        });
                    else
                        ToolboxControl.Visibility = Visibility.Collapsed;

                    RaisePropertyChanged("IsToolboxVisible");
                }
            }
        }

        public bool IsSidePanelVisible {
            get { return SidePanelControl != null ? SidePanelControl.Visibility == Visibility.Visible : false; }
            set {
                if (value != IsSidePanelVisible) {
                    if (value)
                        SidePanelControl.SetBinding(LayoutPanel.VisibilityProperty, new Binding() {
                            Path = new PropertyPath("(0).PreviewIsOpen", ReportDesigner.DocumentSelectorProperty),
                            RelativeSource = new RelativeSource(RelativeSourceMode.Self),
                            Converter = new BooleanToVisibilityConverter() { Inverse = true }
                        });
                    else
                        SidePanelControl.Visibility = Visibility.Collapsed;

                    RaisePropertyChanged("IsSidePanelVisible");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomizedRibbonCommands(ReportDesigner designer) {
            this._designer = designer;
        }

        private DependencyObject FindElement(DependencyObject parent, Func<DependencyObject, bool> condition) {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++) {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (condition(child))
                    return child;
                DependencyObject result = FindElement(child, condition);
                if (result != null)
                    return result;
            }
            return null;
        }

        protected DependencyObject FindDesignerElement(Func<DependencyObject, bool> condition) {
            return FindElement(Designer, condition);
        }

        protected void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
