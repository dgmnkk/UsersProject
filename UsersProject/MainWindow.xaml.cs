using PropertyChanged;
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

namespace UsersProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connStr = null;
        private DataSet dataSet = null;
        private SqlDataAdapter adapter = null;
        
        public MainWindow()
        {
            InitializeComponent();
            connStr = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
        }

        private void LoadData_Button(object sender, RoutedEventArgs e)
        {
            string cmd = "select * from Users";
            adapter = new(cmd, connStr);
            new SqlCommandBuilder(adapter);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            usersList.ItemsSource = dataSet.Tables[0].DefaultView; 
        }

        private void LoadAdmins_Button(object sender, RoutedEventArgs e)
        {
            string cmd = "select * from Users where Role = 'Administrator'";
            adapter = new(cmd, connStr);
            new SqlCommandBuilder(adapter);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            usersList.ItemsSource = dataSet.Tables[0].DefaultView;
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
        }

       
    }
}
