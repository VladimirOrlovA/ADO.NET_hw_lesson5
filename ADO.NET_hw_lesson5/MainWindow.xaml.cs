using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO.NET_hw_lesson5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        DataSet dataSet;
        DataTable dataTable;

        public MainWindow()
        {
            InitializeComponent();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }

        private void CheckConn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCheckConn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewDataRow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewTableStructure_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewTableRecords_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMakeTableRecords_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddColumn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
