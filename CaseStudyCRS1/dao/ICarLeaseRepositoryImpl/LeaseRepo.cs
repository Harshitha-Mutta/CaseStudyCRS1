using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.Entities;
using CaseStudyCRS1.util;
using Microsoft.Data.SqlClient;

namespace CaseStudyCRS1.dao.ICarLeaseRepositoryImpl
{
    public class LeaseRepo:ILease
    {
        DBConnUtil obj = new DBConnUtil();
        public Lease createLease( int carId, int cusId, DateTime sd, DateTime ed,string type)
        {
            Lease lease = new Lease(carId, cusId, sd, ed, type);
            try
            {
                //Console.WriteLine(sd.ToLongDateString() + ed.ToLongDateString());
                string query = "INSERT INTO Lease VALUES (@carId, @cusId, @sd, @ed, @type)";
                
                SqlConnection con = obj.conObj();
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@carId", carId);
                cmd.Parameters.AddWithValue("@cusId", cusId);
                cmd.Parameters.AddWithValue("@sd", sd);
                cmd.Parameters.AddWithValue("@ed", ed);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.ExecuteNonQuery();
                string query1 = string.Format("UPDATE Vehicle set status =0 where VEHICLEID={0}", carId);
                SqlCommand cmd1=new SqlCommand(query1,con);
                
                int n = cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                //Console.WriteLine(n + " rows affected Successfully");
                con.Close();
                return lease;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return lease;
            }
            
        }
        public void returnCar(int lid)
        {
            try
            {
                
                Lease lease =findLeaseByID(lid);
                string query = string.Format("UPDATE Vehicle set status =" +
                    "1 where VEHICLEID={0}", lease.vehicleId);
                string query1 = string.Format("Update Lease set enddate=GETDATE() where leaseid={0}", lid);
                SqlConnection con = obj.conObj();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd1=new SqlCommand (query1,con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                int m = cmd1.ExecuteNonQuery();
                Console.WriteLine("Car returned Sucessfully");
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Lease> ListActiveLeases()
        {
            List<Lease> l1= new List<Lease>();
            try
            {
                SqlConnection con = obj.conObj();
                string query = string.Format("SELECT * FROM LEASE where ENDDATE>=GETDATE()");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    l1.Add(new Lease
                    {
                        leaseId = Convert.ToInt32(reader["Leaseid"]),
                        vehicleId = Convert.ToInt32(reader["VEHICLEID"]),
                        customerId = Convert.ToInt32(reader["CUSTOMERID"]),
                        startDate = Convert.ToDateTime(reader["STARTDATE"]),
                        endDate = Convert.ToDateTime(reader["ENDDATE"]),
                        type = Convert.ToString(reader["TYPE"])
                    }) ;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return l1;
        }
        public List<Lease> listLeaseHistory()
        {
            List<Lease> l1 = new List<Lease>();
            try
            {
                SqlConnection con = obj.conObj();
                string query = string.Format("SELECT * FROM LEASE");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    l1.Add(new Lease
                    {
                        leaseId = Convert.ToInt32(reader["Leaseid"]),
                        vehicleId = Convert.ToInt32(reader["VEHICLEID"]),
                        customerId = Convert.ToInt32(reader["CUSTOMERID"]),
                        startDate = Convert.ToDateTime(reader["STARTDATE"]),
                        endDate = Convert.ToDateTime(reader["ENDDATE"]),
                        type = Convert.ToString(reader["TYPE"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return l1;
        }
        public Lease findLeaseByID(int lid)
        {
            try
            {
                SqlConnection con = obj.conObj();
                string query = string.Format("select * from lease where leaseid={0}", lid);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (new Lease
                    {
                        leaseId = Convert.ToInt32(reader["LEASEID"]),
                        vehicleId = Convert.ToInt32(reader["VEHICLEID"]),
                        customerId = Convert.ToInt32(reader["CUSTOMERID"]),
                        startDate = Convert.ToDateTime(reader["STARTDATE"]).Date,
                        endDate = Convert.ToDateTime(reader["ENDDATE"]).Date,
                        type = reader["type"].ToString()
                    });

                }
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



    }
}
