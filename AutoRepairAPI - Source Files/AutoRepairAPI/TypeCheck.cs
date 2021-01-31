using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairAPI
{
    public class TypeCheck
    {
        public bool isValid { get; set; }
        public List<string> list { get; set; }
        public TypeCheck()
        {
            isValid = true;
            list = new List<string>();
        }
        public string ListTostring()
        {
            if (list is null)
                return null;
            if (list.Count() < 1)
                return null;
            return String.Join(" --- ", list.ToArray());
        }
    }
}
