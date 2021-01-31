using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class EmployeeM {
        public int Employee_id{ get; set; }//PK
        public string Password { get; set; }
        public int Manager_id { get; set; }//FK
        public long Bank_acc_no { get; set; }
        public string Address{ get; set; }
        public string Lname { get; set; }
        public string Fname { get; set; }
        public decimal Salary_rate { get; set; }
        public decimal Hourly_rate { get; set; }
        public bool Pay_Type { get; set; }
        public bool MecFlag { get; set; }
        public bool CFlag { get; set; }
        public bool ManFlag { get; set; }
        public bool AFlag { get; set; }
        public EmployeeM(int Employee_id1, string Password1, int Manager_id1, long Bank_acc_no1, string Address1, string Lname1, string Fname1, decimal Salary_rate1, decimal Hourly_rate1,
                        bool Pay_Type1, bool MecFlag1, bool CFlag1, bool ManFlag1, bool AFlag1){
            Employee_id = Employee_id1;
            Password = Password1;
            Manager_id = Manager_id1;
            Bank_acc_no = Bank_acc_no1;
            Address = Address1;
            Lname = Lname1;
            Fname = Fname1;
            Salary_rate = Salary_rate1;
            Hourly_rate = Hourly_rate1;
            Pay_Type = Pay_Type1;
            MecFlag = MecFlag1;
            CFlag = CFlag1;
            ManFlag = ManFlag1;
            AFlag = AFlag1;
        }
        public EmployeeM(){}

        public EmployeeM(SqlDataReader reader) {
            Employee_id = reader.GetInt32(reader.GetOrdinal("Employee_id"));
            Password = reader.GetString(reader.GetOrdinal("EPassword"));
            Lname = reader.GetString(reader.GetOrdinal("Lname"));
            Fname = reader.GetString(reader.GetOrdinal("Fname"));
            Address = reader.GetString(reader.GetOrdinal("EAddress"));
            if (reader[reader.GetName(reader.GetOrdinal("Bank_acc_no"))] != DBNull.Value)
                Bank_acc_no = reader.GetInt64(reader.GetOrdinal("Bank_acc_no"));
            else
                Bank_acc_no = 0;
            if (reader[reader.GetName(reader.GetOrdinal("Salary_rate"))] != DBNull.Value)
                Salary_rate = reader.GetDecimal(reader.GetOrdinal("Salary_rate"));
            else
                Salary_rate = 0.0m;
            if (reader[reader.GetName(reader.GetOrdinal("Hourly_rate"))] != DBNull.Value)
                Hourly_rate = reader.GetDecimal(reader.GetOrdinal("Hourly_rate"));
            else
                Hourly_rate = 0.0m;
            Pay_Type = reader.GetBoolean(reader.GetOrdinal("Pay_Type"));
            MecFlag = reader.GetBoolean(reader.GetOrdinal("MecFlag"));
            CFlag = reader.GetBoolean(reader.GetOrdinal("CFlag"));
            ManFlag = reader.GetBoolean(reader.GetOrdinal("ManFlag"));
            AFlag = reader.GetBoolean(reader.GetOrdinal("AFlag"));
            if (reader[reader.GetName(reader.GetOrdinal("Manager_id"))] != DBNull.Value)
                Manager_id = reader.GetInt32(reader.GetOrdinal("Manager_id"));
            else
                Manager_id = 0;

        }

        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (Employee_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Employee_id must be greater than 0");
            }
            if (!(Password is null))
            {
                if (Password.Length > 128 || Password.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Password is restricted to 128 characters");
                }
            }
            else
            {
                Check.isValid = false;
                Check.list.Add("Password must not be null");
            }
            if (!(Lname is null))
            {
                if (Lname.Length > 128 || Lname.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Lname is restricted to 128 characters");
                }
            }
            if (!(Fname is null))
            {
                if (Fname.Length > 128 || Fname.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Fname is restricted to 128 characters");
                }
            }
            if (Manager_id < 0)
            {
                Check.isValid = false;
                Check.list.Add("Manager_id must be positive or 0/Null");
            }
            if (!(Address is null))
            {
                if (Address.Length > 256 || Address.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Lname is restricted to 256 characters");
                }
            }
            if (Bank_acc_no < 0)
            {
                Check.isValid = false;
                Check.list.Add("Bank_acc_no must be positive or 0");
            }
            if (Salary_rate > 99999999.99m || Salary_rate < -99999999.99m)
            {
                Check.isValid = false;
                Check.list.Add("Amount must be between -99999999.99 and 99999999.99");
            }
            if (Hourly_rate > 99999999.99m || Hourly_rate < -99999999.99m)
            {
                Check.isValid = false;
                Check.list.Add("Hours must be between -99999999.99 and 99999999.99");
            }
            //no need to check the booleans

            return Check;
        }

        public TypeCheck SQLSchemaValidParameters_MINUS_EMPLOYEE_ID()
        {
            TypeCheck Check = SQLSchemaValidParameters();
            Check.list.Remove("Employee_id must be greater than 0");
            if (Check.list.Count() > 0)
                return Check;
            return new TypeCheck();
        }
    }
}
