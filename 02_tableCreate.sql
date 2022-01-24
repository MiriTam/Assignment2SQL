CREATE TABLE Superhero (
 Id int IDENTITY(1,1) PRIMARY KEY,
 Name nvarchar(50),
 Alias nvarchar(50),
 Origin nvarchar(50),
);

CREATE TABLE Assistant (
 Id int IDENTITY(1,1) PRIMARY KEY,
 Name nvarchar(50),
);

CREATE TABLE Power (
 Id int IDENTITY(1,1) PRIMARY KEY,
 Name nvarchar(50),
 Description nvarchar(200),
);