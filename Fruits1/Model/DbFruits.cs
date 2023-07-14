using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fruits1.Model
{
    internal class DbFruits : IDisposable
    {
        SqlConnection connection = null;

        public DbFruits()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DbFruits"].ConnectionString;
            connection.Open();
        }
        public void Dispose()
        {
            connection.Close();
        }

        public List<Vegan> GetFruktiki()
        {
            string commandText = "SELECT * FROM Fruktiki";
            List<Vegan> fruitList = new List<Vegan>();

            var command = connection.CreateCommand();
            command.CommandText = commandText;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                fruitList.Add(new Vegan()
                {
                    Id = (int)reader["Id"],
                    name = (string)reader["name"],
                    type = (string)reader["type"],
                    color = (string)reader["color"],
                    callory = (int)reader["callory"]

                });
            }

            reader.Close();


            return fruitList;
        }
        public int MaxC()
        {
            string sqlExpression = "SELECT Max(Callory) FROM Fruktiki";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            object maxC = command.ExecuteScalar();
            //  return (int)maxC;
            return Convert.ToInt32(command.ExecuteScalar());
            //    return Convert.ToInt32(maxC);
        }
        public int MinC()
        {
            string sqlExpression = "SELECT Min(Callory) FROM Fruktiki";

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            object minC = command.ExecuteScalar();

            //    return (int)minC;
            return Convert.ToInt32(command.ExecuteScalar());

        }
        public int AvgC()
        {
            string sqlExpression = "SELECT AVG(Callory) FROM Fruktiki";

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            //  command.CommandText = "SELECT AVG(Callory) FROM Fruktiki";
            object avgC = command.ExecuteScalar();

            return Convert.ToInt32(command.ExecuteScalar());

        }

        public List<string> GetCallory1()//"Callory > 120"GetCallory1()//"Callory > 120"
        {
            string commandText = "SELECT Name, Callory from Fruktiki where Callory > 120 ";
            List<string> CalList1 = new List<string>();



            var command = connection.CreateCommand();
            command.CommandText = commandText;
            var reader = command.ExecuteReader();


            while (reader.Read())
            {
                CalList1.Add($"{reader[0]}: {reader[1]}");
            }

            reader.Close();

            return CalList1;
        }

        public List<string> GetCallory2()//"Callory < 120"
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT Name, Callory from Fruktiki where Callory < 120 ";
            SqlDataReader reader = command.ExecuteReader();

            List<string> CalList2 = new List<string>();

            while (reader.Read())
            {
                CalList2.Add($"{reader[0]}: {reader[1]}");
            }

            reader.Close();
            return CalList2;
        }


        public List<string> GetCallory3()//"Callory from 120 to 150"
        {

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT Name, Callory from Fruktiki where Callory BETWEEN 120 AND 150 ";
            SqlDataReader reader = command.ExecuteReader();

            List<string> CalList3 = new List<string>();

            while (reader.Read())
            {
                CalList3.Add($"{reader[0]}: {reader[1]}");
            }

            reader.Close();
            return CalList3;
        }

        public int CountF()
        {
            string sqlExpression = "SELECT COUNT(type) FROM Fruktiki where type='fruit'";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            object count = command.ExecuteScalar();
            // return (int)count;
            return Convert.ToInt32(command.ExecuteScalar());

        }
        public int CountV()
        {
            string sqlExpression = "SELECT COUNT(type) FROM Fruktiki where type='veg'";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            object count = command.ExecuteScalar();
            return (int)count;

        }

        //  ■ Показать количество овощей i фруктов каждого цвета;
        public List<string> GetQty()
        {
            //SqlCommand command = new SqlCommand();

            string commandText = "SELECT Color, COUNT(*) FROM Fruktiki GROUP BY Color";

            SqlCommand command = new SqlCommand(commandText, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string> QtyList = new List<string>();
            while (reader.Read())
            {
                QtyList.Add(
               $"{reader[0]}: {reader[1]}");
            }

            reader.Close();
            return QtyList;
        }
        //■ Показать все овощи и фрукты выбранного цвета 
        public List<string> GetRed(string red)
        {
           SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Name from Fruktiki WHERE color =@red";
            command.Connection = connection;
            command.Parameters.AddWithValue("@red", red);
            SqlDataReader reader = command.ExecuteReader();
            List<string> RedList = new List<string>();
            while (reader.Read())
            {
                RedList.Add(
                $"{reader["Name"]}");
            }
            reader.Close();
            return RedList;
        }
       
        //    listBox1.Items.Clear();

        



    }





}

