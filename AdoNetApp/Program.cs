// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
namespace AdoNetApp
{
    class DbConnection
    {
        public static string ConnectionString
        {
            get{return "server=localhost; database=LtiDb;uid=sa;password=examlyMssql@123";}
        }
    }
    class Employee 
    {
        public int EmployeeId{get;set;}
        public string? EmployeeName{get;set;}
        public double Salary{get;set;}
        public DateTime JoinDate{get;set;}
    }
    class EmployeeDetails
    {
        SqlConnection con;
        public void AddEmployee(Employee emp)
        {
            try
            {   
                using (con=new SqlConnection(DbConnection.ConnectionString))
                {
                    con.Open();
                    string str=$"insert into Emplyees values ('{emp.EmployeeName}','{emp.Salary}','{emp.JoinDate}')";
                    SqlCommand cmd=new SqlCommand(str,con);
                    cmd.ExecuteNonQuery();
                }
                // return emp1;

                Console.WriteLine("Row inserted successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void GetmaximunSalary()
        {
            try
            {

                using (con=new SqlConnection(DbConnection.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd=new SqlCommand("select max(salary) from employees",con);
                    object obj=cmd.ExecuteScalar();
                    if(!Convert.IsDBNull(obj))
                        Console.WriteLine("Maximum salary is {0}",obj);
                    else 
                        Console.WriteLine("No employees present");
                }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteEmployee(int empid)
        {
            try 
            {
                using (con=new SqlConnection(DbConnection.ConnectionString))
                {
                    con.Open();
                    string str=$"delete from Emplyees where employeeid={empid}";
                    SqlCommand cmd=new SqlCommand(str,con);
                    int count=cmd.ExecuteNonQuery();
                
                    if(count==0)
                        Console.WriteLine("NO");
                    else
                        Console.WriteLine("Employee Deleted successfully"); 
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public void UpdateEmployee(int empid, Employee emp)
        {
            try 
            {
                using (con=new SqlConnection(DbConnection.ConnectionString))
                {
                con.Open();
                string str=$"update Emplyees set employeename='{emp.EmployeeName}',Salary='{emp.Salary}', joindate='{emp.JoinDate}'";
                SqlCommand cmd=new SqlCommand(str,con);
                int count=cmd.ExecuteNonQuery();
            
                if(count==0)
                    Console.WriteLine("No");
                else 
                    Console.WriteLine("Updated");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SearchEmployee(int empid)
        {
            try 
            {
                using (con=new SqlConnection(DbConnection.ConnectionString))
                {
                con.Open();
                string str=$"select * from Emplyees where employeeid={empid}";
                SqlCommand cmd=new SqlCommand(str,con);
                SqlDataReader reader=cmd.ExecuteReader();
                if(reader.Read()==true)
                {
                    Console.WriteLine(reader.GetInt32(0));
                    Console.WriteLine(reader.GetInt32(1));
                    Console.WriteLine(reader.GetInt32(3));
                
                }   
                {
                    Console.WriteLine("No such employee present");
                }
                reader.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void GetAllEmployees()
        {
            try 
            {
            using (con=new SqlConnection(DbConnection.ConnectionString))
            {
                con.Open();
                string str=$"select * from Emplyees";
                SqlCommand cmd=new SqlCommand(str,con);
                SqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read()==true)
                {
                    Console.WriteLine("{0},{1},{2},{3}",reader.GetInt32(0),reader.GetString(1),reader.GetDecimal(2),reader.GetDateTime(3));

                }
                reader.Close();
            }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    class Program 
    {
        public static void Main()
        {
            EmployeeDetails db=new EmployeeDetails();
            // string conStr="server=localhost; database=LtiDb;uid=sa;password=examlyMssql@123";
            // SqlConnection con=new SqlConnection(conStr);
            // con.Open();
            // string str="insert into Emplyees values('Rajesh',45037,'12-Dec-2022' )";
            // SqlCommand cmd=new SqlCommand(str,con);
            // cmd.ExecuteNonQuery();
            // con.Close();
            // con.Dispose();
            // Console.WriteLine("Row Inserted successfully");
            // List<Employee> list=new List<Employee>();
            Employee emp1=new Employee(){EmployeeId=101,EmployeeName="Ganesh",Salary=50000.00,JoinDate=DateTime.Parse("12-Dec-2022")};

            // db.AddEmployee(emp1);
            // list.Add(emp1);
            // foreach(var v in list)
            // {
            //     Console.WriteLine(v);
            // }
            // db.AddEmployee(emp1);
            db.GetmaximunSalary();
            

        }
    }
}
