using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class Employee_invoiceM
    {
        public int Invoice_id { get; set; }//PK
        public int Employee_id { get; set; }//PK FK
        public decimal Amount { get; set; }
        public DateTime Interval_Start_Date{ get; set;} //only the date will be concidered 
        public DateTime Interval_End_Date { get; set; }  //only the date will be concidered 
        public DateTime Payment_Date { get; set; }  //only the date will be concidered 
        public decimal Hours { get; set; }
        public Employee_invoiceM(int Invoice_id1, int Employee_id1, decimal Amount1, DateTime Interval_Start_Date1
                            , DateTime Interval_End_Date1, DateTime Payment_Date1, decimal Hours1) {
            Invoice_id = Invoice_id1;
            Employee_id = Employee_id1;
            Amount = Amount1;
            Interval_Start_Date = Interval_Start_Date1;
            Interval_End_Date = Interval_End_Date1;
            Payment_Date = Payment_Date1;
            Hours = Hours1;
        }
        public Employee_invoiceM(){}

        public Employee_invoiceM(SqlDataReader reader) {
            Invoice_id = reader.GetInt32(reader.GetOrdinal("Invoice_id"));
            Employee_id = reader.GetInt32(reader.GetOrdinal("Employee_id"));
            if (reader[reader.GetName(reader.GetOrdinal("Amount"))] != DBNull.Value)
                Amount = reader.GetDecimal(reader.GetOrdinal("Amount"));
            else
                Amount = 0.0m;
            Interval_Start_Date = reader.GetDateTime(reader.GetOrdinal("Interval_Start_Date"));
            Interval_End_Date = reader.GetDateTime(reader.GetOrdinal("Interval_End_Date"));
            Payment_Date = reader.GetDateTime(reader.GetOrdinal("Payment_Date"));
            if (reader[reader.GetName(reader.GetOrdinal("WHours"))] != DBNull.Value)
                Hours = reader.GetDecimal(reader.GetOrdinal("WHours"));
            else
                Hours = 0.0m;
        }
        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (Invoice_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Invoice_id must be greater than 0");
            }
            if (Employee_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Employee_id must be greater than 0");
            }
            if(Amount > 99999999.99m || Amount < -99999999.99m)
            {
                Check.isValid = false;
                Check.list.Add("Amount must be between -99999999.99 and 99999999.99");
            }
            if (Hours > 99999999.99m || Hours < -99999999.99m)
            {
                Check.isValid = false;
                Check.list.Add("Hours must be between -99999999.99 and 99999999.99");
            }

            return Check;
        }

        public TypeCheck SQLSchemaValidParameters_MINUS_INVOICE_ID()
        {
            TypeCheck Check = SQLSchemaValidParameters();
            Check.list.Remove("Invoice_id must be greater than 0");
            if (Check.list.Count() > 0)
                return Check;
            return new TypeCheck();
        }
    }
}
