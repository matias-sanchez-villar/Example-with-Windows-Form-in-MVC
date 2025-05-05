# MVC Project - Windows Forms (C#) and SQL Server

This is a project developed using the MVC architecture pattern in Windows Forms with C# and SQL Server. The project is designed to manage information about people and requires a database to function properly.

## Requirements

Before you begin, make sure you have the following:

- **SQL Server** installed and running.
- **Visual Studio** (or any compatible C# IDE).
- **.NET Framework** installed.
- Access to a SQL Server instance where the database `EjemploBD` will be created.

## Installation Instructions

1. **Clone the repository:**
   Clone this repository to your local machine using Git.

   ```bash
   git clone https://github.com/your_username/your_repository.git


## Create the database

-- Create the database
CREATE DATABASE EjemploBD;

-- Use the database
USE EjemploBD;

-- Create the Personas table
CREATE TABLE dbo.Personas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50)
);

--insert into
