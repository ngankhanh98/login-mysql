using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace login_mysql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection mySqlConnection;
        string connstring;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            connstring = "SERVER=db4free.net; PORT=3306; DATABASE=managementapp; UID=managementapp; PWD=managementapp123;oldguids=true";
            try
            {
                mySqlConnection = new MySqlConnection();
                mySqlConnection.ConnectionString = connstring;
                mySqlConnection.Open();

                MessageBox.Show("Connection created");

                //string query = @"SELECT * FROM `managementapp`.`ACCOUNTS` WHERE USER=@username AND PASSWORD=@password";
                String query = string.Format(@"SELECT * FROM managementapp.ACCOUNTS WHERE USERNAME = '{0}' AND PASSWORD = '{1}';", txtUsername.Text, txtPassword.Text);
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                //mySqlCommand.Parameters.AddWithValue("@username", MySqlDbType.VarChar).Value = txtUsername.Text;
                //mySqlCommand.Parameters.AddWithValue("@password", MySqlDbType.VarChar).Value = txtPassword.Text;
                //mySqlCommand.ExecuteReader().Read();
                //int count = Convert.ToInt32(result);

                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    MessageBox.Show(dataReader["USERNAME"].ToString());
                }
                else
                {
                    MessageBox.Show("Username or password incorrect");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
