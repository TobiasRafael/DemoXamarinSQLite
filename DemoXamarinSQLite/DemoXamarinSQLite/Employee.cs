using SQLite.Net.Attributes;
using System;

namespace DemoXamarinSQLite
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int IDEmployee { get; set; }

        public string Names { get; set; }

        public string LastNames { get; set; }

        public DateTime ContractDate { get; set; }

        public decimal Salary { get; set; }
        public bool Active { get; set; }

        public string CompleteName
        {
            get
            {
                return string.Format("{0} {1}", this.Names, this.LastNames);
            }
        }
        public string ContractDateEdited
        {
            get
            {
                return string.Format("{0:yy-MM-dd}", ContractDate);
            }

        }

        public string EditedSalary
        {
            get
            {
            return string.Format("{0:C2}",Salary);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", IDEmployee, CompleteName, ContractDateEdited, EditedSalary,Active);
        }
        
    }
}
