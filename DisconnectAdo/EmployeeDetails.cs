
using System.Data.SqlClient;
using System.Data;
using System;
namespace DisconnectAdo;

public class EmployeeDetails
{
    string conStr="server=localhost; database=LtiDb;uid=sa;password=examlyMssql@123";
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    string str;
    SqlCommandBuilder build;
    public EmployeeDetails()
    {
        con=new SqlConnection(conStr);
        
        con.Open();
        string str= "select employeeid, employeename, salary, joindate from Emplyees";
        da=new SqlDataAdapter(str,con);
        ds=new DataSet();
        build=new SqlCommandBuilder(da);
        da.MissingSchemaAction=MissingSchemaAction.AddWithKey;
        da.Fill(ds,"dtEmployees");
    }

    public void GetAllData()
    {
        
        
        foreach(DataRow row in ds.Tables[0].Rows)
        {
            Console.WriteLine("{0},{1},{2},{3}",row[0],row[1],row["salary"],row["joindate"]);
        }

    }
    public void AddEmployee(Emplyees emp)
    {
        DataRow? row=ds.Tables[0].NewRow();
        row["employeename"]=emp.EmployeeName;
        row["salary"]=emp.Salary;
        row["joindate"]=emp.JoinDate;
        ds.Tables[0].Rows.Add(row);
        ds.Update(ds.Tables[0]);
        Console.WriteLine("Row Inserted");
    }

    public void SearchEmployee(int empid)
    {
        DataRow? row= ds.Tables[0].Rows.Find(empid);
        if(row!=null)
        {
            Console.WriteLine($"{row["EmployeeId"]}, {row["EmployeeName"]},{row["Salary"]},{row["JoinDate"]}");
        }
        else 
        {
            Console.WriteLine("No");

        }
    }
    public void DeleteEmployee(int empid)
    {
        DataRow? row=ds.Tables[0].Rows.Find(empid);
        if(row!=null)
        {
            row.Delete();
            ds.Update(ds.Tables[0]);
        }
        else 
        {
            Console.WriteLine("no");
        }
    }

}
