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
    Celular NVARCHAR(30) UNIQUE
)
GO
INSERT INTO Persons (Nombre, Apellido, Sexo, DNI, FechaNacimiento, Domicilio, Celular)
VALUES ('Juan', 'Perez', 'M', '34567890', '1980-05-15', '123 Main St, Ciudad', '5551234567'),
       ('Maria', 'Gonzalez', 'F', '98765432', '1985-03-20', '456 Elm St, Ciudad', '5559876543'),
       ('Luis', 'Martinez', 'M', '45678901', '1990-08-10', '789 Oak St, Ciudad', '5557890123'),
       ('Ana', 'Lopez', 'F', '34597801', '1988-12-05', '567 Pine St, Ciudad', '5552345678'),
       ('Carlos', 'Rodriguez', 'M', '46789012', '1982-06-30',  '890 Cedar St, Ciudad', '5553456789'),
       ('Maxi', 'Programa', 'M', '46711112', '1982-06-30',  '890 Cedar St, Ciudad', '5500000789'),
       ('Luis', 'Pasajero', 'M', '45111111', '1990-08-10', '789 Oak St, Ciudad', '5557898823'),
       ('Ana', 'Pasajero', 'F', '34117801', '1988-12-05', '567 Pine St, Ciudad', '5556645678'),
       ('Carlos', 'Pasajero', 'M', '46781112', '1982-06-30',  '890 Cedar St, Ciudad', '5113456789')
GO
CREATE TABLE Roles
(
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    Rol NVARCHAR(30) NOT NULL
)
GO
INSERT INTO Roles (Rol)
VALUES ('Client'),
       ('Employee')
GO
CREATE TABLE Credentials
(  
    Id Bigint PRIMARY key NOT NULL IDENTITY(1,1),
    IdPerson Bigint FOREIGN KEY REFERENCES Persons(IdPerson) unique,
    IdRol INT FOREIGN Key REFERENCES Roles(IdRol),
    Email NVARCHAR(255) UNIQUE NOT NULL,
    HashContraseña NVARCHAR(255),
    Sal NVARCHAR(255),
    ImageProfile  NVARCHAR(500)
)
GO
INSERT INTO Credentials (IdPerson, IdRol, Email, HashContraseña, Sal)
VALUES 
(1,1, 'usuario1@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(2,1, 'usuario2@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(3,2, 'usuario3@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(4,2, 'usuario4@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(5,2, 'usuario5@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT'),
(6,2, 'usuario6@example.com', '/RplRpd+ZqaWdfrDkO1FJJiz7eu4HBwTSSyAZQ7nWSg=', 'd70yJWTixT')
GO
CREATE TABLE Positions(
     IdPosition TINYINT PRIMARY KEY IDENTITY(1,1),
     Position NVARCHAR(30) NOT NULL
)
GO
INSERT INTO Positions(Position)
VALUES ('HR Manager'),
       ('Flight Operations Manager'),
       ('Pilot'),
       ('Flight Attendant')
GO
CREATE TABLE Employees(
   IdEmployee BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
   IdCredencial Bigint NOT NULL FOREIGN KEY REFERENCES Credentials(Id),
   IdPosition TINYINT NOT NULL FOREIGN KEY REFERENCES Positions(IdPosition),
   JoinDate  DATE NOT NULL,
   Salary MONEY NOT NULL DEFAULT(20000) CHECK (Salary>0),
   Available BIT NOT NULL DEFAULT(1),
   Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Employees (IdCredencial,IdPosition, Salary, JoinDate)
VALUES 
(3, 2, 30000, GETDATE()),
(4, 3, 40000, GETDATE()),
(5, 4, 30000, GETDATE()),
(6, 4, 40000, GETDATE())
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
GO
CREATE TABLE Provincias(
   IdProvincia BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
   NombreProvincia varchar(250),
   Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Provincias(NombreProvincia)
VALUES 
('Buenos Aires'),
('Córdoba'),
('Mendoza'),
('Río Negro'),
('Salta')
GO
CREATE TABLE Ciudades(
   IdCiudad BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
   IdProvincia Bigint NOT NULL FOREIGN KEY REFERENCES Provincias(IdProvincia),
   NombreCiudad varchar(250) NOT NULL,
   Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Ciudades(IdProvincia, NombreCiudad)
VALUES 
(1, 'Ciudad de Buenos Aires'),
(1, 'Ezeiza'),
(2, 'Ciudad de Córdoba'),
(3, 'Ciudad de Mendoza'),
(4, 'San Carlos de Bariloche'),
(5, 'Ciudad de Salta')
GO
CREATE TABLE Aeropuertos(
   CodigoIATA VARCHAR(6) NOT NULL PRIMARY KEY,
   IdCiudad Bigint NOT NULL FOREIGN KEY REFERENCES Ciudades(IdCiudad),
   NombreAeropuerto varchar(250) NOT NULL,
   Direccion varchar(250) NOT NULL,
   Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Aeropuertos(CodigoIATA,IdCiudad,NombreAeropuerto,Direccion)
VALUES 
('AEP', 1, 'Aeroparque Jorge Newbery','Av. Costanera Rafael Obligado s/n'),
('EZE', 1, 'Aeropuerto Internacional Ministro Pistarini','AU Tte. Gral. Pablo Riccheri Km 33'),
('COR', 2, 'Aeropuerto Internacional Ingeniero Aeronáutico Ambrosio Taravella','Av. La Voz del Interior 8500'),
('MDZ', 3, 'Aeropuerto Internacional Gobernador Francisco Gabrielli','Acceso A Aeropuerto Internacional Gabrielli F. J., Las Heras'),
('BRC', 4, 'Aeropuerto Internacional Teniente Luis Candelaria','RP80 S/N'),
('SLA', 5, 'Aeropuerto Internacional de Salta Martín Miguel de Güemes','RN51 5')
GO
CREATE TABLE Booking(
    IdBooking BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdClient  BIGINT NOT NULL FOREIGN KEY REFERENCES Client(IdClient),
    IdOrigen  BIGINT NOT NULL FOREIGN KEY REFERENCES Ciudades(IdCiudad),
    IdDestino  BIGINT NOT NULL FOREIGN KEY REFERENCES Ciudades(IdCiudad),
    SolicitudDate DATETIME NOT NULL DEFAULT(GETDATE()),
    DateBooking DATE NOT NULL CHECK(DateBooking > DATEADD(day, 5, GETDATE())),
    Passengers SMALLINT NOT NULL CHECK(Passengers BETWEEN 1 AND 12),
    StateBooking VARCHAR(12) NOT NULL DEFAULT('En proceso') CHECK(StateBooking IN('En proceso','Aprobada ','Cancelada')),
    Estado BIT NOT NULL DEFAULT(1),
    CHECK(IdOrigen <> IdDestino)
)
INSERT INTO Booking(IdClient,IdOrigen,IdDestino,SolicitudDate,DateBooking,Passengers,StateBooking)
VALUES
(1,1,4,GETDATE(),'2030-11-06',7,'Aprobada')
GO
CREATE TABLE Aircraft(
    IdAircraft INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Model VARCHAR(100) NOT NULL,
    PassengerCapacity TINYINT NOT NULL,
    MinimumCrew TINYINT NOT NULL,
    FuelCapacity DECIMAL(10,2) NOT NULL,
    FlightRange DECIMAL(10,2) NOT NULL,
    YearOfManufacture DATETIME NOT NULL,
    Available BIT NOT NULL DEFAULT(1),
    Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Aircraft (Model, PassengerCapacity, MinimumCrew, FuelCapacity, FlightRange, YearOfManufacture, Available, Estado)
VALUES
('Gulfstream G650', 18, 2, 50000.00, 8000.00, '2016-02-01', 1, 1),
('Bombardier Challenger 350', 10, 2, 20000.50, 3500.75, '2017-08-10', 1, 1),
('Cessna Citation X', 8, 2, 15000.25, 3500.50, '2014-11-15', 1, 1),
('Embraer Phenom 300', 7, 1, 11000.75, 2000.25, '2019-05-20', 1, 1),
('Dassault Falcon 7X', 14, 3, 65000.50, 5600.00, '2015-04-05', 1, 1)
GO
CREATE TABLE Flight(   
   IdFlight INT NOT NULL PRIMARY KEY IDENTITY(1,1),
   IdBooking BIGINT NOT NULL FOREIGN KEY REFERENCES Booking(IdBooking),
   IdAircraft INT FOREIGN KEY REFERENCES Aircraft(IdAircraft),
   FlightState VARCHAR(15) NOT NULL DEFAULT('En proceso') CHECK(FlightState  IN('En proceso','Finalizado ','Cancelado')),
   Estado BIT NOT NULL DEFAULT(1)
)
INSERT INTO Flight(IdBooking,IdAircraft)
VALUES 
(1,5)    
GO
CREATE TABLE FlightCrew (
    IdFlight INT NOT NULL FOREIGN KEY REFERENCES Flight(IdFlight),
    IdEmployee BIGINT NOT NULL FOREIGN KEY REFERENCES Employees(IdEmployee),
    Estado BIT NOT NULL DEFAULT(1),
    PRIMARY KEY(IdFlight, IdEmployee)
)
GO
INSERT INTO FlightCrew(IdFlight,IdEmployee)
VALUES
(1,2),
(1,3)
GO
CREATE TABLE FlightPassengers(
   IdPerson Bigint FOREIGN KEY REFERENCES Persons(IdPerson),
   IdFlight INT NOT NULL FOREIGN KEY REFERENCES Flight(IdFlight),
   Estado BIT NOT NULL DEFAULT(1),
   PRIMARY KEY(IdFlight, IdPerson) 
)
GO
INSERT INTO FlightPassengers(IdFlight,IdPerson)
VALUES
(1,7),
(1,8),
(1,9)
GO
CREATE TABLE Itinerary(   
   IdItinerary INT NOT NULL PRIMARY KEY IDENTITY(1,1),
   IdFlight INT NOT NULL FOREIGN KEY REFERENCES Flight(IdFlight),
   FlightArrival DATETIME NOT NULL,
   FlightDeparture DATETIME NOT NULL,
   CodIATAArrival VARCHAR(6) NOT NULL FOREIGN KEY REFERENCES Aeropuertos(CodigoIATA),
   CodIATADeparture VARCHAR(6) NOT NULL FOREIGN KEY REFERENCES Aeropuertos(CodigoIATA),
   ETA INT NOT NULL,
   flightHours TIME NOT NULL,
   updateTrip varchar(500),
   Estado BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Itinerary(IdFlight,FlightArrival,FlightDeparture,CodIATAArrival,CodIATADeparture,ETA,flightHours)
VALUES
(1,GETDATE(),GETDATE(),'AEP','BRC',5,'02:30:00')

