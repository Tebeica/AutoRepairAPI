using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class Vehicle_modelM
    {
        public string Vehicle_model { get; set; } //PK
        public string Vehicle_make { get; set; } //PK
        public int Year { get; set; } //PK
        public Vehicle_modelM(string Vehicle_model1, string Vehicle_make1, int Year1)
        {
            Vehicle_model = Vehicle_model1;
            Vehicle_make = Vehicle_make1;
            Year = Year1;
        }
        public Vehicle_modelM() { }

        public Vehicle_modelM(SqlDataReader reader) {
            Vehicle_make = reader.GetString(reader.GetOrdinal("Make"));
            Vehicle_model = reader.GetString(reader.GetOrdinal("Model"));
            Year = reader.GetInt32(reader.GetOrdinal("VYear"));
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

            return Check;
        }
    }
}
