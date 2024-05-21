using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.Entities;
using CaseStudyCRS1.util;
using Microsoft.Data.SqlClient;

namespace CaseStudyCRS1.dao.ICarLeaseRepositoryImpl
{
    public class VehicleRepo:IVehicle
    {
        DBConnUtil obj = new DBConnUtil();
        public void addCar(Vehicle v)
        {
            try
            {
                string query = 
                string.Format("insert into Vehicle values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",v.vehicleid,v.make,v.model,v.year,v.dailyrate,v.status,v.passengerCapacity,v.engineCapacity);
                SqlConnection con = obj.conObj();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                //Console.WriteLine(n + " rows affected Successfully");
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeCar(int vid)
        {
            try
            {
                string query = string.Format("Delete from Vehicle where vehicleid={0}", vid);
                SqlConnection con = obj.conObj();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                //Console.WriteLine(n + " rows affected Successfully");
                con.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Vehicle> listAvailableCars()
        {
            try
            {
                SqlConnection con = obj.conObj();
                string query = "select * from Vehicle where status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                List<Vehicle>vehicles =new List<Vehicle>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vehicles.Add(new Vehicle
                    {
                        vehicleid=Convert.ToInt32(reader["vehicleid"]),
                        make= reader["make"].ToString(),
                        model= reader["model"].ToString(),
                        year=Convert.ToInt32(reader["year"]),
                        dailyrate=Convert.ToInt32(reader["dailyrate"]),
                        status= Convert.ToInt32(reader["status"]),
                        passengerCapacity=Convert.ToInt32(reader["PASSENGERCAPACITY"]),
                        engineCapacity=Convert.ToSingle(reader["ENGINECAPACITY"])
                        
                    });
                }
                return vehicles;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<Vehicle> listRentedCars()
        {
            try
            {
                SqlConnection con = obj.conObj();
                int status = 0;
                string query1 = "select * from vehicle where status=0";
                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                List<Vehicle>vehicles=new List<Vehicle>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vehicles.Add(new Vehicle
                    {
                        vehicleid = Convert.ToInt32(reader["vehicleid"]),
                        make = reader["make"].ToString(),
                        model = reader["model"].ToString(),
                        year = Convert.ToInt32(reader["year"]),
                        dailyrate = Convert.ToInt32(reader["dailyrate"]),
                        status = Convert.ToInt32(reader["status"]),
                        passengerCapacity = Convert.ToInt32(reader["PASSENGERCAPACITY"]),
                        engineCapacity = Convert.ToSingle(reader["ENGINECAPACITY"])
                    });
                }
                return vehicles;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Vehicle findCarById(int carID)
        {
            
                SqlConnection con = obj.conObj();
                string query = string.Format("select * from Vehicle where vehicleid={0}",carID);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new Vehicle
                    {
                        vehicleid = Convert.ToInt32(reader["vehicleid"]),
                        make = reader["make"].ToString(),
                        model = reader["model"].ToString(),
                        year = Convert.ToInt32(reader["year"]),
                        dailyrate = Convert.ToInt32(reader["dailyrate"]),
                        status = Convert.ToInt32(reader["status"]),
                        passengerCapacity = Convert.ToInt32(reader["PASSENGERCAPACITY"]),
                        engineCapacity = Convert.ToSingle(reader["ENGINECAPACITY"])
                    };
                }
            return null;
            
            
        }
    }
}
