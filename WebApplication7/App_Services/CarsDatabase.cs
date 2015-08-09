using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.App_Services
{
    public class CarsDatabase
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public static List<Car> getCars()
        {
            string query = "SELECT Id, Brand, Model, Price, Year, Volume FROM Cars";
            List<Car> cars = new List<Car>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Car car = new Car();
                            car.ID = reader.GetInt32(0);
                            string brand = reader.GetString(1);
                            car.Brand = brand.TrimEnd(' ');
                            string model = reader.GetString(2);
                            car.Model = model.TrimEnd(' ');
                            car.Price = reader.GetDecimal(3);
                            car.Year = reader.GetInt32(4);
                            car.Volume = reader.GetInt32(5);

                            cars.Add(car);
                        }

                        return cars;
                    }
                }
            }
        }

        public static Car getCar(int id)
        {
            string query = "SELECT Brand, Model, Price, Year, Volume FROM Cars WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Car car = new Car();
                            car.ID = id;
                            string brand = reader.GetString(0);
                            car.Brand = brand.TrimEnd(' ');
                            string model = reader.GetString(1);
                            car.Model = model.TrimEnd(' ');
                            car.Price = reader.GetDecimal(2);
                            car.Year = reader.GetInt32(3);
                            car.Volume = reader.GetInt32(4);
                            return car;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static void deleteCar(int id)
        {
            string query = "DELETE FROM Cars WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void addCar(Car car)
        {
            string query = ("INSERT INTO Cars (Brand, Model, Price, Year, Volume)");
            query += " VALUES (@Brand, @Model, @Price, @Year, @Volume)";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Brand", car.Brand);
                    cmd.Parameters.AddWithValue("@Model", car.Model);
                    cmd.Parameters.AddWithValue("@Price", car.Price);
                    cmd.Parameters.AddWithValue("@Year", car.Year);
                    cmd.Parameters.AddWithValue("@Volume", car.Volume);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}