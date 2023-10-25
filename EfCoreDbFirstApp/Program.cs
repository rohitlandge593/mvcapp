// See https://aka.ms/new-console-template for more information
using EfCoreDbFirstApp.Data;
using Microsoft.EntityFrameworkCore;
MyDatabaseContext db=new MyDatabaseContext();
//Employee emp=new Employee();
// {
//     emp.EmployeeName="ABCDE";
//     emp.DepartmentId=1;
//     emp.Salary=35000;
//     emp.JoinDate=DateTime.Parse("12-Dec-2022");

// }
// db.Employees.Add(emp);
// db.SaveChanges();
// Console.WriteLine("Row Inserted Successfully into Id:{0} successfully",emp.EmployeeId);
// foreach(var emp in db.Employees)
// {
//     Console.WriteLine("{0},{1},{2},{3}",emp.EmployeeId,emp.EmployeeName,emp.Department.DepartmentName,emp.Salary);
// }
// var emp=db.Employees.Find(2);
// if(emp!=null)
//     Console.WriteLine("{0},{1},{2}",emp.EmployeeId,emp.EmployeeName,emp.Salary);
// else
//     Console.WriteLine("No");

// var emp=db.Employees.Find(2);
// if(emp!=null)
// {
//     db.Remove(emp);
//     db.SaveChanges();
//     Console.WriteLine("Deleted");
// }
// else
//     Console.WriteLine("No");

//var emp=db.Employees.Find(1);

foreach(var emp in db.Employees.Include("Department"))
{
    emp.EmployeeName="ABCDE";
    emp.Salary=35000;
    db.SaveChanges();
    Console.WriteLine("{0},{1},{2},{3}",emp.EmployeeId,emp.EmployeeName,emp.Department.DepartmentName,emp.Salary);
}