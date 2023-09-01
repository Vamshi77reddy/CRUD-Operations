using System;
using System.Data.SqlClient;

namespace CRUDapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=LAPTOP-IB990ERS\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True";
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
               Console.WriteLine("Connected sucessfully");

                Console.WriteLine("Select from the options\n1.Create\n2.Retrieve\n3.Update\n4.Delete");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Id");
                int id=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Salary");
                int Salary = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Gender");
                string Gender = Console.ReadLine();
                Console.WriteLine("Enter Dep");
                string Dep = Console.ReadLine();
                Console.WriteLine("Enter city");
                string City = Console.ReadLine();
                string insertQuery= "INSERT INTO employee(e_id,e_name,e_age,e_salary,e_gender,e_dep,e_city) values("+ id+",'"+Name+"',"+age+",'"+Salary+"','"+Gender+"','"+Dep+"','"+City+"')";
                SqlCommand insertcommand = new SqlCommand(insertQuery,sqlConnection);
                insertcommand.ExecuteNonQuery();
                Console.WriteLine   ("data added successfully");
                        break;


                    case 2:
                string displayQuery = "SELECT * FROM EMPLOYEE";
                SqlCommand disp=new SqlCommand(displayQuery,sqlConnection);
                SqlDataReader dataread= disp.ExecuteReader();
                while(dataread.Read())
                {
                    Console.WriteLine("Id - " + dataread.GetValue(0).ToString());
                    Console.WriteLine("Name - " + dataread.GetValue(1).ToString());
                    Console.WriteLine("Age - " + dataread.GetValue(2).ToString());
                    Console.WriteLine("Salary - " + dataread.GetValue(3).ToString());
                    Console.WriteLine("Gender - " + dataread.GetValue(4).ToString());
                    Console.WriteLine("Dep - " + dataread.GetValue(5).ToString());
                    Console.WriteLine("City - " + dataread.GetValue(6).ToString());


                }
                dataread.Close();
                        break;
                    case 3:
                        String u_name;
                        int u_id;
                        Console.WriteLine("Enter the id of the entry to be Updated");
                        u_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the name you would like to change");
                        u_name = Console.ReadLine();
                        String updateQuery = "UPDATE employee SET e_name = '" + u_name + "' WHERE e_id = " + u_id + "";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                        updateCommand.ExecuteNonQuery();
                        Console.WriteLine("Successfully updated");
                        break;

                    case 4:
                        int d_id;
                        Console.WriteLine("Enter the id of the entry to be removed");
                        d_id = int.Parse(Console.ReadLine());
                        String deleteQuery = "DELETE FROM employee WHERE e_id = " + d_id + "";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                        deleteCommand.ExecuteNonQuery();
                        Console.WriteLine("Successfully deleted");
                        break;
                    default:
                        Console.WriteLine("Please enter the valid choice");
                        break;
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
