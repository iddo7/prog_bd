/*
    Projet Prog & DB
    Julien Fortin & Isaac Negreiros
    BD Export
*/



/*   --- DROPPING TABLES ---   */
drop function if exists calculate_salary_for_project;
drop table if exists projects_employees cascade;
drop table if exists employees cascade;
drop table if exists projects cascade;
drop table if exists clients cascade;



/*   --- CREATING TABLES ---   */

CREATE TABLE clients (
    id INT PRIMARY KEY,
    fullName VARCHAR(255),
    address VARCHAR(255),
    phoneNumber VARCHAR(20),
    email VARCHAR(255)
);

CREATE TABLE projects (
    code VARCHAR(20) PRIMARY KEY,
    title VARCHAR(255),
    startDate DATE,
    description TEXT,
    budget DOUBLE,
    numberOfEmployees INT CHECK (numberOfEmployees <= 5),
    totalSalaries DOUBLE,
    clientId INT,
    status VARCHAR(10) DEFAULT 'En cours',
    FOREIGN KEY (clientId) REFERENCES clients(id)
);

CREATE TABLE employees (
    code VARCHAR(20) PRIMARY KEY,
    firstName VARCHAR(255),
    lastName VARCHAR(255),
    birthday DATE,
    email VARCHAR(255),
    address VARCHAR(255),
    hiringDate DATE,
    hourlyRate DOUBLE CHECK (hourlyRate >= 15),
    profilePicture VARCHAR(255),
    status VARCHAR(20)
);

CREATE TABLE projects_employees (
    projectCode VARCHAR(20),
    employeeCode VARCHAR(20),
    hoursWorked DOUBLE,
    salary DOUBLE,
    FOREIGN KEY (employeeCode) REFERENCES employees(code),
    FOREIGN KEY (projectCode) REFERENCES projects(code)
);


INSERT INTO clients (id, fullName, address, phoneNumber, email)
VALUES
    (100, 'John Doe', '123 Main St', '+1234567890', 'john.doe@example.com'),
    (101, 'Jane Smith', '456 Oak Ave', '+0987654321', 'jane.smith@example.com'),
    (102, 'Robert Johnson', '789 Pine Rd', '+1122334455', 'robert.j@example.com'),
    (103, 'Maria Garcia', '101 Maple Ln', '+3344556677', 'maria.g@example.com'),
    (104, 'William Davis', '202 Cedar Blvd', '+5566778899', 'william.d@example.com'),
    (105, 'Sophie Brown', '303 Walnut St', '+9900112233', 'sophie.b@example.com'),
    (106, 'Michael White', '404 Birch Rd', '+6677889900', 'michael.w@example.com'),
    (107, 'Eva Robinson', '505 Pine Ave', '+1122334455', 'eva.r@example.com'),
    (108, 'Alex Turner', '606 Oak Ln', '+3344556677', 'alex.t@example.com'),
    (109, 'Olivia Taylor', '707 Elm Blvd', '+5566778899', 'olivia.t@example.com');

INSERT INTO projects (code, title, startDate, description, budget, numberOfEmployees, totalSalaries, clientId, status)
VALUES
    ('P001', 'Website Redesign', '2023-01-15', 'Redesigning the company website', 5000.00, 3, 3000.00, 100, 'En cours'),
    ('P002', 'Product Launch', '2023-02-01', 'Launching a new product line', 10000.00, 5, 5000.00, 101, 'En cours'),
    ('P003', 'Marketing Campaign', '2023-03-10', 'Promoting the brand through various channels', 8000.00, 4, 4000.00, 103, 'En cours'),
    ('P004', 'Sales Training', '2023-04-05', 'Training the sales team on new techniques', 6000.00, 2, 2000.00, 104, 'En cours'),
    ('P005', 'Inventory System Upgrade', '2023-05-20', 'Upgrading the inventory management system', 7000.00, 3, 3000.00, 105, 'En cours'),
    ('P006', 'Customer Support Improvement', '2023-06-15', 'Enhancing customer support services', 4000.00, 2, 2000.00, 106, 'En cours'),
    ('P007', 'Employee Wellness Program', '2023-07-01', 'Implementing a wellness program for employees', 3000.00, 1, 1000.00, 107, 'En cours'),
    ('P008', 'Mobile App Development', '2023-08-10', 'Developing a mobile application', 12000.00, 4, 4000.00, 108, 'En cours'),
    ('P009', 'Training Videos Production', '2023-09-05', 'Creating training videos for internal use', 5000.00, 2, 2000.00, 109, 'En cours'),
    ('P010', 'Community Outreach', '2023-10-20', 'Engaging with the local community', 2500.00, 1, 1000.00, 102, 'En cours');

INSERT INTO employees (code, firstName, lastName, birthday, email, address, hiringDate, hourlyRate, profilePicture, status)
VALUES
    ('E001', 'Alice', 'Johnson', '1990-05-20', 'alice.johnson@example.com', '789 Pine Rd', '2022-03-10', 20.00, 'alice.jpg', 'Active'),
    ('E002', 'Bob', 'Williams', '1985-12-15', 'bob.williams@example.com', '456 Elm St', '2021-02-28', 25.00, 'bob.jpg', 'Active'),
    ('E003', 'Charlie', 'Smith', '1992-08-30', 'charlie.smith@example.com', '101 Oak Ln', '2023-01-15', 18.00, 'charlie.jpg', 'Active'),
    ('E004', 'Diana', 'Miller', '1988-04-05', 'diana.miller@example.com', '202 Maple Blvd', '2020-11-05', 22.00, 'diana.jpg', 'Active'),
    ('E005', 'Edward', 'Jones', '1995-06-22', 'edward.jones@example.com', '303 Cedar Ave', '2022-05-10', 23.00, 'edward.jpg', 'Active'),
    ('E006', 'Fiona', 'Brown', '1987-02-18', 'fiona.brown@example.com', '404 Birch Rd', '2021-09-01', 19.00, 'fiona.jpg', 'Active'),
    ('E007', 'George', 'Clark', '1991-11-12', 'george.clark@example.com', '505 Pine St', '2022-07-15', 21.00, 'george.jpg', 'Active'),
    ('E008', 'Helen', 'White', '1986-07-08', 'helen.white@example.com', '606 Elm Ave', '2020-12-20', 26.00, 'helen.jpg', 'Active'),
    ('E009', 'Ian', 'Martin', '1993-09-25', 'ian.martin@example.com', '707 Walnut Ln', '2023-02-05', 24.00, 'ian.jpg', 'Active'),
    ('E010', 'Jessica', 'Wilson', '1989-03-14', 'jessica.wilson@example.com', '808 Cedar Blvd', '2022-04-18', 21.50, 'jessica.jpg', 'Active');

INSERT INTO projects_employees (projectCode, employeeCode, hoursWorked)
VALUES
    ('P001', 'E001', 40.0),
    ('P009', 'E001', 40.0),
    ('P001', 'E002', 32.5),
    ('P002', 'E003', 45.0),
    ('P002', 'E004', 28.0),
    ('P003', 'E005', 35.5);



/*   --- CREATING FUNCTIONS ---   */

CREATE FUNCTION f_calculate_salary_for_project (employeeCode VARCHAR(20), projectCode VARCHAR(20))
RETURNS DOUBLE
BEGIN
    DECLARE salary DOUBLE;

    SELECT hoursWorked * hourlyRate INTO salary
    FROM projects_employees pe
    INNER JOIN employees e ON pe.employeeCode = e.code
    WHERE pe.employeeCode = employeeCode AND pe.projectCode = projectCode;

    RETURN salary;
END;
-- Ex: SELECT f_calculate_salary_for_project('E002', 'P001') AS salary


