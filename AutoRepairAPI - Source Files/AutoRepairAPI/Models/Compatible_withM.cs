using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class Compatible_withM
    {
        public string Vehicle_model { get; set; } //PK FK
        public string Vehicle_make { get; set; } //PK FK
        public int Vehicle_year { get; set; } //PK FK
        public int Part_id { get; set; } //PK FK
        public Compatible_withM(string Vehicle_model1, string Vehicle_make1, int Vehicle_year1, int Part_id1)
        {
            Vehicle_model = Vehicle_model1;
            Vehicle_make = Vehicle_make1;
            Vehicle_year = Vehicle_year1;
            Part_id = Part_id1;
        }
        public Compatible_withM() { }
        public Compatible_withM(SqlDataReader reader) {
            Part_id = reader.GetInt32(reader.GetOrdinal("Part_id"));
            Vehicle_make = reader.GetString(reader.GetOrdinal("Vehicle_make"));
            Vehicle_model = reader.GetString(reader.GetOrdinal("Vehicle_model"));
            Vehicle_year = reader.GetInt32(reader.GetOrdinal("Vehicle_year"));
        }
        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (!(Vehicle_model is null))
            {
                if (Vehicle_model.Length > 32 || Vehicle_model.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Vehicle_model is restricted to 32 characters");
                }
            }
            else
            {
                Check.isValid = false;
                Check.list.Add("Vehicle_model must not be null");
            }
            if (!(Vehicle_make is null))
            {
                if (Vehicle_make.Length > 32 || Vehicle_make.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Vehicle_make is restricted to 32 characters");
                }
            }
            else
            {
                Check.isValid = false;
                Check.list.Add("Vehicle_make must not be null");
            }
           /* if (Vehicle_year < 0)
            {
                Check.isValid = false;
                Check.list.Add("Vehicle_year must not be negative");
            }*/
            if (Part_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Part_id must be greater then 0");
            }
            return Check;
        }
    }
}
