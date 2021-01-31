using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class VehicleM
    {
        public string VIN { get; set; } //PK
        public string Vehicle_model { get; set; } //FK
        public string Vehicle_make { get; set; } //FK
        public int Vehicle_year { get; set; } //FK
        public int CustomerID { get; set; } //FK
        public string Color { get; set; }
        public string Registration_No { get; set; }
        public VehicleM(string VIN1, string Vehicle_model1, string Vehicle_make1, int Vehicle_year1, int CustomerID1, 
                string Color1, string Registration_No1){
            VIN = VIN1;
            Vehicle_model = Vehicle_model1;
            Vehicle_make = Vehicle_make1;
            Vehicle_year = Vehicle_year1;
            CustomerID = CustomerID1;
            Color = Color1;
            Registration_No = Registration_No1;
        }
        public VehicleM() { }

        public VehicleM(SqlDataReader reader) {
            VIN = reader.GetString(reader.GetOrdinal("VIN"));
            Vehicle_make = reader.GetString(reader.GetOrdinal("Vehicle_make"));
            Vehicle_model = reader.GetString(reader.GetOrdinal("Vehicle_model"));
            if (reader[reader.GetName(reader.GetOrdinal("Vehicle_year"))] != DBNull.Value)
                Vehicle_year = reader.GetInt32(reader.GetOrdinal("Vehicle_year"));
            else
                Vehicle_year = 0;
            Color = reader.GetString(reader.GetOrdinal("Color"));
            if (reader[reader.GetName(reader.GetOrdinal("CustomerID"))] != DBNull.Value)
                CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            else
                CustomerID = 0;
            Registration_No = reader.GetString(reader.GetOrdinal("Registration_No"));
        }

        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (!(VIN is null))
            {
                if (VIN.Length > 17 || VIN.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("VIN is restricted to 17 characters");
                }
            }
            else
            {
                Check.isValid = false;
                Check.list.Add("VIN must not be null");
            }
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
            if (CustomerID < 1)
            {
                Check.isValid = false;
                Check.list.Add("CustomerID must be greater than 0");
            }
            if (!(Color is null))
            {
                if (Color.Length > 32 || Color.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Color is restricted to 32 characters");
                }
            }
            if (!(Registration_No is null))
            {
                if (Registration_No.Length > 20 || Registration_No.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Registration_No is restricted to 20 characters");
                }
            }

            return Check;
        }
    }
}
