CREATE DATABASE AirJetbWeb_DB
use AirJetbWeb_DB
GO
CREATE TABLE Persons
(       
    IdPerson Bigint PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(60),
    Apellido NVARCHAR(60),
    Sexo CHAR(1) NOT NULL CHECK(Sexo='M'OR Sexo='F' OR Sexo='X'),
    DNI NVARCHAR(8) UNIQUE,
    FechaNacimiento DATETIME not null,
    Domicilio NVARCHAR(200),
    --CodPostal  falta  ver si va y desarrollar tabla
    Celular NVARCHAR(30) UNIQUE
)
GO
INSERT INTO Persons (Nombre, Apellido, Sexo, DNI, FechaNacimiento, FechaRegistro, Domicilio, Celular)
VALUES ('Juan', 'Perez', 'M', '34567890', '1980-05-15', '2023-10-25', '123 Main St, Ciudad', '5551234567'),
       ('Maria', 'Gonzalez', 'F', '98765432', '1985-03-20','2023-09-25', '456 Elm St, Ciudad', '5559876543'),
       ('Luis', 'Martinez', 'M', '45678901', '1990-08-10', '2023-08-25','789 Oak St, Ciudad', '5557890123'),
       ('Ana', 'Lopez', 'F', '34597801', '1988-12-05','2023-07-25', '567 Pine St, Ciudad', '5552345678'),
       ('Carlos', 'Rodriguez', 'M', '46789012', '1982-06-30', '2023-04-25', '890 Cedar St, Ciudad', '5553456789')
GO
CREATE TABLE Roles
(
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    Rol NVARCHAR(30) NOT NULL
)
GO
INSERT INTO Roles (Rol)
VALUES ('Client'),
       ('Employee'),
       ('Manager')
GO
CREATE TABLE Credentials
(  
    Id Bigint PRIMARY key NOT NULL IDENTITY(1,1),
    IdPerson Bigint FOREIGN KEY REFERENCES Persons(IdPerson) unique,
    IdRol INT FOREIGN Key REFERENCES Roles(IdRol),
    Email NVARCHAR(255) UNIQUE NOT NULL,
    --Usuario NVARCHAR(255), vemos....
    HashContraseña NVARCHAR(255),
    Sal NVARCHAR(255)
)
GO
INSERT INTO Credentials (IdPerson, IdRol, Email, HashContraseña, Sal)
VALUES 
(1,1, 'usuario1@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(2,1, 'usuario2@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(3,2, 'usuario3@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(4,2, 'usuario4@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(5,3, 'usuario5@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT')
GO
CREATE TABLE Employees(
   IdEmployee BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
   IdCredencial Bigint NOT NULL FOREIGN KEY REFERENCES Credentials(Id),
   JoinDate  DATE NOT NULL,
   Salary MONEY NOT NULL DEFAULT(20000) CHECK (Salary>0),
   Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Employees (IdCredencial,Salary, JoinDate)
VALUES 
(3, 30000, GETDATE()),
(4, 40000, GETDATE())
---(5, 60000, GETDATE())todavia no
GO
CREATE TABLE Client(
   IdClient BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
   IdCredencial Bigint NOT NULL FOREIGN KEY REFERENCES Credentials(Id),
   JoinDate  DATE NOT NULL,
   Estado BIT NOT NULL DEFAULT(1),
)
GO
INSERT INTO Client(IdCredencial, JoinDate)
VALUES 
(1, GETDATE()),
(2, GETDATE())