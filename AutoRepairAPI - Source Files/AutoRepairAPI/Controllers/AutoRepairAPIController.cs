using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using AutoRepairAPI.Models;
using Newtonsoft.Json;
using AutoRepairAPI;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AutoRepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoRepairAPIController : ControllerBase
    {
        private DatabaseManager DB = new DatabaseManager();

        private string[] GenaricErrorCodes =
        {
            "Error 100: Tuple does not exist in database",
            "Error 200: Attempting to insert an invalid FK",
            "Error 300: Attempting to assign a null or invalid PK",
            "Error 4",
            "Error 500: Invalid data value. See - ",
            "Error 600: Invalid Login",
            "Error 700: Authentication of login rejected"
        };
        

        // GET api/AutoRepairAPI/getEmployee/{Employee_id}
        [HttpGet]
        [Route("getEmployee/{Employee_id}")]
        public ActionResult<string> getEmployee(int Employee_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid()) 
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if(!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if(!(LoginE.ManFlag || LoginE.AFlag || LoginE.Employee_id == Employee_id))
                    return GenaricErrorCodes[6];

                if (Employee_id < 1)
                    return GenaricErrorCodes[4] + "Employee_id must be greater than 0";
                EmployeeM E = DB.getEmployee(Employee_id);
                if (E is null)
                    return null;
                return JsonConvert.SerializeObject(E);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addEmployee -info in body
        [HttpPost]
        [Route("addEmployee")]
        public ActionResult<string> addEmployee([FromBody] EmployeeM Employee)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Employee.SQLSchemaValidParameters_MINUS_EMPLOYEE_ID();//Auto-Increments ID so no PK check required.
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                DB.addEmployee(Employee);
                return "Employee Successfully Entered";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/payEmployee -info in body
        [HttpPost]
        [Route("payEmployee")]
        public ActionResult<string> payEmployee([FromBody] Employee_invoiceM Employee_invoice)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Employee_invoice.SQLSchemaValidParameters_MINUS_INVOICE_ID();//Auto-Increments ID so no PK check required.
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                DB.payEmployee(Employee_invoice);
                return "Invoice Successfully Entered";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // PUT api/AutoRepairAPI/updateEmployeeInfo -info in body
        [HttpPut]
        [Route("updateEmployeeInfo")]
        public ActionResult<string> updateEmployeeInfo([FromBody] EmployeeM Employee)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Employee.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                EmployeeM e = DB.getEmployee(Employee.Employee_id);
                if (e is null)//Current Tuple doesnt exist
                    return GenaricErrorCodes[0];
                DB.updateEmployeeInfo(Employee);
                return "Employee Info Successfully Updated";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getInvoices/{Employee_id}
        [HttpGet]
        [Route("getInvoices/{Employee_id}")]
        public ActionResult<string> getInvoices(int Employee_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.Employee_id == Employee_id))
                    return GenaricErrorCodes[6];

                if (Employee_id < 1)
                    return GenaricErrorCodes[4] + "Employee_id must be greater than 0";

                List<Employee_invoiceM> List = DB.getInvoices(Employee_id);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getInvoice/{Employee_id}/{Invoice_id}
        [HttpGet]
        [Route("getInvoice/{Employee_id}/{Invoice_id}")]
        public ActionResult<string> getInvoice(int Employee_id, int Invoice_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.Employee_id == Employee_id))
                    return GenaricErrorCodes[6];

                string error = GenaricErrorCodes[4];
                if (Employee_id < 0)
                    error += "Employee_id must be greater than 0";
                if (Invoice_id < 0)
                    error += "Invoice_id must be greater than 0";
                if (Employee_id < 0 || Invoice_id < 0)
                    return error;

                Employee_invoiceM EI = DB.getInvoice(Employee_id, Invoice_id);
                if (EI is null)
                    return null;
                return JsonConvert.SerializeObject(EI);
            }
            finally 
            { 
                DB.CloseSQLConnection(); 
            }
        }

        // GET api/AutoRepairAPI/getManagersDelagates/{Manager_id}
        [HttpGet]
        [Route("getManagersDelagates/{Manager_id}")]
        public ActionResult<string> getManagersDelagates(int Manager_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];

            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag))
                    return GenaricErrorCodes[6];

                if (Manager_id < 1)
                    return GenaricErrorCodes[4] + "Manager_id must be greater than 0";

                List<int> List = DB.getManagersDelagates(Manager_id);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/assignMechanic -info in body
        [HttpPost]
        [Route("assignMechanic")]
        public ActionResult<string> assignMechanic([FromBody] Assigned_toM assignment)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = assignment.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                EmployeeM employee = DB.getEmployee(assignment.Mechanic_id);
                Work_orderM WO = DB.getWorkOrder(assignment.Work_order_id);
                if ((employee is null) || (WO is null))
                    return GenaricErrorCodes[1];
                if (!employee.MecFlag)
                    return GenaricErrorCodes[3] + "01: Attempting to assign an employee who is not a mechanic";
                DB.assignMechanic(assignment);
                return "Mechanic Successfully Assigned";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/assignClerk -info in body
        [HttpPost]
        [Route("assignClerk")]
        public ActionResult<string> assignClerk([FromBody] Associated_withM assignment)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = assignment.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                EmployeeM employee = DB.getEmployee(assignment.Clerk_id);
                Work_orderM WO = DB.getWorkOrder(assignment.Work_order_id);
                if ((employee is null) || (WO is null))
                    return GenaricErrorCodes[1];
                if (!employee.CFlag)
                    return GenaricErrorCodes[3] + "02: Attempting to assign an employee who is not a Clerk";
                DB.assignClerk(assignment);
                return "Successfully Added Clerk Association";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/createWorkOrder -info in body
        [HttpPost]
        [Route("createWorkOrder")]
        public ActionResult<string> createWorkOrder([FromBody] Work_orderM work_Order)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = work_Order.SQLSchemaValidParameters_MINUS_WORK_ORDER_ID();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                VehicleM vt = DB.getVehicle(work_Order.Vehicle_VIN);
                CustomerM ct = DB.getCustomer(work_Order.CustomerID);
                if((vt is null) || (ct is null))
                    return GenaricErrorCodes[1];
                else if (vt.CustomerID != ct.CustomerID)
                    return GenaricErrorCodes[3] + "04: Attempting to tether a vehicle to a customer in a work order when the vehicle is not owned by the customer.";
                DB.createWorkOrder(work_Order);
                return "Successfully Created Work Order";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // PUT api/AutoRepairAPI/updateWorkOrder -info in body
        [HttpPut]
        [Route("updateWorkOrder")]
        public ActionResult<string> updateWorkOrder([FromBody] Work_orderM work_Order)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = work_Order.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                VehicleM vt = DB.getVehicle(work_Order.Vehicle_VIN);
                CustomerM ct = DB.getCustomer(work_Order.CustomerID);
                if ((vt is null) || (ct is null))
                    return GenaricErrorCodes[1];
                if (vt.CustomerID != ct.CustomerID)
                    return "Error 404: Attempting to tether a vehicle to a customer in a work order when the vehicle is not owned by the customer.";
                Work_orderM WO = DB.getWorkOrder(work_Order.Work_order_id);
                if (WO is null)
                    return GenaricErrorCodes[0];
                DB.updateWorkOrder(work_Order);
                return "Successfully Updated Work Order";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getCustomerWorkOrders/{Customer_id}
        [HttpGet]
        [Route("getCustomerWorkOrders/{Customer_id}")]
        public ActionResult<string> getCustomerWorkOrders(int Customer_id) 
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];

            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                if (Customer_id < 1)
                    return GenaricErrorCodes[4] + "Customer_id must be greater than 0";

                List<Work_orderM> List = DB.getCustomerWorkOrders(Customer_id);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getWorkOrder/{WorkOrder_id}
        [HttpGet]
        [Route("getWorkOrder/{WorkOrder_id}")]
        public ActionResult<string> getWorkOrder(int WorkOrder_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];

                if (WorkOrder_id < 1)
                    return GenaricErrorCodes[4] + "WorkOrder_id must be greater than 0";

                Work_orderM WO = DB.getWorkOrder(WorkOrder_id);
                if (WO is null)
                    return null;
                return JsonConvert.SerializeObject(WO);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getEmployeeWorkOrders/{Employee_id}
        [HttpGet]
        [Route("getEmployeeWorkOrders/{Employee_id}")]
        public ActionResult<string> getEmployeeWorkOrders(int Employee_id) 
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];

                if (Employee_id < 1)
                    return GenaricErrorCodes[4] + "Employee_id must be greater than 0";

                List<Work_orderM> List = DB.getEmployeeWorkOrders(Employee_id);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // DELETE api/AutoRepairAPI/removeWorkOrder/{WorkOrder_id}
        [HttpDelete]
        [Route("removeWorkOrder/{WorkOrder_id}")]
        public ActionResult<string> removeWorkOrder(int WorkOrder_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag))
                    return GenaricErrorCodes[6];

                if (WorkOrder_id < 1)
                    return GenaricErrorCodes[4] + "WorkOrder_id must be greater than 0";

                Work_orderM WO = DB.getWorkOrder(WorkOrder_id);
                if (WO is null)
                    return GenaricErrorCodes[0];
                //No need to check FK as it is set to cascade to null on parts
                DB.removeWorkOrder(WorkOrder_id);
                return "Successfully Removed Work Order";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addCustomer -info in body
        [HttpPost]
        [Route("addCustomer")]
        public ActionResult<string> addCustomer([FromBody] CustomerM Customer)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Customer.SQLSchemaValidParameters_MINUS_CUSTOMER_ID();//Auto-Increments ID so no PK check required.
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                DB.addCustomer(Customer);
                return "Successfully Added Customer";
            } finally{
                DB.CloseSQLConnection();
            }
        }

        // PUT api/AutoRepairAPI/updateCustomer -info in body
        [HttpPut]
        [Route("updateCustomer")]
        public ActionResult<string> updateCustomer([FromBody] CustomerM Customer)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Customer.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                CustomerM C = DB.getCustomer(Customer.CustomerID);
                if (C is null)
                    return GenaricErrorCodes[0];
                DB.updateCustomer(Customer);
                return "Successfully Updated Customer";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }


        // GET api/AutoRepairAPI/getCustomer/{Customer_id}
        [HttpGet]
        [Route("getCustomer/{Customer_id}")]
        public ActionResult<string> getCustomer(int Customer_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                if (Customer_id < 1)
                    return GenaricErrorCodes[4] + "Customer_id must be greater than 0";

                CustomerM C = DB.getCustomer(Customer_id);
                if (C is null)
                    return null;
                return JsonConvert.SerializeObject(C);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getCustomerVehicles/{Customer_id}
        [HttpGet]
        [Route("getCustomerVehicles/{Customer_id}")]
        public ActionResult<string> getCustomerVehicles(int Customer_id) 
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                if (Customer_id < 1)
                    return GenaricErrorCodes[4] + "Customer_id must be greater than 0";

                List<VehicleM> List = DB.getCustomerVehicles(Customer_id);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addVehicle -info in body
        [HttpPost]
        [Route("addVehicle")]
        public ActionResult<string> addVehicle([FromBody] VehicleM Vehicle)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Vehicle.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                if (!DB.checkVehicleModel(new Vehicle_modelM(Vehicle.Vehicle_model, Vehicle.Vehicle_make, Vehicle.Vehicle_year)))
                    return GenaricErrorCodes[1];
                VehicleM vm = DB.getVehicle(Vehicle.VIN);
                if (!(vm is null))
                    return GenaricErrorCodes[2] + " - VIN has already been used";
                DB.addVehicle(Vehicle);
                return "Successfully Added Vehicle";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // PUT api/AutoRepairAPI/updateVehicle -info in body
        [HttpPut]
        [Route("updateVehicle")]
        public ActionResult<string> updateVehicle([FromBody] VehicleM Vehicle)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.CFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Vehicle.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                if (!DB.checkVehicleModel(new Vehicle_modelM(Vehicle.Vehicle_model, Vehicle.Vehicle_make, Vehicle.Vehicle_year)))
                    return GenaricErrorCodes[1];
                VehicleM v = DB.getVehicle(Vehicle.VIN);
                if (v is null)
                    return GenaricErrorCodes[0];
                DB.updateVehicle(Vehicle);
                return "Successfully Updated Vehicle";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getVehicle/{VIN}
        [HttpGet]
        [Route("getVehicle/{VIN}")]
        public ActionResult<string> getVehicle(string VIN)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];

                if (!(VIN is null))
                {
                    if (VIN.Length > 17 || VIN.Length < 0)
                        return GenaricErrorCodes[4] + "VIN is restricted to 17 characters";
                }
                else
                    return GenaricErrorCodes[4] + "VIN must not be null";

                VehicleM v = DB.getVehicle(VIN);
                if (v is null)
                    return null;
                return JsonConvert.SerializeObject(v);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/checkVehicleModel
        [HttpGet]
        [Route("checkVehicleModel")]
        public ActionResult<string> checkVehicleModel([FromBody] Vehicle_modelM VM)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = VM.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                return JsonConvert.SerializeObject(DB.checkVehicleModel(VM));
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addVehicleModel -info in body
        [HttpPost]
        [Route("addVehicleModel")]
        public ActionResult<string> addVehicleModel([FromBody] Vehicle_modelM Vehicle)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Vehicle.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                DB.addVehicleModel(Vehicle);
                return "Successfully Added Vehicle Model";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // DELETE api/AutoRepairAPI/removeVehicleModel -info in body
        [HttpDelete]
        [Route("removeVehicleModel")]
        public ActionResult<string> removeVehicleModel([FromBody] Vehicle_modelM Vehicle)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Vehicle.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                if (!DB.checkVehicleModel(Vehicle))
                    return GenaricErrorCodes[0];
                DB.removeVehicleModel(Vehicle);
                return "Successfully Removed Vehicle Model";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getWorkOrderParts/{WorkOrder_id}
        [HttpGet]
        [Route("getWorkOrderParts/{WorkOrder_id}")]
        public ActionResult<string> getWorkOrderParts(int WorkOrder_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];

                if (WorkOrder_id < 1)
                    return  GenaricErrorCodes[4] + "WorkOrder_id must be greater than 0";

                List<PartM> List = DB.getWorkOrderParts(WorkOrder_id);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getPartsOnStock
        [HttpGet]
        [Route("getPartsOnStock")]
        public ActionResult<string> getPartsOnStock() 
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                List<PartM> List = DB.getPartsOnStock();
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // PUT api/AutoRepairAPI/updatePart -info in body
        [HttpPut]
        [Route("updatePart")]
        public ActionResult<string> updatePart([FromBody] PartM Part)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Part.SQLSchemaValidParameters();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();
                PartM P = DB.getPart(Part.Part_id, Part.Part_instance_id);
                if (P is null)
                    return GenaricErrorCodes[0];
                DB.updatePart(Part);
                return "Successfully Updated Part";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/getPart/{Part_id}/{Part_instance_id}
        [HttpGet]
        [Route("getPart/{Part_id}/{Part_instance_id}")]
        public ActionResult<string> getPart(int Part_id, int Part_instance_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                string error = GenaricErrorCodes[4];
                if (Part_id < 1)
                    error += "Part_id must be greater than 0";
                if (Part_instance_id < 1)
                    error += "Part_instance_id must be greater than 0";
                if (Part_id < 1 || Part_instance_id < 1)
                    return error;

                PartM Part = DB.getPart(Part_id, Part_instance_id);
                if (Part is null)
                    return null;
                return JsonConvert.SerializeObject(Part);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addPart -info in body
        [HttpPost]
        [Route("addPart")]
        public ActionResult<string> addPart([FromBody] PartM Part)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Part.SQLSchemaValidParameters_MINUS_INSTANCE_ID();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                Catalog_partM CatalogPart = DB.getCatalogPart(Part.Part_id);
                if (Part.Work_order_id != 0)
                { 
                    Work_orderM WO = DB.getWorkOrder(Part.Work_order_id);
                    if (WO is null)
                        return GenaricErrorCodes[1];
                }
                if (CatalogPart is null)
                    return GenaricErrorCodes[1];
                DB.addPart(Part);
                return "Successfully Added Part";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/searchCompatiblePart/{searchTerm} -info in body
        [HttpGet]
        [Route("searchCompatiblePart/{searchTerm}")]
        public ActionResult<string> searchCompatiblePart([FromBody] Vehicle_modelM VM, string searchTerm)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                string s = GenaricErrorCodes[4];
                TypeCheck check = VM.SQLSchemaValidParameters();
                if (!check.isValid)
                    s += check.ListTostring();
                if (!(searchTerm is null))
                {
                    if (searchTerm.Length > 256 || searchTerm.Length < 0)
                        s += "searchTerm is restricted to 256 characters";
                }
                else
                    s += GenaricErrorCodes[4] + "VIN must not be null";
                if (!(s.Equals(GenaricErrorCodes[4])))
                    return s;

                List<Catalog_partM> List = DB.searchCompatiblePart(VM, searchTerm);
                if (List is null)
                    return null;
                if (List.Count() < 1)
                    return null;
                return JsonConvert.SerializeObject(List);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }
        
        // GET api/AutoRepairAPI/getCatalogPart/{Part_id}
        [HttpGet]
        [Route("getCatalogPart/{Part_id}")]
        public ActionResult<string> getCatalogPart(int Part_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                if (Part_id < 1)
                return GenaricErrorCodes[4] + "Part_id must be greater than 0";

                Catalog_partM CatalogPart = DB.getCatalogPart(Part_id);
                if (CatalogPart is null)
                    return null;
                return JsonConvert.SerializeObject(CatalogPart);
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addCatalogPart -info in body
        [HttpPost]
        [Route("addCatalogPart")]
        public ActionResult<string> addCatalogPart([FromBody] Catalog_partM Part)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.AFlag))
                    return GenaricErrorCodes[6];

                TypeCheck check = Part.SQLSchemaValidParameters_MINUS_PART_ID();
                if (!check.isValid)
                    return GenaricErrorCodes[4] + check.ListTostring();

                DB.addCatalogPart(Part); //Auto increment Key so no need to check
                return "Successfully Added Catalog Part";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // DELETE api/AutoRepairAPI/removeCatalogPart/{Part_id}
        [HttpDelete]
        [Route("removeCatalogPart/{Part_id}")]
        public ActionResult<string> removeCatalogPart(int Part_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.AFlag))
                    return GenaricErrorCodes[6];

                if (Part_id < 1)
                    return GenaricErrorCodes[4] + "Part_id must be greater than 0";

                Catalog_partM CatalogPart = DB.getCatalogPart(Part_id);
                if (CatalogPart is null)
                    return GenaricErrorCodes[0];
                DB.removeCatalogPart(Part_id);
                return "Successfully Deleted Catalog Part";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // POST api/AutoRepairAPI/addCompatibility/{Part_id} -info in body
        [HttpPost]
        [Route("addCompatibility/{Part_id}")]
        public ActionResult<string> addCompatibility([FromBody] Vehicle_modelM VM, int Part_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.AFlag))
                    return GenaricErrorCodes[6];

                string s = GenaricErrorCodes[4];
                TypeCheck check = VM.SQLSchemaValidParameters();
                if (!check.isValid)
                    s += check.ListTostring();
                if (Part_id < 1)
                    s += "Part_id must be greater than 0";
                if (!check.isValid || Part_id < 1)
                    return s;

                Catalog_partM Part = DB.getCatalogPart(Part_id);
                if ((!DB.checkVehicleModel(VM)) || (Part is null))
                    return GenaricErrorCodes[1];
                DB.addCompatibility(Part_id, VM);
                return "Successfully Added Compatibility";
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

        // GET api/AutoRepairAPI/checkPartCompatibility/{Part_id} -info in body
        [HttpGet]
        [Route("checkPartCompatibility/{Part_id}")]
        public ActionResult<string> checkPartCompatibility([FromBody] Vehicle_modelM VM, int Part_id)
        {
            login log = new login(Request.Headers["Authorization"]);
            if (!log.isValid())
                return GenaricErrorCodes[5];
            DB.OpenSQLConnection();
            try
            {
                EmployeeM LoginE = DB.getEmployee(log.id);
                if (!LoginE.Password.Equals(log.password))
                    return GenaricErrorCodes[5];
                if (!(LoginE.ManFlag || LoginE.AFlag || LoginE.MecFlag))
                    return GenaricErrorCodes[6];

                string s = GenaricErrorCodes[4];
                TypeCheck check = VM.SQLSchemaValidParameters();
                if (!check.isValid)
                    s += check.ListTostring();
                if (Part_id < 1)
                    s += " --- Part_id must be greater than 0";
                if (Part_id < 1 || (!check.isValid))
                    return s;

                Catalog_partM Part = DB.getCatalogPart(Part_id);
                if ((!DB.checkVehicleModel(VM)) || (Part is null))
                    return GenaricErrorCodes[0];
                return JsonConvert.SerializeObject(DB.checkPartCompatibility(Part_id, VM)); 
            }
            finally
            {
                DB.CloseSQLConnection();
            }
        }

    }
}
