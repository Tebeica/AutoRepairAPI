using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class CustomerM{
        public int CustomerID { get; set; } //PK
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone_number { get; set; }
        public string Address { get; set; }
        public CustomerM(int CustomerID1, string Fname1, string Lname1, string Phone_number1, string Address1){
            CustomerID = CustomerID1;
            Fname = Fname1;
            Lname = Lname1;
            Phone_number = Phone_number1;
            Address = Address1;
        }
        public CustomerM() { }
        public CustomerM(SqlDataReader reader) {
            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            Fname = reader.GetString(reader.GetOrdinal("Fname"));
            Lname = reader.GetString(reader.GetOrdinal("Lname"));
            Address = reader.GetString(reader.GetOrdinal("CAddress"));
            Phone_number = reader.GetString(reader.GetOrdinal("Phone_number"));
        }
        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (CustomerID < 1)
            {
                Check.isValid = false;
                Check.list.Add("CustomerID must be greater than 0");
            }
            if (!(Fname is null))
            {
                if (Fname.Length > 128 || Fname.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Fname is restricted to 128 characters");
                }
            }
            if (!(Lname is null))
            {
                if (Lname.Length > 128 || Lname.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Lname is restricted to 128 characters");
                }
            }
            if (!(Phone_number is null))
            {
                if (Phone_number.Length > 15 || Phone_number.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Lname is restricted to 15 characters");
                }
            }
            if (!(Address is null))
            {
                if (Address.Length > 256 || Address.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Lname is restricted to 256 characters");
                }
            }

            return Check;
        }
        public TypeCheck SQLSchemaValidParameters_MINUS_CUSTOMER_ID()
        {
            TypeCheck Check = SQLSchemaValidParameters();
            Check.list.Remove("CustomerID must be greater than 0");
            if (Check.list.Count() > 0)
                return Check;
            return new TypeCheck();
        }
    }
}
