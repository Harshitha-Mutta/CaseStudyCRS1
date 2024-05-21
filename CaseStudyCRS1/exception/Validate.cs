using CaseStudyCRS1.util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CaseStudyCRS1.exception
{
    public class Validate
    {
        DBConnUtil obj = new DBConnUtil();
        public Validate() { }
        public bool isCarAvailable(int vid)
        {
            
                SqlConnection con = obj.conObj();
                string query = ("select vehicleid from Vehicle");
                SqlCommand cmd = new SqlCommand(query, con);
                List<int> s1 = new List<int>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s1.Add(Convert.ToInt32(reader["vehicleid"]));
                }
                if (s1.Contains(vid))
                {
                    return true;
                }
                return false;
            
        }
        public bool isCustomerAvailable(int cid)
        {
            SqlConnection con = obj.conObj();
            string query = ("select customerid from customer");
            SqlCommand cmd = new SqlCommand(query, con);
            List<int> s1 = new List<int>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1.Add(Convert.ToInt32(reader["customerid"]));
            }
            if (s1.Contains(cid))
            {
                return true;
            }
            return false;
        }
        public bool isLeaseAvailable(int lid)
        {
            SqlConnection con = obj.conObj();
            string query = ("select leaseid from Lease");
            SqlCommand cmd = new SqlCommand(query, con);
            List<int> s1 = new List<int>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1.Add(Convert.ToInt32(reader["leaseid"]));
            }
            if (s1.Contains(lid))
            {
                return true;
            }
            return false;
        }
        public bool isCarForRent(int cid)
        {
            SqlConnection con = obj.conObj();
            string query = "select vehicleid from Vehicle where status=1";
            SqlCommand cmd = new SqlCommand(query, con);
            List<int> s1 = new List<int>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1.Add(Convert.ToInt32(reader["vehicleid"]));
            }
            if (s1.Contains(cid))
            {
                return true;
            }
            return false;
        }
        public bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Use MailAddress class to validate email format
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
