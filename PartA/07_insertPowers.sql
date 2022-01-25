INSERT INTO Power
 (Name, Description)
 VALUES
 ('Wealth', 'Hero is like a fictional Jeff Bezos');

INSERT INTO Power
 (Name, Description)
 VALUES
 ('Super strength', 'Hero is super strong and fast')

INSERT INTO Power
 (Name, Description)
 VALUES
 ('Spider powers', 'Hero has abilities like a spider');

INSERT INTO Power
 (Name, Description)
 VALUES
 ('Lasso of Truth', 'Hero has magic lasso that forces people to tell the truth.')

 INSERT INTO SuperheroPowers
  (SuperheroId, PowerId)
  VALUES
  (
  (
   SELECT Id FROM Superhero
   WHERE Alias = 'Spiderman'
  ),
  (
   SELECT Id FROM Power
   WHERE Name = 'Spider powers'
  )
  );

INSERT INTO SuperheroPowers
  (SuperheroId, PowerId)
  VALUES
  (
  (
   SELECT Id FROM Superhero
   WHERE Alias = 'Spiderman'
  ),
  (
   SELECT Id
   FROM Power
   WHERE Name = 'Super strength'
  )
  );

INSERT INTO SuperheroPowers
  (SuperheroId, PowerId)
  VALUES
  (
  (
   SELECT Id FROM Superhero
   WHERE Alias = 'Wonder Woman'
  ),
  (
   SELECT Id
   FROM Power
   WHERE Name = 'Super strength'
  )
  );

  INSERT INTO SuperheroPowers
  (SuperheroId, PowerId)
  VALUES
  (
  (
   SELECT Id FROM Superhero
   WHERE Alias = 'Batman'
  ),
  (
   SELECT Id FROM Power
   WHERE Name = 'Wealth'
  )
  );