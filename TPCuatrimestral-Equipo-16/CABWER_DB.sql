use master
go
Create Database CabWeb_DB
go
use CabWeb_DB
CREATE TABLE Credenciales
(
    Id INT PRIMARY KEY IDENTITY(1,1)
    Nombre NVARCHAR(255),
    Apellido NVARCHAR(255),
    FechaNacimiento DATETIME,
    FechaRegistro DATETIME,
    CorreoElectronico NVARCHAR(255),
    HashContraseña NVARCHAR(255),
    Sal NVARCHAR(255),
    Sexo CHAR(1)
);