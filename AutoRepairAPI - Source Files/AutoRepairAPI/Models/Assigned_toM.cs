using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRepairAPI;

namespace AutoRepairAPI.Models
{
    public class Assigned_toM
    {
        public int Mechanic_id { get; set; }//PK FK
        public int Work_order_id { get; set; }//PK FK
        public Assigned_toM(int Mechanic_id1, int Work_order_id1)
        {
            Mechanic_id = Mechanic_id1;
            Work_order_id = Work_order_id1;
        }
        public Assigned_toM(){}

        public Assigned_toM(SqlDataReader reader) {
            Mechanic_id = reader.GetInt32(reader.GetOrdinal("Mechanic_id"));
            Work_order_id = reader.GetInt32(reader.GetOrdinal("Work_order_id"));
        }
        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();      
            if (Mechanic_id < 1){
                Check.isValid = false;
                Check.list.Add("Mechanic_id must be greater than 0");
            }
            if (Work_order_id < 1){
                Check.isValid = false;
                Check.list.Add("Work_order_id must be greater than 0");
            }
            return Check;
        }
    }
}
