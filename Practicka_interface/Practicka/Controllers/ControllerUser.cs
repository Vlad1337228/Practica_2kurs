using Practicka.Interfaces;
using Practicka.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practicka.Controllers
{
    public class ControllerUser : IControlUser
    {
        public void RegisterUser(string name, string email, string pass)
        {
            string s = "SELECT * FROM [Client] WHERE email='" + email + "' AND password='" + pass + "'";
            using (SqlCommand command = new SqlCommand(s, MainWindow.connection))
            {
                MainWindow.connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader sqlDataReader = command.ExecuteReader();


                if (!sqlDataReader.HasRows)
                {
                    sqlDataReader.Close();
                    using (SqlCommand command1 = new SqlCommand($"INSERT INTO [Client] (email, password, name, id_voucher, count_voucher,sale) Values(@email, @pass, @name ,@id_voucher, @count_voucher , @sale )", MainWindow.connection))
                    {
                        command1.Parameters.AddWithValue("@name", name);
                        command1.Parameters.AddWithValue("@email", email);
                        command1.Parameters.AddWithValue("@pass", pass);
                        command1.Parameters.AddWithValue("@id_voucher", 0);
                        command1.Parameters.AddWithValue("@count_voucher", 0);
                        command1.Parameters.AddWithValue("@sale", 0);
                        command1.ExecuteNonQuery();
                    }
                    MessageBox.Show("Пользователь зарегестрирован.");
                    MainWindow.connection.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с этими данными уже есть.");
                }
                sqlDataReader.Close();
                MainWindow.connection.Close();
            }
        }

        public bool ReturnUser(string email,string pass)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM [Client]  WHERE email='" + email + "' AND password='" + pass + "'", MainWindow.connection))
            {
                MainWindow.connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (Check_RowsInDB(sqlDataReader))
                {
                    var user = new User();
                    bool prom=false;
                    (user, prom) = OutPutUser(sqlDataReader);
                    if (prom && user!=null)
                    {
                        MainWindow.user = user;
                        sqlDataReader.Close();
                        MainWindow.connection.Close();
                        if (user.id_voucher!=0)
                        {
                            ControllerVoucher cv = new ControllerVoucher();
                            cv.ReturnVoucher(MainWindow.user.id_voucher);
                        }
                        return true;
                    }
                }
                sqlDataReader.Close();
                MainWindow.connection.Close();
                return false;
            }

        }

        private (User,bool) OutPutUser(SqlDataReader sqlDataReader)
        {
            var user = new User();
            try
            {
                sqlDataReader.Read();
                user.id =(Int32) sqlDataReader.GetValue(0) ;
                user.id_voucher = (Int32)sqlDataReader.GetValue(1);
                user.name = sqlDataReader.GetString(2);
                user.email = sqlDataReader.GetString(3);
                user.password = sqlDataReader.GetString(4);
                user.count_vouchers = sqlDataReader.GetInt16(5);
                user.sale =(short)CheckSale(user.count_vouchers);
                return (user,true);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка системы. Название ошибки: " + e);
                return (null, false);
            }
        }

        private int CheckSale(int i)
        {
            if (i >= 1 && i < 3)
                return 2;
            if (i >= 3 && i < 7)
                return 5;
            if (i >= 7 && i < 10)
                return 8;
            if (i >= 10)
                return 10;
            return 0;
        }

        private bool Check_RowsInDB(SqlDataReader sql)
        {
            if (!sql.HasRows)
            {
                return false;
            }
            return true;

        }

        
    }
}
