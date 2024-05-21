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
    public class CustomerRepo:ICustomer
    {
        DBConnUtil obj = new DBConnUtil();
        public void addCustomer(Customer c)
        {
            try
            {
                string query =
                string.Format("insert into Customer values('{0}','{1}','{2}','{3}','{4}')", c.customerID, c.firstname,c.lastname,c.email,c.phoneNumber);
                SqlConnection con = obj.conObj();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                //Console.WriteLine(n + " rows affected Successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeCustomer(int cid)
        {
            try
            {
                string query = string.Format("Delete from Customer where CUSTOMERID ={0}", cid);
                SqlConnection con = obj.conObj();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                //Console.WriteLine(n + " rows affected Successfully");
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Customer> listCustomers()
        {
            try
            {
                SqlConnection con = obj.conObj();
                string query = "select * from Customer";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                List<Customer> c1 = new List<Customer>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c1.Add (new Customer
                    {
                        customerID = Convert.ToInt32(reader["customerid"]),
                        firstname = reader["firstname"].ToString(),
                        lastname = reader["lastname"].ToString(),
                        email = (reader["email"]).ToString(),
                        phoneNumber = (reader["phonenumber"]).ToString()
                    });

                }
                return c1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Customer findCustomerById(int customerID)
        {
            try
            {
                SqlConnection con = obj.conObj();
                string query = string.Format("select * from customer where customerid={0}", customerID);
                SqlCommand cmd = new SqlCommand(query, con);                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (new Customer
                    {
                        customerID = Convert.ToInt32(reader["customerid"]),
                        firstname = reader["firstname"].ToString(),
                        lastname = reader["lastname"].ToString(),
                        email = (reader["email"]).ToString(),
                        phoneNumber = (reader["phonenumber"]).ToString()
                    });

                }
                return null;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}
