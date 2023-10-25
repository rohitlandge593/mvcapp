using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MyMvcApp.Models
{
    
    public class Emplyees
    {
        public int EmployeeId{get;set;}
        
        public string? EmployeeName{get;set;}
        public double Salary{get;set;}
        public DateTime JoinDate{get;set;}

    }
}