using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class PartM
    {
        public int Part_id { get; set; } //PK FK
        public int Part_instance_id { get; set; } //PK
        public string State { get; set; }
        public decimal Price { get; set; }
        public int Work_order_id { get; set; } //FK
        public PartM(int Part_id1, int Part_instance_id1, string State1, decimal Price1, int Work_order_id1)
        {
            Part_id = Part_id1;
            Part_instance_id = Part_instance_id1;
            State = State1;
            Price = Price1;
            Work_order_id = Work_order_id1;
        }
        public PartM() { }

        public PartM(SqlDataReader reader)
        {
            Part_id = reader.GetInt32(reader.GetOrdinal("Part_id"));
            Part_instance_id = reader.GetInt32(reader.GetOrdinal("Part_instance_no"));
            State = reader.GetString(reader.GetOrdinal("PState"));
            if (reader[reader.GetName(reader.GetOrdinal("Price"))] != DBNull.Value)
                Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            else
                Price = 0.0m;
            if (reader[reader.GetName(reader.GetOrdinal("Work_order_id"))] != DBNull.Value)
                Work_order_id = reader.GetInt32(reader.GetOrdinal("Work_order_id"));
            else
                Work_order_id = 0;
        }

        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (Part_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Part_id must be greater than 0");
            }
            if (Part_instance_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Part_instance_id must be greater than 0");
            }
            if (!(State is null))
            {
                if (State.Length > 32 || State.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("State is restricted to 32 characters");
                }
            }
            if (Price > 99999999.99m || Price < -99999999.99m)
            {
                Check.isValid = false;
                Check.list.Add("Price must be between -99999999.99 and 99999999.99");
            }
            if (Work_order_id < 0)
            {
                Check.isValid = false;
                Check.list.Add("Work_order_id must be positive or 0");
            }

            return Check;
        }
        public TypeCheck SQLSchemaValidParameters_MINUS_INSTANCE_ID()
        {
            TypeCheck Check = SQLSchemaValidParameters();
            Check.list.Remove("Part_instance_id must be greater than 0");
            if (Check.list.Count() > 0)
                return Check;
            return new TypeCheck();
        }
    }
}
