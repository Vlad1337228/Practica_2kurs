using Practicka.Controllers;
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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private int page = 1;
        private int numerable;
        private int final_advertisement;
        private bool not_switch_next = false;
        public SearchWindow()
        {
            InitializeComponent();
            if(MainWindow.user==null)
            {
                this.textBoxSale.Text = "0%";
            }
            else
            {
                this.textBoxSale.Text = MainWindow.user.sale + "%";
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow.vouchers = null; 
            var voucher = new ControllerVoucher();
            var country = textBoxCountry1.Text;//str
            var departure = textBoxDate3.Text;//date
            var back = textBoxDate4.Text;//date
            var price_min = textBoxValue3.Text;//int
            var price_max = textBoxValue4.Text;//int
            var city = textBoxCity.Text;//str
            var eating = comboBoxEating.Text;//str
            int sale=0;
            try
            {
                 sale = int.Parse((textBoxSale.Text).Split('%')[0]);//int
            }
            catch
            {
                MessageBox.Show("ошибка в скидке.");
            }
            page = 1;
            numerable = 0;
            voucher.ReturnVouchers(country, departure, back, price_min, price_max, city, eating, sale);
            DisplayVoucher();
        }
        
        private void DisplayVoucher()
        {
            var list = MainWindow.vouchers;
            try
            {
                final_advertisement = -1;

                OutVoucher1(list[numerable]);
                numerable++;

                final_advertisement = 0;
                OutVoucher2(list[numerable]);
                numerable++;

                final_advertisement = 1;
                OutVoucher3(list[numerable]);
                numerable++;

                final_advertisement = 2;
                
            }
            catch
            {
                DeleteVoucherInfo();
                not_switch_next = true;
                return;
            }
            return;
        }

        private void DisplayAuto_From_The_End()
        {
            var list = MainWindow.vouchers;
            try
            {
                numerable = numerable - 3 - (final_advertisement + 1);
                final_advertisement = -1;

                OutVoucher1(list[numerable]);
                final_advertisement = 0;
                numerable += 1;

                OutVoucher2(list[numerable]);
                final_advertisement = 1;
                numerable += 1;

                OutVoucher3(list[numerable]);
                final_advertisement = 2;
                numerable += 1;

                not_switch_next = false;
            }
            catch
            {
                DeleteVoucherInfo();
                not_switch_next = true;
                return;
            }
        }
        private void DeleteVoucherInfo()
        {
            for (int i = final_advertisement + 1; i < 3; i++)
            {
                Voucher v = new Voucher();
                if (i == 0)
                    OutVoucher1(v);
                if (i == 1)
                    OutVoucher2(v);
                if (i == 2)
                    OutVoucher3(v);
            }
        }
        
        private void OutVoucher3(Voucher voucher)
        {
            labelCountryRes6.Content = voucher.country;
            textBoxCity3.Content = voucher.city;
            labelDate1Res6.Content = voucher.send.Day.ToString()+'.'+ voucher.send.Month.ToString() +'.' + voucher.send.Year.ToString();
            labelDate2Res3_____1.Content = voucher.back.Day.ToString() + '.' + voucher.back.Month.ToString() + '.' + voucher.back.Year.ToString();
            labelExRes6.Content = voucher.excursion;
            textBoxEat3.Content = voucher.eating;
            textBoxPrice3.Content = voucher.sold+"руб.";
        }

        private void OutVoucher2(Voucher voucher)
        {
            labelCountryRes5.Content = voucher.country;
            textBoxCity2.Content = voucher.city;
            labelDate1Res5.Content = voucher.send.Day.ToString() + '.' + voucher.send.Month.ToString() + '.' + voucher.send.Year.ToString();
            labelDate2Res4.Content = voucher.back.Day.ToString() + '.' + voucher.back.Month.ToString() + '.' + voucher.back.Year.ToString();
            labelExRes5.Content = voucher.excursion;
            textBoxEat2.Content = voucher.eating;
            textBoxPrice2.Content = voucher.sold + "руб.";
        }

        private void OutVoucher1(Voucher voucher)
        {
            labelCountryRes4.Content = voucher.country;
            textBoxCity1.Content = voucher.city;
            labelDate1Res4.Content = voucher.send.Day.ToString() + '.' + voucher.send.Month.ToString() + '.' + voucher.send.Year.ToString();
            labelDate2Res3.Content = voucher.back.Day.ToString() + '.' + voucher.back.Month.ToString() + '.' + voucher.back.Year.ToString();
            labelExRes4.Content = voucher.excursion;
            textBoxEat1.Content = voucher.eating;
            textBoxPrice1.Content = voucher.sold + "руб.";

        }

        

        private void imageArrowRight1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (not_switch_next)
            {
                return;
            }
            page += 1;
            labelPage1.Content = (page).ToString();
            DisplayVoucher();
            
        }

        private void imageArrowLeft1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (page == 1)
            {
                return;
            }
            page -= 1;
            labelPage1.Content = (page).ToString();
            DisplayAuto_From_The_End();
        }

        private bool CheckVouch(int i)
        {
            try
            {
                var e=MainWindow.vouchers[i];
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void PlusVoucher(Voucher vouch)
        {
            DialogResult dr = new DialogResult();
            if (MainWindow.user.id_voucher != 0)
            {
                dr = MessageBox.Show("У вас уже добавлена путевка в профиле. Изменяя путевку вы подтверждаете, что уже использовали ее. Изменить?", "Внимание", MessageBoxButtons.YesNo);
            }
            if (dr.ToString() == "Yes" || MainWindow.user.id_voucher == 0)
            {
                MainWindow.user.id_voucher = vouch.id;
                MainWindow.voucher = vouch;
                using (SqlCommand command = new SqlCommand($"UPDATE [Client] SET id_voucher={vouch.id} WHERE id={MainWindow.user.id} ", MainWindow.connection))
                {
                    MainWindow.connection.Open();
                    command.ExecuteNonQuery();
                    MainWindow.connection.Close();
                    if (MainWindow.myProfileWindiw != null)
                        MainWindow.myProfileWindiw.UserVoucherInfo();
                }
                using (SqlCommand command = new SqlCommand($"UPDATE [Client] SET count_voucher={MainWindow.user.count_vouchers + 1} WHERE id={MainWindow.user.id} ", MainWindow.connection))
                {
                    MainWindow.connection.Open();
                    command.ExecuteNonQuery();
                    MainWindow.connection.Close();
                }
                if (CheckSoldVouch(vouch))
                {
                    using (SqlCommand command = new SqlCommand($"INSERT INTO [Sold_voucher] (Id_sold_voucher, count) VALUES ({vouch.id},{1})  ", MainWindow.connection))
                    {
                        MainWindow.connection.Open();
                        command.ExecuteNonQuery();
                        MainWindow.connection.Close();
                    }
                    
                }
                else
                {
                    using (SqlCommand command = new SqlCommand($"UPDATE [Sold_voucher] SET count=count+1 WHERE Id_sold_voucher={vouch.id}  ", MainWindow.connection))
                    {
                        MainWindow.connection.Open();
                        command.ExecuteNonQuery();
                        MainWindow.connection.Close();
                    }
                }

                using (SqlCommand command = new SqlCommand($"INSERT INTO [DateSoldVoucher] (id_voucher , DateSoldVoucher ) VALUES ({vouch.id}, CAST('{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} ' as datetime))  ", MainWindow.connection))
                {
                    MainWindow.connection.Open();
                    command.ExecuteNonQuery();
                    MainWindow.connection.Close();
                }

            }

        }

        private bool CheckSoldVouch(Voucher v)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Sold_voucher] WHERE Id_sold_voucher={v.id}  ", MainWindow.connection))
            {
                MainWindow.connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader s = command.ExecuteReader();
                if(s.HasRows)
                {
                    MainWindow.connection.Close();
                    s.Close();
                    return false;
                }
                else
                {
                    MainWindow.connection.Close();
                    s.Close();
                    return true;
                }
               
            }
        }

        private void buttonPlus1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (CheckVouch((page-1)*3))
            {
                var vouch = MainWindow.vouchers[(page - 1) * 3]; // MainWindow.vouchers[(page-1)*3+1] - для след поля
                if (MainWindow.user != null)
                {
                    PlusVoucher(vouch);
                }
                else
                    MessageBox.Show("Пожалуйста войдите в аккаунт.");


                return;
            }
            MessageBox.Show("Это поле пустое. Выбирите другую путевку.");
        }


        private void buttonPlus_Copy1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CheckVouch((page - 1) * 3 + 1 ))
            {
                var vouch = MainWindow.vouchers[(page - 1) * 3 + 1 ]; 
                if (MainWindow.user != null)
                {
                    PlusVoucher(vouch);
                }
                else
                    MessageBox.Show("Пожалуйста войдите в аккаунт.");


                return;
            }
            MessageBox.Show("Это поле пустое. Выбирите другую путевку.");
        }

        private void buttonPlus1_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CheckVouch((page - 1) * 3 + 2))
            {
                var vouch = MainWindow.vouchers[(page - 1) * 3 + 2]; 
                if (MainWindow.user != null)
                {
                    PlusVoucher(vouch);
                }
                else
                    MessageBox.Show("Пожалуйста войдите в аккаунт.");


                return;
            }
            MessageBox.Show("Это поле пустое. Выбирите другую путевку.");
        }

        private void buttonPlus1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
