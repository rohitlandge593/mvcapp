// See https://aka.ms/new-console-template for more information
using System;
namespace DisconnectAdo;

    class Program
    {
        public static void Main()
        {
            EmployeeDetails obj=new EmployeeDetails();
            // obj.GetAllData();
            Emplyees emp =new Emplyees();
            {
                EmployeeName="Deepak V";
                Salary=42000;
                JoinDate=Convert.ToDateTime("16-dec-1999");
            };

            obj.SearchEmployee(2);
        }
    }

