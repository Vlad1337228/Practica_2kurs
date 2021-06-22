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
    /// Логика взаимодействия для registerForm.xaml
    /// </summary>
    public partial class registerForm : Window
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            var name = textBoxName.Text;
            var email = textBoxEmail.Text;
            var pass = textBoxPass.Password;
            if(Check(name,email,pass))
            {
                ControllerUser cu = new ControllerUser();
                cu.RegisterUser(name, email, pass);
            }
            else
            {
                MessageBox.Show("Введите корректные данные. В полях должно быть не больше,чем 50 символов.");
                return;
            }    
        }

        private bool Check(string name, string email, string pass)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(pass))
            {
                    return false;
            }
            if (email.Contains("@mail.ru") && email.Length != 8 && email.Length <= 50)
            {
                return true;
            }
            return false;
        }
    }
}
