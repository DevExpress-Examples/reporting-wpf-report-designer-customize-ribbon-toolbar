using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.XtraReports.UI;

namespace CustomizeReportDesignerToolbar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseDocumentButton_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (reportDesigner.ActiveDocument != null)
                reportDesigner.ActiveDocument.Close();
        }

        private void AboutButton_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            MessageBox.Show("This example demonstrates how to customize the Report Designer's toolbar.", "About");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reportDesigner.OpenDocument(new XtraReport());
        }
    }
}
