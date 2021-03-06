USE [master]
GO
/****** Object:  Database [autorepair]    Script Date: 2020-12-07 5:18:39 PM ******/
CREATE DATABASE [autorepair]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'autorepair', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\autorepair.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'autorepair_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\autorepair_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [autorepair] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [autorepair].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [autorepair] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [autorepair] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [autorepair] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [autorepair] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [autorepair] SET ARITHABORT OFF 
GO
ALTER DATABASE [autorepair] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [autorepair] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [autorepair] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [autorepair] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [autorepair] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [autorepair] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [autorepair] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [autorepair] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [autorepair] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [autorepair] SET  ENABLE_BROKER 
GO
ALTER DATABASE [autorepair] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [autorepair] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [autorepair] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [autorepair] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [autorepair] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [autorepair] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [autorepair] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [autorepair] SET RECOVERY FULL 
GO
ALTER DATABASE [autorepair] SET  MULTI_USER 
GO
ALTER DATABASE [autorepair] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [autorepair] SET DB_CHAINING OFF 
GO
ALTER DATABASE [autorepair] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [autorepair] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [autorepair] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [autorepair] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'autorepair', N'ON'
GO
ALTER DATABASE [autorepair] SET QUERY_STORE = ON
GO
ALTER DATABASE [autorepair] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [autorepair]
GO
/****** Object:  User [TeodorT]    Script Date: 2020-12-07 5:18:39 PM ******/
CREATE USER [Teodor] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [Teodor]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [Teodor]
GO
/****** Object:  Schema [Teodor]    Script Date: 2020-12-07 5:18:39 PM ******/
CREATE SCHEMA [Teodor]
GO
/****** Object:  Table [dbo].[assigned_to]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[assigned_to](
	[Mechanic_id] [int] NOT NULL,
	[Work_order_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Mechanic_id] ASC,
	[Work_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[associated_with]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[associated_with](
	[Clerk_id] [int] NOT NULL,
	[Work_order_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Clerk_id] ASC,
	[Work_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catalog_part]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalog_part](
	[Part_id] [int] IDENTITY(1,1) NOT NULL,
	[Part_name] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[Part_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compatible_with]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compatible_with](
	[Part_id] [int] NOT NULL,
	[Vehicle_make] [varchar](32) NOT NULL,
	[Vehicle_model] [varchar](32) NOT NULL,
	[Vehicle_year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Part_id] ASC,
	[Vehicle_make] ASC,
	[Vehicle_model] ASC,
	[Vehicle_year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](128) NULL,
	[Lname] [varchar](128) NULL,
	[CAddress] [varchar](256) NULL,
	[Phone_number] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[Employee_id] [int] IDENTITY(1,1) NOT NULL,
	[EPassword] [varchar](128) NOT NULL,
	[Lname] [varchar](128) NULL,
	[Fname] [varchar](128) NULL,
	[EAddress] [varchar](256) NULL,
	[Bank_acc_no] [bigint] NULL,
	[Salary_rate] [decimal](10, 2) NULL,
	[Hourly_rate] [decimal](10, 2) NULL,
	[Pay_Type] [bit] NOT NULL,
	[MecFlag] [bit] NOT NULL,
	[CFlag] [bit] NOT NULL,
	[ManFlag] [bit] NOT NULL,
	[AFlag] [bit] NOT NULL,
	[Manager_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee_invoice]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_invoice](
	[Invoice_id] [int] NOT NULL,
	[Employee_id] [int] NOT NULL,
	[Amount] [decimal](10, 2) NULL,
	[Interval_Start_Date] [date] NULL,
	[Interval_End_Date] [date] NULL,
	[Payment_Date] [date] NULL,
	[WHours] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Invoice_id] ASC,
	[Employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TRIGGER Employee_Invoice_TRG
ON employee_invoice
INSTEAD OF INSERT

AS

DECLARE @iid INT
DECLARE @eid INT
DECLARE @amount DECIMAL(10,2)
DECLARE @interval_start_date DATE
DECLARE @interval_end_date DATE
DECLARE @payment_date DATE
DECLARE @whours DECIMAL(10,2)

SELECT @eid = Employee_id FROM INSERTED
SELECT @amount = Amount FROM INSERTED
SELECT @interval_start_date = Interval_Start_Date FROM INSERTED
SELECT @interval_end_date = Interval_End_Date FROM INSERTED
SELECT @payment_date = Payment_Date FROM INSERTED
SELECT @whours = WHours FROM INSERTED

IF NOT EXISTS (SELECT * FROM employee_invoice WHERE Employee_id = @eid)
SET @iid = 1
ELSE 
SET @iid = (SELECT MAX(T.Invoice_id) + 1
            FROM employee_invoice T
            WHERE T.Employee_id    = @eid)

INSERT INTO employee_invoice(Invoice_id, Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours)
    VALUES(@iid, @eid, @amount, @interval_start_date, @interval_end_date, @payment_date, @whours)
GO

/****** Object:  Table [dbo].[part]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[part](
	[Part_id] [int] NOT NULL,
	[Part_instance_no] [int] /*IDENTITY(1,1)*/ NOT NULL,
	[PState] [varchar](32) NULL,
	[Price] [decimal](10, 2) NULL,
	[Work_order_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Part_id] ASC,
	[Part_instance_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TRIGGER Part_TRG
ON part
INSTEAD OF INSERT

AS

DECLARE @pid INT
DECLARE @piid INT
DECLARE @state VARCHAR(32)
DECLARE @price DECIMAL(10,2)
DECLARE @woid INT

SELECT @pid = Part_id FROM INSERTED
SELECT @state = PState FROM INSERTED
SELECT @price = Price FROM INSERTED
SELECT @woid = Work_order_id FROM INSERTED

IF NOT EXISTS (SELECT * FROM part WHERE Part_id = @pid)
SET @piid = 1
ELSE 
SET @piid = (SELECT MAX(T.Part_instance_no) + 1
            FROM part T
            WHERE T.Part_id = @pid)

INSERT INTO part(Part_id, Part_instance_no, PState, Price, Work_order_id)
    VALUES(@pid, @piid, @state, @price, @woid)
GO
/****** Object:  Table [dbo].[vehicle]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicle](
	[VIN] [varchar](17) NOT NULL,
	[Vehicle_make] [varchar](32) NOT NULL,
	[Vehicle_model] [varchar](32) NOT NULL,
	[Vehicle_year] [int] NOT NULL,
	[Color] [varchar](32) NULL,
	[CustomerID] [int] NULL,
	[Registration_No] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[VIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehicle_model]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehicle_model](
	[Make] [varchar](32) NOT NULL,
	[Model] [varchar](32) NOT NULL,
	[VYear] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Make] ASC,
	[Model] ASC,
	[VYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[work_order]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[work_order](
	[Work_order_id] [int] IDENTITY(1,1) NOT NULL,
	[Closed] [bit] NULL,
	[Amount_Due] [decimal](10, 2) NULL,
	[Vehicle_VIN] [varchar](17) NOT NULL,
	[CustomerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Work_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[catalog_part] ADD  DEFAULT (NULL) FOR [Part_name]
GO
ALTER TABLE [dbo].[compatible_with] ADD  DEFAULT (NULL) FOR [Part_id]
GO
ALTER TABLE [dbo].[compatible_with] ADD  DEFAULT (NULL) FOR [Vehicle_make]
GO
ALTER TABLE [dbo].[compatible_with] ADD  DEFAULT (NULL) FOR [Vehicle_model]
GO
ALTER TABLE [dbo].[compatible_with] ADD  DEFAULT (NULL) FOR [Vehicle_year]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (NULL) FOR [Fname]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (NULL) FOR [Lname]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (NULL) FOR [CAddress]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT (NULL) FOR [Phone_number]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT '0000' FOR [EPassword]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [Lname]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [Fname]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [EAddress]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [Bank_acc_no]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [Salary_rate]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [Hourly_rate]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT ((0)) FOR [Pay_Type]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT ((0)) FOR [MecFlag]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT ((0)) FOR [CFlag]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT ((0)) FOR [ManFlag]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT ((0)) FOR [AFlag]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT (NULL) FOR [Manager_id]
GO
ALTER TABLE [dbo].[employee_invoice] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[employee_invoice] ADD  DEFAULT (NULL) FOR [Interval_Start_Date]
GO
ALTER TABLE [dbo].[employee_invoice] ADD  DEFAULT (NULL) FOR [Interval_End_Date]
GO
ALTER TABLE [dbo].[employee_invoice] ADD  DEFAULT (NULL) FOR [Payment_Date]
GO
ALTER TABLE [dbo].[employee_invoice] ADD  DEFAULT ((0)) FOR [WHours]
GO
ALTER TABLE [dbo].[part] ADD  DEFAULT (NULL) FOR [Part_id]
GO
ALTER TABLE [dbo].[part] ADD  DEFAULT (NULL) FOR [PState]
GO
ALTER TABLE [dbo].[part] ADD  DEFAULT (NULL) FOR [Price]
GO
ALTER TABLE [dbo].[part] ADD  DEFAULT (NULL) FOR [Work_order_id]
GO
/*ALTER TABLE [dbo].[vehicle] ADD  DEFAULT (NULL) FOR [Vehicle_make]
GO
ALTER TABLE [dbo].[vehicle] ADD  DEFAULT (NULL) FOR [Vehicle_model]
GO
ALTER TABLE [dbo].[vehicle] ADD  DEFAULT (NULL) FOR [Vehicle_year]
GO*/
ALTER TABLE [dbo].[vehicle] ADD  DEFAULT (NULL) FOR [Color]
GO
ALTER TABLE [dbo].[vehicle] ADD  DEFAULT (NULL) FOR [CustomerID]
GO
ALTER TABLE [dbo].[vehicle] ADD  DEFAULT (NULL) FOR [Registration_No]
GO
ALTER TABLE [dbo].[vehicle_model] ADD  DEFAULT (NULL) FOR [Make]
GO
ALTER TABLE [dbo].[vehicle_model] ADD  DEFAULT (NULL) FOR [Model]
GO
ALTER TABLE [dbo].[vehicle_model] ADD  DEFAULT (NULL) FOR [VYear]
GO
ALTER TABLE [dbo].[work_order] ADD  DEFAULT ((0)) FOR [Closed]
GO
ALTER TABLE [dbo].[work_order] ADD  DEFAULT (NULL) FOR [Amount_Due]
GO
/*ALTER TABLE [dbo].[work_order] ADD  DEFAULT (NULL) FOR [Vehicle_VIN]
GO
ALTER TABLE [dbo].[work_order] ADD  DEFAULT (NULL) FOR [CustomerID]
GO*/
ALTER TABLE [dbo].[assigned_to]  WITH CHECK ADD FOREIGN KEY([Mechanic_id])
REFERENCES [dbo].[employee] ([Employee_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[assigned_to]  WITH CHECK ADD  CONSTRAINT [FK_ASWork_order_id] FOREIGN KEY([Work_order_id])
REFERENCES [dbo].[work_order] ([Work_order_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[assigned_to] CHECK CONSTRAINT [FK_ASWork_order_id]
GO
ALTER TABLE [dbo].[associated_with]  WITH CHECK ADD FOREIGN KEY([Clerk_id])
REFERENCES [dbo].[employee] ([Employee_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[associated_with]  WITH CHECK ADD  CONSTRAINT [FK_AWork_order_id] FOREIGN KEY([Work_order_id])
REFERENCES [dbo].[work_order] ([Work_order_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[associated_with] CHECK CONSTRAINT [FK_AWork_order_id]
GO
ALTER TABLE [dbo].[compatible_with]  WITH CHECK ADD FOREIGN KEY([Vehicle_make], [Vehicle_model], [Vehicle_year])
REFERENCES [dbo].[vehicle_model] ([Make], [Model], [VYear])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[compatible_with]  WITH CHECK ADD  CONSTRAINT [FK_CPart_id] FOREIGN KEY([Part_id])
REFERENCES [dbo].[catalog_part] ([Part_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[compatible_with] CHECK CONSTRAINT [FK_CPart_id]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD FOREIGN KEY([Manager_id])
REFERENCES [dbo].[employee] ([Employee_id])
GO
ALTER TABLE [dbo].[employee_invoice]  WITH CHECK ADD  CONSTRAINT [FK_IEmployee_id] FOREIGN KEY([Employee_id])
REFERENCES [dbo].[employee] ([Employee_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employee_invoice] CHECK CONSTRAINT [FK_IEmployee_id]
GO
ALTER TABLE [dbo].[part]  WITH CHECK ADD  CONSTRAINT [FK_PPart_id] FOREIGN KEY([Part_id])
REFERENCES [dbo].[catalog_part] ([Part_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[part] CHECK CONSTRAINT [FK_PPart_id]
GO
ALTER TABLE [dbo].[part]  WITH CHECK ADD  CONSTRAINT [FK_PWork_order_id] FOREIGN KEY([Work_order_id])
REFERENCES [dbo].[work_order] ([Work_order_id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[part] CHECK CONSTRAINT [FK_PWork_order_id]
GO
ALTER TABLE [dbo].[vehicle]  WITH CHECK ADD FOREIGN KEY([Vehicle_make], [Vehicle_model], [Vehicle_year])
REFERENCES [dbo].[vehicle_model] ([Make], [Model], [VYear])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[vehicle]  WITH CHECK ADD  CONSTRAINT [FK_VCustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[customer] ([CustomerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[vehicle] CHECK CONSTRAINT [FK_VCustomerID]
GO
ALTER TABLE [dbo].[work_order]  WITH CHECK ADD  CONSTRAINT [FK_WcustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[customer] ([CustomerID])
GO
ALTER TABLE [dbo].[work_order] CHECK CONSTRAINT [FK_WcustomerID]
GO
ALTER TABLE [dbo].[work_order]  WITH CHECK ADD  CONSTRAINT [FK_WvehicleVIN] FOREIGN KEY([Vehicle_VIN])
REFERENCES [dbo].[vehicle] ([VIN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[work_order] CHECK CONSTRAINT [FK_WvehicleVIN]
GO

/****** Object:  StoredProcedure [dbo].[addCatalogPart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[addCatalogPart]
	@Part_name VARCHAR(64)
AS
	BEGIN
		INSERT INTO catalog_part(Part_name)
		VALUES (@Part_name)
	END

GO
/****** Object:  StoredProcedure [dbo].[addCompatibility]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[addCompatibility]
	@Part_id INT,
	@Vehicle_Make VARCHAR(32),
	@Vehicle_Model VARCHAR(32),
	@Vehicle_Year INT
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM compatible_with
						WHERE Part_id = @Part_id AND
						Vehicle_make = @Vehicle_Make AND
						Vehicle_model = @Vehicle_Model AND
						Vehicle_year = @Vehicle_Year)
		BEGIN
			INSERT INTO compatible_with(Part_id, Vehicle_make, Vehicle_model, Vehicle_year)
			VALUES (@Part_id, @Vehicle_Make, @Vehicle_Model, @Vehicle_Year)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[addCustomer]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[addCustomer]		
	@Fname VARCHAR(128),
	@Lname VARCHAR(128),
	@CAddress VARCHAR(256),
	@Phone_number VARCHAR(15)
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM customer
						WHERE Fname = @Fname AND 
						Phone_number = @Phone_number AND 
						Lname = @Lname AND 
						CAddress = @CAddress)
		BEGIN
			INSERT INTO customer(Fname, Phone_number, Lname, CAddress)
			VALUES(@Fname, @Phone_number, @Lname, @CAddress)
		END 
	END
GO
/****** Object:  StoredProcedure [dbo].[addEmployee]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[addEmployee]
	@EPassword VARCHAR(128),
	@Lname VARCHAR(128),
	@Fname VARCHAR (128),
	@EAddress VARCHAR(256),
	@Bank_acc_no BIGINT,
	@Salary_rate DECIMAL(10,2),
	@Hourly_rate DECIMAL(10,2),
	@Pay_type BIT,
	@MecFlag BIT,
	@CFlag BIT,
	@ManFlag BIT,
	@AFlag BIT,
	@Manager_id INT
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM employee
						WHERE EPassword = @EPassword AND
						Bank_acc_no = @Bank_acc_no AND
						EAddress = @EAddress AND
						Lname = @Lname AND
						Fname = @Fname AND
						Pay_type = @Pay_type AND
						Salary_rate = @Salary_rate AND
						Hourly_rate = @Hourly_rate AND
						MecFlag = @MecFlag AND
						CFlag = @CFlag AND
						ManFlag = @ManFlag AND
						AFlag = @AFlag AND
						(Manager_id = @Manager_id OR (Manager_id IS NULL AND @Manager_id < 1)))
		BEGIN
			IF(@Manager_id < 1) 
			BEGIN 
				INSERT INTO employee(EPassword, Bank_acc_no, EAddress, Lname, Fname, 
							Pay_type, Salary_rate, Hourly_rate, MecFlag, CFlag, ManFlag, 
							AFlag, Manager_id)
				VALUES (@EPassword, @Bank_acc_no, @EAddress, @Lname, @Fname, @Pay_type,
						@Salary_rate, @Hourly_rate, @MecFlag, @CFlag, @ManFlag,
						@AFlag, NULL)
			END
			ELSE
			BEGIN 
				INSERT INTO employee(EPassword, Bank_acc_no, EAddress, Lname, Fname, 
							Pay_type, Salary_rate, Hourly_rate, MecFlag, CFlag, ManFlag, 
							AFlag, Manager_id)
				VALUES (@EPassword, @Bank_acc_no, @EAddress, @Lname, @Fname, @Pay_type,
						@Salary_rate, @Hourly_rate, @MecFlag, @CFlag, @ManFlag,
						@AFlag, @Manager_id)
			END
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[addPart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[addPart]
	@Part_id INT,
	@PState VARCHAR(32),
	@Price DECIMAL(10,2),
	@Work_order_id INT
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM part P
						WHERE P.Part_id = @Part_id AND
							P.PState = @PState AND
							P.Price = @Price AND
							(P.Work_order_id = @Work_order_id OR (P.Work_order_id IS NULL AND @Work_order_id < 1)))
		BEGIN
			IF(@Work_order_id < 1) 
			BEGIN 
				INSERT INTO part(Part_id, PState, Price, Work_order_id)
				VALUES (@Part_id, @PState, @Price, NULL)
			END
			ELSE
			BEGIN
				INSERT INTO part(Part_id, PState, Price, Work_order_id)
				VALUES (@Part_id, @PState, @Price, @Work_order_id)
			END
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[addVehicle]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[addVehicle]
	@VIN VARCHAR(17),
	@Vehicle_make VARCHAR(32),
	@Vehicle_model VARCHAR(32),
	@Vehicle_year INT,
	@Color VARCHAR(32),
	@CustomerID INT,
	@Registration_No VARCHAR(20)
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM vehicle V
						WHERE v.VIN = @VIN)
		BEGIN
			INSERT INTO vehicle(VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No)
			VALUES (@VIN, @Vehicle_make, @Vehicle_model, @Vehicle_year, @Color, @CustomerID, @Registration_No)
		END
	END

	
GO
/****** Object:  StoredProcedure [dbo].[addVehicleModel]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[addVehicleModel]
	@Vehicle_make	VARCHAR(32),
	@Vehicle_model	VARCHAR(32),
	@Year			INT
AS
	BEGIN 
		IF NOT EXISTS (SELECT * FROM vehicle_model
						WHERE Make = @Vehicle_make AND
						Model = @Vehicle_model AND
						VYear = @Year)
		BEGIN
			INSERT INTO vehicle_model(Make, Model, VYear) 
			VALUES (@Vehicle_make, @Vehicle_model, @Year)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[assignClerk]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[assignClerk]
	@Work_order_id INT,
	@Employee_id INT
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM associated_with
						WHERE Work_order_id = @Work_order_id AND
						Clerk_id = @Employee_id)
		BEGIN
			INSERT INTO associated_with(Clerk_id, Work_order_id)
			VALUES (@Employee_id, @Work_order_id)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[assignMechanic]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[assignMechanic]
	@Work_order_id INT,
	@Employee_id INT
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM assigned_to
						WHERE Work_order_id = @Work_order_id AND
						Mechanic_id = @Employee_id)
		BEGIN
			INSERT INTO assigned_to(Mechanic_id, Work_order_id)
			VALUES (@Employee_id, @Work_order_id)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[checkPartCompatibility]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[checkPartCompatibility]
	@Part_id		INT,
	@Vehicle_Make	VARCHAR(32),
	@Vehicle_Model	VARCHAR(32),
	@Vehicle_Year	INT
AS
	BEGIN
		SELECT CAST (CASE WHEN EXISTS (
			SELECT * FROM compatible_with W
			WHERE (	W.Part_id = @Part_id AND
					W.Vehicle_make = @Vehicle_Make AND
					W.Vehicle_model = @Vehicle_Model AND
					W.Vehicle_year = @Vehicle_Year) )
			THEN 1
			ELSE 0
			END AS BIT)
	END
GO
/****** Object:  StoredProcedure [dbo].[checkVehicleModel]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[checkVehicleModel]
	@Vehicle_make	VARCHAR(32),
	@Vehicle_model	VARCHAR(32),
	@Year			INT
AS
	BEGIN
		SELECT CAST (CASE WHEN EXISTS (
			SELECT * FROM vehicle_model V
			WHERE (	V.Make = @Vehicle_Make AND
					V.Model = @Vehicle_Model AND
					V.VYear = @Year) )
			THEN 1
			ELSE 0
			END AS BIT)
	END
GO
/****** Object:  StoredProcedure [dbo].[createWorkOrder]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[createWorkOrder]
	@Closed BIT,
	@Amount_due DECIMAL(10,2),
	@Vehicle_VIN VARCHAR(17),
	@CustomerID INT
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM work_order W
						WHERE W.Closed = @Closed AND
							W.Amount_Due = @Amount_due AND
							W.Vehicle_VIN = @Vehicle_VIN AND
							W.CustomerID = @CustomerID)
		BEGIN
			INSERT INTO work_order(Closed, Amount_Due, Vehicle_VIN, CustomerID) 
			VALUES (@Closed, @Amount_due, @Vehicle_VIN, @CustomerID)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getCatalogPart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[getCatalogPart]
	@Part_id	INT
AS
	Begin
		IF EXISTS (SELECT * FROM catalog_part C
					WHERE C.Part_id = @Part_id)
		BEGIN
			SELECT * FROM catalog_part C
					WHERE C.Part_id = @Part_id
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getCustomer]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[getCustomer]
	@CustomerID INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM customer C
					WHERE C.CustomerID = @CustomerID)
		BEGIN	
			SELECT * FROM customer C
					WHERE C.CustomerID = @CustomerID
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getCustomerVehicles]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[getCustomerVehicles]
	@CustomerID INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM vehicle V
					WHERE V.CustomerID = @CustomerID)
		BEGIN
			SELECT * FROM vehicle V
			WHERE V.CustomerID = @CustomerID
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getCustomerWorkOrders]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getCustomerWorkOrders]
	@CustomerID		INT
AS
	BEGIN
		IF EXISTS (Select * from work_order W
					WHERE W.CustomerID=@CustomerID)
		BEGIN
			Select * from work_order W
			WHERE W.CustomerID=@CustomerID
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getEmployee]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getEmployee]		
	@Employee_id INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM employee E
			WHERE E.Employee_id = @Employee_id)
		BEGIN
			SELECT * FROM employee E
			WHERE E.Employee_id = @Employee_id
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getEmployeeWorkOrders]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getEmployeeWorkOrders]
	@Employee_id INT
AS 
	BEGIN
		IF EXISTS (SELECT * FROM employee E
					WHERE E.Employee_id = @Employee_id)
		BEGIN
			SELECT DISTINCT W.Work_order_id, W.Closed, W.Amount_Due, W.CustomerID, W.Vehicle_VIN FROM work_order W, assigned_to A, associated_with B
			WHERE	((A.Work_order_id = W.Work_order_id) AND (A.Mechanic_id = @Employee_id)) OR
					((B.Work_order_id = W.Work_order_id) AND (B.Clerk_id = @Employee_id))
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getInvoice]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getInvoice]
	@Invoice_id INT,
	@Employee_id INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM employee_invoice E
					WHERE E.Employee_id=@Employee_id AND E.Invoice_id=@Invoice_id)
		BEGIN
			SELECT * FROM employee_invoice
			WHERE Invoice_id = @Invoice_id AND
			Employee_id = @Employee_id
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getInvoices]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getInvoices]
	@Employee_id INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM employee_invoice E
					WHERE E.Employee_id=@Employee_id)
		BEGIN 
			SELECT * FROM employee_invoice
			WHERE Employee_id = @Employee_id
		END
	END
GO

/****** Object:  StoredProcedure [dbo].[getManagersDelagates]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getManagersDelagates]
	@Manager_id INT
AS
	BEGIN
		IF EXISTS (SELECT e.Employee_id FROM employee as e
					WHERE e.Manager_id = @Manager_id)
		BEGIN 
			SELECT e.Employee_id FROM employee as e
			WHERE e.Manager_id = @Manager_id
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getPart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getPart]
	@Part_id INT,
	@Part_instance_no INT
AS 
	BEGIN
		IF EXISTS (SELECT * FROM part P
					WHERE P.Part_id = @Part_id AND
					P.Part_instance_no = @Part_instance_no)
		BEGIN
			SELECT * FROM part P
			WHERE P.Part_id = @Part_id AND
			P.Part_instance_no = @Part_instance_no
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getPartsOnStock]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getPartsOnStock]
AS
	BEGIN
		SELECT * FROM part P
		WHERE (P.Work_order_id IS NULL) OR (P.Work_order_id = 0)
	END
GO
/****** Object:  StoredProcedure [dbo].[getVehicle]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[getVehicle]
	@VIN VARCHAR(17)
AS
	BEGIN
		IF EXISTS (SELECT * FROM vehicle V
					WHERE V.VIN = @VIN)
		BEGIN
			SELECT * FROM vehicle V
			WHERE V.VIN = @VIN
		END
	END

GO
/****** Object:  StoredProcedure [dbo].[getWorkOrder]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getWorkOrder]
	@Work_order_id INT
AS 
	BEGIN
		IF EXISTS (SELECT * from work_order W
					WHERE W.Work_order_id = @Work_order_id)
		BEGIN
			SELECT * FROM work_order W
			WHERE W.Work_order_id = @Work_order_id
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[getWorkOrderParts]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getWorkOrderParts]
	@Work_order_id INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM part P
					WHERE P.Work_order_id = @Work_order_id)
		BEGIN
			SELECT * FROM part P
			WHERE P.Work_order_id = @Work_order_id
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[payEmployee]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[payEmployee]
	@Employee_id INT,
	@Amount DECIMAL(10,2),
	@Interval_Start_Date DATE,
	@Interval_End_Date DATE,
	@Payment_Date DATE,
	@WHours DECIMAL(10,2)
AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM employee_invoice
						WHERE Employee_id = @Employee_id AND
							Interval_Start_Date = @Interval_Start_Date AND
							Interval_End_Date = @Interval_End_Date)
		BEGIN
			INSERT INTO employee_invoice(Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours)
				VALUES (@Employee_id, @Amount, @Interval_Start_Date, @Interval_End_Date, @Payment_Date, @WHours)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[removeCatalogPart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[removeCatalogPart]
	@Part_id VARCHAR(32)

AS
	BEGIN
		IF EXISTS (SELECT * FROM catalog_part
					WHERE Part_id = @Part_id)
		BEGIN
			DELETE FROM catalog_part
			WHERE (Part_id = @Part_id)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[removeVehicleModel]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[removeVehicleModel]
	@Vehicle_make VARCHAR(32),
	@Vehicle_model VARCHAR(32),
	@Vehicle_year INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM vehicle_model V
					WHERE V.Make = @Vehicle_make AND
							V.Model = @Vehicle_model AND
							V.VYear = @Vehicle_year)
		BEGIN
			DELETE FROM vehicle_model
				WHERE (Make = @Vehicle_make AND
						Model = @Vehicle_model AND
						VYear = @Vehicle_year)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[removeWorkOrder]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[removeWorkOrder]
	@Work_order_id INT
AS
	BEGIN
		IF EXISTS (Select * from work_order w
					WHERE w.Work_order_id = @Work_order_id)
		BEGIN 
			DELETE FROM work_order
				WHERE (Work_order_id = @Work_order_id)
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[searchCompatiblePart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[searchCompatiblePart]
	@Vehicle_make		VARCHAR(32),
	@Vehicle_model		VARCHAR(32),
	@Vehicle_year		INT,
	@Part_name_string	VARCHAR(256)
AS
	BEGIN
		IF EXISTS (	SELECT cat.Part_id, cat.Part_name
					FROM catalog_part as cat, compatible_with as com
					WHERE (com.Part_id = cat.Part_id AND com.Vehicle_make=@Vehicle_make AND com.Vehicle_model=@Vehicle_model
						AND com.Vehicle_year=@Vehicle_year AND cat.Part_name LIKE '%' + @Part_name_string + '%'))
		BEGIN 
			SELECT cat.Part_id, cat.Part_name
			FROM catalog_part as cat, compatible_with as com
			WHERE (com.Part_id = cat.Part_id AND com.Vehicle_make=@Vehicle_make AND com.Vehicle_model=@Vehicle_model
						AND com.Vehicle_year=@Vehicle_year AND cat.Part_name LIKE '%' + @Part_name_string + '%')
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[updateCustomer]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[updateCustomer]
	@CustomerID		INT,
	@Fname			VARCHAR(128),
	@Phone_number	VARCHAR(15),
	@Lname			VARCHAR(128),
	@Address		VARCHAR(256)
AS
	BEGIN
		IF EXISTS (SELECT * FROM customer WHERE CustomerID = @CustomerID)
		BEGIN	
			UPDATE customer
			SET		Fname = @Fname,
					Lname = @Lname,
					CAddress = @Address,
					Phone_number = @Phone_number
			WHERE
				CustomerID = @CustomerID
		END
	END

					
GO
/****** Object:  StoredProcedure [dbo].[updateEmployeeInfo]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[updateEmployeeInfo]
	@Employee_id INT,
	@EPassword VARCHAR(128),
	@Bank_acc_no BIGINT,
	@EAddress VARCHAR(256),
	@Lname VARCHAR(128),
	@Fname VARCHAR (128),
	@Pay_type BIT,
	@Salary_rate DECIMAL(10,2),
	@Hourly_rate DECIMAL(10,2),
	@MecFlag BIT,
	@CFlag BIT,
	@ManFlag BIT,
	@AFlag BIT,
	@Manager_id INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM employee 
					WHERE Employee_id = @Employee_id)
		BEGIN
			IF(@Manager_id < 1) 
			BEGIN 
				UPDATE employee 
				SET Bank_acc_no = @Bank_acc_no,
					EPassword = @EPassword,
 					EAddress = @EAddress, 
					Lname = @Lname, 
					Fname = @Fname, 
					Pay_type = @Pay_type, 
					Salary_rate = @Salary_rate,
					Hourly_rate = @Hourly_rate, 
					MecFlag = @MecFlag, 
					CFlag = @CFlag, 
					ManFlag = @ManFlag, 
					AFlag = @AFlag, 
					Manager_id = NULL
				WHERE Employee_id = @Employee_id
			END
			ELSE
			BEGIN
				UPDATE employee 
				SET Bank_acc_no = @Bank_acc_no,
					EPassword = @EPassword,
 					EAddress = @EAddress, 
					Lname = @Lname, 
					Fname = @Fname, 
					Pay_type = @Pay_type, 
					Salary_rate = @Salary_rate,
					Hourly_rate = @Hourly_rate, 
					MecFlag = @MecFlag, 
					CFlag = @CFlag, 
					ManFlag = @ManFlag, 
					AFlag = @AFlag, 
					Manager_id = @Manager_id 
				WHERE Employee_id = @Employee_id
			END
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[updatePart]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[updatePart]
	@Part_id INT,
	@Part_instance_no INT,
	@PState VARCHAR(32),
	@Price DECIMAL(10,2),
	@Work_order_id INT
AS 
	BEGIN
		IF EXISTS (SELECT * FROM part P
					WHERE P.Part_id = @Part_id AND P.Part_instance_no = @Part_instance_no)
		BEGIN
			IF(@Work_order_id < 1) 
			BEGIN 
				UPDATE part
				SET		PState = @PState,
						Price = @Price,
						Work_order_id = NULL
				WHERE Part_id = @Part_id AND Part_instance_no = @Part_instance_no
			END
			ELSE
			BEGIN
				UPDATE part
				SET		PState = @PState,
						Price = @Price,
						Work_order_id = @Work_order_id
				WHERE Part_id = @Part_id AND Part_instance_no = @Part_instance_no
			END
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[updateVehicle]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[updateVehicle]
	@VIN				VARCHAR(17),
	@Vehicle_make		VARCHAR(32),
	@Vehicle_model		VARCHAR(32),
	@Vehicle_year		INT,
	@Color				VARCHAR(32),
	@CustomerID			INT,
	@Registration_No	VARCHAR(20)
AS
	BEGIN
		IF EXISTS (SELECT * FROM vehicle V WHERE V.VIN = @VIN)

		BEGIN
			UPDATE vehicle
			SET Vehicle_make = @Vehicle_make,
				Vehicle_model = @Vehicle_model,
				Vehicle_year = @Vehicle_year,
				Color = @Color,
				CustomerID = @CustomerID,
				Registration_No = @Registration_No
			WHERE VIN = @VIN
		END
	END
GO
/****** Object:  StoredProcedure [dbo].[updateWorkOrder]    Script Date: 2020-12-07 5:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[updateWorkOrder]
	@Work_order_id INT,
	@Closed BIT,
	@Amount_due DECIMAL(10,2),
	@Vehicle_VIN VARCHAR(17),
	@CustomerID INT
AS
	BEGIN
		IF EXISTS (SELECT * FROM work_order W
					WHERE W.Work_order_id = @Work_order_id)
		BEGIN
			UPDATE work_order
			SET Closed = @Closed,
				Amount_Due = @Amount_due,
				Vehicle_VIN = @Vehicle_VIN,
				CustomerID = @CustomerID
			WHERE 
				Work_order_id = @Work_order_id
		END
	END
GO
USE [master]
GO
ALTER DATABASE [autorepair] SET  READ_WRITE 
GO
