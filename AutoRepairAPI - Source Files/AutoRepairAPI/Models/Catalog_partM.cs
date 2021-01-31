using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI.Models
{
    public class Catalog_partM
    {
        public int Part_id { get; set; } //PK
        public string Part_name { get; set; }
        public Catalog_partM(int Part_id1, string Part_name1)
        {
            Part_id = Part_id1;
            Part_name = Part_name1;
        }
        public Catalog_partM() { }

        public Catalog_partM(SqlDataReader reader) {
            Part_id = reader.GetInt32(reader.GetOrdinal("Part_id"));
            Part_name = reader.GetString(reader.GetOrdinal("Part_name"));
        }
        public TypeCheck SQLSchemaValidParameters()
        {
            TypeCheck Check = new TypeCheck();
            if (Part_id < 1)
            {
                Check.isValid = false;
                Check.list.Add("Part_id must be greater than 0");
            }
            if (!(Part_name is null))
            {
                if (Part_name.Length > 64 || Part_name.Length < 0)
                {
                    Check.isValid = false;
                    Check.list.Add("Part_name is restricted to 64 characters");
                }
            }
            return Check;
        }
        public TypeCheck SQLSchemaValidParameters_MINUS_PART_ID()
        {
            TypeCheck Check = SQLSchemaValidParameters();
            Check.list.Remove("Part_id must be greater than 0");
            if (Check.list.Count() > 0)
                return Check;
            return new TypeCheck();
        }
    }
}
