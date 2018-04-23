using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.PropertyGrid;
using DevExpress.Xpf.Reports.UserDesigner;
using DevExpress.XtraReports.UI;


namespace WpfApplicationEUDCustomPropertiesWindow {
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class MainWindow : DXWindow {
        public static readonly DependencyProperty CustomRibbonCommandsProperty = DependencyProperty.Register(
               "CustomRibbonCommands",
               typeof(CustomizedRibbonCommands),
               typeof(MainWindow),
               new PropertyMetadata(null)
       );
        public CustomizedRibbonCommands CustomRibbonCommands {
            get { return (CustomizedRibbonCommands)GetValue(CustomRibbonCommandsProperty); }
            set { SetValue(CustomRibbonCommandsProperty, value); }
        }  
        public MainWindow() {
            InitializeComponent();
            CustomRibbonCommands = new CustomizedRibbonCommands(reportDesigner);
            reportDesigner.OpenDocument(new XtraReport());
        }
    }
}
