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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Practicka
{
    /// <summary>
    /// Логика взаимодействия для MyProfileWindow.xaml
    /// </summary>
    public partial class MyProfileWindow : Window
    {
        public MyProfileWindow()
        {
            InitializeComponent();
            
           
        }

        public  void UserVoucherInfo()
        {
            listVoucher.Items.Clear();
            listVoucher.Items.Add("Страна: "+MainWindow.voucher.country);
            listVoucher.Items.Add("Город: " + MainWindow.voucher.city);
            listVoucher.Items.Add("Питание: " + MainWindow.voucher.eating);
            listVoucher.Items.Add("Экскурсия: " + MainWindow.voucher.excursion);
            listVoucher.Items.Add("Даты приезда и отъезда: " + MainWindow.voucher.send.ToString()+" - "+MainWindow.voucher.back.ToString());
            listVoucher.Items.Add("Цена: " + Sale(MainWindow.voucher.sold)+"руб., включая скидку! Вместо "+ MainWindow.voucher.sold + "руб.");
        }

        private double Sale(int i)
        {
            return i - i * MainWindow.user.sale / 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.mainWindow.Show();
        }

        private void listVoucher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listVoucher_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updateVoucher_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.user.id_voucher!=0)
            {
                DialogResult dr = new DialogResult();
                if (MainWindow.user.id_voucher != 0)
                {
                    dr = MessageBox.Show("Удаление путевки означает, что вы не использовали путевку, поэтому скидка не будет начислена. Удалить?", "Внимание", MessageBoxButtons.YesNo);
                }
                if (dr.ToString() == "Yes")
                {
                    using (SqlCommand command = new SqlCommand($"UPDATE [Client] SET id_voucher={0} WHERE id={MainWindow.user.id} ", MainWindow.connection))
                    {
                        MainWindow.connection.Open();
                        command.ExecuteNonQuery();
                        MainWindow.connection.Close();
                    }
                    using (SqlCommand command = new SqlCommand($"UPDATE [Client] SET count_voucher={MainWindow.user.count_vouchers - 1} WHERE id={MainWindow.user.id} ", MainWindow.connection))
                    {
                        MainWindow.connection.Open();
                        command.ExecuteNonQuery();
                        MainWindow.connection.Close();
                    }
                }
            }

            MainWindow.voucher = new Voucher();
            MainWindow.user.id_voucher = 0;
            UserVoucherInfo();
        }
    }
}
