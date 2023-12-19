/*
    Projet Prog & DB
    Julien Fortin & Isaac Negreiros
    BD Export
*/

/*   --- DROPPING ---   */
/*   --- DROPPING ---   */
drop view if exists v_clients_with_projects cascade;
drop view if exists v_clients_without_projects cascade;
drop view if exists v_employees_with_projects cascade;
drop view if exists v_projects cascade;
drop view if exists v_unassigned_employees cascade;

drop function if exists f_random_int;
drop function if exists f_calculate_salary_for_project;
drop function if exists f_client_id_exists;
drop function if exists f_generate_unique_client_id;
drop function if exists f_has_a_project;
drop function if exists f_is_assigned;
drop function if exists f_number_of_projects;
drop function if exists f_generate_employee_code;
drop function if exists f_generate_project_code;
drop function if exists f_calculate_total_salaries;
drop procedure if exists p_assign_employee_to_project;
drop procedure if exists p_delete_client;
drop procedure if exists p_delete_employee;
drop procedure if exists p_delete_employee_project;
drop procedure if exists p_delete_project;
drop procedure if exists p_insert_client;
drop procedure if exists p_insert_employee;
drop procedure if exists p_insert_project;
drop procedure if exists p_update_client;
drop procedure if exists p_update_employee;
drop procedure if exists p_update_employee_project;
drop procedure if exists p_update_project;
drop procedure if exists p_return_editable_fields;
drop procedure if exists p_select_clients;
drop procedure if exists p_select_employees;
drop procedure if exists p_select_projects;
drop procedure if exists p_select_projects_employees;
drop procedure if exists p_return_assigned_project_employees;
drop procedure if exists p_insert_admin;
drop procedure if exists p_update_admin;
drop procedure if exists p_delete_admin;
drop procedure if exists p_select_admins;
drop procedure if exists p_update_totalSalaries;
drop procedure if exists p_select_unassigned_employees;


drop trigger if exists before_insert_clients;
drop trigger if exists before_insert_projects;
drop trigger if exists before_insert_employees;
drop trigger if exists before_update_employee_status;
drop trigger if exists before_delete_project;
drop trigger if exists before_delete_employee;
drop trigger if exists before_delete_client;



drop table if exists projects_employees cascade;
drop table if exists employees cascade;
drop table if exists projects cascade;
drop table if exists clients cascade;
drop table if exists admin cascade;






/*   --- CREATING TABLES ---   */
SET lc_time_names = 'fr_CA';

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
                          numberOfEmployees
                              INT CHECK (numberOfEmployees <= 5 AND numberOfEmployees > 0),
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
                                    hoursWorked DOUBLE DEFAULT 0,
                                    salary DOUBLE DEFAULT 0,
                                    FOREIGN KEY (employeeCode) REFERENCES employees(code),
                                    FOREIGN KEY (projectCode) REFERENCES projects(code)
);


CREATE TABLE admin (
    id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL
);




/*   --- INSERTING VALUES ---   */

INSERT INTO admin (username, password) VALUES ('admin', 'hashed_password_here');



INSERT INTO clients (id, fullName, address, phoneNumber, email)
VALUES
    (100, 'John Doe', '123 Main St', '(123) 456-7890', 'john.doe@example.com'),
    (101, 'Jane Smith', '456 Oak Ave', '(098) 765-4321', 'jane.smith@example.com'),
    (102, 'Robert Johnson', '789 Pine Rd', '(112) 233-4455', 'robert.j@example.com'),
    (103, 'Maria Garcia', '101 Maple Ln', '(334) 455-6677', 'maria.g@example.com'),
    (104, 'William Davis', '202 Cedar Blvd', '(556) 677-8899', 'william.d@example.com'),
    (105, 'Sophie Brown', '303 Walnut St', '(990) 011-2233', 'sophie.b@example.com'),
    (106, 'Michael White', '404 Birch Rd', '(667) 788-9900', 'michael.w@example.com'),
    (107, 'Eva Robinson', '505 Pine Ave', '(112) 233-4455', 'eva.r@example.com'),
    (108, 'Alex Turner', '606 Oak Ln', '(334) 455-6677', 'alex.t@example.com'),
    (109, 'Olivia Taylor', '707 Elm Blvd', '(556) 677-8899', 'olivia.t@example.com');

INSERT INTO projects (code, title, startDate, description, budget, numberOfEmployees, totalSalaries, clientId, status)
VALUES
    ('P001', 'Website Redesign', '2024-01-15', 'Redesigning the company website', 5000.00, 3, 3000.00, 100, 'En cours'),
    ('P002', 'Product Launch', '2024-02-01', 'Launching a new product line', 10000.00, 5, 5000.00, 101, 'En cours'),
    ('P003', 'Marketing Campaign', '2024-03-10', 'Promoting the brand through various channels', 8000.00, 4, 4000.00, 103, 'En cours'),
    ('P004', 'Sales Training', '2024-04-05', 'Training the sales team on new techniques', 6000.00, 2, 2000.00, 104, 'En cours'),
    ('P005', 'Inventory System Upgrade', '2024-05-20', 'Upgrading the inventory management system', 7000.00, 3, 3000.00, 105, 'En cours'),
    ('P006', 'Customer Support Improvement', '2024-06-15', 'Enhancing customer support services', 4000.00, 2, 2000.00, 106, 'En cours'),
    ('P007', 'Employee Wellness Program', '2024-07-01', 'Implementing a wellness program for employees', 3000.00, 1, 1000.00, 107, 'En cours'),
    ('P008', 'Mobile App Development', '2024-08-10', 'Developing a mobile application', 12000.00, 4, 4000.00, 108, 'En cours'),
    ('P009', 'Training Videos Production', '2024-09-05', 'Creating training videos for internal use', 5000.00, 2, 2000.00, 109, 'En cours'),
    ('P010', 'Community Outreach', '2024-10-20', 'Engaging with the local community', 2500.00, 1, 1000.00, 102, 'En cours'),
    ('P011', 'Community Outreach', '2024-10-20', 'Engaging with the local community', 2500.00, 1, 1000.00, 102, 'En cours'),
    ('P012', 'Community Outreach', '2024-10-20', 'Engaging with the local community', 2500.00, 1, 1000.00, 102, 'En cours');

INSERT INTO employees (code, firstName, lastName, birthday, email, address, hiringDate, hourlyRate, profilePicture, status)
VALUES
    ('E001', 'Alice', 'Johnson', '1990-05-20', 'alice.johnson@example.com', '789 Pine Rd', '2022-03-10', 20.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E002', 'Bob', 'Williams', '1985-12-15', 'bob.williams@example.com', '456 Elm St', '2021-02-28', 25.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E003', 'Charlie', 'Smith', '1992-08-30', 'charlie.smith@example.com', '101 Oak Ln', '2023-01-15', 18.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E004', 'Diana', 'Miller', '1988-04-05', 'diana.miller@example.com', '202 Maple Blvd', '2020-11-05', 22.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E005', 'Edward', 'Jones', '1995-06-22', 'edward.jones@example.com', '303 Cedar Ave', '2022-05-10', 23.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E006', 'Fiona', 'Brown', '1987-02-18', 'fiona.brown@example.com', '404 Birch Rd', '2021-09-01', 19.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E007', 'George', 'Clark', '1991-11-12', 'george.clark@example.com', '505 Pine St', '2022-07-15', 21.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E008', 'Helen', 'White', '1986-07-08', 'helen.white@example.com', '606 Elm Ave', '2020-12-20', 26.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E009', 'Ian', 'Martin', '1993-09-25', 'ian.martin@example.com', '707 Walnut Ln', '2023-02-05', 24.00, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier'),
    ('E010', 'Jessica', 'Wilson', '1989-03-14', 'jessica.wilson@example.com', '808 Cedar Blvd', '2022-04-18', 21.50, 'https://tr.rbxcdn.com/38c6edcb50633730ff4cf39ac8859840/420/420/Hat/Png', 'Journalier');

INSERT INTO projects_employees (projectCode, employeeCode, hoursWorked)
VALUES
    ('P001', 'E001', 40.0),
    ('P001', 'E006', 40.0),
    ('P001', 'E002', 32.5),
    ('P002', 'E003', 45.0),
    ('P002', 'E004', 28.0),
    ('P003', 'E005', 35.5);





/*   --- CREATING FUNCTIONS ---   */


/* -  - */
CREATE FUNCTION f_random_int(_min INT, _max INT)
    RETURNS INT
BEGIN
    RETURN FLOOR(RAND() * (_max - _min) + _min);
END;
-- Ex: SELECT f_random_int(10, 99);


/* - Returns current salary for an employee for it's assigned project based on hoursWorked & hourlyRate - */
CREATE FUNCTION f_calculate_salary_for_project (_employeeCode VARCHAR(20), _projectCode VARCHAR(20))
    RETURNS DOUBLE
BEGIN
    DECLARE salary DOUBLE;

    SELECT hoursWorked * hourlyRate INTO salary
    FROM projects_employees pe
             INNER JOIN employees e ON pe.employeeCode = e.code
    WHERE pe.employeeCode = _employeeCode AND pe.projectCode = _projectCode;

    RETURN salary;
END;
-- Ex: SELECT f_calculate_salary_for_project('E002', 'P001') AS salary

/* - Returns totalSalaries for given project - */
CREATE FUNCTION f_calculate_total_salaries(_projectCode VARCHAR(20))
    RETURNS DOUBLE
BEGIN
    DECLARE totalSalaries DOUBLE;

    SELECT SUM(salary) INTO totalSalaries
    FROM projects_employees
    WHERE projectCode = _projectCode;

    RETURN totalSalaries;
END;

/* - Checks if an employee is assigned to a project - */
CREATE FUNCTION f_is_assigned (_employeeCode VARCHAR(20))
    RETURNS BOOL
BEGIN
    DECLARE isAssigned BOOL;

    SELECT COUNT(employeeCode) INTO isAssigned
    FROM projects_employees
    WHERE employeeCode = _employeeCode;

    RETURN isAssigned;
END;
-- Ex: SELECT f_is_assigned('E001') AS isAssigned


/* - Checks if a client has a project - */
CREATE FUNCTION f_has_a_project (_id INT)
    RETURNS BOOL
BEGIN
    DECLARE hasProject BOOL;

    SELECT COUNT(clientId) INTO hasProject
    FROM projects
    WHERE clientId = _id;

    RETURN hasProject;
END;
-- Ex: SELECT f_has_a_project(101) AS hasAProject


/* - Returns how many projects a client has - */
CREATE FUNCTION f_number_of_projects (_id INT)
    RETURNS INT
BEGIN
    DECLARE numberOfProjects INT;

    SELECT COUNT(clientId) INTO numberOfProjects
    FROM projects
    WHERE clientId = _id;

    RETURN numberOfProjects;
END;
-- Ex: SELECT f_number_of_projects(100) AS numberOfProjects


/* - Checks if a given client id already exists - */
CREATE FUNCTION f_client_id_exists (_id INT)
    RETURNS BOOL
BEGIN
    DECLARE idExists BOOL;

    SELECT COUNT(*) INTO idExists
    FROM clients
    WHERE id = _id;

    RETURN idExists;
END;
-- Ex: SELECT f_client_id_exists(801) AS idExists


/* - Generates a unique id between min and max - */
CREATE FUNCTION f_generate_unique_client_id()
    RETURNS INT
BEGIN
    DECLARE uniqueId INT;
    DECLARE min INT;
    DECLARE max INT;
    SET min = 100;
    SET max = 999;

    REPEAT
        SET uniqueId = f_random_int(min, max);
    UNTIL f_client_id_exists(uniqueId) = 0 END REPEAT;

    RETURN uniqueId;
END;
-- Ex: SELECT f_generate_unique_client_id() AS uniqueClientId


/* - Generates an employee code - */
CREATE FUNCTION f_generate_employee_code(_lastName VARCHAR(255), _birthday DATE)
    RETURNS VARCHAR(20)
BEGIN
    DECLARE code VARCHAR(20);
    SET code = CONCAT(LEFT(_lastName, 2), '-', YEAR(_birthday), '-', f_random_int(10, 99));
    RETURN code;
END;
-- Ex: SELECT f_generate_employee_code('Johnson', '1990-05-20') AS employeeCode


/* - Generates a project code - */
CREATE FUNCTION f_generate_project_code(_clientId INT, _startDate DATE)
    RETURNS VARCHAR(20)
BEGIN
    DECLARE code VARCHAR(20);
    SET code = CONCAT(_clientId, '-', f_random_int(10, 99), '-', YEAR(_startDate));
    RETURN code;
END;
-- Ex: SELECT f_generate_project_code(104, '2024-02-01') AS employeeCode





/*   --- CREATING TRIGGERS ---   */


-- clients trigger
DELIMITER //
CREATE TRIGGER before_insert_clients
    BEFORE INSERT ON clients
    FOR EACH ROW

BEGIN
    DECLARE new_id INT;
    SET new_id = f_generate_unique_client_id();
    SET NEW.id = new_id;
END;
//
DELIMITER ;

-- projects trigger
DELIMITER //
CREATE TRIGGER before_insert_projects
    BEFORE INSERT ON projects
    FOR EACH ROW

BEGIN
    DECLARE new_code VARCHAR(20);
    SET new_code = f_generate_project_code(NEW.clientId, NEW.startDate);
    SET NEW.code = new_code;
END;
//
DELIMITER ;

-- employees trigger
DELIMITER //
CREATE TRIGGER before_insert_employees
    BEFORE INSERT ON employees
    FOR EACH ROW

BEGIN
    DECLARE new_code  VARCHAR(20);
    SET new_code = f_generate_employee_code(NEW.lastName, NEW.birthday);
    SET NEW.code = new_code;
END;
//
DELIMITER ;

DELIMITER //

CREATE TRIGGER before_update_employee_status
    BEFORE UPDATE ON employees
    FOR EACH ROW
BEGIN
    IF NEW.status <> OLD.status THEN
        IF DATEDIFF(NOW(), NEW.hiringDate) >= 1095 THEN
            SET NEW.status = 'Permanent';
        ELSE
            SET NEW.status = 'Journalier';
        END IF;
    END IF;
END //

DELIMITER ;


DELIMITER //
CREATE TRIGGER before_delete_project
    BEFORE DELETE ON projects
    FOR EACH ROW
BEGIN
    DELETE FROM projects_employees WHERE projectCode = OLD.code;
END //
DELIMITER ;



DELIMITER //
CREATE TRIGGER before_delete_employee
    before DELETE ON employees
    FOR EACH ROW
BEGIN
    DELETE FROM projects_employees WHERE employeeCode = OLD.code;
END //
DELIMITER ;



DELIMITER //
CREATE TRIGGER before_delete_client
    before DELETE ON clients
    FOR EACH ROW
BEGIN
    DELETE FROM projects WHERE clientId = OLD.id;
END //
DELIMITER ;



/*   --- CREATING VIEWS ---   */

CREATE VIEW v_unassigned_employees AS
SELECT *
FROM employees e
WHERE !f_is_assigned(code);
-- Ex: SELECT * FROM v_unassigned_employees

CREATE VIEW v_clients_with_projects AS
SELECT *
FROM clients c
WHERE f_has_a_project(id);
-- Ex: SELECT * FROM v_clients_with_projects

CREATE VIEW v_projects AS
SELECT
    p.code,
    p.title,
    c.fullName,
    DATE_FORMAT(p.startDate, '%d %M %Y') AS startDate,
    p.budget
FROM projects p
         INNER JOIN clients c on p.clientId = c.id
ORDER BY p.startDate;
-- Ex: SELECT * FROM v_projects

CREATE VIEW v_employees_with_projects AS
SELECT e.*, COUNT(pe.projectCode) AS numberOfProjects
FROM employees e
         LEFT JOIN projects_employees pe ON e.code = pe.employeeCode
GROUP BY e.code;
-- Ex: SELECT * FROM v_employees_with_projects

CREATE VIEW v_clients_without_projects AS
SELECT *
FROM clients c
WHERE NOT f_has_a_project(c.id);
-- Ex: SELECT * FROM v_clients_without_projects






/*   --- CREATING PROCEDURES ---   */

/* Procedure to insert data into the 'clients' table */
DELIMITER //
CREATE PROCEDURE p_insert_client(
    IN _fullName VARCHAR(255),
    IN _address VARCHAR(255),
    IN _phoneNumber VARCHAR(20),
    IN _email VARCHAR(255)
)
BEGIN
    INSERT INTO clients (fullName, address, phoneNumber, email)
    VALUES (_fullName, _address, _phoneNumber, _email);
END //
DELIMITER ;

/* Procedure to insert data into the 'projects' table */
DELIMITER //
CREATE PROCEDURE p_insert_project(
    IN _title VARCHAR(255),
    IN _startDate DATE,
    IN _description TEXT,
    IN _budget DOUBLE,
    IN _numberOfEmployees INT,
    IN _totalSalaries DOUBLE,
    IN _clientId INT,
    IN _status VARCHAR(20)
)
BEGIN
    DECLARE EXIT HANDLER FOR 1452
        BEGIN
            SELECT 'Cannot create a project with a non-existing client';
        end ;
    IF (_numberOfEmployees < 0 || _numberOfEmployees > 5) THEN
        SIGNAL SQLSTATE '45000' SET message_text="Invalid number of employees";
    end if ;


    INSERT INTO projects (title, startDate, description, budget, numberOfEmployees, totalSalaries, clientId, status)
    VALUES (_title, _startDate, _description, _budget, _numberOfEmployees, _totalSalaries, _clientId, _status);
END //
DELIMITER ;
-- CALL p_insert_project('test', '2023-08-14', 'baa', 1200, -1, 60000, 100, 'aaa');


/* Procedure to insert data into the 'employees' table */
DELIMITER //
CREATE PROCEDURE p_insert_employee(
    IN _firstName VARCHAR(255),
    IN _lastName VARCHAR(255),
    IN _birthday DATE,
    IN _email VARCHAR(255),
    IN _address VARCHAR(255),
    IN _hiringDate DATE,
    IN _hourlyRate DOUBLE,
    IN _profilePicture VARCHAR(255),
    IN _status VARCHAR(20)
)
BEGIN
    IF (_hourlyRate < 15) THEN
       SIGNAL SQLSTATE '45001' SET message_text = "Invalid hourly rate";
    end if ;
    IF (_status != 'Journalier' && _status != 'Permanent') THEN
        SIGNAL SQLSTATE '45000' SET message_text="Invalid status";
    end if ;

    INSERT INTO employees (firstName, lastName, birthday, email, address, hiringDate, hourlyRate, profilePicture, status)
    VALUES (_firstName, _lastName, _birthday, _email, _address, _hiringDate, _hourlyRate, _profilePicture, _status);
END //
DELIMITER ;
-- CALL p_insert_employee('a', 'b', '2002-02-01', 'asd@asd.ca', '123 ra asd', '2012-11-01', 18, 'asdasdasdas.ca', 'aa');


-- procedure add admin
DELIMITER //
CREATE PROCEDURE p_insert_admin(
    IN _username VARCHAR(50),
    IN _password VARCHAR(255)
)
BEGIN
    INSERT INTO admin (username, password)
    VALUES (_username, _password);
END //
DELIMITER ;



/* Procedure to assign employees to projects */
DELIMITER //
CREATE PROCEDURE p_assign_employee_to_project(
    IN _projectCode VARCHAR(20),
    IN _employeeCode VARCHAR(20),
    IN _hoursWorked DOUBLE
)
BEGIN
    IF (_hoursWorked < 0) THEN
        SIGNAL SQLSTATE '45000' SET message_text="Invalid hours worked";
    end if ;
    IF (f_is_assigned(_employeeCode)) THEN
        SIGNAL SQLSTATE '45001' SET message_text="Employee already assigned to a project";
    end if ;

    INSERT INTO projects_employees (projectCode, employeeCode, hoursWorked)
    VALUES (_projectCode, _employeeCode, _hoursWorked);
END //
DELIMITER ;


/* Procedure to update data in the 'clients' table */
DELIMITER //
CREATE PROCEDURE p_update_client(
    IN _clientID INT,
    IN _fullName VARCHAR(255),
    IN _address VARCHAR(255),
    IN _phoneNumber VARCHAR(20),
    IN _email VARCHAR(255)
)
BEGIN
    UPDATE clients
    SET fullName = _fullName, address = _address, phoneNumber = _phoneNumber, email = _email
    WHERE id = _clientID;
END //
DELIMITER ;

/* Procedure to update data in the 'projects' table */
DELIMITER //
CREATE PROCEDURE p_update_project(
    IN _projectCode VARCHAR(20),
    IN _title VARCHAR(255),
    IN _startDate DATE,
    IN _description TEXT,
    IN _budget DOUBLE,
    IN _numberOfEmployees INT,
    IN _totalSalaries DOUBLE,
    IN _clientId INT,
    IN _status VARCHAR(20)
)
BEGIN
    UPDATE projects
    SET title = _title, startDate = _startDate, description = _description, budget = _budget,
        numberOfEmployees = _numberOfEmployees, totalSalaries = _totalSalaries, clientId = _clientId, status = _status
    WHERE code = _projectCode;
END //
DELIMITER ;

/* Procedure to update data in the 'employees' table */
DELIMITER //
CREATE PROCEDURE p_update_employee(
    IN _employeeCode VARCHAR(20),
    IN _firstName VARCHAR(255),
    IN _lastName VARCHAR(255),
    IN _birthday DATE,
    IN _email VARCHAR(255),
    IN _address VARCHAR(255),
    IN _hiringDate DATE,
    IN _hourlyRate DOUBLE,
    IN _profilePicture VARCHAR(255),
    IN _status VARCHAR(20)
)
BEGIN
    UPDATE employees
    SET firstName = _firstName, lastName = _lastName, birthday = _birthday, email = _email,
        address = _address, hiringDate = _hiringDate, hourlyRate = _hourlyRate, profilePicture = _profilePicture, status = _status
    WHERE code = _employeeCode;
END //
DELIMITER ;

-- procedure modify admin
DELIMITER //
CREATE PROCEDURE p_update_admin(
    IN _adminID INT,
    IN _newUsername VARCHAR(50),
    IN _newPassword VARCHAR(255)
)
BEGIN
    UPDATE admin
    SET username = _newUsername, password = _newPassword
    WHERE id = _adminID;
END //
DELIMITER ;



/* Update Project totalSalaries */
DELIMITER //
CREATE PROCEDURE p_update_totalSalaries(
    IN _projectCode VARCHAR(20)
)
BEGIN
    UPDATE projects
    SET totalSalaries = f_calculate_total_salaries(_projectCode)
    WHERE code = _projectCode;
END //
DELIMITER ;

/* Procedure to update data in the 'projects_employees' table (for employee-to-project association) */
DELIMITER //
CREATE PROCEDURE p_update_employee_project(
    IN _projectCode VARCHAR(20),
    IN _employeeCode VARCHAR(20),
    IN _hoursWorked DOUBLE
)
BEGIN
    UPDATE projects_employees
    SET hoursWorked = _hoursWorked,
    salary = f_calculate_salary_for_project(_employeeCode, _projectCode)
    WHERE projectCode = _projectCode AND employeeCode = _employeeCode;
    CALL p_update_totalSalaries(_projectCode);
END //
DELIMITER ;

/* Procedure to delete data from the 'clients' table */
DELIMITER //
CREATE PROCEDURE p_delete_client(
    IN _clientID INT
)
BEGIN
    DELETE FROM clients WHERE id = _clientID;
END //
DELIMITER ;

/* Procedure to delete data from the 'projects' table */
DELIMITER //
CREATE PROCEDURE p_delete_project(
    IN _projectCode VARCHAR(20)
)
BEGIN
    DELETE FROM projects WHERE code = _projectCode;
END //
DELIMITER ;

/* Procedure to delete data from the 'employees' table */
DELIMITER //
CREATE PROCEDURE p_delete_employee(
    IN _employeeCode VARCHAR(20)
)
BEGIN
    DELETE FROM employees WHERE code = _employeeCode;
END //
DELIMITER ;

-- delete admin
DELIMITER //
CREATE PROCEDURE p_delete_admin(
    IN _adminID INT
)
BEGIN
    DELETE FROM admin WHERE id = _adminID;
END //
DELIMITER ;


/* Procedure to delete data from the 'projects_employees' table (employee-to-project association) */
DELIMITER //
CREATE PROCEDURE p_delete_employee_project(
    IN _projectCode VARCHAR(20),
    IN _employeeCode VARCHAR(20)
)
BEGIN
    DELETE FROM projects_employees WHERE projectCode = _projectCode AND employeeCode = _employeeCode;
END //
DELIMITER ;

/* Procédure qui retourne tous les champs editable d'un employé passé en paramètre */
DELIMITER //

DELIMITER //

CREATE PROCEDURE p_return_editable_fields(
    IN _employeeCode VARCHAR(20)
)
BEGIN
    SELECT
        firstName,
        lastName,
        email,
        address,
        hourlyRate,
        profilePicture,
        status
    FROM
        employees
    WHERE
            code = _employeeCode;
END //

DELIMITER ;


/* Retourne unassigned employees */
DELIMITER //

CREATE PROCEDURE p_select_unassigned_employees()
BEGIN
    SELECT *
    FROM employees e
    WHERE NOT EXISTS (
        SELECT 1
        FROM projects_employees pe
        WHERE pe.employeeCode = e.code
    );
END //

DELIMITER ;
-- CALL p_select_unassigned_employees();



DELIMITER //

CREATE PROCEDURE p_return_assigned_project_employees(
    IN _projectCode VARCHAR(20)
)
BEGIN
    SELECT
        employeeCode
    FROM
        projects_employees
    WHERE
            projectCode = _projectCode;
END //

DELIMITER ;



DELIMITER //

/* Procedure pour sélectionner tous les enregistrements de la table 'clients' */
CREATE PROCEDURE p_select_clients()
BEGIN
    SELECT * FROM clients;
END //

/* Procedure pour sélectionner tous les enregistrements de la table 'projects' */
CREATE PROCEDURE p_select_projects()
BEGIN
    SELECT * FROM projects;
END //

/* Procedure pour sélectionner tous les enregistrements de la table 'employees' */
CREATE PROCEDURE p_select_employees()
BEGIN
    SELECT * FROM employees;
END //

/* Procedure pour sélectionner tous les enregistrements de la table 'projects_employees' */
CREATE PROCEDURE p_select_projects_employees()
BEGIN
    SELECT * FROM projects_employees;
END //

/* Select admins */
CREATE PROCEDURE p_select_admins()
BEGIN
    SELECT * FROM admin;
END //

DELIMITER ;
