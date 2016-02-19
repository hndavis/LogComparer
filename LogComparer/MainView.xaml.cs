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

namespace LogComparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        void ShowColumns(DataGrid dg)
        {
            foreach (var col in dg.Columns)
            {
                switch (col.Header.ToString().ToLower())
                {
                    case "raw":
                        col.Visibility = Visibility.Collapsed;
                        break;

                    case "parent":
                        col.Visibility = Visibility.Collapsed;
                        break;

                    case "ts":
                        col.Visibility = Visibility.Collapsed;
                        break;


                }

            }
        }

        private void FrameworkElement_OnTargetUpdated(object sender, DataTransferEventArgs e)
        {
           DataGrid dg = sender as DataGrid;
            if (dg == null)
                return;
            ShowColumns(dg);
        }
    }
}
