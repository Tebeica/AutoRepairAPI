using System;
using System.Text;

namespace AutoRepairAPI
{
    public class login
    {
        public int id { get; set; }
        public string password { get; set; }
        public login(string authHeader)
        {
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                try
                {
                    string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                    int seperatorIndex = usernamePassword.IndexOf(':');
                    id = Int32.Parse(usernamePassword.Substring(0, seperatorIndex));
                    password = usernamePassword.Substring(seperatorIndex + 1);
                }
                catch (Exception e)
                {
                    id = -1;
                    password = null;
                }
            }
            else
            {
                id = -1;
                password = null;
            }
        }

        public bool isValid()
        {
            if (id < 1)
                return false;
            if (password is null)
                return false;
            if (password.Length > 128 || password.Length < 0)
                return false;
            return true;
        }
    }
}
