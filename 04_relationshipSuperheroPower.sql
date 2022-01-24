CREATE TABLE SuperheroPowers (
 SuperheroId int NOT NULL,
 PowerId int NOT NULL,
 PRIMARY KEY(SuperheroId, PowerId),
);

ALTER TABLE SuperheroPowers
ADD FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);

ALTER TABLE SuperheroPowers
ADD FOREIGN KEY (PowerId) REFERENCES Power(Id);