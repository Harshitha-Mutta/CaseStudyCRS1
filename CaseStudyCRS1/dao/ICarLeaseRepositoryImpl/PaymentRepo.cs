using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.Entities;
using CaseStudyCRS1.util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCRS1.dao.ICarLeaseRepositoryImpl
{
    public class PaymentRepo:IPayment
    {
        DBConnUtil obj = new DBConnUtil();
        public void recordPayment(Lease lease, double amount)
        {
            try
            {
                DateTime paymentDate= (DateTime.Now);
                string s1 = paymentDate.ToString("yyyy/MM/dd");
                //Console.WriteLine(paymentDateS);
                int year = Convert.ToInt32(s1.Substring(0, 4));
                int month = Convert.ToInt32(s1.Substring(5, 2));
                int day = Convert.ToInt32(s1.Substring(8, 2));
                DateTime sd1 = new DateTime(year, month, day);
                string query = "insert into Payment values(@LEASEID,@PAYMENTDATE,@AMOUNT)";
                SqlConnection con = obj.conObj();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@LEASEID", lease.leaseId);
                cmd.Parameters.AddWithValue("@PAYMENTDATE", sd1);
                cmd.Parameters.AddWithValue("@AMOUNT", amount);

                int n = cmd.ExecuteNonQuery();
                Console.WriteLine("Payment Successfull");
                con.Close();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Payment> ListPaymentHistory()
        {
            List<Payment> l1 = new List<Payment>();
            try
            {
                SqlConnection con = obj.conObj();
                string query = string.Format("SELECT * FROM PAYMENT");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    l1.Add(new Payment
                    {
                        paymentId = Convert.ToInt32(reader["PAYMENTID"]),
                        leaseId= Convert.ToInt32(reader["LEASEID"]),
                        paymentDate = Convert.ToDateTime(reader["PAYMENTDATE"]),
                        amount = Convert.ToInt32(reader["AMOUNT"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return l1;
        }
    }
}
