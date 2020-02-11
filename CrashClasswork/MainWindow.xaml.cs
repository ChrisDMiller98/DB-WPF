using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace CrashClasswork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employees.accdb");
            InitializeComponent();
        }

        private void SeeAssets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, AssetID, Description, * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())

            {
                data += read["EmployeeID"].ToString() + "\n";
                data += read["AssetID"].ToString() + "\n";
                data += read["Description"].ToString() + "\n";
            }
            Help.Text = data;
            cn.Close();
        }

        private void SeeEmployees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, FirstName, LastName, * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())

            {
                data += read["EmployeeID"].ToString() + "\n";
                data += read["FirstName"].ToString() + "\n";
                data += read["LastName"].ToString() + "\n";
            }
            Help2.Text = data;
            cn.Close();
        }
    }
}
