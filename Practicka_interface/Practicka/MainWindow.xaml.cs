using Practicka.Model;
using System;
using System.Collections.Generic;
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

namespace Practicka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static EnterWindow enterWindow;
        public static MainWindow mainWindow;
        public static MyProfileWindow myProfileWindiw;
        public static registerForm register;
        public static SearchWindow searchWindow;
        public static string connect_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\AppData\\Local\\Microsoft\\Microsoft SQL Server Local DB\\Instances\\MSSQLLocalDB\\Practica_DB.mdf;Integrated Security=True";
        public static SqlConnection connection = new SqlConnection(connect_string);

        public static User user;
        public static Voucher voucher;
        public static Sold_Voucher sold_voucher;
        public static Offer offer;
        public static List<Voucher> vouchers;

        public static bool Vhod = false; // вошел или вышел пользователь

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            mainWindow.buttonExit.Visibility = Visibility.Hidden;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
             EnterWindow ew = new EnterWindow();
             ew.ShowDialog();
        }

        private void buttonLK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.myProfileWindiw = new MyProfileWindow();
            MainWindow.mainWindow.Hide();
            MainWindow.myProfileWindiw.Show();
        }

        private void buttonBron_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.user = null;
            MainWindow.voucher = null;
            MainWindow.sold_voucher = null;
            MainWindow.offer = null;
            mainWindow.buttonExit.Visibility = Visibility.Hidden;
            mainWindow.buttonEnter.Visibility = Visibility.Visible;
        }

        private void textBoxAdeparture_date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
