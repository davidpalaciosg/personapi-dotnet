-- Eliminaci�n de las tablas si existen
IF OBJECT_ID('Estudios', 'U') IS NOT NULL
    DROP TABLE Estudios;

IF OBJECT_ID('Telefono', 'U') IS NOT NULL
    DROP TABLE Telefono;

IF OBJECT_ID('Persona', 'U') IS NOT NULL
    DROP TABLE Persona;

IF OBJECT_ID('Profesion', 'U') IS NOT NULL
    DROP TABLE Profesion;

-- Creacion de bases de datos
CREATE DATABASE persona_db;

-- Crear tablas en la base de datos especifico

USE persona_db;
GO

-- Creaci�n de la tabla Profesion
CREATE TABLE Profesion (
  id INT PRIMARY KEY,
  nom VARCHAR(90),
  des TEXT
);

-- Creaci�n del �ndice en la tabla Profesion
CREATE INDEX idx_Profesion_id ON Profesion (id);

-- Creaci�n de la tabla Persona
CREATE TABLE Persona (
  cc INT PRIMARY KEY,
  nombre VARCHAR(45),
  apellido VARCHAR(45),
  genero CHAR(1),
  edad INT
);

-- Creaci�n del �ndice en la tabla Persona
CREATE INDEX idx_Persona_cc ON Persona (cc);

-- Creaci�n de la tabla Telefono
CREATE TABLE Telefono (
  num VARCHAR(15) PRIMARY KEY,
  oper VARCHAR(45),
  duenio INT,
  FOREIGN KEY (duenio) REFERENCES Persona(cc)
);

-- Creaci�n del �ndice en la tabla Telefono
CREATE INDEX idx_Telefono_num ON Telefono (num);

-- Creaci�n de la tabla Estudios
CREATE TABLE Estudios (
  id_prof INT,
  cc_per INT,
  fecha DATE,
  univer VARCHAR(50),
  PRIMARY KEY(id_prof, cc_per),
  FOREIGN KEY (id_prof) REFERENCES Profesion(id),
  FOREIGN KEY (cc_per) REFERENCES Persona(cc)
);

-- Creaci�n de los �ndices en la tabla Estudios
CREATE INDEX idx_Estudios_id_prof ON Estudios (id_prof);
CREATE INDEX idx_Estudios_cc_per ON Estudios (cc_per);
