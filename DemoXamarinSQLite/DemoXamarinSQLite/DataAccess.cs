using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DemoXamarinSQLite
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Platform,
                System.IO.Path.Combine(config.DirectoryDB, "Employees.db3"));
            connection.CreateTable<Employee>();
        }

        public void InsertEmployee(Employee employee)
        {
            connection.Insert(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            connection.Update(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            connection.Delete(employee);
        }
        public Employee GetEmployee(int IDEmployee)
        {
            return connection.Table<Employee>().FirstOrDefault(c => c.IDEmployee == IDEmployee);
        }
        public List<Employee> GetEmployees()
        {
            return connection.Table<Employee>().OrderBy(c => c.LastNames).ToList();
        }
        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
