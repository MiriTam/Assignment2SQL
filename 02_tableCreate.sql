CREATE TABLE Superhero (
 Id int NOT NULL,
 Name nvarchar(50),
 Alias nvarchar(50),
 Origin nvarchar(50),
 PRIMARY KEY(Id)
);

CREATE TABLE Assistant (
 Id int NOT NULL,
 Name nvarchar(50),
 PRIMARY KEY(Id)
);

CREATE TABLE Power (
 Id int NOT NULL,
 Name nvarchar(50),
 Description nvarchar(200),
 PRIMARY KEY(Id)
);