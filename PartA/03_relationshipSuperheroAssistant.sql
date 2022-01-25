ALTER TABLE Assistant
 ADD SuperheroId int NOT NULL

ALTER TABLE Assistant
 ADD FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);