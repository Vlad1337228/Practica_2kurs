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
        public static DateSoldVoucher offer;
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
            //MainWindow.mainWindow.Hide();
            if (MainWindow.user != null)
            {
                MainWindow.myProfileWindiw.labelNameUser.Content = MainWindow.user.name;
                MainWindow.myProfileWindiw.labelEmailUser.Content = MainWindow.user.email;
                if(MainWindow.user.id_voucher!=0)
                   MainWindow.myProfileWindiw.UserVoucherInfo();
                MainWindow.myProfileWindiw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Войдите в аккаунт для просмотра данных о профиле и о путевке.");
            }
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

        private void textBoxArrival_date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxForm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void textBoxForm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SearchVouchMainForm(object sender, RoutedEventArgs e, string country)
        {
            MainWindow.searchWindow = new SearchWindow();
            MainWindow.searchWindow.textBoxCountry1.Text = country;
            MainWindow.searchWindow.Button_Click_2(sender, e);
            MainWindow.searchWindow.Show();
        }

        private void search1_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm( sender,  e , "Япония");
        }

        private void search2_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "Швейцария");
        }

        private void search3_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "Турция");
        }

        private void search4_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "Дубаи");
        }

        private void search5_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "Египет");
        }

        private void search6_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "Россия");
        }

        private void search7_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "США");
        }

        private void search8_Click(object sender, RoutedEventArgs e)
        {
            SearchVouchMainForm(sender, e, "Канада");
        }
    }
}
