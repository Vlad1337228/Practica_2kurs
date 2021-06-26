using Practicka.Interfaces;
using Practicka.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicka.Controllers
{
    public class ControllerSold_Voucher : IControlSoldVouchers
    {
        public List<Sold_Voucher> ReturnSoldVoucher()
        {
            throw new NotImplementedException();
        }

        public static void WriteSoldVoucher(int id_voucher)
        {
            //string s = "SELECT * FROM [Sold_voucher] WHERE id='" + email + "' AND password='" + pass + "'";
            //using (SqlCommand command = new SqlCommand(s, MainWindow.connection))
            //{
            //    MainWindow.connection.Open();
            //    command.ExecuteNonQuery();
            //    SqlDataReader sqlDataReader = command.ExecuteReader();


            //    if (!sqlDataReader.HasRows)
            //    {
            //        sqlDataReader.Close();
            //        using (SqlCommand command1 = new SqlCommand($"INSERT INTO [Client] (email, password, name, id_voucher, count_voucher,sale) Values(@email, @pass, @name ,@id_voucher, @count_voucher , @sale )", MainWindow.connection))
            //        {
            //            command1.Parameters.AddWithValue("@name", name);
            //            command1.Parameters.AddWithValue("@email", email);
            //            command1.Parameters.AddWithValue("@pass", pass);
            //            command1.Parameters.AddWithValue("@id_voucher", 0);
            //            command1.Parameters.AddWithValue("@count_voucher", 0);
            //            command1.Parameters.AddWithValue("@sale", 0);
            //            command1.ExecuteNonQuery();
            //        }
            //        MessageBox.Show("Пользователь зарегестрирован.");
            //        MainWindow.connection.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Пользователь с этими данными уже есть.");
            //    }
            //    sqlDataReader.Close();
            //    MainWindow.connection.Close();
           // }
        }
    }
}
