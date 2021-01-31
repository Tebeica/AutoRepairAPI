USE [autorepair]
GO
-- EMPLOYEE ***********************************************************************************************
-- need to insert managers first, as the foreign key for manager id requires it
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Caffrey', 'Caril', '606 Del Mar Terrace', 6706721858273654, 62455.90, null, 0, 0, 0, 0, 1, null);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Iacomettii', 'Roobbie', '51934 Esch Park', '36077987490352', 68971.08, null, 0, 0, 0, 0, 1, null);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Haverty', 'Nada', '10 Crowley Trail', '560221106786707613', 76149.37, null, 0, 0, 0, 0, 1, null);
-- insert admin
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Dmitrichenko', 'Maggee', '2909 Helena Street', '4917440451151080', 75280.51, null, 0, 0, 0, 1, 1, null);
-- insert mechanics
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Conan', 'Enrichetta', '79 Bayside Way', '3552807951599814', null, 58.99, 1, 1, 0, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Sanders', 'Scot', '375 Glacier Hill Lane', '5100132009242305', 55237.63, null, 0, 1, 0, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Riccardelli', 'Claudine', '288 Redwing Crossing', '491173161952488494', 53810.86, null, 0, 1, 0, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Roos', 'Jamill', '48 Pennsylvania Court', '3558398023252651', null, 38.51, 1, 1, 0, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Kliemchen', 'Ettore', '99191 School Place', '3557848139560844', null, 26.09, 1, 1, 0, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Glantz', 'Sigfried', '2720 Loftsgordon Avenue', '3583123652829564', null, 32.36, 1, 1, 0, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Petkens', 'Sande', '92 Namekagon Crossing', '5268966690576267', null, 36.93, 1, 1, 0, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Lenglet', 'Glory', '70 Mandrake Pass', '3538172140007800', 71253.68, null, 0, 1, 0, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Larcher', 'Bili', '32 Blackbird Point', '3546761847701143', null, 59.78, 1, 1, 0, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Rylatt', 'Angel', '8 Dovetail Crossing', '5455283451023247', null, 36.68, 1, 1, 0, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Guirard', 'Robyn', '33 Colorado Pass', '30267954510474', 52660.48, null, 0, 1, 0, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Silversmid', 'Major', '35 Johnson Avenue', '347809676877869', null, 47.41, 1, 1, 0, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'O''Luney', 'Daryl', '637 Randy Trail', '5602236339359268', null, 25.01, 1, 1, 0, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Clemitt', 'Gabriela', '38 Thierer Point', '3554151819258679', 57391.54, null, 0, 1, 0, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Foan', 'Dody', '8 Longview Place', '36875176549114', 78212.13, null, 0, 1, 0, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Galbraith', 'Sunny', '3 Blue Bill Park Court', '201421928386379', null, 18.89, 1, 1, 0, 0, 0, 2)
-- insert clerks
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Brydell', 'Darby', '667 Eagle Crest Center', '374622246502396', null, 43.67, 1, 0, 1, 0, 0, 2);;
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Cowthart', 'Janene', '2 Warner Parkway', '3558028339725641', null, 16.19, 1, 0, 1, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Hebard', 'Thorny', '7 Monument Drive', '3533232410943137', 68428.05, null, 0, 0, 1, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'MacFadin', 'Bartholemy', '3 Chive Avenue', '060426019145867438', null, 18.55, 1, 0, 1, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Hein', 'Ermanno', '282 Rowland Trail', '5241874723613549', null, 46.10, 1, 0, 1, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Stoade', 'Idette', '145 Center Center', '3558525307696274', 55840.49, null, 0, 0, 1, 0, 0, 3);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Santacrole', 'Ally', '83389 Shoshone Place', '201852178897261', null, 44.04, 1, 0, 1, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Choake', 'Gasparo', '30176 Texas Pass', '30119316733643', null, 43.31, 1, 0, 1, 0, 0, 1);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'McBeth', 'Poppy', '104 Thackeray Court', '30104000480248', null, 56.04, 1, 0, 1, 0, 0, 2);
insert into employee (EPassword, Lname, Fname, EAddress, Bank_acc_no, Salary_rate, Hourly_rate, Pay_type, MecFlag, CFlag, AFlag, ManFlag, Manager_id) values ('123456', 'Mostin', 'Clea', '661 Kenwood Drive', '3568101950705263', 60748.14, null, 0, 0, 1, 0, 0, 1);



-- employee_invoice ***********************************************************************************************
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (1, 2315.55, '2020-07-08', '2020-07-22', '2020-07-29', 30);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (2, 1180.96, '2020-07-08', '2020-07-22', '2020-07-29', 70);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (3, 1797.68, '2020-07-08', '2020-07-22', '2020-07-29', 74);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (4, 616.22, '2020-07-08', '2020-07-22', '2020-07-29', 14);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (5, 2217.51, '2020-07-08', '2020-07-22', '2020-07-29', 58);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (12, 2144.98, '2020-07-08', '2020-07-22', '2020-07-29', 7);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (7, 855.12, '2020-07-08', '2020-07-22', '2020-07-29', 0);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (6, 1236.46, '2020-07-08', '2020-07-22', '2020-07-29', 21);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (9, 1813.52, '2020-07-08', '2020-07-22', '2020-07-29', 5);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (11, 1437.67, '2020-07-08', '2020-07-22', '2020-07-29', 60);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (13, 1522.70, '2020-07-08', '2020-07-22', '2020-07-29', 41);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (19, 2073.36, '2020-07-08', '2020-07-22', '2020-07-29', 54);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (22, 2091.39, '2020-07-08', '2020-07-22', '2020-07-29', 8);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (23, 1807.47, '2020-07-08', '2020-07-22', '2020-07-29', 66);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (30, 1420.46, '2020-07-08', '2020-07-22', '2020-07-29', 83);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (26, 2007.97, '2020-07-08', '2020-07-22', '2020-07-29', 64);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (15, 1240.86, '2020-07-08', '2020-07-22', '2020-07-29', 64);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (16, 2075.38, '2020-07-08', '2020-07-22', '2020-07-29', 41);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (30, 693.40, '2020-07-08', '2020-07-22', '2020-07-29', 83);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (27, 1851.25, '2020-07-08', '2020-07-22', '2020-07-29', 19);

insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (1, 2071.33, '2020-07-23', '2020-08-05', '2020-08-12', 34);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (2, 1697.55, '2020-07-23', '2020-08-05', '2020-08-12', 35);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (3, 2309.60, '2020-07-23', '2020-08-05', '2020-08-12', 46);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (4, 3110.28, '2020-07-23', '2020-08-05', '2020-08-12', 61);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (5, 2707.50, '2020-07-23', '2020-08-05', '2020-08-12', 19);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (6, 3896.81, '2020-07-23', '2020-08-05', '2020-08-12', 32);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (7, 535.11, '2020-07-23', '2020-08-05', '2020-08-12', 66);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (8, 2042.60, '2020-07-23', '2020-08-05', '2020-08-12', 36);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (9, 708.53, '2020-07-23', '2020-08-05', '2020-08-12', 32);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (10, 976.49, '2020-07-23', '2020-08-05', '2020-08-12', 50);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (11, 3962.65, '2020-07-23', '2020-08-05', '2020-08-12', 84);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (12, 1148.25, '2020-07-23', '2020-08-05', '2020-08-12', 7);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (13, 3169.47, '2020-07-23', '2020-08-05', '2020-08-12', 37);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (14, 1188.11, '2020-07-23', '2020-08-05', '2020-08-12', 77);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (15, 1819.92, '2020-07-23', '2020-08-05', '2020-08-12', 6);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (16, 2328.10, '2020-07-23', '2020-08-05', '2020-08-12', 47);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (17, 3605.88, '2020-07-23', '2020-08-05', '2020-08-12', 9);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (18, 1743.10, '2020-07-23', '2020-08-05', '2020-08-12', 1);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (19, 1170.63, '2020-07-23', '2020-08-05', '2020-08-12', 60);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (20, 1841.14, '2020-07-23', '2020-08-05', '2020-08-12', 16);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (21, 1589.63, '2020-07-23', '2020-08-05', '2020-08-12', 56);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (22, 3320.62, '2020-07-23', '2020-08-05', '2020-08-12', 71);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (23, 979.29, '2020-07-23', '2020-08-05', '2020-08-12', 70);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (24, 3861.26, '2020-07-23', '2020-08-05', '2020-08-12', 14);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (25, 3994.46, '2020-07-23', '2020-08-05', '2020-08-12', 63);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (26, 721.94, '2020-07-23', '2020-08-05', '2020-08-12', 83);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (27, 3020.28, '2020-07-23', '2020-08-05', '2020-08-12', 1);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (28, 3445.15, '2020-07-23', '2020-08-05', '2020-08-12', 60);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (29, 670.99, '2020-07-23', '2020-08-05', '2020-08-12', 81);
insert into employee_invoice (Employee_id, Amount, Interval_Start_Date, Interval_End_Date, Payment_Date, WHours) values (30, 3992.43, '2020-07-23', '2020-08-05', '2020-08-12', 81);



-- customer ***********************************************************************************************
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Rikki', 'Entres', '58091 Mosinee Park', '623-822-8450');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Sheela', 'Facher', '8122 Corry Junction', '999-601-4410');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Clerkclaude', 'Yelden', '749 Park Meadow Trail', '971-767-0755');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Ramonda', 'Zanardii', '57225 Russell Court', '867-906-9295');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Lawton', 'Alenshev', '9 Pine View Avenue', '784-113-0318');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Morris', 'Caseri', '2 Autumn Leaf Parkway', '810-616-4093');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Kippar', 'Reinmar', '3 Oneill Point', '720-565-0775');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Antonino', 'Farrell', '15 Texas Hill', '477-825-5585');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Wash', 'Rowthorn', '72945 Village Green Center', '299-804-3422');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Harman', 'Deacon', '14020 Red Cloud Lane', '210-597-3307');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Alexia', 'Sayse', '643 Eastwood Avenue', '593-445-2973');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Marieann', 'Tanner', '559 Hintze Alley', '435-226-0069');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Webb', 'Pharaoh', '1322 Steensland Drive', '125-143-8786');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Roderich', 'Lunam', '60 Northview Terrace', '384-273-6916');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Reilly', 'Kliesl', '1842 Maywood Park', '243-163-8506');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Catlaina', 'Gosling', '0 Lyons Trail', '139-786-2260');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Trefor', 'Marquand', '72 Clemons Hill', '788-240-7831');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Alano', 'Kerley', '3974 Fisk Road', '586-796-1497');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Mellie', 'Fraczak', '49 Del Mar Pass', '978-979-8985');
insert into customer (Fname, Lname, CAddress, Phone_number) values ('Michale', 'Pochon', '25545 Summer Ridge Park', '220-969-3305');



-- vehicle_model ***********************************************************************************************
insert into vehicle_model (Make, Model, VYear) values ('Lotus', 'Esprit', 1996);
insert into vehicle_model (Make, Model, VYear) values ('Hyundai', 'Azera', 2010);
insert into vehicle_model (Make, Model, VYear) values ('MINI', 'Clubman', 2008);
insert into vehicle_model (Make, Model, VYear) values ('Honda', 'Insight', 2003);
insert into vehicle_model (Make, Model, VYear) values ('Honda', 'Element', 2003);
insert into vehicle_model (Make, Model, VYear) values ('Mazda', 'MPV', 1994);
insert into vehicle_model (Make, Model, VYear) values ('BMW', 'Z4 M', 2006);
insert into vehicle_model (Make, Model, VYear) values ('GMC', 'Jimmy', 1999);
insert into vehicle_model (Make, Model, VYear) values ('Infiniti', 'G', 1996);
insert into vehicle_model (Make, Model, VYear) values ('GMC', 'Suburban 1500', 1996);
insert into vehicle_model (Make, Model, VYear) values ('Volkswagen', 'GTI', 1999);
insert into vehicle_model (Make, Model, VYear) values ('Land Rover', 'Range Rover', 1995);
insert into vehicle_model (Make, Model, VYear) values ('Pontiac', 'Firefly', 1995);
insert into vehicle_model (Make, Model, VYear) values ('Mitsubishi', 'Galant', 1999);
insert into vehicle_model (Make, Model, VYear) values ('Subaru', 'Legacy', 2007);



-- vehicle ***********************************************************************************************
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('JN8AF5MR0BT743790', 'Lotus', 'Esprit', 1996, 'Yellow', 1, '4060740594');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('KL8AF5HP0BT748375', 'Lotus', 'Esprit', 1996, 'Blue', 1, '4060740594');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('1N4AL2AP5AC604359', 'Hyundai', 'Azera', 2010, 'Blue', 2, '3783463998');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('KMHCM3ACXAU419958', 'MINI', 'Clubman', 2008, 'Teal', 3, '7816781881');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('WVGAV7AX6AW338281', 'Honda', 'Insight', 2003, 'Purple', 4, '5531342675');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('WAUA2AFD2DN666409', 'Honda', 'Element', 2003, 'Turquoise', 5, '1548056375');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('1G6AY5S39E0782777', 'Mazda', 'MPV', 1994, 'Teal', 6, '4491953856');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('WAUFGBFCXDN550623', 'BMW', 'Z4 M', 2006, 'Crimson', 7, '8304101912');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('1G6AS5SX3E0733661', 'GMC', 'Jimmy', 1999, 'Blue', 8, '2871450773');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('WAURV78T88A777089', 'Infiniti', 'G', 1996, 'Fuscia', 9, '3582602567');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('SAJWA6BU4F8176233', 'GMC', 'Suburban 1500', 1996, 'Maroon', 10, '8106077551');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('5NPEB4AC4CH579288', 'Volkswagen', 'GTI', 1999, 'Maroon', 11, '7931044304');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('JTHBE1D28F5949334', 'Land Rover', 'Range Rover', 1995, 'Crimson', 12, '7161291909');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('5UXKR2C55E0720496', 'Mitsubishi', 'Galant', 1999, 'Mauv', 13, '6973999611');
insert into vehicle (VIN, Vehicle_make, Vehicle_model, Vehicle_year, Color, CustomerID, Registration_No) values ('3C63D3FLXCG948613', 'Subaru', 'Legacy', 2007, 'Goldenrod', 14, '3847165178');



-- work_order ***********************************************************************************************
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 458.61, 'JN8AF5MR0BT743790', 1);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (0, 3500.76, '1N4AL2AP5AC604359', 2);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (0, 193.71, 'KMHCM3ACXAU419958', 3);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 1715.06, 'WVGAV7AX6AW338281', 4);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 4135.00, 'WAUA2AFD2DN666409', 5);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 3071.95, '1G6AY5S39E0782777', 6);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (0, 3341.63, 'WAUFGBFCXDN550623', 7);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (0, 1227.36, '1G6AS5SX3E0733661', 8);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 3619.53, 'WAURV78T88A777089', 9);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 3559.32, 'SAJWA6BU4F8176233', 10);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (0, 1439.59, '5NPEB4AC4CH579288', 11);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (0, 2295.26, 'JTHBE1D28F5949334', 12);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 3106.40, '5UXKR2C55E0720496', 13);
insert into work_order (Closed, Amount_Due, Vehicle_VIN, CustomerID) values (1, 776.25, '3C63D3FLXCG948613', 14);


-- associated_with ***********************************************************************************************
insert into associated_with (Clerk_id, Work_order_id) values (21, 1);
insert into associated_with (Clerk_id, Work_order_id) values (21, 2);
insert into associated_with (Clerk_id, Work_order_id) values (22, 3);
insert into associated_with (Clerk_id, Work_order_id) values (23, 4);
insert into associated_with (Clerk_id, Work_order_id) values (24, 5);
insert into associated_with (Clerk_id, Work_order_id) values (25, 6);
insert into associated_with (Clerk_id, Work_order_id) values (26, 7);
insert into associated_with (Clerk_id, Work_order_id) values (27, 8);
insert into associated_with (Clerk_id, Work_order_id) values (28, 9);
insert into associated_with (Clerk_id, Work_order_id) values (30, 10);
insert into associated_with (Clerk_id, Work_order_id) values (21, 11);
insert into associated_with (Clerk_id, Work_order_id) values (21, 12);
insert into associated_with (Clerk_id, Work_order_id) values (22, 13);
insert into associated_with (Clerk_id, Work_order_id) values (23, 14);



-- assigned_to ***********************************************************************************************
insert into assigned_to (Mechanic_id, Work_order_id) values (5, 1);
insert into assigned_to (Mechanic_id, Work_order_id) values (5, 2);
insert into assigned_to (Mechanic_id, Work_order_id) values (6, 3);
insert into assigned_to (Mechanic_id, Work_order_id) values (7, 4);
insert into assigned_to (Mechanic_id, Work_order_id) values (8, 5);
insert into assigned_to (Mechanic_id, Work_order_id) values (9, 6);
insert into assigned_to (Mechanic_id, Work_order_id) values (10, 7);
insert into assigned_to (Mechanic_id, Work_order_id) values (11, 8);
insert into assigned_to (Mechanic_id, Work_order_id) values (12, 9);
insert into assigned_to (Mechanic_id, Work_order_id) values (13, 10);
insert into assigned_to (Mechanic_id, Work_order_id) values (14, 11);
insert into assigned_to (Mechanic_id, Work_order_id) values (15, 12);
insert into assigned_to (Mechanic_id, Work_order_id) values (16, 13);
insert into assigned_to (Mechanic_id, Work_order_id) values (18, 14);



-- catalog_part ***********************************************************************************************
insert into catalog_part (Part_name) values ('Balance Shaft Chain');
insert into catalog_part (Part_name) values ('Balance Shaft Chain Guide');
insert into catalog_part (Part_name) values ('Balance Shaft Chain Tensioner');
insert into catalog_part (Part_name) values ('Balance Shaft Sprocket');
insert into catalog_part (Part_name) values ('Camshaft Bolt');
insert into catalog_part (Part_name) values ('Camshaft Seal');
insert into catalog_part (Part_name) values ('Conversion / Lower Gasket Set');
insert into catalog_part (Part_name) values ('Crankshaft Repair Sleeve');
insert into catalog_part (Part_name) values ('Crankshaft Seal');
insert into catalog_part (Part_name) values ('Cylinder Head Bolt');
insert into catalog_part (Part_name) values ('Cylinder Head Gasket');
insert into catalog_part (Part_name) values ('Cylinder Head Gasket Set');
insert into catalog_part (Part_name) values ('Cylinder Repair Sleeve');
insert into catalog_part (Part_name) values ('Exhaust Valve');



-- part ***********************************************************************************************
insert into part (Part_id, PState, Price, Work_order_id) values (1, 0, 1075.89, 1);
insert into part (Part_id, PState, Price, Work_order_id) values (2, 1, 1299.41, 2);
insert into part (Part_id, PState, Price, Work_order_id) values (3, 0, 853.53, 3);
insert into part (Part_id, PState, Price, Work_order_id) values (4, 1, 1509.97, 4);
insert into part (Part_id, PState, Price, Work_order_id) values (5, 1, 1317.87, 5);
insert into part (Part_id, PState, Price, Work_order_id) values (6, 0, 279.59, 6);
insert into part (Part_id, PState, Price, Work_order_id) values (7, 1, 544.40, 7);
insert into part (Part_id, PState, Price, Work_order_id) values (8, 1, 1237.77, 8);
insert into part (Part_id, PState, Price, Work_order_id) values (9, 1, 954.03, 9);
insert into part (Part_id, PState, Price, Work_order_id) values (10, 1, 1331.53, 10);
insert into part (Part_id, PState, Price, Work_order_id) values (11, 0, 1310.14, 11);
insert into part (Part_id, PState, Price, Work_order_id) values (12, 0, 639.19, 12);
insert into part (Part_id, PState, Price, Work_order_id) values (13, 0, 596.93, 13);
insert into part (Part_id, PState, Price, Work_order_id) values (14, 1, 666.65, 14);
insert into part (Part_id, PState, Price, Work_order_id) values (14, 1, 622.65, 14);
insert into part (Part_id, PState, Price, Work_order_id) values (14, 1, 663.65, 14);
insert into part (Part_id, PState, Price, Work_order_id) values (14, 1, 6566.65, NULL);
insert into part (Part_id, PState, Price, Work_order_id) values (14, 1, 622.65, NULL);
insert into part (Part_id, PState, Price, Work_order_id) values (14, 1, 6637.65, NULL);


-- compatible_with ***********************************************************************************************
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (1, 'Lotus', 'Esprit', 1996);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (1, 'Hyundai', 'Azera', 2010);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (2, 'Hyundai', 'Azera', 2010);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (10, 'Hyundai', 'Azera', 2010);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (3, 'MINI', 'Clubman', 2008);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (4, 'Honda', 'Insight', 2003);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (5, 'Honda', 'Element', 2003);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (6, 'Mazda', 'MPV', 1994);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (7, 'BMW', 'Z4 M', 2006);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (8, 'GMC', 'Jimmy', 1999);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (9, 'Infiniti', 'G', 1996);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (10, 'GMC', 'Suburban 1500', 1996);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (11, 'Volkswagen', 'GTI', 1999);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (12, 'Land Rover', 'Range Rover', 1995);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (13, 'Mitsubishi', 'Galant', 1999);
insert into compatible_with (Part_id, Vehicle_make, Vehicle_model, Vehicle_year) values (14, 'Subaru', 'Legacy', 2007);