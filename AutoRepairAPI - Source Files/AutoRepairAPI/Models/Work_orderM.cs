using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class Work_orderM {
        public int Work_order_id{ get; set;} //PK
        public bool Closed { get; set; }
        public decimal Amount_Due { get; set; }
        public string Vehicle_VIN { get; set; }//FK
        public int CustomerID { get; set; }//FK
        public Work_orderM(int Work_order_id1, bool Closed1, decimal Amount_Due1, string Vehicle_VIN1, int CustomerID1){
            Work_order_id = Work_order_id1;
            Closed = Closed1;
            Amount_Due = Amount_Due1;
            Vehicle_VIN = Vehicle_VIN1;
            CustomerID = CustomerID1;
        }
        public Work_orderM() { }
        public Work_orderM(SqlDataReader reader) {
            Work_order_id = reader.GetInt32(reader.GetOrdinal("Work_order_id"));
            Closed = reader.GetBoolean(reader.GetOrdinal("Closed"));
            if (reader[reader.GetName(reader.GetOrdinal("Amount_Due"))] != DBNull.Value)
                Amount_Due = reader.GetDecimal(reader.GetOrdinal("Amount_Due"));
            else
                Amount_Due = 0.0m;
            Vehicle_VIN = reader.GetString(reader.GetOrdinal("Vehicle_VIN"));
            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
        }

        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (Work_order_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Work_order_id must be greater than 0");
            }
            if (Amount_Due > 99999999.99m || Amount_Due < -99999999.99m)
            {
                Check.isValid = false;
                Check.list.Add("Amount_Due must be between -99999999.99 and 99999999.99");
            }
            if (!(Vehicle_VIN is null))
            {
                if (Vehicle_VIN.Length > 17 || Vehicle_VIN.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Vehicle_VIN is restricted to 17 characters");
                }
            }
            else
            {
                Check.isValid = false;
                Check.list.Add("Vehicle_VIN must not be null");
            }
            if (CustomerID < 1)
            {
                Check.isValid = false;
                Check.list.Add("CustomerID must be greater than 0");
            }

            return Check;
        }

        public TypeCheck SQLSchemaValidParameters_MINUS_WORK_ORDER_ID()
        {
            TypeCheck Check = SQLSchemaValidParameters();
            Check.list.Remove("Work_order_id must be greater than 0");
            if (Check.list.Count() > 0)
                return Check;
            return new TypeCheck();
        }
    }
}
