using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace MyMvcApp.Controllers;
//  class DbConnection
//     {
//         public static string ConnectionString
//         {
//             get{return "server=localhost; database=LtiDb;uid=sa;password=examlyMssql@123";}
//         }
//     }

public class HomeController : Controller
{
    SqlConnection con;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ViewResult Index()
    {
        // string str="Welcome to ASP.Net Core MVC App";
        // ViewData["message"]=str;
        // ViewBag.message2="ASP.Net Core Entity Framework";
        // List<string> list=new List<string>();
        // list.Add("Virat");
        // list.Add("Rohit");
        // list.Add("Suresh");
        // list.Add("Shikhar");
        // ViewBag.message2=list;
        // Employee empObj=new Employee{
        //     EmployeeId=101,
        //     EmployeeName="AAAA",
        //     Salary=40000,
        //     JoinDate=DateTime.Parse("12-Dec-2022")};
        List<Emplyees> empList=new List<Emplyees>();
        string str="server=localhost; database=LtiDb;uid=sa;password=examlyMssql@123";
        using(con=new SqlConnection(str))
        {
            con.Open();
            string strl="select * from Emplyees";
            SqlCommand cmd=new SqlCommand(strl,con);
            SqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()==true)
            {
                Emplyees emp=new Emplyees();
                emp.EmployeeId=reader.GetInt32(0);
                emp.EmployeeName=reader.GetString(1);
                emp.Salary=(double)reader.GetDecimal(2);
                emp.JoinDate=reader.GetDateTime(3);
                empList.Add(emp);

                
            }
            reader.Close();
            return View(empList);
            
        }
        

    }
    public ViewResult Create()
    {
        string str="server=localhost; database=LtiDb;uid=sa;password=examlyMssql@123";
        using(con=new SqlConnection(str))
        {
            con.Open();
            Emplyees emp=new Emplyees{
                EmployeeName="ABCDF",
                Salary=93000,
                JoinDate=DateTime.Parse("12-Dec-2021")
            };
            SqlCommand cmd=new SqlCommand("proc_InsertEmployee",con);
            cmd.CommandType=CommandType.StoredProcedure;

            SqlParameter p_employeeid=new SqlParameter("@employeeid",System.Data.SqlDbType.Int);
            p_employeeid.Direction=ParameterDirection.Output;
            cmd.Parameters.Add(p_employeeid);

           cmd.Parameters.AddWithValue("@employeename",emp.EmployeeName);
           cmd.Parameters.AddWithValue("@salary",emp.Salary);
           cmd.Parameters.AddWithValue("@ejoindate",emp.JoinDate);

           cmd.ExecuteNonQuery();
           ViewBag.employeeid=p_employeeid.Value;
    return View();


        }
    } 
    

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult ContactUs()
    {
        return View();
    }
    public ContentResult Content()
    {
        return Content("Welcome to ASP.Net MVC");

    }
    public FileResult FileDownload()
    {
        return File("/audio/rajthakre.mp3","audio/mp3","rajthakre.mp3");
    }
    public RedirectResult Redirect()
    {
        return Redirect("/https://www.facebook.com");
    }
    public JsonResult Json()
    {
        List<string> obj=new List<string>{"India","Russia","Japan"};
        return Json(obj);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
