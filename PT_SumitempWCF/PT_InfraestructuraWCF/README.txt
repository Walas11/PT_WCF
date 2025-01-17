*** INSTRUCCIONES ***

// CREACIÓN DE LA BASE DE DATOS EN SQL SERVER //

-- --------------------------------------------------------------------------------------------------------------------------------------------- --

CREATE DATABASE PT_SumitempWCF

GO
USE PT_SumitempWCF

GO
CREATE TABLE Usuario(
	DocumentoIdentidad VARCHAR(50) NOT NULL PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Email2 VARCHAR(255),
    Telefono VARCHAR(20) NOT NULL,
    Telefono2 VARCHAR(20),
    Direccion VARCHAR(255) NOT NULL,
    Direccion2 VARCHAR(255)
);

Insert into Usuario (DocumentoIdentidad,Nombres,Apellidos,FechaNacimiento,Email,Email2,Telefono,Telefono2,Direccion,Direccion2)
Values ('1014304449SAL','Sebastian','Acero Leon','1999-03-24T00:00:00','sebastianaceroleon@outlook.com',null,'3192106183',null,'Cra 107 c 70 76',null)

select * from Usuario

-- --------------------------------------------------------------------------------------------------------------------------------------------- --

// CONFIGURAR EN EL APPSETTINGS.JSON LA CADENA DE CONEXION DE LA MAQUINA Y USUARIO //

-- ------------------------------------------------------------------------------------------------------- --

// SI CUENTA CON LOGIN
"Server=XXX;Database=PT_SumitempWCF;User Id=XXX;Password=XXX.;TrustServerCertificate=true;"

// SI ES WINDOWS AUTHENTICATION
"Server=PC9355\\MSSQLSERVER01;Database=PT_SumitempWCF;Trusted_Connection=True;TrustServerCertificate=true;"

-- ------------------------------------------------------------------------------------------------------- --


// CONFIGURAR EN EL APPSETTINGS.JSON LA CADENA DE CONEXION DE LA MAQUINA Y USUARIO //

-- ------------------------------------------------------------------------------------------------------- --

dotnet add package CoreWCF
dotnet add package CoreWCF.Http
dotnet add package CoreWCF.Primitives
dotnet add package CoreWCF.ConfigurationManager
System.ServiceModel.Http

-- ------------------------------------------------------------------------------------------------------- --