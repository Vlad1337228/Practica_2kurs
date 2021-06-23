using Practicka.Controllers;
using Practicka.Model;
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
using System.Windows.Shapes;

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
                this.textBoxSale.Text = MainWindow.user.sale.ToString()+"%";
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
            //comboBoxEating.Items.Add("Завтрак");
            //comboBoxEating.Items.Add("Обед");
            //comboBoxEating.Items.Add("Ужин");
            //comboBoxEating.Items.Add("Все включено");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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
            
            if(!voucher.ReturnVouchers(country, departure, back, price_min,price_max, city, eating, sale))
            {
                if(MainWindow.vouchers==null)
                {

                }
                else
                {
                    DisplayVoucher();
                }
            }
            
            

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

        private void DeleteVoucherInfo()
        {
            throw new NotImplementedException();//доделать удаление инфы из объявлений
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

        private void imageArrowRight1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
