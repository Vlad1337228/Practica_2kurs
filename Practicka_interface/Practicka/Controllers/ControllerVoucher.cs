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
    public class ControllerVoucher : IControlVoucher
    {
        private string d1=""; // для дат в методе returnVouchers
        private string d2="";
        private string s1 = "", s2 = ""; // для предложки, если нет подходящих дат

        private bool flag_date_deparure = false;
        public void ReturnVouchers(string country, string dep, string back, string min, string max, string city, string eat, int sale)
        {
            List<string> list = new List<string>();
            string request;
            if (!string.IsNullOrEmpty(country))
            {
                list.Add($"country=N'{country}'");
            }
            if (!string.IsNullOrEmpty(city))
            {
                list.Add($"city=N'{city}'");
            }
            if (!string.IsNullOrEmpty(eat))
            {
                list.Add($"eating=N'{eat}'");
            }
            if(CheckDate(dep))
            {
                 d1 = DateToString(DateTime.Parse(dep));
            }
            if (CheckDate(back))
            {
                d2 = DateToString(DateTime.Parse(back));
            }
            BetweenDate(d1, d2, list);
            CheckPrice(min, max, list);
            request=CommandSQL(list);
            using (SqlCommand command = new SqlCommand(request, MainWindow.connection))
            {
                MainWindow.connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                OutVouchers(sqlDataReader);
                MainWindow.connection.Close();
                sqlDataReader.Close();
                if (CheckMoreDate(request,MainWindow.vouchers.Count , dep,back) && !flag_date_deparure)
                {

                    flag_date_deparure = true;
                    ReturnVouchers(country,s1,s2,min,max,city,eat,sale);
                }
                
            }
            
             flag_date_deparure=false;
        }

        private bool CheckMoreDate(string request, int count ,string dep , string back)
        {
            
            if (request.Contains("departure") && count==0 && !request.Contains("back"))
            {
                MessageBox.Show("По вашему запросу ничего не найдено, поэтому мы нашли для вас похожие предложения!");
                s1=MounthMore(dep,-1);
                //var date = dep.Split('.');
                //string s = date[0] + "." + CheckMounth(int.Parse(date[1]), -1).ToString() + date[2];
                return true;
            }
            if (request.Contains("back") && count == 0 && !request.Contains("departure"))
            {
                MessageBox.Show("По вашему запросу ничего не найдено, поэтому мы нашли для вас похожие предложения!");
                s2=MounthMore(back, 1);
                return true;
                //var date = back.Split('.');
                //string s = date[0] + "." + CheckMounth(int.Parse(date[1]), 1 ).ToString() + date[2];
            }
            if (request.Contains("departure") && count == 0 && request.Contains("back"))
            {
                MessageBox.Show("По вашему запросу ничего не найдено, поэтому мы нашли для вас похожие предложения!");
                s1=MounthMore(dep, -1);
                s2=MounthMore(back, 1);
                return true;
            }
            return false;
        }

        private string MounthMore(string date_, int i)
        {
            var date = date_.Split('.');
            return date[0] + "." + CheckMounth(int.Parse(date[1]), i).ToString() + "." + date[2];
        }

        private int CheckMounth(int mounth , int r)
        {
            if(mounth+r<1)
                return 12;
            
            if (mounth + r > 12)
                return 1;

            return mounth + r;
        }

        public void BetweenDate(string dt1,string dt2 , List<string> l)
        {
            if (dt1 != "" && dt2!="")
            {
                l.Add(@" departure >=  '" + dt1.ToString() + "' AND back<='" + dt2.ToString() + "'");
                return;
            }
            if (dt1 != "" && dt2 == "")
            {
                l.Add($" departure >=  '" + dt1.ToString() + "' ");
                return;
            }
            if (dt1 == "" && dt2!="")
            {
                l.Add($" back <=  '" + dt2.ToString() + "' ");
                return;
            }
        }

        public string DateToString(DateTime dt)
        {
            string s = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            return s;
        }
        public void OutVouchers(SqlDataReader sql)
        {
            List<Voucher> l = new List<Voucher>();
            while(sql.Read())
            {
                Voucher v = new Voucher();
                v.id= (Int32)sql.GetValue(0);
                v.sold = (Int32)sql.GetValue(1);
                v.send = (DateTime)sql.GetValue(2);
                v.back = (DateTime)sql.GetValue(3);
                v.excursion= sql.GetValue(4).ToString();
                v.eating= sql.GetValue(5).ToString();
                v.city= sql.GetValue(6).ToString();
                v.country= sql.GetValue(7).ToString();
                l.Add(v);
            }
            MainWindow.vouchers = l;
        }

        private string CommandSQL(List<string> list)
        {
            string str = "SELECT * FROM [Voucher] ";
            int e = -1;
            int n;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    e = i;
            }
            if (e != -1)
            {
                str += " WHERE ";
            }
            if (e == 0 && e == list.Count)
                n = list.Count;
            else
                n = e;
            for (int i = 0; i < n; i++)
            {
                if (list[i] != null)
                {

                    str += list[i];
                    str += " AND ";
                }
            }
            if (n == -1)
                return str;
            str += list[n];
            return str;
        }

        private void CheckPrice(string s1,string s2, List<string> l)
        {
            int p1 = -1;
            int p2 = -1;

            if (!string.IsNullOrEmpty(s1))
            {
                try
                {
                    p1 = int.Parse(s1);
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные в первое поле стоимости ");
                }
            }
            if (!string.IsNullOrEmpty(s2))
            {
                try
                {
                    p2 = int.Parse(s2);
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные во второе поле стоимости ");
                }
            }
            if(p1!=-1 && p2!=-1)
            {
                l.Add(@" price BETWEEN  '" + p1.ToString() + "' AND '" + p2.ToString() + "'");
                return;
            }
            if(p1!=-1 && p2==-1)
            {
                l.Add($" price >=  '" + p1.ToString() + "' ");
                return;
            }
            if (p1 == -1 && p2 != -1)
            {
                l.Add($" price <=  '" + p2.ToString() + "' ");
                return;
            }
        }

        private bool CheckDate(string s)
        {
            DateTime d;
            if (!string.IsNullOrEmpty(s))
            {
                try
                {
                    d = DateTime.Parse(s);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные в поля даты.");
                }
            }
            return false;
        }

       
        public void ReturnVoucher(int id_voucher)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Voucher] WHERE id={id_voucher} ", MainWindow.connection))
            {
                MainWindow.connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                OutVoucher(sqlDataReader);
                MainWindow.connection.Close();
                sqlDataReader.Close();
            }
        }

        private void OutVoucher(SqlDataReader sql)
        {
            Voucher v = new Voucher();
            while (sql.Read())
            {
                v.id = (Int32)sql.GetValue(0);
                v.sold = (Int32)sql.GetValue(1);
                v.send = (DateTime)sql.GetValue(2);
                v.back = (DateTime)sql.GetValue(3);
                v.excursion = sql.GetValue(4).ToString();
                v.eating = sql.GetValue(5).ToString();
                v.city = sql.GetValue(6).ToString();
                v.country = sql.GetValue(7).ToString();
               
            }
            MainWindow.voucher = v;
        }
    }
}
