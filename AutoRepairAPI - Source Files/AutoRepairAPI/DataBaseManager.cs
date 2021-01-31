using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoRepairAPI.Models;
using Microsoft.Data.SqlClient;

namespace AutoRepairAPI
{
    public class DatabaseManager
    {
        public DatabaseManager() { }
        private const string connectionString = "Server=localhost;Database=autorepair;Trusted_Connection=True;";
        private SqlConnection SQLConnection;
        public void OpenSQLConnection()
        {
            SQLConnection = new SqlConnection(connectionString);
            SQLConnection.Open();
        }
        public void CloseSQLConnection()
        {
            SQLConnection.Close();
        }

        public EmployeeM getEmployee(int employee_id)
        {
            EmployeeM EM = null;
            string spName = @"[dbo].[getEmployee]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@Employee_id";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = employee_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one employee with the PK: " + employee_id + ", key values have been destroyed");
                            EM = new EmployeeM(reader);
                        }
                    }
                }

            }
            return EM;
        }
        public void addEmployee(EmployeeM EM)
        {
            string spName = @"[dbo].[addEmployee]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[13];
                string[] names =
                {
                    "@EPassword","@Lname","@Fname","@EAddress","@Bank_acc_no","@Salary_rate","@Hourly_rate","@Pay_type","@MecFlag","@CFlag","@ManFlag","@AFlag","@Manager_id"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.BigInt,SqlDbType.Decimal,SqlDbType.Decimal,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Int
                };
                Object[] values =
                {
                   EM.Password, EM.Lname, EM.Fname,EM.Address,EM.Bank_acc_no,EM.Salary_rate,EM.Hourly_rate,EM.Pay_Type,EM.MecFlag,EM.CFlag,EM.ManFlag,EM.AFlag,EM.Manager_id 
                };

                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void payEmployee(Employee_invoiceM IV)
        {
            string spName = @"[dbo].[payEmployee]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[6];
                string[] names =
                {
                    "@Employee_id","@Amount","@Interval_Start_Date","@Interval_End_Date","@Payment_Date","@WHours"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Int,SqlDbType.Decimal,SqlDbType.Date,SqlDbType.Date,SqlDbType.Date,SqlDbType.Decimal
                };
                Object[] values =
                {
                   IV.Employee_id,IV.Amount,IV.Interval_Start_Date,IV.Interval_End_Date,IV.Payment_Date,IV.Hours
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void updateEmployeeInfo(EmployeeM EM)
        {
            string spName = @"[dbo].[updateEmployeeInfo]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[14];
                string[] names =
                {
                    "@Employee_id","@EPassword","@Bank_acc_no","@EAddress","@Lname","@Fname","@Pay_type","@Salary_rate","@Hourly_rate","@MecFlag","@CFlag","@ManFlag","@AFlag","@Manager_id"
                };
                SqlDbType[] DBtypes =
                {
                    SqlDbType.Int,SqlDbType.VarChar,SqlDbType.BigInt,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.Bit,SqlDbType.Decimal,SqlDbType.Decimal,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.Int
                };
                Object[] values =
                {
                   EM.Employee_id, EM.Password, EM.Bank_acc_no, EM.Address, EM.Lname, EM.Fname, EM.Pay_Type, EM.Salary_rate,EM.Hourly_rate,EM.MecFlag,EM.CFlag,EM.ManFlag,EM.AFlag,EM.Manager_id
                };

                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public List<Employee_invoiceM> getInvoices(int Employee_id)
        {
            List<Employee_invoiceM> IVL = new List<Employee_invoiceM>();
            string spName = @"[dbo].[getInvoices]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@Employee_id";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Employee_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            IVL.Add(new Employee_invoiceM(reader));
                        }
                    }
                }

            }
            return IVL;
        }
        public Employee_invoiceM getInvoice(int Employee_id, int Invoice_id)
        {
            Employee_invoiceM IV = null;
            string spName = @"[dbo].[getInvoice]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Invoice_id_Parameter = new SqlParameter();
                SqlParameter Employee_id_Parameter = new SqlParameter();
                Invoice_id_Parameter.ParameterName = "@Invoice_id";
                Employee_id_Parameter.ParameterName = "@Employee_id";
                Invoice_id_Parameter.SqlDbType = SqlDbType.Int;
                Employee_id_Parameter.SqlDbType = SqlDbType.Int;
                Invoice_id_Parameter.Value = Invoice_id;
                Employee_id_Parameter.Value = Employee_id;
                cmd.Parameters.Add(Invoice_id_Parameter);
                cmd.Parameters.Add(Employee_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one part with the PK: " + Invoice_id + " " + Employee_id + ", key values have been destroyed");
                            IV = new Employee_invoiceM(reader);
                        }
                    }
                }

            }
            return IV;
        }
        public List<int> getManagersDelagates(int Manager_id)
        {
            List<int> employee_ids = new List<int>();
            string spName = @"[dbo].[getManagersDelagates]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@Manager_id";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Manager_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employee_ids.Add(reader.GetInt32(0));
                        }
                    }
                }

            }
            return employee_ids;
        }
        public void assignMechanic(Assigned_toM assignment)
        {
            string spName = @"[dbo].[assignMechanic]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[2];
                string[] names =
                {
                    "@Work_order_id","@Employee_id"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Int, SqlDbType.Int
                };
                Object[] values =
                {
                   assignment.Work_order_id,assignment.Mechanic_id
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void assignClerk(Associated_withM associasion)
        {
            string spName = @"[dbo].[assignClerk]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[2];
                string[] names =
                {
                    "@Work_order_id","@Employee_id"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Int, SqlDbType.Int
                };
                Object[] values =
                {
                   associasion.Work_order_id,associasion.Clerk_id
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void createWorkOrder(Work_orderM WO)
        {
            string spName = @"[dbo].[createWorkOrder]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[4];
                string[] names =
                {
                    "@Closed","@Amount_due","@Vehicle_VIN","@CustomerID"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Bit,SqlDbType.Decimal,SqlDbType.VarChar, SqlDbType.Int
                };
                Object[] values =
                {
                   WO.Closed,WO.Amount_Due,WO.Vehicle_VIN,WO.CustomerID
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void updateWorkOrder(Work_orderM WO)
        {
            string spName = @"[dbo].[updateWorkOrder]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[5];
                string[] names =
                {
                    "@Work_order_id","@Closed","@Amount_due","@Vehicle_VIN","@CustomerID"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Int, SqlDbType.Bit,SqlDbType.Decimal,SqlDbType.VarChar, SqlDbType.Int
                };
                Object[] values =
                {
                   WO.Work_order_id,WO.Closed,WO.Amount_Due,WO.Vehicle_VIN,WO.CustomerID
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public List<Work_orderM> getCustomerWorkOrders(int Customer_id)
        {
            List<Work_orderM> WOL = new List<Work_orderM>();
            string spName = @"[dbo].[getCustomerWorkOrders]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@CustomerID";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Customer_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            WOL.Add(new Work_orderM(reader));
                        }
                    }
                }

            }
            return WOL;
        }
        public Work_orderM getWorkOrder(int WorkOrder_id)
        {
            Work_orderM WO = null;
            string spName = @"[dbo].[getWorkOrder]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@Work_order_id";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = WorkOrder_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one work order with the PK: " + WorkOrder_id + ", key values have been destroyed");
                            WO = new Work_orderM(reader);
                        }
                    }
                }

            }
            return WO;
        }
        public List<Work_orderM> getEmployeeWorkOrders(int Employee_id)
        {
            List<Work_orderM> WOL = new List<Work_orderM>();
            string spName = @"[dbo].[getEmployeeWorkOrders]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@Employee_id";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Employee_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            WOL.Add(new Work_orderM(reader));
                        }
                    }
                }

            }
            return WOL;
        }
        public void removeWorkOrder(int WorkOrder_id)
        {
            string spName = @"[dbo].[removeWorkOrder]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Work_order_id_Parameter = new SqlParameter();
                Work_order_id_Parameter.ParameterName = "@Work_order_id";
                Work_order_id_Parameter.SqlDbType = SqlDbType.Int;
                Work_order_id_Parameter.Value = WorkOrder_id;
                cmd.Parameters.Add(Work_order_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void addCustomer(CustomerM Customer)
        {
            string spName = @"[dbo].[addCustomer]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[4];
                string[] names =
                {
                    "@Fname","@Lname","@CAddress","@Phone_number"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.VarChar
                };
                Object[] values =
                {
                   Customer.Fname,Customer.Lname,Customer.Address,Customer.Phone_number
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void updateCustomer(CustomerM Customer)
        {
            string spName = @"[dbo].[updateCustomer]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[5];
                string[] names =
                {
                    "@CustomerID","@Fname","@Phone_number","@Lname","@Address"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Int,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.VarChar
                };
                Object[] values =
                {
                   Customer.CustomerID,Customer.Fname,Customer.Phone_number,Customer.Lname,Customer.Address
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public CustomerM getCustomer(int Customer_id)
        {
            CustomerM C = null;
            string spName = @"[dbo].[getCustomer]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@CustomerID";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Customer_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one customer with the PK: " + Customer_id + ", key values have been destroyed");
                            C = new CustomerM(reader);
                        }
                    }
                }

            }
            return C;
        }
        public List<VehicleM> getCustomerVehicles(int Customer_id)
        {
            List<VehicleM> CV = new List<VehicleM>();
            string spName = @"[dbo].[getCustomerVehicles]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@CustomerID";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Customer_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CV.Add(new VehicleM(reader));
                        }
                    }
                }

            }
            return CV;
        }
        public void addVehicle(VehicleM V)
        {
            string spName = @"[dbo].[addVehicle]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[7];
                string[] names =
                {
                    "@VIN","@Vehicle_make","@Vehicle_model","@Vehicle_year","@Color","@CustomerID","@Registration_No"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int,SqlDbType.VarChar, SqlDbType.Int,SqlDbType.VarChar
                };
                Object[] values =
                {
                   V.VIN,V.Vehicle_make,V.Vehicle_model,V.Vehicle_year,V.Color,V.CustomerID,V.Registration_No
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void updateVehicle(VehicleM V)
        {
            string spName = @"[dbo].[updateVehicle]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[7];
                string[] names =
                {
                    "@VIN","@Vehicle_make","@Vehicle_model","@Vehicle_year","@Color","@CustomerID","@Registration_No"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int,SqlDbType.VarChar, SqlDbType.Int,SqlDbType.VarChar
                };
                Object[] values =
                {
                   V.VIN,V.Vehicle_make,V.Vehicle_model,V.Vehicle_year,V.Color,V.CustomerID,V.Registration_No
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public VehicleM getVehicle(string VIN)
        {
            VehicleM V = null;
            string spName = @"[dbo].[getVehicle]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@VIN";
                Emp_id_Parameter.SqlDbType = SqlDbType.VarChar;
                Emp_id_Parameter.Value = VIN;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one vehicle with the PK: " + VIN + ", key values have been destroyed");
                            V = new VehicleM(reader);
                        }
                    }
                }

            }
            return V;
        }
        public bool checkVehicleModel(Vehicle_modelM vehicle_modelM)
        {
            bool exists = false;
            string spName = @"[dbo].[checkVehicleModel]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[3];
                string[] names =
                {
                    "@Vehicle_make","@Vehicle_model","@Year"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int
                };
                Object[] values =
                {
                   vehicle_modelM.Vehicle_make,vehicle_modelM.Vehicle_model,vehicle_modelM.Year
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("Function checkVehicleModel Failed");
                            exists = reader.GetBoolean(0);
                        }
                    }
                }

            }
            return exists;
        }
        public void addVehicleModel(Vehicle_modelM VM)
        {
            string spName = @"[dbo].[addVehicleModel]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[3];
                string[] names =
                {
                    "@Vehicle_make","@Vehicle_model","@Year"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int
                };
                Object[] values =
                {
                   VM.Vehicle_make,VM.Vehicle_model,VM.Year
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void removeVehicleModel(Vehicle_modelM VM)
        {
            string spName = @"[dbo].[removeVehicleModel]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[3];
                string[] names =
                {
                    "@Vehicle_make","@Vehicle_model","@Vehicle_year"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int
                };
                Object[] values =
                {
                   VM.Vehicle_make,VM.Vehicle_model,VM.Year
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public List<PartM> getWorkOrderParts(int Workorder_id)
        {
            List<PartM> Parts = new List<PartM>();
            string spName = @"[dbo].[getWorkOrderParts]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter Emp_id_Parameter = new SqlParameter();
                Emp_id_Parameter.ParameterName = "@Work_order_id";
                Emp_id_Parameter.SqlDbType = SqlDbType.Int;
                Emp_id_Parameter.Value = Workorder_id;
                cmd.Parameters.Add(Emp_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Parts.Add(new PartM(reader));
                        }
                    }
                }

            }
            return Parts;
        }
        public List<PartM> getPartsOnStock()
        {
            List<PartM> Parts = new List<PartM>();
            string spName = @"[dbo].[getPartsOnStock]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Parts.Add(new PartM(reader));
                        }
                    }
                }

            }
            return Parts;
        }
        public void updatePart(PartM part)
        {
            string spName = @"[dbo].[updatePart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[5];
                string[] names =
                {
                    "@Part_id","@Part_instance_no","@PState","@Price","@Work_order_id"
                };
                SqlDbType[] DBtypes =
                {
                    SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar,SqlDbType.Decimal, SqlDbType.Int
                };
                Object[] values =
                {
                   part.Part_id,part.Part_instance_id,part.State,part.Price,part.Work_order_id
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public PartM getPart(int Part_id, int Part_instance_id)
        {
            PartM part = null;
            string spName = @"[dbo].[getPart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter part_id_Parameter = new SqlParameter();
                SqlParameter instance_id_Parameter = new SqlParameter();
                part_id_Parameter.ParameterName = "@Part_id";
                instance_id_Parameter.ParameterName = "@Part_instance_no";
                part_id_Parameter.SqlDbType = SqlDbType.Int;
                instance_id_Parameter.SqlDbType = SqlDbType.Int;
                part_id_Parameter.Value = Part_id;
                instance_id_Parameter.Value = Part_instance_id;
                cmd.Parameters.Add(part_id_Parameter);
                cmd.Parameters.Add(instance_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one part with the PK: " + Part_id + " " + Part_instance_id + ", key values have been destroyed");
                            part = new PartM(reader);
                        }
                    }
                }

            }
            return part;
        }
        public void addPart(PartM part)
        {
            string spName = @"[dbo].[addPart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[4];
                string[] names =
                {
                    "@Part_id","@PState","@Price","@Work_order_id"
                };
                SqlDbType[] DBtypes =
                {
                    SqlDbType.Int, SqlDbType.VarChar,SqlDbType.Decimal, SqlDbType.Int
                };
                Object[] values =
                {
                   part.Part_id,part.State,part.Price,part.Work_order_id
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public List<Catalog_partM> searchCompatiblePart(Vehicle_modelM VM, string searchTerm)
        {
            List<Catalog_partM> Parts = new List<Catalog_partM>();
            string spName = @"[dbo].[searchCompatiblePart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[4];
                string[] names =
                {
                    "@Vehicle_make","@Vehicle_model","@Vehicle_year","@Part_name_string"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int,SqlDbType.VarChar
                };
                Object[] values =
                {
                   VM.Vehicle_make,VM.Vehicle_model,VM.Year,searchTerm
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Parts.Add(new Catalog_partM(reader));
                        }
                    }
                }

            }
            return Parts;
        }
        public Catalog_partM getCatalogPart(int Part_id)
        {
            Catalog_partM CatalogPart = null;
            string spName = @"[dbo].[getCatalogPart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter part_id_Parameter = new SqlParameter();
                part_id_Parameter.ParameterName = "@Part_id";
                part_id_Parameter.SqlDbType = SqlDbType.Int;
                part_id_Parameter.Value = Part_id;
                cmd.Parameters.Add(part_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("more then one part with the PK: " + Part_id + ", key values have been destroyed");
                            CatalogPart = new Catalog_partM(reader);
                        }
                    }
                }

            }
            return CatalogPart;
        }
        public void addCatalogPart(Catalog_partM CP)
        {
            string spName = @"[dbo].[addCatalogPart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[1];
                string[] names =
                {
                    "@Part_name"
                };
                SqlDbType[] DBtypes =
                {
                    SqlDbType.VarChar
                };
                Object[] values =
                {
                   CP.Part_name
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void removeCatalogPart(int Part_id)
        {
            string spName = @"[dbo].[removeCatalogPart]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter part_id_Parameter = new SqlParameter();
                part_id_Parameter.ParameterName = "@Part_id";
                part_id_Parameter.SqlDbType = SqlDbType.Int;
                part_id_Parameter.Value = Part_id;
                cmd.Parameters.Add(part_id_Parameter);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void addCompatibility(int Part_id, Vehicle_modelM VehicleType)
        {
            string spName = @"[dbo].[addCompatibility]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[4];
                string[] names =
                {
                    "@Part_id","@Vehicle_Make","@Vehicle_Model","@Vehicle_Year"
                };
                SqlDbType[] DBtypes =
                {
                    SqlDbType.Int,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.Int
                };
                Object[] values =
                {
                   Part_id, VehicleType.Vehicle_make,VehicleType.Vehicle_model,VehicleType.Year
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public bool checkPartCompatibility(int Part_id, Vehicle_modelM VehicleType)
        {
            bool Compatible = false;
            string spName = @"[dbo].[checkPartCompatibility]";
            using (SqlCommand cmd = new SqlCommand(spName, SQLConnection))
            {
                SqlParameter[] parms = new SqlParameter[4];
                string[] names =
                {
                    "@Part_id","@Vehicle_Make","@Vehicle_Model","@Vehicle_Year"
                };
                SqlDbType[] DBtypes =
                {
                     SqlDbType.Int, SqlDbType.VarChar,SqlDbType.VarChar, SqlDbType.Int
                };
                Object[] values =
                {
                   Part_id,VehicleType.Vehicle_make,VehicleType.Vehicle_model,VehicleType.Year
                };
                for (int i = 0; i < parms.Length; i++)
                {
                    parms[i] = new SqlParameter();
                    parms[i].ParameterName = names[i];
                    parms[i].SqlDbType = DBtypes[i];
                    parms[i].Value = values[i];
                    cmd.Parameters.Add(parms[i]);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int test = 0;
                        while (reader.Read())
                        {
                            if (test > 0) throw new Exception("Function checkPartCompatibility Failed");
                            Compatible = reader.GetBoolean(0);
                        }
                    }
                }

            }
            return Compatible;
        }
    }
}
