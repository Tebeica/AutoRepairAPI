using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRepairAPI;

namespace AutoRepairAPI.Models
{
    public class Associated_withM
    {
        public int Clerk_id { get; set; }//PK FK
        public int Work_order_id { get; set; }//PK FK
        public Associated_withM(int Clerk_id1, int Work_order_id1)
        {
            Clerk_id = Clerk_id1;
            Work_order_id = Work_order_id1;
        }
        public Associated_withM() { }

        public Associated_withM(SqlDataReader reader) {
            Clerk_id = reader.GetInt32(reader.GetOrdinal("Clerk_id"));
            Work_order_id = reader.GetInt32(reader.GetOrdinal("Work_order_id"));
        }
        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (Clerk_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Clerk_id must be greater than 0");
            }
            if (Work_order_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Work_order_id must be greater than 0");
            }
            return Check;
        }
    }
}
