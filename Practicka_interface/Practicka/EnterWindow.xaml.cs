using Practicka.Controllers;
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
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        public EnterWindow()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.register = new registerForm();
            MainWindow.register.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var email = boxEmail.Text;
            var pass = boxPass.Password;
            if(Check_Email(email) && Check_Pass(pass))
            {
                ControllerUser cu = new ControllerUser();
                if(cu.ReturnUser(email,pass))
                {
                    MessageBox.Show("Вы вошли");
                    MainWindow.mainWindow.buttonExit.Visibility = Visibility.Visible;
                    MainWindow.mainWindow.buttonEnter.Visibility = Visibility.Hidden;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден. Повторите попытку.");
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный email или пароль.В email и пароле должно быть больше чем 50 символов.");
            }
        }

        private bool Check_Pass(string pass)
        {
            if(string.IsNullOrEmpty(pass))
            {
                return false;
            }
            return true;
        }

        private bool Check_Email(string str)
        {
            if (str.Contains("@mail.ru") && str.Length!=8 && str.Length<=50)
                return true;
            else
                return false;
        }
    }
}
